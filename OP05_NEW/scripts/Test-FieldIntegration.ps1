# OP05 현장/개발 PC 통합 점검 + wStep 시나리오 시뮬레이션
# 사용: powershell -ExecutionPolicy Bypass -File scripts\Test-FieldIntegration.ps1
# 현장 PC(192.168.0.10)에서 실행하면 해당 PC 기준으로 SQL/MDB/네트워크를 검증합니다.

param(
    [string]$SqlServer = '192.168.0.222\Ftech_Svr',
    [string]$SqlCatalog = 'FTECH_SVR',
    [string]$ExePath = ''
)

$ErrorActionPreference = 'Continue'
$pass = $true

function Write-Result($name, $ok, $detail) {
    $mark = if ($ok) { 'OK' } else { 'FAIL' }
    Write-Host "[$mark] $name" -ForegroundColor $(if ($ok) { 'Green' } else { 'Red' })
    if ($detail) { Write-Host "      $detail" }
    if (-not $ok) { $script:pass = $false }
}

Write-Host '=== OP05 Field Integration Test ===' -ForegroundColor Cyan
Write-Host "Host: $env:COMPUTERNAME | $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')"

# 1) Network
foreach ($ip in @('192.168.0.222', '192.168.0.10')) {
    $ping = Test-Connection -ComputerName $ip -Count 1 -Quiet -ErrorAction SilentlyContinue
    Write-Result "Ping $ip" $ping
}

# 2) SQL
try {
    $connStr = "Provider=SQLOLEDB;Data Source=$SqlServer;Initial Catalog=$SqlCatalog;User ID=sa;Password=sns123.,;Connect Timeout=3"
    $conn = New-Object -ComObject ADODB.Connection
    $conn.Open($connStr)
    $rs = New-Object -ComObject ADODB.Recordset
    $rs.Open('SELECT TOP 1 PartNo FROM Table_Part', $conn)
    $sample = if (-not $rs.EOF) { $rs.Fields('PartNo').Value } else { '(empty)' }
    $rs.Close(); $conn.Close()
    Write-Result 'SQL Table_Part' $true "sample=$sample"
} catch {
    Write-Result 'SQL Table_Part' $false $_.Exception.Message
}

# 3) Local MDB (exe 옆 DB)
if (-not $ExePath) {
    $candidates = @(
        'C:\Ftech\RS4_OP05_NEW.exe',
        'C:\Program Files\Ftech\RS4_OP05_NEW.exe',
        (Join-Path $PSScriptRoot '..\bin\RS4_OP05_NEW.exe')
    )
    foreach ($c in $candidates) {
        if (Test-Path -LiteralPath $c) { $ExePath = $c; break }
    }
}

if ($ExePath -and (Test-Path -LiteralPath $ExePath)) {
    $mdb = Join-Path (Split-Path -Parent $ExePath) 'DB\DB.mdb'
    Write-Result 'EXE found' $true $ExePath
    if (Test-Path -LiteralPath $mdb) {
        try {
            $cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$mdb"
            $conn = New-Object -ComObject ADODB.Connection
            $conn.Open($cs)
            $rs = New-Object -ComObject ADODB.Recordset
            $rs.Open('SELECT Scanner, Laser, Io FROM Table_SerialPort', $conn)
            $ports = if (-not $rs.EOF) {
                "Scanner=$($rs.Fields('Scanner').Value), Laser=$($rs.Fields('Laser').Value), Io=$($rs.Fields('Io').Value)"
            } else { 'no row' }
            $rs.Close(); $conn.Close()
            Write-Result 'MDB Table_SerialPort' $true $ports
        } catch {
            Write-Result 'MDB Table_SerialPort' $false $_.Exception.Message
        }
    } else {
        Write-Result 'MDB file' $false $mdb
    }
} else {
    Write-Result 'EXE found' $false 'RS4_OP05_NEW.exe not found'
}

# 4) wStep 시나리오 시뮬레이션 (FrmMain Tmr_Work 핵심 분기)
function Step-Transition([double]$w, $i) {
    if ($i.plc4000 -eq 0 -and $w -ne 0) { return 0, 'reset by PLC stop' }
    if ($w -eq 0) { if ($i.plc4000 -eq 1) { return 1, 'start -> scan wait' } }
    elseif ($w -eq 1) {
        if ($i.scan_valid) {
            if ($i.before_ok) { return 2, 'scan accepted' } else { return 1.1, 'before-check NG' }
        }
    }
    elseif ($w -eq 1.1) { return 1, 'alarm shown, back to scan wait' }
    elseif ($w -eq 2) { return 2.1, 'load options' }
    elseif ($w -eq 2.1) { return 3, 'send PLC options' }
    elseif ($w -eq 3) {
        if ($i.plc4004 -eq 1) {
            if ($i.length_ok) { return 4, 'length OK' } else { return 3.1, 'length NG' }
        }
    }
    elseif ($w -eq 3.1) { if ($i.plc4004 -eq 0) { return 3, 'retry gate' } }
    elseif ($w -eq 4) {
        if ($i.tool_ok -and $i.rivet_ok -and $i.coverL_ok -and $i.coverR_ok) { return 5, 'assembly OK' }
    }
    elseif ($w -eq 5) { return 6, 'complete wait' }
    elseif ($w -eq 6) { if ($i.plc4001 -eq 1) { return 0, 'print/save done' } }
    return $w, 'hold'
}

function Run-Scenario($name, $seq) {
    $w = 0
    Write-Host "`n--- $name ---" -ForegroundColor Yellow
    $idx = 0
    foreach ($inp in $seq) {
        $idx++
        $nw, $msg = Step-Transition $w $inp
        Write-Host ("t{0}: wStep {1} -> {2} | {3}" -f $idx, $w, $nw, $msg)
        $w = $nw
    }
    $ok = ($name -like '*BeforeNG*' -and $w -eq 1) -or ($name -notlike '*BeforeNG*' -and $w -eq 0)
    Write-Result "Scenario $name" $ok "final wStep=$w"
}

Run-Scenario 'A-NormalComplete' @(
    @{ plc4000=1 }, @{ plc4000=1; scan_valid=$true; before_ok=$true },
    @{ plc4000=1 }, @{ plc4000=1 },
    @{ plc4000=1; plc4004=1; length_ok=$true },
    @{ plc4000=1; tool_ok=$true; rivet_ok=$true; coverL_ok=$true; coverR_ok=$true },
    @{ plc4000=1 }, @{ plc4000=1; plc4001=1 }
)
Run-Scenario 'B-LengthNgRetry' @(
    @{ plc4000=1 }, @{ plc4000=1; scan_valid=$true; before_ok=$true },
    @{ plc4000=1 }, @{ plc4000=1 },
    @{ plc4000=1; plc4004=1; length_ok=$false },
    @{ plc4000=1; plc4004=0 },
    @{ plc4000=1; plc4004=1; length_ok=$true },
    @{ plc4000=1; tool_ok=$true; rivet_ok=$true; coverL_ok=$true; coverR_ok=$true },
    @{ plc4000=1 }, @{ plc4000=1; plc4001=1 }
)
Run-Scenario 'C-BeforeNG' @(
    @{ plc4000=1 }, @{ plc4000=1; scan_valid=$true; before_ok=$false },
    @{ plc4000=1 }
)

Write-Host ''
if ($pass) {
    Write-Host '=== ALL CHECKS PASSED ===' -ForegroundColor Green
    exit 0
} else {
    Write-Host '=== SOME CHECKS FAILED ===' -ForegroundColor Red
    exit 1
}
