using ResisterTest.Managers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class _FrmMain : Form
    {
        // ── 측정 시퀀스 스텝 ────────────────────────────────────────────
        private double wStep1 = 0;

        // ── 시리얼 포트 ─────────────────────────────────────────────────
        private SerialPort spLvdt    = new SerialPort();  // DI-20W RS-232 전용
        private SerialPort spRs485   = new SerialPort();  // RS-485 (로드셀 1,2)
        private SerialPort spScanner = new SerialPort();  // 바코드 스캐너


        // ── PLC 드라이버 ────────────────────────────────────────────────
        private IPlcDriver plcDriver;
        private Thread plcWorkThread;
        private Thread plcReceiveThread;
        private bool plcThreadRun = false;

        // ── 그래프 데이터 ───────────────────────────────────────────────
        private ZedGraph.LineItem fwdLine;       // 전방 (전진)
        private ZedGraph.LineItem bwdLine;       // 후방 (후진)
        private ZedGraph.TextObj  fwdLastLabel;  // 전방 마지막 값 라벨
        private ZedGraph.TextObj  bwdLastLabel;  // 후방 마지막 값 라벨
        private int graphPtCount = 0;
        private GraphRecord _graphRec;           // 측정 사이클 그래프 데이터

        // ── 검사 시간 추적 ──────────────────────────────────────────────
        private DateTime _startTime;

        // ── 사이클 타이머 ───────────────────────────────────────────────
        private Stopwatch cycleWatch = new Stopwatch();
        private Stopwatch stepWatch  = new Stopwatch();

        // ── 작업 표준서 폼 ──────────────────────────────────────────────
        private _FrmWorkStandard _frmWorkStandard;

        // ── 임시 변수 ───────────────────────────────────────────────────
        private double lvdtZero = 0;
        private double lc1Zero  = 0;
        private double lc2Zero  = 0;

        // ── 리셋 처리 ───────────────────────────────────────────────────
        private readonly System.Windows.Forms.Timer resetTimer = new System.Windows.Forms.Timer { Interval = 100 };
        private bool resetBitPrev   = false;
        private int  resetHoldTick  = 0;    // 100ms 단위 홀드 카운트
        private bool resetLongFired = false; // 2초 기능 중복 방지
        private int  errorPulseTick = 0;    // 에러 리셋 펄스 OFF 카운트
        private int  resetStep      = 0;    // 2초 리셋 후 복귀 시퀀스 스텝

        public _FrmMain()
        {
            InitializeComponent();
        }

        // ═══════════════════════════════════════════════════════════════
        // Form Load / Close
        // ═══════════════════════════════════════════════════════════════
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Logger.Initialize(srcTxtLog);
            GlobalValues.LoadSettingsFromIni();
            GlobalValues.LoadCounts();
            ApplyLayout();
            RepositionHeaderButtons();
            InitGraph();
            UpdateCountLabels();
            UpdateSpecLabel();
            UpdateFormulaLabel();
            UpdateEquipTitle();

            btnPartMgr.Visible = false;

            GlobalValues.ZeroSensorsAction = () => Task.Run((Action)ZeroAllSensors);
            GlobalValues.ZeroLvdtAction    = () => Task.Run((Action)ZeroLvdt);
            GlobalValues.ZeroLc1Action     = () => Task.Run((Action)ZeroLc1);
            GlobalValues.ZeroLc2Action     = () => Task.Run((Action)ZeroLc2);
            OpenPorts();
            StartPlcThread();

            tmrDisplay.Start();
            resetTimer.Tick += ResetTimer_Tick;
            resetTimer.Start();

            _frmWorkStandard = new _FrmWorkStandard();
            _frmWorkStandard.WindowState = FormWindowState.Normal;
            _frmWorkStandard.Location    = new Point(-2000, 0);
            _frmWorkStandard.WindowState = FormWindowState.Maximized;
            _frmWorkStandard.Show();

            Logger.Log("유격 검사기 시작");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            workTimer1.Stop();
            tmrDisplay.Stop();
            resetTimer.Stop();
            StopPlcThread();
            ClosePorts();
            GlobalValues.SaveCounts();
            _frmWorkStandard?.Close();
            base.OnFormClosing(e);
        }

        // ═══════════════════════════════════════════════════════════════
        // 헤더 우측 버튼 재배치 (Anchor 계산이 InitializeComponent 순서상 틀어지므로)
        // ═══════════════════════════════════════════════════════════════
        private void RepositionHeaderButtons()
        {
            const int BW   = 150;
            const int BH   = 72;
            const int GAP  = 4;
            const int STEP = BW + GAP;
            int r   = panelHeader.ClientSize.Width;
            int h   = panelHeader.ClientSize.Height;
            int top = (h - BH) / 2;

            // btnPartMgr 숨김 — 화면 밖으로 내보내고 나머지 3개만 배치
            btnPartMgr.SetBounds(-500, top, BW, BH);
            btnSignal.SetBounds(   r - BW,          top, BW, BH);
            btnConfig.SetBounds(   r - BW - STEP,   top, BW, BH);
            btnDataView.SetBounds( r - BW - STEP*2, top, BW, BH);
            lblDateTime.SetBounds( r - BW - STEP*3 - 156, (h - 18) / 2, 150, 18);
        }

        // ═══════════════════════════════════════════════════════════════
        // 반응형 레이아웃 — 창 크기에 맞게 내부 컨트롤 배치
        // ═══════════════════════════════════════════════════════════════
        private void ApplyLayout()
        {
            int w = panelMain.ClientSize.Width;
            int h = panelMain.ClientSize.Height;

            // 배너 & 센서 패널 폭 = 전체 폭 - 16px
            int innerW = Math.Max(w - 16, 100);

            panelBanner.Size = new Size(innerW, 56);
            panelSensor.Size = new Size(innerW, 96);

            // 배너(y=8,h=56) → 센서(y=72,h=96) → 그래프(y=176)
            // 8+56+8=72, 72+96+8=176
            int graphTop = 176;
            int graphH   = Math.Max(h - graphTop - 228, 100);
            PlotDiff1.Location = new Point(8, graphTop);
            PlotDiff1.Size     = new Size(innerW, graphH);

            // 결과 패널
            panelResult.Location = new Point(8, graphTop + graphH + 8);
            panelResult.Size     = new Size(innerW, 220);

            // 결과 카드 너비를 innerW에 맞게 3분할
            int cw  = (innerW - 24) / 3;  // 24 = 2×12 gap
            int cg  = 12;
            if (cw < 200) cw = 200;

            lblFwdDisp.Size         = new Size(cw, 40); lblFwdDisp.Location  = new Point(0, 0);
            lbFwdDispMeasure1.Size  = new Size(cw, 132); lbFwdDispMeasure1.Location = new Point(0, 40);
            lblBwdDisp.Size         = new Size(cw, 40); lblBwdDisp.Location  = new Point(cw + cg, 0);
            lbBwdDispMeasure1.Size  = new Size(cw, 132); lbBwdDispMeasure1.Location = new Point(cw + cg, 40);
            lblGapAngle.Size        = new Size(cw, 40); lblGapAngle.Location = new Point((cw + cg) * 2, 0);
            lbGapAngleMeasure1.Size = new Size(cw, 80); lbGapAngleMeasure1.Location = new Point((cw + cg) * 2, 40);
            lblSpec.Location        = new Point((cw + cg) * 2, 122);
            lblSpec.Size            = new Size(110, 50);
            lbGapSpec1.Location     = new Point((cw + cg) * 2 + 114, 122);
            lbGapSpec1.Size         = new Size(cw - 114, 50);

            // 공식 레이블 — 3개 카드 전체 너비
            lblFormula.Location = new Point(0, 176);
            lblFormula.Size     = new Size(innerW - 16, 40);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            BeginInvoke((Action)(() =>
            {
                panelMain.SuspendLayout();
                ApplyLayout();
                panelMain.ResumeLayout();
                if (PlotDiff1 != null) { PlotDiff1.AxisChange(); PlotDiff1.Invalidate(); }
                Logger.Log($"[레이아웃] panelMain={panelMain.ClientSize.Width}x{panelMain.ClientSize.Height}  panelSensor={panelSensor.Size.Width}x{panelSensor.Size.Height}");
                Logger.Log($"[레이아웃] LC1위치=({lbLoadCell1.Location.X},{lbLoadCell1.Location.Y}) 크기={lbLoadCell1.Size.Width}x{lbLoadCell1.Size.Height} Visible={lbLoadCell1.Visible}");
            }));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (panelMain != null && IsHandleCreated)
            {
                panelMain.SuspendLayout();
                ApplyLayout();
                panelMain.ResumeLayout();
                if (PlotDiff1 != null)
                {
                    PlotDiff1.AxisChange();
                    PlotDiff1.Invalidate();
                }
            }
            if (panelHeader != null && IsHandleCreated)
                RepositionHeaderButtons();
        }

        // ═══════════════════════════════════════════════════════════════
        // 그래프 초기화
        // ═══════════════════════════════════════════════════════════════
        private void InitGraph()
        {
            var cBg   = Color.FromArgb(15,  23,  42);
            var cCard = Color.FromArgb(22,  32,  48);
            var cCyan = Color.FromArgb(6,   182, 212);
            var cText = Color.FromArgb(148, 163, 184);
            var cGrid = Color.FromArgb(51,  65,  85);
            var cZero = Color.FromArgb(80,  100, 120);

            PlotDiff1.BackColor = cBg;
            var master = PlotDiff1.MasterPane;
            master.Fill             = new ZedGraph.Fill(cBg);
            master.Border.IsVisible = false;

            var pane = PlotDiff1.GraphPane;
            pane.Fill             = new ZedGraph.Fill(cBg);
            pane.Chart.Fill       = new ZedGraph.Fill(cCard);
            pane.Border.Color     = cGrid; pane.Border.Width = 1f;
            pane.Chart.Border.Color = cGrid; pane.Chart.Border.Width = 1f;

            pane.Title.Text                    = "유격 측정";
            pane.Title.FontSpec.FontColor      = cCyan;
            pane.Title.FontSpec.Size           = 13f;
            pane.Title.FontSpec.IsBold         = true;
            pane.Title.FontSpec.Family         = "맑은 고딕";
            pane.Title.FontSpec.Fill.IsVisible = false;
            pane.Title.FontSpec.Border.IsVisible = false;

            void SetAxis(ZedGraph.Axis ax, double min, double max, double step = 0)
            {
                ax.Title.IsVisible               = false;
                ax.Scale.FontSpec.FontColor      = cText;
                ax.Scale.FontSpec.Size           = 10f;
                ax.Scale.FontSpec.Family         = "맑은 고딕";
                ax.Scale.FontSpec.Fill.IsVisible = false;
                ax.Color                         = cGrid;
                ax.MajorTic.Color                = cGrid;
                ax.MinorTic.Color                = cGrid;
                ax.MajorGrid.Color               = cGrid;
                ax.MajorGrid.IsVisible           = true;
                ax.MajorGrid.DashOn              = 4f;
                ax.MajorGrid.DashOff             = 4f;
                ax.MinorGrid.IsVisible           = false;
                ax.Scale.Min = min;
                ax.Scale.Max = max;
                if (step > 0)
                {
                    ax.Scale.MajorStep     = step;
                    ax.Scale.MajorStepAuto = false;
                }
            }
            SetAxis(pane.XAxis, -2.0, 2.0, 0.1);   // 변위 0.1mm 단위
            SetAxis(pane.YAxis, -10.0, 10.0, 1.0);  // 하중 1.0 단위

            // 축을 원점 기준 중앙에 표시 (4사분면)
            pane.XAxis.Cross     = 0.0;
            pane.XAxis.CrossAuto = false;
            pane.YAxis.Cross     = 0.0;
            pane.YAxis.CrossAuto = false;

            // 축 제목 고정 위치 TextObj
            ZedGraph.TextObj MakeLabel(string text, double x, double y, ZedGraph.AlignH ah, ZedGraph.AlignV av)
            {
                var t = new ZedGraph.TextObj(text, x, y, ZedGraph.CoordType.ChartFraction, ah, av);
                t.FontSpec.FontColor      = cText;
                t.FontSpec.Family         = "맑은 고딕";
                t.FontSpec.Size           = 10f;
                t.FontSpec.Fill.IsVisible = false;
                t.FontSpec.Border.IsVisible = false;
                return t;
            }
            pane.GraphObjList.Add(MakeLabel("변위 (mm)", 1.0, 0.5, ZedGraph.AlignH.Right, ZedGraph.AlignV.Bottom));
            pane.GraphObjList.Add(MakeLabel($"하중 ({MeasureData1.LoadUnit})", 0.5, 0.0, ZedGraph.AlignH.Left, ZedGraph.AlignV.Top));

            pane.Legend.IsVisible = false;

            // 수평 영점선 (Y=0)
            var hZero = pane.AddCurve("", new ZedGraph.PointPairList(
                new double[] { -2, 2 }, new double[] { 0, 0 }), cZero, ZedGraph.SymbolType.None);
            hZero.Line.Width = 1f;
            hZero.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            hZero.IsSelectable = false;

            // 수직 영점선 (X=0)
            var vZero = pane.AddCurve("", new ZedGraph.PointPairList(
                new double[] { 0, 0 }, new double[] { -10, 10 }), cZero, ZedGraph.SymbolType.None);
            vZero.Line.Width = 1f;
            vZero.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            vZero.IsSelectable = false;

            var cFwd = Color.FromArgb(0,   200, 255);  // 전방: 시안
            var cBwd = Color.FromArgb(255, 140,   0);  // 후방: 오렌지

            fwdLine = pane.AddCurve("전방", new ZedGraph.PointPairList(), cFwd, ZedGraph.SymbolType.None);
            fwdLine.Line.Width = 2.5f;
            fwdLine.Line.IsAntiAlias = true;

            bwdLine = pane.AddCurve("후방", new ZedGraph.PointPairList(), cBwd, ZedGraph.SymbolType.None);
            bwdLine.Line.Width = 2.5f;
            bwdLine.Line.IsAntiAlias = true;

            // 범례
            pane.Legend.IsVisible       = true;
            pane.Legend.Position        = ZedGraph.LegendPos.Right;
            pane.Legend.FontSpec.FontColor    = cText;
            pane.Legend.FontSpec.Family       = "맑은 고딕";
            pane.Legend.FontSpec.Size         = 11f;
            pane.Legend.FontSpec.Fill.IsVisible   = false;
            pane.Legend.FontSpec.Border.IsVisible = false;
            pane.Legend.Fill            = new ZedGraph.Fill(cCard);
            pane.Legend.Border.Color    = cGrid;

            // 마지막 값 라벨 (처음엔 숨김)
            ZedGraph.TextObj MakeLastLabel(Color c)
            {
                var lbl = new ZedGraph.TextObj("", 0, 0,
                    ZedGraph.CoordType.AxisXYScale,
                    ZedGraph.AlignH.Left, ZedGraph.AlignV.Center);
                lbl.FontSpec.FontColor      = c;
                lbl.FontSpec.Size           = 10f;
                lbl.FontSpec.Family         = "맑은 고딕";
                lbl.FontSpec.IsBold         = true;
                lbl.FontSpec.Fill           = new ZedGraph.Fill(Color.FromArgb(180, 30, 35, 40));
                lbl.FontSpec.Border.IsVisible = false;
                lbl.IsVisible               = false;
                return lbl;
            }
            fwdLastLabel = MakeLastLabel(cFwd);
            bwdLastLabel = MakeLastLabel(cBwd);
            pane.GraphObjList.Add(fwdLastLabel);
            pane.GraphObjList.Add(bwdLastLabel);

            graphPtCount = 0;
            PlotDiff1.IsEnableHZoom = false;
            PlotDiff1.IsEnableVZoom = false;
            PlotDiff1.AxisChange();
            PlotDiff1.Invalidate();
        }

        private void ClearGraph()
        {
            fwdLine.Points = new ZedGraph.PointPairList();
            bwdLine.Points = new ZedGraph.PointPairList();
            if (fwdLastLabel != null) fwdLastLabel.IsVisible = false;
            if (bwdLastLabel != null) bwdLastLabel.IsVisible = false;
            graphPtCount = 0;
            _graphRec = new GraphRecord
            {
                MeasureTime = DateTime.Now,
                PartNo      = MeasureData1.PartNo,
                PartName    = MeasureData1.PartName,
                LoadUnit    = MeasureData1.LoadUnit,
                GapSpec     = MeasureData1.GapSpec,
            };
            PlotDiff1.AxisChange();
            PlotDiff1.Invalidate();
        }

        private void AddGraphPoint(double x, double y, bool isFwd)
        {
            var list = isFwd
                ? (ZedGraph.PointPairList)fwdLine.Points
                : (ZedGraph.PointPairList)bwdLine.Points;
            list.Add(x, y);
            _graphRec?.Points.Add(new GraphPoint
            {
                Direction = isFwd ? "FWD" : "BWD",
                X = x, Y = y
            });

            // 마지막 점에 값 표시 (약간 우측으로 오프셋)
            var lbl = isFwd ? fwdLastLabel : bwdLastLabel;
            if (lbl != null)
            {
                lbl.Location.X = x + 0.05;
                lbl.Location.Y = y;
                lbl.Text       = $"X:{x:F2}\nY:{y:F1}";
                lbl.IsVisible  = true;
            }

            graphPtCount++;
            if (graphPtCount % 5 == 0)
                PlotDiff1.Invalidate();
        }

        // ═══════════════════════════════════════════════════════════════
        // 포트 열기/닫기
        // ═══════════════════════════════════════════════════════════════
        private void OpenPorts()
        {
            OpenSerial(spLvdt,    GlobalValues.LvdtPort,    GlobalValues.LvdtBaud);
            OpenSerial(spRs485,   GlobalValues.Rs485Port,   GlobalValues.Rs485Baud);
            OpenSerial(spScanner, GlobalValues.ScannerPort, 9600);
            if (spLvdt.IsOpen)    spLvdt.DataReceived    += SpLvdt_DataReceived;
            if (spScanner.IsOpen) spScanner.DataReceived += SpScanner_DataReceived;
            if (spRs485.IsOpen)
            {
                rs485Run = true;
                rs485Thread = new Thread(Rs485PollThread) { IsBackground = true, Name = "RS485Poll" };
                rs485Thread.Start();
            }
        }

        private void ClosePorts()
        {
            rs485Run = false;
            rs485Thread?.Join(500);
            CloseSerial(spLvdt);
            CloseSerial(spRs485);
            CloseSerial(spScanner);
        }

        private void OpenSerial(SerialPort sp, string portName, int baud)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(portName)) return;
                if (baud <= 0)
                {
                    Logger.Log($"[{portName}] 포트 열기 실패: 보드레이트 값 오류 ({baud}) — 환경설정에서 확인하세요");
                    return;
                }
                if (sp.IsOpen) sp.Close();
                sp.PortName  = portName;
                sp.BaudRate  = baud;
                sp.DataBits  = 8;
                sp.Parity    = Parity.None;
                sp.StopBits  = StopBits.One;
                sp.ReadTimeout  = 500;
                sp.WriteTimeout = 500;
                Logger.Log($"[{portName}] 포트 열기 시도: {baud}bps 8N1");
                sp.Open();
                Logger.Log($"[{portName}] 포트 열기 성공");
            }
            catch (Exception ex) { Logger.Log($"[{portName}] 포트 열기 실패: {ex.Message}"); }
        }

        private void CloseSerial(SerialPort sp)
        {
            try { if (sp.IsOpen) sp.Close(); } catch { }
        }

        private readonly object _rs485Lock = new object();
        private Thread rs485Thread;
        private volatile bool rs485Run = false;

        private void Rs485PollThread()
        {
            Logger.Log($"[RS485] 폴링 시작 — LC1Id={GlobalValues.LoadCell1Id} LC2Id={GlobalValues.LoadCell2Id}");
            while (rs485Run)
            {
                try
                {
                    lock (_rs485Lock) PollLoadCell(GlobalValues.LoadCell1Id, v => {
                        MeasureData1.ValueLoadCell1 = v;
                        try { if (IsHandleCreated && !IsDisposed) BeginInvoke((MethodInvoker)(() => lbLoadCell1.Text = v.ToString("F2"))); } catch { }
                    });
                    if (!rs485Run) break;
                    if (GlobalValues.LoadCell2Id > 0)
                    {
                        Thread.Sleep(20);
                        lock (_rs485Lock) PollLoadCell(GlobalValues.LoadCell2Id, v => {
                            MeasureData1.ValueLoadCell2 = v;
                            try { if (IsHandleCreated && !IsDisposed) BeginInvoke((MethodInvoker)(() => lbLoadCell2.Text = v.ToString("F2"))); } catch { }
                        });
                    }
                    Thread.Sleep(20);
                }
                catch (Exception ex)
                {
                    Logger.Log($"[RS485] 스레드 예외: {ex.GetType().Name}: {ex.Message}");
                    Thread.Sleep(200);
                }
            }
        }

        private int _lcLogTick = 0;
        private void PollLoadCell(int id, Action<double> setVal)
        {
            try
            {
                spRs485.DiscardInBuffer();
                spRs485.Write(new byte[] { (byte)(0x30 + id), 0x52 }, 0, 2);
                spRs485.ReadTimeout = 150;

                var rawBytes = new System.Collections.Generic.List<byte>();
                var sb = new System.Text.StringBuilder();
                bool stx = false;
                for (int i = 0; i < 40; i++)
                {
                    int b = spRs485.ReadByte();
                    rawBytes.Add((byte)b);
                    if (!stx) { if (b == 0x02) stx = true; }
                    else       { if (b == 0x03) break; sb.Append((char)b); }
                }

                if (id == 1) _lcLogTick++;

                if (stx && sb.Length > 1)
                {
                    // 프로토콜: STX + idByte + 부호+공백+값 + ETX
                    // sb = "1+   5.0" → Substring(1) = "+   5.0" → 공백 제거 → "+5.0"
                    string dataStr = sb.ToString().Substring(1).Replace(" ", "");
                    if (double.TryParse(dataStr,
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out double val))
                        setVal(val);
                }
            }
            catch (Exception ex) { Logger.Log($"[LC{id}폴링오류] {ex.GetType().Name}: {ex.Message}"); }
        }

        // DI-20W Stream mode 수신: "ST,NT,+1234.5\r\n"
        private string _lvdtBuf = "";
        private int _lvdtLogCount = 0;
        private void SpLvdt_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string recv = spLvdt.ReadExisting();
                _lvdtLogCount++;
                _lvdtBuf += recv;
                int idx;
                while ((idx = _lvdtBuf.IndexOf('\n')) >= 0)
                {
                    string line = _lvdtBuf.Substring(0, idx).TrimEnd('\r');
                    _lvdtBuf = _lvdtBuf.Substring(idx + 1);
                    var parts = line.Split(',');
                    if (parts.Length >= 3 && parts[0] == "ST" && parts[1] == "NT" &&
                        double.TryParse(parts[2].Replace(" ", ""),
                            System.Globalization.NumberStyles.Float,
                            System.Globalization.CultureInfo.InvariantCulture, out double val))
                    {
                        double net = val - MeasureData1.LvdtOffset;
                        MeasureData1.ValueLvdt = net;
                        try { if (IsHandleCreated && !IsDisposed) BeginInvoke((MethodInvoker)(() => srcLvdt1.Text = net.ToString("F3"))); } catch { }
                    }
                }
            }
            catch (Exception ex) { Logger.Log($"[LVDT오류] {ex.GetType().Name}: {ex.Message}"); }
        }


        // ── RS-485 하드웨어 영점 명령 ────────────────────────────────────
        // DI-20W: "ID{id}Z", BS-205: {idByte, 'Z'(0x5A)}
        private void ZeroLvdt()
        {
            try
            {
                // Stream mode에서는 PC 명령 무시됨 → 소프트웨어 영점으로 대체
                // Command mode(F-40≠000)이면 하드웨어 영점도 시도
                if (spLvdt.IsOpen && GlobalValues.LvdtId > 0)
                {
                    string id2 = GlobalValues.LvdtId.ToString("D2");
                    byte[] cmd = System.Text.Encoding.ASCII.GetBytes($"ID{id2}Z");
                    spLvdt.Write(cmd, 0, cmd.Length);
                    Thread.Sleep(80);
                }
                // 소프트웨어 영점: 현재 raw값을 기준으로 offset 저장
                MeasureData1.LvdtOffset += MeasureData1.ValueLvdt;
                Logger.Log($"[영점] LVDT 영점 완료 (offset={MeasureData1.LvdtOffset:F3})");
            }
            catch (Exception ex) { Logger.Log($"[영점] LVDT 실패: {ex.Message}"); }
        }

        private void ZeroLc1()
        {
            try
            {
                if (!spRs485.IsOpen) return;
                lock (_rs485Lock)
                {
                    spRs485.DiscardInBuffer();
                    spRs485.Write(new byte[] { (byte)(0x30 + GlobalValues.LoadCell1Id), 0x5A }, 0, 2);
                    Thread.Sleep(50);
                }
                Logger.Log("[영점] 로드셀1 영점 완료");
            }
            catch (Exception ex) { Logger.Log($"[영점] 로드셀1 실패: {ex.Message}"); }
        }

        private void ZeroLc2()
        {
            try
            {
                if (!spRs485.IsOpen) return;
                lock (_rs485Lock)
                {
                    spRs485.DiscardInBuffer();
                    spRs485.Write(new byte[] { (byte)(0x30 + GlobalValues.LoadCell2Id), 0x5A }, 0, 2);
                    Thread.Sleep(50);
                }
                Logger.Log("[영점] 로드셀2 영점 완료");
            }
            catch (Exception ex) { Logger.Log($"[영점] 로드셀2 실패: {ex.Message}"); }
        }

        private void ZeroAllSensors()
        {
            ZeroLvdt();
            ZeroLc1();
            ZeroLc2();
        }


        // ═══════════════════════════════════════════════════════════════
        // ── 바코드 스캐너 수신 ────────────────────────────────────────────
        private string _scanBuf = "";
        private void SpScanner_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                _scanBuf += spScanner.ReadExisting();
                int idx;
                while ((idx = _scanBuf.IndexOf('\r')) >= 0)
                {
                    string code = _scanBuf.Substring(0, idx).Trim();
                    _scanBuf = _scanBuf.Substring(idx + 1);
                    if (!string.IsNullOrEmpty(code))
                        BeginInvoke(new Action(() => ApplyBarcode(code)));
                }
            }
            catch { }
        }

        private void ApplyBarcode(string code)
        {
            if (code.Length < 35)
            {
                Logger.Log($"[바코드] 길이 {code.Length}자리 — 35자리 미만, 검사 불가");
                return;
            }
            if (wStep1 != 0)
            {
                Logger.Log($"[바코드] 검사 진행 중 — 무시");
                return;
            }
            _startTime = DateTime.Now;
            wStep1 = 1.0;
            workTimer1.Start();
            lbBarcode1.Text = code;
            srcState.Text = "PUSH 버튼을 누르세요";
            cycleWatch.Restart();
            Logger.Log($"[바코드] {code} ({code.Length}자리) → 검사 시작");
        }

        // ═══════════════════════════════════════════════════════════════
        // 리셋 처리 타이머 (100ms)
        // ═══════════════════════════════════════════════════════════════
        private void ResetTimer_Tick(object sender, EventArgs e)
        {
            // 에러 리셋 펄스 자동 OFF
            if (errorPulseTick > 0 && --errorPulseTick == 0)
                PLCData1.SetPlcBit(GlobalValues.ErrorResetOutDWord, GlobalValues.ErrorResetOutBit, false);

            // ── 리셋 입력 엣지 감지 ──────────────────────────────────
            bool resetNow = PLCData1.PlcValueBit[GlobalValues.ResetInputDWord, GlobalValues.ResetInputBit];

            if (resetNow && !resetBitPrev)
            {
                // 상승 엣지: 카운터 초기화
                resetHoldTick  = 0;
                resetLongFired = false;
            }

            if (resetNow)
            {
                resetHoldTick++;
                // 2초(20틱) 이상 유지 → 검사루틴 초기화 + 에러리셋 + 서보 이동
                if (resetHoldTick >= 20 && !resetLongFired)
                {
                    StopMeasure();
                    TriggerErrorReset();
                    PLCData1.SetPlcBit(9, 9, true);  // D4009.9 서보 ON
                    resetLongFired = true;

                    // LOAD 현재 위치에 따라 서보 이동 방향 결정
                    if (PLCData1.PlcValueBit[0, 7])  // LOAD 하강 센서 D4000.7
                    {
                        PLCData1.SetPlcBit(12, 0, true);  // POS 1 검사위치 지령
                        resetStep = 2;
                        Logger.Log($"[리셋] 2초 → 에러리셋 + 서보ON(D4009.9) + LOAD 하강 → POS1({PLCData1.Servo1PosComments[0]}) 지령");
                    }
                    else if (PLCData1.PlcValueBit[0, 8])  // LOAD 상승 센서 D4000.8
                    {
                        PLCData1.SetPlcBit(12, 1, true);  // POS 2 대기위치 지령
                        resetStep = 3;
                        Logger.Log($"[리셋] 2초 → 에러리셋 + 서보ON(D4009.9) + LOAD 상승 → POS2({PLCData1.Servo1PosComments[1]}) 지령");
                    }
                    else
                    {
                        resetStep = 0;
                        Logger.Log("[리셋] 2초 → 에러리셋 + 서보ON(D4009.9) + LOAD 위치 불명 → 서보 이동 생략");
                    }
                }
            }
            else if (!resetNow && resetBitPrev)
            {
                // 하강 엣지 — 2초 미만이면 에러리셋 펄스만
                if (!resetLongFired)
                {
                    TriggerErrorReset();
                    Logger.Log("[리셋] 짧은 리셋 → 에러리셋 펄스");
                }
            }

            resetBitPrev = resetNow;

            // ── 서보 포지션 복귀 시퀀스 ─────────────────────────────
            switch (resetStep)
            {
                case 2:
                    // POS 1(검사위치) 지령 중 → D4014.0 완료 대기
                    if (PLCData1.PlcValueBit[14, 0])
                    {
                        PLCData1.SetPlcBit(12, 0, false);
                        resetStep = 0;
                        Logger.Log("[리셋 시퀀스] POS1 완료 → 지령 OFF");
                    }
                    break;

                case 3:
                    // POS 2(대기위치) 지령 중 → D4014.1 완료 대기
                    if (PLCData1.PlcValueBit[14, 1])
                    {
                        PLCData1.SetPlcBit(12, 1, false);
                        resetStep = 0;
                        Logger.Log("[리셋 시퀀스] POS2 완료 → 지령 OFF");
                    }
                    break;
            }
        }

        private void TriggerErrorReset()
        {
            PLCData1.SetPlcBit(GlobalValues.ErrorResetOutDWord, GlobalValues.ErrorResetOutBit, true);
            errorPulseTick = 3;  // 300ms 후 자동 OFF
        }


        // ═══════════════════════════════════════════════════════════════
        // PLC 스레드
        // ═══════════════════════════════════════════════════════════════
        private void StartPlcThread()
        {
            try
            {
                plcDriver = new MelsecMxDriver(GlobalValues.PlcIpAddress, GlobalValues.PlcIpPort, this);
                plcDriver.Connect();
                plcThreadRun = true;
                plcWorkThread    = new Thread(PlcWorkLoop)    { IsBackground = true };
                plcReceiveThread = new Thread(PlcReceiveLoop) { IsBackground = true };
                plcWorkThread.Start();
                plcReceiveThread.Start();
            }
            catch (Exception ex) { Logger.Log($"PLC 연결 실패: {ex.Message}"); }
        }

        private void StopPlcThread()
        {
            plcThreadRun = false;
            try { plcDriver?.Disconnect(); } catch { }
        }

        private void PlcWorkLoop()
        {
            while (plcThreadRun)
            {
                // writePlcValueBit[0~13, bit] → writePlcValue[4000~4013] 변환 (출력 영역)
                for (int w = 0; w < 14; w++)
                {
                    int val = 0;
                    for (int b = 0; b < 16; b++)
                        if (PLCData1.writePlcValueBit[w, b]) val |= (1 << b);
                    PLCData1.writePlcValue[4000 + w] = val;
                }

                try { plcDriver.WriteWords(4000, 14); } catch { }  // D4000~D4013 출력
                try { plcDriver.WriteWords(5002, 4);  } catch { }  // D5002~D5005 JOG속도
                try { plcDriver.WriteWords(6000, 24); } catch { }  // D6000~D6023 6포지션
                Thread.Sleep(50);
            }
        }

        private void PlcReceiveLoop()
        {
            int flickerCount = 0;
            while (plcThreadRun)
            {
                try { plcDriver.ReadWords(4000, 15); } catch { }  // D4000~D4014 (비트 입력)

                // D4009.0 플리커: 100ms × 10 = 1초 주기 ON/OFF
                if (++flickerCount >= 10)
                {
                    PLCData1.writePlcValueBit[9, 0] = !PLCData1.writePlcValueBit[9, 0];
                    flickerCount = 0;
                }

                Thread.Sleep(100);
            }
        }

        // ═══════════════════════════════════════════════════════════════
        // 디스플레이 타이머 (200ms)
        // ═══════════════════════════════════════════════════════════════
        private int _tickLog = 0;
        private void tmrDisplay_Tick(object sender, EventArgs e)
        {
            try
            {
            System.Threading.Thread.MemoryBarrier();
            _tickLog++;

            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            srcLvdt1.Text    = MeasureData1.ValueLvdt.ToString("F3");
            lbLoadCell1.Text = MeasureData1.ValueLoadCell1.ToString("F2");
            lbLoadCell2.Text = MeasureData1.ValueLoadCell2.ToString("F2");
            if (cycleWatch.IsRunning)
                LbCycle1.Text = $"사이클: {cycleWatch.Elapsed.TotalSeconds:F1}s";

            // D4008.1 서보 알람
            lbServoAlarm.Visible = PLCData1.PlcValueBit[8, 1];
            } catch (Exception ex) { Logger.Log($"[Tick오류] {ex.GetType().Name}: {ex.Message}"); }
        }

        // ═══════════════════════════════════════════════════════════════
        // 측정 시퀀스 타이머 (100ms)
        // ═══════════════════════════════════════════════════════════════
        private const int IN_PUSH_WORD  = 0;
        private const int IN_PUSH_BIT   = 0;
        private const int IN_CLAMP_WORD = 0;
        private const int IN_CLAMP_BIT  = 3;  // D4000 bit3 = 클램프 센서
        private const int OUT_SOL_WORD  = 4;
        private const int OUT_SOL_BIT   = 0;  // D4004 bit0 = 클램프 출력

        private void workTimer1_Tick(object sender, EventArgs e)
        {
            // D4008.1 서보 알람 발생 시 즉시 검사 중단
            if (PLCData1.PlcValueBit[8, 1] && wStep1 != 0)
            {
                StopMeasure();
                srcState.Text = "서보 알람 — 검사 중단";
                Logger.Log("[알람] D4008.1 서보 알람 발생 → 검사 중단");
                return;
            }

            switch ((int)(wStep1 * 10 + 0.5))
            {
                case 0: break;

                case 10:
                    if (PLCData1.PlcValueBit[IN_PUSH_WORD, IN_PUSH_BIT]) wStep1 = 1.1;
                    break;

                case 11:
                    PLCData1.SetPlcBit(OUT_SOL_WORD, OUT_SOL_BIT, true);
                    srcState.Text = "고정 중... (클램프 대기)";
                    Logger.Log("[SOL] 솔레노이드 ON → 제품 고정");
                    stepWatch.Restart();
                    wStep1 = 1.2;
                    break;

                case 12:
                    if (PLCData1.PlcValueBit[IN_CLAMP_WORD, IN_CLAMP_BIT])
                    {
                        PLCData1.SetPlcBit(OUT_SOL_WORD, OUT_SOL_BIT, false);  // 클램프 출력 해제 (기구 자력 유지)
                        srcState.Text = "고정 완료 — PUSH 버튼을 누르세요 (측정 시작)";
                        Logger.Log("[클램프] 클램프 센서 감지 → 클램프 출력 OFF → 측정 대기");
                        wStep1 = 1.3;
                    }
                    else if (stepWatch.Elapsed.TotalSeconds > 15)
                    {
                        PLCData1.SetPlcBit(OUT_SOL_WORD, OUT_SOL_BIT, false);
                        Logger.Log("[클램프] 타임아웃 — 클램프 미감지");
                        StopMeasure();
                    }
                    break;

                case 13:
                    if (PLCData1.PlcValueBit[IN_PUSH_WORD, IN_PUSH_BIT])
                    {
                        Logger.Log("[측정 시작] PUSH 확인 → 영점 잡기");
                        wStep1 = 2.0;
                    }
                    break;

                case 20:
                    srcState.Text = "영점 잡는 중...";
                    ClearGraph();
                    lbFwdDispMeasure1.Text  = "---";
                    lbBwdDispMeasure1.Text  = "---";
                    lbGapAngleMeasure1.Text = "---";
                    lbGapJudge1.Text        = "...";
                    lbGapJudge1.ForeColor   = Color.FromArgb(148, 163, 184);
                    lbGapJudge1.BackColor   = Color.FromArgb(22, 32, 48);
                    MeasureData1.FwdDisp = 0;
                    MeasureData1.BwdDisp = 0;
                    Task.Run(() => ZeroAllSensors()); // 하드웨어 영점 명령 비동기 전송
                    stepWatch.Restart();
                    wStep1 = 2.5; // 안정화 대기
                    break;

                case 25: // 영점 안정화 대기 (300ms)
                    if (stepWatch.Elapsed.TotalMilliseconds >= 300)
                    {
                        lvdtZero = MeasureData1.ValueLvdt;
                        lc1Zero  = MeasureData1.ValueLoadCell1;
                        lc2Zero  = MeasureData1.ValueLoadCell2;
                        stepWatch.Restart();
                        wStep1 = 3.0;
                    }
                    break;

                case 30:
                    srcState.Text = "전진 중...";
                    PLCData1.SetPlcBit(9, 1, true);
                    stepWatch.Restart();
                    wStep1 = 3.1;
                    break;

                case 31:
                {
                    double lc1Net  = MeasureData1.ValueLoadCell1 - lc1Zero;
                    double lvdtNet = MeasureData1.ValueLvdt - lvdtZero;
                    AddGraphPoint(lvdtNet, lc1Net, true);
                    if (lc1Net >= MeasureData1.CalcThreshold())
                    {
                        PLCData1.SetPlcBit(9, 1, false);
                        MeasureData1.FwdDisp = Math.Abs(lvdtNet);
                        Logger.Log($"[전진완료] FwdDisp={MeasureData1.FwdDisp:F3}mm LC1={lc1Net:F3}kgf");
                        wStep1 = 4.0;
                    }
                    else if (stepWatch.Elapsed.TotalSeconds > 30)
                    {
                        PLCData1.SetPlcBit(9, 1, false);
                        Logger.Log("[전진] 타임아웃");
                        StopMeasure();
                    }
                    break;
                }

                case 40:
                    // LVDT 기준은 처음 영점 그대로 유지 — 로드셀만 재영점
                    srcState.Text = "후진 전 로드셀 영점...";
                    Task.Run(() => { ZeroLc1(); ZeroLc2(); });
                    stepWatch.Restart();
                    wStep1 = 4.5;
                    break;

                case 45: // 로드셀 안정화 대기 (200ms)
                    if (stepWatch.Elapsed.TotalMilliseconds >= 200)
                    {
                        // lvdtZero 는 그대로 유지 (처음 영점 기준)
                        lc1Zero = MeasureData1.ValueLoadCell1;
                        lc2Zero = MeasureData1.ValueLoadCell2;
                        stepWatch.Restart();
                        wStep1 = 5.0;
                    }
                    break;

                case 50:
                    srcState.Text = "후진 중...";
                    PLCData1.SetPlcBit(9, 2, true);
                    stepWatch.Restart();
                    wStep1 = 5.1;
                    break;

                case 51:
                {
                    double lc2Net  = MeasureData1.ValueLoadCell2 - lc2Zero;
                    double lvdtNet = MeasureData1.ValueLvdt - lvdtZero;
                    AddGraphPoint(lvdtNet, lc2Net, false);
                    if (lc2Net >= MeasureData1.CalcThreshold())
                    {
                        PLCData1.SetPlcBit(9, 2, false);
                        MeasureData1.BwdDisp = Math.Abs(lvdtNet);
                        Logger.Log($"[후진완료] BwdDisp={MeasureData1.BwdDisp:F3}mm LC2={lc2Net:F3}kgf");
                        wStep1 = 6.0;
                    }
                    else if (stepWatch.Elapsed.TotalSeconds > 30)
                    {
                        PLCData1.SetPlcBit(9, 2, false);
                        Logger.Log("[후진] 타임아웃");
                        StopMeasure();
                    }
                    break;
                }

                case 60:
                {
                    srcState.Text = "계산 중...";
                    MeasureData1.GapAngle = MeasureData1.CalcGapAngle();

                    lbFwdDispMeasure1.Text  = MeasureData1.FwdDisp.ToString("F2");
                    lbBwdDispMeasure1.Text  = MeasureData1.BwdDisp.ToString("F2");
                    lbGapAngleMeasure1.Text = MeasureData1.GapAngle.ToString("F2");

                    bool pass = MeasureData1.GapAngle <= MeasureData1.GapSpec;
                    ShowJudge(pass);
                    SaveResult(pass);
                    PLCData1.SetPlcBit(OUT_SOL_WORD, OUT_SOL_BIT, false);

                    Logger.Log($"[결과] 유격={MeasureData1.GapAngle:F3}° 스펙≤{MeasureData1.GapSpec:F3}° → {(pass ? "OK" : "NG")}");
                    cycleWatch.Stop();
                    srcState.Text = pass ? "OK" : "NG";

                    lbBarcode1.Text = "대기 중...";
                    workTimer1.Stop();
                    wStep1 = 0;
                    break;
                }
            }
        }

        // ═══════════════════════════════════════════════════════════════
        // 결과 저장 및 카운터
        // ═══════════════════════════════════════════════════════════════
        private void ShowJudge(bool pass)
        {
            lbGapJudge1.Text      = pass ? "OK" : "NG";
            lbGapJudge1.BackColor = pass ? Color.FromArgb(20, 83, 45)   : Color.FromArgb(127, 29, 29);
            lbGapJudge1.ForeColor = pass ? Color.FromArgb(34, 197, 94)  : Color.FromArgb(239, 68, 68);
        }

        private void SaveResult(bool pass)
        {
            DateTime endTime = DateTime.Now;

            GlobalValues.TotalCount++;
            if (pass) GlobalValues.OkCount++;
            UpdateCountLabels();
            GlobalValues.SaveCounts();

            // DB 저장
            ClassDatabase.SaveRecord(
                startTime:  _startTime,
                endTime:    endTime,
                play:       MeasureData1.GapAngle,
                pass:       pass);

            // CSV 저장 (기존 유지)
            string dir  = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Result",
                                       endTime.ToString("yyyyMMdd"));
            Directory.CreateDirectory(dir);
            string file = Path.Combine(dir, "result.csv");
            bool header = !File.Exists(file);
            using (var sw = new StreamWriter(file, true, System.Text.Encoding.UTF8))
            {
                if (header)
                    sw.WriteLine("DateTime,FwdDisp_mm,BwdDisp_mm,Play_deg,Spec_deg,Judge");
                sw.WriteLine($"{endTime:yyyy-MM-dd HH:mm:ss}," +
                             $"{MeasureData1.FwdDisp:F3}," +
                             $"{MeasureData1.BwdDisp:F3}," +
                             $"{MeasureData1.GapAngle:F3}," +
                             $"{MeasureData1.GapSpec:F3}," +
                             $"{(pass ? "OK" : "NG")}");
            }

            AppendLog($"[{endTime:HH:mm:ss}] 유격={MeasureData1.GapAngle:F3}° → {(pass ? "OK" : "NG")}");

            // 그래프 포인트 CSV 저장
            if (_graphRec != null && _graphRec.Points.Count > 0)
            {
                _graphRec.MeasureTime = endTime;
                _graphRec.PartNo      = MeasureData1.PartNo;
                _graphRec.PartName    = MeasureData1.PartName;
                _graphRec.FwdDisp     = MeasureData1.FwdDisp;
                _graphRec.BwdDisp     = MeasureData1.BwdDisp;
                _graphRec.GapAngle    = MeasureData1.GapAngle;
                _graphRec.GapSpec     = MeasureData1.GapSpec;
                _graphRec.Pass        = pass;
                _graphRec.LoadUnit    = MeasureData1.LoadUnit;
                try { _graphRec.Save(); } catch (Exception ex) { Logger.Log($"[그래프CSV저장오류] {ex.Message}"); }
                _graphRec = null;
            }

        }

        private void UpdateCountLabels()
        {
            int ng = GlobalValues.TotalCount - GlobalValues.OkCount;
            lbOkCount.Text    = GlobalValues.OkCount.ToString();
            lbNGCount.Text    = ng.ToString();
            lbTotalCount.Text = GlobalValues.TotalCount.ToString();
        }

        private void UpdateEquipTitle()
        {
            lblTitle.Text = GlobalValues.EquipTitle;
            lblTitle.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold);
            this.Text     = GlobalValues.EquipTitle;
        }

        private void UpdateSpecLabel()
        {
            lbGapSpec1.Text = $"{MeasureData1.GapSpec:F2} {MeasureData1.Unit}";
        }

        private void UpdateFormulaLabel()
        {
            lblFormula.Text =
                $"변위 (mm)  /  L({MeasureData1.L_mm:F0} mm)  ×  180° / π";
        }

        private void UpdateGraphLabels()
        {
            var pane = PlotDiff1.GraphPane;
            // TextObj 중 하중 단위 라벨 갱신
            foreach (ZedGraph.GraphObj obj in pane.GraphObjList)
            {
                if (obj is ZedGraph.TextObj t && t.Text.StartsWith("하중"))
                    t.Text = $"하중 ({MeasureData1.LoadUnit})";
            }
            PlotDiff1.AxisChange();
            PlotDiff1.Invalidate();
        }

        private void AppendLog(string msg)
        {
            if (srcTxtLog.InvokeRequired)
                srcTxtLog.BeginInvoke(new Action(() => AppendLog(msg)));
            else
            {
                srcTxtLog.AppendText(msg + Environment.NewLine);
                if (srcTxtLog.Lines.Length > 500)
                    srcTxtLog.Text = srcTxtLog.Text.Substring(srcTxtLog.Text.IndexOf('\n') + 1);
            }
        }

        private void StopMeasure()
        {
            PLCData1.SetPlcBit(9, 1, false);
            PLCData1.SetPlcBit(9, 2, false);
            PLCData1.SetPlcBit(OUT_SOL_WORD, OUT_SOL_BIT, false);
            wStep1 = 0;
            lbBarcode1.Text = "대기 중...";
            srcState.Text = "정지";
            workTimer1.Stop();
        }

        // ═══════════════════════════════════════════════════════════════
        // 버튼 이벤트
        // ═══════════════════════════════════════════════════════════════
        private void btnPartMgr_Click(object sender, EventArgs e)
        {
            using (var frm = new _FrmPartManager())
                frm.ShowDialog(this);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            using (var frm = new _FrmConfiguration())
            {
                frm.ShowDialog(this);
                UpdateEquipTitle();
                UpdateSpecLabel();
                UpdateFormulaLabel();
                UpdateGraphLabels();
            }
        }

        private void btnSignal_Click(object sender, EventArgs e)
        {
            using (var frm = new ResisterTest._FrmSignalPlc1())
                frm.ShowDialog(this);
        }

        private void btnDataView_Click(object sender, EventArgs e)
        {
            using (var frm = new _FrmDataViewer())
                frm.ShowDialog(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "종료",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnCountReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("수량을 리셋하시겠습니까?", "확인",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GlobalValues.OkCount    = 0;
                GlobalValues.TotalCount = 0;
                UpdateCountLabels();
                GlobalValues.SaveCounts();
            }
        }
    }
}
