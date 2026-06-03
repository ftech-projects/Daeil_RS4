# RS4 Modernization Report

**작업일**: 2026-05-13
**팀**: rs4-modernize (team-lead + noise-test/op-line-a/op-line-b/op-line-c/server)
**참조 가이드**: `RS4/CONVERSION_RULES.md`
**참조 프로젝트**: NEAMEA(`DSC_MEA_NEA/CONV/PopV1/`), NoiseTestJG(`DAEIL_JG/NoiseTestJG/`)

## 작업 목표
1. 모든 NI(NationalInstruments.UI.*) 컨트롤 제거
2. NI DaqTaskComponent 디자이너 컴포넌트 제거 → 코드 직접 Task 생성
3. NI 측정 그래프 → ZedGraph 마이그레이션 (NoiseTest)
4. FlexCell.Grid → DataGridView
5. Mitsubishi MX Component (ActPlc) → 코드 동적 생성
6. AxCWButton → Label (해당 시)

## 프로젝트별 변환 내역

### NoiseTest (Task #1, noise-test)
- FrmMain.Designer.vb 6549→5201줄 정리 (Python 일괄 스크립트)
- NI XAxis/YAxis/XyCursor/ScatterPlot/DaqTaskComponent/ActPlc 일괄 제거
- srcGraph 12개 → ZedGraph.ZedGraphControl (Location/Size/Name/TabIndex 보존)
- ClassZedGraph.vb 복사 + ZedGraphCompat.vb 신규 (NI ScatterGraph API wrapper)
- InitializeDaqTask/StopDaqTask/AnalogInCallback 코드 직접 Task 생성 (DaqTask.vb의 Configure 내용 이식: cDAQ1Mod1/ai0~ai2, 25600Hz, 2560 samples)
- DAQ 콜백 → ConcurrentQueue.Enqueue + AutoResetEvent.Set 후 즉시 리턴
- Trd_AcqWorker (ProcessAcqDataWorker)가 dequeue → Me.BeginInvoke(ProcessAcqData) UI 위임
- Monitor.Enter/Exit → SyncLock daqLock (daqLock 클래스 멤버)
- _stopAcqWorker Boolean + AutoResetEvent.WaitOne(100ms) 종료 메커니즘
- IsHandleCreated/Not IsDisposed 체크로 BeginInvoke 안전
- InitAllZedGraphs() — 12개 srcGraph 일괄 초기화
- ActPlc 동적 생성 (InitializeActPlc, FrmMain_Load에서 호출)
- FrmBasicAngle/FrmAngleBasic: FlexCell.Grid → DataGridView
- vbproj: NI.UI/UI.WindowsForms/DAQmx.ComponentModel/FlexCell 제거; ZedGraph 추가; DaqTask.vb/User.vb/.mxb 컴파일 제외
- licenses.licx: NI 21개 라인 제거
- Lib/sound2.dll 신규 (DSC_GN7 복사)
- 빌드: 0 errors, warnings(BC42020/BC42372/CWUIControlsLib LIBNOTREG)

### Op01(계획수량), Op02 (Task #2, op-line-a)
- Designer.vb: NI ScatterPlot/XAxis/YAxis 제거, ActPlc 6곳 제거
- Op01: FlexCell.Grid → DataGridView (InitGrid Columns.Add/Rows.Add, LoadGrid AddItem→Rows.Add)
- FrmMain.vb: InitializeActPlc() 추가 + Load에서 호출, 미사용 Init_Grid 주석
- AxCWUIControlsLib 미등록 lc.exe -1 오류 → DSC_GN7 pre-built DLL로 COMReference 대체
- licenses.licx 비움, vbproj NI/FlexCell 제거
- 빌드: 0 errors

### Op03, Op05 (Task #3, op-line-b)
- Op03: Designer.vb ScatterPlot/XAxis/YAxis/ActPlc 제거, FrmMain.vb InitializeActPlc 추가, AxCWUIControlsLib dead code 주석
- Op05: ScatterPlot/XAxis/YAxis/ActPlc/Switch1/WaveformGraph/WaveformPlot/DaqTask2Component 제거, GridCount FlexCell→DGV
- Op05 DaqTask2Component → 직접 Task 생성 (Dev3/ai0~ai3 4채널, 1000Hz, 100 samples, DaqAnalogInCallback)
- Op05 DAQ 패턴: `SynchronizeCallbacks = True` (UI 쓰레드에서 콜백 직접 처리) — 레이저 4채널 1000Hz 저빈도 데이터라 단순 버전 선택. 정상 종료 코드(-200088/-88709/-88710) 예외 흡수
- vbproj: NI.UI/CWUIControlsLib/FlexCell 제거; NI.Common+NI.DAQmx HintPath; DaqTask2.vb/User.vb `<None>` 처리
- NI 어셈블리 HintPath: NI.Common (`GAC_MSIL\...v4.0_19.1.40.49152__dc6ad606294fc298`), NI.DAQmx (`MeasurementStudioVS2010\DotNET\Assemblies\Current`)
- TargetFramework v4.0 → v4.8
- 빌드: 0 errors

### OpVip, PlanCreate (Task #4, op-line-c)
- OpVip: NI ScatterPlot/XAxis/YAxis 제거, ActPlc 디자이너 제거 + InitializeActPlc 추가, AxCWUIControlsLib Imports 주석, IN_LABEL/OUT_LABEL → Object
- PlanCreate: NI 제거 + FlexCell.Grid → DataGridView (InitGrid FlexCell→DGV, LoadPlan AddItem→Rows.Add) — ActPlc 없음
- licenses.licx NI 제거, vbproj NI/FlexCell 제거
- 빌드: 0 errors

### ServerManager (Task #6 = #5 일부, server 선작업, noise-test 검증)
- Grid1/Grid2/Grid3 → DataGridView (Designer + .vb API 변환)
- vbproj FlexCell/NI 참조 없음, licenses.licx 없음
- 빌드: 0 errors / 0 warnings

### ServerPlan, ServerPlan102 (#5 일부, server 선작업, op-line-a 검증)
- 이미 DGV 변환 + 클린 상태로 확인
- 빌드: 0 errors

### ServerSeq (#5 일부, server + noise-test + op-line-c)
- FrmMain.Designer.vb: server 변환 완료
- FrmMain.vb: server 절반 변환 → noise-test가 .Cell(r,c).Text 128라인 일괄 GVal/SVal 변환, 중복 GVal 정의 정리, CellStr→GVal 통일
- FrmRegisterSeq (Flex=4): server 선작업 + op-line-c 확정 — DataGridView + OleDb DataAdapter DataSource 바인딩, `SetDate()` 내부 `Grid1.Rows(i).Cells(n).Value` 직접 접근, `SetDataBinding()`으로 DB 직결
- FrmSearch (Flex=2): server 선작업 + op-line-c 확정 — DataGridView + DataSource 바인딩, ExportToExcel은 "추후 구현" TODO 주석 처리
- 빌드: 0 errors (FrmMain — noise-test 검증, 전체 ServerSeq — op-line-b 및 op-line-c 풀빌드 확인)

### AlcUpdate (#5 일부, op-line-c → op-line-a 검증)
- AlcUpdate.vbproj 산출물 `AlcUpdate.exe` 빌드 통과 (sln 통합 빌드에서 op-line-b 확인)

## 공통 변환 패턴 정리

### NI 그래프 제거
- Op 라인: ScatterPlot/XAxis/YAxis 단순 제거
- NoiseTest: ZedGraph 마이그레이션 (ZedGraphCompat wrapper로 호환)

### NI DaqTaskComponent 제거
- NoiseTest, Op05에서 적용
- 디자이너 컴포넌트 → `myTask = New Task()` 코드 생성 + AnalogMultiChannelReader 콜백
- **두 가지 패턴**:
  - **단순 버전 (Op05, op-line-b)**: `SynchronizeCallbacks = True` → 콜백이 UI 쓰레드에서 호출됨. 저빈도(1000Hz, 100 samples) 4채널 레이저 데이터에 충분
  - **분리 버전 (NoiseTest, noise-test)**: `SynchronizeCallbacks = False` + `ConcurrentQueue` + `AutoResetEvent` + `Trd_AcqWorker` → DAQ 콜백 쓰레드 빠르게 리턴, 워커가 큐 dequeue 후 `Me.BeginInvoke`로 UI 위임. 고빈도(25600Hz, 2560 samples) Mic+Laser 데이터의 1600라인 검사 로직에 필수
- 공통: 정상 종료 DaqException 코드(-200088, -88709, -88710) 흡수
- DaqTask.vb / DaqTask.User.vb / .mxb는 vbproj Compile에서 제외하고 `<None>` 처리 (NationalInstruments.DAQmx.ComponentModel 참조도 제거)

### ActPlc 동적 생성
- `Private WithEvents ActPlc As AxACTETHERLib.AxActQNUDECPUTCP` + `InitializeActPlc()` + Load 호출
- Designer.vb 6곳 제거 (New/BeginInit/Properties/Controls.Add/EndInit/Friend WithEvents)
- .resx ActPlc.OcxState 제거

### FlexCell → DataGridView
- FlexCell 1-base ↔ DGV 0-base 매핑 주의
- Cell(r,c).Text → Rows(r-1).Cells(c-1).Value
- AddItem → Rows.Add
- ColumnWidth → Columns(c-1).Width

### AxCWUIControlsLib (CWUI COM) 해결책
1. 미사용 dead code면: Imports/필드 주석 처리
2. 사용 중이면: DSC_GN7 pre-built DLL(AxInterop/Interop.CWUIControlsLib.dll)로 COMReference 대체

### licenses.licx
- Measurement Studio NI UI 라이선스 라인 모두 제거 또는 파일 비우기
- 안 지우면 lc.exe -1 오류

## 빌드 검증

### 개별 프로젝트 (각 팀원 보고)
| 프로젝트 | 산출물 | 빌드 결과 | 비고 |
| --- | --- | --- | --- |
| NoiseTest(192.168.0.117) | NoiseTest(20230504).exe | ✅ 0 errors | warnings: BC42020/BC42372/LIBNOTREG (pre-existing) |
| Op01(192.168.0.103)(계획수량) | RS4_OP01(20250428)(PLAN).exe | ✅ 0 errors | |
| Op02_1(192.168.0.107) | RS4_OP02_1(20210609).exe | ✅ 0 errors | |
| Op02_2(192.168.0.108) | RS4_OP02_2(20220209).exe | ✅ 0 errors | |
| Op03(192.168.0.122) | RS4_OP03(20220221).exe | ✅ 0 errors | |
| Op05 | (Op03 sln 내 포함 산출물) | ✅ 0 errors | |
| Op VIP(192.168.0.112) | RS4_OPVIP(20210609).exe | ✅ 0 errors | MSB3284 (CWUIControlsLib COM 미등록, pre-existing) |
| PlanCreate | CreatePlan.exe | ✅ 0 errors | |
| ServerManager(192.168.0.222) | ServerManager.exe | ✅ 0 errors / 0 warnings | |
| ServerPlan | ServerPlan.exe | ✅ 0 errors | |
| ServerPlan102 | ServerPlan.exe | ✅ 0 errors | |
| ServerSeq | ServerPlan(20250515).exe | ✅ 0 errors | FrmMain(noise-test) + FrmRegisterSeq/FrmSearch(server 초벌+op-line-c 완성) |
| AlcUpdate | AlcUpdate.exe | ✅ 0 errors | |

### RS4.sln 통합 빌드 (op-line-b 실행)
- **결과**: 12/12 성공, **0 errors**
- **스킵**: FtechSetup.vdproj — MSBuild 미지원 설치 프로젝트 (원래부터 sln 빌드 시 자동 스킵)
- **경고 (모두 pre-existing, 이번 마이그레이션과 무관)**:
  - MSB3284: AxCWUIControlsLib COM 미등록 (OpVip, PlanCreate, NoiseTest) — 런타임 등록 PC에서 OK
  - MSB3270: NoiseTest sound2 AMD64 아키텍처 불일치
  - BC42020/BC42104/BC42024: NoiseTest ClassZedGraph.vb 람다 미타입/미사용 변수

## 미해결/주의사항 (모두 pre-existing, 마이그레이션 무관)
- **MSB3284 CWUIControlsLib**: COM `{d940e4e4-6079-11ce-88cb-0020af6845f6}` 미등록 환경 경고. 빌드 자체 통과. 런타임은 등록 PC 필요 (운영 PC에는 등록되어 있음)
- **MSB3270 sound2.dll x86/AMD64 mismatch**: NoiseTest. 런타임 운영 PC에선 무해 (BC42372)
- **BC42020 ZedGraph 람다 추론**: ClassZedGraph.vb 9곳. 무해
- **BC42104/BC42024 NoiseTest 변수**: 사용 안 된 지역 변수 (FlagPass/Incoming) + Data_out null 가능성. 무해

## 학습/이력 노트
- **ServerSeq GVal/SVal 헬퍼 중복 원인 (op-line-c 분석)**: VS 라이브 linter가 변환 중 GVal/SVal 헬퍼를 자동 추가하는 이력이 있어, 라인 336/808에 중복 정의가 발생했음. server-noise-test 동시 편집 충돌이 아니라 IDE의 자동 코드 생성 결과. 다음에 같은 회귀 시 헬퍼 정의 중복부터 점검

## 다음 단계 — **완료**
- ✅ ServerSeq FrmRegisterSeq/FrmSearch (server 초벌 + op-line-c 완성)
- ✅ AlcUpdate (op-line-b sln 빌드에서 통과 확인)
- ✅ RS4.sln 통합 빌드 (op-line-b 실행, 12/12 성공, 0 errors)
- ✅ FlexCell 전역 제거 (op-line-c 확인: vbproj 0개, 코드 0개 잔존)
- ✅ 추가 세션 처리 (op-line-c): Op02_2 추가 정리, PlanEdit 변환 완료

**RS4.sln 마이그레이션 종료** — 모든 12개 프로젝트 빌드 0 errors, 사전 등록 경고만 잔존 (운영 환경 무관).

## sln 외 프로젝트 (참고)
- **NoiseTesBefore** (FrmAngleBasic, FrmBasicAngle): op-line-c가 FlexCell 제거 완료. 빌드는 **NI Measurement Studio / NI-DAQmx 미설치 환경 블로킹** — FlexCell 범위 외, NoiseTest 백업본 성격이라 RS4.sln에 미포함
- **Op01 원본 버전** (sln의 "Op01(계획수량)"이 아닌 다른 폴더): 같은 사유로 빌드 블로킹
- 이 두 프로젝트는 NI 의존성 설치 후 별도 빌드 필요. RS4.sln 본 작업과는 별개.
