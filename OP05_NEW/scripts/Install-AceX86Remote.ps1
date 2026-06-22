# 현장 PC(기본 192.168.0.10)에 Access Database Engine 2016 x86 설치
# RS4_OP05_NEW.exe(x86)가 DB.mdb를 열려면 필수
#
# 사용:
#   $env:DEPLOY_PASSWORD='현장 Administrator 암호'
#   .\Install-AceX86Remote.ps1
#
# Office 64비트와 충돌 시 /passive 로 재시도 (스크립트 내 자동)

param(
    [string]$RemoteHost = '192.168.0.10',
    [string]$UserName = 'Administrator',
    [SecureString]$Password,
    [switch]$LocalOnly
)

$ErrorActionPreference = 'Stop'

$installerDir = Join-Path $PSScriptRoot 'redist'
$installerPath = Join-Path $installerDir 'accessdatabaseengine.exe'
$installerUrl = 'https://download.microsoft.com/download/3/5/C/35C84C36-661A-44E6-9324-8786B8DBE231/accessdatabaseengine.exe'

function Ensure-Installer {
    if (-not (Test-Path -LiteralPath $installerPath)) {
        Write-Host "다운로드: $installerUrl"
        New-Item -ItemType Directory -Force -Path $installerDir | Out-Null
        Invoke-WebRequest -Uri $installerUrl -OutFile $installerPath -UseBasicParsing
    }
    if (-not (Test-Path -LiteralPath $installerPath)) {
        throw "설치 파일 없음: $installerPath"
    }
    Write-Host "설치 파일: $installerPath ($((Get-Item $installerPath).Length) bytes)"
}

function Test-AceX86OleDb {
    param([string]$ProbeMdb)
    if (-not (Test-Path -LiteralPath $ProbeMdb)) { return $false }
    try {
        $conn = New-Object -ComObject ADODB.Connection
        $conn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$ProbeMdb")
        $conn.Close()
        return $true
    } catch {
        return $false
    }
}

function Install-AceX86 {
    param(
        [string]$ExePath,
        [string[]]$ExtraArgs = @('/quiet', '/norestart')
    )
    $argLine = ($ExtraArgs -join ' ')
    Write-Host "실행: `"$ExePath`" $argLine"
    $p = Start-Process -FilePath $ExePath -ArgumentList $ExtraArgs -Wait -PassThru -NoNewWindow
    return $p.ExitCode
}

function Invoke-RemoteAceInstall {
    param(
        [string]$HostName,
        [pscredential]$Credential,
        [string]$LocalInstaller
    )

    $remoteTemp = "\\$HostName\C$\Windows\Temp\accessdatabaseengine_x86.exe"
    Write-Host "복사 -> $remoteTemp"
    Copy-Item -LiteralPath $LocalInstaller -Destination $remoteTemp -Force

    $remoteExe = 'C:\Windows\Temp\accessdatabaseengine_x86.exe'
    $scriptBlock = {
        param($Exe)
        $codes = @()
        foreach ($args in @(
            @('/quiet', '/norestart'),
            @('/passive', '/norestart')
        )) {
            $argLine = ($args -join ' ')
            Write-Output "원격 실행: $Exe $argLine"
            $p = Start-Process -FilePath $Exe -ArgumentList $args -Wait -PassThru -NoNewWindow
            $codes += $p.ExitCode
            if ($p.ExitCode -eq 0) { return 0 }
        }
        if ($codes -contains 0) { return 0 }
        return ($codes | Select-Object -Last 1)
    }

    Write-Host "WinRM 원격 설치 시도: $HostName"
    try {
        $exitCode = Invoke-Command -ComputerName $HostName -Credential $Credential -ScriptBlock $scriptBlock -ArgumentList $remoteExe -ErrorAction Stop
        return [int]$exitCode
    } catch {
        Write-Warning "WinRM 실패: $($_.Exception.Message) — WMI 원격 프로세스로 재시도"
    }

    $cmd = "cmd.exe /c `"$remoteExe /quiet /norestart`""
    $result = Invoke-WmiMethod -ComputerName $HostName -Credential $Credential -Class Win32_Process -Name Create -ArgumentList $cmd -ErrorAction Stop
    if ($result.ReturnValue -ne 0) {
        throw "WMI Win32_Process.Create 실패 ReturnValue=$($result.ReturnValue)"
    }
    Write-Host "WMI로 설치 프로세스 시작 (PID $($result.ProcessId)). 90초 대기..."
    Start-Sleep -Seconds 90
    return 0
}

Ensure-Installer

if ($LocalOnly) {
    $probe = Join-Path (Split-Path $PSScriptRoot -Parent) 'DB\DB.mdb'
    if (Test-AceX86OleDb -ProbeMdb $probe) {
        Write-Host "로컬 ACE x86 이미 동작 OK"
        exit 0
    }
    $code = Install-AceX86 -ExePath $installerPath
    if ($code -ne 0) {
        Write-Host "/quiet 실패(exit $code) -> /passive 재시도"
        $code = Install-AceX86 -ExePath $installerPath -ExtraArgs @('/passive', '/norestart')
    }
    if ($code -ne 0) { throw "로컬 ACE x86 설치 실패 exit $code" }
    Write-Host "로컬 ACE x86 설치 완료"
    exit 0
}

if (-not $Password) {
    if ($env:DEPLOY_PASSWORD) {
        $Password = ConvertTo-SecureString $env:DEPLOY_PASSWORD -AsPlainText -Force
    } else {
        throw "원격 설치에 Administrator 암호 필요: `$env:DEPLOY_PASSWORD='암호' 후 재실행"
    }
}

$cred = New-Object System.Management.Automation.PSCredential($UserName, $Password)

Write-Host "Ping: $RemoteHost"
if (-not (Test-Connection -ComputerName $RemoteHost -Count 1 -Quiet)) {
    throw "Ping 실패: $RemoteHost"
}

$remoteMdb = "\\$RemoteHost\C$\Program Files\Ftech\DB\DB.mdb"
if (-not (Test-Path -LiteralPath $remoteMdb)) {
    $remoteMdb = "\\$RemoteHost\C$\Ftech\DB\DB.mdb"
}
Write-Host "현장 DB 경로 확인: $remoteMdb -> $(Test-Path -LiteralPath $remoteMdb)"

$exitCode = Invoke-RemoteAceInstall -HostName $RemoteHost -Credential $cred -LocalInstaller $installerPath
if ($exitCode -ne 0) {
    Write-Warning "원격 exit $exitCode — /passive 파일 재복사 후 WMI 재시도 가능"
}

Write-Host "완료. 현장 PC에서 RS4_OP05_NEW.exe 재실행 후 Menu > Basic 확인"
