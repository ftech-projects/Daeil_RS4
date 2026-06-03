Public Class FrmBasic
    Private Sub FrmBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        srcTxtMin.Text = CStr(BasicToolMin)
        srcTxtMax.Text = CStr(BasicToolMax)
        srcTxtUnit.Text = CStr(BAsicUnit)
        
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        BAsicUnit = CStr(srcTxtUnit.Text)
        BasicToolMin = CStr(srcTxtMin.Text)
        BasicToolMax = CStr(srcTxtMax.Text)

        SaveBasicData()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class