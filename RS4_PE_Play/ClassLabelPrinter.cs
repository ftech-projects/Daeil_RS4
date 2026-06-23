using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1
{
    public class LabelTemplate
    {
        public int BarcodeID { get; set; }
        public string Name { get; set; }
        public int LabelWidth { get; set; }      // mm
        public int LabelHeight { get; set; }     // mm
        public string DataMatrixFormat { get; set; }
        public List<LabelElement> Elements { get; set; }

        public LabelTemplate()
        {
            Name = "기본";
            LabelWidth = 60;
            LabelHeight = 40;
            DataMatrixFormat = "GS1";
            Elements = new List<LabelElement>();
        }
    }

    public class LabelElement
    {
        public string Type { get; set; }         // DataMatrix / Text / Line
        public string Field { get; set; }        // PartNo / SerialNo / DateTime / Result / (static)
        public string Text { get; set; }         // 고정 텍스트 (Field가 비어있을 때 사용)
        public int X { get; set; }               // mm
        public int Y { get; set; }               // mm
        public int Width { get; set; }           // mm
        public int Height { get; set; }          // mm
        public int Size1 { get; set; }           // DataMatrix: 셀 크기(dots), Line: 두께
        public int Size2 { get; set; }           // DataMatrix: ECC (0=자동)
        public int FontSize { get; set; }        // pt (0=기본)
        public string FontWeight { get; set; }   // Normal / Bold
        public string FontFamily { get; set; }   // 폰트명 (ZPL A0N 기준)
        public int NgFontHeight { get; set; }    // ZPL 폰트 높이 (dots)
        public int NgFontWidth { get; set; }     // ZPL 폰트 폭 (dots)

        public LabelElement()
        {
            Type = "Text";
            Field = "";
            Text = "";
            FontWeight = "Normal";
            FontFamily = "A0";
            NgFontHeight = 30;
            NgFontWidth = 0;
        }
    }

    public class ClassLabelPrinter
    {
        // 203 DPI 기준 mm→dots 변환 계수
        private const double MM_TO_DOTS = 8.0;

        private SerialPort _port;

        public void SetSerialPort(SerialPort port) => _port = port;

        // JSON 파일에서 템플릿 로드
        public static LabelTemplate LoadTemplate(string jsonPath)
        {
            if (!File.Exists(jsonPath)) return null;
            string json = File.ReadAllText(jsonPath, Encoding.UTF8);
            var ser = new JavaScriptSerializer();
            return ser.Deserialize<LabelTemplate>(json);
        }

        // 템플릿을 JSON 파일로 저장
        public static void SaveTemplate(LabelTemplate t, string jsonPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(jsonPath));
            var ser = new JavaScriptSerializer();
            string json = ser.Serialize(t);
            File.WriteAllText(jsonPath, json, Encoding.UTF8);
        }

        // 기본 템플릿 16개 생성
        public static void CreateDefaultTemplates(string folder)
        {
            Directory.CreateDirectory(folder);
            for (int id = 1; id <= 16; id++)
            {
                string path = Path.Combine(folder, $"Barcode_{id}.json");
                if (File.Exists(path)) continue;
                var t = new LabelTemplate
                {
                    BarcodeID   = id,
                    Name        = $"템플릿 {id}",
                    LabelWidth  = 60,
                    LabelHeight = 40,
                    Elements = new List<LabelElement>
                    {
                        new LabelElement { Type="DataMatrix", Field="SerialNo", X=2, Y=2, Size1=4, Size2=0 },
                        new LabelElement { Type="Text",       Field="PartNo",   X=24, Y=2,  NgFontHeight=30, NgFontWidth=0 },
                        new LabelElement { Type="Text",       Field="PartName", X=24, Y=12, NgFontHeight=25, NgFontWidth=0 },
                        new LabelElement { Type="Text",       Field="DateTime", X=24, Y=22, NgFontHeight=20, NgFontWidth=0 },
                    }
                };
                SaveTemplate(t, path);
            }
        }

        // 라벨 출력
        public void PrintLabel(string jsonPath, Dictionary<string, string> fieldValues)
        {
            var t = LoadTemplate(jsonPath);
            if (t == null) return;
            string zpl = BuildZpl(t, fieldValues);
            SendZpl(zpl);
        }

        // 미리보기 ZPL 생성 (외부 호출용)
        public string BuildZplForPreview(LabelTemplate t, Dictionary<string, string> fieldValues)
        {
            return BuildZpl(t, fieldValues);
        }

        private string BuildZpl(LabelTemplate t, Dictionary<string, string> fieldValues)
        {
            var sb = new StringBuilder();
            int pw = (int)(t.LabelWidth  * MM_TO_DOTS);
            int ll = (int)(t.LabelHeight * MM_TO_DOTS);

            sb.AppendLine("^XA");
            sb.AppendLine($"^PW{pw}");
            sb.AppendLine($"^LL{ll}");
            sb.AppendLine("^LH0,0");

            foreach (var el in t.Elements)
            {
                int x = (int)(el.X * MM_TO_DOTS);
                int y = (int)(el.Y * MM_TO_DOTS);
                string content = ResolveField(el, fieldValues);

                if (el.Type == "DataMatrix")
                {
                    int s1 = el.Size1 > 0 ? el.Size1 : 4;
                    int s2 = el.Size2;
                    sb.AppendLine($"^FO{x},{y}");
                    sb.AppendLine($"^BXN,{s1},{s2}");
                    sb.AppendLine($"^FH^FD{EncodeFieldHexForFh(content)}^FS");
                }
                else if (el.Type == "Text")
                {
                    int fh = el.NgFontHeight > 0 ? el.NgFontHeight : 30;
                    int fw = el.NgFontWidth;
                    string fn = string.IsNullOrEmpty(el.FontFamily) ? "A0" : el.FontFamily;
                    sb.AppendLine($"^FO{x},{y}");
                    sb.AppendLine($"^{fn}N,{fh},{fw}");
                    sb.AppendLine($"^FD{content}^FS");
                }
                else if (el.Type == "Line")
                {
                    int w = (int)(el.Width  * MM_TO_DOTS);
                    int h = (int)(el.Height * MM_TO_DOTS);
                    int thick = el.Size1 > 0 ? el.Size1 : 2;
                    sb.AppendLine($"^FO{x},{y}");
                    sb.AppendLine($"^GB{w},{h},{thick}^FS");
                }
            }
            sb.AppendLine("^XZ");
            return sb.ToString();
        }

        private string ResolveField(LabelElement el, Dictionary<string, string> fieldValues)
        {
            if (!string.IsNullOrEmpty(el.Field) && fieldValues != null &&
                fieldValues.ContainsKey(el.Field))
                return fieldValues[el.Field];
            return el.Text ?? "";
        }

        private string EncodeFieldHexForFh(string text)
        {
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (c < 0x20 || c == '_')
                    sb.Append($"_{(int)c:X2}");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private void SendZpl(string zpl)
        {
            if (_port == null || !_port.IsOpen) return;
            byte[] data = Encoding.ASCII.GetBytes(zpl);
            _port.Write(data, 0, data.Length);
        }
    }
}
