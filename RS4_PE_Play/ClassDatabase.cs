using System;
using System.Data;
using System.Data.OleDb;

public static class ClassDatabase
{
    // ── 검사 결과 저장 (바코드 있으면 UPDATE, 없으면 INSERT) ──────────
    public static void SaveRecord(
        DateTime startTime, DateTime endTime,
        double play, bool pass, string barcode = "")
    {
        try
        {
            using (var conn = new OleDbConnection(GlobalValues.gConString_Record))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                bool hasBarcode = !string.IsNullOrWhiteSpace(barcode);
                bool exists = false;

                if (hasBarcode)
                {
                    var chk = conn.CreateCommand();
                    chk.CommandText = "SELECT COUNT(*) FROM Table_Fram_Inspection WHERE Frame_Barcode = ?";
                    chk.Parameters.AddWithValue("?", barcode);
                    exists = (int)chk.ExecuteScalar() > 0;
                }

                if (exists)
                {
                    cmd.CommandText =
                        "UPDATE Table_Fram_Inspection SET " +
                        "JobDate=?, JobStartTime=?, JobEndTime=?, Inspection_Value=?, Decision=? " +
                        "WHERE Frame_Barcode=?";
                    cmd.Parameters.AddWithValue("?", startTime.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("?", startTime.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("?", endTime.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("?", play.ToString("F3"));
                    cmd.Parameters.AddWithValue("?", pass ? "OK" : "NG");
                    cmd.Parameters.AddWithValue("?", barcode);
                }
                else
                {
                    cmd.CommandText =
                        "INSERT INTO Table_Fram_Inspection " +
                        "(Frame_Barcode, JobDate, JobStartTime, JobEndTime, Inspection_Value, Decision) " +
                        "VALUES (?,?,?,?,?,?)";
                    cmd.Parameters.AddWithValue("?", barcode);
                    cmd.Parameters.AddWithValue("?", startTime.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("?", startTime.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("?", endTime.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("?", play.ToString("F3"));
                    cmd.Parameters.AddWithValue("?", pass ? "OK" : "NG");
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
                    "SELECT Frame_Barcode, JobDate, JobStartTime, JobEndTime, " +
                    "Inspection_Value, Decision " +
                    "FROM Table_Fram_Inspection " +
                    "WHERE JobDate BETWEEN ? AND ? " +
                    "ORDER BY JobStartTime DESC";
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
