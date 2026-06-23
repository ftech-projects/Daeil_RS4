using System;
using System.Data;
using System.Data.OleDb;

public static class ClassDatabase
{
    // ── 품번 키로 PartNo/PartName 조회 — 미등록 시 (null, null) ────────
    public static (string PartNo, string PartName) LookupPart(string partKey)
    {
        if (string.IsNullOrWhiteSpace(partKey)) return (null, null);
        try
        {
            using (var conn = new OleDbConnection(GlobalValues.gConString_Part))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "SELECT PartNo, PartName FROM Table_Part WHERE PartNo = ?";
                cmd.Parameters.AddWithValue("?", partKey);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return (reader["PartNo"] as string, reader["PartName"] as string ?? "---");
                }
            }
        }
        catch { }
        return (null, null);
    }

    // ── 검사 결과 저장 (SerialNo 기준 UPSERT) ─────────────────────────
    public static void SaveRecord(
        string serialNo, string partNo, string partName,
        DateTime startTime, DateTime endTime,
        double fwdDisp, double bwdDisp,
        double play, double playSpec,
        bool pass, string endBarcode = "")
    {
        try
        {
            using (var conn = new OleDbConnection(GlobalValues.gConString_Record))
            {
                conn.Open();

                // SerialNo 존재 여부 확인
                var chk = conn.CreateCommand();
                chk.CommandText = "SELECT COUNT(*) FROM Table_Main WHERE SerialNo = ?";
                chk.Parameters.AddWithValue("?", serialNo ?? "");
                bool exists = (int)chk.ExecuteScalar() > 0;

                var cmd = conn.CreateCommand();
                if (exists)
                {
                    // UPDATE
                    cmd.CommandText =
                        "UPDATE Table_Main SET " +
                        "PartNo=?, PartName=?, INSPECT_DATE=?, START_TIME=?, END_TIME=?, " +
                        "FWD_DISP=?, BWD_DISP=?, PLAY=?, PLAY_SPEC=?, JUDGE=?, EndBarcode=? " +
                        "WHERE SerialNo=?";
                    cmd.Parameters.AddWithValue("?", partNo     ?? "");
                    cmd.Parameters.AddWithValue("?", partName   ?? "");
                    cmd.Parameters.AddWithValue("?", startTime.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("?", startTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("?", endTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("?", fwdDisp);
                    cmd.Parameters.AddWithValue("?", bwdDisp);
                    cmd.Parameters.AddWithValue("?", play);
                    cmd.Parameters.AddWithValue("?", playSpec);
                    cmd.Parameters.AddWithValue("?", pass ? "OK" : "NG");
                    cmd.Parameters.AddWithValue("?", endBarcode ?? "");
                    cmd.Parameters.AddWithValue("?", serialNo   ?? "");
                    ResisterTest.Managers.Logger.Log($"[DB] 업데이트: SerialNo={serialNo}");
                }
                else
                {
                    // INSERT
                    cmd.CommandText =
                        "INSERT INTO Table_Main " +
                        "(SerialNo, PartNo, PartName, INSPECT_DATE, START_TIME, END_TIME, " +
                        " FWD_DISP, BWD_DISP, PLAY, PLAY_SPEC, JUDGE, EndBarcode) " +
                        "VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";
                    cmd.Parameters.AddWithValue("?", serialNo   ?? "");
                    cmd.Parameters.AddWithValue("?", partNo     ?? "");
                    cmd.Parameters.AddWithValue("?", partName   ?? "");
                    cmd.Parameters.AddWithValue("?", startTime.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("?", startTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("?", endTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("?", fwdDisp);
                    cmd.Parameters.AddWithValue("?", bwdDisp);
                    cmd.Parameters.AddWithValue("?", play);
                    cmd.Parameters.AddWithValue("?", playSpec);
                    cmd.Parameters.AddWithValue("?", pass ? "OK" : "NG");
                    cmd.Parameters.AddWithValue("?", endBarcode ?? "");
                }
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            ResisterTest.Managers.Logger.Log($"[DB] 저장 실패: {ex.Message}");
        }
    }

    // ── 날짜 범위 조회 ──────────────────────────────────────────────────
    public static DataTable QueryRecords(DateTime from, DateTime to)
    {
        var dt = new DataTable();
        try
        {
            using (var conn = new OleDbConnection(GlobalValues.gConString_Record))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "SELECT ID, SerialNo, PartNo, PartName, " +
                    "INSPECT_DATE, START_TIME, END_TIME, " +
                    "FWD_DISP, BWD_DISP, PLAY, PLAY_SPEC, JUDGE, EndBarcode " +
                    "FROM Table_Main " +
                    "WHERE INSPECT_DATE BETWEEN ? AND ? " +
                    "ORDER BY START_TIME DESC";
                cmd.Parameters.AddWithValue("?", from.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("?", to.ToString("yyyy-MM-dd"));
                new OleDbDataAdapter(cmd).Fill(dt);
            }
        }
        catch (Exception ex)
        {
            ResisterTest.Managers.Logger.Log($"[DB] 조회 실패: {ex.Message}");
        }
        return dt;
    }
}
