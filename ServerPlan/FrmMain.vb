Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO

Public Class FrmMain

    Private mstrDatabase As String
    Private myDataAdapter As OleDbDataAdapter
    Private myDataSet As DataSet

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'SetDataBinding()

    End Sub
    
    Private Sub SetDataBinding()

        GetDataSet()

        ' DataGridView DataSource 바인딩
        Grid1.DataSource = myDataSet.Tables("Table_PARTPLAN")

        ' 바인딩 후 컬럼 속성 설정 (DataSource 바인딩 시 컬럼이 자동 생성됨)
        If Grid1.Columns.Count > 0 Then
            If Grid1.Columns.Count > 0 Then Grid1.Columns(0).Width = 10
            If Grid1.Columns.Count > 1 Then Grid1.Columns(1).Width = 0 : Grid1.Columns(1).Visible = False
            If Grid1.Columns.Count > 2 Then Grid1.Columns(2).Width = 100
            If Grid1.Columns.Count > 3 Then Grid1.Columns(3).Width = 250
            If Grid1.Columns.Count > 4 Then Grid1.Columns(4).Width = 250
            If Grid1.Columns.Count > 5 Then Grid1.Columns(5).Width = 250
            If Grid1.Columns.Count > 6 Then Grid1.Columns(6).Width = 100
            If Grid1.Columns.Count > 7 Then Grid1.Columns(7).Width = 100 : Grid1.Columns(7).ReadOnly = True
            If Grid1.Columns.Count > 8 Then Grid1.Columns(8).Width = 100 : Grid1.Columns(8).ReadOnly = True

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

        ' TODO: Col 3/4/5은 ComboBox 타입이었으나 DataGridView에서는 일반 텍스트로 편집 가능
        ' ComboBox 아이템 로드는 주석 처리 (별도 구현 필요 시 DataGridViewComboBoxColumn 사용)
        'LoadComboColor()
        'LoadComboPartLH()
        'LoadComboPartRH()

    End Sub

    ' ComboBox 로드 함수들 - DataGridView에서는 DataGridViewComboBoxColumn 사용 필요
    ' 현재는 일반 텍스트 컬럼으로 편집 지원 (TODO: ComboBox 컬럼 별도 구현)
    Private Sub LoadComboPartLH()
        ' TODO: DataGridView ComboBox 컬럼 구현 필요 시 DataGridViewComboBoxColumn 사용
    End Sub

    Private Sub LoadComboPartRH()
        ' TODO: DataGridView ComboBox 컬럼 구현 필요 시 DataGridViewComboBoxColumn 사용
    End Sub

    Private Sub LoadComboColor()
        ' TODO: DataGridView ComboBox 컬럼 구현 필요 시 DataGridViewComboBoxColumn 사용
    End Sub

    Private Sub GetDataSet()

        Dim conn As OleDbConnection

        Dim Qurry1 As String = "SELECT * FROM Table_PARTPLAN ORDER BY LEN(Seq),Seq"

        'Dim ConString As String = "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"
        Dim ConString As String = "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\DB\DB.mdb"
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

    Private Sub SetCount0()

        Dim i As Integer
        For i = 0 To Grid1.RowCount - 1
            If Grid1.Rows(i).Cells(7).Value Is Nothing OrElse Grid1.Rows(i).Cells(7).Value.ToString() = "" Then
                Grid1.Rows(i).Cells(7).Value = "0"
            End If
            If Grid1.Rows(i).Cells(8).Value Is Nothing OrElse Grid1.Rows(i).Cells(8).Value.ToString() = "" Then
                Grid1.Rows(i).Cells(8).Value = "0"
            End If
        Next

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        SetCount0()
        Save_Grid()

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        SetDataBinding()
    End Sub

End Class