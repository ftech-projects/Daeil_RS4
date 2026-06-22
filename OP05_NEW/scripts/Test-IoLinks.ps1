# OP05 I/O 링크 점검 (COM4 MultiMonitor + FBEI 192.168.250.x)
param(
    [string]$ComPort = "COM4",
    [string]$FbeiDiIp = "192.168.250.10",
    [string]$FbeiDoIp = "192.168.250.11"
)

Write-Host "=== COM $ComPort (115200) ===" -ForegroundColor Cyan
$ports = [System.IO.Ports.SerialPort]::GetPortNames()
Write-Host "Available ports: $($ports -join ', ')"
if ($ports -notcontains $ComPort) {
    Write-Host "WARN: $ComPort not in system list" -ForegroundColor Yellow
}

try {
    $sp = New-Object System.IO.Ports.SerialPort $ComPort, 115200, 'None', 8, 'One'
    $sp.NewLine = "`n"
    $sp.ReadTimeout = 3000
    $sp.Open()
    $sp.DiscardInBuffer()
    $deadline = (Get-Date).AddSeconds(5)
    $gotFrame = $false
    while ((Get-Date) -lt $deadline) {
        try {
            $line = $sp.ReadLine().Trim()
            if ($line -match '^S.+E$' -and $line.Length -ge 34) {
                Write-Host "OK frame: $line" -ForegroundColor Green
                $gotFrame = $true
                break
            }
            if ($line) { Write-Host "RX: $line" }
        } catch [System.TimeoutException] { }
    }
    if (-not $gotFrame) { Write-Host "FAIL: no S...E frame in 5s" -ForegroundColor Red }
    $sp.Close()
} catch {
    Write-Host "COM FAIL: $_" -ForegroundColor Red
}

Write-Host "`n=== FBEI LAN ping ===" -ForegroundColor Cyan
foreach ($ip in @($FbeiDiIp, $FbeiDoIp)) {
    $p = ping -n 2 $ip
    if ($LASTEXITCODE -eq 0) { Write-Host "OK ping $ip" -ForegroundColor Green }
    else { Write-Host "FAIL ping $ip (다른 서브넷이면 PC NIC 192.168.250.x 필요)" -ForegroundColor Yellow }
}
