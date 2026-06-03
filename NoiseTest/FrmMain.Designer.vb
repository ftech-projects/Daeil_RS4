<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TmrWork = New System.Windows.Forms.Timer(Me.components)
        Me.SerialScanner = New System.IO.Ports.SerialPort(Me.components)
        Me.InstantDoCtrl1 = New Automation.BDaq.InstantDoCtrl(Me.components)
        Me.InstantDiCtrl1 = New Automation.BDaq.InstantDiCtrl(Me.components)
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label134 = New System.Windows.Forms.Label()
        Me.srcLaser2Angle = New System.Windows.Forms.Label()
        Me.srcLaser1Angle = New System.Windows.Forms.Label()
        Me.lbD4050 = New System.Windows.Forms.Label()
        Me.lbD4001 = New System.Windows.Forms.Label()
        Me.lbD4000 = New System.Windows.Forms.Label()
        Me.srcLbPlcConnectionState = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.srcLaser2 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.srcStep1 = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.srcScannerInput = New System.Windows.Forms.Label()
        Me.lbRequestCount2 = New System.Windows.Forms.Label()
        Me.lbRequestCount1 = New System.Windows.Forms.Label()
        Me.lbRequestStep2 = New System.Windows.Forms.Label()
        Me.lbRequestStep1 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.LbSupply4Volt = New System.Windows.Forms.Label()
        Me.LbSupply3Volt = New System.Windows.Forms.Label()
        Me.LbSupply2Volt = New System.Windows.Forms.Label()
        Me.LbSupply1Volt = New System.Windows.Forms.Label()
        Me.LbSupply4Amp = New System.Windows.Forms.Label()
        Me.LbSupply3Amp = New System.Windows.Forms.Label()
        Me.LbSupply2Amp = New System.Windows.Forms.Label()
        Me.LbSupply1Amp = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.srcLaser1 = New System.Windows.Forms.Label()
        Me.srcNoise = New System.Windows.Forms.Label()
        Me.P_OUT_15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.P_OUT_14 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.P_OUT_13 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.P_OUT_12 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.P_OUT_11 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.P_OUT_10 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.P_OUT_09 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.P_OUT_08 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.P_OUT_07 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.P_OUT_06 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.P_OUT_05 = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.P_OUT_04 = New System.Windows.Forms.Label()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.P_OUT_03 = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.P_OUT_02 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.P_OUT_01 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.P_OUT_00 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.P_IN_15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.P_IN_14 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.P_IN_13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.P_IN_12 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.P_IN_11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.P_IN_10 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.P_IN_09 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.P_IN_08 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.P_IN_07 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.P_IN_06 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.P_IN_05 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.P_IN_04 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.P_IN_03 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.P_IN_02 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.P_IN_01 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.P_IN_00 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TmrIO = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_FWD_AMP_SPEC = New System.Windows.Forms.Label()
        Me.Panel_LSUPT_FWD_AMP = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BasicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VitualKeyboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.srcLbSerial = New System.Windows.Forms.Label()
        Me.srcLbPartName = New System.Windows.Forms.Label()
        Me.srcLbPartNo = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lbCanStep = New System.Windows.Forms.Label()
        Me.lbCanConnection = New System.Windows.Forms.Label()
        Me.LbCan = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SerialPrinter = New System.IO.Ports.SerialPort(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.Label149 = New System.Windows.Forms.Label()
        Me.Label150 = New System.Windows.Forms.Label()
        Me.srclbValReclBwdTicTime = New System.Windows.Forms.Label()
        Me.srclbValReclBwdEndAngle = New System.Windows.Forms.Label()
        Me.srclbValReclBwdStartAngle = New System.Windows.Forms.Label()
        Me.Label144 = New System.Windows.Forms.Label()
        Me.Label140 = New System.Windows.Forms.Label()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.srclbValReclFwdTicTime = New System.Windows.Forms.Label()
        Me.srclbValReclFwdEndAngle = New System.Windows.Forms.Label()
        Me.srclbValReclFwdStartAngle = New System.Windows.Forms.Label()
        Me.Label132 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.srclbValReclBwdSpeed = New System.Windows.Forms.Label()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.srclbDecReclBwdSpeed = New System.Windows.Forms.Label()
        Me.srclbSpecReclBwdSpeed = New System.Windows.Forms.Label()
        Me.srclbValReclFwdSpeed = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.srclbDecReclFwdSpeed = New System.Windows.Forms.Label()
        Me.srclbSpecReclFwdSpeed = New System.Windows.Forms.Label()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.srcGraphReclBAmp = New ZedGraph.ZedGraphControl()
        Me.srcGraphReclBNoise = New ZedGraph.ZedGraphControl()
        Me.srcGraphReclFAmp = New ZedGraph.ZedGraphControl()
        Me.srcGraphReclFNoise = New ZedGraph.ZedGraphControl()
        Me.srclbValReclEndAngle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.srclbValReclBwdAngle = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.srclbDecReclBwdAngle = New System.Windows.Forms.Label()
        Me.srclbSpecReclBwdAngle = New System.Windows.Forms.Label()
        Me.srclbDecReclEndAngle = New System.Windows.Forms.Label()
        Me.srclbValReclBwdAmp = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.srclbDecReclBwdAmp = New System.Windows.Forms.Label()
        Me.srclbSpecReclBwdAmp = New System.Windows.Forms.Label()
        Me.srclbValReclBwdNoise = New System.Windows.Forms.Label()
        Me.srclbSpecReclEndAngle = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.srclbDecReclBwdNoise = New System.Windows.Forms.Label()
        Me.srclbSpecReclBwdNoise = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.srclbValReclFwdAngle = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.srclbDecReclFwdAngle = New System.Windows.Forms.Label()
        Me.srclbSpecReclFwdAngle = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.srclbValReclFwdAmp = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.srclbDecReclFwdAmp = New System.Windows.Forms.Label()
        Me.srclbSpecReclFwdAmp = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.srclbValReclFwdNoise = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.srclbDecReclFwdNoise = New System.Windows.Forms.Label()
        Me.srclbSpecReclFwdNoise = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.Label165 = New System.Windows.Forms.Label()
        Me.Label167 = New System.Windows.Forms.Label()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.srclbValFrestBwdTicTime = New System.Windows.Forms.Label()
        Me.srclbValFrestBwdEndAngle = New System.Windows.Forms.Label()
        Me.srclbValFrestBwdStartAngle = New System.Windows.Forms.Label()
        Me.Label157 = New System.Windows.Forms.Label()
        Me.Label158 = New System.Windows.Forms.Label()
        Me.Label159 = New System.Windows.Forms.Label()
        Me.srclbValFrestFwdTicTime = New System.Windows.Forms.Label()
        Me.srclbValFrestFwdEndAngle = New System.Windows.Forms.Label()
        Me.srclbValFrestFwdStartAngle = New System.Windows.Forms.Label()
        Me.Label163 = New System.Windows.Forms.Label()
        Me.Label164 = New System.Windows.Forms.Label()
        Me.srclbValFrestBwdSpeed = New System.Windows.Forms.Label()
        Me.Label148 = New System.Windows.Forms.Label()
        Me.srclbDecFrestBwdSpeed = New System.Windows.Forms.Label()
        Me.srclbSpecFrestBwdSpeed = New System.Windows.Forms.Label()
        Me.srclbValFrestFwdSpeed = New System.Windows.Forms.Label()
        Me.Label143 = New System.Windows.Forms.Label()
        Me.srclbDecFrestFwdSpeed = New System.Windows.Forms.Label()
        Me.srclbSpecFrestFwdSpeed = New System.Windows.Forms.Label()
        Me.Label146 = New System.Windows.Forms.Label()
        Me.srcGraphFrestBAmp = New ZedGraph.ZedGraphControl()
        Me.srcGraphFrestBNoise = New ZedGraph.ZedGraphControl()
        Me.srcGraphFrestFAmp = New ZedGraph.ZedGraphControl()
        Me.srcGraphFrestFNoise = New ZedGraph.ZedGraphControl()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.srclbValFrestBwdAmp = New System.Windows.Forms.Label()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.srclbDecFrestBwdAmp = New System.Windows.Forms.Label()
        Me.srclbSpecFrestBwdAmp = New System.Windows.Forms.Label()
        Me.srclbValFrestBwdNoise = New System.Windows.Forms.Label()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.srclbDecFrestBwdNoise = New System.Windows.Forms.Label()
        Me.srclbSpecFrestBwdNoise = New System.Windows.Forms.Label()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.srclbValFrestFwdAmp = New System.Windows.Forms.Label()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.srclbDecFrestFwdAmp = New System.Windows.Forms.Label()
        Me.srclbSpecFrestFwdAmp = New System.Windows.Forms.Label()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.srclbValFrestFwdNoise = New System.Windows.Forms.Label()
        Me.Label133 = New System.Windows.Forms.Label()
        Me.srclbDecFrestFwdNoise = New System.Windows.Forms.Label()
        Me.srclbSpecFrestFwdNoise = New System.Windows.Forms.Label()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.Label138 = New System.Windows.Forms.Label()
        Me.Serial_Supply1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Serial_Supply2 = New System.IO.Ports.SerialPort(Me.components)
        Me.srclbTotalDecision = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.Label129 = New System.Windows.Forms.Label()
        Me.Label131 = New System.Windows.Forms.Label()
        Me.srcGraphBolsterAmp = New ZedGraph.ZedGraphControl()
        Me.srcGraphBolsterNoise = New ZedGraph.ZedGraphControl()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Label166 = New System.Windows.Forms.Label()
        Me.srclbDataBolsterDefAmp = New System.Windows.Forms.Label()
        Me.Label168 = New System.Windows.Forms.Label()
        Me.srclbDecBolsterDefAmp = New System.Windows.Forms.Label()
        Me.srclbSpecBolsterDefAmp = New System.Windows.Forms.Label()
        Me.Label177 = New System.Windows.Forms.Label()
        Me.srclbDataBolsterInfAmp = New System.Windows.Forms.Label()
        Me.Label179 = New System.Windows.Forms.Label()
        Me.srclbDecBolsterInfAmp = New System.Windows.Forms.Label()
        Me.srclbSpecBolsterInfAmp = New System.Windows.Forms.Label()
        Me.srclbDataBolsterInfNoise = New System.Windows.Forms.Label()
        Me.Label184 = New System.Windows.Forms.Label()
        Me.srclbDecBolsterInfNoise = New System.Windows.Forms.Label()
        Me.srclbSpecBolsterInfNoise = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.srclbDataLsuptDefAmp = New System.Windows.Forms.Label()
        Me.Label142 = New System.Windows.Forms.Label()
        Me.srclbDecLsuptDefAmp = New System.Windows.Forms.Label()
        Me.srclbSpecLsuptDefAmp = New System.Windows.Forms.Label()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.srcGraphLsuptAmp = New ZedGraph.ZedGraphControl()
        Me.srcGraphLsuptNoise = New ZedGraph.ZedGraphControl()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.srclbDataLsuptMidAmp = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.srclbDecLsuptMidAmp = New System.Windows.Forms.Label()
        Me.srclbSpecLsuptMidAmp = New System.Windows.Forms.Label()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.srclbDataLsuptMidNoise = New System.Windows.Forms.Label()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.srclbDecLsuptMidNoise = New System.Windows.Forms.Label()
        Me.srclbSpecLsuptMidNoise = New System.Windows.Forms.Label()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.Label125 = New System.Windows.Forms.Label()
        Me.Label141 = New System.Windows.Forms.Label()
        Me.Tmr_Connect = New System.Windows.Forms.Timer(Me.components)
        Me.srclbType = New System.Windows.Forms.Label()
        Me.SerialCan = New System.IO.Ports.SerialPort(Me.components)
        Me.Tmr_Can = New System.Windows.Forms.Timer(Me.components)
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel8.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(3, 1058)
        Me.Panel3.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1920, 3)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1917, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(3, 1055)
        Me.Panel2.TabIndex = 10
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 1058)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1917, 3)
        Me.Panel4.TabIndex = 9
        '
        'TmrWork
        '
        '
        'SerialScanner
        '
        '
        'InstantDoCtrl1
        '
        Me.InstantDoCtrl1._StateStream = CType(resources.GetObject("InstantDoCtrl1._StateStream"), Automation.BDaq.DeviceStateStreamer)
        '
        'InstantDiCtrl1
        '
        Me.InstantDiCtrl1._StateStream = CType(resources.GetObject("InstantDiCtrl1._StateStream"), Automation.BDaq.DeviceStateStreamer)
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.Button6)
        Me.Panel8.Controls.Add(Me.Button5)
        Me.Panel8.Controls.Add(Me.Label134)
        Me.Panel8.Controls.Add(Me.srcLaser2Angle)
        Me.Panel8.Controls.Add(Me.srcLaser1Angle)
        Me.Panel8.Controls.Add(Me.lbD4050)
        Me.Panel8.Controls.Add(Me.lbD4001)
        Me.Panel8.Controls.Add(Me.lbD4000)
        Me.Panel8.Controls.Add(Me.srcLbPlcConnectionState)
        Me.Panel8.Controls.Add(Me.Label45)
        Me.Panel8.Controls.Add(Me.srcLaser2)
        Me.Panel8.Controls.Add(Me.Label58)
        Me.Panel8.Controls.Add(Me.Label108)
        Me.Panel8.Controls.Add(Me.srcStep1)
        Me.Panel8.Controls.Add(Me.Label93)
        Me.Panel8.Controls.Add(Me.Label95)
        Me.Panel8.Controls.Add(Me.Label97)
        Me.Panel8.Controls.Add(Me.Label101)
        Me.Panel8.Controls.Add(Me.Label102)
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Controls.Add(Me.Label105)
        Me.Panel8.Controls.Add(Me.Label24)
        Me.Panel8.Controls.Add(Me.Label107)
        Me.Panel8.Controls.Add(Me.Label78)
        Me.Panel8.Controls.Add(Me.Label80)
        Me.Panel8.Controls.Add(Me.Label81)
        Me.Panel8.Controls.Add(Me.Label85)
        Me.Panel8.Controls.Add(Me.Label87)
        Me.Panel8.Controls.Add(Me.Label89)
        Me.Panel8.Controls.Add(Me.Label91)
        Me.Panel8.Controls.Add(Me.Label64)
        Me.Panel8.Controls.Add(Me.Label65)
        Me.Panel8.Controls.Add(Me.Label66)
        Me.Panel8.Controls.Add(Me.Label72)
        Me.Panel8.Controls.Add(Me.Label73)
        Me.Panel8.Controls.Add(Me.Label74)
        Me.Panel8.Controls.Add(Me.Label77)
        Me.Panel8.Controls.Add(Me.Label63)
        Me.Panel8.Controls.Add(Me.Label60)
        Me.Panel8.Controls.Add(Me.Label59)
        Me.Panel8.Controls.Add(Me.Label57)
        Me.Panel8.Controls.Add(Me.Label56)
        Me.Panel8.Controls.Add(Me.Label53)
        Me.Panel8.Controls.Add(Me.Label52)
        Me.Panel8.Controls.Add(Me.Label48)
        Me.Panel8.Controls.Add(Me.Label42)
        Me.Panel8.Controls.Add(Me.Label41)
        Me.Panel8.Controls.Add(Me.Label27)
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Controls.Add(Me.srcScannerInput)
        Me.Panel8.Controls.Add(Me.lbRequestCount2)
        Me.Panel8.Controls.Add(Me.lbRequestCount1)
        Me.Panel8.Controls.Add(Me.lbRequestStep2)
        Me.Panel8.Controls.Add(Me.lbRequestStep1)
        Me.Panel8.Controls.Add(Me.Label67)
        Me.Panel8.Controls.Add(Me.Label68)
        Me.Panel8.Controls.Add(Me.Label37)
        Me.Panel8.Controls.Add(Me.Label70)
        Me.Panel8.Controls.Add(Me.LbSupply4Volt)
        Me.Panel8.Controls.Add(Me.LbSupply3Volt)
        Me.Panel8.Controls.Add(Me.LbSupply2Volt)
        Me.Panel8.Controls.Add(Me.LbSupply1Volt)
        Me.Panel8.Controls.Add(Me.LbSupply4Amp)
        Me.Panel8.Controls.Add(Me.LbSupply3Amp)
        Me.Panel8.Controls.Add(Me.LbSupply2Amp)
        Me.Panel8.Controls.Add(Me.LbSupply1Amp)
        Me.Panel8.Controls.Add(Me.Label32)
        Me.Panel8.Controls.Add(Me.Label31)
        Me.Panel8.Controls.Add(Me.srcLaser1)
        Me.Panel8.Controls.Add(Me.srcNoise)
        Me.Panel8.Controls.Add(Me.P_OUT_15)
        Me.Panel8.Controls.Add(Me.Label16)
        Me.Panel8.Controls.Add(Me.P_OUT_14)
        Me.Panel8.Controls.Add(Me.Label18)
        Me.Panel8.Controls.Add(Me.P_OUT_13)
        Me.Panel8.Controls.Add(Me.Label20)
        Me.Panel8.Controls.Add(Me.P_OUT_12)
        Me.Panel8.Controls.Add(Me.Label26)
        Me.Panel8.Controls.Add(Me.P_OUT_11)
        Me.Panel8.Controls.Add(Me.Label30)
        Me.Panel8.Controls.Add(Me.P_OUT_10)
        Me.Panel8.Controls.Add(Me.Label34)
        Me.Panel8.Controls.Add(Me.P_OUT_09)
        Me.Panel8.Controls.Add(Me.Label40)
        Me.Panel8.Controls.Add(Me.P_OUT_08)
        Me.Panel8.Controls.Add(Me.Label46)
        Me.Panel8.Controls.Add(Me.P_OUT_07)
        Me.Panel8.Controls.Add(Me.Label94)
        Me.Panel8.Controls.Add(Me.P_OUT_06)
        Me.Panel8.Controls.Add(Me.Label96)
        Me.Panel8.Controls.Add(Me.P_OUT_05)
        Me.Panel8.Controls.Add(Me.Label98)
        Me.Panel8.Controls.Add(Me.P_OUT_04)
        Me.Panel8.Controls.Add(Me.Label100)
        Me.Panel8.Controls.Add(Me.P_OUT_03)
        Me.Panel8.Controls.Add(Me.Label92)
        Me.Panel8.Controls.Add(Me.P_OUT_02)
        Me.Panel8.Controls.Add(Me.Label90)
        Me.Panel8.Controls.Add(Me.P_OUT_01)
        Me.Panel8.Controls.Add(Me.Label88)
        Me.Panel8.Controls.Add(Me.P_OUT_00)
        Me.Panel8.Controls.Add(Me.Label86)
        Me.Panel8.Controls.Add(Me.P_IN_15)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.P_IN_14)
        Me.Panel8.Controls.Add(Me.Label39)
        Me.Panel8.Controls.Add(Me.P_IN_13)
        Me.Panel8.Controls.Add(Me.Label8)
        Me.Panel8.Controls.Add(Me.P_IN_12)
        Me.Panel8.Controls.Add(Me.Label43)
        Me.Panel8.Controls.Add(Me.P_IN_11)
        Me.Panel8.Controls.Add(Me.Label9)
        Me.Panel8.Controls.Add(Me.P_IN_10)
        Me.Panel8.Controls.Add(Me.Label47)
        Me.Panel8.Controls.Add(Me.P_IN_09)
        Me.Panel8.Controls.Add(Me.Label49)
        Me.Panel8.Controls.Add(Me.P_IN_08)
        Me.Panel8.Controls.Add(Me.Label51)
        Me.Panel8.Controls.Add(Me.P_IN_07)
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Controls.Add(Me.P_IN_06)
        Me.Panel8.Controls.Add(Me.Label11)
        Me.Panel8.Controls.Add(Me.P_IN_05)
        Me.Panel8.Controls.Add(Me.Label12)
        Me.Panel8.Controls.Add(Me.P_IN_04)
        Me.Panel8.Controls.Add(Me.Label13)
        Me.Panel8.Controls.Add(Me.P_IN_03)
        Me.Panel8.Controls.Add(Me.Label25)
        Me.Panel8.Controls.Add(Me.P_IN_02)
        Me.Panel8.Controls.Add(Me.Label14)
        Me.Panel8.Controls.Add(Me.P_IN_01)
        Me.Panel8.Controls.Add(Me.Label15)
        Me.Panel8.Controls.Add(Me.P_IN_00)
        Me.Panel8.Controls.Add(Me.Label21)
        Me.Panel8.Location = New System.Drawing.Point(4, 968)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1912, 113)
        Me.Panel8.TabIndex = 96
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1818, 5)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(89, 31)
        Me.Button5.TabIndex = 244
        Me.Button5.Text = "Cush 배기 LH"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label134
        '
        Me.Label134.BackColor = System.Drawing.Color.Black
        Me.Label134.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label134.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label134.ForeColor = System.Drawing.Color.White
        Me.Label134.Location = New System.Drawing.Point(1219, 86)
        Me.Label134.Name = "Label134"
        Me.Label134.Size = New System.Drawing.Size(120, 20)
        Me.Label134.TabIndex = 243
        Me.Label134.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLaser2Angle
        '
        Me.srcLaser2Angle.BackColor = System.Drawing.Color.Black
        Me.srcLaser2Angle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLaser2Angle.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.srcLaser2Angle.ForeColor = System.Drawing.Color.White
        Me.srcLaser2Angle.Location = New System.Drawing.Point(1580, 46)
        Me.srcLaser2Angle.Name = "srcLaser2Angle"
        Me.srcLaser2Angle.Size = New System.Drawing.Size(114, 20)
        Me.srcLaser2Angle.TabIndex = 242
        Me.srcLaser2Angle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLaser1Angle
        '
        Me.srcLaser1Angle.BackColor = System.Drawing.Color.Black
        Me.srcLaser1Angle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLaser1Angle.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.srcLaser1Angle.ForeColor = System.Drawing.Color.White
        Me.srcLaser1Angle.Location = New System.Drawing.Point(1580, 26)
        Me.srcLaser1Angle.Name = "srcLaser1Angle"
        Me.srcLaser1Angle.Size = New System.Drawing.Size(114, 20)
        Me.srcLaser1Angle.TabIndex = 241
        Me.srcLaser1Angle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4050
        '
        Me.lbD4050.BackColor = System.Drawing.Color.Gray
        Me.lbD4050.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4050.Font = New System.Drawing.Font("Arial Narrow", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lbD4050.ForeColor = System.Drawing.Color.White
        Me.lbD4050.Location = New System.Drawing.Point(1700, 46)
        Me.lbD4050.Name = "lbD4050"
        Me.lbD4050.Size = New System.Drawing.Size(112, 20)
        Me.lbD4050.TabIndex = 240
        Me.lbD4050.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4001
        '
        Me.lbD4001.BackColor = System.Drawing.Color.Gray
        Me.lbD4001.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4001.Font = New System.Drawing.Font("Arial Narrow", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lbD4001.ForeColor = System.Drawing.Color.White
        Me.lbD4001.Location = New System.Drawing.Point(1756, 26)
        Me.lbD4001.Name = "lbD4001"
        Me.lbD4001.Size = New System.Drawing.Size(56, 20)
        Me.lbD4001.TabIndex = 239
        Me.lbD4001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4000
        '
        Me.lbD4000.BackColor = System.Drawing.Color.Gray
        Me.lbD4000.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4000.Font = New System.Drawing.Font("Arial Narrow", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lbD4000.ForeColor = System.Drawing.Color.White
        Me.lbD4000.Location = New System.Drawing.Point(1700, 26)
        Me.lbD4000.Name = "lbD4000"
        Me.lbD4000.Size = New System.Drawing.Size(56, 20)
        Me.lbD4000.TabIndex = 238
        Me.lbD4000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPlcConnectionState
        '
        Me.srcLbPlcConnectionState.BackColor = System.Drawing.Color.Gray
        Me.srcLbPlcConnectionState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPlcConnectionState.Font = New System.Drawing.Font("Arial Narrow", 11.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPlcConnectionState.ForeColor = System.Drawing.Color.White
        Me.srcLbPlcConnectionState.Location = New System.Drawing.Point(1625, 6)
        Me.srcLbPlcConnectionState.Name = "srcLbPlcConnectionState"
        Me.srcLbPlcConnectionState.Size = New System.Drawing.Size(69, 20)
        Me.srcLbPlcConnectionState.TabIndex = 237
        Me.srcLbPlcConnectionState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Black
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(1522, 46)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(60, 20)
        Me.Label45.TabIndex = 234
        Me.Label45.Text = "mm"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLaser2
        '
        Me.srcLaser2.BackColor = System.Drawing.Color.Black
        Me.srcLaser2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLaser2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.srcLaser2.ForeColor = System.Drawing.Color.White
        Me.srcLaser2.Location = New System.Drawing.Point(1428, 46)
        Me.srcLaser2.Name = "srcLaser2"
        Me.srcLaser2.Size = New System.Drawing.Size(94, 20)
        Me.srcLaser2.TabIndex = 233
        Me.srcLaser2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Black
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label58.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label58.ForeColor = System.Drawing.Color.White
        Me.Label58.Location = New System.Drawing.Point(1345, 46)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(83, 20)
        Me.Label58.TabIndex = 232
        Me.Label58.Text = "DIstance 2"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label108
        '
        Me.Label108.BackColor = System.Drawing.Color.Black
        Me.Label108.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label108.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.White
        Me.Label108.Location = New System.Drawing.Point(1030, 86)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(99, 20)
        Me.Label108.TabIndex = 228
        Me.Label108.Text = "Program Step"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcStep1
        '
        Me.srcStep1.BackColor = System.Drawing.Color.Black
        Me.srcStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcStep1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcStep1.ForeColor = System.Drawing.Color.White
        Me.srcStep1.Location = New System.Drawing.Point(1129, 86)
        Me.srcStep1.Name = "srcStep1"
        Me.srcStep1.Size = New System.Drawing.Size(90, 20)
        Me.srcStep1.TabIndex = 227
        Me.srcStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label93
        '
        Me.Label93.BackColor = System.Drawing.Color.Black
        Me.Label93.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label93.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.ForeColor = System.Drawing.Color.White
        Me.Label93.Location = New System.Drawing.Point(718, 66)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(87, 20)
        Me.Label93.TabIndex = 226
        Me.Label93.Text = "LH LOW"
        Me.Label93.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label95
        '
        Me.Label95.BackColor = System.Drawing.Color.Black
        Me.Label95.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label95.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.ForeColor = System.Drawing.Color.White
        Me.Label95.Location = New System.Drawing.Point(50, 66)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(87, 20)
        Me.Label95.TabIndex = 225
        Me.Label95.Text = "RH BOL INF"
        Me.Label95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label97
        '
        Me.Label97.BackColor = System.Drawing.Color.Black
        Me.Label97.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label97.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.ForeColor = System.Drawing.Color.White
        Me.Label97.Location = New System.Drawing.Point(718, 46)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(87, 20)
        Me.Label97.TabIndex = 224
        Me.Label97.Text = "RH UP"
        Me.Label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label101
        '
        Me.Label101.BackColor = System.Drawing.Color.Black
        Me.Label101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label101.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.White
        Me.Label101.Location = New System.Drawing.Point(50, 46)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(87, 20)
        Me.Label101.TabIndex = 223
        Me.Label101.Text = "RECL BWD"
        Me.Label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label102
        '
        Me.Label102.BackColor = System.Drawing.Color.Black
        Me.Label102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label102.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.ForeColor = System.Drawing.Color.White
        Me.Label102.Location = New System.Drawing.Point(718, 26)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(87, 20)
        Me.Label102.TabIndex = 222
        Me.Label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1345, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 20)
        Me.Label7.TabIndex = 165
        Me.Label7.Text = "Noise"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label105
        '
        Me.Label105.BackColor = System.Drawing.Color.Black
        Me.Label105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label105.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.ForeColor = System.Drawing.Color.White
        Me.Label105.Location = New System.Drawing.Point(718, 6)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(87, 20)
        Me.Label105.TabIndex = 221
        Me.Label105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Black
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(1345, 26)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 20)
        Me.Label24.TabIndex = 167
        Me.Label24.Text = "DIstance 1"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label107
        '
        Me.Label107.BackColor = System.Drawing.Color.Black
        Me.Label107.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label107.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.ForeColor = System.Drawing.Color.White
        Me.Label107.Location = New System.Drawing.Point(50, 26)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(87, 20)
        Me.Label107.TabIndex = 220
        Me.Label107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label78
        '
        Me.Label78.BackColor = System.Drawing.Color.Black
        Me.Label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label78.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.White
        Me.Label78.Location = New System.Drawing.Point(885, 66)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(87, 20)
        Me.Label78.TabIndex = 219
        Me.Label78.Text = "LH DEF"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label80
        '
        Me.Label80.BackColor = System.Drawing.Color.Black
        Me.Label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label80.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.White
        Me.Label80.Location = New System.Drawing.Point(217, 66)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(87, 20)
        Me.Label80.TabIndex = 218
        Me.Label80.Text = "RH BOL DEF"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label81
        '
        Me.Label81.BackColor = System.Drawing.Color.Black
        Me.Label81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label81.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.White
        Me.Label81.Location = New System.Drawing.Point(885, 46)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(87, 20)
        Me.Label81.TabIndex = 217
        Me.Label81.Text = "RH MID"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label85
        '
        Me.Label85.BackColor = System.Drawing.Color.Black
        Me.Label85.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label85.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.White
        Me.Label85.Location = New System.Drawing.Point(217, 46)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(87, 20)
        Me.Label85.TabIndex = 216
        Me.Label85.Text = "RECL FWD"
        Me.Label85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label87
        '
        Me.Label87.BackColor = System.Drawing.Color.Black
        Me.Label87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label87.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.ForeColor = System.Drawing.Color.White
        Me.Label87.Location = New System.Drawing.Point(885, 26)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(87, 20)
        Me.Label87.TabIndex = 215
        Me.Label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label89
        '
        Me.Label89.BackColor = System.Drawing.Color.Black
        Me.Label89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label89.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.White
        Me.Label89.Location = New System.Drawing.Point(885, 6)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(87, 20)
        Me.Label89.TabIndex = 214
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label91
        '
        Me.Label91.BackColor = System.Drawing.Color.Black
        Me.Label91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label91.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.White
        Me.Label91.Location = New System.Drawing.Point(217, 26)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(87, 20)
        Me.Label91.TabIndex = 213
        Me.Label91.Text = "USB CONNECT CHECK"
        Me.Label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Black
        Me.Label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label64.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.White
        Me.Label64.Location = New System.Drawing.Point(1052, 66)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(87, 20)
        Me.Label64.TabIndex = 212
        Me.Label64.Text = "LH BOL INF"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.Black
        Me.Label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label65.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.White
        Me.Label65.Location = New System.Drawing.Point(384, 66)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(87, 20)
        Me.Label65.TabIndex = 211
        Me.Label65.Text = "LH UP"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.Black
        Me.Label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label66.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.White
        Me.Label66.Location = New System.Drawing.Point(1052, 46)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(87, 20)
        Me.Label66.TabIndex = 210
        Me.Label66.Text = "RH LOW"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label72
        '
        Me.Label72.BackColor = System.Drawing.Color.Black
        Me.Label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label72.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.White
        Me.Label72.Location = New System.Drawing.Point(384, 46)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(87, 20)
        Me.Label72.TabIndex = 209
        Me.Label72.Text = "FREST BWD"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label73
        '
        Me.Label73.BackColor = System.Drawing.Color.Black
        Me.Label73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label73.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.White
        Me.Label73.Location = New System.Drawing.Point(1052, 26)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(87, 20)
        Me.Label73.TabIndex = 208
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.Color.Black
        Me.Label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label74.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.White
        Me.Label74.Location = New System.Drawing.Point(1052, 6)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(87, 20)
        Me.Label74.TabIndex = 207
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label77
        '
        Me.Label77.BackColor = System.Drawing.Color.Black
        Me.Label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label77.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.White
        Me.Label77.Location = New System.Drawing.Point(384, 26)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(87, 20)
        Me.Label77.TabIndex = 206
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.Black
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label63.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.White
        Me.Label63.Location = New System.Drawing.Point(1219, 66)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(87, 20)
        Me.Label63.TabIndex = 205
        Me.Label63.Text = "LH BOL DEF"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.Black
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label60.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.White
        Me.Label60.Location = New System.Drawing.Point(551, 66)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(87, 20)
        Me.Label60.TabIndex = 204
        Me.Label60.Text = "LH MID"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.Black
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label59.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.White
        Me.Label59.Location = New System.Drawing.Point(1219, 46)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(87, 20)
        Me.Label59.TabIndex = 203
        Me.Label59.Text = "RH DEF"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Black
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label57.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.White
        Me.Label57.Location = New System.Drawing.Point(551, 46)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(87, 20)
        Me.Label57.TabIndex = 202
        Me.Label57.Text = "FREST FWD"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Black
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label56.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.White
        Me.Label56.Location = New System.Drawing.Point(1219, 26)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(87, 20)
        Me.Label56.TabIndex = 201
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Black
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.White
        Me.Label53.Location = New System.Drawing.Point(1219, 6)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(87, 20)
        Me.Label53.TabIndex = 200
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Black
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label52.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(551, 26)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(87, 20)
        Me.Label52.TabIndex = 199
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Black
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(551, 6)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(87, 20)
        Me.Label48.TabIndex = 198
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Black
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(384, 6)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(87, 20)
        Me.Label42.TabIndex = 197
        Me.Label42.Text = "STOP"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Black
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(217, 6)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(87, 20)
        Me.Label41.TabIndex = 196
        Me.Label41.Text = "RESET"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Black
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(50, 6)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(87, 20)
        Me.Label27.TabIndex = 195
        Me.Label27.Text = "START BUTTON"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 20)
        Me.Label3.TabIndex = 194
        Me.Label3.Text = "Scanner"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcScannerInput
        '
        Me.srcScannerInput.BackColor = System.Drawing.Color.Black
        Me.srcScannerInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcScannerInput.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcScannerInput.ForeColor = System.Drawing.Color.White
        Me.srcScannerInput.Location = New System.Drawing.Point(82, 86)
        Me.srcScannerInput.Name = "srcScannerInput"
        Me.srcScannerInput.Size = New System.Drawing.Size(556, 20)
        Me.srcScannerInput.TabIndex = 193
        Me.srcScannerInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbRequestCount2
        '
        Me.lbRequestCount2.BackColor = System.Drawing.Color.Black
        Me.lbRequestCount2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRequestCount2.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRequestCount2.ForeColor = System.Drawing.Color.White
        Me.lbRequestCount2.Location = New System.Drawing.Point(932, 86)
        Me.lbRequestCount2.Name = "lbRequestCount2"
        Me.lbRequestCount2.Size = New System.Drawing.Size(98, 20)
        Me.lbRequestCount2.TabIndex = 192
        Me.lbRequestCount2.Text = "V"
        Me.lbRequestCount2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbRequestCount1
        '
        Me.lbRequestCount1.BackColor = System.Drawing.Color.Black
        Me.lbRequestCount1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRequestCount1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRequestCount1.ForeColor = System.Drawing.Color.White
        Me.lbRequestCount1.Location = New System.Drawing.Point(736, 86)
        Me.lbRequestCount1.Name = "lbRequestCount1"
        Me.lbRequestCount1.Size = New System.Drawing.Size(98, 20)
        Me.lbRequestCount1.TabIndex = 191
        Me.lbRequestCount1.Text = "V"
        Me.lbRequestCount1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbRequestStep2
        '
        Me.lbRequestStep2.BackColor = System.Drawing.Color.Black
        Me.lbRequestStep2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRequestStep2.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRequestStep2.ForeColor = System.Drawing.Color.White
        Me.lbRequestStep2.Location = New System.Drawing.Point(834, 86)
        Me.lbRequestStep2.Name = "lbRequestStep2"
        Me.lbRequestStep2.Size = New System.Drawing.Size(98, 20)
        Me.lbRequestStep2.TabIndex = 190
        Me.lbRequestStep2.Text = "V"
        Me.lbRequestStep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbRequestStep1
        '
        Me.lbRequestStep1.BackColor = System.Drawing.Color.Black
        Me.lbRequestStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRequestStep1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRequestStep1.ForeColor = System.Drawing.Color.White
        Me.lbRequestStep1.Location = New System.Drawing.Point(638, 86)
        Me.lbRequestStep1.Name = "lbRequestStep1"
        Me.lbRequestStep1.Size = New System.Drawing.Size(98, 20)
        Me.lbRequestStep1.TabIndex = 189
        Me.lbRequestStep1.Text = "V"
        Me.lbRequestStep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.Black
        Me.Label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label67.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label67.ForeColor = System.Drawing.Color.White
        Me.Label67.Location = New System.Drawing.Point(1771, 66)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(44, 20)
        Me.Label67.TabIndex = 188
        Me.Label67.Text = "V"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.Color.Black
        Me.Label68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label68.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label68.ForeColor = System.Drawing.Color.White
        Me.Label68.Location = New System.Drawing.Point(1536, 66)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(44, 20)
        Me.Label68.TabIndex = 187
        Me.Label68.Text = "V"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Black
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(1771, 86)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(44, 20)
        Me.Label37.TabIndex = 186
        Me.Label37.Text = "A"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.Color.Black
        Me.Label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label70.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label70.ForeColor = System.Drawing.Color.White
        Me.Label70.Location = New System.Drawing.Point(1536, 86)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(44, 20)
        Me.Label70.TabIndex = 185
        Me.Label70.Text = "A"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbSupply4Volt
        '
        Me.LbSupply4Volt.BackColor = System.Drawing.Color.Black
        Me.LbSupply4Volt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbSupply4Volt.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LbSupply4Volt.ForeColor = System.Drawing.Color.White
        Me.LbSupply4Volt.Location = New System.Drawing.Point(1580, 66)
        Me.LbSupply4Volt.Name = "LbSupply4Volt"
        Me.LbSupply4Volt.Size = New System.Drawing.Size(99, 20)
        Me.LbSupply4Volt.TabIndex = 184
        Me.LbSupply4Volt.Text = "VOLT(L/SUPT)"
        Me.LbSupply4Volt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbSupply3Volt
        '
        Me.LbSupply3Volt.BackColor = System.Drawing.Color.Black
        Me.LbSupply3Volt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbSupply3Volt.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LbSupply3Volt.ForeColor = System.Drawing.Color.White
        Me.LbSupply3Volt.Location = New System.Drawing.Point(1345, 66)
        Me.LbSupply3Volt.Name = "LbSupply3Volt"
        Me.LbSupply3Volt.Size = New System.Drawing.Size(99, 20)
        Me.LbSupply3Volt.TabIndex = 183
        Me.LbSupply3Volt.Text = "VOLT(RECL)"
        Me.LbSupply3Volt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbSupply2Volt
        '
        Me.LbSupply2Volt.BackColor = System.Drawing.Color.Black
        Me.LbSupply2Volt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbSupply2Volt.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LbSupply2Volt.ForeColor = System.Drawing.Color.White
        Me.LbSupply2Volt.Location = New System.Drawing.Point(1679, 66)
        Me.LbSupply2Volt.Name = "LbSupply2Volt"
        Me.LbSupply2Volt.Size = New System.Drawing.Size(92, 20)
        Me.LbSupply2Volt.TabIndex = 182
        Me.LbSupply2Volt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbSupply1Volt
        '
        Me.LbSupply1Volt.BackColor = System.Drawing.Color.Black
        Me.LbSupply1Volt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbSupply1Volt.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LbSupply1Volt.ForeColor = System.Drawing.Color.White
        Me.LbSupply1Volt.Location = New System.Drawing.Point(1444, 66)
        Me.LbSupply1Volt.Name = "LbSupply1Volt"
        Me.LbSupply1Volt.Size = New System.Drawing.Size(92, 20)
        Me.LbSupply1Volt.TabIndex = 181
        Me.LbSupply1Volt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbSupply4Amp
        '
        Me.LbSupply4Amp.BackColor = System.Drawing.Color.Black
        Me.LbSupply4Amp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbSupply4Amp.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LbSupply4Amp.ForeColor = System.Drawing.Color.White
        Me.LbSupply4Amp.Location = New System.Drawing.Point(1580, 86)
        Me.LbSupply4Amp.Name = "LbSupply4Amp"
        Me.LbSupply4Amp.Size = New System.Drawing.Size(99, 20)
        Me.LbSupply4Amp.TabIndex = 180
        Me.LbSupply4Amp.Text = "AMP(L/SUPT)"
        Me.LbSupply4Amp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbSupply3Amp
        '
        Me.LbSupply3Amp.BackColor = System.Drawing.Color.Black
        Me.LbSupply3Amp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbSupply3Amp.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LbSupply3Amp.ForeColor = System.Drawing.Color.White
        Me.LbSupply3Amp.Location = New System.Drawing.Point(1345, 86)
        Me.LbSupply3Amp.Name = "LbSupply3Amp"
        Me.LbSupply3Amp.Size = New System.Drawing.Size(99, 20)
        Me.LbSupply3Amp.TabIndex = 179
        Me.LbSupply3Amp.Text = "AMP(RECL)"
        Me.LbSupply3Amp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbSupply2Amp
        '
        Me.LbSupply2Amp.BackColor = System.Drawing.Color.Black
        Me.LbSupply2Amp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbSupply2Amp.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LbSupply2Amp.ForeColor = System.Drawing.Color.White
        Me.LbSupply2Amp.Location = New System.Drawing.Point(1679, 86)
        Me.LbSupply2Amp.Name = "LbSupply2Amp"
        Me.LbSupply2Amp.Size = New System.Drawing.Size(92, 20)
        Me.LbSupply2Amp.TabIndex = 178
        Me.LbSupply2Amp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbSupply1Amp
        '
        Me.LbSupply1Amp.BackColor = System.Drawing.Color.Black
        Me.LbSupply1Amp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbSupply1Amp.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LbSupply1Amp.ForeColor = System.Drawing.Color.White
        Me.LbSupply1Amp.Location = New System.Drawing.Point(1444, 86)
        Me.LbSupply1Amp.Name = "LbSupply1Amp"
        Me.LbSupply1Amp.Size = New System.Drawing.Size(92, 20)
        Me.LbSupply1Amp.TabIndex = 177
        Me.LbSupply1Amp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Black
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(1522, 26)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(60, 20)
        Me.Label32.TabIndex = 170
        Me.Label32.Text = "mm"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Black
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(1565, 6)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(60, 20)
        Me.Label31.TabIndex = 169
        Me.Label31.Text = "dB"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLaser1
        '
        Me.srcLaser1.BackColor = System.Drawing.Color.Black
        Me.srcLaser1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLaser1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.srcLaser1.ForeColor = System.Drawing.Color.White
        Me.srcLaser1.Location = New System.Drawing.Point(1428, 26)
        Me.srcLaser1.Name = "srcLaser1"
        Me.srcLaser1.Size = New System.Drawing.Size(94, 20)
        Me.srcLaser1.TabIndex = 168
        Me.srcLaser1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcNoise
        '
        Me.srcNoise.BackColor = System.Drawing.Color.Black
        Me.srcNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcNoise.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.srcNoise.ForeColor = System.Drawing.Color.White
        Me.srcNoise.Location = New System.Drawing.Point(1428, 6)
        Me.srcNoise.Name = "srcNoise"
        Me.srcNoise.Size = New System.Drawing.Size(137, 20)
        Me.srcNoise.TabIndex = 166
        Me.srcNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_15
        '
        Me.P_OUT_15.BackColor = System.Drawing.Color.Black
        Me.P_OUT_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_15.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_15.ForeColor = System.Drawing.Color.White
        Me.P_OUT_15.Location = New System.Drawing.Point(1306, 66)
        Me.P_OUT_15.Name = "P_OUT_15"
        Me.P_OUT_15.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_15.TabIndex = 164
        Me.P_OUT_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Black
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(1172, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 20)
        Me.Label16.TabIndex = 163
        Me.Label16.Text = "OUT 15"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_14
        '
        Me.P_OUT_14.BackColor = System.Drawing.Color.Black
        Me.P_OUT_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_14.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_14.ForeColor = System.Drawing.Color.White
        Me.P_OUT_14.Location = New System.Drawing.Point(1139, 66)
        Me.P_OUT_14.Name = "P_OUT_14"
        Me.P_OUT_14.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_14.TabIndex = 162
        Me.P_OUT_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Black
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(1005, 66)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 20)
        Me.Label18.TabIndex = 161
        Me.Label18.Text = "OUT 14"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_13
        '
        Me.P_OUT_13.BackColor = System.Drawing.Color.Black
        Me.P_OUT_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_13.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_13.ForeColor = System.Drawing.Color.White
        Me.P_OUT_13.Location = New System.Drawing.Point(972, 66)
        Me.P_OUT_13.Name = "P_OUT_13"
        Me.P_OUT_13.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_13.TabIndex = 160
        Me.P_OUT_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Black
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(838, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(47, 20)
        Me.Label20.TabIndex = 159
        Me.Label20.Text = "OUT 13"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_12
        '
        Me.P_OUT_12.BackColor = System.Drawing.Color.Black
        Me.P_OUT_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_12.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_12.ForeColor = System.Drawing.Color.White
        Me.P_OUT_12.Location = New System.Drawing.Point(805, 66)
        Me.P_OUT_12.Name = "P_OUT_12"
        Me.P_OUT_12.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_12.TabIndex = 158
        Me.P_OUT_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Black
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(671, 66)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(47, 20)
        Me.Label26.TabIndex = 157
        Me.Label26.Text = "OUT 12"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_11
        '
        Me.P_OUT_11.BackColor = System.Drawing.Color.Black
        Me.P_OUT_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_11.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_11.ForeColor = System.Drawing.Color.White
        Me.P_OUT_11.Location = New System.Drawing.Point(638, 66)
        Me.P_OUT_11.Name = "P_OUT_11"
        Me.P_OUT_11.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_11.TabIndex = 156
        Me.P_OUT_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Black
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(504, 66)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(47, 20)
        Me.Label30.TabIndex = 155
        Me.Label30.Text = "OUT 11"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_10
        '
        Me.P_OUT_10.BackColor = System.Drawing.Color.Black
        Me.P_OUT_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_10.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_10.ForeColor = System.Drawing.Color.White
        Me.P_OUT_10.Location = New System.Drawing.Point(471, 66)
        Me.P_OUT_10.Name = "P_OUT_10"
        Me.P_OUT_10.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_10.TabIndex = 154
        Me.P_OUT_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Black
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(337, 66)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 20)
        Me.Label34.TabIndex = 153
        Me.Label34.Text = "OUT 10"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_09
        '
        Me.P_OUT_09.BackColor = System.Drawing.Color.Black
        Me.P_OUT_09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_09.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_09.ForeColor = System.Drawing.Color.White
        Me.P_OUT_09.Location = New System.Drawing.Point(304, 66)
        Me.P_OUT_09.Name = "P_OUT_09"
        Me.P_OUT_09.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_09.TabIndex = 152
        Me.P_OUT_09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Black
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(170, 66)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(47, 20)
        Me.Label40.TabIndex = 151
        Me.Label40.Text = "OUT 09"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_08
        '
        Me.P_OUT_08.BackColor = System.Drawing.Color.Black
        Me.P_OUT_08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_08.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_08.ForeColor = System.Drawing.Color.White
        Me.P_OUT_08.Location = New System.Drawing.Point(137, 66)
        Me.P_OUT_08.Name = "P_OUT_08"
        Me.P_OUT_08.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_08.TabIndex = 150
        Me.P_OUT_08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Black
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label46.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(3, 66)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(47, 20)
        Me.Label46.TabIndex = 149
        Me.Label46.Text = "OUT 08"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_07
        '
        Me.P_OUT_07.BackColor = System.Drawing.Color.Black
        Me.P_OUT_07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_07.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_07.ForeColor = System.Drawing.Color.White
        Me.P_OUT_07.Location = New System.Drawing.Point(1306, 46)
        Me.P_OUT_07.Name = "P_OUT_07"
        Me.P_OUT_07.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_07.TabIndex = 148
        Me.P_OUT_07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label94
        '
        Me.Label94.BackColor = System.Drawing.Color.Black
        Me.Label94.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label94.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label94.ForeColor = System.Drawing.Color.White
        Me.Label94.Location = New System.Drawing.Point(1172, 46)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(47, 20)
        Me.Label94.TabIndex = 147
        Me.Label94.Text = "OUT 07"
        Me.Label94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_06
        '
        Me.P_OUT_06.BackColor = System.Drawing.Color.Black
        Me.P_OUT_06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_06.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_06.ForeColor = System.Drawing.Color.White
        Me.P_OUT_06.Location = New System.Drawing.Point(1139, 46)
        Me.P_OUT_06.Name = "P_OUT_06"
        Me.P_OUT_06.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_06.TabIndex = 146
        Me.P_OUT_06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label96
        '
        Me.Label96.BackColor = System.Drawing.Color.Black
        Me.Label96.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label96.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.ForeColor = System.Drawing.Color.White
        Me.Label96.Location = New System.Drawing.Point(1005, 46)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(47, 20)
        Me.Label96.TabIndex = 145
        Me.Label96.Text = "OUT 06"
        Me.Label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_05
        '
        Me.P_OUT_05.BackColor = System.Drawing.Color.Black
        Me.P_OUT_05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_05.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_05.ForeColor = System.Drawing.Color.White
        Me.P_OUT_05.Location = New System.Drawing.Point(972, 46)
        Me.P_OUT_05.Name = "P_OUT_05"
        Me.P_OUT_05.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_05.TabIndex = 144
        Me.P_OUT_05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label98
        '
        Me.Label98.BackColor = System.Drawing.Color.Black
        Me.Label98.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label98.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.ForeColor = System.Drawing.Color.White
        Me.Label98.Location = New System.Drawing.Point(838, 46)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(47, 20)
        Me.Label98.TabIndex = 143
        Me.Label98.Text = "OUT 05"
        Me.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_04
        '
        Me.P_OUT_04.BackColor = System.Drawing.Color.Black
        Me.P_OUT_04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_04.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_04.ForeColor = System.Drawing.Color.White
        Me.P_OUT_04.Location = New System.Drawing.Point(805, 46)
        Me.P_OUT_04.Name = "P_OUT_04"
        Me.P_OUT_04.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_04.TabIndex = 142
        Me.P_OUT_04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label100
        '
        Me.Label100.BackColor = System.Drawing.Color.Black
        Me.Label100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label100.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label100.ForeColor = System.Drawing.Color.White
        Me.Label100.Location = New System.Drawing.Point(671, 46)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(47, 20)
        Me.Label100.TabIndex = 141
        Me.Label100.Text = "OUT 04"
        Me.Label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_03
        '
        Me.P_OUT_03.BackColor = System.Drawing.Color.Black
        Me.P_OUT_03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_03.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_03.ForeColor = System.Drawing.Color.White
        Me.P_OUT_03.Location = New System.Drawing.Point(638, 46)
        Me.P_OUT_03.Name = "P_OUT_03"
        Me.P_OUT_03.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_03.TabIndex = 140
        Me.P_OUT_03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label92
        '
        Me.Label92.BackColor = System.Drawing.Color.Black
        Me.Label92.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label92.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.White
        Me.Label92.Location = New System.Drawing.Point(504, 46)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(47, 20)
        Me.Label92.TabIndex = 139
        Me.Label92.Text = "OUT 03"
        Me.Label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_02
        '
        Me.P_OUT_02.BackColor = System.Drawing.Color.Black
        Me.P_OUT_02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_02.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_02.ForeColor = System.Drawing.Color.White
        Me.P_OUT_02.Location = New System.Drawing.Point(471, 46)
        Me.P_OUT_02.Name = "P_OUT_02"
        Me.P_OUT_02.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_02.TabIndex = 138
        Me.P_OUT_02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label90
        '
        Me.Label90.BackColor = System.Drawing.Color.Black
        Me.Label90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label90.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.White
        Me.Label90.Location = New System.Drawing.Point(337, 46)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(47, 20)
        Me.Label90.TabIndex = 137
        Me.Label90.Text = "OUT 02"
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_01
        '
        Me.P_OUT_01.BackColor = System.Drawing.Color.Black
        Me.P_OUT_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_01.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_01.ForeColor = System.Drawing.Color.White
        Me.P_OUT_01.Location = New System.Drawing.Point(304, 46)
        Me.P_OUT_01.Name = "P_OUT_01"
        Me.P_OUT_01.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_01.TabIndex = 136
        Me.P_OUT_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label88
        '
        Me.Label88.BackColor = System.Drawing.Color.Black
        Me.Label88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label88.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.White
        Me.Label88.Location = New System.Drawing.Point(170, 46)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(47, 20)
        Me.Label88.TabIndex = 135
        Me.Label88.Text = "OUT 01"
        Me.Label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_OUT_00
        '
        Me.P_OUT_00.BackColor = System.Drawing.Color.Black
        Me.P_OUT_00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_OUT_00.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_OUT_00.ForeColor = System.Drawing.Color.White
        Me.P_OUT_00.Location = New System.Drawing.Point(137, 46)
        Me.P_OUT_00.Name = "P_OUT_00"
        Me.P_OUT_00.Size = New System.Drawing.Size(33, 20)
        Me.P_OUT_00.TabIndex = 134
        Me.P_OUT_00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label86
        '
        Me.Label86.BackColor = System.Drawing.Color.Black
        Me.Label86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label86.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.White
        Me.Label86.Location = New System.Drawing.Point(3, 46)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(47, 20)
        Me.Label86.TabIndex = 133
        Me.Label86.Text = "OUT 00"
        Me.Label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_15
        '
        Me.P_IN_15.BackColor = System.Drawing.Color.Black
        Me.P_IN_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_15.ForeColor = System.Drawing.Color.White
        Me.P_IN_15.Location = New System.Drawing.Point(1306, 26)
        Me.P_IN_15.Name = "P_IN_15"
        Me.P_IN_15.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_15.TabIndex = 100
        Me.P_IN_15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1172, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 20)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "IN 15"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_14
        '
        Me.P_IN_14.BackColor = System.Drawing.Color.Black
        Me.P_IN_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_14.ForeColor = System.Drawing.Color.White
        Me.P_IN_14.Location = New System.Drawing.Point(1139, 26)
        Me.P_IN_14.Name = "P_IN_14"
        Me.P_IN_14.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_14.TabIndex = 98
        Me.P_IN_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Black
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(1005, 26)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(47, 20)
        Me.Label39.TabIndex = 97
        Me.Label39.Text = "IN 14"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_13
        '
        Me.P_IN_13.BackColor = System.Drawing.Color.Black
        Me.P_IN_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_13.ForeColor = System.Drawing.Color.White
        Me.P_IN_13.Location = New System.Drawing.Point(972, 26)
        Me.P_IN_13.Name = "P_IN_13"
        Me.P_IN_13.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_13.TabIndex = 96
        Me.P_IN_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(838, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 20)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "IN 13"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_12
        '
        Me.P_IN_12.BackColor = System.Drawing.Color.Black
        Me.P_IN_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_12.ForeColor = System.Drawing.Color.White
        Me.P_IN_12.Location = New System.Drawing.Point(805, 26)
        Me.P_IN_12.Name = "P_IN_12"
        Me.P_IN_12.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_12.TabIndex = 94
        Me.P_IN_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Black
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(671, 26)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(47, 20)
        Me.Label43.TabIndex = 93
        Me.Label43.Text = "IN 12"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_11
        '
        Me.P_IN_11.BackColor = System.Drawing.Color.Black
        Me.P_IN_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_11.ForeColor = System.Drawing.Color.White
        Me.P_IN_11.Location = New System.Drawing.Point(1306, 6)
        Me.P_IN_11.Name = "P_IN_11"
        Me.P_IN_11.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_11.TabIndex = 92
        Me.P_IN_11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Black
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(1172, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 20)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "IN 11"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_10
        '
        Me.P_IN_10.BackColor = System.Drawing.Color.Black
        Me.P_IN_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_10.ForeColor = System.Drawing.Color.White
        Me.P_IN_10.Location = New System.Drawing.Point(1139, 6)
        Me.P_IN_10.Name = "P_IN_10"
        Me.P_IN_10.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_10.TabIndex = 90
        Me.P_IN_10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Black
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(1005, 6)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(47, 20)
        Me.Label47.TabIndex = 89
        Me.Label47.Text = "IN 10"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_09
        '
        Me.P_IN_09.BackColor = System.Drawing.Color.Black
        Me.P_IN_09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_09.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_09.ForeColor = System.Drawing.Color.White
        Me.P_IN_09.Location = New System.Drawing.Point(972, 6)
        Me.P_IN_09.Name = "P_IN_09"
        Me.P_IN_09.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_09.TabIndex = 88
        Me.P_IN_09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Black
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label49.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.White
        Me.Label49.Location = New System.Drawing.Point(838, 6)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(47, 20)
        Me.Label49.TabIndex = 87
        Me.Label49.Text = "IN 09"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_08
        '
        Me.P_IN_08.BackColor = System.Drawing.Color.Black
        Me.P_IN_08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_08.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_08.ForeColor = System.Drawing.Color.White
        Me.P_IN_08.Location = New System.Drawing.Point(805, 6)
        Me.P_IN_08.Name = "P_IN_08"
        Me.P_IN_08.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_08.TabIndex = 86
        Me.P_IN_08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Black
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(671, 6)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(47, 20)
        Me.Label51.TabIndex = 85
        Me.Label51.Text = "IN 08"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_07
        '
        Me.P_IN_07.BackColor = System.Drawing.Color.Black
        Me.P_IN_07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_07.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_07.ForeColor = System.Drawing.Color.White
        Me.P_IN_07.Location = New System.Drawing.Point(638, 26)
        Me.P_IN_07.Name = "P_IN_07"
        Me.P_IN_07.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_07.TabIndex = 84
        Me.P_IN_07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Black
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(504, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 20)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "IN 07"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_06
        '
        Me.P_IN_06.BackColor = System.Drawing.Color.Black
        Me.P_IN_06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_06.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_06.ForeColor = System.Drawing.Color.White
        Me.P_IN_06.Location = New System.Drawing.Point(471, 26)
        Me.P_IN_06.Name = "P_IN_06"
        Me.P_IN_06.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_06.TabIndex = 82
        Me.P_IN_06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Black
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(337, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 20)
        Me.Label11.TabIndex = 81
        Me.Label11.Text = "IN 06"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_05
        '
        Me.P_IN_05.BackColor = System.Drawing.Color.Black
        Me.P_IN_05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_05.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_05.ForeColor = System.Drawing.Color.White
        Me.P_IN_05.Location = New System.Drawing.Point(304, 26)
        Me.P_IN_05.Name = "P_IN_05"
        Me.P_IN_05.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_05.TabIndex = 80
        Me.P_IN_05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Black
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(170, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 20)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "IN 05"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_04
        '
        Me.P_IN_04.BackColor = System.Drawing.Color.Black
        Me.P_IN_04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_04.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_04.ForeColor = System.Drawing.Color.White
        Me.P_IN_04.Location = New System.Drawing.Point(137, 26)
        Me.P_IN_04.Name = "P_IN_04"
        Me.P_IN_04.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_04.TabIndex = 78
        Me.P_IN_04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Black
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(3, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 20)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "IN 04"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_03
        '
        Me.P_IN_03.BackColor = System.Drawing.Color.Black
        Me.P_IN_03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_03.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_03.ForeColor = System.Drawing.Color.White
        Me.P_IN_03.Location = New System.Drawing.Point(638, 6)
        Me.P_IN_03.Name = "P_IN_03"
        Me.P_IN_03.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_03.TabIndex = 76
        Me.P_IN_03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Black
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(504, 6)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(47, 20)
        Me.Label25.TabIndex = 75
        Me.Label25.Text = "IN 03"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_02
        '
        Me.P_IN_02.BackColor = System.Drawing.Color.Black
        Me.P_IN_02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_02.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_02.ForeColor = System.Drawing.Color.White
        Me.P_IN_02.Location = New System.Drawing.Point(471, 6)
        Me.P_IN_02.Name = "P_IN_02"
        Me.P_IN_02.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_02.TabIndex = 74
        Me.P_IN_02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Black
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(337, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 20)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "IN 02"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_01
        '
        Me.P_IN_01.BackColor = System.Drawing.Color.Black
        Me.P_IN_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_01.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_01.ForeColor = System.Drawing.Color.White
        Me.P_IN_01.Location = New System.Drawing.Point(304, 6)
        Me.P_IN_01.Name = "P_IN_01"
        Me.P_IN_01.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_01.TabIndex = 72
        Me.P_IN_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Black
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(170, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 20)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "IN 01"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P_IN_00
        '
        Me.P_IN_00.BackColor = System.Drawing.Color.Black
        Me.P_IN_00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_IN_00.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_IN_00.ForeColor = System.Drawing.Color.White
        Me.P_IN_00.Location = New System.Drawing.Point(137, 6)
        Me.P_IN_00.Name = "P_IN_00"
        Me.P_IN_00.Size = New System.Drawing.Size(33, 20)
        Me.P_IN_00.TabIndex = 70
        Me.P_IN_00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Black
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(3, 6)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 20)
        Me.Label21.TabIndex = 69
        Me.Label21.Text = "IN 00"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TmrIO
        '
        '
        'Panel_FWD_AMP_SPEC
        '
        Me.Panel_FWD_AMP_SPEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel_FWD_AMP_SPEC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_FWD_AMP_SPEC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_FWD_AMP_SPEC.ForeColor = System.Drawing.Color.Black
        Me.Panel_FWD_AMP_SPEC.Location = New System.Drawing.Point(76, 508)
        Me.Panel_FWD_AMP_SPEC.Name = "Panel_FWD_AMP_SPEC"
        Me.Panel_FWD_AMP_SPEC.Size = New System.Drawing.Size(134, 27)
        Me.Panel_FWD_AMP_SPEC.TabIndex = 239
        Me.Panel_FWD_AMP_SPEC.Text = "0.9 ~ 2.6 A"
        Me.Panel_FWD_AMP_SPEC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel_LSUPT_FWD_AMP
        '
        Me.Panel_LSUPT_FWD_AMP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel_LSUPT_FWD_AMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_LSUPT_FWD_AMP.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel_LSUPT_FWD_AMP.ForeColor = System.Drawing.Color.Black
        Me.Panel_LSUPT_FWD_AMP.Location = New System.Drawing.Point(569, 508)
        Me.Panel_LSUPT_FWD_AMP.Name = "Panel_LSUPT_FWD_AMP"
        Me.Panel_LSUPT_FWD_AMP.Size = New System.Drawing.Size(90, 27)
        Me.Panel_LSUPT_FWD_AMP.TabIndex = 433
        Me.Panel_LSUPT_FWD_AMP.Text = "2.3"
        Me.Panel_LSUPT_FWD_AMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DarkGray
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1914, 31)
        Me.MenuStrip1.TabIndex = 99
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SerialPortToolStripMenuItem, Me.BasicToolStripMenuItem, Me.BarcodeToolStripMenuItem, Me.VitualKeyboardToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(62, 27)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'SerialPortToolStripMenuItem
        '
        Me.SerialPortToolStripMenuItem.Name = "SerialPortToolStripMenuItem"
        Me.SerialPortToolStripMenuItem.Size = New System.Drawing.Size(189, 28)
        Me.SerialPortToolStripMenuItem.Text = "Serial Port"
        '
        'BasicToolStripMenuItem
        '
        Me.BasicToolStripMenuItem.Name = "BasicToolStripMenuItem"
        Me.BasicToolStripMenuItem.Size = New System.Drawing.Size(189, 28)
        Me.BasicToolStripMenuItem.Text = "Basic"
        '
        'BarcodeToolStripMenuItem
        '
        Me.BarcodeToolStripMenuItem.Name = "BarcodeToolStripMenuItem"
        Me.BarcodeToolStripMenuItem.Size = New System.Drawing.Size(189, 28)
        Me.BarcodeToolStripMenuItem.Text = "Barcode"
        '
        'VitualKeyboardToolStripMenuItem
        '
        Me.VitualKeyboardToolStripMenuItem.Name = "VitualKeyboardToolStripMenuItem"
        Me.VitualKeyboardToolStripMenuItem.Size = New System.Drawing.Size(189, 28)
        Me.VitualKeyboardToolStripMenuItem.Text = "Vitual Keyboard"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(189, 28)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'srcLbSerial
        '
        Me.srcLbSerial.BackColor = System.Drawing.Color.Black
        Me.srcLbSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbSerial.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbSerial.ForeColor = System.Drawing.Color.White
        Me.srcLbSerial.Location = New System.Drawing.Point(1017, 78)
        Me.srcLbSerial.Name = "srcLbSerial"
        Me.srcLbSerial.Size = New System.Drawing.Size(372, 31)
        Me.srcLbSerial.TabIndex = 34
        Me.srcLbSerial.Text = "PART NO."
        Me.srcLbSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartName
        '
        Me.srcLbPartName.BackColor = System.Drawing.Color.Black
        Me.srcLbPartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartName.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartName.ForeColor = System.Drawing.Color.White
        Me.srcLbPartName.Location = New System.Drawing.Point(440, 78)
        Me.srcLbPartName.Name = "srcLbPartName"
        Me.srcLbPartName.Size = New System.Drawing.Size(577, 31)
        Me.srcLbPartName.TabIndex = 32
        Me.srcLbPartName.Text = "PART NO."
        Me.srcLbPartName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartNo
        '
        Me.srcLbPartNo.BackColor = System.Drawing.Color.Black
        Me.srcLbPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartNo.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartNo.ForeColor = System.Drawing.Color.White
        Me.srcLbPartNo.Location = New System.Drawing.Point(222, 78)
        Me.srcLbPartNo.Name = "srcLbPartNo"
        Me.srcLbPartNo.Size = New System.Drawing.Size(218, 31)
        Me.srcLbPartNo.TabIndex = 31
        Me.srcLbPartNo.Text = "PART NO."
        Me.srcLbPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.lbCanStep)
        Me.Panel11.Controls.Add(Me.lbCanConnection)
        Me.Panel11.Controls.Add(Me.LbCan)
        Me.Panel11.Controls.Add(Me.ActPlc)
        Me.Panel11.Controls.Add(Me.Label19)
        Me.Panel11.Location = New System.Drawing.Point(3, 34)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1556, 44)
        Me.Panel11.TabIndex = 113
        '
        'lbCanStep
        '
        Me.lbCanStep.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbCanStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbCanStep.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCanStep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbCanStep.Location = New System.Drawing.Point(1070, 4)
        Me.lbCanStep.Name = "lbCanStep"
        Me.lbCanStep.Size = New System.Drawing.Size(89, 32)
        Me.lbCanStep.TabIndex = 653
        Me.lbCanStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbCanConnection
        '
        Me.lbCanConnection.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbCanConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbCanConnection.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCanConnection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbCanConnection.Location = New System.Drawing.Point(1159, 4)
        Me.lbCanConnection.Name = "lbCanConnection"
        Me.lbCanConnection.Size = New System.Drawing.Size(183, 32)
        Me.lbCanConnection.TabIndex = 652
        Me.lbCanConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbCan
        '
        Me.LbCan.BackColor = System.Drawing.Color.Black
        Me.LbCan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LbCan.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCan.ForeColor = System.Drawing.Color.White
        Me.LbCan.Location = New System.Drawing.Point(1342, 4)
        Me.LbCan.Name = "LbCan"
        Me.LbCan.Size = New System.Drawing.Size(210, 32)
        Me.LbCan.TabIndex = 651
        Me.LbCan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Black
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 28.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(0, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(1556, 44)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "RS4 FRT BACK NOISE TEST SYSTEM"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Navy
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(219, 31)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "사양정보"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label35)
        Me.Panel6.Controls.Add(Me.Label36)
        Me.Panel6.Controls.Add(Me.Label44)
        Me.Panel6.Controls.Add(Me.Label50)
        Me.Panel6.Controls.Add(Me.Label54)
        Me.Panel6.Controls.Add(Me.Label111)
        Me.Panel6.Controls.Add(Me.Label145)
        Me.Panel6.Controls.Add(Me.Label149)
        Me.Panel6.Controls.Add(Me.Label150)
        Me.Panel6.Controls.Add(Me.srclbValReclBwdTicTime)
        Me.Panel6.Controls.Add(Me.srclbValReclBwdEndAngle)
        Me.Panel6.Controls.Add(Me.srclbValReclBwdStartAngle)
        Me.Panel6.Controls.Add(Me.Label144)
        Me.Panel6.Controls.Add(Me.Label140)
        Me.Panel6.Controls.Add(Me.Label139)
        Me.Panel6.Controls.Add(Me.srclbValReclFwdTicTime)
        Me.Panel6.Controls.Add(Me.srclbValReclFwdEndAngle)
        Me.Panel6.Controls.Add(Me.srclbValReclFwdStartAngle)
        Me.Panel6.Controls.Add(Me.Label132)
        Me.Panel6.Controls.Add(Me.Label17)
        Me.Panel6.Controls.Add(Me.srclbValReclBwdSpeed)
        Me.Panel6.Controls.Add(Me.Label126)
        Me.Panel6.Controls.Add(Me.srclbDecReclBwdSpeed)
        Me.Panel6.Controls.Add(Me.srclbSpecReclBwdSpeed)
        Me.Panel6.Controls.Add(Me.srclbValReclFwdSpeed)
        Me.Panel6.Controls.Add(Me.Label112)
        Me.Panel6.Controls.Add(Me.srclbDecReclFwdSpeed)
        Me.Panel6.Controls.Add(Me.srclbSpecReclFwdSpeed)
        Me.Panel6.Controls.Add(Me.Label122)
        Me.Panel6.Controls.Add(Me.srcGraphReclBAmp)
        Me.Panel6.Controls.Add(Me.srcGraphReclBNoise)
        Me.Panel6.Controls.Add(Me.srcGraphReclFAmp)
        Me.Panel6.Controls.Add(Me.srcGraphReclFNoise)
        Me.Panel6.Controls.Add(Me.srclbValReclEndAngle)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.srclbValReclBwdAngle)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label38)
        Me.Panel6.Controls.Add(Me.srclbDecReclBwdAngle)
        Me.Panel6.Controls.Add(Me.srclbSpecReclBwdAngle)
        Me.Panel6.Controls.Add(Me.srclbDecReclEndAngle)
        Me.Panel6.Controls.Add(Me.srclbValReclBwdAmp)
        Me.Panel6.Controls.Add(Me.Label55)
        Me.Panel6.Controls.Add(Me.srclbDecReclBwdAmp)
        Me.Panel6.Controls.Add(Me.srclbSpecReclBwdAmp)
        Me.Panel6.Controls.Add(Me.srclbValReclBwdNoise)
        Me.Panel6.Controls.Add(Me.srclbSpecReclEndAngle)
        Me.Panel6.Controls.Add(Me.Label84)
        Me.Panel6.Controls.Add(Me.srclbDecReclBwdNoise)
        Me.Panel6.Controls.Add(Me.srclbSpecReclBwdNoise)
        Me.Panel6.Controls.Add(Me.Label33)
        Me.Panel6.Controls.Add(Me.Label29)
        Me.Panel6.Controls.Add(Me.Label28)
        Me.Panel6.Controls.Add(Me.Label23)
        Me.Panel6.Controls.Add(Me.Label22)
        Me.Panel6.Controls.Add(Me.srclbValReclFwdAngle)
        Me.Panel6.Controls.Add(Me.Label79)
        Me.Panel6.Controls.Add(Me.srclbDecReclFwdAngle)
        Me.Panel6.Controls.Add(Me.srclbSpecReclFwdAngle)
        Me.Panel6.Controls.Add(Me.Label83)
        Me.Panel6.Controls.Add(Me.srclbValReclFwdAmp)
        Me.Panel6.Controls.Add(Me.Label71)
        Me.Panel6.Controls.Add(Me.srclbDecReclFwdAmp)
        Me.Panel6.Controls.Add(Me.srclbSpecReclFwdAmp)
        Me.Panel6.Controls.Add(Me.Label75)
        Me.Panel6.Controls.Add(Me.srclbValReclFwdNoise)
        Me.Panel6.Controls.Add(Me.Label69)
        Me.Panel6.Controls.Add(Me.srclbDecReclFwdNoise)
        Me.Panel6.Controls.Add(Me.srclbSpecReclFwdNoise)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.Label120)
        Me.Panel6.Location = New System.Drawing.Point(3, 109)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1912, 313)
        Me.Panel6.TabIndex = 255
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Black
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(1613, 237)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(64, 26)
        Me.Label35.TabIndex = 631
        Me.Label35.Text = "종료각"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Black
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(1613, 211)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(64, 26)
        Me.Label36.TabIndex = 630
        Me.Label36.Text = "시작각"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Black
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label44.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(1613, 167)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(64, 44)
        Me.Label44.TabIndex = 629
        Me.Label44.Text = "속도"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Black
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label50.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.White
        Me.Label50.Location = New System.Drawing.Point(1613, 123)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(64, 44)
        Me.Label50.TabIndex = 628
        Me.Label50.Text = "각도"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Black
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label54.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.White
        Me.Label54.Location = New System.Drawing.Point(1613, 79)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(64, 44)
        Me.Label54.TabIndex = 627
        Me.Label54.Text = "전류"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label111
        '
        Me.Label111.BackColor = System.Drawing.Color.Black
        Me.Label111.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label111.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.ForeColor = System.Drawing.Color.White
        Me.Label111.Location = New System.Drawing.Point(1613, 35)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(64, 44)
        Me.Label111.TabIndex = 626
        Me.Label111.Text = "소음"
        Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label145
        '
        Me.Label145.BackColor = System.Drawing.Color.Black
        Me.Label145.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label145.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label145.ForeColor = System.Drawing.Color.White
        Me.Label145.Location = New System.Drawing.Point(1763, 237)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(27, 26)
        Me.Label145.TabIndex = 625
        Me.Label145.Text = "°"
        Me.Label145.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label149
        '
        Me.Label149.BackColor = System.Drawing.Color.Black
        Me.Label149.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label149.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label149.ForeColor = System.Drawing.Color.White
        Me.Label149.Location = New System.Drawing.Point(1763, 211)
        Me.Label149.Name = "Label149"
        Me.Label149.Size = New System.Drawing.Size(27, 26)
        Me.Label149.TabIndex = 624
        Me.Label149.Text = "°"
        Me.Label149.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label150
        '
        Me.Label150.BackColor = System.Drawing.Color.Black
        Me.Label150.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label150.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label150.ForeColor = System.Drawing.Color.White
        Me.Label150.Location = New System.Drawing.Point(1866, 211)
        Me.Label150.Name = "Label150"
        Me.Label150.Size = New System.Drawing.Size(27, 51)
        Me.Label150.TabIndex = 623
        Me.Label150.Text = "s"
        Me.Label150.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclBwdTicTime
        '
        Me.srclbValReclBwdTicTime.BackColor = System.Drawing.Color.Black
        Me.srclbValReclBwdTicTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclBwdTicTime.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclBwdTicTime.ForeColor = System.Drawing.Color.White
        Me.srclbValReclBwdTicTime.Location = New System.Drawing.Point(1790, 211)
        Me.srclbValReclBwdTicTime.Name = "srclbValReclBwdTicTime"
        Me.srclbValReclBwdTicTime.Size = New System.Drawing.Size(76, 51)
        Me.srclbValReclBwdTicTime.TabIndex = 622
        Me.srclbValReclBwdTicTime.Text = "23.5"
        Me.srclbValReclBwdTicTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclBwdEndAngle
        '
        Me.srclbValReclBwdEndAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValReclBwdEndAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclBwdEndAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclBwdEndAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValReclBwdEndAngle.Location = New System.Drawing.Point(1677, 237)
        Me.srclbValReclBwdEndAngle.Name = "srclbValReclBwdEndAngle"
        Me.srclbValReclBwdEndAngle.Size = New System.Drawing.Size(86, 26)
        Me.srclbValReclBwdEndAngle.TabIndex = 621
        Me.srclbValReclBwdEndAngle.Text = "45.5"
        Me.srclbValReclBwdEndAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclBwdStartAngle
        '
        Me.srclbValReclBwdStartAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValReclBwdStartAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclBwdStartAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclBwdStartAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValReclBwdStartAngle.Location = New System.Drawing.Point(1677, 211)
        Me.srclbValReclBwdStartAngle.Name = "srclbValReclBwdStartAngle"
        Me.srclbValReclBwdStartAngle.Size = New System.Drawing.Size(86, 26)
        Me.srclbValReclBwdStartAngle.TabIndex = 620
        Me.srclbValReclBwdStartAngle.Text = "23.5"
        Me.srclbValReclBwdStartAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label144
        '
        Me.Label144.BackColor = System.Drawing.Color.Black
        Me.Label144.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label144.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label144.ForeColor = System.Drawing.Color.White
        Me.Label144.Location = New System.Drawing.Point(815, 237)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(27, 26)
        Me.Label144.TabIndex = 617
        Me.Label144.Text = "°"
        Me.Label144.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label140
        '
        Me.Label140.BackColor = System.Drawing.Color.Black
        Me.Label140.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label140.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label140.ForeColor = System.Drawing.Color.White
        Me.Label140.Location = New System.Drawing.Point(815, 211)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(27, 26)
        Me.Label140.TabIndex = 616
        Me.Label140.Text = "°"
        Me.Label140.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label139
        '
        Me.Label139.BackColor = System.Drawing.Color.Black
        Me.Label139.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label139.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label139.ForeColor = System.Drawing.Color.White
        Me.Label139.Location = New System.Drawing.Point(918, 211)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(27, 51)
        Me.Label139.TabIndex = 615
        Me.Label139.Text = "s"
        Me.Label139.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclFwdTicTime
        '
        Me.srclbValReclFwdTicTime.BackColor = System.Drawing.Color.Black
        Me.srclbValReclFwdTicTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclFwdTicTime.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclFwdTicTime.ForeColor = System.Drawing.Color.White
        Me.srclbValReclFwdTicTime.Location = New System.Drawing.Point(842, 211)
        Me.srclbValReclFwdTicTime.Name = "srclbValReclFwdTicTime"
        Me.srclbValReclFwdTicTime.Size = New System.Drawing.Size(76, 51)
        Me.srclbValReclFwdTicTime.TabIndex = 614
        Me.srclbValReclFwdTicTime.Text = "23.5"
        Me.srclbValReclFwdTicTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclFwdEndAngle
        '
        Me.srclbValReclFwdEndAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValReclFwdEndAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclFwdEndAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclFwdEndAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValReclFwdEndAngle.Location = New System.Drawing.Point(729, 237)
        Me.srclbValReclFwdEndAngle.Name = "srclbValReclFwdEndAngle"
        Me.srclbValReclFwdEndAngle.Size = New System.Drawing.Size(86, 26)
        Me.srclbValReclFwdEndAngle.TabIndex = 613
        Me.srclbValReclFwdEndAngle.Text = "45.5"
        Me.srclbValReclFwdEndAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclFwdStartAngle
        '
        Me.srclbValReclFwdStartAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValReclFwdStartAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclFwdStartAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclFwdStartAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValReclFwdStartAngle.Location = New System.Drawing.Point(729, 211)
        Me.srclbValReclFwdStartAngle.Name = "srclbValReclFwdStartAngle"
        Me.srclbValReclFwdStartAngle.Size = New System.Drawing.Size(86, 26)
        Me.srclbValReclFwdStartAngle.TabIndex = 612
        Me.srclbValReclFwdStartAngle.Text = "23.5"
        Me.srclbValReclFwdStartAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label132
        '
        Me.Label132.BackColor = System.Drawing.Color.Black
        Me.Label132.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label132.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label132.ForeColor = System.Drawing.Color.White
        Me.Label132.Location = New System.Drawing.Point(665, 237)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(64, 26)
        Me.Label132.TabIndex = 611
        Me.Label132.Text = "종료각"
        Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Black
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(665, 211)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 26)
        Me.Label17.TabIndex = 610
        Me.Label17.Text = "시작각"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclBwdSpeed
        '
        Me.srclbValReclBwdSpeed.BackColor = System.Drawing.Color.Black
        Me.srclbValReclBwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclBwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclBwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbValReclBwdSpeed.Location = New System.Drawing.Point(1677, 189)
        Me.srclbValReclBwdSpeed.Name = "srclbValReclBwdSpeed"
        Me.srclbValReclBwdSpeed.Size = New System.Drawing.Size(123, 22)
        Me.srclbValReclBwdSpeed.TabIndex = 609
        Me.srclbValReclBwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label126
        '
        Me.Label126.BackColor = System.Drawing.Color.Black
        Me.Label126.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label126.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label126.ForeColor = System.Drawing.Color.White
        Me.Label126.Location = New System.Drawing.Point(1800, 167)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(40, 44)
        Me.Label126.TabIndex = 608
        Me.Label126.Text = "°/s"
        Me.Label126.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecReclBwdSpeed
        '
        Me.srclbDecReclBwdSpeed.BackColor = System.Drawing.Color.Blue
        Me.srclbDecReclBwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecReclBwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecReclBwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbDecReclBwdSpeed.Location = New System.Drawing.Point(1840, 167)
        Me.srclbDecReclBwdSpeed.Name = "srclbDecReclBwdSpeed"
        Me.srclbDecReclBwdSpeed.Size = New System.Drawing.Size(53, 44)
        Me.srclbDecReclBwdSpeed.TabIndex = 607
        Me.srclbDecReclBwdSpeed.Text = "OK"
        Me.srclbDecReclBwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecReclBwdSpeed
        '
        Me.srclbSpecReclBwdSpeed.BackColor = System.Drawing.Color.Black
        Me.srclbSpecReclBwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecReclBwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecReclBwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbSpecReclBwdSpeed.Location = New System.Drawing.Point(1677, 167)
        Me.srclbSpecReclBwdSpeed.Name = "srclbSpecReclBwdSpeed"
        Me.srclbSpecReclBwdSpeed.Size = New System.Drawing.Size(123, 22)
        Me.srclbSpecReclBwdSpeed.TabIndex = 606
        Me.srclbSpecReclBwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclFwdSpeed
        '
        Me.srclbValReclFwdSpeed.BackColor = System.Drawing.Color.Black
        Me.srclbValReclFwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclFwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclFwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbValReclFwdSpeed.Location = New System.Drawing.Point(729, 189)
        Me.srclbValReclFwdSpeed.Name = "srclbValReclFwdSpeed"
        Me.srclbValReclFwdSpeed.Size = New System.Drawing.Size(123, 22)
        Me.srclbValReclFwdSpeed.TabIndex = 604
        Me.srclbValReclFwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label112
        '
        Me.Label112.BackColor = System.Drawing.Color.Black
        Me.Label112.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label112.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.ForeColor = System.Drawing.Color.White
        Me.Label112.Location = New System.Drawing.Point(852, 167)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(40, 44)
        Me.Label112.TabIndex = 603
        Me.Label112.Text = "°/s"
        Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecReclFwdSpeed
        '
        Me.srclbDecReclFwdSpeed.BackColor = System.Drawing.Color.Blue
        Me.srclbDecReclFwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecReclFwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecReclFwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbDecReclFwdSpeed.Location = New System.Drawing.Point(892, 167)
        Me.srclbDecReclFwdSpeed.Name = "srclbDecReclFwdSpeed"
        Me.srclbDecReclFwdSpeed.Size = New System.Drawing.Size(53, 44)
        Me.srclbDecReclFwdSpeed.TabIndex = 602
        Me.srclbDecReclFwdSpeed.Text = "OK"
        Me.srclbDecReclFwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecReclFwdSpeed
        '
        Me.srclbSpecReclFwdSpeed.BackColor = System.Drawing.Color.Black
        Me.srclbSpecReclFwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecReclFwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecReclFwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbSpecReclFwdSpeed.Location = New System.Drawing.Point(729, 167)
        Me.srclbSpecReclFwdSpeed.Name = "srclbSpecReclFwdSpeed"
        Me.srclbSpecReclFwdSpeed.Size = New System.Drawing.Size(123, 22)
        Me.srclbSpecReclFwdSpeed.TabIndex = 601
        Me.srclbSpecReclFwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label122
        '
        Me.Label122.BackColor = System.Drawing.Color.Black
        Me.Label122.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label122.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label122.ForeColor = System.Drawing.Color.White
        Me.Label122.Location = New System.Drawing.Point(665, 167)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(64, 44)
        Me.Label122.TabIndex = 600
        Me.Label122.Text = "속도"
        Me.Label122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcGraphReclBAmp
        '
        Me.srcGraphReclBAmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphReclBAmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphReclBAmp.Location = New System.Drawing.Point(1282, 35)
        Me.srcGraphReclBAmp.Name = "srcGraphReclBAmp"
        Me.srcGraphReclBAmp.Size = New System.Drawing.Size(331, 271)
        Me.srcGraphReclBAmp.TabIndex = 596
        '
        'srcGraphReclBNoise
        '
        Me.srcGraphReclBNoise.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphReclBNoise.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphReclBNoise.Location = New System.Drawing.Point(951, 35)
        Me.srcGraphReclBNoise.Name = "srcGraphReclBNoise"
        Me.srcGraphReclBNoise.Size = New System.Drawing.Size(331, 271)
        Me.srcGraphReclBNoise.TabIndex = 595
        '
        'srcGraphReclFAmp
        '
        Me.srcGraphReclFAmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphReclFAmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphReclFAmp.Location = New System.Drawing.Point(334, 35)
        Me.srcGraphReclFAmp.Name = "srcGraphReclFAmp"
        Me.srcGraphReclFAmp.Size = New System.Drawing.Size(331, 271)
        Me.srcGraphReclFAmp.TabIndex = 594
        '
        'srcGraphReclFNoise
        '
        Me.srcGraphReclFNoise.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphReclFNoise.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphReclFNoise.Location = New System.Drawing.Point(3, 35)
        Me.srcGraphReclFNoise.Name = "srcGraphReclFNoise"
        Me.srcGraphReclFNoise.Size = New System.Drawing.Size(331, 271)
        Me.srcGraphReclFNoise.TabIndex = 593
        '
        'srclbValReclEndAngle
        '
        Me.srclbValReclEndAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValReclEndAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclEndAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclEndAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValReclEndAngle.Location = New System.Drawing.Point(729, 284)
        Me.srclbValReclEndAngle.Name = "srclbValReclEndAngle"
        Me.srclbValReclEndAngle.Size = New System.Drawing.Size(123, 22)
        Me.srclbValReclEndAngle.TabIndex = 578
        Me.srclbValReclEndAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1613, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 29)
        Me.Label1.TabIndex = 592
        Me.Label1.Text = "리클 후진 검사 정보"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclBwdAngle
        '
        Me.srclbValReclBwdAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValReclBwdAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclBwdAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclBwdAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValReclBwdAngle.Location = New System.Drawing.Point(1677, 145)
        Me.srclbValReclBwdAngle.Name = "srclbValReclBwdAngle"
        Me.srclbValReclBwdAngle.Size = New System.Drawing.Size(123, 22)
        Me.srclbValReclBwdAngle.TabIndex = 591
        Me.srclbValReclBwdAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(852, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 44)
        Me.Label5.TabIndex = 577
        Me.Label5.Text = "°"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Black
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(1800, 123)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(40, 44)
        Me.Label38.TabIndex = 590
        Me.Label38.Text = "°"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecReclBwdAngle
        '
        Me.srclbDecReclBwdAngle.BackColor = System.Drawing.Color.Blue
        Me.srclbDecReclBwdAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecReclBwdAngle.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecReclBwdAngle.ForeColor = System.Drawing.Color.White
        Me.srclbDecReclBwdAngle.Location = New System.Drawing.Point(1840, 123)
        Me.srclbDecReclBwdAngle.Name = "srclbDecReclBwdAngle"
        Me.srclbDecReclBwdAngle.Size = New System.Drawing.Size(53, 44)
        Me.srclbDecReclBwdAngle.TabIndex = 589
        Me.srclbDecReclBwdAngle.Text = "OK"
        Me.srclbDecReclBwdAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecReclBwdAngle
        '
        Me.srclbSpecReclBwdAngle.BackColor = System.Drawing.Color.Black
        Me.srclbSpecReclBwdAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecReclBwdAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecReclBwdAngle.ForeColor = System.Drawing.Color.White
        Me.srclbSpecReclBwdAngle.Location = New System.Drawing.Point(1677, 123)
        Me.srclbSpecReclBwdAngle.Name = "srclbSpecReclBwdAngle"
        Me.srclbSpecReclBwdAngle.Size = New System.Drawing.Size(123, 22)
        Me.srclbSpecReclBwdAngle.TabIndex = 588
        Me.srclbSpecReclBwdAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecReclEndAngle
        '
        Me.srclbDecReclEndAngle.BackColor = System.Drawing.Color.Blue
        Me.srclbDecReclEndAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecReclEndAngle.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecReclEndAngle.ForeColor = System.Drawing.Color.White
        Me.srclbDecReclEndAngle.Location = New System.Drawing.Point(892, 262)
        Me.srclbDecReclEndAngle.Name = "srclbDecReclEndAngle"
        Me.srclbDecReclEndAngle.Size = New System.Drawing.Size(53, 44)
        Me.srclbDecReclEndAngle.TabIndex = 576
        Me.srclbDecReclEndAngle.Text = "OK"
        Me.srclbDecReclEndAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclBwdAmp
        '
        Me.srclbValReclBwdAmp.BackColor = System.Drawing.Color.Black
        Me.srclbValReclBwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclBwdAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclBwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbValReclBwdAmp.Location = New System.Drawing.Point(1677, 101)
        Me.srclbValReclBwdAmp.Name = "srclbValReclBwdAmp"
        Me.srclbValReclBwdAmp.Size = New System.Drawing.Size(123, 22)
        Me.srclbValReclBwdAmp.TabIndex = 586
        Me.srclbValReclBwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Black
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.White
        Me.Label55.Location = New System.Drawing.Point(1800, 79)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(40, 44)
        Me.Label55.TabIndex = 585
        Me.Label55.Text = "A"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecReclBwdAmp
        '
        Me.srclbDecReclBwdAmp.BackColor = System.Drawing.Color.Blue
        Me.srclbDecReclBwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecReclBwdAmp.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecReclBwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDecReclBwdAmp.Location = New System.Drawing.Point(1840, 79)
        Me.srclbDecReclBwdAmp.Name = "srclbDecReclBwdAmp"
        Me.srclbDecReclBwdAmp.Size = New System.Drawing.Size(53, 44)
        Me.srclbDecReclBwdAmp.TabIndex = 584
        Me.srclbDecReclBwdAmp.Text = "OK"
        Me.srclbDecReclBwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecReclBwdAmp
        '
        Me.srclbSpecReclBwdAmp.BackColor = System.Drawing.Color.Black
        Me.srclbSpecReclBwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecReclBwdAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecReclBwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbSpecReclBwdAmp.Location = New System.Drawing.Point(1677, 79)
        Me.srclbSpecReclBwdAmp.Name = "srclbSpecReclBwdAmp"
        Me.srclbSpecReclBwdAmp.Size = New System.Drawing.Size(123, 22)
        Me.srclbSpecReclBwdAmp.TabIndex = 583
        Me.srclbSpecReclBwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclBwdNoise
        '
        Me.srclbValReclBwdNoise.BackColor = System.Drawing.Color.Black
        Me.srclbValReclBwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclBwdNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclBwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbValReclBwdNoise.Location = New System.Drawing.Point(1677, 57)
        Me.srclbValReclBwdNoise.Name = "srclbValReclBwdNoise"
        Me.srclbValReclBwdNoise.Size = New System.Drawing.Size(123, 22)
        Me.srclbValReclBwdNoise.TabIndex = 581
        Me.srclbValReclBwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecReclEndAngle
        '
        Me.srclbSpecReclEndAngle.BackColor = System.Drawing.Color.Black
        Me.srclbSpecReclEndAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecReclEndAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecReclEndAngle.ForeColor = System.Drawing.Color.White
        Me.srclbSpecReclEndAngle.Location = New System.Drawing.Point(729, 262)
        Me.srclbSpecReclEndAngle.Name = "srclbSpecReclEndAngle"
        Me.srclbSpecReclEndAngle.Size = New System.Drawing.Size(123, 22)
        Me.srclbSpecReclEndAngle.TabIndex = 575
        Me.srclbSpecReclEndAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label84
        '
        Me.Label84.BackColor = System.Drawing.Color.Black
        Me.Label84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label84.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.White
        Me.Label84.Location = New System.Drawing.Point(1800, 35)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(40, 44)
        Me.Label84.TabIndex = 580
        Me.Label84.Text = "dB"
        Me.Label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecReclBwdNoise
        '
        Me.srclbDecReclBwdNoise.BackColor = System.Drawing.Color.Blue
        Me.srclbDecReclBwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecReclBwdNoise.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecReclBwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbDecReclBwdNoise.Location = New System.Drawing.Point(1840, 35)
        Me.srclbDecReclBwdNoise.Name = "srclbDecReclBwdNoise"
        Me.srclbDecReclBwdNoise.Size = New System.Drawing.Size(53, 44)
        Me.srclbDecReclBwdNoise.TabIndex = 579
        Me.srclbDecReclBwdNoise.Text = "OK"
        Me.srclbDecReclBwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecReclBwdNoise
        '
        Me.srclbSpecReclBwdNoise.BackColor = System.Drawing.Color.Black
        Me.srclbSpecReclBwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecReclBwdNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecReclBwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbSpecReclBwdNoise.Location = New System.Drawing.Point(1677, 35)
        Me.srclbSpecReclBwdNoise.Name = "srclbSpecReclBwdNoise"
        Me.srclbSpecReclBwdNoise.Size = New System.Drawing.Size(123, 22)
        Me.srclbSpecReclBwdNoise.TabIndex = 578
        Me.srclbSpecReclBwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Black
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(665, 262)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(64, 44)
        Me.Label33.TabIndex = 574
        Me.Label33.Text = "출하각"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(1282, 6)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(331, 29)
        Me.Label29.TabIndex = 576
        Me.Label29.Text = "리클 후진 전류 그래프"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(951, 6)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(331, 29)
        Me.Label28.TabIndex = 573
        Me.Label28.Text = "리클 후진 소음 그래프"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Black
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(665, 6)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(280, 29)
        Me.Label23.TabIndex = 546
        Me.Label23.Text = "리클 전진 검사 정보"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(334, 6)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(331, 29)
        Me.Label22.TabIndex = 545
        Me.Label22.Text = "리클 전진 전류 그래프"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclFwdAngle
        '
        Me.srclbValReclFwdAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValReclFwdAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclFwdAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclFwdAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValReclFwdAngle.Location = New System.Drawing.Point(729, 145)
        Me.srclbValReclFwdAngle.Name = "srclbValReclFwdAngle"
        Me.srclbValReclFwdAngle.Size = New System.Drawing.Size(123, 22)
        Me.srclbValReclFwdAngle.TabIndex = 536
        Me.srclbValReclFwdAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label79
        '
        Me.Label79.BackColor = System.Drawing.Color.Black
        Me.Label79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label79.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.White
        Me.Label79.Location = New System.Drawing.Point(852, 123)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(40, 44)
        Me.Label79.TabIndex = 535
        Me.Label79.Text = "°"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecReclFwdAngle
        '
        Me.srclbDecReclFwdAngle.BackColor = System.Drawing.Color.Blue
        Me.srclbDecReclFwdAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecReclFwdAngle.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecReclFwdAngle.ForeColor = System.Drawing.Color.White
        Me.srclbDecReclFwdAngle.Location = New System.Drawing.Point(892, 123)
        Me.srclbDecReclFwdAngle.Name = "srclbDecReclFwdAngle"
        Me.srclbDecReclFwdAngle.Size = New System.Drawing.Size(53, 44)
        Me.srclbDecReclFwdAngle.TabIndex = 534
        Me.srclbDecReclFwdAngle.Text = "OK"
        Me.srclbDecReclFwdAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecReclFwdAngle
        '
        Me.srclbSpecReclFwdAngle.BackColor = System.Drawing.Color.Black
        Me.srclbSpecReclFwdAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecReclFwdAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecReclFwdAngle.ForeColor = System.Drawing.Color.White
        Me.srclbSpecReclFwdAngle.Location = New System.Drawing.Point(729, 123)
        Me.srclbSpecReclFwdAngle.Name = "srclbSpecReclFwdAngle"
        Me.srclbSpecReclFwdAngle.Size = New System.Drawing.Size(123, 22)
        Me.srclbSpecReclFwdAngle.TabIndex = 533
        Me.srclbSpecReclFwdAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label83
        '
        Me.Label83.BackColor = System.Drawing.Color.Black
        Me.Label83.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label83.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.ForeColor = System.Drawing.Color.White
        Me.Label83.Location = New System.Drawing.Point(665, 123)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(64, 44)
        Me.Label83.TabIndex = 531
        Me.Label83.Text = "각도"
        Me.Label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclFwdAmp
        '
        Me.srclbValReclFwdAmp.BackColor = System.Drawing.Color.Black
        Me.srclbValReclFwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclFwdAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclFwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbValReclFwdAmp.Location = New System.Drawing.Point(729, 101)
        Me.srclbValReclFwdAmp.Name = "srclbValReclFwdAmp"
        Me.srclbValReclFwdAmp.Size = New System.Drawing.Size(123, 22)
        Me.srclbValReclFwdAmp.TabIndex = 528
        Me.srclbValReclFwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label71
        '
        Me.Label71.BackColor = System.Drawing.Color.Black
        Me.Label71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label71.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.White
        Me.Label71.Location = New System.Drawing.Point(852, 79)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(40, 44)
        Me.Label71.TabIndex = 527
        Me.Label71.Text = "A"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecReclFwdAmp
        '
        Me.srclbDecReclFwdAmp.BackColor = System.Drawing.Color.Blue
        Me.srclbDecReclFwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecReclFwdAmp.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecReclFwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDecReclFwdAmp.Location = New System.Drawing.Point(892, 79)
        Me.srclbDecReclFwdAmp.Name = "srclbDecReclFwdAmp"
        Me.srclbDecReclFwdAmp.Size = New System.Drawing.Size(53, 44)
        Me.srclbDecReclFwdAmp.TabIndex = 526
        Me.srclbDecReclFwdAmp.Text = "OK"
        Me.srclbDecReclFwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecReclFwdAmp
        '
        Me.srclbSpecReclFwdAmp.BackColor = System.Drawing.Color.Black
        Me.srclbSpecReclFwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecReclFwdAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecReclFwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbSpecReclFwdAmp.Location = New System.Drawing.Point(729, 79)
        Me.srclbSpecReclFwdAmp.Name = "srclbSpecReclFwdAmp"
        Me.srclbSpecReclFwdAmp.Size = New System.Drawing.Size(123, 22)
        Me.srclbSpecReclFwdAmp.TabIndex = 525
        Me.srclbSpecReclFwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.Black
        Me.Label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label75.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.White
        Me.Label75.Location = New System.Drawing.Point(665, 79)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(64, 44)
        Me.Label75.TabIndex = 523
        Me.Label75.Text = "전류"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValReclFwdNoise
        '
        Me.srclbValReclFwdNoise.BackColor = System.Drawing.Color.Black
        Me.srclbValReclFwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValReclFwdNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValReclFwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbValReclFwdNoise.Location = New System.Drawing.Point(729, 57)
        Me.srclbValReclFwdNoise.Name = "srclbValReclFwdNoise"
        Me.srclbValReclFwdNoise.Size = New System.Drawing.Size(123, 22)
        Me.srclbValReclFwdNoise.TabIndex = 520
        Me.srclbValReclFwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.Color.Black
        Me.Label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label69.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.ForeColor = System.Drawing.Color.White
        Me.Label69.Location = New System.Drawing.Point(852, 35)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(40, 44)
        Me.Label69.TabIndex = 519
        Me.Label69.Text = "dB"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecReclFwdNoise
        '
        Me.srclbDecReclFwdNoise.BackColor = System.Drawing.Color.Blue
        Me.srclbDecReclFwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecReclFwdNoise.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecReclFwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbDecReclFwdNoise.Location = New System.Drawing.Point(892, 35)
        Me.srclbDecReclFwdNoise.Name = "srclbDecReclFwdNoise"
        Me.srclbDecReclFwdNoise.Size = New System.Drawing.Size(53, 44)
        Me.srclbDecReclFwdNoise.TabIndex = 518
        Me.srclbDecReclFwdNoise.Text = "OK"
        Me.srclbDecReclFwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecReclFwdNoise
        '
        Me.srclbSpecReclFwdNoise.BackColor = System.Drawing.Color.Black
        Me.srclbSpecReclFwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecReclFwdNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecReclFwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbSpecReclFwdNoise.Location = New System.Drawing.Point(729, 35)
        Me.srclbSpecReclFwdNoise.Name = "srclbSpecReclFwdNoise"
        Me.srclbSpecReclFwdNoise.Size = New System.Drawing.Size(123, 22)
        Me.srclbSpecReclFwdNoise.TabIndex = 516
        Me.srclbSpecReclFwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(665, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 44)
        Me.Label2.TabIndex = 512
        Me.Label2.Text = "소음"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label120
        '
        Me.Label120.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label120.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label120.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label120.ForeColor = System.Drawing.Color.White
        Me.Label120.Location = New System.Drawing.Point(3, 6)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(331, 29)
        Me.Label120.TabIndex = 21
        Me.Label120.Text = "리클 전진 소음 그래프"
        Me.Label120.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Button4)
        Me.Panel5.Controls.Add(Me.Button3)
        Me.Panel5.Controls.Add(Me.Button2)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.Label103)
        Me.Panel5.Controls.Add(Me.Label109)
        Me.Panel5.Controls.Add(Me.Label116)
        Me.Panel5.Controls.Add(Me.Label121)
        Me.Panel5.Controls.Add(Me.Label124)
        Me.Panel5.Controls.Add(Me.Label165)
        Me.Panel5.Controls.Add(Me.Label167)
        Me.Panel5.Controls.Add(Me.Label169)
        Me.Panel5.Controls.Add(Me.srclbValFrestBwdTicTime)
        Me.Panel5.Controls.Add(Me.srclbValFrestBwdEndAngle)
        Me.Panel5.Controls.Add(Me.srclbValFrestBwdStartAngle)
        Me.Panel5.Controls.Add(Me.Label157)
        Me.Panel5.Controls.Add(Me.Label158)
        Me.Panel5.Controls.Add(Me.Label159)
        Me.Panel5.Controls.Add(Me.srclbValFrestFwdTicTime)
        Me.Panel5.Controls.Add(Me.srclbValFrestFwdEndAngle)
        Me.Panel5.Controls.Add(Me.srclbValFrestFwdStartAngle)
        Me.Panel5.Controls.Add(Me.Label163)
        Me.Panel5.Controls.Add(Me.Label164)
        Me.Panel5.Controls.Add(Me.srclbValFrestBwdSpeed)
        Me.Panel5.Controls.Add(Me.Label148)
        Me.Panel5.Controls.Add(Me.srclbDecFrestBwdSpeed)
        Me.Panel5.Controls.Add(Me.srclbSpecFrestBwdSpeed)
        Me.Panel5.Controls.Add(Me.srclbValFrestFwdSpeed)
        Me.Panel5.Controls.Add(Me.Label143)
        Me.Panel5.Controls.Add(Me.srclbDecFrestFwdSpeed)
        Me.Panel5.Controls.Add(Me.srclbSpecFrestFwdSpeed)
        Me.Panel5.Controls.Add(Me.Label146)
        Me.Panel5.Controls.Add(Me.srcGraphFrestBAmp)
        Me.Panel5.Controls.Add(Me.srcGraphFrestBNoise)
        Me.Panel5.Controls.Add(Me.srcGraphFrestFAmp)
        Me.Panel5.Controls.Add(Me.srcGraphFrestFNoise)
        Me.Panel5.Controls.Add(Me.Label114)
        Me.Panel5.Controls.Add(Me.Label115)
        Me.Panel5.Controls.Add(Me.Label82)
        Me.Panel5.Controls.Add(Me.srclbValFrestBwdAmp)
        Me.Panel5.Controls.Add(Me.Label99)
        Me.Panel5.Controls.Add(Me.srclbDecFrestBwdAmp)
        Me.Panel5.Controls.Add(Me.srclbSpecFrestBwdAmp)
        Me.Panel5.Controls.Add(Me.srclbValFrestBwdNoise)
        Me.Panel5.Controls.Add(Me.Label106)
        Me.Panel5.Controls.Add(Me.srclbDecFrestBwdNoise)
        Me.Panel5.Controls.Add(Me.srclbSpecFrestBwdNoise)
        Me.Panel5.Controls.Add(Me.Label117)
        Me.Panel5.Controls.Add(Me.Label118)
        Me.Panel5.Controls.Add(Me.srclbValFrestFwdAmp)
        Me.Panel5.Controls.Add(Me.Label127)
        Me.Panel5.Controls.Add(Me.srclbDecFrestFwdAmp)
        Me.Panel5.Controls.Add(Me.srclbSpecFrestFwdAmp)
        Me.Panel5.Controls.Add(Me.Label130)
        Me.Panel5.Controls.Add(Me.srclbValFrestFwdNoise)
        Me.Panel5.Controls.Add(Me.Label133)
        Me.Panel5.Controls.Add(Me.srclbDecFrestFwdNoise)
        Me.Panel5.Controls.Add(Me.srclbSpecFrestFwdNoise)
        Me.Panel5.Controls.Add(Me.Label136)
        Me.Panel5.Controls.Add(Me.Label138)
        Me.Panel5.Location = New System.Drawing.Point(3, 422)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1912, 313)
        Me.Panel5.TabIndex = 256
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(827, 246)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(54, 33)
        Me.Button4.TabIndex = 642
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(773, 246)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(54, 33)
        Me.Button3.TabIndex = 641
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(719, 246)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(54, 33)
        Me.Button2.TabIndex = 640
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(665, 246)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(54, 33)
        Me.Button1.TabIndex = 639
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label103
        '
        Me.Label103.BackColor = System.Drawing.Color.Black
        Me.Label103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label103.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label103.ForeColor = System.Drawing.Color.White
        Me.Label103.Location = New System.Drawing.Point(1613, 217)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(64, 26)
        Me.Label103.TabIndex = 638
        Me.Label103.Text = "종료각"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label109
        '
        Me.Label109.BackColor = System.Drawing.Color.Black
        Me.Label109.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label109.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label109.ForeColor = System.Drawing.Color.White
        Me.Label109.Location = New System.Drawing.Point(1613, 191)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(64, 26)
        Me.Label109.TabIndex = 637
        Me.Label109.Text = "시작각"
        Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label116
        '
        Me.Label116.BackColor = System.Drawing.Color.Black
        Me.Label116.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label116.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label116.ForeColor = System.Drawing.Color.White
        Me.Label116.Location = New System.Drawing.Point(1613, 139)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(64, 52)
        Me.Label116.TabIndex = 636
        Me.Label116.Text = "속도"
        Me.Label116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label121
        '
        Me.Label121.BackColor = System.Drawing.Color.Black
        Me.Label121.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label121.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label121.ForeColor = System.Drawing.Color.White
        Me.Label121.Location = New System.Drawing.Point(1613, 87)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(64, 52)
        Me.Label121.TabIndex = 635
        Me.Label121.Text = "전류"
        Me.Label121.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label124
        '
        Me.Label124.BackColor = System.Drawing.Color.Black
        Me.Label124.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label124.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label124.ForeColor = System.Drawing.Color.White
        Me.Label124.Location = New System.Drawing.Point(1613, 35)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(64, 52)
        Me.Label124.TabIndex = 634
        Me.Label124.Text = "소음"
        Me.Label124.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label165
        '
        Me.Label165.BackColor = System.Drawing.Color.Black
        Me.Label165.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label165.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label165.ForeColor = System.Drawing.Color.White
        Me.Label165.Location = New System.Drawing.Point(1763, 217)
        Me.Label165.Name = "Label165"
        Me.Label165.Size = New System.Drawing.Size(27, 26)
        Me.Label165.TabIndex = 633
        Me.Label165.Text = "°"
        Me.Label165.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label167
        '
        Me.Label167.BackColor = System.Drawing.Color.Black
        Me.Label167.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label167.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label167.ForeColor = System.Drawing.Color.White
        Me.Label167.Location = New System.Drawing.Point(1763, 191)
        Me.Label167.Name = "Label167"
        Me.Label167.Size = New System.Drawing.Size(27, 26)
        Me.Label167.TabIndex = 632
        Me.Label167.Text = "°"
        Me.Label167.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label169
        '
        Me.Label169.BackColor = System.Drawing.Color.Black
        Me.Label169.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label169.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label169.ForeColor = System.Drawing.Color.White
        Me.Label169.Location = New System.Drawing.Point(1866, 191)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(27, 51)
        Me.Label169.TabIndex = 631
        Me.Label169.Text = "s"
        Me.Label169.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestBwdTicTime
        '
        Me.srclbValFrestBwdTicTime.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestBwdTicTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestBwdTicTime.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestBwdTicTime.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestBwdTicTime.Location = New System.Drawing.Point(1790, 191)
        Me.srclbValFrestBwdTicTime.Name = "srclbValFrestBwdTicTime"
        Me.srclbValFrestBwdTicTime.Size = New System.Drawing.Size(76, 51)
        Me.srclbValFrestBwdTicTime.TabIndex = 630
        Me.srclbValFrestBwdTicTime.Text = "23.5"
        Me.srclbValFrestBwdTicTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestBwdEndAngle
        '
        Me.srclbValFrestBwdEndAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestBwdEndAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestBwdEndAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestBwdEndAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestBwdEndAngle.Location = New System.Drawing.Point(1677, 217)
        Me.srclbValFrestBwdEndAngle.Name = "srclbValFrestBwdEndAngle"
        Me.srclbValFrestBwdEndAngle.Size = New System.Drawing.Size(86, 26)
        Me.srclbValFrestBwdEndAngle.TabIndex = 629
        Me.srclbValFrestBwdEndAngle.Text = "45.5"
        Me.srclbValFrestBwdEndAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestBwdStartAngle
        '
        Me.srclbValFrestBwdStartAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestBwdStartAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestBwdStartAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestBwdStartAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestBwdStartAngle.Location = New System.Drawing.Point(1677, 191)
        Me.srclbValFrestBwdStartAngle.Name = "srclbValFrestBwdStartAngle"
        Me.srclbValFrestBwdStartAngle.Size = New System.Drawing.Size(86, 26)
        Me.srclbValFrestBwdStartAngle.TabIndex = 628
        Me.srclbValFrestBwdStartAngle.Text = "23.5"
        Me.srclbValFrestBwdStartAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label157
        '
        Me.Label157.BackColor = System.Drawing.Color.Black
        Me.Label157.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label157.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label157.ForeColor = System.Drawing.Color.White
        Me.Label157.Location = New System.Drawing.Point(815, 217)
        Me.Label157.Name = "Label157"
        Me.Label157.Size = New System.Drawing.Size(27, 26)
        Me.Label157.TabIndex = 625
        Me.Label157.Text = "°"
        Me.Label157.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label158
        '
        Me.Label158.BackColor = System.Drawing.Color.Black
        Me.Label158.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label158.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label158.ForeColor = System.Drawing.Color.White
        Me.Label158.Location = New System.Drawing.Point(815, 191)
        Me.Label158.Name = "Label158"
        Me.Label158.Size = New System.Drawing.Size(27, 26)
        Me.Label158.TabIndex = 624
        Me.Label158.Text = "°"
        Me.Label158.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label159
        '
        Me.Label159.BackColor = System.Drawing.Color.Black
        Me.Label159.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label159.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label159.ForeColor = System.Drawing.Color.White
        Me.Label159.Location = New System.Drawing.Point(918, 191)
        Me.Label159.Name = "Label159"
        Me.Label159.Size = New System.Drawing.Size(27, 51)
        Me.Label159.TabIndex = 623
        Me.Label159.Text = "s"
        Me.Label159.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestFwdTicTime
        '
        Me.srclbValFrestFwdTicTime.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestFwdTicTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestFwdTicTime.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestFwdTicTime.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestFwdTicTime.Location = New System.Drawing.Point(842, 191)
        Me.srclbValFrestFwdTicTime.Name = "srclbValFrestFwdTicTime"
        Me.srclbValFrestFwdTicTime.Size = New System.Drawing.Size(76, 51)
        Me.srclbValFrestFwdTicTime.TabIndex = 622
        Me.srclbValFrestFwdTicTime.Text = "23.5"
        Me.srclbValFrestFwdTicTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestFwdEndAngle
        '
        Me.srclbValFrestFwdEndAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestFwdEndAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestFwdEndAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestFwdEndAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestFwdEndAngle.Location = New System.Drawing.Point(729, 217)
        Me.srclbValFrestFwdEndAngle.Name = "srclbValFrestFwdEndAngle"
        Me.srclbValFrestFwdEndAngle.Size = New System.Drawing.Size(86, 26)
        Me.srclbValFrestFwdEndAngle.TabIndex = 621
        Me.srclbValFrestFwdEndAngle.Text = "45.5"
        Me.srclbValFrestFwdEndAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestFwdStartAngle
        '
        Me.srclbValFrestFwdStartAngle.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestFwdStartAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestFwdStartAngle.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestFwdStartAngle.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestFwdStartAngle.Location = New System.Drawing.Point(729, 191)
        Me.srclbValFrestFwdStartAngle.Name = "srclbValFrestFwdStartAngle"
        Me.srclbValFrestFwdStartAngle.Size = New System.Drawing.Size(86, 26)
        Me.srclbValFrestFwdStartAngle.TabIndex = 620
        Me.srclbValFrestFwdStartAngle.Text = "23.5"
        Me.srclbValFrestFwdStartAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label163
        '
        Me.Label163.BackColor = System.Drawing.Color.Black
        Me.Label163.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label163.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label163.ForeColor = System.Drawing.Color.White
        Me.Label163.Location = New System.Drawing.Point(665, 217)
        Me.Label163.Name = "Label163"
        Me.Label163.Size = New System.Drawing.Size(64, 26)
        Me.Label163.TabIndex = 619
        Me.Label163.Text = "종료각"
        Me.Label163.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label164
        '
        Me.Label164.BackColor = System.Drawing.Color.Black
        Me.Label164.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label164.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label164.ForeColor = System.Drawing.Color.White
        Me.Label164.Location = New System.Drawing.Point(665, 191)
        Me.Label164.Name = "Label164"
        Me.Label164.Size = New System.Drawing.Size(64, 26)
        Me.Label164.TabIndex = 618
        Me.Label164.Text = "시작각"
        Me.Label164.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestBwdSpeed
        '
        Me.srclbValFrestBwdSpeed.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestBwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestBwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestBwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestBwdSpeed.Location = New System.Drawing.Point(1677, 165)
        Me.srclbValFrestBwdSpeed.Name = "srclbValFrestBwdSpeed"
        Me.srclbValFrestBwdSpeed.Size = New System.Drawing.Size(123, 26)
        Me.srclbValFrestBwdSpeed.TabIndex = 608
        Me.srclbValFrestBwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label148
        '
        Me.Label148.BackColor = System.Drawing.Color.Black
        Me.Label148.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label148.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label148.ForeColor = System.Drawing.Color.White
        Me.Label148.Location = New System.Drawing.Point(1800, 139)
        Me.Label148.Name = "Label148"
        Me.Label148.Size = New System.Drawing.Size(40, 52)
        Me.Label148.TabIndex = 607
        Me.Label148.Text = "°"
        Me.Label148.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecFrestBwdSpeed
        '
        Me.srclbDecFrestBwdSpeed.BackColor = System.Drawing.Color.Blue
        Me.srclbDecFrestBwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecFrestBwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecFrestBwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbDecFrestBwdSpeed.Location = New System.Drawing.Point(1840, 139)
        Me.srclbDecFrestBwdSpeed.Name = "srclbDecFrestBwdSpeed"
        Me.srclbDecFrestBwdSpeed.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecFrestBwdSpeed.TabIndex = 606
        Me.srclbDecFrestBwdSpeed.Text = "OK"
        Me.srclbDecFrestBwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecFrestBwdSpeed
        '
        Me.srclbSpecFrestBwdSpeed.BackColor = System.Drawing.Color.Black
        Me.srclbSpecFrestBwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecFrestBwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecFrestBwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbSpecFrestBwdSpeed.Location = New System.Drawing.Point(1677, 139)
        Me.srclbSpecFrestBwdSpeed.Name = "srclbSpecFrestBwdSpeed"
        Me.srclbSpecFrestBwdSpeed.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecFrestBwdSpeed.TabIndex = 605
        Me.srclbSpecFrestBwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestFwdSpeed
        '
        Me.srclbValFrestFwdSpeed.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestFwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestFwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestFwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestFwdSpeed.Location = New System.Drawing.Point(729, 165)
        Me.srclbValFrestFwdSpeed.Name = "srclbValFrestFwdSpeed"
        Me.srclbValFrestFwdSpeed.Size = New System.Drawing.Size(123, 26)
        Me.srclbValFrestFwdSpeed.TabIndex = 603
        Me.srclbValFrestFwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label143
        '
        Me.Label143.BackColor = System.Drawing.Color.Black
        Me.Label143.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label143.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label143.ForeColor = System.Drawing.Color.White
        Me.Label143.Location = New System.Drawing.Point(852, 139)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(40, 52)
        Me.Label143.TabIndex = 602
        Me.Label143.Text = "°"
        Me.Label143.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecFrestFwdSpeed
        '
        Me.srclbDecFrestFwdSpeed.BackColor = System.Drawing.Color.Blue
        Me.srclbDecFrestFwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecFrestFwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecFrestFwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbDecFrestFwdSpeed.Location = New System.Drawing.Point(892, 139)
        Me.srclbDecFrestFwdSpeed.Name = "srclbDecFrestFwdSpeed"
        Me.srclbDecFrestFwdSpeed.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecFrestFwdSpeed.TabIndex = 601
        Me.srclbDecFrestFwdSpeed.Text = "OK"
        Me.srclbDecFrestFwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecFrestFwdSpeed
        '
        Me.srclbSpecFrestFwdSpeed.BackColor = System.Drawing.Color.Black
        Me.srclbSpecFrestFwdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecFrestFwdSpeed.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecFrestFwdSpeed.ForeColor = System.Drawing.Color.White
        Me.srclbSpecFrestFwdSpeed.Location = New System.Drawing.Point(729, 139)
        Me.srclbSpecFrestFwdSpeed.Name = "srclbSpecFrestFwdSpeed"
        Me.srclbSpecFrestFwdSpeed.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecFrestFwdSpeed.TabIndex = 600
        Me.srclbSpecFrestFwdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label146
        '
        Me.Label146.BackColor = System.Drawing.Color.Black
        Me.Label146.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label146.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label146.ForeColor = System.Drawing.Color.White
        Me.Label146.Location = New System.Drawing.Point(665, 139)
        Me.Label146.Name = "Label146"
        Me.Label146.Size = New System.Drawing.Size(64, 52)
        Me.Label146.TabIndex = 599
        Me.Label146.Text = "속도"
        Me.Label146.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcGraphFrestBAmp
        '
        Me.srcGraphFrestBAmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphFrestBAmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphFrestBAmp.Location = New System.Drawing.Point(1282, 35)
        Me.srcGraphFrestBAmp.Name = "srcGraphFrestBAmp"
        Me.srcGraphFrestBAmp.Size = New System.Drawing.Size(331, 271)
        Me.srcGraphFrestBAmp.TabIndex = 598
        '
        'srcGraphFrestBNoise
        '
        Me.srcGraphFrestBNoise.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphFrestBNoise.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphFrestBNoise.Location = New System.Drawing.Point(951, 35)
        Me.srcGraphFrestBNoise.Name = "srcGraphFrestBNoise"
        Me.srcGraphFrestBNoise.Size = New System.Drawing.Size(331, 271)
        Me.srcGraphFrestBNoise.TabIndex = 597
        '
        'srcGraphFrestFAmp
        '
        Me.srcGraphFrestFAmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphFrestFAmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphFrestFAmp.Location = New System.Drawing.Point(334, 35)
        Me.srcGraphFrestFAmp.Name = "srcGraphFrestFAmp"
        Me.srcGraphFrestFAmp.Size = New System.Drawing.Size(331, 271)
        Me.srcGraphFrestFAmp.TabIndex = 596
        '
        'srcGraphFrestFNoise
        '
        Me.srcGraphFrestFNoise.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphFrestFNoise.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphFrestFNoise.Location = New System.Drawing.Point(3, 35)
        Me.srcGraphFrestFNoise.Name = "srcGraphFrestFNoise"
        Me.srcGraphFrestFNoise.Size = New System.Drawing.Size(331, 271)
        Me.srcGraphFrestFNoise.TabIndex = 595
        '
        'Label114
        '
        Me.Label114.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label114.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label114.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.ForeColor = System.Drawing.Color.White
        Me.Label114.Location = New System.Drawing.Point(1282, 6)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(331, 29)
        Me.Label114.TabIndex = 576
        Me.Label114.Text = "풋레스트 후진 전류 그래프"
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label115
        '
        Me.Label115.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label115.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label115.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label115.ForeColor = System.Drawing.Color.White
        Me.Label115.Location = New System.Drawing.Point(951, 6)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(331, 29)
        Me.Label115.TabIndex = 573
        Me.Label115.Text = "풋레스트 후진 소음 그래프"
        Me.Label115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.Color.Black
        Me.Label82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label82.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.White
        Me.Label82.Location = New System.Drawing.Point(1613, 6)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(280, 29)
        Me.Label82.TabIndex = 572
        Me.Label82.Text = "풋레스트 후진 검사 정보"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestBwdAmp
        '
        Me.srclbValFrestBwdAmp.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestBwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestBwdAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestBwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestBwdAmp.Location = New System.Drawing.Point(1677, 113)
        Me.srclbValFrestBwdAmp.Name = "srclbValFrestBwdAmp"
        Me.srclbValFrestBwdAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbValFrestBwdAmp.TabIndex = 565
        Me.srclbValFrestBwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label99
        '
        Me.Label99.BackColor = System.Drawing.Color.Black
        Me.Label99.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label99.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.ForeColor = System.Drawing.Color.White
        Me.Label99.Location = New System.Drawing.Point(1800, 87)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(40, 52)
        Me.Label99.TabIndex = 564
        Me.Label99.Text = "A"
        Me.Label99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecFrestBwdAmp
        '
        Me.srclbDecFrestBwdAmp.BackColor = System.Drawing.Color.Blue
        Me.srclbDecFrestBwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecFrestBwdAmp.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecFrestBwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDecFrestBwdAmp.Location = New System.Drawing.Point(1840, 87)
        Me.srclbDecFrestBwdAmp.Name = "srclbDecFrestBwdAmp"
        Me.srclbDecFrestBwdAmp.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecFrestBwdAmp.TabIndex = 563
        Me.srclbDecFrestBwdAmp.Text = "OK"
        Me.srclbDecFrestBwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecFrestBwdAmp
        '
        Me.srclbSpecFrestBwdAmp.BackColor = System.Drawing.Color.Black
        Me.srclbSpecFrestBwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecFrestBwdAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecFrestBwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbSpecFrestBwdAmp.Location = New System.Drawing.Point(1677, 87)
        Me.srclbSpecFrestBwdAmp.Name = "srclbSpecFrestBwdAmp"
        Me.srclbSpecFrestBwdAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecFrestBwdAmp.TabIndex = 562
        Me.srclbSpecFrestBwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestBwdNoise
        '
        Me.srclbValFrestBwdNoise.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestBwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestBwdNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestBwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestBwdNoise.Location = New System.Drawing.Point(1677, 61)
        Me.srclbValFrestBwdNoise.Name = "srclbValFrestBwdNoise"
        Me.srclbValFrestBwdNoise.Size = New System.Drawing.Size(123, 26)
        Me.srclbValFrestBwdNoise.TabIndex = 559
        Me.srclbValFrestBwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label106
        '
        Me.Label106.BackColor = System.Drawing.Color.Black
        Me.Label106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label106.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.ForeColor = System.Drawing.Color.White
        Me.Label106.Location = New System.Drawing.Point(1800, 35)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(40, 52)
        Me.Label106.TabIndex = 558
        Me.Label106.Text = "dB"
        Me.Label106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecFrestBwdNoise
        '
        Me.srclbDecFrestBwdNoise.BackColor = System.Drawing.Color.Blue
        Me.srclbDecFrestBwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecFrestBwdNoise.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecFrestBwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbDecFrestBwdNoise.Location = New System.Drawing.Point(1840, 35)
        Me.srclbDecFrestBwdNoise.Name = "srclbDecFrestBwdNoise"
        Me.srclbDecFrestBwdNoise.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecFrestBwdNoise.TabIndex = 557
        Me.srclbDecFrestBwdNoise.Text = "OK"
        Me.srclbDecFrestBwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecFrestBwdNoise
        '
        Me.srclbSpecFrestBwdNoise.BackColor = System.Drawing.Color.Black
        Me.srclbSpecFrestBwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecFrestBwdNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecFrestBwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbSpecFrestBwdNoise.Location = New System.Drawing.Point(1677, 35)
        Me.srclbSpecFrestBwdNoise.Name = "srclbSpecFrestBwdNoise"
        Me.srclbSpecFrestBwdNoise.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecFrestBwdNoise.TabIndex = 556
        Me.srclbSpecFrestBwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label117
        '
        Me.Label117.BackColor = System.Drawing.Color.Black
        Me.Label117.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label117.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label117.ForeColor = System.Drawing.Color.White
        Me.Label117.Location = New System.Drawing.Point(665, 6)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(280, 29)
        Me.Label117.TabIndex = 546
        Me.Label117.Text = "풋레스트 전진 검사 정보"
        Me.Label117.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label118
        '
        Me.Label118.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label118.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label118.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label118.ForeColor = System.Drawing.Color.White
        Me.Label118.Location = New System.Drawing.Point(334, 6)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(331, 29)
        Me.Label118.TabIndex = 545
        Me.Label118.Text = "풋레스트 전진 전류 그래프"
        Me.Label118.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestFwdAmp
        '
        Me.srclbValFrestFwdAmp.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestFwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestFwdAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestFwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestFwdAmp.Location = New System.Drawing.Point(729, 113)
        Me.srclbValFrestFwdAmp.Name = "srclbValFrestFwdAmp"
        Me.srclbValFrestFwdAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbValFrestFwdAmp.TabIndex = 528
        Me.srclbValFrestFwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label127
        '
        Me.Label127.BackColor = System.Drawing.Color.Black
        Me.Label127.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label127.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label127.ForeColor = System.Drawing.Color.White
        Me.Label127.Location = New System.Drawing.Point(852, 87)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(40, 52)
        Me.Label127.TabIndex = 527
        Me.Label127.Text = "A"
        Me.Label127.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecFrestFwdAmp
        '
        Me.srclbDecFrestFwdAmp.BackColor = System.Drawing.Color.Blue
        Me.srclbDecFrestFwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecFrestFwdAmp.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecFrestFwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDecFrestFwdAmp.Location = New System.Drawing.Point(892, 87)
        Me.srclbDecFrestFwdAmp.Name = "srclbDecFrestFwdAmp"
        Me.srclbDecFrestFwdAmp.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecFrestFwdAmp.TabIndex = 526
        Me.srclbDecFrestFwdAmp.Text = "OK"
        Me.srclbDecFrestFwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecFrestFwdAmp
        '
        Me.srclbSpecFrestFwdAmp.BackColor = System.Drawing.Color.Black
        Me.srclbSpecFrestFwdAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecFrestFwdAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecFrestFwdAmp.ForeColor = System.Drawing.Color.White
        Me.srclbSpecFrestFwdAmp.Location = New System.Drawing.Point(729, 87)
        Me.srclbSpecFrestFwdAmp.Name = "srclbSpecFrestFwdAmp"
        Me.srclbSpecFrestFwdAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecFrestFwdAmp.TabIndex = 525
        Me.srclbSpecFrestFwdAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label130
        '
        Me.Label130.BackColor = System.Drawing.Color.Black
        Me.Label130.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label130.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label130.ForeColor = System.Drawing.Color.White
        Me.Label130.Location = New System.Drawing.Point(665, 87)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(64, 52)
        Me.Label130.TabIndex = 523
        Me.Label130.Text = "전류"
        Me.Label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbValFrestFwdNoise
        '
        Me.srclbValFrestFwdNoise.BackColor = System.Drawing.Color.Black
        Me.srclbValFrestFwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbValFrestFwdNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbValFrestFwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbValFrestFwdNoise.Location = New System.Drawing.Point(729, 61)
        Me.srclbValFrestFwdNoise.Name = "srclbValFrestFwdNoise"
        Me.srclbValFrestFwdNoise.Size = New System.Drawing.Size(123, 26)
        Me.srclbValFrestFwdNoise.TabIndex = 520
        Me.srclbValFrestFwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label133
        '
        Me.Label133.BackColor = System.Drawing.Color.Black
        Me.Label133.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label133.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label133.ForeColor = System.Drawing.Color.White
        Me.Label133.Location = New System.Drawing.Point(852, 35)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(40, 52)
        Me.Label133.TabIndex = 519
        Me.Label133.Text = "dB"
        Me.Label133.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecFrestFwdNoise
        '
        Me.srclbDecFrestFwdNoise.BackColor = System.Drawing.Color.Blue
        Me.srclbDecFrestFwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecFrestFwdNoise.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecFrestFwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbDecFrestFwdNoise.Location = New System.Drawing.Point(892, 35)
        Me.srclbDecFrestFwdNoise.Name = "srclbDecFrestFwdNoise"
        Me.srclbDecFrestFwdNoise.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecFrestFwdNoise.TabIndex = 518
        Me.srclbDecFrestFwdNoise.Text = "OK"
        Me.srclbDecFrestFwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecFrestFwdNoise
        '
        Me.srclbSpecFrestFwdNoise.BackColor = System.Drawing.Color.Black
        Me.srclbSpecFrestFwdNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecFrestFwdNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecFrestFwdNoise.ForeColor = System.Drawing.Color.White
        Me.srclbSpecFrestFwdNoise.Location = New System.Drawing.Point(729, 35)
        Me.srclbSpecFrestFwdNoise.Name = "srclbSpecFrestFwdNoise"
        Me.srclbSpecFrestFwdNoise.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecFrestFwdNoise.TabIndex = 516
        Me.srclbSpecFrestFwdNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label136
        '
        Me.Label136.BackColor = System.Drawing.Color.Black
        Me.Label136.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label136.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label136.ForeColor = System.Drawing.Color.White
        Me.Label136.Location = New System.Drawing.Point(665, 35)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(64, 52)
        Me.Label136.TabIndex = 512
        Me.Label136.Text = "소음"
        Me.Label136.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label138
        '
        Me.Label138.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label138.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label138.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label138.ForeColor = System.Drawing.Color.White
        Me.Label138.Location = New System.Drawing.Point(3, 6)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(331, 29)
        Me.Label138.TabIndex = 21
        Me.Label138.Text = "풋레스트 전진 소음 그래프"
        Me.Label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTotalDecision
        '
        Me.srclbTotalDecision.BackColor = System.Drawing.Color.Blue
        Me.srclbTotalDecision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTotalDecision.Font = New System.Drawing.Font("Arial Narrow", 48.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTotalDecision.ForeColor = System.Drawing.Color.White
        Me.srclbTotalDecision.Location = New System.Drawing.Point(1559, 34)
        Me.srclbTotalDecision.Name = "srclbTotalDecision"
        Me.srclbTotalDecision.Size = New System.Drawing.Size(358, 75)
        Me.srclbTotalDecision.TabIndex = 580
        Me.srclbTotalDecision.Text = "OK"
        Me.srclbTotalDecision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label128)
        Me.Panel7.Controls.Add(Me.Label129)
        Me.Panel7.Controls.Add(Me.Label131)
        Me.Panel7.Controls.Add(Me.srcGraphBolsterAmp)
        Me.Panel7.Controls.Add(Me.srcGraphBolsterNoise)
        Me.Panel7.Controls.Add(Me.Label62)
        Me.Panel7.Controls.Add(Me.Label104)
        Me.Panel7.Controls.Add(Me.Label166)
        Me.Panel7.Controls.Add(Me.srclbDataBolsterDefAmp)
        Me.Panel7.Controls.Add(Me.Label168)
        Me.Panel7.Controls.Add(Me.srclbDecBolsterDefAmp)
        Me.Panel7.Controls.Add(Me.srclbSpecBolsterDefAmp)
        Me.Panel7.Controls.Add(Me.Label177)
        Me.Panel7.Controls.Add(Me.srclbDataBolsterInfAmp)
        Me.Panel7.Controls.Add(Me.Label179)
        Me.Panel7.Controls.Add(Me.srclbDecBolsterInfAmp)
        Me.Panel7.Controls.Add(Me.srclbSpecBolsterInfAmp)
        Me.Panel7.Controls.Add(Me.srclbDataBolsterInfNoise)
        Me.Panel7.Controls.Add(Me.Label184)
        Me.Panel7.Controls.Add(Me.srclbDecBolsterInfNoise)
        Me.Panel7.Controls.Add(Me.srclbSpecBolsterInfNoise)
        Me.Panel7.Controls.Add(Me.Label61)
        Me.Panel7.Controls.Add(Me.srclbDataLsuptDefAmp)
        Me.Panel7.Controls.Add(Me.Label142)
        Me.Panel7.Controls.Add(Me.srclbDecLsuptDefAmp)
        Me.Panel7.Controls.Add(Me.srclbSpecLsuptDefAmp)
        Me.Panel7.Controls.Add(Me.Label147)
        Me.Panel7.Controls.Add(Me.srcGraphLsuptAmp)
        Me.Panel7.Controls.Add(Me.srcGraphLsuptNoise)
        Me.Panel7.Controls.Add(Me.Label76)
        Me.Panel7.Controls.Add(Me.srclbDataLsuptMidAmp)
        Me.Panel7.Controls.Add(Me.Label110)
        Me.Panel7.Controls.Add(Me.srclbDecLsuptMidAmp)
        Me.Panel7.Controls.Add(Me.srclbSpecLsuptMidAmp)
        Me.Panel7.Controls.Add(Me.Label113)
        Me.Panel7.Controls.Add(Me.srclbDataLsuptMidNoise)
        Me.Panel7.Controls.Add(Me.Label119)
        Me.Panel7.Controls.Add(Me.srclbDecLsuptMidNoise)
        Me.Panel7.Controls.Add(Me.srclbSpecLsuptMidNoise)
        Me.Panel7.Controls.Add(Me.Label123)
        Me.Panel7.Controls.Add(Me.Label125)
        Me.Panel7.Controls.Add(Me.Label141)
        Me.Panel7.Location = New System.Drawing.Point(4, 735)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1912, 227)
        Me.Panel7.TabIndex = 581
        '
        'Label128
        '
        Me.Label128.BackColor = System.Drawing.Color.Black
        Me.Label128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label128.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label128.ForeColor = System.Drawing.Color.White
        Me.Label128.Location = New System.Drawing.Point(1612, 168)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(64, 52)
        Me.Label128.TabIndex = 647
        Me.Label128.Text = "전류"
        Me.Label128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label129
        '
        Me.Label129.BackColor = System.Drawing.Color.Black
        Me.Label129.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label129.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label129.ForeColor = System.Drawing.Color.White
        Me.Label129.Location = New System.Drawing.Point(1612, 87)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(64, 52)
        Me.Label129.TabIndex = 646
        Me.Label129.Text = "전류"
        Me.Label129.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label131
        '
        Me.Label131.BackColor = System.Drawing.Color.Black
        Me.Label131.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label131.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label131.ForeColor = System.Drawing.Color.White
        Me.Label131.Location = New System.Drawing.Point(1612, 35)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(64, 52)
        Me.Label131.TabIndex = 645
        Me.Label131.Text = "소음"
        Me.Label131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcGraphBolsterAmp
        '
        Me.srcGraphBolsterAmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphBolsterAmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphBolsterAmp.Location = New System.Drawing.Point(1281, 35)
        Me.srcGraphBolsterAmp.Name = "srcGraphBolsterAmp"
        Me.srcGraphBolsterAmp.Size = New System.Drawing.Size(331, 185)
        Me.srcGraphBolsterAmp.TabIndex = 644
        '
        'srcGraphBolsterNoise
        '
        Me.srcGraphBolsterNoise.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphBolsterNoise.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphBolsterNoise.Location = New System.Drawing.Point(950, 35)
        Me.srcGraphBolsterNoise.Name = "srcGraphBolsterNoise"
        Me.srcGraphBolsterNoise.Size = New System.Drawing.Size(331, 185)
        Me.srcGraphBolsterNoise.TabIndex = 643
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label62.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.White
        Me.Label62.Location = New System.Drawing.Point(1281, 6)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(331, 29)
        Me.Label62.TabIndex = 642
        Me.Label62.Text = "볼스터 전류 그래프"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label104.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.White
        Me.Label104.Location = New System.Drawing.Point(950, 6)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(331, 29)
        Me.Label104.TabIndex = 641
        Me.Label104.Text = "볼스터 소음 그래프"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label166
        '
        Me.Label166.BackColor = System.Drawing.Color.Black
        Me.Label166.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label166.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label166.ForeColor = System.Drawing.Color.White
        Me.Label166.Location = New System.Drawing.Point(1612, 139)
        Me.Label166.Name = "Label166"
        Me.Label166.Size = New System.Drawing.Size(280, 29)
        Me.Label166.TabIndex = 640
        Me.Label166.Text = "볼스터 배기 검사 정보"
        Me.Label166.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataBolsterDefAmp
        '
        Me.srclbDataBolsterDefAmp.BackColor = System.Drawing.Color.Black
        Me.srclbDataBolsterDefAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataBolsterDefAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbDataBolsterDefAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDataBolsterDefAmp.Location = New System.Drawing.Point(1676, 194)
        Me.srclbDataBolsterDefAmp.Name = "srclbDataBolsterDefAmp"
        Me.srclbDataBolsterDefAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbDataBolsterDefAmp.TabIndex = 639
        Me.srclbDataBolsterDefAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label168
        '
        Me.Label168.BackColor = System.Drawing.Color.Black
        Me.Label168.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label168.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label168.ForeColor = System.Drawing.Color.White
        Me.Label168.Location = New System.Drawing.Point(1799, 168)
        Me.Label168.Name = "Label168"
        Me.Label168.Size = New System.Drawing.Size(40, 52)
        Me.Label168.TabIndex = 638
        Me.Label168.Text = "A"
        Me.Label168.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecBolsterDefAmp
        '
        Me.srclbDecBolsterDefAmp.BackColor = System.Drawing.Color.Blue
        Me.srclbDecBolsterDefAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecBolsterDefAmp.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecBolsterDefAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDecBolsterDefAmp.Location = New System.Drawing.Point(1839, 168)
        Me.srclbDecBolsterDefAmp.Name = "srclbDecBolsterDefAmp"
        Me.srclbDecBolsterDefAmp.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecBolsterDefAmp.TabIndex = 637
        Me.srclbDecBolsterDefAmp.Text = "OK"
        Me.srclbDecBolsterDefAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecBolsterDefAmp
        '
        Me.srclbSpecBolsterDefAmp.BackColor = System.Drawing.Color.Black
        Me.srclbSpecBolsterDefAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecBolsterDefAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecBolsterDefAmp.ForeColor = System.Drawing.Color.White
        Me.srclbSpecBolsterDefAmp.Location = New System.Drawing.Point(1676, 168)
        Me.srclbSpecBolsterDefAmp.Name = "srclbSpecBolsterDefAmp"
        Me.srclbSpecBolsterDefAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecBolsterDefAmp.TabIndex = 636
        Me.srclbSpecBolsterDefAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label177
        '
        Me.Label177.BackColor = System.Drawing.Color.Black
        Me.Label177.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label177.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label177.ForeColor = System.Drawing.Color.White
        Me.Label177.Location = New System.Drawing.Point(1612, 6)
        Me.Label177.Name = "Label177"
        Me.Label177.Size = New System.Drawing.Size(280, 29)
        Me.Label177.TabIndex = 629
        Me.Label177.Text = "볼스터 흡기 검사 정보"
        Me.Label177.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataBolsterInfAmp
        '
        Me.srclbDataBolsterInfAmp.BackColor = System.Drawing.Color.Black
        Me.srclbDataBolsterInfAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataBolsterInfAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbDataBolsterInfAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDataBolsterInfAmp.Location = New System.Drawing.Point(1676, 113)
        Me.srclbDataBolsterInfAmp.Name = "srclbDataBolsterInfAmp"
        Me.srclbDataBolsterInfAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbDataBolsterInfAmp.TabIndex = 628
        Me.srclbDataBolsterInfAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label179
        '
        Me.Label179.BackColor = System.Drawing.Color.Black
        Me.Label179.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label179.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label179.ForeColor = System.Drawing.Color.White
        Me.Label179.Location = New System.Drawing.Point(1799, 87)
        Me.Label179.Name = "Label179"
        Me.Label179.Size = New System.Drawing.Size(40, 52)
        Me.Label179.TabIndex = 627
        Me.Label179.Text = "A"
        Me.Label179.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecBolsterInfAmp
        '
        Me.srclbDecBolsterInfAmp.BackColor = System.Drawing.Color.Blue
        Me.srclbDecBolsterInfAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecBolsterInfAmp.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecBolsterInfAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDecBolsterInfAmp.Location = New System.Drawing.Point(1839, 87)
        Me.srclbDecBolsterInfAmp.Name = "srclbDecBolsterInfAmp"
        Me.srclbDecBolsterInfAmp.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecBolsterInfAmp.TabIndex = 626
        Me.srclbDecBolsterInfAmp.Text = "OK"
        Me.srclbDecBolsterInfAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecBolsterInfAmp
        '
        Me.srclbSpecBolsterInfAmp.BackColor = System.Drawing.Color.Black
        Me.srclbSpecBolsterInfAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecBolsterInfAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecBolsterInfAmp.ForeColor = System.Drawing.Color.White
        Me.srclbSpecBolsterInfAmp.Location = New System.Drawing.Point(1676, 87)
        Me.srclbSpecBolsterInfAmp.Name = "srclbSpecBolsterInfAmp"
        Me.srclbSpecBolsterInfAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecBolsterInfAmp.TabIndex = 625
        Me.srclbSpecBolsterInfAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataBolsterInfNoise
        '
        Me.srclbDataBolsterInfNoise.BackColor = System.Drawing.Color.Black
        Me.srclbDataBolsterInfNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataBolsterInfNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbDataBolsterInfNoise.ForeColor = System.Drawing.Color.White
        Me.srclbDataBolsterInfNoise.Location = New System.Drawing.Point(1676, 61)
        Me.srclbDataBolsterInfNoise.Name = "srclbDataBolsterInfNoise"
        Me.srclbDataBolsterInfNoise.Size = New System.Drawing.Size(123, 26)
        Me.srclbDataBolsterInfNoise.TabIndex = 623
        Me.srclbDataBolsterInfNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label184
        '
        Me.Label184.BackColor = System.Drawing.Color.Black
        Me.Label184.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label184.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label184.ForeColor = System.Drawing.Color.White
        Me.Label184.Location = New System.Drawing.Point(1799, 35)
        Me.Label184.Name = "Label184"
        Me.Label184.Size = New System.Drawing.Size(40, 52)
        Me.Label184.TabIndex = 622
        Me.Label184.Text = "dB"
        Me.Label184.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecBolsterInfNoise
        '
        Me.srclbDecBolsterInfNoise.BackColor = System.Drawing.Color.Blue
        Me.srclbDecBolsterInfNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecBolsterInfNoise.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecBolsterInfNoise.ForeColor = System.Drawing.Color.White
        Me.srclbDecBolsterInfNoise.Location = New System.Drawing.Point(1839, 35)
        Me.srclbDecBolsterInfNoise.Name = "srclbDecBolsterInfNoise"
        Me.srclbDecBolsterInfNoise.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecBolsterInfNoise.TabIndex = 621
        Me.srclbDecBolsterInfNoise.Text = "OK"
        Me.srclbDecBolsterInfNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecBolsterInfNoise
        '
        Me.srclbSpecBolsterInfNoise.BackColor = System.Drawing.Color.Black
        Me.srclbSpecBolsterInfNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecBolsterInfNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecBolsterInfNoise.ForeColor = System.Drawing.Color.White
        Me.srclbSpecBolsterInfNoise.Location = New System.Drawing.Point(1676, 35)
        Me.srclbSpecBolsterInfNoise.Name = "srclbSpecBolsterInfNoise"
        Me.srclbSpecBolsterInfNoise.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecBolsterInfNoise.TabIndex = 620
        Me.srclbSpecBolsterInfNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.Black
        Me.Label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label61.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(664, 139)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(280, 29)
        Me.Label61.TabIndex = 618
        Me.Label61.Text = "럼버서포트 배기 검사 정보"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataLsuptDefAmp
        '
        Me.srclbDataLsuptDefAmp.BackColor = System.Drawing.Color.Black
        Me.srclbDataLsuptDefAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataLsuptDefAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbDataLsuptDefAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDataLsuptDefAmp.Location = New System.Drawing.Point(728, 194)
        Me.srclbDataLsuptDefAmp.Name = "srclbDataLsuptDefAmp"
        Me.srclbDataLsuptDefAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbDataLsuptDefAmp.TabIndex = 617
        Me.srclbDataLsuptDefAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label142
        '
        Me.Label142.BackColor = System.Drawing.Color.Black
        Me.Label142.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label142.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label142.ForeColor = System.Drawing.Color.White
        Me.Label142.Location = New System.Drawing.Point(851, 168)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(40, 52)
        Me.Label142.TabIndex = 616
        Me.Label142.Text = "A"
        Me.Label142.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecLsuptDefAmp
        '
        Me.srclbDecLsuptDefAmp.BackColor = System.Drawing.Color.Blue
        Me.srclbDecLsuptDefAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecLsuptDefAmp.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecLsuptDefAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDecLsuptDefAmp.Location = New System.Drawing.Point(891, 168)
        Me.srclbDecLsuptDefAmp.Name = "srclbDecLsuptDefAmp"
        Me.srclbDecLsuptDefAmp.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecLsuptDefAmp.TabIndex = 615
        Me.srclbDecLsuptDefAmp.Text = "OK"
        Me.srclbDecLsuptDefAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecLsuptDefAmp
        '
        Me.srclbSpecLsuptDefAmp.BackColor = System.Drawing.Color.Black
        Me.srclbSpecLsuptDefAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecLsuptDefAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecLsuptDefAmp.ForeColor = System.Drawing.Color.White
        Me.srclbSpecLsuptDefAmp.Location = New System.Drawing.Point(728, 168)
        Me.srclbSpecLsuptDefAmp.Name = "srclbSpecLsuptDefAmp"
        Me.srclbSpecLsuptDefAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecLsuptDefAmp.TabIndex = 614
        Me.srclbSpecLsuptDefAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label147
        '
        Me.Label147.BackColor = System.Drawing.Color.Black
        Me.Label147.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label147.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label147.ForeColor = System.Drawing.Color.White
        Me.Label147.Location = New System.Drawing.Point(664, 168)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(64, 52)
        Me.Label147.TabIndex = 613
        Me.Label147.Text = "전류"
        Me.Label147.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcGraphLsuptAmp
        '
        Me.srcGraphLsuptAmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphLsuptAmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphLsuptAmp.Location = New System.Drawing.Point(334, 35)
        Me.srcGraphLsuptAmp.Name = "srcGraphLsuptAmp"
        Me.srcGraphLsuptAmp.Size = New System.Drawing.Size(331, 185)
        Me.srcGraphLsuptAmp.TabIndex = 596
        '
        'srcGraphLsuptNoise
        '
        Me.srcGraphLsuptNoise.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.srcGraphLsuptNoise.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.srcGraphLsuptNoise.Location = New System.Drawing.Point(3, 35)
        Me.srcGraphLsuptNoise.Name = "srcGraphLsuptNoise"
        Me.srcGraphLsuptNoise.Size = New System.Drawing.Size(331, 185)
        Me.srcGraphLsuptNoise.TabIndex = 595
        '
        'Label76
        '
        Me.Label76.BackColor = System.Drawing.Color.Black
        Me.Label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label76.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.White
        Me.Label76.Location = New System.Drawing.Point(664, 6)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(280, 29)
        Me.Label76.TabIndex = 572
        Me.Label76.Text = "럼버서포트 흡기 검사 정보"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataLsuptMidAmp
        '
        Me.srclbDataLsuptMidAmp.BackColor = System.Drawing.Color.Black
        Me.srclbDataLsuptMidAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataLsuptMidAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbDataLsuptMidAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDataLsuptMidAmp.Location = New System.Drawing.Point(728, 113)
        Me.srclbDataLsuptMidAmp.Name = "srclbDataLsuptMidAmp"
        Me.srclbDataLsuptMidAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbDataLsuptMidAmp.TabIndex = 565
        Me.srclbDataLsuptMidAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label110
        '
        Me.Label110.BackColor = System.Drawing.Color.Black
        Me.Label110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label110.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.ForeColor = System.Drawing.Color.White
        Me.Label110.Location = New System.Drawing.Point(851, 87)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(40, 52)
        Me.Label110.TabIndex = 564
        Me.Label110.Text = "A"
        Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecLsuptMidAmp
        '
        Me.srclbDecLsuptMidAmp.BackColor = System.Drawing.Color.Blue
        Me.srclbDecLsuptMidAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecLsuptMidAmp.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecLsuptMidAmp.ForeColor = System.Drawing.Color.White
        Me.srclbDecLsuptMidAmp.Location = New System.Drawing.Point(891, 87)
        Me.srclbDecLsuptMidAmp.Name = "srclbDecLsuptMidAmp"
        Me.srclbDecLsuptMidAmp.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecLsuptMidAmp.TabIndex = 563
        Me.srclbDecLsuptMidAmp.Text = "OK"
        Me.srclbDecLsuptMidAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecLsuptMidAmp
        '
        Me.srclbSpecLsuptMidAmp.BackColor = System.Drawing.Color.Black
        Me.srclbSpecLsuptMidAmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecLsuptMidAmp.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecLsuptMidAmp.ForeColor = System.Drawing.Color.White
        Me.srclbSpecLsuptMidAmp.Location = New System.Drawing.Point(728, 87)
        Me.srclbSpecLsuptMidAmp.Name = "srclbSpecLsuptMidAmp"
        Me.srclbSpecLsuptMidAmp.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecLsuptMidAmp.TabIndex = 562
        Me.srclbSpecLsuptMidAmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label113
        '
        Me.Label113.BackColor = System.Drawing.Color.Black
        Me.Label113.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label113.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label113.ForeColor = System.Drawing.Color.White
        Me.Label113.Location = New System.Drawing.Point(664, 87)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(64, 52)
        Me.Label113.TabIndex = 561
        Me.Label113.Text = "전류"
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataLsuptMidNoise
        '
        Me.srclbDataLsuptMidNoise.BackColor = System.Drawing.Color.Black
        Me.srclbDataLsuptMidNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataLsuptMidNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbDataLsuptMidNoise.ForeColor = System.Drawing.Color.White
        Me.srclbDataLsuptMidNoise.Location = New System.Drawing.Point(728, 61)
        Me.srclbDataLsuptMidNoise.Name = "srclbDataLsuptMidNoise"
        Me.srclbDataLsuptMidNoise.Size = New System.Drawing.Size(123, 26)
        Me.srclbDataLsuptMidNoise.TabIndex = 559
        Me.srclbDataLsuptMidNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label119
        '
        Me.Label119.BackColor = System.Drawing.Color.Black
        Me.Label119.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label119.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label119.ForeColor = System.Drawing.Color.White
        Me.Label119.Location = New System.Drawing.Point(851, 35)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(40, 52)
        Me.Label119.TabIndex = 558
        Me.Label119.Text = "dB"
        Me.Label119.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecLsuptMidNoise
        '
        Me.srclbDecLsuptMidNoise.BackColor = System.Drawing.Color.Blue
        Me.srclbDecLsuptMidNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecLsuptMidNoise.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecLsuptMidNoise.ForeColor = System.Drawing.Color.White
        Me.srclbDecLsuptMidNoise.Location = New System.Drawing.Point(891, 35)
        Me.srclbDecLsuptMidNoise.Name = "srclbDecLsuptMidNoise"
        Me.srclbDecLsuptMidNoise.Size = New System.Drawing.Size(53, 52)
        Me.srclbDecLsuptMidNoise.TabIndex = 557
        Me.srclbDecLsuptMidNoise.Text = "OK"
        Me.srclbDecLsuptMidNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbSpecLsuptMidNoise
        '
        Me.srclbSpecLsuptMidNoise.BackColor = System.Drawing.Color.Black
        Me.srclbSpecLsuptMidNoise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbSpecLsuptMidNoise.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbSpecLsuptMidNoise.ForeColor = System.Drawing.Color.White
        Me.srclbSpecLsuptMidNoise.Location = New System.Drawing.Point(728, 35)
        Me.srclbSpecLsuptMidNoise.Name = "srclbSpecLsuptMidNoise"
        Me.srclbSpecLsuptMidNoise.Size = New System.Drawing.Size(123, 26)
        Me.srclbSpecLsuptMidNoise.TabIndex = 556
        Me.srclbSpecLsuptMidNoise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label123
        '
        Me.Label123.BackColor = System.Drawing.Color.Black
        Me.Label123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label123.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Label123.ForeColor = System.Drawing.Color.White
        Me.Label123.Location = New System.Drawing.Point(664, 35)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(64, 52)
        Me.Label123.TabIndex = 555
        Me.Label123.Text = "소음"
        Me.Label123.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label125
        '
        Me.Label125.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label125.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label125.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label125.ForeColor = System.Drawing.Color.White
        Me.Label125.Location = New System.Drawing.Point(334, 6)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(331, 29)
        Me.Label125.TabIndex = 545
        Me.Label125.Text = "럼버서포트 전류 그래프"
        Me.Label125.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label141
        '
        Me.Label141.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label141.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label141.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label141.ForeColor = System.Drawing.Color.White
        Me.Label141.Location = New System.Drawing.Point(3, 6)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(331, 29)
        Me.Label141.TabIndex = 21
        Me.Label141.Text = "럼버서포트 소음 그래프"
        Me.Label141.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tmr_Connect
        '
        '
        'srclbType
        '
        Me.srclbType.BackColor = System.Drawing.Color.Black
        Me.srclbType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbType.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.srclbType.ForeColor = System.Drawing.Color.White
        Me.srclbType.Location = New System.Drawing.Point(1389, 78)
        Me.srclbType.Name = "srclbType"
        Me.srclbType.Size = New System.Drawing.Size(170, 31)
        Me.srclbType.TabIndex = 582
        Me.srclbType.Text = "PART NO."
        Me.srclbType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tmr_Can
        '
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(1818, 42)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(89, 31)
        Me.Button6.TabIndex = 245
        Me.Button6.Text = "Cush 배기 RH"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1920, 1061)
        Me.Controls.Add(Me.srclbType)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.srclbTotalDecision)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.srcLbPartName)
        Me.Controls.Add(Me.srcLbSerial)
        Me.Controls.Add(Me.srcLbPartNo)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel8.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TmrWork As System.Windows.Forms.Timer
    Friend WithEvents SerialScanner As System.IO.Ports.SerialPort
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents P_OUT_07 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_06 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_05 As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_04 As System.Windows.Forms.Label
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_03 As System.Windows.Forms.Label
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_02 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_01 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_00 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents P_IN_15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents P_IN_14 As System.Windows.Forms.Label
    Friend WithEvents P_IN_13 As System.Windows.Forms.Label
    Friend WithEvents P_IN_12 As System.Windows.Forms.Label
    Friend WithEvents P_IN_11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents P_IN_10 As System.Windows.Forms.Label
    Friend WithEvents P_IN_09 As System.Windows.Forms.Label
    Friend WithEvents P_IN_08 As System.Windows.Forms.Label
    Friend WithEvents P_IN_07 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents P_IN_06 As System.Windows.Forms.Label
    Friend WithEvents P_IN_05 As System.Windows.Forms.Label
    Friend WithEvents P_IN_04 As System.Windows.Forms.Label
    Friend WithEvents P_IN_03 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents P_IN_02 As System.Windows.Forms.Label
    Friend WithEvents P_IN_01 As System.Windows.Forms.Label
    Friend WithEvents P_IN_00 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_13 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_12 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_11 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_10 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_09 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents P_OUT_08 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents TmrIO As System.Windows.Forms.Timer

    Friend WithEvents Label39 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label21 As Label
    Private WithEvents InstantDoCtrl1 As Automation.BDaq.InstantDoCtrl
    Private WithEvents InstantDiCtrl1 As Automation.BDaq.InstantDiCtrl
    Friend WithEvents Panel_FWD_AMP_SPEC As System.Windows.Forms.Label
    Friend WithEvents Panel_LSUPT_FWD_AMP As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SerialPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BasicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VitualKeyboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents srcLbSerial As System.Windows.Forms.Label
    Friend WithEvents srcLbPartName As System.Windows.Forms.Label
    Friend WithEvents srcLbPartNo As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents SerialPrinter As System.IO.Ports.SerialPort
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents srclbSpecReclFwdNoise As System.Windows.Forms.Label
    Friend WithEvents srclbDecReclFwdNoise As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents srclbValReclFwdNoise As System.Windows.Forms.Label
    Friend WithEvents srclbValReclFwdAngle As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents srclbDecReclFwdAngle As System.Windows.Forms.Label
    Friend WithEvents srclbSpecReclFwdAngle As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents srclbValReclFwdAmp As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents srclbDecReclFwdAmp As System.Windows.Forms.Label
    Friend WithEvents srclbSpecReclFwdAmp As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestBwdAmp As System.Windows.Forms.Label
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents srclbDecFrestBwdAmp As System.Windows.Forms.Label
    Friend WithEvents srclbSpecFrestBwdAmp As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestBwdNoise As System.Windows.Forms.Label
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents srclbDecFrestBwdNoise As System.Windows.Forms.Label
    Friend WithEvents srclbSpecFrestBwdNoise As System.Windows.Forms.Label
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestFwdAmp As System.Windows.Forms.Label
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents srclbDecFrestFwdAmp As System.Windows.Forms.Label
    Friend WithEvents srclbSpecFrestFwdAmp As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestFwdNoise As System.Windows.Forms.Label
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents srclbDecFrestFwdNoise As System.Windows.Forms.Label
    Friend WithEvents srclbSpecFrestFwdNoise As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents srcLaser1 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents srcNoise As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lbRequestCount2 As System.Windows.Forms.Label
    Friend WithEvents lbRequestCount1 As System.Windows.Forms.Label
    Friend WithEvents lbRequestStep2 As System.Windows.Forms.Label
    Friend WithEvents lbRequestStep1 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents LbSupply4Volt As System.Windows.Forms.Label
    Friend WithEvents LbSupply3Volt As System.Windows.Forms.Label
    Friend WithEvents LbSupply2Volt As System.Windows.Forms.Label
    Friend WithEvents LbSupply1Volt As System.Windows.Forms.Label
    Friend WithEvents LbSupply4Amp As System.Windows.Forms.Label
    Friend WithEvents LbSupply3Amp As System.Windows.Forms.Label
    Friend WithEvents LbSupply2Amp As System.Windows.Forms.Label
    Friend WithEvents LbSupply1Amp As System.Windows.Forms.Label
    Friend WithEvents Serial_Supply1 As System.IO.Ports.SerialPort
    Friend WithEvents Serial_Supply2 As System.IO.Ports.SerialPort
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents srcScannerInput As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents srcStep1 As System.Windows.Forms.Label
    Friend WithEvents srclbValReclEndAngle As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents srclbDecReclEndAngle As System.Windows.Forms.Label
    Friend WithEvents srclbSpecReclEndAngle As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents srclbValReclBwdAngle As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents srclbDecReclBwdAngle As System.Windows.Forms.Label
    Friend WithEvents srclbSpecReclBwdAngle As System.Windows.Forms.Label
    Friend WithEvents srclbValReclBwdAmp As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents srclbDecReclBwdAmp As System.Windows.Forms.Label
    Friend WithEvents srclbSpecReclBwdAmp As System.Windows.Forms.Label
    Friend WithEvents srclbValReclBwdNoise As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents srclbDecReclBwdNoise As System.Windows.Forms.Label
    Friend WithEvents srclbSpecReclBwdNoise As System.Windows.Forms.Label
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents srcGraphReclFAmp As ZedGraph.ZedGraphControl
    Friend WithEvents srcGraphReclFNoise As ZedGraph.ZedGraphControl
    Friend WithEvents srcGraphFrestFAmp As ZedGraph.ZedGraphControl
    Friend WithEvents srcGraphFrestFNoise As ZedGraph.ZedGraphControl
    Friend WithEvents srcGraphFrestBAmp As ZedGraph.ZedGraphControl
    Friend WithEvents srcGraphFrestBNoise As ZedGraph.ZedGraphControl
    Friend WithEvents srclbTotalDecision As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents srcLaser2 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents srcGraphReclBNoise As ZedGraph.ZedGraphControl
    Friend WithEvents srcGraphReclBAmp As ZedGraph.ZedGraphControl
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents srcGraphLsuptAmp As ZedGraph.ZedGraphControl
    Friend WithEvents srcGraphLsuptNoise As ZedGraph.ZedGraphControl
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents srclbDataLsuptMidAmp As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents srclbDecLsuptMidAmp As System.Windows.Forms.Label
    Friend WithEvents srclbSpecLsuptMidAmp As System.Windows.Forms.Label
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents srclbDataLsuptMidNoise As System.Windows.Forms.Label
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents srclbDecLsuptMidNoise As System.Windows.Forms.Label
    Friend WithEvents srclbSpecLsuptMidNoise As System.Windows.Forms.Label
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents Label125 As System.Windows.Forms.Label
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents Tmr_Connect As System.Windows.Forms.Timer
    Friend WithEvents srcLbPlcConnectionState As System.Windows.Forms.Label
    Friend WithEvents lbD4050 As System.Windows.Forms.Label
    Friend WithEvents lbD4001 As System.Windows.Forms.Label
    Friend WithEvents lbD4000 As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestFwdSpeed As System.Windows.Forms.Label
    Friend WithEvents Label143 As System.Windows.Forms.Label
    Friend WithEvents srclbDecFrestFwdSpeed As System.Windows.Forms.Label
    Friend WithEvents srclbSpecFrestFwdSpeed As System.Windows.Forms.Label
    Friend WithEvents Label146 As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestBwdSpeed As System.Windows.Forms.Label
    Friend WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents srclbDecFrestBwdSpeed As System.Windows.Forms.Label
    Friend WithEvents srclbSpecFrestBwdSpeed As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents srclbDataLsuptDefAmp As System.Windows.Forms.Label
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents srclbDecLsuptDefAmp As System.Windows.Forms.Label
    Friend WithEvents srclbSpecLsuptDefAmp As System.Windows.Forms.Label
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents Label166 As System.Windows.Forms.Label
    Friend WithEvents srclbDataBolsterDefAmp As System.Windows.Forms.Label
    Friend WithEvents Label168 As System.Windows.Forms.Label
    Friend WithEvents srclbDecBolsterDefAmp As System.Windows.Forms.Label
    Friend WithEvents srclbSpecBolsterDefAmp As System.Windows.Forms.Label
    Friend WithEvents Label177 As System.Windows.Forms.Label
    Friend WithEvents srclbDataBolsterInfAmp As System.Windows.Forms.Label
    Friend WithEvents Label179 As System.Windows.Forms.Label
    Friend WithEvents srclbDecBolsterInfAmp As System.Windows.Forms.Label
    Friend WithEvents srclbSpecBolsterInfAmp As System.Windows.Forms.Label
    Friend WithEvents srclbDataBolsterInfNoise As System.Windows.Forms.Label
    Friend WithEvents Label184 As System.Windows.Forms.Label
    Friend WithEvents srclbDecBolsterInfNoise As System.Windows.Forms.Label
    Friend WithEvents srclbSpecBolsterInfNoise As System.Windows.Forms.Label
    Friend WithEvents srcGraphBolsterAmp As ZedGraph.ZedGraphControl
    Friend WithEvents srcGraphBolsterNoise As ZedGraph.ZedGraphControl
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents srclbValReclFwdSpeed As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents srclbDecReclFwdSpeed As System.Windows.Forms.Label
    Friend WithEvents srclbSpecReclFwdSpeed As System.Windows.Forms.Label
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents srclbValReclBwdSpeed As System.Windows.Forms.Label
    Friend WithEvents Label126 As System.Windows.Forms.Label
    Friend WithEvents srclbDecReclBwdSpeed As System.Windows.Forms.Label
    Friend WithEvents srclbSpecReclBwdSpeed As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents srclbValReclFwdEndAngle As System.Windows.Forms.Label
    Friend WithEvents srclbValReclFwdStartAngle As System.Windows.Forms.Label
    Friend WithEvents srclbValReclFwdTicTime As System.Windows.Forms.Label
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents Label149 As System.Windows.Forms.Label
    Friend WithEvents Label150 As System.Windows.Forms.Label
    Friend WithEvents srclbValReclBwdTicTime As System.Windows.Forms.Label
    Friend WithEvents srclbValReclBwdEndAngle As System.Windows.Forms.Label
    Friend WithEvents srclbValReclBwdStartAngle As System.Windows.Forms.Label
    Friend WithEvents Label165 As System.Windows.Forms.Label
    Friend WithEvents Label167 As System.Windows.Forms.Label
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestBwdTicTime As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestBwdEndAngle As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestBwdStartAngle As System.Windows.Forms.Label
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Friend WithEvents Label158 As System.Windows.Forms.Label
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestFwdTicTime As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestFwdEndAngle As System.Windows.Forms.Label
    Friend WithEvents srclbValFrestFwdStartAngle As System.Windows.Forms.Label
    Friend WithEvents Label163 As System.Windows.Forms.Label
    Friend WithEvents Label164 As System.Windows.Forms.Label
    Friend WithEvents srclbType As System.Windows.Forms.Label
    Friend WithEvents srcLaser2Angle As System.Windows.Forms.Label
    Friend WithEvents srcLaser1Angle As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents SerialCan As System.IO.Ports.SerialPort
    Friend WithEvents Tmr_Can As System.Windows.Forms.Timer
    Friend WithEvents lbCanConnection As System.Windows.Forms.Label
    Friend WithEvents LbCan As System.Windows.Forms.Label
    Friend WithEvents lbCanStep As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
End Class
