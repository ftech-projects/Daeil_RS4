' Keyence IL 시리즈 레이저 변위 센서 (DL-RS1A 등 RS-232C 통신 유닛)
' PopV4(대일공업 DAEIL_JG)와 동일 프로토콜: MS + CR/LF 폴링, CSV 응답 파싱
' 센서 헤드 예: IL-300 (기준거리 300mm) — docs/KEYENCE_IL.md 참고

Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Web.Script.Serialization

Public Class KeyenceIlLaserClient
    Implements IDisposable

    Private Class AmplifierChannel
        Public Property MappingIndex As Integer
        Public Property Name As String
    End Class

    Private Class AmplifierState
        Public Port As SerialPort
        Public ModelRangeMm As Double
        Public Channels As New List(Of AmplifierChannel)
        Public Values() As Double
        Public ReadOnly SyncRoot As New Object()
    End Class

    Private ReadOnly _amplifiers As New List(Of AmplifierState)
    Private _pollIntervalMs As Integer = 300
    Private _cts As CancellationTokenSource
    Private _pollThread As Thread
    Private _disposed As Boolean

    Public Event Updated(mappingIndex As Integer, distanceMm As Double)
    Public Event LogMessage(message As String)

    ''' <param name="comPortOverride">Table_SerialPort.Laser 등 DB 값 (첫 번째 앰프 COM 덮어씀)</param>
    Public Shared Function FromConfig(configPath As String, Optional comPortOverride As String = Nothing) As KeyenceIlLaserClient
        Dim client As New KeyenceIlLaserClient()
        Dim pollMs As Integer = 300
        Dim amps As New List(Of Dictionary(Of String, Object))

        If File.Exists(configPath) Then
            Try
                Dim json = File.ReadAllText(configPath)
                Dim root = CType(New JavaScriptSerializer().DeserializeObject(json), Dictionary(Of String, Object))
                If root IsNot Nothing AndAlso root.ContainsKey("keyenceIl") Then
                    Dim kc = CType(root("keyenceIl"), Dictionary(Of String, Object))
                    If kc.ContainsKey("pollIntervalMs") Then pollMs = Convert.ToInt32(kc("pollIntervalMs"))
                    Dim ampList = TryCast(kc("amplifiers"), ArrayList)
                    If ampList IsNot Nothing Then
                        For Each item As Object In ampList
                            Dim dict = TryCast(item, Dictionary(Of String, Object))
                            If dict IsNot Nothing Then amps.Add(dict)
                        Next
                    End If
                ElseIf root IsNot Nothing AndAlso root.ContainsKey("osm41") Then
                    ' 이전 config 호환: osm41.comPort → 단일 IL 앰프
                    Dim osm = CType(root("osm41"), Dictionary(Of String, Object))
                    Dim legacy As New Dictionary(Of String, Object) From {
                        {"comPort", If(osm.ContainsKey("comPort"), osm("comPort"), "COM3")},
                        {"baudRate", If(osm.ContainsKey("baudRate"), osm("baudRate"), 9600)},
                        {"model", "IL-300"},
                        {"channelMapping", If(osm.ContainsKey("channelMapping"), osm("channelMapping"), Nothing)}
                    }
                    amps.Add(legacy)
                End If
            Catch ex As Exception
                client.RaiseLog("[KeyenceIL] config.json 읽기 실패, 기본값 사용: " & ex.Message)
            End Try
        End If

        If amps.Count = 0 Then
            amps.Add(New Dictionary(Of String, Object) From {
                {"comPort", "COM3"},
                {"baudRate", 9600},
                {"model", "IL-300"},
                {"channelMapping", New Dictionary(Of String, Object) From {
                    {"1", "LsrLeftUpper"},
                    {"2", "LsrRightUpper"},
                    {"3", "LsrLeftLower"},
                    {"4", "LsrRightLower"}
                }}
            })
        End If

        client._pollIntervalMs = Math.Max(100, pollMs)
        Dim ampIndex As Integer = 0
        For Each ampDef As Dictionary(Of String, Object) In amps
            If ampIndex = 0 AndAlso Not String.IsNullOrWhiteSpace(comPortOverride) Then
                ampDef("comPort") = comPortOverride.Trim()
            End If
            client.AddAmplifierFromDictionary(ampDef)
            ampIndex += 1
        Next
        Return client
    End Function

    Private Sub AddAmplifierFromDictionary(ampDef As Dictionary(Of String, Object))
        Dim comPort = CStr(If(ampDef.ContainsKey("comPort"), ampDef("comPort"), "COM3"))
        If String.Equals(comPort, "Disabled", StringComparison.OrdinalIgnoreCase) Then Exit Sub

        Dim baud = 9600
        If ampDef.ContainsKey("baudRate") Then baud = Convert.ToInt32(ampDef("baudRate"))
        Dim model = CStr(If(ampDef.ContainsKey("model"), ampDef("model"), "IL-300"))
        Dim rangeMm = GetModelRangeMm(model)

        Dim state As New AmplifierState With {
            .ModelRangeMm = rangeMm,
            .Port = New SerialPort(comPort, baud, Parity.None, 8, StopBits.One) With {
                .NewLine = vbLf,
                .ReadTimeout = 500,
                .WriteTimeout = 500,
                .Encoding = Text.Encoding.ASCII
            }
        }

        Dim mapping = TryGetChannelMapping(ampDef)
        ReDim state.Values(mapping.Count - 1)
        For i As Integer = 0 To mapping.Count - 1
            state.Channels.Add(mapping(i))
            state.Values(i) = Double.NaN
        Next

        AddHandler state.Port.DataReceived, Sub(sender, e) OnDataReceived(state)
        _amplifiers.Add(state)
        RaiseLog("[KeyenceIL] 앰프 등록 " & comPort & " @ " & baud & ", " & model & " (range=" & rangeMm & "mm, ch=" & mapping.Count & ")")
    End Sub

    Private Shared Function TryGetChannelMapping(ampDef As Dictionary(Of String, Object)) As List(Of AmplifierChannel)
        Dim result As New List(Of AmplifierChannel)
        Dim defaultNames = New String() {"LsrLeftUpper", "LsrRightUpper", "LsrLeftLower", "LsrRightLower"}

        If ampDef.ContainsKey("channelMapping") AndAlso ampDef("channelMapping") IsNot Nothing Then
            Dim mapObj = ampDef("channelMapping")
            Dim keys As New List(Of String)
            If TypeOf mapObj Is Dictionary(Of String, Object) Then
                For Each keyItem As String In CType(mapObj, Dictionary(Of String, Object)).Keys
                    keys.Add(keyItem)
                Next
            ElseIf TypeOf mapObj Is IDictionary(Of String, Object) Then
                For Each keyItem As String In CType(mapObj, IDictionary(Of String, Object)).Keys
                    keys.Add(keyItem)
                Next
            End If
            keys.Sort(Function(a As String, b As String) Val(a).CompareTo(Val(b)))
            For Each k As String In keys
                Dim chNum = Integer.Parse(k)
                Dim idx = chNum - 1
                Dim name As String = defaultNames(Math.Min(idx, defaultNames.Length - 1))
                If TypeOf mapObj Is Dictionary(Of String, Object) Then
                    name = CStr(CType(mapObj, Dictionary(Of String, Object))(k))
                ElseIf TypeOf mapObj Is IDictionary(Of String, Object) Then
                    name = CStr(CType(mapObj, IDictionary(Of String, Object))(k))
                End If
                result.Add(New AmplifierChannel With {.MappingIndex = idx, .Name = name})
            Next
        End If

        If result.Count = 0 Then
            For i As Integer = 0 To 3
                result.Add(New AmplifierChannel With {.MappingIndex = i, .Name = defaultNames(i)})
            Next
        End If
        Return result
    End Function

    Public Shared Function GetModelRangeMm(model As String) As Double
        Select Case model.Trim().ToUpperInvariant()
            Case "IL-30", "IL-030" : Return 30
            Case "IL-65" : Return 65
            Case "IL-100" : Return 100
            Case "IL-300" : Return 300
            Case "IL-600" : Return 600
            Case "IL-2000" : Return 2000
            Case Else : Return 300
        End Select
    End Function

    Public Sub StartPolling()
        If _disposed Then Throw New ObjectDisposedException(NameOf(KeyenceIlLaserClient))
        If _amplifiers.Count = 0 Then
            RaiseLog("[KeyenceIL] 활성 앰프 없음")
            Exit Sub
        End If
        If _pollThread IsNot Nothing AndAlso _pollThread.IsAlive Then Exit Sub

        For Each amp As AmplifierState In _amplifiers
            If Not amp.Port.IsOpen Then
                amp.Port.Open()
                RaiseLog("[KeyenceIL] 포트 열림 " & amp.Port.PortName)
            End If
        Next

        _cts = New CancellationTokenSource()
        _pollThread = New Thread(AddressOf PollLoop) With {.IsBackground = True, .Name = "KeyenceIlPoll"}
        _pollThread.Start()
    End Sub

    Public Sub StopPolling()
        If _cts IsNot Nothing Then _cts.Cancel()
        If _pollThread IsNot Nothing AndAlso _pollThread.IsAlive Then
            _pollThread.Join(800)
        End If
        For Each amp As AmplifierState In _amplifiers
            Try
                If amp.Port.IsOpen Then amp.Port.Close()
            Catch
            End Try
        Next
    End Sub

    Private Sub PollLoop()
        While _cts IsNot Nothing AndAlso Not _cts.Token.IsCancellationRequested
            For Each amp As AmplifierState In _amplifiers
                Try
                    If amp.Port.IsOpen Then
                        amp.Port.Write("MS" & vbCrLf)
                    End If
                Catch ex As Exception
                    RaiseLog("[KeyenceIL] " & amp.Port.PortName & " MS 전송 실패: " & ex.Message)
                End Try
            Next
            Thread.Sleep(_pollIntervalMs)
        End While
    End Sub

    Private Sub OnDataReceived(amp As AmplifierState)
        Try
            Dim incoming As String = amp.Port.ReadLine()
            If String.IsNullOrEmpty(incoming) Then Exit Sub
            Dim readData = incoming
            If readData.Length > 0 Then readData = readData.Substring(0, readData.Length - 1)
            amp.Port.DiscardInBuffer()

            Dim parts = readData.Split(","c)
            If parts.Length < 9 Then Exit Sub

            SyncLock amp.SyncRoot
                For i As Integer = 0 To amp.Channels.Count - 1
                    Dim csvIndex = 2 + (i * 2)
                    If csvIndex >= parts.Length Then Exit For
                    Dim raw As Double
                    If Not Double.TryParse(parts(csvIndex), Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture, raw) Then Continue For
                    Dim gapMm = amp.ModelRangeMm - raw
                    amp.Values(i) = gapMm
                    RaiseEvent Updated(amp.Channels(i).MappingIndex, gapMm)
                Next
            End SyncLock
        Catch ex As Exception
            RaiseLog("[KeyenceIL] " & amp.Port.PortName & " 수신 파싱: " & ex.Message)
        End Try
    End Sub

    Private Sub RaiseLog(msg As String)
        RaiseEvent LogMessage(msg)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If _disposed Then Return
        _disposed = True
        StopPolling()
        For Each amp As AmplifierState In _amplifiers
            amp.Port.Dispose()
        Next
    End Sub
End Class
