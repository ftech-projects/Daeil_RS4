' FBEI EtherNet/IP IO 클라이언트 (Op01_PE — 입력 1 + 출력 1 구성)
' EEIP.NET (Sres.Net.EEIP) 라이브러리 사용
'
'   IN  (FBEI-3200N-TS 32DI) : ch 1~32   IP 192.168.250.10
'   OUT (FBEI-0032N-TS 32DO) : ch 1~32   IP 192.168.250.11
'
' === 어셈블리 인스턴스 (FBEI EDS V1.03 검증값) ===
'   32DI: IN(T->O)=101 size=10, OUT(O->T)=100 size=0 (출력 없음 → Null connection)
'   32DO: IN(T->O)=101 size=10, OUT(O->T)=100 size=4
'
' ※ EDS 상수는 FBEI-3200N-TS/0032N-TS 기준. 모델 다르면 보정.

Imports System.Collections
Imports System.Threading
Imports Sres.Net.EEIP

Public Class FbeiIoClient
    Implements IDisposable

    ' === 어셈블리 상수 (FBEI EDS + 실보드 ForwardOpen 검증값 2026-06-03) ===
    Private Const CONFIG_INSTANCE As Byte = &H66    ' 102 (Config)
    Private Const INPUT_INSTANCE As Byte = &H65     ' 101 (T->O, FBEI->PC)
    Private Const OUTPUT_INSTANCE As Byte = &H64    ' 100 (O->T, PC->FBEI)
    Private Const INPUT_ONLY_INSTANCE As Byte = &HC1 ' 193 (32DI O->T = Input-Only 연결점)
    Private Const DI_INPUT_LEN As UShort = 10US     ' 32DI Input (T->O)
    Private Const DI_OUTPUT_LEN As UShort = 0US     ' 32DI 출력 없음 → Input-Only(0xC1) ZeroLength
    Private Const DO_INPUT_LEN As UShort = 10US     ' 32DO Input (T->O, 진단)
    Private Const DO_OUTPUT_LEN As UShort = 4US     ' 32DO 출력 (O->T), Header32Bit
    Private Const SCAN_INTERVAL_MS As Integer = 10  ' 입력 폴링 주기
    Private Const CH_COUNT As Integer = 32          ' 입력/출력 채널 수
    Private Const ORIGINATOR_PORT_IN As Integer = &H8AE   ' 2222 (입력 클라)
    Private Const ORIGINATOR_PORT_OUT As Integer = &H8AF  ' 2223 (출력 클라) — 충돌 회피
    Private Shared ReadOnly CONFIG_DATA() As Byte = {&H6, &H0} ' FBEI parameter config: filter=medium, reserved=0

    ' === 멤버 ===
    Private ReadOnly _diClient As EEIPClient = New EEIPClient()   ' 입력 ch 1~32
    Private ReadOnly _doClient As EEIPClient = New EEIPClient()   ' 출력 ch 1~32
    Private ReadOnly _diIp As String
    Private ReadOnly _doIp As String
    Private ReadOnly _rpiMicros As UInteger
    Private ReadOnly _outputBuffer(3) As Byte                     ' Q1~Q32
    Private ReadOnly _inputBits As New BitArray(CH_COUNT)         ' i1~i32
    Private ReadOnly _syncLock As New Object()
    Private _cts As CancellationTokenSource
    Private _scanThread As Thread
    Private _connected As Boolean
    Private _disposed As Boolean

    ''' <summary>입력 채널 1~32 변화</summary>
    Public Event InputChanged(channel As Integer, value As Boolean)
    ''' <summary>모듈 전원 에러</summary>
    Public Event PowerError(moduleName As String, hasError As Boolean)
    Public Event LogMessage(message As String)

    ''' <param name="inputIp">입력모듈 IP (ch 1~32)</param>
    ''' <param name="outputIp">출력모듈 IP (ch 1~32)</param>
    Public Sub New(inputIp As String, outputIp As String, Optional rpiMs As Integer = 10)
        _diIp = inputIp
        _doIp = outputIp
        _rpiMicros = CUInt(rpiMs * 1000)
    End Sub

    Public Sub Connect()
        If _disposed Then Throw New ObjectDisposedException(NameOf(FbeiIoClient))
        If _connected Then Exit Sub

        ' 입/출력 둘 다 Class1 I/O — OriginatorUDPPort를 다르게 줘서 로컬 2222 충돌 회피
        ' (같은 포트면 두번째 ForwardOpen에서 '각 소켓 주소는 하나만' 에러)
        OpenSlave(_diClient, _diIp, DI_INPUT_LEN, DI_OUTPUT_LEN, ORIGINATOR_PORT_IN, "IN")
        OpenSlave(_doClient, _doIp, DO_INPUT_LEN, DO_OUTPUT_LEN, ORIGINATOR_PORT_OUT, "OUT")

        _connected = True
        _cts = New CancellationTokenSource()
        _scanThread = New Thread(AddressOf ScanLoop) With {.IsBackground = True, .Name = "FbeiScan"}
        _scanThread.Start()
    End Sub

    Private Sub OpenSlave(client As EEIPClient, ip As String, tIn As UShort, tOut As UShort, originatorPort As Integer, label As String)
        client.IPAddress = ip
        client.RegisterSession()
        client.OriginatorUDPPort = originatorPort   ' ★ RegisterSession 후, ForwardOpen 전 (2222 충돌 회피)
        client.SetAttributeSingle(&H4, CONFIG_INSTANCE, 3, CONFIG_DATA)
        Dim cfg As Byte() = client.GetAttributeSingle(&H4, CONFIG_INSTANCE, 3)
        RaiseEvent LogMessage($"[FBEI-{label}] {ip} Config 0x66={BitConverter.ToString(cfg).Replace("-", " ")}")

        client.AssemblyObjectClass = &H4
        client.ConfigurationAssemblyInstanceID = CONFIG_INSTANCE
        client.T_O_InstanceID = INPUT_INSTANCE
        client.T_O_Length = tIn
        client.O_T_InstanceID = OUTPUT_INSTANCE
        client.O_T_Length = tOut

        client.RequestedPacketRate_O_T = _rpiMicros
        client.RequestedPacketRate_T_O = _rpiMicros

        ' O->T 연결 (실보드 ForwardOpen 검증값)
        If tOut > 0 Then
            ' 출력모듈(32DO): O->T = run/idle 헤더 포함(Header32Bit), 4byte 데이터
            ' (Modeless/len4 는 STATUS 0x127 'Invalid O->T size'로 거부됨)
            client.O_T_RealTimeFormat = RealTimeFormat.Header32Bit
            client.O_T_ConnectionType = ConnectionType.Point_to_Point
            ' ★ T->O = Multicast: 출력보드 BF GREEN 확정 레시피 (holdout 검증 2026-06-04)
            '   P2P로는 ForwardOpen 돼도 BF RED 유지. Multicast + 지속연결이라야
            '   보드가 Owned+I/O Run(Identity Status 0x0065) 되며 BF GREEN.
            '   (EDS Connection1 Exclusive Owner 도 T->O를 "Point Multicast"로 명시)
            client.T_O_ConnectionType = ConnectionType.Multicast
        Else
            ' 입력모듈(32DI): Input-Only 연결점 0xC1 + ZeroLength
            ' (Null=0x315 Invalid segment, 0xC1+Heartbeat=0x127 거부 → ZeroLength만 성공)
            client.O_T_InstanceID = INPUT_ONLY_INSTANCE
            client.O_T_RealTimeFormat = RealTimeFormat.ZeroLength
            client.O_T_ConnectionType = ConnectionType.Point_to_Point
            ' 입력보드 T->O는 P2P 유지 (입력 읽기 검증됨). BF는 실행 후 육안 확인.
            client.T_O_ConnectionType = ConnectionType.Point_to_Point
        End If

        client.T_O_RealTimeFormat = RealTimeFormat.Modeless

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
                _diClient.ForwardClose() : _diClient.UnRegisterSession()
                _doClient.ForwardClose() : _doClient.UnRegisterSession()
            End If
        Catch ex As Exception
            RaiseEvent LogMessage($"[FBEI] Disconnect 예외: {ex.Message}")
        End Try
        _connected = False
    End Sub

    ' === 입력 읽기 ===
    ''' <summary>채널 1~32</summary>
    Public Function GetInput(channel As Integer) As Boolean
        If channel < 1 OrElse channel > CH_COUNT Then Throw New ArgumentOutOfRangeException(NameOf(channel))
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
    ''' <summary>채널 1~32 출력 설정. 즉시 전송.</summary>
    Public Sub SetOutput(channel As Integer, value As Boolean)
        If channel < 1 OrElse channel > CH_COUNT Then Throw New ArgumentOutOfRangeException(NameOf(channel))
        Dim byteIdx As Integer = (channel - 1) \ 8
        Dim bitIdx As Integer = (channel - 1) Mod 8
        SyncLock _syncLock
            If value Then
                _outputBuffer(byteIdx) = _outputBuffer(byteIdx) Or CByte(1 << bitIdx)
            Else
                ' Not(1<<bitIdx)는 Integer 음수(-2 등) → CByte 직접 변환 시 OverflowException.
                ' &HFF And 로 하위 8비트만 떼어 byte 범위로 안전하게 (해당 비트만 0, 나머지 유지).
                _outputBuffer(byteIdx) = _outputBuffer(byteIdx) And CByte(&HFF And Not (1 << bitIdx))
            End If
        End SyncLock
        FlushOutput()
    End Sub

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
                ' Header32Bit 출력: EEIP.NET이 run/idle 헤더(항상 Run) 자동 prepend, O_T_IOData는 순수데이터.
                ' → offset 0 = Q1~Q32 (EEIP.NET 소스 확인됨)
                Dim target As Byte() = _doClient.O_T_IOData
                If target IsNot Nothing AndAlso target.Length >= 4 Then
                    Array.Copy(_outputBuffer, target, 4)
                    _doClient.O_T_IOData = target
                End If
            End SyncLock
        Catch ex As Exception
            RaiseEvent LogMessage($"[FBEI-OUT] 출력 쓰기 예외: {ex.Message}")
        End Try
    End Sub

    ' === 스캔 루프 (입력 폴링) ===
    Private Sub ScanLoop()
        Dim token As CancellationToken = _cts.Token
        Dim prev As New BitArray(CH_COUNT)
        While Not token.IsCancellationRequested
            Try
                Dim raw As Byte() = _diClient.T_O_IOData
                ' Modeless → byte 0부터 페이로드
                If raw IsNot Nothing AndAlso raw.Length >= 4 Then
                    SyncLock _syncLock
                        For i As Integer = 0 To CH_COUNT - 1
                            Dim bIdx As Integer = i \ 8
                            Dim bitIdx As Integer = i Mod 8
                            _inputBits(i) = ((raw(bIdx) >> bitIdx) And 1) = 1
                        Next
                    End SyncLock
                    For ch As Integer = 1 To CH_COUNT
                        Dim cur As Boolean = _inputBits(ch - 1)
                        If cur <> prev(ch - 1) Then
                            prev(ch - 1) = cur
                            RaiseEvent InputChanged(ch, cur)
                        End If
                    Next
                    ' Byte 8: Power status (bit0 = error)
                    If raw.Length >= 9 Then
                        RaiseEvent PowerError("IN", (raw(8) And &H1) <> 0)
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
