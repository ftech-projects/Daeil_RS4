<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWorkStandard
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
        Me.srcPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.srcPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'srcPictureBox
        '
        Me.srcPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.srcPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.srcPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.srcPictureBox.Name = "srcPictureBox"
        Me.srcPictureBox.Size = New System.Drawing.Size(558, 359)
        Me.srcPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.srcPictureBox.TabIndex = 1
        Me.srcPictureBox.TabStop = False
        '
        'FrmWorkStandard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 359)
        Me.Controls.Add(Me.srcPictureBox)
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(-2500, 0)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmWorkStandard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrmWorkStandard"
        CType(Me.srcPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents srcPictureBox As System.Windows.Forms.PictureBox
End Class
