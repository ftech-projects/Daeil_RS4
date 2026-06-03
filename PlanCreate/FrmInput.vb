Public Class FrmInput

    Private tmpCount As String

    Private Sub Frm_Input_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadCombbColor()
        LoadCombbPart()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        If ComboBox1.Text <> "" And ComboBox2.Text <> "" And TextBox1.Text <> "" Then
            FrmMain.AddPlan(ComboBox1.Text, ComboBox2.Text, TextBox1.Text)
            Me.Close()
            FrmMain.InitGrid()
            FrmMain.LoadPlan()
        Else
            MsgBox("모든항목을 입력해주세요")
        End If

    End Sub

    Private Sub LoadCombbPart()

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset
        Dim tmp As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", MdbConnect)

        If Rs.RecordCount > 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                ComboBox1.Items.Add(Trim(Rs.Fields("PartNo").Value))
                Rs.MoveNext()
            Loop
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

    Private Sub LoadCombbColor()

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset
        Dim tmp As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Color ORDER BY LEN(ColorCode),ColorCode", MdbConnect)

        If Rs.RecordCount > 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                ComboBox2.Items.Add(Trim(Rs.Fields("ColorCode").Value))
                Rs.MoveNext()
            Loop
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

End Class