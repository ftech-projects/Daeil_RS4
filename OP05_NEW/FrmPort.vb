Public Class FrmPort
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()
        Init_ComboBox()

    End Sub

    Private Sub FrmPort_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not LoadPortData() Then
            MessageBox.Show("Port 불러오기 실패" & vbCrLf & LastMdbError & vbCrLf & MdbFilePath(),
                            "DB", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Port_2_ComboBox()
    End Sub

    Private Sub Port_2_ComboBox()

        srcCbScanner.Text = PortNumber_Scanner
        srcCbTool.Text = PortNumber_Tool
        srcCbPrinter.Text = PortNumber_Printer
        srcCbLaser.Text = PortNumber_Laser
        srcCbIo.Text = PortNumber_Io

    End Sub

    Private Sub Init_ComboBox()

        For i As Integer = 1 To 15
            srcCbScanner.Items.Add("COM" & CStr(i))
            srcCbPrinter.Items.Add("COM" & CStr(i))
            srcCbTool.Items.Add("COM" & CStr(i))
            srcCbLaser.Items.Add("COM" & CStr(i))
            srcCbIo.Items.Add("COM" & CStr(i))
        Next
        srcCbLaser.Items.Add("Disabled")
        srcCbIo.Items.Add("Disabled")

    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        PortNumber_Scanner = srcCbScanner.Text
        PortNumber_Tool = srcCbTool.Text
        PortNumber_Printer = srcCbPrinter.Text
        PortNumber_Laser = srcCbLaser.Text
        PortNumber_Io = srcCbIo.Text

        If Not SavePortData() Then
            MessageBox.Show("Port 저장 실패" & vbCrLf & LastMdbError & vbCrLf & MdbFilePath(),
                            "DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        FrmMain.SerialOpen()
        FrmMain.RestartLaserCommunication()
        FrmMain.RestartIoCommunication()
        MessageBox.Show("Port 설정이 저장되었습니다.", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        CheckFormPort = False

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        CheckFormPort = False
    End Sub

End Class
