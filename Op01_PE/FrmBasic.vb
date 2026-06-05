Public Class FrmBasic
    Private srcTxtAtlasTool1Ip As TextBox
    Private srcTxtAtlasTool2Ip As TextBox

    Private Sub FrmBasic_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        EnsureAtlasIpControls()
        srcTxtMin.Text = CStr(BasicToolMin)
        srcTxtMax.Text = CStr(BasicToolMax)
        srcTxtUnit.Text = CStr(BAsicUnit)
        srcTxtAtlasTool1Ip.Text = CStr(AtlasTool1Ip)
        srcTxtAtlasTool2Ip.Text = CStr(AtlasTool2Ip)

    End Sub

    Private Sub EnsureAtlasIpControls()

        If srcTxtAtlasTool1Ip IsNot Nothing Then Exit Sub

        Dim lbGroup As New Label With {
            .BackColor = Color.Silver,
            .BorderStyle = BorderStyle.FixedSingle,
            .Font = New Font("Arial Narrow", 22.0!, FontStyle.Bold),
            .ForeColor = Color.Black,
            .Location = New Point(1, 171),
            .Name = "LabelAtlasGroup",
            .Size = New Size(80, 70),
            .Text = "ATLAS",
            .TextAlign = ContentAlignment.MiddleCenter
        }

        Dim lbTool1 As New Label With {
            .BackColor = Color.Silver,
            .BorderStyle = BorderStyle.FixedSingle,
            .Font = New Font("Arial Narrow", 18.0!, FontStyle.Bold),
            .ForeColor = Color.Black,
            .Location = New Point(81, 171),
            .Name = "LabelAtlasTool1",
            .Size = New Size(132, 35),
            .Text = "TOOL1 IP",
            .TextAlign = ContentAlignment.MiddleCenter
        }

        Dim lbTool2 As New Label With {
            .BackColor = Color.Silver,
            .BorderStyle = BorderStyle.FixedSingle,
            .Font = New Font("Arial Narrow", 18.0!, FontStyle.Bold),
            .ForeColor = Color.Black,
            .Location = New Point(81, 206),
            .Name = "LabelAtlasTool2",
            .Size = New Size(132, 35),
            .Text = "TOOL2 IP",
            .TextAlign = ContentAlignment.MiddleCenter
        }

        srcTxtAtlasTool1Ip = New TextBox With {
            .Font = New Font("Arial Narrow", 18.0!),
            .Location = New Point(213, 171),
            .Name = "srcTxtAtlasTool1Ip",
            .Size = New Size(193, 35)
        }

        srcTxtAtlasTool2Ip = New TextBox With {
            .Font = New Font("Arial Narrow", 18.0!),
            .Location = New Point(213, 206),
            .Name = "srcTxtAtlasTool2Ip",
            .Size = New Size(193, 35)
        }

        Controls.Add(lbGroup)
        Controls.Add(lbTool1)
        Controls.Add(lbTool2)
        Controls.Add(srcTxtAtlasTool1Ip)
        Controls.Add(srcTxtAtlasTool2Ip)

        Button1.Location = New Point(1, 311)
        Button2.Location = New Point(406, 311)
        ClientSize = New Size(812, 362)

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        BAsicUnit = CStr(srcTxtUnit.Text)
        BasicToolMin = CStr(srcTxtMin.Text)
        BasicToolMax = CStr(srcTxtMax.Text)
        AtlasTool1Ip = CStr(srcTxtAtlasTool1Ip.Text).Trim()
        AtlasTool2Ip = CStr(srcTxtAtlasTool2Ip.Text).Trim()

        SaveBasicData()
        FrmMain.ReinitializeAtlasTools()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class
