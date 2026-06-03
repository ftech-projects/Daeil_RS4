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
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.srclbStepR = New System.Windows.Forms.Label()
        Me.lbD4359 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbD4309 = New System.Windows.Forms.Label()
        Me.lbTitleD4309 = New System.Windows.Forms.Label()
        Me.lbD4358 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lbD4308 = New System.Windows.Forms.Label()
        Me.lbTitleD4308 = New System.Windows.Forms.Label()
        Me.lbD4357 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lbD4307 = New System.Windows.Forms.Label()
        Me.lbTitleD4307 = New System.Windows.Forms.Label()
        Me.lbD4356 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lbD4306 = New System.Windows.Forms.Label()
        Me.lbTitleD4306 = New System.Windows.Forms.Label()
        Me.lbD4355 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lbD4305 = New System.Windows.Forms.Label()
        Me.lbTitleD4305 = New System.Windows.Forms.Label()
        Me.lbD4354 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lbD4304 = New System.Windows.Forms.Label()
        Me.lbTitleD4304 = New System.Windows.Forms.Label()
        Me.lbD4353 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.lbD4303 = New System.Windows.Forms.Label()
        Me.lbTitleD4303 = New System.Windows.Forms.Label()
        Me.lbD4352 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lbD4302 = New System.Windows.Forms.Label()
        Me.lbTitleD4302 = New System.Windows.Forms.Label()
        Me.lbD4351 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.lbD4301 = New System.Windows.Forms.Label()
        Me.lbTitleD4301 = New System.Windows.Forms.Label()
        Me.lbD4350 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lbD4300 = New System.Windows.Forms.Label()
        Me.lbTitleD4300 = New System.Windows.Forms.Label()
        Me.srclbStepL = New System.Windows.Forms.Label()
        Me.srcLbPlcConnectionState = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbD4259 = New System.Windows.Forms.Label()
        Me.lbTitleD4259 = New System.Windows.Forms.Label()
        Me.lbD4209 = New System.Windows.Forms.Label()
        Me.lbTitleD4209 = New System.Windows.Forms.Label()
        Me.lbD4258 = New System.Windows.Forms.Label()
        Me.lbTitleD4258 = New System.Windows.Forms.Label()
        Me.lbD4208 = New System.Windows.Forms.Label()
        Me.lbTitleD4208 = New System.Windows.Forms.Label()
        Me.lbD4257 = New System.Windows.Forms.Label()
        Me.lbTitleD4257 = New System.Windows.Forms.Label()
        Me.lbD4207 = New System.Windows.Forms.Label()
        Me.lbTitleD4207 = New System.Windows.Forms.Label()
        Me.lbD4256 = New System.Windows.Forms.Label()
        Me.lbTitleD4256 = New System.Windows.Forms.Label()
        Me.lbD4206 = New System.Windows.Forms.Label()
        Me.lbTitleD4206 = New System.Windows.Forms.Label()
        Me.lbD4255 = New System.Windows.Forms.Label()
        Me.lbTitleD4255 = New System.Windows.Forms.Label()
        Me.lbD4205 = New System.Windows.Forms.Label()
        Me.lbTitleD4205 = New System.Windows.Forms.Label()
        Me.lbD4254 = New System.Windows.Forms.Label()
        Me.lbTitleD4254 = New System.Windows.Forms.Label()
        Me.lbD4204 = New System.Windows.Forms.Label()
        Me.lbTitleD4204 = New System.Windows.Forms.Label()
        Me.lbD4253 = New System.Windows.Forms.Label()
        Me.lbTitleD4253 = New System.Windows.Forms.Label()
        Me.lbD4203 = New System.Windows.Forms.Label()
        Me.lbTitleD4203 = New System.Windows.Forms.Label()
        Me.lbD4252 = New System.Windows.Forms.Label()
        Me.lbTitleD4252 = New System.Windows.Forms.Label()
        Me.lbD4202 = New System.Windows.Forms.Label()
        Me.lbTitleD4202 = New System.Windows.Forms.Label()
        Me.lbD4251 = New System.Windows.Forms.Label()
        Me.lbTitleD4251 = New System.Windows.Forms.Label()
        Me.lbD4201 = New System.Windows.Forms.Label()
        Me.lbTitleD4201 = New System.Windows.Forms.Label()
        Me.lbD4250 = New System.Windows.Forms.Label()
        Me.lbTitleD4250 = New System.Windows.Forms.Label()
        Me.lbD4200 = New System.Windows.Forms.Label()
        Me.lbTitleD4200 = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Serial_ScannerL = New System.IO.Ports.SerialPort(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Tmr_Connect = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_Tool1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.srcLbSerialR = New System.Windows.Forms.Label()
        Me.srcLbPartOptionR = New System.Windows.Forms.Label()
        Me.srcLbPartNameR = New System.Windows.Forms.Label()
        Me.srcLbPartNoR = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Serial_ScannerR = New System.IO.Ports.SerialPort(Me.components)
        Me.Tmr_Work2 = New System.Windows.Forms.Timer(Me.components)
        Me.Serial_Tool1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Serial_Tool2 = New System.IO.Ports.SerialPort(Me.components)
        Me.Serial_Tool3 = New System.IO.Ports.SerialPort(Me.components)
        Me.Serial_Resist1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Serial_Resist2 = New System.IO.Ports.SerialPort(Me.components)
        Me.srclbDecSabBarcodeL = New System.Windows.Forms.Label()
        Me.srclbDataSabBarcodeL = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.srclbTargetSabBarcodeL = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.srclbDecSabTqL = New System.Windows.Forms.Label()
        Me.srclbDataSabTQ1L = New System.Windows.Forms.Label()
        Me.srclbTargetSabTqL = New System.Windows.Forms.Label()
        Me.srclbDataSabTQ2L = New System.Windows.Forms.Label()
        Me.srclbDecSabResistL = New System.Windows.Forms.Label()
        Me.srclbDataSabResistL = New System.Windows.Forms.Label()
        Me.srclbTargetSabResistL = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.srclbDecAirToolL = New System.Windows.Forms.Label()
        Me.srclbDataAirToolL = New System.Windows.Forms.Label()
        Me.srclbTargetAirToolL = New System.Windows.Forms.Label()
        Me.srclbDecMotorBarcodeL = New System.Windows.Forms.Label()
        Me.srclbDataMotorBarcodeL = New System.Windows.Forms.Label()
        Me.srclbTargetMotorBarcodeL = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.srclbDecMotorTqL = New System.Windows.Forms.Label()
        Me.srclbdataMotorTqL = New System.Windows.Forms.Label()
        Me.srclbTargetMotorTqL = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.srclbDecAirToolR = New System.Windows.Forms.Label()
        Me.srclbDataAirToolR = New System.Windows.Forms.Label()
        Me.srclbTargetAirToolR = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.srclbDeccSabResistR = New System.Windows.Forms.Label()
        Me.srclbDatacSabResistR = New System.Windows.Forms.Label()
        Me.srclbTargetcSabResistR = New System.Windows.Forms.Label()
        Me.srclbDatacSabTQ2R = New System.Windows.Forms.Label()
        Me.srclbDeccSabTqR = New System.Windows.Forms.Label()
        Me.srclbDatacSabTQ1R = New System.Windows.Forms.Label()
        Me.srclbTargetcSabTqR = New System.Windows.Forms.Label()
        Me.srclbDecCSabBarcodeR = New System.Windows.Forms.Label()
        Me.srclbDataCSabBarcodeR = New System.Windows.Forms.Label()
        Me.srclbTargetCSabBarcodeR = New System.Windows.Forms.Label()
        Me.srclbDecSabResistR = New System.Windows.Forms.Label()
        Me.srclbDataSabResistR = New System.Windows.Forms.Label()
        Me.srclbTargetSabResistR = New System.Windows.Forms.Label()
        Me.srclbDataSabTQ2R = New System.Windows.Forms.Label()
        Me.srclbDecSabTqR = New System.Windows.Forms.Label()
        Me.srclbDataSabTQ1R = New System.Windows.Forms.Label()
        Me.srclbTargetSabTqR = New System.Windows.Forms.Label()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.Label125 = New System.Windows.Forms.Label()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.srclbDecSabBarcodeR = New System.Windows.Forms.Label()
        Me.srclbDataSabBarcodeR = New System.Windows.Forms.Label()
        Me.srclbTargetSabBarcodeR = New System.Windows.Forms.Label()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.tmr_Tool2 = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_Tool3 = New System.Windows.Forms.Timer(Me.components)
        Me.srcPictureBoxR = New System.Windows.Forms.PictureBox()
        Me.srcPictureBoxL = New System.Windows.Forms.PictureBox()
        Me.srclbDecMonitorBarcodeL = New System.Windows.Forms.Label()
        Me.srclbDataMonitorBarcodeL = New System.Windows.Forms.Label()
        Me.srclbTargetMonitorBarcodeL = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.srclbDecMonitorBarcodeR = New System.Windows.Forms.Label()
        Me.srclbDataMonitorBarcodeR = New System.Windows.Forms.Label()
        Me.srclbTargetMonitorBarcodeR = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.srclbAlarm = New System.Windows.Forms.Label()
        Me.LbAlarmLeft = New System.Windows.Forms.Label()
        Me.LbAlarmRight = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.srcPictureBoxR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.srcPictureBoxL, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MenuStrip1.Size = New System.Drawing.Size(1917, 41)
        Me.MenuStrip1.TabIndex = 98
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SerialPortToolStripMenuItem, Me.BasicToolStripMenuItem, Me.BarcodeToolStripMenuItem, Me.VitualKeyboardToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(86, 37)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'SerialPortToolStripMenuItem
        '
        Me.SerialPortToolStripMenuItem.Name = "SerialPortToolStripMenuItem"
        Me.SerialPortToolStripMenuItem.Size = New System.Drawing.Size(256, 38)
        Me.SerialPortToolStripMenuItem.Text = "Serial Port"
        '
        'BasicToolStripMenuItem
        '
        Me.BasicToolStripMenuItem.Name = "BasicToolStripMenuItem"
        Me.BasicToolStripMenuItem.Size = New System.Drawing.Size(256, 38)
        Me.BasicToolStripMenuItem.Text = "Basic"
        '
        'BarcodeToolStripMenuItem
        '
        Me.BarcodeToolStripMenuItem.Name = "BarcodeToolStripMenuItem"
        Me.BarcodeToolStripMenuItem.Size = New System.Drawing.Size(256, 38)
        Me.BarcodeToolStripMenuItem.Text = "Barcode"
        '
        'VitualKeyboardToolStripMenuItem
        '
        Me.VitualKeyboardToolStripMenuItem.Name = "VitualKeyboardToolStripMenuItem"
        Me.VitualKeyboardToolStripMenuItem.Size = New System.Drawing.Size(256, 38)
        Me.VitualKeyboardToolStripMenuItem.Text = "Vitual Keyboard"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(256, 38)
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
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Black
        Me.Panel11.Controls.Add(Me.srclbStepR)
        Me.Panel11.Controls.Add(Me.lbD4359)
        Me.Panel11.Controls.Add(Me.Label14)
        Me.Panel11.Controls.Add(Me.lbD4309)
        Me.Panel11.Controls.Add(Me.lbTitleD4309)
        Me.Panel11.Controls.Add(Me.lbD4358)
        Me.Panel11.Controls.Add(Me.Label25)
        Me.Panel11.Controls.Add(Me.lbD4308)
        Me.Panel11.Controls.Add(Me.lbTitleD4308)
        Me.Panel11.Controls.Add(Me.lbD4357)
        Me.Panel11.Controls.Add(Me.Label29)
        Me.Panel11.Controls.Add(Me.lbD4307)
        Me.Panel11.Controls.Add(Me.lbTitleD4307)
        Me.Panel11.Controls.Add(Me.lbD4356)
        Me.Panel11.Controls.Add(Me.Label33)
        Me.Panel11.Controls.Add(Me.lbD4306)
        Me.Panel11.Controls.Add(Me.lbTitleD4306)
        Me.Panel11.Controls.Add(Me.lbD4355)
        Me.Panel11.Controls.Add(Me.Label37)
        Me.Panel11.Controls.Add(Me.lbD4305)
        Me.Panel11.Controls.Add(Me.lbTitleD4305)
        Me.Panel11.Controls.Add(Me.lbD4354)
        Me.Panel11.Controls.Add(Me.Label41)
        Me.Panel11.Controls.Add(Me.lbD4304)
        Me.Panel11.Controls.Add(Me.lbTitleD4304)
        Me.Panel11.Controls.Add(Me.lbD4353)
        Me.Panel11.Controls.Add(Me.Label45)
        Me.Panel11.Controls.Add(Me.lbD4303)
        Me.Panel11.Controls.Add(Me.lbTitleD4303)
        Me.Panel11.Controls.Add(Me.lbD4352)
        Me.Panel11.Controls.Add(Me.Label49)
        Me.Panel11.Controls.Add(Me.lbD4302)
        Me.Panel11.Controls.Add(Me.lbTitleD4302)
        Me.Panel11.Controls.Add(Me.lbD4351)
        Me.Panel11.Controls.Add(Me.Label53)
        Me.Panel11.Controls.Add(Me.lbD4301)
        Me.Panel11.Controls.Add(Me.lbTitleD4301)
        Me.Panel11.Controls.Add(Me.lbD4350)
        Me.Panel11.Controls.Add(Me.Label57)
        Me.Panel11.Controls.Add(Me.lbD4300)
        Me.Panel11.Controls.Add(Me.lbTitleD4300)
        Me.Panel11.Controls.Add(Me.srclbStepL)
        Me.Panel11.Controls.Add(Me.srcLbPlcConnectionState)
        Me.Panel11.Controls.Add(Me.Label11)
        Me.Panel11.Controls.Add(Me.lbD4259)
        Me.Panel11.Controls.Add(Me.lbTitleD4259)
        Me.Panel11.Controls.Add(Me.lbD4209)
        Me.Panel11.Controls.Add(Me.lbTitleD4209)
        Me.Panel11.Controls.Add(Me.lbD4258)
        Me.Panel11.Controls.Add(Me.lbTitleD4258)
        Me.Panel11.Controls.Add(Me.lbD4208)
        Me.Panel11.Controls.Add(Me.lbTitleD4208)
        Me.Panel11.Controls.Add(Me.lbD4257)
        Me.Panel11.Controls.Add(Me.lbTitleD4257)
        Me.Panel11.Controls.Add(Me.lbD4207)
        Me.Panel11.Controls.Add(Me.lbTitleD4207)
        Me.Panel11.Controls.Add(Me.lbD4256)
        Me.Panel11.Controls.Add(Me.lbTitleD4256)
        Me.Panel11.Controls.Add(Me.lbD4206)
        Me.Panel11.Controls.Add(Me.lbTitleD4206)
        Me.Panel11.Controls.Add(Me.lbD4255)
        Me.Panel11.Controls.Add(Me.lbTitleD4255)
        Me.Panel11.Controls.Add(Me.lbD4205)
        Me.Panel11.Controls.Add(Me.lbTitleD4205)
        Me.Panel11.Controls.Add(Me.lbD4254)
        Me.Panel11.Controls.Add(Me.lbTitleD4254)
        Me.Panel11.Controls.Add(Me.lbD4204)
        Me.Panel11.Controls.Add(Me.lbTitleD4204)
        Me.Panel11.Controls.Add(Me.lbD4253)
        Me.Panel11.Controls.Add(Me.lbTitleD4253)
        Me.Panel11.Controls.Add(Me.lbD4203)
        Me.Panel11.Controls.Add(Me.lbTitleD4203)
        Me.Panel11.Controls.Add(Me.lbD4252)
        Me.Panel11.Controls.Add(Me.lbTitleD4252)
        Me.Panel11.Controls.Add(Me.lbD4202)
        Me.Panel11.Controls.Add(Me.lbTitleD4202)
        Me.Panel11.Controls.Add(Me.lbD4251)
        Me.Panel11.Controls.Add(Me.lbTitleD4251)
        Me.Panel11.Controls.Add(Me.lbD4201)
        Me.Panel11.Controls.Add(Me.lbTitleD4201)
        Me.Panel11.Controls.Add(Me.lbD4250)
        Me.Panel11.Controls.Add(Me.lbTitleD4250)
        Me.Panel11.Controls.Add(Me.lbD4200)
        Me.Panel11.Controls.Add(Me.lbTitleD4200)
        Me.Panel11.Location = New System.Drawing.Point(1493, 141)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(423, 748)
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
        Me.srclbStepR.Size = New System.Drawing.Size(57, 32)
        Me.srclbStepR.TabIndex = 213
        Me.srclbStepR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4359
        '
        Me.lbD4359.BackColor = System.Drawing.Color.Gray
        Me.lbD4359.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4359.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4359.ForeColor = System.Drawing.Color.White
        Me.lbD4359.Location = New System.Drawing.Point(340, 706)
        Me.lbD4359.Name = "lbD4359"
        Me.lbD4359.Size = New System.Drawing.Size(78, 35)
        Me.lbD4359.TabIndex = 212
        Me.lbD4359.Text = "1"
        Me.lbD4359.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gray
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(212, 706)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 35)
        Me.Label14.TabIndex = 211
        Me.Label14.Text = "D4359"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4309
        '
        Me.lbD4309.BackColor = System.Drawing.Color.Gray
        Me.lbD4309.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4309.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4309.ForeColor = System.Drawing.Color.White
        Me.lbD4309.Location = New System.Drawing.Point(134, 706)
        Me.lbD4309.Name = "lbD4309"
        Me.lbD4309.Size = New System.Drawing.Size(78, 35)
        Me.lbD4309.TabIndex = 210
        Me.lbD4309.Text = "1"
        Me.lbD4309.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4309
        '
        Me.lbTitleD4309.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4309.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4309.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4309.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4309.Location = New System.Drawing.Point(6, 706)
        Me.lbTitleD4309.Name = "lbTitleD4309"
        Me.lbTitleD4309.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4309.TabIndex = 209
        Me.lbTitleD4309.Text = "D4309"
        Me.lbTitleD4309.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4358
        '
        Me.lbD4358.BackColor = System.Drawing.Color.Gray
        Me.lbD4358.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4358.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4358.ForeColor = System.Drawing.Color.White
        Me.lbD4358.Location = New System.Drawing.Point(340, 671)
        Me.lbD4358.Name = "lbD4358"
        Me.lbD4358.Size = New System.Drawing.Size(78, 35)
        Me.lbD4358.TabIndex = 208
        Me.lbD4358.Text = "1"
        Me.lbD4358.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Gray
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(212, 671)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 35)
        Me.Label25.TabIndex = 207
        Me.Label25.Text = "D4358"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4308
        '
        Me.lbD4308.BackColor = System.Drawing.Color.Gray
        Me.lbD4308.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4308.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4308.ForeColor = System.Drawing.Color.White
        Me.lbD4308.Location = New System.Drawing.Point(134, 671)
        Me.lbD4308.Name = "lbD4308"
        Me.lbD4308.Size = New System.Drawing.Size(78, 35)
        Me.lbD4308.TabIndex = 206
        Me.lbD4308.Text = "1"
        Me.lbD4308.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4308
        '
        Me.lbTitleD4308.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4308.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4308.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4308.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4308.Location = New System.Drawing.Point(6, 671)
        Me.lbTitleD4308.Name = "lbTitleD4308"
        Me.lbTitleD4308.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4308.TabIndex = 205
        Me.lbTitleD4308.Text = "D4308"
        Me.lbTitleD4308.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4357
        '
        Me.lbD4357.BackColor = System.Drawing.Color.Gray
        Me.lbD4357.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4357.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4357.ForeColor = System.Drawing.Color.White
        Me.lbD4357.Location = New System.Drawing.Point(340, 636)
        Me.lbD4357.Name = "lbD4357"
        Me.lbD4357.Size = New System.Drawing.Size(78, 35)
        Me.lbD4357.TabIndex = 204
        Me.lbD4357.Text = "1"
        Me.lbD4357.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Gray
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(212, 636)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(128, 35)
        Me.Label29.TabIndex = 203
        Me.Label29.Text = "D4357"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4307
        '
        Me.lbD4307.BackColor = System.Drawing.Color.Gray
        Me.lbD4307.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4307.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4307.ForeColor = System.Drawing.Color.White
        Me.lbD4307.Location = New System.Drawing.Point(134, 636)
        Me.lbD4307.Name = "lbD4307"
        Me.lbD4307.Size = New System.Drawing.Size(78, 35)
        Me.lbD4307.TabIndex = 202
        Me.lbD4307.Text = "1"
        Me.lbD4307.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4307
        '
        Me.lbTitleD4307.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4307.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4307.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4307.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4307.Location = New System.Drawing.Point(6, 636)
        Me.lbTitleD4307.Name = "lbTitleD4307"
        Me.lbTitleD4307.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4307.TabIndex = 201
        Me.lbTitleD4307.Text = "D4307"
        Me.lbTitleD4307.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4356
        '
        Me.lbD4356.BackColor = System.Drawing.Color.Gray
        Me.lbD4356.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4356.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4356.ForeColor = System.Drawing.Color.White
        Me.lbD4356.Location = New System.Drawing.Point(340, 601)
        Me.lbD4356.Name = "lbD4356"
        Me.lbD4356.Size = New System.Drawing.Size(78, 35)
        Me.lbD4356.TabIndex = 200
        Me.lbD4356.Text = "1"
        Me.lbD4356.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Gray
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(212, 601)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(128, 35)
        Me.Label33.TabIndex = 199
        Me.Label33.Text = "D4356"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4306
        '
        Me.lbD4306.BackColor = System.Drawing.Color.Gray
        Me.lbD4306.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4306.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4306.ForeColor = System.Drawing.Color.White
        Me.lbD4306.Location = New System.Drawing.Point(134, 601)
        Me.lbD4306.Name = "lbD4306"
        Me.lbD4306.Size = New System.Drawing.Size(78, 35)
        Me.lbD4306.TabIndex = 198
        Me.lbD4306.Text = "1"
        Me.lbD4306.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4306
        '
        Me.lbTitleD4306.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4306.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4306.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4306.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4306.Location = New System.Drawing.Point(6, 601)
        Me.lbTitleD4306.Name = "lbTitleD4306"
        Me.lbTitleD4306.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4306.TabIndex = 197
        Me.lbTitleD4306.Text = "D4306"
        Me.lbTitleD4306.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4355
        '
        Me.lbD4355.BackColor = System.Drawing.Color.Gray
        Me.lbD4355.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4355.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4355.ForeColor = System.Drawing.Color.White
        Me.lbD4355.Location = New System.Drawing.Point(340, 566)
        Me.lbD4355.Name = "lbD4355"
        Me.lbD4355.Size = New System.Drawing.Size(78, 35)
        Me.lbD4355.TabIndex = 196
        Me.lbD4355.Text = "1"
        Me.lbD4355.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Gray
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(212, 566)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(128, 35)
        Me.Label37.TabIndex = 195
        Me.Label37.Text = "D4355"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4305
        '
        Me.lbD4305.BackColor = System.Drawing.Color.Gray
        Me.lbD4305.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4305.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4305.ForeColor = System.Drawing.Color.White
        Me.lbD4305.Location = New System.Drawing.Point(134, 566)
        Me.lbD4305.Name = "lbD4305"
        Me.lbD4305.Size = New System.Drawing.Size(78, 35)
        Me.lbD4305.TabIndex = 194
        Me.lbD4305.Text = "1"
        Me.lbD4305.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4305
        '
        Me.lbTitleD4305.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4305.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4305.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4305.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4305.Location = New System.Drawing.Point(6, 566)
        Me.lbTitleD4305.Name = "lbTitleD4305"
        Me.lbTitleD4305.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4305.TabIndex = 193
        Me.lbTitleD4305.Text = "D4305"
        Me.lbTitleD4305.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4354
        '
        Me.lbD4354.BackColor = System.Drawing.Color.Gray
        Me.lbD4354.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4354.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4354.ForeColor = System.Drawing.Color.White
        Me.lbD4354.Location = New System.Drawing.Point(340, 531)
        Me.lbD4354.Name = "lbD4354"
        Me.lbD4354.Size = New System.Drawing.Size(78, 35)
        Me.lbD4354.TabIndex = 192
        Me.lbD4354.Text = "1"
        Me.lbD4354.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Gray
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(212, 531)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(128, 35)
        Me.Label41.TabIndex = 191
        Me.Label41.Text = "D4354"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4304
        '
        Me.lbD4304.BackColor = System.Drawing.Color.Gray
        Me.lbD4304.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4304.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4304.ForeColor = System.Drawing.Color.White
        Me.lbD4304.Location = New System.Drawing.Point(134, 531)
        Me.lbD4304.Name = "lbD4304"
        Me.lbD4304.Size = New System.Drawing.Size(78, 35)
        Me.lbD4304.TabIndex = 190
        Me.lbD4304.Text = "1"
        Me.lbD4304.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4304
        '
        Me.lbTitleD4304.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4304.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4304.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4304.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4304.Location = New System.Drawing.Point(6, 531)
        Me.lbTitleD4304.Name = "lbTitleD4304"
        Me.lbTitleD4304.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4304.TabIndex = 189
        Me.lbTitleD4304.Text = "D4304"
        Me.lbTitleD4304.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4353
        '
        Me.lbD4353.BackColor = System.Drawing.Color.Gray
        Me.lbD4353.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4353.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4353.ForeColor = System.Drawing.Color.White
        Me.lbD4353.Location = New System.Drawing.Point(340, 496)
        Me.lbD4353.Name = "lbD4353"
        Me.lbD4353.Size = New System.Drawing.Size(78, 35)
        Me.lbD4353.TabIndex = 188
        Me.lbD4353.Text = "1"
        Me.lbD4353.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Gray
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(212, 496)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(128, 35)
        Me.Label45.TabIndex = 187
        Me.Label45.Text = "D4353"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4303
        '
        Me.lbD4303.BackColor = System.Drawing.Color.Gray
        Me.lbD4303.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4303.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4303.ForeColor = System.Drawing.Color.White
        Me.lbD4303.Location = New System.Drawing.Point(134, 496)
        Me.lbD4303.Name = "lbD4303"
        Me.lbD4303.Size = New System.Drawing.Size(78, 35)
        Me.lbD4303.TabIndex = 186
        Me.lbD4303.Text = "1"
        Me.lbD4303.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4303
        '
        Me.lbTitleD4303.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4303.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4303.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4303.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4303.Location = New System.Drawing.Point(6, 496)
        Me.lbTitleD4303.Name = "lbTitleD4303"
        Me.lbTitleD4303.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4303.TabIndex = 185
        Me.lbTitleD4303.Text = "D4303"
        Me.lbTitleD4303.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4352
        '
        Me.lbD4352.BackColor = System.Drawing.Color.Gray
        Me.lbD4352.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4352.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4352.ForeColor = System.Drawing.Color.White
        Me.lbD4352.Location = New System.Drawing.Point(340, 461)
        Me.lbD4352.Name = "lbD4352"
        Me.lbD4352.Size = New System.Drawing.Size(78, 35)
        Me.lbD4352.TabIndex = 184
        Me.lbD4352.Text = "1"
        Me.lbD4352.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Gray
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label49.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.White
        Me.Label49.Location = New System.Drawing.Point(212, 461)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(128, 35)
        Me.Label49.TabIndex = 183
        Me.Label49.Text = "D4352"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4302
        '
        Me.lbD4302.BackColor = System.Drawing.Color.Gray
        Me.lbD4302.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4302.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4302.ForeColor = System.Drawing.Color.White
        Me.lbD4302.Location = New System.Drawing.Point(134, 461)
        Me.lbD4302.Name = "lbD4302"
        Me.lbD4302.Size = New System.Drawing.Size(78, 35)
        Me.lbD4302.TabIndex = 182
        Me.lbD4302.Text = "1"
        Me.lbD4302.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4302
        '
        Me.lbTitleD4302.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4302.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4302.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4302.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4302.Location = New System.Drawing.Point(6, 461)
        Me.lbTitleD4302.Name = "lbTitleD4302"
        Me.lbTitleD4302.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4302.TabIndex = 181
        Me.lbTitleD4302.Text = "D4302"
        Me.lbTitleD4302.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4351
        '
        Me.lbD4351.BackColor = System.Drawing.Color.Gray
        Me.lbD4351.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4351.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4351.ForeColor = System.Drawing.Color.White
        Me.lbD4351.Location = New System.Drawing.Point(340, 426)
        Me.lbD4351.Name = "lbD4351"
        Me.lbD4351.Size = New System.Drawing.Size(78, 35)
        Me.lbD4351.TabIndex = 180
        Me.lbD4351.Text = "1"
        Me.lbD4351.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Gray
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.White
        Me.Label53.Location = New System.Drawing.Point(212, 426)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(128, 35)
        Me.Label53.TabIndex = 179
        Me.Label53.Text = "D4351"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4301
        '
        Me.lbD4301.BackColor = System.Drawing.Color.Gray
        Me.lbD4301.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4301.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4301.ForeColor = System.Drawing.Color.White
        Me.lbD4301.Location = New System.Drawing.Point(134, 426)
        Me.lbD4301.Name = "lbD4301"
        Me.lbD4301.Size = New System.Drawing.Size(78, 35)
        Me.lbD4301.TabIndex = 178
        Me.lbD4301.Text = "1"
        Me.lbD4301.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4301
        '
        Me.lbTitleD4301.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4301.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4301.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4301.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4301.Location = New System.Drawing.Point(6, 426)
        Me.lbTitleD4301.Name = "lbTitleD4301"
        Me.lbTitleD4301.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4301.TabIndex = 177
        Me.lbTitleD4301.Text = "D4301"
        Me.lbTitleD4301.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4350
        '
        Me.lbD4350.BackColor = System.Drawing.Color.Gray
        Me.lbD4350.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4350.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4350.ForeColor = System.Drawing.Color.White
        Me.lbD4350.Location = New System.Drawing.Point(340, 391)
        Me.lbD4350.Name = "lbD4350"
        Me.lbD4350.Size = New System.Drawing.Size(78, 35)
        Me.lbD4350.TabIndex = 176
        Me.lbD4350.Text = "1"
        Me.lbD4350.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Gray
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label57.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.White
        Me.Label57.Location = New System.Drawing.Point(212, 391)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(128, 35)
        Me.Label57.TabIndex = 175
        Me.Label57.Text = "D4350"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4300
        '
        Me.lbD4300.BackColor = System.Drawing.Color.Gray
        Me.lbD4300.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4300.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4300.ForeColor = System.Drawing.Color.White
        Me.lbD4300.Location = New System.Drawing.Point(134, 391)
        Me.lbD4300.Name = "lbD4300"
        Me.lbD4300.Size = New System.Drawing.Size(78, 35)
        Me.lbD4300.TabIndex = 174
        Me.lbD4300.Text = "1"
        Me.lbD4300.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4300
        '
        Me.lbTitleD4300.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4300.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4300.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4300.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4300.Location = New System.Drawing.Point(6, 391)
        Me.lbTitleD4300.Name = "lbTitleD4300"
        Me.lbTitleD4300.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4300.TabIndex = 173
        Me.lbTitleD4300.Text = "D4300"
        Me.lbTitleD4300.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbStepL
        '
        Me.srclbStepL.BackColor = System.Drawing.Color.Gray
        Me.srclbStepL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbStepL.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbStepL.ForeColor = System.Drawing.Color.White
        Me.srclbStepL.Location = New System.Drawing.Point(304, 9)
        Me.srclbStepL.Name = "srclbStepL"
        Me.srclbStepL.Size = New System.Drawing.Size(57, 32)
        Me.srclbStepL.TabIndex = 172
        Me.srclbStepL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPlcConnectionState
        '
        Me.srcLbPlcConnectionState.BackColor = System.Drawing.Color.Gray
        Me.srcLbPlcConnectionState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPlcConnectionState.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcLbPlcConnectionState.ForeColor = System.Drawing.Color.White
        Me.srcLbPlcConnectionState.Location = New System.Drawing.Point(212, 9)
        Me.srcLbPlcConnectionState.Name = "srcLbPlcConnectionState"
        Me.srcLbPlcConnectionState.Size = New System.Drawing.Size(92, 32)
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
        Me.Label11.Size = New System.Drawing.Size(206, 32)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "192.168.0.105"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4259
        '
        Me.lbD4259.BackColor = System.Drawing.Color.Gray
        Me.lbD4259.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4259.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4259.ForeColor = System.Drawing.Color.White
        Me.lbD4259.Location = New System.Drawing.Point(340, 356)
        Me.lbD4259.Name = "lbD4259"
        Me.lbD4259.Size = New System.Drawing.Size(78, 35)
        Me.lbD4259.TabIndex = 169
        Me.lbD4259.Text = "1"
        Me.lbD4259.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4259
        '
        Me.lbTitleD4259.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4259.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4259.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4259.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4259.Location = New System.Drawing.Point(212, 356)
        Me.lbTitleD4259.Name = "lbTitleD4259"
        Me.lbTitleD4259.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4259.TabIndex = 168
        Me.lbTitleD4259.Text = "D4259"
        Me.lbTitleD4259.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4209
        '
        Me.lbD4209.BackColor = System.Drawing.Color.Gray
        Me.lbD4209.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4209.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4209.ForeColor = System.Drawing.Color.White
        Me.lbD4209.Location = New System.Drawing.Point(134, 356)
        Me.lbD4209.Name = "lbD4209"
        Me.lbD4209.Size = New System.Drawing.Size(78, 35)
        Me.lbD4209.TabIndex = 167
        Me.lbD4209.Text = "1"
        Me.lbD4209.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4209
        '
        Me.lbTitleD4209.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4209.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4209.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4209.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4209.Location = New System.Drawing.Point(6, 356)
        Me.lbTitleD4209.Name = "lbTitleD4209"
        Me.lbTitleD4209.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4209.TabIndex = 166
        Me.lbTitleD4209.Text = "D4209"
        Me.lbTitleD4209.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4258
        '
        Me.lbD4258.BackColor = System.Drawing.Color.Gray
        Me.lbD4258.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4258.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4258.ForeColor = System.Drawing.Color.White
        Me.lbD4258.Location = New System.Drawing.Point(340, 321)
        Me.lbD4258.Name = "lbD4258"
        Me.lbD4258.Size = New System.Drawing.Size(78, 35)
        Me.lbD4258.TabIndex = 165
        Me.lbD4258.Text = "1"
        Me.lbD4258.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4258
        '
        Me.lbTitleD4258.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4258.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4258.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4258.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4258.Location = New System.Drawing.Point(212, 321)
        Me.lbTitleD4258.Name = "lbTitleD4258"
        Me.lbTitleD4258.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4258.TabIndex = 164
        Me.lbTitleD4258.Text = "D4258"
        Me.lbTitleD4258.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4208
        '
        Me.lbD4208.BackColor = System.Drawing.Color.Gray
        Me.lbD4208.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4208.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4208.ForeColor = System.Drawing.Color.White
        Me.lbD4208.Location = New System.Drawing.Point(134, 321)
        Me.lbD4208.Name = "lbD4208"
        Me.lbD4208.Size = New System.Drawing.Size(78, 35)
        Me.lbD4208.TabIndex = 163
        Me.lbD4208.Text = "1"
        Me.lbD4208.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4208
        '
        Me.lbTitleD4208.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4208.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4208.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4208.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4208.Location = New System.Drawing.Point(6, 321)
        Me.lbTitleD4208.Name = "lbTitleD4208"
        Me.lbTitleD4208.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4208.TabIndex = 162
        Me.lbTitleD4208.Text = "D4208"
        Me.lbTitleD4208.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4257
        '
        Me.lbD4257.BackColor = System.Drawing.Color.Gray
        Me.lbD4257.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4257.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4257.ForeColor = System.Drawing.Color.White
        Me.lbD4257.Location = New System.Drawing.Point(340, 286)
        Me.lbD4257.Name = "lbD4257"
        Me.lbD4257.Size = New System.Drawing.Size(78, 35)
        Me.lbD4257.TabIndex = 161
        Me.lbD4257.Text = "1"
        Me.lbD4257.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4257
        '
        Me.lbTitleD4257.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4257.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4257.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4257.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4257.Location = New System.Drawing.Point(212, 286)
        Me.lbTitleD4257.Name = "lbTitleD4257"
        Me.lbTitleD4257.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4257.TabIndex = 160
        Me.lbTitleD4257.Text = "D4257"
        Me.lbTitleD4257.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4207
        '
        Me.lbD4207.BackColor = System.Drawing.Color.Gray
        Me.lbD4207.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4207.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4207.ForeColor = System.Drawing.Color.White
        Me.lbD4207.Location = New System.Drawing.Point(134, 286)
        Me.lbD4207.Name = "lbD4207"
        Me.lbD4207.Size = New System.Drawing.Size(78, 35)
        Me.lbD4207.TabIndex = 159
        Me.lbD4207.Text = "1"
        Me.lbD4207.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4207
        '
        Me.lbTitleD4207.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4207.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4207.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4207.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4207.Location = New System.Drawing.Point(6, 286)
        Me.lbTitleD4207.Name = "lbTitleD4207"
        Me.lbTitleD4207.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4207.TabIndex = 158
        Me.lbTitleD4207.Text = "D4207"
        Me.lbTitleD4207.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4256
        '
        Me.lbD4256.BackColor = System.Drawing.Color.Gray
        Me.lbD4256.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4256.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4256.ForeColor = System.Drawing.Color.White
        Me.lbD4256.Location = New System.Drawing.Point(340, 251)
        Me.lbD4256.Name = "lbD4256"
        Me.lbD4256.Size = New System.Drawing.Size(78, 35)
        Me.lbD4256.TabIndex = 157
        Me.lbD4256.Text = "1"
        Me.lbD4256.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4256
        '
        Me.lbTitleD4256.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4256.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4256.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4256.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4256.Location = New System.Drawing.Point(212, 251)
        Me.lbTitleD4256.Name = "lbTitleD4256"
        Me.lbTitleD4256.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4256.TabIndex = 156
        Me.lbTitleD4256.Text = "D4256"
        Me.lbTitleD4256.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4206
        '
        Me.lbD4206.BackColor = System.Drawing.Color.Gray
        Me.lbD4206.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4206.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4206.ForeColor = System.Drawing.Color.White
        Me.lbD4206.Location = New System.Drawing.Point(134, 251)
        Me.lbD4206.Name = "lbD4206"
        Me.lbD4206.Size = New System.Drawing.Size(78, 35)
        Me.lbD4206.TabIndex = 155
        Me.lbD4206.Text = "1"
        Me.lbD4206.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4206
        '
        Me.lbTitleD4206.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4206.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4206.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4206.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4206.Location = New System.Drawing.Point(6, 251)
        Me.lbTitleD4206.Name = "lbTitleD4206"
        Me.lbTitleD4206.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4206.TabIndex = 154
        Me.lbTitleD4206.Text = "D4206"
        Me.lbTitleD4206.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4255
        '
        Me.lbD4255.BackColor = System.Drawing.Color.Gray
        Me.lbD4255.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4255.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4255.ForeColor = System.Drawing.Color.White
        Me.lbD4255.Location = New System.Drawing.Point(340, 216)
        Me.lbD4255.Name = "lbD4255"
        Me.lbD4255.Size = New System.Drawing.Size(78, 35)
        Me.lbD4255.TabIndex = 153
        Me.lbD4255.Text = "1"
        Me.lbD4255.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4255
        '
        Me.lbTitleD4255.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4255.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4255.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4255.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4255.Location = New System.Drawing.Point(212, 216)
        Me.lbTitleD4255.Name = "lbTitleD4255"
        Me.lbTitleD4255.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4255.TabIndex = 152
        Me.lbTitleD4255.Text = "D4255"
        Me.lbTitleD4255.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4205
        '
        Me.lbD4205.BackColor = System.Drawing.Color.Gray
        Me.lbD4205.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4205.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4205.ForeColor = System.Drawing.Color.White
        Me.lbD4205.Location = New System.Drawing.Point(134, 216)
        Me.lbD4205.Name = "lbD4205"
        Me.lbD4205.Size = New System.Drawing.Size(78, 35)
        Me.lbD4205.TabIndex = 151
        Me.lbD4205.Text = "1"
        Me.lbD4205.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4205
        '
        Me.lbTitleD4205.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4205.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4205.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4205.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4205.Location = New System.Drawing.Point(6, 216)
        Me.lbTitleD4205.Name = "lbTitleD4205"
        Me.lbTitleD4205.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4205.TabIndex = 150
        Me.lbTitleD4205.Text = "D4205"
        Me.lbTitleD4205.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4254
        '
        Me.lbD4254.BackColor = System.Drawing.Color.Gray
        Me.lbD4254.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4254.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4254.ForeColor = System.Drawing.Color.White
        Me.lbD4254.Location = New System.Drawing.Point(340, 181)
        Me.lbD4254.Name = "lbD4254"
        Me.lbD4254.Size = New System.Drawing.Size(78, 35)
        Me.lbD4254.TabIndex = 149
        Me.lbD4254.Text = "1"
        Me.lbD4254.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4254
        '
        Me.lbTitleD4254.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4254.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4254.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4254.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4254.Location = New System.Drawing.Point(212, 181)
        Me.lbTitleD4254.Name = "lbTitleD4254"
        Me.lbTitleD4254.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4254.TabIndex = 148
        Me.lbTitleD4254.Text = "D4254"
        Me.lbTitleD4254.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4204
        '
        Me.lbD4204.BackColor = System.Drawing.Color.Gray
        Me.lbD4204.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4204.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4204.ForeColor = System.Drawing.Color.White
        Me.lbD4204.Location = New System.Drawing.Point(134, 181)
        Me.lbD4204.Name = "lbD4204"
        Me.lbD4204.Size = New System.Drawing.Size(78, 35)
        Me.lbD4204.TabIndex = 147
        Me.lbD4204.Text = "1"
        Me.lbD4204.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4204
        '
        Me.lbTitleD4204.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4204.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4204.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4204.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4204.Location = New System.Drawing.Point(6, 181)
        Me.lbTitleD4204.Name = "lbTitleD4204"
        Me.lbTitleD4204.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4204.TabIndex = 146
        Me.lbTitleD4204.Text = "D4204"
        Me.lbTitleD4204.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4253
        '
        Me.lbD4253.BackColor = System.Drawing.Color.Gray
        Me.lbD4253.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4253.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4253.ForeColor = System.Drawing.Color.White
        Me.lbD4253.Location = New System.Drawing.Point(340, 146)
        Me.lbD4253.Name = "lbD4253"
        Me.lbD4253.Size = New System.Drawing.Size(78, 35)
        Me.lbD4253.TabIndex = 145
        Me.lbD4253.Text = "1"
        Me.lbD4253.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4253
        '
        Me.lbTitleD4253.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4253.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4253.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4253.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4253.Location = New System.Drawing.Point(212, 146)
        Me.lbTitleD4253.Name = "lbTitleD4253"
        Me.lbTitleD4253.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4253.TabIndex = 144
        Me.lbTitleD4253.Text = "D4253"
        Me.lbTitleD4253.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4203
        '
        Me.lbD4203.BackColor = System.Drawing.Color.Gray
        Me.lbD4203.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4203.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4203.ForeColor = System.Drawing.Color.White
        Me.lbD4203.Location = New System.Drawing.Point(134, 146)
        Me.lbD4203.Name = "lbD4203"
        Me.lbD4203.Size = New System.Drawing.Size(78, 35)
        Me.lbD4203.TabIndex = 143
        Me.lbD4203.Text = "1"
        Me.lbD4203.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4203
        '
        Me.lbTitleD4203.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4203.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4203.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4203.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4203.Location = New System.Drawing.Point(6, 146)
        Me.lbTitleD4203.Name = "lbTitleD4203"
        Me.lbTitleD4203.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4203.TabIndex = 142
        Me.lbTitleD4203.Text = "D4203"
        Me.lbTitleD4203.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4252
        '
        Me.lbD4252.BackColor = System.Drawing.Color.Gray
        Me.lbD4252.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4252.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4252.ForeColor = System.Drawing.Color.White
        Me.lbD4252.Location = New System.Drawing.Point(340, 111)
        Me.lbD4252.Name = "lbD4252"
        Me.lbD4252.Size = New System.Drawing.Size(78, 35)
        Me.lbD4252.TabIndex = 141
        Me.lbD4252.Text = "1"
        Me.lbD4252.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4252
        '
        Me.lbTitleD4252.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4252.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4252.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4252.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4252.Location = New System.Drawing.Point(212, 111)
        Me.lbTitleD4252.Name = "lbTitleD4252"
        Me.lbTitleD4252.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4252.TabIndex = 140
        Me.lbTitleD4252.Text = "D4252"
        Me.lbTitleD4252.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4202
        '
        Me.lbD4202.BackColor = System.Drawing.Color.Gray
        Me.lbD4202.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4202.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4202.ForeColor = System.Drawing.Color.White
        Me.lbD4202.Location = New System.Drawing.Point(134, 111)
        Me.lbD4202.Name = "lbD4202"
        Me.lbD4202.Size = New System.Drawing.Size(78, 35)
        Me.lbD4202.TabIndex = 139
        Me.lbD4202.Text = "1"
        Me.lbD4202.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4202
        '
        Me.lbTitleD4202.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4202.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4202.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4202.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4202.Location = New System.Drawing.Point(6, 111)
        Me.lbTitleD4202.Name = "lbTitleD4202"
        Me.lbTitleD4202.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4202.TabIndex = 138
        Me.lbTitleD4202.Text = "D4202"
        Me.lbTitleD4202.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4251
        '
        Me.lbD4251.BackColor = System.Drawing.Color.Gray
        Me.lbD4251.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4251.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4251.ForeColor = System.Drawing.Color.White
        Me.lbD4251.Location = New System.Drawing.Point(340, 76)
        Me.lbD4251.Name = "lbD4251"
        Me.lbD4251.Size = New System.Drawing.Size(78, 35)
        Me.lbD4251.TabIndex = 137
        Me.lbD4251.Text = "1"
        Me.lbD4251.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4251
        '
        Me.lbTitleD4251.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4251.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4251.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4251.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4251.Location = New System.Drawing.Point(212, 76)
        Me.lbTitleD4251.Name = "lbTitleD4251"
        Me.lbTitleD4251.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4251.TabIndex = 136
        Me.lbTitleD4251.Text = "D4251"
        Me.lbTitleD4251.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4201
        '
        Me.lbD4201.BackColor = System.Drawing.Color.Gray
        Me.lbD4201.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4201.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4201.ForeColor = System.Drawing.Color.White
        Me.lbD4201.Location = New System.Drawing.Point(134, 76)
        Me.lbD4201.Name = "lbD4201"
        Me.lbD4201.Size = New System.Drawing.Size(78, 35)
        Me.lbD4201.TabIndex = 135
        Me.lbD4201.Text = "1"
        Me.lbD4201.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4201
        '
        Me.lbTitleD4201.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4201.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4201.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4201.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4201.Location = New System.Drawing.Point(6, 76)
        Me.lbTitleD4201.Name = "lbTitleD4201"
        Me.lbTitleD4201.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4201.TabIndex = 134
        Me.lbTitleD4201.Text = "D4201"
        Me.lbTitleD4201.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4250
        '
        Me.lbD4250.BackColor = System.Drawing.Color.Gray
        Me.lbD4250.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4250.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4250.ForeColor = System.Drawing.Color.White
        Me.lbD4250.Location = New System.Drawing.Point(340, 41)
        Me.lbD4250.Name = "lbD4250"
        Me.lbD4250.Size = New System.Drawing.Size(78, 35)
        Me.lbD4250.TabIndex = 133
        Me.lbD4250.Text = "1"
        Me.lbD4250.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4250
        '
        Me.lbTitleD4250.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4250.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4250.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4250.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4250.Location = New System.Drawing.Point(212, 41)
        Me.lbTitleD4250.Name = "lbTitleD4250"
        Me.lbTitleD4250.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4250.TabIndex = 132
        Me.lbTitleD4250.Text = "D4250"
        Me.lbTitleD4250.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbD4200
        '
        Me.lbD4200.BackColor = System.Drawing.Color.Gray
        Me.lbD4200.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbD4200.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbD4200.ForeColor = System.Drawing.Color.White
        Me.lbD4200.Location = New System.Drawing.Point(134, 41)
        Me.lbD4200.Name = "lbD4200"
        Me.lbD4200.Size = New System.Drawing.Size(78, 35)
        Me.lbD4200.TabIndex = 131
        Me.lbD4200.Text = "1"
        Me.lbD4200.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTitleD4200
        '
        Me.lbTitleD4200.BackColor = System.Drawing.Color.Gray
        Me.lbTitleD4200.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbTitleD4200.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitleD4200.ForeColor = System.Drawing.Color.White
        Me.lbTitleD4200.Location = New System.Drawing.Point(6, 41)
        Me.lbTitleD4200.Name = "lbTitleD4200"
        Me.lbTitleD4200.Size = New System.Drawing.Size(128, 35)
        Me.lbTitleD4200.TabIndex = 130
        Me.lbTitleD4200.Text = "D4200"
        Me.lbTitleD4200.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMessage
        '
        Me.txtMessage.BackColor = System.Drawing.Color.Black
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.Enabled = False
        Me.txtMessage.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.txtMessage.ForeColor = System.Drawing.Color.White
        Me.txtMessage.Location = New System.Drawing.Point(1493, 889)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(424, 160)
        Me.txtMessage.TabIndex = 51
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
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(0, 573)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(746, 38)
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
        Me.Label3.Text = "RS4 FRT BACK ASSEMBLE SYSTEM OP02_2"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 41)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1917, 59)
        Me.Panel3.TabIndex = 119
        '
        'Tmr_Connect
        '
        '
        'tmr_Tool1
        '
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
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Gray
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(746, 573)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(746, 38)
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
        'srclbDecSabBarcodeL
        '
        Me.srclbDecSabBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDecSabBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecSabBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecSabBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDecSabBarcodeL.Location = New System.Drawing.Point(315, 654)
        Me.srclbDecSabBarcodeL.Name = "srclbDecSabBarcodeL"
        Me.srclbDecSabBarcodeL.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecSabBarcodeL.TabIndex = 169
        Me.srclbDecSabBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataSabBarcodeL
        '
        Me.srclbDataSabBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDataSabBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataSabBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataSabBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDataSabBarcodeL.Location = New System.Drawing.Point(151, 654)
        Me.srclbDataSabBarcodeL.Name = "srclbDataSabBarcodeL"
        Me.srclbDataSabBarcodeL.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataSabBarcodeL.TabIndex = 168
        Me.srclbDataSabBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Black
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(90, 654)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 43)
        Me.Label17.TabIndex = 167
        Me.Label17.Text = "입력"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetSabBarcodeL
        '
        Me.srclbTargetSabBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetSabBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetSabBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetSabBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetSabBarcodeL.Location = New System.Drawing.Point(151, 611)
        Me.srclbTargetSabBarcodeL.Name = "srclbTargetSabBarcodeL"
        Me.srclbTargetSabBarcodeL.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetSabBarcodeL.TabIndex = 166
        Me.srclbTargetSabBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Black
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(90, 611)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(61, 43)
        Me.Label26.TabIndex = 165
        Me.Label26.Text = "목표"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Black
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(0, 611)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(90, 86)
        Me.Label27.TabIndex = 164
        Me.Label27.Text = "SAB1 BARCODE"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Black
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(90, 740)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(61, 43)
        Me.Label35.TabIndex = 184
        Me.Label35.Text = "입력"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Black
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(90, 697)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(61, 43)
        Me.Label38.TabIndex = 182
        Me.Label38.Text = "목표"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Black
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(0, 697)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(90, 86)
        Me.Label39.TabIndex = 181
        Me.Label39.Text = "SAB1 T/Q"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Black
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(373, 887)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 86)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "SAB1 RESIST"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label13.Visible = False
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Black
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(463, 930)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(61, 43)
        Me.Label43.TabIndex = 191
        Me.Label43.Text = "DATA"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label43.Visible = False
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Black
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label46.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(463, 887)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(61, 43)
        Me.Label46.TabIndex = 189
        Me.Label46.Text = "TARGET"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label46.Visible = False
        '
        'srclbDecSabTqL
        '
        Me.srclbDecSabTqL.BackColor = System.Drawing.Color.Black
        Me.srclbDecSabTqL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecSabTqL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecSabTqL.ForeColor = System.Drawing.Color.White
        Me.srclbDecSabTqL.Location = New System.Drawing.Point(315, 740)
        Me.srclbDecSabTqL.Name = "srclbDecSabTqL"
        Me.srclbDecSabTqL.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecSabTqL.TabIndex = 208
        Me.srclbDecSabTqL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataSabTQ1L
        '
        Me.srclbDataSabTQ1L.BackColor = System.Drawing.Color.Black
        Me.srclbDataSabTQ1L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataSabTQ1L.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataSabTQ1L.ForeColor = System.Drawing.Color.White
        Me.srclbDataSabTQ1L.Location = New System.Drawing.Point(151, 740)
        Me.srclbDataSabTQ1L.Name = "srclbDataSabTQ1L"
        Me.srclbDataSabTQ1L.Size = New System.Drawing.Size(82, 43)
        Me.srclbDataSabTQ1L.TabIndex = 207
        Me.srclbDataSabTQ1L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetSabTqL
        '
        Me.srclbTargetSabTqL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetSabTqL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetSabTqL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetSabTqL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetSabTqL.Location = New System.Drawing.Point(151, 697)
        Me.srclbTargetSabTqL.Name = "srclbTargetSabTqL"
        Me.srclbTargetSabTqL.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetSabTqL.TabIndex = 206
        Me.srclbTargetSabTqL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataSabTQ2L
        '
        Me.srclbDataSabTQ2L.BackColor = System.Drawing.Color.Black
        Me.srclbDataSabTQ2L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataSabTQ2L.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataSabTQ2L.ForeColor = System.Drawing.Color.White
        Me.srclbDataSabTQ2L.Location = New System.Drawing.Point(233, 740)
        Me.srclbDataSabTQ2L.Name = "srclbDataSabTQ2L"
        Me.srclbDataSabTQ2L.Size = New System.Drawing.Size(82, 43)
        Me.srclbDataSabTQ2L.TabIndex = 209
        Me.srclbDataSabTQ2L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecSabResistL
        '
        Me.srclbDecSabResistL.BackColor = System.Drawing.Color.Black
        Me.srclbDecSabResistL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecSabResistL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecSabResistL.ForeColor = System.Drawing.Color.White
        Me.srclbDecSabResistL.Location = New System.Drawing.Point(688, 930)
        Me.srclbDecSabResistL.Name = "srclbDecSabResistL"
        Me.srclbDecSabResistL.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecSabResistL.TabIndex = 212
        Me.srclbDecSabResistL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbDecSabResistL.Visible = False
        '
        'srclbDataSabResistL
        '
        Me.srclbDataSabResistL.BackColor = System.Drawing.Color.Black
        Me.srclbDataSabResistL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataSabResistL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataSabResistL.ForeColor = System.Drawing.Color.White
        Me.srclbDataSabResistL.Location = New System.Drawing.Point(524, 930)
        Me.srclbDataSabResistL.Name = "srclbDataSabResistL"
        Me.srclbDataSabResistL.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataSabResistL.TabIndex = 211
        Me.srclbDataSabResistL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbDataSabResistL.Visible = False
        '
        'srclbTargetSabResistL
        '
        Me.srclbTargetSabResistL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetSabResistL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetSabResistL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetSabResistL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetSabResistL.Location = New System.Drawing.Point(524, 887)
        Me.srclbTargetSabResistL.Name = "srclbTargetSabResistL"
        Me.srclbTargetSabResistL.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetSabResistL.TabIndex = 210
        Me.srclbTargetSabResistL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbTargetSabResistL.Visible = False
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Black
        Me.Label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label64.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label64.ForeColor = System.Drawing.Color.White
        Me.Label64.Location = New System.Drawing.Point(0, 783)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(90, 86)
        Me.Label64.TabIndex = 235
        Me.Label64.Text = "AIRTOOL"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecAirToolL
        '
        Me.srclbDecAirToolL.BackColor = System.Drawing.Color.Black
        Me.srclbDecAirToolL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecAirToolL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecAirToolL.ForeColor = System.Drawing.Color.White
        Me.srclbDecAirToolL.Location = New System.Drawing.Point(315, 826)
        Me.srclbDecAirToolL.Name = "srclbDecAirToolL"
        Me.srclbDecAirToolL.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecAirToolL.TabIndex = 248
        Me.srclbDecAirToolL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataAirToolL
        '
        Me.srclbDataAirToolL.BackColor = System.Drawing.Color.Black
        Me.srclbDataAirToolL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataAirToolL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataAirToolL.ForeColor = System.Drawing.Color.White
        Me.srclbDataAirToolL.Location = New System.Drawing.Point(151, 826)
        Me.srclbDataAirToolL.Name = "srclbDataAirToolL"
        Me.srclbDataAirToolL.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataAirToolL.TabIndex = 247
        Me.srclbDataAirToolL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetAirToolL
        '
        Me.srclbTargetAirToolL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetAirToolL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetAirToolL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetAirToolL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetAirToolL.Location = New System.Drawing.Point(151, 783)
        Me.srclbTargetAirToolL.Name = "srclbTargetAirToolL"
        Me.srclbTargetAirToolL.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetAirToolL.TabIndex = 246
        Me.srclbTargetAirToolL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecMotorBarcodeL
        '
        Me.srclbDecMotorBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDecMotorBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecMotorBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecMotorBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDecMotorBarcodeL.Location = New System.Drawing.Point(688, 654)
        Me.srclbDecMotorBarcodeL.Name = "srclbDecMotorBarcodeL"
        Me.srclbDecMotorBarcodeL.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecMotorBarcodeL.TabIndex = 244
        Me.srclbDecMotorBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataMotorBarcodeL
        '
        Me.srclbDataMotorBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDataMotorBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataMotorBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataMotorBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDataMotorBarcodeL.Location = New System.Drawing.Point(524, 654)
        Me.srclbDataMotorBarcodeL.Name = "srclbDataMotorBarcodeL"
        Me.srclbDataMotorBarcodeL.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataMotorBarcodeL.TabIndex = 243
        Me.srclbDataMotorBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetMotorBarcodeL
        '
        Me.srclbTargetMotorBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetMotorBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetMotorBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetMotorBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetMotorBarcodeL.Location = New System.Drawing.Point(524, 611)
        Me.srclbTargetMotorBarcodeL.Name = "srclbTargetMotorBarcodeL"
        Me.srclbTargetMotorBarcodeL.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetMotorBarcodeL.TabIndex = 241
        Me.srclbTargetMotorBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.Black
        Me.Label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label75.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label75.ForeColor = System.Drawing.Color.White
        Me.Label75.Location = New System.Drawing.Point(90, 826)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(61, 43)
        Me.Label75.TabIndex = 255
        Me.Label75.Text = "입력"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecMotorTqL
        '
        Me.srclbDecMotorTqL.BackColor = System.Drawing.Color.Black
        Me.srclbDecMotorTqL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecMotorTqL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecMotorTqL.ForeColor = System.Drawing.Color.White
        Me.srclbDecMotorTqL.Location = New System.Drawing.Point(688, 740)
        Me.srclbDecMotorTqL.Name = "srclbDecMotorTqL"
        Me.srclbDecMotorTqL.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecMotorTqL.TabIndex = 254
        Me.srclbDecMotorTqL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbdataMotorTqL
        '
        Me.srclbdataMotorTqL.BackColor = System.Drawing.Color.Black
        Me.srclbdataMotorTqL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbdataMotorTqL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbdataMotorTqL.ForeColor = System.Drawing.Color.White
        Me.srclbdataMotorTqL.Location = New System.Drawing.Point(524, 740)
        Me.srclbdataMotorTqL.Name = "srclbdataMotorTqL"
        Me.srclbdataMotorTqL.Size = New System.Drawing.Size(164, 43)
        Me.srclbdataMotorTqL.TabIndex = 253
        Me.srclbdataMotorTqL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetMotorTqL
        '
        Me.srclbTargetMotorTqL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetMotorTqL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetMotorTqL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetMotorTqL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetMotorTqL.Location = New System.Drawing.Point(524, 697)
        Me.srclbTargetMotorTqL.Name = "srclbTargetMotorTqL"
        Me.srclbTargetMotorTqL.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetMotorTqL.TabIndex = 252
        Me.srclbTargetMotorTqL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label89
        '
        Me.Label89.BackColor = System.Drawing.Color.Black
        Me.Label89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label89.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label89.ForeColor = System.Drawing.Color.White
        Me.Label89.Location = New System.Drawing.Point(90, 783)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(61, 43)
        Me.Label89.TabIndex = 251
        Me.Label89.Text = "목표"
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.Black
        Me.Label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label67.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label67.ForeColor = System.Drawing.Color.White
        Me.Label67.Location = New System.Drawing.Point(373, 697)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(90, 86)
        Me.Label67.TabIndex = 257
        Me.Label67.Text = "MOTOR T/Q"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.Color.Black
        Me.Label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label74.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label74.ForeColor = System.Drawing.Color.White
        Me.Label74.Location = New System.Drawing.Point(373, 611)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(90, 86)
        Me.Label74.TabIndex = 256
        Me.Label74.Text = "MOTOR BARCODE"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecAirToolR
        '
        Me.srclbDecAirToolR.BackColor = System.Drawing.Color.Black
        Me.srclbDecAirToolR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecAirToolR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecAirToolR.ForeColor = System.Drawing.Color.White
        Me.srclbDecAirToolR.Location = New System.Drawing.Point(1061, 826)
        Me.srclbDecAirToolR.Name = "srclbDecAirToolR"
        Me.srclbDecAirToolR.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecAirToolR.TabIndex = 310
        Me.srclbDecAirToolR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataAirToolR
        '
        Me.srclbDataAirToolR.BackColor = System.Drawing.Color.Black
        Me.srclbDataAirToolR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataAirToolR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataAirToolR.ForeColor = System.Drawing.Color.White
        Me.srclbDataAirToolR.Location = New System.Drawing.Point(897, 826)
        Me.srclbDataAirToolR.Name = "srclbDataAirToolR"
        Me.srclbDataAirToolR.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataAirToolR.TabIndex = 309
        Me.srclbDataAirToolR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetAirToolR
        '
        Me.srclbTargetAirToolR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetAirToolR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetAirToolR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetAirToolR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetAirToolR.Location = New System.Drawing.Point(897, 783)
        Me.srclbTargetAirToolR.Name = "srclbTargetAirToolR"
        Me.srclbTargetAirToolR.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetAirToolR.TabIndex = 308
        Me.srclbTargetAirToolR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label98
        '
        Me.Label98.BackColor = System.Drawing.Color.Black
        Me.Label98.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label98.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label98.ForeColor = System.Drawing.Color.White
        Me.Label98.Location = New System.Drawing.Point(746, 783)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(90, 86)
        Me.Label98.TabIndex = 296
        Me.Label98.Text = "AIRTOOL"
        Me.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDeccSabResistR
        '
        Me.srclbDeccSabResistR.BackColor = System.Drawing.Color.Black
        Me.srclbDeccSabResistR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDeccSabResistR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDeccSabResistR.ForeColor = System.Drawing.Color.White
        Me.srclbDeccSabResistR.Location = New System.Drawing.Point(1434, 1006)
        Me.srclbDeccSabResistR.Name = "srclbDeccSabResistR"
        Me.srclbDeccSabResistR.Size = New System.Drawing.Size(58, 43)
        Me.srclbDeccSabResistR.TabIndex = 295
        Me.srclbDeccSabResistR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbDeccSabResistR.Visible = False
        '
        'srclbDatacSabResistR
        '
        Me.srclbDatacSabResistR.BackColor = System.Drawing.Color.Black
        Me.srclbDatacSabResistR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDatacSabResistR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDatacSabResistR.ForeColor = System.Drawing.Color.White
        Me.srclbDatacSabResistR.Location = New System.Drawing.Point(1270, 1006)
        Me.srclbDatacSabResistR.Name = "srclbDatacSabResistR"
        Me.srclbDatacSabResistR.Size = New System.Drawing.Size(164, 43)
        Me.srclbDatacSabResistR.TabIndex = 294
        Me.srclbDatacSabResistR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbDatacSabResistR.Visible = False
        '
        'srclbTargetcSabResistR
        '
        Me.srclbTargetcSabResistR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetcSabResistR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetcSabResistR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetcSabResistR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetcSabResistR.Location = New System.Drawing.Point(1270, 963)
        Me.srclbTargetcSabResistR.Name = "srclbTargetcSabResistR"
        Me.srclbTargetcSabResistR.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetcSabResistR.TabIndex = 293
        Me.srclbTargetcSabResistR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbTargetcSabResistR.Visible = False
        '
        'srclbDatacSabTQ2R
        '
        Me.srclbDatacSabTQ2R.BackColor = System.Drawing.Color.Black
        Me.srclbDatacSabTQ2R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDatacSabTQ2R.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDatacSabTQ2R.ForeColor = System.Drawing.Color.White
        Me.srclbDatacSabTQ2R.Location = New System.Drawing.Point(1352, 740)
        Me.srclbDatacSabTQ2R.Name = "srclbDatacSabTQ2R"
        Me.srclbDatacSabTQ2R.Size = New System.Drawing.Size(82, 43)
        Me.srclbDatacSabTQ2R.TabIndex = 292
        Me.srclbDatacSabTQ2R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDeccSabTqR
        '
        Me.srclbDeccSabTqR.BackColor = System.Drawing.Color.Black
        Me.srclbDeccSabTqR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDeccSabTqR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDeccSabTqR.ForeColor = System.Drawing.Color.White
        Me.srclbDeccSabTqR.Location = New System.Drawing.Point(1434, 740)
        Me.srclbDeccSabTqR.Name = "srclbDeccSabTqR"
        Me.srclbDeccSabTqR.Size = New System.Drawing.Size(58, 43)
        Me.srclbDeccSabTqR.TabIndex = 291
        Me.srclbDeccSabTqR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDatacSabTQ1R
        '
        Me.srclbDatacSabTQ1R.BackColor = System.Drawing.Color.Black
        Me.srclbDatacSabTQ1R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDatacSabTQ1R.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDatacSabTQ1R.ForeColor = System.Drawing.Color.White
        Me.srclbDatacSabTQ1R.Location = New System.Drawing.Point(1270, 740)
        Me.srclbDatacSabTQ1R.Name = "srclbDatacSabTQ1R"
        Me.srclbDatacSabTQ1R.Size = New System.Drawing.Size(82, 43)
        Me.srclbDatacSabTQ1R.TabIndex = 290
        Me.srclbDatacSabTQ1R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetcSabTqR
        '
        Me.srclbTargetcSabTqR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetcSabTqR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetcSabTqR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetcSabTqR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetcSabTqR.Location = New System.Drawing.Point(1270, 697)
        Me.srclbTargetcSabTqR.Name = "srclbTargetcSabTqR"
        Me.srclbTargetcSabTqR.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetcSabTqR.TabIndex = 289
        Me.srclbTargetcSabTqR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecCSabBarcodeR
        '
        Me.srclbDecCSabBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDecCSabBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecCSabBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecCSabBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDecCSabBarcodeR.Location = New System.Drawing.Point(1434, 654)
        Me.srclbDecCSabBarcodeR.Name = "srclbDecCSabBarcodeR"
        Me.srclbDecCSabBarcodeR.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecCSabBarcodeR.TabIndex = 288
        Me.srclbDecCSabBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataCSabBarcodeR
        '
        Me.srclbDataCSabBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDataCSabBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataCSabBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataCSabBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDataCSabBarcodeR.Location = New System.Drawing.Point(1270, 654)
        Me.srclbDataCSabBarcodeR.Name = "srclbDataCSabBarcodeR"
        Me.srclbDataCSabBarcodeR.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataCSabBarcodeR.TabIndex = 287
        Me.srclbDataCSabBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetCSabBarcodeR
        '
        Me.srclbTargetCSabBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetCSabBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetCSabBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetCSabBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetCSabBarcodeR.Location = New System.Drawing.Point(1270, 611)
        Me.srclbTargetCSabBarcodeR.Name = "srclbTargetCSabBarcodeR"
        Me.srclbTargetCSabBarcodeR.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetCSabBarcodeR.TabIndex = 286
        Me.srclbTargetCSabBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecSabResistR
        '
        Me.srclbDecSabResistR.BackColor = System.Drawing.Color.Black
        Me.srclbDecSabResistR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecSabResistR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecSabResistR.ForeColor = System.Drawing.Color.White
        Me.srclbDecSabResistR.Location = New System.Drawing.Point(1061, 1006)
        Me.srclbDecSabResistR.Name = "srclbDecSabResistR"
        Me.srclbDecSabResistR.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecSabResistR.TabIndex = 285
        Me.srclbDecSabResistR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbDecSabResistR.Visible = False
        '
        'srclbDataSabResistR
        '
        Me.srclbDataSabResistR.BackColor = System.Drawing.Color.Black
        Me.srclbDataSabResistR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataSabResistR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataSabResistR.ForeColor = System.Drawing.Color.White
        Me.srclbDataSabResistR.Location = New System.Drawing.Point(897, 1006)
        Me.srclbDataSabResistR.Name = "srclbDataSabResistR"
        Me.srclbDataSabResistR.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataSabResistR.TabIndex = 284
        Me.srclbDataSabResistR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbDataSabResistR.Visible = False
        '
        'srclbTargetSabResistR
        '
        Me.srclbTargetSabResistR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetSabResistR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetSabResistR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetSabResistR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetSabResistR.Location = New System.Drawing.Point(897, 963)
        Me.srclbTargetSabResistR.Name = "srclbTargetSabResistR"
        Me.srclbTargetSabResistR.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetSabResistR.TabIndex = 283
        Me.srclbTargetSabResistR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbTargetSabResistR.Visible = False
        '
        'srclbDataSabTQ2R
        '
        Me.srclbDataSabTQ2R.BackColor = System.Drawing.Color.Black
        Me.srclbDataSabTQ2R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataSabTQ2R.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataSabTQ2R.ForeColor = System.Drawing.Color.White
        Me.srclbDataSabTQ2R.Location = New System.Drawing.Point(979, 740)
        Me.srclbDataSabTQ2R.Name = "srclbDataSabTQ2R"
        Me.srclbDataSabTQ2R.Size = New System.Drawing.Size(82, 43)
        Me.srclbDataSabTQ2R.TabIndex = 282
        Me.srclbDataSabTQ2R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecSabTqR
        '
        Me.srclbDecSabTqR.BackColor = System.Drawing.Color.Black
        Me.srclbDecSabTqR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecSabTqR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecSabTqR.ForeColor = System.Drawing.Color.White
        Me.srclbDecSabTqR.Location = New System.Drawing.Point(1061, 740)
        Me.srclbDecSabTqR.Name = "srclbDecSabTqR"
        Me.srclbDecSabTqR.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecSabTqR.TabIndex = 281
        Me.srclbDecSabTqR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataSabTQ1R
        '
        Me.srclbDataSabTQ1R.BackColor = System.Drawing.Color.Black
        Me.srclbDataSabTQ1R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataSabTQ1R.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataSabTQ1R.ForeColor = System.Drawing.Color.White
        Me.srclbDataSabTQ1R.Location = New System.Drawing.Point(897, 740)
        Me.srclbDataSabTQ1R.Name = "srclbDataSabTQ1R"
        Me.srclbDataSabTQ1R.Size = New System.Drawing.Size(82, 43)
        Me.srclbDataSabTQ1R.TabIndex = 280
        Me.srclbDataSabTQ1R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetSabTqR
        '
        Me.srclbTargetSabTqR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetSabTqR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetSabTqR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetSabTqR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetSabTqR.Location = New System.Drawing.Point(897, 697)
        Me.srclbTargetSabTqR.Name = "srclbTargetSabTqR"
        Me.srclbTargetSabTqR.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetSabTqR.TabIndex = 279
        Me.srclbTargetSabTqR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label121
        '
        Me.Label121.BackColor = System.Drawing.Color.Black
        Me.Label121.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label121.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label121.ForeColor = System.Drawing.Color.White
        Me.Label121.Location = New System.Drawing.Point(1119, 963)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(90, 86)
        Me.Label121.TabIndex = 273
        Me.Label121.Text = "SAB2 RESIST"
        Me.Label121.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label121.Visible = False
        '
        'Label122
        '
        Me.Label122.BackColor = System.Drawing.Color.Black
        Me.Label122.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label122.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label122.ForeColor = System.Drawing.Color.White
        Me.Label122.Location = New System.Drawing.Point(1119, 697)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(90, 86)
        Me.Label122.TabIndex = 272
        Me.Label122.Text = "SAB2 T/Q"
        Me.Label122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label123
        '
        Me.Label123.BackColor = System.Drawing.Color.Black
        Me.Label123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label123.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label123.ForeColor = System.Drawing.Color.White
        Me.Label123.Location = New System.Drawing.Point(1119, 611)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(90, 86)
        Me.Label123.TabIndex = 271
        Me.Label123.Text = "SAB2 BARCODE"
        Me.Label123.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label125
        '
        Me.Label125.BackColor = System.Drawing.Color.Black
        Me.Label125.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label125.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label125.ForeColor = System.Drawing.Color.White
        Me.Label125.Location = New System.Drawing.Point(836, 1006)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(61, 43)
        Me.Label125.TabIndex = 269
        Me.Label125.Text = "DATA"
        Me.Label125.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label125.Visible = False
        '
        'Label126
        '
        Me.Label126.BackColor = System.Drawing.Color.Black
        Me.Label126.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label126.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label126.ForeColor = System.Drawing.Color.White
        Me.Label126.Location = New System.Drawing.Point(836, 963)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(61, 43)
        Me.Label126.TabIndex = 268
        Me.Label126.Text = "TARGET"
        Me.Label126.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label126.Visible = False
        '
        'Label127
        '
        Me.Label127.BackColor = System.Drawing.Color.Black
        Me.Label127.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label127.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label127.ForeColor = System.Drawing.Color.White
        Me.Label127.Location = New System.Drawing.Point(746, 963)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(90, 86)
        Me.Label127.TabIndex = 267
        Me.Label127.Text = "SAB1 RESIST"
        Me.Label127.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label127.Visible = False
        '
        'Label130
        '
        Me.Label130.BackColor = System.Drawing.Color.Black
        Me.Label130.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label130.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label130.ForeColor = System.Drawing.Color.White
        Me.Label130.Location = New System.Drawing.Point(746, 697)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(90, 86)
        Me.Label130.TabIndex = 264
        Me.Label130.Text = "SAB1 T/Q"
        Me.Label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecSabBarcodeR
        '
        Me.srclbDecSabBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDecSabBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecSabBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecSabBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDecSabBarcodeR.Location = New System.Drawing.Point(1061, 654)
        Me.srclbDecSabBarcodeR.Name = "srclbDecSabBarcodeR"
        Me.srclbDecSabBarcodeR.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecSabBarcodeR.TabIndex = 263
        Me.srclbDecSabBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataSabBarcodeR
        '
        Me.srclbDataSabBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDataSabBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataSabBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataSabBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDataSabBarcodeR.Location = New System.Drawing.Point(897, 654)
        Me.srclbDataSabBarcodeR.Name = "srclbDataSabBarcodeR"
        Me.srclbDataSabBarcodeR.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataSabBarcodeR.TabIndex = 262
        Me.srclbDataSabBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetSabBarcodeR
        '
        Me.srclbTargetSabBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetSabBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetSabBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetSabBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetSabBarcodeR.Location = New System.Drawing.Point(897, 611)
        Me.srclbTargetSabBarcodeR.Name = "srclbTargetSabBarcodeR"
        Me.srclbTargetSabBarcodeR.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetSabBarcodeR.TabIndex = 260
        Me.srclbTargetSabBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label136
        '
        Me.Label136.BackColor = System.Drawing.Color.Black
        Me.Label136.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label136.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label136.ForeColor = System.Drawing.Color.White
        Me.Label136.Location = New System.Drawing.Point(746, 611)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(90, 86)
        Me.Label136.TabIndex = 258
        Me.Label136.Text = "SAB1 BARCODE"
        Me.Label136.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Black
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(1209, 1006)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 43)
        Me.Label20.TabIndex = 316
        Me.Label20.Text = "DATA"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label20.Visible = False
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Black
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(1209, 963)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(61, 43)
        Me.Label31.TabIndex = 315
        Me.Label31.Text = "TARGET"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label31.Visible = False
        '
        'tmr_Tool2
        '
        '
        'tmr_Tool3
        '
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
        'srclbDecMonitorBarcodeL
        '
        Me.srclbDecMonitorBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDecMonitorBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecMonitorBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecMonitorBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDecMonitorBarcodeL.Location = New System.Drawing.Point(688, 826)
        Me.srclbDecMonitorBarcodeL.Name = "srclbDecMonitorBarcodeL"
        Me.srclbDecMonitorBarcodeL.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecMonitorBarcodeL.TabIndex = 322
        Me.srclbDecMonitorBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataMonitorBarcodeL
        '
        Me.srclbDataMonitorBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbDataMonitorBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataMonitorBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataMonitorBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbDataMonitorBarcodeL.Location = New System.Drawing.Point(524, 826)
        Me.srclbDataMonitorBarcodeL.Name = "srclbDataMonitorBarcodeL"
        Me.srclbDataMonitorBarcodeL.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataMonitorBarcodeL.TabIndex = 321
        Me.srclbDataMonitorBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetMonitorBarcodeL
        '
        Me.srclbTargetMonitorBarcodeL.BackColor = System.Drawing.Color.Black
        Me.srclbTargetMonitorBarcodeL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetMonitorBarcodeL.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetMonitorBarcodeL.ForeColor = System.Drawing.Color.White
        Me.srclbTargetMonitorBarcodeL.Location = New System.Drawing.Point(524, 783)
        Me.srclbTargetMonitorBarcodeL.Name = "srclbTargetMonitorBarcodeL"
        Me.srclbTargetMonitorBarcodeL.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetMonitorBarcodeL.TabIndex = 320
        Me.srclbTargetMonitorBarcodeL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Black
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label47.ForeColor = System.Drawing.Color.White
        Me.Label47.Location = New System.Drawing.Point(373, 783)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(90, 86)
        Me.Label47.TabIndex = 319
        Me.Label47.Text = "MONITOR CABLE"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecMonitorBarcodeR
        '
        Me.srclbDecMonitorBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDecMonitorBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecMonitorBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecMonitorBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDecMonitorBarcodeR.Location = New System.Drawing.Point(1434, 826)
        Me.srclbDecMonitorBarcodeR.Name = "srclbDecMonitorBarcodeR"
        Me.srclbDecMonitorBarcodeR.Size = New System.Drawing.Size(58, 43)
        Me.srclbDecMonitorBarcodeR.TabIndex = 328
        Me.srclbDecMonitorBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataMonitorBarcodeR
        '
        Me.srclbDataMonitorBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbDataMonitorBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataMonitorBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataMonitorBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbDataMonitorBarcodeR.Location = New System.Drawing.Point(1270, 826)
        Me.srclbDataMonitorBarcodeR.Name = "srclbDataMonitorBarcodeR"
        Me.srclbDataMonitorBarcodeR.Size = New System.Drawing.Size(164, 43)
        Me.srclbDataMonitorBarcodeR.TabIndex = 327
        Me.srclbDataMonitorBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetMonitorBarcodeR
        '
        Me.srclbTargetMonitorBarcodeR.BackColor = System.Drawing.Color.Black
        Me.srclbTargetMonitorBarcodeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetMonitorBarcodeR.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetMonitorBarcodeR.ForeColor = System.Drawing.Color.White
        Me.srclbTargetMonitorBarcodeR.Location = New System.Drawing.Point(1270, 783)
        Me.srclbTargetMonitorBarcodeR.Name = "srclbTargetMonitorBarcodeR"
        Me.srclbTargetMonitorBarcodeR.Size = New System.Drawing.Size(222, 43)
        Me.srclbTargetMonitorBarcodeR.TabIndex = 326
        Me.srclbTargetMonitorBarcodeR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Black
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label55.ForeColor = System.Drawing.Color.White
        Me.Label55.Location = New System.Drawing.Point(1119, 783)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(90, 86)
        Me.Label55.TabIndex = 325
        Me.Label55.Text = "MONITOR CABLE"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(380, 465)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 108)
        Me.Label5.TabIndex = 334
        Me.Label5.Text = "시리얼"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(380, 357)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 108)
        Me.Label6.TabIndex = 333
        Me.Label6.Text = "옵션"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(380, 249)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 108)
        Me.Label7.TabIndex = 332
        Me.Label7.Text = "사양정보"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(380, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 108)
        Me.Label8.TabIndex = 331
        Me.Label8.Text = "사양"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label15.TabIndex = 338
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
        Me.Label18.TabIndex = 337
        Me.Label18.Text = "옵션"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Black
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(1126, 249)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 108)
        Me.Label21.TabIndex = 336
        Me.Label21.Text = "사양정보"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Black
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(1126, 141)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 108)
        Me.Label24.TabIndex = 335
        Me.Label24.Text = "사양"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Black
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(463, 826)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 43)
        Me.Label22.TabIndex = 344
        Me.Label22.Text = "입력"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Black
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(463, 783)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(61, 43)
        Me.Label23.TabIndex = 343
        Me.Label23.Text = "목표"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Black
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(463, 740)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 43)
        Me.Label28.TabIndex = 342
        Me.Label28.Text = "입력"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Black
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(463, 697)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(61, 43)
        Me.Label30.TabIndex = 341
        Me.Label30.Text = "목표"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Black
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label44.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(463, 654)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(61, 43)
        Me.Label44.TabIndex = 340
        Me.Label44.Text = "입력"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Black
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(463, 611)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(61, 43)
        Me.Label51.TabIndex = 339
        Me.Label51.Text = "목표"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Black
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(836, 826)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 43)
        Me.Label12.TabIndex = 350
        Me.Label12.Text = "입력"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Black
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(836, 783)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 43)
        Me.Label19.TabIndex = 349
        Me.Label19.Text = "목표"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Black
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(836, 740)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(61, 43)
        Me.Label32.TabIndex = 348
        Me.Label32.Text = "입력"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Black
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(836, 697)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(61, 43)
        Me.Label36.TabIndex = 347
        Me.Label36.Text = "목표"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Black
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(836, 654)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(61, 43)
        Me.Label40.TabIndex = 346
        Me.Label40.Text = "입력"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Black
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(836, 611)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(61, 43)
        Me.Label42.TabIndex = 345
        Me.Label42.Text = "목표"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Black
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(1209, 826)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(61, 43)
        Me.Label48.TabIndex = 356
        Me.Label48.Text = "입력"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Black
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label50.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label50.ForeColor = System.Drawing.Color.White
        Me.Label50.Location = New System.Drawing.Point(1209, 783)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(61, 43)
        Me.Label50.TabIndex = 355
        Me.Label50.Text = "목표"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Black
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label52.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(1209, 740)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(61, 43)
        Me.Label52.TabIndex = 354
        Me.Label52.Text = "입력"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Black
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label54.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label54.ForeColor = System.Drawing.Color.White
        Me.Label54.Location = New System.Drawing.Point(1209, 697)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(61, 43)
        Me.Label54.TabIndex = 353
        Me.Label54.Text = "목표"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Black
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label56.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label56.ForeColor = System.Drawing.Color.White
        Me.Label56.Location = New System.Drawing.Point(1209, 654)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(61, 43)
        Me.Label56.TabIndex = 352
        Me.Label56.Text = "입력"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Black
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label58.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label58.ForeColor = System.Drawing.Color.White
        Me.Label58.Location = New System.Drawing.Point(1209, 611)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(61, 43)
        Me.Label58.TabIndex = 351
        Me.Label58.Text = "목표"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbAlarm
        '
        Me.srclbAlarm.BackColor = System.Drawing.Color.Red
        Me.srclbAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbAlarm.Font = New System.Drawing.Font("Arial Narrow", 65.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbAlarm.ForeColor = System.Drawing.Color.Yellow
        Me.srclbAlarm.Location = New System.Drawing.Point(12, 392)
        Me.srclbAlarm.Name = "srclbAlarm"
        Me.srclbAlarm.Size = New System.Drawing.Size(1893, 214)
        Me.srclbAlarm.TabIndex = 357
        Me.srclbAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbAlarm.Visible = False
        '
        'LbAlarmLeft
        '
        Me.LbAlarmLeft.BackColor = System.Drawing.Color.Red
        Me.LbAlarmLeft.Font = New System.Drawing.Font("Arial Narrow", 45.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbAlarmLeft.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LbAlarmLeft.Location = New System.Drawing.Point(55, 637)
        Me.LbAlarmLeft.Name = "LbAlarmLeft"
        Me.LbAlarmLeft.Size = New System.Drawing.Size(670, 384)
        Me.LbAlarmLeft.TabIndex = 358
        Me.LbAlarmLeft.Text = "바코드 에러 !!"
        Me.LbAlarmLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LbAlarmLeft.Visible = False
        '
        'LbAlarmRight
        '
        Me.LbAlarmRight.BackColor = System.Drawing.Color.Red
        Me.LbAlarmRight.Font = New System.Drawing.Font("Arial Narrow", 45.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbAlarmRight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LbAlarmRight.Location = New System.Drawing.Point(787, 633)
        Me.LbAlarmRight.Name = "LbAlarmRight"
        Me.LbAlarmRight.Size = New System.Drawing.Size(670, 384)
        Me.LbAlarmRight.TabIndex = 359
        Me.LbAlarmRight.Text = "바코드 에러 !!"
        Me.LbAlarmRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LbAlarmRight.Visible = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1917, 1061)
        Me.Controls.Add(Me.LbAlarmRight)
        Me.Controls.Add(Me.LbAlarmLeft)
        Me.Controls.Add(Me.srclbAlarm)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.srclbDecMonitorBarcodeR)
        Me.Controls.Add(Me.srclbDataMonitorBarcodeR)
        Me.Controls.Add(Me.srclbTargetMonitorBarcodeR)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.srclbDecMonitorBarcodeL)
        Me.Controls.Add(Me.srclbDataMonitorBarcodeL)
        Me.Controls.Add(Me.srclbTargetMonitorBarcodeL)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.srclbDecAirToolR)
        Me.Controls.Add(Me.srclbDataAirToolR)
        Me.Controls.Add(Me.srclbTargetAirToolR)
        Me.Controls.Add(Me.Label98)
        Me.Controls.Add(Me.srclbDeccSabResistR)
        Me.Controls.Add(Me.srclbDatacSabResistR)
        Me.Controls.Add(Me.srclbTargetcSabResistR)
        Me.Controls.Add(Me.srclbDatacSabTQ2R)
        Me.Controls.Add(Me.srclbDeccSabTqR)
        Me.Controls.Add(Me.srclbDatacSabTQ1R)
        Me.Controls.Add(Me.srclbTargetcSabTqR)
        Me.Controls.Add(Me.srclbDecCSabBarcodeR)
        Me.Controls.Add(Me.srclbDataCSabBarcodeR)
        Me.Controls.Add(Me.srclbTargetCSabBarcodeR)
        Me.Controls.Add(Me.srclbDecSabResistR)
        Me.Controls.Add(Me.srclbDataSabResistR)
        Me.Controls.Add(Me.srclbTargetSabResistR)
        Me.Controls.Add(Me.srclbDataSabTQ2R)
        Me.Controls.Add(Me.srclbDecSabTqR)
        Me.Controls.Add(Me.srclbDataSabTQ1R)
        Me.Controls.Add(Me.srclbTargetSabTqR)
        Me.Controls.Add(Me.Label121)
        Me.Controls.Add(Me.Label122)
        Me.Controls.Add(Me.Label123)
        Me.Controls.Add(Me.Label125)
        Me.Controls.Add(Me.Label126)
        Me.Controls.Add(Me.Label127)
        Me.Controls.Add(Me.Label130)
        Me.Controls.Add(Me.srclbDecSabBarcodeR)
        Me.Controls.Add(Me.srclbDataSabBarcodeR)
        Me.Controls.Add(Me.srclbTargetSabBarcodeR)
        Me.Controls.Add(Me.Label136)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label74)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.srclbDecMotorTqL)
        Me.Controls.Add(Me.srclbdataMotorTqL)
        Me.Controls.Add(Me.srclbTargetMotorTqL)
        Me.Controls.Add(Me.Label89)
        Me.Controls.Add(Me.srclbDecAirToolL)
        Me.Controls.Add(Me.srclbDataAirToolL)
        Me.Controls.Add(Me.srclbTargetAirToolL)
        Me.Controls.Add(Me.srclbDecMotorBarcodeL)
        Me.Controls.Add(Me.srclbDataMotorBarcodeL)
        Me.Controls.Add(Me.srclbTargetMotorBarcodeL)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.srclbDecSabResistL)
        Me.Controls.Add(Me.srclbDataSabResistL)
        Me.Controls.Add(Me.srclbTargetSabResistL)
        Me.Controls.Add(Me.srclbDataSabTQ2L)
        Me.Controls.Add(Me.srclbDecSabTqL)
        Me.Controls.Add(Me.srclbDataSabTQ1L)
        Me.Controls.Add(Me.srclbTargetSabTqL)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.srclbDecSabBarcodeL)
        Me.Controls.Add(Me.srclbDataSabBarcodeL)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.srclbTargetSabBarcodeL)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.srcLbSerialR)
        Me.Controls.Add(Me.srcLbPartOptionR)
        Me.Controls.Add(Me.srcLbPartNameR)
        Me.Controls.Add(Me.srcLbPartNoR)
        Me.Controls.Add(Me.srcPictureBoxR)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.srcLbSerialL)
        Me.Controls.Add(Me.srcLbPartOptionL)
        Me.Controls.Add(Me.srcLbPartNameL)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.srcLbPartNoL)
        Me.Controls.Add(Me.srcPictureBoxL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel11)
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
        Me.Panel3.ResumeLayout(False)
        CType(Me.srcPictureBoxR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.srcPictureBoxL, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label1 As Label
    Friend WithEvents srcLbPartNoL As Label
    Friend WithEvents srcLbSerialL As Label
    Friend WithEvents srcLbPartOptionL As Label
    Friend WithEvents srcLbPartNameL As Label
    Friend WithEvents Serial_ScannerL As IO.Ports.SerialPort
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents VitualKeyboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents srcPictureBoxL As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbD4200 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4200 As System.Windows.Forms.Label
    Friend WithEvents lbD4250 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4250 As System.Windows.Forms.Label
    Friend WithEvents lbD4251 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4251 As System.Windows.Forms.Label
    Friend WithEvents lbD4201 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4201 As System.Windows.Forms.Label
    Friend WithEvents lbD4259 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4259 As System.Windows.Forms.Label
    Friend WithEvents lbD4209 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4209 As System.Windows.Forms.Label
    Friend WithEvents lbD4258 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4258 As System.Windows.Forms.Label
    Friend WithEvents lbD4208 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4208 As System.Windows.Forms.Label
    Friend WithEvents lbD4257 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4257 As System.Windows.Forms.Label
    Friend WithEvents lbD4207 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4207 As System.Windows.Forms.Label
    Friend WithEvents lbD4256 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4256 As System.Windows.Forms.Label
    Friend WithEvents lbD4206 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4206 As System.Windows.Forms.Label
    Friend WithEvents lbD4255 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4255 As System.Windows.Forms.Label
    Friend WithEvents lbD4205 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4205 As System.Windows.Forms.Label
    Friend WithEvents lbD4254 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4254 As System.Windows.Forms.Label
    Friend WithEvents lbD4204 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4204 As System.Windows.Forms.Label
    Friend WithEvents lbD4253 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4253 As System.Windows.Forms.Label
    Friend WithEvents lbD4203 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4203 As System.Windows.Forms.Label
    Friend WithEvents lbD4252 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4252 As System.Windows.Forms.Label
    Friend WithEvents lbD4202 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4202 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents srcLbPlcConnectionState As System.Windows.Forms.Label
    Friend WithEvents Tmr_Connect As System.Windows.Forms.Timer
    Friend WithEvents srclbStepL As System.Windows.Forms.Label
    Friend WithEvents tmr_Tool1 As System.Windows.Forms.Timer
    Friend WithEvents lbD4359 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbD4309 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4309 As System.Windows.Forms.Label
    Friend WithEvents lbD4358 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lbD4308 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4308 As System.Windows.Forms.Label
    Friend WithEvents lbD4357 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lbD4307 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4307 As System.Windows.Forms.Label
    Friend WithEvents lbD4356 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lbD4306 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4306 As System.Windows.Forms.Label
    Friend WithEvents lbD4355 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lbD4305 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4305 As System.Windows.Forms.Label
    Friend WithEvents lbD4354 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lbD4304 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4304 As System.Windows.Forms.Label
    Friend WithEvents lbD4353 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents lbD4303 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4303 As System.Windows.Forms.Label
    Friend WithEvents lbD4352 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lbD4302 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4302 As System.Windows.Forms.Label
    Friend WithEvents lbD4351 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents lbD4301 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4301 As System.Windows.Forms.Label
    Friend WithEvents lbD4350 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents lbD4300 As System.Windows.Forms.Label
    Friend WithEvents lbTitleD4300 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents srcLbSerialR As System.Windows.Forms.Label
    Friend WithEvents srcLbPartOptionR As System.Windows.Forms.Label
    Friend WithEvents srcLbPartNameR As System.Windows.Forms.Label
    Friend WithEvents srcLbPartNoR As System.Windows.Forms.Label
    Friend WithEvents srcPictureBoxR As System.Windows.Forms.PictureBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Serial_ScannerR As System.IO.Ports.SerialPort
    Friend WithEvents Tmr_Work2 As System.Windows.Forms.Timer
    Friend WithEvents srclbStepR As System.Windows.Forms.Label
    Friend WithEvents Serial_Tool1 As System.IO.Ports.SerialPort
    Friend WithEvents Serial_Tool2 As System.IO.Ports.SerialPort
    Friend WithEvents Serial_Tool3 As System.IO.Ports.SerialPort
    Friend WithEvents Serial_Resist1 As System.IO.Ports.SerialPort
    Friend WithEvents Serial_Resist2 As System.IO.Ports.SerialPort
    Friend WithEvents srclbDecSabBarcodeL As System.Windows.Forms.Label
    Friend WithEvents srclbDataSabBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents srclbTargetSabBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents srclbDecSabTqL As System.Windows.Forms.Label
    Friend WithEvents srclbDataSabTQ1L As System.Windows.Forms.Label
    Friend WithEvents srclbTargetSabTqL As System.Windows.Forms.Label
    Friend WithEvents srclbDataSabTQ2L As System.Windows.Forms.Label
    Friend WithEvents srclbDecSabResistL As System.Windows.Forms.Label
    Friend WithEvents srclbDataSabResistL As System.Windows.Forms.Label
    Friend WithEvents srclbTargetSabResistL As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents srclbDecAirToolL As System.Windows.Forms.Label
    Friend WithEvents srclbDataAirToolL As System.Windows.Forms.Label
    Friend WithEvents srclbTargetAirToolL As System.Windows.Forms.Label
    Friend WithEvents srclbDecMotorBarcodeL As System.Windows.Forms.Label
    Friend WithEvents srclbDataMotorBarcodeL As System.Windows.Forms.Label
    Friend WithEvents srclbTargetMotorBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents srclbDecMotorTqL As System.Windows.Forms.Label
    Friend WithEvents srclbdataMotorTqL As System.Windows.Forms.Label
    Friend WithEvents srclbTargetMotorTqL As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents srclbDecAirToolR As System.Windows.Forms.Label
    Friend WithEvents srclbDataAirToolR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetAirToolR As System.Windows.Forms.Label
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents srclbDeccSabResistR As System.Windows.Forms.Label
    Friend WithEvents srclbDatacSabResistR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetcSabResistR As System.Windows.Forms.Label
    Friend WithEvents srclbDatacSabTQ2R As System.Windows.Forms.Label
    Friend WithEvents srclbDeccSabTqR As System.Windows.Forms.Label
    Friend WithEvents srclbDatacSabTQ1R As System.Windows.Forms.Label
    Friend WithEvents srclbTargetcSabTqR As System.Windows.Forms.Label
    Friend WithEvents srclbDecCSabBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbDataCSabBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetCSabBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbDecSabResistR As System.Windows.Forms.Label
    Friend WithEvents srclbDataSabResistR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetSabResistR As System.Windows.Forms.Label
    Friend WithEvents srclbDataSabTQ2R As System.Windows.Forms.Label
    Friend WithEvents srclbDecSabTqR As System.Windows.Forms.Label
    Friend WithEvents srclbDataSabTQ1R As System.Windows.Forms.Label
    Friend WithEvents srclbTargetSabTqR As System.Windows.Forms.Label
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents Label125 As System.Windows.Forms.Label
    Friend WithEvents Label126 As System.Windows.Forms.Label
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents srclbDecSabBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbDataSabBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetSabBarcodeR As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents tmr_Tool2 As System.Windows.Forms.Timer
    Friend WithEvents tmr_Tool3 As System.Windows.Forms.Timer
    Friend WithEvents srclbDecMonitorBarcodeL As System.Windows.Forms.Label
    Friend WithEvents srclbDataMonitorBarcodeL As System.Windows.Forms.Label
    Friend WithEvents srclbTargetMonitorBarcodeL As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents srclbDecMonitorBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbDataMonitorBarcodeR As System.Windows.Forms.Label
    Friend WithEvents srclbTargetMonitorBarcodeR As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents srclbAlarm As System.Windows.Forms.Label
    Friend WithEvents LbAlarmLeft As System.Windows.Forms.Label
    Friend WithEvents LbAlarmRight As System.Windows.Forms.Label
End Class
