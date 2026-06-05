# FBEI(ELCO FB20) EtherNet/IP — 출력(O→T) 안 됨 문제 [Codex 질문서]

## 0. 한 줄 요약
ELCO **FBEI-0032N-TS (32DO)** EtherNet/IP 출력이 안 됨. **입력(32DI)은 정상 동작**.
출력모듈 **BF LED가 빨강(Bus Failure) 유지** — 연결 중에도 안 꺼짐. 보드 Q LED도 안 켜짐.
→ 우리가 보내는 **O→T(producer)를 보드가 유효한 I/O 연결로 안 받아들임**.

---

## ⚡ 업데이트 3 (2026-06-04) — Codex 원격 패치/패킷캡처 결과

### A. EEIP.NET O→T source port 패치 적용
- `EIPClient.cs sendUDP()`에서 기존 `new UdpClient()` 송신은 ephemeral source port 가능성이 있어,
  Class 1 receive socket(`udpClientReceive`)을 재사용하도록 패치.
- 반영 DLL:
  - 로컬 `DAEIL_RS4/lib/EEIP.dll`
  - `Op01_PE/bin/EEIP.dll`
  - `OP05_NEW/bin/EEIP.dll`
  - 원격 `C:\Program Files\ftech\EEIP.dll`
- 원본 백업: `DAEIL_RS4/lib/EEIP.dll.bak_20260604_092314`

### B. pktmon 캡처로 확정된 O→T 실제 패킷
- 캡처 파일: 원격 `C:\fbei_cap.pcap`, 로컬 `/tmp/fbei_cap.pcap`
- ForwardOpen 성공 응답:
  - O→T CID = `13 b7 57 ba`
  - T→O CID = `73 47 ce 06`
- UDP O→T:
  - `192.168.250.1:2222 -> 192.168.250.11:2222`
  - CID = `13 b7 57 ba` (ForwardOpen 응답과 일치)
  - Connected Data length = `0x000A`
  - payload = sequence 2B + run/idle `01 00 00 00` + output data `FF 00 00 00`
- 즉 **source port, CID, RUN bit, data offset, UDP 흐름은 모두 정상**. source port 가설은 반증됨.

### C. 강제 변형 테스트 결과
| 변형 | 결과 |
| --- | --- |
| `Transport Type/Trigger = 0x02` | ForwardOpen 실패, General Status 1 / Additional 284 |
| O→T connection size 광고값 = 4 | ForwardOpen 실패, Additional 295 (`0x127`, Invalid O→T size) |
| O→T connection size 광고값 = 8 | ForwardOpen 실패, Additional 295 (`0x127`, Invalid O→T size) |
| 원래 Header32Bit/size10 + source port 고정 | ForwardOpen OK, UDP 정상 송신 |

### D. 현재 결론
- 보드는 **Header32Bit/size10만 ForwardOpen 수락**한다.
- 그런데 수락 후 정상 RUN/Data O→T 패킷을 받아도 Q LED가 안 켜진다면, EEIP.NET 패킷 구성보다 **장비 설정/펌웨어/EDS-매뉴얼 불일치 또는 별도 configuration assembly 요구** 쪽 가능성이 더 커짐.
- 다음 확정 수단은 정상 PLC(Omron/Sysmac 등) 연결 시 ForwardOpen/O→T 패킷 캡처와 현재 캡처 비교.

### E. Config Assembly explicit 확인
- `GetAttributeSingle(Class 0x04, Instance 0x66, Attribute 3)` 결과:
  - Product: `FBEI-0032N-TS`
  - Product Code: `37`
  - Revision: `1.1`
  - Config Assembly `0x66` data length: **2 bytes**
  - Current data: `00 00`
- `SetAttributeSingle(4,0x66,3, 00 00)` 가능, readback `00 00`.
- `SetAttributeSingle(4,0x66,3, FF FF)` 가능, readback `FF FF`, 이후 `00 00`으로 복구.
- 각 config write 후 `out 192.168.250.11 0 FF 8` 테스트는 ForwardOpen OK/송신 완료. 실제 Q LED 점등 여부는 현장 육안 확인 필요.

---

## ⚡ 업데이트 4 (2026-06-04) — BF 적색 원인 재분류

### A. 웹 GUI 확인
- 보드 `192.168.250.10:80`, `192.168.250.11:80`은 열려 있음.
- `/` 요청은 `Location: /webif/`로 301 redirect.
- 하지만 `/webif/` 및 흔한 하위 경로(`/webif/index.htm`, `/webif/status.htm`, `/webif/config.htm` 등)는 전부 **404 Not Found**.
- 따라서 현재 보드 웹 GUI는 BF 상태 확인 수단으로 사용할 수 없음.

### B. CIP 상태 객체 확인
- `FbeiConfigProbe.exe`에 임의 CIP `get/set` 기능 추가.
- 양쪽 보드 공통 상태:
  - Identity Status attr5, 연결 없음: `34 00` (`0x0034`)
  - Assembly Config `0x66` attr3: `06 00`
  - TCP/IP Status attr1: `01 00 00 00`
  - Ethernet Link Port1: speed `100`, flags `0x0F` (link up)
  - Ethernet Link Port2: speed `0`, flags `0x00` (미연결)
  - DLR topology/status: `00 / 00`
- 즉 링 구성 자체가 BF 적색의 직접 원인이라는 증거는 없음. Port1 단일 링크와 DLR 상태는 정상 범위로 보임.

### C. Exclusive Owner 연결 중 Identity Status 변화
- `FbeiIpAssign.exe omc 192.168.250.11 20` 실행:
  - Config `0x66=06 00`
  - ForwardOpen OK (`T→O=Multicast`)
  - 실행 중 Identity Status attr5: `65 00` (`0x0065`)
  - 종료 후 Identity Status attr5: `34 00` (`0x0034`)
- 결론: 출력보드는 Class1 Exclusive Owner 연결을 내부적으로 **Owned/Run 상태로 인정**한다.
- 따라서 BF가 물리적으로 계속 빨강이면, 현재는 “EtherNet/IP bus connection 자체 불성립”보다 **configuration/SF/출력 적용 조건 문제**로 분류하는 것이 맞다.

### D. BF RED 해결 확정
- `FbeiIpAssign.exe omc 192.168.250.11 600`을 원격에서 지속 실행하자 출력보드 BF LED가 **RED → GREEN**으로 바뀜.
- 이후 Q1~8 ON을 오래 유지하지 않도록 `holdout` 모드를 추가:
  - 명령: `FbeiIpAssign.exe holdout 192.168.250.11 86400`
  - 출력 데이터: `00 00 00 00` 유지
  - Config `0x66`: `00 00`
  - ForwardOpen: Exclusive Owner, O→T Header32Bit/4, T→O Multicast/10
  - 실행 중 Identity Status: `65 00` (`Owned + configured + I/O Run`)
- 원격 실행 상태:
  - `C:\Program Files\ftech\FbeiIpAssign.exe`
  - PID `6744`
  - 시작 시각: 2026-06-04 10:07
  - 유지 시간: 86400초
- 현장 확인:
  - 출력보드 BF LED GREEN 확인됨.
  - 각 Ethernet 포트 LED도 정상 동작 확인됨.
- 최종 결론:
  - BF RED의 직접 원인은 배선/링/필드전원 문제가 아니라 **Class1 scanner connection이 지속 유지되지 않은 상태**였다.
  - 출력보드 BF를 GREEN으로 유지하려면 실제 설비 프로그램이 종료되지 않고 Exclusive Owner 연결을 계속 유지해야 한다.
  - 단발성 `out`/`omc` 테스트는 ForwardClose 후 BF가 다시 RED가 되는 것이 정상이다.

---

## ⚡ 업데이트 2 (2026-06-04) — 클론버그 수정 후에도 실패. 1차정보 전수검증 결과

### A. Codex가 찾은 클론버그 = 진짜였고 수정·검증 완료 (땡큐)
- `EIPClient.cs` O_T_IOData **getter(line 1356)** = `(byte[]) _O_T_IOData.Clone()` → **복사본 반환**.
  **setter(1363-1369)** = `Array.Copy(value, _O_T_IOData, min(len,505))` + 나머지 clear → 내부버퍼에 되씀.
  **송신루프(864)** = `Array.Copy(_O_T_IOData, 0, o_t_IOData, 20+headerOffset, O_T_Length)` → 내부버퍼 송신.
- 즉 기존코드 `O_T_IOData[0]=val`은 **clone에만 쓰고 버려져 내부버퍼 영영 0**. 1.6.0도 master도 동일(둘다 clone).
- **수정**: `FbeiIoClient.vb` FlushOutput(176-191) + `Program.vb`의 모든 출력경로에 `target[..]=출력; client.O_T_IOData = target` (setter writeback) 추가. 리빌드+재배포 완료.
- **결과: 데이터는 송신버퍼에 들어가지만(검증됨) 출력은 여전히 안 됨.** 즉 클론버그는 *필요했지만 불충분*한 수정.

### B. EEIP O→T 송신경로 = 교과서적으로 정확 (소스 직접 읽음, 추측 아님)
Header32Bit + O_T_Length=4 기준 (`out` 모드 = 현재 FbeiIoClient 설정):
- ForwardOpen **수락됨**. `connectionSize = O_T_Length + o_t_headerOffset(6) = 10` (289-291, 418).
- 송신패킷: offset **20 = `01 00 00 00` → run/idle RUN 비트 SET**(852-857, idle 아님). offset **24~27 = 우리 데이터 4byte**(864). 총길이 `4+20+4=28`. CPF data item length(16-17) = `4+4+2 = 10`.
- 목적지 = **192.168.250.11:2222 유니캐스트**(792), RPI **20ms** 주기 송신(872).
- connectionID_O_T = ForwardOpen 응답이 준 타겟할당 CID(526-527, 813-816) — 정상.
→ **프로토콜상 흠 없음. ForwardOpen 성공 + RUN + 데이터 정위치 + 패킷 흐름.**

### C. 실보드 테스트 매트릭스 (모두 클론버그 수정본으로)
| 테스트 | ForwardOpen | Q LED | BF | 비고 |
| --- | --- | --- | --- | --- |
| `out` P2P Header32Bit/4 (O_T[0]=0xFF) | OK | **안켜짐** | red | 데이터 송신버퍼 적용 확인 |
| `omc` **T→O=Multicast** Header32Bit/4 | OK | **안켜짐** | red | EDS의 "Point Multicast" 반영 — 무효 |
| `dodiag` (DO T→O 10byte 진단읽기) | OK | - | red | raw 전부 00, Q1~8 ON해도 변화0 |
→ **P2P든 Multicast든 동일 실패. T→O 연결타입 무관.**

### D. 매뉴얼로 확정한 사실 (Manual_FB20_raw.txt)
- **BF LED red(line 976-980)** = ①Configuration error ②Bus connection error. **입력모듈(.10)도 BF red인데 입력은 정상동작** → 이 보드에서 red BF는 통신불량 단정 지표 아님(양쪽 다 config error 상태로 추정).
- **1-32 I/O 채널 LED(line 987-990)**: `Off=Channel low level`, **`On=Channel high level`** → Q LED는 **로직레벨(명령상태) 표시**(field power/부하 무관). **Q LED 안켜짐 = 보드가 우리 출력을 high로 인식 안 함 = O→T 페이로드 미적용.**
- **어셈블리(line 1383-1412)**: OUTPUT **inst100 = 4byte** 순수 Q1~Q32(run/idle 표기 없음). INPUT **inst101 = 10byte** = 단락S1~32(0-3)/과부하O1~32(4-7)/전원에러(byte8)/예약(9). **DO의 T→O는 순수 진단 — Q상태를 echo 안 함**(∴ dodiag로 출력적용 확인 불가).
- **byte8 전원에러 bit0 = 0** → **출력 field power 24V 정상 연결됨**(미연결이면 1). 단락·과부하도 0.

### E. ★핵심 수수께끼: connectionSize 협상★
실보드 ForwardOpen 스윕 결과 (O_T_Length=4 고정):
- **Modeless/4** → STATUS **0x127 Invalid O→T size** (EEIP 광고 size = 4+**2** = 6)
- **Header32Bit/4** → **수락** (EEIP 광고 size = 4+**6** = 10)
- EEIP는 connectionSize에 시퀀스카운트 +2를 포함(`O_T_Length + o_t_headerOffset`, headerOffset Modeless=2/Header32Bit=6). 매뉴얼상 출력은 순수 4byte인데, 보드는 6은 거부하고 10은 수락 → **보드가 기대하는 O→T size가 무엇인지 불명확**. 이게 "configuration error(BF red)" + 출력 미적용의 근원일 가능성.

### F. 자동 4트랙 분석(EEIP소스/EDS디코드/매뉴얼/웹) 합성 결론
1. (~60%) O_T_RealTimeFormat=Header32Bit인데 보드는 헤더없는 순수4byte 기대 → 데이터정렬/size 불일치 → BF red + 미적용. (단 Modeless/4는 0x127로 거부된 모순 존재)
2. (~20%) ForwardOpen O→T size가 보드 실제 출력어셈블리(4)와 불일치.
3. (~10%) 송신 소스포트 ephemeral(784, 2222 미바인딩). 단 입력도 같은경로라 단독설명 약함.
4. (~7%) 출력 field power 미인가 — **byte8=0으로 반증됨**.
5. (~3%) Exclusive Owner 점유충돌.

### G. ★Codex에게 묻는 것 (업데이트)★
1. **ForwardOpen 수락 + RUN + 데이터정위치 + 패킷흐름인데 보드가 O→T를 적용 안 하고 Q LED(로직레벨) 미점등.** 이 정확한 패턴의 원인 1순위는? (config assembly? O→T size 협상? run/idle을 보드가 안 원함?)
2. **connectionSize 수수께끼(E절)**: 보드가 Modeless/6 거부·Header32Bit/10 수락. ELCO FBEI-0032N-TS가 실제로 기대하는 O→T connection size와 real-time format은? EEIP의 `+2 시퀀스카운트 포함` 광고가 문제인가? O_T_Length를 몇으로? (Modeless로 정확히 4를 광고하게 하려면 EEIP 수정 필요한가?)
3. BF red가 양쪽모듈 다 = "configuration error"라면, **이 보드 출력 활성화에 config assembly(0x66) 데이터가 필요한가?** EEIP는 config 0x66을 데이터 0으로 보냄. 매뉴얼 "Configuration Data" 표엔 INPUT101/OUTPUT100만 있고 config 102 데이터 정의 없음 — config size=0이 맞나?
4. 패킷캡처로 결정적으로 봐야 할 필드는? (아래 H절 pktmon 가이드 검증 요망)

### H. pktmon(Win10 내장) 패킷캡처 가이드 — 미실행, 다음 수단
```cmd
pktmon filter remove
pktmon filter add -t tcp -p 44818       REM ForwardOpen 협상
pktmon filter add -t udp -p 2222        REM Class1 I/O
pktmon start --capture --pkt-size 0 -f C:\cap.etl
REM (FbeiIpAssign out 192.168.250.11 0 FF 10 실행해 출력 시도, ~10초)
pktmon stop
pktmon etl2pcap C:\cap.etl -o C:\cap.pcap   REM Wireshark 'enip' 필터
```
봐야 할 것: [A] ForwardOpen Req의 O→T network connection params 16bit — Connection Size 하위9bit가 4/8/10 중 뭔지, RT format bit. [B] Reply General Status=0? O→T CID값. [C] UDP2222 패킷 CPF: Sequenced Addr(0x8002) CID가 Reply의 O→T CID와 일치? Connected Data(0x00B1) length, payload 앞 4byte가 `01000000`(run/idle)인지 바로 데이터인지. [D] 보드→PC에 Connection timeout/ForwardClose 찍히나. [E] O→T 송신 소스포트 2222 vs ephemeral.

---

## 1. 하드웨어 / 네트워크
- 타겟 PC: **DESKTOP-OMAE5JC**, Win10 19044. 보드망 NIC = **이더넷 192.168.250.1/24** (Realtek GbE).
- 보드 2대 (ELCO FB20, EtherNet/IP, static IP 고정 완료):
  - **192.168.250.10 = FBEI-3200N-TS (32DI 입력)**, MAC 8C:19:2D:52:21:E6, ProdCode 35
  - **192.168.250.11 = FBEI-0032N-TS (32DO 출력)**, MAC 8C:19:2D:52:21:EC, ProdCode 37
  - Vendor 1232 (ELCO). 둘 다 static IP 고정됨(CIP 0xF5 attr3=0).
- 보드 LED 현재 상태: **PW=녹색(전원OK), BF=빨강(Bus Fault), SF=점등**.
  - 매뉴얼: 정상 PLC(Omron/Siemens) 연결 시 **BF는 GREEN**. BF Red = Bus Failure.

## 2. 되는 것 / 안 되는 것
| 항목 | 상태 |
| --- | --- |
| BOOTP IP 할당 + static 고정 | ✅ |
| 입력(32DI) ForwardOpen + T→O 실데이터 읽기 | ✅ (라이브, 센서 변화 반영) |
| explicit messaging (Identity Class1, TCP/IP 0xF5) | ✅ |
| **출력(32DO) — Q LED 점등 / 실구동** | ❌ |
| **BF LED (양쪽 모듈 다)** | ❌ 빨강 유지 (연결 중에도) |
| DO의 T→O(진단) 읽기 | raw 전부 00 (전원에러 byte8=0, 단락/과부하 0) |

핵심 모순: **입력 T→O는 계속 받히는데(연결 살아있는 것처럼) BF는 빨강이고 출력 O→T는 안 먹음.**

## 3. 사용한 연결 파라미터 (EDS로 검증)
EDS 경로: `20 04 24 66 2C 64 2C 65` (Config 0x66, O→T 0x64/100, T→O 0x65/101).
- **DI (.10, Input-Only)**: AssemblyClass 0x4, Config 0x66, T_O=0x65 len10 **Modeless P2P**, O_T=**0xC1**(193 Input-Only) len0 **ZeroLength P2P**. → 입력 됨.
- **DO (.11, Exclusive Owner)**: T_O=0x65 len10 **Modeless P2P**, O_T=**0x64**(100) len4 **Header32Bit P2P**. → 출력 안 됨, BF 빨강.
- RPI 20ms. OriginatorUDPPort: 두 클라(입/출) 충돌 회피로 2222/2223 다르게.
- ForwardOpen STATUS: **둘 다 성공(에러 없음)**.

### 실보드 스윕으로 확정된 ForwardOpen 조합 (전부 ForwardOpen은 성공)
- DI O_T: Null→STATUS 0x315(Invalid segment), 0xC1+Heartbeat→0x127, **0xC1+ZeroLength→성공(입력읽힘)**
- DO O_T: Modeless/4→0x127, **Header32Bit/4→성공(but 출력 안 먹음)**

## 4. EDS [Connection Manager] 정의 (FBEI-0032N-TS-V1.03.EDS)
```
Connection1 (Exclusive Owner):
  0x04010002,  $ Trigger and Transport
  0x44640405,  $ "Point Multicast"   ← T→O가 Multicast로 명시됨!
  ,,Assem100,  $ OT
  ,,Assem101,  $ TO
  path "20 04 24 66 2C 64 2C 65"
Connection2 (Listen Only): path "20 04 24 66 2C C0 2C 65"
Connection3 (Input Only):  path "20 04 24 66 2C C1 2C 65"
```
⚠️ **우리는 T→O를 Point_to_Point로 했는데 EDS는 "Point Multicast"** — 이게 BF의 원인일 수 있음(미검증).

## 5. 라이브러리 (EEIP.NET / Sres.Net.EEIP)
- **EEIP.NET 1.6.0 과 master(최신) 둘 다 빌드해서 시도 — 동일하게 실패.** (버전 문제 아님)
- 소스 확인(`/tmp/EEIP.NET/EEIP.NET/EIPClient.cs`):
  - ForwardOpen이 **sendUDP 스레드 시작**(line 563-564) → O→T를 RPI마다 송신(line 789-872).
  - line 871: `udpClientsend.Send(o_t_IOData, O_T_Length+20+headerOffset, endPointsend)` — udpClientsend는 **ephemeral 소스포트**(2222 바인딩 아님).
  - Header32Bit: run/idle 헤더 `o_t_IOData[20]=1`(RUN), 데이터는 그 뒤 offset24. headerOffset=6.
  - **즉 O→T는 실제로 송신됨.** 보드가 안 받아들이는 것.
- 우리 코드: `DAEIL_RS4/Op01_PE/Common/FbeiIoClient.vb` (입력1+출력1), 출력쓰기는 `O_T_IOData[0..3]`.

## 6. 의심 가설 (검증/반증 필요)
1. **T→O를 Multicast로 해야 BF green?** (EDS가 Multicast 명시). EEIP.NET `T_O_ConnectionType=Multicast`로 시도 안 해봄.
2. O→T 소스포트가 ephemeral이라 보드가 매칭 못함? (보통 connection ID로 매칭하지만 확인 필요)
3. RPI/timeout multiplier / connection priority 불일치로 보드가 연결 unhealthy 판정?
4. 보드가 진짜 PLC의 특정 동작(예: config assembly 데이터, 특정 trigger class)을 기대?
5. EEIP.NET의 O→T 패킷 포맷(sequence count, connection ID, run/idle)이 이 보드와 미묘하게 안 맞음?

→ **패킷 캡처(PC .1 ↔ 보드 .11, UDP 2222)로 O→T가 실제 나가는지/보드 응답을 봐야 ground truth.**

## 7. ★ 직접 접속해서 확인하는 법 (ftechremote)
타겟 PC를 ftechremote HTTP API(:5050)로 원격제어. **WSL에서는 출발지IP 강제 필요**:
```bash
# WSL → 타겟. (WSL2 NAT라 --interface로 같은대역 출발지 강제해야 닿음)
SRC=192.168.0.254; IP=192.168.0.206; HDR="X-API-Key: ftech-remote-2024-admin"
# health
curl --interface $SRC -s -H "$HDR" "http://$IP:5050/api/health"
# cmd 실행
curl --interface $SRC -s -X POST -H "$HDR" -H "Content-Type: application/json" \
  "http://$IP:5050/api/exec" -d '{"shell":"cmd","command":"<명령>"}'
# 파일 업로드: POST /api/files/upload?path=<urlencoded>  -F file=@local
# 스크린샷: GET /api/screenshot?quality=png -o out.png
```
(윈도우 curl.exe 로도 됨: `curl.exe -H "$HDR" ...`)

### 진단 유틸 (이미 타겟에 배포됨)
`C:\Program Files\ftech\FbeiIpAssign.exe` (소스: `DAEIL_RS4/Tools/FbeiIpAssign/Program.vb`, VB.NET .NET4.8, EEIP.dll 동봉). 로그: 같은폴더 `fbei_ip_log.txt`. 콘솔서버는 `wmic process call create "..."`로 detached 실행.
모드:
- `in 192.168.250.10 8` — 입력 8초 라이브 모니터(켜진 채널 디코드)
- `out 192.168.250.11 0 FF 20` — DO에 O_T[0]=0xFF 20초 유지 (Q LED 관찰)
- `osweep 192.168.250.11` — 출력 포맷 4변형 스윕
- `dodiag 192.168.250.11` — DO T→O 진단(전원에러 byte8 등)
- `drive2 <outIp> <inIp> <byteIdx> <bitIdx>` — 출력Class1+입력explicit 동시(출력→입력 피드백)
- `exp <inIp> <outIp> <hex>` — explicit 입출력 (출력 explicit는 안 먹힘 확인됨)
- `lock <ip> [finalIp]` / `id <ip>` / `serve` — IP할당/식별/BOOTP

## 8. 자료 위치
- 매뉴얼: `DAEIL_RS4/OP05_NEW/docs/Manual_FB20-Series_V1.2.pdf` (+ `Manual_FB20_raw.txt` 텍스트)
- EDS: `DAEIL_RS4/OP05_NEW/docs/FBEI-0032N-TS-V1.03.EDS`
- 통신스펙/디코드노트: `DAEIL_RS4/OP05_NEW/docs/COMMUNICATION_SPEC.md`, `EDS_DECODE_NOTES.md`
- EEIP.NET 소스(master): `/tmp/EEIP.NET/` (빌드본 `EEIP.NET/EEIP.NET/bin/Release/EEIP.dll`)
- 통합 툴킷: `Apps/Elco/` (README에 전체 정리)
- 클라이언트 코드: `DAEIL_RS4/Op01_PE/Common/FbeiIoClient.vb`

## 9. Codex에게 묻고 싶은 것
1. BF(Bus Fault) 빨강 + 입력은 되는데 출력 O→T만 안 먹는 이 패턴의 **가장 정확한 원인**은?
2. ELCO FBEI EtherNet/IP에서 **Exclusive Owner 출력 연결을 EEIP.NET으로 성립**시키려면 정확히 어떤 파라미터? (특히 T→O Multicast vs P2P, RPI, timeout, run/idle, config assembly)
3. EEIP.NET이 이 보드(또는 일반 ODVA adapter)와 출력이 안 되는 알려진 이슈/해결책?
4. 패킷캡처로 뭘 봐야 O→T 거부 원인을 확정하나? (구체적 필드)
