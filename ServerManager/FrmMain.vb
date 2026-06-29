Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO

Public Class FrmMain

    Private mstrDatabase As String
    Private myDataAdapter As OleDbDataAdapter
    Private myDataSet As DataSet
    Private mstrDatabase2 As String
    Private myDataAdapter2 As OleDbDataAdapter
    Private myDataSet2 As DataSet

    Private Function FieldGridValue(ByVal fld As ADODB.Field) As Object
        If IsDBNull(fld.Value) Then
            Return DBNull.Value
        ElseIf TypeOf fld.Value Is String Then
            Return Trim(CStr(fld.Value))
        Else
            Return fld.Value
        End If
    End Function

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ComboBox1.Items.Add("OP01")
        ComboBox1.Items.Add("OP02_1")
        ComboBox1.Items.Add("OP02_2")
        ComboBox1.Items.Add("OP VIP")
        ComboBox1.Items.Add("OP03")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ComboBox1.Text = "OP01" Then
            InitGridOP01()
            LoadGridOp01()
        ElseIf ComboBox1.Text = "OP02_1" Then
            InitGridOP02_1()
            LoadGridOp02_1()
        ElseIf ComboBox1.Text = "OP02_2" Then
            InitGridOP02_2()
            LoadGridOp02_2()
        ElseIf ComboBox1.Text = "OP VIP" Then
            InitGridOpVIP()
            LoadGridOpVIP()
        ElseIf ComboBox1.Text = "OP03" Then
            InitGridOp03()
            LoadGridOp03()
        Else
            MsgBox("설정할 공정을 선택해주세요")
        End If

    End Sub

    Private Sub InitGridOP01()

        ' DataGridView 컬럼 재구성 (8컬럼: 0=숨김, 1=PartNo, ..., 7=FrameBarcode)
        Grid2.SuspendLayout()
        Grid2.Columns.Clear()
        Grid2.Rows.Clear()
        Grid2.ColumnCount = 8
        Grid2.AllowUserToResizeColumns = False
        Grid2.AllowUserToResizeRows = False
        Grid2.Columns(0).Visible = False
        Grid2.Columns(1).HeaderText = "PartNo"
        Grid2.Columns(2).HeaderText = "Position"
        Grid2.Columns(3).HeaderText = "Type"
        Grid2.Columns(4).HeaderText = "MotorTq"
        Grid2.Columns(5).HeaderText = "MotorBarcode"
        Grid2.Columns(6).HeaderText = "ToolNum"
        Grid2.Columns(7).HeaderText = "FrameBarcode"
        Grid2.Columns(1).Width = 150
        Grid2.Columns(2).Width = 70
        Grid2.Columns(3).Width = 180
        Grid2.Columns(4).Width = 140
        Grid2.Columns(5).Width = 140
        Grid2.Columns(6).Width = 140
        Grid2.Columns(7).Width = 180
        Grid2.Columns(1).ReadOnly = True
        Grid2.Columns(2).ReadOnly = True
        Grid2.Columns(3).ReadOnly = True
        For i As Integer = 1 To 7
            Grid2.Columns(i).DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Next
        Grid2.ResumeLayout()

    End Sub

    Private Sub LoadGridOp01()

        ConnectionOpen()

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)

        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid2.Rows.Add("",
                    FieldGridValue(Rs.Fields("PartNo")),
                    FieldGridValue(Rs.Fields("OptionLhrh")),
                    FieldGridValue(Rs.Fields("OptionType")),
                    FieldGridValue(Rs.Fields("Use_Op01_MotorTq")),
                    FieldGridValue(Rs.Fields("Target_Op01_MotorBarcode")),
                    FieldGridValue(Rs.Fields("Target_Op01_ToolNum")),
                    FieldGridValue(Rs.Fields("Target_Op01_FrameBarcode")))
                Rs.MoveNext()
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()

    End Sub

    Private Sub SaveGridOp01()
        ConnectionOpen()
        Dim Rs As New ADODB.Recordset
        Dim i As Integer
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)
        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            i = 0
            Do Until Rs.EOF
                Rs.Fields("Use_Op01_MotorTq").Value = Grid2.Rows(i).Cells(4).Value
                Rs.Fields("Target_Op01_MotorBarcode").Value = Grid2.Rows(i).Cells(5).Value
                Rs.Fields("Target_Op01_ToolNum").Value = Grid2.Rows(i).Cells(6).Value
                Rs.Fields("Target_Op01_FrameBarcode").Value = Grid2.Rows(i).Cells(7).Value
                Rs.Update()
                Rs.MoveNext()
                i = i + 1
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()
    End Sub

    Private Sub InitGridOP02_1()

        ' DataGridView 컬럼 재구성 (9컬럼)
        Grid2.SuspendLayout()
        Grid2.Columns.Clear()
        Grid2.Rows.Clear()
        Grid2.ColumnCount = 9
        Grid2.AllowUserToResizeColumns = False
        Grid2.AllowUserToResizeRows = False
        Grid2.Columns(0).Visible = False
        Grid2.Columns(1).HeaderText = "PartNo"
        Grid2.Columns(2).HeaderText = "Position"
        Grid2.Columns(3).HeaderText = "Type"
        Grid2.Columns(4).HeaderText = "Harness Barcode"
        Grid2.Columns(5).HeaderText = "L/Supt Barcode"
        Grid2.Columns(6).HeaderText = "L/Supt Version"
        Grid2.Columns(7).HeaderText = "ToolNum1"
        Grid2.Columns(8).HeaderText = "ToolNum2"
        Grid2.Columns(1).Width = 150
        Grid2.Columns(2).Width = 70
        Grid2.Columns(3).Width = 180
        Grid2.Columns(4).Width = 140
        Grid2.Columns(5).Width = 140
        Grid2.Columns(6).Width = 140
        Grid2.Columns(7).Width = 100
        Grid2.Columns(8).Width = 100
        Grid2.Columns(1).ReadOnly = True
        Grid2.Columns(2).ReadOnly = True
        Grid2.Columns(3).ReadOnly = True
        For i As Integer = 1 To 8
            Grid2.Columns(i).DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Next
        Grid2.ResumeLayout()

    End Sub

    Private Sub LoadGridOp02_1()

        ConnectionOpen()

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)

        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid2.Rows.Add("",
                    FieldGridValue(Rs.Fields("PartNo")),
                    FieldGridValue(Rs.Fields("OptionLhrh")),
                    FieldGridValue(Rs.Fields("OptionType")),
                    FieldGridValue(Rs.Fields("Target_Op02_HarnessBarcode")),
                    FieldGridValue(Rs.Fields("Target_Op02_LsuptBarcode")),
                    FieldGridValue(Rs.Fields("Target_Op02_LsuptVersion")),
                    FieldGridValue(Rs.Fields("Target_Op02_ToolNum")),
                    FieldGridValue(Rs.Fields("Target_Op02_ToolNum2")))
                Rs.MoveNext()
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()

    End Sub

    Private Sub SaveGridOp02_1()
        ConnectionOpen()
        Dim Rs As New ADODB.Recordset
        Dim i As Integer
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)
        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            i = 0
            Do Until Rs.EOF
                Rs.Fields("Target_Op02_HarnessBarcode").Value = Grid2.Rows(i).Cells(4).Value
                Rs.Fields("Target_Op02_LsuptBarcode").Value = Grid2.Rows(i).Cells(5).Value
                Rs.Fields("Target_Op02_LsuptVersion").Value = Grid2.Rows(i).Cells(6).Value
                Rs.Fields("Target_Op02_ToolNum").Value = Grid2.Rows(i).Cells(7).Value
                Rs.Fields("Target_Op02_ToolNum2").Value = Grid2.Rows(i).Cells(8).Value
                Rs.Update()
                Rs.MoveNext()
                i = i + 1
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()
    End Sub

    Private Sub InitGridOP02_2()

        ' DataGridView 컬럼 재구성 (13컬럼)
        Grid2.SuspendLayout()
        Grid2.Columns.Clear()
        Grid2.Rows.Clear()
        Grid2.ColumnCount = 13
        Grid2.AllowUserToResizeColumns = False
        Grid2.AllowUserToResizeRows = False
        Grid2.Columns(0).Visible = False
        Grid2.Columns(1).HeaderText = "PartNo"
        Grid2.Columns(2).HeaderText = "Position"
        Grid2.Columns(3).HeaderText = "Type"
        Grid2.Columns(4).HeaderText = "MotorTq"
        Grid2.Columns(5).HeaderText = "MotorBarcode"
        Grid2.Columns(6).HeaderText = "SabTq"
        Grid2.Columns(7).HeaderText = "SabBarcode"
        Grid2.Columns(8).HeaderText = "SabResist"
        Grid2.Columns(9).HeaderText = "cSabTq"
        Grid2.Columns(10).HeaderText = "cSabBarcode"
        Grid2.Columns(11).HeaderText = "cSabResist"
        Grid2.Columns(12).HeaderText = "MonitorBarcode"
        Grid2.Columns(1).Width = 150
        Grid2.Columns(2).Width = 70
        Grid2.Columns(3).Width = 100
        Grid2.Columns(4).Width = 90
        Grid2.Columns(5).Width = 120
        Grid2.Columns(6).Width = 90
        Grid2.Columns(7).Width = 120
        Grid2.Columns(8).Width = 90
        Grid2.Columns(9).Width = 90
        Grid2.Columns(10).Width = 120
        Grid2.Columns(11).Width = 90
        Grid2.Columns(12).Width = 120
        Grid2.Columns(1).ReadOnly = True
        Grid2.Columns(2).ReadOnly = True
        Grid2.Columns(3).ReadOnly = True
        For i As Integer = 1 To 12
            Grid2.Columns(i).DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Next
        Grid2.ResumeLayout()

    End Sub

    Private Sub LoadGridOp02_2()

        ConnectionOpen()

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)

        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid2.Rows.Add("",
                    FieldGridValue(Rs.Fields("PartNo")),
                    FieldGridValue(Rs.Fields("OptionLhrh")),
                    FieldGridValue(Rs.Fields("OptionType")),
                    FieldGridValue(Rs.Fields("Use_Op02_MotorTq")),
                    FieldGridValue(Rs.Fields("Target_Op02_MotorBarcode")),
                    FieldGridValue(Rs.Fields("Use_Op02_Sab_Tq")),
                    FieldGridValue(Rs.Fields("Target_Op02_Sab_Barcode")),
                    FieldGridValue(Rs.Fields("Use_Op02_Sab_Resist")),
                    FieldGridValue(Rs.Fields("Use_Op02_cSab_Tq")),
                    FieldGridValue(Rs.Fields("Target_Op02_cSab_Barcode")),
                    FieldGridValue(Rs.Fields("Use_Op02_cSab_Resist")),
                    FieldGridValue(Rs.Fields("Target_Op02_MonitorCableBarcode")))
                Rs.MoveNext()
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()

    End Sub

    Private Sub SaveGridOp02_2()
        ConnectionOpen()
        Dim Rs As New ADODB.Recordset
        Dim i As Integer
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)
        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            i = 0
            Do Until Rs.EOF
                Rs.Fields("Use_Op02_MotorTq").Value = Grid2.Rows(i).Cells(4).Value
                Rs.Fields("Target_Op02_MotorBarcode").Value = Grid2.Rows(i).Cells(5).Value
                Rs.Fields("Use_Op02_Sab_Tq").Value = Grid2.Rows(i).Cells(6).Value
                Rs.Fields("Target_Op02_Sab_Barcode").Value = Grid2.Rows(i).Cells(7).Value
                Rs.Fields("Use_Op02_Sab_Resist").Value = Grid2.Rows(i).Cells(8).Value
                Rs.Fields("Use_Op02_cSab_Tq").Value = Grid2.Rows(i).Cells(9).Value
                Rs.Fields("Target_Op02_cSab_Barcode").Value = Grid2.Rows(i).Cells(10).Value
                Rs.Fields("Use_Op02_cSab_Resist").Value = Grid2.Rows(i).Cells(11).Value
                Rs.Fields("Target_Op02_MonitorCableBarcode").Value = Grid2.Rows(i).Cells(12).Value
                Rs.Update()
                Rs.MoveNext()
                i = i + 1
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()
    End Sub

    Private Sub InitGridOpVIP()

        ' DataGridView 컬럼 재구성 (10컬럼)
        Grid2.SuspendLayout()
        Grid2.Columns.Clear()
        Grid2.Rows.Clear()
        Grid2.ColumnCount = 10
        Grid2.AllowUserToResizeColumns = False
        Grid2.AllowUserToResizeRows = False
        Grid2.Columns(0).Visible = False
        Grid2.Columns(1).HeaderText = "PartNo"
        Grid2.Columns(2).HeaderText = "Position"
        Grid2.Columns(3).HeaderText = "Type"
        Grid2.Columns(4).HeaderText = "HarnessBarcode"
        Grid2.Columns(5).HeaderText = "Rivet 1st"
        Grid2.Columns(6).HeaderText = "Rivet 2nd"
        Grid2.Columns(7).HeaderText = "Rivet 3rd"
        Grid2.Columns(8).HeaderText = "ToolNum"
        Grid2.Columns(9).HeaderText = "MonitorBarcode"
        Grid2.Columns(1).Width = 150
        Grid2.Columns(2).Width = 70
        Grid2.Columns(3).Width = 100
        Grid2.Columns(4).Width = 150
        Grid2.Columns(5).Width = 100
        Grid2.Columns(6).Width = 100
        Grid2.Columns(7).Width = 100
        Grid2.Columns(8).Width = 100
        Grid2.Columns(9).Width = 120
        Grid2.Columns(1).ReadOnly = True
        Grid2.Columns(2).ReadOnly = True
        Grid2.Columns(3).ReadOnly = True
        For i As Integer = 1 To 9
            Grid2.Columns(i).DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Next
        Grid2.ResumeLayout()

    End Sub

    Private Sub LoadGridOpVIP()

        ConnectionOpen()

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)

        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid2.Rows.Add("",
                    FieldGridValue(Rs.Fields("PartNo")),
                    FieldGridValue(Rs.Fields("OptionLhrh")),
                    FieldGridValue(Rs.Fields("OptionType")),
                    FieldGridValue(Rs.Fields("Target_OpVip_HarnessBarcode")),
                    FieldGridValue(Rs.Fields("Target_OpVip_ToolNum")),
                    FieldGridValue(Rs.Fields("Target_OpVip_Rivet1Num")),
                    FieldGridValue(Rs.Fields("Target_OpVip_Rivet2Num")),
                    FieldGridValue(Rs.Fields("Target_OpVip_Rivet3Num")),
                    FieldGridValue(Rs.Fields("Target_OpVip_MonitorCableBarcode")))
                Rs.MoveNext()
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()

    End Sub

    Private Sub SaveGridOpVIP()
        ConnectionOpen()
        Dim Rs As New ADODB.Recordset
        Dim i As Integer
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)
        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            i = 0
            Do Until Rs.EOF
                Rs.Fields("Target_OpVip_HarnessBarcode").Value = Grid2.Rows(i).Cells(4).Value
                Rs.Fields("Target_OpVip_ToolNum").Value = Grid2.Rows(i).Cells(5).Value
                Rs.Fields("Target_OpVip_Rivet1Num").Value = Grid2.Rows(i).Cells(6).Value
                Rs.Fields("Target_OpVip_Rivet2Num").Value = Grid2.Rows(i).Cells(7).Value
                Rs.Fields("Target_OpVip_Rivet3Num").Value = Grid2.Rows(i).Cells(8).Value
                Rs.Fields("Target_OpVip_MonitorCableBarcode").Value = Grid2.Rows(i).Cells(9).Value
                Rs.Update()
                Rs.MoveNext()
                i = i + 1
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()
    End Sub

    Private Sub InitGridOp03()

        ' DataGridView 컬럼 재구성 (8컬럼)
        Grid2.SuspendLayout()
        Grid2.Columns.Clear()
        Grid2.Rows.Clear()
        Grid2.ColumnCount = 8
        Grid2.AllowUserToResizeColumns = False
        Grid2.AllowUserToResizeRows = False
        Grid2.Columns(0).Visible = False
        Grid2.Columns(1).HeaderText = "PartNo"
        Grid2.Columns(2).HeaderText = "Position"
        Grid2.Columns(3).HeaderText = "Type"
        Grid2.Columns(4).HeaderText = "ToolNum"
        Grid2.Columns(5).HeaderText = "RivetNum"
        Grid2.Columns(6).HeaderText = "InsideCoverL"
        Grid2.Columns(7).HeaderText = "InsideCoverR"
        Grid2.Columns(1).Width = 150
        Grid2.Columns(2).Width = 70
        Grid2.Columns(3).Width = 100
        Grid2.Columns(4).Width = 150
        Grid2.Columns(5).Width = 150
        Grid2.Columns(6).Width = 150
        Grid2.Columns(7).Width = 150
        Grid2.Columns(1).ReadOnly = True
        Grid2.Columns(2).ReadOnly = True
        Grid2.Columns(3).ReadOnly = True
        For i As Integer = 1 To 7
            Grid2.Columns(i).DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Next
        Grid2.ResumeLayout()

    End Sub

    Private Sub LoadGridOp03()

        ConnectionOpen()

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)

        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid2.Rows.Add("",
                    FieldGridValue(Rs.Fields("PartNo")),
                    FieldGridValue(Rs.Fields("OptionLhrh")),
                    FieldGridValue(Rs.Fields("OptionType")),
                    FieldGridValue(Rs.Fields("Target_Op04_ToolNum")),
                    FieldGridValue(Rs.Fields("Target_Op04_RivetNum")),
                    FieldGridValue(Rs.Fields("Target_Op03_InsideCoverL")),
                    FieldGridValue(Rs.Fields("Target_Op03_InsideCoverR")))
                Rs.MoveNext()
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()

    End Sub

    Private Sub SaveGridOp03()
        ConnectionOpen()
        Dim Rs As New ADODB.Recordset
        Dim i As Integer
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_Part ORDER BY LEN(PartNo),PartNo", SqlConnect)
        If Rs.RecordCount >= 1 Then
            Rs.MoveFirst()
            i = 0
            Do Until Rs.EOF
                Rs.Fields("Target_Op04_ToolNum").Value = Grid2.Rows(i).Cells(4).Value
                Rs.Fields("Target_Op04_RivetNum").Value = Grid2.Rows(i).Cells(5).Value
                Rs.Fields("Target_Op03_InsideCoverL").Value = Grid2.Rows(i).Cells(6).Value
                Rs.Fields("Target_Op03_InsideCoverR").Value = Grid2.Rows(i).Cells(7).Value
                Rs.Update()
                Rs.MoveNext()
                i = i + 1
            Loop
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionClose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If ComboBox1.Text = "OP01" Then
            SaveGridOp01()
            MsgBox("저장되었습니다")
        ElseIf ComboBox1.Text = "OP02_1" Then
            SaveGridOp02_1()
            MsgBox("저장되었습니다")
        ElseIf ComboBox1.Text = "OP02_2" Then
            SaveGridOp02_2()
            MsgBox("저장되었습니다")
        ElseIf ComboBox1.Text = "OP VIP" Then
            SaveGridOpVIP()
            MsgBox("저장되었습니다")
        ElseIf ComboBox1.Text = "OP03" Then
            SaveGridOp03()
            MsgBox("저장되었습니다")
        Else
            MsgBox("설정할 공정을 선택해주세요")
        End If

    End Sub

    Private Sub SetDataBinding()

        GetDataSet()
        Grid3.DataSource = myDataSet.Tables("Table_Main")

    End Sub

    Private Sub GetDataSet()

        Dim conn As OleDbConnection

        Dim Qurry1 As String = "SELECT * FROM Table_Main WHERE (OP01_DATE BETWEEN '" & Format(srcDtpStart.Value, "yyyy-MM-dd") & _
                        "' AND '" & Format(srcDtpEnd.Value, "yyyy-MM-dd") & "')"

        Dim Qurry2 As String = "SELECT * FROM Table_Main WHERE (OP01_DATE BETWEEN '" & Format(srcDtpStart.Value, "yyyy-MM-dd") & _
                        "' AND '" & Format(srcDtpEnd.Value, "yyyy-MM-dd") & "') AND (SerialNo LIKE '%" & srcTxtSerial.Text & "%')"

        Dim ConString As String = "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,"

        conn = New OleDbConnection
        conn.ConnectionString = ConString
        conn.Open()
        myDataSet = New DataSet
        If srcTxtSerial.Text = "" Then
            myDataAdapter = New OleDbDataAdapter(Qurry1, conn)
        Else
            myDataAdapter = New OleDbDataAdapter(Qurry2, conn)
        End If

        myDataAdapter.Fill(myDataSet, "Table_Main")
        conn.Close()

    End Sub

    Private Sub ConvertExcel()

        ' TODO: DataGridView는 ExportToExcel 미지원 - 별도 구현 필요
        MsgBox("Excel 내보내기 기능은 별도 구현이 필요합니다.", MsgBoxStyle.Information)

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        SetDataBinding()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        ConvertExcel()
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub
End Class