' OSM41-KL30CB6/485 Conventional 프로토콜 클라이언트
' 1포트 RS485 멀티드롭, 4대 (주소 1~4) Query 모드 폴링
' 매뉴얼: docs/UM_OSM41-485_V1.0.pdf

Imports System.IO
Imports System.IO.Ports
Imports System.Threading

Public Class OsmLaserClient
    Implements IDisposable

    ' === 프로토콜 상수 ===
    Private Const FRAME_START As Byte = &H68
    Private Const FRAME_END As Byte = &H16
    Private Const CMD_READ_DISTANCE As Byte = &H0
    Private Const CMD_SET_ADDRESS As Byte = &H80
    Private Const CMD_SET_BAUD As Byte = &H81
    Private Const CMD_SET_MODE As Byte = &H83
    Private Const MODE_CONTINUOUS As Byte = &H0
    Private Const MODE_QUERY As Byte = &H1
    Private Const INVALID_DISTANCE As UShort = &HFFFF
    Private Const RESPONSE_LEN As Integer = 9       ' 거리 응답 프레임 길이
    Private Const RESPONSE_TIMEOUT_MS As Integer = 100
    Private Const POLL_INTERVAL_MS As Integer = 50

    ' === 멤버 ===
    Private ReadOnly _port As SerialPort
    Private ReadOnly _addresses() As Byte
    Private ReadOnly _values() As Integer          ' mm 단위 (-1 = invalid)
    Private ReadOnly _syncLock As New Object()
    Private _cts As CancellationTokenSource
    Private _pollThread As Thread
    Private _disposed As Boolean

    Public Event Updated(slaveIndex As Integer, distanceMm As Integer)
    Public Event LogMessage(message As String)

    ''' <param name="comPortName">시리얼 포트 이름 (예: "COM3")</param>
    ''' <param name="slaveAddresses">슬레이브 주소 배열 (예: {1,2,3,4})</param>
    ''' <param name="baudRate">기본 115200</param>
    Public Sub New(comPortName As String, slaveAddresses() As Byte, Optional baudRate As Integer = 115200)
        _addresses = slaveAddresses
        ReDim _values(_addresses.Length - 1)
        For i As Integer = 0 To _values.Length - 1
            _values(i) = -1
        Next
        _port = New SerialPort(comPortName, baudRate, Parity.None, 8, StopBits.One)
        _port.ReadTimeout = RESPONSE_TIMEOUT_MS
        _port.WriteTimeout = RESPONSE_TIMEOUT_MS
    End Sub

    ''' <summary>포트 열고 폴링 쓰레드 시작</summary>
    Public Sub StartPolling()
        If _disposed Then Throw New ObjectDisposedException(NameOf(OsmLaserClient))
        If _pollThread IsNot Nothing AndAlso _pollThread.IsAlive Then Exit Sub

        _port.Open()
        RaiseEvent LogMessage($"[OSM41] 포트 열림: {_port.PortName} @ {_port.BaudRate}")

        ' 모든 슬레이브를 Query 모드로 전환 (멀티드롭 필수)
        For Each adr As Byte In _addresses
            Try
                SetOutputMode(adr, MODE_QUERY)
                RaiseEvent LogMessage($"[OSM41] adr={adr} Query 모드 설정")
            Catch ex As Exception
                RaiseEvent LogMessage($"[OSM41] adr={adr} Query 모드 설정 실패: {ex.Message}")
            End Try
        Next

        _cts = New CancellationTokenSource()
        _pollThread = New Thread(AddressOf PollLoop) With {.IsBackground = True, .Name = "OsmPoll"}
        _pollThread.Start()
    End Sub

    Public Sub StopPolling()
        If _cts IsNot Nothing Then _cts.Cancel()
        If _pollThread IsNot Nothing AndAlso _pollThread.IsAlive Then
            _pollThread.Join(500)
        End If
        If _port.IsOpen Then _port.Close()
    End Sub

    ''' <summary>마지막 측정값 (mm). 인덱스는 생성자에 넘긴 주소 순서</summary>
    Public Function GetDistance(slaveIndex As Integer) As Integer
        SyncLock _syncLock
            Return _values(slaveIndex)
        End SyncLock
    End Function

    Public Function GetAllDistances() As Integer()
        SyncLock _syncLock
            Return DirectCast(_values.Clone(), Integer())
        End SyncLock
    End Function

    ' === 폴링 루프 ===
    Private Sub PollLoop()
        Dim token As CancellationToken = _cts.Token
        While Not token.IsCancellationRequested
            For i As Integer = 0 To _addresses.Length - 1
                If token.IsCancellationRequested Then Exit While
                Try
                    Dim mm As Integer = ReadDistance(_addresses(i))
                    SyncLock _syncLock
                        _values(i) = mm
                    End SyncLock
                    RaiseEvent Updated(i, mm)
                Catch ex As TimeoutException
                    SyncLock _syncLock
                        _values(i) = -1
                    End SyncLock
                Catch ex As Exception
                    RaiseEvent LogMessage($"[OSM41] adr={_addresses(i)} 폴링 예외: {ex.Message}")
                End Try
            Next
            Thread.Sleep(POLL_INTERVAL_MS)
        End While
    End Sub

    ' === 명령: 거리 읽기 ===
    Private Function ReadDistance(adr As Byte) As Integer
        ' 요청: 68 [adr] 03 00 cs1 cs2 16
        Dim req(6) As Byte
        req(0) = FRAME_START
        req(1) = adr
        req(2) = &H3
        req(3) = CMD_READ_DISTANCE
        Dim cs As UShort = CUShort(adr) + 3US + 0US
        req(4) = CByte(cs And &HFF)
        req(5) = CByte((cs >> 8) And &HFF)
        req(6) = FRAME_END

        _port.DiscardInBuffer()
        _port.Write(req, 0, req.Length)

        Dim resp() As Byte = ReadResponse(RESPONSE_LEN)

        ' 응답: 68 [adr] 05 00 d1 d2 cs1 cs2 16
        If resp(0) <> FRAME_START OrElse resp(RESPONSE_LEN - 1) <> FRAME_END Then
            Throw New IOException("OSM41 프레임 헤더/종료 불일치")
        End If
        If resp(1) <> adr OrElse resp(2) <> &H5 OrElse resp(3) <> CMD_READ_DISTANCE Then
            Throw New IOException("OSM41 응답 필드 불일치")
        End If
        Dim sum As UShort = CUShort(resp(1)) + CUShort(resp(2)) + CUShort(resp(3)) + CUShort(resp(4)) + CUShort(resp(5))
        Dim recvCs As UShort = CUShort(resp(6)) Or (CUShort(resp(7)) << 8)
        If sum <> recvCs Then
            Throw New IOException($"OSM41 체크섬 불일치: calc={sum:X4} recv={recvCs:X4}")
        End If

        Dim raw As UShort = CUShort(resp(4)) Or (CUShort(resp(5)) << 8)
        If raw = INVALID_DISTANCE Then Return -1
        Return CInt(raw)   ' 단위 mm (KL30CB6 분해능 0.001mm 가중치는 실측 후 보정)
    End Function

    ' === 명령: 출력 모드 변경 ===
    Public Sub SetOutputMode(adr As Byte, mode As Byte)
        ' 요청: 68 [adr] 04 83 d1 cs1 cs2 16
        Dim req(7) As Byte
        req(0) = FRAME_START
        req(1) = adr
        req(2) = &H4
        req(3) = CMD_SET_MODE
        req(4) = mode
        Dim cs As UShort = CUShort(adr) + 4US + CUShort(CMD_SET_MODE) + CUShort(mode)
        req(5) = CByte(cs And &HFF)
        req(6) = CByte((cs >> 8) And &HFF)
        req(7) = FRAME_END

        _port.DiscardInBuffer()
        _port.Write(req, 0, req.Length)

        ' 응답: 68 [adr] 04 83 state cs1 cs2 16  (8 bytes)
        Dim resp() As Byte = ReadResponse(8)
        If resp(0) <> FRAME_START OrElse resp(7) <> FRAME_END Then
            Throw New IOException("SetOutputMode 응답 프레임 불일치")
        End If
        If resp(4) <> 0 Then
            Throw New IOException($"SetOutputMode 실패: state={resp(4)}")
        End If
    End Sub

    Private Function ReadResponse(expectedLen As Integer) As Byte()
        Dim buf(expectedLen - 1) As Byte
        Dim total As Integer = 0
        Dim sw As Stopwatch = Stopwatch.StartNew()
        While total < expectedLen
            If sw.ElapsedMilliseconds > RESPONSE_TIMEOUT_MS Then
                Throw New TimeoutException("OSM41 응답 타임아웃")
            End If
            Dim n As Integer = _port.BytesToRead
            If n > 0 Then
                Dim toRead As Integer = Math.Min(n, expectedLen - total)
                Dim got As Integer = _port.Read(buf, total, toRead)
                total += got
            Else
                Thread.Sleep(2)
            End If
        End While
        Return buf
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        If _disposed Then Return
        _disposed = True
        StopPolling()
        _port.Dispose()
        GC.SuppressFinalize(Me)
    End Sub
End Class
