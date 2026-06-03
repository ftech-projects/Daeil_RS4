<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegisterSeq
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Grid1 (FlexCell.Grid → DataGridView로 변환)
        '
        Me.Grid1.AllowUserToAddRows = True
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Grid1.Font = New System.Drawing.Font("Arial Narrow", 12.0!)
        Me.Grid1.Location = New System.Drawing.Point(11, 12)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid1.Size = New System.Drawing.Size(1256, 597)
        Me.Grid1.TabIndex = 141
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button2.Location = New System.Drawing.Point(867, 618)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(198, 51)
        Me.Button2.TabIndex = 140
        Me.Button2.Text = "저장"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button1.Location = New System.Drawing.Point(1069, 618)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 51)
        Me.Button1.TabIndex = 139
        Me.Button1.Text = "나가기"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Arial Narrow", 120.0!)
        Me.DateTimePicker1.Font = New System.Drawing.Font("Arial Narrow", 19.0!)
        Me.DateTimePicker1.Location = New System.Drawing.Point(11, 618)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(386, 51)
        Me.DateTimePicker1.TabIndex = 145
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 16.0!)
        Me.Button3.Location = New System.Drawing.Point(402, 618)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(198, 51)
        Me.Button3.TabIndex = 146
        Me.Button3.Text = "불러오기"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmRegisterSeq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1275, 677)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmRegisterSeq"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRegisterSeq"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grid1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
