<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmIo
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabIo = New System.Windows.Forms.TabControl()
        Me.TabCom = New System.Windows.Forms.TabPage()
        Me.LblComAi = New System.Windows.Forms.Label()
        Me.PanelComOut = New System.Windows.Forms.Panel()
        Me.LblComOutTitle = New System.Windows.Forms.Label()
        Me.PanelComIn = New System.Windows.Forms.Panel()
        Me.LblComInTitle = New System.Windows.Forms.Label()
        Me.TabFbei = New System.Windows.Forms.TabPage()
        Me.PanelFbeiOut = New System.Windows.Forms.Panel()
        Me.LblFbeiOutTitle = New System.Windows.Forms.Label()
        Me.PanelFbeiIn = New System.Windows.Forms.Panel()
        Me.LblFbeiInTitle = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.TabIo.SuspendLayout()
        Me.TabCom.SuspendLayout()
        Me.TabFbei.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabIo
        '
        Me.TabIo.Controls.Add(Me.TabCom)
        Me.TabIo.Controls.Add(Me.TabFbei)
        Me.TabIo.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TabIo.Location = New System.Drawing.Point(12, 12)
        Me.TabIo.Name = "TabIo"
        Me.TabIo.SelectedIndex = 0
        Me.TabIo.Size = New System.Drawing.Size(1000, 620)
        Me.TabIo.TabIndex = 0
        '
        'TabCom
        '
        Me.TabCom.Controls.Add(Me.LblComAi)
        Me.TabCom.Controls.Add(Me.PanelComOut)
        Me.TabCom.Controls.Add(Me.LblComOutTitle)
        Me.TabCom.Controls.Add(Me.PanelComIn)
        Me.TabCom.Controls.Add(Me.LblComInTitle)
        Me.TabCom.Location = New System.Drawing.Point(4, 29)
        Me.TabCom.Name = "TabCom"
        Me.TabCom.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCom.Size = New System.Drawing.Size(992, 587)
        Me.TabCom.TabIndex = 0
        Me.TabCom.Text = "COM I/O (ESP)"
        Me.TabCom.UseVisualStyleBackColor = True
        '
        'LblComAi
        '
        Me.LblComAi.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblComAi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblComAi.Font = New System.Drawing.Font("Arial Narrow", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblComAi.Location = New System.Drawing.Point(6, 520)
        Me.LblComAi.Name = "LblComAi"
        Me.LblComAi.Size = New System.Drawing.Size(974, 58)
        Me.LblComAi.TabIndex = 4
        Me.LblComAi.Text = "AI"
        Me.LblComAi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelComOut
        '
        Me.PanelComOut.AutoScroll = True
        Me.PanelComOut.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelComOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelComOut.Location = New System.Drawing.Point(506, 38)
        Me.PanelComOut.Name = "PanelComOut"
        Me.PanelComOut.Size = New System.Drawing.Size(474, 472)
        Me.PanelComOut.TabIndex = 3
        '
        'LblComOutTitle
        '
        Me.LblComOutTitle.BackColor = System.Drawing.Color.DarkOrange
        Me.LblComOutTitle.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblComOutTitle.ForeColor = System.Drawing.Color.White
        Me.LblComOutTitle.Location = New System.Drawing.Point(506, 6)
        Me.LblComOutTitle.Name = "LblComOutTitle"
        Me.LblComOutTitle.Size = New System.Drawing.Size(474, 28)
        Me.LblComOutTitle.TabIndex = 2
        Me.LblComOutTitle.Text = "OUTPUT (DO 1~8)"
        Me.LblComOutTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelComIn
        '
        Me.PanelComIn.AutoScroll = True
        Me.PanelComIn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelComIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelComIn.Location = New System.Drawing.Point(6, 38)
        Me.PanelComIn.Name = "PanelComIn"
        Me.PanelComIn.Size = New System.Drawing.Size(474, 472)
        Me.PanelComIn.TabIndex = 1
        '
        'LblComInTitle
        '
        Me.LblComInTitle.BackColor = System.Drawing.Color.DarkGreen
        Me.LblComInTitle.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblComInTitle.ForeColor = System.Drawing.Color.White
        Me.LblComInTitle.Location = New System.Drawing.Point(6, 6)
        Me.LblComInTitle.Name = "LblComInTitle"
        Me.LblComInTitle.Size = New System.Drawing.Size(474, 28)
        Me.LblComInTitle.TabIndex = 0
        Me.LblComInTitle.Text = "INPUT (DI 1~16)"
        Me.LblComInTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabFbei
        '
        Me.TabFbei.Controls.Add(Me.PanelFbeiOut)
        Me.TabFbei.Controls.Add(Me.LblFbeiOutTitle)
        Me.TabFbei.Controls.Add(Me.PanelFbeiIn)
        Me.TabFbei.Controls.Add(Me.LblFbeiInTitle)
        Me.TabFbei.Location = New System.Drawing.Point(4, 29)
        Me.TabFbei.Name = "TabFbei"
        Me.TabFbei.Padding = New System.Windows.Forms.Padding(3)
        Me.TabFbei.Size = New System.Drawing.Size(992, 587)
        Me.TabFbei.TabIndex = 1
        Me.TabFbei.Text = "LAN I/O (FBEI)"
        Me.TabFbei.UseVisualStyleBackColor = True
        '
        'PanelFbeiOut
        '
        Me.PanelFbeiOut.AutoScroll = True
        Me.PanelFbeiOut.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelFbeiOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelFbeiOut.Location = New System.Drawing.Point(506, 38)
        Me.PanelFbeiOut.Name = "PanelFbeiOut"
        Me.PanelFbeiOut.Size = New System.Drawing.Size(474, 540)
        Me.PanelFbeiOut.TabIndex = 3
        '
        'LblFbeiOutTitle
        '
        Me.LblFbeiOutTitle.BackColor = System.Drawing.Color.DarkOrange
        Me.LblFbeiOutTitle.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblFbeiOutTitle.ForeColor = System.Drawing.Color.White
        Me.LblFbeiOutTitle.Location = New System.Drawing.Point(506, 6)
        Me.LblFbeiOutTitle.Name = "LblFbeiOutTitle"
        Me.LblFbeiOutTitle.Size = New System.Drawing.Size(474, 28)
        Me.LblFbeiOutTitle.TabIndex = 2
        Me.LblFbeiOutTitle.Text = "OUTPUT (Q1~32)"
        Me.LblFbeiOutTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelFbeiIn
        '
        Me.PanelFbeiIn.AutoScroll = True
        Me.PanelFbeiIn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelFbeiIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelFbeiIn.Location = New System.Drawing.Point(6, 38)
        Me.PanelFbeiIn.Name = "PanelFbeiIn"
        Me.PanelFbeiIn.Size = New System.Drawing.Size(474, 540)
        Me.PanelFbeiIn.TabIndex = 1
        '
        'LblFbeiInTitle
        '
        Me.LblFbeiInTitle.BackColor = System.Drawing.Color.DarkGreen
        Me.LblFbeiInTitle.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblFbeiInTitle.ForeColor = System.Drawing.Color.White
        Me.LblFbeiInTitle.Location = New System.Drawing.Point(6, 6)
        Me.LblFbeiInTitle.Name = "LblFbeiInTitle"
        Me.LblFbeiInTitle.Size = New System.Drawing.Size(474, 28)
        Me.LblFbeiInTitle.TabIndex = 0
        Me.LblFbeiInTitle.Text = "INPUT (X1~32)"
        Me.LblFbeiInTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnClose
        '
        Me.BtnClose.Font = New System.Drawing.Font("Arial Narrow", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BtnClose.Location = New System.Drawing.Point(892, 642)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(120, 44)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "CLOSE"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'LblStatus
        '
        Me.LblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStatus.Font = New System.Drawing.Font("Arial Narrow", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblStatus.Location = New System.Drawing.Point(12, 642)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(868, 44)
        Me.LblStatus.TabIndex = 1
        Me.LblStatus.Text = "Status"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimerRefresh
        '
        Me.TimerRefresh.Interval = 100
        '
        'FrmIo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 698)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.TabIo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmIo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "I/O Monitor"
        Me.TabIo.ResumeLayout(False)
        Me.TabCom.ResumeLayout(False)
        Me.TabFbei.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabIo As TabControl
    Friend WithEvents TabCom As TabPage
    Friend WithEvents TabFbei As TabPage
    Friend WithEvents PanelComIn As Panel
    Friend WithEvents LblComInTitle As Label
    Friend WithEvents PanelComOut As Panel
    Friend WithEvents LblComOutTitle As Label
    Friend WithEvents LblComAi As Label
    Friend WithEvents PanelFbeiIn As Panel
    Friend WithEvents LblFbeiInTitle As Label
    Friend WithEvents PanelFbeiOut As Panel
    Friend WithEvents LblFbeiOutTitle As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents LblStatus As Label
    Friend WithEvents TimerRefresh As Timer
End Class
