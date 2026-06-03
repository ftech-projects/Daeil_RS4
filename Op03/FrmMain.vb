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

    ' ActPlc 동적 생성 (디자이너 제거 후)
    Private WithEvents ActPlc As AxACTETHERLib.AxActQNUDECPUTCP

    Private FlagLError As Boolean
    Private FlagRError As Boolean
    Private AlarmMessage(100) As String
    Private TmpToolCount As Integer
    Private StartTImeL As String
    Private StartTImeR As String

    Private Tool1_Delay_count As Double
    Private Tool1_Ready As Boolean
    Private Tool_String1 As String
    Private Tool_Connection1 As Boolean
    Private Tool1_Count As Integer

    Private Tool2_Delay_count As Double
    Private Tool2_Ready As Boolean
    Private Tool_String2 As String
    Private Tool_Connection2 As Boolean
    Private Tool2_Count As Integer

    Private Tool3_Delay_count As Double
    Private Tool3_Ready As Boolean
    Private Tool_String3 As String
    Private Tool_Connection3 As Boolean
    Private Tool3_Count As Integer

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

    Private TargetMonitorBarcodeL As String
    Private TargetMonitorBarcodeR As String

    Private TargetMotorBarcodeL As String
    Private TargetMotorTqL As Boolean
    Private TargetToolNumL As Integer
    Private TargetSabBarcodeL As String
    Private TargetSabTqL As Boolean
    Private TargetSabResistL As Boolean
    Private TargetcSabBarcodeL As String
    Private TargetcSabTqL As Boolean
    Private TargetcSabResistL As Boolean
    
    Private TargetMotorBarcodeR As String
    Private TargetMotorTqR As Boolean
    Private TargetToolNumR As Integer
    Private TargetSabBarcodeR As String
    Private TargetSabTqR As Boolean
    Private TargetSabResistR As Boolean
    Private TargetcSabBarcodeR As String
    Private TargetcSabTqR As Boolean
    Private TargetcSabResistR As Boolean

    Private OptionLhRhR As String
    Private OptionTypeR As String
    Private OptionBackR As String
    Private OptionFootRestR As Boolean
    Private OptionMonitorR As Boolean
    
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

    ' Init_Grid: FlexCell 제거로 미사용 — 호출 없음, 주석 처리
    'Private Sub Init_Grid(ByVal GridName As DataGridView)
    '   ... (미사용)
    'End Sub

    Private Sub InitControlL()

        FlagLError = False
        LbAlarmLeft.Visible = False
        LoadPicture(srcPictureBoxL, "NON")
        srcLbPartNoL.Text = ""
        srcLbPartNameL.Text = ""
        srcLbPartOptionL.Text = ""
        srcLbSerialL.Text = ""

        srclbDataSabBarcodeL.Text = ""
        srclbDataSabTQ1L.Text = ""
        srclbDataSabTQ2L.Text = ""
        srclbDataSabTQ1L.BackColor = Color.Black
        srclbDataSabTQ2L.BackColor = Color.Black
        srclbDataSabResistL.Text = ""
        srclbDataMotorBarcodeL.Text = ""
        srclbdataMotorTqL.Text = ""

        srclbDecSabBarcodeL.Text = ""
        srclbDecSabTqL.Text = ""
        srclbDecSabResistL.Text = ""
        srclbDecMotorBarcodeL.Text = ""
        srclbDecMotorTqL.Text = ""

        srclbDecSabBarcodeL.BackColor = Color.Black
        srclbDecSabTqL.BackColor = Color.Black
        srclbDecSabResistL.BackColor = Color.Black
        srclbDecMotorBarcodeL.BackColor = Color.Black
        srclbDecMotorTqL.BackColor = Color.Black
        srclbdataMotorTqL.BackColor = Color.Black

        srclbTargetSabBarcodeL.Text = ""
        srclbTargetSabTqL.Text = BasicSabToolMin & " ~ " & BasicSabToolMax & " " & BAsicSabUnit
        srclbTargetSabResistL.Text = BasicResistMin & " ~ " & BasicResistMax & " " & "Ω"
        srclbTargetMotorBarcodeL.Text = ""
        srclbTargetMotorTqL.Text = BasicMotorToolMin & " ~ " & BasicMotorToolMax & " " & BAsicMotorUnit
        srclbTargetAirToolL.Text = ""

        srclbDataSabTQ1L.BackColor = Color.Black
        srclbDataSabTQ2L.BackColor = Color.Black

        srclbDataMonitorBarcodeL.Text = ""
        srclbTargetMonitorBarcodeL.Text = ""
        srclbDecMonitorBarcodeL.Text = ""
        srclbDecMonitorBarcodeL.BackColor = Color.Black

    End Sub

    Private Sub InitControlR()

        LoadPicture(srcPictureBoxR, "NON")
        srcLbPartNoR.Text = ""
        srcLbPartNameR.Text = ""
        srcLbPartOptionR.Text = ""
        srcLbSerialR.Text = ""

        srclbDataSabBarcodeR.Text = ""
        srclbDataSabTQ1R.Text = ""
        srclbDataSabTQ2R.Text = ""
        srclbDataSabResistR.Text = ""
        srclbDataCSabBarcodeR.Text = ""
        srclbDatacSabTQ1R.Text = ""
        srclbDatacSabTQ2R.Text = ""
        srclbDatacSabResistR.Text = ""
        
        srclbDecSabBarcodeR.Text = ""
        srclbDecSabTqR.Text = ""
        srclbDecSabResistR.Text = ""
        srclbDecCSabBarcodeR.Text = ""
        srclbDeccSabTqR.Text = ""
        srclbDeccSabResistR.Text = ""
        
        srclbDecSabBarcodeR.BackColor = Color.Black
        srclbDecSabTqR.BackColor = Color.Black
        srclbDecSabResistR.BackColor = Color.Black
        srclbDecCSabBarcodeR.BackColor = Color.Black
        srclbDeccSabTqR.BackColor = Color.Black
        srclbDeccSabResistR.BackColor = Color.Black
        
        srclbTargetSabBarcodeR.Text = ""
        srclbTargetSabTqR.Text = BasicSabToolMin & " ~ " & BasicSabToolMax & " " & BAsicSabUnit
        srclbTargetCSabBarcodeR.Text = ""
        srclbTargetcSabTqR.Text = BasicSabToolMin & " ~ " & BasicSabToolMax & " " & BAsicSabUnit
        srclbTargetSabResistR.Text = BasicResistMin & " ~ " & BasicResistMax & " " & "Ω"
        srclbTargetcSabResistR.Text = BasicResistMin & " ~ " & BasicResistMax & " " & "Ω"
        srclbTargetAirToolr.Text = ""

        srclbDataSabTQ1R.BackColor = Color.Black
        srclbDataSabTQ2R.BackColor = Color.Black
        srclbDatacSabTQ1R.BackColor = Color.Black
        srclbDatacSabTQ2R.BackColor = Color.Black

        srclbDataMonitorBarcodeR.Text = ""
        srclbTargetMonitorBarcodeR.Text = ""
        srclbDecMonitorBarcodeR.Text = ""
        srclbDecMonitorBarcodeR.BackColor = Color.Black

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

        Try
            If Serial_Tool1.IsOpen() = True Then
                Serial_Tool1.Close()
            End If
            Serial_Tool1.PortName = PortNumber_Tool1
            Serial_Tool1.BaudRate = 9600
            Serial_Tool1.DataBits = 8
            Serial_Tool1.Open()
            WriteTxtMessage("Serial Printer Open Success" & PortNumber_Tool1)
            Serial_Tool1.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3"))
            Serial_Tool1.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
            tmr_tool1.Interval = 5000
            tmr_tool1.Start()

        Catch ex As Exception
            WriteTxtMessage("Serial Printer Open Fail")
        End Try

        Try
            If Serial_Tool2.IsOpen() = True Then
                Serial_Tool2.Close()
            End If
            Serial_Tool2.PortName = PortNumber_Tool2
            Serial_Tool2.BaudRate = 9600
            Serial_Tool2.DataBits = 8
            Serial_Tool2.Open()
            WriteTxtMessage("Serial Printer Open Success" & PortNumber_Tool2)
            Serial_Tool2.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3"))
            Serial_Tool2.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
            tmr_Tool2.Interval = 5000
            tmr_Tool2.Start()

        Catch ex As Exception
            WriteTxtMessage("Serial Printer Open Fail")
        End Try

        Try
            If Serial_Tool3.IsOpen() = True Then
                Serial_Tool3.Close()
            End If
            Serial_Tool3.PortName = PortNumber_Tool3
            Serial_Tool3.BaudRate = 9600
            Serial_Tool3.DataBits = 8
            Serial_Tool3.Open()
            WriteTxtMessage("Serial Printer Open Success" & PortNumber_Tool3)
            Serial_Tool3.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3"))
            Serial_Tool3.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
            tmr_Tool3.Interval = 5000
            tmr_Tool3.Start()

        Catch ex As Exception
            WriteTxtMessage("Serial Printer Open Fail")
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
            'srclbTargetToolL.Text = CStr(TargetToolNumL)

            TargetSabBarcodeL = Trim(Rs.Fields("Target_Op02_Sab_Barcode").Value)
            TargetcSabBarcodeL = Trim(Rs.Fields("Target_Op02_cSab_Barcode").Value)
            TargetMotorBarcodeL = Trim(Rs.Fields("Target_Op02_motorBarcode").Value)

            TargetSabTqL = Rs.Fields("Use_Op02_Sab_Tq").Value
            TargetcSabTqL = Rs.Fields("Use_Op02_cSab_Tq").Value
            TargetSabResistL = Rs.Fields("Use_Op02_Sab_Resist").Value
            TargetcSabResistL = Rs.Fields("Use_Op02_cSab_Resist").Value
            TargetMotorTqL = Rs.Fields("Use_Op02_MotorTq").Value
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
            'srclbTargetToolR.Text = CStr(TargetToolNumR)

            TargetSabBarcodeR = Trim(Rs.Fields("Target_Op02_Sab_Barcode").Value)
            TargetcSabBarcodeR = Trim(Rs.Fields("Target_Op02_cSab_Barcode").Value)
            TargetMotorBarcodeR = Trim(Rs.Fields("Target_Op02_motorBarcode").Value)

            TargetSabTqR = Rs.Fields("Use_Op02_Sab_Tq").Value
            TargetcSabTqR = Rs.Fields("Use_Op02_cSab_Tq").Value
            TargetSabResistR = Rs.Fields("Use_Op02_Sab_Resist").Value
            TargetcSabResistR = Rs.Fields("Use_Op02_cSab_Resist").Value

            TargetMotorTqR = Rs.Fields("Use_Op02_MotorTq").Value
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
                    "Op02_2_DATE = '" & Format(Now, "yyyy-MM-dd") & "'," &
                    "Op02_2_STARTTIME = '" & StartTImeL & "'," &
                    "Op02_2_ENDTIME = '" & Format(Now, "HH:mm:ss") & "'," &
                    "Op02_2_Sab1Barcode = '" & srclbDataSabBarcodeL.Text & "'," &
                    "Op02_2_Sab1Tq1 = '" & srclbDataSabTQ1L.Text & "'," &
                    "Op02_2_Sab1Tq2 = '" & srclbDataSabTQ2L.Text & "'," &
                    "Op02_2_Sab1Resist = '" & srclbDataSabResistL.Text & "'," &
                    "Op02_2_Sab2Barcode = '" & "NA" & "'," &
                    "Op02_2_Sab2Tq1 = '" & "NA" & "'," &
                    "Op02_2_Sab2Tq2 = '" & "NA" & "'," &
                    "Op02_2_Sab2Resist = '" & "NA" & "'," &
                    "Op02_2_MotorBarcode = '" & srclbDataMotorBarcodeL.Text & "'," &
                    "Op02_2_MotorTq = '" & srclbdataMotorTqL.Text & "'," &
                    "Op02_2_MonitorBarcode = '" & srclbDataMonitorBarcodeL.Text & "'," &
                    "Op02_2_DECISION = '" & "OK" & "' " &
                    "WHERE SERIALNO = '" & strSerial & "'"

        SqlConnect.Execute(strSQL)
        ConnectionCloseSQL()

    End Sub

    Private Sub SaveDbR(ByVal strSerial As String)

        Dim strSQL As String = ""

        ConnectionOpenSQL()

        strSQL = "UPDATE TABLE_MAIN SET " &
                    "Op02_2_DATE = '" & Format(Now, "yyyy-MM-dd") & "'," &
                    "Op02_2_STARTTIME = '" & StartTImeR & "'," &
                    "Op02_2_ENDTIME = '" & Format(Now, "HH:mm:ss") & "'," &
                    "Op02_2_Sab1Barcode = '" & srclbDataSabBarcodeR.Text & "'," &
                    "Op02_2_Sab1Tq1 = '" & srclbDataSabTQ1R.Text & "'," &
                    "Op02_2_Sab1Tq2 = '" & srclbDataSabTQ2R.Text & "'," &
                    "Op02_2_Sab1Resist = '" & srclbDataSabResistR.Text & "'," &
                    "Op02_2_Sab2Barcode = '" & srclbDataCSabBarcodeR.Text & "'," &
                    "Op02_2_Sab2Tq1 = '" & srclbDatacSabTQ1R.Text & "'," &
                    "Op02_2_Sab2Tq2 = '" & srclbDatacSabTQ2R.Text & "'," &
                    "Op02_2_Sab2Resist = '" & srclbDatacSabResistR.Text & "'," &
                    "Op02_2_MotorBarcode = '" & "NA" & "'," &
                    "Op02_2_MotorTq = '" & "NA" & "'," &
                    "Op02_2_MonitorBarcode = '" & srclbDataMonitorBarcodeR.Text & "'," &
                    "Op02_2_DECISION = '" & "OK" & "' " &
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
        If TxtCount = 7 Then
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


    ''' <summary>ActPlc COM 컨트롤 동적 생성 (디자이너 의존 제거)</summary>
    Private Sub InitializeActPlc()
        ActPlc = New AxACTETHERLib.AxActQNUDECPUTCP()
        CType(ActPlc, System.ComponentModel.ISupportInitialize).BeginInit()
        ActPlc.Visible = False
        Me.Controls.Add(ActPlc)
        CType(ActPlc, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub

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

        If Serial_Tool1.IsOpen = True And Serial_Tool2.IsOpen = True And Serial_Tool3.IsOpen = True Then
            Trd1 = New Thread(AddressOf ThreadTask1)
            Trd1.IsBackground = True
            Trd1.Start()
        End If

        Tmr_Connect.Interval = 100
        Tmr_Connect.Start()
        wStepL = 0
        wStepR = 0

        WritePlc("D", "4251", "0000000")
        WritePlc("D", "4251", "0000000")

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

        szDeviceName = "D4200" & vbLf & "D4201" & vbLf & "D4202" & vbLf & "D4203" & vbLf & "D4204" & vbLf & "D4205" & vbLf & "D4206" & vbLf & "D4207" & vbLf & "D4208" & vbLf & "D4209" & vbLf &
                       "D4250" & vbLf & "D4251" & vbLf & "D4252" & vbLf & "D4253" & vbLf & "D4254" & vbLf & "D4255" & vbLf & "D4256" & vbLf & "D4257" & vbLf & "D4258" & vbLf & "D4259" & vbLf &
                       "D4300" & vbLf & "D4301" & vbLf & "D4302" & vbLf & "D4303" & vbLf & "D4304" & vbLf & "D4305" & vbLf & "D4306" & vbLf & "D4307" & vbLf & "D4308" & vbLf & "D4309" & vbLf &
                       "D4350" & vbLf & "D4351" & vbLf & "D4352" & vbLf & "D4353" & vbLf & "D4354" & vbLf & "D4355" & vbLf & "D4356" & vbLf & "D4357" & vbLf & "D4358" & vbLf & "D4359"
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
                PlcValue(i + 4200) = tmpPlcValue(i)
            Next
            For i = 10 To 19
                PlcValue(i + 4240) = tmpPlcValue(i)
            Next
            For i = 20 To 29
                PlcValue(i + 4280) = tmpPlcValue(i)
            Next
            For i = 30 To 39
                PlcValue(i + 4320) = tmpPlcValue(i)
            Next

            lbD4200.Text = PlcValue(4200)
            lbD4201.Text = PlcValue(4201)
            lbD4202.Text = PlcValue(4202)
            lbD4203.Text = PlcValue(4203)
            lbD4204.Text = PlcValue(4204)
            lbD4205.Text = PlcValue(4205)
            lbD4206.Text = PlcValue(4206)
            lbD4207.Text = PlcValue(4207)
            lbD4208.Text = PlcValue(4208)
            lbD4209.Text = PlcValue(4209)

            lbD4250.Text = PlcValue(4250)
            lbD4251.Text = PlcValue(4251)
            lbD4252.Text = PlcValue(4252)
            lbD4253.Text = PlcValue(4253)
            lbD4254.Text = PlcValue(4254)
            lbD4255.Text = PlcValue(4255)
            lbD4256.Text = PlcValue(4256)
            lbD4257.Text = PlcValue(4257)
            lbD4258.Text = PlcValue(4258)
            lbD4259.Text = PlcValue(4259)

            lbD4300.Text = PlcValue(4300)
            lbD4301.Text = PlcValue(4301)
            lbD4302.Text = PlcValue(4302)
            lbD4303.Text = PlcValue(4303)
            lbD4304.Text = PlcValue(4304)
            lbD4305.Text = PlcValue(4305)
            lbD4306.Text = PlcValue(4306)
            lbD4307.Text = PlcValue(4307)
            lbD4308.Text = PlcValue(4308)
            lbD4309.Text = PlcValue(4309)

            lbD4350.Text = PlcValue(4350)
            lbD4351.Text = PlcValue(4351)
            lbD4352.Text = PlcValue(4352)
            lbD4353.Text = PlcValue(4353)
            lbD4354.Text = PlcValue(4354)
            lbD4355.Text = PlcValue(4355)
            lbD4356.Text = PlcValue(4356)
            lbD4357.Text = PlcValue(4357)
            lbD4358.Text = PlcValue(4358)
            lbD4359.Text = PlcValue(4359)

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
            "P" & Mid(strLineSerial, 11, 5) & Mid(strLineSerial, 17, 5) & GS &
            "S" & "" & GS &
            "E" & "EOXXXX" & GS &
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

    Private Sub ThreadTask1()

        Dim Incoming1 As String
        Dim Incoming2 As String
        Dim Incoming3 As String
        Dim ToolData1 As Double
        Dim ToolData2 As Double
        Dim ToolData3 As Double

        Do While Serial_Tool1.IsOpen = True And Serial_Tool2.IsOpen = True And Serial_Tool3.IsOpen = True

            Try

                If Serial_Tool1.BytesToRead > 0 Then
                    Incoming1 = Serial_Tool1.ReadChar
                    If Incoming1 = 3 Then
                        If Len(Tool_String1) = 59 And Mid(Tool_String1, 6, 4) = "0002" Then
                            Serial_Tool1.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
                        ElseIf Len(Tool_String1) = 26 And Mid(Tool_String1, 6, 4) = "0005" Then
                            Serial_Tool1.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00209999            " & Chr("0") & Chr("3"))
                        ElseIf Len(Tool_String1) = 22 And Mid(Tool_String1, 6, 4) = "9999" Then
                            Tool_Connection1 = True
                        ElseIf Len(Tool_String1) > 200 And Mid(Tool_String1, 6, 4) = "0061" Then
                            Serial_Tool1.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200062            " & Chr("0") & Chr("3"))
                            ToolData1 = CDbl(Format(Val(Mid(Tool_String1, 143, 3) & "." & Mid(Tool_String1, 146, 2))))
                            WriteTxtMessage("Tool1 Data : " & ToolData1)

                            If wStepL = 4 Then

                                If srclbDecMotorTqL.Text <> "OK" Then
                                    If ToolData1 >= BasicMotorToolMin And ToolData1 <= BasicMotorToolMax And Mid(Tool_String1, 109, 1) = "1" Then
                                        srclbdataMotorTqL.Text = ToolData1
                                        srclbdataMotorTqL.BackColor = Color.Blue
                                        DingDOng()
                                        srclbDecMotorTqL.Text = "OK"
                                        srclbDecMotorTqL.BackColor = Color.Blue
                                    Else
                                        srclbdataMotorTqL.Text = ToolData1
                                        srclbdataMotorTqL.BackColor = Color.Red
                                        NG()
                                    End If
                                End If
                                '
                            End If
                        End If
                        Tool_String1 = ""
                        Serial_Tool1.DiscardInBuffer()
                    Else
                        Tool_String1 = Tool_String1 & Chr(Incoming1)
                    End If
                End If
            Catch ex As Exception
                Incoming1 = ""
                Tool_String1 = ""
            End Try

            Try

                If Serial_Tool2.BytesToRead > 0 Then
                    Incoming2 = Serial_Tool2.ReadChar
                    If Incoming2 = 3 Then
                        If Len(Tool_String2) = 59 And Mid(Tool_String2, 6, 4) = "0002" Then
                            Serial_Tool2.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
                        ElseIf Len(Tool_String2) = 26 And Mid(Tool_String2, 6, 4) = "0005" Then
                            Serial_Tool2.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00209999            " & Chr("0") & Chr("3"))
                        ElseIf Len(Tool_String2) = 22 And Mid(Tool_String2, 6, 4) = "9999" Then
                            Tool_Connection2 = True
                        ElseIf Len(Tool_String2) > 200 And Mid(Tool_String2, 6, 4) = "0061" Then
                            Serial_Tool2.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200062            " & Chr("0") & Chr("3"))
                            ToolData2 = CDbl(Format(Val(Mid(Tool_String2, 143, 3) & "." & Mid(Tool_String2, 146, 2))))
                            WriteTxtMessage("Tool2 Data : " & ToolData2)

                            If wStepL = 4 Then

                                If srclbDataSabTQ1L.BackColor <> Color.Blue And srclbDataSabTQ2L.BackColor <> Color.Blue Then

                                    If ToolData2 >= BasicSabToolMin And ToolData2 <= BasicSabToolMax And Mid(Tool_String2, 109, 1) = "1" Then
                                        srclbDataSabTQ1L.Text = ToolData2
                                        srclbDataSabTQ1L.BackColor = Color.Blue
                                        DingDOng()
                                    Else
                                        srclbDataSabTQ1L.Text = ToolData2
                                        srclbDataSabTQ1L.BackColor = Color.Red
                                        NG()
                                    End If

                                ElseIf srclbDataSabTQ1L.BackColor = Color.Blue And srclbDataSabTQ2L.BackColor <> Color.Blue Then

                                    If ToolData2 >= BasicSabToolMin And ToolData2 <= BasicSabToolMax And Mid(Tool_String2, 109, 1) = "1" Then
                                        srclbDataSabTQ2L.Text = ToolData2
                                        srclbDataSabTQ2L.BackColor = Color.Blue
                                        srclbDecSabTqL.Text = "OK"
                                        srclbDecSabTqL.BackColor = Color.Blue
                                        DingDOng()
                                    Else
                                        srclbDataSabTQ2L.Text = ToolData2
                                        srclbDataSabTQ2L.BackColor = Color.Red
                                        NG()
                                    End If

                                End If

                            End If
                            '
                        End If
                        Tool_String2 = ""
                        Serial_Tool2.DiscardInBuffer()
                    Else
                        Tool_String2 = Tool_String2 & Chr(Incoming2)
                    End If
                End If
            Catch ex As Exception
                Incoming2 = ""
                Tool_String2 = ""
            End Try

            Try

                If Serial_Tool3.BytesToRead > 0 Then
                    Incoming3 = Serial_Tool3.ReadChar
                    If Incoming3 = 3 Then
                        If Len(Tool_String3) = 59 And Mid(Tool_String3, 6, 4) = "0002" Then
                            Serial_Tool3.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
                        ElseIf Len(Tool_String3) = 26 And Mid(Tool_String3, 6, 4) = "0005" Then
                            Serial_Tool3.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00209999            " & Chr("0") & Chr("3"))
                        ElseIf Len(Tool_String3) = 22 And Mid(Tool_String3, 6, 4) = "9999" Then
                            Tool_Connection3 = True
                        ElseIf Len(Tool_String3) > 200 And Mid(Tool_String3, 6, 4) = "0061" Then
                            Serial_Tool3.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200062            " & Chr("0") & Chr("3"))
                            ToolData3 = CDbl(Format(Val(Mid(Tool_String3, 143, 3) & "." & Mid(Tool_String3, 146, 2))))
                            WriteTxtMessage("Tool3 Data : " & ToolData3)

                            If wStepR = 4 Then

                                If srclbDataSabTQ1R.BackColor <> Color.Blue And srclbDataSabTQ2R.BackColor <> Color.Blue And
                                    srclbDatacSabTQ1R.BackColor <> Color.Blue And srclbDatacSabTQ2R.BackColor <> Color.Blue Then
                                    If ToolData3 >= BasicSabToolMin And ToolData3 <= BasicSabToolMax And Mid(Tool_String3, 109, 1) = "1" And srclbDecSabBarcodeR.Text = "OK" Then
                                        srclbDataSabTQ1R.Text = ToolData3
                                        srclbDataSabTQ1R.BackColor = Color.Blue
                                        DingDOng()
                                    Else
                                        srclbDataSabTQ1R.Text = ToolData3
                                        srclbDataSabTQ1R.BackColor = Color.Red
                                        NG()
                                    End If

                                ElseIf srclbDataSabTQ1R.BackColor = Color.Blue And srclbDataSabTQ2R.BackColor <> Color.Blue And
                                    srclbDatacSabTQ1R.BackColor <> Color.Blue And srclbDatacSabTQ2R.BackColor <> Color.Blue Then

                                    If ToolData3 >= BasicSabToolMin And ToolData3 <= BasicSabToolMax And Mid(Tool_String3, 109, 1) = "1" And srclbDecSabBarcodeR.Text = "OK" Then
                                        srclbDataSabTQ2R.Text = ToolData3
                                        srclbDataSabTQ2R.BackColor = Color.Blue
                                        DingDOng()
                                        srclbDecSabTqR.Text = "OK"
                                        srclbDecSabTqR.BackColor = Color.Blue
                                    Else
                                        srclbDataSabTQ2R.Text = ToolData3
                                        srclbDataSabTQ2R.BackColor = Color.Red
                                        NG()
                                    End If

                                ElseIf srclbDataSabTQ1R.BackColor = Color.Blue And srclbDataSabTQ2R.BackColor = Color.Blue And
                                    srclbDatacSabTQ1R.BackColor <> Color.Blue And srclbDatacSabTQ2R.BackColor <> Color.Blue Then

                                    If ToolData3 >= BasicSabToolMin And ToolData3 <= BasicSabToolMax And Mid(Tool_String3, 109, 1) = "1" And srclbDecCSabBarcodeR.Text = "OK" Then
                                        srclbDatacSabTQ1R.Text = ToolData3
                                        srclbDatacSabTQ1R.BackColor = Color.Blue
                                        DingDOng()
                                    Else
                                        srclbDatacSabTQ1R.Text = ToolData3
                                        srclbDatacSabTQ1R.BackColor = Color.Red
                                        NG()
                                    End If

                                ElseIf srclbDataSabTQ1R.BackColor = Color.Blue And srclbDataSabTQ2R.BackColor = Color.Blue And
                                    srclbDatacSabTQ1R.BackColor = Color.Blue And srclbDatacSabTQ2R.BackColor <> Color.Blue Then

                                    If ToolData3 >= BasicSabToolMin And ToolData3 <= BasicSabToolMax And Mid(Tool_String3, 109, 1) = "1" And srclbDecCSabBarcodeR.Text = "OK" Then
                                        srclbDatacSabTQ2R.Text = ToolData3
                                        srclbDatacSabTQ2R.BackColor = Color.Blue
                                        DingDOng()
                                        srclbDeccSabTqR.Text = "OK"
                                        srclbDeccSabTqR.BackColor = Color.Blue
                                    Else
                                        srclbDatacSabTQ2R.Text = ToolData3
                                        srclbDatacSabTQ2R.BackColor = Color.Red
                                        NG()
                                    End If

                                End If

                            End If
                            '
                        End If
                        Tool_String3 = ""
                        Serial_Tool3.DiscardInBuffer()
                    Else
                        Tool_String3 = Tool_String3 & Chr(Incoming3)
                    End If
                End If
            Catch ex As Exception
                Incoming3 = ""
                Tool_String3 = ""
            End Try

            Application.DoEvents()

        Loop

    End Sub

    Private Sub Serial_ScannerL_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Serial_ScannerL.DataReceived

        Dim Incoming As String
        Dim ScanData As String
        Dim flagNG As Boolean = False

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

            If LbAlarmLeft.Visible = False Then
                If InStr(1, ScanData, TargetMotorBarcodeL) <> 0 And srclbDecMotorBarcodeL.Text <> "NA" Then
                    srclbDataMotorBarcodeL.Text = ScanData
                    srclbDecMotorBarcodeL.Text = "OK"
                    srclbDecMotorBarcodeL.BackColor = Color.Blue
                    DingDOng()
                    flagNG = True
                    FlagLError = False
                End If

                If InStr(1, ScanData, TargetSabBarcodeL) <> 0 And srclbDecSabBarcodeL.Text <> "NA" Then
                    srclbDataSabBarcodeL.Text = ScanData
                    srclbDecSabBarcodeL.Text = "OK"
                    srclbDecSabBarcodeL.BackColor = Color.Blue
                    DingDOng()
                    flagNG = True
                    FlagLError = False
                End If

                If InStr(1, ScanData, TargetMonitorBarcodeL) <> 0 And (srclbDecMonitorBarcodeL.Text <> "NA") Then
                    srclbDataMonitorBarcodeL.Text = ScanData
                    srclbDecMonitorBarcodeL.Text = "OK"
                    srclbDecMonitorBarcodeL.BackColor = Color.Blue
                    DingDOng()
                    flagNG = True
                    FlagLError = False
                End If

                If flagNG = False Then
                    FlagLError = True
                    NG()
                End If

            End If
            
        End If

    End Sub

    Private Sub Serial_ScannerR_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles Serial_ScannerR.DataReceived

        Dim Incoming As String
        Dim ScanData As String
        Dim FlagNG As Boolean = False

        Incoming = Serial_ScannerR.ReadLine()
        ScanData = Mid$(Incoming, 1, Len(Incoming) - 1)
        Serial_ScannerR.DiscardInBuffer()

        WriteTxtMessage("ScanDataR : " & ScanData)

        If FlagRError = False Then

            If wStepR = 1 Then

                If Len(ScanData) >= 23 Then
                    srcLbSerialR.Text = ScanData
                    LoadPArtR(ScanData)
                    wStepR = 2
                End If

            ElseIf wStepR = 4 Then

                If InStr(1, ScanData, TargetSabBarcodeR) <> 0 And srclbDecSabBarcodeR.Text <> "NA" Then
                    srclbDataSabBarcodeR.Text = ScanData
                    srclbDecSabBarcodeR.Text = "OK"
                    srclbDecSabBarcodeR.BackColor = Color.Blue
                    FlagNG = True
                    FlagRError = False
                    DingDOng()
                End If

                If InStr(1, ScanData, TargetcSabBarcodeR) <> 0 And srclbDecCSabBarcodeR.Text <> "NA" Then
                    srclbDataCSabBarcodeR.Text = ScanData
                    srclbDecCSabBarcodeR.Text = "OK"
                    srclbDecCSabBarcodeR.BackColor = Color.Blue
                    FlagNG = True
                    FlagRError = False
                    DingDOng()
                End If

                If InStr(1, ScanData, TargetMonitorBarcodeR) <> 0 And srclbDecMonitorBarcodeR.Text <> "NA" Then
                    srclbDataMonitorBarcodeR.Text = ScanData
                    srclbDecMonitorBarcodeR.Text = "OK"
                    srclbDecMonitorBarcodeR.BackColor = Color.Blue
                    DingDOng()
                    FlagRError = False
                    FlagNG = True
                End If

                If FlagNG = False Then
                    FlagRError = True
                    NG()
                End If

            End If
        End If
        

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

    Private Sub Tmr_Work1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Work1.Tick

        srclbStepL.Text = wStepL

        If PlcValue(4209) <> 0 And srclbAlarm.Visible = False Then
            srclbAlarm.Visible = True
            srclbAlarm.Text = AlarmMessage(CInt(PlcValue(4209)))
        ElseIf PlcValue(4209) = 0 And srclbAlarm.Visible = True Then
            srclbAlarm.Visible = False
        End If

        PcAliveCountL = PcAliveCountL + 1
        If PcAliveCountL = 10 Then
            WritePlc("D", "4250", "1")
        ElseIf PcAliveCountL = 20 Then
            WritePlc("D", "4250", "0")
            PcAliveCountL = 0
        End If

        If PlcValue(4200) = 0 And wStepL <> 0 Then
            WritePlc("D", "4251", "0000000")
            wStepL = 0
            InitControlL()
        End If

        If wStepL = 0 Then

            If PlcValue(4200) = 1 Then
                WritePlc("D", "4251", "0000000")
                InitControlL()
                wStepL = 1
            End If

        ElseIf wStepL = 1 Then '스캔대기

        ElseIf wStepL = 2 Then '스캔완료

            StartTImeL = Format(Now, "HH:mm:ss")

            srclbTargetSabBarcodeL.Text = TargetSabBarcodeL

            If TargetSabTqL = True Then
                srclbDataSabTQ1L.Text = ""
                srclbDataSabTQ2L.Text = ""
                srclbDecSabTqL.Text = ""
                srclbDecSabTqL.BackColor = Color.Black
            Else
                srclbDataSabTQ1L.Text = "NA"
                srclbDataSabTQ2L.Text = "NA"
                srclbDecSabTqL.Text = "NA"
                srclbDecSabTqL.BackColor = Color.Green
            End If

            If TargetMotorTqL = False Then
                srclbdataMotorTqL.Text = "NA"
                srclbDecMotorTqL.Text = "NA"
                srclbDecMotorTqL.BackColor = Color.Green
            End If

            If TargetMotorBarcodeL = "0" Then
                srclbDataMotorBarcodeL.Text = "NA"
                srclbDecMotorBarcodeL.Text = "NA"
                srclbDecMotorBarcodeL.BackColor = Color.Green
            Else
                srclbTargetMotorBarcodeL.Text = TargetMotorBarcodeL
            End If
            If TargetMonitorBarcodeL = "0" Then
                srclbDataMonitorBarcodeL.Text = "NA"
                srclbDecMonitorBarcodeL.Text = "NA"
                srclbDecMonitorBarcodeL.BackColor = Color.Green
            Else
                srclbTargetMonitorBarcodeL.Text = TargetMonitorBarcodeL
            End If

            wStepL = 3
            
        ElseIf wStepL = 3 Then

            FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, Mid(srcLbPartNoL.Text, 1, 11))
            wStepL = 3.1

        ElseIf wStepL = 3.1 Then 'Send PLC Option

            If OptionLhRhL = "LH" Then
                WritePlc("D", "4251", "1")
            ElseIf OptionLhRhL = "RH" Then
                WritePlc("D", "4251", "2")
            End If

            If OptionTypeL = "STD" Then
                WritePlc("D", "4252", "1")
            ElseIf OptionTypeL = "FOLD" Then
                WritePlc("D", "4252", "2")
            ElseIf OptionTypeL = "VIP" Then
                WritePlc("D", "4252", "3")
            End If

            If OptionBackL = "PULLMA" Then
                WritePlc("D", "4253", "1")
            Else
                WritePlc("D", "4253", "2")
            End If

            If OptionFootRestL = True Then
                WritePlc("D", "4254", "1")
            Else
                WritePlc("D", "4254", "0")
            End If

            If OptionMonitorL = True Then
                WritePlc("D", "4255", "1")
            Else
                WritePlc("D", "4255", "0")
            End If
            WritePlc("D", "4256", "1")
            wStepL = 4

        ElseIf wStepL = 4 Then 'Check

            'If srclbDecToolL.Text <> "OK" Then srclbDataToolL.Text = PlcValue(4102)

            'If (CInt(srclSbDataToolL.Text) = TargetToolNumL) And srclbDecToolL.Text <> "OK" Then
            '    srclbDecToolL.Text = "OK"
            '    srclbDecToolL.BackColor = Color.Blue
            '    DingDOng()
            'End If

            'If srclbDecToolL.Text = "OK" Then
            '    WritePlc("D", "4257", "1")
            '    wStepL = 5
            'End If

            If FlagLError = True And LbAlarmLeft.Visible = False Then
                LbAlarmLeft.Visible = True
            End If

            If LbAlarmLeft.Visible = False Then
                If (srclbDecSabTqL.Text = "OK" Or srclbDecSabTqL.Text = "NA") And
               (srclbDecSabBarcodeL.Text = "OK" Or srclbDecSabBarcodeL.Text = "NA") And
               (srclbDecMotorBarcodeL.Text = "OK" Or srclbDecMotorBarcodeL.Text = "NA") And
               (srclbDecMonitorBarcodeL.Text = "OK" Or srclbDecMonitorBarcodeL.Text = "NA") And
               (srclbDecMotorTqL.Text = "OK" Or srclbDecMotorTqL.Text = "NA") Then
                    WritePlc("D", "4257", "1")
                    wStepL = 5
                End If
            End If
            
        ElseIf wStepL = 5 Then

            SaveDbL(srcLbSerialL.Text)
            wStepL = 6

        ElseIf wStepL = 6 Then

            If PlcValue(4201) = 1 Then
                WritePlc("D", "4251", "0000000")
                InitControlL()
                wStepL = 0
            End If

        End If

    End Sub

    Private Sub Tmr_Work2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Work2.Tick

        srclbStepR.Text = wStepR

        PcAliveCountR = PcAliveCountR + 1
        If PcAliveCountR = 10 Then
            WritePlc("D", "4350", "1")
        ElseIf PcAliveCountR = 20 Then
            WritePlc("D", "4350", "0")
            PcAliveCountR = 0
        End If

        If PlcValue(4300) = 0 And wStepR <> 0 Then
            wStepR = 0
            WritePlc("D", "4351", "0000000")
            InitControlR()
        End If

        If wStepR = 0 Then

            If PlcValue(4300) = 1 Then
                WritePlc("D", "4351", "0000000")
                InitControlR()
                wStepR = 1
            End If

        ElseIf wStepR = 1 Then '스캔대기

        ElseIf wStepR = 2 Then '스캔완료

            StartTImeR = Format(Now, "HH:mm:ss")

            srclbTargetSabBarcodeR.Text = TargetSabBarcodeR
            srclbTargetCSabBarcodeR.Text = TargetcSabBarcodeR
            
            If TargetSabTqR = True Then
                srclbDataSabTQ1R.Text = ""
                srclbDataSabTQ2R.Text = ""
                srclbDecSabTqR.Text = ""
                srclbDecSabTqR.BackColor = Color.Black
            Else
                srclbDataSabTQ1R.Text = "NA"
                srclbDataSabTQ2R.Text = "NA"
                srclbDecSabTqR.Text = "NA"
                srclbDecSabTqR.BackColor = Color.Green
            End If

            If TargetcSabTqR = True Then
                srclbDatacSabTQ1R.Text = ""
                srclbDatacSabTQ2R.Text = ""
                srclbDeccSabTqR.Text = ""
                srclbDeccSabTqR.BackColor = Color.Black
            Else
                srclbDatacSabTQ1R.Text = "NA"
                srclbDatacSabTQ2R.Text = "NA"
                srclbDeccSabTqR.Text = "NA"
                srclbDeccSabTqR.BackColor = Color.Green
            End If
            If TargetMonitorBarcodeR = "0" Then
                srclbDataMonitorBarcodeR.Text = "NA"
                srclbDecMonitorBarcodeR.Text = "NA"
                srclbDecMonitorBarcodeR.BackColor = Color.Green
            Else
                srclbTargetMonitorBarcodeR.Text = TargetMonitorBarcodeR
            End If
            wStepR = 3

        ElseIf wStepR = 3 Then

            FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, srcLbPartNoR.Text)
            wStepR = 3.1

        ElseIf wStepR = 3.1 Then 'Send PLC Option

            If OptionLhRhR = "LH" Then
                WritePlc("D", "4351", "1")
            ElseIf OptionLhRhR = "RH" Then
                WritePlc("D", "4351", "2")
            End If

            If OptionTypeR = "STD" Then
                WritePlc("D", "4352", "1")
            ElseIf OptionTypeR = "FOLD" Then
                WritePlc("D", "4352", "2")
            ElseIf OptionTypeR = "VIP" Then
                WritePlc("D", "4352", "3")
            End If

            If OptionBackR = "PULLMA" Then
                WritePlc("D", "4353", "1")
            Else
                WritePlc("D", "4353", "2")
            End If

            If OptionFootRestR = True Then
                WritePlc("D", "4354", "1")
            Else
                WritePlc("D", "4354", "0")
            End If

            If OptionMonitorR = True Then
                WritePlc("D", "4355", "1")
            Else
                WritePlc("D", "4355", "0")
            End If
            WritePlc("D", "4356", "1")
            wStepR = 4

        ElseIf wStepR = 4 Then 'Check

            'If srclbdec Then
            'If srclbDecToolR.Text <> "OK" Then srclbDataToolR.Text = PlcValue(4002)
            'If (CInt(srclbDataToolR.Text) = TargetToolNumR) And srclbDecToolR.Text <> "OK" Then
            '    srclbDecToolR.Text = "OK"
            '    srclbDecToolR.BackColor = Color.Blue
            '    DingDOng()
            'End If
            'If srclbDecToolR.Text = "OK" Then
            '    WritePlc("D", "4257", "1")
            '    wStepR = 5
            'End If

            If FlagRError = True And LbAlarmRight.Visible = False Then
                LbAlarmRight.Visible = True

            End If
            If (srclbDecSabTqR.Text = "OK" Or srclbDecSabTqR.Text = "NA") And
               (srclbDeccSabTqR.Text = "OK" Or srclbDeccSabTqR.Text = "NA") And
               (srclbDecSabBarcodeR.Text = "OK" Or srclbDecSabBarcodeR.Text = "NA") And
               (srclbDecMonitorBarcodeR.Text = "OK" Or srclbDecMonitorBarcodeR.Text = "NA") And
               (srclbDecCSabBarcodeR.Text = "OK" Or srclbDecCSabBarcodeR.Text = "NA") Then
                WritePlc("D", "4357", "1")
                wStepR = 5
            End If

        ElseIf wStepR = 5 Then

            SaveDbR(srcLbSerialR.Text)
            wStepR = 6

        ElseIf wStepR = 6 Then

            If PlcValue(4001) = 1 Then
                WritePlc("D", "4351", "0000000")
                InitControlR()
                wStepR = 0
            End If

        End If

    End Sub

    Private Sub tmr_Tool1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_Tool1.Tick
        If Tool_Connection1 = False Then
            Tool_Connection1 = True
            Serial_Tool1.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "002099990010" & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr("0") & Chr("3"))
        ElseIf Tool_Connection1 = True Then
            Serial_Tool1.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3") &
            Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
        End If
    End Sub

    Private Sub tmr_Tool2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_Tool2.Tick
        If Tool_Connection2 = False Then
            Tool_Connection2 = True
            Serial_Tool2.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "002099990010" & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr("0") & Chr("3"))
        ElseIf Tool_Connection2 = True Then
            Serial_Tool2.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3") &
            Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
        End If
    End Sub

    Private Sub tmr_Tool3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_Tool3.Tick
        If Tool_Connection3 = False Then
            Tool_Connection3 = True
            Serial_Tool3.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "002099990010" & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr(20) & Chr("0") & Chr("3"))
        ElseIf Tool_Connection3 = True Then
            Serial_Tool3.Write(Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200001            " & Chr("0") & Chr("3") &
            Chr("7") & Chr("9") & Chr("7") & Chr("9") & Chr("2") & "00200060            " & Chr("0") & Chr("3"))
        End If
    End Sub

    Private Sub LbAlarmLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LbAlarmLeft.Click
        LbAlarmLeft.Visible = False
        FlagLError = False
    End Sub

    Private Sub LbAlarmRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LbAlarmRight.Click
        LbAlarmRight.Visible = False
        FlagRError = False
    End Sub
End Class