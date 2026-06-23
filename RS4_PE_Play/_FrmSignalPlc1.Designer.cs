namespace ResisterTest
{
    partial class _FrmSignalPlc1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.PanelIn   = new System.Windows.Forms.TableLayoutPanel();
            this.PanelIn2  = new System.Windows.Forms.TableLayoutPanel();
            this.PanelOut  = new System.Windows.Forms.TableLayoutPanel();
            this.label1    = new System.Windows.Forms.Label();
            this.label2    = new System.Windows.Forms.Label();
            this.label5    = new System.Windows.Forms.Label();
            this.label3    = new System.Windows.Forms.Label();
            this.label4    = new System.Windows.Forms.Label();
            this.label9    = new System.Windows.Forms.Label();
            this.label10   = new System.Windows.Forms.Label();

            this.Panel4008 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel4009 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel4012 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel4014 = new System.Windows.Forms.TableLayoutPanel();
            this.label18   = new System.Windows.Forms.Label();
            this.lbVal1    = new System.Windows.Forms.Label();
            this.label22   = new System.Windows.Forms.Label();
            this.lbVal3    = new System.Windows.Forms.Label();
            this.button2   = new System.Windows.Forms.Button();
            this.lblSensorHdr = new System.Windows.Forms.Label();
            this.lblLvdtTitle = new System.Windows.Forms.Label();
            this.lbLvdt       = new System.Windows.Forms.Label();
            this.lblLc1Title  = new System.Windows.Forms.Label();
            this.lbLc1        = new System.Windows.Forms.Label();
            this.lblLc2Title  = new System.Windows.Forms.Label();
            this.lbLc2        = new System.Windows.Forms.Label();
            this.btnZeroLvdt  = new System.Windows.Forms.Button();
            this.btnZeroLc1   = new System.Windows.Forms.Button();
            this.btnZeroLc2   = new System.Windows.Forms.Button();
            this.btnJogFwd = new System.Windows.Forms.Button();
            this.btnJogBwd = new System.Windows.Forms.Button();
            this.lblServCtrl = new System.Windows.Forms.Label();
            this.lblJogSec   = new System.Windows.Forms.Label();
            this.lblPosSec   = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ─ 공통 TableLayoutPanel 설정 헬퍼 ─
            void ConfigTLP(System.Windows.Forms.TableLayoutPanel p, int cols,
                           int x, int y, int w, int h, bool clickable)
            {
                p.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
                p.ColumnCount = cols;
                p.RowCount    = 16;
                p.Font        = new System.Drawing.Font("맑은 고딕", 6F);
                p.Location    = new System.Drawing.Point(x, y);
                p.Margin      = new System.Windows.Forms.Padding(3, 4, 3, 4);
                p.Size        = new System.Drawing.Size(w, h);
                for (int c = 0; c < cols; c++)
                    p.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                        System.Windows.Forms.SizeType.Percent, 100F / cols));
                for (int r = 0; r < 16; r++)
                    p.RowStyles.Add(new System.Windows.Forms.RowStyle(
                        System.Windows.Forms.SizeType.Percent, 6.25F));
            }

            // PanelIn (D4000 — 1컬럼, 좌)
            ConfigTLP(PanelIn, 1, 12, 28, 168, 432, false);

            // PanelIn2 (D4001 — D4000 오른쪽)
            ConfigTLP(PanelIn2, 1, 186, 28, 168, 432, false);

            // PanelOut (D4004 — 1컬럼, 우측 나란히)
            ConfigTLP(PanelOut, 1, 360, 28, 174, 432, true);

            // ══ 서보 1축 신호 패널 ══════════════════════════════════════
            int sX = 554, sW = 155, sGap = 4;
            // D4008 / D4009 상단
            ConfigTLP(Panel4008, 1, sX,             28,  sW, 310, false);
            ConfigTLP(Panel4009, 1, sX + (sW+sGap), 28,  sW, 310, true);
            // D4012 / D4014 하단 (D4008/D4009 아래)
            ConfigTLP(Panel4012, 1, sX,             358, sW, 310, true);
            ConfigTLP(Panel4014, 1, sX + (sW+sGap), 358, sW, 310, false);

            // ─ 섹션 라벨 ─
            void SectionLabel(System.Windows.Forms.Label lb, string txt, int x, int y,
                              System.Drawing.Color fg, bool bold = true)
            {
                lb.AutoSize  = true;
                lb.Text      = txt;
                lb.Font      = new System.Drawing.Font("맑은 고딕", 10F,
                               bold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
                lb.ForeColor = fg;
                lb.Location  = new System.Drawing.Point(x, y);
            }
            var cBlue  = System.Drawing.Color.SteelBlue;
            var cRed   = System.Drawing.Color.Tomato;
            var cCyan  = System.Drawing.Color.FromArgb(6, 182, 212);
            var cMuted = System.Drawing.Color.FromArgb(148, 163, 184);
            var cGreen = System.Drawing.Color.FromArgb(34, 197, 94);

            // 좌측 일반 I/O 라벨 (AutoSize=false, 각 패널 폭 내 제한)
            SectionLabel(label1,  "■ 입력 (D4000)", 12,  11, cBlue);
            label1.AutoSize = false;
            label1.Size     = new System.Drawing.Size(168, 16);

            SectionLabel(label5,  "■ 입력 (D4001)", 186, 11, cBlue);
            label5.AutoSize = false;
            label5.Size     = new System.Drawing.Size(168, 16);

            SectionLabel(label2,  "■ 출력 (D4004)", 360, 11, cRed);
            label2.AutoSize = false;
            label2.Size     = new System.Drawing.Size(174, 16);

            // 서보 1축 신호 라벨
            SectionLabel(label3,  "D4008  입력 (PLC→PC)", sX,             11,  cBlue,  false);
            SectionLabel(label4,  "D4009  출력 (PC→PLC)", sX+(sW+sGap),   11,  cRed,   false);
            SectionLabel(label10, "D4012  포지션 지령",    sX,             342, cRed,   false);
            SectionLabel(label9,  "D4014  포지션 완료",    sX+(sW+sGap),   342, cGreen, false);

            // ══ 서보 제어 섹션 (D4009 오른쪽 x=698, D4008과 동일 y=28) ═══
            int ctrlX = 872, ctrlY = 28;

            SectionLabel(lblServCtrl, "■ 서보 제어", ctrlX, ctrlY, cCyan);
            lblServCtrl.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);

            SectionLabel(lblJogSec, "─ 조 그 ─", ctrlX, ctrlY + 24, cMuted, false);
            lblJogSec.AutoSize  = false;
            lblJogSec.Size      = new System.Drawing.Size(330, 20);
            lblJogSec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            void JogBtn(System.Windows.Forms.Button b, string txt, int x, int y,
                        System.Drawing.Color bg)
            {
                b.Text      = txt;
                b.Font      = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
                b.BackColor = bg;
                b.ForeColor = System.Drawing.Color.White;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Location  = new System.Drawing.Point(x, y);
                b.Size      = new System.Drawing.Size(158, 44);
            }
            JogBtn(btnJogFwd, "▲  전  진", ctrlX,       ctrlY + 48, System.Drawing.Color.FromArgb(30, 64, 175));
            JogBtn(btnJogBwd, "▼  후  진", ctrlX + 162, ctrlY + 48, System.Drawing.Color.FromArgb(51, 65, 85));

            btnJogFwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogFwd_MouseDown);
            btnJogFwd.MouseUp   += new System.Windows.Forms.MouseEventHandler(this.btnJogFwd_MouseUp);
            btnJogBwd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogBwd_MouseDown);
            btnJogBwd.MouseUp   += new System.Windows.Forms.MouseEventHandler(this.btnJogBwd_MouseUp);

            SectionLabel(lblPosSec, "─ 포지션 이동 (좌표/속도 설정) ─", ctrlX, ctrlY + 98, cMuted, false);
            lblPosSec.AutoSize  = false;
            lblPosSec.Size      = new System.Drawing.Size(330, 20);
            lblPosSec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ══ 현재 상태 표시 (서보제어 아래) ════════════════════════════
            // spdY(364)+60+34=458 이 서보제어 끝 → 478부터 표시
            int statX = ctrlX, statY = 478;

            SectionLabel(label18, "■ 1축 현재 위치", statX, statY, cCyan);
            label18.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);

            lbVal1.AutoSize  = false;
            lbVal1.Size      = new System.Drawing.Size(260, 60);
            lbVal1.Font      = new System.Drawing.Font("맑은 고딕", 26F, System.Drawing.FontStyle.Bold);
            lbVal1.ForeColor = cCyan;
            lbVal1.Location  = new System.Drawing.Point(statX, statY + 24);
            lbVal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbVal1.BackColor = System.Drawing.Color.FromArgb(22, 32, 48);

            SectionLabel(label22, "■ 1축 현재 조그속도", statX, statY + 94, cMuted);
            label22.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);

            lbVal3.AutoSize  = false;
            lbVal3.Size      = new System.Drawing.Size(260, 60);
            lbVal3.Font      = new System.Drawing.Font("맑은 고딕", 26F, System.Drawing.FontStyle.Bold);
            lbVal3.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            lbVal3.Location  = new System.Drawing.Point(statX, statY + 118);
            lbVal3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbVal3.BackColor = System.Drawing.Color.FromArgb(22, 32, 48);

            // ══ 센서 실시간값 + 영점 셋 (D4000~D4004 패널 하단 y=468~) ═══════
            int senY = 468;
            int senBoxW = 168;

            // 섹션 헤더
            lblSensorHdr.Text      = "■ 센서 실시간값";
            lblSensorHdr.Font      = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            lblSensorHdr.ForeColor = cCyan;
            lblSensorHdr.Location  = new System.Drawing.Point(12, senY);
            lblSensorHdr.AutoSize  = true;

            // LVDT (x=12)
            lblLvdtTitle.Text      = "LVDT (mm)";
            lblLvdtTitle.Font      = new System.Drawing.Font("맑은 고딕", 8F);
            lblLvdtTitle.ForeColor = cMuted;
            lblLvdtTitle.Location  = new System.Drawing.Point(12, senY + 20);
            lblLvdtTitle.Size      = new System.Drawing.Size(senBoxW, 15);

            lbLvdt.Text      = "---";
            lbLvdt.Font      = new System.Drawing.Font("맑은 고딕", 17F, System.Drawing.FontStyle.Bold);
            lbLvdt.ForeColor = cCyan;
            lbLvdt.BackColor = System.Drawing.Color.FromArgb(22, 32, 48);
            lbLvdt.Location  = new System.Drawing.Point(12, senY + 36);
            lbLvdt.Size      = new System.Drawing.Size(senBoxW, 36);
            lbLvdt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // LC1 전진 (x=186)
            lblLc1Title.Text      = "로드셀1 전진 (kgf)";
            lblLc1Title.Font      = new System.Drawing.Font("맑은 고딕", 8F);
            lblLc1Title.ForeColor = cMuted;
            lblLc1Title.Location  = new System.Drawing.Point(186, senY + 20);
            lblLc1Title.Size      = new System.Drawing.Size(senBoxW, 15);

            lbLc1.Text      = "---";
            lbLc1.Font      = new System.Drawing.Font("맑은 고딕", 17F, System.Drawing.FontStyle.Bold);
            lbLc1.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            lbLc1.BackColor = System.Drawing.Color.FromArgb(22, 32, 48);
            lbLc1.Location  = new System.Drawing.Point(186, senY + 36);
            lbLc1.Size      = new System.Drawing.Size(senBoxW, 36);
            lbLc1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // LC2 후진 (x=360)
            lblLc2Title.Text      = "로드셀2 후진 (kgf)";
            lblLc2Title.Font      = new System.Drawing.Font("맑은 고딕", 8F);
            lblLc2Title.ForeColor = cMuted;
            lblLc2Title.Location  = new System.Drawing.Point(360, senY + 20);
            lblLc2Title.Size      = new System.Drawing.Size(senBoxW, 15);

            lbLc2.Text      = "---";
            lbLc2.Font      = new System.Drawing.Font("맑은 고딕", 17F, System.Drawing.FontStyle.Bold);
            lbLc2.ForeColor = System.Drawing.Color.FromArgb(250, 204, 21);
            lbLc2.BackColor = System.Drawing.Color.FromArgb(22, 32, 48);
            lbLc2.Location  = new System.Drawing.Point(360, senY + 36);
            lbLc2.Size      = new System.Drawing.Size(senBoxW + 6, 36); // PanelOut 우측까지
            lbLc2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 영점 버튼 3개 (센서별 개별)
            void ZeroBtn(System.Windows.Forms.Button b, string txt, int x)
            {
                b.Text      = txt;
                b.Font      = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
                b.BackColor = System.Drawing.Color.FromArgb(120, 53, 15);
                b.ForeColor = System.Drawing.Color.White;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Location  = new System.Drawing.Point(x, senY + 80);
                b.Size      = new System.Drawing.Size(168, 38);
            }
            ZeroBtn(btnZeroLvdt, "LVDT 영점",   12);
            ZeroBtn(btnZeroLc1,  "로드셀1 영점", 186);
            ZeroBtn(btnZeroLc2,  "로드셀2 영점", 360);

            // ─ 닫기 버튼 ─
            button2.Text      = "창  닫  기";
            button2.Font      = new System.Drawing.Font("맑은 고딕", 11F);
            button2.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            button2.ForeColor = System.Drawing.Color.White;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Location  = new System.Drawing.Point(1114, 668);
            button2.Size      = new System.Drawing.Size(100, 36);
            button2.Click    += new System.EventHandler(this.button2_Click);

            // ─ Form ─
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.ClientSize    = new System.Drawing.Size(1230, 710);
            this.ControlBox    = false;
            this.Font          = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin        = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name          = "_FrmSignalPlc1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "시그널";

            this.Controls.Add(label1);
            this.Controls.Add(label5);
            this.Controls.Add(label2);
            this.Controls.Add(label3);   this.Controls.Add(label4);
            this.Controls.Add(label9);   this.Controls.Add(label10);
            this.Controls.Add(PanelIn);  this.Controls.Add(PanelIn2);
            this.Controls.Add(PanelOut);
            this.Controls.Add(Panel4008); this.Controls.Add(Panel4009);
            this.Controls.Add(Panel4012); this.Controls.Add(Panel4014);
            this.Controls.Add(lblServCtrl); this.Controls.Add(lblJogSec);
            this.Controls.Add(btnJogFwd); this.Controls.Add(btnJogBwd);
            this.Controls.Add(lblPosSec);
            this.Controls.Add(label18);  this.Controls.Add(lbVal1);
            this.Controls.Add(label22);  this.Controls.Add(lbVal3);
            this.Controls.Add(lblSensorHdr);
            this.Controls.Add(lblLvdtTitle); this.Controls.Add(lbLvdt);
            this.Controls.Add(lblLc1Title);  this.Controls.Add(lbLc1);
            this.Controls.Add(lblLc2Title);  this.Controls.Add(lbLc2);
            this.Controls.Add(btnZeroLvdt);
            this.Controls.Add(btnZeroLc1);
            this.Controls.Add(btnZeroLc2);
            this.Controls.Add(button2);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TableLayoutPanel PanelIn;
        private System.Windows.Forms.TableLayoutPanel PanelIn2;
        private System.Windows.Forms.TableLayoutPanel PanelOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel Panel4008;
        private System.Windows.Forms.TableLayoutPanel Panel4009;
        private System.Windows.Forms.TableLayoutPanel Panel4012;
        private System.Windows.Forms.TableLayoutPanel Panel4014;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbVal1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbVal3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnJogFwd;
        private System.Windows.Forms.Button btnJogBwd;
        private System.Windows.Forms.TextBox[] txtPosCoord;
        private System.Windows.Forms.TextBox[] txtPosSpd;
        private System.Windows.Forms.TextBox[] txtPosComment;
        private System.Windows.Forms.Button[]  btnGo;
        private System.Windows.Forms.Button    btnSavePos;
        private System.Windows.Forms.TextBox   txtJogSpd;
        private System.Windows.Forms.TextBox   txtDiffSpd;
        private System.Windows.Forms.Label lblServCtrl;
        private System.Windows.Forms.Label lblJogSec;
        private System.Windows.Forms.Label lblPosSec;
        private System.Windows.Forms.Label lblSensorHdr;
        private System.Windows.Forms.Label lblLvdtTitle;
        private System.Windows.Forms.Label lbLvdt;
        private System.Windows.Forms.Label lblLc1Title;
        private System.Windows.Forms.Label lbLc1;
        private System.Windows.Forms.Label lblLc2Title;
        private System.Windows.Forms.Label lbLc2;
        private System.Windows.Forms.Button btnZeroLvdt;
        private System.Windows.Forms.Button btnZeroLc1;
        private System.Windows.Forms.Button btnZeroLc2;
    }
}
