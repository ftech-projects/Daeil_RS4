<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBasicAngle
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
        Me.CN7_btn_Save = New System.Windows.Forms.Button()
        Me.CN7_btn_CLose = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Grid1
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Grid1.DefaultCellStyle.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Grid1.RowTemplate.Height = 20
        Me.Grid1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(10, 11)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid1.Size = New System.Drawing.Size(482, 623)
        Me.Grid1.TabIndex = 23
        Me.Grid1.RowHeadersVisible = False
        '
        'CN7_btn_Save
        '
        Me.CN7_btn_Save.Location = New System.Drawing.Point(498, 468)
        Me.CN7_btn_Save.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CN7_btn_Save.Name = "CN7_btn_Save"
        Me.CN7_btn_Save.Size = New System.Drawing.Size(123, 79)
        Me.CN7_btn_Save.TabIndex = 97
        Me.CN7_btn_Save.Text = "SAVE"
        Me.CN7_btn_Save.UseVisualStyleBackColor = True
        '
        'CN7_btn_CLose
        '
        Me.CN7_btn_CLose.Location = New System.Drawing.Point(498, 555)
        Me.CN7_btn_CLose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CN7_btn_CLose.Name = "CN7_btn_CLose"
        Me.CN7_btn_CLose.Size = New System.Drawing.Size(123, 79)
        Me.CN7_btn_CLose.TabIndex = 96
        Me.CN7_btn_CLose.Text = "CLOSE"
        Me.CN7_btn_CLose.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(498, 428)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(123, 33)
        Me.ComboBox1.TabIndex = 98
        '
        'FrmBasicAngle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 647)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.CN7_btn_Save)
        Me.Controls.Add(Me.CN7_btn_CLose)
        Me.Controls.Add(Me.Grid1)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmBasicAngle"
        Me.Text = "FrmBasicAngle"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grid1 As System.Windows.Forms.DataGridView
    Friend WithEvents CN7_btn_Save As System.Windows.Forms.Button
    Friend WithEvents CN7_btn_CLose As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
