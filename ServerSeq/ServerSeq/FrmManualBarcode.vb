Public Class FrmManualBarcode

    Private Sub FrmManualBarcode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lbAlc1.Text = ""
        lbAlc2.Text = ""
        lbAlc3.Text = ""
        lbAlc4.Text = ""
        lbAlc5.Text = ""
        lbAlc6.Text = ""
        lbAlc7.Text = ""
        lbAlc8.Text = ""
        LoadComboPart()
        LoadComboColor()

    End Sub

    Private Sub LoadComboPart()
        'Dim Rs As New ADODB.Recordset
        'ConnectionOpenMdb()
        'Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        'Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        'Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", MdbConnect)
        'If Rs.RecordCount > 1 Then
        '    Rs.MoveFirst()
        '    Do Until Rs.EOF
        '        If Rs.Fields("optionlhrh").Value = "LH" Then
        '            cbPartLh1.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartLh2.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartLh3.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartLh4.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartLh5.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartLh6.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartLh7.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartLh8.Items.Add(Rs.Fields("PartNo").Value)
        '        ElseIf Rs.Fields("optionlhrh").Value = "RH" Then
        '            cbPartRh1.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartRh2.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartRh3.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartRh4.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartRh5.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartRh6.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartRh7.Items.Add(Rs.Fields("PartNo").Value)
        '            cbPartRh8.Items.Add(Rs.Fields("PartNo").Value)
        '        End If
        '        Rs.MoveNext()
        '    Loop
        'End If
        'Rs.ActiveConnection = Nothing
        'Rs.Close()
        'ConnectionCloseMdb()
    End Sub

    Private Sub LoadComboColor()
        'Dim Rs As New ADODB.Recordset
        'ConnectionOpenMdb()
        'Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        'Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        'Rs.Open("SELECT * FROM Table_Color ORDER BY LEN(ColorCode),ColorCode", MdbConnect)
        'If Rs.RecordCount > 1 Then
        '    Rs.MoveFirst()
        '    Do Until Rs.EOF
        '        cbColorLh1.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorLh2.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorLh3.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorLh4.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorLh5.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorLh6.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorLh7.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorLh8.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorRh1.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorRh2.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorRh3.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorRh4.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorRh5.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorRh6.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorRh7.Items.Add(Rs.Fields("ColorCode").Value)
        '        cbColorRh8.Items.Add(Rs.Fields("ColorCode").Value)
        '        Rs.MoveNext()
        '    Loop
        'End If
        'Rs.ActiveConnection = Nothing
        'Rs.Close()
        'ConnectionCloseMdb()
    End Sub

    Private Function PartNo2AlcCode(ByVal LhPartno As String, ByVal LhColorCode As String, ByVal RhPartno As String, ByVal RhColorCode As String) As String

        Dim tmp As String = "000"
        Dim Rs As New ADODB.Recordset
        ConnectionOpenMdb()
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_AlcCode Where PartNoLH = '" & LhPartno & LhColorCode & "' and PartNoRH = '" & RhPartno & RhColorCode & "'", MdbConnect)
        If Rs.RecordCount >= 1 Then
            tmp = Rs.Fields("ALCCODE").Value
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionCloseMdb()
        Return tmp

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        CarType = txtCar.Text
        LotNo = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        DeliveryDate = Format(DateTimePicker2.Value, "yyyy-MM-dd")
        OkNumber = txtNum.Text

        'SeqPartLH(0) = cbPartLh1.Text & cbColorLh1.Text
        'SeqPartLH(1) = cbPartLh2.Text & cbColorLh2.Text
        'SeqPartLH(2) = cbPartLh3.Text & cbColorLh3.Text
        'SeqPartLH(3) = cbPartLh4.Text & cbColorLh4.Text
        'SeqPartLH(4) = cbPartLh5.Text & cbColorLh5.Text
        'SeqPartLH(5) = cbPartLh6.Text & cbColorLh6.Text
        'SeqPartLH(6) = cbPartLh7.Text & cbColorLh7.Text
        'SeqPartLH(7) = cbPartLh8.Text & cbColorLh8.Text

        'LbAlc1.Text = "ABCDEB1"
        'LbAlc2.Text = "ABCDEB2"
        'LbAlc3.Text = "ABCDEB3"
        'LbAlc4.Text = "ABCDEB4"
        'LbAlc5.Text = "ABCDEB5"
        'LbAlc6.Text = "ABCDEB6"
        'LbAlc7.Text = "ABCDEB7"
        'LbAlc8.Text = "ABCDEB8"

        SeqPart(0) = LbAlc1.Text
        SeqPart(1) = LbAlc2.Text
        SeqPart(2) = LbAlc3.Text
        SeqPart(3) = LbAlc4.Text
        SeqPart(4) = LbAlc5.Text
        SeqPart(5) = LbAlc6.Text
        SeqPart(6) = LbAlc7.Text
        SeqPart(7) = LbAlc8.Text

        FrmMain.BarcodePrint()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class