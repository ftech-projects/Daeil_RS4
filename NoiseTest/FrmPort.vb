Public Class FrmPort

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()
        InitComboBox()
        Port2ComboBox()
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Private Sub Port2ComboBox()

        ComboBox2.Text = PortNumberAmp1
        ComboBox3.Text = PortNumberAmp2
        ComboBox1.Text = PortNumberScanner
        ComboBox4.Text = PortNumberPrinter
        ComboBox5.Text = PortNumberCan

        TextBox1.Text = MicroPhone_Tol
        TextBox2.Text = Sensitivity

    End Sub

    Private Sub InitComboBox()

        For i As Integer = 1 To 15
            ComboBox1.Items.Add("COM" & CStr(i))
            ComboBox2.Items.Add("COM" & CStr(i))
            ComboBox3.Items.Add("COM" & CStr(i))
            ComboBox4.Items.Add("COM" & CStr(i))
            ComboBox5.Items.Add("COM" & CStr(i))
        Next

    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        PortNumberAmp1 = ComboBox2.Text
        PortNumberAmp2 = ComboBox3.Text
        PortNumberScanner = ComboBox1.Text
        PortNumberPrinter = ComboBox4.Text
        PortNumberCan = ComboBox5.Text

        MicroPhone_Tol = TextBox1.Text
        Sensitivity = TextBox2.Text

        SavePortData()
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class