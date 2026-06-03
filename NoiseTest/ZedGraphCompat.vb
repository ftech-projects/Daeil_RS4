'------------------------------------------------------------------------------
' ZedGraphCompat.vb
' NI ScatterGraph API와 ZedGraph 사이의 호환 wrapper.
' 기존 RS4 NoiseTest 코드에서 사용하는 .ClearData(), .PlotXYAppend(),
' .Plots(N).PlotXYAppend(), .Cursors.Item(N).XPosition/YPosition 패턴을
' ZedGraphControl 확장 메서드로 흉내내기 위한 모듈.
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System.Runtime.CompilerServices
Imports System.Drawing
Imports ZedGraph

Module ZedGraphCompat

    ''' <summary>
    ''' 모든 시리즈의 점 데이터를 비운다. NI ScatterGraph.ClearData() 대체.
    ''' </summary>
    <Extension>
    Public Sub ClearData(zg As ZedGraphControl)
        If zg Is Nothing Then Return
        Dim pane As GraphPane = zg.GraphPane
        For Each curve As CurveItem In pane.CurveList
            Dim pts = TryCast(curve.Points, IPointListEdit)
            If pts IsNot Nothing Then pts.Clear()
        Next
        ' X축 초기화
        pane.XAxis.Scale.Min = 0
        pane.XAxis.Scale.Max = 10
        zg.AxisChange()
        zg.Invalidate()
    End Sub

    ''' <summary>
    ''' 시리즈 0에 단일 점 추가. NI ScatterGraph.PlotXYAppend(x, y) 대체.
    ''' </summary>
    <Extension>
    Public Sub PlotXYAppend(zg As ZedGraphControl, xValue As Double, yValue As Double)
        ClassZedGraph.DrawGraph(zg, 0, xValue, yValue)
    End Sub

    ''' <summary>
    ''' N번째 시리즈 프록시 반환. NI ScatterGraph.Plots(N) 대체.
    ''' .Plots(N).PlotXYAppend(x, y) 패턴 지원.
    ''' </summary>
    <Extension>
    Public Function Plots(zg As ZedGraphControl, index As Integer) As ZedGraphPlotProxy
        Return New ZedGraphPlotProxy(zg, index)
    End Function

    ''' <summary>
    ''' Cursors 프록시 반환. NI ScatterGraph.Cursors 대체.
    ''' .Cursors.Item(N).XPosition / YPosition 패턴 지원 (현재는 no-op로 처리).
    ''' </summary>
    <Extension>
    Public Function Cursors(zg As ZedGraphControl) As ZedGraphCursorsProxy
        Return New ZedGraphCursorsProxy(zg)
    End Function

End Module

''' <summary>
''' NI ScatterPlot 프록시. .Plots(N).PlotXYAppend(x, y) 호출 지원.
''' </summary>
Public Class ZedGraphPlotProxy
    Private ReadOnly _zg As ZedGraphControl
    Private ReadOnly _index As Integer

    Public Sub New(zg As ZedGraphControl, index As Integer)
        _zg = zg
        _index = index
    End Sub

    Public Sub PlotXYAppend(xValue As Double, yValue As Double)
        ClassZedGraph.DrawGraph(_zg, _index, xValue, yValue)
    End Sub
End Class

''' <summary>
''' NI XYCursor 컬렉션 프록시. .Cursors.Item(N) 패턴 지원.
''' </summary>
Public Class ZedGraphCursorsProxy
    Private ReadOnly _zg As ZedGraphControl

    Public Sub New(zg As ZedGraphControl)
        _zg = zg
    End Sub

    Public Function Item(index As Integer) As ZedGraphCursorProxy
        Return New ZedGraphCursorProxy(_zg, index)
    End Function

    Default Public ReadOnly Property Items(index As Integer) As ZedGraphCursorProxy
        Get
            Return New ZedGraphCursorProxy(_zg, index)
        End Get
    End Property
End Class

''' <summary>
''' NI XYCursor 개별 프록시. XPosition / YPosition 설정 시
''' ZedGraph 가이드라인으로 표시.
''' index 0/1 → X축 마커, 2/3 → Y축 마커 (NI 패턴 따름).
''' </summary>
Public Class ZedGraphCursorProxy
    Private ReadOnly _zg As ZedGraphControl
    Private ReadOnly _index As Integer

    Public Sub New(zg As ZedGraphControl, index As Integer)
        _zg = zg
        _index = index
    End Sub

    Private _xPosition As Double
    Public Property XPosition As Double
        Get
            Return _xPosition
        End Get
        Set(value As Double)
            _xPosition = value
            ' index 0/1 → 수직 가이드라인 (시간축 마커)
            UpdateGuide(isVertical:=True, pos:=value)
        End Set
    End Property

    Private _yPosition As Double
    Public Property YPosition As Double
        Get
            Return _yPosition
        End Get
        Set(value As Double)
            _yPosition = value
            ' index 2/3 → 수평 가이드라인 (Y 임계값)
            UpdateGuide(isVertical:=False, pos:=value)
        End Set
    End Property

    Private Sub UpdateGuide(isVertical As Boolean, pos As Double)
        If _zg Is Nothing Then Return
        Try
            Dim pane = _zg.GraphPane
            Dim tag As String = "CURSOR_" & _index.ToString()
            ' 기존 가이드 제거
            For i As Integer = pane.GraphObjList.Count - 1 To 0 Step -1
                Dim go = pane.GraphObjList(i)
                If go.Tag IsNot Nothing AndAlso go.Tag.ToString() = tag Then
                    pane.GraphObjList.RemoveAt(i)
                End If
            Next
            Dim col As Color = If(isVertical, Color.SeaGreen, Color.Firebrick)
            Dim lo As LineObj
            If isVertical Then
                lo = New LineObj(col, pos, pane.YAxis.Scale.Min, pos, pane.YAxis.Scale.Max)
            Else
                lo = New LineObj(col, pane.XAxis.Scale.Min, pos, pane.XAxis.Scale.Max, pos)
            End If
            lo.Line.Width = 1.0F
            lo.Line.Style = Drawing.Drawing2D.DashStyle.Dash
            lo.Tag = tag
            pane.GraphObjList.Add(lo)
            _zg.Invalidate()
        Catch
            ' 가이드 갱신 실패는 무시 (UI 핵심 아님)
        End Try
    End Sub
End Class
