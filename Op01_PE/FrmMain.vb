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

    Private TmpSeq As String
    Private AlarmMessage(100) As String

    Private TmpToolCount As Integer
    Private StartTIme As String
    Private Tool1_Delay_count As Double
    Private Tool1_Ready As Boolean
    Private Tool_String1 As String
    Private Tool_Connection1 As Boolean
    Private Tool1_Count As Integer
    Private AtlasTools(1) As AtlasEthernetToolClient
    Private AtlasToolEnabled As Boolean

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

    ' FBEI 운전 스위치 상태 (ch1=Start, ch2=Reset, ch3=비상정지)
    Private IoInStart As Boolean
    Private IoInReset As Boolean
    Private IoInEStop As Boolean
    Private IoStartPrev As Boolean
    Private IoResetPrev As Boolean
    Private IoEStopPrev As Boolean
    Private _eStopLatched As Boolean
    Private _readyForDown As Boolean   ' wStep 3 다운前 판정 OK → Start로 지그다운
    Private _readyForUp As Boolean     ' wStep 3.4 다운後 공구 판정 OK → Start로 지그업

    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"

    Private OptionLHRH As String
    Private OptionType As String
    Private OptionBack As String
    Private OptionFootRest As Boolean
    Private OptionMonitor As Boolean

    Private TargetMotorBarcode As String
    Private TargetFrameBarcode As String
    Private TargetToolNum As Integer
    Private TargetMotorTQ As Boolean

    Private D_OutString As String
    Private rStep As Double
    Private rCount As Double
    Private StartTimeL As String
    Private StartTimeR As String
    Private EndTime As String
    Private wStep As Double
    Private wCount As Double
    Private PcAliveCount As Integer

    Public D_Value(0 To 48) As Integer
    ' IO보드 IN/OUT 인디케이터 (CW LED→일반 Label 변경). 와꾸 — 생성/배치는 다음 단계
    Public IN_LABEL(48) As Label
    Public OUT_LABEL(24) As Label

    Private Trd1 As Thread
    Private Trd2 As Thread
    Private Trd3 As Thread
    Private RecvString As New System.Text.StringBuilder()

    Private Player As New SoundPlayer

    Private Sub NG()

        Me.Player.SoundLocation = System.AppDomain.CurrentDomain.BaseDirectory & "\SOUND\NG.wav"
        Me.Player.Play()

    End Sub

    Private Sub DingDOng()

        Me.Player.SoundLocation = System.AppDomain.CurrentDomain.BaseDirectory & "\SOUND\DINGDONG.wav"
        Me.Player.Play()

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

    Private Sub InitControl()

        srclbSpecMotorTq.Text = BasicToolMin & " ~ " & BasicToolMax & " " & BAsicUnit

        LoadPicture(srcPictureBox, "NON")
        srcLbPartNo.Text = ""
        srcLbPartName.Text = ""
        srcLbPartOption.Text = ""
        srcLbSerial.Text = ""

        srclbTargetMotorBarcode.Text = ""
        srclbDataMotorBarcode.Text = ""
        srclbDecMotorBarcode.Text = ""
        srclbDecMotorBarcode.BackColor = Color.Black

        srclbTargetFrameBarcode.Text = ""
        srclbDataFrameBarcode.Text = ""
        srclbDecFrameBarcode.Text = ""
        srclbDecFrameBarcode.BackColor = Color.Black

        srclbDataMotorTq.Text = ""
        srclbDecMotorTq.Text = ""
        srclbDecMotorTq.BackColor = Color.Black

        srclbDataTool.Text = ""
        srclbDecTool.Text = ""
        srclbDecTool.BackColor = Color.Black

        _readyForDown = False
        _readyForUp = False

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

        ' 시리얼 툴(COM3) — 코드 유지, Atlas LAN 사용 시 비활성화만 (포트 미오픈·스레드 미시작)
        If AtlasToolEnabled Then
            WriteTxtMessage("시리얼 툴 비활성 — Atlas LAN 토크툴 사용")
        Else
            Try
                If Serial_Tool.IsOpen() = True Then
                    Serial_Tool.Close()
                End If
                Serial_Tool.PortName = PortNumber_Tool
                Serial_Tool.BaudRate = 9600
                Serial_Tool.DataBits = 8
                Serial_Tool.Open()
                WriteTxtMessage("Serial Tool Open Success " & PortNumber_Tool)
                Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3"))
                Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
                tmr_Tool.Interval = 5000
                tmr_Tool.Start()
            Catch ex As Exception
                WriteTxtMessage("Serial Tool Open Fail")
            End Try
        End If

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

    Private Function LoadWorkPart() As String

        Dim Rs As New ADODB.Recordset
        Dim Tmp As String = ""

        ConnectionOpenSQL()

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Etc", SqlConnect)

        If Rs.RecordCount = 1 Then

            Tmp = Rs.Fields("SELECT_PART").Value
            TmpSeq = ""
            Try
                TmpSeq = Trim(Rs.Fields("PlanSeq").Value)
            Catch ex As Exception
            End Try

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

        Return Tmp

    End Function

    Private Sub LoadPArt(ByVal str As String)

        ConnectionOpenSQL()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part WHERE PartNo = '" & Mid(str, 1, 11) & "'", SqlConnect)

        If Rs.RecordCount = 1 Then

            srcLbPartName.Text = Trim(Rs.Fields("PartName").Value)
            LoadPicture(srcPictureBox, Mid(str, 1, 11))

            OptionLHRH = Trim(Rs.Fields("OptionLHRH").Value)
            OptionType = Trim(Rs.Fields("OptionType").Value)
            OptionBack = Trim(Rs.Fields("OptionBack").Value)
            OptionFootRest = Rs.Fields("OptionFootRest").Value
            OptionMonitor = Rs.Fields("OptionMon").Value

            srcLbPartOption.Text = OptionType & " " & OptionLHRH
            TargetMotorBarcode = Trim(Rs.Fields("Target_Op01_MotorBarcode").Value)
            TargetFrameBarcode = Trim(Rs.Fields("Target_Op01_FrameBarcode").Value)
            TargetToolNum = CInt(Trim(Rs.Fields("Target_Op01_ToolNum").Value))
            TargetMotorTQ = Rs.Fields("Use_Op01_MotorTq").Value

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

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

        Dim strSQL As String = ""

        ConnectionOpenSQL()

        strSQL = "INSERT INTO TABLE_MAIN (Op01_Date,Op01_StartTime,Op01_EndTime,Op01_MotorBarcode,Op01_FrameBarcode,Op01_MotorTq,PartNo,SerialNo,OP01_Decision) VALUES (" &
                       "'" & Format(Now, "yyyy-MM-dd") & "','" &
                               StartTIme & "','" &
                               Format(Now, "HH:mm:ss") & "','" &
                               srclbDataMotorBarcode.Text & "','" &
                               srclbDataFrameBarcode.Text & "','" &
                               srclbDataMotorTq.Text & "','" &
                               srcLbPartNo.Text & "','" &
                               srcLbSerial.Text & "','" &
                               "OK" & "')"

        SqlConnect.Execute(strSQL)
        ConnectionCloseSQL()

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

    Private Function Create_Serial() As String

        Dim Rs As New ADODB.Recordset
        Dim tmp As String = ""

        ConnectionOpenSQL()

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Main WHERE Op01_DATE = '" & Format(Now, "yyyy-MM-dd") & "'", SqlConnect)

        tmp = Format(Now, "yyyyMMdd") & Format(Rs.RecordCount + 1, "0000") & srcLbPartNo.Text

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

        Return tmp

    End Function

    
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        ' DB(SQL/MDB)·시리얼 초기화 — 신규 타겟에 DB/포트 없어도 IO는 떠야 하므로 경계 catch
        Try
            LoadPortData()
            LoadBarcodeData()
            LoadBasicData()
            LoadALarmMessage()
            InitControl()
            WriteTxtMessage("Init Complete")
            InitializeAtlasTools()   ' SerialOpen 전 — Atlas 활성 시 시리얼 툴 비활성 판단
            SerialOpen()
            InitGrid()
            LoadGrid()
        Catch ex As Exception
            WriteTxtMessage("초기화 일부 실패(DB/시리얼 없음?): " & ex.Message)
        End Try

        Timer1.Interval = 100
        Timer1.Start()

        WriteTxtMessage("System Ready..")

        ' 멜섹 PLC 삭제 → IO보드(FBEI EtherNet/IP, 입력1+출력1) 사용.
        HideDeadPlcDisplay()      ' 죽은 D번지 표시 숨김
        InitializeIoDevices()     ' IO보드 연결
        AddHandler JigClampSequence.JigLog, AddressOf OnJigClampLog
        JigClampSequence.EnableAllMotionSensors()   ' IN 센서 필수 — OUT 후 IN 확인까지 다음 단계 진행
        AddIoMenu()               ' 상단 'IO 제어' 메뉴 추가
        AddressOfPLc = IoInputIp
        Label11.Text = AddressOfPLc
        FlagPlcConnection = False

        ' Atlas 활성 시 시리얼 툴 스레드 생략 (이중 토크 경로 방지)
        If Serial_Tool.IsOpen = True AndAlso Not AtlasToolEnabled Then
            Trd1 = New Thread(AddressOf ThreadTask1)
            Trd1.IsBackground = True
            Trd1.Start()
        End If

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

    Private Sub ConnectPLc()
        ' 멜섹 삭제: 연결은 IO보드(Ios)가 담당. 와꾸 — 연결상태만 반영.
        FlagPlcConnection = (Ios IsNot Nothing AndAlso IoConnected)
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
                ' NC 접점: 정상=ON, 누름(회로 단선)=OFF → 비상정지
                IoInEStop = Not value
                If IoInEStop AndAlso Not IoEStopPrev Then HandleEmergencyStop()
                IoEStopPrev = IoInEStop
            Case IoMap.PinAirTool
                If value AndAlso wStep = 3.4 AndAlso Not AtlasToolEnabled Then HandleAirToolPulse()
        End Select
    End Sub

    ''' <summary>Start — wStep 0 공정시작 / wStep 3 지그다운 / wStep 3.4 지그업</summary>
    Private Sub HandleStartPress()
        If _eStopLatched OrElse IoInEStop Then
            WriteTxtMessage("[IO] Start 무시 — 비상정지 상태")
            Return
        End If

        If Ios Is Nothing OrElse Not IoConnected Then
            srclbAlarm.Visible = True
            srclbAlarm.Text = "IO 보드 미연결 — Start 불가"
            WriteTxtMessage("[IO] Start 거부 — IO 미연결")
            Return
        End If

        If wStep = 3 AndAlso _readyForDown Then
            If Not JigClampSequence.IsJigAtUp(Ios) Then
                srclbAlarm.Visible = True
                srclbAlarm.Text = "지그 업 위치(IN:14) 미확인 — 다운 불가"
                WriteTxtMessage("[IO] Start 거부 — 지그 업 센서(IN:14 ON, IN:13 OFF) 필요")
                NG()
                Return
            End If
            _readyForDown = False
            srclbAlarm.Visible = False
            JigClampSequence.BeginJigDown()
            wStep = 3.2
            WriteTxtMessage("[IO] Start(2회) → 지그 다운 (wStep 3.2)")
            Return
        End If

        If wStep = 3.4 AndAlso _readyForUp Then
            If Not JigClampSequence.IsJigAtDown(Ios) Then
                srclbAlarm.Visible = True
                srclbAlarm.Text = "지그 다운 위치(IN:13) 미확인 — 업 불가"
                WriteTxtMessage("[IO] Start 거부 — 지그 다운 센서(IN:13 ON, IN:14 OFF) 필요")
                NG()
                Return
            End If
            _readyForUp = False
            srclbAlarm.Visible = False
            JigClampSequence.BeginJigUp()
            wStep = 3.6
            WriteTxtMessage("[IO] Start(3회) → 지그 업 (wStep 3.6)")
            Return
        End If

        If wStep = 3 AndAlso Not _readyForDown Then
            WriteTxtMessage("[IO] Start 무시 — 다운前 판정(바코드·토크) 미완료")
            Return
        End If

        If wStep = 3.4 AndAlso Not _readyForUp Then
            WriteTxtMessage("[IO] Start 무시 — 다운後 공구 판정 미완료")
            Return
        End If

        If wStep <> 0 Then Return

        Dim homeFault As String = JigClampSequence.GetHomePositionFault(Ios)
        If homeFault <> "" Then
            srclbAlarm.Visible = True
            srclbAlarm.Text = homeFault
            WriteTxtMessage("[IO] Start 거부 — " & homeFault)
            NG()
            Return
        End If

        WritePlc("D", "4051", "0000000")
        InitControl()
        srclbAlarm.Visible = False
        StartTime = Format(Now, "HH:mm:ss")
        WriteTxtMessage("[IO] Start(1회) → wStep 2 (원위치 확인 OK)")
        wStep = 2
    End Sub

    ''' <summary>Reset — 시퀀스 초기화 + 원위치 복귀</summary>
    Private Sub HandleResetPress()
        _eStopLatched = False
        _readyForDown = False
        _readyForUp = False
        JigClampSequence.Abort()
        InitControl()
        WritePlc("D", "4051", "0000000")

        If Ios Is Nothing OrElse Not IoConnected Then
            wStep = 0
            srclbAlarm.Visible = False
            WriteTxtMessage("[IO] Reset → wStep 0 (IO 미연결)")
            Return
        End If

        JigClampSequence.AllMotionOutputsOff(Ios)

        If JigClampSequence.IsHomePosition(Ios) Then
            wStep = 0
            srclbAlarm.Visible = False
            WriteTxtMessage("[IO] Reset → wStep 0 (이미 원위치)")
            Return
        End If

        JigClampSequence.BeginHoming()
        wStep = 0.1
        srclbAlarm.Visible = True
        srclbAlarm.Text = "원위치 복귀 중… (Reset)"
        WriteTxtMessage("[IO] Reset → 원위치 복귀 시작 (wStep 0.1)")
    End Sub

    ''' <summary>비상정지 — 공정 정지·알람</summary>
    Private Sub HandleEmergencyStop()
        _eStopLatched = True
        _readyForDown = False
        _readyForUp = False
        JigClampSequence.Abort()
        If Ios IsNot Nothing Then JigClampSequence.AllMotionOutputsOff(Ios)
        srclbAlarm.Visible = True
        srclbAlarm.Text = "비상정지 — 리셋 후 재시작"
        WriteTxtMessage("[IO] 비상정지")
    End Sub

    Private Sub OnJigClampLog(message As String)
        WriteTxtMessage(message)
    End Sub

    Private Sub HandleJigIoResult(result As String, okStep As Double, faultMessage As String)
        If result = "COMPLETE" Then
            If okStep = 3.4 AndAlso Not JigClampSequence.IsJigAtDown(Ios) Then
                WriteTxtMessage("[IO] 지그 다운 도착 신호 미확인 — IN:13/14 대기 (wStep 유지)")
                Return
            End If
            If okStep = 3.8 AndAlso Not JigClampSequence.IsJigAtUp(Ios) Then
                WriteTxtMessage("[IO] 지그 업 도착 신호 미확인 — IN:13/14 대기 (wStep 유지)")
                Return
            End If
            wStep = okStep
        End If
    End Sub

    Private Sub HandleHomingTick()
        Dim result As String = JigClampSequence.Tick(Ios)
        If result = "COMPLETE" Then
            wStep = 0
            srclbAlarm.Visible = False
            WriteTxtMessage("[HOME] 원위치 복귀 완료 → wStep 0")
        End If
    End Sub

    ''' <summary>에어 툴 입력 펄스 (Atlas 미사용 시 공구 OK 보조)</summary>
    Private Sub HandleAirToolPulse()
        If srclbDecTool.Text = "OK" Then Exit Sub
        srclbDataTool.Text = CStr(TargetToolNum)
        srclbDecTool.Text = "OK"
        srclbDecTool.BackColor = Color.Blue
        DingDOng()
    End Sub

    Private Sub Ios_PowerError(moduleName As String, hasError As Boolean) Handles Ios.PowerError
        If hasError Then WriteTxtMessage($"[FBEI-{moduleName}] 전원 에러", "FBEI_POWER_ERR")
    End Sub

    Private Sub InitializeAtlasTools()
        StopAtlasTools()

        AtlasToolEnabled = False
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
                AtlasToolEnabled = True
                WriteTxtMessage($"[ATLAS T{i + 1}] 시작 IP={ip}")
            Catch ex As Exception
                WriteTxtMessage($"[ATLAS T{i + 1}] 시작 실패: {ex.Message}")
            End Try
        Next
    End Sub

    Public Sub ReinitializeAtlasTools()
        InitializeAtlasTools()
        If AtlasToolEnabled Then
            tmr_Tool.Stop()
            Try
                If Serial_Tool.IsOpen Then Serial_Tool.Close()
            Catch
            End Try
            WriteTxtMessage("시리얼 툴 비활성 — Atlas LAN 전환")
        End If
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
        Dim stateKey As String = $"ATLAS_T{toolIndex + 1}_STATE"
        If connected Then
            ClearLogDedup($"ATLAS_T{toolIndex + 1}_ERR")
            WriteTxtMessage($"[ATLAS T{toolIndex + 1}] 연결됨", stateKey)
        Else
            WriteTxtMessage($"[ATLAS T{toolIndex + 1}] 연결 끊김", stateKey)
        End If
    End Sub

    Private Sub Atlas_ResultReceived(result As AtlasToolResult)
        If InvokeRequired Then
            BeginInvoke(New Action(Of AtlasToolResult)(AddressOf Atlas_ResultReceived), result)
            Return
        End If

        Dim toolNo As Integer = result.ToolIndex + 1

        If wStep = 3.4 Then
            srclbDataTool.Text = CStr(toolNo)
            If TargetToolNum = toolNo AndAlso srclbDecTool.Text <> "OK" Then
                srclbDecTool.Text = "OK"
                srclbDecTool.BackColor = Color.Blue
                DingDOng()
            End If
            Exit Sub
        End If

        If wStep <> 3 Then Exit Sub

        srclbDataMotorTq.Text = result.TorqueNm.ToString("0.00")

        If result.ControllerOk AndAlso result.TorqueNm >= BasicToolMin AndAlso result.TorqueNm <= BasicToolMax Then
            srclbDecMotorTq.Text = "OK"
            srclbDecMotorTq.BackColor = Color.Blue
            DingDOng()
        Else
            srclbDecMotorTq.Text = "NG"
            srclbDecMotorTq.BackColor = Color.Red
            NG()
        End If
    End Sub

    ''' <summary>옛 PLC D레지스터 표시 숨김 (멜섹 제거). IO 표시는 메뉴의 FrmIo로 분리.</summary>
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

    Private Sub WritePlc(ByVal strChr As String, ByVal StartArry As String, ByVal ArryMessage As String)
        If Ios Is Nothing OrElse Not IoConnected Then Exit Sub
        If srcLbPlcConnectionState.Text <> "OK" Then Exit Sub
        Try
            IoSignalMap.ApplyPlcWrite(Ios, CInt(StartArry), ArryMessage)
        Catch ex As Exception
            WriteTxtMessage("[FBEI-OUT] WritePlc 예외: " & ex.Message)
        End Try
    End Sub

    Private Sub ReadPLc()
        If Ios Is Nothing OrElse Not IoConnected Then
            PlcConnectionError = "DISCONNECTED"
            Exit Sub
        End If
        Try
            IoSignalMap.SyncInputsToPlc(Ios)
            IoInStart = IoMap.GetIn(Ios, IoMap.PinStart)
            IoInReset = IoMap.GetIn(Ios, IoMap.PinReset)
            IoInEStop = Not IoMap.GetIn(Ios, IoMap.PinEStop)
            UpdatePlcDisplayLabels()
            PlcConnectionError = "OK"
        Catch ex As Exception
            PlcConnectionError = ex.Message
        End Try
    End Sub

    Private Sub UpdatePlcDisplayLabels()
        lbD4000.Text = CStr(PlcValue(4000))
        lbD4001.Text = CStr(PlcValue(4001))
        lbD4002.Text = CStr(PlcValue(4002))
        lbD4003.Text = CStr(PlcValue(4003))
        lbD4004.Text = CStr(PlcValue(4004))
        lbD4005.Text = CStr(PlcValue(4005))
        lbD4006.Text = CStr(PlcValue(4006))
        lbD4007.Text = CStr(PlcValue(4007))
        lbD4008.Text = CStr(PlcValue(4008))
        lbD4009.Text = CStr(PlcValue(4009))
        lbD4050.Text = CStr(PlcValue(4050))
        lbD4051.Text = CStr(PlcValue(4051))
        lbD4052.Text = CStr(PlcValue(4052))
        lbD4053.Text = CStr(PlcValue(4053))
        lbD4054.Text = CStr(PlcValue(4054))
        lbD4055.Text = CStr(PlcValue(4055))
        lbD4056.Text = CStr(PlcValue(4056))
        lbD4057.Text = CStr(PlcValue(4057))
        lbD4058.Text = CStr(PlcValue(4058))
        lbD4059.Text = CStr(PlcValue(4059))
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

        If PlcConnectionError = "OK" Then
            srcLbPlcConnectionState.Text = PlcConnectionError
            srcLbPlcConnectionState.BackColor = Color.Blue
            srcLbPlcConnectionState.ForeColor = Color.White
        Else
            srcLbPlcConnectionState.Text = PlcConnectionError
            srcLbPlcConnectionState.BackColor = Color.Red
            srcLbPlcConnectionState.ForeColor = Color.White
        End If

        If PlcConnectionStep = 0 Then
            ConnectPLc()
            PlcConnectionStep = 2
        ElseIf PlcConnectionStep = 2 Then
            If FlagPlcConnection = True Then
                PlcConnectionStep = 3
            Else
                PlcConnectionStep = 0
            End If
        ElseIf PlcConnectionStep = 3 Then
            PlcConnectionError = ""
            ReadPLc()
            PlcConnectionStep = 4
        ElseIf PlcConnectionStep = 4 Then
            If PlcConnectionError <> "" Then
                If PlcConnectionError = "OK" Then
                    PlcConnectionStep = 2
                Else
                    ' 멜섹 삭제: ActPlc.Close() 제거 (IO보드는 Ios.Disconnect로 별도 관리)
                    PlcConnectionStep = 0
                End If
            End If
        End If
    End Sub

    Private Sub Tmr_Work_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Work.Tick

        srclbStep.Text = wStep

        If PlcValue(4009) <> 0 And srclbAlarm.Visible = False Then
            srclbAlarm.Visible = True
            srclbAlarm.Text = AlarmMessage(CInt(PlcValue(4009)))
        ElseIf PlcValue(4009) = 0 And srclbAlarm.Visible = True AndAlso Not _eStopLatched Then
            srclbAlarm.Visible = False
        End If

        PCAliveCount = PCAliveCount + 1
        If PcAliveCount = 10 Then
            WritePlc("D", "4050", "1")
        ElseIf PcAliveCount = 20 Then
            WritePlc("D", "4050", "0")
            PcAliveCount = 0
        End If

        ' Reset 원위치 복귀 (비상정지 중에도 Reset으로 복귀 가능)
        If wStep = 0.1 Then
            HandleHomingTick()
            Return
        End If

        ' 비상정지 래치 시 공정 진행 차단
        If _eStopLatched OrElse IoInEStop Then Exit Sub

        If wStep = 0 Then
            ' Start는 Ios_InputChanged 엣지에서 처리

        ElseIf wStep = 2 Then

            srcLbPartNo.Text = LoadWorkPart()
            If TmpSeq <> "" Then
                wStep = 2.1
            Else
                srclbAlarm.Visible = True
                srclbAlarm.Text = "계획을 입력해주세요"
            End If
            
        ElseIf wStep = 2.1 Then

            LoadPArt(srcLbPartNo.Text)
            FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, Mid(srcLbPartNo.Text, 1, 11))
            wStep = 2.2

        ElseIf wStep = 2.2 Then

            srclbTargetMotorBarcode.Text = TargetMotorBarcode
            srclbTargetFrameBarcode.Text = TargetFrameBarcode
            srclbTargetTool.Text = CStr(TargetToolNum)

            If TargetMotorTQ = False Then
                srclbDataMotorTq.Text = "NA"
                srclbDecMotorTq.Text = "NA"
                srclbDecMotorTq.BackColor = Color.Green
            End If
            If TargetMotorBarcode = "0" Then
                srclbDataMotorBarcode.Text = "NA"
                srclbDecMotorBarcode.Text = "NA"
                srclbDecMotorBarcode.BackColor = Color.Green
            End If
            If TargetFrameBarcode = "0" Then
                srclbDataFrameBarcode.Text = "NA"
                srclbDecFrameBarcode.Text = "NA"
                srclbDecFrameBarcode.BackColor = Color.Green
            End If
            srcLbSerial.Text = Create_Serial()
            wStep = 2.3

        ElseIf wStep = 2.3 Then 'Send PLC Option

            If OptionLHRH = "LH" Then
                WritePlc("D", "4051", "1")
            ElseIf OptionLHRH = "RH" Then
                WritePlc("D", "4051", "2")
            End If

            If OptionType = "STD" Then
                WritePlc("D", "4052", "1")
            ElseIf OptionType = "FOLD" Then
                WritePlc("D", "4052", "2")
            ElseIf OptionType = "VIP" Then
                WritePlc("D", "4052", "3")
            End If

            If OptionBack = "PULLMA" Then
                WritePlc("D", "4053", "1")
            Else
                WritePlc("D", "4053", "2")
            End If

            If OptionFootRest = True Then
                WritePlc("D", "4054", "1")
            Else
                WritePlc("D", "4054", "0")
            End If

            If OptionMonitor = True Then
                WritePlc("D", "4055", "1")
            Else
                WritePlc("D", "4055", "0")
            End If
            WritePlc("D", "4056", "1")
            JigClampSequence.BeginClamp()
            wStep = 2.4

        ElseIf wStep = 2.4 Then
            ' 제품 고정: 핀전진 → 클램프 (1번 지그)
            HandleJigIoResult(JigClampSequence.Tick(Ios), 3, "제품 고정")

        ElseIf wStep = 3 Then
            ' 다운前 판정: 모터바코드 + 프레임바코드 + 토크
            If (srclbDecMotorBarcode.Text = "OK" Or srclbDecMotorBarcode.Text = "PASS" Or srclbDecMotorBarcode.Text = "NA") And _
                (srclbDecFrameBarcode.Text = "OK" Or srclbDecFrameBarcode.Text = "PASS" Or srclbDecFrameBarcode.Text = "NA") And _
                (srclbDecMotorTq.Text = "OK" Or srclbDecMotorTq.Text = "PASS" Or srclbDecMotorTq.Text = "NA") Then
                If Not _readyForDown Then
                    _readyForDown = True
                    srclbAlarm.Visible = True
                    srclbAlarm.Text = "다운前 판정 OK — Start로 지그 다운"
                    WriteTxtMessage("[IO] 다운前 판정 OK — Start(2회) 대기")
                End If
            End If

        ElseIf wStep = 3.2 Then
            HandleJigIoResult(JigClampSequence.Tick(Ios), 3.4, "지그 다운")

        ElseIf wStep = 3.4 Then
            ' 다운後 판정: 지그 다운 위치(IN:13) 유지 중에만 공구 작업
            If Not JigClampSequence.IsJigAtDown(Ios) Then
                srclbAlarm.Visible = True
                srclbAlarm.Text = "지그 다운 위치 이탈 — IN:13/14 확인 후 Reset"
                _readyForUp = False
                Exit Sub
            End If
            If srclbDecTool.Text <> "OK" AndAlso Not AtlasToolEnabled Then srclbDataTool.Text = PlcValue(4002)

            If (CInt(srclbDataTool.Text) = TargetToolNum) And srclbDecTool.Text <> "OK" Then
                srclbDecTool.Text = "OK"
                srclbDecTool.BackColor = Color.Blue
                DingDOng()
            End If

            If srclbDecTool.Text = "OK" Then
                If Not _readyForUp Then
                    _readyForUp = True
                    srclbAlarm.Visible = True
                    srclbAlarm.Text = "공구 판정 OK — Start로 지그 업"
                    WriteTxtMessage("[IO] 다운後 공구 판정 OK — Start(3회) 대기")
                End If
            End If

        ElseIf wStep = 3.6 Then
            HandleJigIoResult(JigClampSequence.Tick(Ios), 3.8, "지그 업")

        ElseIf wStep = 3.8 Then
            If Not JigClampSequence.IsJigAtUp(Ios) Then
                WriteTxtMessage("[IO] 지그 업 도착 신호 미확인 — IN:14 대기 (해제 대기)", "WSTEP38_WAIT_UP")
                Exit Sub
            End If
            JigClampSequence.BeginRelease()
            wStep = 3.9
            WriteTxtMessage("[IO] 제품 해제 시작 (wStep 3.9)")

        ElseIf wStep = 3.9 Then
            ' 제품 해제: 언클램프 → 핀후진 (1번 지그)
            HandleJigIoResult(JigClampSequence.Tick(Ios), 4, "제품 해제")

        ElseIf wStep = 4 Then

            SaveDB()
            SavePlan(srcLbPartNo.Text, TmpSeq)
            wStep = 5

        ElseIf wStep = 5 Then

            ' 지그 업은 wStep 3.6에서 IN:14 확인 완료 — 센서 재확인 후 라벨 인쇄
            If JigClampSequence.IsJigAtUp(Ios) OrElse PlcValue(4001) = 1 Then
                WritePlc("D", "4051", "0000000")
                BarcodePrint(srcLbSerial.Text, srcLbPartNo.Text)
                AddGrid(srcLbPartNo.Text)
                InitGrid()
                LoadGrid()
                InitControl()
                wStep = 0
            End If

        End If

    End Sub

    Private Sub Serial_Scanner_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Serial_Scanner.DataReceived

        Dim Incoming As String
        Dim ScanData As String
        Dim Flag As Boolean = False

        Incoming = Serial_Scanner.ReadLine()
        ScanData = Mid$(Incoming, 1, Len(Incoming) - 1)
        Serial_Scanner.DiscardInBuffer()

        WriteTxtMessage("ScanData : " & ScanData)

        If wStep = 3 Then

            If InStr(1, ScanData, TargetMotorBarcode) <> 0 And (srclbDecMotorBarcode.Text <> "NA") Then
                srclbDataMotorBarcode.Text = ScanData
                srclbDecMotorBarcode.Text = "OK"
                srclbDecMotorBarcode.BackColor = Color.Blue
                DingDOng()
                Flag = True
            End If

            If InStr(1, ScanData, TargetFrameBarcode) <> 0 And (srclbDecFrameBarcode.Text <> "NA") Then
                srclbDataFrameBarcode.Text = ScanData
                srclbDecFrameBarcode.Text = "OK"
                srclbDecFrameBarcode.BackColor = Color.Blue
                DingDOng()
                Flag = True
            End If

            If Flag = False Then NG()

        Else

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

        If AtlasToolEnabled OrElse Not Serial_Tool.IsOpen Then Exit Sub

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
        Dim ToolData As Double

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
                            ToolData = CDbl(Format(Val(Mid(Tool_String1, 143, 3) & "." & Mid(Tool_String1, 146, 2))))
                            WriteTxtMessage("ToolData : " & ToolData)

                            If wStep = 3 Then

                                If ToolData >= BasicToolMin And ToolData <= BasicToolMax And Mid(Tool_String1, 109, 1) = "1" Then
                                    srclbDataMotorTq.Text = ToolData
                                    srclbDecMotorTq.Text = "OK"
                                    srclbDecMotorTq.BackColor = Color.Blue
                                    DingDOng()
                                Else
                                    srclbDataMotorTq.Text = ToolData
                                    srclbDecMotorTq.Text = "NG"
                                    srclbDecMotorTq.BackColor = Color.Red
                                    NG()
                                End If

                            Else
                                NG()
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

        'Private AlarmMessage(100) As String
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

    Private Sub SavePlan(ByVal strPartNo As String, ByVal strSeq As String)

        Dim Rs As New ADODB.Recordset
        Dim tmp As Integer

        ConnectionOpenSQL()
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Plan Where PartNo = '" & Mid(strPartNo, 1, 11) & "' AND PartColor = '" & Mid(strPartNo, 12, 3) & "' AND Seq = '" & TmpSeq & "'", SqlConnect)

        If Rs.RecordCount = 1 Then
            tmp = CInt(Rs.Fields("PartCount").Value)
            tmp = tmp + 1
            Rs.Fields("partCount").Value = CStr(tmp)
            Rs.Update()
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

    End Sub

End Class
