Imports System.Threading
Imports System.IO
Imports System.Media

Module Module1

    Public PortNumberScanner As String
    Public PortNumberPrinter As String

    Public CarType As String
    Public LotNo As String
    Public StartNumber As String
    Public EndNumber As String
    Public DeliveryDate As String
    Public OkNumber As String
    Public SeqPart(8) As String

    Public SeqPartNoLH(8) As String
    Public SeqPartNoRH(8) As String
    Public SeqLotNoLH(8) As String
    Public SeqLotNoRH(8) As String

    Public SqlConnect As ADODB.Connection
    Public MdbConnect As ADODB.Connection

    Sub ConnectionOpenMdb()
        MdbConnect = New ADODB.Connection
        'Dim connection_string As String = "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"
        Dim connection_string As String = "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\DB\DB.mdb"
        MdbConnect.ConnectionString = connection_string
        MdbConnect.Open()
    End Sub

    Sub ConnectionCloseMdb()
        MdbConnect.Close()
    End Sub

    Sub LoadPortData()
        Dim Rs As New ADODB.Recordset
        ConnectionOpenMdb()
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_SerialPort", MdbConnect)
        If Rs.RecordCount = 1 Then
            PortNumberScanner = CStr(Rs.Fields("Scanner").Value)
            PortNumberPrinter = CStr(Rs.Fields("Printer").Value)
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionCloseMdb()
    End Sub

    Sub SavePortData()
        Dim Rs As New ADODB.Recordset
        ConnectionOpenMdb()
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_SerialPort", MdbConnect)
        If Rs.RecordCount = 1 Then
            Rs.Fields("Scanner").Value = PortNumberScanner
            Rs.Fields("Printer").Value = PortNumberPrinter
            Rs.Update()
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionCloseMdb()
    End Sub

End Module
