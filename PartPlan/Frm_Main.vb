Imports System.Threading
Imports System.IO
Imports System.Media

Public Class Frm_Main

    Private Sub Frm_Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitGrid()
        LoadPlan()
        Timer1.Interval = 1000
        Timer1.Start()

    End Sub

    Sub InitGrid()

        With Grid1
            ' 기존 데이터 초기화
            .Rows.Clear()
            .Columns.Clear()

            ' 컬럼 추가 (FlexCell col1..4 → DGV col0..3)
            .Columns.Add("colSeq", "Seq")
            .Columns.Add("colPartNo", "Part No.")
            .Columns.Add("colPartPlan", "Part Plan.")
            .Columns.Add("colCount", "Count.")

            ' 컬럼 너비
            .Columns(0).Width = 100
            .Columns(1).Width = 300
            .Columns(2).Width = 200
            .Columns(3).Width = 200

            ' 가운데 정렬
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With

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
                               Trim(Rs.Fields("PartPlan").Value),
                               Trim(Rs.Fields("PartCount").Value))
                Rs.MoveNext()
            Loop
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        Connection_Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Frm_Plan.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Try
            InitGrid()
            LoadPlan()
            LoadTarget()
            SaveTarget(LabelTarget.Text, LabelSeq.Text)
            
        Catch ex As Exception
        End Try
        
    End Sub

    Private Sub LoadTarget()

        Connection_Open()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Plan ORDER BY LEN(Seq),Seq", Sql_Connect)

        LabelTarget.Text = ""
        LabelSeq.Text = ""

        If Rs.RecordCount > 0 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                If CInt(Rs.Fields("PartPlan").Value) > CInt(Rs.Fields("PartCount").Value) Then
                    LabelTarget.Text = Trim(Rs.Fields("PartNo").Value) & Trim(Rs.Fields("Partcolor").Value)
                    LabelSeq.Text = Trim(Rs.Fields("Seq").Value)
                    Rs.Move(Rs.RecordCount + 1)
                Else
                    Rs.MoveNext()
                End If
            Loop
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        Connection_Close()

    End Sub

    Private Sub SaveTarget(ByVal strTarget As String, ByVal strSeq As String)

        Dim strSQL As String = ""

        Connection_Open()

        'FIrstPart = Rs.Fields("SELECT_PART").Value

        strSQL = "UPDATE TABLE_ETC SET SELECT_PART = '" & strTarget & "' , PlanSeq = '" & strSeq & "'"

        Sql_Connect.Execute(strSQL)
        Connection_Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim strSQL As String = ""
        Connection_Open()
        strSQL = "DELETE FROM TABLE_PLAN"
        Sql_Connect.Execute(strSQL)
        Connection_Close()

        'ConnectionOpenMDB()
        MDb2Sql()

    End Sub

    Sub MDb2Sql()

        ConnectionOpenMDB()
        Connection_Open()

        Dim Rs As New ADODB.Recordset
        Dim tmp As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Plan ORDER BY LEN(Seq),Seq", MdbConnect)

        Dim Rs2 As New ADODB.Recordset
        Dim tmp2 As Integer

        Rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs2.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs2.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs2.Open("SELECT * FROM Table_Plan ORDER BY LEN(Seq),Seq", Sql_Connect)

        If Rs.RecordCount > 1 Then

            Rs.MoveFirst()
            Do Until Rs.EOF
                Rs2.AddNew()
                Rs.Fields("Seq").Value = Rs2.Fields("Seq").Value
                Rs.Fields("PartNo").Value = Rs2.Fields("PartNo").Value
                Rs.Fields("PartColor").Value = Rs2.Fields("PartColor").Value
                Rs.Fields("PartCount").Value = Rs2.Fields("PartCount").Value
                Rs2.Update()
                Rs.MoveNext()
            Loop

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()
        Connection_Close()

    End Sub

End Class
