Imports System.Globalization
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmBasic

    Private txtPeFrtMax As TextBox
    Private txtPeFrtMin As TextBox
    Private txtPeRearMax As TextBox
    Private txtPeRearMin As TextBox
    Private txtPeFrtTol As TextBox
    Private txtPeRearTol As TextBox
    Private _peUiReady As Boolean

    Private Sub FrmBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsurePeBasicUi()
        If Not LoadBasicData() Then
            MessageBox.Show("Basic 불러오기 실패" & vbCrLf & LastMdbError & vbCrLf & MdbFilePath(),
                            "DB", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        BindBasicFieldsToForm()
    End Sub

    Private Sub EnsurePeBasicUi()
        If _peUiReady Then Return
        _peUiReady = True

        Dim gb As New GroupBox With {
            .Text = "PE Line 길이 공차",
            .Location = New Point(12, 430),
            .Size = New Size(870, 120),
            .Font = New Font("맑은 고딕", 10.0F, FontStyle.Bold)
        }

        Dim lblFrt As New Label With {.Text = "FRT Min/Max", .Location = New Point(16, 32), .AutoSize = True}
        txtPeFrtMin = New TextBox With {.Location = New Point(120, 28), .Size = New Size(80, 27)}
        txtPeFrtMax = New TextBox With {.Location = New Point(210, 28), .Size = New Size(80, 27)}

        Dim lblRear As New Label With {.Text = "REAR Min/Max", .Location = New Point(310, 32), .AutoSize = True}
        txtPeRearMin = New TextBox With {.Location = New Point(430, 28), .Size = New Size(80, 27)}
        txtPeRearMax = New TextBox With {.Location = New Point(520, 28), .Size = New Size(80, 27)}

        Dim lblTol As New Label With {.Text = "FRT/REAR 보정치", .Location = New Point(16, 72), .AutoSize = True}
        txtPeFrtTol = New TextBox With {.Location = New Point(150, 68), .Size = New Size(80, 27)}
        txtPeRearTol = New TextBox With {.Location = New Point(240, 68), .Size = New Size(80, 27)}

        gb.Controls.AddRange(New Control() {
            lblFrt, txtPeFrtMin, txtPeFrtMax,
            lblRear, txtPeRearMin, txtPeRearMax,
            lblTol, txtPeFrtTol, txtPeRearTol
        })
        Controls.Add(gb)
        ClientSize = New Size(902, 570)
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

        If txtPeFrtMin IsNot Nothing Then
            txtPeFrtMin.Text = CStr(BasicFrtMin_PE)
            txtPeFrtMax.Text = CStr(BasicFrtMax_PE)
            txtPeRearMin.Text = CStr(BasicRearMin_PE)
            txtPeRearMax.Text = CStr(BasicRearMax_PE)
            txtPeFrtTol.Text = CStr(basicFrtTolPE)
            txtPeRearTol.Text = CStr(BasicRearTolPE)
        End If

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

            If txtPeFrtMin IsNot Nothing Then
                BasicFrtMin_PE = ParseBasicNumber(txtPeFrtMin.Text, "PE FRT Min")
                BasicFrtMax_PE = ParseBasicNumber(txtPeFrtMax.Text, "PE FRT Max")
                BasicRearMin_PE = ParseBasicNumber(txtPeRearMin.Text, "PE REAR Min")
                BasicRearMax_PE = ParseBasicNumber(txtPeRearMax.Text, "PE REAR Max")
                basicFrtTolPE = ParseBasicNumber(txtPeFrtTol.Text, "PE FRT 보정치")
                BasicRearTolPE = ParseBasicNumber(txtPeRearTol.Text, "PE REAR 보정치")
            End If

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
