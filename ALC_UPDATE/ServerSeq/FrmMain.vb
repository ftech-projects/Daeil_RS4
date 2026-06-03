Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Media
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO.Ports
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Drawing.Drawing2D
Imports System.Globalization

Public Class FrmMain

    Private ExcelApp As Excel.Application = Nothing
    Private wb As Excel.Workbook = Nothing
    Private ws As Excel.Worksheet = Nothing

    Private DbState As Boolean
    Private ExcelState As Boolean

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CheckForIllegalCrossThreadCalls = False
        UpdateCount = 0
        DbState = False
        ExcelState = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

    End Sub

    Private Function ConvertSTr(ByVal str As String) As String
        Dim tmp As String = ""
        'Try
        tmp = Trim(str)
        'Catch ex As Exception
        'End Try
        Return tmp
    End Function

    Private Sub GetAlcTarget(ByVal str As String)

        'Dim Rs As New ADODB.Recordset
        'ConnectionOpenMdb()
        'Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        'Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        'Rs.Open("SELECT * FROM Table_ALCCODE WHERE ALCCODE = '" & str & "'", MdbConnect)
        'If Rs.RecordCount = 1 Then
        '    'NowLhTarget = Replace(Rs.Fields("PartNoLH").Value, "-", "")
        '    'NowRhTarget = Replace(Rs.Fields("PartNoRH").Value, "-", "")
        'End If
        'Rs.ActiveConnection = Nothing
        'Rs.Close()
        'ConnectionCloseMdb()

    End Sub

    Private Function ReturnChkPartNo(ByVal str As String)

        Dim tmp As String = ""
        Try
            tmp = Mid(str, 2, 13)
        Catch ex As Exception
        End Try
        Return tmp

    End Function

    Private Function ReturnChkLotNo(ByVal str As String)

        Dim tmp As String = ""
        Try
            tmp = "20" & Mid(str, 16, 6)
        Catch ex As Exception
        End Try
        Return tmp

    End Function

    Private Function Cnvt(ByVal str As String) As String
        Dim tmp = ""
        If str.Length = 6 Then
            tmp = str
        End If
        Return tmp
    End Function

    'Private Sub SaveDb(ByVal strSeq As String, ByVal strIndex As String, ByVal PcodeLH As String, ByVal TCodeLH As String, ByVal ScanDataLH As String, ByVal PcodeRH As String, ByVal TCodeRH As String, ByVal ScanDataRH As String)

    '    Dim strSQL As String = ""
    '    ConnectionOpenMdb()

    '    strSQL = "INSERT INTO TABLE_MAIN (JobDate,JobTime,jobSeq,jobIndex,PcodeLH,TCodeLH,ScanDataLH,PcodeRH,TCodeRH,ScanDataRH) VALUES (" &
    '                   "'" & Format(Now, "yyyy-MM-dd") & "','" &
    '                           Format(Now, "HH:mm:ss") & "','" &
    '                           strSeq & "','" &
    '                           strIndex & "','" &
    '                           PcodeLH & "','" &
    '                           TCodeLH & "','" &
    '                           ScanDataLH & "','" &
    '                           PcodeRH & "','" &
    '                           TCodeRH & "','" &
    '                           ScanDataRH & "')"

    '    MdbConnect.Execute(strSQL)
    '    ConnectionCloseMdb()

    'End Sub

    'Private Sub UpdateDb(ByVal strDate As String, ByVal strSeq As String, ByVal strIndex As String)

    '    Dim tmp As Boolean = False
    '    Dim Rs As New ADODB.Recordset
    '    ConnectionOpenMdb()
    '    Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '    Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
    '    Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
    '    Rs.Open("SELECT * FROM Table_EndSeq WHERE JobDate = '" & strDate & "' AND Seq = '" & strSeq & "'", MdbConnect)
    '    If Rs.RecordCount = 1 Then
    '        Rs.Fields("ALC" & strIndex & "OK").Value = "OK"
    '        Rs.Update()
    '    End If
    '    Rs.ActiveConnection = Nothing
    '    Rs.Close()
    '    ConnectionCloseMdb()

    'End Sub

    'Private Function CheckDuplicate(ByVal strdata As String) As Boolean

    '    Dim tmp As Boolean = False
    '    Dim Rs As New ADODB.Recordset
    '    ConnectionOpenMdb()
    '    Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '    Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
    '    Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
    '    Rs.Open("SELECT * FROM Table_MAIN WHERE ScanDataLH = '" & strdata & "' OR ScanDataRH = '" & strdata & "'", MdbConnect)
    '    If Rs.RecordCount >= 1 Then
    '        tmp = True
    '    End If
    '    Rs.ActiveConnection = Nothing
    '    Rs.Close()
    '    ConnectionCloseMdb()

    '    Return tmp

    'End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim Open As New OpenFileDialog()
        Open.ShowDialog()
        If Open.FileName = "" Then
            TextBox2.Text = ""
        Else
            TextBox2.Text = Open.FileName
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim Open As New OpenFileDialog()
        Open.ShowDialog()
        If Open.FileName = "" Then
            TextBox3.Text = ""
        Else
            TextBox3.Text = Open.FileName
        End If

    End Sub

    Private UpdateCount As Integer
    Private Sub UpdateTextbox(ByVal str As String)
        UpdateCount = UpdateCount + 1
        'If UpdateCount > 20 Then
        '    TextBox1.Clear()
        '    UpdateCount = 0
        'End If
        TextBox1.AppendText(Format(Now, "yyyyMMdd HH:mm:ss") & " " & str & vbNewLine)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If TextBox2.Text <> "" Then
            Try
                UpdateTextbox("DB 파일 확인중..")
                ConnectionOpenMdb(TextBox2.Text)
                ConnectionCloseMdb()
                UpdateTextbox("DB 파일 이상없음.")
                DbState = True
            Catch ex As Exception
                MsgBox("DB 파일 경로를 다시 확인해주세요")
                UpdateTextbox("DB 파일 이상 !")
                DbState = False
                Exit Sub
            End Try
        Else
            MsgBox("DB 파일을 확인해주세요")
        End If

        If TextBox3.Text <> "" Then
            Try
                UpdateTextbox("EXCEL 파일 확인중..")
                If File.Exists(TextBox3.Text) = False Then
                    MsgBox("EXCEL 파일 경로를 다시 확인해주세요")
                    UpdateTextbox("EXCEL 파일 이상 !")
                    ExcelState = False
                    Exit Sub
                End If
                UpdateTextbox("EXCEL 파일 이상없음.")
                ExcelState = True
                ReadExcel()
            Catch ex As Exception
                MsgBox("EXCEL 파일 경로를 다시 확인해주세요")
                UpdateTextbox("EXCEL 파일 이상 !")
                ExcelState = False
                Exit Sub
            End Try
        Else
            MsgBox("엑셀 파일을 확인해주세요")
        End If

    End Sub

    Private Sub SaveDB(ByVal strAlc As String, ByVal strPartLH As String, ByVal strPArtRH As String)

        Dim strSQL As String = ""
        strSQL = "INSERT INTO TABLE_AlcCode (AlcCode,PartNoLH,PartNoRH) VALUES (" & "'" &
                               strAlc & "','" &
                               strPartLH & "','" &
                               strPArtRH & "')"

        MdbConnect.Execute(strSQL)

    End Sub

    Private Sub DeleteDb()
        Dim strSQL As String = ""
        strSQL = "DELETE FROM TABLE_ALCCODE"
        MdbConnect.Execute(strSQL)
    End Sub

    Private Sub ReadExcel()

        Dim ColCount As Int64 = 1

        Try

            ExcelApp = New Excel.Application
            wb = ExcelApp.Workbooks.Open(TextBox3.Text)
            ws = CType(wb.Worksheets("Sheet1"), Excel.Worksheet)

            Dim loopFlag As Boolean = True
            Dim rg1 As Excel.Range
            Dim rg2 As Excel.Range
            Dim rg3 As Excel.Range

            ConnectionOpenMdb(TextBox2.Text)
            DeleteDb()
            UpdateTextbox("DB 삭제 완료.")

            Do While loopFlag = True
                rg1 = CType(ws.Cells(ColCount, 1), Excel.Range)
                rg2 = CType(ws.Cells(ColCount, 2), Excel.Range)
                rg3 = CType(ws.Cells(ColCount, 3), Excel.Range)
                UpdateTextbox("ID:" & Format(ColCount, "00000") & "  " & rg1.Value2.ToString() & "  " & rg2.Value2.ToString() & "  " &
                              rg3.Value2.ToString())
                SaveDB(rg1.Value2.ToString(), rg2.Value2.ToString(), rg3.Value2.ToString())
                If rg1.Value2.ToString = "" Then
                    UpdateTextbox("Completed")
                    loopFlag = False
                End If
                ColCount = ColCount + 1
                System.Windows.Forms.Application.DoEvents()
            Loop

            wb.Close(False, Excel.XlFileFormat.xlWorkbookNormal)
            ExcelApp.Quit()
            ReleaseObject(ws)
            ReleaseObject(wb)
            ReleaseObject(ExcelApp)
            GC.Collect()
            ConnectionCloseMdb()

        Catch ex As Exception

            UpdateTextbox("Completed")
            wb.Close(False, Excel.XlFileFormat.xlWorkbookNormal)
            ExcelApp.Quit()
            ReleaseObject(ws)
            ReleaseObject(wb)
            ReleaseObject(ExcelApp)
            GC.Collect()
            ConnectionCloseMdb()

        End Try

    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)

        Try
            If Not obj Is Nothing Then
                Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            End If
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class