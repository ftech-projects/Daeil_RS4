Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO

Public Class FrmMain

    Private mstrDatabase As String
    Private myDataAdapter As OleDbDataAdapter
    Private myDataSet As DataSet

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetDataBinding()
    End Sub
    
    Private Sub SetDataBinding()

        GetDataSet()

        ' DataGridView DataSource 바인딩
        Grid1.DataSource = myDataSet.Tables("Table_PARTPLAN")

        ' 바인딩 후 컬럼 속성 설정
        If Grid1.Columns.Count > 0 Then
            If Grid1.Columns.Count > 0 Then Grid1.Columns(0).Width = 10
            If Grid1.Columns.Count > 1 Then Grid1.Columns(1).Width = 0 : Grid1.Columns(1).Visible = False
            If Grid1.Columns.Count > 2 Then Grid1.Columns(2).Width = 80
            If Grid1.Columns.Count > 3 Then Grid1.Columns(3).Width = 200
            If Grid1.Columns.Count > 4 Then Grid1.Columns(4).Width = 200
            If Grid1.Columns.Count > 5 Then Grid1.Columns(5).Width = 200
            If Grid1.Columns.Count > 6 Then Grid1.Columns(6).Width = 80
            If Grid1.Columns.Count > 7 Then Grid1.Columns(7).Width = 120 : Grid1.Columns(7).ReadOnly = True
            If Grid1.Columns.Count > 8 Then Grid1.Columns(8).Width = 120 : Grid1.Columns(8).ReadOnly = True

            If Grid1.Columns.Count > 1 Then Grid1.Columns(1).HeaderText = "ID"
            If Grid1.Columns.Count > 2 Then Grid1.Columns(2).HeaderText = "서열"
            If Grid1.Columns.Count > 3 Then Grid1.Columns(3).HeaderText = "LH 파트넘버"
            If Grid1.Columns.Count > 4 Then Grid1.Columns(4).HeaderText = "RH 파트넘버"
            If Grid1.Columns.Count > 5 Then Grid1.Columns(5).HeaderText = "칼라코드"
            If Grid1.Columns.Count > 6 Then Grid1.Columns(6).HeaderText = "계획수량"
            If Grid1.Columns.Count > 7 Then Grid1.Columns(7).HeaderText = "LH 카운트"
            If Grid1.Columns.Count > 8 Then Grid1.Columns(8).HeaderText = "RH 카운트"

            For i As Integer = 1 To Math.Min(8, Grid1.Columns.Count - 1)
                Grid1.Columns(i).DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Next
        End If

        ' TODO: Col 3/4/5 ComboBox 변환 - DataGridViewComboBoxColumn 별도 구현 필요

    End Sub

    ' ComboBox 로드 함수들 - DataGridView에서는 DataGridViewComboBoxColumn 사용 필요
    ' 현재는 일반 텍스트 컬럼으로 편집 지원 (TODO)
    Private Sub LoadComboPartLH()
    End Sub

    Private Sub LoadComboPartRH()
    End Sub

    Private Sub LoadComboColor()
    End Sub

    Private Sub GetDataSet()

        Dim conn As OleDbConnection

        Dim Qurry1 As String = "SELECT * FROM Table_PARTPLAN ORDER BY LEN(Seq),Seq"

        Dim ConString As String = "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"

        conn = New OleDbConnection
        conn.ConnectionString = ConString
        conn.Open()
        myDataSet = New DataSet

        myDataAdapter = New OleDbDataAdapter(Qurry1, conn)
        myDataAdapter.Fill(myDataSet, "Table_PARTPLAN")
        conn.Close()

    End Sub

    Private Sub Save_Grid()

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
            myDataAdapter.Update(myDataSet.Tables("Table_PartPLAN"))
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

    '******************************************************************************
    'Button
    '******************************************************************************

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Save_Grid()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        SetDataBinding()
    End Sub

End Class