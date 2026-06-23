using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

public sealed class CsvRawSaver
{
    private readonly object _sync = new object();
    private readonly List<Tuple<double, double>> _buffer;

    public CsvRawSaver(int initialCapacity)
    {
        if (initialCapacity < 0) initialCapacity = 0;
        _buffer = new List<Tuple<double, double>>(initialCapacity);
    }

    public CsvRawSaver() : this(1024) { }

    /// <summary>
    /// 측정 루프에서 호출. 메모리 버퍼에만 추가.
    /// </summary>
    public void Add(double x, double y)
    {
        lock (_sync)
        {
            _buffer.Add(new Tuple<double, double>(x, y));
        }
    }

    public void Clear()
    {
        lock (_sync)
        {
            _buffer.Clear();
        }
    }


    /// <summary>
    /// 버퍼 전체를 한 번에 CSV로 Append 저장하고, 내부 버퍼는 비움.
    /// 반환: 저장된 파일 전체 경로.
    /// </summary>
    public string Save(string fileNameWithoutPathOrExtension)
    {
        if (string.IsNullOrWhiteSpace(fileNameWithoutPathOrExtension))
            fileNameWithoutPathOrExtension = "raw";

        DateTime now = DateTime.Now;
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string dir = Path.Combine(
            baseDir,
            now.Year.ToString("D4"),
            now.Month.ToString("D2"),
            now.Day.ToString("D2"));

        Directory.CreateDirectory(dir);

        string fileName = fileNameWithoutPathOrExtension.EndsWith(".csv", StringComparison.OrdinalIgnoreCase)
            ? fileNameWithoutPathOrExtension
            : fileNameWithoutPathOrExtension + ".csv";

        string path = Path.Combine(dir, fileName);

        // 스냅샷 떠서 잠금 짧게
        List<Tuple<double, double>> snapshot;
        lock (_sync)
        {
            if (_buffer.Count == 0)
                return path; // 저장할 게 없으면 조용히 리턴

            snapshot = new List<Tuple<double, double>>(_buffer.Count);
            for (int i = 0; i < _buffer.Count; i++)
                snapshot.Add(_buffer[i]);

            _buffer.Clear();
        }

        bool writeHeader = !File.Exists(path);

        // 다른 프로세스가 읽을 수 있게 Read 공유
        using (var fs = new FileStream(
            path,
            FileMode.Append,
            FileAccess.Write,
            FileShare.Read))
        using (var sw = new StreamWriter(fs, new UTF8Encoding(false)))
        {
            if (writeHeader)
                sw.WriteLine("x,y");

            // 문화권 고정(소수점 .)
            IFormatProvider inv = CultureInfo.InvariantCulture;
            for (int i = 0; i < snapshot.Count; i++)
            {
                string sx = snapshot[i].Item1.ToString(inv);
                string sy = snapshot[i].Item2.ToString(inv);
                sw.Write(sx);
                sw.Write(',');
                sw.WriteLine(sy);
            }
            sw.Flush();
            fs.Flush(true); // 가능하면 디스크로 밀어넣기
        }

        return path;
    }

    /// <summary>
    /// 한 점 추가 후 즉시 디스크에 반영하고 싶을 때.
    /// 측정 루프가 매우 느리면 사용.
    /// </summary>
    public string SaveImmediate(double x, double y, string fileNameWithoutPathOrExtension)
    {
        Add(x, y);
        return Save(fileNameWithoutPathOrExtension);
    }
}