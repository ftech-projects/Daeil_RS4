using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

// 통신 포트 설정
public class Configuration
{
    [Category("PLC 통신")]
    [DisplayName("PLC IP 주소")]
    [Description("미쓰비시 PLC Ethernet IP 주소 (예: 192.168.0.10)")]
    public string PlcIpAddress { get; set; }

    [Category("PLC 통신")]
    [DisplayName("PLC 포트")]
    [Description("미쓰비시 PLC Ethernet 포트 (기본 5001)")]
    public int PlcIpPort { get; set; }

    [Category("센서 통신 (LVDT RS-232)")]
    [DisplayName("LVDT 포트")]
    [Description("DI-20W 전용 RS-232 COM 포트")]
    [TypeConverter(typeof(ComPortConverter))]
    public string LvdtPort { get; set; }

    [Category("센서 통신 (LVDT RS-232)")]
    [DisplayName("LVDT 통신속도 (bps)")]
    [Description("DI-20W 통신속도 (기본 38400)")]
    public int LvdtBaud { get; set; }

    [Category("센서 통신 (LVDT RS-232)")]
    [DisplayName("LVDT ID")]
    [Description("DI-20W F-40 설정값과 일치 (기본 1)")]
    public int LvdtId { get; set; }

    [Category("센서 통신 (로드셀 RS-485)")]
    [DisplayName("RS-485 포트")]
    [Description("로드셀 1,2가 공유하는 RS-485 COM 포트")]
    [TypeConverter(typeof(ComPortConverter))]
    public string Rs485Port { get; set; }

    [Category("센서 통신 (로드셀 RS-485)")]
    [DisplayName("RS-485 통신속도 (bps)")]
    [Description("RS-485 공용 통신속도. BS-205 2대 동일하게 설정 (기본 9600)")]
    public int Rs485Baud { get; set; }

    [Category("센서 통신 (로드셀 RS-485)")]
    [DisplayName("로드셀1 ID (전진)")]
    [Description("BS-205 1번 기기 Id 설정값과 일치 (기본 1)")]
    public int LoadCell1Id { get; set; }

    [Category("센서 통신 (로드셀 RS-485)")]
    [DisplayName("로드셀2 ID (후진)")]
    [Description("BS-205 2번 기기 Id 설정값과 일치 (기본 2)")]
    public int LoadCell2Id { get; set; }

    // 리셋 입력 주소
    [Category("리셋 설정")]
    [DisplayName("입력 dWord (D4000=0)")]
    [Description("리셋 입력 비트의 D 주소 오프셋 (D4000→0, D4001→1 ...)")]
    public int ResetInputDWord { get; set; }

    [Category("리셋 설정")]
    [DisplayName("입력 bit")]
    [Description("리셋 입력 비트 번호 (0~15)")]
    public int ResetInputBit { get; set; }

    // 에러 리셋 출력
    [Category("리셋 설정")]
    [DisplayName("에러리셋 출력 dWord (D4009=9)")]
    [Description("에러 리셋 펄스 출력 D 주소 오프셋")]
    public int ErrorResetOutDWord { get; set; }

    [Category("리셋 설정")]
    [DisplayName("에러리셋 출력 bit")]
    [Description("에러 리셋 펄스 출력 비트 번호 (0~15)")]
    public int ErrorResetOutBit { get; set; }

    [Category("기타")]
    [DisplayName("설비 타이틀")]
    [Description("메인 화면 상단에 표시되는 설비 이름")]
    public string EquipTitle { get; set; }

    [Category("기타")]
    [DisplayName("비밀번호")]
    [Description("관리자 비밀번호 (0이면 비밀번호 없음)")]
    public string strPassWord { get; set; }

    public Configuration()
    {
        PlcIpAddress   = GlobalValues.PlcIpAddress;
        PlcIpPort      = GlobalValues.PlcIpPort;
        LvdtPort       = GlobalValues.LvdtPort;
        LvdtBaud       = GlobalValues.LvdtBaud;
        LvdtId         = GlobalValues.LvdtId;
        Rs485Port      = GlobalValues.Rs485Port;
        Rs485Baud      = GlobalValues.Rs485Baud;
        LoadCell1Id    = GlobalValues.LoadCell1Id;
        LoadCell2Id    = GlobalValues.LoadCell2Id;
        ResetInputDWord    = GlobalValues.ResetInputDWord;
        ResetInputBit      = GlobalValues.ResetInputBit;
        ErrorResetOutDWord = GlobalValues.ErrorResetOutDWord;
        ErrorResetOutBit   = GlobalValues.ErrorResetOutBit;
        EquipTitle     = GlobalValues.EquipTitle;
        strPassWord    = GlobalValues.strPassWord;
    }

    public void Apply()
    {
        GlobalValues.PlcIpAddress   = PlcIpAddress;
        GlobalValues.PlcIpPort      = PlcIpPort;
        GlobalValues.LvdtPort       = LvdtPort;
        GlobalValues.LvdtBaud       = LvdtBaud;
        GlobalValues.LvdtId         = LvdtId;
        GlobalValues.Rs485Port      = Rs485Port;
        GlobalValues.Rs485Baud      = Rs485Baud;
        GlobalValues.LoadCell1Id    = LoadCell1Id;
        GlobalValues.LoadCell2Id    = LoadCell2Id;
        GlobalValues.ResetInputDWord    = ResetInputDWord;
        GlobalValues.ResetInputBit      = ResetInputBit;
        GlobalValues.ErrorResetOutDWord = ErrorResetOutDWord;
        GlobalValues.ErrorResetOutBit   = ErrorResetOutBit;
        GlobalValues.EquipTitle         = EquipTitle;
        GlobalValues.strPassWord        = strPassWord;
    }

    private class ComPortConverter : System.ComponentModel.StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => true;
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) => true;
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var ports = Enumerable.Range(1, 10).Select(i => $"COM{i}").ToArray();
            return new StandardValuesCollection(ports);
        }
    }
}


// 유격 측정 설정
public class ConfigurationMeasure
{
    [Category("로드셀 기준값")]
    [DisplayName("부하 하중 P (kgf) — 자동계산")]
    [Description("P = 4.6(kgf·m) / L(m)  —  L 변경 시 자동 산출됩니다.")]
    [System.ComponentModel.ReadOnly(true)]
    public double LoadP => MeasureData1.CalcThreshold();

    [Category("유격 공식")]
    [DisplayName("L 거리 (mm)")]
    [Description("Seat Back Line 길이 L — 유격(도) = (전진변위+후진변위)/L × (180/파이)")]
    public double L_mm { get; set; }

    [Category("스펙")]
    [DisplayName("유격 스펙")]
    [Description("합격 기준 유격값")]
    public double GapSpec { get; set; }

    [Category("스펙")]
    [DisplayName("단위")]
    [Description("유격 단위 (예: °, deg, mm)")]
    public string Unit { get; set; }

    [Category("하중")]
    [DisplayName("하중 단위")]
    [Description("그래프 Y축 하중 단위 (예: kgf, N, kg)")]
    public string LoadUnit { get; set; }

    public ConfigurationMeasure()
    {
        L_mm       = MeasureData1.L_mm;
        GapSpec    = MeasureData1.GapSpec;
        Unit       = MeasureData1.Unit;
        LoadUnit   = MeasureData1.LoadUnit;
    }

    public void Apply()
    {
        MeasureData1.L_mm      = L_mm;
        MeasureData1.GapSpec   = GapSpec;
        MeasureData1.Unit      = Unit;
        MeasureData1.LoadUnit  = LoadUnit;
    }
}
