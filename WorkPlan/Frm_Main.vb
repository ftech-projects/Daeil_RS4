Imports System.Threading
Imports System.IO
Imports System.Media

Public Class Frm_Main

    Private Sub Frm_Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitGrid()
        LoadPlanLH()
        LoadPlanRH()
        Timer1.Interval = 1000
        Timer1.Start()

    End Sub

    Sub InitGrid()

        ' Grid1, Grid2 초기화
        InitPlanGrid(Grid1)
        InitPlanGrid(Grid2)

    End Sub

    Private Sub InitPlanGrid(g As DataGridView)
        g.Rows.Clear()
        g.Columns.Clear()
        g.Columns.Add("colSeq", "Seq")
        g.Columns.Add("colPartNo", "Part No.")
        g.Columns.Add("colPartPlan", "Part Plan.")
        g.Columns.Add("colCount", "Count.")
        g.Columns(0).Width = 85
        g.Columns(1).Width = 200
        g.Columns(2).Width = 110
        g.Columns(3).Width = 110
        For i As Integer = 0 To g.Columns.Count - 1
            g.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            g.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub

    Sub LoadPlanLH()

        ConnectionOpenSQL()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_PartPlanLH  ORDER BY LEN(Seq),Seq", SqlConnect)

        If Rs.RecordCount > 0 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid1.Rows.Add(Trim(Rs.Fields("Seq").Value),
                               Trim(Rs.Fields("PartNo").Value) & Trim(Rs.Fields("PartColor").Value),
                               Trim(Rs.Fields("PartPlan").Value),
                               Trim(Rs.Fields("PartCount").Value))
                Rs.MoveNext()
            Loop
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

    End Sub

    Sub LoadPlanRH()

        ConnectionOpenSQL()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_PartPlanRH  ORDER BY LEN(Seq),Seq", SqlConnect)

        If Rs.RecordCount > 0 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid2.Rows.Add(Trim(Rs.Fields("Seq").Value),
                               Trim(Rs.Fields("PartNo").Value) & Trim(Rs.Fields("PartColor").Value),
                               Trim(Rs.Fields("PartPlan").Value),
                               Trim(Rs.Fields("PartCount").Value))
                Rs.MoveNext()
            Loop
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Frm_Plan.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            InitGrid()
            LoadPlanLH()
            LoadPlanRH()
            'LoadTarget()
            'SaveTarget(LabelTarget.Text, LabelSeq.Text)

        Catch ex As Exception
        End Try

    End Sub

    ' LoadTarget / SaveTarget 은 타이머에서 주석처리되어 미사용 → 미구현 상태 유지

End Class
