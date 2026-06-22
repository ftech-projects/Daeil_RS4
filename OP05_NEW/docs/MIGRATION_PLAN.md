# OP05_NEW 마이그레이션 계획

원본: `RS4/Op05/` (RS4 sln의 Op05 프로젝트)
신규: `RS4/OP05_NEW/` (이 폴더)

## 작업 범위
1. **NI DAQ 전면 제거** — `InitializeDaqTask`, `DaqAnalogInCallback`, `DaqStart`, `DaqEnd`, `myDaq*` 멤버, `DaqTask2.*`, NationalInstruments 참조/Imports
2. **아두이노 관련 제거** — (FrmPort 등 시리얼 기반 IO 인터페이스가 있다면 제거)
3. **OSM41 RS485 클라이언트 추가** — `OsmLaserClient.vb` (1포트 멀티드롭, 주소 1~4 폴링)
4. **FBEI EtherNet/IP 클라이언트 추가** — `FbeiIoClient.vb` (EEIP.NET 사용, 32DI 1대 + 32DO 1대)
5. **FrmMain 통합** — 기존 `Laser1~4` 변수 참조처 신규 클라이언트 값으로 대체. IO 비트 사용처 신규 IO 카드로 매핑.
6. **vbproj 정리** — NI.Common / NI.DAQmx Reference 제거, EEIP.dll 참조 추가
7. **빌드 검증** — 0 errors

## 파일별 변경
| 파일 | 변경 |
| --- | --- |
| `FrmMain.Designer.vb` | 변경 없음 (이미 NI UI 제거됨) |
| `FrmMain.vb` | NI DAQ 블록 삭제, 신규 클라이언트 초기화/사용 코드 추가 |
| `Op03(192.168.0.122).vbproj` | NI Reference/Import 제거, EEIP 추가, DaqTask2.* `<None>` 항목 제거 |
| `DaqTask2.vb`, `DaqTask2.User.vb`, `DaqTask2.mxb` | **파일 삭제** |
| `OsmLaserClient.vb` | **신규** — OSM41 Conventional 프로토콜 클라이언트 |
| `FbeiIoClient.vb` | **신규** — EEIP.NET 래퍼 |
| `appsettings.json` 또는 `config.json` | **신규** — 시리얼 포트, IP, 폴링 주기 등 |
| `App.config` | EtherNet/IP 관련 설정 (라이브러리 요구사항 따라) |

## 통신 클래스 설계

### `OsmLaserClient.vb`
```vb
Public Class OsmLaserClient
    Implements IDisposable

    Private ReadOnly _port As SerialPort
    Private ReadOnly _addresses() As Byte = {1, 2, 3, 4}
    Private _values(3) As Integer  ' mm 단위, -1 = invalid
    Private _cts As CancellationTokenSource
    Private _pollTask As Task

    Public Sub New(comPort As String, baud As Integer = 115200)
    Public Sub Start()      ' 폴링 쓰레드 시작
    Public Sub StopPolling()
    Public Function GetDistance(slaveIndex As Integer) As Integer  ' 0~3 → 마지막 측정값 (mm)
    Public Event Updated(slaveIndex As Integer, distanceMm As Integer)
End Class
```

폴링 루프:
1. for each address in {1,2,3,4}:
   - 송신: `68 [adr] 03 00 [cs1] [cs2] 16`
   - 응답 9바이트 대기 (timeout 100ms)
   - 검증: start=0x68, end=0x16, sum check 일치
   - `_values(i) = (d2 << 8) | d1`, 0xFFFF은 invalid 처리
   - `Updated` 이벤트 발생
2. CancellationToken 확인, 50ms sleep, 반복

### `FbeiIoClient.vb`
```vb
Public Class FbeiIoClient
    Implements IDisposable

    Private ReadOnly _diClient As Sres.Net.EEIP.EEIPClient   ' 32DI 카드
    Private ReadOnly _doClient As Sres.Net.EEIP.EEIPClient   ' 32DO 카드
    Private _inputBits As New BitArray(32)
    Private _outputBits As New BitArray(32)
    Private _cts As CancellationTokenSource
    Private _scanTask As Task

    Public Sub New(diIp As String, doIp As String)
    Public Sub Connect()    ' 두 모듈 ForwardOpen
    Public Sub Disconnect()
    Public Function GetInput(channel As Integer) As Boolean  ' channel: 1~32
    Public Sub SetOutput(channel As Integer, value As Boolean)
    Public Event InputChanged(channel As Integer, value As Boolean)
End Class
```

스캔 루프 (20ms RPI에 맞춰 50ms 간격):
1. `_diClient.T_O_IOData` 4 byte 읽어서 `_inputBits` 갱신, 변화 감지 시 이벤트 발생
2. `_doClient.O_T_IOData` 에 `_outputBits` 4 byte 기록 (set 명령 발생 시 즉시 + 주기적 reaffirm)

### config.json (신규)
```json
{
  "osm41": {
    "comPort": "COM3",
    "baudRate": 115200,
    "slaveAddresses": [1, 2, 3, 4],
    "pollIntervalMs": 50,
    "responseTimeoutMs": 100
  },
  "fbei": {
    "inputModuleIp": "192.168.250.10",
    "outputModuleIp": "192.168.250.11",
    "rpiMs": 20
  },
  "logging": {
    "path": "./logs",
    "retentionDays": 30,
    "maxFileSizeMb": 10
  }
}
```

## 빌드 명령
```
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" ^
  "Op03(192.168.0.122).vbproj" /p:Configuration=Release /v:minimal
```

## 검증 항목
- [ ] 빌드 0 errors
- [ ] `Op05` 폴더의 NI 관련 코드 0건 잔존
- [ ] OSM41 응답 파싱 단위 테스트 (cs 계산, 0xFFFF 무효 처리)
- [ ] FBEI 비트 매핑 (i1=bit0 of byte0, Q32=bit7 of byte3) 검증
- [ ] 실제 하드웨어 연결 후 거리값 단위(mm vs 0.001mm) 보정

## 미정 사항 (사용자 확인 필요)
1. **OSM41 KL30CB6의 거리 응답 스케일** — 매뉴얼은 K2500/K4000 기준 mm. KL30CB6는 분해능 0.001mm라 데이터가 0.001mm 가중치일 가능성. 실측 후 보정.
2. **기존 NI DAQ 4채널 사용처의 의미** — 4개가 모두 거리값으로 쓰였는지, 일부는 다른 신호였는지 FrmMain.vb의 검사 로직 분석 후 매핑 확정.
3. **기존 IO 포인트 32+32 매핑** — 현 시스템의 어느 입력/출력이 어느 핀번호로 가는지 PLC 도면 확인 필요.
