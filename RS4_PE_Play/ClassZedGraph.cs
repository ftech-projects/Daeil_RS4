using System.Drawing;
using System.Drawing.Drawing2D;
using ZedGraph;

public static class ClassZedGraph
{
    private const string Series0Tag = "SERIES_0";
    private const string Series1Tag = "SERIES_1";
    // 라인 시리즈 태그
    private const string Line0Tag = "LINE_0";
    private const string Line1Tag = "LINE_1";
    private const string Line2Tag = "LINE_2"; // 복귀용 파랑

    public static void InitGraph_Diff(
        ZedGraphControl zg,
        string title,
        string yTitle,
        double yMin,
        double yMax,
        double rollingWindowSec = 60,    // 호환용
        int pointsCapacity = 3000,
        bool clearAll = true,
        Color? curveColor = null,        // 미사용
        float lineWidth = 3.0f
    )
    {
        var pane = zg.GraphPane;

        Color bgOuter = Color.White;
        Color bgChart = Color.FromArgb(250, 250, 250);
        Color fg = Color.FromArgb(33, 33, 33);
        Color gridColor = Color.FromArgb(210, 210, 210);

        zg.IsAntiAlias = true;

        if (clearAll)
        {
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();
            zg.ZoomOutAll(pane);
        }

        // 제목/축
        pane.Title.Text = title;
        pane.Title.IsVisible = !string.IsNullOrEmpty(title);
        pane.Title.FontSpec.Size = 28;
        pane.Title.FontSpec.FontColor = fg;

        pane.XAxis.Title.Text = "mm";
        pane.YAxis.Title.Text = yTitle;

        // X축(mm)
        pane.XAxis.Type = AxisType.Linear;
        pane.IsBoundedRanges = true;
        pane.XAxis.Scale.MinAuto = false;
        pane.XAxis.Scale.MaxAuto = false;
        pane.XAxis.Scale.Min = -0.8; // X축 범위
        pane.XAxis.Scale.Max = 0.8;
        // pane.XAxis.Scale.Min = -0.1; // 범위 축소
        // pane.XAxis.Scale.Max = 0.1; // 범위 축소
        // pane.XAxis.Scale.Min = -0.5; // 범위 조정
        // pane.XAxis.Scale.Max = 0.5; // 범위 조정
        // pane.XAxis.Scale.MajorStep = 0.1; // 원본
        // pane.XAxis.Scale.MinorStep = 0.05; // 원본
        // pane.XAxis.Scale.MajorStep = 0.5; // 0.5 단위 그리드
        // pane.XAxis.Scale.MinorStep = 0.1; // 0.1 단위 보조 그리드
        pane.XAxis.Scale.MajorStep = 0.05; // 0.05 단위 그리드
        pane.XAxis.Scale.MinorStep = 0.01; // 0.01 단위 보조 그리드

        // Y축
        pane.YAxis.Scale.MinAuto = false;
        pane.YAxis.Scale.MaxAuto = false;
        pane.YAxis.Scale.Min = yMin;
        pane.YAxis.Scale.Max = yMax;

        // 스타일
        pane.Fill = new Fill(bgOuter);
        pane.Chart.Fill = new Fill(bgChart);
        pane.XAxis.Scale.FontSpec.Size = 18f;
        pane.YAxis.Scale.FontSpec.Size = 18f;
        pane.XAxis.Title.FontSpec.Size = 20f;
        pane.YAxis.Title.FontSpec.Size = 20f;
        pane.XAxis.Scale.FontSpec.FontColor = fg;
        pane.YAxis.Scale.FontSpec.FontColor = fg;
        pane.XAxis.Title.FontSpec.FontColor = fg;
        pane.YAxis.Title.FontSpec.FontColor = fg;
        pane.XAxis.Color = fg;
        pane.YAxis.Color = fg;
        pane.Border.IsVisible = true;
        pane.Border.Color = Color.FromArgb(189, 189, 189);
        pane.Legend.IsVisible = true;
        pane.Legend.Position = LegendPos.InsideTopLeft;
        pane.Legend.FontSpec.Size = 20f;
        pane.Legend.FontSpec.IsBold = true;
        pane.Legend.Border.IsVisible = false;
        pane.Legend.Fill.IsVisible = false;

        // 그리드
        pane.XAxis.MajorGrid.IsVisible = true;
        pane.XAxis.MajorGrid.Color = gridColor;
        pane.XAxis.MajorGrid.DashOn = 2f;
        pane.XAxis.MajorGrid.DashOff = 2f;
        pane.XAxis.MajorGrid.PenWidth = 1f;

        pane.YAxis.MajorGrid.IsVisible = true;
        pane.YAxis.MajorGrid.Color = gridColor;
        pane.YAxis.MajorGrid.DashOn = 2f;
        pane.YAxis.MajorGrid.DashOff = 2f;
        pane.YAxis.MajorGrid.PenWidth = 1f;

        // ── 점 전용 시리즈
        EnsureDotSeries(pane, Series0Tag, "BW", Color.Blue, pointsCapacity);
        EnsureDotSeries(pane, Series1Tag, "FW", Color.FromArgb(255, 140, 0), pointsCapacity);

        // ── 라인 전용 시리즈
        EnsureLineSeries(pane, Line0Tag, "BW", Color.Blue, lineWidth, pointsCapacity, true);
        EnsureLineSeries(pane, Line1Tag, "FW", Color.FromArgb(255, 140, 0), lineWidth, pointsCapacity, true);
        EnsureLineSeries(pane, Line2Tag, "BW-R", Color.Blue, lineWidth, pointsCapacity, false); // 복귀용 파랑 (범례 숨김)

        var vLine = new ZedGraph.LineObj(Color.Black, 0, yMin, 0, yMax);
        vLine.IsClippedToChartRect = true;    // 차트 영역 안에서만 보이게
        vLine.Line.Width = 2.0f;              // 두께
        vLine.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;

        pane.GraphObjList.Add(vLine);

        zg.AxisChange();
        zg.Invalidate();
    }

    private static void EnsureDotSeries(GraphPane pane, string tag, string label, Color color, int capacity)
    {
        int i;
        for (i = 0; i < pane.CurveList.Count; i++)
        {
            var li = pane.CurveList[i] as LineItem;
            if (li != null && li.Tag is string && (string)li.Tag == tag) return;
        }

        var list = new RollingPointPairList(capacity);
        var curve = pane.AddCurve(label, list, color, SymbolType.Circle) as LineItem;
        if (curve != null)
        {
            curve.Tag = tag;
            curve.Line.IsVisible = false;    // 점만
            curve.Line.IsSmooth = false;
            curve.Symbol.Size = 6;
            curve.Symbol.Fill = new Fill(color);
            curve.Symbol.Border.IsVisible = false;
            curve.Label.IsVisible = false;   // 범례에서 숨김 (라인 시리즈에서 표시)
        }
    }

    private static void EnsureLineSeries(GraphPane pane, string tag, string label, Color color, float lineWidth, int capacity, bool showInLegend = true)
    {
        int i;
        for (i = 0; i < pane.CurveList.Count; i++)
        {
            var li = pane.CurveList[i] as LineItem;
            if (li != null && li.Tag is string && (string)li.Tag == tag) return;
        }

        var list = new RollingPointPairList(capacity);
        var curve = pane.AddCurve(label, list, color, SymbolType.None) as LineItem;
        if (curve != null)
        {
            curve.Tag = tag;
            curve.Line.IsVisible = true;     // 선만
            curve.Line.IsSmooth = false;     // 단조 아닌 x 들어오면 절대 켜지 마라
            curve.Line.Width = lineWidth;
            curve.Label.IsVisible = showInLegend; // 범례 표시 여부
        }
    }

    // seriesIndex: 0=검정 점, 1=빨강 점
    public static void DrawDot(ZedGraphControl zg, double xValue, double yValue, int seriesIndex)
    {
        if (zg == null) return;
        var pane = zg.GraphPane;

        string wantTag = seriesIndex == 1 ? Series1Tag : Series0Tag;
        LineItem curve = FindByTag(pane, wantTag);
        if (curve == null) return;

        var pts = curve.Points as IPointListEdit;
        if (pts == null) return;

        pts.Add(xValue, yValue);
        zg.AxisChange();
        zg.Invalidate();
    }

    // seriesIndex: 0=검정 선, 1=빨강 선, 2=파랑 선(복귀)
    public static void DrawGraphLine(ZedGraphControl zg, double xValue, double yValue, int seriesIndex)
    {
        if (zg == null) return;
        var pane = zg.GraphPane;

        string wantTag;
        if (seriesIndex == 2) wantTag = Line2Tag;      // 파랑 (복귀)
        else if (seriesIndex == 1) wantTag = Line1Tag; // 빨강
        else wantTag = Line0Tag;                        // 검정
        LineItem curve = FindByTag(pane, wantTag);
        if (curve == null) return;

        var pts = curve.Points as IPointListEdit;
        if (pts == null) return;

        // 주의: 선 시리즈는 x 단조 증가가 아니면 보간 꼬여서 터질 수 있다.
        // 단조가 보장 안 되면 이 함수 대신 DrawDot을 써라.
        pts.Add(xValue, yValue);
        zg.AxisChange();
        zg.Invalidate();
    }

    private static LineItem FindByTag(GraphPane pane, string tag)
    {
        int i;
        for (i = 0; i < pane.CurveList.Count; i++)
        {
            var li = pane.CurveList[i] as LineItem;
            if (li != null && li.Tag is string && (string)li.Tag == tag) return li;
        }
        return null;
    }
    public static void InitGraph(
        ZedGraphControl zg,
        string title,
        string yTitle,
        double yMin,
        double yMax,
        double rollingWindowSec = 60,
        int pointsCapacity = 3000,
        bool clearAll = true,
        Color? curveColor = null,
        float lineWidth = 3.0f   // ← 곡선 굵기 추가
        )
    {
        // ── 라이트 테마 색상
        Color bgOuter = Color.White;
        Color bgChart = Color.FromArgb(250, 250, 250);
        Color fg = Color.FromArgb(33, 33, 33);
        Color gridColor = Color.FromArgb(210, 210, 210);
        Color lineColor = curveColor ?? Color.FromArgb(25, 118, 210);
        Color peakColor = Color.FromArgb(255, 160, 0);

        GraphPane pane = zg.GraphPane;
        zg.IsAntiAlias = true;

        if (clearAll)
        {
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();
            zg.ZoomOutAll(pane);
        }

        pane.Title.Text = title;
        pane.Title.IsVisible = !string.IsNullOrEmpty(title);
        pane.Title.FontSpec.Size = 36;
        pane.Title.FontSpec.FontColor = fg;

        pane.XAxis.Title.Text = "Elapsed Time (s)";
        pane.YAxis.Title.Text = yTitle;

        pane.XAxis.Type = AxisType.Linear;
        pane.XAxis.Scale.Min = 0;
        pane.XAxis.Scale.Max = rollingWindowSec;
        pane.XAxis.Scale.MajorStep = 2;
        pane.XAxis.Scale.MinorStep = 1;

        pane.YAxis.Scale.Min = yMin;
        pane.YAxis.Scale.Max = yMax;

        pane.Fill = new Fill(bgOuter);
        pane.Chart.Fill = new Fill(bgChart);

        pane.XAxis.Scale.FontSpec.Size = 22f;
        pane.YAxis.Scale.FontSpec.Size = 22f;
        pane.XAxis.Title.FontSpec.Size = 24f;
        pane.YAxis.Title.FontSpec.Size = 24f;

        pane.XAxis.Scale.FontSpec.FontColor = fg;
        pane.YAxis.Scale.FontSpec.FontColor = fg;
        pane.XAxis.Title.FontSpec.FontColor = fg;
        pane.YAxis.Title.FontSpec.FontColor = fg;

        pane.XAxis.Color = fg;
        pane.YAxis.Color = fg;
        pane.Border.IsVisible = true;
        pane.Border.Color = Color.FromArgb(189, 189, 189);

        pane.Legend.IsVisible = false;

        var rolling = new RollingPointPairList(pointsCapacity);
        var curve = pane.AddCurve(
            string.IsNullOrEmpty(title) ? "Series" : title,
            rolling,
            lineColor,
            SymbolType.None
        );

        curve.Line.Width = lineWidth; // ← 사용자 지정 굵기 적용
        curve.Line.IsSmooth = true;
        curve.Line.SmoothTension = 0.1f;

        var peakLine = new LineObj(peakColor, 0, 0, 0, 0)
        {
            IsVisible = false,
            Tag = "PEAK_LINE"
        };
        pane.GraphObjList.Add(peakLine);

        var peakText = new TextObj("", 0, 0, CoordType.AxisXYScale, AlignH.Center, AlignV.Top)
        {
            IsVisible = false,
            Tag = "PEAK_TEXT",
            FontSpec = new FontSpec("Arial Narrow", 18f, peakColor, false, false, false)
            {
                Border = { IsVisible = false },
                Fill = new Fill(Color.Transparent)
            }
        };
        pane.GraphObjList.Add(peakText);

        // ===== 그리드 =====
        pane.XAxis.MajorGrid.IsVisible = true;
        pane.XAxis.MajorGrid.Color = Color.LightGray;
        pane.XAxis.MajorGrid.DashOn = 2f;   // 점선 길이
        pane.XAxis.MajorGrid.DashOff = 2f;  // 점선 간격
        pane.XAxis.MajorGrid.PenWidth = 1f;

        pane.YAxis.MajorGrid.IsVisible = true;
        pane.YAxis.MajorGrid.Color = Color.LightGray;
        pane.YAxis.MajorGrid.DashOn = 2f;
        pane.YAxis.MajorGrid.DashOff = 2f;
        pane.YAxis.MajorGrid.PenWidth = 1f;

        // 간격 1씩
        pane.XAxis.Scale.MajorStep = 1;
        pane.XAxis.Scale.MinorStep = 1;
        pane.YAxis.Scale.MajorStep = 1;
        pane.YAxis.Scale.MinorStep = 1;

        curve.Line.IsSmooth = false;

        zg.AxisChange();
        zg.Invalidate();
    }

    public static void InitGraph_Diff_Dot(
        ZedGraph.ZedGraphControl zg,
        string title,
        string yTitle,
        double yMin,
        double yMax,
        double rollingWindowSec = 60,      // ← 무시됨(호환용)
        int pointsCapacity = 3000,
        bool clearAll = true,
        Color? curveColor = null,
        float lineWidth = 3.0f
)
    {
        var pane = zg.GraphPane;

        // 색
        Color bgOuter = Color.White;
        Color bgChart = Color.FromArgb(250, 250, 250);
        Color fg = Color.FromArgb(33, 33, 33);
        Color gridColor = Color.FromArgb(210, 210, 210);
        Color lineColor = curveColor ?? Color.FromArgb(25, 118, 210);
        Color peakColor = Color.FromArgb(255, 160, 0);

        zg.IsAntiAlias = true;

        if (clearAll)
        {
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();
            zg.ZoomOutAll(pane);
        }

        // 제목/축 라벨
        pane.Title.Text = title;
        pane.Title.IsVisible = !string.IsNullOrEmpty(title);
        pane.Title.FontSpec.Size = 28;
        pane.Title.FontSpec.FontColor = fg;

        pane.XAxis.Title.Text = "mm";
        pane.YAxis.Title.Text = yTitle;

        // ===== 핵심: X축을 Nm 고정 범위로 묶기 =====
        pane.XAxis.Type = AxisType.Linear;
        pane.IsBoundedRanges = true;                 // 자동 스케일 금지
        pane.XAxis.Scale.MinAuto = false;
        pane.XAxis.Scale.MaxAuto = false;
        pane.XAxis.Scale.Min = -0.8; // X축 범위
        pane.XAxis.Scale.Max = 0.8;
        // pane.XAxis.Scale.Min = -0.1; // 범위 축소
        // pane.XAxis.Scale.Max = 0.1; // 범위 축소
        // pane.XAxis.Scale.Min = -0.5; // 범위 조정
        // pane.XAxis.Scale.Max = 0.5; // 범위 조정
        // pane.XAxis.Scale.MajorStep = 0.1; // 원본
        // pane.XAxis.Scale.MinorStep = 0.05; // 원본
        // pane.XAxis.Scale.MajorStep = 0.5; // 0.5 단위 그리드
        // pane.XAxis.Scale.MinorStep = 0.1; // 0.1 단위 보조 그리드
        pane.XAxis.Scale.MajorStep = 0.05; // 0.05 단위 그리드
        pane.XAxis.Scale.MinorStep = 0.01; // 0.01 단위 보조 그리드

        // Y축
        pane.YAxis.Scale.MinAuto = false;
        pane.YAxis.Scale.MaxAuto = false;
        pane.YAxis.Scale.Min = yMin;
        pane.YAxis.Scale.Max = yMax;

        // 테마/폰트
        pane.Fill = new Fill(bgOuter);
        pane.Chart.Fill = new Fill(bgChart);
        pane.XAxis.Scale.FontSpec.Size = 18f;
        pane.YAxis.Scale.FontSpec.Size = 18f;
        pane.XAxis.Title.FontSpec.Size = 20f;
        pane.YAxis.Title.FontSpec.Size = 20f;
        pane.XAxis.Scale.FontSpec.FontColor = fg;
        pane.YAxis.Scale.FontSpec.FontColor = fg;
        pane.XAxis.Title.FontSpec.FontColor = fg;
        pane.YAxis.Title.FontSpec.FontColor = fg;
        pane.XAxis.Color = fg;
        pane.YAxis.Color = fg;
        pane.Border.IsVisible = true;
        pane.Border.Color = Color.FromArgb(189, 189, 189);
        pane.Legend.IsVisible = false;

        // 곡선
        var rolling = new RollingPointPairList(pointsCapacity);
        var curve = pane.AddCurve(
            string.IsNullOrEmpty(title) ? "Series" : title,
            rolling,
            lineColor,
            SymbolType.None
        );

        curve.Line.Width = lineWidth;
        curve.Line.IsSmooth = false;                // ===== 핵심: 스무딩 OFF =====

        // 피크 표시 오브젝트(옵션)
        var peakLine = new LineObj(peakColor, 0, 0, 0, 0) { IsVisible = false, Tag = "PEAKg_LINE" };
        pane.GraphObjList.Add(peakLine);

        var peakText = new TextObj("", 0, 0, CoordType.AxisXYScale, AlignH.Center, AlignV.Top)
        {
            IsVisible = false,
            Tag = "PEAK_TEXT",
            FontSpec = new FontSpec("Arial Narrow", 16f, peakColor, false, false, false) { Border = { IsVisible = false }, Fill = new Fill(Color.Transparent) }
        };
        pane.GraphObjList.Add(peakText);

        // 그리드
        pane.XAxis.MajorGrid.IsVisible = true;
        pane.XAxis.MajorGrid.Color = gridColor;
        pane.XAxis.MajorGrid.DashOn = 2f;
        pane.XAxis.MajorGrid.DashOff = 2f;
        pane.XAxis.MajorGrid.PenWidth = 1f;

        pane.YAxis.MajorGrid.IsVisible = true;
        pane.YAxis.MajorGrid.Color = gridColor;
        pane.YAxis.MajorGrid.DashOn = 2f;
        pane.YAxis.MajorGrid.DashOff = 2f;
        pane.YAxis.MajorGrid.PenWidth = 1f;

        zg.AxisChange();
        zg.Invalidate();
    }

    public static void DrawGraph(ZedGraphControl zg, double yValue, double xValue)
    {
        if (zg == null) return;

        var pane = zg.GraphPane;
        if (pane.CurveList.Count == 0) return;

        var curve = pane.CurveList[0];
        var pts = curve.Points as IPointListEdit;
        if (pts == null) return;

        // 데이터 추가
        pts.Add(xValue, yValue);

        // X축 롤링 (최근 범위 표시)
        pane.XAxis.Scale.Min = 0;
        pane.XAxis.Scale.Max = xValue;

        zg.AxisChange();
        zg.Invalidate();
    }
    public static void DrawDot(ZedGraphControl zg, double xValue, double yValue)
    {
        if (zg == null) return;

        var pane = zg.GraphPane;
        if (pane.CurveList.Count == 0) return;

        // CurveItem → LineItem 캐스팅
        var curve = pane.CurveList[0] as LineItem;
        if (curve == null) return;

        // 점만 찍히게 설정
        curve.Line.IsVisible = false;
        curve.Symbol.Type = SymbolType.Circle;
        curve.Symbol.Size = 6;
        curve.Symbol.Fill = new Fill(curve.Color);
        curve.Symbol.Border.IsVisible = false;

        // 데이터 추가
        var pts = curve.Points as IPointListEdit;
        if (pts != null)
            pts.Add(xValue, yValue);

        zg.AxisChange();
        zg.Invalidate();
    }
    public static void DrawDirectLine(
    ZedGraph.ZedGraphControl zgc,
    double x1, double y1,
    double x2, double y2,
    int group,
    float lineWidth = 1.5f)
    {
        Color lineColor;

        switch (group)
        {
            case 0: lineColor = Color.Black; break;
            case 1: lineColor = Color.Red; break;
            default: lineColor = Color.Gray; break;
        }

        var pane = zgc.GraphPane;

        var list = new ZedGraph.PointPairList();
        list.Add(x1, y1);
        list.Add(x2, y2);

        var curve = pane.AddCurve(string.Empty, list, lineColor, ZedGraph.SymbolType.None);
        curve.Line.Width = lineWidth;

        zgc.AxisChange();
        zgc.Invalidate();
    }
    public static void AddGuideLines(
        ZedGraphControl zg,
        double[] yLines = null,
        double[] xLines = null,
        Color? yColor = null,
        Color? xColor = null,
        float lineWidth = 1.5f,
        DashStyle lineStyle = DashStyle.Dash)
    {
        if (zg == null) return;
        var pane = zg.GraphPane;

        // 1) 기존 기준선 제거 (Tag = "GUIDE_LINE")
        for (int i = pane.GraphObjList.Count - 1; i >= 0; i--)
        {
            var go = pane.GraphObjList[i];
            if (go.Tag != null && go.Tag.ToString() == "GUIDE_LINE")
                pane.GraphObjList.RemoveAt(i);
        }

        // 기본 색상
        Color yCol = yColor ?? Color.Firebrick;
        Color xCol = xColor ?? Color.SeaGreen;

        // 현재 축 범위
        double xMin = pane.XAxis.Scale.Min;
        double xMax = pane.XAxis.Scale.Max;
        double yMin = pane.YAxis.Scale.Min;
        double yMax = pane.YAxis.Scale.Max;

        // 2) Y 기준선(수평)
        if (yLines != null)
        {
            foreach (double y in yLines)
            {
                var yLine = new LineObj(yCol, xMin, y, xMax, y);
                yLine.Line.Width = lineWidth;
                yLine.Line.Style = lineStyle;
                yLine.Tag = "GUIDE_LINE";
                pane.GraphObjList.Add(yLine);
            }
        }

        // 3) X 기준선(수직)
        if (xLines != null)
        {
            foreach (double x in xLines)
            {
                var xLine = new LineObj(xCol, x, yMin, x, yMax);
                xLine.Line.Width = lineWidth;
                xLine.Line.Style = lineStyle;
                xLine.Tag = "GUIDE_LINE";
                pane.GraphObjList.Add(xLine);
            }
        }

        zg.AxisChange();
        zg.Invalidate();
    }

    /// <summary>
    /// 녹색 합격 영역(사각형) 추가
    /// </summary>
    /// <param name="xSpec">X축 합격 범위 (±mm, 예: 0.75이면 -0.75~+0.75)</param>
    /// <param name="yLimitFwd">Y축 전진(CW) 토크 리미트 (양수, 예: 22.5)</param>
    /// <param name="yLimitBwd">Y축 후진(CCW) 토크 리미트 (양수, 예: 22.5)</param>
    public static void AddPassZone(ZedGraphControl zg, double xSpec, double yLimitFwd, double yLimitBwd)
    {
        if (zg == null) return;
        var pane = zg.GraphPane;

        // 기존 합격 영역 제거
        for (int i = pane.GraphObjList.Count - 1; i >= 0; i--)
        {
            if (pane.GraphObjList[i].Tag != null && pane.GraphObjList[i].Tag.ToString() == "PASS_ZONE")
                pane.GraphObjList.RemoveAt(i);
        }

        // BoxObj: (left, top, width, height)
        double left = -xSpec;
        double top = yLimitFwd;
        double width = xSpec * 2;
        double height = yLimitFwd + yLimitBwd;

        var box = new BoxObj(left, top, width, height,
            Color.FromArgb(80, 0, 180, 0),     // 테두리: 반투명 녹색
            Color.FromArgb(40, 0, 200, 0));     // 채움: 반투명 녹색
        box.Location.CoordinateFrame = CoordType.AxisXYScale;
        box.ZOrder = ZOrder.E_BehindCurves;     // 곡선 뒤에 표시
        box.Border.Width = 1.5f;
        box.Tag = "PASS_ZONE";

        pane.GraphObjList.Add(box);

        zg.AxisChange();
        zg.Invalidate();
    }

}


