Imports System.Threading
Imports System.IO
Imports System.Media

Public Class FrmMain

    Dim FIrstPart As String
    Dim ClickIndex As Integer

    Private Sub 프로그램종료ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 프로그램종료ToolStripMenuItem.Click
        End
    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub InitGrid()

        With Grid1
            .Rows.Clear()
            .Columns.Clear()

            ' FlexCell col1→DGV col0, col2→col1, ..., col7→col6
            ' col1~col3: ReadOnly, col4: CheckBox
            .Columns.Add("colPartNo", "PartNo")          ' FlexCell col1
            .Columns.Add("colPlanCount", "PlanCount")     ' FlexCell col2
            .Columns.Add("colCol3", "")                   ' FlexCell col3
            Dim chkCol As New DataGridViewCheckBoxColumn() ' FlexCell col4
            chkCol.Name = "colCheck"
            chkCol.HeaderText = ""
            .Columns.Add(chkCol)
            .Columns.Add("colCol5", "")                   ' FlexCell col5
            .Columns.Add("colCol6", "")                   ' FlexCell col6
            .Columns.Add("colCol7", "")                   ' FlexCell col7

            ' col0~col2 ReadOnly (FlexCell col1~col3 Locked)
            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True

            .Columns(0).Width = 150
            .Columns(1).Width = 70
            .Columns(2).Width = 180
            .Columns(3).Width = 140
            .Columns(4).Width = 140
            .Columns(5).Width = 140
            .Columns(6).Width = 180

            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

End Class
