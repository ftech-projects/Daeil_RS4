# OP05 현장 PC / 원격 점검 — ACE, DB.mdb, Scanner COM, exe
param(
    [string]$AppRoot = 'C:\Program Files\Ftech',
    [string]$RemoteHost = ''
)

$ErrorActionPreference = 'Continue'

function Test-AceOleDb([string]$mdb) {
    if (-not (Test-Path -LiteralPath $mdb)) { return 'DB 없음' }
    try {
        $c = New-Object -ComObject ADODB.Connection
        $c.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$mdb")
        $c.Close()
        return 'ACE x86 OK'
    } catch {
        return "ACE FAIL: $($_.Exception.Message)"
    }
}

function Get-SerialPortRow([string]$mdb) {
    try {
        $c = New-Object -ComObject ADODB.Connection
        $c.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$mdb")
        $rs = New-Object -ComObject ADODB.Recordset
        $rs.Open('SELECT TOP 1 Scanner, Printer, [Tool], Laser, Io FROM Table_SerialPort', $c)
        if ($rs.EOF) { $rs.Close(); $c.Close(); return $null }
        $row = [ordered]@{
            Scanner = [string]$rs.Fields('Scanner').Value
            Printer = [string]$rs.Fields('Printer').Value
            Tool    = [string]$rs.Fields('Tool').Value
            Laser   = [string]$rs.Fields('Laser').Value
            Io      = [string]$rs.Fields('Io').Value
        }
        $rs.Close(); $c.Close()
        return $row
    } catch {
        return @{ Error = $_.Exception.Message }
    }
}

function Invoke-LocalCheck([string]$root) {
    Write-Host "=== OP05 Site Check: $root ===" -ForegroundColor Cyan
    $exe = Join-Path $root 'RS4_OP05_NEW.exe'
    $mdb = Join-Path $root 'DB\DB.mdb'
    $cfg = Join-Path $root 'config.json'

    Write-Host ("EXE  : {0} ({1})" -f $exe, (Test-Path -LiteralPath $exe))
    Write-Host ("DB   : {0} ({1})" -f $mdb, (Test-Path -LiteralPath $mdb))
    Write-Host ("CFG  : {0} ({1})" -f $cfg, (Test-Path -LiteralPath $cfg))
    Write-Host ("ACE  : $(Test-AceOleDb $mdb)")

    if (Test-Path -LiteralPath $mdb) {
        $ports = Get-SerialPortRow $mdb
        if ($ports.Error) {
            Write-Host "Table_SerialPort: $($ports.Error)" -ForegroundColor Red
        } else {
            Write-Host ("PORT : Scanner={0} Laser={1} Io={2}" -f $ports.Scanner, $ports.Laser, $ports.Io)
            if ($ports.Scanner -eq $ports.Laser) {
                Write-Host "WARN : Scanner COM = Laser COM -> 스캐너 또는 레이저 한쪽 동작 불가" -ForegroundColor Yellow
            }
        }
    }

    Write-Host ""
    Write-Host "COM 장치 (장치관리자 포트와 일치 확인):" -ForegroundColor Cyan
    try {
        Get-CimInstance Win32_SerialPort | Select-Object DeviceID, Name | Format-Table -AutoSize
    } catch {
        Write-Host "  (COM 목록 조회 실패)"
    }
}

if ($RemoteHost) {
    if (-not $env:DEPLOY_PASSWORD) {
        Write-Host "원격: `$env:DEPLOY_PASSWORD 설정 후 재실행" -ForegroundColor Yellow
        exit 2
    }
    $sec = ConvertTo-SecureString $env:DEPLOY_PASSWORD -AsPlainText -Force
    $cred = New-Object pscredential('Administrator', $sec)
    $remoteRoot = "\\$RemoteHost\C$\Program Files\Ftech"
    if (-not (Test-Path -LiteralPath $remoteRoot)) {
        $remoteRoot = "\\$RemoteHost\C$\Ftech"
    }
    Write-Host "Remote root: $remoteRoot"
    if (-not (Test-Path -LiteralPath $remoteRoot)) {
        Write-Host "원격 Ftech 폴더 없음" -ForegroundColor Red
        exit 1
    }
    $local = Join-Path $remoteRoot ''
    Invoke-LocalCheck $local.TrimEnd('\')
} else {
    if (-not (Test-Path -LiteralPath $AppRoot)) {
        $AppRoot = Join-Path $PSScriptRoot '..\bin'
        $AppRoot = [IO.Path]::GetFullPath($AppRoot)
    }
    Invoke-LocalCheck $AppRoot
}

Write-Host ""
Write-Host "스캔 무응답 시: 로그에 'Serial Scanner Open Success' / 'ScanData :' 있는지 확인" -ForegroundColor Green
