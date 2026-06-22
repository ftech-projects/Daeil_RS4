Imports System.Globalization
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class AtlasToolResult
    Public Property ToolIndex As Integer
    Public Property TorqueNm As Double
    Public Property AngleDeg As Double
    Public Property ControllerOk As Boolean
    Public Property Raw As String
End Class

Public Class AtlasEthernetToolClient
    Implements IDisposable

    Private Const ATLAS_PORT As Integer = 4545
    Private Const CONNECT_RETRY_MS As Integer = 3000
    Private Const KEEP_ALIVE_MS As Integer = 4000
    Private Const READ_SLEEP_MS As Integer = 20

    Private ReadOnly _toolIndex As Integer
    Private ReadOnly _ipAddress As String
    Private ReadOnly _rxBuffer As New StringBuilder()
    Private _client As TcpClient
    Private _stream As NetworkStream
    Private _worker As Thread
    Private _cts As CancellationTokenSource
    Private _disposed As Boolean
    Private _connected As Boolean
    Private _lastKeepAlive As DateTime = DateTime.MinValue
    Private _commErrorLogged As Boolean

    Public Event LogMessage(message As String)
    Public Event ResultReceived(result As AtlasToolResult)
    Public Event ConnectionChanged(toolIndex As Integer, connected As Boolean)

    Public Sub New(toolIndex As Integer, ipAddress As String)
        _toolIndex = toolIndex
        _ipAddress = If(ipAddress, "").Trim()
    End Sub

    Public ReadOnly Property IsConfigured As Boolean
        Get
            Return _ipAddress <> ""
        End Get
    End Property

    Public Sub Start()
        If _disposed Then Throw New ObjectDisposedException(NameOf(AtlasEthernetToolClient))
        If Not IsConfigured Then Return
        If _worker IsNot Nothing AndAlso _worker.IsAlive Then Return

        _cts = New CancellationTokenSource()
        _worker = New Thread(AddressOf WorkerLoop) With {
            .IsBackground = True,
            .Name = "AtlasTool" & (_toolIndex + 1).ToString(CultureInfo.InvariantCulture)
        }
        _worker.Start()
    End Sub

    Public Sub [Stop]()
        If _cts IsNot Nothing Then _cts.Cancel()
        CloseSocket()
        If _worker IsNot Nothing AndAlso _worker.IsAlive Then
            _worker.Join(1000)
        End If
        _worker = Nothing
    End Sub

    Private Sub WorkerLoop()
        Dim token As CancellationToken = _cts.Token

        While Not token.IsCancellationRequested
            Try
                OpenTcp()
                EstablishOpenProtocolSession()
                SetConnected(True)
                _lastKeepAlive = DateTime.UtcNow

                Dim buffer(1023) As Byte
                While Not token.IsCancellationRequested AndAlso _client IsNot Nothing AndAlso _client.Connected
                    If _stream.DataAvailable Then
                        Dim readCount As Integer = _stream.Read(buffer, 0, buffer.Length)
                        If readCount <= 0 Then Exit While

                        Dim chunk As String = Encoding.ASCII.GetString(buffer, 0, readCount)
                        _rxBuffer.Append(chunk)
                        ParseFrames()
                    End If

                    If (DateTime.UtcNow - _lastKeepAlive).TotalMilliseconds >= KEEP_ALIVE_MS Then
                        SendMid(9999, "001")
                        _lastKeepAlive = DateTime.UtcNow
                    End If

                    Thread.Sleep(READ_SLEEP_MS)
                End While
            Catch ex As Exception
                If Not _commErrorLogged Then
                    _commErrorLogged = True
                    RaiseEvent LogMessage($"[ATLAS T{_toolIndex + 1}] 통신 예외: {ex.Message}")
                End If
            Finally
                SetConnected(False)
                CloseSocket()
            End Try

            If Not token.IsCancellationRequested Then Thread.Sleep(CONNECT_RETRY_MS)
        End While
    End Sub

    Private Sub OpenTcp()
        CloseSocket()

        _client = New TcpClient()
        _client.ReceiveTimeout = 3000
        _client.SendTimeout = 3000
        _client.Connect(_ipAddress, ATLAS_PORT)
        _stream = _client.GetStream()
        _rxBuffer.Clear()
        _commErrorLogged = False
    End Sub

    Private Sub EstablishOpenProtocolSession()
        SendSessionStart()
        If Not WaitForSessionReady(2500) Then
            RaiseEvent LogMessage($"[ATLAS T{_toolIndex + 1}] MID0002 미수신 — 구독 시도")
        End If
        SendSubscribeLastTightening()
    End Sub

    ''' <summary>MID0001 후 0002(ACK) 또는 0004(거부) 대기</summary>
    Private Function WaitForSessionReady(timeoutMs As Integer) As Boolean
        Dim deadline As DateTime = DateTime.UtcNow.AddMilliseconds(timeoutMs)
        Dim buffer(1023) As Byte

        While DateTime.UtcNow < deadline
            If _stream Is Nothing OrElse Not _stream.DataAvailable Then
                Thread.Sleep(READ_SLEEP_MS)
                Continue While
            End If

            Dim readCount As Integer = _stream.Read(buffer, 0, buffer.Length)
            If readCount <= 0 Then Return False

            Dim chunk As String = Encoding.ASCII.GetString(buffer, 0, readCount)
            _rxBuffer.Append(chunk)
            Dim text As String = _rxBuffer.ToString()

            If text.Contains("0004001") Then
                RaiseEvent LogMessage($"[ATLAS T{_toolIndex + 1}] MID0004 세션 거부")
                Throw New InvalidOperationException("Atlas MID0004 session rejected")
            End If
            If text.Length >= 8 AndAlso Mid(text, 5, 4) = "0002" Then
                _rxBuffer.Clear()
                Return True
            End If
            If text.Contains("0061001") Then
                ParseFrames()
                Return True
            End If
        End While

        Return False
    End Function

    Private Sub SetConnected(value As Boolean)
        If _connected = value Then Return
        _connected = value
        RaiseEvent ConnectionChanged(_toolIndex, value)
    End Sub

    Private Sub CloseSocket()
        Try
            If _stream IsNot Nothing Then _stream.Close()
        Catch
        End Try
        Try
            If _client IsNot Nothing Then _client.Close()
        Catch
        End Try
        _stream = Nothing
        _client = Nothing
    End Sub

    Private Sub SendSessionStart()
        SendMid(1, "003")
    End Sub

    Private Sub SendSubscribeLastTightening()
        SendMid(60, "001")
    End Sub

    Private Sub SendAckLastTightening()
        SendMid(62, "001")
    End Sub

    Private Sub SendMid(mid As Integer, rev As String)
        If _stream Is Nothing Then Throw New InvalidOperationException("Atlas stream is not open.")

        Dim frame As String = "0020" & mid.ToString("0000", CultureInfo.InvariantCulture) &
                              rev.PadLeft(3, "0"c) & "0" &
                              ChrW(20) & ChrW(20) & ChrW(20) & ChrW(20) &
                              ChrW(20) & ChrW(20) & ChrW(20) & ChrW(20) & ChrW(0)
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(frame)
        _stream.Write(bytes, 0, bytes.Length)
        _stream.Flush()
    End Sub

    Private Sub ParseFrames()
        Dim allText As String = _rxBuffer.ToString()

        While True
            Dim nulIndex As Integer = allText.IndexOf(ChrW(0))
            Dim frame As String

            If nulIndex >= 0 Then
                frame = allText.Substring(0, nulIndex)
                allText = allText.Substring(nulIndex + 1)
            ElseIf allText.Contains("0061001") AndAlso allText.Length >= 172 Then
                frame = allText
                allText = ""
            Else
                Exit While
            End If

            HandleFrame(frame)
        End While

        _rxBuffer.Clear()
        If allText.Length > 4096 Then
            _rxBuffer.Append(allText.Substring(allText.Length - 4096))
        Else
            _rxBuffer.Append(allText)
        End If
    End Sub

    Private Sub HandleFrame(frame As String)
        If frame.Length < 8 Then Return

        Dim midCode As String = Mid(frame, 5, 4)
        If midCode = "0002" OrElse midCode = "0005" OrElse midCode = "9999" Then
            Return
        ElseIf midCode = "0004" Then
            RaiseEvent LogMessage($"[ATLAS T{_toolIndex + 1}] MID0004 오류 프레임")
        ElseIf frame.Contains("0061001") Then
            SendAckLastTightening()
            ParseTighteningResult(frame)
        End If
    End Sub

    Private Sub ParseTighteningResult(frame As String)
        Try
            Dim anchor0 As Integer = frame.IndexOf("0061", StringComparison.Ordinal)
            If anchor0 < 0 Then
                RaiseEvent LogMessage($"[ATLAS T{_toolIndex + 1}] 0061 앵커 없음")
                Return
            End If

            ' 시리얼 Tool_String1 과 동일 — "0061" 기준 상대 오프셋 (상태=+103, 토크=+137~+141)
            Dim base1 As Integer = anchor0 + 1
            If frame.Length < base1 + 141 Then
                RaiseEvent LogMessage($"[ATLAS T{_toolIndex + 1}] 0061 프레임 길이 부족: {frame.Length}")
                Return
            End If

            Dim statusText As String = Mid(frame, base1 + 103, 1)
            Dim torque As Double = CDbl(Val(Mid(frame, base1 + 137, 3) & "." & Mid(frame, base1 + 140, 2)))
            Dim angle As Double = 0
            If frame.Length >= base1 + 166 Then
                angle = CDbl(Val(Mid(frame, base1 + 161, 3) & "." & Mid(frame, base1 + 164, 2)))
            End If
            Dim controllerOk As Boolean = (statusText = "1")

            RaiseEvent LogMessage($"[ATLAS T{_toolIndex + 1} RX] 0061 DEC={If(controllerOk, "OK", "NG")}, TQ={torque:0.00}, ANG={angle:0.00}")
            RaiseEvent ResultReceived(New AtlasToolResult With {
                .ToolIndex = _toolIndex,
                .TorqueNm = torque,
                .AngleDeg = angle,
                .ControllerOk = controllerOk,
                .Raw = frame
            })
        Catch ex As Exception
            RaiseEvent LogMessage($"[ATLAS T{_toolIndex + 1}] 0061 파싱 실패: {ex.Message}")
        End Try
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If _disposed Then Return
        _disposed = True
        [Stop]()
        If _cts IsNot Nothing Then _cts.Dispose()
        GC.SuppressFinalize(Me)
    End Sub
End Class
