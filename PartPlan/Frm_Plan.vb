Public Class Frm_Plan

    Dim FIrstPart As String
    Dim ClickIndex As Integer

    Private Sub Frm_Plan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitGrid()
        LoadPlan()

    End Sub

    Sub InitGrid()

        With Grid1
            ' 기존 데이터 초기화
            .Rows.Clear()
            .Columns.Clear()

            ' 컬럼 추가 (FlexCell col1=Seq, col2=PartNo, col3=PartPlan → DGV col0,1,2)
            .Columns.Add("colSeq", "Seq")
            .Columns.Add("colPartNo", "Part No.")
            .Columns.Add("colPartPlan", "Part Plan.")

            ' 컬럼 너비
            .Columns(0).Width = 100
            .Columns(1).Width = 300
            .Columns(2).Width = 200

            ' 가운데 정렬
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With

    End Sub

    Sub AddPlan(ByVal strPartNo As String, ByVal strPartCOlor As String, ByVal strPlanNum As String)

        Connection_Open()

        Dim Rs As New ADODB.Recordset
        Dim tmp As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Plan", Sql_Connect)

        With Grid1

            Rs.AddNew()

            Rs.Fields("PartNo").Value = strPartNo
            Rs.Fields("PartColor").Value = strPartCOlor
            Rs.Fields("PartPlan").Value = strPlanNum
            Rs.Fields("Seq").Value = Rs.RecordCount
            Rs.Fields("PartCount").Value = "0"
            Rs.Update()

            Rs.ActiveConnection = Nothing
            Rs.Close()

        End With

        Connection_Close()

    End Sub

    Sub LoadPlan()

        Connection_Open()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Plan  ORDER BY LEN(Seq),Seq", Sql_Connect)

        If Rs.RecordCount > 0 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid1.Rows.Add(Trim(Rs.Fields("Seq").Value),
                               Trim(Rs.Fields("PartNo").Value) & Trim(Rs.Fields("PartColor").Value),
                               Trim(Rs.Fields("PartPlan").Value))
                Rs.MoveNext()
            Loop
        ElseIf Rs.RecordCount = 0 Then
            MsgBox("계획을 입력해주세요")
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        Connection_Close()

    End Sub

    Private Sub DeleteAllPlan()

        Dim strSQL As String = ""
        Connection_Open()

        strSQL = "DELETE FROM TABLE_PLAN"
        Sql_Connect.Execute(strSQL)
        Connection_Close()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Frm_Input.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DeleteAllPlan()
        InitGrid()
        LoadPlan()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
        Frm_Main.initgrid()
        Frm_Main.LoadPlan()
    End Sub

End Class