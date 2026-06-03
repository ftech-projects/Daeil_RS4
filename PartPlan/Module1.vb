Module Module1

    Public Sql_Connect As ADODB.Connection
    Public MdbConnect As ADODB.Connection

    Public Sub ConnectionOpenMDB()

        Try

            MdbConnect = New ADODB.Connection
            MdbConnect.ConnectionString =
                "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\DB\DB.mdb"
            MdbConnect.Open()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ConnectionCloseMDB()

        Try
            MdbConnect.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub Connection_Open()

        Try
            Sql_Connect = New ADODB.Connection

            Dim connection_string = _
            "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"
            Sql_Connect.ConnectionString = connection_string
            Sql_Connect.Open()
        Catch ex As Exception

        End Try
        
    End Sub

    Sub Connection_Close()

        Try
            Sql_Connect.Close()
        Catch ex As Exception

        End Try


    End Sub

End Module
