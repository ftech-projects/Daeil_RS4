Public Class FrmBarcode

    Private TmpPartName As String
    Private TmpPartShortName As String

    Private Sub FrmBarcode_Load(sender As Object, e As EventArgs) Handles Me.Load

        txt1X.Text = B1X
        txt1Y.Text = B1Y
        txt1L.Text = B1L

        txt2X.Text = B2X
        txt2Y.Text = B2Y
        txt2W.Text = B2W
        txt2H.Text = B2H

        txt3X.Text = B3X
        txt3Y.Text = B3Y
        txt3W.Text = B3W
        txt3H.Text = B3H

        txt4X.Text = B4X
        txt4Y.Text = B4Y
        txt4W.Text = B4W
        txt4H.Text = B4H

        txt5X.Text = B5X
        txt5Y.Text = B5Y
        txt5W.Text = B5W
        txt5H.Text = B5H

        txt6X.Text = B6X
        txt6Y.Text = B6Y
        txt6W.Text = B6W
        txt6H.Text = B6H

        txt7X.Text = B7X
        txt7Y.Text = B7Y
        txt7W.Text = B7W
        txt7H.Text = B7H

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        B1X = txt1X.Text
        B1Y = txt1Y.Text
        B1L = txt1L.Text

        B2X = txt2X.Text
        B2Y = txt2Y.Text
        B2W = txt2W.Text
        B2H = txt2H.Text

        B3X = txt3X.Text
        B3Y = txt3Y.Text
        B3W = txt3W.Text
        B3H = txt3H.Text

        B4X = txt4X.Text
        B4Y = txt4Y.Text
        B4H = txt4W.Text
        B4W = txt4H.Text

        B5X = txt5X.Text
        B5Y = txt5Y.Text
        B5W = txt5W.Text
        B5H = txt5H.Text

        B6X = txt6X.Text
        B6Y = txt6Y.Text
        B6W = txt6W.Text
        B6H = txt6H.Text

        B7X = txt7X.Text
        B7Y = txt7Y.Text
        B7W = txt7W.Text
        B7H = txt7H.Text

        SaveBarcodeData()

    End Sub

End Class