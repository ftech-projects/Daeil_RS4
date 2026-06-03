Module Module1

    Public PlcValue(0 To 5000) As Integer

    Public AddressOfPLc As String
    Public FlagPlcConnection As Boolean
    Public PlcConnectionError As String
    Public PlcConnectionStep As Integer

    Public BarcodeS1X As String
    Public BarcodeS1Y As String
    Public BarcodeS1H As String
    Public BarcodeS1W As String
    Public BarcodeS2X As String
    Public BarcodeS2Y As String
    Public BarcodeS2H As String
    Public BarcodeS2W As String
    Public BarcodeS3X As String
    Public BarcodeS3Y As String
    Public BarcodeS3H As String
    Public BarcodeS3W As String
    Public BarcodeS4X As String
    Public BarcodeS4Y As String
    Public BarcodeS4H As String
    Public BarcodeS4W As String
    Public BarcodeS5X As String
    Public BarcodeS5Y As String
    Public BarcodeS5H As String
    Public BarcodeS5W As String
    Public BarcodeBX As String
    Public BarcodeBY As String
    Public BarcodeBH As String
    Public BarcodeBL As String
    Public BarcodeBS As String

    Public PortNumber_Printer As String
    Public PortNumber_ScannerL As String
    Public PortNumber_ScannerR As String
    Public PortNumber_Tool As String

    Public Password As String
    Public CheckFormBasic As Boolean
    Public CheckFormPort As Boolean
    Public CheckFormToolSet As Boolean

    Public WorkImage() As String

    Public BAsicUnit As String
    Public BasicToolMax As Double
    Public BasicToolMin As Double
    
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

    Public Sub LoadBarcodeData()

        ConnectionOpenMDB()
        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Barcode", MdbConnect)

        If Rs.RecordCount = 1 Then

            BarcodeS1X = CStr(Rs.Fields("S1X").Value)
            BarcodeS1Y = CStr(Rs.Fields("S1Y").Value)
            BarcodeS1W = CStr(Rs.Fields("S1W").Value)
            BarcodeS1H = CStr(Rs.Fields("S1H").Value)

            BarcodeS2X = CStr(Rs.Fields("S2X").Value)
            BarcodeS2Y = CStr(Rs.Fields("S2Y").Value)
            BarcodeS2W = CStr(Rs.Fields("S2W").Value)
            BarcodeS2H = CStr(Rs.Fields("S2H").Value)

            BarcodeS3X = CStr(Rs.Fields("S3X").Value)
            BarcodeS3Y = CStr(Rs.Fields("S3Y").Value)
            BarcodeS3W = CStr(Rs.Fields("S3W").Value)
            BarcodeS3H = CStr(Rs.Fields("S3H").Value)

            BarcodeS4X = CStr(Rs.Fields("S4X").Value)
            BarcodeS4Y = CStr(Rs.Fields("S4Y").Value)
            BarcodeS4W = CStr(Rs.Fields("S4W").Value)
            BarcodeS4H = CStr(Rs.Fields("S4H").Value)

            BarcodeS5X = CStr(Rs.Fields("S5X").Value)
            BarcodeS5Y = CStr(Rs.Fields("S5Y").Value)
            BarcodeS5W = CStr(Rs.Fields("S5W").Value)
            BarcodeS5H = CStr(Rs.Fields("S5H").Value)

            BarcodeBX = CStr(Rs.Fields("BX").Value)
            BarcodeBY = CStr(Rs.Fields("BY").Value)
            BarcodeBH = CStr(Rs.Fields("BH").Value)
            BarcodeBL = CStr(Rs.Fields("BL").Value)
            BarcodeBS = CStr(Rs.Fields("BS").Value)

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

    Public Sub SaveBarcodeData()

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Barcode", MdbConnect)

        If Rs.RecordCount = 1 Then


            Rs.Fields("S1X").Value = CStr(BarcodeS1X)
            Rs.Fields("S1Y").Value = CStr(BarcodeS1Y)
            Rs.Fields("S1W").Value = CStr(BarcodeS1W)
            Rs.Fields("S1H").Value = CStr(BarcodeS1H)

            Rs.Fields("S2X").Value = CStr(BarcodeS2X)
            Rs.Fields("S2Y").Value = CStr(BarcodeS2Y)
            Rs.Fields("S2W").Value = CStr(BarcodeS2W)
            Rs.Fields("S2H").Value = CStr(BarcodeS2H)

            Rs.Fields("S3X").Value = CStr(BarcodeS3X)
            Rs.Fields("S3Y").Value = CStr(BarcodeS3Y)
            Rs.Fields("S3W").Value = CStr(BarcodeS3W)
            Rs.Fields("S3H").Value = CStr(BarcodeS3H)

            Rs.Fields("S4X").Value = CStr(BarcodeS4X)
            Rs.Fields("S4Y").Value = CStr(BarcodeS4Y)
            Rs.Fields("S4W").Value = CStr(BarcodeS4W)
            Rs.Fields("S4H").Value = CStr(BarcodeS4H)

            Rs.Fields("S5X").Value = CStr(BarcodeS5X)
            Rs.Fields("S5Y").Value = CStr(BarcodeS5Y)
            Rs.Fields("S5W").Value = CStr(BarcodeS5W)
            Rs.Fields("S5H").Value = CStr(BarcodeS5H)

            Rs.Fields("BX").Value = CStr(BarcodeBX)
            Rs.Fields("BY").Value = CStr(BarcodeBY)
            Rs.Fields("BH").Value = CStr(BarcodeBH)
            Rs.Fields("BL").Value = CStr(BarcodeBL)
            Rs.Fields("BS").Value = CStr(BarcodeBS)

            Rs.Update()

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()


    End Sub

    Public Sub LoadBasicData()

        ConnectionOpenMDB()
        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_BASIC", MdbConnect)

        If Rs.RecordCount = 1 Then

            BAsicUnit = CStr(Rs.Fields("Unit").Value)
            BasicToolMin = CStr(Rs.Fields("toolmin").Value)
            BasicToolMax = CStr(Rs.Fields("toolmax").Value)

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

    Public Sub SaveBasicData()

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_BASIC", MdbConnect)

        If Rs.RecordCount = 1 Then

            Rs.Fields("Unit").Value = CStr(BAsicUnit)
            Rs.Fields("toolmin").Value = CStr(BasicToolMin)
            Rs.Fields("toolmax").Value = CStr(BasicToolMax)

            Rs.Update()

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

    Public Sub LoadPortData()

        ConnectionOpenMDB()
        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_SerialPort", MdbConnect)

        If Rs.RecordCount = 1 Then

            PortNumber_ScannerL = Rs.Fields("ScannerL").Value
            PortNumber_ScannerR = Rs.Fields("ScannerR").Value

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

    Public Sub SavePortData()

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_SerialPort", MdbConnect)

        If Rs.RecordCount = 1 Then

            Rs.Fields("ScannerL").Value = PortNumber_ScannerL
            Rs.Fields("ScannerR").Value = PortNumber_ScannerR
            Rs.Update()

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

End Module
