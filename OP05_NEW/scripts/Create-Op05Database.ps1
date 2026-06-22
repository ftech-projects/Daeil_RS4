# OP05_NEW 전용 Access DB 생성 (PopV4 Table_SET 포트값 참고)
param(
    [string]$OutPath = (Join-Path $PSScriptRoot '..\DB\DB.mdb'),
    [string]$PopV4Mdb = ''
)

$ErrorActionPreference = 'Stop'
$OutPath = [System.IO.Path]::GetFullPath($OutPath)
$outDir = Split-Path $OutPath -Parent
if (-not (Test-Path $outDir)) { New-Item -ItemType Directory -Path $outDir -Force | Out-Null }

if ([string]::IsNullOrWhiteSpace($PopV4Mdb)) {
    $found = Get-ChildItem 'C:\Program Files (x86)\business' -Filter 'DB.mdb' -Recurse -ErrorAction SilentlyContinue |
        Where-Object { $_.FullName -like '*PopV4*bin*Debug*DB*' -and $_.FullName -notlike '*Backup*' } |
        Select-Object -First 1
    if ($found) { $PopV4Mdb = $found.FullName }
}

# PopV4 Table_SET 기본값
$scanner = 'COM3'
$printer = 'Disabled'
$tool = 'Disabled'
$ioPort = 'COM4'
$laser = 'COM5'
if ($PopV4Mdb -and (Test-Path $PopV4Mdb)) {
    try {
        $pc = New-Object System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$PopV4Mdb")
        $pc.Open()
        $cmd = $pc.CreateCommand()
        $cmd.CommandText = 'SELECT ScannerPort, PrinterPort, Tool1Port, Laser1Port FROM Table_SET'
        $r = $cmd.ExecuteReader()
        if ($r.Read()) {
            if ($r['ScannerPort']) { $scanner = [string]$r['ScannerPort'] }
            if ($r['PrinterPort']) { $printer = [string]$r['PrinterPort'] }
            if ($r['Tool1Port']) { $tool = [string]$r['Tool1Port'] }
            if ($r['Laser1Port']) { $laser = [string]$r['Laser1Port'] }
        }
        $r.Close(); $pc.Close()
        Write-Host "PopV4 참고: Scanner=$scanner Printer=$printer Tool=$tool Laser=$laser"
    } catch {
        Write-Warning "PopV4 읽기 실패, 기본 COM 사용: $_"
    }
}

if (Test-Path $OutPath) { Remove-Item -LiteralPath $OutPath -Force }

$cat = New-Object -ComObject ADOX.Catalog
try {
    $cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$OutPath")
} finally {
    [void][System.Runtime.InteropServices.Marshal]::ReleaseComObject($cat)
}

function Invoke-DbSql([string]$ConnStr, [string]$Sql) {
    $c = New-Object System.Data.OleDb.OleDbConnection($ConnStr)
    $c.Open()
    try {
        $cmd = $c.CreateCommand()
        $cmd.CommandText = $Sql
        [void]$cmd.ExecuteNonQuery()
    } finally { $c.Close() }
}

$cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$OutPath"

Invoke-DbSql $cs @"
CREATE TABLE Table_SerialPort (
  ID COUNTER PRIMARY KEY,
  Scanner TEXT(50),
  Printer TEXT(50),
  [Tool] TEXT(50),
  Laser TEXT(50),
  Io TEXT(50)
);
"@

Invoke-DbSql $cs @"
CREATE TABLE Table_Barcode (
  ID COUNTER PRIMARY KEY,
  S1X TEXT(20), S1Y TEXT(20), S1W TEXT(20), S1H TEXT(20),
  S2X TEXT(20), S2Y TEXT(20), S2W TEXT(20), S2H TEXT(20),
  S3X TEXT(20), S3Y TEXT(20), S3W TEXT(20), S3H TEXT(20),
  S4X TEXT(20), S4Y TEXT(20), S4W TEXT(20), S4H TEXT(20),
  S5X TEXT(20), S5Y TEXT(20), S5W TEXT(20), S5H TEXT(20),
  BX TEXT(20), [BY] TEXT(20), BH TEXT(20), BL TEXT(20), BS TEXT(20)
);
"@

Invoke-DbSql $cs @"
CREATE TABLE Table_BASIC (
  ID COUNTER PRIMARY KEY,
  FrtMin_STDLH DOUBLE, FrtMax_STDLH DOUBLE,
  RearMin_STDLH DOUBLE, RearMax_STDLH DOUBLE,
  FrtMin_VIPRH DOUBLE, FrtMax_VIPRH DOUBLE,
  RearMin_VIPRH DOUBLE, RearMax_VIPRH DOUBLE,
  FrtMin_FOLDRH DOUBLE, FrtMax_FOLDRH DOUBLE,
  RearMin_FOLDRH DOUBLE, RearMax_FOLDRH DOUBLE,
  RearTolVIP DOUBLE, FrtTolVIP DOUBLE,
  RearTolSTD DOUBLE, FrtTolSTD DOUBLE,
  RearTolFOLD DOUBLE, FrtTolFOLD DOUBLE,
  FlagDuplicate YESNO, FlagBeforeCheck YESNO
);
"@

Invoke-DbSql $cs @"
CREATE TABLE Table_Count (
  ID COUNTER PRIMARY KEY,
  JobPartNo TEXT(50),
  JobCount TEXT(20)
);
"@

$esc = { param([string]$s) if ($null -eq $s) { "''" } else { "'" + ($s -replace "'", "''") + "'" } }

Invoke-DbSql $cs ("INSERT INTO Table_SerialPort (Scanner, Printer, [Tool], Laser, Io) VALUES ({0}, {1}, {2}, {3}, {4})" -f (&$esc $scanner), (&$esc $printer), (&$esc $tool), (&$esc $laser), (&$esc $ioPort))

Invoke-DbSql $cs @"
INSERT INTO Table_Barcode (
  S1X,S1Y,S1W,S1H,S2X,S2Y,S2W,S2H,S3X,S3Y,S3W,S3H,S4X,S4Y,S4W,S4H,S5X,S5Y,S5W,S5H,BX,[BY],BH,BL,BS
) VALUES (
  '100','80','300','40','100','130','300','40','100','180','300','40','100','230','300','40','100','280','300','40',
  '50','400','30','200','12'
);
"@

Invoke-DbSql $cs @"
INSERT INTO Table_BASIC (
  FrtMin_STDLH,FrtMax_STDLH,RearMin_STDLH,RearMax_STDLH,
  FrtMin_VIPRH,FrtMax_VIPRH,RearMin_VIPRH,RearMax_VIPRH,
  FrtMin_FOLDRH,FrtMax_FOLDRH,RearMin_FOLDRH,RearMax_FOLDRH,
  RearTolVIP,FrtTolVIP,RearTolSTD,FrtTolSTD,RearTolFOLD,FrtTolFOLD,
  FlagDuplicate,FlagBeforeCheck
) VALUES (
  0,9999,0,9999, 0,9999,0,9999, 0,9999,0,9999,
  5,5,5,5,5,5, 0,0
);
"@

Write-Host "Created: $OutPath"
