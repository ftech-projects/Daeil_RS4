Imports System.IO
Module Module1

    Public tmpLog(20000000) As String
    Public tmpLogCount As Int64

    Public MicroPhone_Tol As Double
    Public Sensitivity As Double

    Public vLaser1 As Double
    Public vLaser2 As Double
    Public vNoise As Double
    Public ValueAmp1 As Double
    Public ValueAmp2 As Double
    Public ValueVolt1 As Double
    Public ValueVolt2 As Double

    Public PortNumberScanner As String
    Public PortNumberPrinter As String
    Public PortNumberAmp1 As String
    Public PortNumberAmp2 As String
    Public PortNumberCan As String

    Public SqlConnect As ADODB.Connection
    Public MdbConnect As ADODB.Connection

    Public BasicLsuptInfTime As Double
    Public BasicLsuptDefTime As Double
    Public BasicBolsterInfTime As Double
    Public BasicBolsterDefTime As Double
    Public BasicLsuptAmpMin As Double
    Public BasicLsuptAmpMax As Double
    Public BasicLsuptNoiseMin As Double
    Public BasicLsuptNoiseMax As Double

    Public BasicReclStopAmp As Double
    Public BasicLsuptStopAmp As Double
    Public BasicLsuptFwdTime As Double
    Public BasicLsuptBwdTime As Double

    Public BasicReclFwdNoiseMin As Double
    Public BasicReclFwdNoiseMax As Double
    Public BasicReclFwdAmpMin As Double
    Public BasicReclFwdAmpMax As Double
    Public BasicReclFwdAngleMin As Double
    Public BasicReclFwdAngleMax As Double
    Public BasicReclFwdSpeedMin As Double
    Public BasicReclFwdSpeedMax As Double

    Public BasicReclBwdNoiseMin As Double
    Public BasicReclBwdNoiseMax As Double
    Public BasicReclBwdAmpMin As Double
    Public BasicReclBwdAmpMax As Double
    Public BasicReclBwdAngleMin As Double
    Public BasicReclBwdAngleMax As Double
    Public BasicReclBwdSpeedMin As Double
    Public BasicReclBwdSpeedMax As Double

    Public BasicFrestFwdNoiseMin As Double
    Public BasicFrestFwdNoiseMax As Double
    Public BasicFrestFwdAmpMin As Double
    Public BasicFrestFwdAmpMax As Double

    Public BasicFrestBwdNoiseMin As Double
    Public BasicFrestBwdNoiseMax As Double
    Public BasicFrestBwdAmpMin As Double
    Public BasicFrestBwdAmpMax As Double
    Public BasicFrestFwdSpeedMin As Double
    Public BasicFrestFwdSpeedMax As Double
    Public BasicFrestBwdSpeedMin As Double
    Public BasicFrestBwdSpeedMax As Double
    Public BasicReclEndAngleMin As Double
    Public BasicReclEndAngleMax As Double

    Public BasicReclVolt As Double
    Public BasicLsuptVolt As Double

    Public FlagTogether As Boolean
    Public B1X As String
    Public B1Y As String
    Public B1L As String
    Public B2X As String
    Public B2Y As String
    Public B2W As String
    Public B2H As String
    Public B3X As String
    Public B3Y As String
    Public B3W As String
    Public B3H As String
    Public B4X As String
    Public B4Y As String
    Public B4W As String
    Public B4H As String
    Public B5X As String
    Public B5Y As String
    Public B5W As String
    Public B5H As String
    Public B6X As String
    Public B6Y As String
    Public B6W As String
    Public B6H As String
    Public B7X As String
    Public B7Y As String
    Public B7W As String
    Public B7H As String

    Public Function Dec2Hex(ByVal DecNum As Long) As String
        Dim strReturn As String = ""
        Try
            Dim hexv As String, na As Long

            hexv = ""
            Do While DecNum > 0
                na = DecNum Mod 16
                Select Case na
                    Case 10
                        hexv = "A" + Trim(hexv)
                    Case 11
                        hexv = "B" + Trim(hexv)
                    Case 12
                        hexv = "C" + Trim(hexv)
                    Case 13
                        hexv = "D" + Trim(hexv)
                    Case 14
                        hexv = "E" + Trim(hexv)
                    Case 15
                        hexv = "F" + Trim(hexv)
                    Case Else
                        hexv = Str(na) + Trim(hexv)
                End Select
                If DecNum >= 16 Then
                    DecNum = Int(DecNum / 16)
                Else
                    hexv = "0" + Trim(hexv)
                    Exit Do
                End If
            Loop

            If Len(hexv) > 1 And (Len(hexv) Mod 2 = 1) Then
                strReturn = Mid(hexv, 2)
            Else
                strReturn = hexv
            End If
        Catch ex As Exception
            'RemoteLog(MethodBase.GetCurrentMethod().Name & ", ErrorNumber: " & Err.Number & ", Desc: " & Err.Description)
        End Try
        Dec2Hex = strReturn

    End Function

    Sub ConnectionOpen()
        SqlConnect = New ADODB.Connection
        Dim connection_string As String = "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"
        SqlConnect.ConnectionString = connection_string
        SqlConnect.Open()
    End Sub

    Sub ConnectionClose()
        SqlConnect.Close()
    End Sub

    Public Sub ConnectionOpenMdb()
        MdbConnect = New ADODB.Connection
        MdbConnect.ConnectionString = "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\DB\DB.mdb"
        MdbConnect.Open()
    End Sub

    Public Sub ConnectionCloseMdb()
        MdbConnect.Close()
    End Sub

    Public Sub LoadPortData()

        ConnectionOpenMdb()
        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_SerialPort", MdbConnect)

        If Rs.RecordCount = 1 Then

            PortNumberAmp1 = Rs.Fields("Amp1").Value
            PortNumberAmp2 = Rs.Fields("Amp2").Value
            PortNumberScanner = Rs.Fields("Scanner").Value
            PortNumberPrinter = Rs.Fields("Printer").Value
            PortNumberCan = Rs.Fields("CAN").Value
            Sensitivity = Rs.Fields("Sensitivity").Value
            MicroPhone_Tol = Rs.Fields("Microphone_Tol").Value

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMdb()

    End Sub

    Public Sub SavePortData()

        ConnectionOpenMdb()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_SerialPort", MdbConnect)

        If Rs.RecordCount = 1 Then

            Rs.Fields("amp1").Value = PortNumberAmp1
            Rs.Fields("amp2").Value = PortNumberAmp2
            Rs.Fields("scanner").Value = PortNumberScanner
            Rs.Fields("printer").Value = PortNumberPrinter
            Rs.Fields("CAN").Value = PortNumberCan
            Rs.Fields("Sensitivity").Value = Sensitivity
            Rs.Fields("Microphone_Tol").Value = MicroPhone_Tol

            Rs.Update()

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMdb()

    End Sub

    Public Sub LoadBarcodeData()

        ConnectionOpenMdb()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Barcode", MdbConnect)

        If Rs.RecordCount = 1 Then

            B1X = Rs.Fields("B1X").Value
            B1Y = Rs.Fields("B1Y").Value
            B1L = Rs.Fields("B1L").Value

            B2X = Rs.Fields("B2X").Value
            B2Y = Rs.Fields("B2Y").Value
            B2W = Rs.Fields("B2W").Value
            B2H = Rs.Fields("B2H").Value

            B3X = Rs.Fields("B3X").Value
            B3Y = Rs.Fields("B3Y").Value
            B3W = Rs.Fields("B3W").Value
            B3H = Rs.Fields("B3H").Value

            B4X = Rs.Fields("B4X").Value
            B4Y = Rs.Fields("B4Y").Value
            B4W = Rs.Fields("B4W").Value
            B4H = Rs.Fields("B4H").Value

            B5X = Rs.Fields("B5X").Value
            B5Y = Rs.Fields("B5Y").Value
            B5W = Rs.Fields("B5W").Value
            B5H = Rs.Fields("B5H").Value

            B6X = Rs.Fields("B6X").Value
            B6Y = Rs.Fields("B6Y").Value
            B6W = Rs.Fields("B6W").Value
            B6H = Rs.Fields("B6H").Value

            B7X = Rs.Fields("B7X").Value
            B7Y = Rs.Fields("B7Y").Value
            B7W = Rs.Fields("B7W").Value
            B7H = Rs.Fields("B7H").Value

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMdb()

    End Sub

    Public Sub SaveBarcodeData()

        ConnectionOpenMdb()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Barcode", MdbConnect)

        If Rs.RecordCount = 1 Then

            Rs.Fields("B1X").Value = B1X
            Rs.Fields("B1Y").Value = B1Y
            Rs.Fields("B1L").Value = B1L

            Rs.Fields("B2X").Value = B2X
            Rs.Fields("B2Y").Value = B2Y
            Rs.Fields("B2W").Value = B2W
            Rs.Fields("B2H").Value = B2H

            Rs.Fields("B3X").Value = B3X
            Rs.Fields("B3Y").Value = B3Y
            Rs.Fields("B3W").Value = B3W
            Rs.Fields("B3H").Value = B3H

            Rs.Fields("B4X").Value = B4X
            Rs.Fields("B4Y").Value = B4Y
            Rs.Fields("B4W").Value = B4W
            Rs.Fields("B4H").Value = B4H

            Rs.Fields("B5X").Value = B5X
            Rs.Fields("B5Y").Value = B5Y
            Rs.Fields("B5W").Value = B5W
            Rs.Fields("B5H").Value = B5H

            Rs.Fields("B6X").Value = B6X
            Rs.Fields("B6Y").Value = B6Y
            Rs.Fields("B6W").Value = B6W
            Rs.Fields("B6H").Value = B6H

            Rs.Fields("B7X").Value = B7X
            Rs.Fields("B7Y").Value = B7Y
            Rs.Fields("B7W").Value = B7W
            Rs.Fields("B7H").Value = B7H

            Rs.Update()

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMdb()

    End Sub


    Public Sub LoadBasicData()

        ConnectionOpenMdb()
        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Basic", MdbConnect)

        If Rs.RecordCount = 1 Then

            FlagTogether = Rs.Fields("FlagTogether").Value

            BasicReclFwdNoiseMin = CDbl(Rs.Fields("ReclFwdNoiseMin").Value)
            BasicReclFwdNoiseMax = CDbl(Rs.Fields("ReclFwdNoiseMax").Value)
            BasicReclFwdAmpMin = CDbl(Rs.Fields("ReclFwdAmpMin").Value)
            BasicReclFwdAmpMax = CDbl(Rs.Fields("ReclFwdAmpMax").Value)

            BasicReclBwdNoiseMin = CDbl(Rs.Fields("ReclBwdNoiseMin").Value)
            BasicReclBwdNoiseMax = CDbl(Rs.Fields("ReclBwdNoiseMax").Value)
            BasicReclBwdAmpMin = CDbl(Rs.Fields("ReclBwdAmpMin").Value)
            BasicReclBwdAmpMax = CDbl(Rs.Fields("ReclBwdAmpMax").Value)

            BasicFrestFwdNoiseMin = CDbl(Rs.Fields("frestFwdNoiseMin").Value)
            BasicFrestFwdNoiseMax = CDbl(Rs.Fields("frestFwdNoiseMax").Value)
            BasicFrestFwdAmpMin = CDbl(Rs.Fields("frestFwdAmpMin").Value)
            BasicFrestFwdAmpMax = CDbl(Rs.Fields("frestFwdAmpMax").Value)

            BasicFrestBwdNoiseMin = CDbl(Rs.Fields("frestBwdNoiseMin").Value)
            BasicFrestBwdNoiseMax = CDbl(Rs.Fields("frestBwdNoiseMax").Value)
            BasicFrestBwdAmpMin = CDbl(Rs.Fields("frestBwdAmpMin").Value)
            BasicFrestBwdAmpMax = CDbl(Rs.Fields("frestBwdAmpMax").Value)

            BasicFrestFwdSpeedMin = CDbl(Rs.Fields("frestfwdSpeedMin").Value)
            BasicFrestFwdSpeedMax = CDbl(Rs.Fields("frestfwdSpeedMax").Value)

            BasicFrestBwdSpeedMin = CDbl(Rs.Fields("frestBwdSpeedMin").Value)
            BasicFrestBwdSpeedMax = CDbl(Rs.Fields("frestBwdSpeedMax").Value)

            BasicReclFwdSpeedMin = CDbl(Rs.Fields("ReclfwdSpeedMin").Value)
            BasicReclFwdSpeedMax = CDbl(Rs.Fields("ReclfwdSpeedMax").Value)

            BasicReclBwdSpeedMin = CDbl(Rs.Fields("ReclbwdSpeedMin").Value)
            BasicReclBwdSpeedMax = CDbl(Rs.Fields("ReclbwdSpeedMax").Value)

            BasicReclEndAngleMin = CDbl(Rs.Fields("ReclEndAngleMin").Value)
            BasicReclEndAngleMax = CDbl(Rs.Fields("ReclEndAngleMAx").Value)

            BasicReclStopAmp = CDbl(Rs.Fields("ReclStopamp").Value)
            BasicLsuptStopAmp = CDbl(Rs.Fields("LsuptStopamp").Value)

            BasicLsuptInfTime = CDbl(Rs.Fields("LsuptInfTime").Value)
            BasicLsuptDefTime = CDbl(Rs.Fields("LsuptDefTime").Value)
            BasicBolsterInfTime = CDbl(Rs.Fields("BolsterInfTime").Value)
            BasicBolsterDefTime = CDbl(Rs.Fields("BolsterDefTime").Value)
            BasicLsuptAmpMax = CDbl(Rs.Fields("LsuptAmpMax").Value)
            BasicLsuptAmpMin = CDbl(Rs.Fields("LsuptAmpMin").Value)
            BasicLsuptNoiseMax = CDbl(Rs.Fields("LsuptNoiseMax").Value)
            BasicLsuptNoiseMin = CDbl(Rs.Fields("LsuptNoiseMin").Value)

            BasicReclVolt = CDbl(Rs.Fields("ReclVolt").Value)
            BasicLsuptVolt = CDbl(Rs.Fields("lsuptVolt").Value)

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMdb()

    End Sub

    Public Sub SaveBasicData()

        ConnectionOpenMdb()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_basic", MdbConnect)

        If Rs.RecordCount = 1 Then

            Rs.Fields("FlagTogether").Value = FlagTogether

            Rs.Fields("ReclFwdNoiseMin").Value = CStr(BasicReclFwdNoiseMin)
            Rs.Fields("ReclFwdNoiseMax").Value = CStr(BasicReclFwdNoiseMax)
            Rs.Fields("ReclFwdAmpMin").Value = CStr(BasicReclFwdAmpMin)
            Rs.Fields("ReclFwdAmpMax").Value = CStr(BasicReclFwdAmpMax)

            Rs.Fields("ReclBwdNoiseMin").Value = CStr(BasicReclBwdNoiseMin)
            Rs.Fields("ReclBwdNoiseMax").Value = CStr(BasicReclBwdNoiseMax)
            Rs.Fields("ReclBwdAmpMin").Value = CStr(BasicReclBwdAmpMin)
            Rs.Fields("ReclBwdAmpMax").Value = CStr(BasicReclBwdAmpMax)

            Rs.Fields("FrestFwdNoiseMin").Value = CStr(BasicFrestFwdNoiseMin)
            Rs.Fields("FrestFwdNoiseMax").Value = CStr(BasicFrestFwdNoiseMax)
            Rs.Fields("FrestFwdAmpMin").Value = CStr(BasicFrestFwdAmpMin)
            Rs.Fields("FrestFwdAmpMax").Value = CStr(BasicFrestFwdAmpMax)

            Rs.Fields("FrestBwdNoiseMin").Value = CStr(BasicFrestBwdNoiseMin)
            Rs.Fields("FrestBwdNoiseMax").Value = CStr(BasicFrestBwdNoiseMax)
            Rs.Fields("FrestBwdAmpMin").Value = CStr(BasicFrestBwdAmpMin)
            Rs.Fields("FrestBwdAmpMax").Value = CStr(BasicFrestBwdAmpMax)

            Rs.Fields("ReclfwdSpeedMin").Value = CStr(BasicReclFwdSpeedMin)
            Rs.Fields("ReclfwdSpeedMax").Value = CStr(BasicReclFwdSpeedMax)
            Rs.Fields("ReclbwdSpeedMin").Value = CStr(BasicReclBwdSpeedMin)
            Rs.Fields("ReclbwdSpeedMax").Value = CStr(BasicReclBwdSpeedMax)

            Rs.Fields("FrestfwdSpeedMin").Value = CStr(BasicFrestFwdSpeedMin)
            Rs.Fields("FrestfwdSpeedMax").Value = CStr(BasicFrestFwdSpeedMax)
            Rs.Fields("FrestbwdSpeedMin").Value = CStr(BasicFrestBwdSpeedMin)
            Rs.Fields("FrestbwdSpeedMax").Value = CStr(BasicFrestBwdSpeedMax)

            Rs.Fields("ReclStopAmp").Value = CStr(BasicReclStopAmp)
            Rs.Fields("LsuptStopAmp").Value = CStr(BasicLsuptStopAmp)

            'Rs.Fields("LsuptFwdTime").Value = CStr(BasicLsuptFwdTime)
            'Rs.Fields("LsuptBwdTime").Value = CStr(BasicLsuptBwdTime)

            Rs.Fields("LsuptInfTime").Value = CStr(BasicLsuptInfTime)
            Rs.Fields("LsuptDefTime").Value = CStr(BasicLsuptDefTime)
            Rs.Fields("BolsterInfTime").Value = CStr(BasicBolsterInfTime)
            Rs.Fields("BolsterDefTime").Value = CStr(BasicBolsterDefTime)
            Rs.Fields("LsuptAmpMax").Value = CStr(BasicLsuptAmpMax)
            Rs.Fields("LsuptAmpMin").Value = CStr(BasicLsuptAmpMin)
            Rs.Fields("LsuptNoiseMax").Value = CStr(BasicLsuptNoiseMax)
            Rs.Fields("LsuptNoiseMin").Value = CStr(BasicLsuptNoiseMin)

            Rs.Fields("ReclVolt").Value = CStr(BasicReclVolt)
            Rs.Fields("lsuptVolt").Value = CStr(BasicLsuptVolt)


            Rs.Update()

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMdb()

    End Sub

    Public Class HiResTimer

        Private isPerfCounterSupported As Boolean = False
        Private timerFrequency As Int64 = 0
        Declare Function QueryPerformanceCounter Lib "Kernel32" (ByRef X As Long) As Short
        Declare Function QueryPerformanceFrequency Lib "Kernel32" (ByRef X As Long) As Short

        Public Sub New()
            Dim returnVal As Integer = QueryPerformanceFrequency(timerFrequency)
            If returnVal <> 0 AndAlso timerFrequency <> 1000 Then
                isPerfCounterSupported = True
            Else
                timerFrequency = 1000
            End If
        End Sub

        Public ReadOnly Property Frequency() As Int64
            Get
                Return timerFrequency
            End Get
        End Property

        Public ReadOnly Property Value() As Int64
            Get
                Dim tickCount As Int64 = 0

                If isPerfCounterSupported Then
                    QueryPerformanceCounter(tickCount)
                    Return tickCount
                Else
                    Return CType(Environment.TickCount, Int64)
                End If
            End Get
        End Property

    End Class

    Function FolderCheck(ByVal folder As String) As Boolean
        Try
            Return System.IO.Directory.Exists(folder)
        Catch ex As Exception
            Return System.IO.Directory.Exists(folder)
        End Try
    End Function

    Function FileCheck(ByVal folder As String, ByVal file As String) As Boolean
        Return System.IO.File.Exists(folder & "\" & file)
    End Function

    Sub FolderMake(ByVal folder As String)
        Try
            System.IO.Directory.CreateDirectory(folder)
        Catch ex As Exception
        End Try
    End Sub

    Sub FileWrite(ByVal folder As String, ByVal file As String, ByVal str As String)
        Try
            Using f As New StreamWriter(folder & "\" & file, True)
                f.WriteLine(str)
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Sub FileMake(ByVal folder As String, ByVal File As String)
        Try
            System.IO.File.Create(folder & "\" & File)
        Catch ex As Exception
        End Try
    End Sub
End Module
