' IO 제어 창 — FBEI 입력 실시간 표시 / 출력 클릭 강제 ON/OFF
' 메인폼 메뉴 'IO 제어'로 열림. FbeiIoClient(Ios) 참조를 받아 동작.
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmIo
    Inherits Form

    Private ReadOnly _io As FbeiIoClient
    Private ReadOnly _inLabels(48) As Label    ' 입력 핀0~31 (사용분만 생성)
    Private ReadOnly _outLabels(24) As Label   ' 출력 핀0~11
    Private ReadOnly LedOff As Color = Color.FromArgb(64, 64, 64)
    Private ReadOnly LedInOn As Color = Color.Green    ' 짙은 녹색 (흰 글자 가독성 — Lime은 글자 묻힘)
    Private ReadOnly LedOutOn As Color = Color.Red

    Public Sub New(io As FbeiIoClient)
        _io = io
        Me.Text = "IO 제어 — FBEI"
        Me.ClientSize = New Size(770, 840)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(30, 30, 30)
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        BuildPanels()
        SyncInputs()                         ' 현재 입력상태 초기 반영 (이벤트는 변화시만 옴)
        If _io IsNot Nothing Then AddHandler _io.InputChanged, AddressOf OnInputChanged
        AddHandler Me.FormClosed,
            Sub() If _io IsNot Nothing Then RemoveHandler _io.InputChanged, AddressOf OnInputChanged
    End Sub

    Private Sub BuildPanels()
        ' === IN 패널 ===
        Dim pnlIn As New Panel With {.Location = New Point(8, 8), .Size = New Size(372, 824),
            .BorderStyle = BorderStyle.FixedSingle, .BackColor = Color.Black, .AutoScroll = True}
        Header(pnlIn, "입 력 (IN)")
        Dim r As Integer = 0
        For pin As Integer = 0 To Math.Min(IoMap.InputNames.Length, _inLabels.Length) - 1
            If IoMap.InputNames(pin) = "" Then Continue For
            Dim lb As Label = MkLabel("ledIn" & pin.ToString("00"), pin, IoMap.InputNames(pin), r, False)
            _inLabels(pin) = lb
            pnlIn.Controls.Add(lb)
            r += 1
        Next
        Controls.Add(pnlIn)

        ' === OUT 패널 (클릭 ON/OFF) ===
        Dim pnlOut As New Panel With {.Location = New Point(388, 8), .Size = New Size(372, 824),
            .BorderStyle = BorderStyle.FixedSingle, .BackColor = Color.Black, .AutoScroll = True}
        Header(pnlOut, "출 력 (OUT)  ▶ 클릭 강제 ON/OFF")
        r = 0
        For pin As Integer = 0 To Math.Min(IoMap.OutputNames.Length, _outLabels.Length) - 1
            Dim lb As Label = MkLabel("ledOut" & pin.ToString("00"), pin, IoMap.OutputNames(pin), r, True)
            lb.Tag = pin + 1                 ' 출력채널(1-base)
            AddHandler lb.Click, AddressOf OutClick
            _outLabels(pin) = lb
            pnlOut.Controls.Add(lb)
            r += 1
        Next
        Controls.Add(pnlOut)
    End Sub

    ''' <summary>현재 입력 비트 전체를 LED에 초기 반영</summary>
    Private Sub SyncInputs()
        If _io Is Nothing Then Return
        Try
            Dim bits = _io.GetInputBits()
            For pin As Integer = 0 To _inLabels.Length - 1
                If _inLabels(pin) IsNot Nothing AndAlso pin < bits.Length Then
                    _inLabels(pin).BackColor = If(bits(pin), LedInOn, LedOff)
                End If
            Next
        Catch
        End Try
    End Sub

    ''' <summary>입력 변화(스캔스레드) → LED 갱신. CheckForIllegalCrossThreadCalls=False 전제.</summary>
    Private Sub OnInputChanged(channel As Integer, value As Boolean)
        Dim pin As Integer = channel - 1
        Try
            If pin >= 0 AndAlso pin <= _inLabels.Length - 1 AndAlso _inLabels(pin) IsNot Nothing Then
                _inLabels(pin).BackColor = If(value, LedInOn, LedOff)
            End If
        Catch
        End Try
    End Sub

    ''' <summary>출력 라벨 클릭 → 강제 토글</summary>
    Private Sub OutClick(sender As Object, e As EventArgs)
        Dim lb As Label = TryCast(sender, Label)
        If lb Is Nothing OrElse lb.Tag Is Nothing Then Return
        Dim ch As Integer = CInt(lb.Tag)
        Dim newState As Boolean = (lb.BackColor <> LedOutOn)
        Try
            If _io IsNot Nothing Then _io.SetOutput(ch, newState)
        Catch
        End Try
        lb.BackColor = If(newState, LedOutOn, LedOff)
    End Sub

    Private Sub Header(pnl As Panel, text As String)
        pnl.Controls.Add(New Label With {.Text = text, .AutoSize = False, .Size = New Size(366, 28),
            .Location = New Point(1, 1), .TextAlign = ContentAlignment.MiddleCenter,
            .BackColor = Color.Navy, .ForeColor = Color.White, .Font = New Font("맑은 고딕", 11.0!, FontStyle.Bold)})
    End Sub

    Private Function MkLabel(name As String, pin As Integer, sig As String, row As Integer, isOut As Boolean) As Label
        Return New Label With {
            .Name = name, .Text = (pin + 1).ToString("00") & "   " & sig,
            .AutoSize = False, .Size = New Size(360, 28),
            .Location = New Point(4, 34 + row * 30),
            .BorderStyle = BorderStyle.FixedSingle, .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("맑은 고딕", 10.0!), .BackColor = LedOff, .ForeColor = Color.White,
            .Cursor = If(isOut, Cursors.Hand, Cursors.Default)}
    End Function
End Class
