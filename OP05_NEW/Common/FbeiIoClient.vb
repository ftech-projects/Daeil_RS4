' FBEI-3200N-TS (32DI) + FBEI-0032N-TS (32DO) EtherNet/IP 클라이언트
' EEIP.NET (Sres.Net.EEIP) 라이브러리 사용
' 매뉴얼: docs/Manual_FB20-Series_V1.2.pdf

' === 어셈블리 인스턴스 ===
'   FBEI-3200N-TS (32DI):  IN(T->O)=101 size=10, OUT(O->T)=100 size=0
'   FBEI-0032N-TS (32DO):  IN(T->O)=101 size=10, OUT(O->T)=100 size=4

Imports System.Collections
Imports System.Threading
Imports Sres.Net.EEIP

Public Class FbeiIoClient
    Implements IDisposable

    ' === 어셈블리 상수 (FBEI-0032N-TS EDS V1.03 검증값) ===
    ' Path: 20 04 24 66 2C 64 2C 65
    '       Class=0x04(Assembly), Instance=0x66(102, Config), CP=0x64(100, OT), CP=0x65(101, TO)
    Private Const CONFIG_INSTANCE As Byte = &H66    ' 102 - EDS Connection Path "24 66"
    Private Const INPUT_INSTANCE As Byte = &H65     ' 101 (T->O, FBEI->PC)
    Private Const OUTPUT_INSTANCE As Byte = &H64    ' 100 (O->T, PC->FBEI)
    Private Const DI_INPUT_LEN As UShort = 10US     ' FBEI-3200N-TS Input (T->O)
    Private Const DI_OUTPUT_LEN As UShort = 0US     ' 32DI 카드는 출력 없음 → Null connection
    Private Const DO_INPUT_LEN As UShort = 10US     ' FBEI-0032N-TS Input (T->O, 진단)
    Private Const DO_OUTPUT_LEN As UShort = 4US     ' 32DO 카드 출력 (O->T)
    Private Const RPI_MICROS As UInteger = 10000UI  ' 10ms RPI (EEIP.NET 단위는 microseconds)
    Private Const SCAN_INTERVAL_MS As Integer = 10   ' 입력 폴링 주기 (T->O 갱신 주기와 일치)

    ' === 멤버 ===
    Private ReadOnly _diClient As EEIPClient = New EEIPClient()
    Private ReadOnly _doClient As EEIPClient = New EEIPClient()
    Private ReadOnly _diIp As String
    Private ReadOnly _doIp As String
    Private ReadOnly _rpiMicros As UInteger
    Private ReadOnly _outputBuffer(3) As Byte    ' Q1~Q32
    Private ReadOnly _inputBits As New BitArray(32)
    Private ReadOnly _syncLock As New Object()
    Private _cts As CancellationTokenSource
    Private _scanThread As Thread
    Private _connected As Boolean
    Private _disposed As Boolean

    Public Event InputChanged(channel As Integer, value As Boolean)
    Public Event PowerError(moduleName As String, hasError As Boolean)
    Public Event LogMessage(message As String)

    Public Sub New(inputModuleIp As String, outputModuleIp As String, Optional rpiMs As Integer = 10)
        _diIp = inputModuleIp
        _doIp = outputModuleIp
        _rpiMicros = CUInt(rpiMs * 1000)
    End Sub

    Public Sub Connect()
        If _disposed Then Throw New ObjectDisposedException(NameOf(FbeiIoClient))
        If _connected Then Exit Sub

        OpenSlave(_diClient, _diIp, DI_INPUT_LEN, DI_OUTPUT_LEN, "DI")
        OpenSlave(_doClient, _doIp, DO_INPUT_LEN, DO_OUTPUT_LEN, "DO")

        _connected = True
        _cts = New CancellationTokenSource()
        _scanThread = New Thread(AddressOf ScanLoop) With {.IsBackground = True, .Name = "FbeiScan"}
        _scanThread.Start()
    End Sub

    Private Sub OpenSlave(client As EEIPClient, ip As String, tIn As UShort, tOut As UShort, label As String)
        client.IPAddress = ip
        client.RegisterSession()

        client.AssemblyObjectClass = &H4
        client.ConfigurationAssemblyInstanceID = CONFIG_INSTANCE     ' 0x66 = 102 (EDS 검증)
        client.T_O_InstanceID = INPUT_INSTANCE                       ' 0x65 = 101
        client.T_O_Length = tIn
        client.O_T_InstanceID = OUTPUT_INSTANCE                      ' 0x64 = 100
        client.O_T_Length = tOut

        client.RequestedPacketRate_O_T = _rpiMicros
        client.RequestedPacketRate_T_O = _rpiMicros

        ' DO 카드(tOut>0)는 O->T 활성, DI 카드는 출력 없음 → Null connection
        ' RealTimeFormat=Modeless: 헤더 없이 raw payload (단순, 첫 시도 안전값)
        ' Header32Bit 필요 시 ForwardOpen STATUS=0x103/0x0136 보면서 교체
        If tOut > 0 Then
            client.O_T_RealTimeFormat = RealTimeFormat.Modeless
            client.O_T_ConnectionType = ConnectionType.Point_to_Point
        Else
            ' EEIP.NET은 O_T_ConnectionType=Null일 때 connection path에서 O_T segment 제거
            client.O_T_RealTimeFormat = RealTimeFormat.Modeless
            client.O_T_ConnectionType = ConnectionType.Null
        End If

        ' T->O (FBEI -> PC) 는 EDS에서 Multicast/P2P 둘 다 지원
        ' Multicast 가 산업 디폴트지만 가정용 스위치는 IGMP snooping 없어서 Multicast 폭주 가능
        ' 본 프로젝트는 PC 1대 + 카드 1대 직결 패턴 → Point_to_Point 안전
        client.T_O_RealTimeFormat = RealTimeFormat.Modeless
        client.T_O_ConnectionType = ConnectionType.Point_to_Point

        client.O_T_Priority = Priority.Scheduled
        client.T_O_Priority = Priority.Scheduled
        client.O_T_OwnerRedundant = False
        client.T_O_OwnerRedundant = False
        client.O_T_VariableLength = False
        client.T_O_VariableLength = False

        client.ForwardOpen()
        RaiseEvent LogMessage($"[FBEI-{label}] {ip} ForwardOpen OK (TO={tIn}B, OT={tOut}B, Config=0x66, RPI={_rpiMicros}us)")
    End Sub

    Public Sub Disconnect()
        If _cts IsNot Nothing Then _cts.Cancel()
        If _scanThread IsNot Nothing AndAlso _scanThread.IsAlive Then
            _scanThread.Join(500)
        End If
        Try
            If _connected Then
                _diClient.ForwardClose()
                _diClient.UnRegisterSession()
                _doClient.ForwardClose()
                _doClient.UnRegisterSession()
            End If
        Catch ex As Exception
            RaiseEvent LogMessage($"[FBEI] Disconnect 예외: {ex.Message}")
        End Try
        _connected = False
    End Sub

    ' === 입력 읽기 ===
    ''' <summary>채널 1~32</summary>
    Public Function GetInput(channel As Integer) As Boolean
        If channel < 1 OrElse channel > 32 Then Throw New ArgumentOutOfRangeException(NameOf(channel))
        SyncLock _syncLock
            Return _inputBits(channel - 1)
        End SyncLock
    End Function

    Public Function GetInputBits() As BitArray
        SyncLock _syncLock
            Return CType(_inputBits.Clone(), BitArray)
        End SyncLock
    End Function

    ' === 출력 쓰기 ===
    ''' <summary>채널 1~32 출력 설정. 즉시 전송됨.</summary>
    Public Sub SetOutput(channel As Integer, value As Boolean)
        If channel < 1 OrElse channel > 32 Then Throw New ArgumentOutOfRangeException(NameOf(channel))
        Dim byteIdx As Integer = (channel - 1) \ 8
        Dim bitIdx As Integer = (channel - 1) Mod 8
        SyncLock _syncLock
            If value Then
                _outputBuffer(byteIdx) = _outputBuffer(byteIdx) Or CByte(1 << bitIdx)
            Else
                _outputBuffer(byteIdx) = _outputBuffer(byteIdx) And CByte(Not (1 << bitIdx))
            End If
        End SyncLock
        FlushOutput()
    End Sub

    Public Function GetOutput(channel As Integer) As Boolean
        If channel < 1 OrElse channel > 32 Then Throw New ArgumentOutOfRangeException(NameOf(channel))
        Dim byteIdx As Integer = (channel - 1) \ 8
        Dim bitIdx As Integer = (channel - 1) Mod 8
        SyncLock _syncLock
            Return ((_outputBuffer(byteIdx) >> bitIdx) And 1) = 1
        End SyncLock
    End Function

    Public Sub SetOutputBytes(buffer() As Byte)
        If buffer.Length <> 4 Then Throw New ArgumentException("FBEI-0032 출력 버퍼는 4바이트")
        SyncLock _syncLock
            Array.Copy(buffer, _outputBuffer, 4)
        End SyncLock
        FlushOutput()
    End Sub

    Private Sub FlushOutput()
        If Not _connected Then Exit Sub
        Try
            SyncLock _syncLock
                ' EEIPClient.O_T_IOData 는 byte() 배열에 직접 노출됨
                Dim target As Byte() = _doClient.O_T_IOData
                If target IsNot Nothing AndAlso target.Length >= 4 Then
                    Array.Copy(_outputBuffer, target, 4)
                End If
            End SyncLock
        Catch ex As Exception
            RaiseEvent LogMessage($"[FBEI-DO] 출력 쓰기 예외: {ex.Message}")
        End Try
    End Sub

    ' === 스캔 루프 ===
    Private Sub ScanLoop()
        Dim token As CancellationToken = _cts.Token
        Dim prev As New BitArray(32)
        While Not token.IsCancellationRequested
            Try
                Dim raw As Byte() = _diClient.T_O_IOData
                ' DO 카드의 T_O_RealTimeFormat=Modeless → byte 0부터 페이로드 시작
                ' (Header32Bit이면 앞 4 byte는 run/idle header이라 offset 처리 필요했음)
                If raw IsNot Nothing AndAlso raw.Length >= 4 Then
                    SyncLock _syncLock
                        For ch As Integer = 1 To 32
                            Dim bIdx As Integer = (ch - 1) \ 8
                            Dim bitIdx As Integer = (ch - 1) Mod 8
                            Dim newVal As Boolean = ((raw(bIdx) >> bitIdx) And 1) = 1
                            If _inputBits(ch - 1) <> newVal Then
                                _inputBits(ch - 1) = newVal
                            End If
                        Next
                    End SyncLock
                    For ch As Integer = 1 To 32
                        Dim cur As Boolean = _inputBits(ch - 1)
                        If cur <> prev(ch - 1) Then
                            prev(ch - 1) = cur
                            RaiseEvent InputChanged(ch, cur)
                        End If
                    Next

                    ' Byte 8: Power status (bit0 = error)
                    If raw.Length >= 9 Then
                        Dim err As Boolean = (raw(8) And &H1) <> 0
                        RaiseEvent PowerError("DI", err)
                    End If
                End If
            Catch ex As Exception
                RaiseEvent LogMessage($"[FBEI-DI] 스캔 예외: {ex.Message}")
            End Try
            Thread.Sleep(SCAN_INTERVAL_MS)
        End While
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If _disposed Then Return
        _disposed = True
        Disconnect()
        GC.SuppressFinalize(Me)
    End Sub
End Class
