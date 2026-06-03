Public Class FrmBasic
    Private Sub FrmBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        srcTxtMax.Text = CStr(BAsicFrtMax_STDLH)
        srcTxtMin.Text = CStr(BAsicFrtMin_STDLH)
        TextBox2.Text = CStr(BAsicRearMax_STDLH)
        TextBox1.Text = CStr(BAsicRearMin_STDLH)

        TextBox6.Text = CStr(BAsicFrtMax_FOLDRH)
        TextBox5.Text = CStr(BAsicFrtMin_FOLDRH)
        TextBox4.Text = CStr(BAsicRearMax_FOLDRH)
        TextBox3.Text = CStr(BAsicRearMin_FOLDRH)

        TextBox10.Text = CStr(BAsicFrtMax_VIPRH)
        TextBox9.Text = CStr(BAsicFrtMin_VIPRH)
        TextBox8.Text = CStr(BAsicRearMax_VIPRH)
        TextBox7.Text = CStr(BAsicRearMin_VIPRH)

        TextBox12.Text = CStr(basicFrtTolVIP)
        TextBox11.Text = CStr(BasicRearTolVIP)

        TextBox14.Text = CStr(basicFrtTolSTD)
        TextBox13.Text = CStr(BasicRearTolSTD)

        TextBox16.Text = CStr(basicFrtTolFOLD)
        TextBox15.Text = CStr(BasicRearTolFOLD)

        CheckBox1.Checked = FlagBeforeCheck
        CheckBox2.Checked = FlagDuplicate

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        BAsicFrtMax_STDLH = CDbl(srcTxtMax.Text)
        BAsicFrtMin_STDLH = CDbl(srcTxtMin.Text)
        BAsicRearMax_STDLH = CDbl(TextBox2.Text)
        BAsicRearMin_STDLH = CDbl(TextBox1.Text)

        BAsicFrtMax_FOLDRH = CDbl(TextBox6.Text)
        BAsicFrtMin_FOLDRH = CDbl(TextBox5.Text)
        BAsicRearMax_FOLDRH = CDbl(TextBox4.Text)
        BAsicRearMin_FOLDRH = CDbl(TextBox3.Text)

        BAsicFrtMax_VIPRH = CDbl(TextBox10.Text)
        BAsicFrtMin_VIPRH = CDbl(TextBox9.Text)
        BAsicRearMax_VIPRH = CDbl(TextBox8.Text)
        BAsicRearMin_VIPRH = CDbl(TextBox7.Text)

        basicFrtTolVIP = CDbl(TextBox12.Text)
        BasicRearTolVIP = CDbl(TextBox11.Text)

        basicFrtTolSTD = CDbl(TextBox14.Text)
        BasicRearTolSTD = CDbl(TextBox13.Text)

        basicFrtTolFOLD = CDbl(TextBox16.Text)
        BasicRearTolFOLD = CDbl(TextBox15.Text)

        FlagBeforeCheck = CheckBox1.Checked
        FlagDuplicate = CheckBox2.Checked

        SaveBasicData()
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class