<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmColor
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
        Me.lbBRZ = New System.Windows.Forms.Label()
        Me.lbGLW = New System.Windows.Forms.Label()
        Me.lbNNB = New System.Windows.Forms.Label()
        Me.lbMGJ = New System.Windows.Forms.Label()
        Me.lbDUE = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PnNNB = New System.Windows.Forms.Panel()
        Me.pnBRZ = New System.Windows.Forms.Panel()
        Me.pnGLW = New System.Windows.Forms.Panel()
        Me.pnMGJ = New System.Windows.Forms.Panel()
        Me.PnDUE = New System.Windows.Forms.Panel()
        Me.PnNNB.SuspendLayout()
        Me.pnBRZ.SuspendLayout()
        Me.pnGLW.SuspendLayout()
        Me.pnMGJ.SuspendLayout()
        Me.PnDUE.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbBRZ
        '
        Me.lbBRZ.BackColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.lbBRZ.Font = New System.Drawing.Font("굴림", 180.0!, System.Drawing.FontStyle.Bold)
        Me.lbBRZ.Location = New System.Drawing.Point(23, 17)
        Me.lbBRZ.Name = "lbBRZ"
        Me.lbBRZ.Size = New System.Drawing.Size(906, 297)
        Me.lbBRZ.TabIndex = 4
        Me.lbBRZ.Text = "BRZ"
        Me.lbBRZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbGLW
        '
        Me.lbGLW.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbGLW.Font = New System.Drawing.Font("굴림", 180.0!, System.Drawing.FontStyle.Bold)
        Me.lbGLW.Location = New System.Drawing.Point(23, 19)
        Me.lbGLW.Name = "lbGLW"
        Me.lbGLW.Size = New System.Drawing.Size(906, 297)
        Me.lbGLW.TabIndex = 5
        Me.lbGLW.Text = "GLW"
        Me.lbGLW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbNNB
        '
        Me.lbNNB.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.lbNNB.Font = New System.Drawing.Font("굴림", 180.0!, System.Drawing.FontStyle.Bold)
        Me.lbNNB.ForeColor = System.Drawing.Color.DarkGray
        Me.lbNNB.Location = New System.Drawing.Point(23, 23)
        Me.lbNNB.Name = "lbNNB"
        Me.lbNNB.Size = New System.Drawing.Size(906, 297)
        Me.lbNNB.TabIndex = 6
        Me.lbNNB.Text = "NNB"
        Me.lbNNB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbMGJ
        '
        Me.lbMGJ.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(136, Byte), Integer))
        Me.lbMGJ.Font = New System.Drawing.Font("굴림", 180.0!, System.Drawing.FontStyle.Bold)
        Me.lbMGJ.Location = New System.Drawing.Point(19, 19)
        Me.lbMGJ.Name = "lbMGJ"
        Me.lbMGJ.Size = New System.Drawing.Size(906, 297)
        Me.lbMGJ.TabIndex = 8
        Me.lbMGJ.Text = "MGJ"
        Me.lbMGJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbDUE
        '
        Me.lbDUE.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(164, Byte), Integer))
        Me.lbDUE.Font = New System.Drawing.Font("굴림", 180.0!, System.Drawing.FontStyle.Bold)
        Me.lbDUE.Location = New System.Drawing.Point(19, 23)
        Me.lbDUE.Name = "lbDUE"
        Me.lbDUE.Size = New System.Drawing.Size(906, 297)
        Me.lbDUE.TabIndex = 7
        Me.lbDUE.Text = "DUE"
        Me.lbDUE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'PnNNB
        '
        Me.PnNNB.BackColor = System.Drawing.Color.Yellow
        Me.PnNNB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnNNB.Controls.Add(Me.lbNNB)
        Me.PnNNB.Location = New System.Drawing.Point(12, 12)
        Me.PnNNB.Name = "PnNNB"
        Me.PnNNB.Size = New System.Drawing.Size(947, 340)
        Me.PnNNB.TabIndex = 9
        '
        'pnBRZ
        '
        Me.pnBRZ.BackColor = System.Drawing.Color.Yellow
        Me.pnBRZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnBRZ.Controls.Add(Me.lbBRZ)
        Me.pnBRZ.Location = New System.Drawing.Point(12, 704)
        Me.pnBRZ.Name = "pnBRZ"
        Me.pnBRZ.Size = New System.Drawing.Size(947, 340)
        Me.pnBRZ.TabIndex = 11
        '
        'pnGLW
        '
        Me.pnGLW.BackColor = System.Drawing.Color.LightGray
        Me.pnGLW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnGLW.Controls.Add(Me.lbGLW)
        Me.pnGLW.Location = New System.Drawing.Point(12, 358)
        Me.pnGLW.Name = "pnGLW"
        Me.pnGLW.Size = New System.Drawing.Size(947, 340)
        Me.pnGLW.TabIndex = 10
        '
        'pnMGJ
        '
        Me.pnMGJ.BackColor = System.Drawing.Color.Yellow
        Me.pnMGJ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnMGJ.Controls.Add(Me.lbMGJ)
        Me.pnMGJ.Location = New System.Drawing.Point(968, 358)
        Me.pnMGJ.Name = "pnMGJ"
        Me.pnMGJ.Size = New System.Drawing.Size(947, 340)
        Me.pnMGJ.TabIndex = 13
        '
        'PnDUE
        '
        Me.PnDUE.BackColor = System.Drawing.Color.Yellow
        Me.PnDUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnDUE.Controls.Add(Me.lbDUE)
        Me.PnDUE.Location = New System.Drawing.Point(968, 12)
        Me.PnDUE.Name = "PnDUE"
        Me.PnDUE.Size = New System.Drawing.Size(947, 340)
        Me.PnDUE.TabIndex = 12
        '
        'FrmColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1927, 1080)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnMGJ)
        Me.Controls.Add(Me.PnDUE)
        Me.Controls.Add(Me.pnBRZ)
        Me.Controls.Add(Me.pnGLW)
        Me.Controls.Add(Me.PnNNB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(-5500, 0)
        Me.Name = "FrmColor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrmColor"
        Me.TopMost = True
        Me.PnNNB.ResumeLayout(False)
        Me.pnBRZ.ResumeLayout(False)
        Me.pnGLW.ResumeLayout(False)
        Me.pnMGJ.ResumeLayout(False)
        Me.PnDUE.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbBRZ As System.Windows.Forms.Label
    Friend WithEvents lbGLW As System.Windows.Forms.Label
    Friend WithEvents lbNNB As System.Windows.Forms.Label
    Friend WithEvents lbMGJ As System.Windows.Forms.Label
    Friend WithEvents lbDUE As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PnNNB As System.Windows.Forms.Panel
    Friend WithEvents pnBRZ As System.Windows.Forms.Panel
    Friend WithEvents pnGLW As System.Windows.Forms.Panel
    Friend WithEvents pnMGJ As System.Windows.Forms.Panel
    Friend WithEvents PnDUE As System.Windows.Forms.Panel
End Class
