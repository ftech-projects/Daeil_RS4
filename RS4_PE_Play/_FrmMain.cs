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
        private SerialPort spRs485   = new SerialPort();  // RS-485 공용 (LVDT + 로드셀 1,2)
        private SerialPort spScanner = new SerialPort();
        private SerialPort spPrinter = new SerialPort();

        // ── RS-485 폴링 스레드 ──────────────────────────────────────────
        private Thread rs485Thread;
        private volatile bool rs485Run = false;

        // ── PLC 드라이버 ────────────────────────────────────────────────
        private IPlcDriver plcDriver;
        private Thread plcWorkThread;
        private Thread plcReceiveThread;
        private bool plcThreadRun = false;

        // ── 그래프 데이터 ───────────────────────────────────────────────
        private ZedGraph.LineItem gapLine;
        private int graphPtCount = 0;

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
            const int BW   = 150; // 버튼 너비
            const int BH   = 72;  // 버튼 높이
            const int GAP  = 4;   // 버튼 간격
            const int STEP = BW + GAP;
            int r = panelHeader.ClientSize.Width;
            int h = panelHeader.ClientSize.Height;
            int top = (h - BH) / 2;
            btnSignal.SetBounds( r - BW,             top, BW, BH);
            btnPartMgr.SetBounds(r - BW - STEP,      top, BW, BH);
            btnConfig.SetBounds( r - BW - STEP * 2,  top, BW, BH);
            btnBarcode.SetBounds(r - BW - STEP * 3,  top, BW, BH);
            lblDateTime.SetBounds(r - BW - STEP * 3 - 156, (h - 18) / 2, 150, 18);
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

            panelBanner.Size = new Size(innerW, 84);
            panelSensor.Size = new Size(innerW, 96);

            // 그래프: 배너+센서+여백 = 8+84+8+96+8=204, 하단 결과(220)+8=228
            int graphH = Math.Max(h - 204 - 228, 100);
            PlotDiff1.Size = new Size(innerW, graphH);

            // 결과 패널 (공식 레이블 포함: 180 → 220)
            panelResult.Location = new Point(8, 204 + graphH + 8);
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

            void SetAxis(ZedGraph.Axis ax, string title, double min, double max)
            {
                ax.Title.Text                    = title;
                ax.Title.FontSpec.FontColor      = cText;
                ax.Title.FontSpec.Family         = "맑은 고딕";
                ax.Title.FontSpec.Fill.IsVisible = false;
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
            }
            SetAxis(pane.XAxis, "변위 (mm)", -2.0, 2.0);
            SetAxis(pane.YAxis, $"하중 ({MeasureData1.LoadUnit})", -10.0, 10.0);

            pane.Legend.IsVisible = false;

            var hZero = pane.AddCurve("", new ZedGraph.PointPairList(
                new double[] { -2, 2 }, new double[] { 0, 0 }), cZero, ZedGraph.SymbolType.None);
            hZero.Line.Width = 1f;
            hZero.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
            hZero.IsSelectable = false;

            var pts = new ZedGraph.PointPairList();
            gapLine = pane.AddCurve("유격", pts, cCyan, ZedGraph.SymbolType.None);
            gapLine.Line.Width = 2.5f;
            gapLine.Line.IsAntiAlias = true;

            graphPtCount = 0;
            PlotDiff1.IsEnableHZoom = false;
            PlotDiff1.IsEnableVZoom = false;
            PlotDiff1.AxisChange();
            PlotDiff1.Invalidate();
        }

        private void ClearGraph()
        {
            gapLine.Points = new ZedGraph.PointPairList();
            graphPtCount = 0;
            PlotDiff1.AxisChange();
            PlotDiff1.Invalidate();
        }

        private void AddGraphPoint(double x, double y)
        {
            ((ZedGraph.PointPairList)gapLine.Points).Add(x, y);
            graphPtCount++;
            if (graphPtCount % 5 == 0)
                PlotDiff1.Invalidate();
        }

        // ═══════════════════════════════════════════════════════════════
        // 포트 열기/닫기
        // ═══════════════════════════════════════════════════════════════
        private void OpenPorts()
        {
            OpenSerial(spRs485,  GlobalValues.Rs485Port,   GlobalValues.Rs485Baud);
            OpenSerial(spScanner, GlobalValues.ScannerPort, 9600);
            OpenSerial(spPrinter, GlobalValues.PrinterPort, 9600);

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
            CloseSerial(spRs485);
            CloseSerial(spScanner);
            CloseSerial(spPrinter);
        }

        private void OpenSerial(SerialPort sp, string portName, int baud)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(portName)) return;
                sp.PortName = portName; sp.BaudRate = baud;
                sp.DataBits = 8; sp.Parity = Parity.None; sp.StopBits = StopBits.One;
                sp.Open();
            }
            catch (Exception ex) { Logger.Log($"포트 열기 실패 [{portName}]: {ex.Message}"); }
        }

        private void CloseSerial(SerialPort sp)
        {
            try { if (sp.IsOpen) sp.Close(); } catch { }
        }

        private readonly object _rs485Lock = new object();

        // ── RS-485 폴링 스레드 (LVDT + 로드셀1 + 로드셀2 순차 폴링) ──────
        // DI-20W Command mode: 송신 "ID01P" → 수신 "ID,01,+1234.5\r\n"
        // BS-205 Command mode: 송신 {idByte, 'R'} → 수신 STX+idByte+data+ETX
        private void Rs485PollThread()
        {
            while (rs485Run)
            {
                try
                {
                    lock (_rs485Lock) { PollLvdt(); }
                    if (!rs485Run) break;
                    Thread.Sleep(30);
                    lock (_rs485Lock) { PollLoadCell(GlobalValues.LoadCell1Id, v => MeasureData1.ValueLoadCell1 = v); }
                    if (!rs485Run) break;
                    Thread.Sleep(30);
                    lock (_rs485Lock) { PollLoadCell(GlobalValues.LoadCell2Id, v => MeasureData1.ValueLoadCell2 = v); }
                    Thread.Sleep(30);
                }
                catch { Thread.Sleep(100); }
            }
        }

        // LVDT 1회 폴링: "ID01P" 송신 → "ID,01,+val\r\n" 수신
        private void PollLvdt()
        {
            try
            {
                spRs485.DiscardInBuffer();
                string id2 = GlobalValues.LvdtId.ToString("D2");
                byte[] cmd = System.Text.Encoding.ASCII.GetBytes($"ID{id2}P");
                spRs485.Write(cmd, 0, cmd.Length);
                spRs485.ReadTimeout = 150;
                string resp = spRs485.ReadLine(); // \n까지 읽음
                var parts = resp.TrimEnd('\r').Split(',');
                if (parts.Length >= 3 && parts[0] == "ID" &&
                    double.TryParse(parts[2].Trim(),
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out double val))
                    MeasureData1.ValueLvdt = val;
            }
            catch { }
        }

        // 로드셀 1회 폴링: {idByte, 'R'} 송신 → STX+idByte+data+ETX 수신
        private void PollLoadCell(int id, Action<double> setVal)
        {
            try
            {
                spRs485.DiscardInBuffer();
                spRs485.Write(new byte[] { (byte)(0x30 + id), 0x52 }, 0, 2); // idByte + 'R'
                spRs485.ReadTimeout = 150;
                var sb = new System.Text.StringBuilder();
                bool stx = false;
                for (int i = 0; i < 24; i++)
                {
                    int b = spRs485.ReadByte(); // TimeoutException 시 catch로 이동
                    if (!stx) { if (b == 0x02) stx = true; }
                    else       { if (b == 0x03) break; sb.Append((char)b); }
                }
                // sb: idChar + data (예: "1+07.487") → [1] 이후가 실제 측정값
                if (stx && sb.Length > 1)
                {
                    string dataStr = sb.ToString().Substring(1);
                    if (double.TryParse(dataStr.Trim(),
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture, out double val))
                        setVal(val);
                }
            }
            catch { }
        }

        // ── RS-485 하드웨어 영점 명령 ────────────────────────────────────
        // DI-20W: "ID{id}Z", BS-205: {idByte, 'Z'(0x5A)}
        private void ZeroLvdt()
        {
            try
            {
                if (!spRs485.IsOpen) return;
                lock (_rs485Lock)
                {
                    string id2 = GlobalValues.LvdtId.ToString("D2");
                    byte[] cmd = System.Text.Encoding.ASCII.GetBytes($"ID{id2}Z");
                    spRs485.DiscardInBuffer();
                    spRs485.Write(cmd, 0, cmd.Length);
                    Thread.Sleep(80);
                }
                Logger.Log("[영점] LVDT 영점 완료");
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

        // ── 스캐너 수신 ────────────────────────────────────────────────
        private string scanBuf = "";
        private void SpScanner_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                scanBuf += spScanner.ReadExisting();
                int idx;
                while ((idx = scanBuf.IndexOf('\r')) >= 0)
                {
                    string code = scanBuf.Substring(0, idx).Trim();
                    scanBuf = scanBuf.Substring(idx + 1);
                    if (!string.IsNullOrEmpty(code))
                        BeginInvoke(new Action(() => ApplyBarcode(code)));
                }
            }
            catch { }
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

        private const int BARCODE_PREFIX_LEN = 12;  // 앞 날짜+시퀀스 자리수

        private void ApplyBarcode(string code)
        {
            // 바코드 앞 12자리(날짜8+시퀀스4) 제거 → 품번 키 추출
            string partKey = code.Length > BARCODE_PREFIX_LEN
                           ? code.Substring(BARCODE_PREFIX_LEN)
                           : code;

            var (partNo, partName) = ClassDatabase.LookupPart(partKey);

            MeasureData1.AssyParNo = code;      // 바코드 원문 (시리얼 번호)
            MeasureData1.PartNo    = partNo ?? "";
            MeasureData1.PartName  = partName ?? "";

            lbBarcode1.Text  = code;
            lbLPartNo1.Text  = partNo   ?? "DB 미등록";
            lbPartName1.Text = partName ?? "";

            if (partNo == null)
            {
                lbLPartNo1.ForeColor = System.Drawing.Color.OrangeRed;
                srcState.Text = "DB 미등록 품번 — 검사 불가";
                Logger.Log($"[바코드] {code} | 품번키={partKey} → DB 미등록");
                return;
            }

            lbLPartNo1.ForeColor = System.Drawing.Color.White;
            _frmWorkStandard?.LoadPicture(MeasureData1.PartNo);

            if (wStep1 == 0)
            {
                _startTime = DateTime.Now;
                wStep1 = 1.0;
                workTimer1.Start();
                srcState.Text = "PUSH 버튼을 누르세요";
                cycleWatch.Restart();
                Logger.Log($"[바코드] {code} | 품번={partNo} | 품명={partName}");
            }
        }

        // ═══════════════════════════════════════════════════════════════
        // PLC 스레드
        // ═══════════════════════════════════════════════════════════════
        private void StartPlcThread()
        {
            try
            {
                plcDriver = new MelsecMxDriver(GlobalValues.PlcIpAddress, GlobalValues.PlcIpPort);
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

                try { plcDriver.WriteWords(4000, 14);  } catch { }  // D4000~D4013 출력
                try { plcDriver.WriteWords(5000, 200); } catch { }
                try { plcDriver.WriteWords(6000, 40);  } catch { }  // D6000~D6039 서보 파라미터
                Thread.Sleep(50);
            }
        }

        private void PlcReceiveLoop()
        {
            int flickerCount = 0;
            while (plcThreadRun)
            {
                try { plcDriver.ReadWords(4000, 15);  } catch { }  // D4000~D4014 (비트 입력)
                try { plcDriver.ReadWords(5000, 100); } catch { }

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
        private void tmrDisplay_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            srcLvdt1.Text    = MeasureData1.ValueLvdt.ToString("F3");
            lbLoadCell1.Text = MeasureData1.ValueLoadCell1.ToString("F2");
            lbLoadCell2.Text = MeasureData1.ValueLoadCell2.ToString("F2");
            if (cycleWatch.IsRunning)
                LbCycle1.Text = $"사이클: {cycleWatch.Elapsed.TotalSeconds:F1}s";

            // D4008.1 서보 알람
            lbServoAlarm.Visible = PLCData1.PlcValueBit[8, 1];
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
                    AddGraphPoint(lvdtNet, lc1Net);
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
                    AddGraphPoint(lvdtNet, lc2Net);
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

                    MeasureData1.AssyParNo = "";
                    MeasureData1.PartNo    = "";
                    MeasureData1.PartName  = "";
                    lbBarcode1.Text  = "";
                    lbLPartNo1.Text  = "";
                    lbLPartNo1.ForeColor = System.Drawing.Color.White;
                    lbPartName1.Text = "";
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
                serialNo:   MeasureData1.AssyParNo,
                partNo:     MeasureData1.PartNo,
                partName:   MeasureData1.PartName,
                startTime:  _startTime,
                endTime:    endTime,
                fwdDisp:    MeasureData1.FwdDisp,
                bwdDisp:    MeasureData1.BwdDisp,
                play:       MeasureData1.GapAngle,
                playSpec:   MeasureData1.GapSpec,
                pass:       pass,
                endBarcode: MeasureData1.AssyParNo);

            // CSV 저장 (기존 유지)
            string dir  = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Result",
                                       endTime.ToString("yyyyMMdd"));
            Directory.CreateDirectory(dir);
            string file = Path.Combine(dir, "result.csv");
            bool header = !File.Exists(file);
            using (var sw = new StreamWriter(file, true, System.Text.Encoding.UTF8))
            {
                if (header)
                    sw.WriteLine("DateTime,Barcode,FwdDisp_mm,BwdDisp_mm,Play_deg,Spec_deg,Judge");
                sw.WriteLine($"{endTime:yyyy-MM-dd HH:mm:ss}," +
                             $"{MeasureData1.AssyParNo}," +
                             $"{MeasureData1.FwdDisp:F3}," +
                             $"{MeasureData1.BwdDisp:F3}," +
                             $"{MeasureData1.GapAngle:F3}," +
                             $"{MeasureData1.GapSpec:F3}," +
                             $"{(pass ? "OK" : "NG")}");
            }

            AppendLog($"[{endTime:HH:mm:ss}] {MeasureData1.AssyParNo} " +
                      $"유격={MeasureData1.GapAngle:F3}° → {(pass ? "OK" : "NG")}");

            // OK 판정 시 라벨 출력
            if (pass)
            {
                try { PrintLabel(); }
                catch (Exception ex) { Logger.Log($"[프린터] 출력 실패: {ex.Message}"); }
            }
        }

        private void PrintLabel()
        {
            if (!spPrinter.IsOpen) return;

            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Labels");
            string jsonPath = Path.Combine(folder, "Barcode_1.json");
            if (!File.Exists(jsonPath)) return;

            var printer = new ClassLabelPrinter();
            printer.SetSerialPort(spPrinter);
            printer.PrintLabel(jsonPath, new System.Collections.Generic.Dictionary<string, string>
            {
                { "PartNo",   MeasureData1.AssyParNo },
                { "PartName", MeasureData1.PartName  },
                { "SerialNo", MeasureData1.AssyParNo },
                { "DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                { "Result",   "OK" }
            });
        }

        private void UpdateCountLabels()
        {
            int ng = GlobalValues.TotalCount - GlobalValues.OkCount;
            lbOkCount.Text    = GlobalValues.OkCount.ToString();
            lbNGCount.Text    = ng.ToString();
            lbTotalCount.Text = GlobalValues.TotalCount.ToString();
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
            pane.YAxis.Title.Text = $"하중 ({MeasureData1.LoadUnit})";
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
            srcState.Text = "정지";
            workTimer1.Stop();
        }

        // ═══════════════════════════════════════════════════════════════
        // 버튼 이벤트
        // ═══════════════════════════════════════════════════════════════
        private void btnBarcode_Click(object sender, EventArgs e)
        {
            using (var frm = new _FrmBarcodeSetting())
                frm.ShowDialog(this);
        }

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
