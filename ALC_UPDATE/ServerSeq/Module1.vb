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

    Sub ConnectionOpenMdb(ByVal strPath As String)
        MdbConnect = New ADODB.Connection
        'Dim connection_string As String = "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\DB\DB.mdb"
        Dim connection_string As String = "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & strPath
        MdbConnect.ConnectionString = connection_string
        MdbConnect.Open()
    End Sub

    Sub ConnectionCloseMdb()
        MdbConnect.Close()
    End Sub

End Module
