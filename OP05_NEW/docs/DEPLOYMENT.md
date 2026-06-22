# 현장 PC 배포 (192.168.0.10 등)

## 필수 런타임

| 구성요소 | 용도 |
|----------|------|
| .NET Framework 4.8 | 애플리케이션 |
| **Access Database Engine 2016 (x86)** | **`DB\DB.mdb`** — Basic/Port/Barcode/로컬 Part (OLEDB `Microsoft.ACE.OLEDB.12.0`) |
| EEIP.dll | FBEI EtherNet/IP (빌드 출력 `bin`에 포함) |

> **RS4_OP05_NEW.exe는 32비트(x86) 빌드**입니다. Windows가 64비트여도 **ACE x86**이 필요합니다. ACE x64만 설치되어 있으면 「공급자를 찾을 수 없습니다」 오류가 납니다.

### ACE x86 설치 (현장 PC)

1. [Microsoft Access Database Engine 2016 Redistributable](https://www.microsoft.com/en-us/download/details.aspx?id=54920) → **`accessdatabaseengine.exe`** (32비트, 약 78MB)
2. 관리자 권한: `accessdatabaseengine.exe /quiet /norestart`  
   Office 64비트와 충돌 시: `/passive /norestart`
3. 또는 개발 PC에서 원격 스크립트:
   ```powershell
   cd OP05_NEW\scripts
   $env:DEPLOY_PASSWORD='현장 Administrator 암호'
   .\Install-AceX86Remote.ps1
   ```

| 구성요소 | 용도 (선택) |
|----------|------|
| Mitsubishi MX Component | PLC 사용 시만 — **현장 OP05는 PLC 제거 빌드** |

## 배포 파일

`bin` 폴더 전체를 현장 경로(예: `C:\Program Files\Ftech\` 또는 `C:\Ftech\`)에 복사:

- `RS4_OP05_NEW.exe`
- `RS4_OP05_NEW.exe.config`
- `config.json`
- `EEIP.dll`, `Interop.ACTETHERLib.dll`, `AxInterop.ACTETHERLib.dll`
- **`DB\DB.mdb`** (필수 — 없으면 0x800A0E7D 연결 오류)
- **`SOUND\NG.wav`, `SOUND\DINGDONG.wav`** (있으면 재생, 없으면 스킵)
- `IMAGE\` (있는 경우)

PopV4와 동일하게 `DB\DB.mdb`는 exe **바로 아래** `DB` 폴더에 있어야 합니다.

## 오류 0x80040154

**원인:** MX Component 미설치 또는 COM 미등록.  
**해결:** 현장 PC에 MX Component 설치 후 재부팅, 프로그램 재실행.

DLL만 복사하는 것으로는 해결되지 않습니다.
