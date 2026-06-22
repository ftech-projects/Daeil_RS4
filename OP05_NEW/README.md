# OP05_NEW

기존 `Op05`를 NI DAQ + 아두이노 제거하고 ELCO 하드웨어로 교체한 버전.

## 신규 하드웨어
- **OSM41-KL30CB6/485** ×4 — RS485 멀티드롭, Conventional 프로토콜 (Query 모드)
- **FBEI-3200N-TS** ×1 — 32DI, EtherNet/IP
- **FBEI-0032N-TS** ×1 — 32DO, EtherNet/IP

상세 통신 사양은 [`docs/COMMUNICATION_SPEC.md`](docs/COMMUNICATION_SPEC.md), 마이그레이션 계획은 [`docs/MIGRATION_PLAN.md`](docs/MIGRATION_PLAN.md) 참조.

## 빌드 전 준비

### 1. EEIP.NET 라이브러리 설치
EtherNet/IP 통신용 EEIP.dll을 `RS4/lib/EEIP.dll` 경로에 배치 필요.

```powershell
# NuGet으로 받기 (PowerShell)
nuget install EEIP -OutputDirectory C:\Users\ryudae33\Desktop\Apps\RS4\packages
# 받은 다음 lib\net*\EEIP.dll → RS4\lib\EEIP.dll 로 복사
```

또는 GitHub에서 직접: <https://github.com/rossmann-engineering/EEIP.NET> 빌드 후 DLL 복사.

### 2. OSM41 4대 초기 설정 (현장)
1. PC와 1대씩 단독 연결 (115200 8N1)
2. 각 센서 메뉴 진입 (TEACH 3초)
3. `adr` 메뉴에서 주소를 1, 2, 3, 4로 각각 설정
4. `Set Output Mode` (`0x83`)로 모두 **Query** 모드 변경 (코드가 시작 시 자동 시도하지만 수동 설정도 OK)
5. 4대 모두 같은 RS485 버스에 결선

### 3. FBEI 모듈 IP 설정 (현장)
1. ELCO **IP Setting Tool** 다운로드 후 설치
2. PC NIC: `192.168.250.100/24` 임시 설정
3. FBEI-3200N-TS (32DI) → `192.168.250.10` 고정
4. FBEI-0032N-TS (32DO) → `192.168.250.11` 고정
5. "Start fixed IP" 옵션 체크하여 다음 부팅에도 유지

## 빌드
```cmd
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" ^
  "Op03(192.168.0.122).vbproj" /p:Configuration=Release /v:minimal
```

## 주의 (실측 후 확인 필요)
- OSM41-KL30CB6 거리 응답 단위 — 매뉴얼은 mm. KL30CB6 분해능 0.001mm라 0.001mm 가중치 가능성 있음. **실제 센서 응답값과 캘리퍼 실측을 비교해서 `OsmLaserClient.ReadDistance` 반환값을 mm로 변환하는 스케일 결정 필요**.
- 기존 NI DAQ는 0~5V → 20~200mm (Y=36X+20) 변환식 사용. OSM41 mm 값을 그대로 쓰려면 측정 위치/캘리브레이션 재조정 필요.

## 변경 파일
- 제거: `DaqTask2.vb`, `DaqTask2.User.vb`, `DaqTask2.mxb` (NI DAQ)
- 신규: `Common/OsmLaserClient.vb`, `Common/FbeiIoClient.vb`, `config.json`, `docs/*`
- 수정: `FrmMain.vb` (NI DAQ 블록 제거 + 신규 클라이언트 통합), `Op03(192.168.0.122).vbproj`
