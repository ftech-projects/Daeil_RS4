Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Media
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO.Ports

Public Class FrmMain

    Private TmpToolCount As Integer
    Private StartTIme As String
    Private Tool1_Delay_count As Double
    Private Tool1_Ready As Boolean
    Private Tool_String1 As String
    Private Tool_Connection1 As Boolean
    Private Tool1_Count As Integer
    Private AtlasTools(1) As AtlasEthernetToolClient
    Private AtlasToolEnabled As Boolean
    Private ReadOnly _atlasConnected(1) As Boolean  ' T1/T2 실제 TCP 연결

    Private Timer As New HiResTimer()
    Private Const LogMaxLines As Integer = 500
    Private ReadOnly _logDedup As New Dictionary(Of String, String)

    ' === IO보드 (FBEI EtherNet/IP, 입력1 + 출력1) — 멜섹 PLC 대체 ===
    ' IP는 상수. 추후 config.json 로드/실측 보정.
    Private Const IoInputIp As String = "192.168.250.10"    ' 입력모듈 32DI (ch 1~32)
    Private Const IoOutputIp As String = "192.168.250.11"   ' 출력모듈 32DO (ch 1~32)
    Private Const IoRpiMs As Integer = 20
    Private WithEvents Ios As FbeiIoClient
    Private IoConnected As Boolean

    ' FBEI 운전 스위치 (ch1=Start, ch2=Reset, ch3=비상정지 NO — 누름=ON)
    Private IoInStart As Boolean
    Private IoInReset As Boolean
    Private IoInEStop As Boolean
    Private IoStartPrev As Boolean
    Private IoResetPrev As Boolean
    Private IoEStopPrev As Boolean
    Private _eStopLatched As Boolean
    Private Enum PeStartWait
        None = 0
        JigDown = 1
        JigUp = 2
        Unclamp = 3
    End Enum
    Private _peStartWait As PeStartWait = PeStartWait.None
    Private _partScannedReady As Boolean  ' wStep 0 품번 스캔·정보 표시 완료 → Start 대기
    Private AlarmMessage(100) As String
    Private _cachedMainSerialLength As Integer = -1
    Private Const PeSerialSeqDigits As Integer = 4

    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"

    Private OptionLHRH As String
    Private OptionType As String
    Private OptionBack As String
    Private OptionFootRest As Boolean
    Private OptionMonitor As Boolean

    Private TargetToolNum As Integer
    Private _usePeMonitorbracketTq As Boolean

    Private Const MonitorbracketTqCount As Integer = 4
    Private _dataMonitorbracketTq() As Label
    Private _decMonitorbracketTq() As Label
    Private _monitorbracketTqWired As Boolean

    Private D_OutString As String
    Private rStep As Double
    Private rCount As Double
    Private StartTimeL As String
    Private StartTimeR As String
    Private EndTime As String
    Private wStep As Double
    Private wCount As Double

    Public D_Value(0 To 48) As Integer
    ' IO보드 IN/OUT 인디케이터 (CW LED→일반 Label 변경). 와꾸 — 생성/배치는 다음 단계
    Public IN_LABEL(48) As Label
    Public OUT_LABEL(24) As Label

    Private Trd1 As Thread
    Private Trd2 As Thread
    Private Trd3 As Thread
    Private RecvString As New System.Text.StringBuilder()

    Private Player As New SoundPlayer

    Private ReadOnly Property SoundBasePath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "\SOUND\"
        End Get
    End Property

    Private Sub PlayNgSound()
        Player.SoundLocation = SoundBasePath & "NG.wav"
        Player.Load()
        Player.Play()
    End Sub

    Private Sub PlayOkSound()
        Player.SoundLocation = SoundBasePath & "DINGDONG.wav"
        Player.Load()
        Player.Play()
    End Sub

    Private Sub NG()
        PlayNgSound()
    End Sub

    Private Sub DingDOng()
        PlayOkSound()
    End Sub

    ''' <summary>srclbAlarm — 비상정지 전용 (그 외 안내는 txtMessage 로그만)</summary>
    Private Sub ShowEStopAlarm()
        srclbAlarm.Visible = True
        srclbAlarm.Text = "비상정지 — 리셋 후 재시작"
    End Sub

    Private Sub HideEStopAlarm()
        If _eStopLatched OrElse IoInEStop Then Return
        srclbAlarm.Visible = False
        srclbAlarm.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LoadPicture(ByVal picTarget As PictureBox, ByVal picName As String)

        Dim tmp As String = picName

        Try
            picTarget.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\Image\" & tmp & ".png")
        Catch ex As Exception
        End Try

        Try
            picTarget.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\Image\" & tmp & ".jpg")
        Catch ex As Exception
        End Try

        Try
            Mid(tmp, 5, 1) = "0"
            picTarget.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\Image\" & tmp & ".png")
        Catch ex As Exception
        End Try

        Try
            Mid(tmp, 5, 1) = "0"
            picTarget.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\Image\" & tmp & ".jpg")
        Catch ex As Exception
        End Try

        'LoadPicture(Picture_Main, "ASSEMBLE\NHGT")

    End Sub

    Private Sub Control2Arry()

        
    End Sub

    ' Init_Grid: FlexCell 제거로 미사용 — 참조 없음, 주석 처리
    'Private Sub Init_Grid(ByVal GridName As DataGridView)
    '   ... (미사용)
    'End Sub

    Private Sub EnsureMonitorbracketTqLabels()
        If _monitorbracketTqWired Then Return
        _dataMonitorbracketTq = {srclbDataMonitorbracketTq1, srclbDataMonitorbracketTq2, srclbDataMonitorbracketTq3, srclbDataMonitorbracketTq4}
        _decMonitorbracketTq = {srclbDecMonitorbracketTq1, srclbDecMonitorbracketTq2, srclbDecMonitorbracketTq3, srclbDecMonitorbracketTq4}
        _monitorbracketTqWired = True
        UpdateMonitorbracketTqHeader()
    End Sub

    Private Sub UpdateMonitorbracketTqHeader()
        Label19.Text = "모니터브라켓 T/Q"
        If IsPeMonitorbracketTqNa() Then
            srclbTargetMonitorbracketTq.Text = "NA"
        Else
            srclbTargetMonitorbracketTq.Text = MonitorbracketTqSpecText
        End If
    End Sub

    Private ReadOnly Property MonitorbracketTqSpecText As String
        Get
            Return BasicToolMin & " ~ " & BasicToolMax & " " & BAsicUnit
        End Get
    End Property

    Private Function IsPeMonitorbracketTqNa() As Boolean
        Return Not _usePeMonitorbracketTq
    End Function

    ''' <summary>모니터브라켓 T/Q 검사 사용 (Use_PE_MonitorbracketTq=1)</summary>
    Private Function PeNeedsMonitorbracketTq() As Boolean
        Return _usePeMonitorbracketTq
    End Function

    ''' <summary>에어툴 사용 (Target_PE_ToolNum ≠ 0·NULL)</summary>
    Private Function PeNeedsAirTool() As Boolean
        Return TargetToolNum > 0
    End Function

    Private Function IsPeAirToolNa() As Boolean
        Return Not PeNeedsAirTool()
    End Function

    Private Sub ResetMonitorbracketTqRow(ByVal index As Integer, ByVal markNa As Boolean)
        EnsureMonitorbracketTqLabels()
        If markNa Then
            _dataMonitorbracketTq(index).Text = "NA"
            _decMonitorbracketTq(index).Text = "NA"
            _decMonitorbracketTq(index).BackColor = Color.Green
        Else
            _dataMonitorbracketTq(index).Text = ""
            _decMonitorbracketTq(index).Text = ""
            _decMonitorbracketTq(index).BackColor = Color.Black
        End If
    End Sub

    Private Sub ResetAllMonitorbracketTq()
        Dim markNa As Boolean = IsPeMonitorbracketTqNa()
        For i As Integer = 0 To MonitorbracketTqCount - 1
            ResetMonitorbracketTqRow(i, markNa)
        Next
    End Sub

    Private Function GetNextMonitorbracketTqSlot() As Integer
        EnsureMonitorbracketTqLabels()
        For i As Integer = 0 To MonitorbracketTqCount - 1
            Dim state As String = _decMonitorbracketTq(i).Text
            If state <> "OK" AndAlso state <> "NA" Then Return i
        Next
        Return -1
    End Function

    Private Function AllMonitorbracketTqDone() As Boolean
        EnsureMonitorbracketTqLabels()
        For i As Integer = 0 To MonitorbracketTqCount - 1
            Dim state As String = _decMonitorbracketTq(i).Text
            If state <> "OK" AndAlso state <> "NA" AndAlso state <> "PASS" Then Return False
        Next
        Return True
    End Function

    Private Function SqlEscape(ByVal value As String) As String
        Return Trim(If(value, "")).Replace("'", "''")
    End Function

    Private Function ReadDbUseFlag(ByVal field As Object) As Boolean
        If field Is Nothing OrElse IsDBNull(field) Then Return False
        Dim s As String = Trim(CStr(field))
        If s = "" OrElse s = "0" Then Return False
        If String.Equals(s, "false", StringComparison.OrdinalIgnoreCase) Then Return False
        Return True
    End Function

    ''' <summary>클램프 완료 후 wStep 3 — 모니터브라켓 T/Q (Use_PE_MonitorbracketTq=1 일 때만)</summary>
    Private Sub BeginMonitorbracketWorkStep()
        _peStartWait = PeStartWait.None
        For i As Integer = 0 To MonitorbracketTqCount - 1
            ResetMonitorbracketTqRow(i, False)
        Next

        srclbDataTool.Text = ""
        srclbDecTool.Text = ""
        srclbDecTool.BackColor = Color.Black

        WriteTxtMessage("[IO] 제품 고정 완료 — 모니터브라켓 T/Q 시작 (4회)")
    End Sub

    ''' <summary>클램프 완료(IN 확인) 후 다음 공정 분기</summary>
    Private Sub RouteAfterClampComplete()
        If PeNeedsMonitorbracketTq() Then
            wStep = 3
            BeginMonitorbracketWorkStep()
        ElseIf PeNeedsAirTool() Then
            wStep = 3.1
            _peStartWait = PeStartWait.JigDown
            WriteTxtMessage("[IO] 클램프 완료 — T/Q N/A, Start 대기 (지그 다운)")
        Else
            wStep = 3.7
            _peStartWait = PeStartWait.Unclamp
            WriteTxtMessage("[IO] 클램프 완료 — T/Q·에어툴 N/A, Start 대기 (언클램프)")
        End If
    End Sub

    ''' <summary>모니터브라켓 T/Q 4회 완료 후 다음 공정 분기</summary>
    Private Sub RouteAfterTqComplete()
        If PeNeedsAirTool() Then
            _peStartWait = PeStartWait.JigDown
            WriteTxtMessage("[IO] 모니터브라켓 T/Q 완료 — Start 대기 (지그 다운)")
        Else
            wStep = 3.7
            _peStartWait = PeStartWait.Unclamp
            WriteTxtMessage("[IO] 모니터브라켓 T/Q 완료 — 에어툴 N/A, Start 대기 (언클램프)")
        End If
    End Sub

    ''' <summary>언클램프 시작 — 1·2번 OUT:03,09→IN:06,12 / OUT:01,07→IN:04,10</summary>
    Private Sub BeginPeUnclamp()
        If Ios Is Nothing OrElse Not IoConnected Then
            WriteTxtMessage("[IO] 언클램프 거부 — IO 미연결")
            Return
        End If
        If Not JigClampSequence.IsJigAtUp(Ios) Then
            WriteTxtMessage("[IO] 언클램프 거부 — IN:14 ON, IN:13 OFF 필요")
            NG()
            Return
        End If
        _peStartWait = PeStartWait.None
        JigClampSequence.BeginRelease()
        wStep = 3.9
        WriteTxtMessage("[IO] 제품 해제 시작 (wStep 3.9)")
    End Sub

    Private Sub SavePeMonitorbracketTqToMain(ByVal slot As Integer, ByVal tqValue As String)
        If srcLbSerial.Text = "" OrElse slot < 0 OrElse slot >= MonitorbracketTqCount Then Return
        Dim col As String = "PE_MonitorbracketTq" & CStr(slot + 1)
        Try
            ConnectionOpenSQL()
            Dim sql As String = "UPDATE TABLE_MAIN SET " & col & " = '" & SqlEscape(tqValue) &
                "' WHERE SerialNo = '" & SqlEscape(srcLbSerial.Text) & "'"
            SqlConnect.Execute(sql)
            WriteTxtMessage("[DB] " & col & " 저장 — " & tqValue)
        Catch ex As Exception
            WriteTxtMessage("[DB] " & col & " 저장 실패 — " & ex.Message)
        Finally
            ConnectionCloseSQL()
        End Try
    End Sub

    Private Sub SavePeWorkToMain()
        EnsureMonitorbracketTqLabels()
        Try
            ConnectionOpenSQL()
            Dim sql As String = "UPDATE TABLE_MAIN SET " &
                "PE_Date = '" & Format(Now, "yyyy-MM-dd") & "'," &
                "PE_StartTime = '" & SqlEscape(StartTime) & "'," &
                "PE_EndTime = '" & Format(Now, "HH:mm:ss") & "'," &
                "PE_MonitorbracketTq1 = '" & SqlEscape(_dataMonitorbracketTq(0).Text) & "'," &
                "PE_MonitorbracketTq2 = '" & SqlEscape(_dataMonitorbracketTq(1).Text) & "'," &
                "PE_MonitorbracketTq3 = '" & SqlEscape(_dataMonitorbracketTq(2).Text) & "'," &
                "PE_MonitorbracketTq4 = '" & SqlEscape(_dataMonitorbracketTq(3).Text) & "'," &
                "PE_Decision = 'OK' " &
                "WHERE SerialNo = '" & SqlEscape(srcLbSerial.Text) & "'"
            SqlConnect.Execute(sql)
            WriteTxtMessage("[DB] PE 작업 실적 저장 — " & srcLbSerial.Text)
            PlayOkSound()
        Catch ex As Exception
            WriteTxtMessage("[DB] PE 작업 저장 실패 — " & ex.Message)
            NG()
        Finally
            ConnectionCloseSQL()
        End Try
    End Sub

    Private Sub ApplyMonitorbracketTqResult(ByVal slot As Integer, ByVal torqueNm As Double, ByVal controllerOk As Boolean)
        If InvokeRequired Then
            BeginInvoke(New Action(Of Integer, Double, Boolean)(AddressOf ApplyMonitorbracketTqResult), slot, torqueNm, controllerOk)
            Return
        End If

        EnsureMonitorbracketTqLabels()
        Dim tqText As String = torqueNm.ToString("0.00")
        Dim isOk As Boolean = controllerOk AndAlso torqueNm >= BasicToolMin AndAlso torqueNm <= BasicToolMax
        _dataMonitorbracketTq(slot).Text = tqText
        If isOk Then
            _decMonitorbracketTq(slot).Text = "OK"
            _decMonitorbracketTq(slot).BackColor = Color.Blue
            SavePeMonitorbracketTqToMain(slot, tqText)
            PlayOkSound()
            WriteTxtMessage("[T/Q] 모니터브라켓 T/Q " & CStr(slot + 1) & " = " & tqText & " OK")
        Else
            _decMonitorbracketTq(slot).Text = "NG"
            _decMonitorbracketTq(slot).BackColor = Color.Red
            SavePeMonitorbracketTqToMain(slot, tqText)
            PlayNgSound()
            WriteTxtMessage("[T/Q] 모니터브라켓 T/Q " & CStr(slot + 1) & " = " & tqText & " NG")
        End If
    End Sub

    Private Sub InitControl()

        EnsureMonitorbracketTqLabels()

        LoadPicture(srcPictureBox, "NON")
        srcLbPartNo.Text = ""
        srcLbPartName.Text = ""
        srcLbPartOption.Text = ""
        srcLbSerial.Text = ""

        _usePeMonitorbracketTq = False
        ResetAllMonitorbracketTq()

        srclbDataTool.Text = ""
        srclbDecTool.Text = ""
        srclbDecTool.BackColor = Color.Black

        _peStartWait = PeStartWait.None
        _partScannedReady = False

    End Sub

    ''' <summary>공정 Start 시 판정값만 초기화 (스캔으로 표시한 품번 정보 유지)</summary>
    Private Sub InitJudgmentOnly()

        _peStartWait = PeStartWait.None

        For i As Integer = 0 To MonitorbracketTqCount - 1
            ResetMonitorbracketTqRow(i, IsPeMonitorbracketTqNa())
        Next

        If PeNeedsAirTool() Then
            srclbDataTool.Text = ""
            srclbDecTool.Text = ""
            srclbDecTool.BackColor = Color.Black
        Else
            srclbDataTool.Text = "NA"
            srclbDecTool.Text = "NA"
            srclbDecTool.BackColor = Color.Green
        End If

    End Sub

    Sub SerialOpen()

        Try
            If Serial_Printer.IsOpen() = True Then
                Serial_Printer.Close()
            End If
            Serial_Printer.PortName = PortNumber_Printer
            Serial_Printer.BaudRate = 9600
            Serial_Printer.DataBits = 8
            Serial_Printer.Open()
            WriteTxtMessage("Serial Printer Open Success" & PortNumber_Printer)
        Catch ex As Exception
            WriteTxtMessage("Serial Printer Open Fail")
        End Try

        ' 시리얼 툴(COM) — Atlas LAN과 병행, 비상 폴백 항상 활성
        EnsureSerialToolOpen()

        Try
            If Serial_Scanner.IsOpen() = True Then
                Serial_Scanner.Close()
            End If
            Serial_Scanner.PortName = PortNumber_Scanner
            Serial_Scanner.BaudRate = 9600
            Serial_Scanner.DataBits = 8
            Serial_Scanner.Parity = IO.Ports.Parity.None
            Serial_Scanner.Handshake = Ports.Handshake.RequestToSendXOnXOff
            Serial_Scanner.Open()
            WriteTxtMessage("Serial Scanner Open Success " & PortNumber_Scanner)
        Catch ex As Exception
            WriteTxtMessage("Serial Scanner Open Fail")
        End Try

    End Sub

    Sub BarcodePrint(ByVal strSerial As String, ByVal strPartno As String)

        'Serial_Printer.Write("^FO" & BarcodeBX & "," & BarcodeBY & "^BXN," & BarcodeBH & "," & BarcodeBL & ",0,0,,^FH^FD" & strSerial & "^FS")

        Serial_Printer.Write("^XA")
        Serial_Printer.Write("^FO" & BarcodeBX & "," & BarcodeBY & "^BQN," & BarcodeBH & "," & BarcodeBL & "^FDMM,A" & strSerial & "^FS")
        Serial_Printer.Write("^FO" & BarcodeS1X & "," & BarcodeS1Y & "^A0N," & BarcodeS1H & "," & BarcodeS1W & "^FD" & strPartno & "^FS")
        Serial_Printer.Write("^FO" & BarcodeS2X & "," & BarcodeS2Y & "^A0N," & BarcodeS2H & "," & BarcodeS2W & "^FD" & strSerial & "^FS")
        Serial_Printer.Write("^FO" & BarcodeS3X & "," & BarcodeS3Y & "^A0N," & BarcodeS3H & "," & BarcodeS3W & "^FD" & Format(Now, "yyyy.MM.dd") & " " & Format(Now, "HH:mm") & "^FS")
        Serial_Printer.Write("^XZ")

    End Sub

    Private Function LoadPArt(ByVal str As String, Optional ByRef faultMessage As String = Nothing) As Boolean

        faultMessage = ""

        ConnectionOpenSQL()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part WHERE PartNo = '" & Mid(str, 1, 11) & "'", SqlConnect)

        If Rs.RecordCount <> 1 Then
            faultMessage = "DB에 없는 품번 — " & str
            Rs.ActiveConnection = Nothing
            Rs.Close()
            ConnectionCloseSQL()
            Return False
        End If

        Dim partOptionType As String = Trim(CStr(Rs.Fields("OptionType").Value))

        srcLbPartName.Text = Trim(Rs.Fields("PartName").Value)
        LoadPicture(srcPictureBox, Mid(str, 1, 11))

        OptionLHRH = Trim(Rs.Fields("OptionLHRH").Value)
        OptionType = partOptionType
        OptionBack = Trim(Rs.Fields("OptionBack").Value)
        OptionFootRest = Rs.Fields("OptionFootRest").Value
        OptionMonitor = Rs.Fields("OptionMon").Value

        srcLbPartOption.Text = OptionType & " " & OptionLHRH
        srcLbPartNo.Text = Trim(CStr(Rs.Fields("PartNo").Value))
        TargetToolNum = CInt(Val(Trim(CStr(Rs.Fields("Target_PE_ToolNum").Value))))
        _usePeMonitorbracketTq = ReadDbUseFlag(Rs.Fields("Use_PE_MonitorbracketTq").Value)
        UpdateMonitorbracketTqHeader()

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()
        Return True

    End Function

    Private Function NormalizePartNo(ByVal partNo As String) As String
        Return Trim(If(partNo, ""))
    End Function

    ''' <summary>서버 Table_Main SerialNo 길이 (없으면 26)</summary>
    Private Function GetMainSerialNoLength() As Integer
        If _cachedMainSerialLength > 0 Then Return _cachedMainSerialLength

        Dim Rs As New ADODB.Recordset
        _cachedMainSerialLength = 26
        Try
            ConnectionOpenSQL()
            Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            Rs.LockType = ADODB.LockTypeEnum.adLockReadOnly
            Rs.Open("SELECT TOP 1 LEN(SerialNo) AS SerialLen FROM Table_Main WHERE SerialNo IS NOT NULL AND SerialNo <> '' ORDER BY Op01_Date DESC", SqlConnect)
            If Not Rs.EOF AndAlso Not IsDBNull(Rs.Fields("SerialLen").Value) Then
                Dim len As Integer = CInt(Rs.Fields("SerialLen").Value)
                If len > 0 Then _cachedMainSerialLength = len
            End If
        Catch ex As Exception
            WriteTxtMessage("[DB] SerialNo 길이 조회 실패 — 기본 26 (" & ex.Message & ")")
        Finally
            If Rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                Rs.ActiveConnection = Nothing
                Rs.Close()
            End If
            ConnectionCloseSQL()
        End Try
        Return _cachedMainSerialLength
    End Function

    ''' <summary>당일 yyyyMMdd 접두 SerialNo 최대 순번 (없으면 0)</summary>
    Private Function GetTodaySerialMaxSeq() As Integer
        Dim dateToken As String = Format(Now, "yyyyMMdd")
        Dim Rs As New ADODB.Recordset
        Try
            ConnectionOpenSQL()
            Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            Rs.LockType = ADODB.LockTypeEnum.adLockReadOnly
            Rs.Open(
                "SELECT MAX(CAST(SUBSTRING(SerialNo, 9, " & PeSerialSeqDigits & ") AS INT)) AS MaxSeq " &
                "FROM Table_Main WHERE LEN(SerialNo) = " & GetMainSerialNoLength() &
                " AND SerialNo LIKE '" & SqlEscape(dateToken) & "%'", SqlConnect)
            If Not Rs.EOF AndAlso Not IsDBNull(Rs.Fields("MaxSeq").Value) Then
                Return CInt(Rs.Fields("MaxSeq").Value)
            End If
            Return 0
        Catch ex As Exception
            WriteTxtMessage("[DB] 당일 시리얼 순번 조회 실패 — " & ex.Message)
            Return 0
        Finally
            If Rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                Rs.ActiveConnection = Nothing
                Rs.Close()
            End If
            ConnectionCloseSQL()
        End Try
    End Function

    ''' <summary>임시 PE 시리얼 — yyyyMMdd + 일일순번(0001~) + 품번, 길이=Table_Main.SerialNo</summary>
    Private Function CreatePeSerial(ByVal partNo As String) As String
        partNo = NormalizePartNo(partNo)
        Dim totalLen As Integer = GetMainSerialNoLength()
        Dim dateToken As String = Format(Now, "yyyyMMdd")
        Dim seq As Integer = GetTodaySerialMaxSeq() + 1
        Dim partLen As Integer = totalLen - dateToken.Length - PeSerialSeqDigits
        If partLen < 1 Then partLen = 14

        Dim partToken As String = partNo
        If partToken.Length > partLen Then
            partToken = partToken.Substring(0, partLen)
        ElseIf partToken.Length < partLen Then
            partToken = partToken.PadRight(partLen, " "c)
        End If

        Return dateToken & Format(seq, New String("0"c, PeSerialSeqDigits)) & partToken
    End Function

    ''' <summary>임시 모드 — 자동생성 SerialNo가 Table_Main에 없으면 최소 행 INSERT</summary>
    Private Sub EnsurePeMainRow()
        If srcLbSerial.Text = "" OrElse srcLbPartNo.Text = "" Then Return
        Dim Rs As New ADODB.Recordset
        Try
            ConnectionOpenSQL()
            Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            Rs.LockType = ADODB.LockTypeEnum.adLockReadOnly
            Rs.Open("SELECT SerialNo FROM Table_Main WHERE SerialNo = '" & SqlEscape(srcLbSerial.Text) & "'", SqlConnect)
            If Rs.RecordCount > 0 Then Return

            Dim sql As String = "INSERT INTO Table_Main (PartNo, SerialNo, PE_Date) VALUES (" &
                "'" & SqlEscape(srcLbPartNo.Text) & "'," &
                "'" & SqlEscape(srcLbSerial.Text) & "'," &
                "'" & Format(Now, "yyyy-MM-dd") & "')"
            SqlConnect.Execute(sql)
            WriteTxtMessage("[DB] Table_Main 임시 행 생성 — " & srcLbSerial.Text)
        Catch ex As Exception
            WriteTxtMessage("[DB] Table_Main 임시 행 생성 실패 — " & ex.Message)
        Finally
            If Rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                Rs.ActiveConnection = Nothing
                Rs.Close()
            End If
            ConnectionCloseSQL()
        End Try
    End Sub

    ''' <summary>라벨/시리얼 스캔에서 품번 추출 (26자 라벨 또는 품번만 스캔)</summary>
    Private Function ExtractPartNoFromScan(ByVal scanData As String) As String
        Dim s As String = Trim(scanData)
        If s = "" Then Return ""
        If s.Length >= 26 Then
            Return NormalizePartNo(Mid(s, 13, 14))
        End If
        If s.Length >= 11 Then
            Return NormalizePartNo(s)
        End If
        Return ""
    End Function

    ' ========================================================================
    ' ★ TEMP_SCAN_BYPASS — 205 벤치·테스트 전용 (임의 구현). 정식 라벨 투입 시 제거.
    '   현재: GS1 P/T 역파싱 + Table_Main 없어도 바코드 품번으로 LoadPArt
    '   정식: 스캐너가 26자 SerialNo만 읽음 → Table_Main 조회 필수 → Main.PartNo로 LoadPArt
    '   제거 대상: IsGs1LabelScan, TryParseGs1LabelScan, TryParseLabelScan,
    '              TryLookupMainPartNo, TryResolveLabelScan → TryResolveMainLabelScan 복원
    ' ========================================================================

    Private Function IsGs1LabelScan(ByVal scanData As String) As Boolean
        Dim s As String = Trim(If(scanData, ""))
        Return s.Contains(Chr(29)) OrElse s.StartsWith("[)>")
    End Function

    ''' <summary>[TEMP] GS1 DataMatrix — OP05 BarcodePrint 역변환. 정식 라벨 적용 시 제거.</summary>
    Private Function TryParseGs1LabelScan(ByVal scanData As String, ByRef serial As String, ByRef partNo As String, ByRef faultMessage As String) As Boolean
        faultMessage = ""
        serial = ""
        partNo = ""

        Dim pField As String = ""
        Dim tField As String = ""
        For Each seg As String In Split(Trim(scanData), Chr(29))
            Dim t As String = Trim(seg)
            If t.Length = 0 Then Continue For
            t = t.Trim(ChrW(30)).Trim(ChrW(4))
            If t.StartsWith("P", StringComparison.OrdinalIgnoreCase) AndAlso t.Length > 1 Then pField = t
            If t.StartsWith("T", StringComparison.OrdinalIgnoreCase) AndAlso t.Length > 1 Then tField = t
        Next

        If pField = "" OrElse tField = "" Then
            faultMessage = "GS1 라벨 P/T 필드 없음"
            Return False
        End If

        Dim pBody As String = pField.Substring(1).Trim()
        If pBody.Length < 6 Then
            faultMessage = "GS1 P 필드 품번 길이 부족"
            Return False
        End If

        Dim part14 As String = (pBody.Substring(0, 5) & "-" & pBody.Substring(5)).PadRight(14)
        If part14.Length > 14 Then part14 = part14.Substring(0, 14)
        partNo = NormalizePartNo(part14.TrimEnd())

        If tField.Length < 16 Then
            faultMessage = "GS1 T 필드 길이 부족"
            Return False
        End If

        Dim date6 As String = tField.Substring(1, 6)
        Dim seq4 As String = ""
        Dim a000Idx As Integer = tField.IndexOf("A000", StringComparison.Ordinal)
        If a000Idx >= 0 AndAlso tField.Length >= a000Idx + 8 Then
            seq4 = tField.Substring(a000Idx + 4, 4)
        Else
            seq4 = tField.Substring(15, 4)
        End If

        serial = ("20" & date6 & seq4 & part14).Substring(0, 26)
        Return True
    End Function

    ''' <summary>[TEMP] 라벨 스캔 — GS1 또는 26자 평문. 정식 라벨 적용 시 제거.</summary>
    Private Function TryParseLabelScan(ByVal scanData As String, ByRef serial As String, ByRef partNo As String, ByRef faultMessage As String) As Boolean
        faultMessage = ""
        serial = ""
        partNo = ""

        If IsGs1LabelScan(scanData) Then
            Return TryParseGs1LabelScan(scanData, serial, partNo, faultMessage)
        End If

        Dim raw As String = Trim(If(scanData, ""))
        If raw.Length < 26 Then
            faultMessage = "라벨 형식 오류 — GS1 또는 26자 시리얼 필요"
            Return False
        End If

        serial = raw.Substring(0, 26)
        partNo = NormalizePartNo(Mid(raw, 13, 14))
        If partNo = "" Then
            faultMessage = "라벨 품번 추출 실패"
            Return False
        End If
        Return True
    End Function

    ''' <summary>[TEMP] Table_Main 있으면 PartNo 참고. 정식 라벨 적용 시 Main 필수 조회로 복원.</summary>
    Private Function TryLookupMainPartNo(ByVal serial As String, ByRef mainPartNo As String) As Boolean
        mainPartNo = ""
        If Trim(serial) = "" Then Return False

        Dim Rs As New ADODB.Recordset
        ConnectionOpenSQL()
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockReadOnly

        Try
            Rs.Open("SELECT PartNo FROM Table_Main WHERE SerialNo = '" & SqlEscape(serial) & "'", SqlConnect)
            If Rs.RecordCount <> 1 Then Return False
            mainPartNo = NormalizePartNo(CStr(Rs.Fields("PartNo").Value))
            Return mainPartNo <> ""
        Finally
            If Rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                Rs.ActiveConnection = Nothing
                Rs.Close()
            End If
            ConnectionCloseSQL()
        End Try
    End Function

    ''' <summary>[TEMP] 테스트용 스캔 해석. 정식 라벨 적용 시 TryResolveMainLabelScan으로 교체.</summary>
    Private Function TryResolveLabelScan(ByVal scanData As String, ByRef serial As String, ByRef partNo As String, ByRef faultMessage As String) As Boolean
        If Not TryParseLabelScan(scanData, serial, partNo, faultMessage) Then Return False

        Dim mainPart As String = ""
        If TryLookupMainPartNo(serial, mainPart) Then
            partNo = mainPart
            WriteTxtMessage("[SCAN] Table_Main 실적 확인 — SerialNo: " & serial & " PartNo: " & partNo)
        Else
            WriteTxtMessage("[SCAN] Table_Main 실적 없음 — 바코드 품번 사용: " & partNo & " SerialNo: " & serial)
        End If
        Return True
    End Function

    ''' <summary>스캔 품번 → DB 로드·화면 표시 (wStep 0, Start 전 확인용)</summary>
    Private Sub ApplyPartPreviewTargets()
        If PeNeedsAirTool() Then
            srclbTargetTool.Text = CStr(TargetToolNum)
            srclbDataTool.Text = ""
            srclbDecTool.Text = ""
            srclbDecTool.BackColor = Color.Black
        Else
            srclbTargetTool.Text = "NA"
            srclbDataTool.Text = "NA"
            srclbDecTool.Text = "NA"
            srclbDecTool.BackColor = Color.Green
        End If

        ResetAllMonitorbracketTq()
        UpdateMonitorbracketTqHeader()
    End Sub

    Private Sub HandleIdlePartScan(ByVal scanData As String)
        If wStep <> 0 OrElse _eStopLatched OrElse IoInEStop Then Exit Sub

        Dim serial As String = ""
        Dim partNo As String = ""
        Dim scanFault As String = ""
        If Not TryResolveLabelScan(scanData, serial, partNo, scanFault) Then
            WriteTxtMessage("[SCAN] " & scanFault)
            NG()
            _partScannedReady = False
            Return
        End If

        Dim loadFault As String = ""
        If Not LoadPArt(partNo, loadFault) Then
            WriteTxtMessage("[SCAN] " & loadFault)
            NG()
            _partScannedReady = False
            Return
        End If

        srcLbSerial.Text = serial

        FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, Mid(partNo, 1, 11))
        ApplyPartPreviewTargets()

        _partScannedReady = True
        WriteTxtMessage("[SCAN] Op01 라벨 OK — " & serial & " / " & partNo & " (Start 대기)")
        PlayOkSound()
    End Sub

    Private Function OptionConvert(str As String) As String

        Dim tmp As String

        If str = "ON" Then
            tmp = ""
        ElseIf str = "OFF" Then
            tmp = ""
        ElseIf str = "PASS" Then
            tmp = "PASS"
        End If

        Return tmp

    End Function

    Private Function OptionConvertInt(str As String) As Integer

        Dim tmp As Integer

        If str = "ON" Then
            tmp = 1
        ElseIf str = "OFF" Then
            tmp = 0
        ElseIf str = "PASS" Then
            tmp = 100
        End If

        Return tmp

    End Function

    Private Sub SaveDB()
        SavePeWorkToMain()
    End Sub

    Private Function STR2ASC(ByVal str As String) As String

        Dim tmp As String = ""
        Dim i As Integer

        For i = 1 To Len(str)
            tmp = tmp & Hex(Asc(Mid(str, i, 1)))
        Next

        Return tmp

    End Function

    ''' <summary>로그 추가 — dedupKey 동일 메시지 반복 억제(상태 변경·재시도 시 다시 출력)</summary>
    Private Sub WriteTxtMessage(ByVal strMessage As String, Optional dedupKey As String = Nothing)
        If dedupKey IsNot Nothing Then
            Dim prev As String = Nothing
            If _logDedup.TryGetValue(dedupKey, prev) AndAlso prev = strMessage Then Return
            _logDedup(dedupKey) = strMessage
        End If

        If InvokeRequired Then
            BeginInvoke(New Action(Of String, String)(AddressOf WriteTxtMessage), strMessage, dedupKey)
            Return
        End If

        Dim scrollToEnd As Boolean = (txtMessage.TextLength = 0) OrElse
            (txtMessage.SelectionStart >= txtMessage.TextLength - 2)
        Dim line As String = Format(Now, "yyyy-MM-dd HH:mm:ss") & ": " & strMessage & Environment.NewLine

        txtMessage.AppendText(line)
        TrimLogLines()

        If scrollToEnd Then
            txtMessage.SelectionStart = txtMessage.Text.Length
            txtMessage.ScrollToCaret()
        End If
    End Sub

    Private Sub ClearLogDedup(dedupKey As String)
        If dedupKey IsNot Nothing Then _logDedup.Remove(dedupKey)
    End Sub

    Private Sub TrimLogLines()
        Dim lines() As String = txtMessage.Lines
        If lines.Length <= LogMaxLines Then Return
        Dim keep(LogMaxLines - 1) As String
        Array.Copy(lines, lines.Length - LogMaxLines, keep, 0, LogMaxLines)
        txtMessage.Lines = keep
        txtMessage.SelectionStart = txtMessage.Text.Length
        txtMessage.ScrollToCaret()
    End Sub

    Private Function ASC2STR(ByVal str As String) As String

        Dim One_Hex, Tmp_Hex, retVal As String
        Dim i As Integer

        retVal = ""
        For i = 1 To Len(str)
            One_Hex = Mid(str, i, 1)
            If IsNumeric(One_Hex) Then
                Tmp_Hex = Mid(str, i, 2)
                i = i + 1
            Else
                Tmp_Hex = Mid(str, i, 4)
                i = i + 3
            End If
            retVal = retVal & Chr("&H" & Tmp_Hex)
        Next
        Return retVal

    End Function

    
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        ' DB(SQL/MDB)·시리얼 초기화 — 신규 타겟에 DB/포트 없어도 IO는 떠야 하므로 경계 catch
        Try
            LoadPortData()
            LoadBarcodeData()
            LoadBasicData()
            WriteTxtMessage("[CFG] 토크 " & BasicToolMin & "~" & BasicToolMax & " " & BAsicUnit &
                " | Atlas T1=" & AtlasTool1Ip & " T2=" & AtlasTool2Ip)
            EnsureMonitorbracketTqLabels()
            UpdateMonitorbracketTqHeader()
            LoadALarmMessage()
            InitControl()
            WriteTxtMessage("Init Complete")
            SerialOpen()              ' COM3 비상 폴백 — Atlas보다 먼저 오픈
            InitializeAtlasTools()
            InitGrid()
            LoadGrid()
        Catch ex As Exception
            WriteTxtMessage("초기화 일부 실패(DB/시리얼 없음?): " & ex.Message)
        End Try

        Timer1.Interval = 100
        Timer1.Start()

        WriteTxtMessage("System Ready..")

        HideDeadPlcDisplay()
        InitializeIoDevices()     ' FBEI I/O 연결
        AddHandler JigClampSequence.JigLog, AddressOf OnJigClampLog
        JigClampSequence.EnableAllMotionSensors()
        ' 1번 지그 클램프·언클램프 센서 미동작 — IN:05/06 위치확인 우회(정비 후 SetSensorRequired(5/6, True))
        JigClampSequence.SetSensorRequired(5, False)
        JigClampSequence.SetSensorRequired(6, False)
        WriteTxtMessage("[JIG] IN:05/06 센서 우회 — 1번 클램프·언클램프 위치확인 생략(3초 타이머)")
        AddIoMenu()
        Label11.Text = IoInputIp

        ' EnsureSerialToolOpen에서 스레드 기동 — 중복 생성 방지
        EnsureSerialToolThread()

        Tmr_Connect.Interval = 100
        Tmr_Connect.Start()
        wStep = 0

        Tmr_Work.Interval = 100
        Tmr_Work.Start()

        FrmWorkStandard.WindowState = FormWindowState.Normal
        FrmWorkStandard.Location = New Point(-2000, 0)
        FrmWorkStandard.WindowState = FormWindowState.Maximized
        FrmWorkStandard.Show()

    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler JigClampSequence.JigLog, AddressOf OnJigClampLog
        Try
            JigClampSequence.Abort()
            If Ios IsNot Nothing Then JigClampSequence.AllMotionOutputsOff(Ios)
        Catch
        End Try
        Try
            If Ios IsNot Nothing Then Ios.Dispose()
        Catch
        End Try
        StopAtlasTools()
    End Sub

    Private Sub SyncIoInputs()
        If Ios Is Nothing OrElse Not IoConnected Then
            PlcConnectionError = "DISCONNECTED"
            Exit Sub
        End If
        Try
            IoSignalMap.SyncInputsToPlc(Ios)
            IoInStart = IoMap.GetIn(Ios, IoMap.PinStart)
            IoInReset = IoMap.GetIn(Ios, IoMap.PinReset)
            IoInEStop = IoMap.GetIn(Ios, IoMap.PinEStop)
            PlcConnectionError = "OK"
        Catch ex As Exception
            PlcConnectionError = ex.Message
        End Try
    End Sub

    Private Sub UpdateIoConnectionDisplay()
        SyncIoInputs()
        If PlcConnectionError = "OK" Then
            srcLbPlcConnectionState.Text = "IO OK"
            srcLbPlcConnectionState.BackColor = Color.Blue
            srcLbPlcConnectionState.ForeColor = Color.White
        ElseIf PlcConnectionError = "DISCONNECTED" Then
            srcLbPlcConnectionState.Text = "IO NG"
            srcLbPlcConnectionState.BackColor = Color.Red
            srcLbPlcConnectionState.ForeColor = Color.White
        Else
            srcLbPlcConnectionState.Text = "IO ERR"
            srcLbPlcConnectionState.BackColor = Color.Red
            srcLbPlcConnectionState.ForeColor = Color.White
        End If
    End Sub

    ''' <summary>IO보드(FBEI EtherNet/IP, 입력2+출력1) 초기화 + 연결. 와꾸 — 연결/로그만.</summary>
    Private Sub InitializeIoDevices()
        Try
            Ios = New FbeiIoClient(IoInputIp, IoOutputIp, rpiMs:=IoRpiMs)
            Ios.Connect()
            IoConnected = True
            ClearLogDedup("FBEI_DI_SCAN")
            ClearLogDedup("FBEI_OUT_WRITE")
            WriteTxtMessage($"[FBEI] 연결 (IN={IoInputIp}, OUT={IoOutputIp})", "FBEI_CONN_OK")
        Catch ex As Exception
            IoConnected = False
            WriteTxtMessage("[FBEI] 초기화 실패: " & ex.Message, "FBEI_CONN_FAIL")
        End Try
    End Sub

    Private Sub Ios_LogMessage(message As String) Handles Ios.LogMessage
        Dim dedupKey As String = Nothing
        If message.Contains("스캔 예외") Then dedupKey = "FBEI_DI_SCAN"
        If message.Contains("출력 쓰기 예외") Then dedupKey = "FBEI_OUT_WRITE"
        If message.Contains("전원 에러") Then dedupKey = "FBEI_POWER_ERR"
        WriteTxtMessage(message, dedupKey)
    End Sub

    ''' <summary>입력 채널 변화 → PlcValue + Start/Reset/비상정지 엣지 처리</summary>
    Private Sub Ios_InputChanged(channel As Integer, value As Boolean) Handles Ios.InputChanged
        If InvokeRequired Then
            BeginInvoke(New Action(Of Integer, Boolean)(AddressOf Ios_InputChanged), channel, value)
            Return
        End If
        IoSignalMap.ApplyInputChange(channel, value)

        Select Case IoMap.ChannelToPin(channel)
            Case IoMap.PinStart
                IoInStart = value
                If value AndAlso Not IoStartPrev Then HandleStartPress()
                IoStartPrev = value
            Case IoMap.PinReset
                IoInReset = value
                If value AndAlso Not IoResetPrev Then HandleResetPress()
                IoResetPrev = value
            Case IoMap.PinEStop
                ' NO 접점(현장): 평상시=OFF, 누름=ON → 비상정지 (NC Not value 사용 금지 — 기동 시 오검출)
                IoInEStop = value
                If IoInEStop AndAlso Not IoEStopPrev Then HandleEmergencyStop()
                IoEStopPrev = IoInEStop
            Case IoMap.PinAirTool
                ' 에어툴 IN:31 — Atlas 사용 여부와 무관 (현장 에어 스위치)
                If value AndAlso wStep = 3.4 AndAlso PeNeedsAirTool() Then HandleAirToolPulse()
        End Select
    End Sub

    ''' <summary>Start — wStep 0 공정시작 / 중간 대기 시 지그·언클램프</summary>
    Private Sub HandleStartPress()
        If _eStopLatched OrElse IoInEStop Then
            WriteTxtMessage("[IO] Start 무시 — 비상정지 상태")
            Return
        End If

        If Ios Is Nothing OrElse Not IoConnected Then
            WriteTxtMessage("[IO] Start 거부 — IO 보드 미연결")
            Return
        End If

        ' 지그 다운 (T/Q 완료 또는 클램프만+에어툴)
        If (wStep = 3 OrElse wStep = 3.1) AndAlso _peStartWait = PeStartWait.JigDown Then
            If wStep = 3 AndAlso Not AllMonitorbracketTqDone() Then
                WriteTxtMessage("[IO] Start 무시 — 모니터브라켓 T/Q 미완료")
                Return
            End If
            If Not JigClampSequence.IsJigAtUp(Ios) Then
                WriteTxtMessage("[IO] Start 거부 — 지그 업(IN:14) 미확인, 다운 불가")
                NG()
                Return
            End If
            _peStartWait = PeStartWait.None
            JigClampSequence.BeginJigDown()
            wStep = 3.2
            WriteTxtMessage("[IO] Start → 지그 다운 OUT:10 (wStep 3.2)")
            Return
        End If

        ' 지그 업 (에어툴 체결 후)
        If wStep = 3.4 AndAlso _peStartWait = PeStartWait.JigUp Then
            If srclbDecTool.Text <> "OK" Then
                WriteTxtMessage("[IO] Start 무시 — 에어툴 체결 미완료")
                Return
            End If
            If Not JigClampSequence.IsJigAtDown(Ios) Then
                WriteTxtMessage("[IO] Start 거부 — 지그 다운(IN:13) 미확인, 업 불가")
                NG()
                Return
            End If
            _peStartWait = PeStartWait.None
            JigClampSequence.BeginJigUp()
            wStep = 3.6
            WriteTxtMessage("[IO] Start → 지그 업 OUT:11 (wStep 3.6)")
            Return
        End If

        ' 언클램프 (T/Q만 또는 클램프만)
        If (wStep = 3 OrElse wStep = 3.7) AndAlso _peStartWait = PeStartWait.Unclamp Then
            If wStep = 3 AndAlso Not AllMonitorbracketTqDone() Then
                WriteTxtMessage("[IO] Start 무시 — 모니터브라켓 T/Q 미완료")
                Return
            End If
            BeginPeUnclamp()
            Return
        End If

        If wStep <> 0 Then
            WriteTxtMessage("[IO] Start 무시 — wStep " & wStep & " 대기 조건 미충족")
            Return
        End If

        If Not _partScannedReady Then
            WriteTxtMessage("[IO] Start 거부 — 품번 스캔·확인 필요")
            Return
        End If

        Dim homeFault As String = JigClampSequence.GetHomePositionFault(Ios)
        If homeFault <> "" Then
            WriteTxtMessage("[IO] Start 거부 — " & homeFault)
            NG()
            Return
        End If

        InitJudgmentOnly()
        HideEStopAlarm()
        StartTime = Format(Now, "HH:mm:ss")
        WriteTxtMessage("[IO] Start → 제품 고정 OUT:00,02,06,08 (1·2번 핀+클램프 동시, wStep 2.3) — " & srcLbPartNo.Text)
        wStep = 2.3
    End Sub

    ''' <summary>Reset — 시퀀스 초기화 + 원위치 복귀</summary>
    Private Sub HandleResetPress()
        _eStopLatched = False
        _peStartWait = PeStartWait.None
        JigClampSequence.Abort()
        InitControl()

        If Ios Is Nothing OrElse Not IoConnected Then
            wStep = 0
            HideEStopAlarm()
            WriteTxtMessage("[IO] Reset → wStep 0 (IO 미연결)")
            Return
        End If

        JigClampSequence.AllMotionOutputsOff(Ios)

        If JigClampSequence.IsHomePosition(Ios) Then
            wStep = 0
            HideEStopAlarm()
            WriteTxtMessage("[IO] Reset → wStep 0 (이미 원위치)")
            Return
        End If

        JigClampSequence.BeginHoming()
        wStep = 0.1
        WriteTxtMessage("[IO] Reset → 원위치 복귀 시작 (wStep 0.1)")
    End Sub

    ''' <summary>비상정지 — 공정 정지·알람 (IN:02 NO, 누름 시)</summary>
    Private Sub HandleEmergencyStop()
        _eStopLatched = True
        _peStartWait = PeStartWait.None
        JigClampSequence.Abort()
        If Ios IsNot Nothing Then JigClampSequence.AllMotionOutputsOff(Ios)
        ShowEStopAlarm()
        WriteTxtMessage("[IO] 비상정지")
    End Sub

    Private Sub OnJigClampLog(message As String)
        WriteTxtMessage(message)
    End Sub

    Private Sub HandleJigIoResult(result As String, okStep As Double, faultMessage As String)
        If result = "COMPLETE" Then
            If okStep = 3.4 AndAlso Not JigClampSequence.IsJigAtDown(Ios) Then
                WriteTxtMessage("[IO] 지그 다운 미확인 — IN:13 대기 (wStep 유지)")
                Return
            End If
            If okStep = 3.8 AndAlso Not JigClampSequence.IsJigAtUp(Ios) Then
                WriteTxtMessage("[IO] 지그 업 미확인 — IN:14 대기 (wStep 유지)")
                Return
            End If
            If okStep = 3 Then
                RouteAfterClampComplete()
                Return
            End If
            wStep = okStep
            If okStep = 3.8 Then
                BeginPeUnclamp()
            End If
        ElseIf result = "FAULT" Then
            Dim faultText As String = If(faultMessage <> "", faultMessage, "센서 및 지그 이상")
            WriteTxtMessage("[IO] " & faultText)
            NG()
        End If
    End Sub

    Private Sub HandleHomingTick()
        Dim result As String = JigClampSequence.Tick(Ios)
        If result = "COMPLETE" Then
            wStep = 0
            HideEStopAlarm()
            WriteTxtMessage("[HOME] 원위치 복귀 완료 → wStep 0")
        End If
    End Sub

    Private Function IsAtMonitorbracketTqWorkStep() As Boolean
        Return wStep >= 2.99 AndAlso wStep <= 3.01
    End Function

    Private Function IsAtAirToolWorkStep() As Boolean
        Return wStep >= 3.39 AndAlso wStep <= 3.41
    End Function

    Private Function TryApplyMonitorbracketTq(ByVal torqueNm As Double, ByVal controllerOk As Boolean, ByVal source As String) As Boolean
        If Not IsAtMonitorbracketTqWorkStep() Then
            WriteTxtMessage("[" & source & "] T/Q 무시 — wStep " & wStep & " (모니터브라켓 T/Q는 wStep 3)")
            Return False
        End If
        If IsPeMonitorbracketTqNa() Then
            WriteTxtMessage("[" & source & "] T/Q 무시 — Use_PE_MonitorbracketTq N/A 품번")
            Return False
        End If
        Dim slot As Integer = GetNextMonitorbracketTqSlot()
        If slot < 0 Then
            WriteTxtMessage("[" & source & "] T/Q 무시 — 4회 체결 완료")
            Return False
        End If
        ApplyMonitorbracketTqResult(slot, torqueNm, controllerOk)
        Return True
    End Function

    Private Sub TryApplyAirTool(ByVal toolNo As Integer, ByVal source As String)
        If Not IsAtAirToolWorkStep() Then
            WriteTxtMessage("[" & source & "] 에어툴 무시 — wStep " & wStep & " (에어툴은 wStep 3.4)")
            Return
        End If
        If Not PeNeedsAirTool() Then
            WriteTxtMessage("[" & source & "] 에어툴 무시 — Target_PE_ToolNum N/A")
            Return
        End If
        If Not IsAirToolTargetMatch(toolNo) Then
            WriteTxtMessage("[" & source & "] 에어툴 툴번 불일치 — 수신:" & toolNo & " 목표:" & TargetToolNum)
            Return
        End If
        ApplyAirToolOk(CStr(toolNo))
    End Sub

    Private Sub ProcessSerialTool0061(ByVal toolString As String)
        Dim toolData As Double = CDbl(Format(Val(Mid(toolString, 143, 3) & "." & Mid(toolString, 146, 2))))
        WriteTxtMessage("ToolData : " & toolData)

        If IsAtAirToolWorkStep() Then
            WriteTxtMessage("[SERIAL] wStep 3.4 — 에어툴은 IN:31 펄스 사용 (토크 0061 무시)")
            Return
        End If

        If IsAtMonitorbracketTqWorkStep() Then
            Dim controllerOk As Boolean = (Mid(toolString, 109, 1) = "1")
            TryApplyMonitorbracketTq(toolData, controllerOk, "SERIAL")
        Else
            WriteTxtMessage("[SERIAL] 0061 무시 — wStep " & wStep)
        End If
    End Sub

    ''' <summary>에어툴 체결 OK — 1회만 인정 (wStep 3.4)</summary>
    Private Sub ApplyAirToolOk(Optional ByVal toolDisplay As String = "")
        If srclbDecTool.Text = "OK" Then Exit Sub

        Dim display As String = Trim(If(toolDisplay, ""))
        If display = "" Then
            display = If(TargetToolNum > 0, CStr(TargetToolNum), "1")
        End If

        srclbDataTool.Text = display
        srclbDecTool.Text = "OK"
        srclbDecTool.BackColor = Color.Blue
        PlayOkSound()
        WriteTxtMessage("[IO] 에어툴 체결 OK — " & display)
    End Sub

    Private Function IsAirToolTargetMatch(ByVal toolNo As Integer) As Boolean
        If TargetToolNum <= 0 Then Return True
        Return toolNo = TargetToolNum
    End Function

    ''' <summary>에어 툴 입력 펄스 (Atlas 미사용 시 공구 OK 보조)</summary>
    Private Sub HandleAirToolPulse()
        ApplyAirToolOk()
    End Sub

    Private Sub Ios_PowerError(moduleName As String, hasError As Boolean) Handles Ios.PowerError
        If hasError Then WriteTxtMessage($"[FBEI-{moduleName}] 전원 에러", "FBEI_POWER_ERR")
    End Sub

    Private Function IsAnyAtlasConnected() As Boolean
        Return _atlasConnected(0) OrElse _atlasConnected(1)
    End Function

    Private Sub SyncAtlasToolMode()
        AtlasToolEnabled = IsAnyAtlasConnected()
    End Sub

    Private Sub EnsureSerialToolThread()
        If Not Serial_Tool.IsOpen Then Return
        If Trd1 IsNot Nothing AndAlso Trd1.IsAlive Then Return
        Trd1 = New Thread(AddressOf ThreadTask1)
        Trd1.IsBackground = True
        Trd1.Start()
    End Sub

    Private Sub EnsureSerialToolOpen()
        Try
            If Serial_Tool.IsOpen() Then
                EnsureSerialToolThread()
                Return
            End If
            Serial_Tool.PortName = PortNumber_Tool
            Serial_Tool.BaudRate = 9600
            Serial_Tool.DataBits = 8
            Serial_Tool.Open()
            WriteTxtMessage("Serial Tool Open Success " & PortNumber_Tool)
            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3"))
            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
            tmr_Tool.Interval = 5000
            If Not tmr_Tool.Enabled Then tmr_Tool.Start()
            EnsureSerialToolThread()
        Catch ex As Exception
            WriteTxtMessage("Serial Tool Open Fail — " & ex.Message)
        End Try
    End Sub

    Private Sub StopSerialToolIo()
        tmr_Tool.Stop()
        Try
            If Serial_Tool.IsOpen Then Serial_Tool.Close()
        Catch
        End Try
    End Sub

    Private Sub InitializeAtlasTools()
        StopAtlasTools()

        AtlasToolEnabled = False
        _atlasConnected(0) = False
        _atlasConnected(1) = False
        Dim ips() As String = {AtlasTool1Ip, AtlasTool2Ip}

        For i As Integer = 0 To ips.Length - 1
            Dim ip As String = If(ips(i), "").Trim()
            If ip = "" Then Continue For

            Try
                Dim client As New AtlasEthernetToolClient(i, ip)
                AddHandler client.LogMessage, AddressOf Atlas_LogMessage
                AddHandler client.ResultReceived, AddressOf Atlas_ResultReceived
                AddHandler client.ConnectionChanged, AddressOf Atlas_ConnectionChanged
                AtlasTools(i) = client
                client.Start()
                WriteTxtMessage($"[ATLAS T{i + 1}] 시작 IP={ip} (TCP 4545 대기)")
            Catch ex As Exception
                WriteTxtMessage($"[ATLAS T{i + 1}] 시작 실패: {ex.Message}")
            End Try
        Next
    End Sub

    Public Sub ReinitializeAtlasTools()
        InitializeAtlasTools()
        EnsureSerialToolOpen()
    End Sub

    Private Sub StopAtlasTools()
        For i As Integer = 0 To AtlasTools.Length - 1
            Try
                If AtlasTools(i) IsNot Nothing Then
                    RemoveHandler AtlasTools(i).LogMessage, AddressOf Atlas_LogMessage
                    RemoveHandler AtlasTools(i).ResultReceived, AddressOf Atlas_ResultReceived
                    RemoveHandler AtlasTools(i).ConnectionChanged, AddressOf Atlas_ConnectionChanged
                    AtlasTools(i).Dispose()
                End If
            Catch ex As Exception
                WriteTxtMessage($"[ATLAS T{i + 1}] 종료 예외: {ex.Message}")
            Finally
                AtlasTools(i) = Nothing
            End Try
        Next
        AtlasToolEnabled = False
        _atlasConnected(0) = False
        _atlasConnected(1) = False
    End Sub

    Private Sub Atlas_LogMessage(message As String)
        ' 토크 수신(0061)은 매 체결마다 기록, 통신 예외는 툴별 1회(재연결 시 해제)
        Dim dedupKey As String = Nothing
        If message.Contains("통신 예외") Then dedupKey = $"ATLAS_T{ExtractAtlasToolNum(message)}_ERR"
        WriteTxtMessage(message, dedupKey)
    End Sub

    Private Shared Function ExtractAtlasToolNum(message As String) As Integer
        Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(message, "T(\d+)")
        Return If(m.Success, CInt(m.Groups(1).Value), 0)
    End Function

    Private Sub Atlas_ConnectionChanged(toolIndex As Integer, connected As Boolean)
        If InvokeRequired Then
            BeginInvoke(New Action(Of Integer, Boolean)(AddressOf Atlas_ConnectionChanged), toolIndex, connected)
            Return
        End If
        If toolIndex < 0 OrElse toolIndex > 1 Then Return
        _atlasConnected(toolIndex) = connected
        SyncAtlasToolMode()

        Dim stateKey As String = $"ATLAS_T{toolIndex + 1}_STATE"
        If connected Then
            ClearLogDedup($"ATLAS_T{toolIndex + 1}_ERR")
            WriteTxtMessage($"[ATLAS T{toolIndex + 1}] 연결됨 — {If(toolIndex = 0, AtlasTool1Ip, AtlasTool2Ip)}:4545", stateKey)
        Else
            WriteTxtMessage($"[ATLAS T{toolIndex + 1}] 연결 끊김", stateKey)
        End If
        EnsureSerialToolOpen()
    End Sub

    Private Sub Atlas_ResultReceived(result As AtlasToolResult)
        If InvokeRequired Then
            BeginInvoke(New Action(Of AtlasToolResult)(AddressOf Atlas_ResultReceived), result)
            Return
        End If

        Dim toolNo As Integer = result.ToolIndex + 1
        Dim source As String = "ATLAS T" & CStr(toolNo)

        If IsAtAirToolWorkStep() AndAlso PeNeedsAirTool() Then
            TryApplyAirTool(toolNo, source)
            Return
        End If

        If Not TryApplyMonitorbracketTq(result.TorqueNm, result.ControllerOk, source) Then
            WriteTxtMessage("[" & source & "] 수신 TQ=" & result.TorqueNm.ToString("0.00") &
                " OK=" & result.ControllerOk.ToString() & " — 화면 미반영")
        End If
    End Sub

    ''' <summary>옛 PLC D레지스터 패널 숨김 — Op01_PE는 FBEI I/O만 사용</summary>
    Private Sub HideDeadPlcDisplay()
        Try
            For Each c As Control In Panel11.Controls
                If c.Name.StartsWith("lbD4") OrElse c.Name.StartsWith("lbTitleD4") Then c.Visible = False
            Next
        Catch
        End Try
    End Sub

    ''' <summary>메뉴 'IO 제어' → IO 모니터/제어 창 열기 (단일 인스턴스)</summary>
    Private _frmIo As FrmIo
    Private Sub OpenIoForm(sender As Object, e As EventArgs)
        If _frmIo Is Nothing OrElse _frmIo.IsDisposed Then _frmIo = New FrmIo(Ios)
        _frmIo.Show()
        _frmIo.BringToFront()
    End Sub

    ''' <summary>상단 메뉴에 'IO 제어' 항목 추가</summary>
    Private Sub AddIoMenu()
        Try
            Dim mi As New ToolStripMenuItem("IO 제어") With {.Font = New Font("맑은 고딕", 11.0!, FontStyle.Bold)}
            AddHandler mi.Click, AddressOf OpenIoForm
            MenuStrip1.Items.Add(mi)
        Catch
        End Try
    End Sub

    Private Function ReturnPrintString(strData As String) As String

        Dim RS As String = "_1e"
        Dim GS As String = "_1d"
        Dim EOT As String = "_04"

        Dim tmp As String = ""
        If strData.Length > 10 Then
            tmp = "#" & "[)>" & RS & "06" & GS & strData & RS & EOT
        End If
        Return tmp

    End Function

    Private Function CreateEndBArcode(strLineSerial As String) As String

        Dim RS As String = "_1e"
        Dim GS As String = "_1d"
        Dim EOT As String = "_04"
        Dim TMP As String = ""
        Dim _4M_1 As String
        Dim _4M_2 As String = ""
        Dim _4M_3 As String
        Dim _4M_4 As String
        Dim _4M_CODE As String
        Dim EndData As String = ""

        Dim i As Integer

        Dim BUCKLE1_TMP As String = ""
        Dim BUCKLE2_TMP As String = ""
        Dim BUCKLE3_TMP As String = ""
        Dim SplitTmp1() As String
        Dim SplitTmp2() As String
        Dim SplitTmp3() As String

        Dim PrintDataTmp1 As String = ""
        Dim PrintDataTmp2 As String = ""
        Dim PrintDataTmp3 As String = ""

        ConnectionOpenSQL()

        Dim RRs As New ADODB.Recordset

        RRs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        RRs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        RRs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        RRs.Open("SELECT * FROM TABLE_MAIN WHERE LINE_SERIAL_NO = '" & strLineSerial & "'", SqlConnect)

        If RRs.RecordCount = 1 Then

            'PART_NO nchar(14)	Checked
            'LINE_SERIAL_NO  nchar(24)	Checked
            'INR_BUCKLE_SN   nchar(200)	Checked
            'CTR_BUCKLE_SN nchar(150)	Checked
            'CTR2_BUCKLE_SN  nchar(200)	Checked
            'END_SERIAL  nchar(200)	Checked

            Try
                BUCKLE1_TMP = Trim(RRs.Fields("INR_BUCKLE_SN").Value)
            Catch ex As Exception
                BUCKLE1_TMP = ""
            End Try
            Try
                BUCKLE2_TMP = Trim(RRs.Fields("CTR_BUCKLE_SN").Value)
            Catch ex As Exception
                BUCKLE2_TMP = ""
            End Try
            Try
                BUCKLE3_TMP = Trim(RRs.Fields("CTR2_BUCKLE_SN").Value)
            Catch ex As Exception
                BUCKLE3_TMP = ""
            End Try

        End If

        RRs.ActiveConnection = Nothing
        RRs.Close()

        ConnectionCloseSQL()

        _4M_1 = "1"
        'InStr(1, ScanData, "893") <> 0 Then
        If InStr(1, strLineSerial, "893") <> 0 Then
            _4M_2 = "L"
        Else
            _4M_2 = "R"
        End If

        If CInt(Format(Now, "HHmm")) >= 800 And CInt(Format(Now, "HHmm")) <= 1530 Then
            _4M_3 = "A"
        Else
            _4M_3 = "B"
        End If
        _4M_4 = "1"
        _4M_CODE = _4M_1 & _4M_2 & _4M_3 & _4M_4

        If BUCKLE1_TMP <> "" Then
            SplitTmp1 = Split(BUCKLE1_TMP, Chr(29))
            For i = 1 To UBound(SplitTmp1) - 1
                If i < UBound(SplitTmp1) - 1 Then
                    PrintDataTmp1 = PrintDataTmp1 & SplitTmp1(i) & GS
                Else
                    PrintDataTmp1 = PrintDataTmp1 & SplitTmp1(i) & GS
                End If
            Next
        End If
        If BUCKLE2_TMP <> "" Then
            SplitTmp2 = Split(BUCKLE2_TMP, Chr(29))
            For i = 1 To UBound(SplitTmp2) - 1
                If i < UBound(SplitTmp2) - 1 Then
                    PrintDataTmp2 = PrintDataTmp2 & SplitTmp2(i) & GS
                Else
                    PrintDataTmp2 = PrintDataTmp2 & SplitTmp2(i) & GS
                End If
            Next
        End If
        If BUCKLE3_TMP <> "" Then
            SplitTmp3 = Split(BUCKLE3_TMP, Chr(29))
            For i = 1 To UBound(SplitTmp3) - 1
                If i < UBound(SplitTmp3) - 1 Then
                    PrintDataTmp3 = PrintDataTmp3 & SplitTmp3(i) & GS
                Else
                    PrintDataTmp3 = PrintDataTmp3 & SplitTmp3(i) & GS
                End If
            Next
        End If

        '200713 0001 88888 00000 AAA
        EndData =
            "[)>" & RS & "06" & GS &
            "V" & "AKZX" & GS &
            "P" & Mid(strLineSerial, 11, 5) & Mid(strLineSerial, 17, 8) & GS &
            "S" & "" & GS &
            "E" & "" & GS &
            "T" & Mid(strLineSerial, 1, 6) & _4M_CODE & "A" & "000" & Mid(strLineSerial, 7, 4) & GS &
            "M" & "" & GS &
            "C" & "" & GS &
            RS & EOT &
            ReturnPrintString(PrintDataTmp1) &
            ReturnPrintString(PrintDataTmp2) &
            ReturnPrintString(PrintDataTmp3)

        Return EndData

    End Function

    Private Sub ThreadTask3()

        'Dim incoming2 As String
        'Dim RecvString2 As New System.Text.StringBuilder()

        'Do While 1


        '    Try

        '        incoming2 = Serial_Laser2.ReadLine()

        '        If incoming2 Is Nothing Then
        '            'Exit Do
        '        Else

        '            RecvString2.Append(incoming2)

        '            If RecvString2.Length = 25 Then

        '                LAser3 = 100 - CDbl(Mid(RecvString2.ToString, 7, 6))
        '                LAser4 = 100 - CDbl(Mid(RecvString2.ToString, 18, 6))

        '                LaserFRONT_L.Text = LAser3
        '                LaserREAR_L.Text = LAser4

        '            End If

        '            RecvString2.Clear()
        '            Serial_Laser2.DiscardInBuffer()

        '        End If

        '    Catch ex As Exception

        '    End Try

        '    Application.DoEvents()
        'Loop

    End Sub

    Public Function Hex2Dec(str As String) As String

        Dim tmp As String = ""

        Try
            tmp = CDbl("&H" & str)
        Catch ex As Exception

        End Try

        Return tmp

    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start(osk)
        End If
    End Sub

    Private Sub SerialPortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SerialPortToolStripMenuItem.Click
        FrmPort.Show()
    End Sub

    Private Sub BasicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BasicToolStripMenuItem.Click
        FrmBasic.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub BarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarcodeToolStripMenuItem.Click
        FrmBarcode.Show()
    End Sub

    Private Sub VitualKeyboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VitualKeyboardToolStripMenuItem.Click

        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start(osk)
        End If

    End Sub

    Private Sub Tmr_Connect_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Connect.Tick
        UpdateIoConnectionDisplay()
    End Sub

    Private Sub Tmr_Work_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Work.Tick

        srclbStep.Text = wStep

        ' Reset 원위치 복귀 (비상정지 중에도 Reset 가능)
        If wStep = 0.1 Then
            HandleHomingTick()
            Return
        End If

        If _eStopLatched OrElse IoInEStop Then Exit Sub

        If wStep = 0 Then
            ' 품번 스캔 → HandleIdlePartScan / Start → HandleStartPress

        ElseIf wStep = 2.3 Then
            If Ios Is Nothing OrElse Not IoConnected Then
                WriteTxtMessage("[IO] 제품 고정 대기 — FBEI 미연결")
                Exit Sub
            End If
            JigClampSequence.BeginClamp()
            wStep = 2.4

        ElseIf wStep = 2.4 Then
            ' 제품 고정: 1·2번 핀전진+클램프 동시 → IN:03,05,09,11
            HandleJigIoResult(JigClampSequence.Tick(Ios), 3, "제품 고정")

        ElseIf wStep = 3 Then
            ' 모니터브라켓 T/Q 4회 — 완료 후 RouteAfterTqComplete
            If AllMonitorbracketTqDone() AndAlso _peStartWait = PeStartWait.None Then
                RouteAfterTqComplete()
            End If

        ElseIf wStep = 3.1 OrElse wStep = 3.7 Then
            ' Start 대기 (지그 다운 / 언클램프)

        ElseIf wStep = 3.2 Then
            ' 지그 다운: OUT:10 → IN:13
            HandleJigIoResult(JigClampSequence.Tick(Ios), 3.4, "지그 다운")

        ElseIf wStep = 3.4 Then
            ' 지그 다운 유지 + 에어툴 IN:31 / Atlas
            If Not JigClampSequence.IsJigAtDown(Ios) Then
                WriteTxtMessage("[IO] 지그 다운 이탈 — IN:13/14 확인 후 Reset")
                _peStartWait = PeStartWait.None
                Exit Sub
            End If

            If srclbDecTool.Text = "OK" AndAlso _peStartWait = PeStartWait.None Then
                _peStartWait = PeStartWait.JigUp
                WriteTxtMessage("[IO] 에어툴 OK — Start 대기 (지그 업)")
            End If

        ElseIf wStep = 3.6 Then
            ' 지그 업: OUT:11 → IN:14
            HandleJigIoResult(JigClampSequence.Tick(Ios), 3.8, "지그 업")

        ElseIf wStep = 3.8 Then
            ' 지그 업 확인 후 해제 (HandleJigIoResult에서 BeginPeUnclamp)

        ElseIf wStep = 3.9 Then
            ' 제품 해제: 1·2번 언클램프→핀후진
            HandleJigIoResult(JigClampSequence.Tick(Ios), 4, "제품 해제")

        ElseIf wStep = 4 Then
            SaveDB()
            AddGrid(srcLbPartNo.Text)
            InitGrid()
            LoadGrid()
            InitControl()
            wStep = 0
            HideEStopAlarm()
            WriteTxtMessage("[IO] PE 작업 완료 — wStep 0")

        End If

    End Sub

    Private Sub Serial_Scanner_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Serial_Scanner.DataReceived

        Dim Incoming As String
        Dim ScanData As String

        Incoming = Serial_Scanner.ReadLine()
        ScanData = Trim(Mid$(Incoming, 1, Len(Incoming) - 1))
        Serial_Scanner.DiscardInBuffer()

        WriteTxtMessage("ScanData : " & ScanData)

        If wStep = 0 Then
            HandleIdlePartScan(ScanData)
        ElseIf Trim(ScanData) <> "" Then
            WriteTxtMessage("[SCAN] 무시 — wStep " & wStep)
        End If

    End Sub

    Private Sub InitGrid()

        With GridCount
            ' 기존 데이터 초기화
            .Rows.Clear()
            .Columns.Clear()

            ' 컬럼 추가 (FlexCell col1=품번, col2=생산수량 → DGV col0,1)
            .Columns.Add("colPartNo", "품번")
            .Columns.Add("colCount", "생산수량")

            ' 컬럼 너비
            .Columns(0).Width = 230
            .Columns(1).Width = 190

            ' 가운데 정렬
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With

    End Sub


    Private Sub LoadGrid()

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT JObPartNo,JobCount FROM Table_Count ORDER BY LEN(JobPartNo),JobPartNo", MdbConnect)

        If Rs.RecordCount = 0 Then
        ElseIf Rs.RecordCount >= 1 Then

            Rs.MoveFirst()

            If Rs.BOF = True Or Rs.EOF = True Then
            Else
                Do Until Rs.EOF

                    GridCount.Rows.Add(Rs.Fields("JobPartNo").Value, Rs.Fields("JobCount").Value)
                    Rs.MoveNext()
                Loop
            End If

            Rs.ActiveConnection = Nothing
            Rs.Close()

        End If

        ConnectionCloseMDB()

    End Sub

    Private Sub ResetGrid()

        Dim strSQL As String

        ConnectionOpenMDB()

        strSQL = "DELETE * FROM TABLE_COUNT"
        MdbConnect.Execute(strSQL)
        ConnectionCloseMDB()

    End Sub

    Private Sub AddGrid(ByVal strPart As String)

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset
        Dim TmpInt As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Count WHERE JobPartNo = '" & strPart & "'", MdbConnect)

        If Rs.RecordCount = 0 Then

            Rs.AddNew()

            Rs.Fields("JobPartno").Value = strPart
            Rs.Fields("JobCount").Value = "1"
            Rs.Update()

        ElseIf Rs.RecordCount >= 1 Then

            TmpInt = CInt(Rs.Fields("JobCount").Value)
            TmpInt = TmpInt + 1
            Rs.Fields("JobCount").Value = CStr(TmpInt)
            Rs.Update()

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ResetGrid()
        InitGrid()
        LoadGrid()

    End Sub

    Private Sub tmr_Tool_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_Tool.Tick

        If Not Serial_Tool.IsOpen Then Exit Sub

        If Tool_Connection1 = False Then
            Tool_Connection1 = True
            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "002099990010" & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr("0") & Chr("3"))
        ElseIf Tool_Connection1 = True Then
            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3") &
            Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
        End If

    End Sub

    Private Sub ThreadTask1()

        Dim Incoming1 As String

        Do While Serial_Tool.IsOpen = True

            Try

                If Serial_Tool.BytesToRead > 0 Then

                    Incoming1 = Serial_Tool.ReadChar
                    If Incoming1 = 3 Then

                        If Len(Tool_String1) = 59 And Mid(Tool_String1, 6, 4) = "0002" Then
                            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
                        ElseIf Len(Tool_String1) = 26 And Mid(Tool_String1, 6, 4) = "0005" Then
                            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00209999            " & Chr("0") & Chr("3"))
                        ElseIf Len(Tool_String1) = 22 And Mid(Tool_String1, 6, 4) = "9999" Then
                            Tool_Connection1 = True
                        ElseIf Len(Tool_String1) > 200 And Mid(Tool_String1, 6, 4) = "0061" Then
                            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200062            " & Chr("0") & Chr("3"))
                            Dim captured As String = Tool_String1
                            If IsHandleCreated Then
                                BeginInvoke(New Action(Of String)(AddressOf ProcessSerialTool0061), captured)
                            Else
                                ProcessSerialTool0061(captured)
                            End If

                        End If

                        Tool_String1 = ""
                        Serial_Tool.DiscardInBuffer()

                    Else

                        Tool_String1 = Tool_String1 & Chr(Incoming1)

                    End If

                End If

            Catch ex As Exception

                Incoming1 = ""
                Tool_String1 = ""
            End Try

            Application.DoEvents()

        Loop

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        SaveDB()
    End Sub

    Private Sub Label22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label22.Click

        SaveDB()
        BarcodePrint(srcLbSerial.Text, srcLbPartNo.Text)
        AddGrid(srcLbPartNo.Text)
        InitGrid()
        LoadGrid()
        InitControl()
        wStep = 0

    End Sub

    Private Sub LoadALarmMessage()

        Dim Rs As New ADODB.Recordset
        Dim i As Integer

        ConnectionOpenMDB()
        
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_NGInfo", MdbConnect)

        If Rs.RecordCount >= 1 Then

            i = 0
            Rs.MoveFirst()
            Do Until Rs.EOF
                Try
                    AlarmMessage(CInt(Rs.Fields("PLcid").Value)) = Rs.Fields("ErrorInfo").Value
                Catch ex As Exception
                End Try

                Rs.MoveNext()
            Loop

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

End Class
