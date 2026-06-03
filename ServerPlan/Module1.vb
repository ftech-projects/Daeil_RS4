Imports System.Threading
Imports System.IO
Imports System.Media

Module Module1

    Public SqlConnect As ADODB.Connection

    Sub ConnectionOpen()
        SqlConnect = New ADODB.Connection
        'Dim connection_string As String = "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"
        Dim connection_string As String = "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\DB\DB.mdb"
        SqlConnect.ConnectionString = connection_string
        SqlConnect.Open()
    End Sub

    Sub ConnectionClose()
        SqlConnect.Close()
    End Sub

End Module
