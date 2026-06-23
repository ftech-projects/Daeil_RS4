using System;
using System.Windows.Forms;

// 유격 측정 데이터 및 설정값
public static class MeasureData1
{
    // 실시간 센서값
    public static double ValueLvdt = 0;           // LVDT 현재값 (mm)
    public static double ValueLoadCell1 = 0;      // 1번 로드셀 (전진용, kgf)
    public static double ValueLoadCell2 = 0;      // 2번 로드셀 (후진용, kgf)

    // 유격 공식 파라미터
    public static double L_mm = 300.0;            // Seat Back Line 길이 L (mm)
    public static double GapSpec = 0.5;           // 유격 스펙
    public static string Unit = "°";              // 유격 단위
    public static string LoadUnit = "kgf";        // 하중 단위

    // 측정 결과
    public static double FwdDisp = 0;             // 전진 변위 측정값 (mm)
    public static double BwdDisp = 0;             // 후진 변위 측정값 (mm)
    public static double GapAngle = 0;            // 유격 각도 (°)

    // 품목 정보
    public static string AssyParNo = "";   // 바코드 원문 (시리얼 번호)
    public static string PartNo    = "";   // DB PartNo 값
    public static string PartName  = "";   // DB PartName 값
    public static string TargetScan = "";

    // 부하 하중: P(kgf) = 4.6(kgf·m) / L(m)
    public static double CalcThreshold()
    {
        if (L_mm <= 0) return 5.0;
        return 4.6 / (L_mm / 1000.0);
    }

    // 유격 계산: 유격(°) = (전진변위 + 후진변위) / L(mm) × 180 / π
    public static double CalcGapAngle()
    {
        if (L_mm <= 0) return 0;
        return (FwdDisp + BwdDisp) / L_mm * 180.0 / Math.PI;
    }
}

// PLC 데이터 (서보 제어)
public static class PLCData1
{
    public static bool FlagRecvAll = true;

    public static bool[,] PlcValueBit = new bool[32, 16];
    public static bool[,] writePlcValueBit = new bool[32, 16];

    public static void SetPlcBit(int dWord, int bitIndex, bool value)
    {
        if (dWord >= 0 && dWord < 32 && bitIndex >= 0 && bitIndex < 16)
            PLCData1.writePlcValueBit[dWord, bitIndex] = value;
    }

    public static int[] PlcValue = new int[10000];
    public static int[] writePlcValue = new int[10000];
    public static int[] lastWriteBuffer = new int[10000];

    public static void SetPlc(int address, int value)
    {
        try
        {
            string hexValue;
            if (value <= 0xFFFF)
            {
                hexValue = value.ToString("X4");
                PLCData1.writePlcValue[address] = Convert.ToUInt16(hexValue, 16);
            }
            else
            {
                hexValue = value.ToString("X8");
                PLCData1.writePlcValue[address] = Convert.ToUInt16(hexValue.Substring(4, 4), 16);
                PLCData1.writePlcValue[address + 1] = Convert.ToUInt16(hexValue.Substring(0, 4), 16);
            }
        }
        catch { }
    }

    public static int Servo1Pos1 = 0, Servo1Pos2 = 0, Servo1Pos3 = 0, Servo1Pos4 = 0, Servo1Pos5 = 0, Servo1Pos6 = 0;
    public static int Servo1Pos1Spd = 0, Servo1Pos2Spd = 0, Servo1Pos3Spd = 0, Servo1Pos4Spd = 0, Servo1Pos5Spd = 0, Servo1Pos6Spd = 0;
    public static string[] Servo1PosComments = new string[] { "포지션1", "포지션2", "포지션3", "포지션4", "포지션5", "포지션6" };
    public static int Servo1JogSpd = 0;
    public static int DiffSpeed = 0;

    public static void ServoSet()
    {
        PLCData1.SetPlc(5002, PLCData1.Servo1JogSpd);
        PLCData1.SetPlc(5004, PLCData1.DiffSpeed);

        PLCData1.SetPlc(6000, PLCData1.Servo1Pos1);
        PLCData1.SetPlc(6004, PLCData1.Servo1Pos2);
        PLCData1.SetPlc(6008, PLCData1.Servo1Pos3);
        PLCData1.SetPlc(6012, PLCData1.Servo1Pos4);
        PLCData1.SetPlc(6016, PLCData1.Servo1Pos5);
        PLCData1.SetPlc(6020, PLCData1.Servo1Pos6);

        PLCData1.SetPlc(6002, PLCData1.Servo1Pos1Spd);
        PLCData1.SetPlc(6006, PLCData1.Servo1Pos2Spd);
        PLCData1.SetPlc(6010, PLCData1.Servo1Pos3Spd);
        PLCData1.SetPlc(6014, PLCData1.Servo1Pos4Spd);
        PLCData1.SetPlc(6018, PLCData1.Servo1Pos5Spd);
        PLCData1.SetPlc(6022, PLCData1.Servo1Pos6Spd);
    }
}

public class GlobalValues
{
    public static string gConString_Part =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"\DB\DataBase_Part.accdb";

    public static string gConString_Record =
        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"\DB\DataBase_Record.accdb";

    // SQL Server 설정
    public static bool   SqlServerEnabled  = false;
    public static string SqlServerIp       = "192.168.0.222";
    public static string SqlServerInstance = "Ftech_Svr";
    public static string SqlServerCatalog  = "FTECH_SVR";
    public static string SqlServerUserId   = "sa";
    public static string SqlServerPassword = "";

    public static string gConString_Sql =>
        $"Provider=SQLOLEDB;" +
        $"Data Source={SqlServerIp}{(string.IsNullOrWhiteSpace(SqlServerInstance) ? "" : "\\" + SqlServerInstance)};" +
        $"Initial Catalog={SqlServerCatalog};" +
        $"User ID={SqlServerUserId};Password={SqlServerPassword};";

    public static Form openForm;
    public static System.Action ZeroSensorsAction; // 전체 영점 (_FrmMain에서 등록)
    public static System.Action ZeroLvdtAction;    // LVDT 단독 영점
    public static System.Action ZeroLc1Action;     // 로드셀1 단독 영점
    public static System.Action ZeroLc2Action;     // 로드셀2 단독 영점
    public static string strPassWord;

    public static string PlcIpAddress = "192.168.0.1";
    public static int PlcIpPort = 5001;

    public static string Rs485Port;          // RS-485 공용 포트 (LVDT + 로드셀 1,2)
    public static string ScannerPort;
    public static string PrinterPort;

    public static int Rs485Baud    = 9600;   // RS-485 공용 통신속도
    public static int LvdtId       = 1;      // DI-20W Command mode ID (F-40)
    public static int LoadCell1Id  = 1;      // BS-205 1번 로드셀 ID
    public static int LoadCell2Id  = 2;      // BS-205 2번 로드셀 ID

    // 리셋 입력 주소 (D4000.1 기본)
    public static int ResetInputDWord  = 0;
    public static int ResetInputBit    = 1;

    // 에러 리셋 출력 주소 (D4009.3 기본)
    public static int ErrorResetOutDWord = 9;
    public static int ErrorResetOutBit   = 3;

    public static int OkCount = 0;
    public static int TotalCount = 0;

    public static void SaveCounts()
    {
        IniFile ini = new IniFile("config.ini");
        ini.WriteValue("Counter", "OkCount", OkCount.ToString());
        ini.WriteValue("Counter", "TotalCount", TotalCount.ToString());
    }

    public static void LoadCounts()
    {
        IniFile ini = new IniFile("config.ini");
        OkCount = int.TryParse(ini.ReadValue("Counter", "OkCount"), out var ok) ? ok : 0;
        TotalCount = int.TryParse(ini.ReadValue("Counter", "TotalCount"), out var total) ? total : 0;
    }

    public static void LoadSettingsFromIni()
    {
        IniFile ini = new IniFile("config.ini");

        string ReadStr(string section, string key, string def)
        {
            string val = ini.ReadValue(section, key)?.Trim();
            return string.IsNullOrWhiteSpace(val) ? def : val;
        }
        int ReadInt(string section, string key, int def = 0)
        {
            string val = ini.ReadValue(section, key);
            return int.TryParse(val, out int r) ? r : def;
        }
        double ReadDouble(string section, string key, double def = 0)
        {
            string val = ini.ReadValue(section, key);
            return double.TryParse(val, out double r) ? r : def;
        }

        // SQL Server 설정
        SqlServerEnabled  = ReadStr("SqlServer", "Enabled",  "false").ToLower() == "true";
        SqlServerIp       = ReadStr("SqlServer", "Ip",       "192.168.0.222");
        SqlServerInstance = ReadStr("SqlServer", "Instance", "Ftech_Svr");
        SqlServerCatalog  = ReadStr("SqlServer", "Catalog",  "FTECH_SVR");
        SqlServerUserId   = ReadStr("SqlServer", "UserId",   "sa");
        SqlServerPassword = ReadStr("SqlServer", "Password", "");

        // 시스템 설정
        strPassWord = ReadStr("System", "PassWord", "0");
        PlcIpAddress = ReadStr("System", "PlcIpAddress", "192.168.0.1");
        PlcIpPort = ReadInt("System", "PlcIpPort", 5001);
        Rs485Port    = ReadStr("System", "Rs485Port",    "COM3");
        ScannerPort  = ReadStr("System", "ScannerPort",  "COM5");
        PrinterPort  = ReadStr("System", "PrinterPort",  "COM6");
        Rs485Baud    = ReadInt("System", "Rs485Baud",    9600);
        LvdtId       = ReadInt("System", "LvdtId",       1);
        LoadCell1Id  = ReadInt("System", "LoadCell1Id",  1);
        LoadCell2Id  = ReadInt("System", "LoadCell2Id",  2);

        // 리셋 설정
        ResetInputDWord    = ReadInt("Reset", "InputDWord",         0);
        ResetInputBit      = ReadInt("Reset", "InputBit",           1);
        ErrorResetOutDWord = ReadInt("Reset", "ErrorResetOutDWord", 9);
        ErrorResetOutBit   = ReadInt("Reset", "ErrorResetOutBit",   3);

        // 서보 설정
        PLCData1.Servo1JogSpd = ReadInt("Plc1", "Servo1JogSpd");
        PLCData1.DiffSpeed = ReadInt("Plc1", "DiffSpeed");
        for (int i = 1; i <= 6; i++)
        {
            typeof(PLCData1).GetField($"Servo1Pos{i}").SetValue(null, ReadInt("Plc1", $"Servo1Pos{i}"));
            typeof(PLCData1).GetField($"Servo1Pos{i}Spd").SetValue(null, ReadInt("Plc1", $"Servo1Pos{i}Spd"));
            PLCData1.Servo1PosComments[i - 1] = ReadStr("Plc1", $"Servo1Pos{i}Comment", $"포지션{i}");
        }

        // 측정 설정
        MeasureData1.L_mm = ReadDouble("Measure", "L_mm", 300.0);
        MeasureData1.GapSpec    = ReadDouble("Measure", "GapSpec", 0.5);
        MeasureData1.Unit       = ReadStr("Measure", "Unit", "°");
        MeasureData1.LoadUnit   = ReadStr("Measure", "LoadUnit", "kgf");
        MeasureData1.AssyParNo = ReadStr("Measure", "AssyPartNo", "");
        MeasureData1.TargetScan = ReadStr("Measure", "TargetScan", "");
    }

    // config.ini [PartList] 섹션에서 바코드→품명 조회
    public static string LookupPartName(string barcode)
    {
        if (string.IsNullOrWhiteSpace(barcode)) return "---";
        IniFile ini = new IniFile("config.ini");
        string name = ini.ReadValue("PartList", barcode);
        return string.IsNullOrEmpty(name) ? "---" : name;
    }

    public static void SaveChannelSettingsToIni()
    {
        IniFile ini = new IniFile("config.ini");

        ini.WriteValue("SqlServer", "Enabled",  SqlServerEnabled.ToString());
        ini.WriteValue("SqlServer", "Ip",       SqlServerIp       ?? "192.168.0.222");
        ini.WriteValue("SqlServer", "Instance", SqlServerInstance ?? "Ftech_Svr");
        ini.WriteValue("SqlServer", "Catalog",  SqlServerCatalog  ?? "FTECH_SVR");
        ini.WriteValue("SqlServer", "UserId",   SqlServerUserId   ?? "sa");
        ini.WriteValue("SqlServer", "Password", SqlServerPassword ?? "");

        ini.WriteValue("System", "PassWord", strPassWord ?? "0");
        ini.WriteValue("System", "PlcIpAddress", PlcIpAddress ?? "192.168.0.1");
        ini.WriteValue("System", "PlcIpPort", PlcIpPort.ToString());
        ini.WriteValue("System", "Rs485Port",   Rs485Port   ?? "COM3");
        ini.WriteValue("System", "ScannerPort", ScannerPort ?? "COM5");
        ini.WriteValue("System", "PrinterPort", PrinterPort ?? "COM6");
        ini.WriteValue("System", "Rs485Baud",   Rs485Baud.ToString());
        ini.WriteValue("System", "LvdtId",      LvdtId.ToString());
        ini.WriteValue("System", "LoadCell1Id", LoadCell1Id.ToString());
        ini.WriteValue("System", "LoadCell2Id", LoadCell2Id.ToString());

        ini.WriteValue("Reset", "InputDWord",         ResetInputDWord.ToString());
        ini.WriteValue("Reset", "InputBit",           ResetInputBit.ToString());
        ini.WriteValue("Reset", "ErrorResetOutDWord", ErrorResetOutDWord.ToString());
        ini.WriteValue("Reset", "ErrorResetOutBit",   ErrorResetOutBit.ToString());

        ini.WriteValue("Plc1", "Servo1JogSpd", PLCData1.Servo1JogSpd.ToString());
        ini.WriteValue("Plc1", "DiffSpeed", PLCData1.DiffSpeed.ToString());
        for (int i = 1; i <= 6; i++)
        {
            ini.WriteValue("Plc1", $"Servo1Pos{i}", ((int)typeof(PLCData1).GetField($"Servo1Pos{i}").GetValue(null)).ToString());
            ini.WriteValue("Plc1", $"Servo1Pos{i}Spd", ((int)typeof(PLCData1).GetField($"Servo1Pos{i}Spd").GetValue(null)).ToString());
            ini.WriteValue("Plc1", $"Servo1Pos{i}Comment", PLCData1.Servo1PosComments[i - 1] ?? "");
        }

        ini.WriteValue("Measure", "L_mm", MeasureData1.L_mm.ToString());
        ini.WriteValue("Measure", "GapSpec", MeasureData1.GapSpec.ToString());
        ini.WriteValue("Measure", "Unit",     MeasureData1.Unit     ?? "°");
        ini.WriteValue("Measure", "LoadUnit", MeasureData1.LoadUnit ?? "kgf");
        ini.WriteValue("Measure", "AssyPartNo", MeasureData1.AssyParNo);
        ini.WriteValue("Measure", "TargetScan", MeasureData1.TargetScan);
    }
}
