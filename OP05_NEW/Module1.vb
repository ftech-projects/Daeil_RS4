Module Module1

    Public NOW_COLOR As String
    Public FlagDuplicate As Boolean
    Public FlagBeforeCheck As Boolean

    Public PlcValue(0 To 5000) As Integer

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
    Public PortNumber_Scanner As String
    Public PortNumber_Tool As String
    Public PortNumber_Laser As String
    Public PortNumber_Io As String

    Public Password As String
    Public CheckFormBasic As Boolean
    Public CheckFormPort As Boolean
    Public CheckFormToolSet As Boolean

    Public WorkImage() As String

    Public BAsicFrtMin_STDLH As Double
    Public BAsicFrtMax_STDLH As Double
    Public BAsicFrtMin_VIPRH As Double
    Public BAsicFrtMax_VIPRH As Double
    Public BAsicFrtMin_FOLDRH As Double
    Public BAsicFrtMax_FOLDRH As Double

    Public BAsicRearMin_STDLH As Double
    Public BAsicRearMax_STDLH As Double
    Public BAsicRearMin_VIPRH As Double
    Public BAsicRearMax_VIPRH As Double
    Public BAsicRearMin_FOLDRH As Double
    Public BAsicRearMax_FOLDRH As Double

    Public BasicRearTolSTD As Double
    Public basicFrtTolSTD As Double
    Public BasicRearTolVIP As Double
    Public basicFrtTolVIP As Double
    Public BasicRearTolFOLD As Double
    Public basicFrtTolFOLD As Double

    Public BasicFrtMin_PE As Double
    Public BasicFrtMax_PE As Double
    Public BasicRearMin_PE As Double
    Public BasicRearMax_PE As Double
    Public basicFrtTolPE As Double
    Public BasicRearTolPE As Double

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

    Private Sub ApplyDefaultPortData()
        PortNumber_Scanner = "COM3"
        PortNumber_Printer = "Disabled"
        PortNumber_Tool = "Disabled"
        PortNumber_Laser = "COM5"
        PortNumber_Io = "COM4"
    End Sub

    Private Sub ReadBarcodeFromRecordset(Rs As ADODB.Recordset)
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
    End Sub

    Private Sub WriteBarcodeToRecordset(Rs As ADODB.Recordset)
        Rs.Fields("S1X").Value = BarcodeS1X
        Rs.Fields("S1Y").Value = BarcodeS1Y
        Rs.Fields("S1W").Value = BarcodeS1W
        Rs.Fields("S1H").Value = BarcodeS1H

        Rs.Fields("S2X").Value = BarcodeS2X
        Rs.Fields("S2Y").Value = BarcodeS2Y
        Rs.Fields("S2W").Value = BarcodeS2W
        Rs.Fields("S2H").Value = BarcodeS2H

        Rs.Fields("S3X").Value = BarcodeS3X
        Rs.Fields("S3Y").Value = BarcodeS3Y
        Rs.Fields("S3W").Value = BarcodeS3W
        Rs.Fields("S3H").Value = BarcodeS3H

        Rs.Fields("S4X").Value = BarcodeS4X
        Rs.Fields("S4Y").Value = BarcodeS4Y
        Rs.Fields("S4W").Value = BarcodeS4W
        Rs.Fields("S4H").Value = BarcodeS4H

        Rs.Fields("S5X").Value = BarcodeS5X
        Rs.Fields("S5Y").Value = BarcodeS5Y
        Rs.Fields("S5W").Value = BarcodeS5W
        Rs.Fields("S5H").Value = BarcodeS5H

        Rs.Fields("BX").Value = BarcodeBX
        Rs.Fields("BY").Value = BarcodeBY
        Rs.Fields("BH").Value = BarcodeBH
        Rs.Fields("BL").Value = BarcodeBL
        Rs.Fields("BS").Value = BarcodeBS
    End Sub

    Public Function LoadBarcodeData() As Boolean
        LastMdbError = ""
        If Not EnsureBarcodeTableRow() Then Return False
        If Not ConnectionOpenMDB() Then Return False

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        Rs.LockType = ADODB.LockTypeEnum.adLockReadOnly

        Try
            Rs.Open("SELECT TOP 1 * FROM Table_Barcode ORDER BY ID", MdbConnect)
            If Rs.EOF Then
                LastMdbError = "Table_Barcode에 데이터가 없습니다."
                Return False
            End If
            ReadBarcodeFromRecordset(Rs)
            Return True
        Catch ex As Exception
            LastMdbError = "LoadBarcodeData: " & ex.Message
            Return False
        Finally
            Try
                Rs.ActiveConnection = Nothing
                Rs.Close()
            Catch
            End Try
            ConnectionCloseMDB()
        End Try
    End Function

    Public Function SaveBarcodeData() As Boolean
        LastMdbError = ""
        If Not EnsureBarcodeTableRow() Then Return False
        If Not ConnectionOpenMDB() Then Return False

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Try
            Rs.Open("SELECT TOP 1 * FROM Table_Barcode ORDER BY ID", MdbConnect)
            If Rs.EOF Then
                LastMdbError = "Table_Barcode에 저장할 행이 없습니다."
                Return False
            End If
            WriteBarcodeToRecordset(Rs)
            Rs.Update()
            Return True
        Catch ex As Exception
            LastMdbError = "SaveBarcodeData: " & ex.Message &
                " (Program Files 아래 DB면 쓰기 권한·관리자 실행 확인)"
            Return False
        Finally
            Try
                Rs.ActiveConnection = Nothing
                Rs.Close()
            Catch
            End Try
            ConnectionCloseMDB()
        End Try
    End Function

    Private Function TryReadDoubleField(Rs As ADODB.Recordset, fieldName As String, defaultValue As Double) As Double
        Try
            Dim raw As Object = Rs.Fields(fieldName).Value
            If IsDBNull(raw) Then Return defaultValue
            Return CDbl(raw)
        Catch
            Return defaultValue
        End Try
    End Function

    Private Sub TryWriteDoubleField(Rs As ADODB.Recordset, fieldName As String, value As Double)
        Try
            Rs.Fields(fieldName).Value = value
        Catch
        End Try
    End Sub

    Private Sub ReadBasicFromRecordset(Rs As ADODB.Recordset)
        BAsicFrtMin_STDLH = CDbl(Rs.Fields("FrtMin_STDLH").Value)
        BAsicFrtMax_STDLH = CDbl(Rs.Fields("FrtMax_STDLH").Value)
        BAsicRearMin_STDLH = CDbl(Rs.Fields("RearMin_STDLH").Value)
        BAsicRearMax_STDLH = CDbl(Rs.Fields("RearMax_STDLH").Value)

        BAsicFrtMin_VIPRH = CDbl(Rs.Fields("FrtMin_VIPRH").Value)
        BAsicFrtMax_VIPRH = CDbl(Rs.Fields("FrtMax_VIPRH").Value)
        BAsicRearMin_VIPRH = CDbl(Rs.Fields("RearMin_VIPRH").Value)
        BAsicRearMax_VIPRH = CDbl(Rs.Fields("RearMax_VIPRH").Value)

        BAsicFrtMin_FOLDRH = CDbl(Rs.Fields("FrtMin_FOLDRH").Value)
        BAsicFrtMax_FOLDRH = CDbl(Rs.Fields("FrtMax_FOLDRH").Value)
        BAsicRearMin_FOLDRH = CDbl(Rs.Fields("RearMin_FOLDRH").Value)
        BAsicRearMax_FOLDRH = CDbl(Rs.Fields("RearMax_FOLDRH").Value)

        BasicRearTolVIP = CDbl(Rs.Fields("RearTolVIP").Value)
        basicFrtTolVIP = CDbl(Rs.Fields("FrtTolVIP").Value)

        BasicRearTolSTD = CDbl(Rs.Fields("RearTolSTD").Value)
        basicFrtTolSTD = CDbl(Rs.Fields("FrtTolSTD").Value)

        BasicRearTolFOLD = CDbl(Rs.Fields("RearTolFOLD").Value)
        basicFrtTolFOLD = CDbl(Rs.Fields("FrtTolFOLD").Value)

        BasicFrtMin_PE = TryReadDoubleField(Rs, "FrtMin_PE", BAsicFrtMin_STDLH)
        BasicFrtMax_PE = TryReadDoubleField(Rs, "FrtMax_PE", BAsicFrtMax_STDLH)
        BasicRearMin_PE = TryReadDoubleField(Rs, "RearMin_PE", BAsicRearMin_STDLH)
        BasicRearMax_PE = TryReadDoubleField(Rs, "RearMax_PE", BAsicRearMax_STDLH)
        basicFrtTolPE = TryReadDoubleField(Rs, "FrtTolPE", basicFrtTolSTD)
        BasicRearTolPE = TryReadDoubleField(Rs, "RearTolPE", BasicRearTolSTD)

        FlagDuplicate = Rs.Fields("FlagDuplicate").Value
        FlagBeforeCheck = Rs.Fields("FlagBeforeCheck").Value
    End Sub

    Private Sub WriteBasicToRecordset(Rs As ADODB.Recordset)
        Rs.Fields("FrtMin_STDLH").Value = BAsicFrtMin_STDLH
        Rs.Fields("FrtMax_STDLH").Value = BAsicFrtMax_STDLH
        Rs.Fields("RearMin_STDLH").Value = BAsicRearMin_STDLH
        Rs.Fields("RearMax_STDLH").Value = BAsicRearMax_STDLH

        Rs.Fields("FrtMin_VIPRH").Value = BAsicFrtMin_VIPRH
        Rs.Fields("FrtMax_VIPRH").Value = BAsicFrtMax_VIPRH
        Rs.Fields("RearMin_VIPRH").Value = BAsicRearMin_VIPRH
        Rs.Fields("RearMax_VIPRH").Value = BAsicRearMax_VIPRH

        Rs.Fields("FrtMin_FOLDRH").Value = BAsicFrtMin_FOLDRH
        Rs.Fields("FrtMax_FOLDRH").Value = BAsicFrtMax_FOLDRH
        Rs.Fields("RearMin_FOLDRH").Value = BAsicRearMin_FOLDRH
        Rs.Fields("RearMax_FOLDRH").Value = BAsicRearMax_FOLDRH

        Rs.Fields("RearTolVIP").Value = BasicRearTolVIP
        Rs.Fields("FrtTolVIP").Value = basicFrtTolVIP
        Rs.Fields("RearTolSTD").Value = BasicRearTolSTD
        Rs.Fields("FrtTolSTD").Value = basicFrtTolSTD
        Rs.Fields("RearTolFOLD").Value = BasicRearTolFOLD
        Rs.Fields("FrtTolFOLD").Value = basicFrtTolFOLD

        TryWriteDoubleField(Rs, "FrtMin_PE", BasicFrtMin_PE)
        TryWriteDoubleField(Rs, "FrtMax_PE", BasicFrtMax_PE)
        TryWriteDoubleField(Rs, "RearMin_PE", BasicRearMin_PE)
        TryWriteDoubleField(Rs, "RearMax_PE", BasicRearMax_PE)
        TryWriteDoubleField(Rs, "FrtTolPE", basicFrtTolPE)
        TryWriteDoubleField(Rs, "RearTolPE", BasicRearTolPE)

        Rs.Fields("FlagDuplicate").Value = FlagDuplicate
        Rs.Fields("FlagBeforeCheck").Value = FlagBeforeCheck
    End Sub

    Public Function LoadBasicData() As Boolean
        LastMdbError = ""
        If Not EnsureBasicTableRow() Then Return False
        If Not ConnectionOpenMDB() Then Return False

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        Rs.LockType = ADODB.LockTypeEnum.adLockReadOnly

        Try
            Rs.Open("SELECT TOP 1 * FROM Table_BASIC ORDER BY ID", MdbConnect)
            If Rs.EOF Then
                LastMdbError = "Table_BASIC에 데이터가 없습니다."
                Return False
            End If
            ReadBasicFromRecordset(Rs)
            Return True
        Catch ex As Exception
            LastMdbError = "LoadBasicData: " & ex.Message
            Return False
        Finally
            Try
                Rs.ActiveConnection = Nothing
                Rs.Close()
            Catch
            End Try
            ConnectionCloseMDB()
        End Try
    End Function

    Public Function SaveBasicData() As Boolean
        LastMdbError = ""
        If Not EnsureBasicTableRow() Then Return False
        If Not ConnectionOpenMDB() Then Return False

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Try
            Rs.Open("SELECT TOP 1 * FROM Table_BASIC ORDER BY ID", MdbConnect)
            If Rs.EOF Then
                LastMdbError = "Table_BASIC에 저장할 행이 없습니다."
                Return False
            End If
            WriteBasicToRecordset(Rs)
            Rs.Update()
            Return True
        Catch ex As Exception
            LastMdbError = "SaveBasicData: " & ex.Message &
                " (Program Files 아래 DB면 쓰기 권한·관리자 실행 확인)"
            Return False
        Finally
            Try
                Rs.ActiveConnection = Nothing
                Rs.Close()
            Catch
            End Try
            ConnectionCloseMDB()
        End Try
    End Function

    Private Sub ReadPortFromRecordset(Rs As ADODB.Recordset)
        PortNumber_Scanner = CStr(Rs.Fields("Scanner").Value)
        PortNumber_Printer = CStr(Rs.Fields("Printer").Value)
        PortNumber_Tool = CStr(Rs.Fields("Tool").Value)
        Try
            PortNumber_Laser = CStr(Rs.Fields("Laser").Value)
        Catch
            PortNumber_Laser = "COM3"
        End Try
        If String.IsNullOrWhiteSpace(PortNumber_Laser) Then PortNumber_Laser = "COM3"
        Try
            PortNumber_Io = CStr(Rs.Fields("Io").Value)
        Catch
            PortNumber_Io = "COM4"
        End Try
        If String.IsNullOrWhiteSpace(PortNumber_Io) Then PortNumber_Io = "COM4"
    End Sub

    Private Sub WritePortToRecordset(Rs As ADODB.Recordset)
        Rs.Fields("Scanner").Value = PortNumber_Scanner
        Rs.Fields("Printer").Value = PortNumber_Printer
        Rs.Fields("Tool").Value = PortNumber_Tool
        Try
            Rs.Fields("Laser").Value = PortNumber_Laser
        Catch
        End Try
        Try
            Rs.Fields("Io").Value = PortNumber_Io
        Catch
        End Try
    End Sub

    Public Function LoadPortData() As Boolean
        LastMdbError = ""
        If Not EnsureSerialPortTableRow() Then
            ApplyDefaultPortData()
            Return False
        End If
        If Not ConnectionOpenMDB() Then
            ApplyDefaultPortData()
            Return False
        End If

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        Rs.LockType = ADODB.LockTypeEnum.adLockReadOnly

        Try
            Rs.Open("SELECT TOP 1 * FROM Table_SerialPort ORDER BY ID", MdbConnect)
            If Rs.EOF Then
                LastMdbError = "Table_SerialPort에 데이터가 없습니다."
                ApplyDefaultPortData()
                Return False
            End If
            ReadPortFromRecordset(Rs)
            Return True
        Catch ex As Exception
            LastMdbError = "LoadPortData: " & ex.Message
            ApplyDefaultPortData()
            Return False
        Finally
            Try
                Rs.ActiveConnection = Nothing
                Rs.Close()
            Catch
            End Try
            ConnectionCloseMDB()
        End Try
    End Function

    Public Function SavePortData() As Boolean
        LastMdbError = ""
        If Not EnsureSerialPortTableRow() Then Return False
        If Not ConnectionOpenMDB() Then Return False

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Try
            Rs.Open("SELECT TOP 1 * FROM Table_SerialPort ORDER BY ID", MdbConnect)
            If Rs.EOF Then
                LastMdbError = "Table_SerialPort에 저장할 행이 없습니다."
                Return False
            End If
            WritePortToRecordset(Rs)
            Rs.Update()
            Return True
        Catch ex As Exception
            LastMdbError = "SavePortData: " & ex.Message &
                " (Program Files 아래 DB면 쓰기 권한·관리자 실행 확인)"
            Return False
        Finally
            Try
                Rs.ActiveConnection = Nothing
                Rs.Close()
            Catch
            End Try
            ConnectionCloseMDB()
        End Try
    End Function

End Module
