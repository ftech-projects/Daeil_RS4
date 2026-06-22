@echo off
chcp 65001 >nul
title OP05 - Access Database Engine x86 설치

:: 관리자 권한 확인
net session >nul 2>&1
if %errorLevel% neq 0 (
    echo [오류] 관리자 권한으로 실행하세요.
    echo        파일 우클릭 -^> "관리자 권한으로 실행"
    pause
    exit /b 1
)

set "DIR=%~dp0"
set "EXE=%DIR%accessdatabaseengine.exe"

if not exist "%EXE%" (
    echo [오류] accessdatabaseengine.exe 가 없습니다.
    echo        이 폴더 전체를 USB 등으로 복사했는지 확인하세요.
    pause
    exit /b 1
)

echo ========================================
echo  OP05용 ACE x86 (Access Database Engine)
echo  RS4_OP05_NEW.exe 가 DB.mdb 를 열 때 필요
echo ========================================
echo.
echo 설치 파일: %EXE%
echo.

echo [1/2] /quiet 설치 시도...
"%EXE%" /quiet /norestart
if %errorLevel% equ 0 goto :OK

echo.
echo [2/2] /quiet 실패 (exit %errorLevel%) - Office 64비트 충돌 가능
echo       /passive 로 재시도 (화면에 진행 표시)...
"%EXE%" /passive /norestart
if %errorLevel% equ 0 goto :OK

echo.
echo [오류] 설치 실패 exit %errorLevel%
echo.
echo 확인 사항:
echo  - Office 64비트 와 충돌 시 Microsoft 문서 참고
echo  - 기존 Access Database Engine 제거 후 재시도
echo  - PC 재부팅 후 다시 실행
pause
exit /b %errorLevel%

:OK
echo.
echo [완료] ACE x86 설치가 끝났습니다.
echo        PC 재부팅 또는 RS4_OP05_NEW.exe 재실행 후
echo        Menu -^> Basic 가 열리는지 확인하세요.
echo.
pause
exit /b 0
