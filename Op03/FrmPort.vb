Public Class FrmPort
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()
        Init_ComboBox()
        Port_2_ComboBox()
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Private Sub Port_2_ComboBox()

        srcCbScannerL.Text = PortNumber_ScannerL
        srcCbScannerR.Text = PortNumber_ScannerR
        srcCbTool1.Text = PortNumber_Tool1
        srcCbTool2.Text = PortNumber_Tool2
        srcCbTool3.Text = PortNumber_Tool3
        srcCbResist1.Text = PortNumber_Resist1
        srcCbResist2.Text = PortNumber_Resist2

    End Sub

    Private Sub Init_ComboBox()

        For i As Integer = 1 To 15
            srcCbScannerL.Items.Add("COM" & CStr(i))
            srcCbScannerR.Items.Add("COM" & CStr(i))
            srcCbTool1.Items.Add("COM" & CStr(i))
            srcCbTool2.Items.Add("COM" & CStr(i))
            srcCbTool3.Items.Add("COM" & CStr(i))
            srcCbResist1.Items.Add("COM" & CStr(i))
            srcCbResist2.Items.Add("COM" & CStr(i))
        Next

    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        PortNumber_ScannerL = srcCbScannerL.Text
        PortNumber_ScannerR = srcCbScannerR.Text
        PortNumber_Tool1 = srcCbTool1.Text
        PortNumber_Tool2 = srcCbTool2.Text
        PortNumber_Tool3 = srcCbTool3.Text
        PortNumber_Resist1 = srcCbResist1.Text
        PortNumber_Resist2 = srcCbResist2.Text

        SavePortData()
        FrmMain.SerialOpen()
        Me.Close()

    End Sub

    Private Sub Button2_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Me.Close()
        CheckFormPort = False

    End Sub

End Class