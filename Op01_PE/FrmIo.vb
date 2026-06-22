' IO 제어 창 — FBEI 입력 실시간 표시 / 출력 클릭 강제 ON/OFF
' 핀맵: IoMap.vb (이미지1 / 전장 배선 기준)
Imports System.Collections
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmIo
    Inherits Form

    Private ReadOnly _io As FbeiIoClient
    Private ReadOnly _inLabels(48) As Label
    Private ReadOnly _outLabels(24) As Label
    Private ReadOnly LedOff As Color = Color.FromArgb(64, 64, 64)
    Private ReadOnly LedInOn As Color = Color.Green
    Private ReadOnly LedOutOn As Color = Color.OrangeRed
    Private Const IoRowHeight As Integer = 28
    Private Const IoRowPitch As Integer = 30
    Private Const InLabelWidth As Integer = 388
    Private Const OutLabelWidth As Integer = 384

    Public Sub New(io As FbeiIoClient)
        _io = io
        Me.Text = "IO 제어 — FBEI (Op01_PE)"
        Me.ClientSize = New Size(820, 900)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(30, 30, 30)
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        BuildPanels()
        SyncInputs()
        If _io IsNot Nothing Then AddHandler _io.InputChanged, AddressOf OnInputChanged
        AddHandler Me.FormClosed,
            Sub() If _io IsNot Nothing Then RemoveHandler _io.InputChanged, AddressOf OnInputChanged
    End Sub

    Private Sub BuildPanels()
        ' === IN 패널 (운전 스위치 IN:00~02 포함 — 이미지1 동일) ===
        Dim pnlIn As New Panel With {
            .Location = New Point(8, 8), .Size = New Size(400, 884),
            .BorderStyle = BorderStyle.FixedSingle, .BackColor = Color.Black, .AutoScroll = True
        }
        Header(pnlIn, "입 력 (IN) — IN:핀번호")
        Dim r As Integer = 0
        For pin As Integer = 0 To Math.Min(IoMap.InputNames.Length, _inLabels.Length) - 1
            If IoMap.InputNames(pin) = "" Then Continue For
            Dim lb As Label = MkInLabel(pin, r)
            _inLabels(pin) = lb
            pnlIn.Controls.Add(lb)
            r += 1
        Next
        Controls.Add(pnlIn)

        ' === OUT 패널 ===
        Dim pnlOut As New Panel With {
            .Location = New Point(416, 8), .Size = New Size(396, 884),
            .BorderStyle = BorderStyle.FixedSingle, .BackColor = Color.Black, .AutoScroll = True
        }
        Header(pnlOut, "출 력 (OUT) — OUT:핀번호  ▶ 클릭 ON/OFF")
        r = 0
        For pin As Integer = 0 To Math.Min(IoMap.OutputNames.Length, _outLabels.Length) - 1
            Dim lb As Label = MkOutLabel(pin, r)
            lb.Tag = pin
            AddHandler lb.Click, AddressOf OutClick
            _outLabels(pin) = lb
            pnlOut.Controls.Add(lb)
            r += 1
        Next
        Controls.Add(pnlOut)
    End Sub

    Private Function MkInLabel(pin As Integer, row As Integer) As Label
        Return MkIoRowLabel("ledIn" & pin.ToString("00"),
                            "IN:" & pin.ToString("00") & "  " & IoMap.InputNames(pin),
                            InLabelWidth, row, Cursors.Default)
    End Function

    Private Function MkOutLabel(pin As Integer, row As Integer) As Label
        Return MkIoRowLabel("ledOut" & pin.ToString("00"),
                            "OUT:" & pin.ToString("00") & "  " & IoMap.OutputNames(pin),
                            OutLabelWidth, row, Cursors.Hand)
    End Function

    ''' <summary>IN/OUT 공통 행 레이아웃 — 왼쪽 정렬, 10pt, 28px (운전 스위치 포함)</summary>
    Private Function MkIoRowLabel(controlName As String, text As String, width As Integer,
                                  row As Integer, cursor As Cursor) As Label
        Return New Label With {
            .Name = controlName,
            .Text = text,
            .AutoSize = False,
            .Size = New Size(width, IoRowHeight),
            .Location = New Point(4, 34 + row * IoRowPitch),
            .BorderStyle = BorderStyle.FixedSingle,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Font = New Font("맑은 고딕", 10.0!),
            .BackColor = LedOff,
            .ForeColor = Color.White,
            .Cursor = cursor
        }
    End Function

    Private Sub SyncInputs()
        If _io Is Nothing Then Return
        Try
            Dim bits As BitArray = _io.GetInputBits()
            For pin As Integer = 0 To _inLabels.Length - 1
                If _inLabels(pin) Is Nothing OrElse pin >= bits.Length Then Continue For
                SetInLed(pin, bits(pin))
            Next
        Catch
        End Try
    End Sub

    Private Sub OnInputChanged(channel As Integer, value As Boolean)
        Dim pin As Integer = channel - 1
        Try
            If pin >= 0 AndAlso pin <= _inLabels.Length - 1 AndAlso _inLabels(pin) IsNot Nothing Then
                SetInLed(pin, value)
            End If
        Catch
        End Try
    End Sub

    ''' <summary>IN 표시 — OFF=회색, ON=녹색</summary>
    Private Sub SetInLed(pin As Integer, value As Boolean)
        If _inLabels(pin) Is Nothing Then Return
        _inLabels(pin).BackColor = If(value, LedInOn, LedOff)
        _inLabels(pin).ForeColor = If(value, Color.Black, Color.White)
    End Sub

    Private Sub OutClick(sender As Object, e As EventArgs)
        Dim lb As Label = TryCast(sender, Label)
        If lb Is Nothing OrElse lb.Tag Is Nothing Then Return
        Dim pin As Integer = CInt(lb.Tag)
        Dim newState As Boolean = (lb.BackColor <> LedOutOn)
        Try
            If _io IsNot Nothing Then IoMap.SetOut(_io, pin, newState)
        Catch
        End Try
        lb.BackColor = If(newState, LedOutOn, LedOff)
        lb.ForeColor = If(newState, Color.White, Color.White)
    End Sub

    Private Sub Header(pnl As Panel, text As String)
        pnl.Controls.Add(New Label With {
            .Text = text, .AutoSize = False, .Size = New Size(pnl.Width - 4, 28),
            .Location = New Point(1, 1), .TextAlign = ContentAlignment.MiddleCenter,
            .BackColor = Color.Navy, .ForeColor = Color.White,
            .Font = New Font("맑은 고딕", 11.0!, FontStyle.Bold)
        })
    End Sub

End Class
