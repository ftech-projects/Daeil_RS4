Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Media
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO.Ports
'Imports AxCWUIControlsLib  ' CWUIControlsLib COM 미등록 — 미사용 필드라 주석 처리

Public Class FrmMain

    Friend ReadOnly Property IoMonitorMm As MultiMonitorIoClient
        Get
            Return MmIo
        End Get
    End Property

    Friend ReadOnly Property IoMonitorFbei As FbeiIoClient
        Get
            Return Ios
        End Get
    End Property

    Friend ReadOnly Property IoMonitorSettings As MultiMonitorSettings
        Get
            Return _ioSettings
        End Get
    End Property

    Friend ReadOnly Property IoMonitorFbeiOk As Boolean
        Get
            Return _fbeiOk
        End Get
    End Property

    ' === 현장 레이저 (Keyence IL-300, PopV4 동일 MS/RS-232) ===
    Private WithEvents Lasers As KeyenceIlLaserClient
    ' FBEI 32DI + 32DO (EtherNet/IP) — 랜
    Private WithEvents Ios As FbeiIoClient
    Private _fbeiOk As Boolean
    ' ESP32 / MultiMonitor.ino (COM4, 115200)
    Private MmIo As MultiMonitorIoClient
    Private _ioSettings As MultiMonitorSettings
    Private _ioDiagTick As Integer

    Private EndBarcodeData As String
    Private TmpLsuptBArcode As String
    Private TmpSab1BArcode As String
    Private tmpSab2Barcode As String

    Private ValueLsrLeftUpper As Double
    Private ValueLsrLeftLower As Double
    Private ValueLsrRightUpper As Double
    Private ValueLsrRightLower As Double
    Private _laserGeometry As LaserGeometryConfig = New LaserGeometryConfig()

    Private TmpToolCount As Integer
    Private StartTIme As String
    Private Tool1_Delay_count As Double
    Private Tool1_Ready As Boolean
    Private Tool_String1 As String
    Private Tool_Connection1 As Boolean
    Private Tool1_Count As Integer

    Private Timer As New HiResTimer()
    Private TxtCount As Integer

    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"

    Private OptionLHRH As String
    Private OptionType As String
    Private OptionBack As String
    Private OptionFootRest As Boolean
    Private OptionMonitor As Boolean
    Private TargetMotorBarcode As String
    Private TargetToolNum As Integer
    Private TargetRivetNum As Integer

    Private D_OutString As String
    Private rStep As Double
    Private rCount As Double
    Private StartTimeL As String
    Private StartTimeR As String
    Private EndTime As String
    Private wStep As Double
    Private wCount As Double
    ' COM I/O 패널 IN0=Start, IN1=Reset, IN2=E-Stop, IN3=에어툴(Tool/Rivet 펄스)
    Private IoInStart As Boolean
    Private IoInReset As Boolean
    Private IoInEStop As Boolean
    Private IoInAirTool As Boolean
    Private IoStartPrev As Boolean
    Private IoResetPrev As Boolean
    Private IoEStopPrev As Boolean
    Private IoAirToolPrev As Boolean
    Private _ioToolPulseCount As Integer
    Private _ioRivetPulseCount As Integer
    Private _laserDiagTick As Integer
    Private _laserHasData As Boolean
    Private _step3WaitTick As Integer
    Private _runLengthAtStep3 As Boolean
    Private _ioComOkLogged As Boolean
    Private _fbeiOkLogged As Boolean
    Private _serverConnectionLogged As Boolean
    Private _eStopAlarmActive As Boolean
    Private _soundFolderLogged As Boolean

    Public D_Value(0 To 48) As Integer
    'Public IN_LABEL(48) As AxCWUIControlsLib.AxCWButton  ' 미사용 — CWUIControlsLib COM 제거로 주석 처리
    'Public OUT_LABEL(24) As AxCWUIControlsLib.AxCWButton

    Private Trd1 As Thread
    Private Trd2 As Thread
    Private Trd3 As Thread
    Private RecvString As New System.Text.StringBuilder()

    ''' <summary>SOUND 폴더에 wav 있으면 재생, 없으면 스킵</summary>
    Private Sub PlayAppSound(fileName As String)
        If String.IsNullOrEmpty(fileName) Then Return
        Dim soundPath = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SOUND", fileName)
        If Not File.Exists(soundPath) Then Return
        ThreadPool.QueueUserWorkItem(
            Sub(state)
                Try
                    Using sp As New SoundPlayer(CStr(state))
                        sp.PlaySync()
                    End Using
                Catch ex As Exception
                    Try
                        If IsHandleCreated AndAlso Not IsDisposed Then
                            BeginInvoke(Sub() WriteTxtMessage("[SOUND] 재생 실패 " & IO.Path.GetFileName(CStr(state)) & ": " & ex.Message))
                        End If
                    Catch
                    End Try
                End Try
            End Sub, soundPath)
    End Sub

    Private Sub LogSoundFolderOnce()
        If _soundFolderLogged Then Return
        _soundFolderLogged = True
        Dim soundDir = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SOUND")
        If Not Directory.Exists(soundDir) Then
            WriteTxtMessage("[SOUND] 폴더 없음: " & soundDir)
            Return
        End If
        Dim names = Directory.GetFiles(soundDir, "*.wav").Select(Function(f) IO.Path.GetFileName(f)).ToArray()
        If names.Length = 0 Then
            WriteTxtMessage("[SOUND] wav 없음: " & soundDir)
        Else
            WriteTxtMessage("[SOUND] " & soundDir & " → " & String.Join(", ", names))
        End If
    End Sub

    Private Sub NG()
        PlayAppSound("NG.wav")
    End Sub

    Private Sub DingDOng()
        PlayAppSound("DINGDONG.wav")
    End Sub

    ''' <summary>판정 라벨 OK — 최초 OK 전환 시에만 띵동 (중복 재생 방지)</summary>
    Private Sub MarkDecisionOk(lbl As Label)
        If lbl.Text = "OK" Then Return
        lbl.Text = "OK"
        lbl.BackColor = Color.Blue
        DingDOng()
    End Sub

    ''' <summary>해당 없음(PASS) — 체결·스캔 생략 항목, 무음·녹색</summary>
    Private Sub MarkDecisionPass(lbl As Label)
        If lbl.Text = "PASS" Then Return
        lbl.Text = "PASS"
        lbl.BackColor = Color.Green
    End Sub

    Private Function IsDecisionComplete(decText As String) As Boolean
        Return decText = "OK" OrElse decText = "PASS"
    End Function

    ''' <summary>목표 0(미체결)·커버 미사용 등 시퀀스 생략 항목 PASS 처리</summary>
    Private Sub ApplyPartSkipDecisions()
        If TargetToolNum = 0 Then
            srclbDataTool.Text = "0"
            MarkDecisionPass(srclbDecTool)
        End If
        If TargetRivetNum = 0 Then
            srclbDataRivet.Text = "0"
            MarkDecisionPass(srclbDecRivet)
        End If
    End Sub

    ''' <summary>동적 데이터 라벨 글자 크기를 박스에 맞춤</summary>
    Private Sub FitDynamicLabels()
        LabelTextFitHelper.FitLabels(
            srcLbPartNo, srcLbPartName, srcLbPartOption, srcLbSerial,
            srclbTargetTool, srclbDataTool, srclbDecTool,
            srclbTargetRivet, srclbDataRivet, srclbDecRivet,
            srclbSpecLengthTest, srclbDataLengthTestFrt, srclbDecLengthTestFrt,
            srclbDataLengthTestRear, srclbDecLengthTestRear,
            srclbTargetCoverL, srclbDataCoverL, srclbDecCoverL,
            srclbTargetCoverR, srclbDataCoverR, srclbDecCoverR,
            srcLsrLeftUpper, srcLsrRightUpper, srcLsrLeftLower, srcLsrRightLower,
            srcLbCheck1, srcLbCheck2_1, srcLbCheck2_2, srcLbCheckVip, srcLbCheckNoiseTest,
            LabelFrt, LabelRear, srclbAlarm)
    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        FitDynamicLabels()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LoadPicture(ByVal picTarget As PictureBox, ByVal picName As String)

        Dim tmp As String
        tmp = picName

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

    ' FlexCell → DataGridView 변환. 미사용 메서드지만 타입 호환 유지
    Private Sub Init_Grid(ByVal GridName As System.Windows.Forms.DataGridView)

        With GridName
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .RowHeadersVisible = False
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect

            .ColumnCount = 4
            For i As Integer = 0 To 3
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            .Columns(0).Width = 0
            .Columns(0).Visible = False
            .Columns(1).Width = 60
            .Columns(2).Width = 80
            .Columns(3).Width = 100

            .Columns(1).HeaderText = "No."
            .Columns(2).HeaderText = "I/O"
            .Columns(3).HeaderText = "Dec."

            .Refresh()
        End With

    End Sub

    Private Sub InitControl()

        LoadPicture(srcPictureBox, "NON")
        LoadPicture(srcPictureBox2, "NON")
        srcLbPartNo.Text = ""
        srcLbPartName.Text = ""
        srcLbPartOption.Text = ""
        srcLbSerial.Text = ""

        srclbDataTool.Text = ""
        srclbDecTool.Text = ""
        srclbDecTool.BackColor = Color.Black
        srclbTargetTool.Text = ""

        srclbDataRivet.Text = ""
        srclbDecRivet.Text = ""
        srclbDecRivet.BackColor = Color.Black
        srclbTargetRivet.Text = ""

        srclbSpecLengthTest.Text = ""
        srclbDataLengthTestFrt.Text = ""
        srclbDataLengthTestRear.Text = ""
        srclbDecLengthTestFrt.Text = ""
        srclbDecLengthTestFrt.BackColor = Color.Black
        srclbDecLengthTestRear.Text = ""
        srclbDecLengthTestRear.BackColor = Color.Black

        srcLbCheck1.Text = ""
        srcLbCheck2_1.Text = ""
        srcLbCheck2_2.Text = ""
        srcLbCheckVip.Text = ""
        srcLbCheckNoiseTest.Text = ""

        srcLbCheck1.BackColor = Color.Black
        srcLbCheck2_1.BackColor = Color.Black
        srcLbCheck2_2.BackColor = Color.Black
        srcLbCheckVip.BackColor = Color.Black
        srcLbCheckNoiseTest.BackColor = Color.Black

        srclbTargetCoverL.Text = ""
        srclbTargetCoverR.Text = ""
        srclbDataCoverL.Text = ""
        srclbDataCoverR.Text = ""
        srclbDecCoverL.Text = ""
        srclbDecCoverR.Text = ""
        srclbDecCoverL.BackColor = Color.Black
        srclbDecCoverR.BackColor = Color.Black

        ResetIoToolRivetCounts()
        UpdateStepTraceLabels()
        FitDynamicLabels()

    End Sub

    Private Sub ResetIoToolRivetCounts()
        _ioToolPulseCount = 0
        _ioRivetPulseCount = 0
        IoAirToolPrev = False
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

        If Not String.IsNullOrWhiteSpace(PortNumber_Tool) AndAlso
           Not String.Equals(PortNumber_Tool, "Disabled", StringComparison.OrdinalIgnoreCase) AndAlso
           Not String.Equals(PortNumber_Tool, PortNumber_Io, StringComparison.OrdinalIgnoreCase) Then
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
                WriteTxtMessage("Serial Tool Open Fail " & PortNumber_Tool)
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
            Serial_Scanner.StopBits = IO.Ports.StopBits.One
            Serial_Scanner.Handshake = IO.Ports.Handshake.None
            Serial_Scanner.NewLine = vbCr
            Serial_Scanner.Encoding = System.Text.Encoding.ASCII
            Serial_Scanner.ReadTimeout = 800
            Serial_Scanner.Open()
            WriteTxtMessage("Serial Scanner Open Success " & PortNumber_Scanner & " (9600 None CR)")
        Catch ex As Exception
            WriteTxtMessage("Serial Scanner Open Fail " & PortNumber_Scanner & ": " & ex.Message)
        End Try

    End Sub

    ''' <summary>스캐너 수신 문자열 정리 — ReadLine 후 CR/LF/널 제거 (마지막 글자 잘라내기 금지)</summary>
    Private Function NormalizeScanText(raw As String) As String
        If raw Is Nothing Then Return ""
        Return raw.Trim().Trim(ChrW(0), ChrW(13), ChrW(10))
    End Function

    Private Function ReadScannerPayload() As String
        Try
            Return Serial_Scanner.ReadLine()
        Catch ex As TimeoutException
            Return Serial_Scanner.ReadExisting()
        End Try
    End Function

    Sub BarcodePrint(ByVal strSerial As String, ByVal strPartno As String)

        Dim TmpEndSerial As String
        Dim StartCode As String
        Dim EndCode As String
        Dim aCode As String
        Dim vCode As String
        Dim pCode As String
        Dim sCode As String
        Dim eCode As String
        Dim tCode As String
        Dim mCode As String
        Dim cCode As String

        Dim RS As String = "_1e"
        Dim GS As String = "_1d"
        Dim EOT As String = "_04"

        Dim tmpSerial As String = strSerial
        Dim tmpPartNo As String = strPartno
        Dim SplitSab1String() As String
        Dim SplitSab2String() As String
        Dim SplitLsuptString() As String

        Dim Sab1String As String = ""
        Dim Sab2String As String = ""
        Dim LsuptString As String = ""
        Dim BarcodeSize As Integer

        BarcodeSize = CInt(BarcodeBH)

        'Tmp = Format(Now, "yy") & ConvertMonth(Format(Now, "MM")) & Format(Now, "dd") & Format(1, "0000") & strPArt

        '2021 03 29 0001 88310-G0000AAA

        Mid(tmpSerial, 17, 1) = "0"
        Mid(tmpPartNo, 5, 1) = "0"

        StartCode = "[)>" & RS & "06" & GS
        vCode = "V" & "2812" & GS
        pCode = "P" & Mid(tmpSerial, 13, 5) & Mid(tmpSerial, 19, 8) & GS
        sCode = "S" & "" & GS
        eCode = "E" & "XXXXXXXXX" & GS
        tCode = "T" & Mid(tmpSerial, 3, 6) & "S1B2" & "A" & "000" & Mid(tmpSerial, 9, 4) & GS
        aCode = "1A" & GS
        mCode = "M" & "Y" & GS
        cCode = "C" & GS
        EndCode = RS & EOT

        If TmpSab1BArcode <> "" Then
            SplitSab1String = Split(TmpSab1BArcode, Chr(29))
            For i As Integer = 1 To UBound(SplitSab1String) - 1
                Sab1String = Sab1String & SplitSab1String(i) & GS
            Next i
        End If
        
        If tmpSab2Barcode <> "" Then
            SplitSab2String = Split(tmpSab2Barcode, Chr(29))
            For i As Integer = 1 To UBound(SplitSab2String) - 1
                Sab2String = Sab2String & SplitSab2String(i) & GS
            Next i
        End If

        If TmpLsuptBArcode <> "" Then
            SplitLsuptString = Split(TmpLsuptBArcode, Chr(29))
            For i As Integer = 1 To UBound(SplitLsuptString) - 1
                LsuptString = LsuptString & SplitLsuptString(i) & GS
            Next i
        End If

        If Sab1String = "" And Sab2String = "" Then

            If LsuptString = "" Then
                TmpEndSerial = StartCode & vCode & pCode & sCode & eCode & tCode & mCode & cCode & EndCode
            Else
                TmpEndSerial = StartCode & vCode & pCode & sCode & eCode & tCode & mCode & cCode & EndCode &
                               "#" & "[)>" & RS & "06" & GS & LsuptString & RS & EOT
            End If

        ElseIf Sab1String = "" And Sab2String <> "" Then

            BarcodeSize = BarcodeSize - 1
            If LsuptString = "" Then
                TmpEndSerial = StartCode & vCode & pCode & sCode & eCode & tCode & mCode & cCode & EndCode &
                           "#" & "[)>" & RS & "06" & GS & Sab2String & RS & EOT
            Else
                TmpEndSerial = StartCode & vCode & pCode & sCode & eCode & tCode & mCode & cCode & EndCode &
                           "#" & "[)>" & RS & "06" & GS & Sab2String & RS & EOT &
                           "#" & "[)>" & RS & "06" & GS & LsuptString & RS & EOT
            End If

        ElseIf Sab1String <> "" And Sab2String = "" Then

            BarcodeSize = BarcodeSize - 1
            If LsuptString = "" Then
                TmpEndSerial = StartCode & vCode & pCode & sCode & eCode & tCode & mCode & cCode & EndCode &
                           "#" & "[)>" & RS & "06" & GS & Sab1String & RS & EOT
            Else
                TmpEndSerial = StartCode & vCode & pCode & sCode & eCode & tCode & mCode & cCode & EndCode &
                           "#" & "[)>" & RS & "06" & GS & Sab1String & RS & EOT &
                           "#" & "[)>" & RS & "06" & GS & LsuptString & RS & EOT
            End If
            
        ElseIf Sab1String <> "" And Sab2String <> "" Then

            BarcodeSize = BarcodeSize - 2
            If LsuptString = "" Then
                TmpEndSerial = StartCode & vCode & pCode & sCode & eCode & tCode & mCode & cCode & EndCode &
                           "#" & "[)>" & RS & "06" & GS & Sab1String & RS & EOT &
                           "#" & "[)>" & RS & "06" & GS & Sab2String & RS & EOT
            Else
                TmpEndSerial = StartCode & vCode & pCode & sCode & eCode & tCode & mCode & cCode & EndCode &
                           "#" & "[)>" & RS & "06" & GS & Sab1String & RS & EOT &
                           "#" & "[)>" & RS & "06" & GS & Sab2String & RS & EOT &
                           "#" & "[)>" & RS & "06" & GS & LsuptString & RS & EOT
            End If

        End If

        'tTmp = "[)>" & RS & "06" & GS &
        '            "V" & "2812" & GS &
        '            "P" & Partno & GS &
        '            "S" & "" & GS &
        '            "E" & "" & GS &
        '            "T" & Mid(Lot, 1, 6) & "D100" & "A" & "0000" & Mid(Lot, 7, 7) & GS &
        '            "M" & "" & GS &
        '            "C" & "" & GS & RS & EOT &
        '            "#" & "[)>" & RS & "06" & GS & tmp1 & RS & EOT &
        '            "#" & "[)>" & RS & "06" & GS & tmp2 & RS & EOT

        EndBarcodeData = TmpEndSerial
        Serial_Printer.Write("^XA")
        Serial_Printer.Write("^FO" & BarcodeBX & "," & BarcodeBY & "^BY5^BXN," & CStr(BarcodeSize) & ",200,,,,^FH^FD" & TmpEndSerial & "^FS")
        Serial_Printer.Write("^FO" & BarcodeS1X & "," & BarcodeS1Y & "^A0N," & BarcodeS1H & "," & BarcodeS1W & "^FD" & Mid(tmpSerial, 13, 5) & "-" & Mid(tmpSerial, 19, 8) & "^FS")
        Serial_Printer.Write("^FO" & BarcodeS2X & "," & BarcodeS2Y & "^A0N," & BarcodeS2H & "," & BarcodeS2W & "^FD" & tmpSerial & "^FS")
        Serial_Printer.Write("^FO" & BarcodeS3X & "," & BarcodeS3Y & "^A0N," & BarcodeS3H & "," & BarcodeS3W & "^FD" & srcLbPartName.Text & " " & srcLbPartOption.Text & "^FS")
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
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

        Return Tmp

    End Function

    Private Function RsFieldStr(rs As ADODB.Recordset, ParamArray fieldNames() As String) As String
        For Each fieldName As String In fieldNames
            Try
                Return Trim(CStr(rs.Fields(fieldName).Value))
            Catch
            End Try
        Next
        Return ""
    End Function

    Private Function RsFieldInt(rs As ADODB.Recordset, fieldName As String, Optional defaultValue As Integer = 0) As Integer
        Try
            Dim raw As String = Trim(CStr(rs.Fields(fieldName).Value))
            If String.IsNullOrEmpty(raw) Then Return defaultValue
            Return CInt(raw)
        Catch
            Return defaultValue
        End Try
    End Function

    Private Function RsFieldBool(rs As ADODB.Recordset, fieldName As String, Optional defaultValue As Boolean = False) As Boolean
        Try
            Dim raw As Object = rs.Fields(fieldName).Value
            If IsDBNull(raw) Then Return defaultValue
            Return CBool(raw)
        Catch
            Return defaultValue
        End Try
    End Function

    Private Function LoadPArt(ByVal str As String) As Boolean
        Dim partKey As String = Mid(str, 13, 11)
        Dim rs As ADODB.Recordset = Nothing
        Dim usingLocalMdb As Boolean = False
        LoadPArt = False

        Try
            ConnectionOpenSQL()
            If SqlConnect IsNot Nothing AndAlso SqlConnect.State = ADODB.ObjectStateEnum.adStateOpen Then
                rs = New ADODB.Recordset
                rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
                rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
                rs.Open("SELECT * FROM Table_Part WHERE PartNo = '" & partKey & "'", SqlConnect)
            End If
        Catch
        End Try

        If rs Is Nothing OrElse rs.RecordCount = 0 Then
            Try
                EnsurePartLocalTable()
                If ConnectionOpenMDB() Then
                    If rs IsNot Nothing Then
                        Try
                            If rs.State = ADODB.ObjectStateEnum.adStateOpen Then rs.Close()
                        Catch
                        End Try
                    End If
                    rs = New ADODB.Recordset
                    rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                    rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
                    rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
                    rs.Open("SELECT * FROM Table_Part_Local WHERE PartNo = '" & partKey & "'", MdbConnect)
                    usingLocalMdb = True
                End If
            Catch
            End Try
        End If

        If rs IsNot Nothing AndAlso rs.RecordCount = 1 Then
            srcLbPartNo.Text = Mid(str, 13, 14)
            srcLbPartName.Text = Trim(rs.Fields("PartName").Value)
            LoadPicture(srcPictureBox, Mid(srcLbPartNo.Text, 1, 11))

            OptionLHRH = RsFieldStr(rs, "OptionLHRH", "OptionLhRh")
            OptionType = RsFieldStr(rs, "OptionType")
            OptionBack = RsFieldStr(rs, "OptionBack")
            OptionFootRest = RsFieldBool(rs, "OptionFootRest")
            OptionMonitor = RsFieldBool(rs, "OptionMon")

            srcLbPartOption.Text = OptionType & " " & OptionLHRH
            TargetToolNum = RsFieldInt(rs, "Target_Op04_ToolNum")
            TargetRivetNum = RsFieldInt(rs, "Target_Op04_RivetNum")
            srclbTargetTool.Text = CStr(TargetToolNum)
            srclbTargetRivet.Text = CStr(TargetRivetNum)

            If Trim(rs.Fields("Target_Op03_InsideCoverL").Value) = "0" Then
                srclbTargetCoverL.Text = "0"
                srclbDataCoverL.Text = ""
                MarkDecisionPass(srclbDecCoverL)
            Else
                srclbTargetCoverL.Text = Trim(rs.Fields("Target_Op03_InsideCoverL").Value) & Microsoft.VisualBasic.Right(srcLbPartNo.Text, 3)
                srclbDataCoverL.Text = ""
                srclbDecCoverL.Text = ""
                srclbDecCoverL.BackColor = Color.Black
            End If

            If Trim(rs.Fields("Target_Op03_InsideCoverR").Value) = "0" Then
                srclbTargetCoverR.Text = "0"
                srclbDataCoverR.Text = ""
                MarkDecisionPass(srclbDecCoverR)
            Else
                srclbTargetCoverR.Text = Trim(rs.Fields("Target_Op03_InsideCoverR").Value) & Microsoft.VisualBasic.Right(srcLbPartNo.Text, 3)
                srclbDataCoverR.Text = ""
                srclbDecCoverR.Text = ""
                srclbDecCoverR.BackColor = Color.Black
            End If

            ApplyPartSkipDecisions()

            If OptionType = "VIP" Then
                srclbSpecLengthTest.Text = BAsicFrtMin_VIPRH & " ~ " & BAsicFrtMax_VIPRH
            ElseIf OptionType = "STD" Then
                srclbSpecLengthTest.Text = BAsicFrtMin_STDLH & " ~ " & BAsicFrtMax_STDLH
            ElseIf OptionType = "FOLD" Then
                srclbSpecLengthTest.Text = BAsicFrtMin_FOLDRH & " ~ " & BAsicFrtMax_FOLDRH
            End If

            If usingLocalMdb Then
                WriteTxtMessage("[PART] SQL 오프라인 - 로컬 Table_Part_Local 사용")
            End If
            LoadPArt = True
        Else
            WriteTxtMessage("[PART] 조회 실패: " & partKey & " (SQL Table_Part / MDB Table_Part_Local 미등록)")
        End If

        Try
            If rs IsNot Nothing Then
                rs.ActiveConnection = Nothing
                If rs.State = ADODB.ObjectStateEnum.adStateOpen Then rs.Close()
            End If
        Catch
        End Try
        ConnectionCloseSQL()
        If usingLocalMdb Then ConnectionCloseMDB()
        FitDynamicLabels()
    End Function

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

    Private Sub SaveDB(ByVal strSerial As String)

        Dim strSQL As String = ""

        ConnectionOpenSQL()

        strSQL = "UPDATE TABLE_MAIN SET " &
                    "Op03_DATE = '" & Format(Now, "yyyy-MM-dd") & "'," &
                    "Op03_STARTTIME = '" & StartTIme & "'," &
                    "Op03_ENDTIME = '" & Format(Now, "HH:mm:ss") & "'," &
                    "Op03_CoverL = '" & srclbDataCoverL.Text & "'," &
                    "Op03_CoverR = '" & srclbDataCoverR.Text & "'," &
                    "Op03_LengthFRT = '" & srclbDataLengthTestFrt.Text & "'," &
                    "End_BArcode = '" & EndBarcodeData & "'," &
                    "Op03_LengthREAR = '" & srclbDataLengthTestRear.Text & "' " &
                    "WHERE SERIALNO = '" & strSerial & "'"

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

    Private Sub WriteTxtMessage(ByVal strMessage As String)

        TxtCount = TxtCount + 1
        If TxtCount = 5 Then
            txtMessage.Text = Format(Now, "yyyy-MM-dd") & " " & Format(Now, "HH:mm:ss") & ": " & strMessage & vbCrLf
            TxtCount = 1
        Else
            txtMessage.Text = txtMessage.Text & Format(Now, "yyyy-MM-dd") & " " & Format(Now, "HH:mm:ss") & ": " & strMessage & vbCrLf
        End If

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

    ''' <summary>Keyence IL 레이저 COM 변경 시 포트 설정 저장 후 재연결</summary>
    Public Sub RestartLaserCommunication()
        Try
            If Lasers IsNot Nothing Then
                Lasers.Dispose()
                Lasers = Nothing
            End If
            StartLaserPolling()
        Catch ex As Exception
            WriteTxtMessage("[KeyenceIL] 재시작 실패: " & ex.Message)
        End Try
    End Sub

    Private Sub StartLaserPolling()
        Dim cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json")
        _laserGeometry = LaserGeometryConfig.LoadFromConfig(cfgPath)
        Dim laserCom = If(String.IsNullOrWhiteSpace(PortNumber_Laser), "COM3", PortNumber_Laser.Trim())
        Dim scannerCom = If(String.IsNullOrWhiteSpace(PortNumber_Scanner), "", PortNumber_Scanner.Trim())

        If String.Equals(laserCom, "Disabled", StringComparison.OrdinalIgnoreCase) Then
            WriteTxtMessage("[KeyenceIL] Laser=Disabled — 레이저 폴링 생략")
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(scannerCom) AndAlso
           String.Equals(laserCom, scannerCom, StringComparison.OrdinalIgnoreCase) Then
            WriteTxtMessage("[KeyenceIL] 오류: Laser COM(" & laserCom & ") = Scanner COM — 포트 충돌, 레이저 미시작")
            WriteTxtMessage("[KeyenceIL] PORT SETTING에서 Scanner/Laser COM을 서로 다르게 설정하세요")
            Exit Sub
        End If

        Lasers = KeyenceIlLaserClient.FromConfig(cfgPath, laserCom)
        Lasers.StartPolling()
        _laserHasData = False
        WriteTxtMessage("[KeyenceIL] 폴링 시작 COM=" & laserCom & " (Scanner=" & scannerCom & ", MS 프로토콜)")
        WriteTxtMessage("[KeyenceIL] 보정: 상단×cos(" & Format(_laserGeometry.UpperTiltDeg, "0.#") & "°), 하단=Value×" &
                        Format(_laserGeometry.LowerScale, "0.###") & "+" & Format(_laserGeometry.LowerOffsetMm, "0.#") & "mm")
    End Sub

    Public Sub RestartIoCommunication()
        _ioComOkLogged = False
        Try
            If MmIo IsNot Nothing Then
                RemoveHandler MmIo.LogMessage, AddressOf MmIo_LogMessage
                RemoveHandler MmIo.DigitalInputChanged, AddressOf MmIo_DigitalInputChanged
                MmIo.Dispose()
                MmIo = Nothing
            End If
            ConnectMultiMonitorIo()
        Catch ex As Exception
            WriteTxtMessage("[IO-COM] 재시작 실패: " & ex.Message)
        End Try
    End Sub

    Private Sub ConnectMultiMonitorIo()
        Dim cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json")
        _ioSettings = MultiMonitorIoClient.LoadSettings(cfgPath)
        If Not String.IsNullOrWhiteSpace(PortNumber_Io) Then
            _ioSettings.ComPort = PortNumber_Io.Trim()
        End If

        If Not _ioSettings.Enabled Then
            WriteTxtMessage("[IO-COM] multiMonitor.enabled=false — COM I/O 생략")
            Exit Sub
        End If
        If String.Equals(_ioSettings.ComPort, "Disabled", StringComparison.OrdinalIgnoreCase) Then
            WriteTxtMessage("[IO-COM] Disabled — COM I/O 생략")
            Exit Sub
        End If

        MmIo = New MultiMonitorIoClient(_ioSettings.ComPort, _ioSettings.BaudRate)
        AddHandler MmIo.LogMessage, AddressOf MmIo_LogMessage
        AddHandler MmIo.DigitalInputChanged, AddressOf MmIo_DigitalInputChanged
        MmIo.Connect()
        WriteTxtMessage("[IO-COM] IN3 에어툴 DI 채널=" & _ioSettings.IoChannelAirTool().ToString())
        RefreshIoDiagnosticUi()
        RefreshPlcSignalIndicators()
    End Sub

    Private Sub ConnectFbeiIo()
        _fbeiOk = False
        If _ioSettings Is Nothing OrElse Not _ioSettings.FbeiEnabled Then
            WriteTxtMessage("[FBEI] config fbei.enabled=false — 랜 I/O 생략")
            Exit Sub
        End If

        Try
            Ios = New FbeiIoClient(_ioSettings.FbeiDiIp, _ioSettings.FbeiDoIp, _ioSettings.FbeiRpiMs)
            Ios.Connect()
            _fbeiOk = True
            WriteTxtMessage("[FBEI] EtherNet/IP 연결 OK (DI=" & _ioSettings.FbeiDiIp & ", DO=" & _ioSettings.FbeiDoIp & ")")
        Catch ex As Exception
            WriteTxtMessage("[FBEI] 연결 실패: " & ex.Message)
        End Try
    End Sub

    ''' <summary>Keyence IL 레이저 + COM I/O(MultiMonitor) + FBEI 랜 I/O 초기화 (레이저는 SerialOpen 이후)</summary>
    Private Sub InitializeElcoDevices()
        Dim cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json")
        _ioSettings = MultiMonitorIoClient.LoadSettings(cfgPath)

        Try
            ConnectMultiMonitorIo()
        Catch ex As Exception
            WriteTxtMessage("[IO-COM] 초기화 실패: " & ex.Message)
        End Try

        ConnectFbeiIo()
        LogIoLinkSummary()
    End Sub

    Private Sub StartLaserAfterSerialOpen()
        Try
            StartLaserPolling()
        Catch ex As Exception
            WriteTxtMessage("[KeyenceIL] 초기화 실패: " & ex.Message)
        End Try
    End Sub

    Private Sub LogIoLinkSummary()
        Dim comOk = MmIo IsNot Nothing AndAlso MmIo.IsConnected
        WriteTxtMessage("[I/O 요약] COM " & If(comOk, "OK " & _ioSettings.ComPort, "NG") &
                        " | FBEI 랜 " & If(_fbeiOk, "OK", "NG"))
    End Sub

    ''' <summary>Keyence IL 간거리 업데이트 — UI 스레드로 마샬링 (mm = 모델기준거리 - raw)</summary>
    Private Sub Lasers_Updated(mappingIndex As Integer, distanceMm As Double) Handles Lasers.Updated
        If Double.IsNaN(distanceMm) OrElse Double.IsInfinity(distanceMm) Then Exit Sub
        Dim valueMm As Double = distanceMm
        If InvokeRequired Then
            BeginInvoke(Sub() ApplyLaserValue(mappingIndex, valueMm))
        Else
            ApplyLaserValue(mappingIndex, valueMm)
        End If
    End Sub

    Private Sub ApplyLaserValue(mappingIndex As Integer, gapMm As Double)
        ' gapMm = 모델기준(300) - raw → 상단 cos(θ), 하단 scale/offset 후 합연산에 사용
        Dim corrected = _laserGeometry.CorrectGapMm(mappingIndex, gapMm)
        Dim display = Format(corrected, "0.0#")

        Select Case mappingIndex
            Case 0  ' LsrLeftUpper (상단 +8°)
                ValueLsrLeftUpper = corrected
                srcLsrLeftUpper.Text = display
            Case 1  ' LsrRightUpper
                ValueLsrRightUpper = corrected
                srcLsrRightUpper.Text = display
            Case 2  ' LsrLeftLower (수평)
                ValueLsrLeftLower = corrected
                srcLsrLeftLower.Text = display
            Case 3  ' LsrRightLower
                ValueLsrRightLower = corrected
                srcLsrRightLower.Text = display
        End Select

        _laserHasData = True
        UpdateStepTraceLabels()
        LabelTextFitHelper.FitLabels(srcLsrLeftUpper, srcLsrRightUpper, srcLsrLeftLower, srcLsrRightLower)
    End Sub

    Private Function ResolveOptionTypeForLength() As String
        Dim t = OptionType.Trim()
        If String.IsNullOrEmpty(t) Then Return "STD"
        Return t
    End Function

    Private Sub LogLaserValuesAtStep3()
        _laserDiagTick += 1
        If _laserDiagTick Mod 30 <> 0 Then Return
        Dim pollOk = Lasers IsNot Nothing
        WriteTxtMessage("[KeyenceIL] wStep3 LU=" & Format(ValueLsrLeftUpper, "0.0#") &
                        " RU=" & Format(ValueLsrRightUpper, "0.0#") &
                        " LL=" & Format(ValueLsrLeftLower, "0.0#") &
                        " RL=" & Format(ValueLsrRightLower, "0.0#") &
                        " recv=" & If(_laserHasData, "Y", "N") &
                        " poll=" & If(pollOk, "Y", "N"))
    End Sub

    ''' <summary>간거리 Frt/Rear — 판정은 각각 표시, 소리만 세트 1회</summary>
    Private Sub FinalizeLengthSetJudgment(frtOk As Boolean, rearOk As Boolean)
        If frtOk Then
            srclbDecLengthTestFrt.Text = "OK" : srclbDecLengthTestFrt.BackColor = Color.Blue
        Else
            srclbDecLengthTestFrt.Text = "NG" : srclbDecLengthTestFrt.BackColor = Color.Red
        End If
        If rearOk Then
            srclbDecLengthTestRear.Text = "OK" : srclbDecLengthTestRear.BackColor = Color.Blue
        Else
            srclbDecLengthTestRear.Text = "NG" : srclbDecLengthTestRear.BackColor = Color.Red
        End If

        If frtOk AndAlso rearOk Then
            DingDOng()
            srclbAlarm.Visible = False
            NOW_COLOR = Mid(srcLbPartNo.Text, 12, 3)
            FrmColor.WindowState = FormWindowState.Normal
            FrmColor.Location = New Point(-2500, 0)
            FrmColor.WindowState = FormWindowState.Maximized
            FrmColor.Show()
            ResetIoToolRivetCounts()
            ApplyPartSkipDecisions()
            If TargetToolNum > 0 Then srclbDataTool.Text = "0"
            If TargetRivetNum > 0 Then srclbDataRivet.Text = "0"
            WriteTxtMessage("[LENGTH] OK Frt+Rear 세트 통과")
            wStep = 4
        Else
            NG()
            WriteTxtMessage("[LENGTH] NG Frt=" & If(frtOk, "OK", "NG") &
                            " Rear=" & If(rearOk, "OK", "NG") & " — Start(IN0) 재검사")
            wStep = 3.1
            _runLengthAtStep3 = False
        End If
        FitDynamicLabels()
    End Sub

    ''' <summary>wStep 3 길이시험 — OptionType(VIP/STD/FOLD), 비어 있으면 STD</summary>
    Private Sub RunLengthTestStep3()
        Dim opt = ResolveOptionTypeForLength()
        If String.IsNullOrEmpty(OptionType.Trim()) Then
            WriteTxtMessage("[LENGTH] OptionType 미설정 — STD 공차로 계산")
        End If

        Dim frtOk As Boolean
        Dim rearOk As Boolean
        Dim frtVal As Double
        Dim rearVal As Double

        If opt = "VIP" Then
            frtVal = basicFrtTolVIP - ValueLsrLeftUpper - ValueLsrRightUpper
            rearVal = BasicRearTolVIP - ValueLsrLeftLower - ValueLsrRightLower
            srclbDataLengthTestFrt.Text = Format(frtVal, "0.0#")
            srclbDataLengthTestRear.Text = Format(rearVal, "0.0#")
            frtOk = frtVal >= BAsicFrtMin_VIPRH And frtVal <= BAsicFrtMax_VIPRH
            rearOk = rearVal >= BAsicRearMin_VIPRH And rearVal <= BAsicRearMax_VIPRH
        ElseIf opt = "FOLD" Then
            frtVal = basicFrtTolFOLD - ValueLsrLeftUpper - ValueLsrRightUpper
            rearVal = BasicRearTolFOLD - ValueLsrLeftLower - ValueLsrRightLower
            srclbDataLengthTestFrt.Text = Format(frtVal, "0.0#")
            srclbDataLengthTestRear.Text = Format(rearVal, "0.0#")
            frtOk = frtVal >= BAsicFrtMin_FOLDRH And frtVal <= BAsicFrtMax_FOLDRH
            rearOk = rearVal >= BAsicRearMin_FOLDRH And rearVal <= BAsicRearMax_FOLDRH
        Else
            frtVal = basicFrtTolSTD - ValueLsrLeftUpper - ValueLsrRightUpper
            rearVal = BasicRearTolSTD - ValueLsrLeftLower - ValueLsrRightLower
            srclbDataLengthTestFrt.Text = Format(frtVal, "0.0#")
            srclbDataLengthTestRear.Text = Format(rearVal, "0.0#")
            Dim frtTol As Double = (BAsicFrtMax_STDLH - BAsicFrtMin_STDLH)
            Dim rearTol As Double = (BAsicRearMax_STDLH - BAsicRearMin_STDLH)
            frtOk = frtVal >= (BAsicFrtMin_STDLH - frtTol) And frtVal <= (BAsicFrtMax_STDLH + frtTol)
            rearOk = rearVal >= (BAsicRearMin_STDLH - rearTol) And rearVal <= (BAsicRearMax_STDLH + rearTol)
        End If

        FinalizeLengthSetJudgment(frtOk, rearOk)
    End Sub

    ''' <summary>wStep / reset step(reStep) 표시 라벨 갱신</summary>
    Private Sub UpdateStepTraceLabels()
        LabelFrt.Text = "wStep: " & wStep.ToString()
        LabelRear.Text = "reStep: " & rStep.ToString()
        LabelTextFitHelper.FitLabels(LabelFrt, LabelRear)
    End Sub

    Private Sub Lasers_LogMessage(message As String) Handles Lasers.LogMessage
        WriteTxtMessage(message)
    End Sub

    Private Sub Ios_LogMessage(message As String) Handles Ios.LogMessage
        WriteTxtMessage(message)
    End Sub

    Private Sub MmIo_LogMessage(message As String)
        If message.StartsWith("[IO-COM] 연결 OK", StringComparison.OrdinalIgnoreCase) Then
            If _ioComOkLogged Then Return
            _ioComOkLogged = True
        End If
        WriteTxtMessage(message)
    End Sub

    Private Sub MmIo_DigitalInputChanged(channel As Integer, value As Boolean)
        If channel >= 1 AndAlso channel <= 8 Then
            If InvokeRequired Then
                BeginInvoke(Sub() ApplyIoInputToLabel(channel, value))
            Else
                ApplyIoInputToLabel(channel, value)
            End If
        End If
    End Sub

    Private Sub ApplyIoInputToLabel(channel As Integer, value As Boolean)
        Dim txt = If(value, "1", "0")
        If channel >= 1 AndAlso channel <= 16 Then
            PlcValue(3999 + channel) = If(value, 1, 0)
        End If
        Dim chStart = If(_ioSettings Is Nothing, 1, _ioSettings.IoChannelStart())
        Dim chReset = If(_ioSettings Is Nothing, 2, _ioSettings.IoChannelReset())
        Dim chEStop = If(_ioSettings Is Nothing, 3, _ioSettings.IoChannelEStop())
        Dim chAir = If(_ioSettings Is Nothing, 4, _ioSettings.IoChannelAirTool())

        Select Case channel
            Case chStart ' IN0 Start
                IoInStart = value
                lbD4000.Text = txt
                ApplySignalColor(lbD4000, value)
            Case chReset ' IN1 Reset
                IoInReset = value
                lbD4001.Text = txt
                ApplySignalColor(lbD4001, value)
            Case chEStop ' IN2 E-Stop
                IoInEStop = value
                lbD4002.Text = txt
                ApplySignalColor(lbD4002, value)
            Case chAir ' IN3 에어툴
                IoInAirTool = value
                lbD4003.Text = txt
                ApplySignalColor(lbD4003, value)
                HandleAirToolIoEdge(value)
            Case 5
                lbD4004.Text = txt
                ApplySignalColor(lbD4004, value)
            Case 6
                lbD4005.Text = txt
                ApplySignalColor(lbD4005, value)
            Case 7
                lbD4006.Text = txt
                ApplySignalColor(lbD4006, value)
            Case 8
                lbD4007.Text = txt
                ApplySignalColor(lbD4007, value)
        End Select
        If channel = chStart OrElse channel = chReset OrElse channel = chEStop Then
            HandlePanelIoEdge(channel, value, chStart, chReset, chEStop)
        End If
    End Sub

    ''' <summary>리셋 — wStep·reStep 0(스캔대기)으로 복귀</summary>
    Private Sub PerformSequenceReset(reason As String)
        wStep = 0
        rStep = 0
        InitControl()
        srclbAlarm.Visible = False
        _eStopAlarmActive = False
        IoStartPrev = False
        _runLengthAtStep3 = False
        _step3WaitTick = 0
        Try
            FrmColor.Close()
        Catch
        End Try
        UpdateStepTraceLabels()
        WriteTxtMessage("[IO] " & reason & " -> wStep 0, reStep 0")
    End Sub

    ''' <summary>Start(IN0) — wStep 1→2, wStep 3.1→길이 재검사</summary>
    Private Sub HandleStartPress()
        If IoInEStop OrElse _eStopAlarmActive Then Return
        If wStep = 1 Then
            WriteTxtMessage("[IO] Start(IN0) -> wStep 2")
            wStep = 2
        ElseIf wStep = 3.1 Then
            WriteTxtMessage("[IO] Start(IN0) -> 길이 재검사 (wStep 3)")
            wStep = 3
            _runLengthAtStep3 = True
        End If
    End Sub

    ''' <summary>비상 정지 — 시퀀스 정지 후 Reset 안내</summary>
    Private Sub HandleEmergencyStop()
        If wStep <> 0 Then rStep = wStep
        wStep = 0
        IoStartPrev = False
        _runLengthAtStep3 = False
        _step3WaitTick = 0
        Try
            FrmColor.Close()
        Catch
        End Try
        srclbAlarm.Visible = True
        srclbAlarm.Text = "비상 정지 !! E-Stop 해제 후 Reset(IN1)을 눌러주세요"
        LabelTextFitHelper.FitLabelToBounds(srclbAlarm, allowWordBreak:=True)
        If Not _eStopAlarmActive Then
            _eStopAlarmActive = True
            WriteTxtMessage("[IO] 비상 정지 E-Stop — E-Stop 해제 후 Reset(IN1)을 눌러주세요")
        End If
    End Sub

    ''' <summary>패널 I/O: IN0 Start, IN1 Reset, IN2 E-Stop</summary>
    Private Sub ProcessPanelIo()
        If IoInReset AndAlso Not IoResetPrev AndAlso Not IoInEStop Then
            PerformSequenceReset("Reset")
        End If
        IoResetPrev = IoInReset

        If IoInEStop AndAlso Not IoEStopPrev Then
            HandleEmergencyStop()
            IoStartPrev = False
        End If
        IoEStopPrev = IoInEStop
        If IoInEStop Then Return

        If IoInStart AndAlso Not IoStartPrev Then
            HandleStartPress()
        End If
        IoStartPrev = IoInStart
    End Sub

    ''' <summary>IN3 에어툴 상승엣지 — wStep 4에서 Tool 목표 달성 후 Rivet 펄스 카운트</summary>
    Private Sub HandleAirToolIoEdge(value As Boolean)
        If value AndAlso Not IoAirToolPrev Then
            RegisterAirToolPulse()
        End If
        IoAirToolPrev = value
    End Sub

    Private Sub RegisterAirToolPulse()
        If wStep <> 4 Then Return
        If IoInEStop OrElse _eStopAlarmActive Then Return

        If Not IsDecisionComplete(srclbDecTool.Text) AndAlso TargetToolNum > 0 Then
            _ioToolPulseCount += 1
            srclbDataTool.Text = CStr(_ioToolPulseCount)
            WriteTxtMessage("[IO] IN3 에어툴 Tool " & _ioToolPulseCount.ToString() & "/" & TargetToolNum.ToString())
            If _ioToolPulseCount >= TargetToolNum Then
                MarkDecisionOk(srclbDecTool)
            End If
            Return
        End If

        If Not IsDecisionComplete(srclbDecRivet.Text) AndAlso TargetRivetNum > 0 Then
            _ioRivetPulseCount += 1
            srclbDataRivet.Text = CStr(_ioRivetPulseCount)
            WriteTxtMessage("[IO] IN3 에어툴 Rivet " & _ioRivetPulseCount.ToString() & "/" & TargetRivetNum.ToString())
            If _ioRivetPulseCount >= TargetRivetNum Then
                MarkDecisionOk(srclbDecRivet)
            End If
        End If
    End Sub

    ''' <summary>DI 변화 즉시 Start/Reset/E-Stop 처리 (100ms 타이머 누락 방지)</summary>
    Private Sub HandlePanelIoEdge(channel As Integer, value As Boolean, chStart As Integer, chReset As Integer, chEStop As Integer)
        Select Case channel
            Case chStart
                If value AndAlso Not IoStartPrev Then
                    HandleStartPress()
                End If
                IoStartPrev = value
            Case chReset
                If value AndAlso Not IoResetPrev AndAlso Not IoInEStop Then
                    PerformSequenceReset("Reset")
                ElseIf value AndAlso Not IoResetPrev AndAlso IoInEStop Then
                    WriteTxtMessage("[IO] Reset 무시 — E-Stop ON 상태 (E-Stop 해제 후 Reset)")
                End If
                IoResetPrev = value
            Case chEStop
                If value AndAlso Not IoEStopPrev Then
                    HandleEmergencyStop()
                    IoStartPrev = False
                End If
                IoEStopPrev = value
        End Select
    End Sub

    Private Sub LogServerConnectionOnce()
        If _serverConnectionLogged Then Return
        _serverConnectionLogged = True
        Try
            ConnectionOpenSQL()
            If SqlConnect IsNot Nothing AndAlso SqlConnect.State = ADODB.ObjectStateEnum.adStateOpen Then
                WriteTxtMessage("[SQL] 서버 연결 OK — 192.168.0.222\Ftech_Svr")
            Else
                WriteTxtMessage("[SQL] 서버 연결 실패 — 로컬 MDB 비상본 사용")
            End If
        Catch ex As Exception
            WriteTxtMessage("[SQL] 서버 연결 실패: " & ex.Message)
        Finally
            ConnectionCloseSQL()
        End Try
    End Sub

    ''' <summary>PopV4 스타일 신호 표시: ON=Blue, OFF=DarkRed</summary>
    Private Sub ApplySignalColor(target As Label, isOn As Boolean)
        target.ForeColor = Color.White
        target.BackColor = If(isOn, Color.DarkBlue, Color.DarkRed)
    End Sub

    Private Sub RefreshPlcSignalIndicators()
        ApplySignalColor(lbD4000, PlcValue(4000) <> 0)
        ApplySignalColor(lbD4001, PlcValue(4001) <> 0)
        ApplySignalColor(lbD4002, PlcValue(4002) <> 0)
        ApplySignalColor(lbD4003, PlcValue(4003) <> 0)
        ApplySignalColor(lbD4004, PlcValue(4004) <> 0)
        ApplySignalColor(lbD4005, PlcValue(4005) <> 0)
        ApplySignalColor(lbD4006, PlcValue(4006) <> 0)
        ApplySignalColor(lbD4007, PlcValue(4007) <> 0)
        ApplySignalColor(lbD4008, PlcValue(4008) <> 0)
        ApplySignalColor(lbD4009, PlcValue(4009) <> 0)

        ApplySignalColor(lbD4050, PlcValue(4050) <> 0)
        ApplySignalColor(lbD4051, PlcValue(4051) <> 0)
        ApplySignalColor(lbD4052, PlcValue(4052) <> 0)
        ApplySignalColor(lbD4053, PlcValue(4053) <> 0)
        ApplySignalColor(lbD4054, PlcValue(4054) <> 0)
        ApplySignalColor(lbD4055, PlcValue(4055) <> 0)
        ApplySignalColor(lbD4056, PlcValue(4056) <> 0)
        ApplySignalColor(lbD4057, PlcValue(4057) <> 0)
        ApplySignalColor(lbD4058, PlcValue(4058) <> 0)
        ApplySignalColor(lbD4059, PlcValue(4059) <> 0)
    End Sub

    Private Sub RefreshIoDiagnosticUi()
        If MmIo Is Nothing OrElse Not MmIo.IsConnected Then Return
        For ch As Integer = 1 To 8
            ApplyIoInputToLabel(ch, MmIo.GetDigitalInput(ch))
        Next
    End Sub

    Private Sub CheckIoHealth()
        _ioDiagTick += 1
        If _ioDiagTick Mod 30 <> 0 Then Return

        If MmIo IsNot Nothing AndAlso MmIo.IsConnected Then
            Dim age = (DateTime.UtcNow - MmIo.LastFrameUtc).TotalSeconds
            If MmIo.LastFrameUtc = DateTime.MinValue OrElse age > 2.0 Then
                WriteTxtMessage("[IO-COM] 프레임 없음 " & age.ToString("0.0") & "s — 배선/펌웨어 확인")
            ElseIf Not _ioComOkLogged Then
                Dim di = ""
                For i As Integer = 1 To 8
                    di &= If(MmIo.GetDigitalInput(i), "1", "0")
                Next
                _ioComOkLogged = True
                WriteTxtMessage("[IO-COM] OK frames=" & MmIo.FramesReceived & " DI[1-8]=" & di &
                                " AI1=" & MmIo.GetAnalogRaw(1))
            End If
        End If

        If _fbeiOk AndAlso Ios IsNot Nothing Then
            Try
                If Not _fbeiOkLogged Then
                    Dim b1 = Ios.GetInput(1)
                    _fbeiOkLogged = True
                    WriteTxtMessage("[FBEI] OK DI1=" & If(b1, "1", "0"))
                End If
            Catch ex As Exception
                WriteTxtMessage("[FBEI] 읽기 실패: " & ex.Message)
                _fbeiOk = False
                _fbeiOkLogged = False
            End Try
        End If
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        If Not LoadPortData() Then
            WriteTxtMessage("[DB] LoadPortData FAIL: " & LastMdbError & " | " & MdbFilePath())
        End If
        If Not LoadBarcodeData() Then
            WriteTxtMessage("[DB] LoadBarcodeData FAIL: " & LastMdbError & " | " & MdbFilePath())
        End If
        If Not LoadBasicData() Then
            WriteTxtMessage("[DB] LoadBasicData FAIL: " & LastMdbError & " | " & MdbFilePath())
        End If
        LogServerConnectionOnce()
        LogSoundFolderOnce()
        Dim partLocalReady = EnsurePartLocalTable()
        If partLocalReady Then
            WriteTxtMessage("[DB] EnsurePartLocalTable OK: " & MdbFilePath())
        Else
            WriteTxtMessage("[DB] EnsurePartLocalTable FAIL: " & MdbFilePath() & " | " & LastMdbError)
        End If

        If Not String.IsNullOrEmpty(LastMdbError) Then
            WriteTxtMessage("[DB] " & LastMdbError & " — DB\DB.mdb를 exe와 같은 폴더에 복사하세요.")
        End If

        InitializeElcoDevices()

        InitControl()

        WriteTxtMessage("Init Complete")
        WriteTxtMessage("[PORT] Scanner=" & PortNumber_Scanner & " Laser=" & PortNumber_Laser &
                        " Io=" & PortNumber_Io & " Printer=" & PortNumber_Printer)
        SerialOpen()
        StartLaserAfterSerialOpen()

        Timer1.Interval = 100
        Timer1.Start()

        WriteTxtMessage("System Ready..")

        Label11.Text = "192.168.0.222\Ftech_Svr"
        srcLbPlcConnectionState.Text = "I/O 모드"
        srcLbPlcConnectionState.BackColor = Color.DarkSlateGray
        srcLbPlcConnectionState.ForeColor = Color.White

        Tmr_Connect.Interval = 100
        Tmr_Connect.Start()

        wStep = 0

        Tmr_Work.Interval = 100
        Tmr_Work.Start()

        FrmWorkStandard.WindowState = FormWindowState.Normal
        FrmWorkStandard.Location = New Point(-2000, 0)
        FrmWorkStandard.WindowState = FormWindowState.Maximized
        FrmWorkStandard.Show()

        InitGrid()
        LoadGrid()
        FitDynamicLabels()

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

    Private Sub PartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartToolStripMenuItem.Click
        FrmPart.Show()
    End Sub

    Private Sub IoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IoToolStripMenuItem.Click
        Using frm As New FrmIo(Me)
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        If Lasers IsNot Nothing Then Lasers.Dispose()
        If MmIo IsNot Nothing Then
            RemoveHandler MmIo.LogMessage, AddressOf MmIo_LogMessage
            RemoveHandler MmIo.DigitalInputChanged, AddressOf MmIo_DigitalInputChanged
            MmIo.Dispose()
        End If
        If Ios IsNot Nothing Then Ios.Dispose()
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
        CheckIoHealth()
    End Sub

    Private Sub Tmr_Work_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Work.Tick

        srclbStep.Text = wStep
        UpdateStepTraceLabels()

        ProcessPanelIo()

        If IoInEStop OrElse _eStopAlarmActive Then Return

        If wStep = 0 Then
            ' 스캔 대기 — Serial_Scanner_DataReceived 에서 처리

        ElseIf wStep = 0.1 Then

            srclbAlarm.Visible = True
            srclbAlarm.Text = "이전공정을 확인해주세요 !!"
            NG()
            wStep = 0

        ElseIf wStep = 1 Then
            ' Start(IN0) 대기 — ProcessPanelIo 에서 wStep 2 로 전환

        ElseIf wStep = 2 Then

            srclbAlarm.Visible = False
            srclbTargetTool.Text = CStr(TargetToolNum)
            srclbTargetRivet.Text = CStr(TargetRivetNum)
            LoadPicture(srcPictureBox2, Mid(srcLbPartNo.Text, 12, 3))
            FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, Mid(srcLbPartNo.Text, 1, 11))
            wStep = 2.1

        ElseIf wStep = 2.1 Then

            wStep = 3
            _runLengthAtStep3 = True
            _step3WaitTick = 0

        ElseIf wStep = 3 Then 'Check

            LogLaserValuesAtStep3()

            If _runLengthAtStep3 Then
                _runLengthAtStep3 = False
                If Not _laserHasData Then
                    WriteTxtMessage("[KeyenceIL] wStep3 — 레이저 수신 없음. COM/배선/DL-RS1A R스위치 확인")
                End If
                RunLengthTestStep3()
            End If

        ElseIf wStep = 3.1 Then
            ' 길이 NG — Start(IN0) 재검사 대기

        ElseIf wStep = 4 Then

            ApplyPartSkipDecisions()

            If Not IsDecisionComplete(srclbDecTool.Text) AndAlso TargetToolNum > 0 Then
                srclbDataTool.Text = CStr(_ioToolPulseCount)
            End If
            If Not IsDecisionComplete(srclbDecRivet.Text) AndAlso TargetRivetNum > 0 Then
                srclbDataRivet.Text = CStr(_ioRivetPulseCount)
            End If

            If IsDecisionComplete(srclbDecTool.Text) AndAlso IsDecisionComplete(srclbDecRivet.Text) AndAlso
               IsDecisionComplete(srclbDecCoverL.Text) AndAlso IsDecisionComplete(srclbDecCoverR.Text) Then
                wStep = 5
            End If

        ElseIf wStep = 5 Then

            wStep = 6

        ElseIf wStep = 6 Then

            DingDOng()
            WriteTxtMessage("[SEQ] 작업 완료")
            LoadSabBarcode(srcLbSerial.Text)
            BarcodePrint(srcLbSerial.Text, srcLbPartNo.Text)
            SaveDB(srcLbSerial.Text)
            AddGrid(srcLbPartNo.Text)
            InitGrid()
            LoadGrid()
            InitControl()
            FrmColor.Close()
            wStep = 0

        End If

    End Sub

    Private Sub InitGrid()
        ' FlexCell → DataGridView 변환
        With GridCount
            .Rows.Clear()
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .RowHeadersVisible = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False

            .ColumnCount = 3
            .Columns(0).Visible = False    ' FlexCell 인덱스 열 숨김

            For i As Integer = 1 To 2
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            .Columns(1).Width = 230
            .Columns(2).Width = 190

            ' 컬럼 헤더 텍스트 (FlexCell의 Cell(0,x) 고정 행 역할)
            .Columns(1).HeaderText = "품번"
            .Columns(2).HeaderText = "생산수량"

            .Refresh()
        End With

    End Sub


    Private Sub LoadGrid()

        If Not ConnectionOpenMDB() Then Exit Sub

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Try
            Rs.Open("SELECT JObPartNo,JobCount FROM Table_Count ORDER BY LEN(JobPartNo),JobPartNo", MdbConnect)
        Catch ex As Exception
            ConnectionCloseMDB()
            Exit Sub
        End Try

        If Rs.RecordCount = 0 Then
        ElseIf Rs.RecordCount >= 1 Then

            Rs.MoveFirst()

            If Rs.BOF = True Or Rs.EOF = True Then
            Else
                Do Until Rs.EOF

                    ' FlexCell AddItem → DataGridView Rows.Add (FlexCell은 1-base, DGV는 0-base)
                    GridCount.Rows.Add("", Rs.Fields("JobPartNo").Value, Rs.Fields("JobCount").Value)
                    Rs.MoveNext()
                Loop
            End If

            Rs.ActiveConnection = Nothing
            Rs.Close()

        End If

        ConnectionCloseMDB()

    End Sub

    Private Sub ResetGrid()

        If Not ConnectionOpenMDB() Then Exit Sub
        Dim strSQL As String = "DELETE * FROM TABLE_COUNT"
        Try
            MdbConnect.Execute(strSQL)
        Catch ex As Exception
        End Try
        ConnectionCloseMDB()

    End Sub

    Private Sub AddGrid(ByVal strPart As String)

        If Not ConnectionOpenMDB() Then Exit Sub

        Dim Rs As New ADODB.Recordset
        Dim TmpInt As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Try
            Rs.Open("SELECT * FROM Table_Count WHERE JobPartNo = '" & strPart & "'", MdbConnect)
        Catch ex As Exception
            ConnectionCloseMDB()
            Exit Sub
        End Try

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

    Private Sub Serial_Scanner_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Serial_Scanner.DataReceived

        Dim Incoming As String
        Dim ScanData As String

        Try
            Incoming = ReadScannerPayload()
            ScanData = NormalizeScanText(Incoming)
            Serial_Scanner.DiscardInBuffer()

            If String.IsNullOrEmpty(ScanData) Then
                WriteTxtMessage("[SCAN] empty payload (COM=" & PortNumber_Scanner & ", check wiring/baud/CR)")
                Return
            End If

            WriteTxtMessage("ScanData : " & ScanData & " | wStep=" & wStep.ToString() & " Len=" & Len(ScanData).ToString())

            If wStep = 0 Then

                If Len(ScanData) >= 23 Then

                    StartTIme = Format(Now, "HH:mm:ss")
                    If FlagBeforeCheck = True Then
                        srcLbSerial.Text = ScanData
                        LoadBasicData()
                        If Not LoadPArt(ScanData) Then
                            NG()
                            srclbAlarm.Visible = True
                            srclbAlarm.Text = "품번 조회 실패 !! 다시 스캔하세요"
                            wStep = 0
                            WriteTxtMessage("[SCAN] Part 조회 실패 — wStep 0 유지 (재스캔 대기)")
                        Else
                            CheckBefore(srcLbSerial.Text)
                            If srcLbPartName.Text.Contains("VIP") = True Then
                            Else
                                srcLbCheckVip.Text = "NA"
                                srcLbCheckVip.BackColor = Color.Green
                            End If

                            If srcLbCheck1.Text = "OK" And srcLbCheck2_1.Text = "OK" And srcLbCheck2_2.Text = "OK" And
                                (srcLbCheckVip.Text = "OK" Or srcLbCheckVip.Text = "NA") And srcLbCheckNoiseTest.Text = "OK" Then
                                srclbAlarm.Visible = False
                                wStep = 1
                                WriteTxtMessage("[SCAN] OK -> wStep 1 (Start 대기)")
                            Else
                                wStep = 0.1
                                WriteTxtMessage("[SCAN] before-check NG -> wStep 0.1")
                            End If
                        End If

                    Else

                        srcLbSerial.Text = ScanData
                        If LoadPArt(ScanData) Then
                            srclbAlarm.Visible = False
                            wStep = 1
                            WriteTxtMessage("[SCAN] OK -> wStep 1 (Start 대기)")
                        Else
                            NG()
                            srclbAlarm.Visible = True
                            srclbAlarm.Text = "품번 조회 실패 !! 다시 스캔하세요"
                            wStep = 0
                            WriteTxtMessage("[SCAN] Part 조회 실패 — wStep 0 유지 (재스캔 대기)")
                        End If
                    End If

                Else
                    WriteTxtMessage("[SCAN] ignored: Len<23 (need full serial barcode, not part-only label)")
                End If

            ElseIf wStep >= 2 Then

                Dim coverLNeedsScan = (srclbDecCoverL.Text <> "PASS" AndAlso srclbTargetCoverL.Text <> "0")
                Dim coverRNeedsScan = (srclbDecCoverR.Text <> "PASS" AndAlso srclbTargetCoverR.Text <> "0")

                If coverLNeedsScan AndAlso InStr(1, ScanData, srclbTargetCoverL.Text) <> 0 Then
                    srclbDataCoverL.Text = ScanData
                    MarkDecisionOk(srclbDecCoverL)
                ElseIf coverRNeedsScan AndAlso InStr(1, ScanData, srclbTargetCoverR.Text) <> 0 Then
                    srclbDataCoverR.Text = ScanData
                    MarkDecisionOk(srclbDecCoverR)
                ElseIf Not coverLNeedsScan AndAlso Not coverRNeedsScan Then
                    WriteTxtMessage("[SCAN] cover PASS — 스캔 불필요, 무시")
                Else
                    NG()
                    WriteTxtMessage("[SCAN] cover NG at wStep=" & wStep.ToString())
                End If

            Else
                WriteTxtMessage("[SCAN] ignored: wStep=" & wStep.ToString() & " (wStep 0=스캔대기)")
            End If

        Catch ex As Exception
            WriteTxtMessage("[SCAN] ERROR: " & ex.Message)
            NG()
        End Try

    End Sub

    Private Sub tmr_Tool_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_Tool.Tick

        If Tool_Connection1 = False Then
            Tool_Connection1 = True
            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "002099990010" & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr("0") & Chr("3"))
        ElseIf Tool_Connection1 = True Then
            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3") &
            Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
        End If

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        'SaveDB()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ResetGrid()
        InitGrid()
        LoadGrid()
    End Sub

    Private Sub CheckBefore(ByVal str As String)

        ConnectionOpenSQL()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Main WHERE SerialNo = '" & str & "'", SqlConnect)

        If Rs.RecordCount = 1 Then

            Try
                If Rs.Fields("Op01_Decision").Value = "OK" Then
                    srcLbCheck1.Text = "OK"
                    srcLbCheck1.BackColor = Color.Blue
                Else
                    srcLbCheck1.Text = "NG"
                    srcLbCheck1.BackColor = Color.Red
                End If
            Catch ex As Exception
                srcLbCheck1.Text = "NG"
                srcLbCheck1.BackColor = Color.Red
            End Try

            Try
                If Rs.Fields("Op02_1_Decision").Value = "OK" Then
                    srcLbCheck2_1.Text = "OK"
                    srcLbCheck2_1.BackColor = Color.Blue
                Else
                    srcLbCheck2_1.Text = "NG"
                    srcLbCheck2_1.BackColor = Color.Red
                End If
            Catch ex As Exception
                srcLbCheck2_1.Text = "NG"
                srcLbCheck2_1.BackColor = Color.Red
            End Try

            Try
                If Rs.Fields("Op02_2_Decision").Value = "OK" Then
                    srcLbCheck2_2.Text = "OK"
                    srcLbCheck2_2.BackColor = Color.Blue
                Else
                    srcLbCheck2_2.Text = "NG"
                    srcLbCheck2_2.BackColor = Color.Red
                End If
            Catch ex As Exception
                srcLbCheck2_2.Text = "NG"
                srcLbCheck2_2.BackColor = Color.Red
            End Try

            Try
                If Rs.Fields("OpVip_Decision").Value = "OK" Then
                    srcLbCheckVip.Text = "OK"
                    srcLbCheckVip.BackColor = Color.Blue
                Else
                    srcLbCheckVip.Text = "NG"
                    srcLbCheckVip.BackColor = Color.Red
                End If
            Catch ex As Exception
                srcLbCheckVip.Text = "NG"
                srcLbCheckVip.BackColor = Color.Red
            End Try

            Try
                If Rs.Fields("OpTest_Decision").Value = "OK" Then
                    srcLbCheckNoiseTest.Text = "OK"
                    srcLbCheckNoiseTest.BackColor = Color.Blue
                Else
                    srcLbCheckNoiseTest.Text = "NG"
                    srcLbCheckNoiseTest.BackColor = Color.Red
                End If
            Catch ex As Exception
                srcLbCheckNoiseTest.Text = "NG"
                srcLbCheckNoiseTest.BackColor = Color.Red
            End Try


        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

        'ConvertColor(srcLbCheck1, srcLbCheck1.Text)
        'ConvertColor(srcLbCheck2_1, srcLbCheck2_1.Text)
        'ConvertColor(srcLbCheck2_2, srcLbCheck2_2.Text)
        'ConvertColor(srcLbCheckVip, srcLbCheckVip.Text)
        'ConvertColor(srcLbCheckNoiseTest, srcLbCheckNoiseTest.Text)

    End Sub

    Private Sub srcPictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles srcPictureBox2.Click
        Panel2.Visible = False
    End Sub

    Private Sub LoadSabBarcode(ByVal str As String)

        ConnectionOpenSQL()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Main WHERE SerialNo = '" & str & "'", SqlConnect)

        If Rs.RecordCount = 1 Then

            Try
                TmpSab1BArcode = Trim(Rs.Fields("Op02_2_Sab1Barcode").Value)
            Catch ex As Exception
                TmpSab1BArcode = ""
            End Try

            Try
                tmpSab2Barcode = Trim(Rs.Fields("Op02_2_Sab2Barcode").Value)
            Catch ex As Exception
                tmpSab2Barcode = ""
            End Try

            Try
                TmpLsuptBArcode = Trim(Rs.Fields("Op02_1_LsuptBarcode").Value)
            Catch ex As Exception
                TmpLsuptBArcode = ""
            End Try

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

        'ConvertColor(srcLbCheck1, srcLbCheck1.Text)
        'ConvertColor(srcLbCheck2_1, srcLbCheck2_1.Text)
        'ConvertColor(srcLbCheck2_2, srcLbCheck2_2.Text)
        'ConvertColor(srcLbCheckVip, srcLbCheckVip.Text)
        'ConvertColor(srcLbCheckNoiseTest, srcLbCheckNoiseTest.Text)

    End Sub

    Private Sub Label28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label28.Click
        LoadSabBarcode(srcLbSerial.Text)
        BarcodePrint(srcLbSerial.Text, srcLbPartNo.Text)
    End Sub

    Private Sub srcLbCheckNoiseTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles srcLbCheckNoiseTest.Click
        LoadSabBarcode(srcLbSerial.Text)
        BarcodePrint(srcLbSerial.Text, srcLbPartNo.Text)
    End Sub

End Class