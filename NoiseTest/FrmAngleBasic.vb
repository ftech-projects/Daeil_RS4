Imports System.IO

Public Class FrmAngleBasic

    Private CLickIndex As Integer

    ' === DataGridView 헬퍼: 1-base FlexCell (Cell(r, c), Column(c).Width 등) → 0-base DGV ===
    Private Sub InitGrid()

        With Grid1
            ' DataGridView 기본 셋업 (FlexCell의 AutoRedraw/DrawMode/AllowUserResizing는 무시)
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            ' 컬럼 9개 생성 (FlexCell의 col 1~9 매핑 — col 0은 행번호용이라 미사용)
            ' DGV는 0-base. 1번 컬럼(인덱스 0) = PartNo
            .Columns.Clear()
            Dim headers As String() = {"PartNo", "LR", "Type",
                                       "EndAngleMin", "EndAngleMax",
                                       "FwdAngleMin", "FwdAngleMax",
                                       "BwdAngleMin", "BwdAngleMax"}
            Dim widths As Integer() = {150, 100, 100, 140, 140, 140, 140, 140, 140}
            For i As Integer = 0 To headers.Length - 1
                Dim col As New DataGridViewTextBoxColumn()
                col.HeaderText = headers(i)
                col.Width = widths(i)
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                ' PartNo/LR/Type 열은 읽기 전용
                If i <= 2 Then col.ReadOnly = True
                .Columns.Add(col)
            Next

            .Refresh()
        End With

    End Sub

    Private Sub LoadGrid()

        ConnectionOpen()

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)

        Grid1.Rows.Clear()
        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                ' AddItem 대체: 9개 셀 한꺼번에 Add
                Grid1.Rows.Add(
                    Trim(Rs.Fields("PartNo").Value),
                    Trim(Rs.Fields("OptionLhrh").Value),
                    Trim(Rs.Fields("OptionType").Value),
                    Trim(Rs.Fields("TargetTestEndAngleMin").Value),
                    Trim(Rs.Fields("TargetTestEndAngleMax").Value),
                    Trim(Rs.Fields("TargetTestFwdAngleMin").Value),
                    Trim(Rs.Fields("TargetTestFwdAngleMax").Value),
                    Trim(Rs.Fields("TargetTestBwdAngleMin").Value),
                    Trim(Rs.Fields("TargetTestBwdAngleMax").Value))
                Rs.MoveNext()
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionClose()

    End Sub

    Private Sub SaveGrid()

        ConnectionOpen()

        Dim Rs As New ADODB.Recordset
        Dim i As Integer
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)

        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            i = 0  ' DGV는 0-base
            Do Until Rs.EOF
                If i >= Grid1.Rows.Count Then Exit Do
                ' FlexCell 인덱스 4~9 (1-base) → DGV 인덱스 3~8 (0-base)
                Rs.Fields("TargetTestEndAngleMin").Value = CStr(Grid1.Rows(i).Cells(3).Value)
                Rs.Fields("TargetTestEndAngleMax").Value = CStr(Grid1.Rows(i).Cells(4).Value)
                Rs.Fields("TargetTestFwdAngleMin").Value = CStr(Grid1.Rows(i).Cells(5).Value)
                Rs.Fields("TargetTestFwdAngleMax").Value = CStr(Grid1.Rows(i).Cells(6).Value)
                Rs.Fields("TargetTestBwdAngleMin").Value = CStr(Grid1.Rows(i).Cells(7).Value)
                Rs.Fields("TargetTestBwdAngleMax").Value = CStr(Grid1.Rows(i).Cells(8).Value)
                Rs.Update()
                Rs.MoveNext()
                i = i + 1
            Loop
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionClose()

    End Sub

    Private Sub FrmAngleBasic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        InitGrid()
        LoadGrid()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SaveGrid()
        Me.Close()
    End Sub

End Class
