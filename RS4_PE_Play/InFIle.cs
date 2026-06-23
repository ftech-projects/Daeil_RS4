using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class IniFile
{
    private readonly string _filePath;
    // 생성자
    public IniFile(string filePath)
    {
        _filePath = System.IO.Path.IsPathRooted(filePath)
            ? filePath
            : System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
    }
    // 설정값 읽기
    public string ReadValue(string section, string key)
    {
        string value = "";
        try
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("INI 파일이 존재하지 않습니다.");
                return value;
            }

            string[] lines = File.ReadAllLines(_filePath);
            bool inSection = false;

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                // 섹션 찾기
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    inSection = trimmedLine.Trim('[', ']') == section;
                }
                else if (inSection && trimmedLine.Contains("="))
                {
                    string[] parts = trimmedLine.Split(new[] { '=' }, 2);
                    if (parts[0].Trim() == key)
                    {
                        value = parts[1].Trim();
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("INI 읽기 오류: " + ex.Message);
        }

        return value;
    }
    // 설정값 저장
    public void WriteValue(string section, string key, string value)
    {
        try
        {
            List<string> lines = File.Exists(_filePath)
                ? File.ReadAllLines(_filePath).ToList()
                : new List<string>();

            List<string> newLines = new List<string>();
            bool inSection = false;
            bool sectionExists = false;
            bool keyWritten = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i].Trim();

                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    if (inSection && !keyWritten)
                    {
                        newLines.Add($"{key}={value}");
                        keyWritten = true;
                    }

                    string currentSection = line.Trim('[', ']');
                    inSection = currentSection.Equals(section, StringComparison.OrdinalIgnoreCase);
                    sectionExists |= inSection;

                    newLines.Add(lines[i]);
                    continue;
                }

                if (inSection && line.Contains("="))
                {
                    string[] parts = line.Split(new[] { '=' }, 2);
                    if (parts[0].Trim() == key)
                    {
                        newLines.Add($"{key}={value}");
                        keyWritten = true;
                        continue;
                    }
                }

                newLines.Add(lines[i]);
            }

            if (!sectionExists)
            {
                newLines.Add($"[{section}]");
            }

            if (!keyWritten)
            {
                newLines.Add($"{key}={value}");
            }

            File.WriteAllLines(_filePath, newLines);
        }
        catch (Exception ex)
        {
            Console.WriteLine("INI 쓰기 오류: " + ex.Message);
        }
    }
}
