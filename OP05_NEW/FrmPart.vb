Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class FrmPart
    Inherits Form

    Private ReadOnly dgvParts As New DataGridView()
    Private ReadOnly btnSearch As New Button()
    Private ReadOnly btnAdd As New Button()
    Private ReadOnly btnDelete As New Button()
    Private ReadOnly btnSave As New Button()
    Private ReadOnly btnClose As New Button()
    Private ReadOnly cboType As New ComboBox()
    Private ReadOnly cboLhRh As New ComboBox()
    Private ReadOnly lblType As New Label()
    Private ReadOnly lblLhRh As New Label()
    Private ReadOnly deletedIds As New List(Of Integer)()
    Private currentTableName As String = "Table_Part"
    Private currentIsSql As Boolean = True

    Private Sub FrmPart_Load(sender As Object, e As EventArgs) Handles Me.Load
        EnsurePartLocalTable()
        InitializeLayout()
        InitializeGrid()
        InitializeFilters()
        LoadGrid()
    End Sub

    Private Sub InitializeLayout()
        Text = "Part 관리"
        StartPosition = FormStartPosition.CenterScreen
        Size = New Size(1700, 850)
        TopMost = True
        Font = New Font("맑은 고딕", 10.0F)

        lblType.Text = "Type"
        lblType.Location = New Point(20, 18)
        lblType.AutoSize = True

        cboType.DropDownStyle = ComboBoxStyle.DropDownList
        cboType.Location = New Point(70, 12)
        cboType.Size = New Size(130, 30)

        lblLhRh.Text = "LH/RH"
        lblLhRh.Location = New Point(220, 18)
        lblLhRh.AutoSize = True

        cboLhRh.DropDownStyle = ComboBoxStyle.DropDownList
        cboLhRh.Location = New Point(285, 12)
        cboLhRh.Size = New Size(130, 30)

        btnSearch.Text = "조회"
        btnSearch.Location = New Point(440, 10)
        btnSearch.Size = New Size(90, 34)

        btnAdd.Text = "ADD"
        btnAdd.Location = New Point(900, 10)
        btnAdd.Size = New Size(100, 34)

        btnDelete.Text = "DELETE"
        btnDelete.Location = New Point(1010, 10)
        btnDelete.Size = New Size(100, 34)

        btnSave.Text = "Save"
        btnSave.Location = New Point(1120, 10)
        btnSave.Size = New Size(100, 34)

        btnClose.Text = "Close"
        btnClose.Location = New Point(1230, 10)
        btnClose.Size = New Size(90, 34)

        dgvParts.Location = New Point(20, 55)
        dgvParts.Size = New Size(1620, 730)
        dgvParts.AllowUserToAddRows = False
        dgvParts.AllowUserToDeleteRows = False
        dgvParts.MultiSelect = False
        dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvParts.RowHeadersWidth = 40
        dgvParts.RowTemplate.Height = 30
        dgvParts.DefaultCellStyle.Font = New Font("맑은 고딕", 10.0F)
        dgvParts.ColumnHeadersDefaultCellStyle.Font = New Font("맑은 고딕", 10.0F, FontStyle.Bold)

        Controls.Add(lblType)
        Controls.Add(cboType)
        Controls.Add(lblLhRh)
        Controls.Add(cboLhRh)
        Controls.Add(btnSearch)
        Controls.Add(btnAdd)
        Controls.Add(btnDelete)
        Controls.Add(btnSave)
        Controls.Add(btnClose)
        Controls.Add(dgvParts)

        AddHandler btnSearch.Click, AddressOf BtnSearch_Click
        AddHandler btnAdd.Click, AddressOf BtnAdd_Click
        AddHandler btnDelete.Click, AddressOf BtnDelete_Click
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        AddHandler btnClose.Click, AddressOf BtnClose_Click
        AddHandler dgvParts.DataError, AddressOf DgvParts_DataError
    End Sub

    Private Sub InitializeFilters()
        cboType.Items.Clear()
        cboType.Items.Add("전체")
        cboType.Items.Add("STD")
        cboType.Items.Add("FOLD")
        cboType.Items.Add("VIP")
        cboType.SelectedIndex = 0

        cboLhRh.Items.Clear()
        cboLhRh.Items.Add("전체")
        cboLhRh.Items.Add("LH")
        cboLhRh.Items.Add("RH")
        cboLhRh.SelectedIndex = 0
    End Sub

    Private Sub InitializeGrid()
        dgvParts.Columns.Clear()

        Dim colId As New DataGridViewTextBoxColumn()
        colId.Name = "ID"
        colId.HeaderText = "ID"
        colId.Visible = False
        dgvParts.Columns.Add(colId)

        dgvParts.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "PartNo", .HeaderText = "PartNo", .Width = 170})
        dgvParts.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "PartName", .HeaderText = "PartName", .Width = 360})

        Dim colLhRh As New DataGridViewComboBoxColumn()
        colLhRh.Name = "OptionLHRH"
        colLhRh.HeaderText = "LH/RH"
        colLhRh.Width = 80
        colLhRh.Items.AddRange("LH", "RH")
        dgvParts.Columns.Add(colLhRh)

        Dim colType As New DataGridViewComboBoxColumn()
        colType.Name = "OptionType"
        colType.HeaderText = "Type"
        colType.Width = 90
        colType.Items.AddRange("STD", "FOLD", "VIP")
        dgvParts.Columns.Add(colType)

        dgvParts.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "OptionBack", .HeaderText = "OptionBack", .Width = 110})

        dgvParts.Columns.Add(New DataGridViewCheckBoxColumn() With {.Name = "OptionFootRest", .HeaderText = "FootRest", .Width = 80})
        dgvParts.Columns.Add(New DataGridViewCheckBoxColumn() With {.Name = "OptionMon", .HeaderText = "Monitor", .Width = 80})

        dgvParts.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Target_Op04_ToolNum", .HeaderText = "ToolNum", .Width = 80})
        dgvParts.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Target_Op04_RivetNum", .HeaderText = "RivetNum", .Width = 80})
        dgvParts.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Target_Op03_InsideCoverL", .HeaderText = "CoverL", .Width = 120})
        dgvParts.Columns.Add(New DataGridViewTextBoxColumn() With {.Name = "Target_Op03_InsideCoverR", .HeaderText = "CoverR", .Width = 120})
    End Sub

    Private Sub LoadGrid()
        deletedIds.Clear()
        dgvParts.Rows.Clear()
        EnsurePartLocalTable()
        Dim cn As ADODB.Connection = Nothing
        Dim sourceLabel As String = ""
        If Not TryOpenPartConnection(cn, sourceLabel) Then
            MessageBox.Show("SQL/MDB 모두 연결 실패", "Part", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rs As New ADODB.Recordset
        Try
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

            Dim whereParts As New List(Of String)()
            If cboType.SelectedIndex > 0 Then
                whereParts.Add("OptionType = '" & EscapeSql(CStr(cboType.SelectedItem)) & "'")
            End If
            If cboLhRh.SelectedIndex > 0 Then
                whereParts.Add("OptionLHRH = '" & EscapeSql(CStr(cboLhRh.SelectedItem)) & "'")
            End If

            Dim sql As String = "SELECT * FROM " & currentTableName
            If whereParts.Count > 0 Then
                sql &= " WHERE " & String.Join(" AND ", whereParts)
            End If
            sql &= " ORDER BY LEN(PartNo), PartNo"

            rs.Open(sql, cn)

            If rs.RecordCount > 0 Then
                rs.MoveFirst()
                Do Until rs.EOF
                    Dim rowIndex As Integer = dgvParts.Rows.Add()
                    Dim row As DataGridViewRow = dgvParts.Rows(rowIndex)
                    row.Cells("ID").Value = SafeToString(rs, "ID")
                    row.Cells("PartNo").Value = SafeToString(rs, "PartNo")
                    row.Cells("PartName").Value = SafeToString(rs, "PartName")
                    row.Cells("OptionLHRH").Value = SafeToString(rs, "OptionLHRH")
                    row.Cells("OptionType").Value = SafeToString(rs, "OptionType")
                    row.Cells("OptionBack").Value = SafeToString(rs, "OptionBack")
                    row.Cells("OptionFootRest").Value = SafeToBool(rs, "OptionFootRest")
                    row.Cells("OptionMon").Value = SafeToBool(rs, "OptionMon")
                    row.Cells("Target_Op04_ToolNum").Value = SafeToString(rs, "Target_Op04_ToolNum")
                    row.Cells("Target_Op04_RivetNum").Value = SafeToString(rs, "Target_Op04_RivetNum")
                    row.Cells("Target_Op03_InsideCoverL").Value = SafeToString(rs, "Target_Op03_InsideCoverL")
                    row.Cells("Target_Op03_InsideCoverR").Value = SafeToString(rs, "Target_Op03_InsideCoverR")
                    rs.MoveNext()
                Loop
            End If
            Text = "Part 관리 - " & sourceLabel
        Catch ex As Exception
            MessageBox.Show("Part 조회 오류: " & ex.Message, "Part", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If rs.State = ADODB.ObjectStateEnum.adStateOpen Then rs.Close()
            Catch
            End Try
            If currentIsSql Then
                ConnectionCloseSQL()
            Else
                ConnectionCloseMDB()
            End If
        End Try
    End Sub

    Private Sub SaveGrid()
        Dim cn As ADODB.Connection = Nothing
        Dim saveLabel As String = ""
        If Not TryOpenPartConnection(cn, saveLabel) Then
            MessageBox.Show("SQL/MDB 모두 연결 실패 — 저장할 수 없습니다." & vbCrLf & LastMdbError, "Part", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim rs As New ADODB.Recordset
        Try
            For Each deletedId As Integer In deletedIds
                cn.Execute("DELETE FROM " & currentTableName & " WHERE ID = " & deletedId.ToString(), , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
            Next
            deletedIds.Clear()

            For Each row As DataGridViewRow In dgvParts.Rows
                If row.IsNewRow Then Continue For

                Dim id As String = GridValue(row, "ID")
                If id = "NEW" OrElse id = "" Then
                    rs.Open("SELECT * FROM " & currentTableName, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                    rs.AddNew()
                    FillRecordsetFromRow(rs, row)
                    rs.Update()
                    rs.Close()
                Else
                    rs.Open("SELECT * FROM " & currentTableName & " WHERE ID = " & CInt(id), cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
                    If Not rs.EOF Then
                        FillRecordsetFromRow(rs, row)
                        rs.Update()
                    Else
                        Throw New InvalidOperationException("Part ID " & id & " 행을 찾을 수 없습니다.")
                    End If
                    rs.Close()
                End If
            Next

            MessageBox.Show("저장되었습니다. (" & saveLabel & ")", "Part", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Part 저장 오류: " & ex.Message, "Part", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If rs.State = ADODB.ObjectStateEnum.adStateOpen Then rs.Close()
            Catch
            End Try
            If currentIsSql Then
                ConnectionCloseSQL()
            Else
                ConnectionCloseMDB()
            End If
        End Try

        LoadGrid()
    End Sub

    Private Sub FillRecordsetFromRow(rs As ADODB.Recordset, row As DataGridViewRow)
        rs.Fields("PartNo").Value = GridValue(row, "PartNo")
        rs.Fields("PartName").Value = GridValue(row, "PartName")
        rs.Fields("OptionLHRH").Value = GridValue(row, "OptionLHRH")
        rs.Fields("OptionType").Value = GridValue(row, "OptionType")
        rs.Fields("OptionBack").Value = GridValue(row, "OptionBack")
        rs.Fields("OptionFootRest").Value = GridBoolValue(row, "OptionFootRest")
        rs.Fields("OptionMon").Value = GridBoolValue(row, "OptionMon")
        rs.Fields("Target_Op04_ToolNum").Value = GridIntValue(row, "Target_Op04_ToolNum")
        rs.Fields("Target_Op04_RivetNum").Value = GridIntValue(row, "Target_Op04_RivetNum")
        rs.Fields("Target_Op03_InsideCoverL").Value = GridValue(row, "Target_Op03_InsideCoverL")
        rs.Fields("Target_Op03_InsideCoverR").Value = GridValue(row, "Target_Op03_InsideCoverR")
    End Sub

    ''' <summary>SQL 우선, 실패 시 MDB Table_Part_Local (동기화 없음)</summary>
    Private Function TryOpenPartConnection(ByRef cn As ADODB.Connection, ByRef sourceLabel As String) As Boolean
        ConnectionOpenSQL()
        If SqlConnect IsNot Nothing AndAlso SqlConnect.State = ADODB.ObjectStateEnum.adStateOpen Then
            cn = SqlConnect
            currentTableName = "Table_Part"
            currentIsSql = True
            sourceLabel = "SQL"
            Return True
        End If

        EnsurePartLocalTable()
        If ConnectionOpenMDB() Then
            cn = MdbConnect
            currentTableName = "Table_Part_Local"
            currentIsSql = False
            sourceLabel = "MDB(오프라인)"
            Return True
        End If

        Return False
    End Function

    Private Shared Function GridValue(row As DataGridViewRow, columnName As String) As String
        Dim v As Object = row.Cells(columnName).Value
        If v Is Nothing OrElse IsDBNull(v) Then Return ""
        Return v.ToString().Trim()
    End Function

    Private Shared Function GridBoolValue(row As DataGridViewRow, columnName As String) As Boolean
        Dim v As Object = row.Cells(columnName).Value
        If v Is Nothing OrElse IsDBNull(v) Then Return False
        Return CBool(v)
    End Function

    Private Shared Function GridIntValue(row As DataGridViewRow, columnName As String) As Integer
        Dim raw As String = GridValue(row, columnName)
        Dim value As Integer = 0
        Integer.TryParse(raw, value)
        Return value
    End Function

    Private Shared Function SafeToString(rs As ADODB.Recordset, fieldName As String) As String
        Try
            Dim v As Object = rs.Fields(fieldName).Value
            If v Is Nothing OrElse IsDBNull(v) Then Return ""
            Return v.ToString().Trim()
        Catch
            Return ""
        End Try
    End Function

    Private Shared Function SafeToBool(rs As ADODB.Recordset, fieldName As String) As Boolean
        Try
            Dim v As Object = rs.Fields(fieldName).Value
            If v Is Nothing OrElse IsDBNull(v) Then Return False
            Return CBool(v)
        Catch
            Return False
        End Try
    End Function

    Private Shared Function EscapeSql(value As String) As String
        Return value.Replace("'", "''")
    End Function

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs)
        LoadGrid()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        Dim insertIndex As Integer = dgvParts.Rows.Count
        If dgvParts.SelectedRows.Count > 0 Then
            insertIndex = dgvParts.SelectedRows(0).Index + 1
        End If

        dgvParts.Rows.Insert(insertIndex, 1)
        Dim row = dgvParts.Rows(insertIndex)
        row.Cells("ID").Value = "NEW"
        row.Cells("PartNo").Value = "88888-00000"
        row.Cells("PartName").Value = "신규 품번"
        row.Cells("OptionLHRH").Value = "LH"
        row.Cells("OptionType").Value = "STD"
        row.Cells("OptionBack").Value = "PULLMA"
        row.Cells("OptionFootRest").Value = False
        row.Cells("OptionMon").Value = False
        row.Cells("Target_Op04_ToolNum").Value = "0"
        row.Cells("Target_Op04_RivetNum").Value = "0"
        row.Cells("Target_Op03_InsideCoverL").Value = "0"
        row.Cells("Target_Op03_InsideCoverR").Value = "0"
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)
        If dgvParts.SelectedRows.Count = 0 Then
            MessageBox.Show("삭제할 행을 선택하세요.", "Part", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row As DataGridViewRow = dgvParts.SelectedRows(0)
        Dim id As String = GridValue(row, "ID")
        If id <> "" AndAlso id <> "NEW" Then
            Dim idValue As Integer
            If Integer.TryParse(id, idValue) Then
                If Not deletedIds.Contains(idValue) Then
                    deletedIds.Add(idValue)
                End If
            End If
        End If

        dgvParts.Rows.Remove(row)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        SaveGrid()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub DgvParts_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        e.ThrowException = False
    End Sub
End Class
