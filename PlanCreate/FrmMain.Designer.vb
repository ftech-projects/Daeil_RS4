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
        Me.Tmr_Work = New System.Windows.Forms.Timer(Me.components)
        Me.Serial_Printer = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Serial_Scanner = New System.IO.Ports.SerialPort(Me.components)
        Me.Serial_Tool = New System.IO.Ports.SerialPort(Me.components)
        Me.Tmr_Connect = New System.Windows.Forms.Timer(Me.components)
        Me.tmr_Tool = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.Button3.Location = New System.Drawing.Point(117, 673)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(134, 83)
        Me.Button3.TabIndex = 142
        Me.Button3.Text = "전체삭제"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.Button1.Location = New System.Drawing.Point(12, 673)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 83)
        Me.Button1.TabIndex = 141
        Me.Button1.Text = "추가"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Arial Narrow", 18.0!)
        Me.Button8.Location = New System.Drawing.Point(780, 672)
        Me.Button8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(105, 83)
        Me.Button8.TabIndex = 140
        Me.Button8.Text = "종료"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Grid1 (FlexCell.Grid → DataGridView로 변환)
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Grid1.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Grid1.Location = New System.Drawing.Point(12, 13)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid1.Size = New System.Drawing.Size(873, 651)
        Me.Grid1.TabIndex = 139
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(902, 769)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Grid1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMain"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tmr_Work As System.Windows.Forms.Timer
    Friend WithEvents Serial_Printer As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Serial_Scanner As IO.Ports.SerialPort
    Friend WithEvents Serial_Tool As IO.Ports.SerialPort
    Friend WithEvents Tmr_Connect As System.Windows.Forms.Timer
    Friend WithEvents tmr_Tool As System.Windows.Forms.Timer
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Grid1 As System.Windows.Forms.DataGridView
End Class
