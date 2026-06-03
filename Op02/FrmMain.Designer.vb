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
        Me.Tmr_Work1 = New System.Windows.Forms.Timer(Me.components)
        Me.Serial_Printer = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BasicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VitualKeyboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.srcLbSerialL = New System.Windows.Forms.Label()
        Me.srcLbPartOptionL = New System.Windows.Forms.Label()
        Me.srcLbPartNameL = New System.Windows.Forms.Label()
        Me.srcLbPartNoL = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.srclbStepR = New System.Windows.Forms.Label()
        Me.lbD4159 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbD4109 = New System.Windows.Forms.Label()
        Me.lbTitleD4109 = New System.Windows.Forms.Label()
        Me.lbD4158 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lbD4108 = New System.Windows.Forms.Label()
        Me.lbTitleD4108 = New System.Windows.Forms.Label()
        Me.lbD4157 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lbD4107 = New System.Windows.Forms.Label()
        Me.lbTitleD4107 = New System.Windows.Forms.Label()
        Me.lbD4156 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lbD4106 = New System.Windows.Forms.Label()
        Me.lbTitleD4106 = New System.Windows.Forms.Label()
        Me.lbD4155 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lbD4105 = New System.Windows.Forms.Label()
        Me.lbTitleD4105 = New System.Windows.Forms.Label()
        Me.lbD4154 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lbD4104 = New System.Windows.Forms.Label()
        Me.lbTitleD4104 = New System.Windows.Forms.Label()
        Me.lbD4153 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.lbD4103 = New System.Windows.Forms.Label()
        Me.lbTitleD4103 = New System.Windows.Forms.Label()
        Me.lbD4152 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lbD4102 = New System.Windows.Forms.Label()
        Me.lbTitleD4102 = New System.Windows.Forms.Label()
        Me.lbD4151 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.lbD4101 = New System.Windows.Forms.Label()
        Me.lbTitleD4101 = New System.Windows.Forms.Label()
        Me.lbD4150 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lbD4100 = New System.Windows.Forms.Label()
        Me.lbTitleD4100 = New System.Windows.Forms.Label()
        Me.srclbStepL = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.srcLbPlcConnectionState = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbD4059 = New System.Windows.Forms.Label()
        Me.lbTitleD4059 = New System.Windows.Forms.Label()
        Me.lbD4009 = New System.Windows.Forms.Label()
        Me.lbTitleD4009 = New System.Windows.Forms.Label()
        Me.lbD4058 = New System.Windows.Forms.Label()
        Me.lbTitleD4058 = New System.Windows.Forms.Label()
        Me.lbD4008 = New System.Windows.Forms.Label()
        Me.lbTitleD4008 = New System.Windows.Forms.Label()
        Me.lbD4057 = New System.Windows.Forms.Label()
        Me.lbTitleD4057 = New System.Windows.Forms.Label()
        Me.lbD4007 = New System.Windows.Forms.Label()
        Me.lbTitleD4007 = New System.Windows.Forms.Label()
        Me.lbD4056 = New System.Windows.Forms.Label()
        Me.lbTitleD4056 = New System.Windows.Forms.Label()
        Me.lbD4006 = New System.Windows.Forms.Label()
        Me.lbTitleD4006 = New System.Windows.Forms.Label()
        Me.lbD4055 = New System.Windows.Forms.Label()
        Me.lbTitleD4055 = New System.Windows.Forms.Label()
        Me.lbD4005 = New System.Windows.Forms.Label()
        Me.lbTitleD4005 = New System.Windows.Forms.Label()
        Me.lbD4054 = New System.Windows.Forms.Label()
        Me.lbTitleD4054 = New System.Windows.Forms.Label()
        Me.lbD4004 = New System.Windows.Forms.Label()
        Me.lbTitleD4004 = New System.Windows.Forms.Label()
        Me.lbD4053 = New System.Windows.Forms.Label()
        Me.lbTitleD4053 = New System.Windows.Forms.Label()
        Me.lbD4003 = New System.Windows.Forms.Label()
        Me.lbTitleD4003 = New System.Windows.Forms.Label()
        Me.lbD4052 = New System.Windows.Forms.Label()
        Me.lbTitleD4052 = New System.Windows.Forms.Label()
        Me.lbD4002 = New System.Windows.Forms.Label()
        Me.lbTitleD4002 = New System.Windows.Forms.Label()
        Me.lbD4051 = New System.Windows.Forms.Label()
        Me.lbTitleD4051 = New System.Windows.Forms.Label()
        Me.lbD4001 = New System.Windows.Forms.Label()
        Me.lbTitleD4001 = New System.Windows.Forms.Label()
        Me.lbD4050 = New System.Windows.Forms.Label()
        Me.lbTitleD4050 = New System.Windows.Forms.Label()
        Me.lbD4000 = New System.Windows.Forms.Label()
        Me.lbTitleD4000 = New System.Windows.Forms.Label()
        Me.Serial_ScannerL = New System.IO.Ports.SerialPort(Me.components)
        Me.Serial_Tool = New System.IO.Ports.SerialPort(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.srcPictureBoxL = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Tmr_Connect = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_Tool = New System.Windows.Forms.Timer(Me.components)
        Me.srclbDecToolL = New System.Windows.Forms.Label()
        Me.srclbDataToolL = New System.Windows.Forms.Label()
        Me.srclbTargetToolL = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.srcLbSerialR = New System.Windows.Forms.Label()
        Me.srcLbPartOptionR = New System.Windows.Forms.Label()
        Me.srcLbPartNameR = New System.Windows.Forms.Label()
        Me.srcLbPartNoR = New System.Windows.Forms.Label()
        Me.srcPictureBoxR = New System.Windows.Forms.PictureBox()
        Me.srclbDecToolR = New System.Windows.Forms.Label()
        Me.srclbDataToolR = New System.Windows.Forms.Label()
        Me.srclbTargetToolR = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Serial_ScannerR = New System.IO.Ports.SerialPort(Me.components)
        Me.Tmr_Work2 = New System.Windows.Forms.Timer(Me.components)
        Me.srclbDecLsuptBarcodeL = New System.Windows.Forms.Label()
        Me.srclbDataLsuptBarcodeL = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.srclbTargetLsuptBarcodeL = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.srclbDecLsuptBarcodeR = New System.Windows.Forms.Label()
        Me.srclbDataLsuptBarcodeR = New System.Windows.Forms.Label()
        Me.srclbTargetLsuptBarcodeR = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.srclbDecHarnessBarcodeL = New System.Windows.Forms.Label()
        Me.srclbDataHarnessBarcodeL = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.srclbTargetHarnessBarcodeL = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.srclbDecHarnessBarcodeR = New System.Windows.Forms.Label()
        Me.srclbDataHarnessBarcodeR = New System.Windows.Forms.Label()
        Me.srclbTargetHarnessBarcodeR = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.srclbDecLsuptVersionBarcodeL = New System.Windows.Forms.Label()
        Me.srclbDataLsuptVersionBarcodeL = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.srclbTargetLsuptVersionBarcodeL = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.srclbDecLsuptVersionBarcodeR = New System.Windows.Forms.Label()
        Me.srclbDataLsuptVersionBarcodeR = New System.Windows.Forms.Label()
        Me.srclbTargetLsuptVersionBarcodeR = New System.Windows.Forms.Label()
        Me.srclbDecTool2L = New System.Windows.Forms.Label()
        Me.srclbDataTool2L = New System.Windows.Forms.Label()
        Me.srclbDecTool2R = New System.Windows.Forms.Label()
        Me.srclbDataTool2R = New System.Windows.Forms.Label()
        Me.srclbTargetTool2L = New System.Windows.Forms.Label()
        Me.srclbTargetTool2R = New System.Windows.Forms.Label()
        Me.srclbAlarm = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.srcPictureBoxL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.srcPictureBoxR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tmr_Work1
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DarkGray
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1917, 31)
        Me.MenuStrip1.TabIndex = 98
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
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(380, 51)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "제품 이미지"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbSerialL
        '
        Me.srcLbSerialL.BackColor = System.Drawing.Color.Black
        Me.srcLbSerialL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbSerialL.Font = New System.Drawing.Font("Arial Narrow", 16.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbSerialL.ForeColor = System.Drawing.Color.White
        Me.srcLbSerialL.Location = New System.Drawing.Point(463, 465)
        Me.srcLbSerialL.Name = "srcLbSerialL"
        Me.srcLbSerialL.Size = New System.Drawing.Size(283, 108)
        Me.srcLbSerialL.TabIndex = 34
        Me.srcLbSerialL.Text = "20210316000188888-00000"
        Me.srcLbSerialL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartOptionL
        '
        Me.srcLbPartOptionL.BackColor = System.Drawing.Color.Black
        Me.srcLbPartOptionL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartOptionL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartOptionL.ForeColor = System.Drawing.Color.White
        Me.srcLbPartOptionL.Location = New System.Drawing.Point(463, 357)
        Me.srcLbPartOptionL.Name = "srcLbPartOptionL"
        Me.srcLbPartOptionL.Size = New System.Drawing.Size(283, 108)
        Me.srcLbPartOptionL.TabIndex = 33
        Me.srcLbPartOptionL.Text = "PART NO."
        Me.srcLbPartOptionL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartNameL
        '
        Me.srcLbPartNameL.BackColor = System.Drawing.Color.Black
        Me.srcLbPartNameL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartNameL.Font = New System.Drawing.Font("Arial Narrow", 16.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartNameL.ForeColor = System.Drawing.Color.White
        Me.srcLbPartNameL.Location = New System.Drawing.Point(463, 249)
        Me.srcLbPartNameL.Name = "srcLbPartNameL"
        Me.srcLbPartNameL.Size = New System.Drawing.Size(283, 108)
        Me.srcLbPartNameL.TabIndex = 32
        Me.srcLbPartNameL.Text = "PART NO."
        Me.srcLbPartNameL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartNoL
        '
        Me.srcLbPartNoL.BackColor = System.Drawing.Color.Black
        Me.srcLbPartNoL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartNoL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartNoL.ForeColor = System.Drawing.Color.White
        Me.srcLbPartNoL.Location = New System.Drawing.Point(463, 141)
        Me.srcLbPartNoL.Name = "srcLbPartNoL"
        Me.srcLbPartNoL.Size = New System.Drawing.Size(283, 108)
        Me.srcLbPartNoL.TabIndex = 31
        Me.srcLbPartNoL.Text = "88888-00000"
        Me.srcLbPartNoL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(380, 465)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 108)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "시리얼"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(380, 357)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 108)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "옵션"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(380, 249)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 108)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "사양정보"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(380, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 108)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "사양"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Black
        Me.Panel11.Controls.Add(Me.srclbStepR)
        Me.Panel11.Controls.Add(Me.lbD4159)
        Me.Panel11.Controls.Add(Me.Label14)
        Me.Panel11.Controls.Add(Me.lbD4109)
        Me.Panel11.Controls.Add(Me.lbTitleD4109)
        Me.Panel11.Controls.Add(Me.lbD4158)
        Me.Panel11.Controls.Add(Me.Label25)
        Me.Panel11.Controls.Add(Me.lbD4108)
        Me.Panel11.Controls.Add(Me.lbTitleD4108)
        Me.Panel11.Controls.Add(Me.lbD4157)
        Me.Panel11.Controls.Add(Me.Label29)
        Me.Panel11.Controls.Add(Me.lbD4107)
        Me.Panel11.Controls.Add(Me.lbTitleD4107)
        Me.Panel11.Controls.Add(Me.lbD4156)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Controls.Add(Me.lbD4106)
        Me.Panel11.Controls.Add(Me.lbTitleD4106)
        Me.Panel11.Controls.Add(Me.lbD4155)
        Me.Panel11.Controls.Add(Me.Label37)
        Me.Panel11.Controls.Add(Me.lbD4105)
        Me.Panel11.Controls.Add(Me.lbTitleD4105)
        Me.Panel11.Controls.Add(Me.lbD4154)
        Me.Panel11.Controls.Add(Me.Label41)
        Me.Panel11.Controls.Add(Me.lbD4104)
        Me.Panel11.Controls.Add(Me.lbTitleD4104)
        Me.Panel11.Controls.Add(Me.lbD4153)
        Me.Panel11.Controls.Add(Me.Label45)
        Me.Panel11.Controls.Add(Me.lbD4103)
        Me.Panel11.Controls.Add(Me.lbTitleD4103)
        Me.Panel11.Controls.Add(Me.lbD4152)
        Me.Panel11.Controls.Add(Me.Label49)
        Me.Panel11.Controls.Add(Me.lbD4102)
        Me.Panel11.Controls.Add(Me.lbTitleD4102)
        Me.Panel11.Controls.Add(Me.lbD4151)
        Me.Panel11.Controls.Add(Me.Label53)
        Me.Panel11.Controls.Add(Me.lbD4101)
        Me.Panel11.Controls.Add(Me.lbTitleD4101)
        Me.Panel11.Controls.Add(Me.lbD4150)
        Me.Panel11.Controls.Add(Me.Label57)
        Me.Panel11.Controls.Add(Me.lbD4100)
        Me.Panel11.Controls.Add(Me.lbTitleD4100)
        Me.Panel11.Controls.Add(Me.srclbStepL)
        Me.Panel11.Controls.Add(Me.txtMessage)
        Me.Panel11.Controls.Add(Me.srcLbPlcConnectionState)
        Me.Panel11.Controls.Add(Me.Label11)
        Me.Panel11.Controls.Add(Me.lbD4059)
        Me.Panel11.Controls.Add(Me.lbTitleD4059)
        Me.Panel11.Controls.Add(Me.lbD4009)
        Me.Panel11.Controls.Add(Me.lbTitleD4009)
        Me.Panel11.Controls.Add(Me.lbD4058)
        Me.Panel11.Controls.Add(Me.lbTitleD4058)
        Me.Panel11.Controls.Add(Me.lbD4008)
        Me.Panel11.Controls.Add(Me.lbTitleD4008)
        Me.Panel11.Controls.Add(Me.lbD4057)
        Me.Panel11.Controls.Add(Me.lbTitleD4057)
        Me.Panel11.Controls.Add(Me.lbD4007)
        Me.Panel11.Controls.Add(Me.lbTitleD4007)
        Me.Panel11.Controls.Add(Me.lbD4056)
        Me.Panel11.Controls.Add(Me.lbTitleD4056)
        Me.Panel11.Controls.Add(Me.lbD4006)
        Me.Panel11.Controls.Add(Me.lbTitleD4006)
        Me.Panel11.Controls.Add(Me.lbD4055)
        Me.Panel11.Controls.Add(Me.lbTitleD4055)
        Me.Panel11.Controls.Add(Me.lbD4005)
        Me.Panel11.Controls.Add(Me.lbTitleD4005)
        Me.Panel11.Controls.Add(Me.lbD4054)
        Me.Panel11.Controls.Add(Me.lbTitleD4054)
        Me.Panel11.Controls.Add(Me.lbD4004)
        Me.Panel11.Controls.Add(Me.lbTitleD4004)
        Me.Panel11.Controls.Add(Me.lbD4053)
        Me.Panel11.Controls.Add(Me.lbTitleD4053)
        Me.Panel11.Controls.Add(Me.lbD4003)
        Me.Panel11.Controls.Add(Me.lbTitleD4003)
        Me.Panel11.Controls.Add(Me.lbD4052)
        Me.Panel11.Controls.Add(Me.lbTitleD4052)
        Me.Panel11.Controls.Add(Me.lbD4002)
        Me.Panel11.Controls.Add(Me.lbTitleD4002)
        Me.Panel11.Controls.Add(Me.lbD4051)
        Me.Panel11.Controls.Add(Me.lbTitleD4051)
        Me.Panel11.Controls.Add(Me.lbD4001)
        Me.Panel11.Controls.Add(Me.lbTitleD4001)
        Me.Panel11.Controls.Add(Me.lbD4050)
        Me.Panel11.Controls.Add(Me.lbTitleD4050)
        Me.Panel11.Controls.Add(Me.lbD4000)
        Me.Panel11.Controls.Add(Me.lbTitleD4000)
        Me.Panel11.Location = New System.Drawing.Point(1493, 141)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(423, 905)
        Me.Panel11.TabIndex = 111
        '
        'srclbStepR
        '
        Me.srclbStepR.BackColor = System.Drawing.Color.Gray
        Me.srclbStepR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbStepR.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbStepR.ForeColor = System.Drawing.Color.White
        Me.srclbStepR.Location = New System.Drawing.Point(361, 9)
        Me.srclbStepR.Name = "srclbStepR"
        Me.srclbStepR.Size = New System.Drawing.Size(57, 36)
        Me.srclbStepR.TabIndex = 213
        Me.srclbStepR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4159
        '
        Me.lbD4159.BackColor = System.Drawing.Color.Gray
        Me.lbD4159.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4159.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4159.ForeColor = System.Drawing.Color.White
        Me.lbD4159.Location = New System.Drawing.Point(340, 738)
        Me.lbD4159.Name = "lbD4159"
        Me.lbD4159.Size = New System.Drawing.Size(78, 36)
        Me.lbD4159.TabIndex = 212
        Me.lbD4159.Text = "1"
        Me.lbD4159.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gray
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(212, 738)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 36)
        Me.Label14.TabIndex = 211
        Me.Label14.Text = "D4159"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4109
        '
        Me.lbD4109.BackColor = System.Drawing.Color.Gray
        Me.lbD4109.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4109.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4109.ForeColor = System.Drawing.Color.White
        Me.lbD4109.Location = New System.Drawing.Point(134, 738)
        Me.lbD4109.Name = "lbD4109"
        Me.lbD4109.Size = New System.Drawing.Size(78, 36)
        Me.lbD4109.TabIndex = 210
        Me.lbD4109.Text = "1"
        Me.lbD4109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4109
        '
        Me.lbTitleD4109.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4109.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4109.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4109.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4109.Location = New System.Drawing.Point(6, 738)
        Me.lbTitleD4109.Name = "lbTitleD4109"
        Me.lbTitleD4109.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4109.TabIndex = 209
        Me.lbTitleD4109.Text = "D4109"
        Me.lbTitleD4109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4158
        '
        Me.lbD4158.BackColor = System.Drawing.Color.Gray
        Me.lbD4158.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4158.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4158.ForeColor = System.Drawing.Color.White
        Me.lbD4158.Location = New System.Drawing.Point(340, 702)
        Me.lbD4158.Name = "lbD4158"
        Me.lbD4158.Size = New System.Drawing.Size(78, 36)
        Me.lbD4158.TabIndex = 208
        Me.lbD4158.Text = "1"
        Me.lbD4158.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Gray
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(212, 702)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 36)
        Me.Label25.TabIndex = 207
        Me.Label25.Text = "D4158"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4108
        '
        Me.lbD4108.BackColor = System.Drawing.Color.Gray
        Me.lbD4108.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4108.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4108.ForeColor = System.Drawing.Color.White
        Me.lbD4108.Location = New System.Drawing.Point(134, 702)
        Me.lbD4108.Name = "lbD4108"
        Me.lbD4108.Size = New System.Drawing.Size(78, 36)
        Me.lbD4108.TabIndex = 206
        Me.lbD4108.Text = "1"
        Me.lbD4108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4108
        '
        Me.lbTitleD4108.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4108.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4108.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4108.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4108.Location = New System.Drawing.Point(6, 702)
        Me.lbTitleD4108.Name = "lbTitleD4108"
        Me.lbTitleD4108.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4108.TabIndex = 205
        Me.lbTitleD4108.Text = "D4108"
        Me.lbTitleD4108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4157
        '
        Me.lbD4157.BackColor = System.Drawing.Color.Gray
        Me.lbD4157.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4157.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4157.ForeColor = System.Drawing.Color.White
        Me.lbD4157.Location = New System.Drawing.Point(340, 666)
        Me.lbD4157.Name = "lbD4157"
        Me.lbD4157.Size = New System.Drawing.Size(78, 36)
        Me.lbD4157.TabIndex = 204
        Me.lbD4157.Text = "1"
        Me.lbD4157.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Gray
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(212, 666)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(128, 36)
        Me.Label29.TabIndex = 203
        Me.Label29.Text = "D4157"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4107
        '
        Me.lbD4107.BackColor = System.Drawing.Color.Gray
        Me.lbD4107.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4107.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4107.ForeColor = System.Drawing.Color.White
        Me.lbD4107.Location = New System.Drawing.Point(134, 666)
        Me.lbD4107.Name = "lbD4107"
        Me.lbD4107.Size = New System.Drawing.Size(78, 36)
        Me.lbD4107.TabIndex = 202
        Me.lbD4107.Text = "1"
        Me.lbD4107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4107
        '
        Me.lbTitleD4107.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4107.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4107.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4107.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4107.Location = New System.Drawing.Point(6, 666)
        Me.lbTitleD4107.Name = "lbTitleD4107"
        Me.lbTitleD4107.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4107.TabIndex = 201
        Me.lbTitleD4107.Text = "D4107"
        Me.lbTitleD4107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4156
        '
        Me.lbD4156.BackColor = System.Drawing.Color.Gray
        Me.lbD4156.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4156.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4156.ForeColor = System.Drawing.Color.White
        Me.lbD4156.Location = New System.Drawing.Point(340, 630)
        Me.lbD4156.Name = "lbD4156"
        Me.lbD4156.Size = New System.Drawing.Size(78, 36)
        Me.lbD4156.TabIndex = 200
        Me.lbD4156.Text = "1"
        Me.lbD4156.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Gray
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(212, 630)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(128, 36)
        Me.Label33.TabIndex = 199
        Me.Label33.Text = "D4156"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4106
        '
        Me.lbD4106.BackColor = System.Drawing.Color.Gray
        Me.lbD4106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4106.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4106.ForeColor = System.Drawing.Color.White
        Me.lbD4106.Location = New System.Drawing.Point(134, 630)
        Me.lbD4106.Name = "lbD4106"
        Me.lbD4106.Size = New System.Drawing.Size(78, 36)
        Me.lbD4106.TabIndex = 198
        Me.lbD4106.Text = "1"
        Me.lbD4106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4106
        '
        Me.lbTitleD4106.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4106.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4106.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4106.Location = New System.Drawing.Point(6, 630)
        Me.lbTitleD4106.Name = "lbTitleD4106"
        Me.lbTitleD4106.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4106.TabIndex = 197
        Me.lbTitleD4106.Text = "D4106"
        Me.lbTitleD4106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4155
        '
        Me.lbD4155.BackColor = System.Drawing.Color.Gray
        Me.lbD4155.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4155.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4155.ForeColor = System.Drawing.Color.White
        Me.lbD4155.Location = New System.Drawing.Point(340, 594)
        Me.lbD4155.Name = "lbD4155"
        Me.lbD4155.Size = New System.Drawing.Size(78, 36)
        Me.lbD4155.TabIndex = 196
        Me.lbD4155.Text = "1"
        Me.lbD4155.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Gray
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(212, 594)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(128, 36)
        Me.Label37.TabIndex = 195
        Me.Label37.Text = "D4155"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4105
        '
        Me.lbD4105.BackColor = System.Drawing.Color.Gray
        Me.lbD4105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4105.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4105.ForeColor = System.Drawing.Color.White
        Me.lbD4105.Location = New System.Drawing.Point(134, 594)
        Me.lbD4105.Name = "lbD4105"
        Me.lbD4105.Size = New System.Drawing.Size(78, 36)
        Me.lbD4105.TabIndex = 194
        Me.lbD4105.Text = "1"
        Me.lbD4105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4105
        '
        Me.lbTitleD4105.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4105.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4105.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4105.Location = New System.Drawing.Point(6, 594)
        Me.lbTitleD4105.Name = "lbTitleD4105"
        Me.lbTitleD4105.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4105.TabIndex = 193
        Me.lbTitleD4105.Text = "D4105"
        Me.lbTitleD4105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4154
        '
        Me.lbD4154.BackColor = System.Drawing.Color.Gray
        Me.lbD4154.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4154.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4154.ForeColor = System.Drawing.Color.White
        Me.lbD4154.Location = New System.Drawing.Point(340, 558)
        Me.lbD4154.Name = "lbD4154"
        Me.lbD4154.Size = New System.Drawing.Size(78, 36)
        Me.lbD4154.TabIndex = 192
        Me.lbD4154.Text = "1"
        Me.lbD4154.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Gray
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(212, 558)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(128, 36)
        Me.Label41.TabIndex = 191
        Me.Label41.Text = "D4154"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4104
        '
        Me.lbD4104.BackColor = System.Drawing.Color.Gray
        Me.lbD4104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4104.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4104.ForeColor = System.Drawing.Color.White
        Me.lbD4104.Location = New System.Drawing.Point(134, 558)
        Me.lbD4104.Name = "lbD4104"
        Me.lbD4104.Size = New System.Drawing.Size(78, 36)
        Me.lbD4104.TabIndex = 190
        Me.lbD4104.Text = "1"
        Me.lbD4104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4104
        '
        Me.lbTitleD4104.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4104.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4104.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4104.Location = New System.Drawing.Point(6, 558)
        Me.lbTitleD4104.Name = "lbTitleD4104"
        Me.lbTitleD4104.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4104.TabIndex = 189
        Me.lbTitleD4104.Text = "D4104"
        Me.lbTitleD4104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4153
        '
        Me.lbD4153.BackColor = System.Drawing.Color.Gray
        Me.lbD4153.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4153.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4153.ForeColor = System.Drawing.Color.White
        Me.lbD4153.Location = New System.Drawing.Point(340, 522)
        Me.lbD4153.Name = "lbD4153"
        Me.lbD4153.Size = New System.Drawing.Size(78, 36)
        Me.lbD4153.TabIndex = 188
        Me.lbD4153.Text = "1"
        Me.lbD4153.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Gray
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(212, 522)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(128, 36)
        Me.Label45.TabIndex = 187
        Me.Label45.Text = "D4153"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4103
        '
        Me.lbD4103.BackColor = System.Drawing.Color.Gray
        Me.lbD4103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4103.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4103.ForeColor = System.Drawing.Color.White
        Me.lbD4103.Location = New System.Drawing.Point(134, 522)
        Me.lbD4103.Name = "lbD4103"
        Me.lbD4103.Size = New System.Drawing.Size(78, 36)
        Me.lbD4103.TabIndex = 186
        Me.lbD4103.Text = "1"
        Me.lbD4103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4103
        '
        Me.lbTitleD4103.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4103.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4103.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4103.Location = New System.Drawing.Point(6, 522)
        Me.lbTitleD4103.Name = "lbTitleD4103"
        Me.lbTitleD4103.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4103.TabIndex = 185
        Me.lbTitleD4103.Text = "D4103"
        Me.lbTitleD4103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4152
        '
        Me.lbD4152.BackColor = System.Drawing.Color.Gray
        Me.lbD4152.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4152.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4152.ForeColor = System.Drawing.Color.White
        Me.lbD4152.Location = New System.Drawing.Point(340, 486)
        Me.lbD4152.Name = "lbD4152"
        Me.lbD4152.Size = New System.Drawing.Size(78, 36)
        Me.lbD4152.TabIndex = 184
        Me.lbD4152.Text = "1"
        Me.lbD4152.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Gray
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label49.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.White
        Me.Label49.Location = New System.Drawing.Point(212, 486)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(128, 36)
        Me.Label49.TabIndex = 183
        Me.Label49.Text = "D4152"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4102
        '
        Me.lbD4102.BackColor = System.Drawing.Color.Gray
        Me.lbD4102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4102.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4102.ForeColor = System.Drawing.Color.White
        Me.lbD4102.Location = New System.Drawing.Point(134, 486)
        Me.lbD4102.Name = "lbD4102"
        Me.lbD4102.Size = New System.Drawing.Size(78, 36)
        Me.lbD4102.TabIndex = 182
        Me.lbD4102.Text = "1"
        Me.lbD4102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4102
        '
        Me.lbTitleD4102.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4102.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4102.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4102.Location = New System.Drawing.Point(6, 486)
        Me.lbTitleD4102.Name = "lbTitleD4102"
        Me.lbTitleD4102.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4102.TabIndex = 181
        Me.lbTitleD4102.Text = "D4102"
        Me.lbTitleD4102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4151
        '
        Me.lbD4151.BackColor = System.Drawing.Color.Gray
        Me.lbD4151.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4151.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4151.ForeColor = System.Drawing.Color.White
        Me.lbD4151.Location = New System.Drawing.Point(340, 450)
        Me.lbD4151.Name = "lbD4151"
        Me.lbD4151.Size = New System.Drawing.Size(78, 36)
        Me.lbD4151.TabIndex = 180
        Me.lbD4151.Text = "1"
        Me.lbD4151.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Gray
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.White
        Me.Label53.Location = New System.Drawing.Point(212, 450)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(128, 36)
        Me.Label53.TabIndex = 179
        Me.Label53.Text = "D4151"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4101
        '
        Me.lbD4101.BackColor = System.Drawing.Color.Gray
        Me.lbD4101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4101.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4101.ForeColor = System.Drawing.Color.White
        Me.lbD4101.Location = New System.Drawing.Point(134, 450)
        Me.lbD4101.Name = "lbD4101"
        Me.lbD4101.Size = New System.Drawing.Size(78, 36)
        Me.lbD4101.TabIndex = 178
        Me.lbD4101.Text = "1"
        Me.lbD4101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4101
        '
        Me.lbTitleD4101.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4101.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4101.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4101.Location = New System.Drawing.Point(6, 450)
        Me.lbTitleD4101.Name = "lbTitleD4101"
        Me.lbTitleD4101.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4101.TabIndex = 177
        Me.lbTitleD4101.Text = "D4101"
        Me.lbTitleD4101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4150
        '
        Me.lbD4150.BackColor = System.Drawing.Color.Gray
        Me.lbD4150.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4150.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4150.ForeColor = System.Drawing.Color.White
        Me.lbD4150.Location = New System.Drawing.Point(340, 414)
        Me.lbD4150.Name = "lbD4150"
        Me.lbD4150.Size = New System.Drawing.Size(78, 36)
        Me.lbD4150.TabIndex = 176
        Me.lbD4150.Text = "1"
        Me.lbD4150.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Gray
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label57.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.White
        Me.Label57.Location = New System.Drawing.Point(212, 414)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(128, 36)
        Me.Label57.TabIndex = 175
        Me.Label57.Text = "D4150"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4100
        '
        Me.lbD4100.BackColor = System.Drawing.Color.Gray
        Me.lbD4100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4100.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4100.ForeColor = System.Drawing.Color.White
        Me.lbD4100.Location = New System.Drawing.Point(134, 414)
        Me.lbD4100.Name = "lbD4100"
        Me.lbD4100.Size = New System.Drawing.Size(78, 36)
        Me.lbD4100.TabIndex = 174
        Me.lbD4100.Text = "1"
        Me.lbD4100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4100
        '
        Me.lbTitleD4100.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4100.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4100.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4100.Location = New System.Drawing.Point(6, 414)
        Me.lbTitleD4100.Name = "lbTitleD4100"
        Me.lbTitleD4100.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4100.TabIndex = 173
        Me.lbTitleD4100.Text = "D4100"
        Me.lbTitleD4100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbStepL
        '
        Me.srclbStepL.BackColor = System.Drawing.Color.Gray
        Me.srclbStepL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbStepL.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbStepL.ForeColor = System.Drawing.Color.White
        Me.srclbStepL.Location = New System.Drawing.Point(304, 9)
        Me.srclbStepL.Name = "srclbStepL"
        Me.srclbStepL.Size = New System.Drawing.Size(57, 36)
        Me.srclbStepL.TabIndex = 172
        Me.srclbStepL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMessage
        '
        Me.txtMessage.BackColor = System.Drawing.Color.Black
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.Enabled = False
        Me.txtMessage.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.txtMessage.ForeColor = System.Drawing.Color.White
        Me.txtMessage.Location = New System.Drawing.Point(6, 777)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(412, 122)
        Me.txtMessage.TabIndex = 51
        '
        'srcLbPlcConnectionState
        '
        Me.srcLbPlcConnectionState.BackColor = System.Drawing.Color.Gray
        Me.srcLbPlcConnectionState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPlcConnectionState.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcLbPlcConnectionState.ForeColor = System.Drawing.Color.White
        Me.srcLbPlcConnectionState.Location = New System.Drawing.Point(212, 9)
        Me.srcLbPlcConnectionState.Name = "srcLbPlcConnectionState"
        Me.srcLbPlcConnectionState.Size = New System.Drawing.Size(92, 36)
        Me.srcLbPlcConnectionState.TabIndex = 171
        Me.srcLbPlcConnectionState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(6, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(206, 36)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "192.168.0.105"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4059
        '
        Me.lbD4059.BackColor = System.Drawing.Color.Gray
        Me.lbD4059.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4059.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4059.ForeColor = System.Drawing.Color.White
        Me.lbD4059.Location = New System.Drawing.Point(340, 369)
        Me.lbD4059.Name = "lbD4059"
        Me.lbD4059.Size = New System.Drawing.Size(78, 36)
        Me.lbD4059.TabIndex = 169
        Me.lbD4059.Text = "1"
        Me.lbD4059.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4059
        '
        Me.lbTitleD4059.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4059.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4059.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4059.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4059.Location = New System.Drawing.Point(212, 369)
        Me.lbTitleD4059.Name = "lbTitleD4059"
        Me.lbTitleD4059.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4059.TabIndex = 168
        Me.lbTitleD4059.Text = "D4059"
        Me.lbTitleD4059.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4009
        '
        Me.lbD4009.BackColor = System.Drawing.Color.Gray
        Me.lbD4009.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4009.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4009.ForeColor = System.Drawing.Color.White
        Me.lbD4009.Location = New System.Drawing.Point(134, 369)
        Me.lbD4009.Name = "lbD4009"
        Me.lbD4009.Size = New System.Drawing.Size(78, 36)
        Me.lbD4009.TabIndex = 167
        Me.lbD4009.Text = "1"
        Me.lbD4009.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4009
        '
        Me.lbTitleD4009.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4009.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4009.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4009.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4009.Location = New System.Drawing.Point(6, 369)
        Me.lbTitleD4009.Name = "lbTitleD4009"
        Me.lbTitleD4009.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4009.TabIndex = 166
        Me.lbTitleD4009.Text = "D4009"
        Me.lbTitleD4009.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4058
        '
        Me.lbD4058.BackColor = System.Drawing.Color.Gray
        Me.lbD4058.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4058.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4058.ForeColor = System.Drawing.Color.White
        Me.lbD4058.Location = New System.Drawing.Point(340, 333)
        Me.lbD4058.Name = "lbD4058"
        Me.lbD4058.Size = New System.Drawing.Size(78, 36)
        Me.lbD4058.TabIndex = 165
        Me.lbD4058.Text = "1"
        Me.lbD4058.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4058
        '
        Me.lbTitleD4058.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4058.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4058.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4058.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4058.Location = New System.Drawing.Point(212, 333)
        Me.lbTitleD4058.Name = "lbTitleD4058"
        Me.lbTitleD4058.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4058.TabIndex = 164
        Me.lbTitleD4058.Text = "D4058"
        Me.lbTitleD4058.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4008
        '
        Me.lbD4008.BackColor = System.Drawing.Color.Gray
        Me.lbD4008.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4008.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4008.ForeColor = System.Drawing.Color.White
        Me.lbD4008.Location = New System.Drawing.Point(134, 333)
        Me.lbD4008.Name = "lbD4008"
        Me.lbD4008.Size = New System.Drawing.Size(78, 36)
        Me.lbD4008.TabIndex = 163
        Me.lbD4008.Text = "1"
        Me.lbD4008.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4008
        '
        Me.lbTitleD4008.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4008.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4008.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4008.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4008.Location = New System.Drawing.Point(6, 333)
        Me.lbTitleD4008.Name = "lbTitleD4008"
        Me.lbTitleD4008.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4008.TabIndex = 162
        Me.lbTitleD4008.Text = "D4008"
        Me.lbTitleD4008.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4057
        '
        Me.lbD4057.BackColor = System.Drawing.Color.Gray
        Me.lbD4057.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4057.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4057.ForeColor = System.Drawing.Color.White
        Me.lbD4057.Location = New System.Drawing.Point(340, 297)
        Me.lbD4057.Name = "lbD4057"
        Me.lbD4057.Size = New System.Drawing.Size(78, 36)
        Me.lbD4057.TabIndex = 161
        Me.lbD4057.Text = "1"
        Me.lbD4057.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4057
        '
        Me.lbTitleD4057.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4057.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4057.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4057.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4057.Location = New System.Drawing.Point(212, 297)
        Me.lbTitleD4057.Name = "lbTitleD4057"
        Me.lbTitleD4057.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4057.TabIndex = 160
        Me.lbTitleD4057.Text = "D4057"
        Me.lbTitleD4057.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4007
        '
        Me.lbD4007.BackColor = System.Drawing.Color.Gray
        Me.lbD4007.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4007.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4007.ForeColor = System.Drawing.Color.White
        Me.lbD4007.Location = New System.Drawing.Point(134, 297)
        Me.lbD4007.Name = "lbD4007"
        Me.lbD4007.Size = New System.Drawing.Size(78, 36)
        Me.lbD4007.TabIndex = 159
        Me.lbD4007.Text = "1"
        Me.lbD4007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4007
        '
        Me.lbTitleD4007.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4007.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4007.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4007.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4007.Location = New System.Drawing.Point(6, 297)
        Me.lbTitleD4007.Name = "lbTitleD4007"
        Me.lbTitleD4007.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4007.TabIndex = 158
        Me.lbTitleD4007.Text = "D4007"
        Me.lbTitleD4007.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4056
        '
        Me.lbD4056.BackColor = System.Drawing.Color.Gray
        Me.lbD4056.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4056.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4056.ForeColor = System.Drawing.Color.White
        Me.lbD4056.Location = New System.Drawing.Point(340, 261)
        Me.lbD4056.Name = "lbD4056"
        Me.lbD4056.Size = New System.Drawing.Size(78, 36)
        Me.lbD4056.TabIndex = 157
        Me.lbD4056.Text = "1"
        Me.lbD4056.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4056
        '
        Me.lbTitleD4056.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4056.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4056.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4056.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4056.Location = New System.Drawing.Point(212, 261)
        Me.lbTitleD4056.Name = "lbTitleD4056"
        Me.lbTitleD4056.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4056.TabIndex = 156
        Me.lbTitleD4056.Text = "D4056"
        Me.lbTitleD4056.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4006
        '
        Me.lbD4006.BackColor = System.Drawing.Color.Gray
        Me.lbD4006.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4006.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4006.ForeColor = System.Drawing.Color.White
        Me.lbD4006.Location = New System.Drawing.Point(134, 261)
        Me.lbD4006.Name = "lbD4006"
        Me.lbD4006.Size = New System.Drawing.Size(78, 36)
        Me.lbD4006.TabIndex = 155
        Me.lbD4006.Text = "1"
        Me.lbD4006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4006
        '
        Me.lbTitleD4006.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4006.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4006.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4006.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4006.Location = New System.Drawing.Point(6, 261)
        Me.lbTitleD4006.Name = "lbTitleD4006"
        Me.lbTitleD4006.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4006.TabIndex = 154
        Me.lbTitleD4006.Text = "D4006"
        Me.lbTitleD4006.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4055
        '
        Me.lbD4055.BackColor = System.Drawing.Color.Gray
        Me.lbD4055.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4055.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4055.ForeColor = System.Drawing.Color.White
        Me.lbD4055.Location = New System.Drawing.Point(340, 225)
        Me.lbD4055.Name = "lbD4055"
        Me.lbD4055.Size = New System.Drawing.Size(78, 36)
        Me.lbD4055.TabIndex = 153
        Me.lbD4055.Text = "1"
        Me.lbD4055.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4055
        '
        Me.lbTitleD4055.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4055.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4055.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4055.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4055.Location = New System.Drawing.Point(212, 225)
        Me.lbTitleD4055.Name = "lbTitleD4055"
        Me.lbTitleD4055.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4055.TabIndex = 152
        Me.lbTitleD4055.Text = "D4055"
        Me.lbTitleD4055.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4005
        '
        Me.lbD4005.BackColor = System.Drawing.Color.Gray
        Me.lbD4005.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4005.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4005.ForeColor = System.Drawing.Color.White
        Me.lbD4005.Location = New System.Drawing.Point(134, 225)
        Me.lbD4005.Name = "lbD4005"
        Me.lbD4005.Size = New System.Drawing.Size(78, 36)
        Me.lbD4005.TabIndex = 151
        Me.lbD4005.Text = "1"
        Me.lbD4005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4005
        '
        Me.lbTitleD4005.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4005.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4005.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4005.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4005.Location = New System.Drawing.Point(6, 225)
        Me.lbTitleD4005.Name = "lbTitleD4005"
        Me.lbTitleD4005.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4005.TabIndex = 150
        Me.lbTitleD4005.Text = "D4005"
        Me.lbTitleD4005.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4054
        '
        Me.lbD4054.BackColor = System.Drawing.Color.Gray
        Me.lbD4054.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4054.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4054.ForeColor = System.Drawing.Color.White
        Me.lbD4054.Location = New System.Drawing.Point(340, 189)
        Me.lbD4054.Name = "lbD4054"
        Me.lbD4054.Size = New System.Drawing.Size(78, 36)
        Me.lbD4054.TabIndex = 149
        Me.lbD4054.Text = "1"
        Me.lbD4054.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4054
        '
        Me.lbTitleD4054.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4054.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4054.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4054.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4054.Location = New System.Drawing.Point(212, 189)
        Me.lbTitleD4054.Name = "lbTitleD4054"
        Me.lbTitleD4054.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4054.TabIndex = 148
        Me.lbTitleD4054.Text = "D4054"
        Me.lbTitleD4054.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4004
        '
        Me.lbD4004.BackColor = System.Drawing.Color.Gray
        Me.lbD4004.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4004.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4004.ForeColor = System.Drawing.Color.White
        Me.lbD4004.Location = New System.Drawing.Point(134, 189)
        Me.lbD4004.Name = "lbD4004"
        Me.lbD4004.Size = New System.Drawing.Size(78, 36)
        Me.lbD4004.TabIndex = 147
        Me.lbD4004.Text = "1"
        Me.lbD4004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4004
        '
        Me.lbTitleD4004.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4004.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4004.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4004.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4004.Location = New System.Drawing.Point(6, 189)
        Me.lbTitleD4004.Name = "lbTitleD4004"
        Me.lbTitleD4004.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4004.TabIndex = 146
        Me.lbTitleD4004.Text = "D4004"
        Me.lbTitleD4004.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4053
        '
        Me.lbD4053.BackColor = System.Drawing.Color.Gray
        Me.lbD4053.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4053.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4053.ForeColor = System.Drawing.Color.White
        Me.lbD4053.Location = New System.Drawing.Point(340, 153)
        Me.lbD4053.Name = "lbD4053"
        Me.lbD4053.Size = New System.Drawing.Size(78, 36)
        Me.lbD4053.TabIndex = 145
        Me.lbD4053.Text = "1"
        Me.lbD4053.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4053
        '
        Me.lbTitleD4053.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4053.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4053.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4053.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4053.Location = New System.Drawing.Point(212, 153)
        Me.lbTitleD4053.Name = "lbTitleD4053"
        Me.lbTitleD4053.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4053.TabIndex = 144
        Me.lbTitleD4053.Text = "D4053"
        Me.lbTitleD4053.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4003
        '
        Me.lbD4003.BackColor = System.Drawing.Color.Gray
        Me.lbD4003.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4003.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4003.ForeColor = System.Drawing.Color.White
        Me.lbD4003.Location = New System.Drawing.Point(134, 153)
        Me.lbD4003.Name = "lbD4003"
        Me.lbD4003.Size = New System.Drawing.Size(78, 36)
        Me.lbD4003.TabIndex = 143
        Me.lbD4003.Text = "1"
        Me.lbD4003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4003
        '
        Me.lbTitleD4003.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4003.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4003.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4003.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4003.Location = New System.Drawing.Point(6, 153)
        Me.lbTitleD4003.Name = "lbTitleD4003"
        Me.lbTitleD4003.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4003.TabIndex = 142
        Me.lbTitleD4003.Text = "D4003"
        Me.lbTitleD4003.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4052
        '
        Me.lbD4052.BackColor = System.Drawing.Color.Gray
        Me.lbD4052.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4052.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4052.ForeColor = System.Drawing.Color.White
        Me.lbD4052.Location = New System.Drawing.Point(340, 117)
        Me.lbD4052.Name = "lbD4052"
        Me.lbD4052.Size = New System.Drawing.Size(78, 36)
        Me.lbD4052.TabIndex = 141
        Me.lbD4052.Text = "1"
        Me.lbD4052.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4052
        '
        Me.lbTitleD4052.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4052.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4052.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4052.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4052.Location = New System.Drawing.Point(212, 117)
        Me.lbTitleD4052.Name = "lbTitleD4052"
        Me.lbTitleD4052.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4052.TabIndex = 140
        Me.lbTitleD4052.Text = "D4052"
        Me.lbTitleD4052.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4002
        '
        Me.lbD4002.BackColor = System.Drawing.Color.Gray
        Me.lbD4002.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4002.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4002.ForeColor = System.Drawing.Color.White
        Me.lbD4002.Location = New System.Drawing.Point(134, 117)
        Me.lbD4002.Name = "lbD4002"
        Me.lbD4002.Size = New System.Drawing.Size(78, 36)
        Me.lbD4002.TabIndex = 139
        Me.lbD4002.Text = "1"
        Me.lbD4002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4002
        '
        Me.lbTitleD4002.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4002.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4002.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4002.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4002.Location = New System.Drawing.Point(6, 117)
        Me.lbTitleD4002.Name = "lbTitleD4002"
        Me.lbTitleD4002.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4002.TabIndex = 138
        Me.lbTitleD4002.Text = "D4002"
        Me.lbTitleD4002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4051
        '
        Me.lbD4051.BackColor = System.Drawing.Color.Gray
        Me.lbD4051.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4051.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4051.ForeColor = System.Drawing.Color.White
        Me.lbD4051.Location = New System.Drawing.Point(340, 81)
        Me.lbD4051.Name = "lbD4051"
        Me.lbD4051.Size = New System.Drawing.Size(78, 36)
        Me.lbD4051.TabIndex = 137
        Me.lbD4051.Text = "1"
        Me.lbD4051.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4051
        '
        Me.lbTitleD4051.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4051.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4051.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4051.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4051.Location = New System.Drawing.Point(212, 81)
        Me.lbTitleD4051.Name = "lbTitleD4051"
        Me.lbTitleD4051.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4051.TabIndex = 136
        Me.lbTitleD4051.Text = "D4051"
        Me.lbTitleD4051.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4001
        '
        Me.lbD4001.BackColor = System.Drawing.Color.Gray
        Me.lbD4001.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4001.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4001.ForeColor = System.Drawing.Color.White
        Me.lbD4001.Location = New System.Drawing.Point(134, 81)
        Me.lbD4001.Name = "lbD4001"
        Me.lbD4001.Size = New System.Drawing.Size(78, 36)
        Me.lbD4001.TabIndex = 135
        Me.lbD4001.Text = "1"
        Me.lbD4001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4001
        '
        Me.lbTitleD4001.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4001.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4001.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4001.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4001.Location = New System.Drawing.Point(6, 81)
        Me.lbTitleD4001.Name = "lbTitleD4001"
        Me.lbTitleD4001.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4001.TabIndex = 134
        Me.lbTitleD4001.Text = "D4001"
        Me.lbTitleD4001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4050
        '
        Me.lbD4050.BackColor = System.Drawing.Color.Gray
        Me.lbD4050.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4050.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4050.ForeColor = System.Drawing.Color.White
        Me.lbD4050.Location = New System.Drawing.Point(340, 45)
        Me.lbD4050.Name = "lbD4050"
        Me.lbD4050.Size = New System.Drawing.Size(78, 36)
        Me.lbD4050.TabIndex = 133
        Me.lbD4050.Text = "1"
        Me.lbD4050.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4050
        '
        Me.lbTitleD4050.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4050.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4050.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4050.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4050.Location = New System.Drawing.Point(212, 45)
        Me.lbTitleD4050.Name = "lbTitleD4050"
        Me.lbTitleD4050.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4050.TabIndex = 132
        Me.lbTitleD4050.Text = "D4050"
        Me.lbTitleD4050.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4000
        '
        Me.lbD4000.BackColor = System.Drawing.Color.Gray
        Me.lbD4000.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4000.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4000.ForeColor = System.Drawing.Color.White
        Me.lbD4000.Location = New System.Drawing.Point(134, 45)
        Me.lbD4000.Name = "lbD4000"
        Me.lbD4000.Size = New System.Drawing.Size(78, 36)
        Me.lbD4000.TabIndex = 131
        Me.lbD4000.Text = "1"
        Me.lbD4000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4000
        '
        Me.lbTitleD4000.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4000.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4000.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4000.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4000.Location = New System.Drawing.Point(6, 45)
        Me.lbTitleD4000.Name = "lbTitleD4000"
        Me.lbTitleD4000.Size = New System.Drawing.Size(128, 36)
        Me.lbTitleD4000.TabIndex = 130
        Me.lbTitleD4000.Text = "D4000"
        Me.lbTitleD4000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Serial_ScannerL
        '
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(380, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(366, 51)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "사양 정보"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Navy
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1493, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(423, 51)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "시스템 정보"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcPictureBoxL
        '
        Me.srcPictureBoxL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcPictureBoxL.Location = New System.Drawing.Point(0, 141)
        Me.srcPictureBoxL.Name = "srcPictureBoxL"
        Me.srcPictureBoxL.Size = New System.Drawing.Size(380, 432)
        Me.srcPictureBoxL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.srcPictureBoxL.TabIndex = 0
        Me.srcPictureBoxL.TabStop = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(0, 573)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(746, 51)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "관리 항목"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1916, 59)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "RS4 FRT BACK ASSEMBLE SYSTEM OP02-1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1917, 59)
        Me.Panel3.TabIndex = 119
        '
        'Tmr_Connect
        '
        '
        'tmr_Tool
        '
        '
        'srclbDecToolL
        '
        Me.srclbDecToolL.BackColor = System.Drawing.Color.Black
        Me.srclbDecToolL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecToolL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecToolL.ForeColor = System.Drawing.Color.White
        Me.srclbDecToolL.Location = New System.Drawing.Point(413, 676)
        Me.srclbDecToolL.Name = "srclbDecToolL"
        Me.srclbDecToolL.Size = New System.Drawing.Size(84, 52)
        Me.srclbDecToolL.TabIndex = 145
        Me.srclbDecToolL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataToolL
        '
        Me.srclbDataToolL.BackColor = System.Drawing.Color.Black
        Me.srclbDataToolL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataToolL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataToolL.ForeColor = System.Drawing.Color.White
        Me.srclbDataToolL.Location = New System.Drawing.Point(249, 676)
        Me.srclbDataToolL.Name = "srclbDataToolL"
        Me.srclbDataToolL.Size = New System.Drawing.Size(164, 52)
        Me.srclbDataToolL.TabIndex = 144
        Me.srclbDataToolL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetToolL
        '
        Me.srclbTargetToolL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetToolL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetToolL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetToolL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetToolL.Location = New System.Drawing.Point(249, 624)
        Me.srclbTargetToolL.Name = "srclbTargetToolL"
        Me.srclbTargetToolL.Size = New System.Drawing.Size(248, 52)
        Me.srclbTargetToolL.TabIndex = 143
        Me.srclbTargetToolL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Black
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(143, 624)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(106, 52)
        Me.Label20.TabIndex = 142
        Me.Label20.Text = "목표"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Black
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(0, 624)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(143, 104)
        Me.Label22.TabIndex = 141
        Me.Label22.Text = "에어툴"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Black
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(143, 676)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(106, 52)
        Me.Label23.TabIndex = 140
        Me.Label23.Text = "체결"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(746, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(380, 51)
        Me.Label9.TabIndex = 146
        Me.Label9.Text = "제품 이미지"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Gray
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(1126, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(366, 51)
        Me.Label16.TabIndex = 147
        Me.Label16.Text = "사양 정보"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbSerialR
        '
        Me.srcLbSerialR.BackColor = System.Drawing.Color.Black
        Me.srcLbSerialR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbSerialR.Font = New System.Drawing.Font("Arial Narrow", 16.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbSerialR.ForeColor = System.Drawing.Color.White
        Me.srcLbSerialR.Location = New System.Drawing.Point(1209, 465)
        Me.srcLbSerialR.Name = "srcLbSerialR"
        Me.srcLbSerialR.Size = New System.Drawing.Size(283, 108)
        Me.srcLbSerialR.TabIndex = 156
        Me.srcLbSerialR.Text = "20210316000188888-00000"
        Me.srcLbSerialR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartOptionR
        '
        Me.srcLbPartOptionR.BackColor = System.Drawing.Color.Black
        Me.srcLbPartOptionR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartOptionR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartOptionR.ForeColor = System.Drawing.Color.White
        Me.srcLbPartOptionR.Location = New System.Drawing.Point(1209, 357)
        Me.srcLbPartOptionR.Name = "srcLbPartOptionR"
        Me.srcLbPartOptionR.Size = New System.Drawing.Size(283, 108)
        Me.srcLbPartOptionR.TabIndex = 155
        Me.srcLbPartOptionR.Text = "PART NO."
        Me.srcLbPartOptionR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartNameR
        '
        Me.srcLbPartNameR.BackColor = System.Drawing.Color.Black
        Me.srcLbPartNameR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartNameR.Font = New System.Drawing.Font("Arial Narrow", 16.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartNameR.ForeColor = System.Drawing.Color.White
        Me.srcLbPartNameR.Location = New System.Drawing.Point(1209, 249)
        Me.srcLbPartNameR.Name = "srcLbPartNameR"
        Me.srcLbPartNameR.Size = New System.Drawing.Size(283, 108)
        Me.srcLbPartNameR.TabIndex = 154
        Me.srcLbPartNameR.Text = "PART NO."
        Me.srcLbPartNameR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartNoR
        '
        Me.srcLbPartNoR.BackColor = System.Drawing.Color.Black
        Me.srcLbPartNoR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartNoR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartNoR.ForeColor = System.Drawing.Color.White
        Me.srcLbPartNoR.Location = New System.Drawing.Point(1209, 141)
        Me.srcLbPartNoR.Name = "srcLbPartNoR"
        Me.srcLbPartNoR.Size = New System.Drawing.Size(283, 108)
        Me.srcLbPartNoR.TabIndex = 153
        Me.srcLbPartNoR.Text = "88888-00000"
        Me.srcLbPartNoR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcPictureBoxR
        '
        Me.srcPictureBoxR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcPictureBoxR.Location = New System.Drawing.Point(746, 141)
        Me.srcPictureBoxR.Name = "srcPictureBoxR"
        Me.srcPictureBoxR.Size = New System.Drawing.Size(380, 432)
        Me.srcPictureBoxR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.srcPictureBoxR.TabIndex = 148
        Me.srcPictureBoxR.TabStop = False
        '
        'srclbDecToolR
        '
        Me.srclbDecToolR.BackColor = System.Drawing.Color.Black
        Me.srclbDecToolR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecToolR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecToolR.ForeColor = System.Drawing.Color.White
        Me.srclbDecToolR.Location = New System.Drawing.Point(1159, 676)
        Me.srclbDecToolR.Name = "srclbDecToolR"
        Me.srclbDecToolR.Size = New System.Drawing.Size(84, 52)
        Me.srclbDecToolR.TabIndex = 163
        Me.srclbDecToolR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataToolR
        '
        Me.srclbDataToolR.BackColor = System.Drawing.Color.Black
        Me.srclbDataToolR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataToolR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataToolR.ForeColor = System.Drawing.Color.White
        Me.srclbDataToolR.Location = New System.Drawing.Point(995, 676)
        Me.srclbDataToolR.Name = "srclbDataToolR"
        Me.srclbDataToolR.Size = New System.Drawing.Size(164, 52)
        Me.srclbDataToolR.TabIndex = 162
        Me.srclbDataToolR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetToolR
        '
        Me.srclbTargetToolR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetToolR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetToolR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetToolR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetToolR.Location = New System.Drawing.Point(995, 624)
        Me.srclbTargetToolR.Name = "srclbTargetToolR"
        Me.srclbTargetToolR.Size = New System.Drawing.Size(248, 52)
        Me.srclbTargetToolR.TabIndex = 161
        Me.srclbTargetToolR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Black
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(746, 624)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(143, 104)
        Me.Label31.TabIndex = 159
        Me.Label31.Text = "에어툴"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Gray
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(746, 573)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(746, 51)
        Me.Label34.TabIndex = 157
        Me.Label34.Text = "관리 항목"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Serial_ScannerR
        '
        '
        'Tmr_Work2
        '
        '
        'srclbDecLsuptBarcodeL
        '
        Me.srclbDecLsuptBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDecLsuptBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecLsuptBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecLsuptBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDecLsuptBarcodeL.Location = New System.Drawing.Point(634, 780)
        Me.srclbDecLsuptBarcodeL.Name = "srclbDecLsuptBarcodeL"
        Me.srclbDecLsuptBarcodeL.Size = New System.Drawing.Size(112, 52)
        Me.srclbDecLsuptBarcodeL.TabIndex = 169
        Me.srclbDecLsuptBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataLsuptBarcodeL
        '
        Me.srclbDataLsuptBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDataLsuptBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataLsuptBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataLsuptBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDataLsuptBarcodeL.Location = New System.Drawing.Point(249, 780)
        Me.srclbDataLsuptBarcodeL.Name = "srclbDataLsuptBarcodeL"
        Me.srclbDataLsuptBarcodeL.Size = New System.Drawing.Size(385, 52)
        Me.srclbDataLsuptBarcodeL.TabIndex = 168
        Me.srclbDataLsuptBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Black
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(143, 780)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 52)
        Me.Label12.TabIndex = 167
        Me.Label12.Text = "입력"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetLsuptBarcodeL
        '
        Me.srclbTargetLsuptBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetLsuptBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetLsuptBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetLsuptBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetLsuptBarcodeL.Location = New System.Drawing.Point(249, 728)
        Me.srclbTargetLsuptBarcodeL.Name = "srclbTargetLsuptBarcodeL"
        Me.srclbTargetLsuptBarcodeL.Size = New System.Drawing.Size(497, 52)
        Me.srclbTargetLsuptBarcodeL.TabIndex = 166
        Me.srclbTargetLsuptBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Black
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(143, 728)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 52)
        Me.Label13.TabIndex = 165
        Me.Label13.Text = "목표"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Black
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(0, 728)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(143, 104)
        Me.Label17.TabIndex = 164
        Me.Label17.Text = "LSUPT / PULLMA 바코드"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecLsuptBarcodeR
        '
        Me.srclbDecLsuptBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDecLsuptBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecLsuptBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecLsuptBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDecLsuptBarcodeR.Location = New System.Drawing.Point(1380, 780)
        Me.srclbDecLsuptBarcodeR.Name = "srclbDecLsuptBarcodeR"
        Me.srclbDecLsuptBarcodeR.Size = New System.Drawing.Size(112, 52)
        Me.srclbDecLsuptBarcodeR.TabIndex = 175
        Me.srclbDecLsuptBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataLsuptBarcodeR
        '
        Me.srclbDataLsuptBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDataLsuptBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataLsuptBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataLsuptBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDataLsuptBarcodeR.Location = New System.Drawing.Point(995, 780)
        Me.srclbDataLsuptBarcodeR.Name = "srclbDataLsuptBarcodeR"
        Me.srclbDataLsuptBarcodeR.Size = New System.Drawing.Size(385, 52)
        Me.srclbDataLsuptBarcodeR.TabIndex = 174
        Me.srclbDataLsuptBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetLsuptBarcodeR
        '
        Me.srclbTargetLsuptBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetLsuptBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetLsuptBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetLsuptBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetLsuptBarcodeR.Location = New System.Drawing.Point(995, 728)
        Me.srclbTargetLsuptBarcodeR.Name = "srclbTargetLsuptBarcodeR"
        Me.srclbTargetLsuptBarcodeR.Size = New System.Drawing.Size(497, 52)
        Me.srclbTargetLsuptBarcodeR.TabIndex = 172
        Me.srclbTargetLsuptBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Black
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(746, 728)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(143, 104)
        Me.Label36.TabIndex = 170
        Me.Label36.Text = "LSUPT / PULLMA 바코드"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecHarnessBarcodeL
        '
        Me.srclbDecHarnessBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDecHarnessBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecHarnessBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecHarnessBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDecHarnessBarcodeL.Location = New System.Drawing.Point(634, 988)
        Me.srclbDecHarnessBarcodeL.Name = "srclbDecHarnessBarcodeL"
        Me.srclbDecHarnessBarcodeL.Size = New System.Drawing.Size(112, 52)
        Me.srclbDecHarnessBarcodeL.TabIndex = 181
        Me.srclbDecHarnessBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataHarnessBarcodeL
        '
        Me.srclbDataHarnessBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDataHarnessBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataHarnessBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataHarnessBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDataHarnessBarcodeL.Location = New System.Drawing.Point(249, 988)
        Me.srclbDataHarnessBarcodeL.Name = "srclbDataHarnessBarcodeL"
        Me.srclbDataHarnessBarcodeL.Size = New System.Drawing.Size(385, 52)
        Me.srclbDataHarnessBarcodeL.TabIndex = 180
        Me.srclbDataHarnessBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Black
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(143, 988)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(106, 52)
        Me.Label28.TabIndex = 179
        Me.Label28.Text = "입력"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetHarnessBarcodeL
        '
        Me.srclbTargetHarnessBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetHarnessBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetHarnessBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetHarnessBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetHarnessBarcodeL.Location = New System.Drawing.Point(249, 936)
        Me.srclbTargetHarnessBarcodeL.Name = "srclbTargetHarnessBarcodeL"
        Me.srclbTargetHarnessBarcodeL.Size = New System.Drawing.Size(497, 52)
        Me.srclbTargetHarnessBarcodeL.TabIndex = 178
        Me.srclbTargetHarnessBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Black
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(143, 936)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(106, 52)
        Me.Label39.TabIndex = 177
        Me.Label39.Text = "목표"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Black
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(0, 936)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(143, 104)
        Me.Label40.TabIndex = 176
        Me.Label40.Text = "하네스 바코드"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecHarnessBarcodeR
        '
        Me.srclbDecHarnessBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDecHarnessBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecHarnessBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecHarnessBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDecHarnessBarcodeR.Location = New System.Drawing.Point(1380, 988)
        Me.srclbDecHarnessBarcodeR.Name = "srclbDecHarnessBarcodeR"
        Me.srclbDecHarnessBarcodeR.Size = New System.Drawing.Size(112, 52)
        Me.srclbDecHarnessBarcodeR.TabIndex = 187
        Me.srclbDecHarnessBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataHarnessBarcodeR
        '
        Me.srclbDataHarnessBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDataHarnessBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataHarnessBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataHarnessBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDataHarnessBarcodeR.Location = New System.Drawing.Point(995, 988)
        Me.srclbDataHarnessBarcodeR.Name = "srclbDataHarnessBarcodeR"
        Me.srclbDataHarnessBarcodeR.Size = New System.Drawing.Size(385, 52)
        Me.srclbDataHarnessBarcodeR.TabIndex = 186
        Me.srclbDataHarnessBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetHarnessBarcodeR
        '
        Me.srclbTargetHarnessBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetHarnessBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetHarnessBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetHarnessBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetHarnessBarcodeR.Location = New System.Drawing.Point(995, 936)
        Me.srclbTargetHarnessBarcodeR.Name = "srclbTargetHarnessBarcodeR"
        Me.srclbTargetHarnessBarcodeR.Size = New System.Drawing.Size(497, 52)
        Me.srclbTargetHarnessBarcodeR.TabIndex = 184
        Me.srclbTargetHarnessBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Black
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(746, 936)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(143, 104)
        Me.Label48.TabIndex = 182
        Me.Label48.Text = "하네스 바코드"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecLsuptVersionBarcodeL
        '
        Me.srclbDecLsuptVersionBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDecLsuptVersionBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecLsuptVersionBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecLsuptVersionBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDecLsuptVersionBarcodeL.Location = New System.Drawing.Point(634, 884)
        Me.srclbDecLsuptVersionBarcodeL.Name = "srclbDecLsuptVersionBarcodeL"
        Me.srclbDecLsuptVersionBarcodeL.Size = New System.Drawing.Size(112, 52)
        Me.srclbDecLsuptVersionBarcodeL.TabIndex = 192
        Me.srclbDecLsuptVersionBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataLsuptVersionBarcodeL
        '
        Me.srclbDataLsuptVersionBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDataLsuptVersionBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataLsuptVersionBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataLsuptVersionBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDataLsuptVersionBarcodeL.Location = New System.Drawing.Point(249, 884)
        Me.srclbDataLsuptVersionBarcodeL.Name = "srclbDataLsuptVersionBarcodeL"
        Me.srclbDataLsuptVersionBarcodeL.Size = New System.Drawing.Size(385, 52)
        Me.srclbDataLsuptVersionBarcodeL.TabIndex = 191
        Me.srclbDataLsuptVersionBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Black
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(143, 884)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(106, 52)
        Me.Label38.TabIndex = 190
        Me.Label38.Text = "입력"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetLsuptVersionBarcodeL
        '
        Me.srclbTargetLsuptVersionBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetLsuptVersionBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetLsuptVersionBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetLsuptVersionBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetLsuptVersionBarcodeL.Location = New System.Drawing.Point(249, 832)
        Me.srclbTargetLsuptVersionBarcodeL.Name = "srclbTargetLsuptVersionBarcodeL"
        Me.srclbTargetLsuptVersionBarcodeL.Size = New System.Drawing.Size(497, 52)
        Me.srclbTargetLsuptVersionBarcodeL.TabIndex = 189
        Me.srclbTargetLsuptVersionBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Black
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(143, 832)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(106, 52)
        Me.Label43.TabIndex = 188
        Me.Label43.Text = "목표"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Black
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label46.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(0, 832)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(143, 104)
        Me.Label46.TabIndex = 193
        Me.Label46.Text = "LSUPT VERSION 바코드"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Black
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label50.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label50.ForeColor = System.Drawing.Color.White
        Me.Label50.Location = New System.Drawing.Point(746, 832)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(143, 104)
        Me.Label50.TabIndex = 199
        Me.Label50.Text = "LSUPT VERSION 바코드"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecLsuptVersionBarcodeR
        '
        Me.srclbDecLsuptVersionBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDecLsuptVersionBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecLsuptVersionBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecLsuptVersionBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDecLsuptVersionBarcodeR.Location = New System.Drawing.Point(1380, 884)
        Me.srclbDecLsuptVersionBarcodeR.Name = "srclbDecLsuptVersionBarcodeR"
        Me.srclbDecLsuptVersionBarcodeR.Size = New System.Drawing.Size(112, 52)
        Me.srclbDecLsuptVersionBarcodeR.TabIndex = 198
        Me.srclbDecLsuptVersionBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataLsuptVersionBarcodeR
        '
        Me.srclbDataLsuptVersionBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDataLsuptVersionBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataLsuptVersionBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataLsuptVersionBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDataLsuptVersionBarcodeR.Location = New System.Drawing.Point(995, 884)
        Me.srclbDataLsuptVersionBarcodeR.Name = "srclbDataLsuptVersionBarcodeR"
        Me.srclbDataLsuptVersionBarcodeR.Size = New System.Drawing.Size(385, 52)
        Me.srclbDataLsuptVersionBarcodeR.TabIndex = 197
        Me.srclbDataLsuptVersionBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetLsuptVersionBarcodeR
        '
        Me.srclbTargetLsuptVersionBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetLsuptVersionBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetLsuptVersionBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetLsuptVersionBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetLsuptVersionBarcodeR.Location = New System.Drawing.Point(995, 832)
        Me.srclbTargetLsuptVersionBarcodeR.Name = "srclbTargetLsuptVersionBarcodeR"
        Me.srclbTargetLsuptVersionBarcodeR.Size = New System.Drawing.Size(497, 52)
        Me.srclbTargetLsuptVersionBarcodeR.TabIndex = 195
        Me.srclbTargetLsuptVersionBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecTool2L
        '
        Me.srclbDecTool2L.BackColor = System.Drawing.Color.Black
        Me.srclbDecTool2L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecTool2L.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecTool2L.ForeColor = System.Drawing.Color.White
        Me.srclbDecTool2L.Location = New System.Drawing.Point(661, 676)
        Me.srclbDecTool2L.Name = "srclbDecTool2L"
        Me.srclbDecTool2L.Size = New System.Drawing.Size(85, 52)
        Me.srclbDecTool2L.TabIndex = 201
        Me.srclbDecTool2L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataTool2L
        '
        Me.srclbDataTool2L.BackColor = System.Drawing.Color.Black
        Me.srclbDataTool2L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataTool2L.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataTool2L.ForeColor = System.Drawing.Color.White
        Me.srclbDataTool2L.Location = New System.Drawing.Point(497, 676)
        Me.srclbDataTool2L.Name = "srclbDataTool2L"
        Me.srclbDataTool2L.Size = New System.Drawing.Size(164, 52)
        Me.srclbDataTool2L.TabIndex = 200
        Me.srclbDataTool2L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecTool2R
        '
        Me.srclbDecTool2R.BackColor = System.Drawing.Color.Black
        Me.srclbDecTool2R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecTool2R.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecTool2R.ForeColor = System.Drawing.Color.White
        Me.srclbDecTool2R.Location = New System.Drawing.Point(1407, 676)
        Me.srclbDecTool2R.Name = "srclbDecTool2R"
        Me.srclbDecTool2R.Size = New System.Drawing.Size(85, 52)
        Me.srclbDecTool2R.TabIndex = 203
        Me.srclbDecTool2R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataTool2R
        '
        Me.srclbDataTool2R.BackColor = System.Drawing.Color.Black
        Me.srclbDataTool2R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataTool2R.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataTool2R.ForeColor = System.Drawing.Color.White
        Me.srclbDataTool2R.Location = New System.Drawing.Point(1243, 676)
        Me.srclbDataTool2R.Name = "srclbDataTool2R"
        Me.srclbDataTool2R.Size = New System.Drawing.Size(164, 52)
        Me.srclbDataTool2R.TabIndex = 202
        Me.srclbDataTool2R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetTool2L
        '
        Me.srclbTargetTool2L.BackColor = System.Drawing.Color.Black
        Me.srclbTargetTool2L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetTool2L.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetTool2L.ForeColor = System.Drawing.Color.White
        Me.srclbTargetTool2L.Location = New System.Drawing.Point(497, 624)
        Me.srclbTargetTool2L.Name = "srclbTargetTool2L"
        Me.srclbTargetTool2L.Size = New System.Drawing.Size(249, 52)
        Me.srclbTargetTool2L.TabIndex = 204
        Me.srclbTargetTool2L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetTool2R
        '
        Me.srclbTargetTool2R.BackColor = System.Drawing.Color.Black
        Me.srclbTargetTool2R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetTool2R.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetTool2R.ForeColor = System.Drawing.Color.White
        Me.srclbTargetTool2R.Location = New System.Drawing.Point(1243, 624)
        Me.srclbTargetTool2R.Name = "srclbTargetTool2R"
        Me.srclbTargetTool2R.Size = New System.Drawing.Size(249, 52)
        Me.srclbTargetTool2R.TabIndex = 205
        Me.srclbTargetTool2R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbAlarm
        '
        Me.srclbAlarm.BackColor = System.Drawing.Color.Red
        Me.srclbAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbAlarm.Font = New System.Drawing.Font("Arial Narrow", 65.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbAlarm.ForeColor = System.Drawing.Color.Yellow
        Me.srclbAlarm.Location = New System.Drawing.Point(12, 573)
        Me.srclbAlarm.Name = "srclbAlarm"
        Me.srclbAlarm.Size = New System.Drawing.Size(1893, 214)
        Me.srclbAlarm.TabIndex = 206
        Me.srclbAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbAlarm.Visible = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Black
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(1126, 465)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 108)
        Me.Label15.TabIndex = 210
        Me.Label15.Text = "시리얼"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Black
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(1126, 357)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(83, 108)
        Me.Label18.TabIndex = 209
        Me.Label18.Text = "옵션"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Black
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(1126, 249)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 108)
        Me.Label19.TabIndex = 208
        Me.Label19.Text = "사양정보"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Black
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(1126, 141)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 108)
        Me.Label21.TabIndex = 207
        Me.Label21.Text = "사양"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Black
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(889, 884)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(106, 52)
        Me.Label24.TabIndex = 218
        Me.Label24.Text = "입력"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Black
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(889, 832)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(106, 52)
        Me.Label26.TabIndex = 217
        Me.Label26.Text = "목표"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Black
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(889, 988)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(106, 52)
        Me.Label27.TabIndex = 216
        Me.Label27.Text = "입력"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Black
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(889, 936)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(106, 52)
        Me.Label30.TabIndex = 215
        Me.Label30.Text = "목표"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Black
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(889, 780)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(106, 52)
        Me.Label32.TabIndex = 214
        Me.Label32.Text = "입력"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Black
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(889, 728)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(106, 52)
        Me.Label35.TabIndex = 213
        Me.Label35.Text = "목표"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Black
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(889, 624)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(106, 52)
        Me.Label42.TabIndex = 212
        Me.Label42.Text = "목표"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Black
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label44.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(889, 676)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(106, 52)
        Me.Label44.TabIndex = 211
        Me.Label44.Text = "체결"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1917, 1047)
        Me.Controls.Add(Me.srclbAlarm)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.srclbTargetTool2R)
        Me.Controls.Add(Me.srclbTargetTool2L)
        Me.Controls.Add(Me.srclbDecTool2R)
        Me.Controls.Add(Me.srclbDataTool2R)
        Me.Controls.Add(Me.srclbDecTool2L)
        Me.Controls.Add(Me.srclbDataTool2L)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.srclbDecLsuptVersionBarcodeR)
        Me.Controls.Add(Me.srclbDataLsuptVersionBarcodeR)
        Me.Controls.Add(Me.srclbTargetLsuptVersionBarcodeR)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.srclbDecLsuptVersionBarcodeL)
        Me.Controls.Add(Me.srclbDataLsuptVersionBarcodeL)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.srclbTargetLsuptVersionBarcodeL)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.srclbDecHarnessBarcodeR)
        Me.Controls.Add(Me.srclbDataHarnessBarcodeR)
        Me.Controls.Add(Me.srclbTargetHarnessBarcodeR)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.srclbDecHarnessBarcodeL)
        Me.Controls.Add(Me.srclbDataHarnessBarcodeL)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.srclbTargetHarnessBarcodeL)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.srclbDecLsuptBarcodeR)
        Me.Controls.Add(Me.srclbDataLsuptBarcodeR)
        Me.Controls.Add(Me.srclbTargetLsuptBarcodeR)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.srclbDecLsuptBarcodeL)
        Me.Controls.Add(Me.srclbDataLsuptBarcodeL)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.srclbTargetLsuptBarcodeL)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.srclbDecToolR)
        Me.Controls.Add(Me.srclbDataToolR)
        Me.Controls.Add(Me.srclbTargetToolR)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.srcLbSerialR)
        Me.Controls.Add(Me.srcLbPartOptionR)
        Me.Controls.Add(Me.srcLbPartNameR)
        Me.Controls.Add(Me.srcLbPartNoR)
        Me.Controls.Add(Me.srcPictureBoxR)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.srclbDecToolL)
        Me.Controls.Add(Me.srclbDataToolL)
        Me.Controls.Add(Me.srclbTargetToolL)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.srcLbSerialL)
        Me.Controls.Add(Me.srcLbPartOptionL)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.srcLbPartNameL)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.srcLbPartNoL)
        Me.Controls.Add(Me.srcPictureBoxL)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.srcPictureBoxL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.srcPictureBoxR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tmr_Work1 As System.Windows.Forms.Timer
    Friend WithEvents Serial_Printer As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SerialPortToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BasicToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarcodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents srcLbPartNoL As Label
    Friend WithEvents srcLbSerialL As Label
    Friend WithEvents srcLbPartOptionL As Label
    Friend WithEvents srcLbPartNameL As Label
    Friend WithEvents Serial_ScannerL As IO.Ports.SerialPort
    Friend WithEvents Serial_Tool As IO.Ports.SerialPort
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents VitualKeyboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents srcPictureBoxL As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbD4000 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4000 As System.Windows.Forms.Label
    Friend WithEvents lbD4050 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4050 As System.Windows.Forms.Label
    Friend WithEvents lbD4051 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4051 As System.Windows.Forms.Label
    Friend WithEvents lbD4001 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4001 As System.Windows.Forms.Label
    Friend WithEvents lbD4059 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4059 As System.Windows.Forms.Label
    Friend WithEvents lbD4009 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4009 As System.Windows.Forms.Label
    Friend WithEvents lbD4058 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4058 As System.Windows.Forms.Label
    Friend WithEvents lbD4008 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4008 As System.Windows.Forms.Label
    Friend WithEvents lbD4057 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4057 As System.Windows.Forms.Label
    Friend WithEvents lbD4007 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4007 As System.Windows.Forms.Label
    Friend WithEvents lbD4056 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4056 As System.Windows.Forms.Label
    Friend WithEvents lbD4006 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4006 As System.Windows.Forms.Label
    Friend WithEvents lbD4055 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4055 As System.Windows.Forms.Label
    Friend WithEvents lbD4005 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4005 As System.Windows.Forms.Label
    Friend WithEvents lbD4054 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4054 As System.Windows.Forms.Label
    Friend WithEvents lbD4004 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4004 As System.Windows.Forms.Label
    Friend WithEvents lbD4053 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4053 As System.Windows.Forms.Label
    Friend WithEvents lbD4003 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4003 As System.Windows.Forms.Label
    Friend WithEvents lbD4052 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4052 As System.Windows.Forms.Label
    Friend WithEvents lbD4002 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4002 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents srcLbPlcConnectionState As System.Windows.Forms.Label
    Friend WithEvents Tmr_Connect As System.Windows.Forms.Timer
    Friend WithEvents srclbStepL As System.Windows.Forms.Label
    Friend WithEvents tmr_Tool As System.Windows.Forms.Timer
    Friend WithEvents srclbDecToolL As System.Windows.Forms.Label
    Friend WithEvents srclbDataToolL As System.Windows.Forms.Label
    Friend WithEvents srclbTargetToolL As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lbD4159 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbD4109 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4109 As System.Windows.Forms.Label
    Friend WithEvents lbD4158 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lbD4108 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4108 As System.Windows.Forms.Label
    Friend WithEvents lbD4157 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lbD4107 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4107 As System.Windows.Forms.Label
    Friend WithEvents lbD4156 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lbD4106 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4106 As System.Windows.Forms.Label
    Friend WithEvents lbD4155 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lbD4105 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4105 As System.Windows.Forms.Label
    Friend WithEvents lbD4154 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lbD4104 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4104 As System.Windows.Forms.Label
    Friend WithEvents lbD4153 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents lbD4103 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4103 As System.Windows.Forms.Label
    Friend WithEvents lbD4152 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lbD4102 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4102 As System.Windows.Forms.Label
    Friend WithEvents lbD4151 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents lbD4101 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4101 As System.Windows.Forms.Label
    Friend WithEvents lbD4150 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents lbD4100 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4100 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents srcLbSerialR As System.Windows.Forms.Label
    Friend WithEvents srcLbPartOptionR As System.Windows.Forms.Label
    Friend WithEvents srcLbPartNameR As System.Windows.Forms.Label
    Friend WithEvents srcLbPartNoR As System.Windows.Forms.Label
    Friend WithEvents srcPictureBoxR As System.Windows.Forms.PictureBox
    Friend WithEvents srclbDecToolR As System.Windows.Forms.Label
    Friend WithEvents srclbDataToolR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetToolR As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Serial_ScannerR As System.IO.Ports.SerialPort
    Friend WithEvents Tmr_Work2 As System.Windows.Forms.Timer
    Friend WithEvents srclbStepR As System.Windows.Forms.Label
    Friend WithEvents srclbDecLsuptBarcodeL As System.Windows.Forms.Label
    Friend WithEvents srclbDataLsuptBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents srclbTargetLsuptBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents srclbDecLsuptBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbDataLsuptBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetLsuptBarcodeR As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents srclbDecHarnessBarcodeL As System.Windows.Forms.Label
    Friend WithEvents srclbDataHarnessBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents srclbTargetHarnessBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents srclbDecHarnessBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbDataHarnessBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetHarnessBarcodeR As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents srclbDecLsuptVersionBarcodeL As System.Windows.Forms.Label
    Friend WithEvents srclbDataLsuptVersionBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents srclbTargetLsuptVersionBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents srclbDecLsuptVersionBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbDataLsuptVersionBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetLsuptVersionBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbDecTool2L As System.Windows.Forms.Label
    Friend WithEvents srclbDataTool2L As System.Windows.Forms.Label
    Friend WithEvents srclbDecTool2R As System.Windows.Forms.Label
    Friend WithEvents srclbDataTool2R As System.Windows.Forms.Label
    Friend WithEvents srclbTargetTool2L As System.Windows.Forms.Label
    Friend WithEvents srclbTargetTool2R As System.Windows.Forms.Label
    Friend WithEvents srclbAlarm As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
End Class
