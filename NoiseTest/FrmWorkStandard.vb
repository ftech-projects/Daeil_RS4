Public Class FrmWorkStandard

    Public Sub LoadPicture(ByVal picTarget As PictureBox, ByVal picName As String)

        Try
            picTarget.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\Image_WorkStandard\" & picName & ".png")
        Catch ex As Exception
        End Try

        Try
            picTarget.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\Image_WorkStandard\" & picName & ".jpg")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub srcPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles srcPictureBox.Click
        'Me.Close()
    End Sub
End Class