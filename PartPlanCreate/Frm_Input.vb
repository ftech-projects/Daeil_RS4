Public Class Frm_Input

    'Private tmpCount As String

    'Private Sub Frm_Input_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    LoadCombbColor()
    '    LoadCombbPart()

    'End Sub

    'Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

    '    If ComboBox1.Text <> "" And ComboBox2.Text <> "" And TextBox1.Text <> "" Then
    '        Frm_Plan.AddPlan(ComboBox1.Text, ComboBox2.Text, TextBox1.Text)
    '        Me.Close()
    '        Frm_Plan.InitGrid()
    '        Frm_Plan.LoadPlan()
    '    Else
    '        MsgBox("모든항목을 입력해주세요")
    '    End If

    'End Sub

    'Private Sub LoadCombbPart()

    '    Connection_Open()

    '    Dim Rs As New ADODB.Recordset
    '    Dim tmp As Integer

    '    Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '    Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
    '    Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

    '    Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", Sql_Connect)

    '    If Rs.RecordCount > 1 Then
    '        Rs.MoveFirst()
    '        Do Until Rs.EOF
    '            ComboBox1.Items.Add(Trim(Rs.Fields("PartNo").Value))
    '            Rs.MoveNext()
    '        Loop
    '    End If

    '    Rs.ActiveConnection = Nothing
    '    Rs.Close()

    '    Connection_Close()

    'End Sub

    'Private Sub LoadCombbColor()

    '    Connection_Open()

    '    Dim Rs As New ADODB.Recordset
    '    Dim tmp As Integer

    '    Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '    Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
    '    Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

    '    Rs.Open("SELECT * FROM Table_Color ORDER BY LEN(ColorCode),ColorCode", Sql_Connect)

    '    If Rs.RecordCount > 1 Then
    '        Rs.MoveFirst()
    '        Do Until Rs.EOF
    '            ComboBox2.Items.Add(Trim(Rs.Fields("ColorCode").Value))
    '            Rs.MoveNext()
    '        Loop
    '    End If

    '    Rs.ActiveConnection = Nothing
    '    Rs.Close()

    '    Connection_Close()

    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    tmpCount = tmpCount & sender.text
    '    TextBox1.Text = CInt(tmpCount)
    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    tmpCount = tmpCount & sender.text
    '    TextBox1.Text = CInt(tmpCount)
    'End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    tmpCount = tmpCount & sender.text
    '    TextBox1.Text = CInt(tmpCount)
    'End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    tmpCount = tmpCount & sender.text
    '    TextBox1.Text = CInt(tmpCount)
    'End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    tmpCount = tmpCount & sender.text
    '    TextBox1.Text = CInt(tmpCount)
    'End Sub

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    '    tmpCount = tmpCount & sender.text
    '    TextBox1.Text = CInt(tmpCount)
    'End Sub

    'Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
    '    tmpCount = tmpCount & sender.text
    'End Sub

    'Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
    '    tmpCount = tmpCount & sender.text
    '    TextBox1.Text = CInt(tmpCount)
    'End Sub

    'Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
    '    tmpCount = tmpCount & sender.text
    '    TextBox1.Text = CInt(tmpCount)
    'End Sub

    'Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
    '    tmpCount = tmpCount & sender.text
    '    TextBox1.Text = CInt(tmpCount)
    'End Sub

    'Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
    '    tmpCount = ""
    '    TextBox1.Text = ""
    'End Sub

End Class