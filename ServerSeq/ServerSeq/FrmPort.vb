
Public Class FrmPort

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PortNumberScanner = CbScanner.Text
        PortNumberPrinter = CbPrinter.Text
        SavePortData()
    End Sub

    Private Sub FrmPort_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        For i As Integer = 1 To 16
            CbScanner.Items.Add("COM" & CStr(i))
            CbPrinter.Items.Add("COM" & CStr(i))
        Next
        CbScanner.Text = PortNumberScanner
        CbPrinter.Text = PortNumberPrinter
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class