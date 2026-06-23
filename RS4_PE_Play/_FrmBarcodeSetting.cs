using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class _FrmBarcodeSetting : Form
    {
        private static readonly string LabelFolder =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Labels");

        public _FrmBarcodeSetting()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            // Dock 완료 후 버튼 위치 재계산 (InitializeComponent 타이밍 문제 보정)
            RepositionBottomButtons();
            panelBottom.Resize += (s, ev) => RepositionBottomButtons();

            RefreshPorts();

            // NUD 변경 시 ZPL 자동 갱신 (Designer에 이벤트 미등록이므로 여기서 연결)
            foreach (var nud in new NumericUpDown[] {
                nudDmX, nudDmY, nudDmMod,
                nudT1X, nudT1Y, nudT1H, nudT1W,
                nudT2X, nudT2Y, nudT2H, nudT2W,
                nudT3X, nudT3Y, nudT3H, nudT3W,
                nudT4X, nudT4Y, nudT4H, nudT4W })
                nud.ValueChanged += (s, ev) => GenerateZpl();

            foreach (var chk in new CheckBox[] { chkT1, chkT2, chkT3, chkT4 })
                chk.CheckedChanged += (s, ev) => GenerateZpl();

            LoadSettings();
            GenerateZpl();
        }

        private void RepositionBottomButtons()
        {
            int pw = panelBottom.ClientSize.Width;
            btnClose.Location = new System.Drawing.Point(pw - 8 - 100, 9);
            btnSave.Location  = new System.Drawing.Point(pw - 8 - 100 - 8 - 100, 9);
            btnPrint.Location = new System.Drawing.Point(pw - 8 - 100 - 8 - 100 - 8 - 108, 9);
        }

        private void RefreshPorts()
        {
            string current = cmbPort.SelectedItem?.ToString()
                             ?? GlobalValues.PrinterPort ?? "";
            cmbPort.Items.Clear();
            foreach (var p in SerialPort.GetPortNames())
                cmbPort.Items.Add(p);
            int idx = cmbPort.Items.IndexOf(current);
            if (idx >= 0)
                cmbPort.SelectedIndex = idx;
            else if (cmbPort.Items.Count > 0)
                cmbPort.SelectedIndex = 0;
        }

        private void LoadSettings()
        {
            ClassLabelPrinter.CreateDefaultTemplates(LabelFolder);
            var t = ClassLabelPrinter.LoadTemplate(
                Path.Combine(LabelFolder, "Barcode_1.json"));
            if (t == null) return;

            var dm = t.Elements?.Find(el => el.Type == "DataMatrix");
            if (dm != null)
            {
                nudDmX.Value   = Clamp(dm.X,     nudDmX);
                nudDmY.Value   = Clamp(dm.Y,     nudDmY);
                nudDmMod.Value = Clamp(dm.Size1, nudDmMod);
            }

            var texts = t.Elements?.FindAll(el => el.Type == "Text")
                        ?? new List<LabelElement>();
            ApplyTextEl(texts, 0, nudT1X, nudT1Y, nudT1H, nudT1W, chkT1);
            ApplyTextEl(texts, 1, nudT2X, nudT2Y, nudT2H, nudT2W, chkT2);
            ApplyTextEl(texts, 2, nudT3X, nudT3Y, nudT3H, nudT3W, chkT3);
            ApplyTextEl(texts, 3, nudT4X, nudT4Y, nudT4H, nudT4W, chkT4);
        }

        private void ApplyTextEl(List<LabelElement> list, int i,
            NumericUpDown x, NumericUpDown y, NumericUpDown h, NumericUpDown w, CheckBox chk)
        {
            if (i >= list.Count) { chk.Checked = false; return; }
            var el = list[i];
            x.Value   = Clamp(el.X,            x);
            y.Value   = Clamp(el.Y,            y);
            h.Value   = Clamp(el.NgFontHeight, h);
            w.Value   = Clamp(el.NgFontWidth,  w);
            chk.Checked = true;
        }

        private static decimal Clamp(int v, NumericUpDown n) =>
            Math.Max(n.Minimum, Math.Min(n.Maximum, v));

        private void GenerateZpl()
        {
            var sb = new StringBuilder();
            sb.AppendLine("^XA");
            sb.AppendLine(
                $"^FO{nudDmX.Value},{nudDmY.Value}" +
                $"^BXN,{nudDmMod.Value},0" +
                $"^FD{txtBarcode.Text}^FS");

            string[] vals = {
                txtPartNo.Text,
                txtPartName.Text,
                txtSerial.Text,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
            };
            var cfg = new (NumericUpDown X, NumericUpDown Y, NumericUpDown H, NumericUpDown W, CheckBox Chk)[]
            {
                (nudT1X, nudT1Y, nudT1H, nudT1W, chkT1),
                (nudT2X, nudT2Y, nudT2H, nudT2W, chkT2),
                (nudT3X, nudT3Y, nudT3H, nudT3W, chkT3),
                (nudT4X, nudT4Y, nudT4H, nudT4W, chkT4),
            };

            for (int i = 0; i < 4; i++)
            {
                if (!cfg[i].Chk.Checked) continue;
                sb.AppendLine(
                    $"^FO{cfg[i].X.Value},{cfg[i].Y.Value}" +
                    $"^A0N,{cfg[i].H.Value},{cfg[i].W.Value}" +
                    $"^FD{vals[i]}^FS");
            }

            sb.Append("^XZ");
            txtZpl.Text = sb.ToString();
        }

        private LabelTemplate BuildTemplate()
        {
            var t = new LabelTemplate { BarcodeID = 1 };
            t.Elements.Add(new LabelElement
            {
                Type  = "DataMatrix", Field = "SerialNo",
                X     = (int)nudDmX.Value,
                Y     = (int)nudDmY.Value,
                Size1 = (int)nudDmMod.Value,
            });

            string[] fields = { "PartNo", "PartName", "SerialNo", "DateTime" };
            var cfg = new (NumericUpDown X, NumericUpDown Y, NumericUpDown H, NumericUpDown W, CheckBox Chk)[]
            {
                (nudT1X, nudT1Y, nudT1H, nudT1W, chkT1),
                (nudT2X, nudT2Y, nudT2H, nudT2W, chkT2),
                (nudT3X, nudT3Y, nudT3H, nudT3W, chkT3),
                (nudT4X, nudT4Y, nudT4H, nudT4W, chkT4),
            };

            for (int i = 0; i < 4; i++)
            {
                if (!cfg[i].Chk.Checked) continue;
                t.Elements.Add(new LabelElement
                {
                    Type = "Text", Field = fields[i],
                    X    = (int)cfg[i].X.Value, Y    = (int)cfg[i].Y.Value,
                    NgFontHeight = (int)cfg[i].H.Value,
                    NgFontWidth  = (int)cfg[i].W.Value,
                });
            }
            return t;
        }

        // ── 이벤트 핸들러 ─────────────────────────────────────────────────
        private void btnRefreshPort_Click(object sender, EventArgs e) => RefreshPorts();

        private void txtSample_TextChanged(object sender, EventArgs e) => GenerateZpl();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPort.SelectedItem != null)
                {
                    GlobalValues.PrinterPort = cmbPort.SelectedItem.ToString();
                    new IniFile("config.ini").WriteValue("System", "PrinterPort", GlobalValues.PrinterPort);
                }
                ClassLabelPrinter.SaveTemplate(
                    BuildTemplate(),
                    Path.Combine(LabelFolder, "Barcode_1.json"));
                lblStatus.Text = $"저장됨: {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "저장 실패";
                MessageBox.Show($"저장 중 오류:\n{ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string portName = cmbPort.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(portName))
            {
                lblStatus.Text = "포트를 선택하세요";
                return;
            }
            byte[] data = Encoding.ASCII.GetBytes(txtZpl.Text);
            SerialPort sp = null;
            try
            {
                sp = new SerialPort(portName, 9600);
                sp.Open();
                sp.Write(data, 0, data.Length);
                lblStatus.Text = $"출력 완료: {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"출력 실패: {ex.Message}";
            }
            finally
            {
                try { sp?.Close(); } catch { }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
    }
}
