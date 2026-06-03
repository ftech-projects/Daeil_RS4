Module Module1

    Public Sql_Connect As ADODB.Connection

    Sub Connection_Open()

        Sql_Connect = New ADODB.Connection

        Dim connection_string = _
        "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"
        Sql_Connect.ConnectionString = connection_string
        Sql_Connect.Open()

    End Sub

    Sub Connection_Close()

        Sql_Connect.Close()

    End Sub

End Module
