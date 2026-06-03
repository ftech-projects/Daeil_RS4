<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBasic
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
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBasic))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.srcTxtMotorMax = New System.Windows.Forms.TextBox()
        Me.srcTxtMotorMin = New System.Windows.Forms.TextBox()
        Me.srcTxtMotorUnit = New System.Windows.Forms.TextBox()
        Me.srcTxtSabUnit = New System.Windows.Forms.TextBox()
        Me.srcTxtSabMin = New System.Windows.Forms.TextBox()
        Me.srcTxtSabMax = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.srcTxtResistMin = New System.Windows.Forms.TextBox()
        Me.srcTxtResistMax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(406, 241)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(405, 50)
        Me.Button2.TabIndex = 74
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1, 241)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(405, 50)
        Me.Button1.TabIndex = 73
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(81, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 35)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "MIN"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(81, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 35)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Unit"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(81, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 35)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "MAX"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(812, 67)
        Me.Panel1.TabIndex = 58
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
        Me.Label1.Size = New System.Drawing.Size(810, 65)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "STANDARD SETTING"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Silver
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 105)
        Me.Label9.TabIndex = 75
        Me.Label9.Text = "MOTOR TOOL"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcTxtMotorMax
        '
        Me.srcTxtMotorMax.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.srcTxtMotorMax.Location = New System.Drawing.Point(213, 66)
        Me.srcTxtMotorMax.Name = "srcTxtMotorMax"
        Me.srcTxtMotorMax.Size = New System.Drawing.Size(193, 35)
        Me.srcTxtMotorMax.TabIndex = 80
        '
        'srcTxtMotorMin
        '
        Me.srcTxtMotorMin.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.srcTxtMotorMin.Location = New System.Drawing.Point(213, 101)
        Me.srcTxtMotorMin.Name = "srcTxtMotorMin"
        Me.srcTxtMotorMin.Size = New System.Drawing.Size(193, 35)
        Me.srcTxtMotorMin.TabIndex = 81
        '
        'srcTxtMotorUnit
        '
        Me.srcTxtMotorUnit.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.srcTxtMotorUnit.Location = New System.Drawing.Point(213, 136)
        Me.srcTxtMotorUnit.Name = "srcTxtMotorUnit"
        Me.srcTxtMotorUnit.Size = New System.Drawing.Size(193, 35)
        Me.srcTxtMotorUnit.TabIndex = 82
        '
        'srcTxtSabUnit
        '
        Me.srcTxtSabUnit.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.srcTxtSabUnit.Location = New System.Drawing.Point(618, 136)
        Me.srcTxtSabUnit.Name = "srcTxtSabUnit"
        Me.srcTxtSabUnit.Size = New System.Drawing.Size(193, 35)
        Me.srcTxtSabUnit.TabIndex = 89
        '
        'srcTxtSabMin
        '
        Me.srcTxtSabMin.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.srcTxtSabMin.Location = New System.Drawing.Point(618, 101)
        Me.srcTxtSabMin.Name = "srcTxtSabMin"
        Me.srcTxtSabMin.Size = New System.Drawing.Size(193, 35)
        Me.srcTxtSabMin.TabIndex = 88
        '
        'srcTxtSabMax
        '
        Me.srcTxtSabMax.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.srcTxtSabMax.Location = New System.Drawing.Point(618, 66)
        Me.srcTxtSabMax.Name = "srcTxtSabMax"
        Me.srcTxtSabMax.Size = New System.Drawing.Size(193, 35)
        Me.srcTxtSabMax.TabIndex = 87
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(406, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 105)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "SAB TOOL"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(486, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 35)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "MIN"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(486, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 35)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Unit"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(486, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 35)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "MAX"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcTxtResistMin
        '
        Me.srcTxtResistMin.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.srcTxtResistMin.Location = New System.Drawing.Point(213, 206)
        Me.srcTxtResistMin.Name = "srcTxtResistMin"
        Me.srcTxtResistMin.Size = New System.Drawing.Size(193, 35)
        Me.srcTxtResistMin.TabIndex = 95
        '
        'srcTxtResistMax
        '
        Me.srcTxtResistMax.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.srcTxtResistMax.Location = New System.Drawing.Point(213, 171)
        Me.srcTxtResistMax.Name = "srcTxtResistMax"
        Me.srcTxtResistMax.Size = New System.Drawing.Size(193, 35)
        Me.srcTxtResistMax.TabIndex = 94
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Silver
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(1, 171)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 70)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "SAB RESIST"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Silver
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(81, 206)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 35)
        Me.Label11.TabIndex = 92
        Me.Label11.Text = "MIN"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Silver
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(81, 171)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(132, 35)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "MAX"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmBasic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(812, 292)
        Me.Controls.Add(Me.srcTxtResistMin)
        Me.Controls.Add(Me.srcTxtResistMax)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.srcTxtSabUnit)
        Me.Controls.Add(Me.srcTxtSabMin)
        Me.Controls.Add(Me.srcTxtSabMax)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.srcTxtMotorUnit)
        Me.Controls.Add(Me.srcTxtMotorMin)
        Me.Controls.Add(Me.srcTxtMotorMax)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmBasic"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBasic"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents srcTxtMotorMax As TextBox
    Friend WithEvents srcTxtMotorMin As TextBox
    Friend WithEvents srcTxtMotorUnit As TextBox
    Friend WithEvents srcTxtSabUnit As System.Windows.Forms.TextBox
    Friend WithEvents srcTxtSabMin As System.Windows.Forms.TextBox
    Friend WithEvents srcTxtSabMax As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents srcTxtResistMin As System.Windows.Forms.TextBox
    Friend WithEvents srcTxtResistMax As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
