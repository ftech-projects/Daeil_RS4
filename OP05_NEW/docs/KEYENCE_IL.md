# Keyence IL 시리즈 (OP05_NEW / PopV4 동일)

## 하드웨어

| 항목 | 사양 |
|------|------|
| 센서 헤드 | **IL-300** (기준 거리 300 mm, 간거리 검사) |
| 통신 유닛 | **DL-RS1A** (RS-232C, Keyence) |
| 배선 | RS-232 → PC COM, **9600 8N1** (PopV4 기본) |
| DL-RS1A 스위치 | R/W 스위치 → **R(읽기)** 측 |

## 통신 (PopV4 `FrmMain.vb`와 동일)

| 항목 | 값 |
|------|-----|
| 폴링 명령 | `MS` + `CR` + `LF` |
| 폴링 주기 | 300 ms (`config.json` → `pollIntervalMs`) |
| 응답 | CSV 한 줄, 채널별 거리는 인덱스 **2, 4, 6, 8** (1-based 채널 1~4) |
| 간거리(mm) | **`모델기준거리 - raw`** — IL-300이면 `300 - raw` (= `Value`) |

### 설치각 보정 (`geometryCorrection` in config.json)

| 채널 | 설치 | 합연산에 쓰는 값 |
|------|------|------------------|
| Upper (`LsrLeftUpper`, `LsrRightUpper`) | 수평 대비 **+8°** | `Value × cos(8°)` (+ 선택 scale/offset) |
| Lower (`LsrLeftLower`, `LsrRightLower`) | **수평 0°** | `Value × lowerScale + lowerOffsetMm` (기본 scale=1) |

- `LabelFrt` = TextBoxFrt + 보정된 Upper 좌 + 보정된 Upper 우  
- `LabelRear` = TextBoxRear + 보정된 Lower 좌 + 보정된 Lower 우  
- 길이 시험(`srclbDataLengthTest*`)도 보정된 `ValueLsr*` 사용

### 모델별 기준 거리 (PopV4 `LaserModelConverter`)

| 모델 | 기준(mm) |
|------|----------|
| IL-30 / IL-030 | 30 |
| IL-65 | 65 |
| IL-100 | 100 |
| **IL-300** | **300** |
| IL-600 | 600 |
| IL-2000 | 2000 |

## COM 포트 설정

- **우선:** Access `Table_SerialPort.Laser` (메뉴 → PORT SETTING → LASER)
- **보조:** `config.json`의 `keyenceIl.amplifiers[].comPort` — DB 값이 있으면 **첫 앰프 COM은 DB가 덮어씀**
- PopV4 `Table_SET.Laser1Port`와 동일 개념

## config.json

```json
"keyenceIl": {
  "pollIntervalMs": 300,
  "amplifiers": [
    {
      "comPort": "COM3",
      "baudRate": 9600,
      "model": "IL-300",
      "channelMapping": {
        "1": "LsrLeftUpper",
        "2": "LsrRightUpper",
        "3": "LsrLeftLower",
        "4": "LsrRightLower"
      }
    }
  ]
}
```

앰프 2대(PopV4 `SerialLaser1`/`2` 스타일)는 `amplifiers` 배열에 항목 추가.

## 참고 매뉴얼

- Keyence IL Series Instruction Manual (IL-300)
- DL-RS1A User's Manual — **MS command** (Read output states and data from all sensor amplifiers)
- 현장 검증 프로그램: `PopV4` — `SerialLaser1_DataReceived`, `TmrWork` MS 폴링

## OSM41 대비 변경

| | OSM41 (이전) | Keyence IL-300 (현재) |
|--|-------------|------------------------|
| 프로토콜 | RS485 Conventional 115200 | RS-232 MS/CSV 9600 |
| 클라이언트 | `OsmLaserClient.vb` | `KeyenceIlLaserClient.vb` |
