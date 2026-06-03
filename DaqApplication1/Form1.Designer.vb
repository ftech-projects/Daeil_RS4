<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DaqTaskComponent1 = New DaqApplication1.DaqTaskComponent(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Switch1 = New NationalInstruments.UI.WindowsForms.Switch()
        Me.WaveformGraph1 = New NationalInstruments.UI.WindowsForms.WaveformGraph()
        Me.XAxis1 = New NationalInstruments.UI.XAxis()
        Me.YAxis1 = New NationalInstruments.UI.YAxis()
        Me.WaveformPlot1 = New NationalInstruments.UI.WaveformPlot()
        CType(Me.DaqTaskComponent1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Switch1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WaveformGraph1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DaqTaskComponent1
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Switch1)
        Me.Panel1.Controls.Add(Me.WaveformGraph1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 171)
        Me.Panel1.TabIndex = 0
        '
        'Switch1
        '
        Me.Switch1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Switch1.Location = New System.Drawing.Point(258, 2)
        Me.Switch1.Name = "Switch1"
        Me.Switch1.Size = New System.Drawing.Size(64, 96)
        Me.Switch1.SwitchStyle = NationalInstruments.UI.SwitchStyle.VerticalToggle3D
        Me.Switch1.TabIndex = 0
        '
        'WaveformGraph1
        '
        Me.WaveformGraph1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaveformGraph1.Location = New System.Drawing.Point(2, 2)
        Me.WaveformGraph1.Name = "WaveformGraph1"
        Me.WaveformGraph1.Plots.AddRange(New NationalInstruments.UI.WaveformPlot() {Me.WaveformPlot1})
        Me.WaveformGraph1.Size = New System.Drawing.Size(250, 167)
        Me.WaveformGraph1.TabIndex = 1
        Me.WaveformGraph1.UseColorGenerator = True
        Me.WaveformGraph1.XAxes.AddRange(New NationalInstruments.UI.XAxis() {Me.XAxis1})
        Me.WaveformGraph1.YAxes.AddRange(New NationalInstruments.UI.YAxis() {Me.YAxis1})
        '
        'WaveformPlot1
        '
        Me.WaveformPlot1.XAxis = Me.XAxis1
        Me.WaveformPlot1.YAxis = Me.YAxis1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 519)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DaqTaskComponent1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Switch1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WaveformGraph1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DaqTaskComponent1 As DaqApplication1.DaqTaskComponent
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Switch1 As NationalInstruments.UI.WindowsForms.Switch
    Friend WithEvents WaveformGraph1 As NationalInstruments.UI.WindowsForms.WaveformGraph
    Friend WithEvents WaveformPlot1 As NationalInstruments.UI.WaveformPlot
    Friend WithEvents XAxis1 As NationalInstruments.UI.XAxis
    Friend WithEvents YAxis1 As NationalInstruments.UI.YAxis

End Class
