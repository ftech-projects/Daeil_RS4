Public Class FrmBasic
    Private Sub FrmBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        srcTxtMotorMin.Text = CStr(BasicMotorToolMin)
        srcTxtMotorMax.Text = CStr(BasicMotorToolMax)
        srcTxtMotorUnit.Text = CStr(BAsicMotorUnit)

        srcTxtSabMin.Text = CStr(BasicSabToolMin)
        srcTxtSabMax.Text = CStr(BasicSabToolMax)
        srcTxtSabUnit.Text = CStr(BAsicSabUnit)

        srcTxtResistMin.Text = CStr(BasicResistMin)
        srcTxtResistMax.Text = CStr(BasicResistMax)

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        BasicMotorToolMin = CDbl(srcTxtMotorMin.Text)
        BasicMotorToolMax = CDbl(srcTxtMotorMax.Text)
        BAsicMotorUnit = srcTxtMotorUnit.Text

        BasicSabToolMin = CDbl(srcTxtSabMin.Text)
        BasicSabToolMax = CDbl(srcTxtSabMax.Text)
        BAsicSabUnit = srcTxtSabUnit.Text

        BasicResistMin = CDbl(srcTxtResistMin.Text)
        BasicResistMax = CDbl(srcTxtResistMax.Text)

        SaveBasicData()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class