' RS4_PE_Play 유격 검사 실적 — FTECH_SVR Table_Fram_Inspection 전체 조회 (Op01_v2 전용)

Imports System.Collections.Generic

Module FrameInspectionDb

    Public Structure FrameInspectionRow
        Public Found As Boolean
        Public FrameBarcode As String
        Public Decision As String
        Public IsLatest As Boolean
        Public QueryError As String
    End Structure

    Private Class FrameInspectionEntry
        Public FrameBarcode As String
        Public Decision As String
        Public JobDate As String
        Public JobEndTime As String
    End Class

    Private Function BarcodeMatchesScan(ByVal scan As String, ByVal dbBarcode As String) As Boolean
        Dim s As String = Trim(If(scan, ""))
        Dim d As String = Trim(If(dbBarcode, ""))
        If d = "" OrElse s = "" Then Return False
        If String.Compare(d, s, StringComparison.Ordinal) = 0 Then Return True
        If InStr(1, s, d, CompareMethod.Binary) > 0 Then Return True
        Return False
    End Function

    Private Function LoadAllFrameInspectionRows(ByRef queryError As String) As List(Of FrameInspectionEntry)
        Dim rows As New List(Of FrameInspectionEntry)
        queryError = ""

        Try
            ConnectionOpenSQL()
            If SqlConnect Is Nothing Then
                queryError = "SQL 연결 객체 없음"
                Return rows
            End If

            Dim Rs As New ADODB.Recordset
            Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            Rs.LockType = ADODB.LockTypeEnum.adLockReadOnly

            Rs.Open(
                "SELECT Frame_Barcode, Decision, JobDate, JobEndTime " &
                "FROM Table_Fram_Inspection " &
                "ORDER BY JobDate DESC, JobEndTime DESC",
                SqlConnect)

            If Rs.RecordCount >= 1 AndAlso Not Rs.EOF Then
                Rs.MoveFirst()
                Do Until Rs.EOF
                    rows.Add(New FrameInspectionEntry With {
                        .FrameBarcode = Trim(CStr(Rs.Fields("Frame_Barcode").Value)),
                        .Decision = Trim(CStr(Rs.Fields("Decision").Value)),
                        .JobDate = Trim(CStr(Rs.Fields("JobDate").Value)),
                        .JobEndTime = Trim(CStr(Rs.Fields("JobEndTime").Value))
                    })
                    Rs.MoveNext()
                Loop
            End If

            Rs.ActiveConnection = Nothing
            Rs.Close()
        Catch ex As Exception
            queryError = ex.Message
        Finally
            ConnectionCloseSQL()
        End Try

        Return rows
    End Function

    Private Function FindLatestForBarcode(ByVal allRows As List(Of FrameInspectionEntry), ByVal frameBarcode As String) As FrameInspectionEntry
        Dim key As String = Trim(If(frameBarcode, ""))
        For Each row As FrameInspectionEntry In allRows
            If String.Compare(Trim(row.FrameBarcode), key, StringComparison.Ordinal) = 0 Then
                Return row
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' 전체 실적 조회 후 스캔과 일치하는 항목 탐색.
    ''' 동일 Frame_Barcode의 최신 행을 기준으로 IsLatest 판별(스캔=최신 DB 바코드 여부).
    ''' </summary>
    Public Function QueryFrameInspection(ByVal scanBarcode As String) As FrameInspectionRow
        Dim result As New FrameInspectionRow With {
            .Found = False,
            .FrameBarcode = "",
            .Decision = "",
            .IsLatest = False,
            .QueryError = ""
        }

        Dim trimmedScan As String = Trim(If(scanBarcode, ""))
        If trimmedScan = "" Then
            result.QueryError = "바코드 빈값"
            Return result
        End If

        Dim loadError As String = ""
        Dim allRows As List(Of FrameInspectionEntry) = LoadAllFrameInspectionRows(loadError)
        If loadError <> "" Then
            result.QueryError = loadError
            Return result
        End If

        If allRows.Count = 0 Then
            Return result
        End If

        Dim matchedRow As FrameInspectionEntry = Nothing
        For Each row As FrameInspectionEntry In allRows
            If BarcodeMatchesScan(trimmedScan, row.FrameBarcode) Then
                matchedRow = row
                Exit For
            End If
        Next

        If matchedRow Is Nothing Then
            Return result
        End If

        Dim latestRow As FrameInspectionEntry = FindLatestForBarcode(allRows, matchedRow.FrameBarcode)
        If latestRow Is Nothing Then
            latestRow = matchedRow
        End If

        result.Found = True
        result.FrameBarcode = latestRow.FrameBarcode
        result.Decision = latestRow.Decision
        result.IsLatest = (String.Compare(trimmedScan, latestRow.FrameBarcode, StringComparison.Ordinal) = 0)

        Return result
    End Function

End Module
