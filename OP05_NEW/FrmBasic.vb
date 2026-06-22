Imports System.Globalization

Public Class FrmBasic

    Private Sub FrmBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not LoadBasicData() Then
            MessageBox.Show("Basic 불러오기 실패" & vbCrLf & LastMdbError & vbCrLf & MdbFilePath(),
                            "DB", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        BindBasicFieldsToForm()
    End Sub

    Private Sub BindBasicFieldsToForm()
        srcTxtMax.Text = CStr(BAsicFrtMax_STDLH)
        srcTxtMin.Text = CStr(BAsicFrtMin_STDLH)
        TextBox2.Text = CStr(BAsicRearMax_STDLH)
        TextBox1.Text = CStr(BAsicRearMin_STDLH)

        TextBox6.Text = CStr(BAsicFrtMax_FOLDRH)
        TextBox5.Text = CStr(BAsicFrtMin_FOLDRH)
        TextBox4.Text = CStr(BAsicRearMax_FOLDRH)
        TextBox3.Text = CStr(BAsicRearMin_FOLDRH)

        TextBox10.Text = CStr(BAsicFrtMax_VIPRH)
        TextBox9.Text = CStr(BAsicFrtMin_VIPRH)
        TextBox8.Text = CStr(BAsicRearMax_VIPRH)
        TextBox7.Text = CStr(BAsicRearMin_VIPRH)

        TextBox12.Text = CStr(basicFrtTolVIP)
        TextBox11.Text = CStr(BasicRearTolVIP)

        TextBox14.Text = CStr(basicFrtTolSTD)
        TextBox13.Text = CStr(BasicRearTolSTD)

        TextBox16.Text = CStr(basicFrtTolFOLD)
        TextBox15.Text = CStr(BasicRearTolFOLD)

        CheckBox1.Checked = FlagBeforeCheck
        CheckBox2.Checked = FlagDuplicate
    End Sub

    Private Shared Function ParseBasicNumber(text As String, fieldLabel As String) As Double
        Dim value As Double
        If Double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, value) Then Return value
        If Double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, value) Then Return value
        Throw New FormatException(fieldLabel & " 숫자 형식이 올바르지 않습니다.")
    End Function

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            BAsicFrtMax_STDLH = ParseBasicNumber(srcTxtMax.Text, "STD FRT Max")
            BAsicFrtMin_STDLH = ParseBasicNumber(srcTxtMin.Text, "STD FRT Min")
            BAsicRearMax_STDLH = ParseBasicNumber(TextBox2.Text, "STD REAR Max")
            BAsicRearMin_STDLH = ParseBasicNumber(TextBox1.Text, "STD REAR Min")

            BAsicFrtMax_FOLDRH = ParseBasicNumber(TextBox6.Text, "FOLD FRT Max")
            BAsicFrtMin_FOLDRH = ParseBasicNumber(TextBox5.Text, "FOLD FRT Min")
            BAsicRearMax_FOLDRH = ParseBasicNumber(TextBox4.Text, "FOLD REAR Max")
            BAsicRearMin_FOLDRH = ParseBasicNumber(TextBox3.Text, "FOLD REAR Min")

            BAsicFrtMax_VIPRH = ParseBasicNumber(TextBox10.Text, "VIP FRT Max")
            BAsicFrtMin_VIPRH = ParseBasicNumber(TextBox9.Text, "VIP FRT Min")
            BAsicRearMax_VIPRH = ParseBasicNumber(TextBox8.Text, "VIP REAR Max")
            BAsicRearMin_VIPRH = ParseBasicNumber(TextBox7.Text, "VIP REAR Min")

            basicFrtTolVIP = ParseBasicNumber(TextBox12.Text, "VIP FRT 보정치")
            BasicRearTolVIP = ParseBasicNumber(TextBox11.Text, "VIP REAR 보정치")

            basicFrtTolSTD = ParseBasicNumber(TextBox14.Text, "STD FRT 보정치")
            BasicRearTolSTD = ParseBasicNumber(TextBox13.Text, "STD REAR 보정치")

            basicFrtTolFOLD = ParseBasicNumber(TextBox16.Text, "FOLD FRT 보정치")
            BasicRearTolFOLD = ParseBasicNumber(TextBox15.Text, "FOLD REAR 보정치")

            FlagBeforeCheck = CheckBox1.Checked
            FlagDuplicate = CheckBox2.Checked
        Catch ex As Exception
            MessageBox.Show(ex.Message, "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End Try

        If Not SaveBasicData() Then
            MessageBox.Show("Basic 저장 실패" & vbCrLf & LastMdbError & vbCrLf & MdbFilePath(),
                            "DB", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        MessageBox.Show("Basic 설정이 저장되었습니다.", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class
