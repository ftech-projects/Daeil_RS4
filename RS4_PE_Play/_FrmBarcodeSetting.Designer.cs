namespace WindowsFormsApp1
{
    partial class _FrmBarcodeSetting
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            var bgDark    = System.Drawing.Color.FromArgb(15,  23,  42);
            var bgCard    = System.Drawing.Color.FromArgb(30,  41,  59);
            var bgCard2   = System.Drawing.Color.FromArgb(22,  32,  48);
            var colorCyan  = System.Drawing.Color.FromArgb(6,   182, 212);
            var colorMuted = System.Drawing.Color.FromArgb(148, 163, 184);
            var colorText  = System.Drawing.Color.FromArgb(226, 232, 240);
            var colorGreen = System.Drawing.Color.FromArgb(34,  197, 94);
            var colorBlue  = System.Drawing.Color.FromArgb(59,  130, 246);
            var colorSlate = System.Drawing.Color.FromArgb(51,  65,  85);

            var fontBold   = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Bold);
            var fontNormal = new System.Drawing.Font("맑은 고딕", 9F);
            var fontMono   = new System.Drawing.Font("Consolas", 9F);

            // ── 컨트롤 생성 ─────────────────────────────────────────────────
            this.panelLeft    = new System.Windows.Forms.Panel();
            this.panelRight   = new System.Windows.Forms.Panel();
            this.panelBottom  = new System.Windows.Forms.Panel();
            this.panelSample  = new System.Windows.Forms.Panel();
            this.txtZpl       = new System.Windows.Forms.TextBox();
            this.cmbPort      = new System.Windows.Forms.ComboBox();
            this.btnRefreshPort = new System.Windows.Forms.Button();
            this.chkT1 = new System.Windows.Forms.CheckBox();
            this.chkT2 = new System.Windows.Forms.CheckBox();
            this.chkT3 = new System.Windows.Forms.CheckBox();
            this.chkT4 = new System.Windows.Forms.CheckBox();
            this.nudDmX   = new System.Windows.Forms.NumericUpDown();
            this.nudDmY   = new System.Windows.Forms.NumericUpDown();
            this.nudDmMod = new System.Windows.Forms.NumericUpDown();
            this.nudT1X   = new System.Windows.Forms.NumericUpDown();
            this.nudT1Y   = new System.Windows.Forms.NumericUpDown();
            this.nudT1H   = new System.Windows.Forms.NumericUpDown();
            this.nudT1W   = new System.Windows.Forms.NumericUpDown();
            this.nudT2X   = new System.Windows.Forms.NumericUpDown();
            this.nudT2Y   = new System.Windows.Forms.NumericUpDown();
            this.nudT2H   = new System.Windows.Forms.NumericUpDown();
            this.nudT2W   = new System.Windows.Forms.NumericUpDown();
            this.nudT3X   = new System.Windows.Forms.NumericUpDown();
            this.nudT3Y   = new System.Windows.Forms.NumericUpDown();
            this.nudT3H   = new System.Windows.Forms.NumericUpDown();
            this.nudT3W   = new System.Windows.Forms.NumericUpDown();
            this.nudT4X   = new System.Windows.Forms.NumericUpDown();
            this.nudT4Y   = new System.Windows.Forms.NumericUpDown();
            this.nudT4H   = new System.Windows.Forms.NumericUpDown();
            this.nudT4W   = new System.Windows.Forms.NumericUpDown();
            this.txtBarcode  = new System.Windows.Forms.TextBox();
            this.txtPartNo   = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtSerial   = new System.Windows.Forms.TextBox();
            this.lblStatus   = new System.Windows.Forms.Label();
            this.btnPrint    = new System.Windows.Forms.Button();
            this.btnSave     = new System.Windows.Forms.Button();
            this.btnClose    = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ── NUD 공통 설정 ────────────────────────────────────────────────
            var nudAll = new (System.Windows.Forms.NumericUpDown nud, int max, int def)[]
            {
                (nudDmX,  9999, 40),  (nudDmY,  9999, 40),  (nudDmMod, 20, 8),
                (nudT1X,  9999, 300), (nudT1Y,  9999, 40),  (nudT1H, 999, 40), (nudT1W, 999, 20),
                (nudT2X,  9999, 300), (nudT2Y,  9999, 90),  (nudT2H, 999, 35), (nudT2W, 999, 18),
                (nudT3X,  9999, 300), (nudT3Y,  9999, 135), (nudT3H, 999, 30), (nudT3W, 999, 15),
                (nudT4X,  9999, 300), (nudT4Y,  9999, 170), (nudT4H, 999, 25), (nudT4W, 999, 13),
            };
            foreach (var (nud, max, def) in nudAll)
            {
                nud.Minimum     = 0;
                nud.Maximum     = max;
                nud.Value       = def;
                nud.BackColor   = bgCard2;
                nud.ForeColor   = colorText;
                nud.Font        = fontNormal;
                nud.Size        = new System.Drawing.Size(64, 24);
                nud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            nudDmMod.Size = new System.Drawing.Size(50, 24);

            // ── 헬퍼 로컬 함수 ──────────────────────────────────────────────
            System.Windows.Forms.Label SecLbl(string txt, int y)
            {
                return new System.Windows.Forms.Label
                {
                    Text = txt, Font = fontBold, ForeColor = colorCyan, BackColor = bgCard,
                    Location = new System.Drawing.Point(8, y),
                    Size = new System.Drawing.Size(322, 24),
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                };
            }

            System.Windows.Forms.Label InLbl(string txt, int x, int y)
            {
                return new System.Windows.Forms.Label
                {
                    Text = txt, Font = fontNormal, ForeColor = colorMuted, BackColor = bgCard,
                    Location = new System.Drawing.Point(x, y + 4), AutoSize = true,
                };
            }

            System.Windows.Forms.Panel HSep(int y)
            {
                return new System.Windows.Forms.Panel
                {
                    BackColor = colorSlate,
                    Location  = new System.Drawing.Point(0, y),
                    Size      = new System.Drawing.Size(340, 1),
                };
            }

            void SetChk(System.Windows.Forms.CheckBox chk, string txt, int y)
            {
                chk.Text      = txt;
                chk.Font      = fontBold;
                chk.ForeColor = colorCyan;
                chk.BackColor = bgCard;
                chk.Location  = new System.Drawing.Point(8, y);
                chk.Size      = new System.Drawing.Size(318, 24);
                chk.Checked   = true;
                chk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            }

            // ═══════════════════════════════════════════════════════════════
            // LEFT PANEL
            // ═══════════════════════════════════════════════════════════════
            this.panelLeft.BackColor = bgCard;
            this.panelLeft.Dock      = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Width     = 340;

            // 포트 섹션
            var l_portSec = SecLbl("■ 프린터 포트", 8);
            var l_portLbl = InLbl("포트:", 8, 36);
            cmbPort.Location      = new System.Drawing.Point(50, 36);
            cmbPort.Size          = new System.Drawing.Size(158, 24);
            cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbPort.BackColor     = bgCard2;
            cmbPort.ForeColor     = colorText;
            cmbPort.Font          = fontNormal;
            cmbPort.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;

            btnRefreshPort.Text      = "새로고침";
            btnRefreshPort.Font      = fontNormal;
            btnRefreshPort.BackColor = colorSlate;
            btnRefreshPort.ForeColor = colorText;
            btnRefreshPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefreshPort.FlatAppearance.BorderSize = 0;
            btnRefreshPort.Location  = new System.Drawing.Point(216, 36);
            btnRefreshPort.Size      = new System.Drawing.Size(86, 24);
            btnRefreshPort.Click    += new System.EventHandler(this.btnRefreshPort_Click);

            // DataMatrix 섹션
            var l_sep1  = HSep(64);
            var l_dmSec = SecLbl("■ DataMatrix / QR", 66);
            var l_dmX   = InLbl("X :",   8,  94); nudDmX.Location   = new System.Drawing.Point(28,  94);
            var l_dmY   = InLbl("Y :", 100,  94); nudDmY.Location   = new System.Drawing.Point(128, 94);
            var l_dmM   = InLbl("크기:", 192, 94); nudDmMod.Location = new System.Drawing.Point(222, 94);

            // 텍스트 1
            var l_sep2 = HSep(122);
            SetChk(chkT1, "텍스트 1  ─  품번 (Part No)", 124);
            var l_1X = InLbl("X :",  8, 152); nudT1X.Location = new System.Drawing.Point(28,  152);
            var l_1Y = InLbl("Y :", 100, 152); nudT1Y.Location = new System.Drawing.Point(128, 152);
            var l_1H = InLbl("H :",  8, 180); nudT1H.Location = new System.Drawing.Point(28,  180);
            var l_1W = InLbl("W :", 100, 180); nudT1W.Location = new System.Drawing.Point(128, 180);

            // 텍스트 2
            var l_sep3 = HSep(208);
            SetChk(chkT2, "텍스트 2  ─  품명 (Part Name)", 210);
            var l_2X = InLbl("X :",  8, 238); nudT2X.Location = new System.Drawing.Point(28,  238);
            var l_2Y = InLbl("Y :", 100, 238); nudT2Y.Location = new System.Drawing.Point(128, 238);
            var l_2H = InLbl("H :",  8, 266); nudT2H.Location = new System.Drawing.Point(28,  266);
            var l_2W = InLbl("W :", 100, 266); nudT2W.Location = new System.Drawing.Point(128, 266);

            // 텍스트 3
            var l_sep4 = HSep(294);
            SetChk(chkT3, "텍스트 3  ─  S/N (Serial No)", 296);
            var l_3X = InLbl("X :",  8, 324); nudT3X.Location = new System.Drawing.Point(28,  324);
            var l_3Y = InLbl("Y :", 100, 324); nudT3Y.Location = new System.Drawing.Point(128, 324);
            var l_3H = InLbl("H :",  8, 352); nudT3H.Location = new System.Drawing.Point(28,  352);
            var l_3W = InLbl("W :", 100, 352); nudT3W.Location = new System.Drawing.Point(128, 352);

            // 텍스트 4
            var l_sep5 = HSep(380);
            SetChk(chkT4, "텍스트 4  ─  날짜 (Date/Time)", 382);
            var l_4X = InLbl("X :",  8, 410); nudT4X.Location = new System.Drawing.Point(28,  410);
            var l_4Y = InLbl("Y :", 100, 410); nudT4Y.Location = new System.Drawing.Point(128, 410);
            var l_4H = InLbl("H :",  8, 438); nudT4H.Location = new System.Drawing.Point(28,  438);
            var l_4W = InLbl("W :", 100, 438); nudT4W.Location = new System.Drawing.Point(128, 438);

            this.panelLeft.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                l_portSec, l_portLbl, cmbPort, btnRefreshPort,
                l_sep1, l_dmSec, l_dmX, nudDmX, l_dmY, nudDmY, l_dmM, nudDmMod,
                l_sep2, chkT1, l_1X, nudT1X, l_1Y, nudT1Y, l_1H, nudT1H, l_1W, nudT1W,
                l_sep3, chkT2, l_2X, nudT2X, l_2Y, nudT2Y, l_2H, nudT2H, l_2W, nudT2W,
                l_sep4, chkT3, l_3X, nudT3X, l_3Y, nudT3Y, l_3H, nudT3H, l_3W, nudT3W,
                l_sep5, chkT4, l_4X, nudT4X, l_4Y, nudT4Y, l_4H, nudT4H, l_4W, nudT4W,
            });

            // ═══════════════════════════════════════════════════════════════
            // SAMPLE PANEL (panelRight 안 Dock=Top)
            // ═══════════════════════════════════════════════════════════════
            this.panelSample.BackColor = bgCard;
            this.panelSample.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelSample.Height    = 100;

            var l_smpHdr = new System.Windows.Forms.Label
            {
                Text = "샘플 데이터 (ZPL 미리보기용)", Font = fontNormal,
                ForeColor = colorMuted, BackColor = bgCard,
                Location = new System.Drawing.Point(8, 2), AutoSize = true,
            };

            void SmpField(System.Windows.Forms.TextBox tb, string lbl,
                          int lx, int tx, int y, int w, string def)
            {
                var lc = new System.Windows.Forms.Label
                {
                    Text = lbl, Font = fontNormal, ForeColor = colorMuted, BackColor = bgCard,
                    Location = new System.Drawing.Point(lx, y - 15), AutoSize = true,
                };
                tb.Text        = def;
                tb.BackColor   = bgCard2;
                tb.ForeColor   = colorText;
                tb.Font        = fontNormal;
                tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                tb.Location    = new System.Drawing.Point(tx, y);
                tb.Size        = new System.Drawing.Size(w, 24);
                tb.TextChanged += new System.EventHandler(this.txtSample_TextChanged);
                this.panelSample.Controls.Add(lc);
                this.panelSample.Controls.Add(tb);
            }

            SmpField(txtBarcode,  "바코드",  8,  52,  38, 170, "SAMPLE001");
            SmpField(txtPartNo,   "품번",   234, 260,  38, 160, "PART-001");
            SmpField(txtPartName, "품명",    8,  52,  72, 170, "샘플 품명");
            SmpField(txtSerial,   "S/N",   234, 260,  72, 160, "SN-000001");
            this.panelSample.Controls.Add(l_smpHdr);

            // ZPL 텍스트박스
            txtZpl.Multiline   = true;
            txtZpl.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            txtZpl.Font        = fontMono;
            txtZpl.BackColor   = bgDark;
            txtZpl.ForeColor   = colorCyan;
            txtZpl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtZpl.ReadOnly    = true;
            txtZpl.Dock        = System.Windows.Forms.DockStyle.Fill;
            txtZpl.Padding     = new System.Windows.Forms.Padding(8);

            var l_zplHdr = new System.Windows.Forms.Label
            {
                Text = "  ZPL 미리보기",
                Font = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Bold),
                ForeColor = colorMuted, BackColor = bgCard2,
                Dock = System.Windows.Forms.DockStyle.Top, Height = 32,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
            };
            var l_sepSZ = new System.Windows.Forms.Panel
            {
                BackColor = colorSlate,
                Dock      = System.Windows.Forms.DockStyle.Top,
                Height    = 1,
            };

            // ═══════════════════════════════════════════════════════════════
            // RIGHT PANEL
            // ═══════════════════════════════════════════════════════════════
            this.panelRight.BackColor = bgCard2;
            this.panelRight.Dock      = System.Windows.Forms.DockStyle.Fill;

            // Fill 먼저, Top은 나중 추가 (나중 추가 = 더 위에 표시)
            this.panelRight.Controls.Add(txtZpl);
            this.panelRight.Controls.Add(l_sepSZ);
            this.panelRight.Controls.Add(panelSample);
            this.panelRight.Controls.Add(l_zplHdr);

            // ═══════════════════════════════════════════════════════════════
            // BOTTOM PANEL
            // ═══════════════════════════════════════════════════════════════
            this.panelBottom.BackColor = bgDark;
            this.panelBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height    = 52;

            lblStatus.Text      = "준비";
            lblStatus.Font      = fontNormal;
            lblStatus.ForeColor = colorMuted;
            lblStatus.Location  = new System.Drawing.Point(8, 17);
            lblStatus.Size      = new System.Drawing.Size(300, 18);
            lblStatus.Anchor    = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;

            void BotBtn(System.Windows.Forms.Button b, string txt, int x,
                        System.Drawing.Color bg, System.Drawing.Color fg)
            {
                b.Text      = txt;
                b.Font      = fontBold;
                b.BackColor = bg;
                b.ForeColor = fg;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Size      = new System.Drawing.Size(100, 34);
                b.Location  = new System.Drawing.Point(x, 9);
                b.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            }

            BotBtn(btnClose, "닫  기",    851, colorSlate, colorText);
            BotBtn(btnSave,  "저  장",    743, colorBlue,  System.Drawing.Color.White);
            BotBtn(btnPrint, "테스트 출력", 627, colorGreen, System.Drawing.Color.White);
            btnPrint.Size = new System.Drawing.Size(108, 34);

            btnClose.Click += new System.EventHandler(this.btnClose_Click);
            btnSave.Click  += new System.EventHandler(this.btnSave_Click);
            btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            this.panelBottom.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblStatus, btnClose, btnSave, btnPrint,
            });

            // ═══════════════════════════════════════════════════════════════
            // FORM
            // ═══════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = bgCard2;
            this.ClientSize          = new System.Drawing.Size(960, 540);
            this.Font                = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize         = new System.Drawing.Size(700, 500);
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "바코드 라벨 설정";

            // Fill 먼저, Dock=Left/Bottom은 나중에 추가
            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);
            this.Controls.Add(panelBottom);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel    panelLeft;
        private System.Windows.Forms.Panel    panelRight;
        private System.Windows.Forms.Panel    panelBottom;
        private System.Windows.Forms.Panel    panelSample;
        private System.Windows.Forms.TextBox  txtZpl;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Button   btnRefreshPort;
        private System.Windows.Forms.CheckBox chkT1;
        private System.Windows.Forms.CheckBox chkT2;
        private System.Windows.Forms.CheckBox chkT3;
        private System.Windows.Forms.CheckBox chkT4;
        private System.Windows.Forms.NumericUpDown nudDmX;
        private System.Windows.Forms.NumericUpDown nudDmY;
        private System.Windows.Forms.NumericUpDown nudDmMod;
        private System.Windows.Forms.NumericUpDown nudT1X;
        private System.Windows.Forms.NumericUpDown nudT1Y;
        private System.Windows.Forms.NumericUpDown nudT1H;
        private System.Windows.Forms.NumericUpDown nudT1W;
        private System.Windows.Forms.NumericUpDown nudT2X;
        private System.Windows.Forms.NumericUpDown nudT2Y;
        private System.Windows.Forms.NumericUpDown nudT2H;
        private System.Windows.Forms.NumericUpDown nudT2W;
        private System.Windows.Forms.NumericUpDown nudT3X;
        private System.Windows.Forms.NumericUpDown nudT3Y;
        private System.Windows.Forms.NumericUpDown nudT3H;
        private System.Windows.Forms.NumericUpDown nudT3W;
        private System.Windows.Forms.NumericUpDown nudT4X;
        private System.Windows.Forms.NumericUpDown nudT4Y;
        private System.Windows.Forms.NumericUpDown nudT4H;
        private System.Windows.Forms.NumericUpDown nudT4W;
        private System.Windows.Forms.TextBox  txtBarcode;
        private System.Windows.Forms.TextBox  txtPartNo;
        private System.Windows.Forms.TextBox  txtPartName;
        private System.Windows.Forms.TextBox  txtSerial;
        private System.Windows.Forms.Label    lblStatus;
        private System.Windows.Forms.Button   btnPrint;
        private System.Windows.Forms.Button   btnSave;
        private System.Windows.Forms.Button   btnClose;
    }
}
