Imports System.IO

Public Class FrmAngleBasic

    Private CLickIndex As Integer

    Private Sub InitGrid()

        With Grid1
            .Rows.Clear()
            .Columns.Clear()

            ' FlexCell col0=자동행번호(제거), col1~col9=데이터 → DGV col0~col8
            .Columns.Add("colPartNo", "PartNo")
            .Columns.Add("colLR", "LR")
            .Columns.Add("colType", "Type")
            .Columns.Add("colEndAngleMin", "EndAngleMin")
            .Columns.Add("colEndAngleMax", "EndAngleMax")
            .Columns.Add("colFwdAngleMin", "FwdAngleMin")
            .Columns.Add("colFwdAngleMax", "FwdAngleMax")
            .Columns.Add("colBwdAngleMin", "BwdAngleMin")
            .Columns.Add("colBwdAngleMax", "BwdAngleMax")

            .Columns(0).Width = 150
            .Columns(1).Width = 100
            .Columns(2).Width = 100
            .Columns(3).Width = 140
            .Columns(4).Width = 140
            .Columns(5).Width = 140
            .Columns(6).Width = 140
            .Columns(7).Width = 140
            .Columns(8).Width = 140

            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With

    End Sub

    Private Sub LoadGrid()

        ConnectionOpen()

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)
       
        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
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
            i = 0   ' DGV 0-based 행 인덱스

            Do Until Rs.EOF

                ' FlexCell Cell(i,4)~Cell(i,9) → DGV Rows(i).Cells(3)~Cells(8)
                'Rs.Fields("PartNo").Value = CStr(If(Grid1.Rows(i).Cells(0).Value, ""))
                Rs.Fields("TargetTestEndAngleMin").Value = CStr(If(Grid1.Rows(i).Cells(3).Value, ""))
                Rs.Fields("TargetTestEndAngleMax").Value = CStr(If(Grid1.Rows(i).Cells(4).Value, ""))
                Rs.Fields("TargetTestFwdAngleMin").Value = CStr(If(Grid1.Rows(i).Cells(5).Value, ""))
                Rs.Fields("TargetTestFwdAngleMax").Value = CStr(If(Grid1.Rows(i).Cells(6).Value, ""))
                Rs.Fields("TargetTestBwdAngleMin").Value = CStr(If(Grid1.Rows(i).Cells(7).Value, ""))
                Rs.Fields("TargetTestBwdAngleMax").Value = CStr(If(Grid1.Rows(i).Cells(8).Value, ""))
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