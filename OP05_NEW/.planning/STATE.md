# OP05_NEW 진행 상황

**최종 갱신**: 2026-05-27
**원본**: `RS4/Op05/` (RS4 솔루션의 12개 프로젝트 중 하나)
**목표**: NI DAQ + 아두이노 제거하고 ELCO 신규 하드웨어로 교체

## 하드웨어 구성 (확정)
| 역할 | 모델 | 수량 | 통신 |
| --- | --- | --- | --- |
| 레이저 거리 센서 | OSM41-KL30CB6/485 | 4대 | RS485 멀티드롭 (Conventional 프로토콜) |
| 디지털 입력 32접점 | FBEI-3200N-TS (NPN) | 1대 | EtherNet/IP |
| 디지털 출력 32접점 | FBEI-0032N-TS (NPN) | 1대 | EtherNet/IP |

## 완료된 작업

### 코드 구조 (2026-05-27)
- [x] `OP05_NEW/` 폴더 생성, Op05 전체 복사
- [x] vbproj 재명명: `OP05_NEW.vbproj`, ProjectGuid `{74A82FCE-A87F-46B4-8224-905B308B29E3}`, RootNamespace `RS4_OP05_NEW`, AssemblyName `RS4_OP05_NEW`
- [x] `RS4.sln` 에 OP05_NEW 항목 + ProjectConfigurationPlatforms 추가 (기존 Op05 보존)

### NI DAQ 제거
- [x] `FrmMain.vb` 에서 `myDaqTask/Reader/Callback`, `InitializeDaqTask`, `DaqStart/End`, `DaqAnalogInCallback`, `DataLaser1~4`, `SumLaser1~4`, `Dev3/ai0~ai3` 채널 전부 제거
- [x] `DaqTask2.vb`, `DaqTask2.User.vb`, `DaqTask2.mxb` 파일 삭제
- [x] `vbproj` 에서 NI.Common / NI.DAQmx Reference 제거 + Import 제거
- [x] 변환식 `Y(mm) = 36V + 20` 폐기 (OSM41 직접 mm 출력)
- [x] 잔존 검사 0건

### OSM41 RS485 클라이언트
- [x] `Common/OsmLaserClient.vb` 신규 작성
- [x] Conventional 프로토콜 (`0x68...0x16` 프레임, sum check)
- [x] 거리 읽기 (`0x00`), 출력 모드 설정 (`0x83 0x01` Query 모드)
- [x] 4대 멀티드롭 (주소 1~4), 50ms 폴링 주기
- [x] CancellationToken 기반 백그라운드 쓰레드, IDisposable 패턴
- [x] 응답 검증 (프레임 헤더/종료/sum-check 일치, `0xFFFF` 무효 처리)

### FBEI EtherNet/IP 클라이언트
- [x] `Common/FbeiIoClient.vb` 신규 작성, EEIP.NET 1.6.0 사용
- [x] EDS 파일 (`FBEI-0032N-TS-V1.03.EDS`) 다운로드, `docs/` 보관
- [x] EDS Connection Path 디코드: Class 0x04, Config Instance **0x66 (102)**, Output 0x64 (100), Input 0x65 (101)
- [x] NetworkConnectionParameters 비트 인코딩 검증 (EEIP.NET source line 419)
- [x] 32DI / 32DO 카드 처리 분기:
  - 32DI: `O_T_ConnectionType = Null` (path 에서 O_T segment 제거)
  - 32DO: `O_T_ConnectionType = Point_to_Point`, `O_T_Length = 4`
- [x] `T_O_ConnectionType = Point_to_Point` (가정용 스위치 대비 Multicast 회피)
- [x] `RealTimeFormat = Modeless` (Header32Bit 은 fallback)
- [x] RPI 10ms
- [x] 입력 비트 변화 감지 + InputChanged 이벤트, 출력 즉시 전송

### 통합 + 설정
- [x] `FrmMain.vb` 통합: `InitializeElcoDevices()`, `Lasers_Updated`, `Lasers_LogMessage`, `Ios_LogMessage` 핸들러
- [x] 기존 `ValueLsrLeftUpper/RightUpper/LeftLower/RightLower` 변수 OSM41 값으로 대체
- [x] `LabelFrt/Rear` 합산 식 유지
- [x] ExitToolStripMenuItem: `Lasers.Dispose() + Ios.Dispose()` 후 종료
- [x] `config.json` 작성 (COM, baudRate, slaveAddresses, FBEI IP, RPI, logging)
- [x] `lib/EEIP.dll` 배치 (NuGet `EEIP` 1.6.0.26419 추출)

### 빌드 검증
- [x] msbuild Release|AnyCPU → **0 errors**
- [x] 산출물: `bin/RS4_OP05_NEW.exe` + `EEIP.dll` 자동 복사 + `config.json` 자동 복사
- [x] 사전 경고 3건 (BC42104 ×2, BC42024 ×1, 기존 코드의 미사용/null 가능성 — 기능 영향 없음)

### 문서화
- [x] `docs/COMMUNICATION_SPEC.md` — 프로토콜/어셈블리/매핑 사양
- [x] `docs/MIGRATION_PLAN.md` — 마이그레이션 계획 + 검증 항목
- [x] `docs/EDS_DECODE_NOTES.md` — EDS 비트 디코드, EEIP.NET 매핑, ForwardOpen 에러 코드 디버깅 표
- [x] `docs/FBEI-0032N-TS-V1.03.EDS` — 원본 EDS
- [x] `docs/UM_OSM41-485_V1.0.pdf`, `Manual_FB20-Series_V1.2.pdf`, `ELCO_quotation_20260507.pdf` — 원본 매뉴얼/견적
- [x] `docs/UM_OSM41-485_raw.txt`, `Manual_FB20_raw.txt` — 텍스트 추출본
- [x] `README.md` — 빌드 전 준비/EEIP/IP 설정 안내

## 검증 완료 (정적)
- 컴파일 (msbuild 0 errors)
- EEIP.NET API 시그니처 (GitHub source 검증)
- EDS Identity/Assembly/Connection Path 검증
- NCP 비트 인코딩 (EEIP.NET source line 419 확인)
- Trigger and Transport 인코딩 (EEIP.NET source line 459 — Class 1 Cyclic 하드코딩 확인)

## 미검증 (하드웨어 필요)
- [ ] FBEI ForwardOpen 실제 성공
- [ ] OSM41 응답 (115200 baud 멀티드롭 4대 동시)
- [ ] OSM41 KL30CB6 거리 데이터 스케일 (mm vs 0.001mm 가중치)
- [ ] 32DI 입력 비트 변화 감지
- [ ] 32DO 출력 비트 실제 LED 점등
- [ ] T_O 응답이 byte 0 부터 i1~i32 (Modeless 가정) — Header32Bit 이면 4 byte offset 필요
- [ ] 전체 cycle latency (RPI 10ms 유효성)

## 미해결 / 미정 사항
- **FBEI-3200N-TS EDS 미확보** — FBEI-0032N-TS 와 동일 패밀리 가정으로 진행
- **OSM41 KL30CB6 거리 단위** — 매뉴얼은 K2500/K4000 mm 단위 기준. KL30CB6 는 분해능 0.001mm 이지만 d1d2 단위가 0.001mm 가중치인지 mm 그대로인지 실측 후 보정 필요
- **NI DAQ 0~5V → 20~200mm 변환식 대체 매핑** — 기존 캘리브레이션과 OSM41 측정 위치/지오메트리 재조정 필요
- **PLC 도면과 32DI/32DO 핀 매핑** — 어느 입력/출력이 어느 신호인지 PLC 문서 확인 필요

## 다음 단계 (우선순위 순)
1. **(하드웨어 도착 후)** PC → 스위치 → FBEI 2장 결선, IP Setting Tool 로 `192.168.250.10/.11` 고정
2. 첫 실행, ForwardOpen STATUS 확인. 실패 시 `EDS_DECODE_NOTES.md` §8 디버깅 표 따라 조정
   - 가장 흔한 실패: STATUS `0x0136` (RealTimeFormat 불일치) → Modeless ↔ Header32Bit 교체
   - STATUS `0x0120` (RPI out of range) → 5~100ms 범위 조정
3. OSM41 4대 사전 설정: 메뉴 진입 → 주소 1/2/3/4, Query 모드 전환
4. USB-to-RS485 변환기 결선 (분홍=A, 회색=B, 갈색=+24V, 파랑=GND, 검정=미사용)
5. OSM41 첫 응답 받아서 거리 스케일 결정 (캘리퍼 비교)
6. PLC 신호와 32DI/32DO 매핑 확정 후 `FrmMain.vb` 의 IO 사용처 코드에 반영
7. (선택) FBEI-3200N-TS EDS 확보 — ELCO 한국 영업 `sb.park@elcoautomation.co.kr` 요청

## 결정 사항 (DECISIONS.md 로 이전 예정)
- OSM41 프로토콜: **Conventional 사용** (Modbus RTU 도 가능하지만 default 모드라 현장 설정 변경 불필요)
- FBEI 통신 주체: **PC 직접** (PLC 경유 안 함)
- 레이저 결선: **RS485 1포트 멀티드롭 주소 1~4** (4포트 각각이 아님)
- 토폴로지: **Star (이더넷 스위치 경유)** — daisy-chain 은 SPOF, DLR 은 카드 2장이라 오버킬
- IP 대역: `192.168.250.0/24` (매뉴얼 예시값)
- RPI: 10ms (산업 표준 + EEIP.NET 디폴트 안전치)
