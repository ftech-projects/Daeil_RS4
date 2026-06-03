Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Media
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO.Ports

Public Class FrmMain

    Private TMpFileName As String

    Sub InitGrid()

        ' FlexCell.Grid → DataGridView 변환
        With Grid1
            .Rows.Clear()
            .Columns.Clear()

            ' 4개 컬럼 추가 (기존 FlexCell 구조 유지)
            .ColumnCount = 4
            .Columns(0).Width = 10     ' 스페이서 컬럼
            .Columns(1).Width = 100
            .Columns(2).Width = 300
            .Columns(3).Width = 200

            ' 컬럼 헤더 설정 (FlexCell Cell(0,n) → HeaderText)
            .Columns(0).HeaderText = ""
            .Columns(1).HeaderText = "Seq"
            .Columns(2).HeaderText = "Part No."
            .Columns(3).HeaderText = "Part Plan."

            ' 모든 컬럼 읽기 전용
            For i As Integer = 0 To 3
                .Columns(i).ReadOnly = True
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            .Refresh()
        End With

    End Sub

    Sub AddPlan(ByVal strPartNo As String, ByVal strPartCOlor As String, ByVal strPlanNum As String)

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset
        Dim tmp As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Plan", MdbConnect)

        Rs.AddNew()

        Rs.Fields("PartNo").Value = strPartNo
        Rs.Fields("PartColor").Value = strPartCOlor
        Rs.Fields("PartPlan").Value = strPlanNum
        Rs.Fields("Seq").Value = Rs.RecordCount
        Rs.Fields("PartCount").Value = "0"
        Rs.Update()

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

    Sub LoadPlan()

        ConnectionOpenMDB()

        Dim Rs As New ADODB.Recordset
        Dim tmp As Integer

        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_Plan ORDER BY LEN(Seq),Seq", MdbConnect)

        ' FlexCell.AddItem → DataGridView.Rows.Add 변환
        If Rs.RecordCount > 1 Then
            Rs.MoveFirst()
            Do Until Rs.EOF
                Grid1.Rows.Add(
                    Trim(Rs.Fields("Seq").Value),
                    Trim(Rs.Fields("PartNo").Value) & Trim(Rs.Fields("PartColor").Value),
                    Trim(Rs.Fields("PartPlan").Value))
                Rs.MoveNext()
            Loop
        ElseIf Rs.RecordCount = 1 Then
            Grid1.Rows.Add(
                Trim(Rs.Fields("Seq").Value),
                Trim(Rs.Fields("PartNo").Value) & Trim(Rs.Fields("PartColor").Value),
                Trim(Rs.Fields("PartPlan").Value))
        ElseIf Rs.RecordCount = 0 Then
            MsgBox("계획을 입력해주세요")
        End If

        Rs.ActiveConnection = Nothing
        Rs.Close()

        ConnectionCloseMDB()

    End Sub

    Private Sub DeleteAllPlan()

        Dim strSQL As String = ""
        ConnectionOpenMDB()

        strSQL = "DELETE FROM TABLE_PLAN"
        MdbConnect.Execute(strSQL)
        ConnectionCloseMDB()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FrmInput.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DeleteAllPlan()
        InitGrid()
        LoadPlan()
    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitGrid()
        LoadPlan()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        End
    End Sub

End Class