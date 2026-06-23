namespace WindowsFormsApp1
{
    partial class _FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.panelHeader      = new System.Windows.Forms.Panel();
            this.lblTitle         = new System.Windows.Forms.Label();
            this.lblDateTime      = new System.Windows.Forms.Label();
            this.srcState         = new System.Windows.Forms.Label();
            this.lbServoAlarm     = new System.Windows.Forms.Label();
            this.LbCycle1         = new System.Windows.Forms.Label();
            this.btnBarcode       = new System.Windows.Forms.Button();
            this.btnConfig        = new System.Windows.Forms.Button();
            this.btnSignal        = new System.Windows.Forms.Button();
            this.btnPartMgr       = new System.Windows.Forms.Button();
            this.panelIconArea    = new System.Windows.Forms.Panel();
            this.lblSubTitle      = new System.Windows.Forms.Label();
            this.toolTip1         = new System.Windows.Forms.ToolTip(this.components);

            this.panelLog         = new System.Windows.Forms.Panel();
            this.lblOk            = new System.Windows.Forms.Label();
            this.lbOkCount        = new System.Windows.Forms.Label();
            this.lblNg            = new System.Windows.Forms.Label();
            this.lbNGCount        = new System.Windows.Forms.Label();
            this.lblTotal         = new System.Windows.Forms.Label();
            this.lbTotalCount     = new System.Windows.Forms.Label();
            this.btnCountReset    = new System.Windows.Forms.Button();
            this.lbGapJudge1      = new System.Windows.Forms.Label();
            this.srcTxtLog        = new System.Windows.Forms.TextBox();

            this.panelMain        = new System.Windows.Forms.Panel();
            this.panelBanner      = new System.Windows.Forms.Panel();
            this.lblBarcodeTitle  = new System.Windows.Forms.Label();
            this.lbBarcode1       = new System.Windows.Forms.Label();
            this.lblPartNoTitle   = new System.Windows.Forms.Label();
            this.lbLPartNo1       = new System.Windows.Forms.Label();
            this.lblPartNameTitle = new System.Windows.Forms.Label();
            this.lbPartName1      = new System.Windows.Forms.Label();

            this.panelSensor      = new System.Windows.Forms.Panel();
            this.lblLvdtH         = new System.Windows.Forms.Label();
            this.srcLvdt1         = new System.Windows.Forms.Label();
            this.lblLC1H          = new System.Windows.Forms.Label();
            this.lbLoadCell1      = new System.Windows.Forms.Label();
            this.lblLC2H          = new System.Windows.Forms.Label();
            this.lbLoadCell2      = new System.Windows.Forms.Label();

            this.PlotDiff1        = new ZedGraph.ZedGraphControl();

            this.panelResult      = new System.Windows.Forms.Panel();
            this.lblFwdDisp       = new System.Windows.Forms.Label();
            this.lbFwdDispMeasure1= new System.Windows.Forms.Label();
            this.lbFwdDisp1       = new System.Windows.Forms.Label();
            this.lblBwdDisp       = new System.Windows.Forms.Label();
            this.lbBwdDispMeasure1= new System.Windows.Forms.Label();
            this.lbBwdDisp1       = new System.Windows.Forms.Label();
            this.lblGapAngle      = new System.Windows.Forms.Label();
            this.lbGapAngleMeasure1 = new System.Windows.Forms.Label();
            this.lblSpec          = new System.Windows.Forms.Label();
            this.lbGapSpec1       = new System.Windows.Forms.Label();
            this.lbGapAngle1      = new System.Windows.Forms.Label();
            this.lblJudge         = new System.Windows.Forms.Label();

            this.workTimer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrDisplay = new System.Windows.Forms.Timer(this.components);

            // ── 색상 ──────────────────────────────────────────────────────
            var bgDark     = System.Drawing.Color.FromArgb(15,  23,  42);
            var bgCard     = System.Drawing.Color.FromArgb(30,  41,  59);
            var bgCard2    = System.Drawing.Color.FromArgb(22,  32,  48);
            var colorCyan  = System.Drawing.Color.FromArgb(6,   182, 212);
            var colorText  = System.Drawing.Color.FromArgb(241, 245, 249);
            var colorMuted = System.Drawing.Color.FromArgb(148, 163, 184);
            var colorBorder= System.Drawing.Color.FromArgb(51,  65,  85);
            var colorGreen = System.Drawing.Color.FromArgb(34,  197, 94);
            var colorRed   = System.Drawing.Color.FromArgb(239, 68,  68);
            var colorBlue  = System.Drawing.Color.FromArgb(30,  64,  175);
            var colorSlate = System.Drawing.Color.FromArgb(51,  65,  85);

            // ── 폰트 ──────────────────────────────────────────────────────
            var fontJudge = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Bold);
            var fontBig   = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold);
            var fontMid   = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            var fontNorm  = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            var fontSmall = new System.Drawing.Font("맑은 고딕", 11F);
            var fontTiny  = new System.Drawing.Font("맑은 고딕", 9F);
            var fontMono  = new System.Drawing.Font("Consolas",  9F);

            this.panelHeader.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelBanner.SuspendLayout();
            this.panelSensor.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════════
            // 헤더 (80px) — Dock=Top
            // ══════════════════════════════════════════════════════════════
            this.panelHeader.BackColor = bgDark;
            this.panelHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height    = 80;

            // 파란 아이콘 패널 (좌측)
            this.panelIconArea.BackColor = colorBlue;
            this.panelIconArea.Location  = new System.Drawing.Point(6, 14);
            this.panelIconArea.Size      = new System.Drawing.Size(52, 52);
            this.panelIconArea.Paint    += (s, pe) =>
            {
                pe.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                using (var f2 = new System.Drawing.Font("Segoe MDL2 Assets", 22F))
                using (var b2 = new System.Drawing.SolidBrush(System.Drawing.Color.White))
                {
                    var rc = new System.Drawing.RectangleF(0, 0, 52, 52);
                    var sf = new System.Drawing.StringFormat
                    {
                        Alignment     = System.Drawing.StringAlignment.Center,
                        LineAlignment = System.Drawing.StringAlignment.Center
                    };
                    pe.Graphics.DrawString("", f2, b2, rc, sf);
                }
            };

            this.lblTitle.Text      = "유격 검사기";
            this.lblTitle.Font      = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = colorText;
            this.lblTitle.Location  = new System.Drawing.Point(68, 14);
            this.lblTitle.Size      = new System.Drawing.Size(220, 26);

            this.lblSubTitle.Text      = "DAEIL  -  v1.0";
            this.lblSubTitle.Font      = fontTiny;
            this.lblSubTitle.ForeColor = colorMuted;
            this.lblSubTitle.Location  = new System.Drawing.Point(68, 42);
            this.lblSubTitle.Size      = new System.Drawing.Size(160, 16);

            this.srcState.Font      = new System.Drawing.Font("맑은 고딕", 11F);
            this.srcState.ForeColor = colorCyan;
            this.srcState.Location  = new System.Drawing.Point(310, 28);
            this.srcState.Size      = new System.Drawing.Size(560, 22);
            this.srcState.Text      = "바코드 스캔 대기 중...";

            this.lbServoAlarm.Font      = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lbServoAlarm.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbServoAlarm.BackColor = System.Drawing.Color.Transparent;
            this.lbServoAlarm.Location  = new System.Drawing.Point(310, 54);
            this.lbServoAlarm.Size      = new System.Drawing.Size(200, 18);
            this.lbServoAlarm.Text      = "⚠ 서보 알람";
            this.lbServoAlarm.Visible   = false;

            this.LbCycle1.Font      = fontTiny;
            this.LbCycle1.ForeColor = colorMuted;
            this.LbCycle1.Location  = new System.Drawing.Point(880, 30);
            this.LbCycle1.Size      = new System.Drawing.Size(180, 18);
            this.LbCycle1.Anchor    = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;

            this.lblDateTime.Font      = fontTiny;
            this.lblDateTime.ForeColor = colorMuted;
            this.lblDateTime.Location  = new System.Drawing.Point(1064, 30);
            this.lblDateTime.Size      = new System.Drawing.Size(150, 18);
            this.lblDateTime.Anchor    = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 헤더 우측 아이콘 버튼 (아이콘 + 명칭 Paint 렌더링)
            this.btnBarcode.Tag = new string[] { "", "바코드" };
            this.btnConfig.Tag  = new string[] { "", "설정" };
            this.btnPartMgr.Tag = new string[] { "📋", "품번관리" };
            this.btnSignal.Tag  = new string[] { "", "신호" };

            System.Windows.Forms.PaintEventHandler hdrBtnPaint = (s, pe) =>
            {
                var btn  = (System.Windows.Forms.Button)s;
                var info = (string[])btn.Tag;
                pe.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                var sf = new System.Drawing.StringFormat {
                    Alignment     = System.Drawing.StringAlignment.Center,
                    LineAlignment = System.Drawing.StringAlignment.Center,
                    FormatFlags   = System.Drawing.StringFormatFlags.NoWrap
                };
                using (var iconFont = new System.Drawing.Font("Segoe MDL2 Assets", 20F))
                using (var nameFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold))
                using (var br = new System.Drawing.SolidBrush(btn.ForeColor))
                {
                    pe.Graphics.DrawString(info[0], iconFont, br,
                        new System.Drawing.RectangleF(0, 0, btn.Width, btn.Height * 0.60f), sf);
                    pe.Graphics.DrawString(info[1], nameFont, br,
                        new System.Drawing.RectangleF(0, btn.Height * 0.60f, btn.Width, btn.Height * 0.40f), sf);
                }
            };

            var hdrBtns = new System.Windows.Forms.Button[]
                { this.btnBarcode, this.btnConfig, this.btnPartMgr, this.btnSignal };
            for (int i = 0; i < hdrBtns.Length; i++)
            {
                hdrBtns[i].Text      = "";
                hdrBtns[i].BackColor = bgDark;
                hdrBtns[i].ForeColor = colorMuted;
                hdrBtns[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                hdrBtns[i].FlatAppearance.BorderSize = 0;
                hdrBtns[i].FlatAppearance.MouseOverBackColor = bgCard;
                hdrBtns[i].Size      = new System.Drawing.Size(150, 72);
                hdrBtns[i].Location  = new System.Drawing.Point(1300 + i * 154, 4);
                hdrBtns[i].Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
                hdrBtns[i].Cursor    = System.Windows.Forms.Cursors.Hand;
                hdrBtns[i].Paint    += hdrBtnPaint;
            }
            this.toolTip1.SetToolTip(this.btnBarcode, "바코드 라벨 설정");
            this.toolTip1.SetToolTip(this.btnConfig,  "환경설정");
            this.toolTip1.SetToolTip(this.btnPartMgr, "품번 관리");
            this.toolTip1.SetToolTip(this.btnSignal,  "시그널 모니터");
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            this.btnConfig.Click  += new System.EventHandler(this.btnConfig_Click);
            this.btnPartMgr.Click += new System.EventHandler(this.btnPartMgr_Click);
            this.btnSignal.Click  += new System.EventHandler(this.btnSignal_Click);

            this.panelHeader.Controls.Add(this.panelIconArea);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubTitle);
            this.panelHeader.Controls.Add(this.srcState);
            this.panelHeader.Controls.Add(this.lbServoAlarm);
            this.panelHeader.Controls.Add(this.LbCycle1);
            this.panelHeader.Controls.Add(this.lblDateTime);
            this.panelHeader.Controls.Add(this.btnBarcode);
            this.panelHeader.Controls.Add(this.btnConfig);
            this.panelHeader.Controls.Add(this.btnPartMgr);
            this.panelHeader.Controls.Add(this.btnSignal);

            // ══════════════════════════════════════════════════════════════
            // 우측 패널 — 수량 + 최종 결과 + LOG (300px, Dock=Right)
            // ══════════════════════════════════════════════════════════════
            this.panelLog.BackColor = bgCard;
            this.panelLog.Dock      = System.Windows.Forms.DockStyle.Right;
            this.panelLog.Width     = 300;

            System.Drawing.Drawing2D.GraphicsPath RoundedPath(System.Drawing.Rectangle b, int r)
            {
                var gp = new System.Drawing.Drawing2D.GraphicsPath();
                int d = r * 2;
                gp.AddArc(b.X, b.Y, d, d, 180, 90);
                gp.AddArc(b.Right - d, b.Y, d, d, 270, 90);
                gp.AddArc(b.Right - d, b.Bottom - d, d, d, 0, 90);
                gp.AddArc(b.X, b.Bottom - d, d, d, 90, 90);
                gp.CloseFigure();
                return gp;
            }

            var countItems = new (System.Windows.Forms.Label h, System.Windows.Forms.Label v, string name, System.Drawing.Color accent, int top)[]
            {
                (this.lblOk,    this.lbOkCount,    "OK 수량",   colorGreen, 8),
                (this.lblNg,    this.lbNGCount,    "NG 수량",   colorRed,   100),
                (this.lblTotal, this.lbTotalCount, "전체 수량", colorText,  192),
            };
            foreach (var ci in countItems)
            {
                var card = new System.Windows.Forms.Panel();
                card.BackColor = bgCard2;
                card.Location  = new System.Drawing.Point(8, ci.top);
                card.Size      = new System.Drawing.Size(284, 84);
                card.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
                card.Region    = new System.Drawing.Region(RoundedPath(new System.Drawing.Rectangle(0, 0, 284, 84), 10));

                ci.h.Text      = ci.name;
                ci.h.Font      = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
                ci.h.ForeColor = ci.accent;
                ci.h.BackColor = bgCard2;
                ci.h.Location  = new System.Drawing.Point(0, 0);
                ci.h.Size      = new System.Drawing.Size(284, 30);
                ci.h.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
                ci.h.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

                ci.v.Text      = "0";
                ci.v.Font      = fontBig;
                ci.v.ForeColor = ci.accent;
                ci.v.BackColor = bgCard2;
                ci.v.Location  = new System.Drawing.Point(0, 30);
                ci.v.Size      = new System.Drawing.Size(284, 54);
                ci.v.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                ci.v.Anchor    = ci.h.Anchor;

                card.Controls.Add(ci.h);
                card.Controls.Add(ci.v);
                this.panelLog.Controls.Add(card);
            }

            this.btnCountReset.Text      = "수량 리셋";
            this.btnCountReset.Font      = fontTiny;
            this.btnCountReset.BackColor = colorSlate;
            this.btnCountReset.ForeColor = colorMuted;
            this.btnCountReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCountReset.FlatAppearance.BorderSize = 0;
            this.btnCountReset.Location  = new System.Drawing.Point(8, 284);
            this.btnCountReset.Size      = new System.Drawing.Size(284, 30);
            this.btnCountReset.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnCountReset.Region    = new System.Drawing.Region(RoundedPath(new System.Drawing.Rectangle(0, 0, 284, 30), 8));
            this.btnCountReset.Click    += new System.EventHandler(this.btnCountReset_Click);

            var cardFinal = new System.Windows.Forms.Panel();
            cardFinal.BackColor = bgCard2;
            cardFinal.Location  = new System.Drawing.Point(8, 288);
            cardFinal.Size      = new System.Drawing.Size(284, 146);
            cardFinal.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cardFinal.Region    = new System.Drawing.Region(RoundedPath(new System.Drawing.Rectangle(0, 0, 284, 146), 10));

            var lblFinalTitle = new System.Windows.Forms.Label();
            lblFinalTitle.Text      = "최종 결과";
            lblFinalTitle.Font      = fontTiny;
            lblFinalTitle.ForeColor = colorMuted;
            lblFinalTitle.BackColor = bgCard2;
            lblFinalTitle.Location  = new System.Drawing.Point(0, 0);
            lblFinalTitle.Size      = new System.Drawing.Size(284, 22);
            lblFinalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblFinalTitle.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lbGapJudge1.Text      = "대기";
            this.lbGapJudge1.Font      = fontJudge;
            this.lbGapJudge1.ForeColor = colorMuted;
            this.lbGapJudge1.BackColor = bgCard2;
            this.lbGapJudge1.Location  = new System.Drawing.Point(0, 22);
            this.lbGapJudge1.Size      = new System.Drawing.Size(284, 120);
            this.lbGapJudge1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbGapJudge1.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            cardFinal.Controls.Add(lblFinalTitle);
            cardFinal.Controls.Add(this.lbGapJudge1);

            var lblLogTitle = new System.Windows.Forms.Label();
            lblLogTitle.Text      = "# LOG";
            lblLogTitle.Font      = fontTiny;
            lblLogTitle.ForeColor = colorCyan;
            lblLogTitle.BackColor = bgCard;
            lblLogTitle.Location  = new System.Drawing.Point(8, 442);
            lblLogTitle.Size      = new System.Drawing.Size(284, 20);
            lblLogTitle.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.srcTxtLog.Multiline   = true;
            this.srcTxtLog.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.srcTxtLog.Font        = fontMono;
            this.srcTxtLog.BackColor   = System.Drawing.Color.FromArgb(15, 23, 42);
            this.srcTxtLog.ForeColor   = colorMuted;
            this.srcTxtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.srcTxtLog.Location    = new System.Drawing.Point(8, 462);
            this.srcTxtLog.Size        = new System.Drawing.Size(284, 100);
            this.srcTxtLog.ReadOnly    = true;
            this.srcTxtLog.Anchor      = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;

            this.panelLog.Controls.Add(this.btnCountReset);
            this.panelLog.Controls.Add(cardFinal);
            this.panelLog.Controls.Add(lblLogTitle);
            this.panelLog.Controls.Add(this.srcTxtLog);

            // ══════════════════════════════════════════════════════════════
            // 메인 패널 — Dock=Fill (나머지 공간 전부)
            // ══════════════════════════════════════════════════════════════
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.panelMain.Dock      = System.Windows.Forms.DockStyle.Fill;

            // ─ 바코드 배너 카드 ─────────────────────────────────────────
            this.panelBanner.BackColor = bgCard;
            this.panelBanner.Location  = new System.Drawing.Point(8, 8);
            this.panelBanner.Size      = new System.Drawing.Size(100, 90);
            this.panelBanner.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblBarcodeTitle.Text      = "바코드";
            this.lblBarcodeTitle.Font      = fontSmall;
            this.lblBarcodeTitle.ForeColor = colorMuted;
            this.lblBarcodeTitle.BackColor = bgCard;
            this.lblBarcodeTitle.Location  = new System.Drawing.Point(16, 4);
            this.lblBarcodeTitle.AutoSize  = true;

            this.lbBarcode1.Text      = "바코드 스캔 대기중...";
            this.lbBarcode1.Font      = fontMid;
            this.lbBarcode1.ForeColor = colorCyan;
            this.lbBarcode1.BackColor = bgCard;
            this.lbBarcode1.Location  = new System.Drawing.Point(16, 26);
            this.lbBarcode1.Size      = new System.Drawing.Size(420, 50);
            this.lbBarcode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbBarcode1.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            this.lblPartNoTitle.Text      = "품번";
            this.lblPartNoTitle.Font      = fontSmall;
            this.lblPartNoTitle.ForeColor = colorMuted;
            this.lblPartNoTitle.BackColor = bgCard;
            this.lblPartNoTitle.Location  = new System.Drawing.Point(456, 4);
            this.lblPartNoTitle.AutoSize  = true;

            this.lbLPartNo1.Text      = "---";
            this.lbLPartNo1.Font      = fontMid;
            this.lbLPartNo1.ForeColor = colorText;
            this.lbLPartNo1.BackColor = bgCard;
            this.lbLPartNo1.Location  = new System.Drawing.Point(456, 26);
            this.lbLPartNo1.Size      = new System.Drawing.Size(320, 50);
            this.lbLPartNo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbLPartNo1.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;

            this.lblPartNameTitle.Text      = "품명";
            this.lblPartNameTitle.Font      = fontSmall;
            this.lblPartNameTitle.ForeColor = colorMuted;
            this.lblPartNameTitle.BackColor = bgCard;
            this.lblPartNameTitle.Location  = new System.Drawing.Point(796, 4);
            this.lblPartNameTitle.AutoSize  = true;

            this.lbPartName1.Text      = "---";
            this.lbPartName1.Font      = fontMid;
            this.lbPartName1.ForeColor = colorText;
            this.lbPartName1.BackColor = bgCard;
            this.lbPartName1.Location  = new System.Drawing.Point(796, 26);
            this.lbPartName1.Size      = new System.Drawing.Size(400, 50);
            this.lbPartName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbPartName1.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.panelBanner.Controls.Add(this.lblBarcodeTitle);
            this.panelBanner.Controls.Add(this.lbBarcode1);
            this.panelBanner.Controls.Add(this.lblPartNoTitle);
            this.panelBanner.Controls.Add(this.lbLPartNo1);
            this.panelBanner.Controls.Add(this.lblPartNameTitle);
            this.panelBanner.Controls.Add(this.lbPartName1);

            // ─ 센서 카드 ──────────────────────────────────────────────
            this.panelSensor.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.panelSensor.Location  = new System.Drawing.Point(8, 106);
            this.panelSensor.Size      = new System.Drawing.Size(100, 96);
            this.panelSensor.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            var sensors = new (System.Windows.Forms.Label h, System.Windows.Forms.Label v, string title, int x)[]
            {
                (this.lblLvdtH,  this.srcLvdt1,    "LVDT (mm)",        0),
                (this.lblLC1H,   this.lbLoadCell1, "1번 로드셀 (kgf)", 228),
                (this.lblLC2H,   this.lbLoadCell2, "2번 로드셀 (kgf)", 456),
            };
            foreach (var s in sensors)
            {
                s.h.Text      = s.title;
                s.h.Font      = fontTiny;
                s.h.ForeColor = colorMuted;
                s.h.BackColor = bgCard;
                s.h.Location  = new System.Drawing.Point(s.x, 0);
                s.h.Size      = new System.Drawing.Size(220, 22);
                s.h.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);

                s.v.Text      = "0.000";
                s.v.Font      = new System.Drawing.Font("맑은 고딕", 28F, System.Drawing.FontStyle.Bold);
                s.v.ForeColor = System.Drawing.Color.FromArgb(6, 182, 212);
                s.v.BackColor = bgCard;
                s.v.Location  = new System.Drawing.Point(s.x, 22);
                s.v.Size      = new System.Drawing.Size(220, 66);
                s.v.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            }

            this.panelSensor.Controls.Add(this.lblLvdtH);
            this.panelSensor.Controls.Add(this.srcLvdt1);
            this.panelSensor.Controls.Add(this.lblLC1H);
            this.panelSensor.Controls.Add(this.lbLoadCell1);
            this.panelSensor.Controls.Add(this.lblLC2H);
            this.panelSensor.Controls.Add(this.lbLoadCell2);

            // ─ ZedGraph ───────────────────────────────────────────────
            this.PlotDiff1.Location    = new System.Drawing.Point(8, 210);
            this.PlotDiff1.Size        = new System.Drawing.Size(100, 100);
            this.PlotDiff1.Anchor      = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.PlotDiff1.ScrollGrace = 0D;
            this.PlotDiff1.ScrollMaxX  = 0D;
            this.PlotDiff1.ScrollMaxY  = 0D;
            this.PlotDiff1.ScrollMinX  = 0D;
            this.PlotDiff1.ScrollMinY  = 0D;

            // ─ 결과 카드 패널 ─────────────────────────────────────────
            this.panelResult.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.panelResult.Location  = new System.Drawing.Point(8, 100);
            this.panelResult.Size      = new System.Drawing.Size(100, 180);
            this.panelResult.Anchor    = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;

            const int CARD_W   = 440;
            const int CARD_GAP = 12;

            var resultCards = new (System.Windows.Forms.Label h, System.Windows.Forms.Label v, string title, int x)[]
            {
                (this.lblFwdDisp,  this.lbFwdDispMeasure1,  "전진 변위 (mm)", 0),
                (this.lblBwdDisp,  this.lbBwdDispMeasure1,  "후진 변위 (mm)", CARD_W + CARD_GAP),
                (this.lblGapAngle, this.lbGapAngleMeasure1, "유격 (°)",       (CARD_W + CARD_GAP) * 2),
            };
            foreach (var rc in resultCards)
            {
                rc.h.Text      = rc.title;
                rc.h.Font      = fontMid;
                rc.h.ForeColor = colorMuted;
                rc.h.BackColor = bgCard;
                rc.h.Location  = new System.Drawing.Point(rc.x, 0);
                rc.h.Size      = new System.Drawing.Size(CARD_W, 40);
                rc.h.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                rc.v.Text      = "---";
                rc.v.Font      = fontBig;
                rc.v.ForeColor = System.Drawing.Color.FromArgb(6, 182, 212);
                rc.v.BackColor = bgCard;
                rc.v.Location  = new System.Drawing.Point(rc.x, 40);
                rc.v.Size      = new System.Drawing.Size(CARD_W, 132);
                rc.v.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            }
            this.lbGapAngleMeasure1.Size      = new System.Drawing.Size(CARD_W, 80);
            this.lbGapAngleMeasure1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            int gapX = (CARD_W + CARD_GAP) * 2;
            this.lblSpec.Text      = "SPEC ≤";
            this.lblSpec.Font      = fontMid;
            this.lblSpec.ForeColor = colorMuted;
            this.lblSpec.BackColor = bgCard;
            this.lblSpec.Location  = new System.Drawing.Point(gapX, 122);
            this.lblSpec.Size      = new System.Drawing.Size(110, 50);
            this.lblSpec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lbGapSpec1.Font      = fontBig;
            this.lbGapSpec1.ForeColor = colorText;
            this.lbGapSpec1.BackColor = bgCard;
            this.lbGapSpec1.Location  = new System.Drawing.Point(gapX + 114, 122);
            this.lbGapSpec1.Size      = new System.Drawing.Size(CARD_W - 114, 50);
            this.lbGapSpec1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lbGapAngle1.Size = new System.Drawing.Size(0, 0);
            this.lbFwdDisp1.Size  = new System.Drawing.Size(0, 0);
            this.lbBwdDisp1.Size  = new System.Drawing.Size(0, 0);
            this.lblJudge.Size    = new System.Drawing.Size(0, 0);

            // ─ 유격 공식 레이블 ────────────────────────────────────────
            this.lblFormula = new System.Windows.Forms.Label();
            this.lblFormula.Text      = "변위 (mm)  /  L  ×  180° / π";
            this.lblFormula.Font      = fontSmall;
            this.lblFormula.ForeColor = System.Drawing.Color.FromArgb(94, 234, 212);
            this.lblFormula.BackColor = System.Drawing.Color.FromArgb(15, 30, 35);
            this.lblFormula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormula.Location  = new System.Drawing.Point(0, 176);
            this.lblFormula.Size      = new System.Drawing.Size(100, 40);

            this.panelResult.Controls.Add(this.lblFormula);
            this.panelResult.Controls.Add(this.lblFwdDisp);
            this.panelResult.Controls.Add(this.lbFwdDispMeasure1);
            this.panelResult.Controls.Add(this.lbFwdDisp1);
            this.panelResult.Controls.Add(this.lblBwdDisp);
            this.panelResult.Controls.Add(this.lbBwdDispMeasure1);
            this.panelResult.Controls.Add(this.lbBwdDisp1);
            this.panelResult.Controls.Add(this.lblGapAngle);
            this.panelResult.Controls.Add(this.lbGapAngleMeasure1);
            this.panelResult.Controls.Add(this.lbGapAngle1);
            this.panelResult.Controls.Add(this.lblSpec);
            this.panelResult.Controls.Add(this.lbGapSpec1);
            this.panelResult.Controls.Add(this.lblJudge);

            this.panelMain.Controls.Add(this.panelBanner);
            this.panelMain.Controls.Add(this.panelSensor);
            this.panelMain.Controls.Add(this.PlotDiff1);
            this.panelMain.Controls.Add(this.panelResult);

            // ── 타이머 ─────────────────────────────────────────────────
            this.workTimer1.Interval = 100;
            this.workTimer1.Tick    += new System.EventHandler(this.workTimer1_Tick);

            this.tmrDisplay.Interval = 200;
            this.tmrDisplay.Tick    += new System.EventHandler(this.tmrDisplay_Tick);

            // ── Form ───────────────────────────────────────────────────
            this.AutoScaleMode   = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor       = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize      = new System.Drawing.Size(1920, 1040);
            this.Font            = new System.Drawing.Font("맑은 고딕", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name            = "_FrmMain";
            this.Text            = "유격 검사기";
            this.WindowState     = System.Windows.Forms.FormWindowState.Maximized;

            // Controls 추가 순서 중요: Dock=Right/Left 먼저, Dock=Fill 나중
            this.Controls.Add(this.panelMain);   // Fill
            this.Controls.Add(this.panelLog);    // Right
            this.Controls.Add(this.panelHeader); // Top

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelLog.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelBanner.ResumeLayout(false);
            this.panelBanner.PerformLayout();
            this.panelSensor.ResumeLayout(false);
            this.panelResult.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── 컨트롤 선언 ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel   panelHeader;
        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblDateTime;
        private System.Windows.Forms.Label   srcState;
        private System.Windows.Forms.Label   lbServoAlarm;
        private System.Windows.Forms.Label   LbCycle1;
        private System.Windows.Forms.Button  btnBarcode;
        private System.Windows.Forms.Button  btnConfig;
        private System.Windows.Forms.Button  btnSignal;
        private System.Windows.Forms.Button  btnPartMgr;
        private System.Windows.Forms.Panel   panelIconArea;
        private System.Windows.Forms.Label   lblSubTitle;
        private System.Windows.Forms.ToolTip toolTip1;

        private System.Windows.Forms.Panel   panelLog;
        private System.Windows.Forms.Label   lblOk;
        private System.Windows.Forms.Label   lbOkCount;
        private System.Windows.Forms.Label   lblNg;
        private System.Windows.Forms.Label   lbNGCount;
        private System.Windows.Forms.Label   lblTotal;
        private System.Windows.Forms.Label   lbTotalCount;
        private System.Windows.Forms.Button  btnCountReset;
        private System.Windows.Forms.Label   lbGapJudge1;
        private System.Windows.Forms.TextBox srcTxtLog;

        private System.Windows.Forms.Panel   panelMain;
        private System.Windows.Forms.Panel   panelBanner;
        private System.Windows.Forms.Label   lblBarcodeTitle;
        private System.Windows.Forms.Label   lbBarcode1;
        private System.Windows.Forms.Label   lblPartNoTitle;
        private System.Windows.Forms.Label   lbLPartNo1;
        private System.Windows.Forms.Label   lblPartNameTitle;
        private System.Windows.Forms.Label   lbPartName1;

        private System.Windows.Forms.Panel   panelSensor;
        private System.Windows.Forms.Label   lblLvdtH;
        private System.Windows.Forms.Label   srcLvdt1;
        private System.Windows.Forms.Label   lblLC1H;
        private System.Windows.Forms.Label   lbLoadCell1;
        private System.Windows.Forms.Label   lblLC2H;
        private System.Windows.Forms.Label   lbLoadCell2;

        private ZedGraph.ZedGraphControl     PlotDiff1;

        private System.Windows.Forms.Panel   panelResult;
        private System.Windows.Forms.Label   lblFwdDisp;
        private System.Windows.Forms.Label   lbFwdDispMeasure1;
        private System.Windows.Forms.Label   lbFwdDisp1;
        private System.Windows.Forms.Label   lblBwdDisp;
        private System.Windows.Forms.Label   lbBwdDispMeasure1;
        private System.Windows.Forms.Label   lbBwdDisp1;
        private System.Windows.Forms.Label   lblGapAngle;
        private System.Windows.Forms.Label   lbGapAngleMeasure1;
        private System.Windows.Forms.Label   lblSpec;
        private System.Windows.Forms.Label   lbGapSpec1;
        private System.Windows.Forms.Label   lbGapAngle1;
        private System.Windows.Forms.Label   lblJudge;
        private System.Windows.Forms.Label   lblFormula;

        private System.Windows.Forms.Timer   workTimer1;
        private System.Windows.Forms.Timer   tmrDisplay;
    }
}
