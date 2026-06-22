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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.Tmr_Work = New System.Windows.Forms.Timer(Me.components)
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
        Me.srcLbSerial = New System.Windows.Forms.Label()
        Me.srcLbPartOption = New System.Windows.Forms.Label()
        Me.srcLbPartName = New System.Windows.Forms.Label()
        Me.srcLbPartNo = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.srclbStep = New System.Windows.Forms.Label()
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
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Serial_Scanner = New System.IO.Ports.SerialPort(Me.components)
        Me.Serial_Tool = New System.IO.Ports.SerialPort(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.srclbTargetMonitorbracketTq = New System.Windows.Forms.Label()
        Me.srclbDataMonitorbracketTq1 = New System.Windows.Forms.Label()
        Me.srclbDecMonitorbracketTq1 = New System.Windows.Forms.Label()
        Me.srclbDataMonitorbracketTq2 = New System.Windows.Forms.Label()
        Me.srclbDecMonitorbracketTq2 = New System.Windows.Forms.Label()
        Me.srclbDataMonitorbracketTq3 = New System.Windows.Forms.Label()
        Me.srclbDecMonitorbracketTq3 = New System.Windows.Forms.Label()
        Me.srclbDataMonitorbracketTq4 = New System.Windows.Forms.Label()
        Me.srclbDecMonitorbracketTq4 = New System.Windows.Forms.Label()
        Me.GridCount = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Tmr_Connect = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tmr_Tool = New System.Windows.Forms.Timer(Me.components)
        Me.srclbDecTool = New System.Windows.Forms.Label()
        Me.srclbDataTool = New System.Windows.Forms.Label()
        Me.srclbTargetTool = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.srclbAlarm = New System.Windows.Forms.Label()
        Me.srcPictureBox = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.GridCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.srcPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Tmr_Work
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
        Me.Label1.Size = New System.Drawing.Size(760, 51)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "제품 이미지"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbSerial
        '
        Me.srcLbSerial.BackColor = System.Drawing.Color.Black
        Me.srcLbSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbSerial.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbSerial.ForeColor = System.Drawing.Color.White
        Me.srcLbSerial.Location = New System.Drawing.Point(903, 465)
        Me.srcLbSerial.Name = "srcLbSerial"
        Me.srcLbSerial.Size = New System.Drawing.Size(590, 108)
        Me.srcLbSerial.TabIndex = 34
        Me.srcLbSerial.Text = "20210316000188888-00000"
        Me.srcLbSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartOption
        '
        Me.srcLbPartOption.BackColor = System.Drawing.Color.Black
        Me.srcLbPartOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartOption.Font = New System.Drawing.Font("Arial Narrow", 48.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartOption.ForeColor = System.Drawing.Color.White
        Me.srcLbPartOption.Location = New System.Drawing.Point(903, 357)
        Me.srcLbPartOption.Name = "srcLbPartOption"
        Me.srcLbPartOption.Size = New System.Drawing.Size(590, 108)
        Me.srcLbPartOption.TabIndex = 33
        Me.srcLbPartOption.Text = "PART NO."
        Me.srcLbPartOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartName
        '
        Me.srcLbPartName.BackColor = System.Drawing.Color.Black
        Me.srcLbPartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartName.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartName.ForeColor = System.Drawing.Color.White
        Me.srcLbPartName.Location = New System.Drawing.Point(903, 249)
        Me.srcLbPartName.Name = "srcLbPartName"
        Me.srcLbPartName.Size = New System.Drawing.Size(590, 108)
        Me.srcLbPartName.TabIndex = 32
        Me.srcLbPartName.Text = "PART NO."
        Me.srcLbPartName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPartNo
        '
        Me.srcLbPartNo.BackColor = System.Drawing.Color.Black
        Me.srcLbPartNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPartNo.Font = New System.Drawing.Font("Arial Narrow", 48.0!, System.Drawing.FontStyle.Bold)
        Me.srcLbPartNo.ForeColor = System.Drawing.Color.White
        Me.srcLbPartNo.Location = New System.Drawing.Point(903, 141)
        Me.srcLbPartNo.Name = "srcLbPartNo"
        Me.srcLbPartNo.Size = New System.Drawing.Size(590, 108)
        Me.srcLbPartNo.TabIndex = 31
        Me.srcLbPartNo.Text = "88888-00000"
        Me.srcLbPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Black
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(760, 465)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 108)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "시리얼"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(760, 357)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 108)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "옵션"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(760, 249)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 108)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "사양정보"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(760, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 108)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "사양"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Black
        Me.Panel11.Controls.Add(Me.srclbStep)
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
        Me.Panel11.Size = New System.Drawing.Size(423, 433)
        Me.Panel11.TabIndex = 111
        '
        'srclbStep
        '
        Me.srclbStep.BackColor = System.Drawing.Color.Gray
        Me.srclbStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbStep.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srclbStep.ForeColor = System.Drawing.Color.White
        Me.srclbStep.Location = New System.Drawing.Point(340, 9)
        Me.srclbStep.Name = "srclbStep"
        Me.srclbStep.Size = New System.Drawing.Size(78, 36)
        Me.srclbStep.TabIndex = 172
        Me.srclbStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcLbPlcConnectionState
        '
        Me.srcLbPlcConnectionState.BackColor = System.Drawing.Color.Gray
        Me.srcLbPlcConnectionState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcLbPlcConnectionState.Font = New System.Drawing.Font("Arial Narrow", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcLbPlcConnectionState.ForeColor = System.Drawing.Color.White
        Me.srcLbPlcConnectionState.Location = New System.Drawing.Point(212, 9)
        Me.srcLbPlcConnectionState.Name = "srcLbPlcConnectionState"
        Me.srcLbPlcConnectionState.Size = New System.Drawing.Size(128, 36)
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
        Me.Label11.Text = "192.168.0.100"
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
        'txtMessage
        '
        Me.txtMessage.BackColor = System.Drawing.Color.Black
        Me.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMessage.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.txtMessage.ForeColor = System.Drawing.Color.White
        Me.txtMessage.Location = New System.Drawing.Point(0, 939)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(760, 107)
        Me.txtMessage.TabIndex = 51
        Me.txtMessage.WordWrap = False
        '
        'Serial_Scanner
        '
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(760, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(733, 51)
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
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Navy
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(1493, 573)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(290, 51)
        Me.Label9.TabIndex = 123
        Me.Label9.Text = "생산 수량"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(760, 573)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(733, 51)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "관리 항목"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Black
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(760, 624)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(143, 276)
        Me.Label19.TabIndex = 133
        Me.Label19.Text = "모니터브라켓 T/Q"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Black
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(903, 624)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(106, 55)
        Me.Label24.TabIndex = 147
        Me.Label24.Text = "목표"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetMonitorbracketTq
        '
        Me.srclbTargetMonitorbracketTq.BackColor = System.Drawing.Color.Black
        Me.srclbTargetMonitorbracketTq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetMonitorbracketTq.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetMonitorbracketTq.ForeColor = System.Drawing.Color.White
        Me.srclbTargetMonitorbracketTq.Location = New System.Drawing.Point(1009, 624)
        Me.srclbTargetMonitorbracketTq.Name = "srclbTargetMonitorbracketTq"
        Me.srclbTargetMonitorbracketTq.Size = New System.Drawing.Size(484, 55)
        Me.srclbTargetMonitorbracketTq.TabIndex = 148
        Me.srclbTargetMonitorbracketTq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataMonitorbracketTq1
        '
        Me.srclbDataMonitorbracketTq1.BackColor = System.Drawing.Color.Black
        Me.srclbDataMonitorbracketTq1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataMonitorbracketTq1.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataMonitorbracketTq1.ForeColor = System.Drawing.Color.White
        Me.srclbDataMonitorbracketTq1.Location = New System.Drawing.Point(903, 679)
        Me.srclbDataMonitorbracketTq1.Name = "srclbDataMonitorbracketTq1"
        Me.srclbDataMonitorbracketTq1.Size = New System.Drawing.Size(491, 55)
        Me.srclbDataMonitorbracketTq1.TabIndex = 136
        Me.srclbDataMonitorbracketTq1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecMonitorbracketTq1
        '
        Me.srclbDecMonitorbracketTq1.BackColor = System.Drawing.Color.Black
        Me.srclbDecMonitorbracketTq1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecMonitorbracketTq1.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecMonitorbracketTq1.ForeColor = System.Drawing.Color.White
        Me.srclbDecMonitorbracketTq1.Location = New System.Drawing.Point(1394, 679)
        Me.srclbDecMonitorbracketTq1.Name = "srclbDecMonitorbracketTq1"
        Me.srclbDecMonitorbracketTq1.Size = New System.Drawing.Size(99, 55)
        Me.srclbDecMonitorbracketTq1.TabIndex = 137
        Me.srclbDecMonitorbracketTq1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataMonitorbracketTq2
        '
        Me.srclbDataMonitorbracketTq2.BackColor = System.Drawing.Color.Black
        Me.srclbDataMonitorbracketTq2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataMonitorbracketTq2.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataMonitorbracketTq2.ForeColor = System.Drawing.Color.White
        Me.srclbDataMonitorbracketTq2.Location = New System.Drawing.Point(903, 734)
        Me.srclbDataMonitorbracketTq2.Name = "srclbDataMonitorbracketTq2"
        Me.srclbDataMonitorbracketTq2.Size = New System.Drawing.Size(491, 55)
        Me.srclbDataMonitorbracketTq2.TabIndex = 139
        Me.srclbDataMonitorbracketTq2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecMonitorbracketTq2
        '
        Me.srclbDecMonitorbracketTq2.BackColor = System.Drawing.Color.Black
        Me.srclbDecMonitorbracketTq2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecMonitorbracketTq2.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecMonitorbracketTq2.ForeColor = System.Drawing.Color.White
        Me.srclbDecMonitorbracketTq2.Location = New System.Drawing.Point(1394, 734)
        Me.srclbDecMonitorbracketTq2.Name = "srclbDecMonitorbracketTq2"
        Me.srclbDecMonitorbracketTq2.Size = New System.Drawing.Size(99, 55)
        Me.srclbDecMonitorbracketTq2.TabIndex = 140
        Me.srclbDecMonitorbracketTq2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataMonitorbracketTq3
        '
        Me.srclbDataMonitorbracketTq3.BackColor = System.Drawing.Color.Black
        Me.srclbDataMonitorbracketTq3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataMonitorbracketTq3.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataMonitorbracketTq3.ForeColor = System.Drawing.Color.White
        Me.srclbDataMonitorbracketTq3.Location = New System.Drawing.Point(903, 789)
        Me.srclbDataMonitorbracketTq3.Name = "srclbDataMonitorbracketTq3"
        Me.srclbDataMonitorbracketTq3.Size = New System.Drawing.Size(491, 55)
        Me.srclbDataMonitorbracketTq3.TabIndex = 142
        Me.srclbDataMonitorbracketTq3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecMonitorbracketTq3
        '
        Me.srclbDecMonitorbracketTq3.BackColor = System.Drawing.Color.Black
        Me.srclbDecMonitorbracketTq3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecMonitorbracketTq3.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecMonitorbracketTq3.ForeColor = System.Drawing.Color.White
        Me.srclbDecMonitorbracketTq3.Location = New System.Drawing.Point(1394, 789)
        Me.srclbDecMonitorbracketTq3.Name = "srclbDecMonitorbracketTq3"
        Me.srclbDecMonitorbracketTq3.Size = New System.Drawing.Size(99, 55)
        Me.srclbDecMonitorbracketTq3.TabIndex = 143
        Me.srclbDecMonitorbracketTq3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataMonitorbracketTq4
        '
        Me.srclbDataMonitorbracketTq4.BackColor = System.Drawing.Color.Black
        Me.srclbDataMonitorbracketTq4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataMonitorbracketTq4.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataMonitorbracketTq4.ForeColor = System.Drawing.Color.White
        Me.srclbDataMonitorbracketTq4.Location = New System.Drawing.Point(903, 844)
        Me.srclbDataMonitorbracketTq4.Name = "srclbDataMonitorbracketTq4"
        Me.srclbDataMonitorbracketTq4.Size = New System.Drawing.Size(491, 55)
        Me.srclbDataMonitorbracketTq4.TabIndex = 145
        Me.srclbDataMonitorbracketTq4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDecMonitorbracketTq4
        '
        Me.srclbDecMonitorbracketTq4.BackColor = System.Drawing.Color.Black
        Me.srclbDecMonitorbracketTq4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecMonitorbracketTq4.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecMonitorbracketTq4.ForeColor = System.Drawing.Color.White
        Me.srclbDecMonitorbracketTq4.Location = New System.Drawing.Point(1394, 844)
        Me.srclbDecMonitorbracketTq4.Name = "srclbDecMonitorbracketTq4"
        Me.srclbDecMonitorbracketTq4.Size = New System.Drawing.Size(99, 55)
        Me.srclbDecMonitorbracketTq4.TabIndex = 146
        Me.srclbDecMonitorbracketTq4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridCount
        '
        Me.GridCount.AllowUserToAddRows = False
        Me.GridCount.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridCount.DefaultCellStyle = DataGridViewCellStyle1
        Me.GridCount.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.GridCount.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridCount.Location = New System.Drawing.Point(1493, 624)
        Me.GridCount.Name = "GridCount"
        Me.GridCount.ReadOnly = True
        Me.GridCount.RowHeadersVisible = False
        Me.GridCount.RowTemplate.Height = 30
        Me.GridCount.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.GridCount.Size = New System.Drawing.Size(423, 422)
        Me.GridCount.TabIndex = 138
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
        Me.Label3.Text = "RS4 FRT BACK ASSEMBLE SYSTEM OP01"
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
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button1.Location = New System.Drawing.Point(1782, 573)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 51)
        Me.Button1.TabIndex = 139
        Me.Button1.Text = "RESET"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tmr_Tool
        '
        '
        'srclbDecTool
        '
        Me.srclbDecTool.BackColor = System.Drawing.Color.Black
        Me.srclbDecTool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDecTool.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDecTool.ForeColor = System.Drawing.Color.White
        Me.srclbDecTool.Location = New System.Drawing.Point(1394, 970)
        Me.srclbDecTool.Name = "srclbDecTool"
        Me.srclbDecTool.Size = New System.Drawing.Size(99, 69)
        Me.srclbDecTool.TabIndex = 145
        Me.srclbDecTool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbDataTool
        '
        Me.srclbDataTool.BackColor = System.Drawing.Color.Black
        Me.srclbDataTool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbDataTool.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbDataTool.ForeColor = System.Drawing.Color.White
        Me.srclbDataTool.Location = New System.Drawing.Point(1009, 970)
        Me.srclbDataTool.Name = "srclbDataTool"
        Me.srclbDataTool.Size = New System.Drawing.Size(385, 69)
        Me.srclbDataTool.TabIndex = 144
        Me.srclbDataTool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srclbTargetTool
        '
        Me.srclbTargetTool.BackColor = System.Drawing.Color.Black
        Me.srclbTargetTool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srclbTargetTool.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold)
        Me.srclbTargetTool.ForeColor = System.Drawing.Color.White
        Me.srclbTargetTool.Location = New System.Drawing.Point(1009, 901)
        Me.srclbTargetTool.Name = "srclbTargetTool"
        Me.srclbTargetTool.Size = New System.Drawing.Size(484, 69)
        Me.srclbTargetTool.TabIndex = 143
        Me.srclbTargetTool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Black
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(903, 901)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(106, 69)
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
        Me.Label22.Location = New System.Drawing.Point(760, 900)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(143, 138)
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
        Me.Label23.Location = New System.Drawing.Point(903, 970)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(106, 69)
        Me.Label23.TabIndex = 140
        Me.Label23.Text = "체결"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.srclbAlarm.TabIndex = 186
        Me.srclbAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.srclbAlarm.Visible = False
        '
        'srcPictureBox
        '
        Me.srcPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcPictureBox.Location = New System.Drawing.Point(0, 141)
        Me.srcPictureBox.Name = "srcPictureBox"
        Me.srcPictureBox.Size = New System.Drawing.Size(760, 798)
        Me.srcPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.srcPictureBox.TabIndex = 0
        Me.srcPictureBox.TabStop = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1917, 1047)
        Me.Controls.Add(Me.srclbAlarm)
        Me.Controls.Add(Me.srclbDecMonitorbracketTq4)
        Me.Controls.Add(Me.srclbDataMonitorbracketTq4)
        Me.Controls.Add(Me.srclbDecMonitorbracketTq3)
        Me.Controls.Add(Me.srclbDataMonitorbracketTq3)
        Me.Controls.Add(Me.srclbDecMonitorbracketTq2)
        Me.Controls.Add(Me.srclbDataMonitorbracketTq2)
        Me.Controls.Add(Me.srclbDecMonitorbracketTq1)
        Me.Controls.Add(Me.srclbDataMonitorbracketTq1)
        Me.Controls.Add(Me.srclbDecTool)
        Me.Controls.Add(Me.srclbDataTool)
        Me.Controls.Add(Me.srclbTargetTool)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GridCount)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.srclbTargetMonitorbracketTq)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.srcLbSerial)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.srcLbPartOption)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.srcLbPartName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.srcLbPartNo)
        Me.Controls.Add(Me.srcPictureBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
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
        CType(Me.GridCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.srcPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tmr_Work As System.Windows.Forms.Timer
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
    Friend WithEvents srcLbPartNo As Label
    Friend WithEvents srcLbSerial As Label
    Friend WithEvents srcLbPartOption As Label
    Friend WithEvents srcLbPartName As Label
    Friend WithEvents Serial_Scanner As IO.Ports.SerialPort
    Friend WithEvents Serial_Tool As IO.Ports.SerialPort
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents VitualKeyboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents srcPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents srclbTargetMonitorbracketTq As System.Windows.Forms.Label
    Friend WithEvents srclbDataMonitorbracketTq1 As System.Windows.Forms.Label
    Friend WithEvents srclbDecMonitorbracketTq1 As System.Windows.Forms.Label
    Friend WithEvents srclbDataMonitorbracketTq2 As System.Windows.Forms.Label
    Friend WithEvents srclbDecMonitorbracketTq2 As System.Windows.Forms.Label
    Friend WithEvents srclbDataMonitorbracketTq3 As System.Windows.Forms.Label
    Friend WithEvents srclbDecMonitorbracketTq3 As System.Windows.Forms.Label
    Friend WithEvents srclbDataMonitorbracketTq4 As System.Windows.Forms.Label
    Friend WithEvents srclbDecMonitorbracketTq4 As System.Windows.Forms.Label
    Friend WithEvents GridCount As System.Windows.Forms.DataGridView
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
    Friend WithEvents srclbStep As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tmr_Tool As System.Windows.Forms.Timer
    Friend WithEvents srclbDecTool As System.Windows.Forms.Label
    Friend WithEvents srclbDataTool As System.Windows.Forms.Label
    Friend WithEvents srclbTargetTool As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents srclbAlarm As System.Windows.Forms.Label
End Class
