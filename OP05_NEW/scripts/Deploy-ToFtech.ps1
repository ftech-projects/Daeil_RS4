# OP05_NEW bin -> 현장 PC \\192.168.0.10\C$\Ftech 만 배포 (로컬 C:\Ftech 사용 안 함)
# 사용 예:
#   .\Deploy-ToFtech.ps1
#   $env:DEPLOY_PASSWORD='암호'; .\Deploy-ToFtech.ps1
#   .\Deploy-ToFtech.ps1 -RemoteHost 192.168.0.10 -UserName Administrator

param(
    [string]$SourceDir = (Join-Path $PSScriptRoot '..\bin'),
    [string]$RemoteHost = '192.168.0.10',
    [string]$RemoteSubPath = 'Ftech',
    [string]$UserName = 'Administrator',
    [SecureString]$Password
)

$ErrorActionPreference = 'Stop'
$SourceDir = [System.IO.Path]::GetFullPath($SourceDir)

if (-not (Test-Path -LiteralPath $SourceDir)) {
    throw "소스 없음: $SourceDir (먼저 Release 빌드)"
}

if (-not $Password) {
    if ($env:DEPLOY_PASSWORD) {
        $Password = ConvertTo-SecureString $env:DEPLOY_PASSWORD -AsPlainText -Force
    } else {
        $Password = Read-Host "현장 PC ($RemoteHost) 계정 [$UserName] 암호" -AsSecureString
    }
}

$cred = New-Object System.Management.Automation.PSCredential($UserName, $Password)

Write-Host "연결: \\$RemoteHost\C$ ..."
$drive = New-PSDrive -Name 'DeployFtechRemote' -PSProvider FileSystem -Root "\\$RemoteHost\C$" -Credential $cred -ErrorAction Stop
try {
    $remoteFtech = "DeployFtechRemote:\$RemoteSubPath"
    if (-not (Test-Path -LiteralPath $remoteFtech)) {
        New-Item -ItemType Directory -Path $remoteFtech -Force | Out-Null
        Write-Host "폴더 생성: \\$RemoteHost\C$\$RemoteSubPath"
    }

    Write-Host "복사: $SourceDir -> \\$RemoteHost\C$\$RemoteSubPath"
    & robocopy $SourceDir $remoteFtech /E /XO /R:2 /W:3 /NP /NFL /NDL | Out-Null
    $rc = $LASTEXITCODE
    if ($rc -ge 8) { throw "robocopy 실패 (exit $rc)" }
    Write-Host "완료 (robocopy exit $rc)"
    Write-Host "현장 실행: C:\$RemoteSubPath\RS4_OP05_NEW.exe"
} finally {
    Remove-PSDrive -Name 'DeployFtechRemote' -Force -ErrorAction SilentlyContinue
}
