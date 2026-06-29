' ============================================================
'  전장팀 배선 핀맵 — Op01_PE IoMap.vb 와 동일 (이미지1 UI)
'  OP05: IN:00~02·IN:31 = COM(ESP), IN:03~14·OUT = FBEI
' ============================================================
Module IoMap

    Public Const PinStart As Integer = 0
    Public Const PinReset As Integer = 1
    Public Const PinEStop As Integer = 2
    Public Const PinAirTool As Integer = 31

    Public ReadOnly InputNames() As String = {
        "스위치1 [Start]",
        "스위치2 [Reset]",
        "스위치3 [비상정지]",
        "1번 핀전진 센서",
        "1번 핀후진 센서",
        "1번 클램프 센서",
        "1번 언클램프 센서",
        "지그 회전 클램프 센서",
        "지그 회전 언클램프 센서",
        "2번 핀전진 센서",
        "2번 핀후진 센서",
        "2번 클램프 센서",
        "2번 언클램프 센서",
        "지그 다운 센서",
        "지그 업 센서",
        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
        "에어 툴"
    }

    Public ReadOnly OutputNames() As String = {
        "1번 핀전진",
        "1번 핀후진",
        "1번 클램프",
        "1번 언클램프",
        "1번 지그회전 클램프",
        "1번 지그회전 언클램프",
        "2번 핀전진",
        "2번 핀후진",
        "2번 클램프",
        "2번 언클램프",
        "2번 지그 다운",
        "2번 지그 업"
    }

    Public Const Jig1OutPinStart As Integer = 0
    Public Const Jig1OutPinEnd As Integer = 5
    Public Const Jig2OutPinStart As Integer = 6
    Public Const Jig2OutPinEnd As Integer = 11

    Public Enum InputKind
        Normal
        Start
        ResetButton
        EmergencyStop
        AirTool
        JigUpSensor
    End Enum

    Public Function InputKindOf(pin As Integer) As InputKind
        Select Case pin
            Case 0 : Return InputKind.Start
            Case 1 : Return InputKind.ResetButton
            Case 2 : Return InputKind.EmergencyStop
            Case 14 : Return InputKind.JigUpSensor
            Case 31 : Return InputKind.AirTool
            Case Else : Return InputKind.Normal
        End Select
    End Function

    ''' <summary>OP05 — COM(ESP)에서 읽는 입력 핀</summary>
    Public Function IsComInputPin(pin As Integer) As Boolean
        Return pin = PinStart OrElse pin = PinReset OrElse pin = PinEStop OrElse pin = PinAirTool
    End Function

    Public Function ComChannelForPin(pin As Integer, settings As MultiMonitorSettings) As Integer
        If settings Is Nothing Then
            Select Case pin
                Case PinStart : Return 1
                Case PinReset : Return 2
                Case PinEStop : Return 3
                Case PinAirTool : Return 4
                Case Else : Return pin + 1
            End Select
        End If
        Select Case pin
            Case PinStart : Return settings.IoChannelStart()
            Case PinReset : Return settings.IoChannelReset()
            Case PinEStop : Return settings.IoChannelEStop()
            Case PinAirTool : Return settings.IoChannelAirTool()
            Case Else : Return pin + 1
        End Select
    End Function

    Public Function PinToChannel(pin As Integer) As Integer
        Return pin + 1
    End Function

    Public Function ChannelToPin(channel As Integer) As Integer
        Return channel - 1
    End Function

    Public Function InLabel(pin As Integer) As String
        Return "IN:" & pin.ToString("00")
    End Function

    Public Function OutLabel(pin As Integer) As String
        Return "OUT:" & pin.ToString("00")
    End Function

    Public Function GetIn(ios As FbeiIoClient, pin As Integer) As Boolean
        Return ios.GetInput(PinToChannel(pin))
    End Function

    Public Sub SetOut(ios As FbeiIoClient, pin As Integer, value As Boolean)
        ios.SetOutput(PinToChannel(pin), value)
    End Sub

End Module
