namespace WindowsFormsApp1
{
    partial class _FrmPartManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            var bgDark    = System.Drawing.Color.FromArgb(15,  23,  42);
            var bgCard    = System.Drawing.Color.FromArgb(22,  32,  48);
            var bgCard2   = System.Drawing.Color.FromArgb(30,  41,  59);
            var colorCyan = System.Drawing.Color.FromArgb(6,  182, 212);
            var colorText = System.Drawing.Color.FromArgb(148,163, 184);
            var colorSlate= System.Drawing.Color.FromArgb(51,  65,  85);
            var fontBold  = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            var fontNorm  = new System.Drawing.Font("맑은 고딕", 11F);

            this.dgv          = new System.Windows.Forms.DataGridView();
            this.lblPartNo    = new System.Windows.Forms.Label();
            this.lblPartName  = new System.Windows.Forms.Label();
            this.txtPartNo    = new System.Windows.Forms.TextBox();
            this.txtPartName  = new System.Windows.Forms.TextBox();
            this.btnAdd       = new System.Windows.Forms.Button();
            this.btnEdit      = new System.Windows.Forms.Button();
            this.btnDelete    = new System.Windows.Forms.Button();
            this.btnClose     = new System.Windows.Forms.Button();
            this.panelBottom  = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)this.dgv).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // ── 폼 ──────────────────────────────────────────────────────────
            this.Text            = "품번 관리";
            this.Size            = new System.Drawing.Size(800, 650);
            this.MinimumSize     = new System.Drawing.Size(640, 500);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor       = bgDark;
            this.ForeColor       = colorText;
            this.Font            = fontNorm;

            // ── DataGridView ────────────────────────────────────────────────
            this.dgv.Dock                          = System.Windows.Forms.DockStyle.Fill;
            this.dgv.BackgroundColor               = bgCard;
            this.dgv.GridColor                     = colorSlate;
            this.dgv.BorderStyle                   = System.Windows.Forms.BorderStyle.None;
            this.dgv.DefaultCellStyle.BackColor    = bgCard;
            this.dgv.DefaultCellStyle.ForeColor    = colorText;
            this.dgv.DefaultCellStyle.SelectionBackColor = colorCyan;
            this.dgv.DefaultCellStyle.SelectionForeColor = bgDark;
            this.dgv.DefaultCellStyle.Font         = fontNorm;
            this.dgv.ColumnHeadersDefaultCellStyle.BackColor  = bgCard2;
            this.dgv.ColumnHeadersDefaultCellStyle.ForeColor  = colorCyan;
            this.dgv.ColumnHeadersDefaultCellStyle.Font       = fontBold;
            this.dgv.ColumnHeadersBorderStyle      = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv.RowHeadersVisible             = false;
            this.dgv.AllowUserToAddRows            = false;
            this.dgv.AllowUserToDeleteRows         = false;
            this.dgv.ReadOnly                      = true;
            this.dgv.SelectionMode                 = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AutoSizeColumnsMode           = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.EnableHeadersVisualStyles     = false;

            // ── 하단 패널 ───────────────────────────────────────────────────
            this.panelBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height    = 140;
            this.panelBottom.BackColor = bgCard;
            this.panelBottom.Padding   = new System.Windows.Forms.Padding(12, 8, 12, 8);

            void StyleLbl(System.Windows.Forms.Label l, string txt, int x, int y)
            {
                l.Text      = txt;
                l.Font      = fontBold;
                l.ForeColor = colorText;
                l.BackColor = bgCard;
                l.Location  = new System.Drawing.Point(x, y);
                l.AutoSize  = true;
            }
            void StyleTxt(System.Windows.Forms.TextBox t, int x, int y, int w)
            {
                t.Location   = new System.Drawing.Point(x, y);
                t.Size       = new System.Drawing.Size(w, 30);
                t.BackColor  = bgCard2;
                t.ForeColor  = colorText;
                t.Font       = fontNorm;
                t.BorderStyle= System.Windows.Forms.BorderStyle.FixedSingle;
            }
            void StyleBtn(System.Windows.Forms.Button b, string txt,
                System.Drawing.Color bg, int x, int y, int w = 88)
            {
                b.Text      = txt;
                b.Font      = fontBold;
                b.BackColor = bg;
                b.ForeColor = colorText;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Location  = new System.Drawing.Point(x, y);
                b.Size      = new System.Drawing.Size(w, 36);
            }

            StyleLbl(this.lblPartNo,     "품번 :", 12, 16);
            StyleTxt(this.txtPartNo,     76, 12, 220);
            StyleLbl(this.lblPartName,   "품명 :", 12, 56);
            StyleTxt(this.txtPartName,   76, 52, 220);
            var btnGreen = System.Drawing.Color.FromArgb(20,  83, 45);
            var btnBlue  = System.Drawing.Color.FromArgb(29,  78, 216);
            var btnRed   = System.Drawing.Color.FromArgb(127, 29, 29);

            StyleBtn(this.btnAdd,    "추가",  btnGreen, 12,  96);
            StyleBtn(this.btnEdit,   "수정",  btnBlue,  116, 96);
            StyleBtn(this.btnDelete, "삭제",  btnRed,   220, 96);
            StyleBtn(this.btnClose,  "닫기",  colorSlate,
                this.panelBottom.Width - 106, 96, 94);
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom |
                                   System.Windows.Forms.AnchorStyles.Right;

            this.panelBottom.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblPartNo, this.txtPartNo,
                this.lblPartName, this.txtPartName,
                this.btnAdd, this.btnEdit, this.btnDelete, this.btnClose,
            });

            // ── 폼에 추가 ───────────────────────────────────────────────────
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panelBottom);

            ((System.ComponentModel.ISupportInitialize)this.dgv).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label   lblPartNo;
        private System.Windows.Forms.Label   lblPartName;
        private System.Windows.Forms.TextBox txtPartNo;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Button  btnAdd;
        private System.Windows.Forms.Button  btnEdit;
        private System.Windows.Forms.Button  btnDelete;
        private System.Windows.Forms.Button  btnClose;
        private System.Windows.Forms.Panel   panelBottom;
    }
}
