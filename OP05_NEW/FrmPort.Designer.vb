<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPort
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPort))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.srcCbPrinter = New System.Windows.Forms.ComboBox()
        Me.srcCbTool = New System.Windows.Forms.ComboBox()
        Me.srcCbScanner = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LabelLaser = New System.Windows.Forms.Label()
        Me.srcCbLaser = New System.Windows.Forms.ComboBox()
        Me.LabelIo = New System.Windows.Forms.Label()
        Me.srcCbIo = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(788, 67)
        Me.Panel1.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 32.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(786, 65)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "PORT SETTING"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 22.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 50)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "SCANNER"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 22.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(1, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 50)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "PRINTER"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcCbPrinter
        '
        Me.srcCbPrinter.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbPrinter.FormattingEnabled = True
        Me.srcCbPrinter.Location = New System.Drawing.Point(173, 117)
        Me.srcCbPrinter.Name = "srcCbPrinter"
        Me.srcCbPrinter.Size = New System.Drawing.Size(221, 50)
        Me.srcCbPrinter.TabIndex = 47
        '
        'srcCbTool
        '
        Me.srcCbTool.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbTool.FormattingEnabled = True
        Me.srcCbTool.Location = New System.Drawing.Point(173, 167)
        Me.srcCbTool.Name = "srcCbTool"
        Me.srcCbTool.Size = New System.Drawing.Size(221, 50)
        Me.srcCbTool.TabIndex = 48
        Me.srcCbTool.Visible = False
        '
        'srcCbScanner
        '
        Me.srcCbScanner.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbScanner.FormattingEnabled = True
        Me.srcCbScanner.Location = New System.Drawing.Point(173, 67)
        Me.srcCbScanner.Name = "srcCbScanner"
        Me.srcCbScanner.Size = New System.Drawing.Size(221, 50)
        Me.srcCbScanner.TabIndex = 53
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 22.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(172, 50)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "TOOL"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label8.Visible = False
        '
        'LabelLaser
        '
        Me.LabelLaser.BackColor = System.Drawing.Color.Silver
        Me.LabelLaser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelLaser.Font = New System.Drawing.Font("Arial Narrow", 22.0!, System.Drawing.FontStyle.Bold)
        Me.LabelLaser.ForeColor = System.Drawing.Color.Black
        Me.LabelLaser.Location = New System.Drawing.Point(1, 167)
        Me.LabelLaser.Name = "LabelLaser"
        Me.LabelLaser.Size = New System.Drawing.Size(172, 50)
        Me.LabelLaser.TabIndex = 58
        Me.LabelLaser.Text = "LASER"
        Me.LabelLaser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcCbLaser
        '
        Me.srcCbLaser.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbLaser.FormattingEnabled = True
        Me.srcCbLaser.Location = New System.Drawing.Point(173, 167)
        Me.srcCbLaser.Name = "srcCbLaser"
        Me.srcCbLaser.Size = New System.Drawing.Size(221, 50)
        Me.srcCbLaser.TabIndex = 59
        '
        'LabelIo
        '
        Me.LabelIo.BackColor = System.Drawing.Color.Silver
        Me.LabelIo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelIo.Font = New System.Drawing.Font("Arial Narrow", 22.0!, System.Drawing.FontStyle.Bold)
        Me.LabelIo.ForeColor = System.Drawing.Color.Black
        Me.LabelIo.Location = New System.Drawing.Point(1, 217)
        Me.LabelIo.Name = "LabelIo"
        Me.LabelIo.Size = New System.Drawing.Size(172, 50)
        Me.LabelIo.TabIndex = 60
        Me.LabelIo.Text = "I/O (ESP)"
        Me.LabelIo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcCbIo
        '
        Me.srcCbIo.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbIo.FormattingEnabled = True
        Me.srcCbIo.Location = New System.Drawing.Point(173, 217)
        Me.srcCbIo.Name = "srcCbIo"
        Me.srcCbIo.Size = New System.Drawing.Size(221, 50)
        Me.srcCbIo.TabIndex = 61
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1, 367)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(393, 50)
        Me.Button1.TabIndex = 56
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(394, 367)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(393, 50)
        Me.Button2.TabIndex = 57
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrmPort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(788, 417)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.srcCbIo)
        Me.Controls.Add(Me.LabelIo)
        Me.Controls.Add(Me.srcCbLaser)
        Me.Controls.Add(Me.LabelLaser)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.srcCbScanner)
        Me.Controls.Add(Me.srcCbTool)
        Me.Controls.Add(Me.srcCbPrinter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FrmPort"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SERIAL PORT"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents srcCbPrinter As ComboBox
    Friend WithEvents srcCbTool As ComboBox
    Friend WithEvents srcCbScanner As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents LabelLaser As Label
    Friend WithEvents srcCbLaser As ComboBox
    Friend WithEvents LabelIo As Label
    Friend WithEvents srcCbIo As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
