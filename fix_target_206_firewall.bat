@echo off
chcp 65001 >nul
:: ============================================================
::  타겟 PC(192.168.0.206) 핑/ftechremote 방화벽 해제 + 진단
::  사용법: 타겟 PC AnyDesk 화면으로 이 파일 복사 후 더블클릭
::          (UAC 뜨면 "예" → 관리자 권한으로 실행됨)
:: ============================================================

:: --- 관리자 권한 자동 상승 ---
net session >nul 2>&1
if %errorlevel% neq 0 (
    echo 관리자 권한으로 다시 실행합니다... UAC 창에서 "예"를 누르세요.
    powershell -NoProfile -Command "Start-Process -FilePath '%~f0' -Verb RunAs"
    exit /b
)

echo ============================================
echo  FtechRemote / Ping 방화벽 해제 + 진단
echo ============================================
echo.

echo [1] 192.168.0.206 이 어느 NIC인지 + 네트워크 프로필 (Public이면 그게 원인)
powershell -NoProfile -Command "Get-NetIPAddress -IPAddress 192.168.0.206 -ErrorAction SilentlyContinue | Select-Object InterfaceAlias,IPAddress | Format-Table -AutoSize; Get-NetConnectionProfile | Select-Object InterfaceAlias,NetworkCategory | Format-Table -AutoSize"
echo.

echo [2] ICMP(ping) 인바운드 허용
netsh advfirewall firewall add rule name="Allow ICMPv4 Echo In" protocol=icmpv4:8,any dir=in action=allow
echo.

echo [3] ftechremote 포트 5050 인바운드 허용
netsh advfirewall firewall add rule name="FtechRemote 5050" dir=in action=allow protocol=TCP localport=5050
echo.

echo [4] 5050 리슨 상태 (LocalAddress가 0.0.0.0 또는 :: 이어야 원격에서 붙음. 127.0.0.1이면 agent 바인딩 수정 필요)
powershell -NoProfile -Command "Get-NetTCPConnection -LocalPort 5050 -State Listen -ErrorAction SilentlyContinue | Select-Object LocalAddress,LocalPort,OwningProcess | Format-Table -AutoSize; Get-Service *ftech*,*remote* -ErrorAction SilentlyContinue | Select-Object Name,Status | Format-Table -AutoSize"
echo.

echo [5] 보드망(192.168.250.x) NIC 붙어있나 (IO보드 통신용)
powershell -NoProfile -Command "Get-NetIPAddress -AddressFamily IPv4 | Where-Object {$_.IPAddress -like '192.168.250.*'} | Select-Object InterfaceAlias,IPAddress | Format-Table -AutoSize"
echo.

echo ============================================
echo  완료. 위 [4]/[5] 출력을 캡처해서 알려주세요.
echo  - [4] LocalAddress = 0.0.0.0  -^> 원격 접속 가능
echo  - [5] 192.168.250.x 있어야  -^> 보드 통신 가능
echo ============================================
pause
