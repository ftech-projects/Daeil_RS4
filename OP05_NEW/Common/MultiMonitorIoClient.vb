' MultiMonitor.ino / WeldMonitor3 v1.0 텍스트 프로토콜 (Serial1 115200)
' 프레임: S + DI16(0/1) + AI1..4(각 4자리) + E  (기본 길이 34)

Imports System.Collections.Generic
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Web.Script.Serialization

Public Class MultiMonitorIoClient
    Implements IDisposable

    Public Const DefaultBaudRate As Integer = 115200
    Public Const DiCount As Integer = 16
    Public Const DoCount As Integer = 8
    Public Const AiCount As Integer = 4

    Private ReadOnly _port As SerialPort
    Private ReadOnly _sync As New Object()
    Private ReadOnly _di(DiCount - 1) As Boolean
    Private ReadOnly _ai(AiCount - 1) As Integer
    Private ReadOnly _doState(DoCount - 1) As Boolean
    Private _readThread As Thread
    Private _cts As CancellationTokenSource
    Private _connected As Boolean
    Private _disposed As Boolean
    Private _framesReceived As Long
    Private _lastFrameUtc As DateTime = DateTime.MinValue

    Public Event DigitalInputChanged(channel As Integer, value As Boolean)
    Public Event LogMessage(message As String)

    Public Sub New(comPort As String, Optional baudRate As Integer = DefaultBaudRate)
        If String.IsNullOrWhiteSpace(comPort) OrElse
           String.Equals(comPort, "Disabled", StringComparison.OrdinalIgnoreCase) Then
            Throw New ArgumentException("COM 포트가 지정되지 않았습니다.")
        End If

        _port = New SerialPort(comPort.Trim(), baudRate, Parity.None, 8, StopBits.One) With {
            .Handshake = Handshake.None,
            .ReadTimeout = 500,
            .WriteTimeout = 500,
            .NewLine = vbLf,
            .Encoding = Text.Encoding.ASCII
        }
    End Sub

    Public ReadOnly Property IsConnected As Boolean
        Get
            Return _connected AndAlso _port IsNot Nothing AndAlso _port.IsOpen
        End Get
    End Property

    Public ReadOnly Property FramesReceived As Long
        Get
            SyncLock _sync
                Return _framesReceived
            End SyncLock
        End Get
    End Property

    Public ReadOnly Property LastFrameUtc As DateTime
        Get
            SyncLock _sync
                Return _lastFrameUtc
            End SyncLock
        End Get
    End Property

    Public Sub Connect()
        If _disposed Then Throw New ObjectDisposedException(NameOf(MultiMonitorIoClient))
        If IsConnected Then Exit Sub

        _port.Open()
        _port.DiscardInBuffer()
        _connected = True
        _cts = New CancellationTokenSource()
        _readThread = New Thread(AddressOf ReadLoop) With {.IsBackground = True, .Name = "MultiMonitorIO"}
        _readThread.Start()
        RaiseLog($"[IO-COM] 연결 OK {_port.PortName} @ {_port.BaudRate}")
    End Sub

    Public Sub Disconnect()
        If _cts IsNot Nothing Then _cts.Cancel()
        If _readThread IsNot Nothing AndAlso _readThread.IsAlive Then
            _readThread.Join(800)
        End If
        Try
            If _port IsNot Nothing AndAlso _port.IsOpen Then _port.Close()
        Catch ex As Exception
            RaiseLog("[IO-COM] 종료 예외: " & ex.Message)
        End Try
        _connected = False
    End Sub

    Public Function GetDigitalInput(channel As Integer) As Boolean
        If channel < 1 OrElse channel > DiCount Then Throw New ArgumentOutOfRangeException(NameOf(channel))
        SyncLock _sync
            Return _di(channel - 1)
        End SyncLock
    End Function

    Public Function GetAnalogRaw(channel As Integer) As Integer
        If channel < 1 OrElse channel > AiCount Then Throw New ArgumentOutOfRangeException(NameOf(channel))
        SyncLock _sync
            Return _ai(channel - 1)
        End SyncLock
    End Function

    Public Sub SetDigitalOutput(channel As Integer, value As Boolean)
        If channel < 1 OrElse channel > DoCount Then Throw New ArgumentOutOfRangeException(NameOf(channel))
        SyncLock _sync
            _doState(channel - 1) = value
        End SyncLock
        FlushOutputs()
    End Sub

    Public Function GetDigitalOutput(channel As Integer) As Boolean
        If channel < 1 OrElse channel > DoCount Then Throw New ArgumentOutOfRangeException(NameOf(channel))
        SyncLock _sync
            Return _doState(channel - 1)
        End SyncLock
    End Function

    Public Sub SetAllDigitalOutputs(value As Boolean)
        SyncLock _sync
            For i As Integer = 0 To DoCount - 1
                _doState(i) = value
            Next
        End SyncLock
        FlushOutputs()
    End Sub

    Private Sub FlushOutputs()
        If Not IsConnected Then Exit Sub
        Dim frame As String
        SyncLock _sync
            Dim chars(DoCount - 1) As Char
            For i As Integer = 0 To DoCount - 1
                chars(i) = If(_doState(i), "1"c, "0"c)
            Next
            frame = "S" & New String(chars) & "E"
        End SyncLock
        Try
            _port.Write(frame)
        Catch ex As Exception
            RaiseLog("[IO-COM] DO 전송 실패: " & ex.Message)
        End Try
    End Sub

    Private Sub ReadLoop()
        Dim token = _cts.Token
        While Not token.IsCancellationRequested
            Try
                If Not _port.IsOpen Then Exit While
                Dim line As String = _port.ReadLine()
                If String.IsNullOrWhiteSpace(line) Then Continue While
                line = line.Trim()
                If line.StartsWith("WeldingTime", StringComparison.OrdinalIgnoreCase) Then
                    RaiseLog("[IO-COM] " & line)
                    Continue While
                End If
                ParseStatusLine(line)
            Catch ex As TimeoutException
            Catch ex As IOException
                If Not token.IsCancellationRequested Then RaiseLog("[IO-COM] 읽기: " & ex.Message)
            Catch ex As Exception
                If Not token.IsCancellationRequested Then RaiseLog("[IO-COM] 파싱: " & ex.Message)
            End Try
        End While
    End Sub

    Friend Sub ParseStatusLine(line As String)
        If Not line.StartsWith("S", StringComparison.OrdinalIgnoreCase) Then Exit Sub
        Dim endIdx As Integer = line.LastIndexOf("E"c)
        If endIdx < 2 Then Exit Sub

        Dim body = line.Substring(1, endIdx - 1)
        If body.Length < DiCount + AiCount * 4 Then Exit Sub

        SyncLock _sync
            For i As Integer = 0 To DiCount - 1
                Dim bit = body(i) = "1"c
                If _di(i) <> bit Then
                    _di(i) = bit
                    RaiseEvent DigitalInputChanged(i + 1, bit)
                End If
            Next
            Dim aiStart = DiCount
            For i As Integer = 0 To AiCount - 1
                Dim rawStr = body.Substring(aiStart + i * 4, 4)
                Dim rawVal As Integer
                If Integer.TryParse(rawStr, rawVal) Then
                    _ai(i) = rawVal
                End If
            Next
            _framesReceived += 1
            _lastFrameUtc = DateTime.UtcNow
        End SyncLock
    End Sub

    Public Shared Function LoadSettings(configPath As String) As MultiMonitorSettings
        Dim s As New MultiMonitorSettings()
        If Not File.Exists(configPath) Then Return s
        Try
            Dim root = CType(New JavaScriptSerializer().DeserializeObject(File.ReadAllText(configPath)), Dictionary(Of String, Object))
            If root Is Nothing Then Return s
            If root.ContainsKey("multiMonitor") Then
                Dim mm = CType(root("multiMonitor"), Dictionary(Of String, Object))
                If mm.ContainsKey("enabled") Then s.Enabled = Convert.ToBoolean(mm("enabled"))
                If mm.ContainsKey("comPort") Then s.ComPort = CStr(mm("comPort"))
                If mm.ContainsKey("baudRate") Then s.BaudRate = Convert.ToInt32(mm("baudRate"))
                If mm.ContainsKey("inputs") Then
                    Dim inputs = TryCast(mm("inputs"), Dictionary(Of String, Object))
                    If inputs IsNot Nothing Then
                        If inputs.ContainsKey("start") Then s.IoIndexStart = Convert.ToInt32(inputs("start"))
                        If inputs.ContainsKey("reset") Then s.IoIndexReset = Convert.ToInt32(inputs("reset"))
                        If inputs.ContainsKey("eStop") Then s.IoIndexEStop = Convert.ToInt32(inputs("eStop"))
                        If inputs.ContainsKey("airTool") Then s.IoIndexAirTool = Convert.ToInt32(inputs("airTool"))
                    End If
                End If
            End If
            If root.ContainsKey("fbei") Then
                Dim fb = CType(root("fbei"), Dictionary(Of String, Object))
                If fb.ContainsKey("enabled") Then s.FbeiEnabled = Convert.ToBoolean(fb("enabled"))
                If fb.ContainsKey("inputModuleIp") Then s.FbeiDiIp = CStr(fb("inputModuleIp"))
                If fb.ContainsKey("outputModuleIp") Then s.FbeiDoIp = CStr(fb("outputModuleIp"))
                If fb.ContainsKey("rpiMs") Then s.FbeiRpiMs = Convert.ToInt32(fb("rpiMs"))
            End If
        Catch
        End Try
        Return s
    End Function

    Private Sub RaiseLog(msg As String)
        RaiseEvent LogMessage(msg)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If _disposed Then Return
        _disposed = True
        Disconnect()
        _port.Dispose()
        GC.SuppressFinalize(Me)
    End Sub
End Class

Public Class MultiMonitorSettings
    Public Property Enabled As Boolean = True
    Public Property ComPort As String = "COM4"
    Public Property BaudRate As Integer = MultiMonitorIoClient.DefaultBaudRate
    ''' <summary>ESP DI 0-based index (config inputs.*)</summary>
    Public Property IoIndexStart As Integer = 0
    Public Property IoIndexReset As Integer = 1
    Public Property IoIndexEStop As Integer = 2
    Public Property IoIndexAirTool As Integer = 3

    Public Function IoChannelStart() As Integer
        Return IoIndexStart + 1
    End Function

    Public Function IoChannelReset() As Integer
        Return IoIndexReset + 1
    End Function

    Public Function IoChannelEStop() As Integer
        Return IoIndexEStop + 1
    End Function

    Public Function IoChannelAirTool() As Integer
        Return IoIndexAirTool + 1
    End Function
    Public Property FbeiEnabled As Boolean = True
    Public Property FbeiDiIp As String = "192.168.250.10"
    Public Property FbeiDoIp As String = "192.168.250.11"
    Public Property FbeiRpiMs As Integer = 20
End Class
