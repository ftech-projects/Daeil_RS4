
Imports System.Reflection

Module DBOperation

    Public MdbConnect As ADODB.Connection
    Public SqlConnect As ADODB.Connection

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

    Sub ConnectionOpenSQL()

        Try

            Dim connection_string As String = ""
            SqlConnect = New ADODB.Connection
            connection_string = "Provider=SQLOLEDB;Data Source=Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"
            SqlConnect.ConnectionString = connection_string
            SqlConnect.Open()

        Catch ex As Exception

        End Try

    End Sub

    Sub ConnectionCloseSQL()

        Try
            SqlConnect.Close()
        Catch ex As Exception

        End Try

    End Sub

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

End Module
