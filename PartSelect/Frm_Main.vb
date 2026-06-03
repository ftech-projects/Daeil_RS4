Imports System.Threading
Imports System.IO
Imports System.Media

Public Class Frm_Main

    Dim FIrstPart As String
    Dim ClickIndex As Integer

    Private Sub LoadPicturbox(ByVal str As String)

        Dim tmp As String
        tmp = Mid(str, 1, 11)

        Try
            srcPictureBox.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\Image\" & tmp & ".png")
        Catch ex As Exception
        End Try

        Try
            Mid(tmp, 5, 1) = "0"
            srcPictureBox.Image = System.Drawing.Image.FromFile(System.AppDomain.CurrentDomain.BaseDirectory & "\Image\" & tmp & ".png")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub LoadColorCombobox()

        Connection_Open()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Color", Sql_Connect)

        If Rs.RecordCount >= 1 Then

            Rs.MoveFirst()
            Do Until Rs.EOF
                ComboBox1.Items.Add(Trim(Rs.Fields("ColorCode").Value))
                Rs.MoveNext()
            Loop

        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        Connection_Close()

    End Sub

    Private Sub LoadWorkPArt()

        Connection_Open()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Etc", Sql_Connect)

        If Rs.RecordCount = 1 Then

            FIrstPart = Rs.Fields("SELECT_PART").Value
            LoadPicturbox(FIrstPart)
            srcLbPartNo.Text = FIrstPart
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        Connection_Close()

    End Sub

    Private Sub LoadWorkPArtSelect(ByVal str As String)

        Connection_Open()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Etc", Sql_Connect)

        If Rs.RecordCount = 1 Then
            Rs.Fields("SELECT_PART").Value = str
            Rs.Update()
        End If

        If str = "" And str = "0" Then
        Else
            srcLbPartNo.Text = str
            LoadPicturbox(str)
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        Connection_Close()

    End Sub

    Private Sub Load_Grid()

        Connection_Open()

        Dim Rs As New ADODB.Recordset

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Init_Grid()

        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", Sql_Connect)

        If Rs.RecordCount <= 0 Then
            MsgBox("Empty Point Info.")
        Else
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid1.Rows.Add(Trim(Rs.Fields("partno").Value),
                               Trim(Rs.Fields("partname").Value))
                Rs.MoveNext()
            Loop
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        Connection_Close()

    End Sub

    Private Sub Init_Grid()

        With Grid1
            ' 기존 데이터 초기화
            .Rows.Clear()
            .Columns.Clear()

            ' 컬럼 추가 (FlexCell col1=PartNo, col2=PartInfo → DGV col0, col1)
            .Columns.Add("colPartNo", "  Part No.")
            .Columns.Add("colPartInfo", "  Part Info.")

            ' 컬럼 너비
            .Columns(0).Width = 110
            .Columns(1).Width = 310

            ' 왼쪽 정렬 (AlignmentEnum.LeftCenter)
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            Next
        End With

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        End
    End Sub

    Private Sub Load_FirstPart()

        Dim tPart As Integer = 0

        For i As Integer = 0 To Grid1.RowCount - 1
            If Grid1.Rows(i).IsNewRow Then Continue For
            ' 행 색 초기화
            Grid1.Rows(i).Cells(0).Style.BackColor = Color.White
            Grid1.Rows(i).Cells(0).Style.ForeColor = Color.Black
            Grid1.Rows(i).Cells(1).Style.BackColor = Color.White
            Grid1.Rows(i).Cells(1).Style.ForeColor = Color.Black
            ' 현재 파트 찾기
            If CStr(If(Grid1.Rows(i).Cells(0).Value, "")) = FIrstPart Then
                tPart = i
            End If
        Next

        If tPart >= 0 AndAlso tPart < Grid1.RowCount Then
            Grid1.Rows(tPart).Cells(0).Style.BackColor = Color.Blue
            Grid1.Rows(tPart).Cells(0).Style.ForeColor = Color.White
            Grid1.Rows(tPart).Cells(1).Style.BackColor = Color.Blue
            Grid1.Rows(tPart).Cells(1).Style.ForeColor = Color.White
            LoadPicturbox(CStr(If(Grid1.Rows(tPart).Cells(0).Value, "")))
        End If

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Frm_Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Init_Grid()
        Load_Grid()
        LoadColorCombobox()
        LoadWorkPArt()
        Load_FirstPart()

    End Sub

    Private Sub Grid1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid1.CellClick

        If e.RowIndex < 0 Then Return  ' 헤더 클릭 무시
        ClickIndex = e.RowIndex

        For i As Integer = 0 To Grid1.RowCount - 1
            If Grid1.Rows(i).IsNewRow Then Continue For
            Grid1.Rows(i).Cells(0).Style.BackColor = Color.White
            Grid1.Rows(i).Cells(0).Style.ForeColor = Color.Black
            Grid1.Rows(i).Cells(1).Style.BackColor = Color.White
            Grid1.Rows(i).Cells(1).Style.ForeColor = Color.Black
        Next

        If ClickIndex >= 0 AndAlso ClickIndex < Grid1.RowCount Then
            Grid1.Rows(ClickIndex).Cells(0).Style.BackColor = Color.Blue
            Grid1.Rows(ClickIndex).Cells(0).Style.ForeColor = Color.White
            Grid1.Rows(ClickIndex).Cells(1).Style.BackColor = Color.Blue
            Grid1.Rows(ClickIndex).Cells(1).Style.ForeColor = Color.White
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim selPartNo As String = CStr(If(Grid1.RowCount > ClickIndex AndAlso ClickIndex >= 0, Grid1.Rows(ClickIndex).Cells(0).Value, "")) & ComboBox1.Text
        srcLbPartNo.Text = selPartNo

        If selPartNo.Length >= 14 Then
            LoadWorkPArtSelect(selPartNo)
        Else
            MsgBox("사양을 선택해주세요")
        End If

    End Sub

End Class
