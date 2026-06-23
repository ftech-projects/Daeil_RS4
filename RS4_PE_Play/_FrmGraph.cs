using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using ZedGraph;

namespace Daeil_SW_ReclTest
{
    public partial class _FrmGraph : Form
    {
        public _FrmGraph()
        {
            InitializeComponent();
            InitGraph();
        }

        private void InitGraph()
        {
            GraphPane pane = zedGraph1.GraphPane;
            pane.Title.Text = "Raw Profile";
            pane.XAxis.Title.Text = "X";
            pane.YAxis.Title.Text = "Y";
            pane.CurveList.Clear();
            pane.GraphObjList.Clear();

            LineItem curve = pane.AddCurve("Data", new PointPairList(), System.Drawing.Color.Black, SymbolType.None);
            curve.Line.Width = 2.0f;

            zedGraph1.AxisChange();
            zedGraph1.Invalidate();
        }

        public void PlotFromCsv(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("파일이 없거나 경로가 비었습니다.");
                return;
            }

            GraphPane pane = zedGraph1.GraphPane;
            pane.CurveList.Clear();

            // ── Diff 파일 여부 체크
            bool isDiff = filePath.IndexOf("Diff", StringComparison.OrdinalIgnoreCase) >= 0;

            LineItem curve = pane.AddCurve(Path.GetFileName(filePath),
                                           new PointPairList(),
                                           System.Drawing.Color.Black,
                                           SymbolType.Circle);

            if (isDiff)
            {
                // 선은 없애고 점만
                curve.Line.IsVisible = false;
                curve.Symbol.Type = SymbolType.Circle;
                curve.Symbol.Size = 6;
                curve.Symbol.Fill = new Fill(System.Drawing.Color.Black);
                curve.Symbol.Border.IsVisible = false;
            }
            else
            {
                // 일반 파일 → 선으로
                curve.Line.Width = 2.0f;
                curve.Symbol.Type = SymbolType.None;
            }

            PointPairList list = (PointPairList)curve.Points;

            string[] lines = File.ReadAllLines(filePath);
            int i;
            for (i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (line.Length == 0) continue;
                if (i == 0 && (line.IndexOf("X", StringComparison.OrdinalIgnoreCase) >= 0 &&
                               line.IndexOf("Y", StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    // 헤더 건너뜀
                    continue;
                }

                string[] parts = line.Split(',');
                if (parts.Length < 2) continue;

                double x, y;
                if (double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out x) &&
                    double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out y))
                {
                    list.Add(x, y);
                }
            }

            zedGraph1.AxisChange();
            zedGraph1.Invalidate();
        }

    }
}
