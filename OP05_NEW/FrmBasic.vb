Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows.Forms

Public Class FrmBasic

    ''' <summary>고정 클라이언트 크기 — DPI/자동맞춤 없이 픽셀 고정</summary>
    Private Const FormClientWidth As Integer = 902
    Private Const FormClientHeight As Integer = 571

    Private Shared ReadOnly AllowedControlNames As HashSet(Of String) = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "Button1", "Button2", "Panel1", "Label1", "Label2", "Label3", "Label4", "Label5", "Label6", "Label7",
        "Label9", "Label23", "Label24", "Label25",
        "srcTxtMax", "srcTxtMin", "TextBox1", "TextBox2", "TextBox11", "TextBox12",
        "CheckBox1", "CheckBox2"
    }

    Private Sub FrmBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemoveLegacyBasicControls()
        ApplyPeOnlyLayout()

        If Not LoadBasicData() Then
            MessageBox.Show("Basic 불러오기 실패" & vbCrLf & LastMdbError & vbCrLf & MdbFilePath(),
                            "DB", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        BindBasicFieldsToForm()
    End Sub

    Private Sub RemoveLegacyBasicControls()
        Dim toRemove As New List(Of Control)
        For Each ctrl As Control In Controls
            If Not AllowedControlNames.Contains(ctrl.Name) Then
                toRemove.Add(ctrl)
            End If
        Next

        For Each ctrl As Control In toRemove
            Controls.Remove(ctrl)
            ctrl.Dispose()
        Next
    End Sub

    Private Sub ApplyPeOnlyLayout()
        Text = "Basic (PE)"
        Label1.Text = "PE BASIC SETTING"
        ClientSize = New Drawing.Size(FormClientWidth, FormClientHeight)
    End Sub

    Private Sub BindBasicFieldsToForm()
        srcTxtMax.Text = CStr(BasicFrtMax_PE)
        srcTxtMin.Text = CStr(BasicFrtMin_PE)
        TextBox2.Text = CStr(BasicRearMax_PE)
        TextBox1.Text = CStr(BasicRearMin_PE)

        TextBox12.Text = CStr(basicFrtTolPE)
        TextBox11.Text = CStr(BasicRearTolPE)

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
            BasicFrtMax_PE = ParseBasicNumber(srcTxtMax.Text, "PE FRT Max")
            BasicFrtMin_PE = ParseBasicNumber(srcTxtMin.Text, "PE FRT Min")
            BasicRearMax_PE = ParseBasicNumber(TextBox2.Text, "PE REAR Max")
            BasicRearMin_PE = ParseBasicNumber(TextBox1.Text, "PE REAR Min")

            basicFrtTolPE = ParseBasicNumber(TextBox12.Text, "PE FRT 보정치")
            BasicRearTolPE = ParseBasicNumber(TextBox11.Text, "PE REAR 보정치")

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
