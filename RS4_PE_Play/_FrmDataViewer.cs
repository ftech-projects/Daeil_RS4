using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;
using Label = System.Windows.Forms.Label;

public partial class _FrmDataViewer : Form
{
    // ── 색상 팔레트 ────────────────────────────────────────────────
    private static readonly Color BG_DARK  = Color.FromArgb(15, 23, 42);
    private static readonly Color BG_CARD  = Color.FromArgb(22, 32, 48);
    private static readonly Color BG_PANEL = Color.FromArgb(30, 41, 59);
    private static readonly Color C_TEXT   = Color.FromArgb(226, 232, 240);
    private static readonly Color C_MUTED  = Color.FromArgb(100, 116, 139);
    private static readonly Color C_BLUE   = Color.FromArgb(37, 99, 235);
    private static readonly Color C_GRID   = Color.FromArgb(51, 65, 85);
    private static readonly Color C_FWD    = Color.FromArgb(0,   200, 255);
    private static readonly Color C_BWD    = Color.FromArgb(255, 140,   0);
    private static readonly Color C_MARK_A = Color.FromArgb(250, 204,  21);
    private static readonly Color C_MARK_B = Color.FromArgb(34,  197,  94);

    // ── 오버레이 색상 팔레트 (최대 8개 파일) ──────────────────────
    private static readonly Color[] OVERLAY_COLORS =
    {
        Color.FromArgb(99, 202, 255), Color.FromArgb(255, 180,  50),
        Color.FromArgb(180, 130, 255), Color.FromArgb(80, 220, 150),
        Color.FromArgb(255, 100, 130), Color.FromArgb(0,  200, 200),
        Color.FromArgb(255, 220,  80), Color.FromArgb(180, 255, 100),
    };

    // ── 상태 ──────────────────────────────────────────────────────
    private List<GraphRecord> _loadedRecords = new List<GraphRecord>();
    private List<LineItem>    _fwdCurves     = new List<LineItem>();
    private List<LineItem>    _bwdCurves     = new List<LineItem>();
    private GraphPane         _pane;
    private TextObj           _cursorLabel;

    // 마커 A/B
    private double _markerA = double.NaN;
    private double _markerB = double.NaN;
    private LineObj _lineA, _lineB;
    private bool    _placingA, _placingB;

    // ── 컨트롤 ────────────────────────────────────────────────────
    private DateTimePicker  dtpDate;
    private ListBox         lbFiles;
    private ZedGraphControl zgGraph;
    private DataGridView    dgData;
    private Label           lblCursor;

    // 스케일 패널
    private TextBox txXMin, txXMax, txYMin, txYMax;
    // 통계 패널
    private Label lblStatFwd, lblStatBwd, lblStatMeta, lblStatGap, lblStatGapVal;
    // 마커 패널
    private Label lblMarkerStat;
    // 버튼들
    private Button btnMarkA, btnMarkB;

    // ──────────────────────────────────────────────────────────────
    public _FrmDataViewer()
    {
        InitializeComponent();
        InitGraph();
        dtpDate.Value = DateTime.Today;
        LoadFileList();
    }

    // ══════════════════════════════════════════════════════════════
    // 파일 목록
    // ══════════════════════════════════════════════════════════════
    private void LoadFileList()
    {
        lbFiles.Items.Clear();
        var files = GraphRecord.GetFileList(dtpDate.Value);
        foreach (var f in files)
            lbFiles.Items.Add(new FileItem(f));
    }

    private void DtpDate_ValueChanged(object s, EventArgs e) => LoadFileList();

    private void LbFiles_SelectedIndexChanged(object s, EventArgs e)
    {
        if (lbFiles.SelectedItems.Count == 0) return;
        LoadSelectedFiles();
    }

    private void LoadSelectedFiles()
    {
        _loadedRecords.Clear();
        foreach (FileItem fi in lbFiles.SelectedItems)
        {
            try { _loadedRecords.Add(GraphRecord.Load(fi.Path)); }
            catch { }
        }
        RebuildGraph();
        RebuildGrid();
        UpdateStats();
    }

    // ══════════════════════════════════════════════════════════════
    // 그래프 초기화
    // ══════════════════════════════════════════════════════════════
    private void InitGraph()
    {
        _pane = zgGraph.GraphPane;
        _pane.Fill      = new Fill(BG_CARD);
        _pane.Chart.Fill = new Fill(BG_DARK);
        _pane.Border.IsVisible = false;
        _pane.Title.IsVisible  = false;

        SetupAxis(_pane.XAxis, -2.0, 2.0, 0.1);
        SetupAxis(_pane.YAxis, -15.0, 15.0, 1.0);

        _pane.XAxis.Cross = 0.0; _pane.XAxis.CrossAuto = false;
        _pane.YAxis.Cross = 0.0; _pane.YAxis.CrossAuto = false;

        // 원점 수직선
        var vZero = _pane.AddCurve("",
            new PointPairList(new[] { 0.0, 0.0 }, new[] { -100.0, 100.0 }),
            C_GRID, SymbolType.None);
        vZero.Line.Width = 1f; vZero.Line.Style = DashStyle.Dash;
        vZero.IsSelectable = false;

        // 고정 축 라벨
        _pane.GraphObjList.Add(MakeTxtLabel("변위 (mm)", 1.0, 0.5, AlignH.Right, AlignV.Bottom));
        _pane.GraphObjList.Add(MakeTxtLabel("하중", 0.5, 0.0, AlignH.Left, AlignV.Top));

        // 커서 라벨
        _cursorLabel = new TextObj("", 0, 0, CoordType.AxisXYScale, AlignH.Left, AlignV.Top);
        _cursorLabel.FontSpec.FontColor      = C_TEXT;
        _cursorLabel.FontSpec.Size           = 9f;
        _cursorLabel.FontSpec.Fill           = new Fill(Color.FromArgb(200, 22, 32, 48));
        _cursorLabel.FontSpec.Border.IsVisible = false;
        _cursorLabel.IsVisible = false;
        _pane.GraphObjList.Add(_cursorLabel);

        // 범례
        _pane.Legend.IsVisible = false; // 오버레이 시 별도 표시

        zgGraph.IsEnableHZoom = true;
        zgGraph.IsEnableVZoom = true;
        zgGraph.IsEnableHPan  = true;
        zgGraph.IsEnableVPan  = true;
        zgGraph.MouseMove    += ZgGraph_MouseMove;
        zgGraph.MouseClick   += ZgGraph_MouseClick;
        zgGraph.AxisChange();
        zgGraph.Invalidate();
    }

    private void SetupAxis(Axis ax, double min, double max, double step)
    {
        ax.Title.IsVisible               = false;
        ax.Scale.FontSpec.FontColor      = C_TEXT;
        ax.Scale.FontSpec.Size           = 9f;
        ax.Scale.FontSpec.Fill.IsVisible = false;
        ax.Color                         = C_GRID;
        ax.MajorTic.Color                = C_GRID;
        ax.MinorTic.Color                = C_GRID;
        ax.MajorGrid.Color               = C_GRID;
        ax.MajorGrid.IsVisible           = true;
        ax.MajorGrid.DashOn              = 4f;
        ax.MajorGrid.DashOff             = 4f;
        ax.MinorGrid.IsVisible           = false;
        ax.Scale.Min = min; ax.Scale.Max = max;
        ax.Scale.MajorStep = step; ax.Scale.MajorStepAuto = false;
    }

    private TextObj MakeTxtLabel(string text, double x, double y, AlignH ah, AlignV av)
    {
        var obj = new TextObj(text, x, y, CoordType.ChartFraction, ah, av);
        obj.FontSpec.FontColor      = C_MUTED;
        obj.FontSpec.Size           = 10f;
        obj.FontSpec.Fill.IsVisible = false;
        obj.FontSpec.Border.IsVisible = false;
        return obj;
    }

    // ══════════════════════════════════════════════════════════════
    // 그래프 재구성 (오버레이)
    // ══════════════════════════════════════════════════════════════
    private void RebuildGraph()
    {
        // 커브/피크 오브젝트 제거 (커서·마커·원점·축라벨은 유지)
        _pane.CurveList.Clear();
        _fwdCurves.Clear(); _bwdCurves.Clear();

        // 원점 수직선 재추가
        var vZero = _pane.AddCurve("",
            new PointPairList(new[] { 0.0, 0.0 }, new[] { -100.0, 100.0 }),
            C_GRID, SymbolType.None);
        vZero.Line.Width = 1f; vZero.Line.Style = DashStyle.Dash;
        vZero.IsSelectable = false;

        // 피크 TextObj 제거 (태그로 구분)
        _pane.GraphObjList.RemoveAll(o => o.Tag is string t && t == "PEAK");

        int idx = 0;
        bool multi = _loadedRecords.Count > 1;

        foreach (var rec in _loadedRecords)
        {
            Color cFwd = multi ? OVERLAY_COLORS[idx % OVERLAY_COLORS.Length] : C_FWD;
            Color cBwd = multi ? Darken(OVERLAY_COLORS[idx % OVERLAY_COLORS.Length]) : C_BWD;
            string suffix = multi ? $" [{idx + 1}]" : "";

            var fwdPts = new PointPairList();
            var bwdPts = new PointPairList();
            foreach (var p in rec.Points)
            {
                if (p.Direction == "FWD") fwdPts.Add(p.X, p.Y);
                else bwdPts.Add(p.X, p.Y);
            }

            if (fwdPts.Count > 0)
            {
                var ln = _pane.AddCurve($"전방{suffix}", fwdPts, cFwd, SymbolType.None);
                ln.Line.Width = 2f; ln.Line.IsAntiAlias = true;
                _fwdCurves.Add(ln);
                AddPeakLabel(fwdPts, cFwd, rec.LoadUnit);
            }
            if (bwdPts.Count > 0)
            {
                var ln = _pane.AddCurve($"후방{suffix}", bwdPts, cBwd, SymbolType.None);
                ln.Line.Width = 2f; ln.Line.IsAntiAlias = true;
                _bwdCurves.Add(ln);
                AddPeakLabel(bwdPts, cBwd, rec.LoadUnit);
            }
            idx++;
        }

        // 마커 재구성
        RedrawMarkers();

        // 범례 (오버레이 시만 표시)
        _pane.Legend.IsVisible = multi;

        zgGraph.AxisChange();
        zgGraph.Invalidate();
    }

    private void AddPeakLabel(PointPairList pts, Color c, string unit)
    {
        if (pts.Count == 0) return;
        var peak = pts.OrderByDescending(p => Math.Abs(p.Y)).First();

        // 피크 원
        var sym = _pane.AddCurve("",
            new PointPairList(new[] { peak.X }, new[] { peak.Y }),
            c, SymbolType.Circle);
        sym.Symbol.Size = 8f;
        sym.Symbol.Fill = new Fill(c);
        sym.Line.IsVisible = false;
        sym.Tag = "PEAK";

        // 피크 값 텍스트
        var lbl = new TextObj($" {peak.Y:F2}{unit}", peak.X, peak.Y,
            CoordType.AxisXYScale, AlignH.Left, AlignV.Bottom);
        lbl.FontSpec.FontColor      = c;
        lbl.FontSpec.Size           = 9f;
        lbl.FontSpec.IsBold         = true;
        lbl.FontSpec.Fill           = new Fill(Color.FromArgb(160, 15, 23, 42));
        lbl.FontSpec.Border.IsVisible = false;
        lbl.Tag = "PEAK";
        _pane.GraphObjList.Add(lbl);
    }

    private Color Darken(Color c) =>
        Color.FromArgb(Math.Max(0, c.R - 60), Math.Max(0, c.G - 60), Math.Max(0, c.B - 60));

    // ══════════════════════════════════════════════════════════════
    // 그리드 재구성
    // ══════════════════════════════════════════════════════════════
    private void RebuildGrid()
    {
        dgData.Rows.Clear();
        foreach (var rec in _loadedRecords)
        {
            int i = 0;
            foreach (var p in rec.Points)
            {
                dgData.Rows.Add(
                    rec.MeasureTime.ToString("HH:mm:ss"),
                    rec.Barcode,
                    p.Direction == "FWD" ? "전방" : "후방",
                    i++,
                    p.X.ToString("F3", CultureInfo.InvariantCulture),
                    p.Y.ToString("F3", CultureInfo.InvariantCulture));
            }
        }
    }

    // ══════════════════════════════════════════════════════════════
    // 통계 업데이트
    // ══════════════════════════════════════════════════════════════
    private void UpdateStats()
    {
        if (_loadedRecords.Count == 0)
        {
            lblStatMeta.Text    = "파일을 선택하세요";
            lblStatFwd.Text     = "전방: —";
            lblStatBwd.Text     = "후방: —";
            lblStatGapVal.Text  = "—";
            lblStatGapVal.ForeColor = C_MUTED;
            lblMarkerStat.Text  = "마커: —";
            return;
        }

        var rec = _loadedRecords[0];
        lblStatMeta.Text =
            $"측정시각:  {rec.MeasureTime:yyyy-MM-dd HH:mm:ss}     " +
            $"바코드:  {rec.Barcode}     품번:  {rec.PartNo}";

        double fwdPeak = rec.Points.Where(p => p.Direction == "FWD").Select(p => p.Y).DefaultIfEmpty(0).Max();
        double bwdPeak = rec.Points.Where(p => p.Direction == "BWD").Select(p => p.Y).DefaultIfEmpty(0).Max();
        lblStatFwd.Text = $"전방  최대하중: {fwdPeak:F3} {rec.LoadUnit}   전진변위: {rec.FwdDisp:F3} mm";
        lblStatBwd.Text = $"후방  최대하중: {bwdPeak:F3} {rec.LoadUnit}   후진변위: {rec.BwdDisp:F3} mm";

        lblStatGapVal.Text      = $"{rec.GapAngle:F3}°";
        lblStatGapVal.ForeColor = rec.Pass
            ? Color.FromArgb(34, 197, 94)
            : Color.FromArgb(239, 68, 68);
    }

    // ══════════════════════════════════════════════════════════════
    // 마커 A / B
    // ══════════════════════════════════════════════════════════════
    private void BtnMarkA_Click(object s, EventArgs e)
    {
        _placingA = !_placingA; _placingB = false;
        btnMarkA.BackColor = _placingA ? C_MARK_A : BG_PANEL;
        btnMarkA.ForeColor = _placingA ? Color.Black : C_TEXT;
        btnMarkB.BackColor = BG_PANEL; btnMarkB.ForeColor = C_TEXT;
        zgGraph.Cursor = _placingA ? Cursors.Cross : Cursors.Default;
    }
    private void BtnMarkB_Click(object s, EventArgs e)
    {
        _placingB = !_placingB; _placingA = false;
        btnMarkB.BackColor = _placingB ? C_MARK_B : BG_PANEL;
        btnMarkB.ForeColor = _placingB ? Color.Black : C_TEXT;
        btnMarkA.BackColor = BG_PANEL; btnMarkA.ForeColor = C_TEXT;
        zgGraph.Cursor = _placingB ? Cursors.Cross : Cursors.Default;
    }

    private void ZgGraph_MouseClick(object s, MouseEventArgs e)
    {
        if (!_placingA && !_placingB) return;
        double wx, wy;
        _pane.ReverseTransform(new PointF(e.X, e.Y), out wx, out wy);

        if (_placingA) { _markerA = wx; _placingA = false; btnMarkA.BackColor = BG_PANEL; btnMarkA.ForeColor = C_TEXT; zgGraph.Cursor = Cursors.Default; }
        else           { _markerB = wx; _placingB = false; btnMarkB.BackColor = BG_PANEL; btnMarkB.ForeColor = C_TEXT; zgGraph.Cursor = Cursors.Default; }

        RedrawMarkers();
        UpdateMarkerStat();
    }

    private void RedrawMarkers()
    {
        if (_lineA != null) { _pane.GraphObjList.Remove(_lineA); _lineA = null; }
        if (_lineB != null) { _pane.GraphObjList.Remove(_lineB); _lineB = null; }

        if (!double.IsNaN(_markerA)) _lineA = AddVLine(_markerA, C_MARK_A, "A");
        if (!double.IsNaN(_markerB)) _lineB = AddVLine(_markerB, C_MARK_B, "B");

        zgGraph.AxisChange(); zgGraph.Invalidate();
    }

    private LineObj AddVLine(double x, Color c, string tag)
    {
        var lo = new LineObj(c, x, -100, x, 100);
        lo.Line.Width = 1.5f; lo.Line.Style = DashStyle.DashDot;
        lo.Tag = tag;
        _pane.GraphObjList.Add(lo);
        return lo;
    }

    private void UpdateMarkerStat()
    {
        if (double.IsNaN(_markerA) || double.IsNaN(_markerB))
        { lblMarkerStat.Text = "마커: A 또는 B를 설정하세요"; return; }

        double xL = Math.Min(_markerA, _markerB);
        double xR = Math.Max(_markerA, _markerB);
        double dX = xR - xL;

        double maxY = 0;
        if (_loadedRecords.Count > 0)
        {
            maxY = _loadedRecords[0].Points
                .Where(p => p.X >= xL && p.X <= xR)
                .Select(p => Math.Abs(p.Y)).DefaultIfEmpty(0).Max();
        }
        lblMarkerStat.Text =
            $"[A={_markerA:F3}  B={_markerB:F3}]   ΔX = {dX:F3} mm   구간 최대하중 = {maxY:F3}";
    }

    // ══════════════════════════════════════════════════════════════
    // 마우스 이동 → 커서 라벨
    // ══════════════════════════════════════════════════════════════
    private void ZgGraph_MouseMove(object s, MouseEventArgs e)
    {
        double wx, wy;
        _pane.ReverseTransform(new PointF(e.X, e.Y), out wx, out wy);
        if (wx >= _pane.XAxis.Scale.Min && wx <= _pane.XAxis.Scale.Max)
        {
            lblCursor.Text = $"X: {wx:F3} mm    Y: {wy:F3}";
            _cursorLabel.Location.X = wx;
            _cursorLabel.Location.Y = wy;
            _cursorLabel.Text = $"({wx:F2}, {wy:F2})";
            _cursorLabel.IsVisible = true;
            zgGraph.Invalidate();
        }
    }

    // ══════════════════════════════════════════════════════════════
    // 스케일 조정
    // ══════════════════════════════════════════════════════════════
    private void BtnScaleApply_Click(object s, EventArgs e)
    {
        if (TryParsePair(txXMin.Text, txXMax.Text, out double xn, out double xx))
        {
            _pane.XAxis.Scale.Min = xn; _pane.XAxis.Scale.Max = xx;
            _pane.XAxis.Scale.MinAuto = false; _pane.XAxis.Scale.MaxAuto = false;
        }
        if (TryParsePair(txYMin.Text, txYMax.Text, out double yn, out double yx))
        {
            _pane.YAxis.Scale.Min = yn; _pane.YAxis.Scale.Max = yx;
            _pane.YAxis.Scale.MinAuto = false; _pane.YAxis.Scale.MaxAuto = false;
        }
        zgGraph.AxisChange(); zgGraph.Invalidate();
    }

    private void BtnScaleAuto_Click(object s, EventArgs e)
    {
        _pane.XAxis.Scale.MinAuto = true; _pane.XAxis.Scale.MaxAuto = true;
        _pane.YAxis.Scale.MinAuto = true; _pane.YAxis.Scale.MaxAuto = true;
        zgGraph.AxisChange(); zgGraph.Invalidate();
        txXMin.Text = _pane.XAxis.Scale.Min.ToString("F1");
        txXMax.Text = _pane.XAxis.Scale.Max.ToString("F1");
        txYMin.Text = _pane.YAxis.Scale.Min.ToString("F1");
        txYMax.Text = _pane.YAxis.Scale.Max.ToString("F1");
    }

    private void BtnScaleReset_Click(object s, EventArgs e)
    {
        SetupAxis(_pane.XAxis, -2.0, 2.0, 0.1);
        SetupAxis(_pane.YAxis, -15.0, 15.0, 1.0);
        txXMin.Text = "-2.0"; txXMax.Text = "2.0";
        txYMin.Text = "-15.0"; txYMax.Text = "15.0";
        zgGraph.AxisChange(); zgGraph.Invalidate();
    }

    // ══════════════════════════════════════════════════════════════
    // 이미지 저장
    // ══════════════════════════════════════════════════════════════
    private void BtnSaveImage_Click(object s, EventArgs e)
    {
        using (var dlg = new SaveFileDialog())
        {
            dlg.Filter = "PNG 이미지|*.png";
            dlg.FileName = $"graph_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            Bitmap bmp = (Bitmap)zgGraph.GetImage();
            bmp.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
            bmp.Dispose();
        }
    }

    // ══════════════════════════════════════════════════════════════
    // CSV 내보내기 (현재 로드된 데이터)
    // ══════════════════════════════════════════════════════════════
    private void BtnExportCsv_Click(object s, EventArgs e)
    {
        if (_loadedRecords.Count == 0) { MessageBox.Show("로드된 파일이 없습니다."); return; }
        using (var dlg = new SaveFileDialog())
        {
            dlg.Filter = "CSV|*.csv";
            dlg.FileName = $"export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            using (var sw = new StreamWriter(dlg.FileName, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine("Time,Barcode,Direction,Index,X_mm,Y");
                int i = 0;
                foreach (var rec in _loadedRecords)
                    foreach (var p in rec.Points)
                        sw.WriteLine($"{rec.MeasureTime:yyyy-MM-dd HH:mm:ss}," +
                                     $"{rec.Barcode},{p.Direction},{i++}," +
                                     $"{p.X.ToString(CultureInfo.InvariantCulture)}," +
                                     $"{p.Y.ToString(CultureInfo.InvariantCulture)}");
            }
        }
    }

    // ══════════════════════════════════════════════════════════════
    // 유틸
    // ══════════════════════════════════════════════════════════════
    private static bool TryParsePair(string a, string b, out double v1, out double v2)
    {
        v1 = 0; v2 = 0;
        return double.TryParse(a, NumberStyles.Float, CultureInfo.InvariantCulture, out v1)
            && double.TryParse(b, NumberStyles.Float, CultureInfo.InvariantCulture, out v2)
            && v1 < v2;
    }

    private class FileItem
    {
        public string Path;
        public FileItem(string p) { Path = p; }
        public override string ToString() => System.IO.Path.GetFileName(Path);
    }
}
