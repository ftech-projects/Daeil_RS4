# Daeil_RS4 작업 기록

## 2026-06-26 — OP05 PE전용·IO UI, ServerManager NULL 안전, 기타 Git 푸시

- **OP05_NEW**: Basic/길이시험 PE 공차 전용, `IoMap.vb`+FrmIo Op01_PE UI, 스캔 시 `PrepareNewScanDisplay`, DPI manifest
- **ServerManager**: `FieldGridValue`로 Table_Part 그리드 NULL 안전, V1.0 어셈블리·.NET 4.5
- **RS4_PE_Play**: `SaveRecord` INSERT 단순화(바코드 UPSERT 제거)
- **RS4.sln**: `Op01_PE(192.168.0.205)` 저장소 경로로 등록

---

## 2026-06-26 14:05 — RS4_PE_Play 프레임 바코드 DB 저장 Git 푸시

- **변경**: `SaveRecord` — `Frame_Barcode` 있으면 `Table_Fram_Inspection` **UPDATE**, 없으면 **INSERT**
- **변경**: `_FrmMain` — 검사 완료 시 `lbBarcode1` 바코드를 DB 저장에 전달 (`대기 중...` 제외)
- **추가**: `PLC/DAIL_PLAY.gxw`, `Doc/RS4_1st_BACK_유격검사WorRK FLOW.xlsx`
- **삭제**: `Tools/Table_Part_backup_20260605_090550.csv` (구 백업)

---

## 2026-06-15 — RS4 Program Files vs Git 소스 비교

- PF: `C:\Program Files (x86)\business\대일공업\RS4`
- Repo: `C:\Users\Administrator\source\repos\ftech-projects\Daeil_RS4`
- **소스(.cs/.vb/.proj 등, .md 제외)**: 공통 **439개 전부 동일** (줄바꿈 정규화 후)
- **차이**: Repo만 `OP05_NEW\OP05_NEW.vbproj` 존재 (PF는 `OP05_NEW(192.168.0.10).vbproj`만 있음, 내용 동일 추정)
- **문서**: 루트 `claude.md`만 수정 시각 상이

---

| 공정 | 프로젝트 | Table_Main 접두어 | Table_Part 목표/사용 플래그 |
|------|----------|-------------------|----------------------------|
| **PE** | `Op01_PE` | `PE_*` | `Target_PE_*`, `Use_PE_*` |
| **Op01** | `Op01(계획수량)` | `Op01_*` | `Target_Op01_*`, `Use_Op01_*` |
| **VIP** | `OpVip` | `OpVip_*` | `Target_OpVip_*`, `Use_OpVip_*` |

- **PE ≠ Op01 ≠ VIP** — 접두어 혼용 금지
- PE 모듈 T/Q(4회) → `Table_Main.PE_MonitorbracketTq1~4`
- PE T/Q 사용 여부 → **`Table_Part.Use_PE_MonitorbracketTq` 단독** (NULL/0 → NA)
- PE 에어툴 목표 → `Table_Part.Target_PE_ToolNum`

---

## 2026-06-11 — OP05_NEW 상위 repo 합치기 (gitlink → 일반 폴더)

### 배경
- `OP05_NEW`가 중첩 `.git` + gitlink(`160000`)로만 상위 `Daeil_RS4`에 등록되어 GitHub에 폴더만 보이고 소스 미포함

### 조치 (`C:\Users\Administrator\source\repos\ftech-projects\Daeil_RS4`)
1. `OP05_NEW\.git` 삭제 (중첩 저장소 해제)
2. `git rm --cached OP05_NEW` → `git add OP05_NEW/` (89파일, 일반 트리로 추적)
3. `.gitmodules` 없음 — submodule 아닌 **단일 mono-repo**로 통합

### 이후
- `git push origin main` 시 GitHub에서 `OP05_NEW` 내부 파일 전체 표시
- 클론 한 번에 전체 소스 수신 (submodule update 불필요)

---

### 사용자 확인
- `TryParseGs1LabelScan` / `TryResolveLabelScan` 등 **현재 수정은 테스트용 임의 구현**
- 정식 바코드(26자 SerialNo 스캔) 투입 시 **제거·복원** 예정

### TEMP 범위 (`FrmMain.vb` — `TEMP_SCAN_BYPASS` 주석 블록)
| 함수 | 테스트 동작 | 정식 투입 시 |
|------|-------------|--------------|
| `TryParseGs1LabelScan` | GS1 P/T 역파싱 | **제거** |
| `TryParseLabelScan` | GS1·평문 혼용 | **제거** |
| `TryLookupMainPartNo` | Main 선택 참고 | Main **필수** 조회로 복원 |
| `TryResolveLabelScan` | Main 없어도 진행 | `TryResolveMainLabelScan` 복원 |

### 정식 스캔 흐름 (추후)
1. 스캐너 → **26자 `SerialNo`만** 수신
2. `Table_Main` 조회 → `PartNo` 확정
3. `LoadPArt` → 공정 진행
4. `OP01_Decision` 검증 여부는 현장 기준 재확인

### 빌드
- 주석만 변경 (재빌드 불필요)

---

## 2026-06-11 18:30 — Op01_PE GS1 스캔 파싱 + Table_Main 실적 선택 ★TEMP

### ⚠️ 임시(테스트) — 정식 라벨 적용 시 제거

### 문제 (로그 2026-06-19 18:22:37)
```
ScanData : [)>06V2812P88310T4330NNB...T260603S1B2A0000001...
[SCAN] Op01 실적 없음 — SerialNo: [)>06... (GS1 원문 전체)
```

### 원인 (OP01_Decision 아님)
- `OP01_Decision`·`OptionType=PE` 검증은 **이미 제거**된 상태
- 실패 원인: **GS1 DataMatrix 원문 전체**를 `SerialNo`로 `Table_Main` 조회 → 당연히 없음
- 사용자 의도「실적 없어도 된다」= Main 조회 **필수 아님**, 바코드에서 품번 추출 후 `LoadPArt`만 하면 됨

### 변경 (`FrmMain.vb`)
| 함수 | 내용 |
|------|------|
| `TryParseGs1LabelScan` | GS1 `P`/`T` 필드 → `88310-T4330NNB` + `20260603000188310-T4330NNB` (OP05 BarcodePrint 역변환) |
| `TryParseLabelScan` | GS1 또는 평문 26자 라벨 |
| `TryLookupMainPartNo` | Main 있으면 PartNo 참고만 (없어도 OK) |
| `TryResolveLabelScan` | 파싱 성공 시 진행, Main 없으면 로그만 |
| `HandleIdlePartScan` | `TryResolveLabelScan` 호출 |

### 스캔 OK 조건 (갱신)
1. GS1(`[)>` / Chr(29)) 또는 평문 26자 시리얼에서 **품번·시리얼 파싱 성공**
2. `Table_Part` 로드 성공 (`LoadPArt`)
3. `Table_Main` 실적·`OP01_Decision` **불필요**

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

---

## 2026-06-11 — Op01_PE 스캔: Table_Main 품번 조회 원복 (이후 GS1 파싱으로 보완)

### 배경
- 임시 모드: 스캔 문자열에서 품번 추출 → `Table_Part` 로드 + `CreatePeSerial` 자동생성
- Op01 라벨 바코드 적용 → **Table_Main** 기준으로 원복 → **GS1 파싱 + Main 선택**으로 재보완 (위 18:30 항목)

### 변경 (`FrmMain.vb`) — 초기 원복
| 항목 | 내용 |
|------|------|
| `TryResolveMainLabelScan` | (폐기) → `TryResolveLabelScan` |
| `HandleIdlePartScan` | Main 품번으로 `LoadPArt` → `Table_Part` 사양 로드 |
| 제거 | `CreatePeSerial` / `EnsurePeMainRow` 호출 (스캔 경로) |

### 스캔 거부 조건 완화 (유지)
- `OP01_Decision` 확인 **제거**
- `LoadPArt` `OptionType=PE` 필수 검증 **제거**

### 빌드
- Release → `Op01_PE\bin\RS4_OP01_PE.exe`

---

## 2026-06-11 — Op01_PE OK 사운드·T/Q 즉시표시·srclbAlarm 정리

### 증상
1. OK 판정 시 띵동 없음 (NG음만 동작)
2. T/Q 값·판정이 4회 끝나야 한꺼번에 보임
3. `srclbAlarm`이 스캔·T/Q 영역을 가림

### 원인
- `srclbAlarm`(1893×214, Y=573)이 wStep 3 동안 **모니터브라켓 T/Q 라벨 위를 덮음**
- 최종 `SavePeWorkToMain` 성공 시 띵동 미호출
- `SoundPlayer` NG/OK wav 전환 시 `Load()` 없이 `Play()`만 호출

### 변경 (`FrmMain.vb`)
| 항목 | 내용 |
|------|------|
| `srclbAlarm` | **비상정지 전용** (`ShowEStopAlarm` / `HideEStopAlarm`) — 그 외 안내는 `WriteTxtMessage`만 |
| T/Q 표시 | 알람 제거 + `ApplyMonitorbracketTqResult` UI 스레드 `BeginInvoke` |
| 사운드 | `PlayOkSound` / `PlayNgSound` (`Load`+`Play`) — T/Q OK·에어툴 OK·**PE 최종 저장 OK** |

### 빌드
- Release → `Op01_PE\bin\RS4_OP01_PE.exe`

---

## 2026-06-11 — Op01_PE 1번 지그 IN:05/06 센서 우회

### 배경
- 1번 클램프 **IN:05**·언클램프 **IN:06** 현장 미동작 → 고정/해제/원위치에서 wStep 고착
- 레거시 PE PLC 분기·OP05_NEW 포팅은 **보류** (PLC 수정 불가, 센서 정상화 후 재개)

### 변경
| 파일 | 내용 |
|------|------|
| `FrmMain.vb` | Load 시 `SetSensorRequired(5/6, False)` — OUT:02/03 구동 후 **3초 타이머**로 진행 |
| `JigClampSequence.vb` | `GetHomePositionFault`·`NeedsProductHome` — `IsSensorRequired` 미적용 핀은 원위치·호밍 판정 스킵 |

### 유지 (필수)
- IN:03/04(1번 핀), IN:09~12(2번 지그), IN:13/14(지그 업·다운), IN:07/08(회전)

### ★ 문제점
- **물리 위치 미확인** — 클램프 미체결·미해제여도 3초 후 다음 단계 진행 가능
- 수리 후: `SetSensorRequired(5, True)` / `SetSensorRequired(6, True)` 또는 `EnableAllMotionSensors()` 단독 호출로 복구

### 빌드
- Release → `Op01_PE\bin\RS4_OP01_PE.exe`

---

## 2026-06-19 13:30 — 듀얼 지그 동시 핀+클램프 시퀀스

### 원인
- `TickClamp`가 **핀전진(IN:03) 완료 후** 클램프(OUT:02) 출력 → 전장 요구(핀·클램프 **동시**)와 불일치 → IN:05 미도달·wStep 2.4 고착
- `ActiveJigStation=1` → **2번 지그(OUT:06~08) 미구동**

### 수정 (`JigClampSequence.vb`)
| 항목 | 내용 |
|------|------|
| 고정 | `GetActiveJigs()` → `{1,2}` — OUT:00+02, 06+08 **동시** ON → IN:03·05·09·11 모두 확인 |
| 해제 | 1·2번 **동시** 언클램프(OUT:03,09) → 핀후진(OUT:01,07) |
| 원위치 Reset | 기존 Jig1→Jig2 **순차** homing 유지 |
| 추후 | `GetActiveJigs()` — IN:07/08 지그회전 또는 전용 DI로 1/2 선택 예정 |

### 변경 파일
- `JigClampSequence.vb` — `TickClampDual`, `TickReleaseDual`, `GetActiveJigs()`
- `FrmMain.vb` — Start 로그·wStep 2.4/3.9 주석
- `IoMap.vb` — 1·2번 동시 주석

### 기대 로그
```
[IO] Start → 제품 고정 OUT:00,02,06,08 (1·2번 핀+클램프 동시)
[JIG] 1·2번 핀전진+클램프 동시 출력 — OUT:00,02,06,08 → IN:03,05,09,11 대기
[JIG1] 1번 핀전진 도착 — IN:03
[JIG1] 1번 클램프 도착 — IN:05
[JIG2] 2번 핀전진 도착 — IN:09
[JIG2] 2번 클램프 도착 — IN:11
[IO] 제품 고정 완료 — 모니터브라켓 T/Q 시작
```

### 빌드
- Release → `Op01_PE\bin\RS4_OP01_PE.exe`

---

### 수정 내용
| 버그 | 수정 |
|------|------|
| Atlas `Start()` 직후 시리얼(COM3) 차단 | **COM3 항상 오픈** — Atlas 연결·끊김과 무관 |
| TCP만 되고 Open Protocol 세션 전 `연결됨` | **MID0001→0002 확인 후** `SetConnected(True)` |
| `ConnectionChanged` 백그라운드 스레드 → 로그 누락 | **UI 스레드로 마샬링** (`BeginInvoke`) |
| 기동 순서 Atlas→Serial | **SerialOpen(COM3) → InitializeAtlasTools** |
| `Trd1` 시리얼 수신 스레드 중복 기동 | `EnsureSerialToolThread()` 단일화 |

### 변경 파일
- `FrmMain.vb` — 기동 순서, COM3 비상 폴백, Atlas 이벤트 UI 마샬링
- `AtlasEthernetToolClient.vb` — `OpenTcp` / `EstablishOpenProtocolSession` / MID0004 처리

### 현장 배포 후 기대 로그
```
Serial Tool Open Success COM3
[ATLAS T1] 시작 IP=192.168.250.12 ...
[ATLAS T1] 연결됨 — 192.168.250.12:4545
(wStep 3 체결) [ATLAS T1 RX] 0061 ...
```

### 빌드
- Release → `Op01_PE\bin\RS4_OP01_PE.exe`

### 컨트롤러 (현장 확인됨)
- Virtual Station 1 → Open Protocol **On**, port **4545**, Apply

---

### 코드 변경 (`FrmMain.vb`)
- **COM3 시리얼 툴 항상 활성** — Atlas LAN 연결·끊김과 무관하게 `EnsureSerialToolOpen()` 유지
- Atlas `ConnectionChanged`에서 `StopSerialToolIo()` **제거**
- 기동 로그: `Serial Tool Open Success COM3` + (Atlas 연결 시) `시리얼 툴 비상용 활성 — Atlas LAN 병행`
- Release 빌드 → `Op01_PE\bin\RS4_OP01_PE.exe`

### RS4 ↔ Atlas 통신 방식 (현장 설정 대조)
| RS4 코드 | Atlas 측 요구 |
|----------|----------------|
| TCP **4545** | **Open Protocol** (ToolsTalk/ToolsNet 아님) |
| MID 1 세션 + MID 60 구독 + 0061 수신 | Factory Ethernet 포트, Job 실행 중 체결 |

### Power Focus 컨트롤러 이미지 점검 (2026-06-19 현장)

| 화면 | 설정 | 판정 | 비고 |
|------|------|------|------|
| **Network** | T2 IP `.250.13`, 마스크 `255.255.255.0`, Status **Connected** | **OK** | FrmBasic T2와 일치. **T1 `.250.12` 화면 미제공 — 동일 확인 필요** |
| **Server connections** | ToolsTalk **Off**, ToolsNet **Off** | **OK (Open Protocol와 별개)** | RS4는 ToolsTalk/ToolsNet 미사용 |
| **Preferences** | Access via factory port **On**, Torque **Nm** | **OK** | Factory 포트 Open Protocol 접근 허용 |
| **Alarms** | 유지보수/교정 알람 Off | 무관 | 통신과 무관 |
| **Wireless** | WLAN inactive | 무관 | 유선 Ethernet 사용 시 |
| **PIN** | — | 무관 | |

### ★ 현장에서 추가 확인·설정 필요 (이미지에 없음)
1. **T1 컨트롤러** — Network에서 IP `192.168.250.12`, Status Connected 확인
2. **Open Protocol** — Server connections 아래 또는 Communication 메뉴에 **Open Protocol / Ethernet communication** 항목이 있으면 **Enabled**, 포트 **4545** 확인 (ToolsTalk On 불필요)
3. **PC→툴 4545** — 205 PC에서 `Test-NetConnection .250.12/.13 -Port 4545` = True 여부
4. **Job/프로그램** — 컨트롤러 Home에서 Job **Running** 상태에서 체결 시 0061 발생
5. **물리 배선** — Factory Ethernet 포트 ↔ 스위치 ↔ PC(250.x) (Service 포트 `169.254.1.1` 아님)

### 문제점 (확실)
- 이전 exe는 Atlas “연결됨” 판정만으로 **COM3까지 막아** Atlas 0061 미수신 시 **토크 경로 0**이었음 → 이번 수정으로 COM3 비상 경로 복구
- 컨트롤러 **Server connections 전부 Off**는 Open Protocol과 무관하나, **Open Protocol 자체 활성·4545 리슨**은 이미지로 확인 불가 → **현장 추가 메뉴 확인 필수**
- 로그에 `[ATLAS Tn] 연결됨` 없이 체결만 시도하면 **여전히 LAN 경로는 미확인**

---

### 현장 설정 (FrmBasic / Table_BASIC) ↔ 코드
| 항목 | 현장값 | 코드 반영 | 판정 |
|------|--------|-----------|------|
| TOOL MIN/MAX | 5 / 8 N.m | `BasicToolMin`/`BasicToolMax` → `ApplyMonitorbracketTqResult` | **정상** |
| ATLAS T1/T2 IP | .250.12 / .250.13 | `AtlasTool1Ip`/`AtlasTool2Ip` → TCP 4545 | **정상** |
| 시리얼 툴 | COM3 (MDB) | Atlas 미연결 시 폴백 | **수정 후 정상** |

→ **FrmBasic 값 자체는 문제 없음.** 미동작은 **연결·경로·공정단계** 쪽.

### 근본 원인 (코드 버그)
1. **`AtlasToolEnabled=True`를 TCP 연결 전에 설정** — `client.Start()` 직후 시리얼(COM3) 차단. Atlas가 .250.12/.13에 실제 연결 실패해도 **토크 수신 경로가 전부 끊김**.
2. **에어툴 IN:31 차단** — `Not AtlasToolEnabled` 조건으로 wStep 3.4에서 IN:31 펄스 무시. Atlas “시작”만 되어도 에어 스위치 OK 불가.
3. **wStep 게이트** — 모니터브라켓 T/Q는 **wStep=3** (알람 `모니터브라켓 T/Q 체결 4회`)에서만 UI·판정 반영. 클램프(2.4) 중 체결은 로그만.

### 현장·네트워크 (코드 외)
- Atlas IP **192.168.250.12/13** 은 **현장 PC(205) 250.x 대역**에서만 접근 가능 (관리망 154에서는 ping/4545 실패 이력).
- 로그에 `[ATLAS T1] 연결됨` 없으면 → 케이블·스위치·툴 전원·IP 확인.
- 품번 `Use_PE_MonitorbracketTq=0` 이면 UI **NA** (체결 무시).

### 수정 (`FrmMain.vb`)
- `_atlasConnected(2)` — **실제 TCP 연결** 시에만 `AtlasToolEnabled=True`
- Atlas 연결 시 COM 닫음 / 끊기면 `EnsureSerialToolOpen()` 폴백
- IN:31 에어툴 — `Not AtlasToolEnabled` 조건 **제거**
- 기동 로그: `[CFG] 토크 5~8 N.m | Atlas T1=... T2=...`

### 205 현장 확인 순서
1. exe 기동 → `[CFG] 토크 5~8 ...` / `[ATLAS T1] 연결됨` 또는 `Serial Tool Open Success COM3`
2. 품번 스캔 후 wStep **3** + 모니터브라켓 T/Q 4회 알람 상태에서 체결
3. 로그 `[ATLAS T1 RX] 0061` → `모니터브라켓 T/Q n행 = x.xx`
4. 에어툴 품번 → wStep **3.4** 에서 IN:31 또는 Atlas 공구번호

### 빌드
- Release 성공 → `Op01_PE\bin\RS4_OP01_PE.exe`

---

### 원인
1. **Atlas 0061 파싱 오프셋 오류** — 고정 위치(105/138) 사용 → 시리얼과 불일치, 파싱 실패·무시
2. **시리얼 툴 스레드** — `wStep`·라벨 갱신을 백그라운드에서 처리 → 타이밍/스레드 이슈
3. **조용한 무시** — wStep≠3, 슬롯 없음, N/A 품번 시 로그 없이 Exit

### 수정
- `AtlasEthernetToolClient` — `"0061"` 앵커 + 시리얼 동일 오프셋(상태+103, 토크+137)
- `TryApplyMonitorbracketTq` / `TryApplyAirTool` — wStep 3 / 3.4 검증 + **거부 사유 로그**
- 시리얼 0061 → `BeginInvoke` → `ProcessSerialTool0061` (UI 스레드)

### 현장 확인
- 로그 `[ATLAS T1 RX] 0061 DEC=...` 있으나 `화면 미반영` → wStep 확인
- `wStep 3` + 알람 `모니터브라켓 T/Q 체결 (4회)` 상태에서만 T/Q 행 갱신
- 에어툴은 **wStep 3.4** + IN:31 또는 Atlas

---

### 판정 플래그 (`Table_Part`)
| 플래그 | NA 조건 | 스킵 대상 |
|--------|---------|-----------|
| `Use_PE_MonitorbracketTq` | NULL/0 | 모니터브라켓 T/Q 4회 |
| `Target_PE_ToolNum` | NULL/0 | 지그 다운·업 + 에어툴 |

### 시퀀스 (Start = IN:00)
| T/Q | 에어툴 | 흐름 |
|-----|--------|------|
| O | O | 스캔→Start→클램프→T/Q→Start→**지그다운**→에어툴→Start→**지그업**→언클램프→완료 |
| O | X | 스캔→Start→클램프→T/Q→Start→**언클램프**→완료 |
| X | O | 스캔→Start→클램프→Start→**지그다운**→에어툴→Start→**지그업**→언클램프→완료 |
| X | X | 스캔→Start→클램프→Start→**언클램프**→완료 |

### wStep
- `2.3/2.4` 클램프 (OUT:00,02 → IN:03,05)
- `3` 모니터브라켓 T/Q (Atlas/시리얼)
- `3.1` 클램프만+에어툴 — Start 대기(지그다운)
- `3.2` 지그다운 (OUT:10 → IN:13)
- `3.4` 에어툴 (IN:31 / Atlas)
- `3.6` 지그업 (OUT:11 → IN:14)
- `3.7` Start 대기(언클램프)
- `3.9` 해제 (OUT:03,01 → IN:06,04)
- `4` 저장·완료

### I/O 원칙
- **OUT** = 구동 (클램프·지그·핀)
- **IN** = 구동 후 위치 확인 (센서 ON까지 대기)
- `_peStartWait` — JigDown / JigUp / Unclamp Start 대기 상태

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

---

## 2026-06-11 — Op01_PE Module 명칭 제거 → Monitorbracket 통일

### 변경
- PE 소스에서 `Module*` 식별자·UI 컨트롤 **전면 제거** (`srclbSpecModuleTq1~4` 삭제)
- `MonitorbracketTq*` 로 통일: `_usePeMonitorbracketTq`, `IsPeMonitorbracketTqNa()`, `ResetAllMonitorbracketTq()` 등
- **NA 판정:** `Table_Part.Use_PE_MonitorbracketTq` **만** 사용 (`ReadDbUseFlag` → `_usePeMonitorbracketTq`)
  - NULL/0/빈값 → 목표·4행 NA
  - 1 → `5~8 N.m` 목표 + 체결 4회
- `previewNa` 등 부가 조건 제거 — DB 플래그 단일 기준

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

---

## 2026-06-11 — Op01_PE 모니터브라켓 T/Q 라벨 + 목표 NA 버그 수정

### UI
- `모듈 T/Q` → **모니터브라켓 T/Q** (`Label19`, 알람 문구)

### NA 원인 (88310-T4330)
- 서버 `Use_PE_MonitorbracketTq = 1` 인데 화면 목표 **NA** 표시
- **버그:** `FrmMain_Load` 시 `TargetModuleTQ=False` → 목표 NA 설정 후, 스캔·`LoadPArt`로 `True`가 되어도 `UpdateModuleTqHeader()` 미호출
- **수정:** `LoadPArt` 완료 시 + `ApplyPartPreviewTargets`에서 `UpdateModuleTqHeader()` 호출

### NA가 정상인 경우
- `Table_Part.Use_PE_MonitorbracketTq` = NULL / 0 / 빈값 → T/Q 미검사 품번

---

### 배경
- `Use_Op01_*` = **Op01(1공정)** 전용 — PE와 별개
- PE 공정은 `Use_PE_*`, `Target_PE_*` 사용

### 서버 Table_Part 추가
- `Use_PE_MonitorbracketTq` (BIT, NULL) — 모듈(모니터브라켓) T/Q 4회 검사 사용 여부
- `Target_PE_ToolNum` (NCHAR 10) — PE 에어툴 목표

### 코드 (`LoadPArt`)
- `Use_Op01_MotorTq` → `Use_PE_MonitorbracketTq`
- `Target_Op01_ToolNum` → `Target_PE_ToolNum`

### ⚠️ 현장 DB 작업 필요
- PE 품번에 `Use_PE_MonitorbracketTq`, `Target_PE_ToolNum` 값 **수동 입력** (기존 Op01 컬럼값 복사 여부는 품번별 확인)

---

## 2026-06-11 — Op01_PE PE/OpVip 컬럼 분리 수정

### 원인
- PE 공정(`Op01_PE`)인데 VIP용 `OpVip_ModuleTQ*`, `Use_OpVip_ModuleTQ`를 참조·저장하던 **설계 오류**

### 서버 (`192.168.0.222\Ftech_Svr`)
- `Table_Main` **추가:** `PE_MonitorbracketTq1`, `PE_MonitorbracketTq2`, `PE_MonitorbracketTq3`, `PE_MonitorbracketTq4` (NVARCHAR 50)

### 코드 (`FrmMain.vb`)
- `SaveOpVipModuleTqToMain` → `SavePeMonitorbracketTqToMain` (`PE_MonitorbracketTq1~4`)
- `SaveOpVipWorkToMain` → `SavePeWorkToMain` (PE_Date/StartTime/EndTime/Decision + MonitorbracketTq)
- `LoadPArt`: `Use_PE_MonitorbracketTq` (PE 플래그)
- `Op01_PE` 내 `OpVip` 문자열 **0건**

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

---

## 2026-06-11 — Op01_PE 모듈 T/Q 목표값 UI 분리

### UI (`FrmMain.Designer.vb`, `FrmMain.vb`)
- **분리:** `Label19` = "모듈 T/Q"만 표시
- **추가:** `Label24` "목표" + `srclbTargetModuleTq` (y=624)
- T/Q 데이터 4행: y=679/734/789/844
- `UpdateModuleTqHeader`: `Use_PE_MonitorbracketTq` 비활성 시 목표 **"NA"**

---

## 2026-06-11 — Op01_PE 에어툴 1회 체결

### 변경 (`FrmMain.vb`)
- `ApplyAirToolOk` — 에어툴 OK **1회만** 인정 (`srclbDecTool=OK` 이후 무시)
- `TargetToolNum=0`(PE 품번 기본) → **첫 체결** IN:31/Atlas 모두 OK
- `TargetToolNum>0` → 해당 툴번호 1회만 OK
- 화면 목표: `TargetToolNum=0` 이면 **"1회"** 표시
- wStep 3.4 중 시리얼 토크 수신 → NG 대신 **무시** (모듈 T/Q와 분리)

---

## 2026-06-11 — Op01_PE 임시 스캔: Table_Part + 일일 시리얼 자동생성

### 배경
- 바코드 라벨 미적용 → **Table_Main 라벨 검증 비활성(주석 보존)**
- **Table_Part** 품번 로드 + 시리얼 자동 생성

### 임시 스캔 흐름 (`HandleIdlePartScan`)
1. 스캔 → 품번 추출 (26자 라벨 또는 품번 11자 이상)
2. `LoadPArt` → `Table_Part` (OptionType=PE), `srcLbPartNo` = 서버 품번
3. `CreatePeSerial` — `yyyyMMdd` + `0001~` + 품번, **길이=Table_Main.SerialNo(26)**
4. `EnsurePeMainRow` — 없으면 `Table_Main` INSERT (PartNo, SerialNo, PE_Date)
5. Start 대기

### 시리얼 형식 (서버 Main 기준)
- 예: `20260619000188311-T4060NNB` (8+4+14=26)
- 당일 `SerialNo LIKE yyyyMMdd%` MAX 순번 +1, 자정 기준 0001부터

### 복구용 (주석)
- `HandleIdlePartScan` 하단 — `VerifyOp01LabelScan` + Op01 라벨 SerialNo 사용 블록

### 변경 파일
- `FrmMain.vb` — `CreatePeSerial`, `GetTodaySerialMaxSeq`, `GetMainSerialNoLength`, `EnsurePeMainRow`

---

## 2026-06-11 — Op01_PE 모듈 T/Q UI 정렬

### 문제
- 모듈 T/Q 4행 좌측(903~1009) 회색 빈칸 — 행 라벨·데이터 열 미배치

### 수정 (`FrmMain.Designer.vb`)
- `srclbDataModuleTq1~4`: x=903, width=491 (회색+기준+값 열 통합) — Op01 토크 행과 동일 폭
- `srclbSpecModuleTq1~4`: `Visible=False` (기준값은 `Label19`에 `5 ~ 8 N.m` 표시)

---

## 2026-06-11 — Op01_PE 시퀀스 순서 변경 + Table_Main PE 컬럼 저장

### 확정 공정 순서
| 순서 | 동작 |
|------|------|
| 1 | Op01 라벨 **스캔** |
| 2 | 스캔 정보 표시 |
| 3 | **Start** → 제품 **클램프** (wStep 2.3→2.4) |
| 4 | **모듈 바코드 스캔** (wStep 3) — 서버 Part 모듈품번 `0`/빈값 → **N/A** |
| 5 | **모듈 T/Q 4회** 체결 (모듈 스캔 완료 후만 수락) |
| 6 | **Start** → **지그 다운** (3.2→3.4) |
| 7 | **에어툴** 체결 |
| 8 | **Start** → **지그 업** (3.6→3.8) → 해제 (3.9) |
| 9 | **작업 완료** — `Table_Main` UPDATE (wStep 4 → 0) |

### DB (`192.168.0.222\Ftech_Svr` — **현장 DBA 선행 작업 필요**)
```sql
ALTER TABLE TABLE_MAIN ADD PE_ModuleBarcode NVARCHAR(100) NULL;
ALTER TABLE TABLE_MAIN ADD PE_ModuleTQ1 NVARCHAR(20) NULL;
ALTER TABLE TABLE_MAIN ADD PE_ModuleTQ2 NVARCHAR(20) NULL;
ALTER TABLE TABLE_MAIN ADD PE_ModuleTQ3 NVARCHAR(20) NULL;
ALTER TABLE TABLE_MAIN ADD PE_ModuleTQ4 NVARCHAR(20) NULL;
ALTER TABLE TABLE_MAIN ADD PE_Date NVARCHAR(20) NULL;
ALTER TABLE TABLE_MAIN ADD PE_StartTime NVARCHAR(20) NULL;
ALTER TABLE TABLE_MAIN ADD PE_EndTime NVARCHAR(20) NULL;
ALTER TABLE TABLE_MAIN ADD PE_Decision NVARCHAR(10) NULL;
```
- 모듈 스캔 OK/NA 시 즉시 `PE_ModuleBarcode` UPDATE
- T/Q 체결 시 `PE_ModuleTQ1`~`4` 개별 UPDATE
- wStep 4에서 최종 UPDATE (`SerialNo` = Op01 라벨 시리얼)

### 변경 파일
- `FrmMain.vb` — `BeginModuleWorkStep`, `SavePeModuleBarcodeToMain`, `SavePeModuleTqToMain`, `SavePeWorkToMain`, `IsModuleScanDone`, Start 3회 분기, wStep 5 인쇄 제거

### ⚠️ 문제점
- ~~**SQL 컬럼 미생성 시** UPDATE 실패~~ → **2026-06-11 적용 완료** (`192.168.0.222\Ftech_Svr` / `FTECH_SVR`)
- wStep 5 라벨 재인쇄 제거 (Op01에서 이미 인쇄) — PE 전용 라벨 필요 시 별도 요청

### 2026-06-11 보완 — 모듈 N/A 시 T/Q N/A
- `BeginModuleWorkStep`: `IsModuleBarcodeDisabled()` 이면 모듈 T/Q 4행 **NA** + `PE_ModuleTQ1~4` 즉시 `"NA"` 저장
- 기존에는 `TargetModuleTQ=False`일 때만 T/Q NA — **모듈품번 0/빈값 N/A는 T/Q 체결 대기로 잘못 동작** → 수정

---

## 2026-06-19 — Op01_PE FBEI I/O 전용 공정 정리

### 방향
- Op01_PE = **PE 품번만** + **FBEI I/O + 지그 시퀀스** (PLC 없음)
- wStep 2.3 **제품 고정** 유지 (`JigClampSequence.BeginClamp`)

### 변경
- 구 멜섹 PLC 연결 상태머신(`PlcConnectionStep`) 제거 → `UpdateIoConnectionDisplay` (IO OK/NG)
- `ReadPLc`/`UpdatePlcDisplayLabels`/`ApplyPlcWrite` 제거
- wStep 3.4 에어툴: **IN:31 엣지**(`HandleAirToolPulse`) / Atlas만 — `PlcValue(4002)` 폴링 제거
- wStep 5 인쇄: `IsJigAtUp(Ios)` 센서만 (PlcValue 4001 제거)
- wStep 2.3 IO 미연결 시 고정 시작 안 함

### 공정 (I/O)
`스캔(PE)` → Start → **고정** → wStep3 판정 → Start×2 지그다운 → 공구 → Start×3 지그업 → 해제 → 인쇄

---

## 2026-06-19 — Op01_PE PLC 출력 제거 (FBEI I/O만 사용)

### 배경
- Op01_PE는 멜섹 PLC 미사용 — FBEI EtherNet/IP + 지그 시퀀스만
- `WritePlc`(D4050~4056 옵션·Alive) 실출력 없음(`PlcRegToOutputPin=-1`) — 레거시 잔존

### 제거
- wStep 2.3 옵션 전송(LH/RH, STD/FOLD/VIP, D4051~4056)
- Start/Reset/wStep5 `WritePlc(4051)` 초기화
- PC Alive `WritePlc(4050)`
- 구 PLC 알람 `PlcValue(4009)` 처리
- `WritePlc` 메서드

### 유지
- FBEI 입력 동기화(`ReadPLc`/`IoSignalMap`) — Start/센서/에어툴 IN:31→4002
- `JigClampSequence` 지그 I/O

---

## 2026-06-19 — Op01_PE 스캔: OptionType=PE 만 허용

### 변경 (`LoadPArt`, `HandleIdlePartScan`)
- `Table_Part.OptionType` = **PE** (대소문자 무시) 아니면 스캔 거부
- 로그/알람: `[SCAN] PE 사양에 맞지 않음 — OptionType:STD / 품번:88311-T4060NNB` (예)

---

## 2026-06-19 — Op01_PE UI: 모듈 바코드 + 모듈 T/Q 4행 (OpVip 레이아웃)

### 변경
- **Label12** `모터 바코드` → **모듈 바코드**
- **Label19** `모터 T/Q` → **모듈 T/Q** (4행, OpVip 리벳 행 스타일: 기준|측정|판정)
- **프레임 바코드** 섹션(Label26 등) **삭제**
- **에어툴** 행을 y=936~988로 하향 (모듈 T/Q 4행 확보)

### 로직 (`FrmMain.vb`)
- `TargetModuleBarcode` / `TargetModuleTQ` (DB: `Target_Op01_MotorBarcode`, `Use_Op01_MotorTq`)
- Atlas·시리얼 토크 → 빈 슬롯 순서대로 `srclbData/DecModuleTq1~4` 채움
- wStep 3 판정: 모듈 바코드 + 모듈 T/Q 4개 모두 OK/NA
- `SaveDB`: Frame=`NA`, MotorTq=4개 토크 `/` 연결

---

## 2026-06-19 — Op01_PE 2공정: 계획품번 제거, Op01 Table_Main 검증

### 배경
- 1공정 Op01(103)에서 계획·라벨 인쇄 담당
- Op01_PE는 **2번째 라인** — `Table_Plan`/`Table_Etc.SELECT_PART` 조회 불필요

### 변경 (`FrmMain.vb`)
- `HandleIdlePartScan`: `LoadWorkPart`/`SELECT_PART` 비교 **삭제**
- `VerifyOp01LabelScan`: `Table_Main`에서 `SerialNo` 존재 + `PartNo` 일치 + `OP01_Decision=OK`
- 스캔 시리얼 = `srcLbSerial` (Op01 라벨 그대로, `Create_Serial` 제거)
- `LoadWorkPart`, `SavePlan`, `Create_Serial`, wStep 2~2.2(구 계획 로드) **삭제**
- wStep 4 `SavePlan(Table_Plan)` 호출 제거

### 스캔 OK 조건
1. 바코드에서 품번 14자 추출
2. `Table_Main.SerialNo` = 스캔 전체
3. `Table_Main.PartNo` = 추출 품번
4. `Table_Part` 사양 로드

---

## 2026-06-19 08:15 — Op01_PE 스캔 불일치 재분석 (품번 실제 상이)

### 로그
```
ScanData : 20260619000188311-T4060NNB
[SCAN] 불일치 — 스캔:88311-T4060NNB / 계획:88411-T4240NNB
```

### 결론 (코드 버그 아님)
- Trim 수정 **이후** 로그 — 공백 문제 **아님**
- 스캔 추출 `88311-T4060NNB` 정상 (`Mid(13,14)`)
- 계획 `88411-T4240NNB` = SQL `Table_Etc.SELECT_PART` (192.168.0.222)
- **품번 자체가 다름** (88311 ≠ 88411, T4060 ≠ T4240)

### Op01_PE 품번 비교 경로 (전체)
1. `Serial_Scanner_DataReceived` → wStep=0 → `HandleIdlePartScan`
2. `ExtractPartNoFromScan` — 26자 이상이면 13번째부터 14자
3. `LoadWorkPart` — `SELECT * FROM Table_Etc` → `SELECT_PART`, `PlanSeq`
4. `partNo <> planned` → NG, `_partScannedReady=False`
5. Op01_PE 내 **SELECT_PART 쓰기 UI 없음** — 관리 PC/MES에서 SQL 갱신 필요

### 대응
- SQL 확인: `SELECT SELECT_PART, PlanSeq FROM Table_Etc`
- 계획을 `88311-T4060NNB`로 바꾸거나, 해당 품번 라벨 스캔
- 또는 공정 정책 변경(스캔 우선·계획 비교 제거) 시 사용자 지시 필요

---

## 2026-06-19 08:10 — Op01_PE 스캔 불일치 오판 수정 (Trim)

### 현상
```
ScanData : 20260619000188311-T4060NNB      
[SCAN] 불일치 — 스캔:88311-T4060NNB / 계획:88311-T4060NNB
[IO] Start 거부 — 품번 스캔·확인 필요
```
화면·로그상 품번 동일한데 `partNo <> planned` 로 NG.

### 원인
- SQL `Table_Etc.SELECT_PART` 값에 **뒤 공백** 포함 가능 (`LoadWorkPart` Trim 미적용)
- 스캔 원문 끝 공백 (`ScanData` 로그 `...NNB      `)
- VB `String` 비교는 공백까지 일치해야 함 → `88311-T4060NNB` ≠ `88311-T4060NNB      `

### 수정 (`FrmMain.vb`)
- `NormalizePartNo` = `Trim`
- `LoadWorkPart`: `SELECT_PART` Trim
- `ExtractPartNoFromScan` / `HandleIdlePartScan` 비교 전 정규화
- `Serial_Scanner_DataReceived`: `ScanData` Trim

### 현장 확인
- 동일 라벨 재스캔 → `[SCAN] 품번 로드 OK` → Start 허용

---

## 2026-06-19 — Op01_PE 공정 순서 변경: 스캔 → 품번확인 → Start

### 변경 전
- Start(1회) → wStep 2 → SQL `Table_Etc.SELECT_PART` 로드
- 스캔은 wStep 3(바코드 판정)에서만 사용

### 변경 후
1. **wStep 0** — 라벨 스캔 → 품번 추출(14자) → 계획품번 일치 확인 → `LoadPArt`·목표값·이미지 표시
2. 작업자 확인 후 **Start(1회)** → wStep **2.3** (옵션 PLC + 제품 고정)
3. wStep 3 — 모터/프레임 GS1 스캔·토크 (기존)

### 추가
- `_partScannedReady`, `HandleIdlePartScan`, `ExtractPartNoFromScan`, `ApplyPartPreviewTargets`, `InitJudgmentOnly`
- `LoadPArt` → Boolean 반환

### 빌드
- Release → `RS4_OP01_PE.exe`

---

## 2026-06-19 — Op01_PE 비상정지 NO 극성 수정 (기동 오검출만 제거)

### 원인
- 기존 `IoInEStop = Not value` (NC) — 평상시 IN:02 OFF → 항상 비상정지
- 현장: **NO** (안 누름=OFF, 누름=ON)

### 변경
- `IoInEStop = value` (NO) — `Ios_InputChanged` / `ReadPLc`
- 비상정지 기능 **복구**: 누름 시 `HandleEmergencyStop`, Start/Tmr_Work 차단, Reset으로 해제
- NC `Not value` 제거만 — 기능 삭제 아님

### 빌드
- Release → `RS4_OP01_PE.exe`

---

## 2026-06-19 — Op01_PE 소프트웨어 비상정지(NC) 차단 제거 [철회·NO 수정으로 대체]

## 2026-06-12 — Op01_PE 로그박스 수정 (스크롤·중복억제·5줄삭제 버그)

### 원인 (이전)
- `WriteTxtMessage`가 5줄마다 `txtMessage.Text` **전체 초기화** → 지그 로그 소실
- Atlas KeepAlive TX/ACK가 고빈도 로그 → 초기화 후 화면에 KeepAlive만 보임
- `txtMessage.Enabled=False` → 스크롤 불가

### 변경
- **`WriteTxtMessage`**: `AppendText` 누적, 최대 500줄 유지, 하단 자동 스크롤(사용자가 위로 스크롤 시 유지)
- **`txtMessage`**: `ReadOnly`+`ScrollBars.Vertical` (스크롤 가능)
- **중복 억제** (`dedupKey`): FBEI 스캔/출력 예외, Atlas 연결·끊김·통신예외, 반복 대기 메시지 — 동일 키+문구 1회, 재연결 시 키 해제 후 재출력
- **`AtlasEthernetToolClient`**: KeepAlive/ACK/TX MID 로그 제거, 통신 예외 툴별 1회(재연결 시 재출력)

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

---

## 2026-06-12 — Op01_PE I/O 시퀀스 로그 전용화 (센서·지그 알람 제거)

### 변경
- **알람 제거**: `"센서 및 지그 이상 발생"` FAULT/TIMEOUT 처리 삭제 (`FrmMain` `HandleJigIoResult`/`HandleHomingTick`)
- **로그 통일** (`JigClampSequence`): `LogMoveOut` / `LogArrival`
  - 이동: `{동작} 이동 신호 출력 — OUT:xx → IN:xx 대기`
  - 도착: `{동작} 도착 신호 수신 — IN:xx`
- 대상: 지그 업/다운, 핀전진·후진, 클램프·언클램프 (1·2번 지그, 호밍 포함)
- `FAULT`/`MotionFault`/`LastFault` 제거 — 센서 미입력 시 **대기 유지**, 마지막 이동 로그로 정지 위치 파악
- 원위치 Verify 미달: 1회 `"원위치 대기 — …"` 로그 후 대기

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

---

## 2026-06-12 — Op01_PE IN:14 재시도 삭제 + 비상정지 자동 발생 원인 분석

### 분석 — 비상정지 자동 ON (IN:14와 코드 연결 없음)
| 확인 | 내용 |
|------|------|
| 비상정지 트리거 | `Ios_InputChanged` **IN:02(ch3)만** — `IoInEStop = Not value` 후 상승沿 → `HandleEmergencyStop()` |
| IN:14 실패 시 | `JigClampSequence` → `FAULT` + 알람 **"센서 및 지그 이상"** (비상정지 아님) |
| 동시 발생 체감 | 원위치 복귀 중 OUT:11(지그업) 구동 + IN:14 미입력 → 재시도 로그 반복, 별도로 IN:02 NC=OFF면 비상정지 |
| IN:02 상시 OFF | NC 미배선/접점 개방 시 `ReadPLc`가 매 주기 `IoInEStop=True` → `Tmr_Work` 공정 차단 (래치 없어도 정지) |
| IN:14→비상정지 | **소스에 직접 경로 없음** — 전장 노이즈·IN:02 배선·NC 극성 현장 확인 필요 |

### 수정 (요청 범위)
- `JigClampSequence.vb` — 센서 대기 **3회 재시도·OUT 재구동 삭제**
- **5초 타임아웃 FAULT 삭제** — IN 미응답 시 무한 대기(0 반환), `StepRetry`/`AttemptTimeoutTicks` 제거
- IN:14 무응답 시 "무응답" 로그·FAULT 없음 — OUT 유지·센서 ON까지 대기

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

### 미수정 (추후)
- IN:02 NC 극성/디바운스, 비상정지와 FAULT 알람 문구 구분 UI

---

## 2026-06-11 15:00 — Op01_PE FrmIo IN LED 표시 통일 (비상정지 적색 제거)

### 원인
- `SetInLed`가 비상정지(IN:02)에 NC 반전(`Not value`) + **적색 고정** 적용
- 입력이 OFF(0)인 대기 상태에서도 항상 적색으로 보임

### 변경 (`FrmIo.vb`)
- IN 전 핀 **동일 규칙**: OFF=회색, ON=녹색 (Start/Reset/비상정지/에어툴 예외 색상 제거)
- NC 비상정지 **공정 판정**은 `FrmMain` `Ios_InputChanged` 유지 (UI와 분리)

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

---

## 2026-06-11 14:45 — Op01_PE FrmIo IN/OUT UI 스타일 통일 (수정)

### 변경 (`FrmIo.vb`)
- **IN:00~02** 운전 스위치를 **IN:03~31·OUT** 과 동일 스타일로 변경
  - 왼쪽 정렬, 맑은 고딕 **10pt**, 행 높이 **28px**, 간격 **30px**
- `MkIoRowLabel` 공통 헬퍼 — IN/OUT 동일 레이아웃 상수(`IoRowHeight`/`IoRowPitch`)
- ON/OFF 색상은 `SetInLed` 유지 (Start/Reset/E-Stop/센서 구분)

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

---

## 2026-06-11 — Op01_PE 토크/에어툴 갭 분석 + FrmIo 통합 + 시리얼툴 비활성화

### 미수정 — 소스 점검 (토크툴·에어툴)

#### 토크툴 (Atlas LAN) — **대체로 구현됨**
| 항목 | 상태 |
|------|------|
| Atlas Ethernet TCP 4545 | `AtlasEthernetToolClient.vb` |
| wStep 3 토크 판정 | `ControllerOk` + `BasicToolMin~Max`(MDB `Table_BASIC`) → `srclbDecMotorTq` OK/NG |
| 시리얼 툴 | `ThreadTask1`/`Serial_Tool` 코드 **유지**, Atlas ON 시 비활성(아래 수정) |

#### 에어툴 (IN:31) — **갭 있음 (미구현)**
| 사용자 기대 | 현재 코드 | 갭 |
|------------|----------|-----|
| 에어값 초과 시 IN:31 펄스 → **누적 카운트** | `PlcValue(4002)` = IN:31 **0/1 미러만** | 펄스 누적 없음 |
| 품번 **목표 체결 개수** 도달 시 OK | `Target_Op01_ToolNum` = **툴 번호** 비교(Atlas wStep 3.4) | 체결 **개수** 필드·로직 없음 |
| `TmpToolCount`/`Tool1_Count` 카운팅 | **선언만**, 미사용 | 카운터 미연결 |
| `HandleAirToolPulse` | IN:31 상승沿 1회 → **즉시 OK** (`TargetToolNum`을 표시값에 직접 대입) | 1회=완료, N회 체결 미지원 |
| wStep 3.4 폴링 | `PlcValue(4002) = TargetToolNum` | D4002가 0/1이라 목표≥2 불가 |
| Atlas ON + 에어툴 동시 | `Not AtlasToolEnabled` 조건으로 에어 경로 **전부 차단** | 토크=Atlas·공구=에어 동시 운용 시 설계 재검토 필요 |

**★ 문제점**: 에어툴 **체결 횟수 카운팅·목표 개수 OK**는 아직 공정에 반영되지 않음. 205 현장에서 `Target_Op01_ToolNum`이 번호인지 개수인지 DB 정의 확인 필요.

### 수정 진행

1. **`FrmIo.vb`** — 상단 `pnlOp` 운전 스위치 패널 제거, IN:00~02를 IN 목록에 통합(이미지1 동일). 스위치 색상(Start/Reset/E-Stop) `SetInLed` 유지.
2. **`FrmMain.vb`** — 시리얼 툴 **삭제 없이 비활성화**:
   - `InitializeAtlasTools()`를 `SerialOpen()` **앞**으로 이동
   - `AtlasToolEnabled` 시 COM3 미오픈, `tmr_Tool` 미시작, 로그 "시리얼 툴 비활성"
   - `tmr_Tool_Tick` / `ReinitializeAtlasTools`에서 Atlas 전환 시 포트 정리
   - `ThreadTask1` 기존 가드 유지

### 빌드
- Release 성공 → `Op01_PE\bin\RS4_OP01_PE.exe` (기존 `tmp` 경고)

---

## 2026-06-10 12:20 — Op01_PE IN 센서 위치확인 시퀀스 확정 반영

### 전제
- IN 센서 ON = 물리 위치 도달 (센서 정상 가정)
- `EnableAllMotionSensors()` — 우회 없음, OUT 후 IN 확인 필수

### 지그 위치 게이트
| 시점 | 조건 |
|------|------|
| Start→다운 | `IsJigAtUp` (IN:14 ON, IN:13 OFF) |
| 다운 완료→3.4 | `IsJigAtDown` (IN:13 ON, IN:14 OFF) |
| wStep 3.4 작업 | 다운 위치 유지 중에만 공구 판정 |
| Start→업 | `IsJigAtDown` |
| 업 완료→3.8 | `IsJigAtUp` |
| 3.8 해제 | `IsJigAtUp` 재확인 |
| wStep 5 인쇄 | `IsJigAtUp` 또는 PlcValue(4001) |

### I/O 동작
- `TickWaitForPosition` — 목표 IN ON + 반대 IN OFF 확인 (지그·핀전후진)
- 무응답 3회 재시도 → FAULT 알람

### 변경
- `JigClampSequence.vb` — `IsJigAtDown`/`IsJigAtUp`, 반대센서 확인
- `FrmMain.vb` — 단계별 위치 게이트, `EnableAllMotionSensors`

---

## 2026-06-10 12:05 — Op01_PE IN/OUT 핀번호 0-base 통일

### 원칙
- **앱 코드·UI·로그·시퀀스** = 핀번호 **0-base** (`IN:00`, `OUT:00`)
- **FBEI 드라이버만** 내부 채널 1~32 — `IoMap.PinToChannel` / `GetIn` / `SetOut` 경계 변환

### 변경
- `IoMap.vb` — `PinStart/Reset/EStop/AirTool`(0-base), `GetIn`/`SetOut`/`InLabel`/`OutLabel`
- `JigClampSequence.vb` — 모든 IN/OUT 상수·함수 0-base 핀으로 수정
- `IoSignalMap.vb` — `SyncInputPins`, `InputPinToPlcReg` 0-base
- `FrmMain.vb`, `FrmIo.vb` — Pin 기반 처리 (OUT 클릭 Tag=핀번호)

### OUT→IN (0-base 확정)
| OUT | IN | 동작 |
|-----|-----|------|
| OUT:00 | IN:03 | 1번 핀전진 |
| OUT:01 | IN:04 | 1번 핀후진 |
| OUT:02 | IN:05 | 1번 클램프 |
| OUT:03 | IN:06 | 1번 언클램프 |
| OUT:10 | IN:13 | 지그다운 |
| OUT:11 | IN:14 | 지그업 |

---

## 2026-06-10 11:45 — Op01_PE OUT→IN 위치확인 시퀀스 준비

### 전장 원칙 반영
- **IN 센서 ON = 물리 위치 도달** — OUT 구동 후 대응 IN 확인까지 완료해야 다음 단계
- 모든 I/O 동작(고정·해제·지그다운/업·원위치)을 `TickWaitForPosition` 공통 헬퍼로 통일
- IN 무응답 시 **3회 재시도(OUT 재구동)** → 실패 시 `FAULT` + "센서 및 지그 이상 발생" 알람

### OUT→IN 대응표 (`JigClampSequence.vb` 상단 주석)
| OUT | IN | 동작 |
|-----|-----|------|
| OUT:00/06 | IN:04/10 | 핀전진 |
| OUT:01/07 | IN:05/11 | 핀후진 |
| OUT:02/08 | IN:06/12 | 클램프 |
| OUT:03/09 | IN:07/13 | 언클램프 |
| OUT:10 | IN:14 | 지그다운 |
| OUT:11 | IN:15 | 지그업 |

### 센서 고장/미장착 우회 (현장 임시)
- `JigClampSequence.SetSensorRequired(IN채널, False)` — OUT만 구동, 3초 후 진행
- `FrmMain` Form_Load에 우회 예시 주석
- **정비 후 반드시 `True` 복구** — 우회는 임시

### 변경 파일
- `JigClampSequence.vb` — `TickWaitForPosition`, `SetSensorRequired`, 전 동작 IN대기+3회재시도
- `FrmMain.vb` — `HandleJigIoResult` FAULT 분기
- `IoMap.vb` — OUT→IN 주석

### 문제점
- 현장 일부 센서 고장 → 우회 설정 전까지 공정 정지 가능
- 우회 모드는 **실제 위치 미확인** — 안전·품질 리스크, 정비 우선

---

## 2026-06-10 11:10 — Op01_PE 지그 다운 조립 공정 (wStep 3 세분화)

### 확정 흐름 (Start 3회)
| wStep | 동작 |
|-------|------|
| 2.4 | 제품 고정 (핀전진→클램프) |
| 3 | **다운前 판정**: 모터BC + 프레임BC + 토크 → OK 시 Start(2회) 대기 |
| 3.2 | **지그 다운**: OUT:10 → IN:14 |
| 3.4 | **다운後 판정**: 공구(툴번호) → OK 시 Start(3회) 대기 |
| 3.6 | **지그 업**: OUT:11 → IN:15 |
| 3.8 | BeginRelease → 3.9 |
| 3.9 | 제품 해제 (언클램프→핀후진) |
| 4~5 | 저장 → 인쇄 |

### 변경 파일
- `JigClampSequence.vb` — `BeginJigDown`/`BeginJigUp`, `SeqMode.JigDown`/`JigUp`
- `FrmMain.vb` — `_readyForDown`/`_readyForUp`, Start 다단계 분기, wStep 3.2/3.4/3.6/3.8
- Atlas: 토크=wStep3, 공구=wStep3.4 / 에어툴 IN:31=wStep3.4

### 빌드
- Release 성공 → `RS4_OP01_PE.exe`

### 미결
- 지그 다운/업 3회 재시도 미적용 (단일 타임아웃 30초)
- 205 현장 실 I/O 검증 필요

---

## 2026-06-10 10:40 — Op01_PE 원위치 복귀 3회 재시도 + 센서·지그 이상 알람

### 변경 (`JigClampSequence.vb`, `FrmMain.vb`)
- 원위치 복귀(Reset homing)의 **동작별** 센서 대기를 3회 재시도 구조로 변경
  - 대상: ①지그업(IN:15) ②언클램프(IN:07/13) ③핀후진(IN:05/11)
  - 1회당 대기 `AttemptTimeoutTicks = 50`(5초, Tmr_Work 100ms) → 초과 시 출력 재구동 + 재시도
  - `MaxAttempts = 3`(처음 포함) 실패 시 **"센서 및 지그 이상 발생 — {동작} 센서(IN:xx) 무응답"** 알람 + wStep 0 + NG
- `Tick` 반환에 `"FAULT"` 추가, 호밍 중에는 기존 전체 타임아웃(`IoTimeoutTicks=300`) 미적용
- `LastFault` 공개 필드로 알람 문구 전달, `FrmMain.HandleHomingTick`에서 FAULT 분기 처리
- 메인 공정 고정(2.4)·해제(3.9)는 기존 단일 타임아웃 유지 (요청 범위 = 원위치만)

### 빌드
- Release 빌드 성공 → `RS4_OP01_PE.exe` (기존 `tmp` 경고만 잔존)

### 미적용 (필요 시 추후)
- 고정/해제 메인 공정에도 동일 3회 재시도 적용 여부 미확정
- 재시도 시 출력 OFF→ON 펄스가 아닌 **재구동(재-ON)** 방식 (안전상 펄스 미적용)

---

## 2026-06-09 20:00 — Op01_PE 제품고정 시퀀스 + 지그2 예정 항목

### 제품 고정 I/O 시퀀스 (1번 지그, `JigClampSequence.vb`)
| wStep | 동작 |
|-------|------|
| 2.4 | **고정** — 핀전진 ON → 전진센서 → 클램프 ON → 클램프센서 |
| 3 | 작업(스캔·Atlas 토크) — 제품 클램프 유지 |
| 3.9 | **해제** — 언클램프 ON → 언클램프센서 → 핀후진 ON → 후진센서 |
| 4~5 | SQL 저장 → 지그업 센서 대기 → 라벨 인쇄 |

### OUT 배선 (확정)
- **OUT:00~05** = 1번 지그 (핀전·후진, 클램프·언클램프, 지그회전 클램프·언클램프)
- **OUT:06~11** = 2번 지그 (동일 구조 + 지그 다운/업)

### 원위치 interlock (2026-06-09)
- **지그 원위치 = 업** — IN:15(지그업) ON, IN:14(지그다운) OFF 필수
- **Start 전** `IsHomePosition` 미충족 시 진입 불가
- **Reset** — wStep 0.1 순서: **①지그업** → **②언클램프→③핀후진**(1·2번) / 센서 이미 ON이면 해당 단계 생략
- **ON:** IN:05,07,08,11,13,**15** / **OFF:** IN:04,06,09,10,12,**14**

### ★ 추후 수정 예정 (미구현)
1. **2번 지그 선택** — 지그 회전 위치(1번/2번)에 따라 `ActiveJigStation` 1↔2 전환, 해당 OUT:00~05 또는 06~11만 구동
2. **지그 회전** — OUT:04/05(1번) 또는 회전 센서 IN:07/08 연동 시퀀스
3. **지그 업/다운** — OUT:10/11(2번 지그) 시퀀스 삽입 시점 **미확정** (아래 설명 참고)

### 지그 업/다운 시퀀스 검토 메모
현재 wStep 흐름에서 지그 업/다운이 들어갈 **후보 시점**:
- **A. Start 직후 (wStep 2 전)** — 작업 높이로 지그 다운 후 제품 투입
- **B. 고정 전 (wStep 2.4 전)** — 다운 → 핀전진·클램프
- **C. 작업 완료 후 (wStep 3.9 후)** — 해제 후 지그 업 → 배출 위치
- **D. wStep 5** — 현재 **지그 업 센서(IN:14)** 만으로 인쇄 트리거, 출력 미구동

→ 전장/공정 확인 후 A~D 중 선택 필요.

---

## 2026-06-09 19:15 — Op01_PE I/O 핀맵(이미지1)·스위치 정의 반영

### 스위치 (사용자 확정)
| IN | 채널 | 기능 | 동작 |
|----|------|------|------|
| IN:00 | ch1 | **Start** | wStep 0 → 2 (공정 시작) |
| IN:01 | ch2 | **Reset** | wStep 0, 알람 해제 |
| IN:02 | ch3 | **비상정지** | NC 접점(끊김=정지), 리셋 후 재시작 |

### 센서·기타 입력
- IN:03~14 센서 → PlcValue 4004~4015
- IN:14 지그 업 → PlcValue **4001** (wStep5 인쇄 트리거)
- IN:31 에어 툴 → PlcValue 4002 (Atlas 미사용 시 공구 OK 보조)

### 출력 (이미지1)
- OUT:00~11 — IoMap.OutputNames (핀전진~지그업)
- D4057=1 → OUT:11 지그 업 ON

### UI (`FrmIo.vb`)
- 상단 운전 스위치 3개 대형 LED (Start=녹색, Reset=금색, E-Stop=적색)
- IN/OUT `IN:00` / `OUT:00` 형식 표기

---

## 2026-06-09 18:30 — Op01_PE I/O 자동공정·Atlas 연동 수정

### 변경
- **`IoSignalMap.vb` 신규** — FBEI 입력→PlcValue 매핑
  - ch1 스위치1 → D4000(Ready), ch2 스위치2 → D4001(완료), ch3 스위치3 → D4003(Start)
  - `ReadPLc` / `Ios_InputChanged` / `WritePlc` 구현 완료
  - D4057=1 시 출력 ch12(지그 업) ON (전장 잠정)
- **Atlas + 시리얼 이중경로** — `AtlasToolEnabled` 시 COM3 툴 스레드 미시작
- Release 빌드: `Op01_PE\bin\RS4_OP01_PE.exe`

### 토크 한계 5~8 N.m
- **하드코딩 아님** — `Table_BASIC.toolmin` / `toolmax` (MDB) 로드 → `BasicToolMin`/`BasicToolMax`
- 현장 DB 기본값 5~8, 메뉴「기본설정」`FrmBasic`에서 변경·저장 가능
- Atlas 판정: `result.TorqueNm >= BasicToolMin And <= BasicToolMax`

### 벤치 조작 순서 (205)
1. 스위치1 ON → wStep 0→1
2. 스위치3 ON → wStep 1→2 (품번 로드)
3. wStep 3: 바코드 스캔 + Atlas 토크
4. 스위치2 ON → wStep 5→0 (라벨 인쇄)

---

## 2026-06-09 17:05 — Op01_PE 소스·현장 DB·205 벤치 점검

### 대상
- 프로젝트: `Op01_PE` → `RS4_OP01_PE.exe` (205 시험 PC 배포본)
- 현장 DB: `RS4\DB\DB.mdb` (2026-06-05 복사본)
- SQL: `192.168.0.222\Ftech_Svr` / `FTECH_SVR`
- 벤치 PC: `192.168.0.205`

### Op01_PE 아키텍처 요약
| 구분 | 내용 |
|------|------|
| PLC | 멜섹 **제거** → FBEI EtherNet/IP (`192.168.250.10` IN, `.250.11` OUT) |
| 토크툴 | Atlas Ethernet `.250.12`/`.13` TCP 4545 + 구 시리얼(COM3) 잔존 |
| 품번 | SQL `Table_Etc.SELECT_PART` + `PlanSeq` (구 Op01 방식) |
| 로컬 MDB | `{exe}\DB\DB.mdb` — 포트·바코드·기본값·알람 |
| IO UI | 메뉴「IO 제어」`FrmIo.vb` — 수동 IN/OUT 테스트 가능 |
| 핀맵 | `IoMap.vb` (2026-06-03 전장 수기, **잠정**) |
| 의존성 | `lib\EEIP.dll` (빌드 확인 완료) |

### 현장 DB ↔ 소스 호환
| 테이블 | 상태 | 비고 |
|--------|------|------|
| `Table_SerialPort` | OK | Scanner=COM1, Printer=COM2, Tool=COM3 |
| `Table_BASIC` | OK | Unit=N.m, ToolMin=5, ToolMax=8, Atlas IP **빈값** → 코드 기본 `.250.12`/`.13` |
| `Table_Barcode` | OK | 좌표값 존재 |
| `Table_Count` | **0건** | 당일 카운트 그리드만 영향, 공정 차단 아님 |
| `Table_NGInfo` | OK | 구 멜섹 L300~ 알람 문구 (D4009용, IO 미연결 시 미사용) |
| `Table_Etc` | **MDB 없음** | SQL 전용 — `SELECT_PART=88311-T4210GLW`, `PlanSeq=1` 확인 |

### 치명적 문제 (공정 자동 진행 불가)
1. **`ReadPLc()` / `WritePlc()` IO 매핑 미구현 (TODO)**
   - `Ios.GetInput` → `PlcValue(4000~)` 변환 없음 → **항상 0**
   - `wStep`이 `PlcValue(4000)=1`, `PlcValue(4003)=1` 등을 대기 → **영구 wStep=0**
   - `Ios_InputChanged`도 TODO — 이벤트 기반 매핑 없음
2. **OP05_NEW와 대비**: OP05는 `PlcValue(3999+channel)` 동기화 구현됨. Op01_PE는 **와꾸만** 있음.
3. **`config.json` 미사용** — FBEI IP가 `FrmMain.vb` 상수 하드코딩 (`config.json`과 불일치 가능).
4. **연결 상태 오판** — `ReadPLc`가 `iReturnCode=0` 고정 → `PlcConnectionError=OK` 이지만 실제 신호 0.
5. **Atlas + COM3 이중 툴** — Atlas 연결 시 `AtlasToolEnabled=True`로 시리얼 툴 번호 대체하나, COM3 포트 열기 시도는 계속함.

### IO·툴 동작 판정 (154 관리 PC 기준)
| 대상 | ping | 포트 | 판정 |
|------|------|------|------|
| 192.168.0.205 | OK | 7070(AnyDesk)=OK, 445/3389/5985=닫힘 | 원격 파일·RDP 불가, AnyDesk만 가능 |
| 192.168.250.10~13 | **실패** | 44818/4545 실패 | **205 PC 로컬망에서만 접근 가능** (154에서 라우팅 없음) |

→ FBEI/Atlas 실동작 검증은 **205 PC에서** `FrmIo` + 로그 확인 필요.

### 빌드
- `Release` 빌드 성공 → `Op01_PE\bin\RS4_OP01_PE.exe`
- 현장 `DB.mdb` → `Op01_PE\bin\DB\` 복사 완료

### 205 현장 확인 체크리스트 (AnyDesk 7070)
1. `RS4_OP01_PE.exe` 실행 → 로그 `[FBEI] 연결` / `[ATLAS T1]` 메시지
2. 메뉴「IO 제어」→ 입력 스위치·센서 LED 변화
3. 출력 클릭 → 실제 솔레노이드/램프 동작
4. `wStep`이 0에서 안 넘어가면 → **IO↔PlcValue 매핑 미구현**이 원인
5. Atlas 토크 후 `srclbDecMotorTq` OK 여부 (ToolMin~Max 5~8 N.m)

### 권장 수정 (다음 작업)
- OP05_NEW 패턴으로 `ReadPLc`/`Ios_InputChanged`에 `PlcValue` 동기화
- `IoMap` 기준 D4000~D4009 ↔ FBEI 채널 매핑표 전장팀 확정 후 코드 반영
- `WritePlc` → `Ios.SetOutput` 역매핑 (D4050~4057)
- `config.json` 로드로 IP/RPI 통일

---

## 2026-06-05 11:28 — OP05_NEW 갱신 Git 푸시

### 커밋
- **OP05_NEW** (내부): `82e8727` — I/O·레이저·스캔·판정·FrmIo 현장 안정화
- **Daeil_RS4** (상위): OP05_NEW gitlink 갱신 + `RS4.sln` 프로젝트명 `OP05_NEW(192.168.0.10)` + 본 문서

### 원격
- `https://github.com/ftech-projects/Daeil_RS4` — `main` 푸시

### 주요 내용 (OP05_NEW)
- Keyence IL-300, COM ESP + FBEI LAN I/O, Menu I/O 모니터(FrmIo)
- PLC 제거·wStep I/O 재정의, 스캔/COM·품번 조회·PASS/띵동·MX 미설치 가드
- DB.mdb·ACE x86·배포 스크립트·FrmPart

### 문제점
- `OP05_NEW`는 **별도 Git 저장소**(`.gitmodules` 없음) — 클론 시 `git submodule update`로는 내용이 안 채워질 수 있음. 폴더 내 `git pull` 또는 상위에서 gitlink 커밋 해시 확인 필요.
- `temp_seq_sim.py`는 커밋 제외(임시 시뮬 스크립트).

### 작업 경로 (2026-06-05)
- 일상 개발: `C:\Program Files (x86)\business\대일공업\RS4\OP05_NEW`
- Git push: `ftech-projects\Daeil_RS4`

---

## 2026-06-03 — Git 첫 커밋 및 푸시

- **커밋**: `7c8c6b4` — 메시지 `첫 커밋`
- **원격**: `https://github.com/ftech-projects/Daeil_RS4` — `main` 브랜치 푸시 완료 (`origin/main` 추적 설정)
- **추가**: `.gitignore` (Visual Studio `.vs/`, `*.suo`, bin/obj 등) — `git add` 시 `.vs` 파일 잠금(Permission denied) 방지
- **주의**: `OP05_NEW`는 내부에 별도 Git 저장소가 있어 submodule 형태로만 인덱스됨. 클론 시 해당 폴더 내용이 비어 있을 수 있음. 로컬에 `modified content, untracked content` 잔여

---

## 2026-06-24 — ServerManager LoadGridOp02_2 DBNull 크래시 분석

### 증상
- `ServerManager.exe` → OP02_2 그리드 로드(Button1) 시 `InvalidCastException`: DBNull → String 변환 실패
- 스택: `FrmMain.LoadGridOp02_2()` → `Conversions.ToString` (VB `Trim()` 내부)

### 서버 직접 조회 (`192.168.0.222\Ftech_Svr` / `FTECH_SVR`)
- SQL Server 2008 Enterprise — **연결·쿼리 정상** (서버 장애 아님)
- `Table_Part` 전체 136건 중 **50건**이 OP02_2 관련 컬럼 NULL
- 정렬 `ORDER BY LEN(PartNo), PartNo` 기준 **첫 행 `88310-T4330`** 에서 `Use_Op02_MotorTq` NULL → 즉시 크래시
- NULL 다발 컬럼: `Use_Op02_MotorTq`, `Use_Op02_Sab_Tq`, `Use_Op02_Sab_Resist`, `Use_Op02_cSab_Tq`, `Target_Op02_cSab_Barcode`, `Use_Op02_cSab_Resist`, `Target_Op02_MonitorCableBarcode` 등
- 스키마상 전부 `IS_NULLABLE=YES` (NULL 허용)

### 원인 판정
| 구분 | 판정 |
|------|------|
| SQL Server 장애 | **아님** |
| DB 데이터 미설정 | **예** — OP02_2 품번 설정 50건 미입력 |
| 프로그램 결함 | **예** — `LoadGridOp02_2`가 NULL 미처리 (`Trim(Rs.Fields(...).Value)` 직접 호출) |

### 코드 위치
- `ServerManager\FrmMain.vb` — `LoadGridOp02_2()` 291~303행

### 권장 조치
1. **즉시**: `Table_Part` NULL 컬럼에 기본값 입력 (bit→0/1, nchar→`''` 또는 실제 목표값)
2. **근본**: `LoadGridOp02_2`에 `IsDBNull`/`If(..., "")` 방어 코드 추가 (Op01 `LoadPArt` 동일 패턴)

### 코드 수정 (2026-06-24)
- `ServerManager\FrmMain.vb` — `FieldGridValue()` 추가, `LoadGridOp02_2()` NULL → `DBNull.Value` 유지
- 동기화: `C:\Program Files (x86)\business\대일공업\RS4\ServerManager\FrmMain.vb` ← Git repo 동일 복사

### 적용 (2026-06-24)
- `ServerManager\FrmMain.vb` — `FieldGridValue()` 헬퍼 추가: `IsDBNull`이면 `DBNull.Value` 그대로 반환, 문자열은 `Trim`
- `LoadGridOp02_2()` 12개 필드 전부 `FieldGridValue()` 경유로 변경 → NULL 50건도 그리드 조회 가능
