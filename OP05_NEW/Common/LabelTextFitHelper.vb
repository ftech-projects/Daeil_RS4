Imports System.Drawing
Imports System.Windows.Forms

''' <summary>Label 텍스트가 박스(ClientSize) 안에 들어가도록 글자 크기 자동 조정</summary>
Public Module LabelTextFitHelper

    Private Function GetMaxFontPt(lbl As Label) As Single
        If lbl.Tag IsNot Nothing AndAlso TypeOf lbl.Tag Is Single Then
            Return CSng(lbl.Tag)
        End If
        lbl.Tag = lbl.Font.Size
        Return lbl.Font.Size
    End Function

    Public Sub FitLabelToBounds(lbl As Label, Optional minFontPt As Single = 7.0F, Optional allowWordBreak As Boolean = False)
        If lbl Is Nothing OrElse lbl.ClientSize.Width <= 0 OrElse lbl.ClientSize.Height <= 0 Then Return
        Dim text = lbl.Text
        If String.IsNullOrEmpty(text) Then Return

        Dim maxPt = GetMaxFontPt(lbl)
        Dim bestPt = minFontPt
        Dim flags As TextFormatFlags = TextFormatFlags.NoPadding Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter
        If allowWordBreak Then
            flags = flags Or TextFormatFlags.WordBreak
        Else
            flags = flags Or TextFormatFlags.SingleLine
        End If

        Using g As Graphics = lbl.CreateGraphics()
            Dim pt As Single = maxPt
            While pt >= minFontPt
                Using f As New Font(lbl.Font.FontFamily, pt, lbl.Font.Style)
                    Dim sz = TextRenderer.MeasureText(g, text, f, lbl.ClientSize, flags)
                    If sz.Width <= lbl.ClientSize.Width AndAlso sz.Height <= lbl.ClientSize.Height Then
                        bestPt = pt
                        Exit While
                    End If
                End Using
                pt -= 0.5F
            End While
        End Using

        If Math.Abs(lbl.Font.Size - bestPt) > 0.01F Then
            lbl.Font = New Font(lbl.Font.FontFamily, bestPt, lbl.Font.Style)
        End If
    End Sub

    Public Sub FitLabels(ParamArray labels As Label())
        If labels Is Nothing Then Return
        For Each lbl As Label In labels
            If lbl Is Nothing Then Continue For
            Dim wordBreak = (lbl IsNot Nothing AndAlso lbl.Height >= 60)
            FitLabelToBounds(lbl, allowWordBreak:=wordBreak)
        Next
    End Sub

End Module
