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
Imports AxCWUIControlsLib

Public Class FrmMain

    ' ActPlc 동적 생성 (디자이너에서 제거됨)
    Private WithEvents ActPlc As AxACTETHERLib.AxActQNUDECPUTCP

    Private Sub InitializeActPlc()
        ActPlc = New AxACTETHERLib.AxActQNUDECPUTCP()
        CType(ActPlc, System.ComponentModel.ISupportInitialize).BeginInit()
        ActPlc.Visible = False
        Me.Controls.Add(ActPlc)
        CType(ActPlc, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub

    Private TmpSeq As String
    Private AlarmMessage(100) As String

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
    Public IN_LABEL(48) As AxCWUIControlsLib.AxCWButton
    Public OUT_LABEL(24) As AxCWUIControlsLib.AxCWButton

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

    ' Init_Grid: FlexCell 제거로 미사용 코드 주석 처리
    'Private Sub Init_Grid(ByVal GridName As FlexCell.Grid)
    '    ...
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
        Dim TmpColorCode As String = ""
        Dim Tmp As String = ""

        ConnectionOpenSQL()

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_PartPlan order by len(seq),seq", SqlConnect)
        If Rs.RecordCount >= 1 Then

            Rs.MoveFirst()

            Try
                Do Until Rs.EOF
                    If CInt(Rs.Fields("PartPlan").Value) > CInt(Rs.Fields("PartCountLH").Value) Or CInt(Rs.Fields("PartPlan").Value) > CInt(Rs.Fields("PartCountRH").Value) Then
                        If CInt(Rs.Fields("PartCountLH").Value) = CInt(Rs.Fields("PartCountRH").Value) Then
                            Tmp = CStr(Rs.Fields("PartNoLH").Value)
                        ElseIf CInt(Rs.Fields("PartCountLH").Value) > CInt(Rs.Fields("PartCountRH").Value) Then
                            Tmp = CStr(Rs.Fields("PartNoRH").Value)
                        End If
                        TmpColorCode = CStr(Rs.Fields("PartColor").Value)
                        TmpSeq = CStr(Rs.Fields("Seq").Value)
                        Exit Do
                    Else
                        Rs.MoveNext()
                    End If
                Loop
            Catch ex As Exception
                srclbAlarm.Visible = True
                srclbAlarm.Text = "잘못된 계획수량입니다. 입력창을 다시 확인해주세요"
            End Try

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

        Tmp = Tmp & TmpColorCode
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

    
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializeActPlc()

        CheckForIllegalCrossThreadCalls = False

        LoadPortData()
        LoadBarcodeData()
        LoadBasicData()
        LoadALarmMessage()
        InitControl()

        WriteTxtMessage("Init Complete")
        SerialOpen()

        InitGrid()
        LoadGrid()

        Timer1.Interval = 100
        Timer1.Start()

        WriteTxtMessage("System Ready..")

        ActPlc.ActTimeOut = 500
        AddressOfPLc = "192.168.0.100"
        Label11.Text = AddressOfPLc
        FlagPlcConnection = False

        If Serial_Tool.IsOpen = True Then
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
                    ActPlc.Close()
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
        ElseIf PlcValue(4009) = 0 And srclbAlarm.Visible = True Then
            srclbAlarm.Visible = False
        End If

        PCAliveCount = PCAliveCount + 1
        If PcAliveCount = 10 Then
            WritePlc("D", "4050", "1")
        ElseIf PcAliveCount = 20 Then
            WritePlc("D", "4050", "0")
            PcAliveCount = 0
        End If

        If PlcValue(4000) = 0 And wStep <> 0 Then
            wStep = 0
            WritePlc("D", "4051", "0000000")
            InitControl()
        End If

        If wStep = 0 Then

            If PlcValue(4000) = 1 Then
                WritePlc("D", "4051", "0000000")
                InitControl()
                'InitGrid(Grid1)
                wStep = 1
            End If

        ElseIf wStep = 1 Then

            If PlcValue(4003) = 1 Then 'Start
                StartTime = Format(Now, "HH:mm:ss")
                wStep = 2
            End If

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
            wStep = 3

        ElseIf wStep = 3 Then 'Check

            If srclbDecTool.Text <> "OK" Then srclbDataTool.Text = PlcValue(4002)

            If (CInt(srclbDataTool.Text) = TargetToolNum) And srclbDecTool.Text <> "OK" Then
                srclbDecTool.Text = "OK"
                srclbDecTool.BackColor = Color.Blue
                DingDOng()
            End If

            If (srclbDecMotorBarcode.Text = "OK" Or srclbDecMotorBarcode.Text = "PASS" Or srclbDecMotorBarcode.Text = "NA") And _
                (srclbDecFrameBarcode.Text = "OK" Or srclbDecFrameBarcode.Text = "PASS" Or srclbDecFrameBarcode.Text = "NA") And _
                (srclbDecMotorTq.Text = "OK" Or srclbDecMotorTq.Text = "PASS" Or srclbDecMotorTq.Text = "NA") And _
                (srclbDecTool.Text = "OK") Then
                WritePlc("D", "4057", "1")
                wStep = 4
            End If

        ElseIf wStep = 4 Then

            SaveDB()
            SavePlan(srcLbPartNo.Text, TmpSeq)
            wStep = 5

        ElseIf wStep = 5 Then

            If PlcValue(4001) = 1 Then
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
        ' DataGridView로 변환 (FlexCell 제거)
        GridCount.Columns.Clear()
        GridCount.Rows.Clear()

        ' 컬럼 추가: col0 숨김, col1=품번, col2=생산수량
        GridCount.Columns.Add("col0", "")
        GridCount.Columns.Add("col1", "품번")
        GridCount.Columns.Add("col2", "생산수량")

        GridCount.Columns(0).Visible = False
        GridCount.Columns(1).Width = 230
        GridCount.Columns(2).Width = 190

        GridCount.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridCount.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GridCount.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub


    Private Sub LoadGrid()

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT JObPartNo,JobCount FROM Table_Count ORDER BY LEN(JobPartNo),JobPartNo", MdbConnect)

        GridCount.Rows.Clear()

        If Rs.RecordCount = 0 Then
        ElseIf Rs.RecordCount >= 1 Then

            Rs.MoveFirst()

            If Rs.BOF = True Or Rs.EOF = True Then
            Else
                Do Until Rs.EOF
                    ' DataGridView 행 추가 (FlexCell.AddItem → Rows.Add 변환)
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

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ResetGrid()
        InitGrid()
        LoadGrid()

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

        If strPartNo.Contains("883") = True Then
            Rs.Open("SELECT * FROM Table_PartPlan Where PartNoLH = '" & Mid(strPartNo, 1, 11) & "' AND PartColor = '" & Mid(strPartNo, 12, 3) & "' AND Seq = '" & TmpSeq & "'", SqlConnect)
            If Rs.RecordCount = 1 Then
                tmp = CInt(Rs.Fields("PartCountLH").Value)
                tmp = tmp + 1
                Rs.Fields("partCountLH").Value = CStr(tmp)
                Rs.Update()
            End If
        ElseIf strPartNo.Contains("884") = True Then
            Rs.Open("SELECT * FROM Table_PartPlan Where PartNoRH = '" & Mid(strPartNo, 1, 11) & "' AND PartColor = '" & Mid(strPartNo, 12, 3) & "' AND Seq = '" & TmpSeq & "'", SqlConnect)
            If Rs.RecordCount = 1 Then
                tmp = CInt(Rs.Fields("PartCountRH").Value)
                tmp = tmp + 1
                Rs.Fields("partCountRH").Value = CStr(tmp)
                Rs.Update()
            End If
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()
        TmpSeq = ""

    End Sub

End Class