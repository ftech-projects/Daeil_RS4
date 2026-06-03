Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO

Public Class FrmRegisterSeq

    Private FlagAlcCheck As Boolean
    Private mstrDatabase As String
    Private myDataAdapter As OleDbDataAdapter
    Private myDataSet As DataSet

    Private Sub GetDataSet()

        Dim conn As OleDbConnection

        Dim Qurry1 As String = "SELECT ID,JObDate,Seq,Alc1,Alc2,Alc3,Alc4,Alc5,Alc6,Alc7,Alc8 FROM Table_EndSeq WHERE JobDate = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' ORDER BY LEN(Seq),Seq"
        Dim ConString As String = "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\DB\DB.mdb"
        conn = New OleDbConnection
        conn.ConnectionString = ConString
        conn.Open()
        myDataSet = New DataSet

        myDataAdapter = New OleDbDataAdapter(Qurry1, conn)
        myDataAdapter.Fill(myDataSet, "Table_EndSeq")
        conn.Close()

    End Sub

    Private Sub SaveGrid()

        Dim intTopRow, intCurrentRow, intCurrentCol As Integer
        Dim myCommandBuilder As System.Data.OleDb.OleDbCommandBuilder

        'End the current edit operation
        Grid1.EndEdit()

        'Command
        myCommandBuilder = New System.Data.OleDb.OleDbCommandBuilder(myDataAdapter)
        myDataAdapter.DeleteCommand = myCommandBuilder.GetDeleteCommand()
        myDataAdapter.UpdateCommand = myCommandBuilder.GetUpdateCommand()
        myDataAdapter.InsertCommand = myCommandBuilder.GetInsertCommand()

        Try
            'Save to database
            myDataAdapter.Update(myDataSet.Tables("Table_EndSeq"))
        Catch ex As Exception
            myCommandBuilder.Dispose()
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return
        End Try

        myCommandBuilder.Dispose()
        myDataSet.Dispose()
        myDataAdapter.Dispose()

        'Grid status
        intTopRow = If(Grid1.FirstDisplayedScrollingRowIndex >= 0, Grid1.FirstDisplayedScrollingRowIndex, 0)
        intCurrentRow = If(Grid1.CurrentCell IsNot Nothing, Grid1.CurrentCell.RowIndex, 0)
        intCurrentCol = If(Grid1.CurrentCell IsNot Nothing, Grid1.CurrentCell.ColumnIndex, 0)

        'Re-bind
        SetDataBinding()
        If intCurrentRow < Grid1.RowCount AndAlso intCurrentCol < Grid1.ColumnCount Then
            Grid1.CurrentCell = Grid1.Rows(intCurrentRow).Cells(intCurrentCol)
        End If
        If intTopRow < Grid1.RowCount Then
            Grid1.FirstDisplayedScrollingRowIndex = intTopRow
        End If
        Grid1.Refresh()

        MsgBox("Done.", MsgBoxStyle.Exclamation)

    End Sub

    Private Sub SetDataBinding()

        GetDataSet()

        ' DataGridView DataSource 바인딩 (SELECT ID,JobDate,Seq,Alc1..Alc8 → 11컬럼)
        Grid1.DataSource = myDataSet.Tables("Table_EndSeq")

        ' 바인딩 후 컬럼 속성 설정
        If Grid1.Columns.Count >= 11 Then
            Grid1.Columns(0).Visible = False  ' ID 숨김
            Grid1.Columns(1).Width = 100 : Grid1.Columns(1).HeaderText = "Date"
            Grid1.Columns(2).Width = 80 : Grid1.Columns(2).HeaderText = "Seq"
            For i As Integer = 3 To 10
                Grid1.Columns(i).Width = 80
                Grid1.Columns(i).HeaderText = "ALC " & (i - 2)
            Next
            For i As Integer = 0 To Grid1.Columns.Count - 1
                Grid1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            ' TODO: ALC 1..8 ComboBox → DataGridViewComboBoxColumn 변환 필요
        End If

    End Sub

    Private Sub SetDate()
        Dim i As Integer
        FlagAlcCheck = True
        ' FlexCell: For i=1 To Rows-2 (1-based, 헤더+마지막 제외)
        ' DGV: 0-based, IsNewRow로 빈 행 스킵
        ' 컬럼 오프셋: FlexCell Col c → DGV Col (c-1) (FlexCell Col 0 = 자동 행번호)
        For i = 0 To Grid1.RowCount - 1
            If Grid1.Rows(i).IsNewRow Then Continue For
            Grid1.Rows(i).Cells(1).Value = Format(DateTimePicker1.Value, "yyyy-MM-dd")  ' JobDate
            Grid1.Rows(i).Cells(2).Value = CStr(i + 1)  ' Seq (1-based 표시)
            CheckAlcCode(CStr(If(Grid1.Rows(i).Cells(3).Value, "")), CStr(i + 1), "1")
            CheckAlcCode(CStr(If(Grid1.Rows(i).Cells(4).Value, "")), CStr(i + 1), "2")
            CheckAlcCode(CStr(If(Grid1.Rows(i).Cells(5).Value, "")), CStr(i + 1), "3")
            CheckAlcCode(CStr(If(Grid1.Rows(i).Cells(6).Value, "")), CStr(i + 1), "4")
            CheckAlcCode(CStr(If(Grid1.Rows(i).Cells(7).Value, "")), CStr(i + 1), "5")
            CheckAlcCode(CStr(If(Grid1.Rows(i).Cells(8).Value, "")), CStr(i + 1), "6")
            CheckAlcCode(CStr(If(Grid1.Rows(i).Cells(9).Value, "")), CStr(i + 1), "7")
            CheckAlcCode(CStr(If(Grid1.Rows(i).Cells(10).Value, "")), CStr(i + 1), "8")
        Next
    End Sub

    Private Function CheckAlcCode(ByVal strCode As String, ByVal strSeq As String, ByVal strNum As String) As Boolean

        Dim tmp As Boolean = True
        Dim Rs As New ADODB.Recordset
        ConnectionOpenMdb()
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_ALCCODE WHERE ALCCODE = '" & strCode & "'", MdbConnect)
        If Rs.RecordCount < 1 Then
            tmp = False
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionCloseMdb()
        If strCode = "PASS" Then tmp = True
        If tmp = False Then
            FlagAlcCheck = False
            MsgBox("잘못된 ALC CODE 입니다. " & strCode & " Seq " & strSeq & " / ALC " & strNum)
        End If
        Return tmp

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SetDataBinding()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SetDate()
        If FlagAlcCheck = True Then SaveGrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class