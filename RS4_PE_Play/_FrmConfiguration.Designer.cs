namespace WindowsFormsApp1
{
    partial class _FrmConfiguration
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl          = new System.Windows.Forms.TabControl();
            this.tabComm             = new System.Windows.Forms.TabPage();
            this.tabMeasure          = new System.Windows.Forms.TabPage();
            this.tabSql              = new System.Windows.Forms.TabPage();
            this.propertyGrid1       = new System.Windows.Forms.PropertyGrid();
            this.propertyGridMeasure = new System.Windows.Forms.PropertyGrid();
            this.chkSqlEnabled       = new System.Windows.Forms.CheckBox();
            this.lblSqlIp            = new System.Windows.Forms.Label();
            this.txtSqlIp            = new System.Windows.Forms.TextBox();
            this.lblSqlInstance      = new System.Windows.Forms.Label();
            this.txtSqlInstance      = new System.Windows.Forms.TextBox();
            this.lblSqlCatalog       = new System.Windows.Forms.Label();
            this.txtSqlCatalog       = new System.Windows.Forms.TextBox();
            this.lblSqlUser          = new System.Windows.Forms.Label();
            this.txtSqlUser          = new System.Windows.Forms.TextBox();
            this.lblSqlPwd           = new System.Windows.Forms.Label();
            this.txtSqlPwd           = new System.Windows.Forms.TextBox();
            this.button3             = new System.Windows.Forms.Button();
            this.button2             = new System.Windows.Forms.Button();
            this.SuspendLayout();

            var propFont = new System.Drawing.Font("맑은 고딕", 11.25F);
            var fldFont  = new System.Drawing.Font("맑은 고딕", 11F);
            var btnFont  = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);

            // ── propertyGrid1 ─────────────────────────────────────────────
            this.propertyGrid1.Font = propFont;
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;

            // ── propertyGridMeasure ───────────────────────────────────────
            this.propertyGridMeasure.Font = propFont;
            this.propertyGridMeasure.Dock = System.Windows.Forms.DockStyle.Fill;

            // ── SQL 서버 설정 컨트롤 ──────────────────────────────────────
            int lx = 20, tx = 170, tw = 250, rh = 34;

            this.chkSqlEnabled.Text      = "SQL 서버 사용";
            this.chkSqlEnabled.Font      = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.chkSqlEnabled.Location  = new System.Drawing.Point(lx, 30);
            this.chkSqlEnabled.Size      = new System.Drawing.Size(200, 28);
            this.chkSqlEnabled.CheckedChanged += new System.EventHandler(this.ChkSqlEnabled_CheckedChanged);

            this.lblSqlIp.Text      = "서버 IP :";
            this.lblSqlIp.Font      = fldFont;
            this.lblSqlIp.Location  = new System.Drawing.Point(lx, 80);
            this.lblSqlIp.Size      = new System.Drawing.Size(145, rh);
            this.lblSqlIp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtSqlIp.Font     = fldFont;
            this.txtSqlIp.Location = new System.Drawing.Point(tx, 80);
            this.txtSqlIp.Size     = new System.Drawing.Size(tw, rh);

            this.lblSqlInstance.Text      = "인스턴스명 :";
            this.lblSqlInstance.Font      = fldFont;
            this.lblSqlInstance.Location  = new System.Drawing.Point(lx, 126);
            this.lblSqlInstance.Size      = new System.Drawing.Size(145, rh);
            this.lblSqlInstance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtSqlInstance.Font     = fldFont;
            this.txtSqlInstance.Location = new System.Drawing.Point(tx, 126);
            this.txtSqlInstance.Size     = new System.Drawing.Size(tw, rh);

            this.lblSqlCatalog.Text      = "데이터베이스 :";
            this.lblSqlCatalog.Font      = fldFont;
            this.lblSqlCatalog.Location  = new System.Drawing.Point(lx, 172);
            this.lblSqlCatalog.Size      = new System.Drawing.Size(145, rh);
            this.lblSqlCatalog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtSqlCatalog.Font     = fldFont;
            this.txtSqlCatalog.Location = new System.Drawing.Point(tx, 172);
            this.txtSqlCatalog.Size     = new System.Drawing.Size(tw, rh);

            this.lblSqlUser.Text      = "사용자 ID :";
            this.lblSqlUser.Font      = fldFont;
            this.lblSqlUser.Location  = new System.Drawing.Point(lx, 218);
            this.lblSqlUser.Size      = new System.Drawing.Size(145, rh);
            this.lblSqlUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtSqlUser.Font     = fldFont;
            this.txtSqlUser.Location = new System.Drawing.Point(tx, 218);
            this.txtSqlUser.Size     = new System.Drawing.Size(tw, rh);

            this.lblSqlPwd.Text      = "비밀번호 :";
            this.lblSqlPwd.Font      = fldFont;
            this.lblSqlPwd.Location  = new System.Drawing.Point(lx, 264);
            this.lblSqlPwd.Size      = new System.Drawing.Size(145, rh);
            this.lblSqlPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtSqlPwd.Font         = fldFont;
            this.txtSqlPwd.Location     = new System.Drawing.Point(tx, 264);
            this.txtSqlPwd.Size         = new System.Drawing.Size(tw, rh);
            this.txtSqlPwd.PasswordChar = '*';

            // ── 탭 페이지 ─────────────────────────────────────────────────
            this.tabComm.Text    = "통신 설정";
            this.tabComm.Padding = new System.Windows.Forms.Padding(4);
            this.tabComm.Controls.Add(this.propertyGrid1);

            this.tabMeasure.Text    = "측정 설정";
            this.tabMeasure.Padding = new System.Windows.Forms.Padding(4);
            this.tabMeasure.Controls.Add(this.propertyGridMeasure);

            this.tabSql.Text    = "SQL 서버 설정";
            this.tabSql.Padding = new System.Windows.Forms.Padding(4);
            this.tabSql.Controls.Add(this.chkSqlEnabled);
            this.tabSql.Controls.Add(this.lblSqlIp);
            this.tabSql.Controls.Add(this.txtSqlIp);
            this.tabSql.Controls.Add(this.lblSqlInstance);
            this.tabSql.Controls.Add(this.txtSqlInstance);
            this.tabSql.Controls.Add(this.lblSqlCatalog);
            this.tabSql.Controls.Add(this.txtSqlCatalog);
            this.tabSql.Controls.Add(this.lblSqlUser);
            this.tabSql.Controls.Add(this.txtSqlUser);
            this.tabSql.Controls.Add(this.lblSqlPwd);
            this.tabSql.Controls.Add(this.txtSqlPwd);

            // ── TabControl ────────────────────────────────────────────────
            this.tabControl.Font     = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Size     = new System.Drawing.Size(772, 522);
            this.tabControl.Padding  = new System.Drawing.Point(20, 0);
            this.tabControl.TabPages.Add(this.tabComm);
            this.tabControl.TabPages.Add(this.tabMeasure);
            this.tabControl.TabPages.Add(this.tabSql);

            // ── 버튼 ──────────────────────────────────────────────────────
            this.button3.Text     = "적용";
            this.button3.Font     = btnFont;
            this.button3.Location = new System.Drawing.Point(404, 546);
            this.button3.Size     = new System.Drawing.Size(185, 50);
            this.button3.Click   += new System.EventHandler(this.button3_Click);

            this.button2.Text     = "닫기";
            this.button2.Font     = btnFont;
            this.button2.Location = new System.Drawing.Point(599, 546);
            this.button2.Size     = new System.Drawing.Size(185, 50);
            this.button2.Click   += new System.EventHandler(this.button2_Click);

            // ── Form ──────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize          = new System.Drawing.Size(796, 608);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Name = "_FrmConfiguration";
            this.Text = "환경 설정";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage    tabComm;
        private System.Windows.Forms.TabPage    tabMeasure;
        private System.Windows.Forms.TabPage    tabSql;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.PropertyGrid propertyGridMeasure;
        private System.Windows.Forms.CheckBox  chkSqlEnabled;
        private System.Windows.Forms.Label     lblSqlIp;
        private System.Windows.Forms.TextBox   txtSqlIp;
        private System.Windows.Forms.Label     lblSqlInstance;
        private System.Windows.Forms.TextBox   txtSqlInstance;
        private System.Windows.Forms.Label     lblSqlCatalog;
        private System.Windows.Forms.TextBox   txtSqlCatalog;
        private System.Windows.Forms.Label     lblSqlUser;
        private System.Windows.Forms.TextBox   txtSqlUser;
        private System.Windows.Forms.Label     lblSqlPwd;
        private System.Windows.Forms.TextBox   txtSqlPwd;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}
