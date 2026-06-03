Imports System.Threading
Imports System.IO
Imports System.Media

Module Module1

    Public SqlConnect As ADODB.Connection

    Public Function Folder_Check(ByVal folder As String) As Boolean

        Return System.IO.Directory.Exists(folder)

    End Function

    Public Function File_Check(ByVal folder As String, ByVal file As String) As Boolean

        Return System.IO.File.Exists(folder & "\" & file)

    End Function

    Sub Folder_Make(ByVal folder As String)

        Try

            System.IO.Directory.CreateDirectory(folder)

        Catch ex As Exception

        End Try

    End Sub

    Sub File_Write(ByVal folder As String, ByVal file As String, ByVal str As String)

        Try

            Using f As New StreamWriter(folder & "\" & file, True)
                f.WriteLine(str)
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Sub File_Make(ByVal folder As String, ByVal File As String)

        Try

            System.IO.File.Create(folder & "\" & File)

        Catch ex As Exception

        End Try

    End Sub

    Sub ConnectionOpen()
        SqlConnect = New ADODB.Connection
        Dim connection_string As String = "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"
        SqlConnect.ConnectionString = connection_string
        SqlConnect.Open()
    End Sub

    Sub ConnectionClose()
        SqlConnect.Close()
    End Sub

End Module
