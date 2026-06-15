' ============================================================
'  전장팀 배선 핀맵 (현장 수기 — 이미지1 기준 2026-06-09 확정)
'  IN/OUT 표기·시퀀스 코드 = 핀번호 0-base (IN:00, OUT:00)
'  FBEI 드라이버만 내부 채널 1~32 — PinToChannel() 경계 변환
' ============================================================
Module IoMap

    ' --- 운전 스위치 핀 (0-base) ---
    Public Const PinStart As Integer = 0     ' IN:00 Start
    Public Const PinReset As Integer = 1     ' IN:01 Reset
    Public Const PinEStop As Integer = 2     ' IN:02 비상정지
    Public Const PinAirTool As Integer = 31  ' IN:31 에어 툴

    ' --- 입력 (인덱스 = 핀번호 00~31) ---
    Public ReadOnly InputNames() As String = {
        "스위치1 [Start]",              ' 00
        "스위치2 [Reset]",              ' 01
        "스위치3 [비상정지]",           ' 02
        "1번 핀전진 센서",              ' 03
        "1번 핀후진 센서",              ' 04
        "1번 클램프 센서",              ' 05
        "1번 언클램프 센서",            ' 06
        "지그 회전 클램프 센서",        ' 07
        "지그 회전 언클램프 센서",      ' 08
        "2번 핀전진 센서",              ' 09
        "2번 핀후진 센서",              ' 10
        "2번 클램프 센서",              ' 11
        "2번 언클램프 센서",            ' 12
        "지그 다운 센서",               ' 13
        "지그 업 센서",                 ' 14
        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",  ' 15~30 예비
        "에어 툴"                       ' 31
    }

    ' --- 출력 (인덱스 = 핀번호 00~11) ---
    ' OUT:00~05 = 1번 지그(회전 위치1), OUT:06~11 = 2번 지그(회전 위치2) — 현재 1번만 사용
    Public ReadOnly OutputNames() As String = {
        "1번 핀전진",                   ' OUT:00  제품 잡기
        "1번 핀후진",                   ' OUT:01
        "1번 클램프",                   ' OUT:02  제품 잡기
        "1번 언클램프",                 ' OUT:03
        "1번 지그회전 클램프",          ' OUT:04
        "1번 지그회전 언클램프",        ' OUT:05
        "2번 핀전진",                   ' OUT:06  (추후 회전위치2)
        "2번 핀후진",                   ' OUT:07
        "2번 클램프",                   ' OUT:08
        "2번 언클램프",                 ' OUT:09
        "2번 지그 다운",                ' OUT:10 → IN:13 위치확인
        "2번 지그 업"                   ' OUT:11 → IN:14 위치확인
    }

    Public Const Jig1OutPinStart As Integer = 0
    Public Const Jig1OutPinEnd As Integer = 5
    Public Const Jig2OutPinStart As Integer = 6
    Public Const Jig2OutPinEnd As Integer = 11

    ''' <summary>입력 핀 역할 (UI 색상·엣지 처리용)</summary>
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
