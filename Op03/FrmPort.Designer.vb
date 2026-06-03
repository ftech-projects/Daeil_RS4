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
        Me.srcCbScannerR = New System.Windows.Forms.ComboBox()
        Me.srcCbScannerL = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.srcCbTool1 = New System.Windows.Forms.ComboBox()
        Me.srcCbTool2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.srcCbTool3 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.srcCbResist1 = New System.Windows.Forms.ComboBox()
        Me.srcCbResist2 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
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
        Me.Label2.Text = "SCANNER L"
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
        Me.Label3.Text = "SCANNER R"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcCbScannerR
        '
        Me.srcCbScannerR.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbScannerR.FormattingEnabled = True
        Me.srcCbScannerR.Location = New System.Drawing.Point(173, 117)
        Me.srcCbScannerR.Name = "srcCbScannerR"
        Me.srcCbScannerR.Size = New System.Drawing.Size(221, 50)
        Me.srcCbScannerR.TabIndex = 47
        '
        'srcCbScannerL
        '
        Me.srcCbScannerL.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbScannerL.FormattingEnabled = True
        Me.srcCbScannerL.Location = New System.Drawing.Point(173, 67)
        Me.srcCbScannerL.Name = "srcCbScannerL"
        Me.srcCbScannerL.Size = New System.Drawing.Size(221, 50)
        Me.srcCbScannerL.TabIndex = 53
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1, 267)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(393, 50)
        Me.Button1.TabIndex = 56
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(394, 267)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(393, 50)
        Me.Button2.TabIndex = 57
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'srcCbTool1
        '
        Me.srcCbTool1.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbTool1.FormattingEnabled = True
        Me.srcCbTool1.Location = New System.Drawing.Point(566, 67)
        Me.srcCbTool1.Name = "srcCbTool1"
        Me.srcCbTool1.Size = New System.Drawing.Size(221, 50)
        Me.srcCbTool1.TabIndex = 61
        '
        'srcCbTool2
        '
        Me.srcCbTool2.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbTool2.FormattingEnabled = True
        Me.srcCbTool2.Location = New System.Drawing.Point(566, 117)
        Me.srcCbTool2.Name = "srcCbTool2"
        Me.srcCbTool2.Size = New System.Drawing.Size(221, 50)
        Me.srcCbTool2.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 22.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(394, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(172, 50)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "TOOL 2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 22.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(394, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 50)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "TOOL 1"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcCbTool3
        '
        Me.srcCbTool3.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbTool3.FormattingEnabled = True
        Me.srcCbTool3.Location = New System.Drawing.Point(566, 167)
        Me.srcCbTool3.Name = "srcCbTool3"
        Me.srcCbTool3.Size = New System.Drawing.Size(221, 50)
        Me.srcCbTool3.TabIndex = 65
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 22.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(394, 167)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 50)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "TOOL 3"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcCbResist1
        '
        Me.srcCbResist1.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbResist1.FormattingEnabled = True
        Me.srcCbResist1.Location = New System.Drawing.Point(173, 167)
        Me.srcCbResist1.Name = "srcCbResist1"
        Me.srcCbResist1.Size = New System.Drawing.Size(221, 50)
        Me.srcCbResist1.TabIndex = 69
        '
        'srcCbResist2
        '
        Me.srcCbResist2.Font = New System.Drawing.Font("Arial Narrow", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcCbResist2.FormattingEnabled = True
        Me.srcCbResist2.Location = New System.Drawing.Point(173, 217)
        Me.srcCbResist2.Name = "srcCbResist2"
        Me.srcCbResist2.Size = New System.Drawing.Size(221, 50)
        Me.srcCbResist2.TabIndex = 68
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(172, 50)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "SAB RESIST 2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Silver
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1, 167)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(172, 50)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "SAB RESIST 1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmPort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(788, 317)
        Me.Controls.Add(Me.srcCbResist1)
        Me.Controls.Add(Me.srcCbResist2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.srcCbTool3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.srcCbTool1)
        Me.Controls.Add(Me.srcCbTool2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.srcCbScannerL)
        Me.Controls.Add(Me.srcCbScannerR)
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
    Friend WithEvents srcCbScannerR As ComboBox
    Friend WithEvents srcCbScannerL As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents srcCbTool1 As System.Windows.Forms.ComboBox
    Friend WithEvents srcCbTool2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents srcCbTool3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents srcCbResist1 As System.Windows.Forms.ComboBox
    Friend WithEvents srcCbResist2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
