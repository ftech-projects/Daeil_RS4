<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SerialPrinter = New System.IO.Ports.SerialPort(Me.components)
        Me.SerialSCanner = New System.IO.Ports.SerialPort(Me.components)
        Me.LbAlarm = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button3.Location = New System.Drawing.Point(309, 666)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(151, 51)
        Me.Button3.TabIndex = 150
        Me.Button3.Text = "수동바코드출력"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Grid1
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Grid1.DefaultCellStyle.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Grid1.RowTemplate.Height = 30
        Me.Grid1.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(11, 12)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid1.Size = New System.Drawing.Size(986, 651)
        Me.Grid1.TabIndex = 149
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button2.Location = New System.Drawing.Point(464, 666)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(151, 51)
        Me.Button2.TabIndex = 148
        Me.Button2.Text = "새로고침"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button1.Location = New System.Drawing.Point(766, 666)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 51)
        Me.Button1.TabIndex = 147
        Me.Button1.Text = "나가기"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button4.Location = New System.Drawing.Point(7, 666)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(151, 51)
        Me.Button4.TabIndex = 151
        Me.Button4.Text = "서열등록"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button5.Location = New System.Drawing.Point(158, 666)
        Me.Button5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(151, 51)
        Me.Button5.TabIndex = 152
        Me.Button5.Text = "포트설정"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'SerialSCanner
        '
        '
        'LbAlarm
        '
        Me.LbAlarm.BackColor = System.Drawing.Color.Crimson
        Me.LbAlarm.Font = New System.Drawing.Font("Arial Narrow", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbAlarm.ForeColor = System.Drawing.Color.White
        Me.LbAlarm.Location = New System.Drawing.Point(4, 98)
        Me.LbAlarm.Name = "LbAlarm"
        Me.LbAlarm.Size = New System.Drawing.Size(1280, 132)
        Me.LbAlarm.TabIndex = 155
        Me.LbAlarm.Text = "중복된 바코드 입니다. !!!"
        Me.LbAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button6.Location = New System.Drawing.Point(615, 666)
        Me.Button6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(151, 51)
        Me.Button6.TabIndex = 156
        Me.Button6.Text = "데이터 조회"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(922, 670)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(74, 21)
        Me.Button7.TabIndex = 157
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(923, 696)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(74, 21)
        Me.Button8.TabIndex = 158
        Me.Button8.Text = "Button8"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.LbAlarm)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMain"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Grid1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents SerialPrinter As System.IO.Ports.SerialPort
    Friend WithEvents SerialSCanner As System.IO.Ports.SerialPort
    Friend WithEvents LbAlarm As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
End Class
