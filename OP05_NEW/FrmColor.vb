Public Class FrmColor

    Private TmrSTep As Double

    Private Sub FrmColor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        pnBRZ.BackColor = Color.LightGray
        PnDUE.BackColor = Color.LightGray
        pnGLW.BackColor = Color.LightGray
        pnMGJ.BackColor = Color.LightGray
        PnNNB.BackColor = Color.LightGray

        TmrSTep = 0
        Timer1.Interval = 1000
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If TmrSTep = 0 Then

            If NOW_COLOR = "BRZ" Then
                pnBRZ.BackColor = Color.Yellow
            ElseIf NOW_COLOR = "DUE" Then
                PnDUE.BackColor = Color.Yellow
            ElseIf NOW_COLOR = "GLW" Then
                pnGLW.BackColor = Color.Yellow
            ElseIf NOW_COLOR = "MGJ" Then
                pnMGJ.BackColor = Color.Yellow
            ElseIf NOW_COLOR = "NNB" Then
                PnNNB.BackColor = Color.Yellow
            End If
            TmrSTep = 1

        ElseIf TmrSTep = 1 Then

            If NOW_COLOR = "BRZ" Then
                pnBRZ.BackColor = Color.Red
            ElseIf NOW_COLOR = "DUE" Then
                PnDUE.BackColor = Color.Red
            ElseIf NOW_COLOR = "GLW" Then
                pnGLW.BackColor = Color.Red
            ElseIf NOW_COLOR = "MGJ" Then
                pnMGJ.BackColor = Color.Red
            ElseIf NOW_COLOR = "NNB" Then
                PnNNB.BackColor = Color.Red
            End If
            TmrSTep = 0

        End If
        
    End Sub

    Private Sub lbDUE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbDUE.Click
        MsgBox(Me.Location.X)
    End Sub
End Class