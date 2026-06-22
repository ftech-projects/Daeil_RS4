Public Class FrmIo

    Private ReadOnly _main As FrmMain

    Public Sub New(main As FrmMain)
        _main = main
        InitializeComponent()
    End Sub

    Private Const RowH As Integer = 26
    Private Const RowW As Integer = 220

    Private _comDi(MultiMonitorIoClient.DiCount - 1) As Label
    Private _comDo(MultiMonitorIoClient.DoCount - 1) As Button
    Private _fbeiDi(31) As Label
    Private _fbeiDo(31) As Button

    Private Sub FrmIo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuildComPanel()
        BuildFbeiPanel()
        RefreshAll()
        TimerRefresh.Start()
    End Sub

    Private Sub BuildComPanel()
        For i As Integer = 0 To MultiMonitorIoClient.DiCount - 1
            Dim ch = i + 1
            Dim lbl = CreateDiLabel(PanelComIn, ch, ComDiName(ch), 0, i * RowH)
            _comDi(i) = lbl
        Next

        For i As Integer = 0 To MultiMonitorIoClient.DoCount - 1
            Dim ch = i + 1
            Dim btn = CreateDoButton(PanelComOut, "DO" & ch.ToString(), ch, 0, i * RowH, True)
            _comDo(i) = btn
        Next
    End Sub

    Private Sub BuildFbeiPanel()
        For i As Integer = 0 To 31
            Dim ch = i + 1
            Dim col = i \ 16
            Dim row = i Mod 16
            _fbeiDi(i) = CreateDiLabel(PanelFbeiIn, ch, "X" & ch.ToString(), col * (RowW + 8), row * RowH)
            _fbeiDo(i) = CreateDoButton(PanelFbeiOut, "Q" & ch.ToString(), ch, col * (RowW + 8), row * RowH, False)
        Next
    End Sub

    Private Function CreateDiLabel(parent As Panel, channel As Integer, caption As String, x As Integer, y As Integer) As Label
        Dim lbl As New Label()
        lbl.Size = New Size(RowW, RowH - 2)
        lbl.Location = New Point(4 + x, 4 + y)
        lbl.BorderStyle = BorderStyle.FixedSingle
        lbl.TextAlign = ContentAlignment.MiddleLeft
        lbl.Font = New Font("Arial Narrow", 10.0F, FontStyle.Bold)
        lbl.Text = " " & caption
        lbl.Tag = channel
        parent.Controls.Add(lbl)
        Return lbl
    End Function

    Private Function CreateDoButton(parent As Panel, caption As String, channel As Integer, x As Integer, y As Integer, isCom As Boolean) As Button
        Dim btn As New Button()
        btn.Size = New Size(RowW, RowH - 2)
        btn.Location = New Point(4 + x, 4 + y)
        btn.FlatStyle = FlatStyle.Flat
        btn.Font = New Font("Arial Narrow", 10.0F, FontStyle.Bold)
        btn.Text = caption
        btn.Tag = New DoTag(channel, isCom)
        AddHandler btn.Click, AddressOf DoButton_Click
        parent.Controls.Add(btn)
        Return btn
    End Function

    Private Class DoTag
        Public ReadOnly Channel As Integer
        Public ReadOnly IsCom As Boolean
        Public Sub New(ch As Integer, com As Boolean)
            Channel = ch
            IsCom = com
        End Sub
    End Class

    Private Function ComDiName(channel As Integer) As String
        Dim s = _main.IoMonitorSettings
        If s Is Nothing Then Return "IN" & (channel - 1).ToString()
        If channel = s.IoChannelStart() Then Return "IN0 Start"
        If channel = s.IoChannelReset() Then Return "IN1 Reset"
        If channel = s.IoChannelEStop() Then Return "IN2 E-Stop"
        If channel = s.IoChannelAirTool() Then Return "IN3 에어툴"
        Return "IN" & (channel - 1).ToString()
    End Function

    Private Sub DoButton_Click(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Button)
        Dim tag = CType(btn.Tag, DoTag)
        Try
            If tag.IsCom Then
                Dim mm = _main.IoMonitorMm
                If mm Is Nothing OrElse Not mm.IsConnected Then Return
                mm.SetDigitalOutput(tag.Channel, Not mm.GetDigitalOutput(tag.Channel))
            Else
                Dim ios = _main.IoMonitorFbei
                If ios Is Nothing OrElse Not _main.IoMonitorFbeiOk Then Return
                ios.SetOutput(tag.Channel, Not ios.GetOutput(tag.Channel))
            End If
        Catch ex As Exception
            LblStatus.Text = "DO 오류: " & ex.Message
        End Try
        RefreshAll()
    End Sub

    Private Sub TimerRefresh_Tick(sender As Object, e As EventArgs) Handles TimerRefresh.Tick
        RefreshAll()
    End Sub

    Private Sub RefreshAll()
        Dim mm = _main.IoMonitorMm
        Dim ios = _main.IoMonitorFbei
        Dim settings = _main.IoMonitorSettings

        If mm IsNot Nothing AndAlso mm.IsConnected Then
            For i As Integer = 0 To MultiMonitorIoClient.DiCount - 1
                ApplyDiLabel(_comDi(i), mm.GetDigitalInput(i + 1))
            Next
            For i As Integer = 0 To MultiMonitorIoClient.DoCount - 1
                ApplyDoButton(_comDo(i), mm.GetDigitalOutput(i + 1))
            Next
            Dim aiText As String = ""
            For ai As Integer = 1 To MultiMonitorIoClient.AiCount
                If aiText.Length > 0 Then aiText &= "   "
                aiText &= "AI" & ai.ToString() & "=" & mm.GetAnalogRaw(ai).ToString()
            Next
            LblComAi.Text = "  " & aiText
        Else
            For i As Integer = 0 To _comDi.Length - 1
                If _comDi(i) IsNot Nothing Then ApplyDiLabel(_comDi(i), False)
            Next
            For i As Integer = 0 To _comDo.Length - 1
                If _comDo(i) IsNot Nothing Then ApplyDoButton(_comDo(i), False)
            Next
            LblComAi.Text = "  COM I/O 미연결"
        End If

        If ios IsNot Nothing AndAlso _main.IoMonitorFbeiOk Then
            For i As Integer = 0 To 31
                ApplyDiLabel(_fbeiDi(i), ios.GetInput(i + 1))
                ApplyDoButton(_fbeiDo(i), ios.GetOutput(i + 1))
            Next
        Else
            For i As Integer = 0 To 31
                ApplyDiLabel(_fbeiDi(i), False)
                ApplyDoButton(_fbeiDo(i), False)
            Next
        End If

        Dim comPort = If(settings IsNot Nothing, settings.ComPort, "-")
        Dim comState = If(mm IsNot Nothing AndAlso mm.IsConnected, "OK", "NG")
        Dim fbeiState = If(_main.IoMonitorFbeiOk, "OK", "NG")
        LblStatus.Text = "  COM " & comPort & " : " & comState &
                         "   |   FBEI : " & fbeiState &
                         If(settings IsNot Nothing AndAlso settings.FbeiEnabled,
                            " (DI=" & settings.FbeiDiIp & ", DO=" & settings.FbeiDoIp & ")",
                            " (disabled)")
    End Sub

    Private Shared Sub ApplyDiLabel(lbl As Label, isOn As Boolean)
        lbl.BackColor = If(isOn, Color.Lime, Color.LightGray)
        lbl.ForeColor = Color.Black
    End Sub

    Private Shared Sub ApplyDoButton(btn As Button, isOn As Boolean)
        btn.BackColor = If(isOn, Color.Orange, Color.LightGray)
        btn.ForeColor = Color.Black
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmIo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        TimerRefresh.Stop()
    End Sub

End Class
