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

    Private AlarmMessage(100) As String
    Private TargetMonitorBarcodeL As String
    Private TargetMonitorBarcodeR As String

    Private TmpTool2NumR As Integer
    Private TmpTool2NumL As Integer
    Private AfterSCanToolNumR As Integer
    Private AfterSCanToolNumL As Integer

    Private TmpToolCount As Integer
    Private StartTImeL As String
    Private StartTImeR As String
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

    Private OptionLhRhL As String
    Private OptionTypeL As String
    Private OptionBackL As String
    Private OptionFootRestL As Boolean
    Private OptionMonitorL As Boolean
    Private TargetLsuptBarcodeL As String
    Private TargetLsuptVersionBarcodeL As String
    Private TargetToolNumL As Integer
    Private TargetToolNum2L As Integer
    Private TargetFlagSabTqL As Boolean
    Private TargetFlagcSabTqL As Boolean
    Private TargetHarnessBArcodeL As String

    Private OptionLhRhR As String
    Private OptionTypeR As String
    Private OptionBackR As String
    Private OptionFootRestR As Boolean
    Private OptionMonitorR As Boolean
    Private TargetLsuptBarcodeR As String
    Private TargetLsuptVersionBarcodeR As String
    Private TargetToolNumR As Integer
    Private TargetToolNum2R As Integer
    Private TargetFlagSabTqR As Boolean
    Private TargetFlagcSabTqR As Boolean
    Private TargetHarnessBArcodeR As String

    Private D_OutString As String
    Private rStep As Double
    Private rCount As Double
    Private EndTime As String
    Private wStepL As Double
    Private wStepR As Double
    Private wCountL As Double
    Private wCountR As Double
    Private PcAliveCountL As Integer
    Private PcAliveCountR As Integer

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

    ' Init_Grid: FlexCell 제거로 미사용 코드 주석 처리
    'Private Sub Init_Grid(ByVal GridName As FlexCell.Grid)
    '    ...
    'End Sub

    Private Sub InitControlL()

        LoadPicture(srcPictureBoxL, "NON")
        srcLbPartNoL.Text = ""
        srcLbPartNameL.Text = ""
        srcLbPartOptionL.Text = ""
        srcLbSerialL.Text = ""
        srclbTargetToolL.Text = ""
        srclbTargetTool2L.Text = ""

        srclbDataToolL.Text = ""
        srclbDecToolL.Text = ""
        srclbDecToolL.BackColor = Color.Black

        srclbDataTool2L.Text = ""
        srclbDecTool2L.Text = ""
        srclbDecTool2L.BackColor = Color.Black

        srclbTargetLsuptBarcodeL.Text = ""
        srclbDataLsuptBarcodeL.Text = ""
        srclbDecLsuptBarcodeL.Text = ""
        srclbDecLsuptBarcodeL.BackColor = Color.Black

        srclbTargetLsuptVersionBarcodeL.Text = ""
        srclbDataLsuptVersionBarcodeL.Text = ""
        srclbDecLsuptVersionBarcodeL.Text = ""
        srclbDecLsuptVersionBarcodeL.BackColor = Color.Black

        srclbTargetHarnessBarcodeL.Text = ""
        srclbDataHarnessBarcodeL.Text = ""
        srclbDecHarnessBarcodeL.Text = ""
        srclbDecHarnessBarcodeL.BackColor = Color.Black

    End Sub

    Private Sub InitControlR()

        LoadPicture(srcPictureBoxR, "NON")
        srcLbPartNoR.Text = ""
        srcLbPartNameR.Text = ""
        srcLbPartOptionR.Text = ""
        srcLbSerialR.Text = ""
        srclbTargetToolR.Text = ""
        srclbTargetTool2R.Text = ""

        srclbDataToolR.Text = ""
        srclbDecToolR.Text = ""
        srclbDecToolR.BackColor = Color.Black

        srclbDataTool2R.Text = ""
        srclbDecTool2R.Text = ""
        srclbDecTool2R.BackColor = Color.Black

        srclbTargetLsuptBarcodeR.Text = ""
        srclbDataLsuptBarcodeR.Text = ""
        srclbDecLsuptBarcodeR.Text = ""
        srclbDecLsuptBarcodeR.BackColor = Color.Black

        srclbTargetLsuptVersionBarcodeR.Text = ""
        srclbDataLsuptVersionBarcodeR.Text = ""
        srclbDecLsuptVersionBarcodeR.Text = ""
        srclbDecLsuptVersionBarcodeR.BackColor = Color.Black

        srclbTargetHarnessBarcodeR.Text = ""
        srclbDataHarnessBarcodeR.Text = ""
        srclbDecHarnessBarcodeR.Text = ""
        srclbDecHarnessBarcodeR.BackColor = Color.Black

    End Sub

    Sub SerialOpen()

        Try
            If Serial_ScannerL.IsOpen() = True Then
                Serial_ScannerL.Close()
            End If
            Serial_ScannerL.PortName = PortNumber_ScannerL
            Serial_ScannerL.BaudRate = 9600
            Serial_ScannerL.DataBits = 8
            Serial_ScannerL.Parity = IO.Ports.Parity.None
            Serial_ScannerL.Handshake = Ports.Handshake.RequestToSendXOnXOff
            Serial_ScannerL.Open()
            WriteTxtMessage("Serial Scanner L Open Success " & PortNumber_ScannerL)
        Catch ex As Exception
            WriteTxtMessage("Serial Scanner L Open Fail")
        End Try

        Try
            If Serial_ScannerR.IsOpen() = True Then
                Serial_ScannerR.Close()
            End If
            Serial_ScannerR.PortName = PortNumber_ScannerR
            Serial_ScannerR.BaudRate = 9600
            Serial_ScannerR.DataBits = 8
            Serial_ScannerR.Parity = IO.Ports.Parity.None
            Serial_ScannerR.Handshake = Ports.Handshake.RequestToSendXOnXOff
            Serial_ScannerR.Open()
            WriteTxtMessage("Serial Scanner R Open Success " & PortNumber_ScannerR)
        Catch ex As Exception
            WriteTxtMessage("Serial Scanner R Open Fail")
        End Try


    End Sub

    Private Sub Barcode_Print(ByVal LR As String, ByVal strSerial As String, ByVal strPartno As String, ByVal strPartOption As String)

        'If LR = "L" Then
        '    Serial_Printer.Write("^XA")
        '    Serial_Printer.Write("^FO" & BarcodeBX & "," & BarcodeBY & "^BXN," & BarcodeBH & "," & BarcodeBL & ",0,0,,^FH^FD" & strSerial & "^FS")
        '    Serial_Printer.Write("^FO" & BarcodeS1X & "," & BarcodeS1Y & "^A0N," & BarcodeS1H & "," & BarcodeS1W & "^FD" & strPartno & "^FS")
        '    Serial_Printer.Write("^FO" & BarcodeS3X & "," & BarcodeS3Y & "^A0N," & BarcodeS3H & "," & BarcodeS3W & "^FD" & strPartOption & "^FS")
        '    Serial_Printer.Write("^FO" & BarcodeS4X & "," & BarcodeS4Y & "^A0N," & BarcodeS4H & "," & BarcodeS4W & "^FD" & Format(Now, "yyyy.MM.dd") & " " & Format(Now, "HH:mm") & "^FS")
        '    Serial_Printer.Write("^XZ")

        '    'Barcode_Print("R", CreateEndBArcode(srcLbSerialR.Text), srcLbPartNoR.Text, srcLbPartOptionR.Text)

        'ElseIf LR = "R" Then
        '    Serial_Tool.Write("^XA")
        '    Serial_Tool.Write("^FO" & BarcodeBX & "," & BarcodeBY & "^BXN," & BarcodeBH & "," & BarcodeBL & ",0,0,,^FH^FD" & strSerial & "^FS")
        '    Serial_Tool.Write("^FO" & BarcodeS1X & "," & BarcodeS1Y & "^A0N," & BarcodeS1H & "," & BarcodeS1W & "^FD" & strPartno & "^FS")
        '    Serial_Tool.Write("^FO" & BarcodeS3X & "," & BarcodeS3Y & "^A0N," & BarcodeS3H & "," & BarcodeS3W & "^FD" & strPartOption & "^FS")
        '    Serial_Tool.Write("^FO" & BarcodeS4X & "," & BarcodeS4Y & "^A0N," & BarcodeS4H & "," & BarcodeS4W & "^FD" & Format(Now, "yyyy.MM.dd") & " " & Format(Now, "HH:mm") & "^FS")
        '    Serial_Tool.Write("^XZ")

        '    'Barcode_Print("R", CreateEndBArcode(srcLbSerialR.Text), srcLbPartNoR.Text, srcLbPartOptionR.Text)

        'End If

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

    Private Sub LoadPArtL(ByVal str As String)

        ConnectionOpenSQL()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part WHERE PartNo = '" & Mid(str, 13, 11) & "'", SqlConnect)

        If Rs.RecordCount = 1 Then

            srcLbPartNoL.Text = Mid(str, 13, 14)
            srcLbPartNameL.Text = Trim(Rs.Fields("PartName").Value)
            LoadPicture(srcPictureBoxL, Mid(srcLbPartNoL.Text, 1, 11))

            OptionLhRhL = Trim(Rs.Fields("OptionLHRH").Value)
            OptionTypeL = Trim(Rs.Fields("OptionType").Value)
            OptionBackL = Trim(Rs.Fields("OptionBack").Value)
            OptionFootRestL = Rs.Fields("OptionFootRest").Value
            OptionMonitorL = Rs.Fields("OptionMon").Value

            srcLbPartOptionL.Text = OptionTypeL & " " & OptionLhRhL

            TargetToolNumL = CInt(Trim(Rs.Fields("Target_Op02_ToolNum").Value))
            TargetToolNum2L = CInt(Trim(Rs.Fields("Target_Op02_ToolNum2").Value))

            TargetLsuptBarcodeL = Trim(Rs.Fields("Target_Op02_LsuptBarcode").Value)
            TargetLsuptVersionBarcodeL = Trim(Rs.Fields("Target_Op02_LsuptVersion").Value)
            TargetHarnessBArcodeL = Trim(Rs.Fields("Target_Op02_HarnessBarcode").Value)

            TargetMonitorBarcodeL = Trim(Rs.Fields("Target_Op02_MonitorCableBarcode").Value)

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

    End Sub

    Private Sub LoadPArtR(ByVal str As String)

        ConnectionOpenSQL()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part WHERE PartNo = '" & Mid(str, 13, 11) & "'", SqlConnect)

        If Rs.RecordCount = 1 Then

            srcLbPartNoR.Text = Mid(str, 13, 14)
            srcLbPartNameR.Text = Trim(Rs.Fields("PartName").Value)
            LoadPicture(srcPictureBoxR, Mid(srcLbPartNoR.Text, 1, 11))

            OptionLhRhR = Trim(Rs.Fields("OptionLHRH").Value)
            OptionTypeR = Trim(Rs.Fields("OptionType").Value)
            OptionBackR = Trim(Rs.Fields("OptionBack").Value)
            OptionFootRestR = Rs.Fields("OptionFootRest").Value
            OptionMonitorR = Rs.Fields("OptionMon").Value

            srcLbPartOptionR.Text = OptionTypeR & " " & OptionLhRhR

            TargetToolNumR = CInt(Trim(Rs.Fields("Target_Op02_ToolNum").Value))
            TargetToolNum2R = CInt(Trim(Rs.Fields("Target_Op02_ToolNum2").Value))
            TargetLsuptBarcodeR = (Trim(Rs.Fields("Target_Op02_LsuptBarcode").Value))
            TargetLsuptVersionBarcodeR = Trim(Rs.Fields("Target_Op02_LsuptVersion").Value)
            TargetHarnessBArcodeR = Trim(Rs.Fields("Target_Op02_HarnessBarcode").Value)

            TargetMonitorBarcodeR = Trim(Rs.Fields("Target_Op02_MonitorCableBarcode").Value)

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

    End Sub

    Private Function OptionConvert(ByVal str As String) As String

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

    Private Function OptionConvertInt(ByVal str As String) As Integer

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

    Private Sub SaveDbL(ByVal strSerial As String)

        Dim strSQL As String = ""

        ConnectionOpenSQL()

        strSQL = "UPDATE TABLE_MAIN SET " &
                    "Op02_1_DATE = '" & Format(Now, "yyyy-MM-dd") & "'," &
                    "Op02_1_STARTTIME = '" & StartTImeL & "'," &
                    "Op02_1_ENDTIME = '" & Format(Now, "HH:mm:ss") & "'," &
                    "Op02_1_HarnessBarcode = '" & srclbDataHarnessBarcodeL.Text & "'," &
                    "Op02_1_LsuptBarcode = '" & srclbDataLsuptBarcodeL.Text & "'," &
                    "Op02_1_DECISION = '" & "OK" & "' " &
                    "WHERE SERIALNO = '" & strSerial & "'"

        SqlConnect.Execute(strSQL)
        ConnectionCloseSQL()

    End Sub

    Private Sub SaveDbR(ByVal strSerial As String)

        Dim strSQL As String = ""

        ConnectionOpenSQL()

        strSQL = "UPDATE TABLE_MAIN SET " &
                    "Op02_1_DATE = '" & Format(Now, "yyyy-MM-dd") & "'," &
                    "Op02_1_STARTTIME = '" & StartTImeR & "'," &
                    "Op02_1_ENDTIME = '" & Format(Now, "HH:mm:ss") & "'," &
                    "Op02_1_HarnessBarcode = '" & srclbDataHarnessBarcodeR.Text & "'," &
                    "Op02_1_LsuptBarcode = '" & srclbDataLsuptBarcodeR.Text & "'," &
                    "Op02_1_DECISION = '" & "OK" & "' " &
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

        tmp = Format(Now, "yyyyMMdd") & Format(Rs.RecordCount + 1, "0000") & srcLbPartNoL.Text

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

        Return tmp

    End Function


    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        InitializeActPlc()

        CheckForIllegalCrossThreadCalls = False

        LoadPortData()
        LoadBarcodeData()
        LoadBasicData()
        LoadALarmMessage()
        InitControlL()
        InitControlR()

        WriteTxtMessage("Init Complete")
        SerialOpen()

        Timer1.Interval = 100
        Timer1.Start()

        WriteTxtMessage("System Ready..")

        ActPlc.ActTimeOut = 500
        AddressOfPLc = "192.168.0.105"
        Label11.Text = AddressOfPLc
        FlagPlcConnection = False

        If Serial_Tool.IsOpen = True Then
            Trd1 = New Thread(AddressOf ThreadTask1)
            Trd1.IsBackground = True
            Trd1.Start()
        End If

        Tmr_Connect.Interval = 100
        Tmr_Connect.Start()
        wStepL = 0
        wStepR = 0

        WritePlc("D", "4051", "0000000")
        WritePlc("D", "4151", "0000000")

        Tmr_Work1.Interval = 100
        Tmr_Work1.Start()

        Tmr_Work2.Interval = 100
        Tmr_Work2.Start()

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
        Dim Arrysize As Integer = 40

        ReDim sharrDeviceValue(Arrysize - 1)
        ReDim szarrData(Arrysize - 1)

        szDeviceName = "D4000" & vbLf & "D4001" & vbLf & "D4002" & vbLf & "D4003" & vbLf & "D4004" & vbLf & "D4005" & vbLf & "D4006" & vbLf & "D4007" & vbLf & "D4008" & vbLf & "D4009" & vbLf &
                       "D4050" & vbLf & "D4051" & vbLf & "D4052" & vbLf & "D4053" & vbLf & "D4054" & vbLf & "D4055" & vbLf & "D4056" & vbLf & "D4057" & vbLf & "D4058" & vbLf & "D4059" & vbLf &
                       "D4100" & vbLf & "D4101" & vbLf & "D4102" & vbLf & "D4103" & vbLf & "D4104" & vbLf & "D4105" & vbLf & "D4106" & vbLf & "D4107" & vbLf & "D4108" & vbLf & "D4109" & vbLf &
                       "D4150" & vbLf & "D4151" & vbLf & "D4152" & vbLf & "D4153" & vbLf & "D4154" & vbLf & "D4155" & vbLf & "D4156" & vbLf & "D4157" & vbLf & "D4158" & vbLf & "D4159"
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
            For i = 20 To 29
                PlcValue(i + 4080) = tmpPlcValue(i)
            Next
            For i = 30 To 39
                PlcValue(i + 4120) = tmpPlcValue(i)
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

            lbD4100.Text = PlcValue(4100)
            lbD4101.Text = PlcValue(4101)
            lbD4102.Text = PlcValue(4102)
            lbD4103.Text = PlcValue(4103)
            lbD4104.Text = PlcValue(4104)
            lbD4105.Text = PlcValue(4105)
            lbD4106.Text = PlcValue(4106)
            lbD4107.Text = PlcValue(4107)
            lbD4108.Text = PlcValue(4108)
            lbD4109.Text = PlcValue(4109)

            lbD4150.Text = PlcValue(4150)
            lbD4151.Text = PlcValue(4151)
            lbD4152.Text = PlcValue(4152)
            lbD4153.Text = PlcValue(4153)
            lbD4154.Text = PlcValue(4154)
            lbD4155.Text = PlcValue(4155)
            lbD4156.Text = PlcValue(4156)
            lbD4157.Text = PlcValue(4157)
            lbD4158.Text = PlcValue(4158)
            lbD4159.Text = PlcValue(4159)

            PlcConnectionError = "OK"

        Else

            PlcConnectionError = Dec2Hex(iReturnCode)

        End If

    End Sub


    Private Function ReturnPrintString(ByVal strData As String) As String

        Dim RS As String = "_1e"
        Dim GS As String = "_1d"
        Dim EOT As String = "_04"

        Dim tmp As String = ""
        If strData.Length > 10 Then
            tmp = "#" & "[)>" & RS & "06" & GS & strData & RS & EOT
        End If
        Return tmp

    End Function

    Private Function CreateEndBArcode(ByVal strLineSerial As String) As String

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

    Public Function Hex2Dec(ByVal str As String) As String

        Dim tmp As String = ""

        Try
            tmp = CDbl("&H" & str)
        Catch ex As Exception

        End Try

        Return tmp

    End Function

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs)
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

    Private Sub SerialPortToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SerialPortToolStripMenuItem.Click
        FrmPort.Show()
    End Sub

    Private Sub BasicToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BasicToolStripMenuItem.Click
        FrmBasic.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub BarcodeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BarcodeToolStripMenuItem.Click
        FrmBarcode.Show()
    End Sub

    Private Sub VitualKeyboardToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VitualKeyboardToolStripMenuItem.Click

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

                            'If wStep = 3 Then

                            'If ToolData >= BasicToolMin And ToolData <= BasicToolMax And Mid(Tool_String1, 109, 1) = "1" Then
                            '    srclbDataMotorTq.Text = ToolData
                            '    srclbDecMotorTq.Text = "OK"
                            '    srclbDecMotorTq.BackColor = Color.Blue
                            '    DingDOng()
                            'Else
                            '    srclbDataMotorTq.Text = ToolData
                            '    srclbDecMotorTq.Text = "NG"
                            '    srclbDecMotorTq.BackColor = Color.Red
                            '    NG()
                            'End If

                        '
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

    Private Sub Serial_ScannerL_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Serial_ScannerL.DataReceived

        Dim Incoming As String
        Dim ScanData As String
        Dim FlagAlarm As Boolean = False

        Incoming = Serial_ScannerL.ReadLine()
        ScanData = Mid$(Incoming, 1, Len(Incoming) - 1)
        Serial_ScannerL.DiscardInBuffer()

        WriteTxtMessage("ScanDataL : " & ScanData)

        If wStepL = 1 Then

            If Len(ScanData) >= 23 Then
                srcLbSerialL.Text = ScanData
                LoadPArtL(ScanData)
                wStepL = 2
            End If

        ElseIf wStepL = 4 Then

            If InStr(1, ScanData, TargetLsuptBarcodeL) <> 0 Then
                srclbDataLsuptBarcodeL.Text = ScanData
                srclbDecLsuptBarcodeL.Text = "OK"
                srclbDecLsuptBarcodeL.BackColor = Color.Blue
                If srclbDecLsuptVersionBarcodeL.Text <> "NA" Then
                    If InStr(1, ScanData, TargetLsuptVersionBarcodeL) <> 0 Then
                        srclbDataLsuptVersionBarcodeL.Text = TargetLsuptVersionBarcodeL
                        srclbDecLsuptVersionBarcodeL.Text = "OK"
                        srclbDecLsuptVersionBarcodeL.BackColor = Color.Blue
                        DingDOng()
                        FlagAlarm = True
                    Else
                        srclbDataLsuptVersionBarcodeL.Text = ScanData
                        srclbDecLsuptVersionBarcodeL.Text = "NG"
                        srclbDecLsuptVersionBarcodeL.BackColor = Color.Red
                        FlagAlarm = False
                    End If
                Else
                    FlagAlarm = True
                End If
                
            End If

            If InStr(1, ScanData, TargetHarnessBArcodeL) <> 0 Then
                srclbDataHarnessBarcodeL.Text = ScanData
                srclbDecHarnessBarcodeL.Text = "OK"
                srclbDecHarnessBarcodeL.BackColor = Color.Blue
                DingDOng()
                FlagAlarm = True
            End If
            If FlagAlarm = False Then NG()

        End If

    End Sub

    Private Sub Serial_ScannerR_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Serial_ScannerR.DataReceived

        Dim Incoming As String
        Dim ScanData As String
        Dim FlagAlarm As Boolean = False

        Incoming = Serial_ScannerR.ReadLine()
        ScanData = Mid$(Incoming, 1, Len(Incoming) - 1)
        Serial_ScannerR.DiscardInBuffer()

        WriteTxtMessage("ScanDataR : " & ScanData)

        If wStepR = 1 Then

            If Len(ScanData) >= 23 Then
                srcLbSerialR.Text = ScanData
                LoadPArtR(ScanData)
                wStepR = 2
            End If

        ElseIf wStepR = 4 Then

            If InStr(1, ScanData, TargetLsuptBarcodeR) <> 0 Then
                srclbDataLsuptBarcodeR.Text = ScanData
                srclbDecLsuptBarcodeR.Text = "OK"
                srclbDecLsuptBarcodeR.BackColor = Color.Blue

                If srclbDecLsuptVersionBarcodeR.Text <> "NA" Then
                    If InStr(1, ScanData, TargetLsuptVersionBarcodeR) <> 0 Then
                        srclbDataLsuptVersionBarcodeR.Text = TargetLsuptVersionBarcodeR
                        srclbDecLsuptVersionBarcodeR.Text = "OK"
                        srclbDecLsuptVersionBarcodeR.BackColor = Color.Blue
                        DingDOng()
                        FlagAlarm = True
                    Else
                        srclbDataLsuptVersionBarcodeR.Text = ScanData
                        srclbDecLsuptVersionBarcodeR.Text = "NG"
                        srclbDecLsuptVersionBarcodeR.BackColor = Color.Red
                        FlagAlarm = False
                    End If
                Else
                    FlagAlarm = True
                End If
                
            End If

            If InStr(1, ScanData, TargetHarnessBArcodeR) <> 0 Then
                srclbDataHarnessBarcodeR.Text = ScanData
                srclbDecHarnessBarcodeR.Text = "OK"
                srclbDecHarnessBarcodeR.BackColor = Color.Blue
                DingDOng()
                FlagAlarm = True
            End If

            If FlagAlarm = False Then NG()

        End If

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


    Private Sub Tmr_Work1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Work1.Tick

        srclbStepL.Text = wStepL

        If PlcValue(4009) <> 0 And srclbAlarm.Visible = False Then
            srclbAlarm.Visible = True
            srclbAlarm.Text = AlarmMessage(CInt(PlcValue(4009)))
        ElseIf PlcValue(4009) = 0 And srclbAlarm.Visible = True Then
            srclbAlarm.Visible = False
        End If

        PcAliveCountL = PcAliveCountL + 1
        If PcAliveCountL = 10 Then
            WritePlc("D", "4150", "1")
        ElseIf PcAliveCountL = 20 Then
            WritePlc("D", "4150", "0")
            PcAliveCountL = 0
        End If

        If PlcValue(4100) = 0 And wStepL <> 0 Then
            WritePlc("D", "4151", "0000000")
            wStepL = 0
            InitControlL()
        End If

        If wStepL = 0 Then

            If PlcValue(4100) = 1 Then
                WritePlc("D", "4151", "0000000")
                InitControlL()
                wStepL = 1
            End If

        ElseIf wStepL = 1 Then '스캔대기

        ElseIf wStepL = 2 Then '스캔완료

            StartTimeL = Format(Now, "HH:mm:ss")
            wStepL = 3
            
        ElseIf wStepL = 3 Then

            srclbTargetToolL.Text = CStr(TargetToolNumL)
            srclbTargetTool2L.Text = CStr(TargetToolNum2L)

            srclbTargetLsuptBarcodeL.Text = TargetLsuptBarcodeL
            srclbTargetLsuptVersionBarcodeL.Text = TargetLsuptVersionBarcodeL
            srclbTargetHarnessBarcodeL.Text = TargetHarnessBArcodeL

            If TargetLsuptBarcodeL = "0" Then
                srclbDataLsuptBarcodeL.Text = "NA"
                srclbDecLsuptBarcodeL.Text = "NA"
                srclbDecLsuptBarcodeL.BackColor = Color.Green
            End If
            If TargetLsuptVersionBarcodeL = "0" Then
                srclbDataLsuptVersionBarcodeL.Text = "NA"
                srclbDecLsuptVersionBarcodeL.Text = "NA"
                srclbDecLsuptVersionBarcodeL.BackColor = Color.Green
            End If
            If TargetHarnessBArcodeL = "0" Then
                srclbDataHarnessBarcodeL.Text = "NA"
                srclbDecHarnessBarcodeL.Text = "NA"
                srclbDecHarnessBarcodeL.BackColor = Color.Green
            End If

            FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, Mid(srcLbPartNoL.Text, 1, 11))
            wStepL = 3.1

        ElseIf wStepL = 3.1 Then 'Send PLC Option

            If OptionLhRhL = "LH" Then
                WritePlc("D", "4151", "1")
            ElseIf OptionLhRhL = "RH" Then
                WritePlc("D", "4151", "2")
            End If

            If OptionTypeL = "STD" Then
                WritePlc("D", "4152", "1")
            ElseIf OptionTypeL = "FOLD" Then
                WritePlc("D", "4152", "2")
            ElseIf OptionTypeL = "VIP" Then
                WritePlc("D", "4152", "3")
            End If

            If OptionBackL = "PULLMA" Then
                WritePlc("D", "4153", "1")
            Else
                WritePlc("D", "4153", "2")
            End If

            If OptionFootRestL = True Then
                WritePlc("D", "4154", "1")
            Else
                WritePlc("D", "4154", "0")
            End If

            If OptionMonitorL = True Then
                WritePlc("D", "4155", "1")
            Else
                WritePlc("D", "4155", "0")
            End If
            WritePlc("D", "4156", "1")
            wStepL = 4

        ElseIf wStepL = 4 Then 'Check

            If srclbDecToolL.Text <> "OK" Then srclbDataToolL.Text = PlcValue(4102)

            If (srclbDecHarnessBarcodeL.Text = "OK" Or srclbDecHarnessBarcodeL.Text = "NA") And srclbDecToolL.Text = "OK" Then
                If TmpTool2NumL <> PlcValue(4102) Then
                    srclbDataTool2L.Text = CStr(AfterSCanToolNumL + 1)
                    AfterSCanToolNumL = CInt(srclbDataTool2L.Text)
                End If
            End If

            If (CInt(srclbDataToolL.Text) >= TargetToolNumL) And srclbDecToolL.Text <> "OK" Then
                srclbDecToolL.Text = "OK"
                srclbDecToolL.BackColor = Color.Blue
                AfterSCanToolNumL = 0
                DingDOng()
            End If

            Try
                If (CInt(srclbDataTool2L.Text) >= TargetToolNum2L) And srclbDecTool2L.Text <> "OK" Then
                    srclbDecTool2L.Text = "OK"
                    srclbDecTool2L.BackColor = Color.Blue
                    DingDOng()
                End If
            Catch ex As Exception
            End Try
            
            If (srclbDecToolL.Text = "OK" Or srclbDecToolL.Text = "NA") And
               (srclbDecTool2L.Text = "OK" Or srclbDecTool2L.Text = "NA") And
               (srclbDecLsuptBarcodeL.Text = "OK" Or srclbDecLsuptBarcodeL.Text = "NA") And
               (srclbDecLsuptVersionBarcodeL.Text = "OK" Or srclbDecLsuptVersionBarcodeL.Text = "NA") And
               (srclbDecHarnessBarcodeL.Text = "OK" Or srclbDecHarnessBarcodeL.Text = "NA") Then
                WritePlc("D", "4157", "1")
                wStepL = 5
            End If

            TmpTool2NumL = PlcValue(4102)

        ElseIf wStepL = 5 Then

            SaveDbL(srcLbSerialL.Text)
            wStepL = 6

        ElseIf wStepL = 6 Then

            If PlcValue(4101) = 1 Then
               WritePlc("D", "4151", "0000000")
                InitControlL()
                wStepL = 0
            End If

        End If

    End Sub

    Private Sub Tmr_Work2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Work2.Tick

        srclbStepR.Text = wStepR

        PcAliveCountR = PcAliveCountR + 1
        If PcAliveCountR = 10 Then
            WritePlc("D", "4050", "1")
        ElseIf PcAliveCountR = 20 Then
            WritePlc("D", "4050", "0")
            PcAliveCountR = 0
        End If

        If PlcValue(4000) = 0 And wStepR <> 0 Then
            wStepR = 0
            WritePlc("D", "4051", "0000000")
            InitControlR()
        End If

        If wStepR = 0 Then

            If PlcValue(4000) = 1 Then
                WritePlc("D", "4051", "0000000")
                InitControlR()
                wStepR = 1
            End If

        ElseIf wStepR = 1 Then '스캔대기

        ElseIf wStepR = 2 Then '스캔완료

            StartTImeR = Format(Now, "HH:mm:ss")
            wStepR = 3

        ElseIf wStepR = 3 Then

            FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, Mid(srcLbPartNoR.Text, 1, 11))

            srclbTargetToolR.Text = CStr(TargetToolNumR)
            srclbTargetTool2R.Text = CStr(TargetToolNum2R)

            srclbTargetLsuptBarcodeR.Text = TargetLsuptBarcodeR
            srclbTargetLsuptVersionBarcodeR.Text = TargetLsuptVersionBarcodeR
            srclbTargetHarnessBarcodeR.Text = TargetHarnessBArcodeR
            If TargetLsuptBarcodeR = "0" Then
                srclbDataLsuptBarcodeR.Text = "NA"
                srclbDecLsuptBarcodeR.Text = "NA"
                srclbDecLsuptBarcodeR.BackColor = Color.Green
            End If
            If TargetLsuptVersionBarcodeR = "0" Then
                srclbDataLsuptVersionBarcodeR.Text = "NA"
                srclbDecLsuptVersionBarcodeR.Text = "NA"
                srclbDecLsuptVersionBarcodeR.BackColor = Color.Green
            End If
            If TargetHarnessBArcodeR = "0" Then
                srclbDataHarnessBarcodeR.Text = "NA"
                srclbDecHarnessBarcodeR.Text = "NA"
                srclbDecHarnessBarcodeR.BackColor = Color.Green
            End If
            wStepR = 3.1

        ElseIf wStepR = 3.1 Then 'Send PLC Option

            If OptionLhRhR = "LH" Then
                WritePlc("D", "4051", "1")
            ElseIf OptionLhRhR = "RH" Then
                WritePlc("D", "4051", "2")
            End If

            If OptionTypeR = "STD" Then
                WritePlc("D", "4052", "1")
            ElseIf OptionTypeR = "FOLD" Then
                WritePlc("D", "4052", "2")
            ElseIf OptionTypeR = "VIP" Then
                WritePlc("D", "4052", "3")
            End If

            If OptionBackR = "PULLMA" Then
                WritePlc("D", "4053", "1")
            Else
                WritePlc("D", "4053", "2")
            End If

            If OptionFootRestR = True Then
                WritePlc("D", "4054", "1")
            Else
                WritePlc("D", "4054", "0")
            End If

            If OptionMonitorR = True Then
                WritePlc("D", "4055", "1")
            Else
                WritePlc("D", "4055", "0")
            End If
            WritePlc("D", "4056", "1")
            wStepR = 4

        ElseIf wStepR = 4 Then 'Check

            If srclbDecToolR.Text <> "OK" Then srclbDataToolR.Text = PlcValue(4002)

            If (srclbDecHarnessBarcodeR.Text = "OK" Or srclbDecHarnessBarcodeR.Text = "NA") And srclbDecToolR.Text = "OK" Then
                If TmpTool2NumR <> PlcValue(4002) Then
                    srclbDataTool2R.Text = CStr(AfterSCanToolNumR + 1)
                    AfterSCanToolNumR = CInt(srclbDataTool2R.Text)
                End If
            End If

            If (CInt(srclbDataToolR.Text) >= TargetToolNumR) And srclbDecToolR.Text <> "OK" Then
                srclbDecToolR.Text = "OK"
                srclbDecToolR.BackColor = Color.Blue
                AfterSCanToolNumR = 0
                DingDOng()
            End If

            Try
                If TargetToolNum2R = 0 Then
                    srclbDecTool2R.Text = "OK"
                    srclbDecTool2R.BackColor = Color.Blue
                Else
                    If (CInt(srclbDataTool2R.Text) >= TargetToolNum2R) And srclbDecTool2R.Text <> "OK" Then
                        srclbDecTool2R.Text = "OK"
                        srclbDecTool2R.BackColor = Color.Blue
                        DingDOng()
                    End If
                End If
                
            Catch ex As Exception
            End Try

            If (srclbDecToolR.Text = "OK" Or srclbDecToolR.Text = "NA") And
                (srclbDecTool2R.Text = "OK" Or srclbDecTool2R.Text = "NA") And
                (srclbDecLsuptBarcodeR.Text = "OK" Or srclbDecLsuptBarcodeR.Text = "NA") And
                (srclbDecLsuptVersionBarcodeR.Text = "OK" Or srclbDecLsuptVersionBarcodeR.Text = "NA") And
                (srclbDecHarnessBarcodeR.Text = "OK" Or srclbDecHarnessBarcodeR.Text = "NA") Then
                WritePlc("D", "4057", "1")
                wStepR = 5

            End If
            TmpTool2NumR = PlcValue(4002)

        ElseIf wStepR = 5 Then

            SaveDbR(srcLbSerialR.Text)
            wStepR = 6

        ElseIf wStepR = 6 Then

            If PlcValue(4001) = 1 Then
                WritePlc("D", "4051", "0000000")
                InitControlR()
                wStepR = 0
            End If

        End If

    End Sub

End Class