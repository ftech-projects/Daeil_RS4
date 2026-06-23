using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class _FrmConfiguration : Form
    {
        // 탭 스타일 상수
        static readonly Color TAB_ACTIVE_BG   = Color.FromArgb(0, 120, 215);
        static readonly Color TAB_INACTIVE_BG = Color.FromArgb(55, 55, 55);
        static readonly Color TAB_TEXT        = Color.White;
        static readonly Font  TAB_FONT        = new Font("맑은 고딕", 12F, FontStyle.Bold);

        public _FrmConfiguration()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject       = new Configuration();
            propertyGridMeasure.SelectedObject = new ConfigurationMeasure();

            ExpandHelpPanel(propertyGrid1,       80);
            ExpandHelpPanel(propertyGridMeasure, 80);

            // 탭 OwnerDraw
            tabControl.DrawMode  = TabDrawMode.OwnerDrawFixed;
            tabControl.ItemSize  = new Size(0, 40);
            tabControl.DrawItem += TabControl_DrawItem;

            // SQL Server 설정 로드
            chkSqlEnabled.Checked   = GlobalValues.SqlServerEnabled;
            txtSqlIp.Text           = GlobalValues.SqlServerIp;
            txtSqlInstance.Text     = GlobalValues.SqlServerInstance;
            txtSqlCatalog.Text      = GlobalValues.SqlServerCatalog;
            txtSqlUser.Text         = GlobalValues.SqlServerUserId;
            txtSqlPwd.Text          = GlobalValues.SqlServerPassword;
            UpdateSqlFields();
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool active = (e.Index == tabControl.SelectedIndex);
            var  bg     = active ? TAB_ACTIVE_BG : TAB_INACTIVE_BG;
            using (var brush = new SolidBrush(bg))
                e.Graphics.FillRectangle(brush, e.Bounds);

            var text   = tabControl.TabPages[e.Index].Text;
            var sf     = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using (var brush = new SolidBrush(TAB_TEXT))
                e.Graphics.DrawString(text, TAB_FONT, brush, e.Bounds, sf);
        }

        private void UpdateSqlFields()
        {
            bool en = chkSqlEnabled.Checked;
            txtSqlIp.Enabled       = en;
            txtSqlInstance.Enabled = en;
            txtSqlCatalog.Enabled  = en;
            txtSqlUser.Enabled     = en;
            txtSqlPwd.Enabled      = en;
        }

        private void ChkSqlEnabled_CheckedChanged(object sender, EventArgs e)
            => UpdateSqlFields();

        // PropertyGrid 내부 DocComment(설명) 패널 높이 조정
        private static void ExpandHelpPanel(PropertyGrid grid, int height)
        {
            foreach (System.Windows.Forms.Control ctrl in grid.Controls)
            {
                if (ctrl.GetType().Name == "DocComment")
                {
                    var fi = ctrl.GetType().GetField("userSized",
                        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    fi?.SetValue(ctrl, true);
                    ctrl.Height = height;
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (propertyGrid1.SelectedObject as Configuration)?.Apply();
            (propertyGridMeasure.SelectedObject as ConfigurationMeasure)?.Apply();

            GlobalValues.SqlServerEnabled  = chkSqlEnabled.Checked;
            GlobalValues.SqlServerIp       = txtSqlIp.Text.Trim();
            GlobalValues.SqlServerInstance = txtSqlInstance.Text.Trim();
            GlobalValues.SqlServerCatalog  = txtSqlCatalog.Text.Trim();
            GlobalValues.SqlServerUserId   = txtSqlUser.Text.Trim();
            GlobalValues.SqlServerPassword = txtSqlPwd.Text;

            GlobalValues.SaveChannelSettingsToIni();
            MessageBox.Show("환경 설정이 적용되었습니다!");
            PLCData1.FlagRecvAll = true;
            PLCData1.ServoSet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
