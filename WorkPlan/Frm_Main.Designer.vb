<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Main
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.Grid2 = New System.Windows.Forms.DataGridView()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 3)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 765)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1024, 3)
        Me.Panel2.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1021, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(3, 762)
        Me.Panel3.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(3, 762)
        Me.Panel4.TabIndex = 5
        '
        'Timer1
        '
        '
        'Grid1
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Grid1.DefaultCellStyle.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Grid1.RowTemplate.Height = 45
        Me.Grid1.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Grid1.GridColor = System.Drawing.Color.FromArgb(192, 192, 192)
        Me.Grid1.Location = New System.Drawing.Point(3, 3)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid1.Size = New System.Drawing.Size(504, 762)
        Me.Grid1.TabIndex = 200
        '
        'Grid2
        '
        Me.Grid2.AllowUserToAddRows = False
        Me.Grid2.AllowUserToDeleteRows = False
        Me.Grid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Grid2.DefaultCellStyle.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Grid2.RowTemplate.Height = 45
        Me.Grid2.Font = New System.Drawing.Font("Arial Narrow", 9.0!)
        Me.Grid2.GridColor = System.Drawing.Color.FromArgb(192, 192, 192)
        Me.Grid2.Location = New System.Drawing.Point(515, 3)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.ReadOnly = True
        Me.Grid2.RowHeadersVisible = False
        Me.Grid2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid2.Size = New System.Drawing.Size(506, 762)
        Me.Grid2.TabIndex = 201
        '
        'Frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.Grid2)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Frm_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SP2I Part Select"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Grid1 As System.Windows.Forms.DataGridView
    Friend WithEvents Grid2 As System.Windows.Forms.DataGridView

End Class
