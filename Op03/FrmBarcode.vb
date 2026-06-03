Public Class FrmBarcode
    Private Sub FrmBarcode_Load(sender As Object, e As EventArgs) Handles Me.Load

        srcTxtS1X.Text = BarcodeS1X
        srcTxtS1Y.Text = BarcodeS1Y
        srcTxtS1W.Text = BarcodeS1W
        srcTxtS1H.Text = BarcodeS1H

        srcTxtS2X.Text = BarcodeS2X
        srcTxtS2Y.Text = BarcodeS2Y
        srcTxtS2W.Text = BarcodeS2W
        srcTxtS2H.Text = BarcodeS2H

        srcTxtS3X.Text = BarcodeS3X
        srcTxtS3Y.Text = BarcodeS3Y
        srcTxtS3W.Text = BarcodeS3W
        srcTxtS3H.Text = BarcodeS3H

        srcTxtS4X.Text = BarcodeS4X
        srcTxtS4Y.Text = BarcodeS4Y
        srcTxtS4W.Text = BarcodeS4W
        srcTxtS4H.Text = BarcodeS4H

        srcTxtS5X.Text = BarcodeS5X
        srcTxtS5Y.Text = BarcodeS5Y
        srcTxtS5W.Text = BarcodeS5W
        srcTxtS5H.Text = BarcodeS5H

        srcTxtBX.Text = BarcodeBX
        srcTxtBY.Text = BarcodeBY
        srcTxtBH.Text = BarcodeBH
        srcTxtBL.Text = BarcodeBL
        srcTxtBS.Text = BarcodeBS

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        BarcodeS1X = srcTxtS1X.Text
        BarcodeS1Y = srcTxtS1Y.Text
        BarcodeS1W = srcTxtS1W.Text
        BarcodeS1H = srcTxtS1H.Text

        BarcodeS2X = srcTxtS2X.Text
        BarcodeS2Y = srcTxtS2Y.Text
        BarcodeS2W = srcTxtS2W.Text
        BarcodeS2H = srcTxtS2H.Text

        BarcodeS3X = srcTxtS3X.Text
        BarcodeS3Y = srcTxtS3Y.Text
        BarcodeS3W = srcTxtS3W.Text
        BarcodeS3H = srcTxtS3H.Text

        BarcodeS4X = srcTxtS4X.Text
        BarcodeS4Y = srcTxtS4Y.Text
        BarcodeS4W = srcTxtS4W.Text
        BarcodeS4H = srcTxtS4H.Text

        BarcodeS5X = srcTxtS5X.Text
        BarcodeS5Y = srcTxtS5Y.Text
        BarcodeS5W = srcTxtS5W.Text
        BarcodeS5H = srcTxtS5H.Text

        BarcodeBX = srcTxtBX.Text
        BarcodeBY = srcTxtBY.Text
        BarcodeBH = srcTxtBH.Text
        BarcodeBL = srcTxtBL.Text
        BarcodeBS = srcTxtBS.Text

        SaveBarcodeData()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class