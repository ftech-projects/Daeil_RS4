Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Imports System.Threading
Imports System.Media
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Frmsearch

    '******************************************************************************
    '변수
    '******************************************************************************
    Private mstrDatabase As String
    Private myDataAdapter As OleDbDataAdapter
    Private myDataSet As DataSet
    '******************************************************************************
    '초기화    
    '******************************************************************************

    '******************************************************************************
    'Dataset handling
    '******************************************************************************

    Private Sub Frmsearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Private Sub SetDataBinding()

        GetDataSet()

        ' FlexCell.SetDataBinding → DataGridView.DataSource
        Grid1.DataSource = myDataSet.Tables("Table_Main")

    End Sub

    Private Sub GetDataSet()

        Dim conn As OleDbConnection

        Dim Qurry1 As String = "SELECT * FROM Table_Main WHERE (JOBDATE BETWEEN '" & Format(srcDtpStart.Value, "yyyy-MM-dd") &
                        "' AND '" & Format(srcDtpEnd.Value, "yyyy-MM-dd") & "')"

        Dim ConString As String = "Provider=Microsoft.jet.OLEDB.4.0; Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "\DB\DB.mdb"

        conn = New OleDbConnection
        conn.ConnectionString = ConString
        conn.Open()
        myDataSet = New DataSet
        myDataAdapter = New OleDbDataAdapter(Qurry1, conn)
        myDataAdapter.Fill(myDataSet, "Table_Main")
        conn.Close()

    End Sub

    Private Sub ConvertExcel()

        ' TODO: FlexCell.ExportToExcel → DataGridView는 내장 Excel 내보내기 없음.
        ' DataGridView 데이터 수동 CSV/Excel 내보내기 구현 필요 시 여기에 추가.
        MsgBox("Excel 내보내기 기능은 추후 구현 예정입니다.", MsgBoxStyle.Information)

    End Sub

    '******************************************************************************
    'Button
    '******************************************************************************
    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        SetDataBinding()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        ConvertExcel()
    End Sub

End Class
