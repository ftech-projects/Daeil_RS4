# OP05_NEW 통신 사양 (NI DAQ + 아두이노 → ELCO OSM41 + FBEI)

작성일: 2026-05-27
원본 견적서: `ELCO_quotation_20260507.pdf` (EKQT260507-11)

## 하드웨어 구성

| 역할 | 모델 | 수량 | 통신 |
| --- | --- | --- | --- |
| 레이저 거리 센서 (단거리) | OSM41-KL30CB6/485 | 4대 | RS485 멀티드롭 |
| 디지털 입력 32접점 | FBEI-3200N-TS (NPN) | 1대 | EtherNet/IP |
| 디지털 출력 32접점 | FBEI-0032N-TS (NPN) | 1대 | EtherNet/IP |

- Op05 기존 NI DAQ(Dev3 4ch 1000Hz Laser1~4)는 **전부 제거**
- 아두이노 기반 IO도 **전부 제거**
- 기존 Mitsubishi `ActPlc` 통신은 **유지** (PLC 제어 신호 채널은 그대로)

---

## 1. OSM41-KL30CB6/485 (레이저 거리 센서)

### 시리얼 파라미터
| 항목 | 값 |
| --- | --- |
| Baud rate | **115200 bps** (default) |
| Data bits | 8 |
| Stop bits | 1 |
| Parity | None |
| 주소 범위 | 1 ~ 254 (default = 1, broadcast = 0xFF) |

### 프로토콜 선택
센서 메뉴에서 두 가지 모드 중 선택:
- `Nor` (Conventional, **default**) — ELCO 자체 프레임 (`0x68 ... 0x16`)
- `bus` (ModBus) — 표준 Modbus RTU

본 프로젝트는 **Conventional 프로토콜** 사용 (default 그대로).

### 4대 멀티드롭 구성 시 필수 설정
1. 각 센서 메뉴에서 출력 모드를 **Query 모드**로 변경 (`0x83 01` 명령).
   - default는 60Hz active upload → 버스에 한 대만 가능. **반드시 query 모드 전환**.
2. 각 센서 주소를 **1, 2, 3, 4**로 미리 설정 (`0x80` 명령).

### 프레임 포맷 (Conventional)
```
0x68 [adr] [len] [cmd] [data ...] [cs1] [cs2] 0x16
       1byte 1byte 1byte n bytes    2 bytes      1byte
```
- `len` = cmd부터 cs2까지의 byte 수
- `cs` = adr부터 data까지 byte 합계 (2byte little-endian)
- 모든 멀티바이트 데이터는 **little-endian**

### 명령 목록
| 기능 | cmd | 송신 | 응답 |
| --- | --- | --- | --- |
| 거리 읽기 | `0x00` | `68 [adr] 03 00 [cs1] [cs2] 16` | `68 [adr] 05 00 d1 d2 [cs1] [cs2] 16` |
| 주소 설정 | `0x80` | `68 [adr] 04 80 d1 [cs1] [cs2] 16` | `68 [adr] 04 80 state [cs1] [cs2] 16` |
| 보레이트 설정 | `0x81` | `68 [adr] 04 81 d1 [cs1] [cs2] 16` | `68 [adr] 04 81 state [cs1] [cs2] 16` |
| 출력 모드 | `0x83` | `68 [adr] 04 83 d1 [cs1] [cs2] 16` | `68 [adr] 04 83 state [cs1] [cs2] 16` |

- 거리 응답 `d1 d2` = little-endian 16bit, 단위 **mm**
- 측정 범위 초과 시 `0xFFFF`
- 보레이트 레벨: `0x02=9600, 0x03=19200, 0x04=38400, 0x05=115200`(default)
- 출력 모드: `0x00=continuous`, `0x01=query`
- 주소 설정 state: `0=success, 1=fail`

### 거리 읽기 예시 (주소 1)
- 송신: `68 01 03 00 04 00 16`  (cs = 0x01+0x03+0x00 = 0x0004)
- 응답: `68 01 05 00 0D 13 26 00 16`
  - 거리 = `0x130D` = 4877 → 4877 mm (KL30CB6의 mm→0.001mm 분해능 매핑은 별도 확인 필요)

> **주의**: 매뉴얼 본문은 OSM41-K2500/K4000 (mm 단위 2바이트) 기준. KL30CB6 (range 30mm ±5mm, 분해능 0.001mm)은 응답 데이터가 동일한 2바이트 mm일 가능성도 있고, 0.01mm/0.001mm 가중치 스케일 가능성도 있음. **실제 센서 연결 후 측정값과 실측 거리 비교하여 스케일 결정 필요**.

### 응답 시간
- 응답 주파수 30Hz → 약 33ms/주기 × 4대 = 약 **132ms (이상적)** , 안전마진 포함 200ms 폴링 권장.

---

## 2. FBEI-3200N-TS / FBEI-0032N-TS (EtherNet/IP I/O)

### 공통
- 프로토콜: **EtherNet/IP (CIP)**, IEEE 802.3 표준 Ethernet
- 공장 출하 시 **IP 없음** → ELCO "IP Setting Tool"로 IP 고정 필요
- 본 프로젝트 권장 IP:
  - PC NIC: `192.168.250.100/24`
  - FBEI-3200N-TS (32DI): `192.168.250.10`
  - FBEI-0032N-TS (32DO): `192.168.250.11`
- Class 1 implicit (I/O messaging) 사용

### FBEI-3200N-TS (32DI, NPN)
| 방향 | Assembly Instance | Length |
| --- | --- | --- |
| INPUT (T→O, FBEI→PC) | **101** | **10 bytes** |
| OUTPUT (O→T, PC→FBEI) | 100 | **0 bytes** |

**Input 10 bytes 매핑**
| Byte | 내용 |
| --- | --- |
| 0 | i1~i8 (bit0=i1) |
| 1 | i9~i16 |
| 2 | i17~i24 |
| 3 | i25~i32 |
| 4 | S1~S8 (short circuit status) |
| 5 | S9~S16 |
| 6 | S17~S24 |
| 7 | S25~S32 |
| 8 | bit0 = Power Error |
| 9 | Reserved |

### FBEI-0032N-TS (32DO, NPN)
| 방향 | Assembly Instance | Length |
| --- | --- | --- |
| INPUT (T→O, FBEI→PC) | **101** | **10 bytes** |
| OUTPUT (O→T, PC→FBEI) | **100** | **4 bytes** |

**Output 4 bytes 매핑 (PC→FBEI)**
| Byte | 내용 |
| --- | --- |
| 0 | Q1~Q8 |
| 1 | Q9~Q16 |
| 2 | Q17~Q24 |
| 3 | Q25~Q32 |

**Input 10 bytes 매핑 (진단 데이터)**
| Byte | 내용 |
| --- | --- |
| 0~3 | S1~S32 (short circuit status, 채널별) |
| 4~7 | O1~O32 (overload status) |
| 8 | bit0 = Power Error |
| 9 | Reserved |

### Class 1 Connection 파라미터 (권장)
| 항목 | 값 |
| --- | --- |
| Configuration Assembly | instance 1, size 0 |
| O→T (Output) connection | Point-to-Point, Scheduled |
| T→O (Input) connection | Multicast 또는 Point-to-Point, Scheduled |
| RPI (Requested Packet Interval) | **20 ms** (PC NIC 부하 봐서 조정, 10~50ms) |

### LED 상태 (FBEI 측)
- PW Green: 정상
- BF Red: 버스 구성 오류 / 케이블 문제
- SF Red: 단락/과부하 / 전원 24V±20% 벗어남

### 구현 라이브러리
.NET Framework 4.8에서 EtherNet/IP 마스터를 직접 짜는 것보다 검증된 **EEIP.NET** 라이브러리 사용:
- NuGet: `EEIP` (또는 GitHub `rossmann-engineering/EEIP.NET`)
- License: BSD-3
- Class 1 (`RegisterSession` + `ForwardOpen`) + Class 3 explicit 모두 지원

---

## 3. 기존 NI DAQ → 신규 신호 매핑 (TODO: 사용자 확인 필요)

기존 `FrmMain.vb`에서 NI DAQ로 읽던 4채널 레이저:

| 기존 | 채널 | 신규 (예상) |
| --- | --- | --- |
| Dev3/ai0 Laser1 (0-5V) | 1 | OSM41 address=1 |
| Dev3/ai1 Laser2 (0-5V) | 2 | OSM41 address=2 |
| Dev3/ai2 Laser3 (0-5V) | 3 | OSM41 address=3 |
| Dev3/ai3 Laser4 (0-5V) | 4 | OSM41 address=4 |

> 측정 단위 변화: 0~5V (전압) → mm (거리). FrmMain의 `DaqAnalogInCallback` 측정값 사용처 모두 단위 변환 필요. 기존엔 NI DAQ 전압을 별도 스케일 변환했었는지 코드 확인 후 매핑 결정.

## 참조 파일
- `UM_OSM41-485_V1.0.pdf` — OSM41 RS485 user manual
- `Manual_FB20-Series_V1.2.pdf` — FB20 series I/O manual
- `ELCO_quotation_20260507.pdf` — 견적서
- `UM_OSM41-485_raw.txt`, `Manual_FB20_raw.txt` — 텍스트 추출본 (코드 작성 참조용)
