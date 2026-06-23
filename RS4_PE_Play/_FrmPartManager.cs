using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class _FrmPartManager : Form
    {
        public _FrmPartManager()
        {
            InitializeComponent();
            Load   += OnLoad;
            Resize += OnResize;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            btnAdd.Click    += BtnAdd_Click;
            btnEdit.Click   += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClose.Click  += (s, ev) => Close();
            dgv.SelectionChanged += Dgv_SelectionChanged;

            RepositionClose();
            LoadGrid();
        }

        private void OnResize(object sender, EventArgs e) => RepositionClose();

        private void RepositionClose()
        {
            btnClose.Location = new System.Drawing.Point(
                panelBottom.ClientSize.Width - 100, btnClose.Top);
        }

        // ── 그리드 로드 ─────────────────────────────────────────────────────
        private void LoadGrid()
        {
            try
            {
                using (var conn = new OleDbConnection(GlobalValues.gConString_Part))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT PartNo, PartName FROM Table_Part ORDER BY PartNo";
                    var dt = new DataTable();
                    new OleDbDataAdapter(cmd).Fill(dt);
                    dgv.DataSource = dt;
                    if (dgv.Columns.Count >= 2)
                    {
                        dgv.Columns[0].HeaderText   = "품번 (PartNo)";
                        dgv.Columns[1].HeaderText   = "품명 (PartName)";
                        dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgv.Columns[0].Width        = 140;   // 14자리 기준
                        dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"목록 로드 실패:\n{ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── 행 선택 시 입력 필드 채우기 ────────────────────────────────────
        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var row = dgv.SelectedRows[0];
            txtPartNo.Text   = row.Cells[0].Value?.ToString() ?? "";
            txtPartName.Text = row.Cells[1].Value?.ToString() ?? "";
        }

        // ── 추가 ────────────────────────────────────────────────────────────
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string partNo   = txtPartNo.Text.Trim();
            string partName = txtPartName.Text.Trim();
            if (string.IsNullOrEmpty(partNo))
            {
                MessageBox.Show("품번을 입력하세요.", "알림");
                return;
            }
            try
            {
                using (var conn = new OleDbConnection(GlobalValues.gConString_Part))
                {
                    conn.Open();
                    var chk = conn.CreateCommand();
                    chk.CommandText = "SELECT COUNT(*) FROM Table_Part WHERE PartNo = ?";
                    chk.Parameters.AddWithValue("?", partNo);
                    if ((int)chk.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("이미 존재하는 품번입니다.", "알림");
                        return;
                    }
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Table_Part (PartNo, PartName, PART_SCRIPT) VALUES (?,?,?)";
                    cmd.Parameters.AddWithValue("?", partNo);
                    cmd.Parameters.AddWithValue("?", partName);
                    cmd.Parameters.AddWithValue("?", "");
                    cmd.ExecuteNonQuery();
                }
                ClearInput();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"추가 실패:\n{ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── 수정 ────────────────────────────────────────────────────────────
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("수정할 행을 선택하세요.", "알림");
                return;
            }
            string origPartNo = dgv.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
            string partName   = txtPartName.Text.Trim();
            try
            {
                using (var conn = new OleDbConnection(GlobalValues.gConString_Part))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE Table_Part SET PartName = ? WHERE PartNo = ?";
                    cmd.Parameters.AddWithValue("?", partName);
                    cmd.Parameters.AddWithValue("?", origPartNo);
                    cmd.ExecuteNonQuery();
                }
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"수정 실패:\n{ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── 삭제 ────────────────────────────────────────────────────────────
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 행을 선택하세요.", "알림");
                return;
            }
            string partNo = dgv.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
            if (MessageBox.Show($"'{partNo}' 을(를) 삭제하시겠습니까?", "확인",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            try
            {
                using (var conn = new OleDbConnection(GlobalValues.gConString_Part))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Table_Part WHERE PartNo = ?";
                    cmd.Parameters.AddWithValue("?", partNo);
                    cmd.ExecuteNonQuery();
                }
                ClearInput();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"삭제 실패:\n{ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInput()
        {
            txtPartNo.Text   = "";
            txtPartName.Text = "";
        }
    }
}
