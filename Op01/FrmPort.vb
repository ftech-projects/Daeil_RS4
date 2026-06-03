Public Class FrmPort
    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()
        Init_ComboBox()
        Port_2_ComboBox()
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Private Sub Port_2_ComboBox()

        srcCbScanner.Text = PortNumber_Scanner
        srcCbTool.Text = PortNumber_Tool
        srcCbPrinter.Text = PortNumber_Printer
        
    End Sub

    Private Sub Init_ComboBox()

        For i As Integer = 1 To 15
            srcCbScanner.Items.Add("COM" & CStr(i))
            srcCbPrinter.Items.Add("COM" & CStr(i))
            srcCbTool.Items.Add("COM" & CStr(i))
        Next

    End Sub

    Private Sub Button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        PortNumber_Scanner = srcCbScanner.Text
        PortNumber_Tool = srcCbTool.Text
        PortNumber_Printer = srcCbPrinter.Text
        
        SavePortData()
        FrmMain.SerialOpen()
        Me.Close()

        CheckFormPort = False

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        CheckFormPort = False
    End Sub

End Class