Public Class FrmBasic

    Private Sub CN7_btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CN7_btn_Save.Click

        FlagTogether = CheckBox1.Checked

        BasicReclVolt = CDbl(RECL_VOLT.Text)
        BasicLsuptVolt = CDbl(LSUPT_VOLT.Text)

        BasicReclFwdAmpMin = CDbl(FWD_AMP_MIN.Text)
        BasicReclFwdAmpMax = CDbl(FWD_AMP_MAX.Text)
        BasicReclFwdNoiseMin = CDbl(FWD_NOISE_MIN.Text)
        BasicReclFwdNoiseMax = CDbl(FWD_NOISE_MAX.Text)

        BasicReclBwdAmpMin = CDbl(BWD_AMP_MIN.Text)
        BasicReclBwdAmpMax = CDbl(BWD_AMP_MAX.Text)
        BasicReclBwdNoiseMin = CDbl(BWD_NOISE_MIN.Text)
        BasicReclBwdNoiseMax = CDbl(BWD_NOISE_MAX.Text)

        BasicReclFwdSpeedMin = CDbl(FWD_ANGLE_MIN.Text)
        BasicReclFwdSpeedMax = CDbl(FWD_ANGLE_MAX.Text)
        BasicReclBwdSpeedMin = CDbl(BWD_ANGLE_MIN.Text)
        BasicReclBwdSpeedMax = CDbl(BWD_ANGLE_MAX.Text)

        BasicFrestFwdAmpMax = CDbl(L_FWD_AMP_MAX.Text)
        BasicFrestFwdAmpMin = CDbl(L_FWD_AMP_MIN.Text)
        BasicFrestFwdNoiseMax = CDbl(L_FWD_NOISE_MAX.Text)
        BasicFrestFwdNoiseMin = CDbl(L_FWD_NOISE_MIN.Text)

        BasicFrestBwdAmpMax = CDbl(L_BWD_AMP_MAX.Text)
        BasicFrestBwdAmpMin = CDbl(L_BWD_AMP_MIN.Text)

        BasicFrestBwdNoiseMax = CDbl(L_BWD_NOISE_MAX.Text)
        BasicFrestBwdNoiseMin = CDbl(L_BWD_NOISE_MIN.Text)

        BasicFrestBwdSpeedMax = CDbl(L_BWD_ANGLE_MAX.Text)
        BasicFrestBwdSpeedMin = CDbl(L_BWD_ANGLE_MIN.Text)

        BasicFrestFwdSpeedMax = CDbl(L_FWD_ANGLE_MAX.Text)
        BasicFrestFwdSpeedMin = CDbl(L_FWD_ANGLE_MIN.Text)

        BasicReclFwdAngleMin = CDbl(FWD_ANGLE_MIN.Text)
        BasicReclFwdAngleMax = CDbl(FWD_ANGLE_MAX.Text)

        BasicReclBwdAngleMin = CDbl(BWD_ANGLE_MIN.Text)
        BasicReclBwdAngleMax = CDbl(BWD_ANGLE_MAX.Text)

        BasicReclStopAmp = CDbl(RECL_STOP_AMP.Text)
        BasicLsuptStopAmp = CDbl(LSUPT_STOP_AMP.Text)

        BasicLsuptAmpMax = CDbl(TextBox5.Text)
        BasicLsuptAmpMin = CDbl(TextBox4.Text)
        BasicLsuptNoiseMax = CDbl(TextBox3.Text)
        BasicLsuptNoiseMin = CDbl(TextBox2.Text)

        BasicLsuptInfTime = CDbl(TextBox1.Text)
        BasicLsuptDefTime = CDbl(TextBox6.Text)
        BasicBolsterInfTime = CDbl(TextBox8.Text)
        BasicBolsterDefTime = CDbl(TextBox7.Text)

        SaveBasicData()

    End Sub

    Private Sub CN7_btn_CLose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CN7_btn_CLose.Click
        Me.Close()
    End Sub

    Private Sub FrmBasic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CheckBox1.Checked = FlagTogether

        FWD_AMP_MIN.Text = CStr(BasicReclFwdAmpMin)
        FWD_AMP_MAX.Text = CStr(BasicReclFwdAmpMax)
        FWD_NOISE_MIN.Text = CStr(BasicReclFwdNoiseMin)
        FWD_NOISE_MAX.Text = CStr(BasicReclFwdNoiseMax)

        BWD_AMP_MIN.Text = CStr(BasicReclBwdAmpMin)
        BWD_AMP_MAX.Text = CStr(BasicReclBwdAmpMax)
        BWD_NOISE_MIN.Text = CStr(BasicReclBwdNoiseMin)
        BWD_NOISE_MAX.Text = CStr(BasicReclBwdNoiseMax)

        L_FWD_AMP_MAX.Text = CStr(BasicFrestFwdAmpMax)
        L_FWD_AMP_MIN.Text = CStr(BasicFrestFwdAmpMin)
        L_FWD_NOISE_MAX.Text = CStr(BasicFrestFwdNoiseMax)
        L_FWD_NOISE_MIN.Text = CStr(BasicFrestFwdNoiseMin)

        L_BWD_AMP_MAX.Text = CStr(BasicFrestBwdAmpMax)
        L_BWD_AMP_MIN.Text = CStr(BasicFrestBwdAmpMin)
        L_BWD_NOISE_MAX.Text = CStr(BasicFrestBwdNoiseMax)
        L_BWD_NOISE_MIN.Text = CStr(BasicFrestBwdNoiseMin)

        L_FWD_ANGLE_MAX.Text = CStr(BasicFrestFwdSpeedMax)
        L_FWD_ANGLE_MIN.Text = CStr(BasicFrestFwdSpeedMin)

        L_BWD_ANGLE_MAX.Text = CStr(BasicFrestBwdSpeedMax)
        L_BWD_ANGLE_MIN.Text = CStr(BasicFrestBwdSpeedMin)

        FWD_ANGLE_MIN.Text = CStr(BasicReclFwdSpeedMin)
        FWD_ANGLE_MAX.Text = CStr(BasicReclFwdSpeedMax)

        BWD_ANGLE_MIN.Text = CStr(BasicReclBwdSpeedMin)
        BWD_ANGLE_MAX.Text = CStr(BasicReclBwdSpeedMax)

        RECL_STOP_AMP.Text = CStr(BasicReclStopAmp)
        LSUPT_STOP_AMP.Text = CStr(BasicLsuptStopAmp)

        TextBox5.Text = CStr(BasicLsuptAmpMax)
        TextBox4.Text = CStr(BasicLsuptAmpMin)
        TextBox3.Text = CStr(BasicLsuptNoiseMax)
        TextBox2.Text = CStr(BasicLsuptNoiseMin)

        TextBox1.Text = CStr(BasicLsuptInfTime)
        TextBox6.Text = CStr(BasicLsuptDefTime)
        TextBox8.Text = CStr(BasicBolsterInfTime)
        TextBox7.Text = CStr(BasicBolsterDefTime)

        RECL_VOLT.Text = CStr(BasicReclVolt)
        LSUPT_VOLT.Text = CStr(BasicLsuptVolt)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FrmBasicAngle.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FrmAngleBasic.Show()
    End Sub

End Class