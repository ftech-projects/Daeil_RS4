Public Class Frm_Plan

    Dim FIrstPart As String
    Dim ClickIndex As Integer

    Private Sub Frm_Plan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitGrid()
        LoadPlanLH()
        LoadPlanRH()

    End Sub

    Sub InitGrid()

        ' Grid1(LH), Grid2(RH) 초기화
        InitPlanGrid(Grid1)
        InitPlanGrid(Grid2)

    End Sub

    Private Sub InitPlanGrid(g As DataGridView)
        g.Rows.Clear()
        g.Columns.Clear()
        g.Columns.Add("colSeq", "Seq")
        g.Columns.Add("colPartNo", "Part No.")
        g.Columns.Add("colPartPlan", "Part Plan.")
        g.Columns(0).Width = 80
        g.Columns(1).Width = 270
        g.Columns(2).Width = 100
        For i As Integer = 0 To g.Columns.Count - 1
            g.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            g.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub

    Sub AddPlan(ByVal strPartNo As String, ByVal strPartCOlor As String, ByVal strPlanNum As String)

        connectionopensql()

        Dim Rs As New ADODB.Recordset
        Dim tmp As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        If strPartNo.Contains("883") = True Then
            Rs.Open("SELECT * FROM Table_PartPlanLH Order by seq,len(seq)", SqlConnect)
            Rs.AddNew()
            Rs.Fields("PartNo").Value = strPartNo
            Rs.Fields("PartColor").Value = strPartCOlor
            Rs.Fields("PartPlan").Value = strPlanNum
            Rs.Fields("Seq").Value = Rs.RecordCount
            Rs.Fields("PartCount").Value = "0"
            Rs.Update()
        ElseIf strPartNo.Contains("884") = True Then
            Rs.Open("SELECT * FROM Table_PartPlanRH Order by seq,len(seq)", SqlConnect)
            Rs.AddNew()
            Rs.Fields("PartNo").Value = strPartNo
            Rs.Fields("PartColor").Value = strPartCOlor
            Rs.Fields("PartPlan").Value = strPlanNum
            Rs.Fields("Seq").Value = Rs.RecordCount
            Rs.Fields("PartCount").Value = "0"
            Rs.Update()
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionCloseSQL()

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
                               Trim(Rs.Fields("PartPlan").Value))
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
                               Trim(Rs.Fields("PartPlan").Value))
                Rs.MoveNext()
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseSQL()

    End Sub

    Private Sub DeleteAllPlan()

        Dim strSQL As String = ""
        ConnectionOpenSQL()
        strSQL = "DELETE FROM TABLE_PartPlanLH"
        SqlConnect.Execute(strSQL)
        ConnectionCloseSQL()

        ConnectionOpenSQL()
        strSQL = "DELETE FROM TABLE_PartPlanRH"
        SqlConnect.Execute(strSQL)
        ConnectionCloseSQL()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Frm_Input.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DeleteAllPlan()
        InitGrid()
        LoadPlanRH()
        LoadPlanLH()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
        Frm_Main.initgrid()
        Frm_Main.LoadPlanLH()
        Frm_Main.LoadPlanRH()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Frm_Input.Show()
    End Sub

End Class