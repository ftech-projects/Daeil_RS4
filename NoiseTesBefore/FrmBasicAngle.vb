Imports System.Data.OleDb

Public Class FrmBasicAngle

    Private mstrDatabase As String
    Private mstrDatabase2 As String
    Private myDataAdapter As OleDbDataAdapter
    Private myDataSet As DataSet
    Private myDataAdapter2 As OleDbDataAdapter
    Private myDataSet2 As DataSet
    '******************************************************************************
    '초기화    
    '******************************************************************************
    Public Sub New()

        InitializeComponent()
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        'SetDataBinding()

    End Sub

    '******************************************************************************
    'Dataset handling
    '******************************************************************************
    Private Sub SetDataBinding()

        Try

            GetDataSet()

            ' FlexCell SetDataBinding → DGV DataSource
            Grid1.DataSource = myDataSet.Tables("Table_Angle_" & ComboBox1.Text)

            ' 컬럼 설정 (DataSource 설정 후 자동생성된 컬럼 조정)
            ' 쿼리: SELECT * → ID(col0), LASER_LENGTH(col1), CONVERT_ANGLE(col2) 순 가정
            If Grid1.Columns.Count > 0 Then
                Grid1.Columns(0).HeaderText = "ID"
                Grid1.Columns(0).Visible = False     ' FlexCell Column(1).Width=0 → 숨김
            End If
            If Grid1.Columns.Count > 1 Then
                Grid1.Columns(1).HeaderText = "Laser Length"
                Grid1.Columns(1).Width = 180
                Grid1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If
            If Grid1.Columns.Count > 2 Then
                Grid1.Columns(2).HeaderText = "Convert Angle"
                Grid1.Columns(2).Width = 180
                Grid1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If

        Catch ex As Exception
            MsgBox("사양을 선택해주세요")
        End Try

    End Sub

    Private Sub GetDataSet()

        Dim conn As OleDbConnection

        Dim Qurry1 As String = "SELECT * FROM Table_Angle_" & ComboBox1.Text & " ORDER BY LEN(LASER_LENGTH),LASER_LENGTH"
        Dim Constring As String = "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\DB\DB.mdb"

        conn = New OleDbConnection
        conn.ConnectionString = Constring
        conn.Open()
        myDataSet = New DataSet
        myDataAdapter = New OleDbDataAdapter(Qurry1, conn)
        myDataAdapter.Fill(myDataSet, "Table_Angle_" & ComboBox1.Text)
        conn.Close()

    End Sub

    Private Sub Save_Grid1()

        Dim intTopRow As Integer = 0
        Dim intCurrentRow As Integer = 0
        Dim intCurrentCol As Integer = 0
        Dim myCommandBuilder As System.Data.OleDb.OleDbCommandBuilder

        ' 현재 편집 종료
        Grid1.EndEdit()

        ' 현재 위치 저장
        If Grid1.CurrentCell IsNot Nothing Then
            intCurrentRow = Grid1.CurrentCell.RowIndex
            intCurrentCol = Grid1.CurrentCell.ColumnIndex
        End If
        If Grid1.FirstDisplayedScrollingRowIndex >= 0 Then
            intTopRow = Grid1.FirstDisplayedScrollingRowIndex
        End If

        ' Command
        myCommandBuilder = New System.Data.OleDb.OleDbCommandBuilder(myDataAdapter)
        myDataAdapter.DeleteCommand = myCommandBuilder.GetDeleteCommand()
        myDataAdapter.UpdateCommand = myCommandBuilder.GetUpdateCommand()
        myDataAdapter.InsertCommand = myCommandBuilder.GetInsertCommand()

        Try
            ' Save to database
            myDataAdapter.Update(myDataSet.Tables("Table_Angle_" & ComboBox1.Text))
        Catch ex As Exception
            myCommandBuilder.Dispose()
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return
        End Try

        myCommandBuilder.Dispose()
        myDataSet.Dispose()
        myDataAdapter.Dispose()

        ' Re-bind and restore position
        Grid1.SuspendLayout()
        SetDataBinding()
        If Grid1.RowCount > intCurrentRow AndAlso Grid1.ColumnCount > intCurrentCol Then
            Grid1.CurrentCell = Grid1.Rows(intCurrentRow).Cells(intCurrentCol)
        End If
        If intTopRow >= 0 AndAlso intTopRow < Grid1.RowCount Then
            Grid1.FirstDisplayedScrollingRowIndex = intTopRow
        End If
        Grid1.ResumeLayout()
        Grid1.Refresh()

        MsgBox("Save successful", MsgBoxStyle.Exclamation)

    End Sub

    Private Sub CN7_btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CN7_btn_Save.Click
        Save_Grid1()
    End Sub

    Private Sub CN7_btn_CLose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CN7_btn_CLose.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        SetDataBinding()

    End Sub

    Private Sub FrmBasicAngle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ComboBox1.Items.Add("STD_LH")
        ComboBox1.Items.Add("STD_RH")
        ComboBox1.Items.Add("FOLDING")
        ComboBox1.Items.Add("VIP")
        ComboBox1.Items.Add("FOOTREST")

    End Sub

End Class