using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

/// <summary>그래프 포인트 한 개</summary>
public class GraphPoint
{
    public string Direction;  // "FWD" or "BWD"
    public double X;          // 변위 mm
    public double Y;          // 하중 (단위는 LoadUnit)
}

/// <summary>한 측정 사이클의 메타 + 전방/후방 포인트 전체</summary>
public class GraphRecord
{
    public DateTime MeasureTime;
    public string   Barcode   = "";
    public string   PartNo    = "";
    public string   PartName  = "";
    public double   FwdDisp;
    public double   BwdDisp;
    public double   GapAngle;
    public double   GapSpec;
    public bool     Pass;
    public string   LoadUnit  = "kgf";

    public List<GraphPoint> Points = new List<GraphPoint>();

    // ─────────────────────────────────────────────────────
    // 저장
    // ─────────────────────────────────────────────────────
    public string Save()
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string dir = Path.Combine(baseDir, "GraphData",
            MeasureTime.ToString("yyyy"),
            MeasureTime.ToString("MM"),
            MeasureTime.ToString("dd"));
        Directory.CreateDirectory(dir);

        string safe = MakeSafe(Barcode);
        string fileName = $"{MeasureTime:HHmmss}_{safe}.csv";
        string path = Path.Combine(dir, fileName);

        using (var sw = new StreamWriter(path, false, new UTF8Encoding(false)))
        {
            sw.WriteLine($"#MeasureTime={MeasureTime:yyyy-MM-dd HH:mm:ss}");
            sw.WriteLine($"#Barcode={Barcode}");
            sw.WriteLine($"#PartNo={PartNo}");
            sw.WriteLine($"#PartName={PartName}");
            sw.WriteLine($"#FwdDisp={FwdDisp.ToString(CultureInfo.InvariantCulture)}");
            sw.WriteLine($"#BwdDisp={BwdDisp.ToString(CultureInfo.InvariantCulture)}");
            sw.WriteLine($"#GapAngle={GapAngle.ToString(CultureInfo.InvariantCulture)}");
            sw.WriteLine($"#GapSpec={GapSpec.ToString(CultureInfo.InvariantCulture)}");
            sw.WriteLine($"#Judge={(Pass ? "OK" : "NG")}");
            sw.WriteLine($"#LoadUnit={LoadUnit}");
            sw.WriteLine("Direction,X_mm,Y");
            foreach (var p in Points)
            {
                sw.WriteLine($"{p.Direction}," +
                             $"{p.X.ToString(CultureInfo.InvariantCulture)}," +
                             $"{p.Y.ToString(CultureInfo.InvariantCulture)}");
            }
        }
        return path;
    }

    // ─────────────────────────────────────────────────────
    // 로드
    // ─────────────────────────────────────────────────────
    public static GraphRecord Load(string path)
    {
        var rec = new GraphRecord();
        rec.Points = new List<GraphPoint>();

        foreach (string raw in File.ReadLines(path, Encoding.UTF8))
        {
            string line = raw.Trim();
            if (string.IsNullOrEmpty(line)) continue;

            if (line.StartsWith("#"))
            {
                var kv = line.Substring(1).Split(new[] { '=' }, 2);
                if (kv.Length < 2) continue;
                string k = kv[0].Trim();
                string v = kv[1].Trim();
                switch (k)
                {
                    case "MeasureTime":
                        DateTime.TryParseExact(v, "yyyy-MM-dd HH:mm:ss",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out rec.MeasureTime);
                        break;
                    case "Barcode":   rec.Barcode   = v; break;
                    case "PartNo":    rec.PartNo    = v; break;
                    case "PartName":  rec.PartName  = v; break;
                    case "FwdDisp":   double.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out rec.FwdDisp);  break;
                    case "BwdDisp":   double.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out rec.BwdDisp);  break;
                    case "GapAngle":  double.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out rec.GapAngle); break;
                    case "GapSpec":   double.TryParse(v, NumberStyles.Float, CultureInfo.InvariantCulture, out rec.GapSpec);  break;
                    case "Judge":     rec.Pass = v == "OK"; break;
                    case "LoadUnit":  rec.LoadUnit = v; break;
                }
                continue;
            }

            if (line.StartsWith("Direction")) continue; // 헤더 행

            var cols = line.Split(',');
            if (cols.Length < 3) continue;
            double x, y;
            if (!double.TryParse(cols[1], NumberStyles.Float, CultureInfo.InvariantCulture, out x)) continue;
            if (!double.TryParse(cols[2], NumberStyles.Float, CultureInfo.InvariantCulture, out y)) continue;
            rec.Points.Add(new GraphPoint { Direction = cols[0].Trim(), X = x, Y = y });
        }
        return rec;
    }

    // ─────────────────────────────────────────────────────
    // 날짜별 파일 목록
    // ─────────────────────────────────────────────────────
    public static List<string> GetFileList(DateTime date)
    {
        string dir = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "GraphData",
            date.ToString("yyyy"), date.ToString("MM"), date.ToString("dd"));

        if (!Directory.Exists(dir)) return new List<string>();

        var files = new List<string>(Directory.GetFiles(dir, "*.csv"));
        files.Sort();
        files.Reverse(); // 최신 순
        return files;
    }

    private static string MakeSafe(string s)
    {
        if (string.IsNullOrEmpty(s)) return "NO_BC";
        foreach (char c in Path.GetInvalidFileNameChars())
            s = s.Replace(c, '_');
        return s.Length > 30 ? s.Substring(0, 30) : s;
    }
}
