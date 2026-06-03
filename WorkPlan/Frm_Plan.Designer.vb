<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Plan
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
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Grid2 = New System.Windows.Forms.DataGridView()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Grid1
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Grid1.DefaultCellStyle.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Grid1.RowTemplate.Height = 45
        Me.Grid1.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid1.Location = New System.Drawing.Point(12, 81)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid1.Size = New System.Drawing.Size(459, 612)
        Me.Grid1.TabIndex = 129
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(831, 701)
        Me.Button8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(105, 52)
        Me.Button8.TabIndex = 133
        Me.Button8.Text = "창닫기"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(12, 701)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 52)
        Me.Button1.TabIndex = 136
        Me.Button1.Text = "추가"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(123, 701)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(142, 52)
        Me.Button3.TabIndex = 138
        Me.Button3.Text = "전체삭제"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Grid2
        '
        Me.Grid2.AllowUserToAddRows = False
        Me.Grid2.AllowUserToDeleteRows = False
        Me.Grid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Grid2.DefaultCellStyle.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Grid2.RowTemplate.Height = 45
        Me.Grid2.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Grid2.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Grid2.Location = New System.Drawing.Point(477, 81)
        Me.Grid2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.ReadOnly = True
        Me.Grid2.RowHeadersVisible = False
        Me.Grid2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid2.Size = New System.Drawing.Size(459, 612)
        Me.Grid2.TabIndex = 139
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Black
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(12, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(459, 53)
        Me.Label22.TabIndex = 142
        Me.Label22.Text = "LH"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(477, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(459, 53)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "RH"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Frm_Plan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(950, 763)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Grid2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Grid1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Frm_Plan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPlan"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grid1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Grid2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
