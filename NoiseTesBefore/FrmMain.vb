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
Imports Automation.BDaq
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO.Ports
Imports System.Reflection
Imports NationalInstruments
Imports NationalInstruments.DAQmx

Public Class FrmMain

    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"

    Public PlcValue(0 To 5000) As Integer

    Public AddressOfPLc As String
    Public FlagPlcConnection As Boolean
    Public PlcConnectionError As String
    Public PlcConnectionStep As Integer

    Private ArryMaxSize As Integer = 100000
    Private ArryCount1 As Int64
    Private ArryAmp1(ArryMaxSize) As Double
    Private ArryNoise1(ArryMaxSize) As Double
    Private ArryTime1(ArryMaxSize) As Double

    Private ArryCount2 As Int64
    Private ArryAmp2(ArryMaxSize) As Double
    Private ArryNoise2(ArryMaxSize) As Double
    Private ArryTime2(ArryMaxSize) As Double

    Private ArryCountR As Int64
    Private ArryAmpR(ArryMaxSize) As Double
    Private ArryNoiseR(ArryMaxSize) As Double
    Private ArryTimeR(ArryMaxSize) As Double

    Private ArryCountL As Int64
    Private ArryAmpL(ArryMaxSize) As Double
    Private ArryNoiseL(ArryMaxSize) As Double
    Private ArryTimeL(ArryMaxSize) As Double

    Private CounterAtStartR As Int64 = 0
    Private CounterAtStartL As Int64 = 0
    Private CounterAtNowR As Int64 = 0
    Private CounterAtNowL As Int64 = 0

    Private CounterAtStart1 As Int64 = 0
    Private CounterAtMiddle1 As Int64 = 0
    Private CounterAtNow1 As Int64 = 0
    Private CounterAtStart2 As Int64 = 0
    Private CounterAtMiddle2 As Int64 = 0
    Private CounterAtNow2 As Int64 = 0

    Private TotalTimeR As Double = 0
    Private ErrCountR As Double
    Private TmpAmpMAxR As Double
    Private TmpNoiseMaxr As Double

    Private TotalTimeL As Double = 0
    Private ErrCountL As Double
    Private TmpAmpMAxL As Double
    Private TmpAmpMinL As Double
    Private TmpNoiseMaxL As Double

    Private TotalTime1 As Double = 0
    Private TotalTime2 As Double = 0
    Private ErrCount1 As Double
    Private ErrCount2 As Double

    Private TmpAmpMAx1 As Double
    Private TmpNoiseMax1 As Double

    Private TmpAmpMAx2 As Double
    Private TmpNoiseMax2 As Double

    Private CalcCount1 As Double
    Private CalcCount2 As Double
    Private CalcCountR As Double
    Private CalcCountL As Double

    Private RequestStep1 As Integer
    Private RequestStep2 As Integer
    Private RequestCount1 As Double
    Private RequestCount2 As Double

    Private REcl_Step As Double
    Private LSupt_Step As Double

    Private Arry1Count As Int64
    Private Arry1Amp(10000000) As Double
    Private Arry1Amp2(10000000) As Double
    Private Arry1Noise(10000000) As Double
    Private Arry1Time(10000000) As Double

    Private Arry2Count As Int64
    Private Arry2Amp(10000000) As Double
    Private Arry2Noise(10000000) As Double
    Private Arry2Time(10000000) As Double


    Private IO_LIMIT_FWD As Integer
    Private IO_LIMIT_FWD_STATE As Integer
    Private IO_LIMIT_BWD As Integer
    Private IO_LIMIT_BWD_STATE As Integer

    Private IO_RECL_FWD As Integer
    Private IO_RECL_BWD As Integer
    Private IO_LSUPT_FWD As Integer
    Private IO_LSUPT_BWD As Integer

    Private TmrCount As Double
    Private RstCount As Double
    Private RstStep As Double

    Private ManualRunStep As Double

    Private tmpNoise1 As Double
    Private tmpLaser As Double
    Private tmpLaser2 As Double

    Private ANGLE() As Double
    Private LASER() As Double

    Private ANGLE_FREST() As Double
    Private LASER_FREST() As Double

    Private OPTION_LHRH As String
    Private OPTION_RECL As String
    Private OPTION_LSUPT As String
    Private OPTION_FREST As String
    Private OPTION_FRAME As String
    Private OPTION_TYPE As String

    Private TARGET_SAB_SN As String
    Private TARGET_LSUPT_SN As String

    Private TARGET_RECL_SN As String

    Private Err_Count As Double

    Private AMPMAX As Double
    Private AMPMAX2 As Double

    Private NOISEMAX As Double
    Private NOISEMAX2 As Double

    Private LoadMAX As Double
    Private LoadMin As Double
    Private LoadCount As Double
    Private LoadLockStartValue As Double
    Private LoadAvrSum As Double
    Private LoadAvrCount As Double

    Private CounterAtStart As Int64 = 0
    Private CounterAtMiddle As Int64 = 0
    Private CounterAtNow As Int64 = 0
    
    Private TotalTime As Double = 0
    Private TmpTime As Double = 0

    Private SUM_AMP As Double
    Private SUM_AMP2 As Double
    Private SUM_LASER As Double
    Private SUM_LASER2 As Double
    Private SUM_NOISE As Double
    Private DATA_AMP As Double()
    Private DATA_AMP2 As Double()
    Private DATA_LASER As Double()
    Private DATA_LASER2 As Double()
    Private DATA_NOISE As Double()

    Public TestMode As String

    Private Stop_Count As Integer
    Private Before_Laser As Double
    Private Timer As New HiResTimer()
    Private Tmp_Count As Double

    Public TestStep As Double
    
    Private D_Value(0 To 16) As Integer
    Private Out_(0 To 16) As Integer
    Private IO_IN_LABEL(16) As Label
    Private IO_OUT_LABEL(16) As Label

    Private ReworkStr As String
    Private WorkPArt As String

    Private tStep1 As Double
    Private tError1 As String
    Private PLC_STRING_1 As String
    Private tCount As Integer
    Private StartTime As String
    Private EndTime As String
    Private SELECT_PART As String
    Private wStep As Double
    Private rStep As Double
    Private Lstep As Double
    Private Address_Connection_PLC1 As String
    Private Flag_Connection_PLC1 As Boolean

    Private IN_LABEL(10) As Label
    Private OUT_LABEL(10) As Label
    Private VALUE_IN_LABEL(10) As Label
    Private VALUE_OUT_LABEL(10) As Label

    Private RFID_PortNO As Long
    Private Recv_Count As Double
    Private Flag_Connection As Boolean
    Private Trd1 As Thread
    Private Trd2 As Thread
    Private Trd3 As Thread

    Private RecvString As New System.Text.StringBuilder()
    Private RecvString_CAN As New System.Text.StringBuilder()

    Private RequestAmp1Step As Double
    Private RequestAmp2Step As Double

    Private Sub Control2Arry()

        IO_IN_LABEL(0) = P_IN_00
        IO_IN_LABEL(1) = P_IN_01
        IO_IN_LABEL(2) = P_IN_02
        IO_IN_LABEL(3) = P_IN_03
        IO_IN_LABEL(4) = P_IN_04
        IO_IN_LABEL(5) = P_IN_05
        IO_IN_LABEL(6) = P_IN_06
        IO_IN_LABEL(7) = P_IN_07

        IO_IN_LABEL(8) = P_IN_08
        IO_IN_LABEL(9) = P_IN_09
        IO_IN_LABEL(10) = P_IN_10
        IO_IN_LABEL(11) = P_IN_11
        IO_IN_LABEL(12) = P_IN_12
        IO_IN_LABEL(13) = P_IN_13
        IO_IN_LABEL(14) = P_IN_14
        IO_IN_LABEL(15) = P_IN_15

        IO_OUT_LABEL(0) = P_OUT_00
        IO_OUT_LABEL(1) = P_OUT_01
        IO_OUT_LABEL(2) = P_OUT_02
        IO_OUT_LABEL(3) = P_OUT_03
        IO_OUT_LABEL(4) = P_OUT_04
        IO_OUT_LABEL(5) = P_OUT_05
        IO_OUT_LABEL(6) = P_OUT_06
        IO_OUT_LABEL(7) = P_OUT_07

        IO_OUT_LABEL(8) = P_OUT_08
        IO_OUT_LABEL(9) = P_OUT_09
        IO_OUT_LABEL(10) = P_OUT_10
        IO_OUT_LABEL(11) = P_OUT_11
        IO_OUT_LABEL(12) = P_OUT_12
        IO_OUT_LABEL(13) = P_OUT_13
        IO_OUT_LABEL(14) = P_OUT_14
        IO_OUT_LABEL(15) = P_OUT_15

    End Sub

    Private Function StrPtr(ByVal x As String) As Integer
        Return VarPtr(x)
    End Function

    Private Function VarPtr(ByVal obj As Object) As Integer
        ' Obtain a pinned handle to the object
        Dim handle As GCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned)
        Dim pointer As Integer = handle.AddrOfPinnedObject.ToInt32

        ' Free the allocated handle. At this point the GC can move the object in memory, this is 
        ' why this function does not exist in .NET. If you were to use this pointer as a destination 
        ' for memcopy for example, you could overwrite unintended memory, which would crash the 
        ' application or cause unexpected behavior. For this function to work you would need to
        ' maintain the handle until after you are finished using it.
        handle.Free()

        Return pointer
    End Function

    Sub SerialOpen()

        Try
            If Serial_Supply1.IsOpen() = True Then
                Serial_Supply1.Close()
                Serial_Supply1.PortName = PortNumberAmp1
                Serial_Supply1.Parity = Ports.Parity.None
                Serial_Supply1.Handshake = Ports.Handshake.XOnXOff
                Serial_Supply1.BaudRate = 9600
                Serial_Supply1.StopBits = Ports.StopBits.One
                Serial_Supply1.DataBits = 8
                Serial_Supply1.Open()
            Else
                Serial_Supply1.PortName = PortNumberAmp1
                Serial_Supply1.Parity = Ports.Parity.None
                Serial_Supply1.Handshake = Ports.Handshake.XOnXOff
                Serial_Supply1.BaudRate = 9600
                Serial_Supply1.StopBits = Ports.StopBits.One
                Serial_Supply1.DataBits = 8
                Serial_Supply1.Open()
            End If
            Serial_Supply1.WriteLine("*ADR 1")
            RequestStep1 = 0
        Catch ex As Exception
            MsgBox("Serial Open Supply1  Fail " & PortNumberAmp1)
        End Try

        Try
            If Serial_Supply2.IsOpen() = True Then
                Serial_Supply2.Close()
                Serial_Supply2.PortName = PortNumberAmp2
                Serial_Supply2.Parity = Ports.Parity.None
                Serial_Supply2.Handshake = Ports.Handshake.XOnXOff
                Serial_Supply2.BaudRate = 9600
                Serial_Supply2.StopBits = Ports.StopBits.One
                Serial_Supply2.DataBits = 8
                Serial_Supply2.Open()
            Else
                Serial_Supply2.PortName = PortNumberAmp2
                Serial_Supply2.Parity = Ports.Parity.None
                Serial_Supply2.Handshake = Ports.Handshake.XOnXOff
                Serial_Supply2.BaudRate = 9600
                Serial_Supply2.StopBits = Ports.StopBits.One
                Serial_Supply2.DataBits = 8
                Serial_Supply2.Open()
            End If
            Serial_Supply2.WriteLine("*ADR 1")
            RequestStep2 = 0
        Catch ex As Exception
            MsgBox("Serial Open Supply2  Fail " & PortNumberAmp2)
        End Try

        Try
            SerialScanner.PortName = PortNumberScanner
            If SerialScanner.IsOpen() = True Then
                SerialScanner.Close()
                SerialScanner.DataBits = 8
                SerialScanner.Open()
            Else
                SerialScanner.BaudRate = 9600
                SerialScanner.DataBits = 8
                SerialScanner.Open()
            End If
        Catch ex As Exception
            MsgBox("Serial Open Scanner1 Fail " & PortNumberScanner)
        End Try

        Try
            SerialPrinter.PortName = PortNumberPrinter
            If SerialPrinter.IsOpen() = True Then
                SerialPrinter.Close()
                SerialPrinter.DataBits = 8
                SerialPrinter.Open()
            Else
                SerialPrinter.BaudRate = 9600
                SerialPrinter.DataBits = 8
                SerialPrinter.Open()
            End If
        Catch ex As Exception
            MsgBox("Serial Open Printer Fail " & PortNumberPrinter)
        End Try

    End Sub

    Private Sub ThreadTask1()

        Dim Incoming1 As String = ""
        Dim Incoming2 As String = ""
        Dim RecvString1 As String = ""
        Dim RecvString2 As String = ""

        Do
            Try
                If Serial_Supply1.IsOpen = True Then
                    If Serial_Supply1.BytesToRead > 0 Then
                        Incoming1 = Serial_Supply1.ReadChar
                        If Incoming1 = 13 Then
                            If RequestStep1 = 1 Then
                                ValueVolt1 = CDbl(RecvString1)
                                RequestStep1 = 2
                            ElseIf RequestStep1 = 3 Then
                                ValueAmp1 = CDbl(RecvString1)
                                RequestStep1 = 0
                            End If
                            RecvString1 = ""
                            Serial_Supply1.DiscardInBuffer()
                        Else
                            RecvString1 = RecvString1 & Chr(Incoming1)
                        End If
                    End If
                End If
            Catch ex As Exception
                RecvString1 = ""
                RequestStep1 = 0
            End Try

            Try
                If Serial_Supply2.IsOpen = True Then
                    If Serial_Supply2.BytesToRead > 0 Then
                        Incoming2 = Serial_Supply2.ReadChar
                        If Incoming2 = 13 Then
                            If RequestStep2 = 1 Then
                                ValueVolt2 = CDbl(RecvString2)
                                RequestStep2 = 2
                            ElseIf RequestStep2 = 3 Then
                                ValueAmp2 = CDbl(RecvString2)
                                RequestStep2 = 0
                            End If
                            RecvString2 = ""
                            Serial_Supply2.DiscardInBuffer()
                        Else
                            RecvString2 = RecvString2 & Chr(Incoming2)
                        End If
                    End If
                End If
            Catch ex As Exception
                RecvString2 = ""
                RequestStep2 = 0
            End Try

            Application.DoEvents()

        Loop

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory & "\OnKeyboard.exe")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmPort.Show()
    End Sub

    Private Sub LoadPicture(ByVal picTarget As PictureBox, ByVal picName As String)

        Try
            picTarget.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\Image\" & picName & ".png")
        Catch ex As Exception
        End Try

        'LoadPicture(Picture_Main, "ASSEMBLE\NHGT")

    End Sub

    Private Sub InitControl()

        srclbType.Text = ""
        srcLbPartNo.Text = ""
        srcLbPartName.Text = ""
        srcLbSerial.Text = ""

    End Sub

    Private Sub InitTest()

        srclbTotalDecision.Text = ""
        srclbTotalDecision.BackColor = Color.Black

        srclbValReclFwdSpeed.Text = ""
        srclbValReclBwdSpeed.Text = ""

        srclbValReclFwdNoise.Text = ""
        srclbValReclFwdAmp.Text = ""
        srclbValReclFwdAngle.Text = ""
        srclbValReclEndAngle.Text = ""

        srclbDecReclFwdNoise.Text = ""
        srclbDecReclFwdAmp.Text = ""
        srclbDecReclFwdAngle.Text = ""
        srclbDecReclEndAngle.Text = ""

        srclbDecReclFwdNoise.BackColor = Color.Black
        srclbDecReclFwdAmp.BackColor = Color.Black
        srclbDecReclFwdAngle.BackColor = Color.Black
        srclbDecReclEndAngle.BackColor = Color.Black

        srclbValReclBwdNoise.Text = ""
        srclbValReclBwdAmp.Text = ""
        srclbValReclBwdAngle.Text = ""

        srclbDecReclBwdNoise.Text = ""
        srclbDecReclBwdAmp.Text = ""
        srclbDecReclBwdAngle.Text = ""

        srclbDecReclBwdNoise.BackColor = Color.Black
        srclbDecReclBwdAmp.BackColor = Color.Black
        srclbDecReclBwdAngle.BackColor = Color.Black

        srcGraphReclFNoise.ClearData()
        srcGraphReclFAmp.ClearData()
        srcGraphReclBNoise.ClearData()
        srcGraphReclBAmp.ClearData()

        srclbValFrestFwdNoise.Text = ""
        srclbValFrestFwdAmp.Text = ""
        srclbDecFrestFwdNoise.Text = ""
        srclbDecFrestFwdAmp.Text = ""
        srclbDecFrestFwdNoise.BackColor = Color.Black
        srclbDecFrestFwdAmp.BackColor = Color.Black

        srclbSpecFrestBwdNoise.Text = ""
        srclbSpecFrestBwdAmp.Text = ""
        srclbValFrestBwdNoise.Text = ""
        srclbValFrestBwdAmp.Text = ""
        srclbDecFrestBwdNoise.Text = ""
        srclbDecFrestBwdAmp.Text = ""
        srclbDecFrestBwdNoise.BackColor = Color.Black
        srclbDecFrestBwdAmp.BackColor = Color.Black

        srclbValFrestFwdSpeed.Text = ""
        srclbValFrestBwdSpeed.Text = ""

        srclbDecFrestFwdSpeed.Text = ""
        srclbDecFrestBwdSpeed.Text = ""
        srclbDecFrestFwdSpeed.BackColor = Color.Black
        srclbDecFrestBwdSpeed.BackColor = Color.Black

        srcGraphFrestFNoise.ClearData()
        srcGraphFrestFAmp.ClearData()
        srcGraphFrestBNoise.ClearData()
        srcGraphFrestBAmp.ClearData()

        srclbSpecReclFwdAmp.Text = BasicReclFwdAmpMin & " ~ " & BasicReclFwdAmpMax
        srclbSpecReclBwdAmp.Text = BasicReclBwdAmpMin & " ~ " & BasicReclBwdAmpMax
        srclbSpecReclFwdNoise.Text = BasicReclFwdNoiseMin & " ~ " & BasicReclFwdNoiseMax
        srclbSpecReclBwdNoise.Text = BasicReclBwdNoiseMin & " ~ " & BasicReclBwdNoiseMax

        srclbSpecFrestFwdAmp.Text = BasicFrestFwdAmpMin & " ~ " & BasicFrestFwdAmpMax
        srclbSpecFrestBwdAmp.Text = BasicFrestBwdAmpMin & " ~ " & BasicFrestBwdAmpMax
        srclbSpecFrestFwdNoise.Text = BasicFrestFwdNoiseMin & " ~ " & BasicFrestFwdNoiseMax
        srclbSpecFrestBwdNoise.Text = BasicFrestBwdNoiseMin & " ~ " & BasicFrestBwdNoiseMax

        srclbSpecReclFwdSpeed.Text = BasicReclFwdSpeedMin & " ~ " & BasicReclFwdSpeedMax
        srclbSpecReclBwdSpeed.Text = BasicReclBwdSpeedMin & " ~ " & BasicReclBwdSpeedMax

        srclbSpecFrestFwdSpeed.Text = BasicFrestFwdSpeedMin & " ~ " & BasicFrestFwdSpeedMax
        srclbSpecFrestBwdSpeed.Text = BasicFrestBwdSpeedMin & " ~ " & BasicFrestBwdSpeedMax

        srcGraphFrestFAmp.Cursors.Item(2).YPosition = BasicFrestFwdAmpMin
        srcGraphFrestFAmp.Cursors.Item(3).YPosition = BasicFrestFwdAmpMax
        srcGraphFrestBAmp.Cursors.Item(2).YPosition = BasicFrestBwdAmpMin
        srcGraphFrestBAmp.Cursors.Item(3).YPosition = BasicFrestBwdAmpMax

        srcGraphFrestFNoise.Cursors.Item(2).YPosition = BasicFrestFwdNoiseMin
        srcGraphFrestFNoise.Cursors.Item(3).YPosition = BasicFrestFwdNoiseMax
        srcGraphFrestBNoise.Cursors.Item(2).YPosition = BasicFrestBwdNoiseMin
        srcGraphFrestBNoise.Cursors.Item(3).YPosition = BasicFrestBwdNoiseMax

        srcGraphReclFAmp.Cursors.Item(2).YPosition = BasicReclFwdAmpMin
        srcGraphReclFAmp.Cursors.Item(3).YPosition = BasicReclFwdAmpMax
        srcGraphReclBAmp.Cursors.Item(2).YPosition = BasicReclBwdAmpMin
        srcGraphReclBAmp.Cursors.Item(3).YPosition = BasicReclBwdAmpMax

        srcGraphReclFNoise.Cursors.Item(2).YPosition = BasicReclFwdNoiseMin
        srcGraphReclFNoise.Cursors.Item(3).YPosition = BasicReclFwdNoiseMax
        srcGraphReclBNoise.Cursors.Item(2).YPosition = BasicReclBwdNoiseMin
        srcGraphReclBNoise.Cursors.Item(3).YPosition = BasicReclBwdNoiseMax

        srcGraphLsuptAmp.ClearData()
        srcGraphLsuptNoise.ClearData()
        srcGraphBolsterAmp.ClearData()
        srcGraphBolsterNoise.ClearData()

        srcGraphLsuptAmp.Cursors.Item(2).YPosition = BasicLsuptAmpMin
        srcGraphLsuptAmp.Cursors.Item(3).YPosition = BasicLsuptAmpMax
        srcGraphLsuptNoise.Cursors.Item(2).YPosition = BasicLsuptNoiseMin
        srcGraphLsuptNoise.Cursors.Item(3).YPosition = BasicLsuptNoiseMax

        srcGraphBolsterAmp.Cursors.Item(2).YPosition = BasicLsuptAmpMin
        srcGraphBolsterAmp.Cursors.Item(3).YPosition = BasicLsuptAmpMax
        srcGraphBolsterNoise.Cursors.Item(2).YPosition = BasicLsuptNoiseMin
        srcGraphBolsterNoise.Cursors.Item(3).YPosition = BasicLsuptNoiseMax

        'srclbSpecLsuptUpAmp.Text = BasicLsuptAmpMin & " ~ " & BasicLsuptAmpMax
        srclbSpecLsuptMidAmp.Text = BasicLsuptAmpMin & " ~ " & BasicLsuptAmpMax
        'srclbSpecLsuptLowAmp.Text = BasicLsuptAmpMin & " ~ " & BasicLsuptAmpMax
        srclbSpecLsuptDefAmp.Text = BasicLsuptAmpMin & " ~ " & BasicLsuptAmpMax
        srclbSpecBolsterInfAmp.Text = BasicLsuptAmpMin & " ~ " & BasicLsuptAmpMax
        srclbSpecBolsterDefAmp.Text = BasicLsuptAmpMin & " ~ " & BasicLsuptAmpMax

        'srclbSpecLsuptUpNoise.Text = BasicLsuptNoiseMin & " ~ " & BasicLsuptNoiseMax
        srclbSpecLsuptMidNoise.Text = BasicLsuptNoiseMin & " ~ " & BasicLsuptNoiseMax
        'srclbSpecLsuptLowNoise.Text = BasicLsuptNoiseMin & " ~ " & BasicLsuptNoiseMax
        'srclbSpecLsuptDefNoise.Text = BasicLsuptNoiseMin & " ~ " & BasicLsuptNoiseMax
        srclbSpecBolsterInfNoise.Text = BasicLsuptNoiseMin & " ~ " & BasicLsuptNoiseMax
        'srclbSpecBolsterDefNoise.Text = BasicLsuptNoiseMin & " ~ " & BasicLsuptNoiseMax

        'srclbDataLsuptUpAmp.Text = ""
        srclbDataLsuptMidAmp.Text = ""
        'srclbDataLsuptLowAmp.Text = ""
        srclbDataLsuptDefAmp.Text = ""
        srclbDataBolsterInfAmp.Text = ""
        srclbDataBolsterDefAmp.Text = ""
        'srclbDecLsuptUpAmp.Text = ""
        srclbDecLsuptMidAmp.Text = ""
        'srclbDecLsuptLowAmp.Text = ""
        srclbDecLsuptDefAmp.Text = ""
        srclbDecBolsterInfAmp.Text = ""
        srclbDecBolsterDefAmp.Text = ""
        'srclbDecLsuptUpAmp.BackColor = Color.Black
        srclbDecLsuptMidAmp.BackColor = Color.Black
        'srclbDecLsuptLowAmp.BackColor = Color.Black
        srclbDecLsuptDefAmp.BackColor = Color.Black
        srclbDecBolsterInfAmp.BackColor = Color.Black
        srclbDecBolsterDefAmp.BackColor = Color.Black

        'srclbDataLsuptUpNoise.Text = ""
        srclbDataLsuptMidNoise.Text = ""
        'srclbDataLsuptLowNoise.Text = ""
        'srclbDataLsuptDefNoise.Text = ""
        srclbDataBolsterInfNoise.Text = ""
        'srclbDataBolsterDefNoise.Text = ""
        'srclbDecLsuptUpNoise.Text = ""
        srclbDecLsuptMidNoise.Text = ""
        'srclbDecLsuptLowNoise.Text = ""
        'srclbDecLsuptDefNoise.Text = ""
        srclbDecBolsterInfNoise.Text = ""
        'srclbDecBolsterDefNoise.Text = ""
        'srclbDecLsuptUpNoise.BackColor = Color.Black
        srclbDecLsuptMidNoise.BackColor = Color.Black
        'srclbDecLsuptLowNoise.BackColor = Color.Black
        'srclbDecLsuptDefNoise.BackColor = Color.Black
        srclbDecBolsterInfNoise.BackColor = Color.Black
        'srclbDecBolsterDefNoise.BackColor = Color.Black

        srclbDecReclFwdSpeed.Text = ""
        srclbDecReclFwdSpeed.BackColor = Color.Black
        srclbDecReclBwdSpeed.Text = ""
        srclbDecReclBwdSpeed.BackColor = Color.Black

        srclbValReclFwdStartAngle.Text = ""
        srclbValReclFwdEndAngle.Text = ""
        srclbValReclFwdTicTime.Text = ""
        srclbValReclBwdStartAngle.Text = ""
        srclbValReclBwdEndAngle.Text = ""
        srclbValReclBwdTicTime.Text = ""

        srclbValFrestFwdStartAngle.Text = ""
        srclbValFrestFwdEndAngle.Text = ""
        srclbValFrestFwdTicTime.Text = ""
        srclbValFrestBwdStartAngle.Text = ""
        srclbValFrestBwdEndAngle.Text = ""
        srclbValFrestBwdTicTime.Text = ""

    End Sub

    Private Sub Dec2Bin(ByVal Port_0 As Integer, ByVal Port_1 As Integer)

        Dim iten As Integer
        Dim sbin As String
        Dim tmp As String
        Dim i As Integer

        iten = CInt(Port_0)
        sbin = ""
        Do Until iten = 0
            sbin = CStr((iten Mod 2)) & sbin
            iten = iten \ 2
        Loop

        tmp = ""
        For i = 1 To 8 - Len(sbin)
            tmp = tmp & "0"
        Next

        D_Value(0) = CInt(Mid(tmp & sbin, 8, 1))
        D_Value(1) = CInt(Mid(tmp & sbin, 7, 1))
        D_Value(2) = CInt(Mid(tmp & sbin, 6, 1))
        D_Value(3) = CInt(Mid(tmp & sbin, 5, 1))
        D_Value(4) = CInt(Mid(tmp & sbin, 4, 1))
        D_Value(5) = CInt(Mid(tmp & sbin, 3, 1))
        D_Value(6) = CInt(Mid(tmp & sbin, 2, 1))
        D_Value(7) = CInt(Mid(tmp & sbin, 1, 1))

        iten = CInt(Port_1)
        sbin = ""
        Do Until iten = 0
            sbin = CStr((iten Mod 2)) & sbin
            iten = iten \ 2

        Loop

        tmp = ""
        For i = 1 To 8 - Len(sbin)
            tmp = tmp & "0"
        Next

        D_Value(8) = CInt(Mid(tmp & sbin, 8, 1))
        D_Value(9) = CInt(Mid(tmp & sbin, 7, 1))
        D_Value(10) = CInt(Mid(tmp & sbin, 6, 1))
        D_Value(11) = CInt(Mid(tmp & sbin, 5, 1))
        D_Value(12) = CInt(Mid(tmp & sbin, 4, 1))
        D_Value(13) = CInt(Mid(tmp & sbin, 3, 1))
        D_Value(14) = CInt(Mid(tmp & sbin, 2, 1))
        D_Value(15) = CInt(Mid(tmp & sbin, 1, 1))

        For i = 0 To 15
            If D_Value(i) = 1 Then
                D_Value(i) = 0
            Else
                D_Value(i) = 1
            End If
        Next

    End Sub

    Private Sub RequestSupply(ByVal SupplyPort As System.IO.Ports.SerialPort, ByVal strMsg As String)

        Try
            If SupplyPort.IsOpen = True Then
                SupplyPort.WriteLine(strMsg)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TmrIO_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrIO.Tick

        Dim err1 As ErrorCode = ErrorCode.Success
        Dim err2 As ErrorCode = ErrorCode.Success
        Dim tmp1 As Byte
        Dim tmp2 As Byte

        err1 = InstantDiCtrl1.Read(0, tmp1)
        err2 = InstantDiCtrl1.Read(1, tmp2)

        Dec2Bin(CInt(tmp1), CInt(tmp2))

        For i As Integer = 0 To 15
            If D_Value(i) = 0 Then
                IO_IN_LABEL(i).BackColor = Color.White
            Else
                IO_IN_LABEL(i).BackColor = Color.Black
            End If
        Next i

        lbRequestStep1.Text = RequestStep1
        lbRequestCount1.Text = RequestCount1
        RequestCount1 = RequestCount1 + 0.1
        If RequestCount1 >= 2 Then
            RequestStep1 = 0
            RequestCount1 = 0
        End If
        If RequestStep1 = 0 Then
            RequestSupply(Serial_Supply1, "MEAS:VOLT?")
            RequestStep1 = 1
        ElseIf RequestStep1 = 1 Then
            'if data Recv VOLT
        ElseIf RequestStep1 = 2 Then
            RequestSupply(Serial_Supply1, "MEAS:CURR?")
            RequestStep1 = 3
        ElseIf RequestStep1 = 3 Then
            RequestSupply(Serial_Supply1, "SOURS:VOLT " & CStr("13.5"))
            RequestStep1 = 0
        End If

        lbRequestStep2.Text = RequestStep2
        lbRequestCount2.Text = RequestCount2
        RequestCount2 = RequestCount2 + 0.1
        If RequestCount2 >= 1 Then
            RequestStep2 = 0
            RequestCount2 = 0
        End If

        If RequestStep2 = 0 Then
            RequestSupply(Serial_Supply2, "MEAS:VOLT?")
            RequestStep2 = 1
        ElseIf RequestStep2 = 1 Then
            'if data Recv VOLT
        ElseIf RequestStep2 = 2 Then
            RequestSupply(Serial_Supply2, "MEAS:CURR?")
            RequestStep2 = 3
        ElseIf RequestStep2 = 3 Then
            RequestSupply(Serial_Supply2, "SOURS:VOLT " & CStr("13.5"))
            RequestStep2 = 0
        End If

        LbSupply1Volt.Text = ValueVolt1
        LbSupply2Volt.Text = ValueVolt2
        LbSupply1Amp.Text = ValueAmp1
        LbSupply2Amp.Text = ValueAmp2

    End Sub

    Sub Do_On(ByVal Num As Integer)

        Dim P1 As Integer
        Dim P2 As Integer

        Out_(Num) = 1

        If Out_(0) = 1 Then P1 = P1 + 1
        If Out_(1) = 1 Then P1 = P1 + 2
        If Out_(2) = 1 Then P1 = P1 + 4
        If Out_(3) = 1 Then P1 = P1 + 8
        If Out_(4) = 1 Then P1 = P1 + 16
        If Out_(5) = 1 Then P1 = P1 + 32
        If Out_(6) = 1 Then P1 = P1 + 64
        If Out_(7) = 1 Then P1 = P1 + 128

        If Out_(8) = 1 Then P2 = P2 + 1
        If Out_(9) = 1 Then P2 = P2 + 2
        If Out_(10) = 1 Then P2 = P2 + 4
        If Out_(11) = 1 Then P2 = P2 + 8
        If Out_(12) = 1 Then P2 = P2 + 16
        If Out_(13) = 1 Then P2 = P2 + 32
        If Out_(14) = 1 Then P2 = P2 + 64
        If Out_(15) = 1 Then P2 = P2 + 128

        Dim err As ErrorCode = ErrorCode.Success
        err = InstantDoCtrl1.Write(0, CByte(P1))
        err = InstantDoCtrl1.Write(1, CByte(P2))

        IO_OUT_LABEL(Num).BackColor = Color.Black

    End Sub

    Sub Do_Off(ByVal Num As Integer)

        Dim P1 As Integer
        Dim P2 As Integer

        Out_(Num) = 0

        If Out_(0) = 1 Then P1 = P1 + 1
        If Out_(1) = 1 Then P1 = P1 + 2
        If Out_(2) = 1 Then P1 = P1 + 4
        If Out_(3) = 1 Then P1 = P1 + 8
        If Out_(4) = 1 Then P1 = P1 + 16
        If Out_(5) = 1 Then P1 = P1 + 32
        If Out_(6) = 1 Then P1 = P1 + 64
        If Out_(7) = 1 Then P1 = P1 + 128

        If Out_(8) = 1 Then P2 = P2 + 1
        If Out_(9) = 1 Then P2 = P2 + 2
        If Out_(10) = 1 Then P2 = P2 + 4
        If Out_(11) = 1 Then P2 = P2 + 8
        If Out_(12) = 1 Then P2 = P2 + 16
        If Out_(13) = 1 Then P2 = P2 + 32
        If Out_(14) = 1 Then P2 = P2 + 64
        If Out_(15) = 1 Then P2 = P2 + 128

        Dim err As ErrorCode = ErrorCode.Success
        err = InstantDoCtrl1.Write(0, CByte(P1))
        err = InstantDoCtrl1.Write(1, CByte(P2))

        IO_OUT_LABEL(Num).BackColor = Color.White

    End Sub

    Private Function DecideTest() As Boolean

        Dim tmp As Boolean = False

        If srclbDecReclFwdNoise.Text <> "NG" And srclbDecReclFwdAmp.Text <> "NG" And srclbDecReclFwdAngle.Text <> "NG" And srclbDecReclFwdSpeed.Text <> "NG" And
           srclbDecReclBwdNoise.Text <> "NG" And srclbDecReclBwdAmp.Text <> "NG" And srclbDecReclBwdAngle.Text <> "NG" And srclbDecReclBwdSpeed.Text <> "NG" And srclbDecReclEndAngle.Text <> "NG" And
            srclbDecFrestFwdNoise.Text <> "NG" And srclbDecFrestFwdAmp.Text <> "NG" And srclbDecFrestFwdSpeed.Text <> "NG" And
            srclbDecFrestBwdNoise.Text <> "NG" And srclbDecFrestBwdAmp.Text <> "NG" And srclbDecFrestBwdSpeed.Text <> "NG" And
            srclbDecLsuptMidNoise.Text <> "NG" And srclbDecLsuptMidAmp.Text <> "NG" And srclbDecLsuptDefAmp.Text <> "NG" And
            srclbDecBolsterInfNoise.Text <> "NG" And srclbDecBolsterInfAmp.Text <> "NG" And srclbDecBolsterDefAmp.Text <> "NG" Then

            tmp = True

        End If

        Return tmp

    End Function

    Private Sub SaveDB()

        Dim strSQL As String = ""

        ConnectionOpen()

        strSQL = "UPDATE TABLE_MAIN SET " &
                    "OPTEST_DATE = '" & Format(Now, "yyyy-MM-dd") & "'," &
                    "OPTESt_STARTTIME = '" & StartTime & "'," &
                    "OPTEST_ENDTIME = '" & Format(Now, "HH:mm:ss") & "'," &
                    "OPTEST_DECISION = '" & srclbTotalDecision.Text & "'," &
                    "OpTest_Recl_Fwd_Amp = '" & srclbValReclFwdAmp.Text & "'," &
                    "OpTest_Recl_Bwd_Amp = '" & srclbValReclBwdAmp.Text & "'," &
                    "OpTest_Recl_Fwd_Noise = '" & srclbValReclFwdNoise.Text & "'," &
                    "OpTest_Recl_Bwd_Noise = '" & srclbValReclBwdNoise.Text & "'," &
                    "OpTest_Recl_Fwd_Angle = '" & srclbValReclFwdAngle.Text & "'," &
                    "OpTest_Recl_Fwd_Speed = '" & srclbValReclFwdSpeed.Text & "'," &
                    "OpTest_Recl_Bwd_Angle = '" & srclbValReclBwdAngle.Text & "'," &
                    "OpTest_Recl_Bwd_Speed = '" & srclbValReclBwdSpeed.Text & "'," &
                    "OpTest_Frest_Fwd_Amp = '" & srclbValFrestFwdAmp.Text & "'," &
                    "OpTest_Frest_Bwd_Amp = '" & srclbValFrestBwdAmp.Text & "'," &
                    "OpTest_Frest_Fwd_Noise = '" & srclbValFrestFwdNoise.Text & "'," &
                    "OpTest_Frest_Bwd_Noise = '" & srclbValFrestBwdNoise.Text & "'," &
                    "OpTest_Frest_Fwd_Speed = '" & srclbValFrestFwdSpeed.Text & "'," &
                    "OpTest_Frest_Bwd_Speed = '" & srclbValFrestBwdSpeed.Text & "'," &
                    "OpTest_Lsupt_Inf_Amp = '" & srclbDataLsuptMidAmp.Text & "'," &
                    "OpTest_Lsupt_Def_Amp = '" & srclbDataLsuptDefAmp.Text & "'," &
                    "OpTest_Lsupt_Inf_Noise = '" & srclbDataLsuptMidNoise.Text & "'," &
                    "OpTest_Bolster_Inf_Amp = '" & srclbDataBolsterInfAmp.Text & "'," &
                    "OpTest_Bolster_Def_Amp = '" & srclbDataBolsterDefAmp.Text & "'," &
                    "OpTest_Bolster_Inf_Noise = '" & srclbDataBolsterInfNoise.Text & "' " &
                    " WHERE SERIALNO = '" & srcLbSerial.Text & "'"

        SqlConnect.Execute(strSQL)
        ConnectionClose()

    End Sub

    Private Sub P_OUT_00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_OUT_00.Click

        If P_OUT_00.BackColor = Color.White Then
            Do_On(0)
        Else
            Do_Off(0)
        End If

    End Sub

    Private Sub P_OUT_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_OUT_01.Click

        If P_OUT_01.BackColor = Color.White Then
            Do_On(1)
        Else
            Do_Off(1)
        End If

    End Sub

    Private Sub P_OUT_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_OUT_02.Click

        If P_OUT_02.BackColor = Color.White Then
            Do_On(2)
        Else
            Do_Off(2)
        End If

    End Sub

    Private Sub P_OUT_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_OUT_03.Click

        If P_OUT_03.BackColor = Color.White Then
            Do_On(3)
        Else
            Do_Off(3)
        End If

    End Sub

    Private Function Del_Space(ByVal str As String) As String

        Dim tmp As String = ""
        Dim i As Integer

        For i = 1 To Len(str)
            If Mid(str, i, 1) = " " Then
            Else
                tmp = tmp & Mid(str, i, 1)
            End If
        Next

        tmp = tmp & Chr(13)
        Return tmp

    End Function

    Private Sub P_OUT_04_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_04.Click

        If P_OUT_04.BackColor = Color.White Then
            Do_On(4)
        Else
            Do_Off(4)
        End If

    End Sub

    Private Sub P_OUT_05_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_05.Click

        If P_OUT_05.BackColor = Color.White Then
            Do_On(5)
        Else
            Do_Off(5)
        End If

    End Sub

    Private Sub P_OUT_06_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_06.Click

        If P_OUT_06.BackColor = Color.White Then
            Do_On(6)
        Else
            Do_Off(6)
        End If

    End Sub

    Private Sub P_OUT_07_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_07.Click

        If P_OUT_07.BackColor = Color.White Then
            Do_On(7)
        Else
            Do_Off(7)
        End If

    End Sub

    Private Sub P_OUT_08_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_08.Click

        If P_OUT_08.BackColor = Color.White Then
            Do_On(8)
        Else
            Do_Off(8)
        End If

    End Sub

    Private Sub P_OUT_09_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_09.Click

        If P_OUT_09.BackColor = Color.White Then
            Do_On(9)
        Else
            Do_Off(9)
        End If

    End Sub

    Private Sub P_OUT_10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_10.Click

        If P_OUT_10.BackColor = Color.White Then
            Do_On(10)
        Else
            Do_Off(10)
        End If

    End Sub

    Private Sub P_OUT_11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_11.Click

        If P_OUT_11.BackColor = Color.White Then
            Do_On(11)
        Else
            Do_Off(11)
        End If

    End Sub

    Private Sub P_OUT_12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_12.Click

        If P_OUT_12.BackColor = Color.White Then
            Do_On(12)
        Else
            Do_Off(12)
        End If

    End Sub

    Private Sub P_OUT_13_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_13.Click

        If P_OUT_13.BackColor = Color.White Then
            Do_On(13)
        Else
            Do_Off(13)
        End If

    End Sub

    Private Sub P_OUT_14_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_14.Click

        If P_OUT_14.BackColor = Color.White Then
            Do_On(14)
        Else
            Do_Off(14)
        End If

    End Sub

    Private Sub P_OUT_15_Click(ByVal sender As Object, ByVal e As EventArgs) Handles P_OUT_15.Click

        If P_OUT_15.BackColor = Color.White Then
            Do_On(15)
        Else
            Do_Off(15)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DaqEnd()
        End
    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        wStep = 0

        LoadPortData()
        LoadBarcodeData()
        LoadBasicData()
        InitControl()
        InitTest()

        SerialOpen()

        TmrWork.Interval = 100
        TmrWork.Start()

        Control2Arry()

        Try
            InstantDoCtrl1.SelectedDevice = New DeviceInformation(0)
            InstantDiCtrl1.SelectedDevice = New DeviceInformation(0)
        Catch ex As Exception

        End Try

        TmrIO.Interval = 100
        TmrIO.Start()

        DaqStart()

        For i As Integer = 0 To 15
            Do_Off(i)
        Next

        Trd1 = New Thread(AddressOf ThreadTask1)
        Trd1.IsBackground = True
        Trd1.Start()

        ActPlc.ActTimeOut = 500
        AddressOfPLc = "192.168.0.115"
        FlagPlcConnection = False

        Tmr_Connect.Interval = 100
        Tmr_Connect.Start()
        wStep = 0

        FrmWorkStandard.Show()
        FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, "WorkStandard")

    End Sub

    Private Sub DaqStart()

        Try
            DaqTaskComponent1.StartRead()
        Catch ex As NationalInstruments.DAQmx.DaqException
            MessageBox.Show(ex.Message, "DAQ Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub DaqEnd()

        Try
            DaqTaskComponent1.StopRead()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        DaqEnd()
        End
    End Sub

    Private Sub SerialPortToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerialPortToolStripMenuItem.Click
        FrmPort.Show()
    End Sub

    Private Sub BasicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BasicToolStripMenuItem.Click
        FrmBasic.Show()
    End Sub

    Private Sub SerialScanner_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialScanner.DataReceived

        Dim Incoming As String
        Dim ScanData As String

        Incoming = SerialScanner.ReadLine()
        ScanData = Mid$(Incoming, 1, Len(Incoming) - 1)

        SerialScanner.DiscardInBuffer()
        srcScannerInput.Text = ScanData

        'If wStep = 1 Then

        If Len(ScanData) >= 23 Then
            InitControl()
            InitTest()
            For i As Integer = 0 To 15
                Do_Off(i)
            Next
            LoadBasicData()
            InitTest()
            srcLbSerial.Text = ScanData
            LoadPart(ScanData)
            LoadAngleData(OPTION_FRAME)
            LoadAngleDataFrest()
            wStep = 4
        End If

    End Sub

    Private Sub LoadPart(ByVal str As String)

        ConnectionOpen()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part WHERE PartNo = '" & Mid(str, 13, 11) & "'", SqlConnect)

        If Rs.RecordCount = 1 Then

            StartTime = Format(Now, "HH:mm:ss")

            srcLbPartNo.Text = Mid(str, 13, 14)
            srcLbPartName.Text = Trim(Rs.Fields("PartName").Value)

            OPTION_LHRH = Trim(Rs.Fields("OptionLHRH").Value)
            OPTION_FREST = Rs.Fields("OptionFootRest").Value
            OPTION_LSUPT = Trim(Rs.Fields("OptionBack").Value)
            OPTION_RECL = "PWR"
            OPTION_TYPE = Trim(Rs.Fields("OptionType").Value)

            If OPTION_TYPE = "STD" Then
                OPTION_FRAME = "STD_" & OPTION_LHRH
            ElseIf OPTION_TYPE = "VIP" Then
                OPTION_FRAME = "VIP"
            ElseIf OPTION_TYPE = "FOLD" Then
                OPTION_FRAME = "FOLDING"
            End If
            srclbType.Text = OPTION_FRAME
            wStep = 4

            BasicReclFwdAngleMin = CDbl(Trim(Rs.Fields("TargetTestFwdAngleMin").Value))
            BasicReclFwdAngleMax = CDbl(Trim(Rs.Fields("TargetTestFwdAngleMax").Value))
            BasicReclBwdAngleMin = CDbl(Trim(Rs.Fields("TargetTestBwdAngleMin").Value))
            BasicReclBwdAngleMax = CDbl(Trim(Rs.Fields("TargetTestBwdAngleMax").Value))
            BasicReclEndAngleMin = CDbl(Trim(Rs.Fields("TargetTestEndAngleMin").Value))
            BasicReclEndAngleMax = CDbl(Trim(Rs.Fields("TargetTestEndAngleMax").Value))

            srclbSpecReclFwdAngle.Text = BasicReclFwdAngleMin & " ~ " & BasicReclFwdAngleMax
            srclbSpecReclBwdAngle.Text = BasicReclBwdAngleMin & " ~ " & BasicReclBwdAngleMax
            srclbSpecReclEndAngle.Text = BasicReclEndAngleMin & " ~ " & BasicReclEndAngleMax

        Else

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionClose()

    End Sub

    Private Sub TmrWork_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrWork.Tick

        srcStep1.Text = wStep

        If RstStep = 0 Then

            If wStep = 0 Then

                wStep = 1

            ElseIf wStep = 1 Then '스캔대기

            ElseIf wStep = 4 Then '스캔완료

                'FrmWorkStandard.Close()
                Lstep = 0
                rStep = 0
                wStep = 4.1

            ElseIf wStep = 4.1 Then

                For i As Integer = 0 To 15
                    Do_Off(i)
                Next
                WritePlc("D", "4050", "0")
                wStep = 5

            ElseIf wStep = 5 Then

                If PlcValue(4001) = 1 Then
                    wStep = 200
                End If

            ElseIf wStep = 200 Then '풋레스트

                If OPTION_FREST = True Then
                    wStep = 300
                Else
                    wStep = 350
                End If

            ElseIf wStep = 350 Then

                If FlagTogether = True Then
                    rStep = 0
                    Lstep = 0
                    wStep = 2000 '동시구동
                Else
                    wStep = 100
                End If

            ElseIf wStep = 130 Then '리클검사 종료

                wStep = 400

            ElseIf wStep = 400 Then '럼버

                If OPTION_LHRH = "LH" And OPTION_LSUPT = "3C" Then
                    wStep = 600
                ElseIf OPTION_LHRH = "LH" And OPTION_LSUPT = "12C" Then
                    wStep = 600
                ElseIf OPTION_LHRH = "RH" And OPTION_LSUPT = "2C" Then
                    wStep = 600
                ElseIf OPTION_LHRH = "RH" And OPTION_LSUPT = "11C" Then
                    wStep = 600
                Else
                    wStep = 1000
                End If

            ElseIf wStep = 700 Then '럼버 검사 종료

                If OPTION_LHRH = "LH" And OPTION_LSUPT = "12C" Then
                    wStep = 800
                ElseIf OPTION_LHRH = "RH" And OPTION_LSUPT = "11C" Then
                    wStep = 800
                Else
                    wStep = 1000
                End If

            ElseIf wStep = 1000 Then '파워 검사 완료

                If DecideTest() = True Then
                    srclbTotalDecision.Text = "OK"
                    srclbTotalDecision.BackColor = Color.Blue
                Else
                    srclbTotalDecision.Text = "NG"
                    srclbTotalDecision.BackColor = Color.Red
                End If
                SaveDB()
                wStep = 1001

            ElseIf wStep = 1001 Then '완료

                WritePlc("D", "4050", "1")
                TmrCount = 0
                wStep = 1002

            ElseIf wStep = 1002 Then

                TmrCount = TmrCount + 0.1
                If TmrCount > 1 Then
                    WritePlc("D", "4050", "0")
                    'FrmWorkStandard.Show()
                    'FrmWorkStandard.LoadPicture(FrmWorkStandard.srcPictureBox, "WorkStandard")
                    wStep = 0
                End If

            End If

        End If

    End Sub

    Private Function LoadToolData(ByVal strSErial As String) As String

        ConnectionOpen()

        Dim tmp As String = ""
        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Main WHERE Serial_No = '" & strSErial & "'", SqlConnect)

        If Rs.RecordCount >= 1 Then
            Try
                tmp = Trim(Rs.Fields("OP20_2_TOOL_VALUE").Value)
            Catch ex As Exception

            End Try
        Else
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionClose()

        Return tmp

    End Function

    Private Function ConvertStr(ByVal str As String) As String

        Dim tmp As String = ""
        If str = "NA" Then
            tmp = ""
        Else
            tmp = str
        End If
        Return tmp

    End Function

    Private Sub BarcodePrint()

        Dim TMP As String = ""
        Dim TmpTool As String
        Dim PartNameA As String
        Dim PartNameB As String

        TmpTool = LoadToolData(srcLbSerial.Text)

        '리클라이너 모터 체결 T/Q
        '리클 전진각도 
        '후진각도 / 
        '전진소음 / 
        '후진소음 / 
        '럼버 전진소음 
        '후진소음()

        TMP = srcLbPartNo.Text & "," & srcLbPartName.Text & "," & srcLbSerial.Text & "," & TmpTool & "," & _
                ConvertStr(srclbValReclFwdAngle.Text) & "," & _
                ConvertStr(srclbValReclBwdAngle.Text) & "," & _
                ConvertStr(srclbValReclFwdNoise.Text) & "," & _
                ConvertStr(srclbValReclBwdNoise.Text) & "," & _
                ConvertStr(srclbValFrestFwdNoise.Text) & "," & _
                ConvertStr(srclbValFrestBwdNoise.Text)

        PartNameA = Mid(srcLbPartName.Text, 1, 14)
        PartNameB = Mid(srcLbPartName.Text, 15, Len(srcLbPartName.Text) - 13)

        'SerialPrinter.Write("^XA")
        'SerialPrinter.Write("^FO" & "70" & "," & "20" & "^BQ,2," & "4" & "^FDQA," & TMP & "^FS")
        'SerialPrinter.Write("^FO" & "280" & "," & "30" & "^A0N," & "25" & "," & "25" & "^FD" & srcLbPartNo.Text & "^FS")
        'SerialPrinter.Write("^FO" & "280" & "," & "60" & "^A0N," & "25" & "," & "25" & "^FD" & PartNameA & "^FS")
        'SerialPrinter.Write("^FO" & "280" & "," & "90" & "^A0N," & "25" & "," & "25" & "^FD" & PartNameB & "^FS")
        'SerialPrinter.Write("^FO" & "280" & "," & "120" & "^A0N,," & "25" & "," & "25" & "^FD" & srcLbSerial.Text & "^FS")
        'SerialPrinter.Write("^FO" & "280" & "," & "150" & "^A0N,," & "25" & "," & "25" & "^FD" & "KMIN" & " " & Format(Now, "yyyy.MM.dd") & " " & Format(Now, "HH:MM") & "^FS")
        'SerialPrinter.Write("^XZ")

        'B1X = Rs.Fields("B1X").Value
        'B1Y = Rs.Fields("B1Y").Value
        'B1L = Rs.Fields("B1L").Value

        SerialPrinter.Write("^XA")
        SerialPrinter.Write("^FO" & B1X & "," & B1Y & "^BQ,2," & B1L & "^FDQA," & TMP & "^FS")
        SerialPrinter.Write("^FO" & B2X & "," & B2Y & "^A0N," & B2H & "," & B2W & "^FD" & "" & "^FS")
        SerialPrinter.Write("^FO" & B3X & "," & B3Y & "^A0N," & B3H & "," & B3W & "^FD" & srcLbPartNo.Text & "^FS")
        SerialPrinter.Write("^FO" & B4X & "," & B4Y & "^A0N," & B4H & "," & B4H & "^FD" & PartNameA & "^FS")
        SerialPrinter.Write("^FO" & B7X & "," & B7Y & "^A0N," & B7H & "," & B7H & "^FD" & PartNameB & "^FS")
        SerialPrinter.Write("^FO" & B5X & "," & B5Y & "^A0N,," & B5H & "," & B5W & "^FD" & srcLbSerial.Text & "^FS")
        SerialPrinter.Write("^FO" & B6X & "," & B6Y & "^A0N,," & B6H & "," & B6W & "^FD" & "KMIN" & " " & Format(Now, "yyyy.MM.dd") & " " & Format(Now, "HH:MM") & "^FS")

        SerialPrinter.Write("^XZ")

    End Sub

    Private Sub BarcodePrintNG()

        Dim TMP As String = ""

        SerialPrinter.Write("^XA")
        SerialPrinter.Write("^FO" & "70" & "," & "30" & "^A0N," & "100" & "," & "100" & "^FD" & "NG" & "^FS")
        SerialPrinter.Write("^FO" & "280" & "," & "120" & "^A0N,," & "25" & "," & "25" & "^FD" & srcLbSerial.Text & "^FS")
        SerialPrinter.Write("^FO" & "280" & "," & "150" & "^A0N,," & "25" & "," & "25" & "^FD" & "KMIN" & " " & Format(Now, "yyyy.MM.dd") & " " & Format(Now, "HH:MM") & "^FS")
        SerialPrinter.Write("^XZ")

    End Sub

    Private Function Laser2Angle(ByVal vLaser As Double) As Double

        Dim tmp As Double = 0
        Try
            For i As Integer = 0 To UBound(LASER) - 1
                If vLaser >= LASER(i) And vLaser <= LASER(i + 1) Then
                    tmp = Calc(LASER(i), ANGLE(i), LASER(i + 1), ANGLE(i + 1), vLaser)
                End If
            Next i

        Catch ex As Exception

        End Try

        Return tmp

    End Function

    Private Function Laser2Angle_Frest(ByVal vLaser As Double) As Double

        Dim tmp As Double = 0
        Try
            For i As Integer = 0 To UBound(LASER_FREST) - 1
                If vLaser >= LASER_FREST(i) And vLaser <= LASER_FREST(i + 1) Then
                    tmp = Calc(LASER_FREST(i), ANGLE_FREST(i), LASER_FREST(i + 1), ANGLE_FREST(i + 1), vLaser)
                End If
            Next i

        Catch ex As Exception

        End Try

        Return tmp

    End Function

    Public Function Calc(ByVal aLaser As Double, ByVal aAngle As Double, ByVal bLaser As Double, ByVal bAngle As Double, ByVal val As Double) As Double

        Dim t As Double
        Dim tmp As Double = 0
        Try
            If aLaser = 0 And aAngle = 0 And bLaser = 0 And bAngle = 0 Then
                tmp = 0
            Else
                t = (aAngle - bAngle) / (aLaser - bLaser)
                tmp = (t * val) - (t * bLaser) + bAngle
            End If
        Catch ex As Exception
        End Try
        Return tmp

    End Function

    Private Sub LoadAngleData(ByVal strOption As String)

        ConnectionOpenMdb()

        Dim Rs As New ADODB.Recordset
        Dim i As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Angle_" & strOption & " ORDER BY LEN(LASER_LENGTH),LASER_LENGTH", MdbConnect)

        ReDim ANGLE(Rs.RecordCount)
        ReDim LASER(Rs.RecordCount)

        If Rs.RecordCount = 0 Then

        ElseIf Rs.RecordCount = 1 Then

            ANGLE(0) = Rs.Fields("CONVERT_ANGLE").Value
            LASER(0) = Rs.Fields("LASER_LENGTH").Value

        ElseIf Rs.RecordCount > 1 Then

            i = 0
            Rs.MoveFirst()

            Do Until Rs.EOF
                ANGLE(i) = Rs.Fields("CONVERT_ANGLE").Value
                LASER(i) = Rs.Fields("LASER_LENGTH").Value
                i = i + 1
                Rs.MoveNext()
            Loop

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMdb()

    End Sub

    Private Sub LoadAngleDataFrest()

        ConnectionOpenMdb()

        Dim Rs As New ADODB.Recordset
        Dim i As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Angle_FOOTREST ORDER BY LEN(LASER_LENGTH),LASER_LENGTH", MdbConnect)

        ReDim ANGLE_FREST(Rs.RecordCount)
        ReDim LASER_FREST(Rs.RecordCount)

        If Rs.RecordCount = 0 Then

        ElseIf Rs.RecordCount = 1 Then

            ANGLE_FREST(0) = Rs.Fields("CONVERT_ANGLE").Value
            LASER_FREST(0) = Rs.Fields("LASER_LENGTH").Value

        ElseIf Rs.RecordCount > 1 Then

            i = 0
            Rs.MoveFirst()

            Do Until Rs.EOF
                ANGLE_FREST(i) = Rs.Fields("CONVERT_ANGLE").Value
                LASER_FREST(i) = Rs.Fields("LASER_LENGTH").Value
                i = i + 1
                Rs.MoveNext()
            Loop

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMdb()

    End Sub

    Private Sub BarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeToolStripMenuItem.Click
        FrmBarcode.Show()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DaqStart()
    End Sub

    Private Sub DaqTaskComponent1_DataReady(ByVal sender As System.Object, ByVal e As NosieTest.DaqTaskComponentDataReadyEventArgs) Handles DaqTaskComponent1.DataReady

        Dim i As Int64

        Dim Data_out() As Double
        Dim db_time_sec As Double
        Dim db_dt As Double

        System.Threading.Monitor.Enter(DaqTaskComponent1)
        Dim acquiredData() As NationalInstruments.AnalogWaveform(Of Double) = e.GetData

        SUM_NOISE = 0
        SUM_AMP = 0
        SUM_AMP2 = 0
        SUM_LASER = 0
        SUM_LASER2 = 0
        Tmp_Count = 0

        DATA_NOISE = acquiredData(0).GetRawData()
        DATA_LASER = acquiredData(1).GetRawData()
        DATA_LASER2 = acquiredData(2).GetRawData()

        InteropAssembly.LabVIEWExports.sound_to_db(DATA_NOISE, 0, 1 / 25600, Data_out, db_time_sec, db_dt)

        For i = 0 To UBound(Data_out)
            SUM_NOISE = SUM_NOISE + Data_out(i)
        Next
        For i = 0 To UBound(DATA_LASER)
            SUM_LASER = SUM_LASER + DATA_LASER(i)
        Next
        For i = 0 To UBound(DATA_LASER2)
            SUM_LASER2 = SUM_LASER2 + DATA_LASER2(i)
        Next

        tmpNoise1 = (SUM_NOISE / (UBound(Data_out) + 1))
        tmpLaser = (SUM_LASER / (UBound(DATA_LASER) + 1))
        tmpLaser2 = (SUM_LASER2 / (UBound(DATA_LASER2) + 1))

        vNoise = tmpNoise1 + MicroPhone_Tol
        vLaser1 = (tmpLaser2 * 100) + 50
        vLaser2 = (tmpLaser * 100) + 50

        srcNoise.Text = Format(vNoise, "#0.0#")
        srcLaser1.Text = Format(vLaser1, "#0.0#")
        srcLaser2.Text = Format(vLaser2, "#0.0#")

        srcLaser1Angle.Text = Laser2Angle(vLaser1)
        srcLaser2Angle.Text = Laser2Angle_Frest(vLaser2)

        Label134.Text = Lstep & " / " & rStep

        If wStep = 2000 Then '동시구동

            'rstep 0 ~ 6 '후진 

            If Lstep = 1001 Then wStep = 1000
            If Lstep = 1000 And rStep = 1000 Then wStep = 1000

            If rStep = 0 Then

                rStep = 1

            ElseIf rStep = 1 Then 'PWR FWD
                Do_On(1)
                ErrCountR = 0
                CounterAtStartR = Timer.Value
                TmpAmpMAxR = 0
                TmpNoiseMaxr = 0
                ArryCountR = 0
                CalcCountR = 0
                srclbValReclFwdStartAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
                rStep = 2

            ElseIf rStep = 2 Then

                CounterAtNowR = Timer.Value
                TotalTimeR = CDbl(((CounterAtNowR - CounterAtStartR) * 10000 / Timer.Frequency) / 10000)

                If ArryCountR < ArryMaxSize Then
                    ArryNoiseR(ArryCountR) = vNoise
                    ArryAmpR(ArryCountR) = ValueAmp1
                    ArryTimeR(ArryCountR) = TotalTimeR
                    ArryCountR = ArryCountR + 1
                End If

                srcGraphReclFAmp.PlotXYAppend(TotalTimeR, ValueAmp1)
                srcGraphReclFNoise.PlotXYAppend(TotalTimeR, vNoise)
                srclbValReclFwdTicTime.Text = Format(TotalTimeR, "0.0#")

                If TotalTimeR > 1 Then
                    If ValueAmp1 < 0.1 Or ValueAmp1 > BasicReclStopAmp Then
                        CalcCountR = CalcCountR + 1
                    Else
                        CalcCountR = 0
                    End If

                    If CalcCountR > 5 Then
                        Do_Off(0)
                        Do_Off(1)
                        rStep = 2.1
                    End If
                End If

            ElseIf rStep = 2.1 Then

                For i = 0 To ArryCountR - 1
                    If ArryTimeR(i) >= 1 And ArryTimeR(i) <= TotalTimeR - 1 Then
                        If TmpAmpMAxR < ArryAmpR(i) Then TmpAmpMAxR = ArryAmpR(i)
                        If TmpNoiseMaxr < ArryNoiseR(i) Then TmpNoiseMaxr = ArryNoiseR(i)
                    End If
                Next

                srcGraphReclFAmp.Cursors.Item(0).XPosition = 1
                srcGraphReclFAmp.Cursors.Item(1).XPosition = TotalTimeR - 1
                srcGraphReclFNoise.Cursors.Item(0).XPosition = 1
                srcGraphReclFNoise.Cursors.Item(1).XPosition = TotalTimeR - 1

                srclbValReclFwdAmp.Text = Format(TmpAmpMAxR, "0.0")
                srclbValReclFwdNoise.Text = Format(TmpNoiseMaxr, "0.0")
                srclbValReclFwdAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
                srclbValReclFwdEndAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
                srclbValReclFwdSpeed.Text = Format((Math.Abs(CDbl(srclbValReclFwdStartAngle.Text)) + Math.Abs(CDbl(srclbValReclFwdEndAngle.Text))) / CDbl(srclbValReclFwdTicTime.Text), "0.0")

                If TmpAmpMAxR >= BasicReclFwdAmpMin And TmpAmpMAxR <= BasicReclFwdAmpMax Then
                    srclbDecReclFwdAmp.Text = "OK"
                    srclbDecReclFwdAmp.BackColor = Color.Blue
                Else
                    srclbDecReclFwdAmp.Text = "NG"
                    srclbDecReclFwdAmp.BackColor = Color.Red
                End If

                If TmpNoiseMaxr >= BasicReclFwdNoiseMin And TmpNoiseMaxr <= BasicReclFwdNoiseMax Then
                    srclbDecReclFwdNoise.Text = "OK"
                    srclbDecReclFwdNoise.BackColor = Color.Blue
                Else
                    srclbDecReclFwdNoise.Text = "NG"
                    srclbDecReclFwdNoise.BackColor = Color.Red
                End If

                If CDbl(srclbValReclFwdAngle.Text) >= BasicReclFwdAngleMin And CDbl(srclbValReclFwdAngle.Text) <= BasicReclFwdAngleMax Then
                    srclbDecReclFwdAngle.Text = "OK"
                    srclbDecReclFwdAngle.BackColor = Color.Blue
                Else
                    srclbDecReclFwdAngle.Text = "NG"
                    srclbDecReclFwdAngle.BackColor = Color.Red
                End If

                If CDbl(srclbValReclFwdSpeed.Text) >= BasicReclFwdSpeedMin And CDbl(srclbValReclFwdSpeed.Text) <= BasicReclFwdSpeedMax Then
                    srclbDecReclFwdSpeed.Text = "OK"
                    srclbDecReclFwdSpeed.BackColor = Color.Blue
                Else
                    srclbDecReclFwdSpeed.Text = "NG"
                    srclbDecReclFwdSpeed.BackColor = Color.Red
                End If

                rStep = 3

            ElseIf rStep = 3 Then

                Do_On(0)
                ErrCountR = 0
                CounterAtStartR = Timer.Value
                TmpAmpMAxR = 0
                TmpNoiseMaxr = 0
                ArryCountR = 0
                CalcCountR = 0
                srclbValReclBwdStartAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
                rStep = 4

            ElseIf rStep = 4 Then

                CounterAtNowR = Timer.Value
                TotalTimeR = CDbl(((CounterAtNowR - CounterAtStartR) * 10000 / Timer.Frequency) / 10000)
                If ArryCountR < ArryMaxSize Then
                    ArryNoiseR(ArryCountR) = vNoise
                    ArryAmpR(ArryCountR) = ValueAmp1
                    ArryTimeR(ArryCountR) = TotalTimeR
                    ArryCountR = ArryCountR + 1
                End If

                srcGraphReclBAmp.PlotXYAppend(TotalTimeR, ValueAmp1)
                srcGraphReclBNoise.PlotXYAppend(TotalTimeR, vNoise)
                srclbValReclBwdTicTime.Text = Format(TotalTimeR, "0.0#")

                If TotalTimeR > 1 Then
                    If ValueAmp1 < 0.1 Or ValueAmp1 > BasicReclStopAmp Then
                        CalcCountR = CalcCountR + 1
                    Else
                        CalcCountR = 0
                    End If

                    If CalcCountR > 5 Then
                        Do_Off(0)
                        Do_Off(1)
                        rStep = 5
                    End If
                End If

            ElseIf rStep = 5 Then

                For i = 0 To ArryCountR - 1
                    If ArryTimeR(i) >= 1 And ArryTimeR(i) <= TotalTimeR - 1 Then
                        If TmpAmpMAxR < ArryAmpR(i) Then TmpAmpMAxR = ArryAmpR(i)
                        If TmpNoiseMaxr < ArryNoiseR(i) Then TmpNoiseMaxr = ArryNoiseR(i)
                    End If
                Next

                srcGraphReclBAmp.Cursors.Item(0).XPosition = 1
                srcGraphReclBAmp.Cursors.Item(1).XPosition = TotalTimeR - 1
                srcGraphReclBNoise.Cursors.Item(0).XPosition = 1
                srcGraphReclBNoise.Cursors.Item(1).XPosition = TotalTimeR - 1

                srclbValReclBwdAmp.Text = Format(TmpAmpMAxR, "0.0")
                srclbValReclBwdNoise.Text = Format(TmpNoiseMaxr, "0.0")
                srclbValReclBwdAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
                srclbValReclBwdEndAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
                srclbValReclBwdSpeed.Text = Format((Math.Abs(CDbl(srclbValReclBwdStartAngle.Text)) + Math.Abs(CDbl(srclbValReclBwdEndAngle.Text))) / CDbl(srclbValReclBwdTicTime.Text), "0.0")

                If TmpAmpMAxR >= BasicReclBwdAmpMin And TmpAmpMAxR <= BasicReclBwdAmpMax Then
                    srclbDecReclBwdAmp.Text = "OK"
                    srclbDecReclBwdAmp.BackColor = Color.Blue
                Else
                    srclbDecReclBwdAmp.Text = "NG"
                    srclbDecReclBwdAmp.BackColor = Color.Red
                End If

                If TmpNoiseMaxr >= BasicReclBwdNoiseMin And TmpNoiseMaxr <= BasicReclBwdNoiseMax Then
                    srclbDecReclBwdNoise.Text = "OK"
                    srclbDecReclBwdNoise.BackColor = Color.Blue
                Else
                    srclbDecReclBwdNoise.Text = "NG"
                    srclbDecReclBwdNoise.BackColor = Color.Red
                End If

                If CDbl(srclbValReclBwdAngle.Text) >= BasicReclBwdAngleMin And CDbl(srclbValReclBwdAngle.Text) <= BasicReclBwdAngleMax Then
                    srclbDecReclBwdAngle.Text = "OK"
                    srclbDecReclBwdAngle.BackColor = Color.Blue
                Else
                    srclbDecReclBwdAngle.Text = "NG"
                    srclbDecReclBwdAngle.BackColor = Color.Red
                End If

                If CDbl(srclbValReclBwdSpeed.Text) >= BasicReclBwdSpeedMin And CDbl(srclbValReclBwdSpeed.Text) <= BasicReclBwdSpeedMax Then
                    srclbDecReclBwdSpeed.Text = "OK"
                    srclbDecReclBwdSpeed.BackColor = Color.Blue
                Else
                    srclbDecReclBwdSpeed.Text = "NG"
                    srclbDecReclBwdSpeed.BackColor = Color.Red
                End If

                rStep = 6

            ElseIf rStep = 6 Then

                Lstep = 0.01
                rStep = 11

            ElseIf rStep = 11 Then 'PWR BWD END

                Do_On(1)
                ErrCountR = 0
                CounterAtStartR = Timer.Value
                TmpAmpMAxR = 0
                TmpNoiseMaxr = 0
                ArryCountR = 0
                CalcCountR = 0
                rStep = 12

            ElseIf rStep = 12 Then

                srclbValReclEndAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
                If CDbl(srclbValReclEndAngle.Text) >= BasicReclEndAngleMin And CDbl(srclbValReclEndAngle.Text) <= BasicReclEndAngleMax Then
                    Do_Off(0)
                    Do_Off(1)
                    srclbDecReclEndAngle.Text = "OK"
                    srclbDecReclEndAngle.BackColor = Color.Blue
                    rStep = 1000
                Else
                    srclbDecReclEndAngle.Text = "NG"
                    srclbDecReclEndAngle.BackColor = Color.Red
                End If

            End If

            If Lstep = 0.01 Then 'LH RH AIR 흡기

                If OPTION_LSUPT = "3C" Then
                    Lstep = 0.1
                ElseIf OPTION_LSUPT = "12C" Then
                    Lstep = 0.1
                ElseIf OPTION_LSUPT = "2C" Then
                    Lstep = 0.1
                ElseIf OPTION_LSUPT = "11C" Then
                    Lstep = 0.1
                Else
                    Lstep = 5.1
                End If

            ElseIf Lstep = 0.1 Then

                If OPTION_LHRH = "LH" Then
                    Do_On(11)
                ElseIf OPTION_LHRH = "RH" Then
                    Do_On(5)
                End If

                ErrCountL = 0
                CounterAtStartL = Timer.Value
                TmpAmpMAxL = 0
                TmpNoiseMaxL = 0
                ArryCountL = 0
                CalcCountL = 0
                Lstep = 1

            ElseIf Lstep = 1 Then

                CounterAtNowL = Timer.Value
                TotalTimeL = CDbl(((CounterAtNowL - CounterAtStartL) * 10000 / Timer.Frequency) / 10000)

                If 1 < TotalTimeL And TotalTimeL < (BasicLsuptInfTime - 1) Then '커넥터 분리시
                    If ValueAmp2 < 0.05 Then
                        Do_Off(11)
                        Do_Off(5)
                        Lstep = 1.1
                    End If
                End If
                If ArryCountL < ArryMaxSize Then
                    ArryNoiseL(ArryCountL) = vNoise
                    ArryAmpL(ArryCountL) = ValueAmp2
                    ArryTimeL(ArryCountL) = TotalTimeL
                    ArryCountL = ArryCountL + 1
                End If

                srcGraphLsuptAmp.Plots(0).PlotXYAppend(TotalTimeL, ValueAmp2)
                srcGraphLsuptNoise.Plots(0).PlotXYAppend(TotalTimeL, vNoise)

                If TotalTimeL >= BasicLsuptInfTime Then
                    Do_Off(11)
                    Do_Off(5)
                    Lstep = 2
                End If

            ElseIf Lstep = 1.1 Then

                For i = 0 To ArryCountL - 1
                    If ArryTimeL(i) >= 1 And ArryTimeL(i) <= TotalTimeL - 1 Then
                        If TmpAmpMAxL < ArryAmpL(i) Then TmpAmpMAxL = ArryAmpL(i)
                        If TmpNoiseMaxL < ArryNoiseL(i) Then TmpNoiseMaxL = ArryNoiseL(i)
                    End If
                Next

                srcGraphLsuptAmp.Cursors.Item(0).XPosition = 1
                srcGraphLsuptAmp.Cursors.Item(1).XPosition = TotalTimeL - 1
                srcGraphLsuptNoise.Cursors.Item(0).XPosition = 1
                srcGraphLsuptNoise.Cursors.Item(1).XPosition = TotalTimeL - 1

                srclbDataLsuptMidAmp.Text = Format(0, "0.0")
                srclbDataLsuptMidNoise.Text = Format(TmpNoiseMaxL, "0.0")

                srclbDecLsuptMidAmp.Text = "NG"
                srclbDecLsuptMidAmp.BackColor = Color.Red
                
                If TmpNoiseMaxL >= BasicLsuptNoiseMin And TmpNoiseMaxL <= BasicLsuptNoiseMax Then
                    srclbDecLsuptMidNoise.Text = "OK"
                    srclbDecLsuptMidNoise.BackColor = Color.Blue
                Else
                    srclbDecLsuptMidNoise.Text = "NG"
                    srclbDecLsuptMidNoise.BackColor = Color.Red
                End If
                Lstep = 2.1

            ElseIf Lstep = 2 Then

                For i = 0 To ArryCountL - 1
                    If ArryTimeL(i) >= 1 And ArryTimeL(i) <= TotalTimeL - 1 Then
                        If TmpAmpMAxL < ArryAmpL(i) Then TmpAmpMAxL = ArryAmpL(i)
                        If TmpNoiseMaxL < ArryNoiseL(i) Then TmpNoiseMaxL = ArryNoiseL(i)
                    End If
                Next

                srcGraphLsuptAmp.Cursors.Item(0).XPosition = 1
                srcGraphLsuptAmp.Cursors.Item(1).XPosition = TotalTimeL - 1
                srcGraphLsuptNoise.Cursors.Item(0).XPosition = 1
                srcGraphLsuptNoise.Cursors.Item(1).XPosition = TotalTimeL - 1

                srclbDataLsuptMidAmp.Text = Format(TmpAmpMAxL, "0.0")
                srclbDataLsuptMidNoise.Text = Format(TmpNoiseMaxL, "0.0")

                If TmpAmpMAxL >= BasicLsuptAmpMin And TmpAmpMAxL <= BasicLsuptAmpMax Then
                    srclbDecLsuptMidAmp.Text = "OK"
                    srclbDecLsuptMidAmp.BackColor = Color.Blue
                Else
                    srclbDecLsuptMidAmp.Text = "NG"
                    srclbDecLsuptMidAmp.BackColor = Color.Red
                End If

                If TmpNoiseMaxL >= BasicLsuptNoiseMin And TmpNoiseMaxL <= BasicLsuptNoiseMax Then
                    srclbDecLsuptMidNoise.Text = "OK"
                    srclbDecLsuptMidNoise.BackColor = Color.Blue
                Else
                    srclbDecLsuptMidNoise.Text = "NG"
                    srclbDecLsuptMidNoise.BackColor = Color.Red
                End If
                Lstep = 2.1

            ElseIf Lstep = 2.1 Then

                If OPTION_LHRH = "LH" Then
                    Do_On(13)
                ElseIf OPTION_LHRH = "RH" Then
                    Do_On(7)
                End If

                ErrCountL = 0
                CounterAtStartL = Timer.Value
                TmpAmpMAxL = 0
                TmpNoiseMaxL = 0
                ArryCountL = 0
                CalcCountL = 0
                Lstep = 2.2

            ElseIf Lstep = 2.2 Then

                CounterAtNowL = Timer.Value
                TotalTimeL = CDbl(((CounterAtNowL - CounterAtStartL) * 10000 / Timer.Frequency) / 10000)

                If 1 < TotalTimeL And TotalTimeL < (BasicLsuptDefTime - 1) Then '커넥터 분리시
                    If ValueAmp2 < 0.05 Then
                        Do_Off(13)
                        Do_Off(7)
                        Lstep = 2.21
                    End If
                End If

                If ArryCountL < ArryMaxSize Then
                    ArryNoiseL(ArryCountL) = vNoise
                    ArryAmpL(ArryCountL) = ValueAmp2
                    ArryTimeL(ArryCountL) = TotalTimeL
                    ArryCountL = ArryCountL + 1
                End If

                srcGraphLsuptAmp.Plots(1).PlotXYAppend(TotalTimeL, ValueAmp2)
                'srcGraphLsuptNoise.Plots(1).PlotXYAppend(TotalTime1, vNoise)

                If TotalTimeL >= BasicLsuptDefTime Then
                    Do_Off(13)
                    Do_Off(7)
                    Lstep = 2.3
                End If

            ElseIf Lstep = 2.21 Then

                For i = 0 To ArryCountL - 1
                    If ArryTimeL(i) >= 1 And ArryTimeL(i) <= TotalTimeL - 1 Then
                        If TmpAmpMAxL < ArryAmpL(i) Then TmpAmpMAxL = ArryAmpL(i)
                        If TmpNoiseMaxL < ArryNoiseL(i) Then TmpNoiseMaxL = ArryNoiseL(i)
                    End If
                Next

                srcGraphLsuptAmp.Cursors.Item(0).XPosition = 1
                srcGraphLsuptAmp.Cursors.Item(1).XPosition = TotalTimeL - 1
                srcGraphLsuptNoise.Cursors.Item(0).XPosition = 1
                srcGraphLsuptNoise.Cursors.Item(1).XPosition = TotalTimeL - 1

                srclbDataLsuptDefAmp.Text = Format(0, "0.0")
                srclbDecLsuptDefAmp.Text = "NG"
                srclbDecLsuptDefAmp.BackColor = Color.Red

                Lstep = 5.01

            ElseIf Lstep = 2.3 Then

                For i = 0 To ArryCountL - 1
                    If ArryTimeL(i) >= 1 And ArryTimeL(i) <= TotalTimeL - 1 Then
                        If TmpAmpMAxL < ArryAmpL(i) Then TmpAmpMAxL = ArryAmpL(i)
                        If TmpNoiseMaxL < ArryNoiseL(i) Then TmpNoiseMaxL = ArryNoiseL(i)
                    End If
                Next

                srcGraphLsuptAmp.Cursors.Item(0).XPosition = 1
                srcGraphLsuptAmp.Cursors.Item(1).XPosition = TotalTimeL - 1
                srcGraphLsuptNoise.Cursors.Item(0).XPosition = 1
                srcGraphLsuptNoise.Cursors.Item(1).XPosition = TotalTimeL - 1

                srclbDataLsuptDefAmp.Text = Format(TmpAmpMAxL, "0.0")
                'srclbDataLsuptDefNoise.Text = Format(TmpNoiseMax1, "0.0")

                If TmpAmpMAxL >= BasicLsuptAmpMin And TmpAmpMAxL <= BasicLsuptAmpMax Then
                    srclbDecLsuptDefAmp.Text = "OK"
                    srclbDecLsuptDefAmp.BackColor = Color.Blue
                Else
                    srclbDecLsuptDefAmp.Text = "NG"
                    srclbDecLsuptDefAmp.BackColor = Color.Red
                End If

                Lstep = 5.01

            ElseIf Lstep = 5.01 Then

                Lstep = 5.1

            ElseIf Lstep = 5.1 Then

                If OPTION_LHRH = "LH" And OPTION_LSUPT = "12C" Then
                    Lstep = 6
                ElseIf OPTION_LHRH = "RH" And OPTION_LSUPT = "11C" Then
                    Lstep = 6
                Else
                    Lstep = 1000
                End If

            ElseIf Lstep = 6 Then '볼스터 흡기

                If OPTION_LHRH = "LH" Then
                    Do_On(14)
                ElseIf OPTION_LHRH = "RH" Then
                    Do_On(8)
                End If

                ErrCountL = 0
                CounterAtStartL = Timer.Value
                TmpAmpMAxL = 0
                TmpNoiseMaxL = 0
                ArryCountL = 0
                CalcCountL = 0
                Lstep = 7

            ElseIf Lstep = 7 Then

                CounterAtNowL = Timer.Value
                TotalTimeL = CDbl(((CounterAtNowL - CounterAtStartL) * 10000 / Timer.Frequency) / 10000)

                If 1 < TotalTimeL And TotalTimeL < (BasicBolsterInfTime - 1) Then '커넥터 분리시
                    If ValueAmp2 < 0.05 Then  '커넥터 분리시
                        Do_Off(14)
                        Do_Off(8)
                        Lstep = 7.1
                    End If
                End If
                If ArryCountL < ArryMaxSize Then
                    ArryNoiseL(ArryCountL) = vNoise
                    ArryAmpL(ArryCountL) = ValueAmp2
                    ArryTimeL(ArryCountL) = TotalTimeL
                    ArryCountL = ArryCountL + 1
                End If

                srcGraphBolsterAmp.Plots(0).PlotXYAppend(TotalTimeL, ValueAmp2)
                srcGraphBolsterNoise.Plots(0).PlotXYAppend(TotalTimeL, vNoise)

                If TotalTimeL >= BasicBolsterInfTime Then
                    Do_Off(14)
                    Do_Off(8)
                    Lstep = 8
                End If

            ElseIf Lstep = 7.1 Then

                For i = 0 To ArryCountL - 1
                    If ArryTimeL(i) >= 1 And ArryTimeL(i) <= TotalTimeL - 1 Then
                        If TmpAmpMAxL < ArryAmpL(i) Then TmpAmpMAxL = ArryAmpL(i)
                        If TmpNoiseMaxL < ArryNoiseL(i) Then TmpNoiseMaxL = ArryNoiseL(i)
                    End If
                Next

                srcGraphBolsterAmp.Cursors.Item(0).XPosition = 1
                srcGraphBolsterAmp.Cursors.Item(1).XPosition = TotalTimeL - 1
                srcGraphBolsterNoise.Cursors.Item(0).XPosition = 1
                srcGraphBolsterNoise.Cursors.Item(1).XPosition = TotalTimeL - 1

                srclbDataBolsterInfAmp.Text = Format(0, "0.0")
                srclbDataBolsterInfNoise.Text = Format(TmpNoiseMaxL, "0.0")

                srclbDecBolsterInfAmp.Text = "NG"
                srclbDecBolsterInfAmp.BackColor = Color.Red
                
                If TmpNoiseMaxL >= BasicLsuptNoiseMin And TmpNoiseMaxL <= BasicLsuptNoiseMax Then
                    srclbDecBolsterInfNoise.Text = "OK"
                    srclbDecBolsterInfNoise.BackColor = Color.Blue
                Else
                    srclbDecBolsterInfNoise.Text = "NG"
                    srclbDecBolsterInfNoise.BackColor = Color.Red
                End If
                Lstep = 9

            ElseIf Lstep = 8 Then

                For i = 0 To ArryCountL - 1
                    If ArryTimeL(i) >= 1 And ArryTimeL(i) <= TotalTimeL - 1 Then
                        If TmpAmpMAxL < ArryAmpL(i) Then TmpAmpMAxL = ArryAmpL(i)
                        If TmpNoiseMaxL < ArryNoiseL(i) Then TmpNoiseMaxL = ArryNoiseL(i)
                    End If
                Next

                srcGraphBolsterAmp.Cursors.Item(0).XPosition = 1
                srcGraphBolsterAmp.Cursors.Item(1).XPosition = TotalTimeL - 1
                srcGraphBolsterNoise.Cursors.Item(0).XPosition = 1
                srcGraphBolsterNoise.Cursors.Item(1).XPosition = TotalTimeL - 1

                srclbDataBolsterInfAmp.Text = Format(TmpAmpMAxL, "0.0")
                srclbDataBolsterInfNoise.Text = Format(TmpNoiseMaxL, "0.0")

                If TmpAmpMAxL >= BasicLsuptAmpMin And TmpAmpMAxL <= BasicLsuptAmpMax Then
                    srclbDecBolsterInfAmp.Text = "OK"
                    srclbDecBolsterInfAmp.BackColor = Color.Blue
                Else
                    srclbDecBolsterInfAmp.Text = "NG"
                    srclbDecBolsterInfAmp.BackColor = Color.Red
                End If

                If TmpNoiseMaxL >= BasicLsuptNoiseMin And TmpNoiseMaxL <= BasicLsuptNoiseMax Then
                    srclbDecBolsterInfNoise.Text = "OK"
                    srclbDecBolsterInfNoise.BackColor = Color.Blue
                Else
                    srclbDecBolsterInfNoise.Text = "NG"
                    srclbDecBolsterInfNoise.BackColor = Color.Red
                End If
                Lstep = 9

            ElseIf Lstep = 9 Then

                Lstep = 10

            ElseIf Lstep = 10 Then '볼스터 배기

                If OPTION_LHRH = "LH" Then
                    Do_On(15)
                ElseIf OPTION_LHRH = "RH" Then
                    Do_On(9)
                End If

                ErrCountL = 0
                CounterAtStartL = Timer.Value
                TmpAmpMAxL = 0
                TmpAmpMinL = 100
                TmpNoiseMaxL = 0
                ArryCountL = 0
                CalcCountL = 0
                Lstep = 11

            ElseIf Lstep = 11 Then

                CounterAtNowL = Timer.Value
                TotalTimeL = CDbl(((CounterAtNowL - CounterAtStartL) * 10000 / Timer.Frequency) / 10000)

                If 1 < TotalTimeL And TotalTimeL < (BasicBolsterDefTime - 1) Then '동작중 커넥터 분리될 경우
                    If ValueAmp2 < 0.05 Then
                        Do_Off(15)
                        Do_Off(9)
                        Lstep = 12.1
                    End If
                End If
                If ArryCountL < ArryMaxSize Then
                    ArryNoiseL(ArryCountL) = vNoise
                    ArryAmpL(ArryCountL) = ValueAmp2
                    ArryTimeL(ArryCountL) = TotalTimeL
                    ArryCountL = ArryCountL + 1
                End If

                srcGraphBolsterAmp.Plots(1).PlotXYAppend(TotalTimeL, ValueAmp2)

                If TotalTimeL >= BasicBolsterDefTime Then
                    Do_Off(15)
                    Do_Off(9)
                    Lstep = 12
                End If

            ElseIf Lstep = 12 Then

                For i = 0 To ArryCountL - 1
                    If ArryTimeL(i) >= 1 And ArryTimeL(i) <= TotalTimeL - 1 Then
                        If TmpAmpMAxL < ArryAmpL(i) Then TmpAmpMAxL = ArryAmpL(i)
                        If TmpAmpMinL > ArryAmpL(i) Then TmpAmpMinL = ArryAmpL(i)
                        If TmpNoiseMaxL < ArryNoiseL(i) Then TmpNoiseMaxL = ArryNoiseL(i)
                    End If
                Next

                srcGraphBolsterAmp.Cursors.Item(0).XPosition = 1
                srcGraphBolsterAmp.Cursors.Item(1).XPosition = TotalTimeL - 1
                srcGraphBolsterNoise.Cursors.Item(0).XPosition = 1
                srcGraphBolsterNoise.Cursors.Item(1).XPosition = TotalTimeL - 1

                srclbDataBolsterDefAmp.Text = Format(TmpAmpMAxL, "0.0")

                If TmpAmpMAxL >= BasicLsuptAmpMin And TmpAmpMAxL <= BasicLsuptAmpMax Then
                    srclbDecBolsterDefAmp.Text = "OK"
                    srclbDecBolsterDefAmp.BackColor = Color.Blue
                Else
                    srclbDecBolsterDefAmp.Text = "NG"
                    srclbDecBolsterDefAmp.BackColor = Color.Red
                End If
                Lstep = 1001

            ElseIf Lstep = 12.1 Then

                srcGraphBolsterAmp.Cursors.Item(0).XPosition = 1
                srcGraphBolsterAmp.Cursors.Item(1).XPosition = TotalTimeL - 1
                srcGraphBolsterNoise.Cursors.Item(0).XPosition = 1
                srcGraphBolsterNoise.Cursors.Item(1).XPosition = TotalTimeL - 1

                srclbDataBolsterDefAmp.Text = Format(0, "0.0")
                srclbDecBolsterDefAmp.Text = "NG"
                srclbDecBolsterDefAmp.BackColor = Color.Red
                Lstep = 1001

            End If

        ElseIf wStep = 100 Then 'PWR BWD - > PWR FWD 로 변경 2022-02-24

            'wStep = 100.1
            wStep = 110

        ElseIf wStep = 100.1 Then

            Do_On(1)
            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            wStep = 100.2

        ElseIf wStep = 100.2 Then

            CounterAtNow1 = Timer.Value
            TotalTime1 = CDbl(((CounterAtNow1 - CounterAtStart1) * 10000 / Timer.Frequency) / 10000)
            If TotalTime1 > 1 Then
                If ValueAmp1 < 0.1 Or ValueAmp1 > BasicReclStopAmp Then
                    CalcCount1 = CalcCount1 + 1
                Else
                    CalcCount1 = 0
                End If
                If CalcCount1 > 5 Then
                    Do_Off(0)
                    Do_Off(1)
                    wStep = 100.3
                End If
            End If

        ElseIf wStep = 100.3 Then

            Do_On(0)
            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            srclbValReclBwdStartAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
            wStep = 101

        ElseIf wStep = 101 Then

            CounterAtNow1 = Timer.Value
            TotalTime1 = CDbl(((CounterAtNow1 - CounterAtStart1) * 10000 / Timer.Frequency) / 10000)

            If ArryCount1 < ArryMaxSize Then
                ArryNoise1(ArryCount1) = vNoise
                ArryAmp1(ArryCount1) = ValueAmp1
                ArryTime1(ArryCount1) = TotalTime1
                ArryCount1 = ArryCount1 + 1
            End If

            srcGraphReclBAmp.PlotXYAppend(TotalTime1, ValueAmp1)
            srcGraphReclBNoise.PlotXYAppend(TotalTime1, vNoise)
            srclbValReclBwdTicTime.Text = Format(TotalTime1, "0.0#")

            If TotalTime1 > 1 Then
                If ValueAmp1 < 0.1 Or ValueAmp1 > BasicReclStopAmp Then
                    CalcCount1 = CalcCount1 + 1
                Else
                    CalcCount1 = 0
                End If

                If CalcCount1 > 5 Then
                    Do_Off(0)
                    Do_Off(1)
                    wStep = 102
                End If
            End If

        ElseIf wStep = 102 Then

            For i = 0 To ArryCount1 - 1
                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphReclBAmp.Cursors.Item(0).XPosition = 1
            srcGraphReclBAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphReclBNoise.Cursors.Item(0).XPosition = 1
            srcGraphReclBNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbValReclBwdAmp.Text = Format(TmpAmpMAx1, "0.0")
            srclbValReclBwdNoise.Text = Format(TmpNoiseMax1, "0.0")
            srclbValReclBwdAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
            srclbValReclBwdEndAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
            srclbValReclBwdSpeed.Text = Format((Math.Abs(CDbl(srclbValReclBwdStartAngle.Text)) + Math.Abs(CDbl(srclbValReclBwdEndAngle.Text))) / CDbl(srclbValReclBwdTicTime.Text), "0.0")

            If TmpAmpMAx1 >= BasicReclBwdAmpMin And TmpAmpMAx1 <= BasicReclBwdAmpMax Then
                srclbDecReclBwdAmp.Text = "OK"
                srclbDecReclBwdAmp.BackColor = Color.Blue
            Else
                srclbDecReclBwdAmp.Text = "NG"
                srclbDecReclBwdAmp.BackColor = Color.Red
            End If

            If TmpNoiseMax1 >= BasicReclBwdNoiseMin And TmpNoiseMax1 <= BasicReclBwdNoiseMax Then
                srclbDecReclBwdNoise.Text = "OK"
                srclbDecReclBwdNoise.BackColor = Color.Blue
            Else
                srclbDecReclBwdNoise.Text = "NG"
                srclbDecReclBwdNoise.BackColor = Color.Red
            End If

            If CDbl(srclbValReclBwdAngle.Text) >= BasicReclBwdAngleMin And CDbl(srclbValReclBwdAngle.Text) <= BasicReclBwdAngleMax Then
                srclbDecReclBwdAngle.Text = "OK"
                srclbDecReclBwdAngle.BackColor = Color.Blue
            Else
                srclbDecReclBwdAngle.Text = "NG"
                srclbDecReclBwdAngle.BackColor = Color.Red
            End If

            If CDbl(srclbValReclBwdSpeed.Text) >= BasicReclBwdSpeedMin And CDbl(srclbValReclBwdSpeed.Text) <= BasicReclBwdSpeedMax Then
                srclbDecReclBwdSpeed.Text = "OK"
                srclbDecReclBwdSpeed.BackColor = Color.Blue
            Else
                srclbDecReclBwdSpeed.Text = "NG"
                srclbDecReclBwdSpeed.BackColor = Color.Red
            End If

            wStep = 103

        ElseIf wStep = 103 Then

            wStep = 120

        ElseIf wStep = 110 Then 'PWR FWD

            Do_On(1)
            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            srclbValReclFwdStartAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
            wStep = 111

        ElseIf wStep = 111 Then

            CounterAtNow1 = Timer.Value
            TotalTime1 = CDbl(((CounterAtNow1 - CounterAtStart1) * 10000 / Timer.Frequency) / 10000)

            If ArryCount1 < ArryMaxSize Then
                ArryNoise1(ArryCount1) = vNoise
                ArryAmp1(ArryCount1) = ValueAmp1
                ArryTime1(ArryCount1) = TotalTime1
                ArryCount1 = ArryCount1 + 1
            End If

            srcGraphReclFAmp.PlotXYAppend(TotalTime1, ValueAmp1)
            srcGraphReclFNoise.PlotXYAppend(TotalTime1, vNoise)
            srclbValReclFwdTicTime.Text = Format(TotalTime1, "0.0#")

            If TotalTime1 > 1 Then
                If ValueAmp1 < 0.1 Or ValueAmp1 > BasicReclStopAmp Then
                    CalcCount1 = CalcCount1 + 1
                Else
                    CalcCount1 = 0
                End If

                If CalcCount1 > 5 Then
                    Do_Off(0)
                    Do_Off(1)
                    wStep = 112
                End If
            End If

        ElseIf wStep = 112 Then

            For i = 0 To ArryCount1 - 1
                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphReclFAmp.Cursors.Item(0).XPosition = 1
            srcGraphReclFAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphReclFNoise.Cursors.Item(0).XPosition = 1
            srcGraphReclFNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbValReclFwdAmp.Text = Format(TmpAmpMAx1, "0.0")
            srclbValReclFwdNoise.Text = Format(TmpNoiseMax1, "0.0")
            srclbValReclFwdAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
            srclbValReclFwdEndAngle.Text = Format(Laser2Angle(vLaser1), "0.0")
            srclbValReclFwdSpeed.Text = Format((Math.Abs(CDbl(srclbValReclFwdStartAngle.Text)) + Math.Abs(CDbl(srclbValReclFwdEndAngle.Text))) / CDbl(srclbValReclFwdTicTime.Text), "0.0")


            If TmpAmpMAx1 >= BasicReclFwdAmpMin And TmpAmpMAx1 <= BasicReclFwdAmpMax Then
                srclbDecReclFwdAmp.Text = "OK"
                srclbDecReclFwdAmp.BackColor = Color.Blue
            Else
                srclbDecReclFwdAmp.Text = "NG"
                srclbDecReclFwdAmp.BackColor = Color.Red
            End If

            If TmpNoiseMax1 >= BasicReclFwdNoiseMin And TmpNoiseMax1 <= BasicReclFwdNoiseMax Then
                srclbDecReclFwdNoise.Text = "OK"
                srclbDecReclFwdNoise.BackColor = Color.Blue
            Else
                srclbDecReclFwdNoise.Text = "NG"
                srclbDecReclFwdNoise.BackColor = Color.Red
            End If

            If CDbl(srclbValReclFwdAngle.Text) >= BasicReclFwdAngleMin And CDbl(srclbValReclFwdAngle.Text) <= BasicReclFwdAngleMax Then
                srclbDecReclFwdAngle.Text = "OK"
                srclbDecReclFwdAngle.BackColor = Color.Blue
            Else
                srclbDecReclFwdAngle.Text = "NG"
                srclbDecReclFwdAngle.BackColor = Color.Red
            End If

            If CDbl(srclbValReclFwdSpeed.Text) >= BasicReclFwdSpeedMin And CDbl(srclbValReclFwdSpeed.Text) <= BasicReclFwdSpeedMax Then
                srclbDecReclFwdSpeed.Text = "OK"
                srclbDecReclFwdSpeed.BackColor = Color.Blue
            Else
                srclbDecReclFwdSpeed.Text = "NG"
                srclbDecReclFwdSpeed.BackColor = Color.Red
            End If

            wStep = 113

        ElseIf wStep = 113 Then

            wStep = 100.1

        ElseIf wStep = 120 Then 'PWR BWD END

            Do_On(1)
            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            wStep = 121

        ElseIf wStep = 121 Then

            srclbValReclEndAngle.Text = Format(Laser2Angle(vLaser1), "0.0")

            If CDbl(srclbValReclEndAngle.Text) >= BasicReclEndAngleMin And CDbl(srclbValReclEndAngle.Text) <= BasicReclEndAngleMax Then
                Do_Off(0)
                Do_Off(1)
                srclbDecReclEndAngle.Text = "OK"
                srclbDecReclEndAngle.BackColor = Color.Blue
                wStep = 130
            Else
                srclbDecReclEndAngle.Text = "NG"
                srclbDecReclEndAngle.BackColor = Color.Red
            End If

        ElseIf wStep = 300 Then 'FootRest Fwd

            Do_On(3)
            'If OPTION_LHRH = "LH" Then
            '    Do_On(2)
            'ElseIf OPTION_LHRH = "RH" Then
            '    Do_On(2)
            'End If

            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            srclbValFrestFwdStartAngle.Text = Format(Laser2Angle_Frest(vLaser2), "0.0")
            wStep = 301

        ElseIf wStep = 301 Then

            CounterAtNow1 = Timer.Value
            TotalTime1 = CDbl(((CounterAtNow1 - CounterAtStart1) * 10000 / Timer.Frequency) / 10000)

            If ArryCount1 < ArryMaxSize Then
                ArryNoise1(ArryCount1) = vNoise
                ArryAmp1(ArryCount1) = ValueAmp1
                ArryTime1(ArryCount1) = TotalTime1
                ArryCount1 = ArryCount1 + 1
            End If

            srcGraphFrestFAmp.PlotXYAppend(TotalTime1, ValueAmp1)
            srcGraphFrestFNoise.PlotXYAppend(TotalTime1, vNoise)
            srclbValFrestFwdTicTime.Text = Format(TotalTime1, "0.0#")

            If TotalTime1 > 2 Then
                If ValueAmp1 < 0.1 Or ValueAmp1 > BasicLsuptStopAmp Then
                    CalcCount1 = CalcCount1 + 1
                Else
                    CalcCount1 = 0
                End If

                If CalcCount1 > 5 Then
                    Do_Off(2)
                    Do_Off(3)
                    wStep = 302
                End If
            End If

        ElseIf wStep = 302 Then

            For i = 0 To ArryCount1 - 1
                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphFrestFAmp.Cursors.Item(0).XPosition = 1
            srcGraphFrestFAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphFrestFNoise.Cursors.Item(0).XPosition = 1
            srcGraphFrestFNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbValFrestFwdAmp.Text = Format(TmpAmpMAx1, "0.0")
            srclbValFrestFwdNoise.Text = Format(TmpNoiseMax1, "0.0")
            srclbValFrestFwdEndAngle.Text = Format(Laser2Angle_Frest(vLaser2), "0.0")
            srclbValFrestFwdSpeed.Text = Format((Math.Abs(CDbl(srclbValFrestFwdStartAngle.Text)) + Math.Abs(CDbl(srclbValFrestFwdEndAngle.Text))) / CDbl(srclbValFrestFwdTicTime.Text), "0.0")

            If CDbl(srclbValFrestFwdSpeed.Text) >= BasicFrestFwdSpeedMin And CDbl(srclbValFrestFwdSpeed.Text) <= BasicFrestFwdSpeedMax Then
                srclbDecFrestFwdSpeed.Text = "OK"
                srclbDecFrestFwdSpeed.BackColor = Color.Blue
            Else
                srclbDecFrestFwdSpeed.Text = "NG"
                srclbDecFrestFwdSpeed.BackColor = Color.Red
            End If

            If TmpAmpMAx1 >= BasicFrestFwdAmpMin And TmpAmpMAx1 <= BasicFrestFwdAmpMax Then
                srclbDecFrestFwdAmp.Text = "OK"
                srclbDecFrestFwdAmp.BackColor = Color.Blue
            Else
                srclbDecFrestFwdAmp.Text = "NG"
                srclbDecFrestFwdAmp.BackColor = Color.Red
            End If

            If TmpNoiseMax1 >= BasicFrestFwdNoiseMin And TmpNoiseMax1 <= BasicFrestFwdNoiseMax Then
                srclbDecFrestFwdNoise.Text = "OK"
                srclbDecFrestFwdNoise.BackColor = Color.Blue
            Else
                srclbDecFrestFwdNoise.Text = "NG"
                srclbDecFrestFwdNoise.BackColor = Color.Red
            End If

            If CDbl(srclbValFrestFwdSpeed.Text) >= BasicFrestFwdSpeedMin And CDbl(srclbValFrestFwdSpeed.Text) <= BasicFrestFwdSpeedMax Then
                srclbDecFrestFwdSpeed.Text = "OK"
                srclbDecFrestFwdSpeed.BackColor = Color.Blue
            Else
                srclbDecFrestFwdSpeed.Text = "NG"
                srclbDecFrestFwdSpeed.BackColor = Color.Red
            End If

            wStep = 303

        ElseIf wStep = 303 Then

            wStep = 310

        ElseIf wStep = 310 Then 'FootRest Bwd

            'If OPTION_LHRH = "LH" Then
            '    Do_On(3)
            'ElseIf OPTION_LHRH = "RH" Then
            '    Do_On(3)
            'End If
            Do_On(2)

            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            srclbValFrestBwdStartAngle.Text = Format(Laser2Angle_Frest(vLaser2), "0.0")
            wStep = 311

        ElseIf wStep = 311 Then

            CounterAtNow1 = Timer.Value
            TotalTime1 = CDbl(((CounterAtNow1 - CounterAtStart1) * 10000 / Timer.Frequency) / 10000)

            If ArryCount1 < ArryMaxSize Then
                ArryNoise1(ArryCount1) = vNoise
                ArryAmp1(ArryCount1) = ValueAmp1
                ArryTime1(ArryCount1) = TotalTime1
                ArryCount1 = ArryCount1 + 1
            End If

            srcGraphFrestBAmp.PlotXYAppend(TotalTime1, ValueAmp1)
            srcGraphFrestBNoise.PlotXYAppend(TotalTime1, vNoise)
            srclbValFrestBwdTicTime.Text = Format(TotalTime1, "0.0#")

            If TotalTime1 > 2 Then
                If ValueAmp1 < 0.1 Or ValueAmp1 > BasicLsuptStopAmp Then
                    CalcCount1 = CalcCount1 + 1
                Else
                    CalcCount1 = 0
                End If

                If CalcCount1 > 5 Then
                    Do_Off(2)
                    Do_Off(3)
                    wStep = 312
                End If
            End If

        ElseIf wStep = 312 Then

            For i = 0 To ArryCount1 - 1

                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphFrestBAmp.Cursors.Item(0).XPosition = 1
            srcGraphFrestBAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphFrestBNoise.Cursors.Item(0).XPosition = 1
            srcGraphFrestBNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbValFrestBwdAmp.Text = Format(TmpAmpMAx1, "0.0")
            srclbValFrestBwdNoise.Text = Format(TmpNoiseMax1, "0.0")
            srclbValFrestBwdEndAngle.Text = Format(Laser2Angle_Frest(vLaser2), "0.0")
            srclbValFrestBwdSpeed.Text = Format((Math.Abs(CDbl(srclbValFrestBwdStartAngle.Text)) + Math.Abs(CDbl(srclbValFrestBwdEndAngle.Text))) / CDbl(srclbValFrestBwdTicTime.Text), "0.0")

            If CDbl(srclbValFrestBwdSpeed.Text) >= BasicFrestBwdSpeedMin And CDbl(srclbValFrestBwdSpeed.Text) <= BasicFrestBwdSpeedMax Then
                srclbDecFrestBwdSpeed.Text = "OK"
                srclbDecFrestBwdSpeed.BackColor = Color.Blue
            Else
                srclbDecFrestBwdSpeed.Text = "NG"
                srclbDecFrestBwdSpeed.BackColor = Color.Red
            End If

            If TmpAmpMAx1 >= BasicFrestBwdAmpMin And TmpAmpMAx1 <= BasicFrestBwdAmpMax Then
                srclbDecFrestBwdAmp.Text = "OK"
                srclbDecFrestBwdAmp.BackColor = Color.Blue
            Else
                srclbDecFrestBwdAmp.Text = "NG"
                srclbDecFrestBwdAmp.BackColor = Color.Red
            End If

            If TmpNoiseMax1 >= BasicFrestBwdNoiseMin And TmpNoiseMax1 <= BasicFrestBwdNoiseMax Then
                srclbDecFrestBwdNoise.Text = "OK"
                srclbDecFrestBwdNoise.BackColor = Color.Blue
            Else
                srclbDecFrestBwdNoise.Text = "NG"
                srclbDecFrestBwdNoise.BackColor = Color.Red
            End If

            If CDbl(srclbValFrestBwdSpeed.Text) >= BasicFrestBwdSpeedMin And CDbl(srclbValFrestBwdSpeed.Text) <= BasicFrestBwdSpeedMax Then
                srclbDecFrestBwdSpeed.Text = "OK"
                srclbDecFrestBwdSpeed.BackColor = Color.Blue
            Else
                srclbDecFrestBwdSpeed.Text = "NG"
                srclbDecFrestBwdSpeed.BackColor = Color.Red
            End If

            wStep = 313

        ElseIf wStep = 313 Then

            wStep = 350

        ElseIf wStep = 600 Then 'LH RH AIR 흡기

            If OPTION_LHRH = "LH" Then
                Do_On(11)
            ElseIf OPTION_LHRH = "RH" Then
                Do_On(5)
            End If

            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            wStep = 601

        ElseIf wStep = 601 Then

            CounterAtNow1 = Timer.Value
            TotalTime1 = CDbl(((CounterAtNow1 - CounterAtStart1) * 10000 / Timer.Frequency) / 10000)

            If 1 < TotalTime1 And TotalTime1 < (BasicLsuptInfTime - 1) Then '커넥터 분리
                If ValueAmp2 < 0.05 Then
                    Do_Off(11)
                    Do_Off(5)
                    wStep = 601.1
                End If
            End If

            If ArryCount1 < ArryMaxSize Then
                ArryNoise1(ArryCount1) = vNoise
                ArryAmp1(ArryCount1) = ValueAmp2
                ArryTime1(ArryCount1) = TotalTime1
                ArryCount1 = ArryCount1 + 1
            End If

            srcGraphLsuptAmp.Plots(0).PlotXYAppend(TotalTime1, ValueAmp2)
            srcGraphLsuptNoise.Plots(0).PlotXYAppend(TotalTime1, vNoise)

            If TotalTime1 >= BasicLsuptInfTime Then
                Do_Off(11)
                Do_Off(5)
                wStep = 602
            End If

        ElseIf wStep = 601.1 Then

            For i = 0 To ArryCount1 - 1
                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphLsuptAmp.Cursors.Item(0).XPosition = 1
            srcGraphLsuptAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphLsuptNoise.Cursors.Item(0).XPosition = 1
            srcGraphLsuptNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbDataLsuptMidAmp.Text = Format(0, "0.0")
            srclbDataLsuptMidNoise.Text = Format(TmpNoiseMax1, "0.0")

            srclbDecLsuptMidAmp.Text = "NG"
            srclbDecLsuptMidAmp.BackColor = Color.Red
            
            If TmpNoiseMax1 >= BasicLsuptNoiseMin And TmpNoiseMax1 <= BasicLsuptNoiseMax Then
                srclbDecLsuptMidNoise.Text = "OK"
                srclbDecLsuptMidNoise.BackColor = Color.Blue
            Else
                srclbDecLsuptMidNoise.Text = "NG"
                srclbDecLsuptMidNoise.BackColor = Color.Red
            End If
            wStep = 603

        ElseIf wStep = 602 Then

            For i = 0 To ArryCount1 - 1
                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphLsuptAmp.Cursors.Item(0).XPosition = 1
            srcGraphLsuptAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphLsuptNoise.Cursors.Item(0).XPosition = 1
            srcGraphLsuptNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbDataLsuptMidAmp.Text = Format(TmpAmpMAx1, "0.0")
            srclbDataLsuptMidNoise.Text = Format(TmpNoiseMax1, "0.0")

            If TmpAmpMAx1 >= BasicLsuptAmpMin And TmpAmpMAx1 <= BasicLsuptAmpMax Then
                srclbDecLsuptMidAmp.Text = "OK"
                srclbDecLsuptMidAmp.BackColor = Color.Blue
            Else
                srclbDecLsuptMidAmp.Text = "NG"
                srclbDecLsuptMidAmp.BackColor = Color.Red
            End If

            If TmpNoiseMax1 >= BasicLsuptNoiseMin And TmpNoiseMax1 <= BasicLsuptNoiseMax Then
                srclbDecLsuptMidNoise.Text = "OK"
                srclbDecLsuptMidNoise.BackColor = Color.Blue
            Else
                srclbDecLsuptMidNoise.Text = "NG"
                srclbDecLsuptMidNoise.BackColor = Color.Red
            End If
            wStep = 603

        ElseIf wStep = 603 Then 'LH RH 배기

            If OPTION_LHRH = "LH" Then
                Do_On(13)
            ElseIf OPTION_LHRH = "RH" Then
                Do_On(7)
            End If

            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            wStep = 604

        ElseIf wStep = 604 Then

            CounterAtNow1 = Timer.Value
            TotalTime1 = CDbl(((CounterAtNow1 - CounterAtStart1) * 10000 / Timer.Frequency) / 10000)

            If 1 < TotalTime1 And TotalTime1 < (BasicLsuptDefTime - 1) Then
                If ValueAmp2 < 0.05 Then
                    Do_Off(13)
                    Do_Off(7)
                    wStep = 604.1
                End If
            End If

            If ArryCount1 < ArryMaxSize Then
                ArryNoise1(ArryCount1) = vNoise
                ArryAmp1(ArryCount1) = ValueAmp2
                ArryTime1(ArryCount1) = TotalTime1
                ArryCount1 = ArryCount1 + 1
            End If

            srcGraphLsuptAmp.Plots(1).PlotXYAppend(TotalTime1, ValueAmp2)
            'srcGraphLsuptNoise.Plots(1).PlotXYAppend(TotalTime1, vNoise)

            If TotalTime1 >= BasicLsuptDefTime Then
                Do_Off(13)
                Do_Off(7)
                wStep = 605
            End If

        ElseIf wStep = 604.1 Then

            srcGraphLsuptAmp.Cursors.Item(0).XPosition = 1
            srcGraphLsuptAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphLsuptNoise.Cursors.Item(0).XPosition = 1
            srcGraphLsuptNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbDataLsuptDefAmp.Text = Format(0, "0.0")
            srclbDecLsuptDefAmp.Text = "NG"
            srclbDecLsuptDefAmp.BackColor = Color.Red

            wStep = 700

        ElseIf wStep = 605 Then

            For i = 0 To ArryCount1 - 1
                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphLsuptAmp.Cursors.Item(0).XPosition = 1
            srcGraphLsuptAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphLsuptNoise.Cursors.Item(0).XPosition = 1
            srcGraphLsuptNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbDataLsuptDefAmp.Text = Format(TmpAmpMAx1, "0.0")
            'srclbDataLsuptDefNoise.Text = Format(TmpNoiseMax1, "0.0")

            If TmpAmpMAx1 >= BasicLsuptAmpMin And TmpAmpMAx1 <= BasicLsuptAmpMax Then
                srclbDecLsuptDefAmp.Text = "OK"
                srclbDecLsuptDefAmp.BackColor = Color.Blue
            Else
                srclbDecLsuptDefAmp.Text = "NG"
                srclbDecLsuptDefAmp.BackColor = Color.Red
            End If
            wStep = 700

        ElseIf wStep = 800 Then '볼스터 흡기

            If OPTION_LHRH = "LH" Then
                Do_On(14)
            ElseIf OPTION_LHRH = "RH" Then
                Do_On(8)
            End If

            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            wStep = 801

        ElseIf wStep = 801 Then

            CounterAtNow1 = Timer.Value
            TotalTime1 = CDbl(((CounterAtNow1 - CounterAtStart1) * 10000 / Timer.Frequency) / 10000)

            If 1 < TotalTime1 And TotalTime1 < (BasicBolsterInfTime - 1) Then
                If ValueAmp2 < 0.05 Then
                    Do_Off(14)
                    Do_Off(8)
                    wStep = 801.1
                End If
            End If

            If ArryCount1 < ArryMaxSize Then
                ArryNoise1(ArryCount1) = vNoise
                ArryAmp1(ArryCount1) = ValueAmp2
                ArryTime1(ArryCount1) = TotalTime1
                ArryCount1 = ArryCount1 + 1
            End If

            srcGraphBolsterAmp.Plots(0).PlotXYAppend(TotalTime1, ValueAmp2)
            srcGraphBolsterNoise.Plots(0).PlotXYAppend(TotalTime1, vNoise)

            If TotalTime1 >= BasicBolsterInfTime Then
                Do_Off(14)
                Do_Off(8)
                wStep = 802
            End If

        ElseIf wStep = 801.1 Then

            For i = 0 To ArryCount1 - 1
                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphBolsterAmp.Cursors.Item(0).XPosition = 1
            srcGraphBolsterAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphBolsterNoise.Cursors.Item(0).XPosition = 1
            srcGraphBolsterNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbDataBolsterInfAmp.Text = Format(0, "0.0")
            srclbDataBolsterInfNoise.Text = Format(TmpNoiseMax1, "0.0")

            srclbDecBolsterInfAmp.Text = "NG"
            srclbDecBolsterInfAmp.BackColor = Color.Red
            
            If TmpNoiseMax1 >= BasicLsuptNoiseMin And TmpNoiseMax1 <= BasicLsuptNoiseMax Then
                srclbDecBolsterInfNoise.Text = "OK"
                srclbDecBolsterInfNoise.BackColor = Color.Blue
            Else
                srclbDecBolsterInfNoise.Text = "NG"
                srclbDecBolsterInfNoise.BackColor = Color.Red
            End If
            wStep = 803

        ElseIf wStep = 802 Then

            For i = 0 To ArryCount1 - 1
                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphBolsterAmp.Cursors.Item(0).XPosition = 1
            srcGraphBolsterAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphBolsterNoise.Cursors.Item(0).XPosition = 1
            srcGraphBolsterNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbDataBolsterInfAmp.Text = Format(TmpAmpMAx1, "0.0")
            srclbDataBolsterInfNoise.Text = Format(TmpNoiseMax1, "0.0")

            If TmpAmpMAx1 >= BasicLsuptAmpMin And TmpAmpMAx1 <= BasicLsuptAmpMax Then
                srclbDecBolsterInfAmp.Text = "OK"
                srclbDecBolsterInfAmp.BackColor = Color.Blue
            Else
                srclbDecBolsterInfAmp.Text = "NG"
                srclbDecBolsterInfAmp.BackColor = Color.Red
            End If

            If TmpNoiseMax1 >= BasicLsuptNoiseMin And TmpNoiseMax1 <= BasicLsuptNoiseMax Then
                srclbDecBolsterInfNoise.Text = "OK"
                srclbDecBolsterInfNoise.BackColor = Color.Blue
            Else
                srclbDecBolsterInfNoise.Text = "NG"
                srclbDecBolsterInfNoise.BackColor = Color.Red
            End If
            wStep = 803

        ElseIf wStep = 803 Then '볼스터 배기

            If OPTION_LHRH = "LH" Then
                Do_On(15)
            ElseIf OPTION_LHRH = "RH" Then
                Do_On(9)
            End If

            ErrCount1 = 0
            CounterAtStart1 = Timer.Value
            TmpAmpMAx1 = 0
            TmpNoiseMax1 = 0
            ArryCount1 = 0
            CalcCount1 = 0
            wStep = 804

        ElseIf wStep = 804 Then

            CounterAtNow1 = Timer.Value
            TotalTime1 = CDbl(((CounterAtNow1 - CounterAtStart1) * 10000 / Timer.Frequency) / 10000)

            If 1 < TotalTime1 And TotalTime1 < (BasicBolsterDefTime - 1) Then
                If ValueAmp2 < 0.05 Then
                    Do_Off(15)
                    Do_Off(9)
                    wStep = 805.1
                End If
            End If
            If ArryCount1 < ArryMaxSize Then
                ArryNoise1(ArryCount1) = vNoise
                ArryAmp1(ArryCount1) = ValueAmp2
                ArryTime1(ArryCount1) = TotalTime1
                ArryCount1 = ArryCount1 + 1
            End If

            srcGraphBolsterAmp.Plots(1).PlotXYAppend(TotalTime1, ValueAmp2)

            If TotalTime1 >= BasicBolsterDefTime Then
                Do_Off(15)
                Do_Off(9)
                wStep = 805
            End If

        ElseIf wStep = 805 Then

            For i = 0 To ArryCount1 - 1
                If ArryTime1(i) >= 1 And ArryTime1(i) <= TotalTime1 - 1 Then
                    If TmpAmpMAx1 < ArryAmp1(i) Then TmpAmpMAx1 = ArryAmp1(i)
                    If TmpNoiseMax1 < ArryNoise1(i) Then TmpNoiseMax1 = ArryNoise1(i)
                End If
            Next

            srcGraphBolsterAmp.Cursors.Item(0).XPosition = 1
            srcGraphBolsterAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphBolsterNoise.Cursors.Item(0).XPosition = 1
            srcGraphBolsterNoise.Cursors.Item(1).XPosition = TotalTime1 - 1

            srclbDataBolsterDefAmp.Text = Format(TmpAmpMAx1, "0.0")

            If TmpAmpMAx1 >= BasicLsuptAmpMin And TmpAmpMAx1 <= BasicLsuptAmpMax Then
                srclbDecBolsterDefAmp.Text = "OK"
                srclbDecBolsterDefAmp.BackColor = Color.Blue
            Else
                srclbDecBolsterDefAmp.Text = "NG"
                srclbDecBolsterDefAmp.BackColor = Color.Red
            End If
            wStep = 1000

        ElseIf wStep = 805.1 Then '케이블 단선시

            srcGraphBolsterAmp.Cursors.Item(0).XPosition = 1
            srcGraphBolsterAmp.Cursors.Item(1).XPosition = TotalTime1 - 1
            srcGraphBolsterNoise.Cursors.Item(0).XPosition = 1
            srcGraphBolsterNoise.Cursors.Item(1).XPosition = TotalTime1 - 1
            srclbDataBolsterDefAmp.Text = Format(0, "0.0")
            srclbDecBolsterDefAmp.Text = "NG"
            srclbDecBolsterDefAmp.BackColor = Color.Red
            wStep = 1000

        End If

        System.Threading.Monitor.Exit(DaqTaskComponent1)

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
            'lbD4002.Text = PlcValue(4002)
            'lbD4003.Text = PlcValue(4003)
            'lbD4004.Text = PlcValue(4004)
            'lbD4005.Text = PlcValue(4005)
            'lbD4006.Text = PlcValue(4006)
            'lbD4007.Text = PlcValue(4007)
            'lbD4008.Text = PlcValue(4008)
            'lbD4009.Text = PlcValue(4009)

            lbD4050.Text = PlcValue(4050)
            'lbD4051.Text = PlcValue(4051)
            'lbD4052.Text = PlcValue(4052)
            'lbD4053.Text = PlcValue(4053)
            'lbD4054.Text = PlcValue(4054)
            'lbD4055.Text = PlcValue(4055)
            'lbD4056.Text = PlcValue(4056)
            'lbD4057.Text = PlcValue(4057)
            'lbD4058.Text = PlcValue(4058)
            'lbD4059.Text = PlcValue(4059)

            PlcConnectionError = "OK"

        Else

            PlcConnectionError = Dec2Hex(iReturnCode)

        End If

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

    Private Sub VitualKeyboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VitualKeyboardToolStripMenuItem.Click

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

End Class