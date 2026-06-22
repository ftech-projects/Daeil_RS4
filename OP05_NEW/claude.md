# OP05_NEW 작업 기록 (Claude)

## 2026-06-05 — 작업 경로 전환 (business RS4)

### 이전
- 수정 경로: `C:\Users\Administrator\source\repos\ftech-projects\Daeil_RS4\OP05_NEW` (백업·Git용)

### 현재 (현장/일상 개발)
- **주 작업 경로:** `C:\Program Files (x86)\business\대일공업\RS4\OP05_NEW`
- ftech-projects 쪽 수정본(I/O 메뉴·FrmIo 등) **삭제 없이** business 경로로 robocopy 동기화 완료
- ftech-projects는 백업·Git push 시에만 사용

---

## 2026-06-03 — 임시 테스트 버튼 제거 (BtnTestInsertTableMain)

### 배경
- `Table_Main` INSERT 검증용 **TEST INSERT** 버튼(`BtnTestInsertTableMain`) 및 `SqlQuote`, `BtnTestInsertTableMain_Click`을 개발·현장 테스트에 사용
- 테스트 성공 후 배포본에서 UI·코드 제거

### 변경
- `FrmMain.Designer.vb`: 버튼 선언·`InitializeComponent`·`Controls.Add`·`Friend WithEvents` 삭제
- `FrmMain.vb`: `SqlQuote`, `BtnTestInsertTableMain_Click` 및 summary 주석 삭제

### 빌드
- MSBuild 17.14 Release **성공** → `bin\RS4_OP05_NEW.exe` (기존 BC42020 등 경고만, 오류 없음)

---

## 2026-06-02 — 현장 PC(192.168.0.10) 실행 오류 (t.txt)

### 증상
- 배포 경로: `C:\Program Files\Ftech\RS4_OP05_NEW.exe` (현장 PC)
- `t.txt` 예외: `COMException 0x80040154 (REGDB_E_CLASSNOTREG)` — **클래스가 등록되지 않았습니다**
- 발생 위치: `FrmMain.InitializeActPlc()` → `AxACTETHERLib.AxActQNUDECPUTCP` 생성 시

### 원인
- **Mitsubishi MX Component(ACTETHERLib) COM이 현장 PC에 설치·등록되지 않음**
- `bin`의 `AxInterop.ACTETHERLib.dll` / `Interop.ACTETHERLib.dll`만 복사해도 **네이티브 COM 등록은 되지 않음**
- ping/방화벽과 무관한 **런타임 의존성** 문제

### 코드 수정 (FrmMain.vb)
- `ActPlcEnabled` 플래그 추가
- `InitializeActPlc()` Try/Catch — 미설치 시 앱 크래시 방지, 경고 메시지
- `ConnectPLc` / `WritePlc` / `ReadPLc` / `Tmr_Connect` — `ActPlc` Null·비활성 가드
- MX 없을 때 PLC 타이머 미시작, 상태 라벨 `MX 미설치`

### 빌드
- Release 빌드 성공 → `bin\RS4_OP05_NEW.exe`

### 현장 PC 필수 조치 (PLC 통신 사용 시)
1. **Mitsubishi MX Component** 설치 (개발 PC와 동일 버전 권장)
2. 설치 후 **ActQNUDECPUTCP** COM 등록 확인
3. 배포 시 `bin` 전체 복사: exe, config.json, EEIP.dll, Interop*.dll, IMAGE, SOUND 등
4. x86 빌드 — 현장 PC도 **32비트 MX** / **x86 앱** 일치 확인

### 성능·견고성
- MX 미설치 환경에서도 UI·OSM41/FBEI 초기화는 계속 시도 (기존 Try/Catch 유지)
- PLC만 비활성; 불필요한 `Tmr_Connect` 폴링 제거로 CPU 낭비 감소

---

## 2026-06-02 — 레이저 센서 Keyence IL-300 (PopV4 동일) 반영

### 배경
- 현장 센서: **Keyence IL-300** (DL-RS1A RS-232C)
- 참조 프로그램: `PopV4` (`SerialLaser*_DataReceived`, `MS` + CR/LF, 9600bps)
- 간거리(mm) = **300 - raw** (IL-300)

### 변경
- 신규 `Common/KeyenceIlLaserClient.vb` (PopV4 프로토콜)
- `FrmMain.vb`: `OsmLaserClient` → `KeyenceIlLaserClient`, `config.json` 로드
- `config.json`: `keyenceIl` 섹션 (COM3, IL-300, 4채널 매핑)
- 문서: `docs/KEYENCE_IL.md`
- Release 빌드: `bin\RS4_OP05_NEW.exe`

### 현장 확인
- DL-RS1A R/W 스위치 → **R**
- PopV4 DB의 `Laser1Port` COM 번호와 `config.json` `comPort` 일치
- 앰프 2대면 `amplifiers` 배열에 항목 추가 (PopV4 Laser1/Laser2)

---

## 2026-06-02 — ADODB 0x800A0E7D (LoadPortData)

### 원인
- 현장 `C:\Program Files\Ftech\`에 **`DB\DB.mdb` 미배포**
- `ConnectionOpenMDB()`가 실패해도 예외를 삼켜, 닫힌 `MdbConnect`로 `Recordset.Open` → **0x800A0E7D**

### 수정
- `MDBOperation.ConnectionOpenMDB()` → Boolean, Jet/ACE 순서 시도, `LastMdbError`
- `LoadPortData` 등 연결 실패 시 기본 COM·크래시 방지
- 프로젝트 `DB\DB.mdb` 추가 (PopV4에서 복사), 빌드 시 `bin\DB\` 자동 복사

---

## 2026-06-02 — OP05 전용 `DB.mdb` 신규 생성 (PopV4 참고)

### 배경
- PopV4 `DB.mdb`는 `Table_SET`·`Table_Barcode`(컬럼명 상이) 구조로 **OP05와 호환 불가**
- `LoadPortData` / `LoadBasicData` / 바코드 레이아웃은 OP05 전용 테이블 필요

### 생성 방법
- 스크립트: `scripts\Create-Op05Database.ps1`
- PopV4 `Table_SET`에서 포트 시드: **Scanner=COM3, Printer=Disabled, Tool=COM4** (Laser1Port 등은 `config.json` keyenceIl)
- ADOX로 빈 MDB 생성 후 ACE OLE DB로 테이블·초기 데이터 INSERT

### 테이블·초기 데이터
| 테이블 | 행 수 | 비고 |
|--------|------|------|
| `Table_SerialPort` | 1 | Scanner/Printer/Tool (PopV4 포트) |
| `Table_Barcode` | 1 | S1~S5, BX/BY/BH/BL/BS 기본 좌표 |
| `Table_BASIC` | 1 | 공차·한계 기본값 (0~9999, Tol 5) |
| `Table_Count` | 0 | 작업 시 프로그램이 INSERT |

### 스크립트 수정 (실패 원인)
- Access 예약어 **`BY`**, **`Tool`** → `[BY]`, `[Tool]` 로 CREATE/INSERT 수정
- `CONSTRAINT PK_...` 제거 (Jet CREATE TABLE 문법 오류 방지)

### 배포
- 경로: `OP05_NEW\DB\DB.mdb` → Release 빌드 시 `bin\DB\DB.mdb` 자동 복사 (`CopyToOutputDirectory`)
- 현장: `RS4_OP05_NEW.exe`와 **같은 폴더** 아래 `DB\DB.mdb` 필수 (`MDBOperation` 기준 경로)
- PopV4 DB를 exe 옆에 두면 **다시 0x800A0E7D·컬럼 오류** 발생 — 반드시 OP05용 DB 사용

### 재생성
```powershell
powershell -ExecutionPolicy Bypass -File "scripts\Create-Op05Database.ps1"
```

---

## 2026-06-02 — COM 포트 → Table_SerialPort.Laser

### 변경
- `Table_SerialPort`에 **Laser** 컬럼 추가 (기존 DB는 시작 시 `ALTER TABLE` 자동 마이그레이션)
- `FrmPort` PORT SETTING에 **LASER** 콤보 추가 (COM1~15, Disabled)
- 레이저 COM: `config.json`보다 **DB `PortNumber_Laser` 우선**
- `FrmMain_Load`: `LoadPortData()` 후 `InitializeElcoDevices()` (DB 읽은 뒤 레이저 연결)
- 저장 시 `RestartLaserCommunication()` — 시리얼 재오픈

### 파일
- `Module1.vb`, `MDBOperation.vb`, `FrmPort.*`, `FrmMain.vb`, `KeyenceIlLaserClient.vb`, `Create-Op05Database.ps1`

---

## 2026-06-02 — 레이저 상단 8° cos 보정

### 수식
- `Value` = 모델기준(300) − raw  
- **상단** (LeftUpper/RightUpper): `Value_corrected = Value × cos(8°)`  
- **하단** (LeftLower/RightLower): `Value_corrected = Value × lowerScale + lowerOffset` (기본 scale=1)  
- `LabelFrt` / 길이시험 Frt: 보정된 상단 2채널 합산  
- `LabelRear` / 길이시험 Rear: 보정된 하단 2채널 합산  

### 파일
- `Common\LaserGeometryConfig.vb`, `FrmMain.ApplyLaserValue`, `config.json` → `geometryCorrection`

---

## 2026-06-02 — COM4 MultiMonitor I/O + FBEI 랜 동시 점검

### 구현
- `Common\MultiMonitorIoClient.vb` — MultiMonitor.ino v1 텍스트 (115200, S+DI16+AI+E)
- `Table_SerialPort.Io` = COM4, Tool=Disabled (COM4 충돌 방지)
- PORT SETTING → **I/O (ESP)** 콤보, 저장 시 `RestartIoCommunication`
- `config.json`: `multiMonitor` (COM4), `fbei.enabled`
- DI 1~8 → `lbD4000`~`lbD4007` 표시, 3초마다 `[IO-COM]`/`[FBEI]` 헬스 로그
- `scripts\Test-IoLinks.ps1` — 현장 COM/LAN 점검용

### 현장 확인
- 로그 `[IO-COM] OK frames=... DI[1-8]=...` → ESP 수신 정상
- 로그 `[FBEI] EtherNet/IP 연결 OK` → 랜 I/O 정상
- PC NIC가 192.168.250.x 대역이어야 FBEI ping/연결 가능

---

## 2026-06-02 — 현장 I/O 하드웨어 검증 (사용자 확인)

### 확인 완료
- **COM4 / MultiMonitor(ESP32) I/O 동작 정상** — 실제로 동작 확인함
- 패널 입력 **3점만 사용** (램프/표시등 정상 점등 확인):
  1. **스타트(Start)**
  2. **리셋(Reset)**
  3. **비상 정지(E-Stop / Emergency Stop)**

### 개발 시 유의
- I/O는 32점 전부가 아니라 **위 3입력 + 표시 램프** 중심으로 설계·매핑할 것
- DI 채널 번호(1~16 중 어느 비트)는 추후 PLC/화면 매핑 시 사용자와 재확인
- `lbD4000`~`lbD4007` 모니터는 유지, 공정 연동 시 Start/Reset/E-Stop 3신호 우선 반영

---

## 2026-06-02 — 현장 JIT `0x800A0E7D` (LoadPortData 줄 330) 재분석

### 스택이 말해 주는 것
- 예외 위치: `Module1.LoadPortData()` **330행** `Rs.Open(..., MdbConnect)`
- **현재 소스(OP05_NEW)** 는 동일 코드가 **361행**이며 `Try/Catch`·`ConnectionOpenMDB() As Boolean` 있음
- **구 Op05** 소스는 330행에 `Rs.Open`만 있고 `ConnectionOpenMDB()`는 예외 삼킴 → **현장 exe = 구 빌드**

### DB만 넣어도 계속 나는 이유
1. **구 exe**는 MDB 연결 실패해도 `Rs.Open` 호출 → `0x800A0E7D` (연결 닫힘/무효)
2. 구 코드는 **Jet 4.0만** 사용 — ACE 미설치·64/32비트 불일치 시 연결 실패 빈번
3. `DB.mdb` 경로는 반드시 `exe폴더\DB\DB.mdb` (`C:\Program Files\Ftech\DB\DB.mdb`)
4. PopV4 DB는 `Table_SerialPort` 없음 → 테이블 오류(별도 메시지) 가능

### 현장 조치 (순서)
1. 개발 PC `OP05_NEW\bin\` **전체** 복사 (exe + DB\DB.mdb + config.json + DLL)
2. 구 `RS4_OP05_NEW.exe` 덮어쓰기 (실행 중이면 종료 후)
3. 실행 후 로그에 `[DB]` 메시지 없고 크래시 없으면 신규 빌드 적용됨
4. 여전히 `[DB]`/`DB 파일 없음`이면 **Access Database Engine 2016 Redistributable (x86)** 설치

---

## 2026-06-02 14:25 — `C:\Ftech` 배포 (현장 PC만)

### 정책 변경 (사용자 요청)
- **개발 PC 로컬 `C:\Ftech` 배포 중단** — PostBuildEvent 제거
- 배포 대상: **`\\192.168.0.10\C$\Ftech`** 만 (`scripts\Deploy-ToFtech.ps1` 기본값)

### 배포 방법
```powershell
cd OP05_NEW\scripts
$env:DEPLOY_PASSWORD='현장 Administrator 암호'
.\Deploy-ToFtech.ps1
```

### 미완
- C$ 공유는 **현장 PC Administrator 암호** 필요 — 원격 자동 복사는 암호 확보 후 실행
- 암호는 네트워크로 “알아내기” 불가 → 담당자·설비 문서·현장 로그인·재설정 절차 참고 (사용자에게 안내함)

---

## 2026-06-02 16:29 — Table_Part 관리 화면 추가 (PopV4 형식 참고)

### 구현
- 신규 폼 `FrmPart.vb` 추가: PopV4 스타일의 DataGridView 기반 관리 UI
- 메뉴 추가: `FrmMain` 상단 `Menu > Part` 항목 신설, 클릭 시 `FrmPart.Show()`
- 기능: **조회 / ADD / DELETE / Save / Close**
- 필터: `OptionType(STD/FOLD/VIP)`, `OptionLHRH(LH/RH)`

### CRUD 대상 컬럼 (OP05 사용 컬럼 중심)
- `PartNo`, `PartName`
- `OptionLHRH`, `OptionType`, `OptionBack`, `OptionFootRest`, `OptionMon`
- `Target_Op04_ToolNum`, `Target_Op04_RivetNum`
- `Target_Op03_InsideCoverL`, `Target_Op03_InsideCoverR`

### 문제점/주의
- SQL은 기존 코드베이스 방식(ADODB + 동적 SQL)과 동일하여 강타입/파라미터가 아님
- 현장 SQL 스키마에 컬럼명이 다르면 저장 시 예외 가능(특히 `OptionMon`, Target 컬럼)
- 저장 전 `PartNo` 중복/빈값 검증 로직은 최소화 상태이므로 운영 입력 규칙 필요
- 로컬 CLI 빌드 검증은 `AxImp.exe` 미설치(MSB3091)로 중단됨. Visual Studio IDE 빌드 환경에서 최종 확인 필요

## 2026-06-02 16:40 — FrmPart 빌드 오류 수정 및 재검증

### 수정
- `FrmPart.vb`에 `Imports System.Collections.Generic` 추가 (`List(Of T)` 인식)
- `For Each id In deletedIds`를 `For Each deletedId As Integer In deletedIds`로 수정 (BC30451 해결)

### 빌드 검증
- Visual Studio 2022 MSBuild 경로로 직접 빌드 실행:
  `C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe OP05_NEW.vbproj /t:Build /p:Configuration=Release /p:Platform=AnyCPU`
- 결과: **오류 0 / 경고 47**
- 결론: 사용자 보고한 `BC30002`, `BC30451`는 재현되지 않으며 해결 완료

---

## 2026-06-02 16:52 — SQL↔MDB Part 동기화 + 오프라인 비상 운전

### 구현
- `Common/MDBOperation.vb`
  - `EnsurePartLocalTable()` 추가: 로컬 `DB.mdb`에 `Table_Part_Local` 자동 생성/보장
- `FrmMain.vb`
  - 앱 시작 시 `EnsurePartLocalTable()` 실행
  - `LoadPArt()`를 **SQL 우선, 실패 시 MDB(`Table_Part_Local`) fallback**으로 변경
  - SQL 오프라인 fallback 사용 시 로그 출력: `[PART] SQL 오프라인 - 로컬 Table_Part_Local 사용`
- `FrmPart.vb`
  - 조회/저장 모드를 SQL/MDB 자동 전환 (SQL 불가 시 MDB 모드)
  - 동기화 버튼 추가:
    - `SQL→MDB` (서버 마스터를 로컬 비상본으로 동기화)
    - `MDB→SQL` (오프라인 수정본을 서버 복구 시 반영)

### 운용 방식
- 평상시: SQL 온라인 상태에서 `SQL→MDB` 주기 실행(비상본 최신화)
- 장애 시: 자동으로 MDB `Table_Part_Local` 참조하여 생산 지속
- 복구 후: `MDB→SQL` 실행해 서버 마스터에 반영

### 빌드 검증
- VS2022 MSBuild 실행 결과: **오류 0 / 경고 47**

---

## 2026-06-02 17:00 — EnsurePartLocalTable 시작 강제 실행 로그 보강

### 변경
- `EnsurePartLocalTable()`를 `Boolean` 반환으로 변경(성공/실패 판별)
- `FrmMain_Load`에서 시작 시 강제 실행 후 로그 명시:
  - 성공: `[DB] EnsurePartLocalTable OK: <DB 경로>`
  - 실패: `[DB] EnsurePartLocalTable FAIL: <DB 경로> | <오류>`

### 검증
- VS2022 MSBuild 빌드 결과: **오류 0 / 경고 48**

---

## 2026-06-02 17:18 — Step 추적 UI 변경 (TextBoxFrt/Rear 제거)

### 변경
- `FrmMain.Designer.vb`
  - `TextBoxFrt`, `TextBoxRear` 컨트롤/선언 제거
  - `LabelFrt`, `LabelRear` 디자인(위치/크기/스타일)은 유지, 초기 텍스트만 변경
    - 상단: `wStep: 0`
    - 하단: `reStep: 0`
- `FrmMain.vb`
  - 레이저 합산용 `UpdateLaserSumLabels()` 제거
  - 신규 `UpdateStepTraceLabels()` 추가: `LabelFrt=현재 wStep`, `LabelRear=마지막 reset 시점 rStep`
  - `Tmr_Work_Tick`에서 매 tick 갱신
  - PLC reset 분기(`PlcValue(4000)=0 and wStep<>0`)에서 `rStep = wStep` 기록 후 `wStep=0`
  - `InitControl()`에서 라벨 갱신 호출

### 목적
- 어디 단계(`wStep`)에서 멈췄는지 실시간 확인
- reset 시 어느 단계에서 떨어졌는지(`reStep`) 추적 가능

### 검증
- VS2022 MSBuild 빌드 결과: **오류 0 / 경고 48**

---

## 2026-06-02 17:25 — PLC/I-O 육안 신호 표시 강화 (PopV4 스타일)

### 변경
- `FrmMain.vb`
  - 공통 함수 `ApplySignalColor(label, isOn)` 추가
    - ON: `DarkBlue`, OFF: `DarkRed`, 글자색 `White`
  - `RefreshPlcSignalIndicators()` 추가
    - `D4000~D4009`, `D4050~D4059` 라벨 색상을 현재 값(0/비0)에 따라 갱신
  - `ReadPLc()`에서 값 텍스트 갱신 후 즉시 `RefreshPlcSignalIndicators()` 호출
  - `ApplyIoInputToLabel()`(COM I/O 입력 이벤트)에서도 해당 `D4000~D4007` 라벨 색상 동시 갱신

### 효과
- PLC/IO 신호가 OFF/ON일 때 라벨 배경색이 즉시 바뀌어
  작업자가 **신호 유입 여부를 육안으로 바로 확인 가능**

### 검증
- VS2022 MSBuild 빌드 결과: **오류 0 / 경고 48**

---

## 2026-06-03 16:50 — 네트워크·SQL·wStep 시뮬레이션 점검 (192.168.0.222 / 192.168.0.10)

### 네트워크 (개발 PC 기준)
| 대상 | Ping | 포트/서비스 | 결과 |
|------|------|-------------|------|
| 192.168.0.222 (SQL) | OK (1ms) | ADODB SQLOLEDB | **연결 OK** |
| 192.168.0.10 (현장) | OK (1~2ms) | SMB 445 | **포트 OPEN** |
| 192.168.0.10 C$ | — | 파일 공유 | **인증 필요 (암호 없음)** |
| 192.168.0.10 WinRM | — | winrs | **인증/TrustedHosts 필요** |

### SQL 서버 (192.168.0.222\Ftech_Svr)
- `Table_Part`: **116건** (샘플: `88311-T4000`)
- `Table_Main`: **136,356건**
- Connect Timeout=2~3초 설정으로 빠른 응답 확인

### wStep 시나리오 시뮬레이션 (`temp_seq_sim.py` / `Test-FieldIntegration.ps1`)
| 시나리오 | 기대 final wStep | 결과 |
|----------|------------------|------|
| A 정상완료 (스캔→길이OK→조립OK→완료) | 0 | **PASS** |
| B 길이NG 후 재시도 | 0 | **PASS** |
| C 이전공정NG | 1 (스캔대기 복귀) | **PASS** |

### 현장 PC 원격 실행 — **미완 (차단 요인)**
- `\\192.168.0.10\C$\Ftech` / `Program Files\Ftech` → Administrator **암호 미설정** (`DEPLOY_PASSWORD` 없음)
- WinForms GUI + PLC/COM/레이저 하드웨어는 **원격 headless 실행 불가**
- 현장 PC에서 직접 확인 필요

### 현장 PC 수동 시뮬레이션 절차 (작업자)
1. `RS4_OP05_NEW.exe` 실행 → 상단 `wStep: 0` 확인
2. PLC `D4000=1` (또는 Start 입력) → `wStep: 1` (스캔대기)
3. 바코드 23자 이상 스캔 → `wStep: 2` → `2.1` → `3`
4. PLC `D4004=1` + 레이저 길이 OK → `wStep: 4`
5. Tool/Rivet/Cover OK → `wStep: 5` → `6`
6. PLC `D4001=1` → 바코드 출력·DB저장 → `wStep: 0`
7. Reset(`D4000=0`) 시 `reStep`에 직전 단계 표시

### 추가 산출물
- `scripts\Test-FieldIntegration.ps1` — 현장 PC에서 네트워크/SQL/MDB/wStep 시뮬레이션 일괄 점검
- Release 빌드: `bin\RS4_OP05_NEW.exe` (2026-06-03 재빌드 OK)

### 성능·견고성
- SQL 오프라인 시 2초 내 fallback (`Table_Part_Local`)
- 원격 배포/점검은 `DEPLOY_PASSWORD` 설정 후 `Deploy-ToFtech.ps1` + `Test-FieldIntegration.ps1` 조합 권장

---

## 2026-06-03 17:02 — 실제 서버 품번/시리얼/공정바코드 시뮬레이션

### 스크립트
- `scripts\Test-RealBarcodeSimulation.ps1` — SQL `Table_Part`/`Table_Main` 실데이터로 `LoadPArt`·`CheckBefore`·wStep 재현

### 시나리오 결과 (192.168.0.222 실데이터)

| 시나리오 | 실제 바코드 | wStep1 결과 | 최종 wStep |
|----------|-------------|-------------|------------|
| A OK 완료 | `20260602005088411-T4240BRZ` (FOLD/RH) | PASS → 2 | **0** (정상 완료) |
| B 전공정 NG | `20260525006888411-T4280NNB` (VIP/RH, **OpTest=NG**) | **1.1** (알람) | **1.1** |
| C FOLD OK | `20260602000288411-T4220NNB` | PASS → 2 | **0** |
| D **공정바코드 Sab1** wStep1 | `[)>…P80650T4000…` (Len=74) | **1.1** | — |
| E **공정바코드** wStep2 커버 | Sab1/Sab2/Lsupt | **NG** (커버 타겟 불일치) | — |
| E 정답 CoverL/R | `88025T4100BRZ` / `88045T4100BRZ` | **OK** | — |
| F 미등록 품번 | `20260603999999999-T9999ZZZ` | **1.1** (품번 미등록+전공정 INIT) | — |

### 공정바코드 동작 정리
- **wStep=1(스캔대기)에서 공정바코드(Sab/Lsupt) 스캔 시**
  - `Mid(13,11)` 품번키가 `P80650T400` 등 **엉뚱한 값** → `Table_Part` 미등록
  - `Table_Main.SerialNo` 조회도 **미매칭** → 전공정 라벨 INIT → **wStep 1.1 (이전공정 NG 알람)**
  - **제품 시리얼(26자)만 wStep1에서 사용 가능**
- **wStep≥2에서 공정바코드 스캔 시**
  - `InStr(ScanData, srclbTargetCoverL/R)` 비교
  - Sab1/Sab2/Lsupt AIAG 문자열은 Cover 타겟(`88025T4100`+색상코드) **미포함 → NG()**
  - **Inside Cover 전용 바코드**만 CoverL/R OK

### 참고 (VIP 전공정 체크)
- 코드는 `PartName.Contains("VIP")`일 때만 `OpVip_Decision` 검사
- `OptionType=VIP`이어도 PartName에 "VIP" 문자 없으면 **VIP 체크 NA 처리** (B 시나리오는 OpTest=NG로 차단)

### 성능·견고성
- 시뮬레이션은 DB read-only, 현장 PLC/레이저 없이 로직 검증용

---

## 2026-06-03 17:10 — 88310-T4330 스캔 테스트

### 테스트 시리얼 (서버에 실적 없음 → 가상 조합)
- `20260603000188310-T4330NNB` (Len=26)
- `Mid(13,11)` → `88310-T4330` (`Table_Part` **등록됨**)
- `Mid(13,14)` → `88310-T4330NNB` (화면 품번)

### 스캔 결과 (FlagBeforeCheck=True 가정)
- **wStep 1.1** — `Table_Main`에 해당 SerialNo **없음** → 전공정 라벨 blank → NG
- 현장 MDB `FlagBeforeCheck=False`이면 CheckBefore 생략 → **wStep 2** 직행 가능

### 88310-T4330 Table_Part 주요 값
| 항목 | 값 | OP05 스캔 시 사용 |
|------|-----|-------------------|
| PartName | FRAME ASSY-FR SEAT BACK,LH | ✅ |
| OptionLhRh | LH | ✅ |
| OptionType | **(비어 있음)** | ✅ but wStep3 길이시험 분기 **미적용** |
| Target_Op04_ToolNum/RivetNum | **(비어 있음)** | ✅ → 0 |
| CoverL/R | 88015T4000 / 88035T4000 | ✅ → `88015T4000NNB` / `88035T4000NNB` |
| Op01 Frame/Motor, Op02 Lsupt/Sab | 88315T4200, 88340T4300, 80610T4500… | ❌ LoadPArt **미사용** (PopV4용 컬럼) |

### 문제점
- `Table_Main` 실적 0건 → 전공정 확인 불가
- `OptionType`·Op04 Tool/Rivet **미입력** → OP05 공정(길이/조립) 정상 판정 어려움
- FrmPart에서 OptionType·Target_Op04_* 보완 필요

---

## 2026-06-03 17:25 — wStep=1 미진입·스캔 무반응 원인 및 수정

### 사용자 증상 (88310-T4330)
- 스캔해도 **품번/알람/wStep 2 모두 없음** — wStep=1 자체가 안 되는 것 같음

### 근본 원인 1 — **COM I/O ↔ PlcValue 단절 (치명)**
- `Tmr_Work`는 **`PlcValue(4000)=1`** 일 때만 wStep 0→1
- ESP32 `ApplyIoInputToLabel`은 **`lbD4000` 라벨만** 갱신, `PlcValue(4000)` **미갱신**
- MX 미설치/미연결 시 `ReadPLc()`도 안 돌아감 → **PlcValue(4000) 항상 0 → wStep 영구 0**
- `Serial_Scanner_DataReceived`는 **`wStep=1`일 때만** 처리 → 스캔 **완전 무시**

### 근본 원인 2 — 스캔 바코드 형식
- wStep=1은 **`Len(ScanData) >= 23`** (전체 시리얼) 필요
- 품번 라벨 `88310-T4330`(11자)만 스캔하면 **조용히 무시** (로그 없었음)

### 근본 원인 3 — LoadPArt 예외 가능
- `88310-T4330`: `Target_Op04_ToolNum/RivetNum` 빈값 → `CInt("")` 예외 → 스캔 핸들러 중단

### 수정 (`FrmMain.vb`)
1. `ApplyIoInputToLabel`: MX 미설치/미연결 시 `PlcValue(3999+channel)` 동기화
2. `LoadPArt`: `RsFieldStr/Int/Bool` — OptionLhRh·빈 Tool/Rivet 안전 처리
3. `Serial_Scanner_DataReceived`: Try/Catch + wStep/Len/거부 사유 **로그 출력**

### 현장 확인 절차
1. Start(D4000) ON → 상단 **`wStep: 1`** 확인
2. **26자 시리얼** 스캔 (예: `20260603000188310-T4330NNB`)
3. 로그 `[SCAN] ...` 메시지 확인
4. wStep=0이면 Start 신호/PlcValue(4000) 먼저 점검

### 빌드
- Release **오류 0** (`bin\RS4_OP05_NEW.exe`)

---

## 2026-06-03 17:40 — PLC 제거, I/O 전용 wStep 재정의

### wStep 흐름 (변경 후)
| wStep | 의미 | 전환 |
|-------|------|------|
| **0** | **스캔 대기** | 스캔 OK → 1 / NG → 0.1 |
| 0.1 | 전공정 NG 알람 | → 0 |
| **1** | **Start(IN0) 대기** | Start 상승沿 → 2 |
| 2~6 | 공정 (기존과 동일 번호) | 완료 → 0 |

### COM I/O 매핑 (MultiMonitor DI)
| IN | 채널(1-based) | 화면 | 동작 |
|----|---------------|------|------|
| IN0 | 1 | lbD4000 | **Start** — wStep 1에서 상승沿 → wStep 2 |
| IN1 | 2 | lbD4001 | **Reset** — wStep 0 복귀, InitControl |
| IN2 | 3 | lbD4002 | **E-Stop** — 즉시 wStep 0, 알람 |

### PLC 없음(I/O-only) 보조
- `IoOnlyMode()` = MX 미설치 또는 미연결
- wStep 3: 길이시험 **자동 실행** (D4004 대기 생략)
- wStep 4: Tool/Rivet 타겟 0이면 **자동 OK**
- wStep 6: 완료·프린트 **자동 실행** (D4001 대기 생략)

### 수정 파일
- `FrmMain.vb` — ProcessPanelIo, PerformSequenceReset, 스캔 wStep 0/1
- `config.json` — multiMonitor.inputs 주석

### 현장 조작 순서
1. 전원 ON → **wStep: 0** (스캔 대기)
2. 시리얼 바코드 스캔 → **wStep: 1** (품번 표시)
3. **Start(IN0)** 누름 → **wStep: 2**~ 공정 진행
4. **Reset(IN1)** / **E-Stop(IN2)** → **wStep: 0**

---

## 2026-06-03 18:00 — wStep 3 레이저 값 미표시 원인·수정

### 원인
1. **Scanner/Laser COM 충돌** — DB 기본 Scanner=COM3, Laser=COM3
2. **OptionType 비어 있음** → wStep 3 길이 계산 분기 미진입
3. 진단 로그 부족

### 수정
- Laser=Scanner COM 동일 시 레이저 시작 거부 + 로그
- SerialOpen 후 StartLaserPolling 순서
- OptionType 빈값 → STD fallback + RunLengthTestStep3()
- wStep 3 주기적 `[KeyenceIL] wStep3 LU=... recv=Y/N` 로그

### 현장 확인
- PORT SETTING: Scanner/Laser **서로 다른 COM**
- DL-RS1A **R** 스위치, 9600bps
- wStep 3: srcLsr* 4칸 숫자 갱신, 로그 recv=Y/N

---

## 2026-06-03 — 리셋 시도해도 wStep 3 멈춤 원인·수정

### 증상
- 현장: **PLC 없음**, COM I/O(ESP) + PC 시퀀스
- 공정 진행 후 **wStep 3**에서 정지
- **Reset(IN1)** 눌러도 wStep 0으로 안 돌아감

### 원인 (코드 기준, 조건 성립 가정)

**1. wStep 3 정지 — D4004 무한 대기 (1순위)**
- wStep 3 진입 조건: `PlcValue(4004)=1` **또는** `IoOnlyMode()`
- `IoOnlyMode()` = MX **미설치/미연결**일 때만 True
- 현장 PC에 **MX Component만 설치**되어 있고 PLC 실물은 없으면 → `ActPlcEnabled=True`, `FlagPlcConnection` 불명 → `IoOnlyMode=False`
- 결과: **D4004=1** 올 때까지 길이시험 **영구 대기** (PLC 없으면 영원히 3)

**2. Reset 무효 — 타이밍·E-Stop (2순위)**
- Reset은 **100ms 타이머**에서 **상승沿**만 처리 → 짧게 누르면 누락
- 구 코드: **E-Stop ON**이면 Reset 분기 **실행 전 Return** → IN2가 켜져 있으면 Reset 불가
- DI 변화 시 즉시 처리 없음 (COM 프레임은 오는데 타이머만 의존)

**3. wStep 3.1 (길이 NG) 혼동**
- 길이 NG 시 wStep **3.1** — 화면에 "3" 또는 "3.1"로 보일 수 있음
- IoOnly에서 3.1은 D4004=0 재시도 없음 → **Reset만** 탈출

### 수정 (`FrmMain.vb`, `config.json`)
- `config.json` **`plc.enabled: false`** — PLC 시퀀스 비활성, IoOnly 강제
- `LoadPlcSequenceConfig()` 시작 시 로드 → `[PLC] sequence enabled=false`
- `IoOnlyMode()`: `_plcSequenceEnabled=false` 이면 **항상 I/O-only**
- wStep 3: `_runLengthAtStep3` 1회 실행, D4004 대기 시 3초마다 `[wStep3] D4004=0 대기` 로그
- **`HandlePanelIoEdge`**: DI 변화 즉시 Start/Reset/E-Stop (타이머 누락 방지)
- Reset을 **E-Stop보다 먼저** 처리; E-Stop은 **상승沿**만
- `PerformSequenceReset`: `_runLengthAtStep3` 초기화
- PLC D4000-OFF 리셋은 `plc.enabled=true` 일 때만

### 현장 배포 후 확인
1. exe 옆 `config.json`에 `"plc": { "enabled": false }` 포함
2. 기동 로그: `[PLC] sequence enabled=False`
3. wStep 3: `[KeyenceIL] wStep3 ...` + 길이 계산 진행 (D4004 대기 로그 **없어야** 정상)
4. Reset: lbD4001 파란(ON) 순간 로그 `[IO] Reset -> wStep 0`, LabelFrt `wStep: 0`
5. E-Stop ON이면 `[IO] Reset 무시 — E-Stop ON` (E-Stop 해제 후 Reset)

### 빌드
- Release: **오류 0** → `bin\RS4_OP05_NEW.exe`

---

## 2026-06-03 — 로그 1회화·E-Stop 경고·PLC 코드 제거

### 요청
- `[IO-COM] OK` 반복 로그 → **1회만**
- 프로그램 시작 시 **SQL 서버 연결 로그 1회**
- **E-Stop** 시 로그 + Reset 안내 경고
- **PLC 미사용** → PLC 관련 코드 전면 제거

### 변경
- `CheckIoHealth`: `_ioComOkLogged` / `_fbeiOkLogged` — 정상 OK 로그 1회 (프레임 없음 오류는 계속)
- `MmIo_LogMessage`: `[IO-COM] 연결 OK` 1회 필터
- `LogServerConnectionOnce()`: 기동 시 `[SQL] 서버 연결 OK/실패` 1회
- `HandleEmergencyStop()`: 로그 + `srclbAlarm` "E-Stop 해제 후 Reset(IN1)을 눌러주세요"
- E-Stop 중 시퀀스 tick 중단, Reset으로만 복귀
- **PLC 제거**: ActPlc/MX, ReadPLc/WritePlc/ConnectPLc, COMReference ACTETHER, config `plc` 섹션
- 시퀀스: wStep 2.1→3 즉시, wStep 3 길이시험 자동, wStep 6 자동 완료
- UI: Label11=SQL 서버, srcLbPlcConnectionState=`I/O 모드`
- `PlcValue` 배열은 **COM I/O 신호 표시용**으로 유지 (lbD4000~)

### 빌드
- Release: **오류 0**

### 성능·견고성
- 불필요 3초 주기 로그 제거 → 로그창 가독성·CPU 부담 감소
- MX Component 의존 제거 → 현장 PC 설치 요건 단순화
- E-Stop/Reset 분리 → 오조작 시 복구 절차 명확

---

## 2026-06-03 — reStep(리셋 스탭) Reset 후 0 복귀 수정

### 증상
- 화면 하단 **reStep: 3** 에 멈춤 (wStep이 아닌 **리셋 스탭** 표시)
- Reset(IN1) 후에도 reStep이 0으로 안 돌아감

### 원인
- **PLC 제거와 무관** — `PerformSequenceReset()` 이 `rStep = wStep` 으로 **리셋 직전 단계를 reStep에 남기는** 설계였음
- Reset으로 wStep=0은 됐지만 LabelRear(reStep)는 3 유지

### 수정
- `PerformSequenceReset`: `rStep = 0` 명시, 로그 `wStep 0, reStep 0`
- E-Stop(`HandleEmergencyStop`)만 reStep에 멈춘 wStep 기록 → Reset 누르면 reStep도 0

### 확인
- Reset 후: LabelFrt `wStep: 0`, LabelRear `reStep: 0`
- 로그: `[IO] Reset -> wStep 0, reStep 0`

---

## 2026-06-03 — 길이시험 NG: Start(IN0) 재검사

### 변경
- 2초 자동 재검사 **제거**
- NG → **wStep 3.1** (Start 대기)
- **Start(IN0)** 상승沿 → wStep 3 + `_runLengthAtStep3` → 즉시 재검사
- `HandleStartPress()`: wStep 1→2, wStep 3.1→3 공통 처리

### 조작
- 길이 NG 후: **Start** 누름 → 재측정 (srclbAlarm 없음, 로그만)
- 포기 시: **Reset(IN1)**

### 빌드
- Release: **오류 0**

---

## 2026-06-03 — NG음·라벨 자동 맞춤·SOUND 배포

### 변경
- 길이 NG/재검사: **srclbAlarm 미표시**
- `SOUND\NG.wav`, `DINGDONG.wav` 프로젝트 추가 → Release `bin\SOUND\` 자동 복사
- `PlayAppSound`: **파일 있으면 재생, 없으면 스킵** (시스템음·OK.wav 없음)
- `NG()` → `NG.wav`, `DingDOng()` → `DINGDONG.wav` 만
- `Common\LabelTextFitHelper.vb`: 데이터 라벨 글자 크기 자동 축소
- Resize / LoadPArt / InitControl / 길이시험 후 적용

### 현장
- `C:\Program Files\Ftech\SOUND\` **필수** (구 빌드는 폴더 없어 NG 무음+크래시)

---

## 2026-06-03 — PlayAppSound NullReferenceException (Dim path = Path.Combine)

### 증상
- 길이 NG → `NG()` → `PlayAppSound` 줄 101 `NullReferenceException`
- `NewLateBinding.LateGet` / `Container..ctor(Object Instance)`

### 원인
- VB.NET **식별자 대소문자 무시**: `Dim path = Path.Combine(...)` 에서 선언 중인 **`path`(Nothing)** 와 **`System.IO.Path`가 동일** 취급
- `Nothing.Combine(...)` LateGet → NRE (레이저 NG와 무관, **사운드 코드 버그**)

### 수정
- 지역 변수명 `soundPath`, `IO.Path.Combine` 명시
- BeginInvoke 전 `IsHandleCreated` / `IsDisposed` 가드

---

## 2026-06-03 — Basic 저장/불러오기 무음 실패 수정

### 증상
- Menu → Basic 저장해도 재시작·재오픈 시 값 복원 안 됨

### 원인
1. `RecordCount = 1`만 처리 → **행 0개·2개 이상이면 저장/로드 조용히 스킵**
2. `FrmBasic_Load`가 **DB 재로드 없이** 메모리만 표시
3. 저장 성공/실패 **피드백 없음** (DB 쓰기 실패·Program Files 권한 등)
4. 숫자 `CStr()` 저장 — 로케일 이슈 가능

### 수정
- `EnsureBasicTableRow()` — `Table_BASIC` 행 없으면 기본 1행 INSERT
- `LoadBasicData`/`SaveBasicData` → **Boolean**, `SELECT TOP 1`, `adOpenKeyset`, `EOF` 기준
- `FrmBasic`: 열 때 `LoadBasicData`, 저장 시 성공/실패 MessageBox
- 필드명 `RearTolSTD`/`FrtTolSTD` 통일, 숫자는 Double 직접 저장

### 현장 확인
- 저장 실패 시 메시지에 **DB 경로·권한** 안내
- `C:\Program Files\Ftech\DB\DB.mdb` 쓰기 불가면 **관리자 실행** 또는 `C:\Ftech` 배포

---

## 2026-06-03 — Port/Barcode SAVE 동일 패턴 수정

### 점검 대상
| 화면 | 함수 | 기존 문제 |
|------|------|-----------|
| Menu → Port | `SavePortData` / `LoadPortData` | `RecordCount=1`만 처리, 피드백 없음 |
| Menu → Barcode | `SaveBarcodeData` / `LoadBarcodeData` | 동일 |
| Menu → Part | `SaveGrid` | 기존 MessageBox 있음, 수정 시 `RecordCount=1` 스킵 가능 |

### 수정
- `EnsureSerialPortTableRow`, `EnsureBarcodeTableRow` — 행 없으면 기본 1행 INSERT
- Port/Barcode Load·Save → **Boolean**, `SELECT TOP 1`, `adOpenKeyset`, `EOF` 기준
- `FrmPort`/`FrmBarcode`: 열 때 DB 재로드, Save 성공/실패 MessageBox
- `FrmPart`: 수정 행 `RecordCount=1` → **`Not rs.EOF`**, `adOpenKeyset`

### 빌드
- Release: **오류 0**

---

## 2026-06-03 — ACE x86 런타임 의존성 + 원격 설치 스크립트

### 왜 x64 Windows인데 x86 ACE?
- `RS4_OP05_NEW.exe` = **PlatformTarget x86** (32비트 프로세스)
- OLEDB Provider도 **같은 비트**만 로드 가능 (WOW64)
- OS x64 ≠ 앱 x64; **ACE x64만 있으면 x86 앱은 공급자 없음**

### 증상
- Basic 열 때: `공급자를 찾을 수 없습니다` + `DB.mdb` 경로 (파일은 있음)

### 조치
- `scripts\redist\accessdatabaseengine.exe` (Microsoft x86, ~78MB)
- `scripts\Install-AceX86Remote.ps1` — `$env:DEPLOY_PASSWORD` + WinRM/WMI 원격 설치
- `docs\DEPLOYMENT.md` ACE x86 항목 추가

### 원격 설치 시도 (2026-06-03)
- Ping 192.168.0.10 OK
- C$/WinRM: **Administrator 암호 없어 중단** — `$env:DEPLOY_PASSWORD` 설정 후 스크립트 재실행 필요

---

## 2026-06-03 — 스캔 무응답 (wStep=0, PART/SERIAL 빈 화면)

### 현장 증상 (이미지)
- 기동 후 스캔해도 PART NO / SERIAL / 품명 전부 공백, **wStep=0 유지**
- 하단 로그에 `ScanData :` 없음 → **시리얼 수신 자체가 안 됨**

### 원격 점검
- `\\192.168.0.10\C$` — **암호 없어 접근 불가** (`DEPLOY_PASSWORD` 필요)
- `scripts\Test-SiteOp05Check.ps1` 추가 (로컬/원격 ACE·DB·COM 점검)

### 코드 원인
1. **Scanner Handshake = RTS/XON** — 일반 바코드 리더와 불일치, 데이터 미수신
2. **ReadLine 기본 LF** — 스캐너 CR(0x0D) 종단이면 줄 완성 안 됨 → `DataReceived` 후 대기
3. **`Mid(..., Len-1)`** — ReadLine 후 마지막 글자 잘림 → Len&lt;23 무시 가능
4. **Scanner=COM3, Laser=COM3** (DB/config 기본) — PopV4는 Laser **COM5**, 포트 충돌
5. **LoadPortData 실패 시 Scanner=COM1** (ApplyDefaultPortData) — 현장 COM3과 불일치

### 수정
- Scanner: `Handshake=None`, `NewLine=CR`, `ReadTimeout=800`, 수신 정규화(Trim CR/LF)
- 기본 포트: Scanner **COM3**, Laser **COM5**, Io COM4
- `config.json` keyenceIl → COM5
- 기동 로그: `[PORT] Scanner=... Laser=...`
- Open Fail 시 **예외 메시지** 출력

### 현장 조치
1. `bin` 전체 재배포 (신규 exe + config.json + DB)
2. Menu → Port: Scanner=실제 COM, Laser≠Scanner
3. 기동 로그: `Serial Scanner Open Success COMx` 확인 후 스캔 → `ScanData :` 확인

---

## 2026-06-03 — COM 포트 현장 매핑 (config + DB만)

| COM | 용도 |
|-----|------|
| COM1 | Printer |
| COM2 | Scanner |
| COM3 | Laser (config.json keyenceIl) |
| COM4 | I/O (config.json multiMonitor) |

- `config.json`: keyenceIl `comPort` → **COM3**
- `DB\DB.mdb`, `bin\DB\DB.mdb`: `Table_SerialPort` Scanner=COM2, Printer=COM1, Laser=COM3, Io=COM4

### 안내 정책 (2026-06-03)
- **DB/config에 신규 항목(테이블·컬럼·config 키) 추가가 없으면** 「config·DB 같이 배포」 등 **동봉 안내 금지**
- **구조가 달라져 추가가 필요할 때만** 언급
- **PLC 언급 금지 (사용자 요청 2026-06-03)** — 미쓰비시 PLC 통신은 제거됨. 설명·기록 시 **D주소·PlcValue·PLC** 표현 사용하지 않음
- **I/O 설명은 현장 사용분만** — **IN0 Start, IN1 Reset, IN2 E-Stop** 3점 + 표시 램프. DI4~ 및 lbD4003~ 는 모니터용·시퀀스 미사용 → **언급하지 않음**
- **예시·설명 원칙 (사용자 요청 2026-06-03)** — 정보 제공 시 **실제 사용하는 것 위주**로만 예를 든다. (스캐너, 레이저, IN0/1/2, wStep, FrmColor, Cover 스캔, 프린터 등). 미사용 DI·레거시 변수·PopV4 잔재는 예시에 넣지 않음

---

## 2026-06-03 — wStep 4 CInt("") 크래시 (레이저 OK 후 FrmColor)

### 증상
- 길이 OK → FrmColor(NNB 등) 표시 직후 `InvalidCastException` 줄 1674

### 원인
- `TargetToolNum=0` → `srclbDecTool=OK` 인데 `srclbDataTool`은 `""`
- `CInt(srclbDataTool.Text)` 매 tick 예외

### 수정
- wStep 4 Tool/Rivet: `Integer.TryParse` 후 비교, 빈 문자열 스kip

---

## 2026-06-03 — 테스트용 Table_Main INSERT 버튼 (배포 전 삭제 예정)

### 목적
- `SaveDB`는 `UPDATE`만 → `Table_Main`에 시리얼 없으면 OP03 미저장
- 테스트: 스캔 후 서버에 행을 넣어 wStep 6 `UPDATE` 가능하게 함

### UI
- `FrmMain` RESET 버튼 아래 **주황색 `TEST INSERT`**
- `BtnTestInsertTableMain_Click`

### 동작
1. `srcLbSerial` **23자 이상** 필수 (전체 시리얼 스캔 후)
2. 품번: `srcLbPartNo` 없으면 `Mid(serial, 13, 14)`
3. SQL `Table_Main` 중복 시리얼이면 INSERT 안 함
4. INSERT: PartNo, SerialNo, Op01/Op02_1/Op02_2/OpTest = OK + 당일 시각
5. 품명에 VIP 포함 시 `OpVip_Decision` OK 추가
6. `FlagBeforeCheck`이면 `CheckBefore` 재실행

### 삭제 완료 (2026-06-03)
- 테스트 성공(서버 저장 확인) 후 **`TEST INSERT` 버튼·`SqlQuote`·`BtnTestInsertTableMain_Click` 제거**
- Release 빌드 OK → `bin\RS4_OP05_NEW.exe`

---

## 2026-06-03 — IN3 에어툴 I/O (Tool/Rivet 펄스)

### 매핑
| IN | config `inputs` | 역할 |
|----|-----------------|------|
| IN0 | start: 0 | Start |
| IN1 | reset: 1 | Reset |
| IN2 | eStop: 2 | E-Stop |
| IN3 | airTool: 3 | 에어툴 체결 펄스 (Tool → Rivet 순서) |

### wStep 4
- IN3 **상승 엣지**마다 카운트 (`_ioToolPulseCount` / `_ioRivetPulseCount`)
- Tool 목표 달성 후 Rivet 카운트 (동일 IN3)
- 목표 0이면 기존처럼 자동 OK
- 화면 I/O 라벨: IN0 Start ~ IN3 에어툴

### 파일
- `config.json`, `Common/MultiMonitorIoClient.vb`, `FrmMain.vb`, `FrmMain.Designer.vb`

### 수동 설치 패키지 (사용자 직접 설치)
- `scripts\ACE-x86-Install\` — `accessdatabaseengine.exe` + `Install-ACE-x86.bat` + `설치방법.txt`
- `scripts\ACE-x86-Install.zip` — USB/현장 복사용 압축

---

## 2026-06-03 — Menu > I/O 모니터 창 (OP01 PE 스타일)

### 배경
- 192.168.0.205 `RS4_OP01_PE`에 **Menu > I/O** + I/O 모니터 창 존재 (현장 확인)
- 205 PC 소스/C$ 공유 직접 확보 불가 → PopV3 `FrmSignalIO` 패턴 + OP05 이중 I/O(COM ESP + FBEI LAN)에 맞게 구현

### 구현
- 신규 `FrmIo.vb` / `FrmIo.Designer.vb` / `FrmIo.resx`
- `FrmMain` Menu에 **「I/O」** 항목 (Part와 Barcode 사이)
- 모달 `ShowDialog` — 메인 화면 I/O 연결 유지

### 기능
| 탭 | 내용 |
|----|------|
| **COM I/O (ESP)** | DI 1~16 실시간 표시 (IN0 Start, IN1 Reset, IN2 E-Stop, IN3 에어툴 이름 표시), DO 1~8 클릭 토글, AI1~4 raw |
| **LAN I/O (FBEI)** | X1~32 입력 표시, Q1~32 출력 클릭 토글 |
| 하단 | COM 포트/FBEI 연결 상태, CLOSE |

- 100ms 타이머 갱신, ON=녹색(DI)/주황(DO), OFF=회색
- `MultiMonitorIoClient.GetDigitalOutput` / `FbeiIoClient.GetOutput` 추가 (DO 상태 표시·토글)

### 파일
- `FrmIo.*`, `FrmMain.vb`, `FrmMain.Designer.vb`, `Common/MultiMonitorIoClient.vb`, `Common/FbeiIoClient.vb`, `OP05_NEW.vbproj`

### 검증
- VS2022 MSBuild Release: **오류 0** → `bin\RS4_OP05_NEW.exe`

### 문제점 / 차이
- **205 OP01 PE와 픽셀·레이아웃 1:1 동일은 미검증** (원본 FrmIo 소스 미확보)
- OP05는 COM+FBEI **2탭** 구조 (OP01 하드웨어와 다를 수 있음)
- DO 수동 토글은 **공정 중 오작동 위험** — 유지보수·시험용으로만 사용 권장
- 192.168.0.10 배포: `bin\` 전체를 `C:\Ftech`에 덮어쓰기 후 Menu > I/O 확인

### 2026-06-05 — OP01 PE 원본 탐색 + UI 목업
- 205 ping OK, **`\\192.168.0.205\C$` 오류 67** → Ftech/RS4_OP01_PE 파일·소스 미확보
- `ftech-projects` 전역: **`RS4_OP01_PE` vbproj/FrmIo 없음** (Op01 구버전만 존재)
- 유사 참조: `DSC_POP\PopV3\FrmSignalIO` — 64DI/64DO, EDIT/SAVE/CLOSE, 제목 "FTECH IO BOARD Signal Monitor"
- OP05 `FrmIo`는 **COM(ESP)+FBEI 2탭** 구조로 OP05 하드웨어에 맞춤 (PopV3 단일 64/64와 상이)
- UI 목업 이미지: `assets/op05_menu_io_mockup.png`, `assets/op05_frmio_mockup.png`

---

## 2026-06-03 — Part 조회 실패 시 시퀀스 차단 (NRE 예방)

### 배경
- 미등록 품번 스캔 후에도 wStep 1→3 진행 → `OptionType` Nothing → `ResolveOptionTypeForLength()` NRE

### 변경 (`FrmMain.vb`)
- `LoadPArt()` → **`Boolean` 반환** (성공 True / SQL·MDB 미등록 False)
- 실패 로그: `[PART] 조회 실패: {partKey} (SQL Table_Part / MDB Table_Part_Local 미등록)`
- `Serial_Scanner_DataReceived` (wStep 0):
  - 조회 실패 시 **NG.wav**, 알람 `"품번 조회 실패 !! 다시 스캔하세요"`, **wStep 0 유지**
  - 로그: `[SCAN] Part 조회 실패 — wStep 0 유지 (재스캔 대기)`
  - 이전공정 체크 ON/OFF **양쪽** 동일 적용 (실패 시 `CheckBefore` 미호출)
- 조회 성공 시에만 wStep 1 (또는 before-check 분기) 진행

### 성능·견고성
- 잘못된 바코드로 길이시험 단계 진입 불가 → NRE·오판정 방지
- 등록 품번 재스캔 시 정상 진행

### 검증
- VS2022 MSBuild Release: **오류 0** → `bin\RS4_OP05_NEW.exe`

### 현장 배포
- `bin\` 전체를 `C:\Program Files\Ftech\`에 덮어쓰기

---

## 2026-06-03 — OK 판정·작업 완료 띵동(DINGDONG) 보강

### 원인 (완료 시 무음)
- `DingDOng()`는 길이 OK·커버 스캔·에어툴 목표 달성에만 있었음
- **wStep 6**(바코드 출력·DB 저장·초기화)에 **호출 없음** → 마무리 무음
- Tool/Rivet 목표 0(N/A) 자동 OK 시에도 무음

### 변경 (`FrmMain.vb`)
- `MarkDecisionOk(lbl)` 추가: 라벨이 **최초 OK** 될 때만 `DINGDONG.wav`
- 적용: 길이 Frt/Rear, Tool, Rivet, Cover L/R, 목표 0 자동 OK
- wStep 6 (전 항목 OK·작업 완료): 띵동 **1회** + `[SEQ] 작업 완료` (wStep 4→5는 무음 — 완료와 동일 시점이라 중복 제거)

### 검증
- VS2022 MSBuild Release: **오류 0**

---

## 2026-06-03 — 미체결·미스캔 항목 PASS 판정

### 문제
- Tool/Rivet 목표 **0**인데 **OK**+띵동 (체결 없음)

### 변경
- `MarkDecisionPass` / `IsDecisionComplete` / `ApplyPartSkipDecisions`
- Tool/Rivet **0**: 수량 `"0"`, 판정 **PASS**(녹색·무음)
- Cover **0**: 스캔데이터 공란, 판정 **PASS** (NA 폐기)
- wStep 4 완료: **OK 또는 PASS** 전 항목 충족
- Cover PASS 시 스캔 InStr `"0"` 오매칭 방지

---

## 2026-06-03 — 간거리 Frt+Rear 세트 판정·소리

### 변경
- Frt/Rear **판정은 각각** OK/NG 표시
- **소리만 세트 1회**: 둘 다 OK → 띵동 1회·wStep 4 / 하나라도 NG → NG음 1회·wStep 3.1

---

## 2026-06-03 — Part SQL↔MDB 동기화 제거

### 배경
- SQL→MDB / MDB→SQL 동기화 중 오류·데이터 손상 우려

### 변경
- `FrmPart`: **SQL→MDB**, **MDB→SQL** 버튼·`SyncSqlToMdb`/`SyncMdbToSql`/`CopyPartFields` **삭제**
- 조회·저장: **SQL 우선**, 실패 시 **MDB `Table_Part_Local`만** (양방향 복사 없음)
- `LoadPArt`(메인 스캔): 기존과 동일 — SQL 조회 실패 시 로컬 MDB 조회만 (동기화 아님)

### 운용
- 서버 온라인: Part 화면 제목 `SQL`, `Table_Part`에 저장
- 서버 오프라인: `MDB(오프라인)`, `Table_Part_Local`에 저장
- 개별 `MarkDecisionOk` 제거 (`FinalizeLengthSetJudgment`)

### 참고 (2026-06-05)
- **정본**: `business\대일공업\RS4\OP05_NEW` — 동기화 제거 반영됨
- `ftech-projects\Daeil_RS4\OP05_NEW` — `FrmPart`에 SQL↔MDB 버튼 **구버전 잔존**, repo `claude.md`에 본 삭제 섹션 없음 → **repo 쪽이 뒤처짐**
