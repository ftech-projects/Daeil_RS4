# RS4 Modernization Rules

## 목표
RS4 솔루션의 12개 프로젝트에서 다음을 일괄 제거/교체:

1. **모든 NI(NationalInstruments.UI.*) 컨트롤 제거**
   - 일반 폼: NI ScatterPlot/XAxis/YAxis 등 → **단순 제거** (작은 그래프, 부수적)
   - NoiseTest: NI 측정 그래프 → **ZedGraph 마이그레이션** (측정 핵심)
2. **FlexCell.Grid → DataGridView** 변환
3. **Mitsubishi MX Component (AxACTETHERLib.AxActQNUDECPUTCP)** → 디자이너에서 제거 후 코드 동적 생성
4. **NoiseTest 한정**: DaqTaskComponent(디자이너 박힘) → 코드 직접 Task 생성 + 검사 쓰레드 분리

## 참조 프로젝트

- **NEAMEA** (`C:\Users\ryudae33\Desktop\Apps\DSC_MEA_NEA\CONV\PopV1`)
  - NI → ZedGraph 변환 완료된 모델. ClassZedGraph.vb 헬퍼 동일하게 복사 사용.
  - **NI 컨트롤의 변수명과 배치(Location/Size)는 그대로 유지**, 타입만 `ZedGraph.ZedGraphControl()`로 교체.
- **NoiseTestJG** (`C:\Users\ryudae33\Desktop\Apps\DAEIL_JG\NoiseTestJG`)
  - NI DAQ 컴포넌트 제거 + ActPlc 동적 생성 모델.
  - DaqTaskComponent 제거하고 `myTask = New Task()` 직접 생성 + `AnalogMultiChannelReader` 콜백 패턴.
  - ActPlc 동적 생성 패턴 (FrmMain.vb의 `InitializeActPlc()` 참조).

---

## 규칙 1: NI ScatterPlot/XAxis/YAxis 단순 제거 (Op/Plan 폼)

대상: `Op01(계획수량)`, `Op02`, `Op03`, `Op05`, `OpVip`, `PlanCreate`

### Designer.vb에서 제거할 패턴
```vb
' 제거 대상
Me.ScatterPlot1 = New NationalInstruments.UI.ScatterPlot()
Me.XAxis1 = New NationalInstruments.UI.XAxis()
Me.YAxis1 = New NationalInstruments.UI.YAxis()
Me.WaveformGraph1 = New NationalInstruments.UI.WindowsForms.WaveformGraph()
...
Me.WaveformGraph1.Plots.AddRange(...)
Me.Controls.Add(Me.WaveformGraph1)
...
Friend WithEvents WaveformGraph1 As NationalInstruments.UI.WindowsForms.WaveformGraph
Friend WithEvents ScatterPlot1 As NationalInstruments.UI.ScatterPlot
```

### .vb 코드에서 처리
- NI 컨트롤 참조 코드(`ScatterPlot1.PlotXY(...)`, `WaveformGraph1.PlotY(...)` 등)는 **주석 처리**.
- 메서드 호출이 있으면 해당 라인만 주석 처리, 주변 로직은 건드리지 않음.

### .vbproj에서 제거
```xml
<Reference Include="NationalInstruments.UI">
<Reference Include="NationalInstruments.UI.WindowsForms">
<Reference Include="NationalInstruments.Common">
```

### .resx에서 제거
NI 컨트롤 관련 OcxState/이미지 리소스 항목 제거.

---

## 규칙 2: FlexCell.Grid → DataGridView

대상: NI=0/Flex>0인 모든 Designer 파일

### Designer.vb 변환
```vb
' Before
Me.Grid1 = New FlexCell.Grid()
Me.Grid1.AlternatingRowColor = ...
Me.Grid1.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
Me.Grid1.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
...
Friend WithEvents Grid1 As FlexCell.Grid

' After
Me.Grid1 = New System.Windows.Forms.DataGridView()
Me.Grid1.AllowUserToAddRows = False
Me.Grid1.AllowUserToDeleteRows = False
Me.Grid1.ReadOnly = True
Me.Grid1.RowHeadersVisible = False
Me.Grid1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
' Location/Size/Name 등은 기존 값 그대로 유지
...
Friend WithEvents Grid1 As System.Windows.Forms.DataGridView
```

### .vb 코드에서 FlexCell API 변환
| FlexCell | DataGridView |
| --- | --- |
| `.Rows = n` (행 수 설정) | `.RowCount = n` (헤더 행은 0번째라 주의) |
| `.Cols = n` | `.ColumnCount = n` |
| `.Cell(r, c).Text = "..."` | `.Rows(r-1).Cells(c-1).Value = "..."` (FlexCell은 1-base, DGV는 0-base) |
| `.ColumnWidth(c) = w` | `.Columns(c-1).Width = w` |
| `.RowHeight(r) = h` | `.Rows(r).Height = h` |
| `.CellBackColor(r,c) = ...` | `.Rows(r-1).Cells(c-1).Style.BackColor = ...` |
| `.CellFontColor(r,c) = ...` | `.Rows(r-1).Cells(c-1).Style.ForeColor = ...` |
| `.MergeCells = True` | DataGridView는 셀 병합 미지원 → 주석 처리 + TODO 코멘트 |
| 이벤트 `MouseDownRow` | `CellMouseDown` (e.RowIndex 사용) |

### .vbproj에서 제거
```xml
<Reference Include="FlexCell">
```

### .resx에서 제거
FlexCell 관련 OcxState 항목 제거 (있다면).

---

## 규칙 3: Mitsubishi ActPlc 동적 생성

대상: `ActPlc = New AxACTETHERLib.AxActQNUDECPUTCP()`가 있는 모든 폼

### Designer.vb에서 제거할 6곳
1. `Me.ActPlc = New AxACTETHERLib.AxActQNUDECPUTCP()` (선언/할당)
2. `CType(Me.ActPlc, ...).BeginInit()` 호출
3. `'ActPlc` 영역의 속성 설정 블록 (Enabled/Location/Name/OcxState/Size/TabIndex)
4. `Me.Controls.Add(Me.ActPlc)`
5. `CType(Me.ActPlc, ...).EndInit()` 호출
6. `Friend WithEvents ActPlc As AxACTETHERLib.AxActQNUDECPUTCP` (필드)

### .vb (FrmMain)에 추가
```vb
' 클래스 멤버로 동적 선언
Private WithEvents ActPlc As AxACTETHERLib.AxActQNUDECPUTCP

Private Sub InitializeActPlc()
    ActPlc = New AxACTETHERLib.AxActQNUDECPUTCP()
    CType(ActPlc, System.ComponentModel.ISupportInitialize).BeginInit()
    ActPlc.Visible = False
    Me.Controls.Add(ActPlc)
    CType(ActPlc, System.ComponentModel.ISupportInitialize).EndInit()
End Sub
```

### FrmMain_Load에서 호출
```vb
Private Sub FrmMain_Load(...) Handles MyBase.Load
    InitializeActPlc()
    ' 기존 로직...
End Sub
```

### .resx에서 제거
`ActPlc.OcxState` 항목 제거.

### .vbproj는 그대로 유지
`AxACTETHERLib`, `ACTETHERLib` 참조는 코드에서 여전히 사용하므로 **유지**.

---

## 규칙 4: NoiseTest 전용 — DaqTaskComponent 제거 + ZedGraph + 쓰레드 분리

대상: `NoiseTest/` 프로젝트 단독, **Opus 에이전트 전담**

### 4-1. DaqTaskComponent 디자이너 컴포넌트 제거
- `DaqTask.vb`의 `DaqTaskComponent` 클래스 사용처 제거.
- `FrmMain.Designer.vb`에서 `Me.DaqTaskComponent1 = New ...` 및 `components` 컨테이너에 추가하는 코드 제거.
- 이벤트 핸들러 `DaqTaskComponent1_DataReady(...)` Handles 절 제거.

### 4-2. 코드에서 직접 NI DAQmx Task 생성 (NoiseTestJG 패턴)
```vb
Imports NationalInstruments
Imports NationalInstruments.DAQmx

' 클래스 멤버
Private myTask As Task
Private runningTask As Task
Private analogInReader As AnalogMultiChannelReader
Private analogCallback As AsyncCallback
Private acqData As AnalogWaveform(Of Double)()

Private Sub InitializeDaqTask()
    If runningTask IsNot Nothing Then Exit Sub
    Try
        myTask = New Task()
        ' 기존 DaqTask.vb의 Configure() 내용 이식
        myTask.AIChannels.CreateMicrophoneChannel("cDAQ1Mod1/ai0", "SoundPressure",
            47.53, 100, AITerminalConfiguration.Pseudodifferential,
            AIExcitationSource.Internal, 0.002, AISoundPressureUnits.Pascals)
        myTask.AIChannels("SoundPressure").SoundPressureDecibelReference = 0.00002
        myTask.AIChannels.CreateVoltageChannel("cDAQ1Mod1/ai1", "Laser1",
            AITerminalConfiguration.Pseudodifferential, 0, 5, AIVoltageUnits.Volts)
        myTask.AIChannels.CreateVoltageChannel("cDAQ1Mod1/ai2", "Laser2",
            AITerminalConfiguration.Pseudodifferential, 0, 5, AIVoltageUnits.Volts)
        myTask.AIChannels("SoundPressure").Coupling = AICoupling.AC
        myTask.AIChannels("Laser1").Coupling = AICoupling.DC
        myTask.AIChannels("Laser2").Coupling = AICoupling.DC
        myTask.Timing.ConfigureSampleClock("", 25600,
            SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, 2560)
        myTask.Control(TaskAction.Verify)
        runningTask = myTask

        analogInReader = New AnalogMultiChannelReader(myTask.Stream)
        analogInReader.SynchronizeCallbacks = True
        analogCallback = New AsyncCallback(AddressOf AnalogInCallback)
        analogInReader.BeginReadWaveform(2560, analogCallback, myTask)
    Catch ex As DaqException
        AddLog("[DAQ] Init 실패: " & ex.Message)
        runningTask = Nothing
        If myTask IsNot Nothing Then myTask.Dispose()
    End Try
End Sub

Private Sub StopDaqTask()
    Try
        runningTask = Nothing
        If myTask IsNot Nothing Then
            myTask.Stop()
            myTask.Dispose()
            myTask = Nothing
        End If
    Catch ex As Exception
        AddLog("[DAQ] Stop 예외: " & ex.Message)
    End Try
End Sub

Private Sub AnalogInCallback(ByVal ar As IAsyncResult)
    Try
        If runningTask IsNot Nothing AndAlso runningTask Is ar.AsyncState Then
            acqData = analogInReader.EndReadWaveform(ar)
            ' 측정 데이터 처리: 검사 쓰레드(Trd1)에 데이터 큐잉만 하고 빠르게 리턴
            EnqueueAcqData(acqData)
            analogInReader.BeginMemoryOptimizedReadWaveform(2560, analogCallback, myTask, acqData)
        End If
    Catch ex As DaqException
        AddLog("[DAQ] Read 예외: " & ex.Message)
        runningTask = Nothing
        If myTask IsNot Nothing Then myTask.Dispose()
    End Try
End Sub
```

### 4-3. 검사 쓰레드 분리 (핵심)
기존 RS4 NoiseTest는 `DaqTaskComponent1_DataReady` 핸들러 안에서 `Monitor.Enter` → 검사 로직 → `Monitor.Exit`까지 약 1600라인을 콜백 쓰레드에서 처리.
**문제**: DAQ 콜백 쓰레드가 임계 영역에서 너무 오래 묶임.

**해결**: 검사 로직을 `ThreadTask1`(이미 별도 쓰레드로 존재)로 옮김.
- `AnalogInCallback`에서는 데이터를 큐(`ConcurrentQueue(Of AnalogWaveform(Of Double)())`)에 enqueue만 함.
- `ThreadTask1`에서 큐를 dequeue해서 기존 `DaqTaskComponent1_DataReady` 안의 검사 로직 실행.
- 기존 `Monitor.Enter(DaqTaskComponent1)` / `Monitor.Exit(DaqTaskComponent1)`는 검사 상태 lock으로 의미 유지 (`SyncLock` 블록으로 교체).

### 4-4. NI 그래프 → ZedGraph (NEAMEA 패턴)
- `ClassZedGraph.vb`를 NEAMEA에서 복사: `NoiseTest/ClassZedGraph.vb`
- NEAMEA의 `FrmGraph1` 패턴 참조해서 폼별 그래프 변환.
- **변수명/Location/Size 유지**, 타입만 `ZedGraph.ZedGraphControl()`로 교체.
- 코드에서 `WaveformGraph1.PlotY(data)` → `ClassZedGraph.DrawGraph(WaveformGraph1, 0, x, y)` 등으로 호환.
- 초기화는 `ClassZedGraph.InitGraph(WaveformGraph1, "제목", "Y축", yMin, yMax)`.

### 4-5. .vbproj 참조 변경
- `<Reference Include="NationalInstruments.UI*">` 제거 (UI 컨트롤만)
- `<Reference Include="NationalInstruments.DAQmx">` **유지** (DAQ 라이브러리)
- `<Reference Include="NationalInstruments.Common">` **유지**
- `<Reference Include="ZedGraph">` 추가 (HintPath: `..\packages\ZedGraph.5.x.x\lib\net40\ZedGraph.dll` 또는 기존 위치)

---

## 공통 작업 순서 (모든 프로젝트)

1. **Designer.vb 수정** → 컨트롤 선언/속성/Controls.Add 라인 삭제 또는 교체
2. **.resx 수정** → OcxState 등 관련 리소스 삭제
3. **FrmMain.vb 수정** → API 호환 변환 및 ActPlc 동적 생성 코드 추가
4. **.vbproj 수정** → 참조 제거/추가
5. **빌드** → `msbuild <project>.vbproj /p:Configuration=Release /p:Platform=x86`
6. **오류 확인** → 빌드 오류 0건 될 때까지 수정 반복

## 빌드 명령
RS4 솔루션 전체는 .NET Framework 기반 VB.NET. MSBuild 사용:
```bash
# 단일 프로젝트
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" \
  "<프로젝트경로>.vbproj" /p:Configuration=Release /p:Platform="Any CPU" /v:minimal

# 솔루션 전체
MSBuild RS4.sln /p:Configuration=Release /v:minimal
```

## 주의사항
- **변수명 보존**: 기존 NI 컨트롤 변수명(`WaveformGraph1`, `ScatterPlot1` 등)을 가능하면 그대로 유지 (코드 변경 최소화). NoiseTest의 ZedGraph 변환 시 NEAMEA의 srcGraph 패턴 따라 변수명 다듬어도 됨.
- **Location/Size 보존**: 디자이너 배치 그대로.
- **참조 제거는 마지막**: 모든 코드 변환 끝나고 빌드 오류 없을 때만 .vbproj에서 참조 삭제.
- **resx 자동 정리**: VS가 자동으로 정리하지 못하므로 수동으로 OcxState 항목 삭제 필요.
- **NoiseTest는 Opus 전담**: 쓰레드 분리 및 DAQ 재구성이 복잡하므로 단독 에이전트.
