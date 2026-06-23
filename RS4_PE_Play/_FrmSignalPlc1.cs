using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ResisterTest
{
    public partial class _FrmSignalPlc1 : Form
    {
        private Dictionary<string, string> signalNames = new Dictionary<string, string>();
        private System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();

        Label[]  labels_Input  = new Label[16];   // D4000 (1워드)
        Label[]  labels_4001   = new Label[16];   // D4001 (1워드)
        Label[]  labels_Output = new Label[16];   // D4004 (1워드)
        Button[] forceBtns     = new Button[16];

        Label[] labels_4008 = new Label[16];
        Label[] labels_4009 = new Label[16];
        Label[] labels_4012 = new Label[16];
        Label[] labels_4014 = new Label[16];

        int InStartWord  = 4000;
        int OutStartWord = 4004;

        private readonly Dictionary<int, Dictionary<int, string>> bitNames =
            new Dictionary<int, Dictionary<int, string>>
        {
            [4008] = new Dictionary<int, string>
            {
                [0]  = "플리커",
                [1]  = "서보 알람",
                [2]  = "홈 포지션 완료",
                [3]  = "자동",
                [4]  = "수동",
                [5]  = "비상 정지",
                [6]  = "수동 정지 완료",
                [7]  = "서보 온",
                [10] = "CW LIM",
                [11] = "CCW LIM",
                [12] = "HOME"
            },
            [4009] = new Dictionary<int, string>
            {
                [0] = "플리커",
                [1] = "CW",
                [2] = "CCW",
                [3] = "에러 리셋",
                [4] = "홈 포지션 지령",
                [5] = "자동",
                [6] = "수동",
                [7] = "수동 정지 지령",
                [8] = "비상 정지",
                [9] = "서보 온"
            },
            [4012] = new Dictionary<int, string>
            {
                [0] = "포지션 1 지령", [1] = "포지션 2 지령",
                [2] = "포지션 3 지령", [3] = "포지션 4 지령",
                [4] = "포지션 5 지령", [5] = "포지션 6 지령",
                [6] = "포지션 7 지령", [7] = "포지션 8 지령"
            },
            [4014] = new Dictionary<int, string>
            {
                [0] = "포지션 1 완료", [1] = "포지션 2 완료",
                [2] = "포지션 3 완료", [3] = "포지션 4 완료",
                [4] = "포지션 5 완료", [5] = "포지션 6 완료",
                [6] = "포지션 7 완료", [7] = "포지션 8 완료"
            }
        };

        public _FrmSignalPlc1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(15, 23, 42);
            this.Load         += _FrmSignal_Load;
            this.FormClosing  += _FrmSignal_FormClosing;
        }

        private void _FrmSignal_Load(object sender, EventArgs e)
        {
            LoadSignalNames();
            SetInputOutputLabels();
            SetSignalPanels();
            SetPosTable();
            ApplyRoundedCorners();

            void WireZeroBtn(System.Windows.Forms.Button btn, System.Action action)
            {
                btn.Click += (s, ev) =>
                {
                    action?.Invoke();
                    btn.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
                    var t = new System.Windows.Forms.Timer { Interval = 600 };
                    t.Tick += (ts, te) => { t.Stop(); t.Dispose();
                        btn.BackColor = System.Drawing.Color.FromArgb(120, 53, 15); };
                    t.Start();
                };
            }
            WireZeroBtn(btnZeroLvdt, () => GlobalValues.ZeroLvdtAction?.Invoke());
            WireZeroBtn(btnZeroLc1,  () => GlobalValues.ZeroLc1Action?.Invoke());
            WireZeroBtn(btnZeroLc2,  () => GlobalValues.ZeroLc2Action?.Invoke());

            updateTimer.Interval = 100;
            updateTimer.Tick    += UpdateLabels;
            updateTimer.Start();
        }

        private static System.Drawing.Drawing2D.GraphicsPath GetRoundedPath(System.Drawing.Rectangle r, int radius)
        {
            var p = new System.Drawing.Drawing2D.GraphicsPath();
            int d = radius * 2;
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        private void ApplyRoundedCorners()
        {
            var btns = new Button[] { btnJogFwd, btnJogBwd, button2 };
            foreach (var btn in btns)
                btn.Region = new System.Drawing.Region(GetRoundedPath(
                    new System.Drawing.Rectangle(0, 0, btn.Width, btn.Height), 8));
        }

        private void _FrmSignal_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer?.Stop();
            updateTimer?.Dispose();
        }

        // ── IO 라벨 설정 ──────────────────────────────────────────────
        private void SetInputOutputLabels()
        {
            // 입력 D4000 (1워드 × 16비트 = 16)
            for (int i = 0; i < 16; i++)
            {
                int bit  = i;
                string key  = $"D{InStartWord}.{bit}";

                labels_Input[i] = new Label
                {
                    Dock      = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font      = new Font("Arial", 9, FontStyle.Bold),
                    BackColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.LightGray,
                    Text      = $"{bit} ({(signalNames.ContainsKey(key) ? signalNames[key] : "-")})",
                    Padding   = new Padding(18, 0, 0, 0),
                    Tag       = false
                };
                labels_Input[i].Paint += LedLabel_Paint;

                PanelIn.Controls.Add(labels_Input[i], 0, bit);

                string capturedKey = key;
                int    capturedIdx = i;
                labels_Input[i].DoubleClick += (s, ev) =>
                    BeginInvoke(new Action(() => EditSignalName(capturedKey, capturedIdx, isInput: true)));
            }

            // 입력 D4001 (1워드 × 16비트 = 16)
            for (int i = 0; i < 16; i++)
            {
                int bit = i;
                string key = $"D4001.{bit}";

                labels_4001[i] = new Label
                {
                    Dock      = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font      = new Font("Arial", 9, FontStyle.Bold),
                    BackColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.LightGray,
                    Text      = $"{bit} ({(signalNames.ContainsKey(key) ? signalNames[key] : "-")})",
                    Padding   = new Padding(18, 0, 0, 0),
                    Tag       = false
                };
                labels_4001[i].Paint += LedLabel_Paint;
                PanelIn2.Controls.Add(labels_4001[i], 0, bit);

                string capturedKey = key;
                int    capturedIdx = i;
                labels_4001[i].DoubleClick += (s, ev) =>
                    BeginInvoke(new Action(() => EditSignalName(capturedKey, capturedIdx, isInput: true, isD4001: true)));
            }

            // 출력 D4004 (1워드 × 16비트 = 16)
            for (int i = 0; i < 16; i++)
            {
                int bit  = i;
                string key  = $"D{OutStartWord}.{bit}";
                int wIdx = 4;

                labels_Output[i] = new Label
                {
                    Dock      = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font      = new Font("Arial", 9, FontStyle.Bold),
                    BackColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.LightGray,
                    Text      = $"{bit} ({(signalNames.ContainsKey(key) ? signalNames[key] : "-")})",
                    Padding   = new Padding(18, 0, 0, 0),
                    Tag       = false
                };
                labels_Output[i].Paint += LedLabel_Paint;

                var forceBtn = new Button
                {
                    Text      = "ON",
                    Dock      = DockStyle.Right,
                    Width     = 52,
                    Font      = new Font("Arial", 9, FontStyle.Bold),
                    BackColor = Color.FromArgb(60, 60, 60),
                    ForeColor = Color.LightGray,
                    FlatStyle = FlatStyle.Flat
                };
                forceBtn.FlatAppearance.BorderColor = Color.Gray;

                int capturedWIdx = wIdx;
                int capturedBit  = bit;
                // 누르는 동안만 ON, 손 떼면 OFF
                forceBtn.MouseDown += (s, ev) =>
                {
                    PLCData1.writePlcValueBit[capturedWIdx, capturedBit] = true;
                    forceBtn.BackColor = Color.SkyBlue;
                    forceBtn.ForeColor = Color.Navy;
                };
                forceBtn.MouseUp += (s, ev) =>
                {
                    PLCData1.writePlcValueBit[capturedWIdx, capturedBit] = false;
                    forceBtn.BackColor = Color.FromArgb(60, 60, 60);
                    forceBtn.ForeColor = Color.LightGray;
                };

                var cell = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0) };
                forceBtns[i] = forceBtn;
                cell.Controls.Add(forceBtn);
                cell.Controls.Add(labels_Output[i]);

                PanelOut.Controls.Add(cell, 0, bit);

                string capturedKey = key;
                int    capturedIdx = i;
                labels_Output[i].DoubleClick += (s, ev) =>
                    BeginInvoke(new Action(() => EditSignalName(capturedKey, capturedIdx, isInput: false)));
            }
        }

        private void SetPosTable()
        {
            int ctrlX = 872, ctrlY = 28;
            int ptY  = ctrlY + 120;
            int rowH = 28;
            var cMuted = Color.FromArgb(148, 163, 184);

            txtPosCoord   = new System.Windows.Forms.TextBox[6];
            txtPosSpd     = new System.Windows.Forms.TextBox[6];
            txtPosComment = new System.Windows.Forms.TextBox[6];
            btnGo         = new Button[6];

            // 열 오프셋 (POS 라벨 이후): 코멘트 → 좌표 → 속도 → GO
            // GO 버튼 끝(ctrlX+COL_GO+46)이 statX(740) 미만이어야 함 → 380+308+46=734 ✓
            const int COL_COMMENT = 58;   // 코멘트  100px
            const int COL_COORD   = 162;  // 좌표     80px
            const int COL_SPD     = 246;  // 속도     60px
            const int COL_GO      = 310;  // GO       46px  (끝 380+310+46=736)
            const int TOTAL_W     = 298;  // 저장 버튼 폭

            var hdrComment = new Label { Text = "코멘트",       Font = new Font("맑은 고딕", 8F), ForeColor = cMuted, Location = new Point(ctrlX + COL_COMMENT, ptY - 18), AutoSize = true };
            var hdrCoord   = new Label { Text = "좌표 (pulse)", Font = new Font("맑은 고딕", 8F), ForeColor = cMuted, Location = new Point(ctrlX + COL_COORD,   ptY - 18), AutoSize = true };
            var hdrSpd     = new Label { Text = "속도 (pps)",   Font = new Font("맑은 고딕", 8F), ForeColor = cMuted, Location = new Point(ctrlX + COL_SPD,     ptY - 18), AutoSize = true };
            this.Controls.Add(hdrComment);
            this.Controls.Add(hdrCoord);
            this.Controls.Add(hdrSpd);

            int[] coords = { PLCData1.Servo1Pos1, PLCData1.Servo1Pos2, PLCData1.Servo1Pos3,
                             PLCData1.Servo1Pos4, PLCData1.Servo1Pos5, PLCData1.Servo1Pos6 };
            int[] speeds = { PLCData1.Servo1Pos1Spd, PLCData1.Servo1Pos2Spd, PLCData1.Servo1Pos3Spd,
                             PLCData1.Servo1Pos4Spd, PLCData1.Servo1Pos5Spd, PLCData1.Servo1Pos6Spd };
            string[] comments = PLCData1.Servo1PosComments;
            int[] coordAddrs = { 6000, 6004, 6008, 6012, 6032, 6036 };
            int[] spdAddrs   = { 6002, 6006, 6010, 6014, 6034, 6038 };

            for (int i = 0; i < 6; i++)
            {
                int y = ptY + i * rowH;

                var lbl = new Label
                {
                    Text      = $"POS {i + 1}\nD{coordAddrs[i]}/D{spdAddrs[i]}",
                    Font      = new Font("맑은 고딕", 7F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location  = new Point(ctrlX, y),
                    Size      = new Size(56, 28),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                txtPosComment[i] = new System.Windows.Forms.TextBox
                {
                    Text        = comments[i],
                    Font        = new Font("맑은 고딕", 9F),
                    Location    = new Point(ctrlX + COL_COMMENT, y),
                    Size        = new Size(100, 28),
                    BackColor   = Color.FromArgb(22, 32, 48),
                    ForeColor   = Color.FromArgb(250, 204, 21),
                    BorderStyle = BorderStyle.FixedSingle
                };

                txtPosCoord[i] = new System.Windows.Forms.TextBox
                {
                    Text        = coords[i].ToString(),
                    Font        = new Font("맑은 고딕", 10F),
                    Location    = new Point(ctrlX + COL_COORD, y),
                    Size        = new Size(80, 28),
                    TextAlign   = HorizontalAlignment.Right,
                    BackColor   = Color.FromArgb(22, 32, 48),
                    ForeColor   = Color.FromArgb(94, 234, 212),
                    BorderStyle = BorderStyle.FixedSingle
                };

                txtPosSpd[i] = new System.Windows.Forms.TextBox
                {
                    Text        = speeds[i].ToString(),
                    Font        = new Font("맑은 고딕", 10F),
                    Location    = new Point(ctrlX + COL_SPD, y),
                    Size        = new Size(60, 28),
                    TextAlign   = HorizontalAlignment.Right,
                    BackColor   = Color.FromArgb(22, 32, 48),
                    ForeColor   = Color.FromArgb(148, 163, 184),
                    BorderStyle = BorderStyle.FixedSingle
                };

                btnGo[i] = new Button
                {
                    Text      = "GO",
                    Font      = new Font("맑은 고딕", 9F, FontStyle.Bold),
                    BackColor = Color.FromArgb(30, 64, 175),
                    ForeColor = Color.White,
                    Location  = new Point(ctrlX + COL_GO, y),
                    Size      = new Size(46, 28),
                    FlatStyle = FlatStyle.Flat
                };
                btnGo[i].FlatAppearance.BorderSize = 0;
                btnGo[i].Region = new System.Drawing.Region(GetRoundedPath(new System.Drawing.Rectangle(0, 0, 46, 28), 6));
                int pos = i + 1;
                btnGo[i].Click += (s, ev) => MoveToPos(pos);

                this.Controls.Add(lbl);
                this.Controls.Add(txtPosComment[i]);
                this.Controls.Add(txtPosCoord[i]);
                this.Controls.Add(txtPosSpd[i]);
                this.Controls.Add(btnGo[i]);
            }

            btnSavePos = new Button
            {
                Text      = "좌표  저장",
                Font      = new Font("맑은 고딕", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(21, 128, 61),
                ForeColor = Color.White,
                Location  = new Point(ctrlX + COL_COMMENT, ptY + 6 * rowH + 6),
                Size      = new Size(TOTAL_W, 34),
                FlatStyle = FlatStyle.Flat
            };
            btnSavePos.FlatAppearance.BorderSize = 0;
            btnSavePos.Region = new System.Drawing.Region(GetRoundedPath(new System.Drawing.Rectangle(0, 0, TOTAL_W, 34), 6));
            btnSavePos.Click += BtnSavePos_Click;
            this.Controls.Add(btnSavePos);

            // ── 속도 설정 영역 ──────────────────────────────────────
            int spdY = ptY + 6 * rowH + 48;
            var spdHdr = new Label
            {
                Text      = "─ 속도 설정 ─",
                Font      = new Font("맑은 고딕", 9F),
                ForeColor = cMuted,
                Location  = new Point(ctrlX, spdY),
                Size      = new Size(310, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(spdHdr);

            var lblJog = new Label { Text = "조그 속도", Font = new Font("맑은 고딕", 9F, FontStyle.Bold), ForeColor = Color.White, Location = new Point(ctrlX, spdY + 24), Size = new Size(70, 28), TextAlign = ContentAlignment.MiddleLeft };
            txtJogSpd = new System.Windows.Forms.TextBox
            {
                Text        = PLCData1.Servo1JogSpd.ToString(),
                Font        = new Font("맑은 고딕", 10F),
                Location    = new Point(ctrlX + 74, spdY + 24),
                Size        = new Size(70, 28),
                TextAlign   = HorizontalAlignment.Right,
                BackColor   = Color.FromArgb(22, 32, 48),
                ForeColor   = Color.FromArgb(94, 234, 212),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblDiff = new Label { Text = "유격 속도", Font = new Font("맑은 고딕", 9F, FontStyle.Bold), ForeColor = Color.White, Location = new Point(ctrlX + 154, spdY + 24), Size = new Size(70, 28), TextAlign = ContentAlignment.MiddleLeft };
            txtDiffSpd = new System.Windows.Forms.TextBox
            {
                Text        = PLCData1.DiffSpeed.ToString(),
                Font        = new Font("맑은 고딕", 10F),
                Location    = new Point(ctrlX + 228, spdY + 24),
                Size        = new Size(70, 28),
                TextAlign   = HorizontalAlignment.Right,
                BackColor   = Color.FromArgb(22, 32, 48),
                ForeColor   = Color.FromArgb(94, 234, 212),
                BorderStyle = BorderStyle.FixedSingle
            };

            var btnSaveSpd = new Button
            {
                Text      = "속도  저장",
                Font      = new Font("맑은 고딕", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(21, 128, 61),
                ForeColor = Color.White,
                Location  = new Point(ctrlX + 58, spdY + 60),
                Size      = new Size(244, 34),
                FlatStyle = FlatStyle.Flat
            };
            btnSaveSpd.FlatAppearance.BorderSize = 0;
            btnSaveSpd.Region = new System.Drawing.Region(GetRoundedPath(new System.Drawing.Rectangle(0, 0, 244, 34), 6));
            btnSaveSpd.Click += (s, ev) =>
            {
                if (!int.TryParse(txtJogSpd.Text.Trim(),  out int jog)  ||
                    !int.TryParse(txtDiffSpd.Text.Trim(), out int diff))
                {
                    MessageBox.Show("속도 값이 올바르지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PLCData1.Servo1JogSpd = jog;
                PLCData1.DiffSpeed    = diff;
                GlobalValues.SaveChannelSettingsToIni();
                PLCData1.ServoSet();
                MessageBox.Show("속도 저장 완료", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            this.Controls.Add(lblJog);
            this.Controls.Add(txtJogSpd);
            this.Controls.Add(lblDiff);
            this.Controls.Add(txtDiffSpd);
            this.Controls.Add(btnSaveSpd);
        }

        private void BtnSavePos_Click(object sender, EventArgs e)
        {
            int[] coords = new int[6];
            int[] speeds = new int[6];
            for (int i = 0; i < 6; i++)
            {
                if (!int.TryParse(txtPosCoord[i].Text.Trim(), out coords[i]) ||
                    !int.TryParse(txtPosSpd[i].Text.Trim(),   out speeds[i]))
                {
                    MessageBox.Show($"POS {i + 1} 값이 올바르지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            PLCData1.Servo1Pos1 = coords[0]; PLCData1.Servo1Pos2 = coords[1];
            PLCData1.Servo1Pos3 = coords[2]; PLCData1.Servo1Pos4 = coords[3];
            PLCData1.Servo1Pos5 = coords[4]; PLCData1.Servo1Pos6 = coords[5];
            PLCData1.Servo1Pos1Spd = speeds[0]; PLCData1.Servo1Pos2Spd = speeds[1];
            PLCData1.Servo1Pos3Spd = speeds[2]; PLCData1.Servo1Pos4Spd = speeds[3];
            PLCData1.Servo1Pos5Spd = speeds[4]; PLCData1.Servo1Pos6Spd = speeds[5];

            for (int i = 0; i < 6; i++)
                PLCData1.Servo1PosComments[i] = txtPosComment[i].Text;

            GlobalValues.SaveChannelSettingsToIni();
            PLCData1.ServoSet();

            MessageBox.Show("저장 및 서보 전송 완료", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetSignalPanels()
        {
            CreateSignalLabels(4008, Panel4008, labels_4008);
            CreateSignalLabels(4009, Panel4009, labels_4009);
            CreateSignalLabels(4012, Panel4012, labels_4012);
            CreateSignalLabels(4014, Panel4014, labels_4014);
        }

        private void CreateSignalLabels(int dAddr, TableLayoutPanel panel, Label[] labelArray)
        {
            bool clickable = (dAddr == 4009 || dAddr == 4012);
            for (int i = 0; i < 16; i++)
            {
                labelArray[i] = new Label
                {
                    Dock      = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font      = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.FromArgb(30, 30, 30),
                    ForeColor = Color.LightGray,
                    Padding   = new Padding(18, 0, 0, 0),
                    Tag       = false
                };
                labelArray[i].Paint += LedLabel_Paint;
                string name  = bitNames.ContainsKey(dAddr) && bitNames[dAddr].ContainsKey(i)
                               ? bitNames[dAddr][i] : $"{dAddr}.{i}";
                labelArray[i].Text = $"{i} ({name})";
                panel.Controls.Add(labelArray[i], 0, i);

                if (clickable)
                {
                    int wordIndex = dAddr - 4000;
                    int bit = i;
                    labelArray[i].Click += async (s, ev) =>
                    {
                        if (dAddr == 4012)
                        {
                            // 포지션 지령은 펄스 — 200ms 후 자동 OFF
                            PLCData1.writePlcValueBit[wordIndex, bit] = true;
                            await System.Threading.Tasks.Task.Delay(200);
                            PLCData1.writePlcValueBit[wordIndex, bit] = false;
                        }
                        else
                        {
                            bool next = !PLCData1.writePlcValueBit[wordIndex, bit];
                            PLCData1.writePlcValueBit[wordIndex, bit] = next;

                            // 자동(5)/수동(6) 상호 배타
                            if (dAddr == 4009 && next)
                            {
                                if (bit == 5) PLCData1.writePlcValueBit[wordIndex, 6] = false;
                                if (bit == 6) PLCData1.writePlcValueBit[wordIndex, 5] = false;
                            }
                        }
                    };
                }
            }
        }

        private void LoadSignalNames()
        {
            IniFile ini = new IniFile("config.ini");
            for (int i = 0; i < 32; i++)
            {
                int    word = i / 16;
                int    bit  = i % 16;
                string key  = $"D{InStartWord + word}.{bit}";
                string val  = ini.ReadValue("SIGNAL_NAME_PLC1", key);
                if (string.IsNullOrEmpty(val)) { val = "-"; ini.WriteValue("SIGNAL_NAME_PLC1", key, val); }
                signalNames[key] = val;
            }
            for (int i = 0; i < 32; i++)
            {
                int    word = i / 16;
                int    bit  = i % 16;
                string key  = $"D{OutStartWord + word}.{bit}";
                string val  = ini.ReadValue("SIGNAL_NAME_PLC1", key);
                if (string.IsNullOrEmpty(val)) { val = "-"; ini.WriteValue("SIGNAL_NAME_PLC1", key, val); }
                signalNames[key] = val;
            }
        }

        private void UpdateBitPanel(int dAddr, Label[] labelArray)
        {
            int wordIndex = dAddr - 4000;
            bool isOutput = (dAddr == 4009 || dAddr == 4012);
            for (int bit = 0; bit < 16; bit++)
            {
                bool isOn = isOutput
                    ? PLCData1.writePlcValueBit[wordIndex, bit]
                    : PLCData1.PlcValueBit[wordIndex, bit];
                bool cur = labelArray[bit].Tag is bool b && b;
                if (cur != isOn)
                {
                    labelArray[bit].Tag       = isOn;
                    labelArray[bit].BackColor = isOn ? Color.FromArgb(20, 45, 40) : Color.FromArgb(30, 30, 30);
                    labelArray[bit].ForeColor = isOn ? Color.FromArgb(94, 234, 212) : Color.LightGray;
                    labelArray[bit].Invalidate();
                }
            }
        }

        private static void LedLabel_Paint(object sender, PaintEventArgs e)
        {
            var lbl = (Label)sender;
            bool on = lbl.Tag is bool b && b;
            Color ledColor = on ? Color.FromArgb(0, 230, 130) : Color.FromArgb(55, 55, 55);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int cy = lbl.ClientRectangle.Height / 2;
            using (var brush = new SolidBrush(ledColor))
                g.FillEllipse(brush, 3, cy - 5, 10, 10);
            if (on)
                using (var pen = new Pen(Color.FromArgb(120, 255, 200), 1.0f))
                    g.DrawEllipse(pen, 3, cy - 5, 10, 10);
        }

        private void EditSignalName(string key, int idx, bool isInput, bool isD4001 = false)
        {
            string current = signalNames.ContainsKey(key) ? signalNames[key] : "-";
            updateTimer.Stop();
            try
            {
                using (var dlg = new Form())
                {
                    dlg.Text            = $"코멘트 편집 [{key}]";
                    dlg.Size            = new Size(360, 130);
                    dlg.StartPosition   = FormStartPosition.CenterParent;
                    dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                    dlg.MaximizeBox     = false;
                    var tb  = new TextBox { Left = 12, Top = 12, Width = 320, Text = current };
                    var ok  = new Button { Text = "확인", Left = 160, Top = 50, Width = 80, DialogResult = DialogResult.OK };
                    var cnl = new Button { Text = "취소", Left = 250, Top = 50, Width = 80, DialogResult = DialogResult.Cancel };
                    dlg.Controls.AddRange(new Control[] { tb, ok, cnl });
                    dlg.AcceptButton = ok;
                    dlg.CancelButton = cnl;

                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        string newName = string.IsNullOrEmpty(tb.Text.Trim()) ? "-" : tb.Text.Trim();
                        signalNames[key] = newName;
                        int bit = idx % 16;
                        if (isD4001)       labels_4001[idx].Text   = $"{bit} ({newName})";
                        else if (isInput)  labels_Input[idx].Text  = $"{bit} ({newName})";
                        else               labels_Output[idx].Text = $"{bit} ({newName})";
                        new IniFile("config.ini").WriteValue("SIGNAL_NAME_PLC1", key, newName);
                    }
                }
            }
            finally { updateTimer.Start(); }
        }

        private void UpdateLabels(object sender, EventArgs e)
        {
            UpdateBitPanel(4008, labels_4008);
            UpdateBitPanel(4009, labels_4009);
            UpdateBitPanel(4012, labels_4012);
            UpdateBitPanel(4014, labels_4014);

            lbVal1.Text = PLCData1.PlcValue[5000].ToString();
            lbVal3.Text = PLCData1.PlcValue[5002].ToString();

            // 센서 실시간값 갱신
            lbLvdt.Text = MeasureData1.ValueLvdt.ToString("F3");
            lbLc1.Text  = MeasureData1.ValueLoadCell1.ToString("F3");
            lbLc2.Text  = MeasureData1.ValueLoadCell2.ToString("F3");

            // D4001 입력
            for (int i = 0; i < 16; i++)
            {
                bool on  = PLCData1.PlcValueBit[1, i];
                bool cur = labels_4001[i].Tag is bool b3 && b3;
                if (cur != on)
                {
                    labels_4001[i].Tag       = on;
                    labels_4001[i].BackColor = on ? Color.FromArgb(20, 45, 40) : Color.FromArgb(30, 30, 30);
                    labels_4001[i].ForeColor = on ? Color.FromArgb(94, 234, 212) : Color.LightGray;
                    labels_4001[i].Invalidate();
                }
            }

            // 입력 (D4000)
            for (int i = 0; i < 16; i++)
            {
                int bit  = i;
                bool on  = PLCData1.PlcValueBit[0, bit];
                bool cur = labels_Input[i].Tag is bool b1 && b1;
                if (cur != on)
                {
                    labels_Input[i].Tag       = on;
                    labels_Input[i].BackColor = on ? Color.FromArgb(20, 45, 40) : Color.FromArgb(30, 30, 30);
                    labels_Input[i].ForeColor = on ? Color.FromArgb(94, 234, 212) : Color.LightGray;
                    labels_Input[i].Invalidate();
                }
            }

            // 출력 (D4004) → writePlcValueBit[4, bit]
            for (int i = 0; i < 16; i++)
            {
                int bit  = i;
                bool on  = PLCData1.writePlcValueBit[4, bit];
                bool cur = labels_Output[i].Tag is bool b2 && b2;
                if (cur != on)
                {
                    labels_Output[i].Tag       = on;
                    labels_Output[i].BackColor = on ? Color.FromArgb(20, 45, 40) : Color.FromArgb(30, 30, 30);
                    labels_Output[i].ForeColor = on ? Color.FromArgb(94, 234, 212) : Color.LightGray;
                    labels_Output[i].Invalidate();
                }
                if (forceBtns[i] != null)
                {
                    forceBtns[i].BackColor = on ? Color.SkyBlue         : Color.FromArgb(60, 60, 60);
                    forceBtns[i].ForeColor = on ? Color.Navy            : Color.LightGray;
                }
            }
        }

        // ── 버튼 이벤트 ───────────────────────────────────────────────
        private void button2_Click(object sender, EventArgs e)
        {
            PLCData1.FlagRecvAll = false;
            this.Close();
        }

        private void btnJogFwd_MouseDown(object sender, MouseEventArgs e)
        {
            PLCData1.SetPlcBit(9, 6, true);
            PLCData1.SetPlcBit(9, 7, false);
            PLCData1.SetPlcBit(9, 1, true);
        }
        private void btnJogFwd_MouseUp(object sender, MouseEventArgs e) =>
            PLCData1.SetPlcBit(9, 1, false);

        private void btnJogBwd_MouseDown(object sender, MouseEventArgs e)
        {
            PLCData1.SetPlcBit(9, 6, true);
            PLCData1.SetPlcBit(9, 7, false);
            PLCData1.SetPlcBit(9, 2, true);
        }
        private void btnJogBwd_MouseUp(object sender, MouseEventArgs e) =>
            PLCData1.SetPlcBit(9, 2, false);

        private async void MoveToPos(int pos)
        {
            PLCData1.SetPlcBit(9, 5, true);        // D4009.5 = 자동
            PLCData1.SetPlc(5100, pos);             // D5100 = 포지션 번호
            PLCData1.SetPlcBit(12, pos - 1, true);  // D4012.bit(N-1) = 포지션 N 지령 (펄스)
            await System.Threading.Tasks.Task.Delay(200);
            PLCData1.SetPlcBit(12, pos - 1, false); // 200ms 후 자동 OFF
        }
    }
}
