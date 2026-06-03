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
'Imports AxCWUIControlsLib  ' CWUIControlsLib COM 미등록 — 미사용 필드라 주석 처리

Public Class FrmMain

    ' ActPlc 동적 생성 (디자이너 의존 제거)
    Private WithEvents ActPlc As AxACTETHERLib.AxActQNUDECPUTCP

    ' DAQ 직접 Task 생성 (DaqTask2Component → CONVERSION_RULES NoiseTest 패턴)
    Private myDaqTask As NationalInstruments.DAQmx.Task
    Private myDaqRunningTask As NationalInstruments.DAQmx.Task
    Private myDaqReader As NationalInstruments.DAQmx.AnalogMultiChannelReader
    Private myDaqCallback As AsyncCallback

    Private EndBarcodeData As String
    Private TmpLsuptBArcode As String
    Private TmpSab1BArcode As String
    Private tmpSab2Barcode As String

    Private ValueLsrLeftUpper As Double
    Private ValueLsrLeftLower As Double
    Private ValueLsrRightUpper As Double
    Private ValueLsrRightLower As Double

    Private DataLaser1() As Double
    Private DataLaser2() As Double
    Private DataLaser3() As Double
    Private DataLaser4() As Double

    Private SumLaser1 As Double
    Private SumLaser2 As Double
    Private SumLaser3 As Double
    Private SumLaser4 As Double

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
    Private PcAliveCount As Integer

    Public D_Value(0 To 48) As Integer
    'Public IN_LABEL(48) As AxCWUIControlsLib.AxCWButton  ' 미사용 — CWUIControlsLib COM 제거로 주석 처리
    'Public OUT_LABEL(24) As AxCWUIControlsLib.AxCWButton

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

        Try
            If Serial_Tool.IsOpen() = True Then
                Serial_Tool.Close()
            End If
            Serial_Tool.PortName = PortNumber_Tool
            Serial_Tool.BaudRate = 9600
            Serial_Tool.DataBits = 8
            Serial_Tool.Open()
            WriteTxtMessage("Serial Printer Open Success" & PortNumber_Tool)
            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3"))
            Serial_Tool.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
            tmr_Tool.Interval = 5000
            tmr_Tool.Start()

        Catch ex As Exception
            WriteTxtMessage("Serial Printer Open Fail")
        End Try

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

    Private Sub LoadPArt(ByVal str As String)

        ConnectionOpenSQL()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part WHERE PartNo = '" & Mid(str, 13, 11) & "'", SqlConnect)

        If Rs.RecordCount = 1 Then

            srcLbPartNo.Text = Mid(str, 13, 14)
            srcLbPartName.Text = Trim(Rs.Fields("PartName").Value)
            LoadPicture(srcPictureBox, Mid(srcLbPartNo.Text, 1, 11))

            OptionLHRH = Trim(Rs.Fields("OptionLHRH").Value)
            OptionType = Trim(Rs.Fields("OptionType").Value)
            OptionBack = Trim(Rs.Fields("OptionBack").Value)
            OptionFootRest = Rs.Fields("OptionFootRest").Value
            OptionMonitor = Rs.Fields("OptionMon").Value

            srcLbPartOption.Text = OptionType & " " & OptionLHRH
            'TargetMotorBarcode = Trim(Rs.Fields("Target_Op01_MotorBarcode").Value)
            TargetToolNum = CInt(Trim(Rs.Fields("Target_Op04_ToolNum").Value))
            TargetRivetNum = CInt(Trim(Rs.Fields("Target_Op04_RivetNum").Value))
            srclbTargetTool.Text = CStr(TargetToolNum)


            If Trim(Rs.Fields("Target_Op03_InsideCoverL").Value) = "0" Then
                srclbTargetCoverL.Text = "0"
                srclbDecCoverL.Text = "NA"
                srclbDecCoverL.BackColor = Color.Green
            Else
                srclbTargetCoverL.Text = Trim(Rs.Fields("Target_Op03_InsideCoverL").Value) & Microsoft.VisualBasic.Right(srcLbPartNo.Text, 3)
            End If

            If Trim(Rs.Fields("Target_Op03_InsideCoverR").Value) = "0" Then
                srclbTargetCoverR.Text = "0"
                srclbDecCoverR.Text = "NA"
                srclbDecCoverR.BackColor = Color.Green
            Else
                srclbTargetCoverR.Text = Trim(Rs.Fields("Target_Op03_InsideCoverR").Value) & Microsoft.VisualBasic.Right(srcLbPartNo.Text, 3)
            End If

            If OptionType = "VIP" Then
                srclbSpecLengthTest.Text = BAsicFrtMin_VIPRH & " ~ " & BAsicFrtMax_VIPRH
            ElseIf OptionType = "STD" Then
                srclbSpecLengthTest.Text = BAsicFrtMin_STDLH & " ~ " & BAsicFrtMax_STDLH
            ElseIf OptionType = "FOLD" Then
                srclbSpecLengthTest.Text = BAsicFrtMin_FOLDRH & " ~ " & BAsicFrtMax_FOLDRH
            End If

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

    ''' <summary>ActPlc COM 컨트롤 동적 생성 (디자이너 의존 제거)</summary>
    Private Sub InitializeActPlc()
        ActPlc = New AxACTETHERLib.AxActQNUDECPUTCP()
        CType(ActPlc, System.ComponentModel.ISupportInitialize).BeginInit()
        ActPlc.Visible = False
        Me.Controls.Add(ActPlc)
        CType(ActPlc, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub

    ''' <summary>DAQ Task 초기화 (DaqTask2Component 제거 → 직접 Task 생성)</summary>
    Private Sub InitializeDaqTask()
        If myDaqRunningTask IsNot Nothing Then Exit Sub
        Try
            myDaqTask = New NationalInstruments.DAQmx.Task()
            ' DaqTask2.vb Configure() 채널 구성 그대로 이식
            myDaqTask.AIChannels.CreateVoltageChannel("Dev3/ai0", "Laser1",
                NationalInstruments.DAQmx.AITerminalConfiguration.Rse, 0, 5,
                NationalInstruments.DAQmx.AIVoltageUnits.Volts)
            myDaqTask.AIChannels.CreateVoltageChannel("Dev3/ai1", "Laser2",
                NationalInstruments.DAQmx.AITerminalConfiguration.Rse, 0, 5,
                NationalInstruments.DAQmx.AIVoltageUnits.Volts)
            myDaqTask.AIChannels.CreateVoltageChannel("Dev3/ai2", "Laser3",
                NationalInstruments.DAQmx.AITerminalConfiguration.Rse, 0, 5,
                NationalInstruments.DAQmx.AIVoltageUnits.Volts)
            myDaqTask.AIChannels.CreateVoltageChannel("Dev3/ai3", "Laser4",
                NationalInstruments.DAQmx.AITerminalConfiguration.Rse, 0, 5,
                NationalInstruments.DAQmx.AIVoltageUnits.Volts)
            myDaqTask.Timing.ConfigureSampleClock("", 1000,
                NationalInstruments.DAQmx.SampleClockActiveEdge.Rising,
                NationalInstruments.DAQmx.SampleQuantityMode.ContinuousSamples, 100)
            myDaqTask.Control(NationalInstruments.DAQmx.TaskAction.Verify)
            myDaqRunningTask = myDaqTask

            myDaqReader = New NationalInstruments.DAQmx.AnalogMultiChannelReader(myDaqTask.Stream)
            myDaqReader.SynchronizeCallbacks = True
            myDaqCallback = New AsyncCallback(AddressOf DaqAnalogInCallback)
            myDaqReader.BeginReadWaveform(100, myDaqCallback, myDaqTask)
        Catch ex As NationalInstruments.DAQmx.DaqException
            WriteTxtMessage("[DAQ] 초기화 실패: " & ex.Message)
            myDaqRunningTask = Nothing
        End Try
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializeActPlc()
        InitializeDaqTask()

        CheckForIllegalCrossThreadCalls = False

        LoadPortData()
        LoadBarcodeData()
        LoadBasicData()

        InitControl()

        WriteTxtMessage("Init Complete")
        SerialOpen()

        Timer1.Interval = 100
        Timer1.Start()

        WriteTxtMessage("System Ready..")

        ActPlc.ActTimeOut = 500
        AddressOfPLc = "192.168.0.120"
        Label11.Text = AddressOfPLc
        FlagPlcConnection = False

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

        DaqStart()

    End Sub

    Private Sub ConnectPLc()

        ActPlc.ActCpuType = 209

        ActPlc.ActHostAddress = AddressOfPLc
        If ActPlc.Open <> 0 Then
            FlagPlcConnection = False
        Else
            FlagPlcConnection = True
        End If

    End Sub

    Private Sub WritePlc(ByVal strChr As String, ByVal StartArry As String, ByVal ArryMessage As String)

        Dim iReturnCode As Integer              'Return code
        Dim szDeviceName As String = ""         'List data for 'DeviceName'
        Dim sharrDeviceValue() As Short          'Data for 'DeviceValue'

        If srcLbPlcConnectionState.Text = "OK" Then

            ReDim sharrDeviceValue(Len(ArryMessage))

            For i As Integer = 0 To Len(ArryMessage) - 1
                szDeviceName = szDeviceName & strChr & Format((Int(StartArry) + i), "0000")
                'If i <> Len(ArryMessage - 1) Then szDeviceName = szDeviceName + ControlChars.Lf
                If i < Len(ArryMessage) - 1 Then szDeviceName = szDeviceName & ControlChars.Lf
                sharrDeviceValue(i) = Mid(ArryMessage, i + 1, 1)
            Next
            Try
                iReturnCode = ActPlc.WriteDeviceRandom2(szDeviceName, Len(ArryMessage), sharrDeviceValue(0))
            Catch exception As Exception
                'Exception processing
                'MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                FlagPlcConnection = False
                Exit Sub
            End Try

        End If

        'The return code of the method Is displayed by the hexadecimal.
        'txt_ReturnCode.Text = String.Format("0x{0:x8} [HEX]", iReturnCode)

    End Sub

    Private Sub ReadPLc()

        Dim tmpPlcValue(200) As Integer
        Dim i As Integer
        Dim j As Integer
        Dim iReturnCode As Integer              'Return code
        Dim szDeviceName As String = ""         'List data for 'DeviceName'
        Dim iNumberOfDeviceName As Integer = 0  'Data for 'DeviceSize'
        Dim sharrDeviceValue() As Short         'Data for 'DeviceValue'
        Dim szarrData() As String               'Array for 'Data'
        Dim iNumber As Integer                  'Loop counter
        Dim Arrysize As Integer = 20

        ReDim sharrDeviceValue(Arrysize - 1)
        ReDim szarrData(Arrysize - 1)

        szDeviceName = "D4000" & vbLf & "D4001" & vbLf & "D4002" & vbLf & "D4003" & vbLf & "D4004" & vbLf & "D4005" & vbLf & "D4006" & vbLf & "D4007" & vbLf & "D4008" & vbLf & "D4009" & vbLf &
                       "D4050" & vbLf & "D4051" & vbLf & "D4052" & vbLf & "D4053" & vbLf & "D4054" & vbLf & "D4055" & vbLf & "D4056" & vbLf & "D4057" & vbLf & "D4058" & vbLf & "D4059"
        Try
            iReturnCode = ActPlc.ReadDeviceRandom2(szDeviceName, Arrysize, sharrDeviceValue(0))
        Catch exException As Exception
            'Exception processing
            MessageBox.Show(exException.Message, Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'When the ReadDeviceRandom2 method is succeeded, display the read data.
        If iReturnCode = 0 Then

            'Copy the read data to the 'lpszarrData'.
            For iNumber = 0 To iNumberOfDeviceName - 1
                szarrData(iNumber) = sharrDeviceValue(iNumber).ToString()
            Next iNumber
            For i = 0 To Arrysize - 1
                tmpPlcValue(i) = CInt(sharrDeviceValue(i))
            Next i

            For i = 0 To 9
                PlcValue(i + 4000) = tmpPlcValue(i)
            Next
            For i = 10 To 19
                PlcValue(i + 4040) = tmpPlcValue(i)
            Next

            lbD4000.Text = PlcValue(4000)
            lbD4001.Text = PlcValue(4001)
            lbD4002.Text = PlcValue(4002)
            lbD4003.Text = PlcValue(4003)
            lbD4004.Text = PlcValue(4004)
            lbD4005.Text = PlcValue(4005)
            lbD4006.Text = PlcValue(4006)
            lbD4007.Text = PlcValue(4007)
            lbD4008.Text = PlcValue(4008)
            lbD4009.Text = PlcValue(4009)

            lbD4050.Text = PlcValue(4050)
            lbD4051.Text = PlcValue(4051)
            lbD4052.Text = PlcValue(4052)
            lbD4053.Text = PlcValue(4053)
            lbD4054.Text = PlcValue(4054)
            lbD4055.Text = PlcValue(4055)
            lbD4056.Text = PlcValue(4056)
            lbD4057.Text = PlcValue(4057)
            lbD4058.Text = PlcValue(4058)
            lbD4059.Text = PlcValue(4059)

            PlcConnectionError = "OK"

        Else

            PlcConnectionError = Dec2Hex(iReturnCode)

        End If

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

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        DaqEnd()
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
                    ActPlc.Close()
                    PlcConnectionStep = 0
                End If
            End If
        End If
    End Sub

    Private Sub Tmr_Work_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Work.Tick

        srclbStep.Text = wStep

        PCAliveCount = PCAliveCount + 1
        If PcAliveCount = 10 Then
            WritePlc("D", "4050", "1")
        ElseIf PcAliveCount = 20 Then
            WritePlc("D", "4050", "0")
            PcAliveCount = 0
        End If

        If PlcValue(4000) = 0 And wStep <> 0 Then
            wStep = 0
            WritePlc("D", "4051", "0000000000")
            InitControl()
            Try
                FrmColor.Close()
            Catch ex As Exception
            End Try
        End If

        If wStep = 0 Then

            If PlcValue(4000) = 1 Then
                WritePlc("D", "4051", "0000000000")
                InitControl()
                wStep = 1
            End If

        ElseIf wStep = 1 Then '스캔대기

        ElseIf wStep = 1.1 Then

            srclbAlarm.Visible = True
            srclbAlarm.Text = "이전공정을 확인해주세요 !!"
            NG()
            wStep = 1

        ElseIf wStep = 2 Then

            srclbAlarm.Visible = False
            srclbTargetTool.Text = CStr(TargetToolNum)
            srclbTargetRivet.Text = CStr(TargetRivetNum)
            LoadPicture(srcPictureBox2, Mid(srcLbPartNo.Text, 12, 3))
            FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, Mid(srcLbPartNo.Text, 1, 11))
            wStep = 2.1

        ElseIf wStep = 2.1 Then 'Send PLC Option

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
            wStep = 3

        ElseIf wStep = 3 Then 'Check

            If PlcValue(4004) = 1 Then

                If OptionType = "VIP" Then

                    srclbDataLengthTestFrt.Text = Format(basicFrtTolVIP - ValueLsrLeftUpper - ValueLsrRightUpper, "0.0#")
                    srclbDataLengthTestRear.Text = Format(BasicRearTolVIP - ValueLsrLeftLower - ValueLsrRightLower, "0.0#")

                    Dim tmp1 As Double = (BAsicFrtMax_VIPRH - BAsicFrtMin_VIPRH)
                    Dim tmp2 As Double = (BAsicRearMax_VIPRH - BAsicRearMin_VIPRH)

                    tmp1 = 0
                    tmp2 = 0

                    If CDbl(srclbDataLengthTestFrt.Text) >= (BAsicFrtMin_VIPRH - tmp1) And CDbl(srclbDataLengthTestFrt.Text) <= (BAsicFrtMax_VIPRH + tmp1) Then
                        srclbDecLengthTestFrt.Text = "OK"
                        srclbDecLengthTestFrt.BackColor = Color.Blue
                    Else
                        srclbDecLengthTestFrt.Text = "NG"
                        srclbDecLengthTestFrt.BackColor = Color.Red
                    End If
                    If CDbl(srclbDataLengthTestRear.Text) >= (BAsicRearMin_VIPRH - tmp2) And CDbl(srclbDataLengthTestRear.Text) <= (BAsicRearMax_VIPRH + tmp2) Then
                        srclbDecLengthTestRear.Text = "OK"
                        srclbDecLengthTestRear.BackColor = Color.Blue
                    Else
                        srclbDecLengthTestRear.Text = "NG"
                        srclbDecLengthTestRear.BackColor = Color.Red
                    End If

                ElseIf OptionType = "STD" Then

                    srclbDataLengthTestFrt.Text = Format(basicFrtTolSTD - ValueLsrLeftUpper - ValueLsrRightUpper, "0.0#")
                    srclbDataLengthTestRear.Text = Format(BasicRearTolSTD - ValueLsrLeftLower - ValueLsrRightLower, "0.0#")

                    Dim tmp1 As Double = (BAsicFrtMax_STDLH - BAsicFrtMin_STDLH)
                    Dim tmp2 As Double = (BAsicRearMax_STDLH - BAsicRearMin_STDLH)

                    If CDbl(srclbDataLengthTestFrt.Text) >= (BAsicFrtMin_STDLH - tmp1) And CDbl(srclbDataLengthTestFrt.Text) <= (BAsicFrtMax_STDLH + tmp1) Then
                        srclbDecLengthTestFrt.Text = "OK"
                        srclbDecLengthTestFrt.BackColor = Color.Blue
                    Else
                        srclbDecLengthTestFrt.Text = "NG"
                        srclbDecLengthTestFrt.BackColor = Color.Red
                    End If
                    If CDbl(srclbDataLengthTestRear.Text) >= (BAsicRearMin_STDLH - tmp2) And CDbl(srclbDataLengthTestRear.Text) <= (BAsicRearMax_STDLH + tmp2) Then
                        srclbDecLengthTestRear.Text = "OK"
                        srclbDecLengthTestRear.BackColor = Color.Blue
                    Else
                        srclbDecLengthTestRear.Text = "NG"
                        srclbDecLengthTestRear.BackColor = Color.Red
                    End If

                ElseIf OptionType = "FOLD" Then

                    srclbDataLengthTestFrt.Text = Format(basicFrtTolFOLD - ValueLsrLeftUpper - ValueLsrRightUpper, "0.0#")
                    srclbDataLengthTestRear.Text = Format(BasicRearTolFOLD - ValueLsrLeftLower - ValueLsrRightLower, "0.0#")

                    Dim tmp1 As Double = (BAsicFrtMax_FOLDRH - BAsicFrtMin_FOLDRH)
                    Dim tmp2 As Double = (BAsicRearMax_FOLDRH - BAsicRearMin_FOLDRH)

                    tmp1 = 0
                    tmp2 = 0

                    If CDbl(srclbDataLengthTestFrt.Text) >= (BAsicFrtMin_FOLDRH - tmp1) And CDbl(srclbDataLengthTestFrt.Text) <= (BAsicFrtMax_FOLDRH + tmp1) Then
                        srclbDecLengthTestFrt.Text = "OK"
                        srclbDecLengthTestFrt.BackColor = Color.Blue
                    Else
                        srclbDecLengthTestFrt.Text = "NG"
                        srclbDecLengthTestFrt.BackColor = Color.Red
                    End If
                    If CDbl(srclbDataLengthTestRear.Text) >= (BAsicRearMin_FOLDRH - tmp2) And CDbl(srclbDataLengthTestRear.Text) <= (BAsicRearMax_FOLDRH + tmp2) Then
                        srclbDecLengthTestRear.Text = "OK"
                        srclbDecLengthTestRear.BackColor = Color.Blue
                    Else
                        srclbDecLengthTestRear.Text = "NG"
                        srclbDecLengthTestRear.BackColor = Color.Red
                    End If
                End If

                If srclbDecLengthTestFrt.Text = "OK" And srclbDecLengthTestRear.Text = "OK" Then
                    DingDOng()
                    WritePlc("D", "4057", "1")
                    NOW_COLOR = Mid(srcLbPartNo.Text, 12, 3)
                    FrmColor.WindowState = FormWindowState.Normal
                    FrmColor.Location = New Point(-2500, 0)
                    FrmColor.WindowState = FormWindowState.Maximized
                    FrmColor.Show()
                    wStep = 4
                Else
                    wStep = 3.1
                    NG()
                End If

            End If

        ElseIf wStep = 3.1 Then

            If PlcValue(4004) = 0 Then
                wStep = 3
            End If

        ElseIf wStep = 4 Then

            If srclbDecTool.Text <> "OK" Then srclbDataTool.Text = PlcValue(4002)
            If srclbDecRivet.Text <> "OK" Then srclbDataRivet.Text = PlcValue(4003)

            If (CInt(srclbDataTool.Text) = TargetToolNum) And srclbDecTool.Text <> "OK" Then
                WritePlc("D", "4002", "1")
                srclbDecTool.Text = "OK"
                srclbDecTool.BackColor = Color.Blue
                DingDOng()
            End If

            If (CInt(srclbDataRivet.Text) = TargetRivetNum) And srclbDecRivet.Text <> "OK" Then
                WritePlc("D", "4003", "1")
                srclbDecRivet.Text = "OK"
                srclbDecRivet.BackColor = Color.Blue
                DingDOng()
            End If

            If (srclbDecTool.Text = "OK" And srclbDecRivet.Text = "OK" And (srclbDecCoverL.Text = "OK" Or srclbDecCoverL.Text = "NA") And (srclbDecCoverR.Text = "OK" Or srclbDecCoverR.Text = "NA")) Then
                WritePlc("D", "4058", "1")
                wStep = 5
            End If

        ElseIf wStep = 5 Then

            wStep = 6

        ElseIf wStep = 6 Then

            If PlcValue(4001) = 1 Then
                WritePlc("D", "4051", "0000000000")
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

    Private Sub Serial_Scanner_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Serial_Scanner.DataReceived

        Dim Incoming As String
        Dim ScanData As String

        Incoming = Serial_Scanner.ReadLine()
        ScanData = Mid$(Incoming, 1, Len(Incoming) - 1)
        Serial_Scanner.DiscardInBuffer()

        WriteTxtMessage("ScanData : " & ScanData)

        If wStep = 1 Then

            If Len(ScanData) >= 23 Then

                StartTIme = Format(Now, "HH:mm:ss")
                If FlagBeforeCheck = True Then
                    srcLbSerial.Text = ScanData
                    LoadBasicData()
                    LoadPArt(ScanData)
                    CheckBefore(srcLbSerial.Text)
                    If srcLbPartName.Text.Contains("VIP") = True Then
                    Else
                        srcLbCheckVip.Text = "NA"
                        srcLbCheckVip.BackColor = Color.Green
                    End If

                    If srcLbCheck1.Text = "OK" And srcLbCheck2_1.Text = "OK" And srcLbCheck2_2.Text = "OK" And
                        (srcLbCheckVip.Text = "OK" Or srcLbCheckVip.Text = "NA") And srcLbCheckNoiseTest.Text = "OK" Then
                        wStep = 2
                    Else
                        wStep = 1.1
                    End If

                Else

                    srcLbSerial.Text = ScanData
                    LoadPArt(ScanData)
                    wStep = 2
                End If

            End If

        ElseIf wStep >= 2 Then

            If InStr(1, ScanData, srclbTargetCoverL.Text) <> 0 Then
                srclbDataCoverL.Text = ScanData
                srclbDecCoverL.Text = "OK"
                srclbDecCoverL.BackColor = Color.Blue
                DingDOng()
            ElseIf InStr(1, ScanData, srclbTargetCoverR.Text) <> 0 Then
                srclbDataCoverR.Text = ScanData
                srclbDecCoverR.Text = "OK"
                srclbDecCoverR.BackColor = Color.Blue
                DingDOng()
            Else
                NG()
            End If

        End If

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

    Private Sub DaqStart()
        InitializeDaqTask()
    End Sub

    Private Sub DaqEnd()
        ' DAQ Task 정지 및 해제
        myDaqRunningTask = Nothing
        If myDaqTask IsNot Nothing Then
            myDaqTask.Dispose()
            myDaqTask = Nothing
        End If
    End Sub

    ''' <summary>DAQ 비동기 콜백 (DaqTask2Component1_DataReady 대체)</summary>
    Private Sub DaqAnalogInCallback(ByVal ar As IAsyncResult)
        Try
            If myDaqRunningTask IsNot myDaqTask Then Exit Sub

            Dim acquiredData() As NationalInstruments.AnalogWaveform(Of Double) =
                myDaqReader.EndReadWaveform(ar)

            Dim TmpLaser1 As Double
            Dim TmpLaser2 As Double
            Dim TmpLaser3 As Double
            Dim TmpLaser4 As Double
            Dim i As Int64

            SumLaser1 = 0 : SumLaser2 = 0 : SumLaser3 = 0 : SumLaser4 = 0

            DataLaser1 = acquiredData(0).GetRawData()
            DataLaser2 = acquiredData(1).GetRawData()
            DataLaser3 = acquiredData(2).GetRawData()
            DataLaser4 = acquiredData(3).GetRawData()

            For i = 0 To UBound(DataLaser1)
                SumLaser1 += DataLaser1(i)
                SumLaser2 += DataLaser2(i)
                SumLaser3 += DataLaser3(i)
                SumLaser4 += DataLaser4(i)
            Next

            TmpLaser1 = SumLaser1 / (UBound(DataLaser1) + 1)
            TmpLaser2 = SumLaser2 / (UBound(DataLaser2) + 1)
            TmpLaser3 = SumLaser3 / (UBound(DataLaser3) + 1)
            TmpLaser4 = SumLaser4 / (UBound(DataLaser4) + 1)

            ' Y = 36X + 20 (5V=200mm, 0V=20mm)
            ValueLsrLeftUpper  = CDbl(Format((TmpLaser1 * 36) + 20, "0.0"))
            ValueLsrRightUpper = CDbl(Format((TmpLaser2 * 36) + 20, "0.0"))
            ValueLsrLeftLower  = CDbl(Format((TmpLaser3 * 36) + 20, "0.0"))
            ValueLsrRightLower = CDbl(Format((TmpLaser4 * 36) + 20, "0.0"))

            srcLsrLeftLower.Text  = CStr(ValueLsrLeftLower)
            srcLsrRightLower.Text = CStr(ValueLsrRightLower)
            srcLsrLeftUpper.Text  = CStr(ValueLsrLeftUpper)
            srcLsrRightUpper.Text = CStr(ValueLsrRightUpper)

            Try
                LabelFrt.Text = CDbl(TextBoxFrt.Text) + CDbl(srcLsrLeftUpper.Text) + CDbl(srcLsrRightUpper.Text)
            Catch
            End Try
            Try
                LabelRear.Text = CDbl(TextBoxRear.Text) + CDbl(srcLsrLeftLower.Text) + CDbl(srcLsrRightLower.Text)
            Catch
            End Try

            ' 다음 읽기 요청
            myDaqReader.BeginReadWaveform(100, myDaqCallback, myDaqTask)

        Catch ex As NationalInstruments.DAQmx.DaqException
            WriteTxtMessage("[DAQ] 읽기 오류: " & ex.Message)
            MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
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