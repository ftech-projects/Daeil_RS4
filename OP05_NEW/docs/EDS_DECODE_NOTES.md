# EDS 디코드 + EEIP.NET 매핑 노트

원본: `FBEI-0032N-TS-V1.03.EDS` (Elco, 2024-04-08, Revision 1.0)
EEIP.NET: NuGet `EEIP` 1.6.0.26419 (rossmann-engineering)

## 1. Identity (Class 0x01) 확정값
| 필드 | 값 |
| --- | --- |
| Vendor Code | 1232 (ELCO Industry Automation AG) |
| Product Type | 12 (Communications Adapter) |
| Product Code | 37 |
| MajRev / MinRev | 1 / 1 |
| Product Name | `FBEI-0032N-TS` |

## 2. Connection Path (Class 0x06)
EDS path `20 04 24 66 2C 64 2C 65` 디코드:
```
20 04 → Logical Segment, Class = 0x04 (Assembly Object)
24 66 → Logical Segment, Instance = 0x66 (102, Configuration Assembly)
2C 64 → Logical Segment, Connection Point = 0x64 (100, Output Assembly)
2C 65 → Logical Segment, Connection Point = 0x65 (101, Input Assembly)
```

### EEIP.NET 호출 매핑
| EEIP.NET 속성 | 값 | 출처 |
| --- | --- | --- |
| `AssemblyObjectClass` | `0x04` | EDS path segment 1 |
| `ConfigurationAssemblyInstanceID` | **`0x66` (102)** | EDS path segment 2 |
| `O_T_InstanceID` | `0x64` (100) | EDS path segment 3 (Output) |
| `T_O_InstanceID` | `0x65` (101) | EDS path segment 4 (Input) |

> EEIP.NET 기본값은 `ConfigurationAssemblyInstanceID = 0x01` 인데, FBEI는 `0x66` 이라서 **반드시 명시적으로 덮어써야 한다**. 안 그러면 ForwardOpen STATUS = 0x12 (Bad Configuration Path) 또는 0x115 (Invalid Configuration Application Path).

## 3. NetworkConnectionParameters 비트 인코딩
EEIP.NET `EIPClient.cs` line 419 (소스 검증):
```csharp
NetworkConnectionParameters =
    (ConnSize & 0x1FF)
  | (VariableLength << 9)
  | (Priority << 10)
  | (ConnectionType << 13)
  | (RedundantOwner << 15);
```
| Bits | Field | EEIP.NET enum |
| --- | --- | --- |
| [8:0] | ConnectionSize (bytes) | `O_T_Length` / `T_O_Length` |
| [9] | VariableLength | `O_T_VariableLength` / `T_O_VariableLength` |
| [11:10] | Priority | `Low=0, High=1, Scheduled=2, Urgent=3` |
| [14:13] | ConnectionType | `Null=0, Multicast=1, Point_to_Point=2` |
| [15] | RedundantOwner | `O_T_OwnerRedundant` / `T_O_OwnerRedundant` |

> EDS의 상위 16-bit (`0x4464`, `0x4424` 등) 는 EZ-EDS 생성 도구의 메타 정보로, **EEIP.NET 호출과 직접 매칭되지 않는다**. 실제 NCP는 라이브러리가 위 비트 인코딩으로 재구성한다.

## 4. Trigger and Transport
EEIP.NET `EIPClient.cs` line 459:
```csharp
// X------- = Direction (0=Client, 1=Server)
// -XXX---- = ProductionTrigger (0=Cyclic, 1=CoS, 2=Application)
// ----XXXX = TransportClass (0~3)
commonPacketFormat.Data.Add(0x01);  // 하드코딩: Class 1, Cyclic, Client
```
EDS 의 `0x04010002` (Class 2 명시) 와 다르지만, EEIP.NET 은 **항상 Class 1 Cyclic Client** 로 ForwardOpen 한다. ELCO FBEI 펌웨어가 양쪽 다 수용하므로 무방.

## 5. FBEI EDS Connection 3종 vs EEIP.NET 매핑

| Connection | EDS Path 끝 | EEIP.NET 호출 패턴 |
| --- | --- | --- |
| **Connection1 Exclusive Owner** | `2C 64 2C 65` (100/101) | `O_T_ConnectionType=P2P, T_O_ConnectionType=Multicast` (or P2P) |
| **Connection2 Listen Only** | `2C C0 2C 65` (192/101) | `O_T_InstanceID=0xC0, O_T_Length=0, T_O_InstanceID=0x65, T_O_Length=10` |
| **Connection3 Input Only** | `2C C1 2C 65` (193/101) | `O_T_InstanceID=0xC1, O_T_Length=0, T_O_InstanceID=0x65, T_O_Length=10` |

> EEIP.NET 에서 `O_T_ConnectionType = Null` 로 두면 connection path 에서 O_T segment 가 제거된다. FBEI-3200N-TS (32DI 카드, Output 없음) 는 이 방식이 가장 단순. 슬레이브 측이 "Input Only" 명시를 요구하면 `O_T_InstanceID=0xC1` + `O_T_ConnectionType=Point_to_Point` + `O_T_Length=0` 로 시도.

## 6. DLR (Device Level Ring) 지원
EDS 의 `[DLR Class]` Object_Class_Code=0x47, Revision=3 → DLR 슬레이브 노드 자격 있음.
**그러나** 본 프로젝트는 카드 2장 + PC 1대라 star 가 단순/충분. DLR 활용하려면 추가로 산업용 DLR 마스터 스위치/PLC 필요.

## 7. 현재 우리 코드 (`Common/FbeiIoClient.vb`) 의 설정 정리
```vb
AssemblyObjectClass             = &H4
ConfigurationAssemblyInstanceID = &H66  (102)   ← EDS 검증
O_T_InstanceID                  = &H64  (100)
T_O_InstanceID                  = &H65  (101)

' FBEI-3200N-TS (32DI 카드)
T_O_Length              = 10
O_T_Length              = 0
T_O_ConnectionType      = Point_to_Point
T_O_RealTimeFormat      = Modeless
O_T_ConnectionType      = Null            ← path 에서 O_T segment 제거됨
O_T_RealTimeFormat      = Modeless

' FBEI-0032N-TS (32DO 카드)
T_O_Length              = 10
O_T_Length              = 4
T_O_ConnectionType      = Point_to_Point
T_O_RealTimeFormat      = Modeless
O_T_ConnectionType      = Point_to_Point
O_T_RealTimeFormat      = Modeless        ← Header32Bit 은 실제 장비 STATUS 0x103/0x136 보고 fallback

Priority                = Scheduled
VariableLength          = False
OwnerRedundant          = False
RPI                     = 10000 us (10ms)
```

## 8. ForwardOpen 실패 시 디버깅 순서
| STATUS | 의미 | 해결 |
| --- | --- | --- |
| `0x01 0x0103` | Connection in use / Ownership conflict | 다른 스캐너가 점유. 카드 재부팅 또는 30초 timeout 대기 |
| `0x01 0x0107` | Target connection not found | InstanceID 확인 (0x64/0x65/0x66) |
| `0x01 0x0108` | Invalid network connection parameter | NCP 비트 (ConnectionType/Priority/Size) 확인 |
| `0x01 0x0109` | Invalid connection size | `O_T_Length` / `T_O_Length` 가 슬레이브 어셈블리 실제 사이즈와 다름 |
| `0x01 0x0115` | Configuration application path err | `ConfigurationAssemblyInstanceID` 0x66 확인 |
| `0x01 0x0120` | RPI out of range | RPI 5~100ms 사이로 조정 |
| `0x01 0x0136` | Vendor specific (RealTimeFormat 불일치) | `Modeless` ↔ `Header32Bit` 교체 |
| `0x01 0x0203` | Connection timed out | 네트워크 케이블/IP/방화벽 |

## 9. 검증 안 된 부분 (실제 하드웨어 필요)
- ForwardOpen 실 성공 여부
- T_O Modeless 응답이 byte 0 부터 i1~i32 (or Q 진단) 인지 (Header32Bit이면 4 byte offset)
- T_O byte 8 의 power error bit 정확한 위치
- 응답 latency (RPI 10ms 가 실제 유효한지)

## 10. FBEI-3200N-TS EDS 미확보
같은 패밀리 (Vendor 1232) 이므로 Connection 비트 인코딩과 Configuration Instance 는 동일하다고 가정.
정확 검증 필요 시 ELCO 한국 영업 (sb.park@elcoautomation.co.kr) 에 요청.
