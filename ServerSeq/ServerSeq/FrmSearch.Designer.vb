<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmsearch
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.srcDtpStart = New System.Windows.Forms.DateTimePicker()
        Me.srcDtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(809, 9)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 51)
        Me.Button3.TabIndex = 119
        Me.Button3.Text = "Search"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(885, 9)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 51)
        Me.Button2.TabIndex = 118
        Me.Button2.Text = "toExcel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 25)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Gainsboro
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(12, 9)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(115, 25)
        Me.Label45.TabIndex = 115
        Me.Label45.Text = "Start Date"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'srcDtpStart
        '
        Me.srcDtpStart.CalendarFont = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcDtpStart.Font = New System.Drawing.Font("Tahoma", 10.8!)
        Me.srcDtpStart.Location = New System.Drawing.Point(127, 9)
        Me.srcDtpStart.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.srcDtpStart.Name = "srcDtpStart"
        Me.srcDtpStart.Size = New System.Drawing.Size(178, 25)
        Me.srcDtpStart.TabIndex = 111
        '
        'srcDtpEnd
        '
        Me.srcDtpEnd.CalendarFont = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srcDtpEnd.Font = New System.Drawing.Font("Tahoma", 10.8!)
        Me.srcDtpEnd.Location = New System.Drawing.Point(127, 35)
        Me.srcDtpEnd.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.srcDtpEnd.Name = "srcDtpEnd"
        Me.srcDtpEnd.Size = New System.Drawing.Size(178, 25)
        Me.srcDtpEnd.TabIndex = 112
        '
        'Grid1 (FlexCell.Grid → DataGridView로 변환)
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.Font = New System.Drawing.Font("Arial Narrow", 11.25!)
        Me.Grid1.Location = New System.Drawing.Point(12, 65)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadOnly = True
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.Size = New System.Drawing.Size(942, 620)
        Me.Grid1.TabIndex = 114
        '
        'Frmsearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 695)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.srcDtpStart)
        Me.Controls.Add(Me.srcDtpEnd)
        Me.Controls.Add(Me.Grid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Frmsearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSearch"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents srcDtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents srcDtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Grid1 As System.Windows.Forms.DataGridView
End Class
