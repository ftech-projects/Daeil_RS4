
Imports System.IO
Imports System.Reflection

Module DBOperation

    Public MdbConnect As ADODB.Connection
    Public SqlConnect As ADODB.Connection
  Public LastMdbError As String = ""

    Public Function MdbFilePath() As String
        Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB", "DB.mdb")
    End Function

    ''' <summary>기존 DB에 Laser 컬럼이 없으면 추가 (Table_SerialPort)</summary>
    Public Sub EnsureSerialPortLaserColumn()
        If Not ConnectionOpenMDB() Then Exit Sub
        Try
            Dim probe As New ADODB.Recordset
            probe.Open("SELECT Laser FROM Table_SerialPort WHERE 1=0", MdbConnect)
            probe.Close()
        Catch
            Try
                MdbConnect.Execute("ALTER TABLE Table_SerialPort ADD COLUMN Laser TEXT(50)", , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
                MdbConnect.Execute("UPDATE Table_SerialPort SET Laser='COM3' WHERE Laser IS NULL OR Laser=''", , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
            Catch ex As Exception
                LastMdbError = "Table_SerialPort.Laser 추가 실패: " & ex.Message
            End Try
        End Try
        ConnectionCloseMDB()
    End Sub

    ''' <summary>기존 DB에 Io 컬럼이 없으면 추가 (ESP32 MultiMonitor COM)</summary>
    Public Sub EnsureSerialPortIoColumn()
        If Not ConnectionOpenMDB() Then Exit Sub
        Try
            Dim probe As New ADODB.Recordset
            probe.Open("SELECT Io FROM Table_SerialPort WHERE 1=0", MdbConnect)
            probe.Close()
        Catch
            Try
                MdbConnect.Execute("ALTER TABLE Table_SerialPort ADD COLUMN Io TEXT(50)", , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
                MdbConnect.Execute("UPDATE Table_SerialPort SET Io='COM4' WHERE Io IS NULL OR Io=''", , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
                MdbConnect.Execute("UPDATE Table_SerialPort SET [Tool]='Disabled' WHERE [Tool]='COM4'", , ADODB.ExecuteOptionEnum.adExecuteNoRecords)
            Catch ex As Exception
                LastMdbError = "Table_SerialPort.Io 추가 실패: " & ex.Message
            End Try
        End Try
        ConnectionCloseMDB()
    End Sub

    ''' <summary>Table_SerialPort에 기본 1행이 없으면 INSERT</summary>
    Public Function EnsureSerialPortTableRow() As Boolean
        LastMdbError = ""
        EnsureSerialPortLaserColumn()
        EnsureSerialPortIoColumn()
        If Not ConnectionOpenMDB() Then Return False
        Try
            Dim countRs As New ADODB.Recordset
            countRs.Open("SELECT COUNT(*) AS C FROM Table_SerialPort", MdbConnect)
            Dim rowCount As Long = CLng(countRs.Fields("C").Value)
            countRs.Close()
            If rowCount = 0 Then
                MdbConnect.Execute(
                    "INSERT INTO Table_SerialPort (Scanner, Printer, [Tool], Laser, Io) VALUES ('COM3','Disabled','Disabled','COM5','COM4')",
                    ,
                    ADODB.ExecuteOptionEnum.adExecuteNoRecords)
            End If
            ConnectionCloseMDB()
            Return True
        Catch ex As Exception
            LastMdbError = "Table_SerialPort 준비 실패: " & ex.Message
            ConnectionCloseMDB()
            Return False
        End Try
    End Function

    ''' <summary>Table_Barcode에 기본 1행이 없으면 INSERT</summary>
    Public Function EnsureBarcodeTableRow() As Boolean
        LastMdbError = ""
        If Not ConnectionOpenMDB() Then Return False
        Try
            Dim countRs As New ADODB.Recordset
            countRs.Open("SELECT COUNT(*) AS C FROM Table_Barcode", MdbConnect)
            Dim rowCount As Long = CLng(countRs.Fields("C").Value)
            countRs.Close()
            If rowCount = 0 Then
                MdbConnect.Execute(
                    "INSERT INTO Table_Barcode (" &
                    "S1X,S1Y,S1W,S1H,S2X,S2Y,S2W,S2H,S3X,S3Y,S3W,S3H,S4X,S4Y,S4W,S4H,S5X,S5Y,S5W,S5H,BX,[BY],BH,BL,BS) VALUES (" &
                    "'100','80','300','40','100','130','300','40','100','180','300','40','100','230','300','40','100','280','300','40'," &
                    "'50','400','30','200','12')",
                    ,
                    ADODB.ExecuteOptionEnum.adExecuteNoRecords)
            End If
            ConnectionCloseMDB()
            Return True
        Catch ex As Exception
            LastMdbError = "Table_Barcode 준비 실패: " & ex.Message
            ConnectionCloseMDB()
            Return False
        End Try
    End Function

    ''' <summary>Table_BASIC에 기본 1행이 없으면 INSERT (저장/불러오기 무음 실패 방지)</summary>
    Public Function EnsureBasicTableRow() As Boolean
        LastMdbError = ""
        If Not ConnectionOpenMDB() Then Return False
        Try
            Dim countRs As New ADODB.Recordset
            countRs.Open("SELECT COUNT(*) AS C FROM Table_BASIC", MdbConnect)
            Dim rowCount As Long = CLng(countRs.Fields("C").Value)
            countRs.Close()
            If rowCount = 0 Then
                MdbConnect.Execute(
                    "INSERT INTO Table_BASIC (" &
                    "FrtMin_STDLH,FrtMax_STDLH,RearMin_STDLH,RearMax_STDLH," &
                    "FrtMin_VIPRH,FrtMax_VIPRH,RearMin_VIPRH,RearMax_VIPRH," &
                    "FrtMin_FOLDRH,FrtMax_FOLDRH,RearMin_FOLDRH,RearMax_FOLDRH," &
                    "RearTolVIP,FrtTolVIP,RearTolSTD,FrtTolSTD,RearTolFOLD,FrtTolFOLD," &
                    "FlagDuplicate,FlagBeforeCheck) VALUES (" &
                    "0,9999,0,9999,0,9999,0,9999,0,9999,0,9999," &
                    "5,5,5,5,5,5,0,0)",
                    ,
                    ADODB.ExecuteOptionEnum.adExecuteNoRecords)
            End If
            ConnectionCloseMDB()
            Return True
        Catch ex As Exception
            LastMdbError = "Table_BASIC 준비 실패: " & ex.Message
            ConnectionCloseMDB()
            Return False
        End Try
    End Function

    ''' <summary>SQL 미연결 시 Part 로컬 저장용 Table_Part_Local 보장 (서버와 동기화 없음)</summary>
    Public Function EnsurePartLocalTable() As Boolean
        LastMdbError = ""
        If Not ConnectionOpenMDB() Then Return False
        Try
            Dim probe As New ADODB.Recordset
            probe.Open("SELECT PartNo FROM Table_Part_Local WHERE 1=0", MdbConnect)
            probe.Close()
            ConnectionCloseMDB()
            Return True
        Catch
            Try
                MdbConnect.Execute(
                    "CREATE TABLE Table_Part_Local (" &
                    "ID COUNTER PRIMARY KEY, " &
                    "PartNo TEXT(50), " &
                    "PartName TEXT(255), " &
                    "OptionLHRH TEXT(10), " &
                    "OptionType TEXT(20), " &
                    "OptionBack TEXT(50), " &
                    "OptionFootRest YESNO, " &
                    "OptionMon YESNO, " &
                    "Target_Op04_ToolNum LONG, " &
                    "Target_Op04_RivetNum LONG, " &
                    "Target_Op03_InsideCoverL TEXT(50), " &
                    "Target_Op03_InsideCoverR TEXT(50)" &
                    ")",
                    ,
                    ADODB.ExecuteOptionEnum.adExecuteNoRecords)
                ConnectionCloseMDB()
                Return True
            Catch ex As Exception
                LastMdbError = "Table_Part_Local 생성 실패: " & ex.Message
                ConnectionCloseMDB()
                Return False
            End Try
        End Try
    End Function

    ''' <summary>Access DB 연결. 성공 시 True. 실패 시 LastMdbError 설정.</summary>
    Public Function ConnectionOpenMDB() As Boolean
        LastMdbError = ""
        Dim dbPath As String = MdbFilePath()

        If Not File.Exists(dbPath) Then
            LastMdbError = "DB 파일 없음: " & dbPath
            Return False
        End If

        Try
            If MdbConnect IsNot Nothing Then
                If MdbConnect.State = ADODB.ObjectStateEnum.adStateOpen Then
                    Return True
                End If
            End If
        Catch
        End Try

        Dim providers() As String = {
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}",
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}"
        }

        For Each provTemplate As String In providers
            Try
                MdbConnect = New ADODB.Connection
                MdbConnect.ConnectionString = String.Format(provTemplate, dbPath)
                MdbConnect.Open()
                Return True
            Catch ex As Exception
                LastMdbError = ex.Message
                Try
                    If MdbConnect IsNot Nothing Then MdbConnect = Nothing
                Catch
                End Try
            End Try
        Next

        If String.IsNullOrEmpty(LastMdbError) Then
            LastMdbError = "MDB 연결 실패"
        End If
        Return False
    End Function

    Public Sub ConnectionCloseMDB()
        Try
            If MdbConnect IsNot Nothing AndAlso MdbConnect.State = ADODB.ObjectStateEnum.adStateOpen Then
                MdbConnect.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub ConnectionOpenSQL()

        Try

            Dim connection_string As String = ""
            SqlConnect = New ADODB.Connection
            connection_string = "Provider=SQLOLEDB;Data Source=192.168.0.222\Ftech_Svr;Initial Catalog=FTECH_SVR;User ID=sa;Password=sns123.,;Connect Timeout=2"
            SqlConnect.ConnectionString = connection_string
            SqlConnect.Open()

        Catch ex As Exception

        End Try

    End Sub

    Sub ConnectionCloseSQL()

        Try
            If SqlConnect IsNot Nothing AndAlso SqlConnect.State = ADODB.ObjectStateEnum.adStateOpen Then
                SqlConnect.Close()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Function Dec2Hex(ByVal DecNum As Long) As String
        Dim strReturn As String = ""
        Try
            Dim hexv As String, na As Long

            hexv = ""
            Do While DecNum > 0
                na = DecNum Mod 16
                Select Case na
                    Case 10
                        hexv = "A" + Trim(hexv)
                    Case 11
                        hexv = "B" + Trim(hexv)
                    Case 12
                        hexv = "C" + Trim(hexv)
                    Case 13
                        hexv = "D" + Trim(hexv)
                    Case 14
                        hexv = "E" + Trim(hexv)
                    Case 15
                        hexv = "F" + Trim(hexv)
                    Case Else
                        hexv = Str(na) + Trim(hexv)
                End Select
                If DecNum >= 16 Then
                    DecNum = Int(DecNum / 16)
                Else
                    hexv = "0" + Trim(hexv)
                    Exit Do
                End If
            Loop

            If Len(hexv) > 1 And (Len(hexv) Mod 2 = 1) Then
                strReturn = Mid(hexv, 2)
            Else
                strReturn = hexv
            End If
        Catch ex As Exception
        End Try
        Dec2Hex = strReturn

    End Function

End Module
