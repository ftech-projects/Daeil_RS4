Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports ZedGraph

Public Class ClassZedGraph
    Private Sub New()
    End Sub

    Public Shared Sub InitGraph(
        zg As ZedGraphControl,
        title As String,
        yTitle As String,
        yMin As Double,
        yMax As Double,
        Optional rollingWindowSec As Double = 60,
        Optional pointsCapacity As Integer = 3000,
        Optional clearAll As Boolean = True,
        Optional curveColor As Nullable(Of Color) = Nothing,
        Optional lineWidth As Single = 1.5F
    )
        ' ── 라이트 테마 색상 (기존 유지)
        Dim bgOuter As Color = Color.FromArgb(15, 19, 32)      ' #0F1320
        Dim bgChart As Color = Color.FromArgb(15, 19, 32)      ' #0F1320
        Dim fg As Color = Color.FromArgb(207, 216, 220)        ' #CFD8DC
        Dim gridColor As Color = Color.FromArgb(126, 143, 161) ' #7E8FA1
        'Dim lineColor As Color = If(curveColor.HasValue, curveColor.Value, Color.FromArgb(25, 118, 210)) ' 1번 라인

        Dim lineColor As Color = Color.LightBlue

        Dim peakColor As Color = Color.FromArgb(255, 213, 79)  ' #FFD54F

        Dim pane As GraphPane = zg.GraphPane
        zg.IsAntiAlias = True

        If clearAll Then
            pane.CurveList.Clear()
            pane.GraphObjList.Clear()
            zg.ZoomOutAll(pane)
        End If

        pane.Title.Text = title
        pane.Title.IsVisible = Not String.IsNullOrEmpty(title)
        pane.Title.FontSpec.Size = 24.0F
        pane.Title.FontSpec.FontColor = fg
        pane.Title.FontSpec.Family = "Arial Narrow"

        pane.XAxis.Title.Text = "Elapsed Time (s)"
        pane.YAxis.Title.Text = yTitle

        pane.XAxis.Type = AxisType.Linear
        pane.XAxis.Scale.Min = 0
        pane.XAxis.Scale.Max = rollingWindowSec
        pane.XAxis.Scale.MajorStep = 2
        pane.XAxis.Scale.MinorStep = 1

        pane.YAxis.Scale.Min = yMin
        pane.YAxis.Scale.Max = yMax

        pane.Fill = New Fill(bgOuter)
        pane.Chart.Fill = New Fill(bgChart)

        pane.XAxis.Scale.FontSpec.Size = 22.0F
        pane.YAxis.Scale.FontSpec.Size = 22.0F
        pane.XAxis.Title.FontSpec.Size = 24.0F
        pane.YAxis.Title.FontSpec.Size = 24.0F

        pane.XAxis.Scale.FontSpec.FontColor = fg
        pane.YAxis.Scale.FontSpec.FontColor = fg
        pane.XAxis.Title.FontSpec.FontColor = fg
        pane.YAxis.Title.FontSpec.FontColor = fg

        pane.XAxis.Color = fg
        pane.YAxis.Color = fg
        pane.Border.IsVisible = True
        pane.Border.Color = Color.FromArgb(189, 189, 189)

        pane.Legend.IsVisible = False

        ' ----- 라인 1 (기존 색) -----
        Dim rolling1 As New RollingPointPairList(pointsCapacity)
        Dim c1 = pane.AddCurve(If(String.IsNullOrEmpty(title), "Series1", title), rolling1, lineColor, SymbolType.None)
        c1.Line.Width = lineWidth : c1.Line.IsSmooth = False : c1.Line.SmoothTension = 0.1F

        ' ----- 라인 2/3 추가: 배경 대비 강한 컬러 -----
        ' 주황(#FFA000), 연두(#66BB6A)
        If pane.CurveList.Count < 3 Then
            Dim rolling2 As New RollingPointPairList(pointsCapacity)
            Dim rolling3 As New RollingPointPairList(pointsCapacity)

            Dim c2 = pane.AddCurve(If(String.IsNullOrEmpty(title), "Series2", title & "-2"),
                                   rolling2, Color.FromArgb(255, 160, 0), SymbolType.None)
            Dim c3 = pane.AddCurve(If(String.IsNullOrEmpty(title), "Series3", title & "-3"),
                                   rolling3, Color.FromArgb(102, 187, 106), SymbolType.None)

            c2.Line.Width = lineWidth : c2.Line.IsSmooth = False : c2.Line.SmoothTension = 0.1F
            c3.Line.Width = lineWidth : c3.Line.IsSmooth = False : c3.Line.SmoothTension = 0.1F
        End If

        ' 피크 오브젝트 (기존 유지)
        Dim peakLine As New LineObj(peakColor, 0, 0, 0, 0) With {.IsVisible = False, .Tag = "PEAK_LINE"}
        pane.GraphObjList.Add(peakLine)

        Dim peakText As New TextObj("", 0, 0, CoordType.AxisXYScale, AlignH.Center, AlignV.Top) With {
            .IsVisible = False, .Tag = "PEAK_TEXT",
            .FontSpec = New FontSpec("Arial Narrow", 18.0F, peakColor, False, False, False) With {
                .Border = New Border(False, Color.Empty, 0.0F),
                .Fill = New Fill(Color.Transparent)
            }
        }
        pane.GraphObjList.Add(peakText)

        zg.AxisChange()
        zg.Invalidate()
    End Sub

    Public Shared Sub DrawGraph(zg As ZedGraphControl, series As Integer, xValue As Double, yValue As Double)
        If zg Is Nothing Then Return

        Dim pane = zg.GraphPane
        If pane.CurveList.Count = 0 Then Return
        If series < 0 OrElse series >= pane.CurveList.Count Then Return

        Dim curve = TryCast(pane.CurveList(series), LineItem)
        If curve Is Nothing Then Return

        Dim pts = TryCast(curve.Points, IPointListEdit)
        If pts Is Nothing Then Return

        ' 데이터 추가
        pts.Add(xValue, yValue)

        ' X축 롤링 (현재 구현 유지: 0 ~ xValue)
        pane.XAxis.Scale.Min = 0
        pane.XAxis.Scale.Max = xValue

        zg.AxisChange()
        zg.Invalidate()
    End Sub

    'Public Shared Sub InitGraph(
    '    zg As ZedGraphControl,
    '    title As String,
    '    yTitle As String,
    '    yMin As Double,
    '    yMax As Double,
    '    Optional rollingWindowSec As Double = 60,
    '    Optional pointsCapacity As Integer = 3000,
    '    Optional clearAll As Boolean = True,
    '    Optional curveColor As Nullable(Of Color) = Nothing,
    '    Optional lineWidth As Single = 3.0F
    ')
    '    ' ── 라이트 테마 색상
    '    Dim bgOuter As Color = Color.FromArgb(15, 19, 32)      ' #0F1320
    '    Dim bgChart As Color = Color.FromArgb(15, 19, 32)      ' #0F1320
    '    Dim fg As Color = Color.FromArgb(207, 216, 220)        ' #CFD8DC
    '    Dim gridColor As Color = Color.FromArgb(126, 143, 161) ' #7E8FA1
    '    Dim lineColor As Color = If(curveColor.HasValue, curveColor.Value, Color.FromArgb(25, 118, 210))
    '    Dim peakColor As Color = Color.FromArgb(255, 213, 79)  ' #FFD54F

    '    Dim pane As GraphPane = zg.GraphPane
    '    zg.IsAntiAlias = True

    '    If clearAll Then
    '        pane.CurveList.Clear()
    '        pane.GraphObjList.Clear()
    '        zg.ZoomOutAll(pane)
    '    End If

    '    pane.Title.Text = title
    '    pane.Title.IsVisible = Not String.IsNullOrEmpty(title)
    '    pane.Title.FontSpec.Size = 36.0F
    '    pane.Title.FontSpec.FontColor = fg

    '    pane.XAxis.Title.Text = "Elapsed Time (s)"
    '    pane.YAxis.Title.Text = yTitle

    '    pane.XAxis.Type = AxisType.Linear
    '    pane.XAxis.Scale.Min = 0
    '    pane.XAxis.Scale.Max = rollingWindowSec
    '    pane.XAxis.Scale.MajorStep = 2
    '    pane.XAxis.Scale.MinorStep = 1

    '    pane.YAxis.Scale.Min = yMin
    '    pane.YAxis.Scale.Max = yMax

    '    pane.Fill = New Fill(bgOuter)
    '    pane.Chart.Fill = New Fill(bgChart)

    '    pane.XAxis.Scale.FontSpec.Size = 22.0F
    '    pane.YAxis.Scale.FontSpec.Size = 22.0F
    '    pane.XAxis.Title.FontSpec.Size = 24.0F
    '    pane.YAxis.Title.FontSpec.Size = 24.0F

    '    pane.XAxis.Scale.FontSpec.FontColor = fg
    '    pane.YAxis.Scale.FontSpec.FontColor = fg
    '    pane.XAxis.Title.FontSpec.FontColor = fg
    '    pane.YAxis.Title.FontSpec.FontColor = fg

    '    pane.XAxis.Color = fg
    '    pane.YAxis.Color = fg
    '    pane.Border.IsVisible = True
    '    pane.Border.Color = Color.FromArgb(189, 189, 189)

    '    pane.Legend.IsVisible = False

    '    Dim rolling As New RollingPointPairList(pointsCapacity)
    '    Dim curve = pane.AddCurve(If(String.IsNullOrEmpty(title), "Series", title), rolling, lineColor, SymbolType.None)

    '    curve.Line.Width = lineWidth
    '    curve.Line.IsSmooth = True
    '    curve.Line.SmoothTension = 0.1F

    '    Dim peakLine As New LineObj(peakColor, 0, 0, 0, 0) With {
    '        .IsVisible = False,
    '        .Tag = "PEAK_LINE"
    '    }
    '    pane.GraphObjList.Add(peakLine)

    '    Dim peakText As New TextObj("", 0, 0, CoordType.AxisXYScale, AlignH.Center, AlignV.Top) With {
    '        .IsVisible = False,
    '        .Tag = "PEAK_TEXT",
    '        .FontSpec = New FontSpec("Arial Narrow", 18.0F, peakColor, False, False, False) With {
    '            .Border = New Border(False, Color.Empty, 0.0F),
    '            .Fill = New Fill(Color.Transparent)
    '        }
    '    }
    '    pane.GraphObjList.Add(peakText)

    '    zg.AxisChange()
    '    zg.Invalidate()
    'End Sub
    'Public Shared Sub DrawGraph(zg As ZedGraphControl, yValue As Double, xValue As Double)
    '    If zg Is Nothing Then Return

    '    Dim pane = zg.GraphPane
    '    If pane.CurveList.Count = 0 Then Return

    '    Dim curve = pane.CurveList(0)
    '    Dim pts = TryCast(curve.Points, IPointListEdit)
    '    If pts Is Nothing Then Return

    '    ' 데이터 추가
    '    pts.Add(xValue, yValue)

    '    ' X축 롤링 (최근 범위 표시)
    '    pane.XAxis.Scale.Min = 0
    '    pane.XAxis.Scale.Max = xValue

    '    zg.AxisChange()
    '    zg.Invalidate()
    'End Sub
    Public Shared Sub AddGuideLines(
    zg As ZedGraphControl,
    Optional yLines As Double() = Nothing,
    Optional xLines As Double() = Nothing,
    Optional yColor As Nullable(Of Color) = Nothing,
    Optional xColor As Nullable(Of Color) = Nothing,
    Optional lineWidth As Single = 1.0F,
    Optional lineStyle As DashStyle = DashStyle.Dash
)
        If zg Is Nothing Then Return
        Dim pane = zg.GraphPane

        ' 1) 기존 기준선 제거 (Tag = "GUIDE_LINE")
        For i As Integer = pane.GraphObjList.Count - 1 To 0 Step -1
            Dim go = pane.GraphObjList(i)
            If go.Tag IsNot Nothing AndAlso go.Tag.ToString() = "GUIDE_LINE" Then
                pane.GraphObjList.RemoveAt(i)
            End If
        Next

        ' 기본 색상
        Dim yCol As Color = If(yColor.HasValue, yColor.Value, Color.Firebrick)
        Dim xCol As Color = If(xColor.HasValue, xColor.Value, Color.SeaGreen)

        ' 현재 축 범위
        Dim xMin As Double = pane.XAxis.Scale.Min
        Dim xMax As Double = pane.XAxis.Scale.Max
        Dim yMin As Double = pane.YAxis.Scale.Min
        Dim yMax As Double = pane.YAxis.Scale.Max

        ' 2) Y 기준선(수평)
        If yLines IsNot Nothing Then
            Dim y As Double
            For Each y In yLines
                Dim yLine As New LineObj(yCol, xMin, y, xMax, y)
                yLine.Line.Width = lineWidth
                yLine.Line.Style = lineStyle
                yLine.Tag = "GUIDE_LINE"
                pane.GraphObjList.Add(yLine)
            Next
        End If

        ' 3) X 기준선(수직)
        If xLines IsNot Nothing Then
            Dim x As Double
            For Each x In xLines
                Dim xLine As New LineObj(xCol, x, yMin, x, yMax)
                xLine.Line.Width = lineWidth
                xLine.Line.Style = lineStyle
                xLine.Tag = "GUIDE_LINE"
                pane.GraphObjList.Add(xLine)
            Next
        End If

        zg.AxisChange()
        zg.Invalidate()
    End Sub

End Class

