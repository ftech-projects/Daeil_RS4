' ============================================================
'  FbeiIpAssign — ELCO FB20(FBEI) IP 할당 유틸
'  목적: 공장출하 IP없는 FBEI 보드에 BOOTP/DHCP로 IP 부여 + Identity 식별
'        + (선택) CIP 0xF5로 Static 영구고정
'  실행: 타겟 PC의 192.168.250.x NIC에서 관리자 권한으로.
'        BOOTP는 UDP 67/68 broadcast라 Npcap 불필요. (.NET Framework만 있으면 됨)
'  의존: EEIP.dll (..\..\lib)
'
'  ★ 보드 MAC 사전확보 불필요 — BOOTP 요청 패킷 chaddr에서 동적 캡처 + 파일로그 ★
'  보드 = 32DI(FBEI-3200N-TS)=.10 / 32DO(FBEI-0032N-TS)=.11  (2대)
'
'  사용법:
'    FbeiIpAssign.exe                 → BOOTP 서버. 요청 받으면 IP부여+MAC로그+식별, Ctrl+C까지
'    FbeiIpAssign.exe id   <ip>       → Identity + attr5(IP설정) raw 읽기
'    FbeiIpAssign.exe lock <ip> [fin] → Static 고정. fin 주면 그 IP로 relocate(스왑교정) 후 고정
'
'  권장 절차:
'    1) serve 실행(관리자) → 보드 전원(가능하면 DI 먼저 .10, DO 다음 .11)
'    2) 콘솔/로그파일에서 MAC·모델·IP 확인. 모델↔IP 어긋나면 경고 뜸
'    3) attr5 raw 바이트오더 확인 후, 영구고정 필요시 lock 실행
' ============================================================
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Threading
Imports Sres.Net.EEIP

Module Program

    ' --- 설정 ---
    Const SUBNET As String = "255.255.255.0"
    Const GATEWAY As String = "0.0.0.0"
    ' 처음 보는 MAC에 순서대로 부여할 IP 풀 (MAC고정 없을 때 폴백)
    Private ReadOnly IpPool() As String = {"192.168.250.10", "192.168.250.11"}
    ' MAC 고정매핑 (실측 MAC → 관례IP). 전원순서 무관하게 결정적 할당.
    '   32DI 입력 = .10 / 32DO 출력 = .11
    Private ReadOnly MacPin As New Dictionary(Of String, String) From {
        {"8C:19:2D:52:21:E6", "192.168.250.10"},   ' FBEI-3200N-TS 32DI 입력
        {"8C:19:2D:52:21:EC", "192.168.250.11"}    ' FBEI-0032N-TS 32DO 출력
    }
    ' IP별 기대 모델 (Identity ProductName 부분일치). 식별 후 불일치면 경고
    Private ReadOnly ExpectModel As New Dictionary(Of String, String) From {
        {"192.168.250.10", "3200"},   ' 32DI = FBEI-3200N-TS
        {"192.168.250.11", "0032"}    ' 32DO = FBEI-0032N-TS
    }

    Private ReadOnly Leases As New Dictionary(Of String, String)()   ' MAC(hex) → 부여IP
    Private PoolIdx As Integer = 0
    Private ServerIp As String = "192.168.250.1"
    Private LogPath As String = "fbei_ip_log.txt"
    Private ReadOnly StopFlag As New ManualResetEvent(False)

    Function Main(args As String()) As Integer
        Console.OutputEncoding = Encoding.UTF8
        LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fbei_ip_log.txt")
        ServerIp = DetectServerIp()
        Log("=== FbeiIpAssign — ELCO FBEI IP 할당 유틸 ===")
        Log($"서버(NIC) IP: {ServerIp}   서브넷: {SUBNET}   로그: {LogPath}")

        Dim mode As String = If(args.Length > 0, args(0).ToLowerInvariant(), "serve")
        Select Case mode
            Case "id"
                If args.Length < 2 Then Log("사용법: id <ip>") : Return 1
                Return IdentifyBoard(args(1))
            Case "lock"
                If args.Length < 2 Then Log("사용법: lock <ip> [finalIp]") : Return 1
                Return LockStatic(args(1), If(args.Length >= 3, args(2), args(1)))
            Case "io"
                Dim inIp As String = If(args.Length >= 2, args(1), "192.168.250.10")
                Dim outIp As String = If(args.Length >= 3, args(2), "192.168.250.11")
                Return IoTest(inIp, outIp)
            Case "in"
                ' in <ip> [sec] — 입력 라이브 모니터 (켜진 채널 디코드)
                Dim iip As String = If(args.Length >= 2, args(1), "192.168.250.10")
                Dim isec As Integer = If(args.Length >= 3, CInt(args(2)), 6)
                Return InTest(iip, isec)
            Case "fire"
                ' fire <outIp> <inIp> <dataByteIdx> <bitIdx> [sec] — run헤더(ob0=1) + 데이터(ob[4+idx])
                If args.Length < 5 Then Log("사용법: fire <outIp> <inIp> <dataByteIdx> <bitIdx> [sec]") : Return 1
                Return FireTest(args(1), args(2), CInt(args(3)), CInt(args(4)), If(args.Length >= 6, CInt(args(5)), 3))
            Case "drive2"
                ' drive2 <outIp> <inIp> <byteIdx> <bitIdx> [sec] — 출력Class1 + 입력explicit (2222충돌 회피)
                If args.Length < 5 Then Log("사용법: drive2 <outIp> <inIp> <byteIdx> <bitIdx> [sec]") : Return 1
                Return Drive2Test(args(1), args(2), CInt(args(3)), CInt(args(4)), If(args.Length >= 6, CInt(args(5)), 3))
            Case "exp"
                ' exp <inIp> <outIp> <outHex byte0> — 명시메시징 입출력 (UDP2222 불필요)
                Dim eIn As String = If(args.Length >= 2, args(1), "192.168.250.10")
                Dim eOut As String = If(args.Length >= 3, args(2), "192.168.250.11")
                Dim eVal As Byte = If(args.Length >= 4, CByte(Convert.ToInt32(args(3), 16)), CByte(&H4))
                Return ExpTest(eIn, eOut, eVal)
            Case "drive"
                ' drive <outIp> <inIp> <byteIdx> <bitIdx> [holdSec] — 출력ON→입력변화관찰→OFF
                If args.Length < 5 Then Log("사용법: drive <outIp> <inIp> <byteIdx> <bitIdx> [sec]") : Return 1
                Return DriveTest(args(1), args(2), CInt(args(3)), CInt(args(4)), If(args.Length >= 6, CInt(args(5)), 3))
            Case "osweep"
                Return OSweep(If(args.Length >= 2, args(1), "192.168.250.11"))
            Case "dodiag"
                Return DoDiag(If(args.Length >= 2, args(1), "192.168.250.11"))
            Case "omc"
                ' omc <ip> [sec] — 출력 Exclusive Owner, T→O를 Multicast로 (EDS 명시) + Q1~8 ON
                Return OutMcast(If(args.Length >= 2, args(1), "192.168.250.11"), If(args.Length >= 3, CInt(args(2)), 20), New Byte() {&H6, &H0}, "06 00")
            Case "omc0"
                ' omc0 <ip> [sec] — 출력보드 config 00 00으로 Exclusive Owner 테스트
                Return OutMcast(If(args.Length >= 2, args(1), "192.168.250.11"), If(args.Length >= 3, CInt(args(2)), 20), New Byte() {&H0, &H0}, "00 00")
            Case "holdout"
                ' holdout <ip> [sec] — 출력은 OFF(00)로 유지하고 Exclusive Owner 연결만 지속
                Return HoldOutputConnection(If(args.Length >= 2, args(1), "192.168.250.11"), If(args.Length >= 3, CInt(args(2)), 86400))
            Case "out"
                ' out <ip> [offset] [hex] [sec] — O_T_IOData[offset]=hex 를 sec초 유지 (LED 확인)
                Dim oip As String = If(args.Length >= 2, args(1), "192.168.250.11")
                Dim off As Integer = If(args.Length >= 3, CInt(args(2)), 0)
                Dim val As Byte = If(args.Length >= 4, CByte(Convert.ToInt32(args(3), 16)), CByte(&HF))
                Dim sec As Integer = If(args.Length >= 5, CInt(args(4)), 6)
                Return OutTest(oip, off, val, sec)
            Case Else
                Return RunBootpServer()
        End Select
    End Function

    ' ===== BOOTP/DHCP 서버 =====
    Private Function RunBootpServer() As Integer
        Log("BOOTP/DHCP 서버 시작 (UDP 67). 보드 전원 넣으세요. 종료=Ctrl+C")
        Log("IP 풀: " & String.Join(", ", IpPool) & "  (DI=.10, DO=.11)")
        Log(New String("-"c, 60))

        AddHandler Console.CancelKeyPress,
            Sub(s, e)
                e.Cancel = True
                StopFlag.Set()
            End Sub

        Dim sock As Socket = Nothing
        Try
            sock = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
            sock.EnableBroadcast = True
            sock.Bind(New IPEndPoint(IPAddress.Any, 67))   ' BOOTP 서버 포트
            sock.ReceiveTimeout = 1000

            Dim buf(1023) As Byte
            While Not StopFlag.WaitOne(0)
                Dim remote As EndPoint = New IPEndPoint(IPAddress.Any, 0)
                Dim n As Integer
                Try
                    n = sock.ReceiveFrom(buf, remote)
                Catch ex As SocketException
                    Continue While   ' timeout → 루프 재확인 (Ctrl+C 반영)
                End Try
                If n < 240 Then Continue While
                HandleBootp(sock, buf, n)
            End While
        Catch ex As SocketException
            Log($"[오류] 소켓: {ex.Message}")
            If ex.SocketErrorCode = SocketError.AccessDenied Then
                Log("  → 관리자 권한으로 실행하세요 (포트 67 바인딩 필요).")
            ElseIf ex.SocketErrorCode = SocketError.AddressAlreadyInUse Then
                Log("  → 포트 67 사용 중. DHCP Server 서비스/다른 BOOTP툴 종료.")
            End If
            Return 1
        Finally
            If sock IsNot Nothing Then sock.Close()
        End Try
        Log("서버 종료.")
        Return 0
    End Function

    ''' <summary>BOOTREQUEST 처리 → MAC 추출 → IP 부여 → 응답 → 백그라운드 식별</summary>
    Private Sub HandleBootp(sock As Socket, req() As Byte, len As Integer)
        If req(0) <> 1 Then Exit Sub   ' op=1 (REQUEST) 아니면 무시

        Dim mac As String = MacHex(req, 28)                 ' chaddr (28~33)
        Dim msgType As Integer = ParseDhcpMsgType(req, len) ' 53번 옵션 (없으면 -1=순수BOOTP)

        Dim ip As String = Nothing
        If Not Leases.TryGetValue(mac, ip) Then
            Dim pinned As String = Nothing
            If MacPin.TryGetValue(mac, pinned) Then
                ip = pinned                              ' MAC 고정매핑 우선 (결정적)
            ElseIf PoolIdx < IpPool.Length Then
                ip = IpPool(PoolIdx) : PoolIdx += 1       ' 미등록 MAC은 풀에서
            Else
                Log($"[경고] 풀 소진 — MAC {mac} 할당 불가")
                Exit Sub
            End If
            Leases(mac) = ip
            Log($"[신규보드] MAC {mac} → {ip}   (req={DhcpName(msgType)}{If(pinned IsNot Nothing, ", PIN", "")})")
        End If

        Dim replyType As Integer = If(msgType = 1, 2, If(msgType = 3, 5, -1))
        Dim reply() As Byte = BuildReply(req, ip, replyType)
        sock.SendTo(reply, New IPEndPoint(IPAddress.Broadcast, 68))
        Log($"          → 응답 yiaddr={ip} ({If(replyType = -1, "BOOTREPLY", DhcpName(replyType))})")

        ' DHCP OFFER(2) 직후엔 아직 IP 미적용 → ACK/BOOTREPLY 후에만 식별
        If replyType <> 2 Then
            Dim assigned As String = ip
            ThreadPool.QueueUserWorkItem(
                Sub()
                    Thread.Sleep(2500)
                    IdentifyBoard(assigned)
                End Sub)
        End If
    End Sub

    Private Function BuildReply(req() As Byte, yourIp As String, dhcpType As Integer) As Byte()
        Dim p(299) As Byte
        p(0) = 2                          ' op = BOOTREPLY
        p(1) = 1 : p(2) = 6 : p(3) = 0    ' htype=Ethernet, hlen=6, hops=0
        Array.Copy(req, 4, p, 4, 4)       ' xid
        p(10) = req(10) : p(11) = req(11) ' flags (broadcast bit 유지)
        CopyIp(p, 16, yourIp)             ' yiaddr
        CopyIp(p, 20, ServerIp)           ' siaddr
        Array.Copy(req, 24, p, 24, 4)     ' giaddr
        Array.Copy(req, 28, p, 28, 16)    ' chaddr (MAC)
        p(236) = &H63 : p(237) = &H82 : p(238) = &H53 : p(239) = &H63   ' magic cookie

        Dim opts As New List(Of Byte)()
        If dhcpType <> -1 Then opts.AddRange({CByte(53), CByte(1), CByte(dhcpType)})
        opts.AddRange({CByte(1), CByte(4)}) : opts.AddRange(IpBytes(SUBNET))      ' subnet
        opts.AddRange({CByte(54), CByte(4)}) : opts.AddRange(IpBytes(ServerIp))   ' server id
        opts.AddRange({CByte(51), CByte(4), &HFF, &HFF, &HFF, &HFF})              ' lease 무한
        opts.Add(CByte(255))                                                       ' end

        Dim total As Integer = 240 + opts.Count
        If total > p.Length Then ReDim Preserve p(total - 1)
        For i As Integer = 0 To opts.Count - 1
            p(240 + i) = opts(i)
        Next
        Return p
    End Function

    ' ===== Identity 식별 + 모델↔IP 검증 + attr5 raw =====
    Private Function IdentifyBoard(ip As String) As Integer
        Dim c As New EEIPClient()
        Try
            c.IPAddress = ip
            c.RegisterSession()
            Dim name As String = ShortString(c.GetAttributeSingle(1, 1, 7))      ' Product Name
            Dim code As Integer = ToU16(c.GetAttributeSingle(1, 1, 3))           ' Product Code
            Dim serial As UInteger = ToU32(c.GetAttributeSingle(1, 1, 6))        ' Serial
            Dim kind As String = If(name.Contains("3200"), "32DI 입력", If(name.Contains("0032"), "32DO 출력", "?"))
            Log($"[식별] {ip} = {name} ({kind})  ProdCode={code} Serial=0x{serial:X8}")

            ' 모델 ↔ IP 기대값 검증
            Dim expect As String = Nothing
            If ExpectModel.TryGetValue(ip, expect) Then
                If Not name.Contains(expect) Then
                    Dim want As String = If(name.Contains("3200"), "192.168.250.10", If(name.Contains("0032"), "192.168.250.11", "?"))
                    Log($"  ⚠️ 모델↔IP 불일치! {ip}에 {name}이 붙음(기대 {expect}계열).")
                    Log($"     → 교정: lock {ip} {want}   또는 보드 전원순서 바꿔 재할당")
                End If
            End If

            ' TCP/IP Object(0xF5) attr5 raw — 바이트오더 실측용
            Try
                Dim cfg() As Byte = c.GetAttributeSingle(&HF5, 1, 5)
                Log($"        0xF5/attr5(IP설정) raw[{cfg.Length}]: {Hex(cfg)}")
            Catch
                Log("        0xF5/attr5 읽기 실패(미지원/권한)")
            End Try
            c.UnRegisterSession()
            Return 0
        Catch ex As Exception
            Log($"[식별 실패] {ip}: {ex.Message}  (보드가 아직 IP 미적용? 케이블/방화벽?)")
            Try : c.UnRegisterSession() : Catch : End Try
            Return 1
        End Try
    End Function

    ' ===== Static 고정 (CIP 0xF5). finalIp != ip 면 relocate =====
    Private Function LockStatic(ip As String, finalIp As String) As Integer
        Dim relocate As Boolean = Not String.Equals(ip, finalIp, StringComparison.Ordinal)
        Log($"[고정] {ip} → {finalIp} {(If(relocate, "(relocate+고정)", "(현재IP 고정)"))} (CIP TCP/IP 0xF5)")
        Dim c As New EEIPClient()
        Try
            c.IPAddress = ip
            c.RegisterSession()

            ' 1) 변경 전 attr5 (저장된 Interface Config) — 이미 목표IP 들고있는지 확인
            Dim before() As Byte = c.GetAttributeSingle(&HF5, 1, 5)
            Dim storedIp As String = IpFromLE(before, 0)
            Log($"  before attr5[{before.Length}]: {Hex(before)}  (저장IP={storedIp})")

            ' 2) ★ Configuration Control(attr3)=0(static) 먼저 ★
            '    CIP TCP/IP는 BOOTP/DHCP 모드에선 attr5 쓰기 거부(Object State Conflict).
            '    attr3=0으로 'stored static 사용' 전환 → 저장 attr5가 이미 목표IP면 그대로 영구고정.
            c.SetAttributeSingle(&HF5, 1, 3, New Byte() {0, 0, 0, 0})
            Log("  attr3=0 (static) 설정")
            c.UnRegisterSession()

            ' 3) relocate(저장IP != 목표IP)일 때만 attr5 새로 기록 (이제 static모드라 허용)
            If Not String.Equals(storedIp, finalIp, StringComparison.Ordinal) Then
                Try
                    Thread.Sleep(400)
                    Dim cw As New EEIPClient() With {.IPAddress = ip}
                    cw.RegisterSession()
                    Dim cfg(21) As Byte
                    PutIpLE(cfg, 0, finalIp)
                    PutIpLE(cfg, 4, SUBNET)
                    PutIpLE(cfg, 8, GATEWAY)
                    cw.SetAttributeSingle(&HF5, 1, 5, cfg)
                    cw.UnRegisterSession()
                    Log($"  attr5 = {finalIp} 기록 (relocate)")
                Catch exw As Exception
                    Log($"  ⚠️ attr5 relocate 실패: {exw.Message} (저장IP {storedIp} 로 고정됨)")
                End Try
            Else
                Log($"  저장 attr5 이미 {finalIp} → attr3=0만으로 고정 완료")
            End If

            ' 4) 적용 검증: finalIp로 재접속해서 Identity 읽힘?
            Log($"  검증: {finalIp} 재접속 시도(2초 후)...")
            Thread.Sleep(2000)
            Dim ok As Integer = IdentifyBoard(finalIp)
            If ok = 0 Then
                Log($"  ✅ {finalIp} 응답 — 고정 성공. (재부팅 후에도 유지되는지 최종확인 권장)")
            Else
                Log($"  ⚠️ {finalIp} 응답없음 — 즉시적용 안됐거나(재부팅 필요) 바이트오더 상이. before/after raw 비교 요망.")
            End If
            Return 0
        Catch ex As Exception
            Log($"[고정 실패] {ip}: {ex.Message}")
            Log("  (attr5 구조/바이트오더 상이 가능 — before raw 보고 PutIpLE 조정)")
            Try : c.UnRegisterSession() : Catch : End Try
            Return 1
        End Try
    End Function

    ' ===== IO 테스트 (실보드 ForwardOpen → 입력읽기/출력토글) =====
    ' RS4 메인앱의 FbeiIoClient.OpenSlave 와 동일 파라미터로 Class1 I/O 연결.
    ' ⚠️ EtherNet/IP 사이클릭 I/O(T→O)는 UDP 2222 인바운드 필요 — 방화벽 허용해둘 것.
    Private Function IoTest(inIp As String, outIp As String) As Integer
        Log($"[IO테스트] IN(32DI)={inIp}, OUT(32DO)={outIp}")

        ' ===== 1) IN(32DI) — 확정조합 O_T=0xC1 ZeroLength =====
        Log("=== IN(32DI) — O_T=0xC1 ZeroLength (확정) ===")
        Try
            Dim di As New EEIPClient()
            OpenIoEx(di, inIp, &H65US, 10US, &HC1US, 0US, RealTimeFormat.ZeroLength, ConnectionType.Point_to_Point, "IN")
            Thread.Sleep(900)
            Dim raw As Byte() = di.T_O_IOData
            If raw IsNot Nothing AndAlso raw.Length >= 4 Then
                Log($"  ✅ IN 읽기 OK: i1~32 = {raw(0):X2} {raw(1):X2} {raw(2):X2} {raw(3):X2} (PowerErr={If(raw.Length >= 9, raw(8).ToString("X2"), "?")})")
            Else
                Log($"  △ IN ForwardOpen OK인데 데이터 빔(UDP2222?)")
            End If
            di.ForwardClose() : di.UnRegisterSession()
        Catch ex As Exception
            Log($"  ❌ IN 실패: {ex.Message}")
        End Try

        ' ===== 2) OUT(32DO) O→T 포맷 스윕 — Q1 토글 =====
        Log("=== OUT(32DO) O→T 포맷 스윕 ===")
        Dim onames() As String = {"O_T=0x64 Header32Bit len4", "O_T=0x64 ZeroLength len4", "O_T=0x64 Modeless len8", "O_T=0x64 Header32Bit len0"}
        Dim ofmts() As RealTimeFormat = {RealTimeFormat.Header32Bit, RealTimeFormat.ZeroLength, RealTimeFormat.Modeless, RealTimeFormat.Header32Bit}
        Dim olens() As UShort = {4US, 4US, 8US, 0US}
        For v As Integer = 0 To onames.Length - 1
            Try
                Dim dout As New EEIPClient()
                OpenIoEx(dout, outIp, &H65US, 10US, &H64US, olens(v), ofmts(v), ConnectionType.Point_to_Point, "OUT:" & onames(v))
                Dim ob As Byte() = dout.O_T_IOData
                Log($"  O_T_IOData len={If(ob Is Nothing, -1, ob.Length)} → Q1 ON 2초 (출력보드 Q1 LED 확인!)")
                If ob IsNot Nothing AndAlso ob.Length >= 1 Then ob(0) = 1 : dout.O_T_IOData = ob
                Thread.Sleep(2000)
                If ob IsNot Nothing AndAlso ob.Length >= 1 Then ob(0) = 0 : dout.O_T_IOData = ob
                Thread.Sleep(300)
                dout.ForwardClose() : dout.UnRegisterSession()
                Log($"  ✅✅ OUT [{onames(v)}] ForwardOpen 성공 — 이 포맷으로 출력제어 됨")
                Return 0
            Catch ex As Exception
                Log($"  ✗ OUT [{onames(v)}]: {ex.Message}")
            End Try
        Next
        Log("[IO테스트] 출력 포맷 모두 실패 — STATUS 추가분석 필요")
        Return 1
    End Function

    ''' <summary>run/idle 헤더(ob[0]=Run) + 데이터(ob[4+idx]) 로 출력 구동. 입력 explicit 피드백.</summary>
    Private Function FireTest(outIp As String, inIp As String, dataByteIdx As Integer, bitIdx As Integer, holdSec As Integer) As Integer
        Log($"[fire] OUT run헤더+데이터 ob[0]=01, ob[{4 + dataByteIdx}].bit{bitIdx} + IN explicit. ⚠️움직임")
        Dim co As New EEIPClient(), ci As New EEIPClient()
        Try
            OpenIoEx(co, outIp, &H65US, 10US, &H64US, 4US, RealTimeFormat.Header32Bit, ConnectionType.Point_to_Point, "OUT-IO")
            ci.IPAddress = inIp : ci.RegisterSession()
            Thread.Sleep(500)
            Dim baseRaw As Byte() = ci.GetAttributeSingle(&H4, &H65, 3)
            Log($"  baseline IN ON=[{ActiveChannels(baseRaw)}]")

            Dim ob As Byte() = co.O_T_IOData
            If ob Is Nothing OrElse ob.Length < 8 Then Log($"  ⚠️ O_T_IOData 짧음(len={If(ob Is Nothing, -1, ob.Length)})") : Return 1
            ob(0) = CByte(ob(0) Or 1)                                  ' run/idle 헤더 = Run
            ob(4 + dataByteIdx) = CByte(ob(4 + dataByteIdx) Or (1 << bitIdx))  ' 데이터 (헤더 4byte 뒤)
            co.O_T_IOData = ob
            Log($"  → ob[0]=0x{ob(0):X2}(Run) ob[{4 + dataByteIdx}]=0x{ob(4 + dataByteIdx):X2}, {holdSec}초")
            Thread.Sleep(holdSec * 1000)

            Dim afterRaw As Byte() = ci.GetAttributeSingle(&H4, &H65, 3)
            Log($"  구동중   IN ON=[{ActiveChannels(afterRaw)}]")
            Dim diff As String = DiffChannels(baseRaw, afterRaw)

            ob(4 + dataByteIdx) = 0 : ob(0) = CByte(ob(0) And &HFE)
            co.O_T_IOData = ob
            Log("  → OUT OFF")
            Thread.Sleep(800)

            If diff <> "" Then
                Log($"  ✅✅✅ 출력 구동 성공! IN변화: {diff}  → run헤더[0]+데이터[4+] 레이아웃 확정!")
            Else
                Log($"  ✗ 변화없음 — run헤더 위치/데이터offset 다름 (또는 클램프 다른 Q)")
            End If
            co.ForwardClose() : co.UnRegisterSession() : ci.UnRegisterSession()
            Return 0
        Catch ex As Exception
            Log($"[fire 실패] {ex.Message}")
            Try : co.UnRegisterSession() : Catch : End Try
            Try : ci.UnRegisterSession() : Catch : End Try
            Return 1
        End Try
    End Function

    ''' <summary>하이브리드: 출력=Class1 I/O(2222), 입력=explicit GetAttr. 2222 충돌 회피 검증.</summary>
    Private Function Drive2Test(outIp As String, inIp As String, byteIdx As Integer, bitIdx As Integer, holdSec As Integer) As Integer
        Log($"[하이브리드구동] OUT(Class1)[{byteIdx}].bit{bitIdx} + IN(explicit). ⚠️ 실린더 움직임")
        Dim co As New EEIPClient(), ci As New EEIPClient()
        Try
            ' 출력: Class1 I/O (outputs 활성화 위해 필수)
            OpenIoEx(co, outIp, &H65US, 10US, &H64US, 4US, RealTimeFormat.Header32Bit, ConnectionType.Point_to_Point, "OUT-IO")
            ' 입력: explicit (2222 안 바인딩)
            ci.IPAddress = inIp : ci.RegisterSession()
            Thread.Sleep(500)

            Dim baseRaw As Byte() = ci.GetAttributeSingle(&H4, &H65, 3)
            Log($"  baseline IN ON=[{ActiveChannels(baseRaw)}]")

            Dim ob As Byte() = co.O_T_IOData
            If ob Is Nothing OrElse ob.Length <= byteIdx Then Log("  ⚠️ O_T_IOData 작음") : Return 1
            ob(byteIdx) = CByte(ob(byteIdx) Or (1 << bitIdx))
            co.O_T_IOData = ob
            Log($"  → OUT[{byteIdx}].bit{bitIdx} ON, {holdSec}초")
            Thread.Sleep(holdSec * 1000)

            Dim afterRaw As Byte() = ci.GetAttributeSingle(&H4, &H65, 3)
            Log($"  구동중   IN ON=[{ActiveChannels(afterRaw)}]")
            Dim diff As String = DiffChannels(baseRaw, afterRaw)

            ob(byteIdx) = CByte(ob(byteIdx) And Not (1 << bitIdx))
            co.O_T_IOData = ob
            Log("  → OUT OFF")
            Thread.Sleep(800)

            If diff <> "" Then
                Log($"  ✅✅ 하이브리드 성공! IN변화: {diff}")
                Log($"  → 출력Class1+입력explicit 아키텍처 동작 + offset[{byteIdx}] 정답")
            Else
                Log($"  ✗ IN 변화 없음 — offset[{byteIdx}] bit{bitIdx} 확인 (offset 4 시도?)")
            End If
            co.ForwardClose() : co.UnRegisterSession() : ci.UnRegisterSession()
            Return 0
        Catch ex As Exception
            Log($"[하이브리드구동 실패] {ex.Message}")
            Try : co.UnRegisterSession() : Catch : End Try
            Try : ci.UnRegisterSession() : Catch : End Try
            Return 1
        End Try
    End Function

    ''' <summary>명시메시징(Class3): 입력 GetAttr(4,0x65,3) / 출력 SetAttr(4,0x64,3). UDP2222 불필요.</summary>
    Private Function ExpTest(inIp As String, outIp As String, outVal As Byte) As Integer
        Log($"[명시메시징] IN={inIp} GetAttr(4,0x65,3) / OUT={outIp} SetAttr(4,0x64,3)=0x{outVal:X2}")
        Dim ci As New EEIPClient(), co As New EEIPClient()
        Try
            ci.IPAddress = inIp : ci.RegisterSession()
            co.IPAddress = outIp : co.RegisterSession()

            Dim inb As Byte() = ci.GetAttributeSingle(&H4, &H65, 3)
            Log($"  IN baseline raw={Hex(inb)}  ON=[{ActiveChannels(inb)}]")

            co.SetAttributeSingle(&H4, &H64, 3, New Byte() {outVal, 0, 0, 0})
            Log($"  OUT SetAttr byte0=0x{outVal:X2} → 3초 유지 (실린더 움직임)")
            Thread.Sleep(3000)

            Dim inb2 As Byte() = ci.GetAttributeSingle(&H4, &H65, 3)
            Log($"  IN 구동중  raw={Hex(inb2)}  ON=[{ActiveChannels(inb2)}]")
            Dim diff As String = DiffChannels(inb, inb2)

            co.SetAttributeSingle(&H4, &H64, 3, New Byte() {0, 0, 0, 0})
            Log("  OUT → 0 (홈복귀)")
            Thread.Sleep(800)

            If diff <> "" Then
                Log($"  ✅✅ 명시메시징 출력 동작! IN변화: {diff} → 출력은 explicit로 제어 가능")
            Else
                Log($"  ✗ IN 변화 없음 — explicit 출력write가 안 먹힘(I/O연결 owner 필요할 수 있음)")
            End If
            co.UnRegisterSession() : ci.UnRegisterSession()
            Return 0
        Catch ex As Exception
            Log($"[명시메시징 실패] {ex.Message}")
            Try : ci.UnRegisterSession() : Catch : End Try
            Try : co.UnRegisterSession() : Catch : End Try
            Return 1
        End Try
    End Function

    ''' <summary>출력 펄스 → 입력 변화 관찰 (출력→센서 물리피드백으로 출력동작+offset 검증)</summary>
    Private Function DriveTest(outIp As String, inIp As String, byteIdx As Integer, bitIdx As Integer, holdSec As Integer) As Integer
        Log($"[구동테스트] OUT[{byteIdx}].bit{bitIdx} 펄스 → IN 변화관찰. ⚠️ 실린더 움직임")
        Dim di As New EEIPClient(), dout As New EEIPClient()
        Try
            OpenIoEx(di, inIp, &H65US, 10US, &HC1US, 0US, RealTimeFormat.ZeroLength, ConnectionType.Point_to_Point, "IN")
            OpenIoEx(dout, outIp, &H65US, 10US, &H64US, 4US, RealTimeFormat.Header32Bit, ConnectionType.Point_to_Point, "OUT")
            Thread.Sleep(900)
            Dim baseRaw As Byte() = Snap(di.T_O_IOData)
            Log($"  baseline  IN ON=[{ActiveChannels(baseRaw)}]")

            Dim ob As Byte() = dout.O_T_IOData
            If ob Is Nothing OrElse ob.Length <= byteIdx Then Log($"  ⚠️ O_T_IOData 작음(len={If(ob Is Nothing, -1, ob.Length)})") : Return 1
            ob(byteIdx) = CByte(ob(byteIdx) Or (1 << bitIdx))
            dout.O_T_IOData = ob
            Log($"  → OUT[{byteIdx}].bit{bitIdx} ON, {holdSec}초 유지")
            Thread.Sleep(holdSec * 1000)
            Dim afterRaw As Byte() = Snap(di.T_O_IOData)
            Log($"  구동중    IN ON=[{ActiveChannels(afterRaw)}]")

            ob(byteIdx) = CByte(ob(byteIdx) And Not (1 << bitIdx))
            dout.O_T_IOData = ob
            Log("  → OUT OFF")
            Thread.Sleep(800)

            Dim diff As String = DiffChannels(baseRaw, afterRaw)
            If diff <> "" Then
                Log($"  ✅✅ 출력→입력 피드백 확인! 변화: {diff}")
                Log($"  → 출력 실동작 + offset[{byteIdx}] 정답 확정")
            Else
                Log($"  ✗ IN 변화 없음 — offset[{byteIdx}] bit{bitIdx} 무효. (offset 4 또는 다른 bit 시도)")
            End If
            di.ForwardClose() : di.UnRegisterSession()
            dout.ForwardClose() : dout.UnRegisterSession()
            Return 0
        Catch ex As Exception
            Log($"[구동테스트 실패] {ex.Message}")
            Try : di.UnRegisterSession() : Catch : End Try
            Try : dout.UnRegisterSession() : Catch : End Try
            Return 1
        End Try
    End Function

    Private Function Snap(raw() As Byte) As Byte()
        If raw Is Nothing Then Return New Byte() {}
        Return CType(raw.Clone(), Byte())
    End Function

    Private Function ChanOn(raw() As Byte, ch As Integer) As Boolean
        Dim bi As Integer = (ch - 1) \ 8, bit As Integer = (ch - 1) Mod 8
        Return raw IsNot Nothing AndAlso bi < raw.Length AndAlso ((raw(bi) >> bit) And 1) = 1
    End Function

    Private Function DiffChannels(a() As Byte, b() As Byte) As String
        Dim s As New List(Of String)()
        For ch As Integer = 1 To 32
            Dim av As Boolean = ChanOn(a, ch), bv As Boolean = ChanOn(b, ch)
            If av <> bv Then s.Add($"ch{ch}{If(bv, "↑ON", "↓OFF")}")
        Next
        Return String.Join(", ", s)
    End Function

    ''' <summary>입력 라이브 모니터: 1초마다 읽어서 켜진 채널(i1~i32) 디코드 출력.</summary>
    Private Function InTest(ip As String, sec As Integer) As Integer
        Log($"[IN모니터] {ip} {sec}초 — 켜진 입력채널 표시 (센서 눌러보면 변함)")
        Try
            Dim c As New EEIPClient()
            OpenIoEx(c, ip, &H65US, 10US, &HC1US, 0US, RealTimeFormat.ZeroLength, ConnectionType.Point_to_Point, "IN")
            For k As Integer = 1 To sec
                Thread.Sleep(1000)
                Dim raw As Byte() = c.T_O_IOData
                If raw IsNot Nothing AndAlso raw.Length >= 4 Then
                    Dim pe As String = If(raw.Length >= 9, raw(8).ToString("X2"), "?")
                    Log($"  {raw(0):X2} {raw(1):X2} {raw(2):X2} {raw(3):X2}  ON채널=[{ActiveChannels(raw)}]  PowerErr={pe}")
                Else
                    Log($"  데이터 빔(len={If(raw Is Nothing, -1, raw.Length)})")
                End If
            Next
            c.ForwardClose() : c.UnRegisterSession()
            Return 0
        Catch ex As Exception
            Log($"[IN모니터 실패] {ex.Message}")
            Return 1
        End Try
    End Function

    ''' <summary>raw 입력바이트에서 켜진 채널번호(i1~i32) 목록</summary>
    Private Function ActiveChannels(raw() As Byte) As String
        Dim s As New List(Of Integer)()
        For ch As Integer = 1 To 32
            Dim b As Integer = (ch - 1) \ 8, bit As Integer = (ch - 1) Mod 8
            If b < raw.Length AndAlso ((raw(b) >> bit) And 1) = 1 Then s.Add(ch)
        Next
        Return If(s.Count = 0, "(없음)", String.Join(",", s))
    End Function

    ''' <summary>출력 오프셋 확인: O_T_IOData[offset]=val 를 sec초 유지. 출력보드 Q LED 관찰용.</summary>
    ''' <summary>출력 Exclusive Owner — T→O를 Multicast로 (EDS 명시). BF 초록 되는지 확인.</summary>
    Private Function OutMcast(ip As String, sec As Integer, configData() As Byte, configLabel As String) As Integer
        Log($"[출력-Multicast] {ip} Exclusive Owner, T→O=Multicast, Config={configLabel}, Q1~8 ON {sec}초 — ★보드 BF/Q LED 보세요★")
        Try
            Dim c As New EEIPClient()
            c.IPAddress = ip
            c.RegisterSession()
            c.AssemblyObjectClass = &H4
            c.ConfigurationAssemblyInstanceID = &H66
            c.SetAttributeSingle(&H4, &H66, 3, configData)
            Log($"  Config 0x66={Hex(c.GetAttributeSingle(&H4, &H66, 3))}")
            c.T_O_InstanceID = &H65US : c.T_O_Length = 10US
            c.O_T_InstanceID = &H64US : c.O_T_Length = 4US
            c.RequestedPacketRate_O_T = 20000UI : c.RequestedPacketRate_T_O = 20000UI
            c.O_T_RealTimeFormat = RealTimeFormat.Header32Bit
            c.O_T_ConnectionType = ConnectionType.Point_to_Point
            c.T_O_RealTimeFormat = RealTimeFormat.Modeless
            c.T_O_ConnectionType = ConnectionType.Multicast        ' ★ EDS가 명시한 Multicast
            c.O_T_Priority = Priority.Scheduled : c.T_O_Priority = Priority.Scheduled
            c.O_T_OwnerRedundant = False : c.T_O_OwnerRedundant = False
            c.O_T_VariableLength = False : c.T_O_VariableLength = False
            c.ForwardOpen()
            Log("  ForwardOpen OK (T→O=Multicast)")
            Dim ob As Byte() = c.O_T_IOData
            If ob IsNot Nothing AndAlso ob.Length >= 1 Then ob(0) = &HFF : c.O_T_IOData = ob
            Thread.Sleep(sec * 1000)
            Dim t As Byte() = c.T_O_IOData
            If t IsNot Nothing AndAlso t.Length >= 9 Then Log($"  구동중 T→O: {t(0):X2}{t(1):X2}{t(2):X2}{t(3):X2} pwrErr={t(8) And 1}")
            If ob IsNot Nothing AndAlso ob.Length >= 1 Then ob(0) = 0 : c.O_T_IOData = ob
            Thread.Sleep(300)
            c.ForwardClose() : c.UnRegisterSession()
            Log("  완료 — BF 초록 됐나요? Q LED 켜졌나요?")
            Return 0
        Catch ex As Exception
            Log($"[출력-Multicast 실패] {ex.Message}")
            Return 1
        End Try
    End Function

    ''' <summary>32DO 진단 — T→O(진단입력) 읽어 전원에러/단락/과부하 확인 + 출력 명령 반영여부</summary>
    Private Function DoDiag(ip As String) As Integer
        Log($"[DO진단] {ip} 출력모듈 진단(T→O 10byte: S1~32 / O1~32 / byte8=전원에러)")
        Try
            Dim c As New EEIPClient()
            OpenIoEx(c, ip, &H65US, 10US, &H64US, 4US, RealTimeFormat.Header32Bit, ConnectionType.Point_to_Point, "DO")
            Thread.Sleep(1200)
            Dim t As Byte() = c.T_O_IOData
            If t Is Nothing OrElse t.Length < 9 Then
                Log($"  ⚠️ T→O 미수신/부족(len={If(t Is Nothing, -1, t.Length)}) — 연결 단방향?")
            Else
                Log($"  T→O raw[0..9] = {t(0):X2} {t(1):X2} {t(2):X2} {t(3):X2} | {t(4):X2} {t(5):X2} {t(6):X2} {t(7):X2} | {t(8):X2} {t(9):X2}")
                Log($"  단락S1~32={t(0):X2}{t(1):X2}{t(2):X2}{t(3):X2}  과부하O1~32={t(4):X2}{t(5):X2}{t(6):X2}{t(7):X2}")
                Log($"  ★ byte8 전원에러 bit0 = {t(8) And 1}  (1이면 출력 필드전원 24V 미연결!)")
            End If

            ' Q1~Q8 ON 후 진단 변화 (필드전원 있는데 부하 없으면 보통 변화/오픈로드 없음, 단락있으면 S비트)
            Dim ob As Byte() = c.O_T_IOData
            If ob IsNot Nothing AndAlso ob.Length >= 1 Then ob(0) = &HFF : c.O_T_IOData = ob
            Thread.Sleep(1500)
            Dim t2 As Byte() = c.T_O_IOData
            If t2 IsNot Nothing AndAlso t2.Length >= 9 Then
                Log($"  Q1~8 ON 후: S={t2(0):X2}{t2(1):X2}{t2(2):X2}{t2(3):X2} O={t2(4):X2}{t2(5):X2}{t2(6):X2}{t2(7):X2} 전원에러={t2(8) And 1}")
            End If
            If ob IsNot Nothing AndAlso ob.Length >= 1 Then ob(0) = 0 : c.O_T_IOData = ob
            Thread.Sleep(300)
            c.ForwardClose() : c.UnRegisterSession()
            Return 0
        Catch ex As Exception
            Log($"[DO진단 실패] {ex.Message}")
            Return 1
        End Try
    End Function

    ''' <summary>출력 변형 스윕 — 변형별 Q1~Q8 ON 5초. 보드 Q LED로 동작 변형 확인.</summary>
    Private Function OSweep(ip As String) As Integer
        Log($"[출력스윕] {ip} — 변형별 Q1~Q8 ON 5초씩. ★보드 Q LED 보세요★ (켜지는 변형 번호 알려주세요)")
        ' (name, otFmt, otLen, runHdrAt0, dataOffset)
        Dim names() As String = {"A:Header32Bit ob[0]", "B:Header32Bit ob[4]", "C:Modeless8 run+ob[4]", "D:Modeless8 ob[0]"}
        Dim fmts() As RealTimeFormat = {RealTimeFormat.Header32Bit, RealTimeFormat.Header32Bit, RealTimeFormat.Modeless, RealTimeFormat.Modeless}
        Dim olen() As UShort = {4US, 4US, 8US, 8US}
        Dim runHdr() As Boolean = {False, False, True, False}
        Dim dataOff() As Integer = {0, 4, 4, 0}
        For v As Integer = 0 To names.Length - 1
            Log($"  === 변형 {v + 1} [{names(v)}] — Q1~Q8 ON 5초 (지금 보세요) ===")
            Try
                Dim c As New EEIPClient()
                OpenIoEx(c, ip, &H65US, 10US, &H64US, olen(v), fmts(v), ConnectionType.Point_to_Point, $"OUT-{v + 1}")
                Dim t As Byte() = c.T_O_IOData
                Log($"    연결 T→O len={If(t Is Nothing, -1, t.Length)} (null아니면 연결 살아있음)")
                Dim ob As Byte() = c.O_T_IOData
                If ob IsNot Nothing Then
                    If runHdr(v) AndAlso ob.Length >= 4 Then ob(0) = 1 : ob(1) = 0 : ob(2) = 0 : ob(3) = 0
                    If ob.Length > dataOff(v) Then ob(dataOff(v)) = &HFF
                    c.O_T_IOData = ob
                End If
                Thread.Sleep(5000)
                If ob IsNot Nothing Then
                    If ob.Length > dataOff(v) Then ob(dataOff(v)) = 0
                    c.O_T_IOData = ob
                End If
                Thread.Sleep(300)
                c.ForwardClose() : c.UnRegisterSession()
            Catch ex As Exception
                Log($"    변형{v + 1} 실패: {ex.Message}")
            End Try
        Next
        Log("[출력스윕] 끝 — 어느 변형(1~4)에서 Q LED 켜졌는지 알려주세요")
            Return 0
    End Function

    ''' <summary>출력은 모두 OFF로 두고 Exclusive Owner 연결만 유지한다. BF LED GREEN 유지 확인용.</summary>
    Private Function HoldOutputConnection(ip As String, sec As Integer) As Integer
        Log($"[출력-HOLD] {ip} Exclusive Owner 유지, 출력=00 00 00 00, {sec}초 — BF GREEN 유지용")
        Try
            Dim c As New EEIPClient()
            c.IPAddress = ip
            c.RegisterSession()
            c.AssemblyObjectClass = &H4
            c.ConfigurationAssemblyInstanceID = &H66
            c.SetAttributeSingle(&H4, &H66, 3, New Byte() {&H0, &H0})
            Log($"  Config 0x66={Hex(c.GetAttributeSingle(&H4, &H66, 3))}")
            c.T_O_InstanceID = &H65US : c.T_O_Length = 10US
            c.O_T_InstanceID = &H64US : c.O_T_Length = 4US
            c.RequestedPacketRate_O_T = 20000UI : c.RequestedPacketRate_T_O = 20000UI
            c.O_T_RealTimeFormat = RealTimeFormat.Header32Bit
            c.O_T_ConnectionType = ConnectionType.Point_to_Point
            c.T_O_RealTimeFormat = RealTimeFormat.Modeless
            c.T_O_ConnectionType = ConnectionType.Multicast
            c.O_T_Priority = Priority.Scheduled : c.T_O_Priority = Priority.Scheduled
            c.O_T_OwnerRedundant = False : c.T_O_OwnerRedundant = False
            c.O_T_VariableLength = False : c.T_O_VariableLength = False
            c.ForwardOpen()
            Log("  ForwardOpen OK (출력 OFF 유지)")

            Dim ob As Byte() = c.O_T_IOData
            If ob IsNot Nothing Then
                For i As Integer = 0 To Math.Min(3, ob.Length - 1)
                    ob(i) = 0
                Next
                c.O_T_IOData = ob
            End If

            Dim deadline As DateTime = DateTime.Now.AddSeconds(sec)
            While DateTime.Now < deadline
                Thread.Sleep(1000)
            End While

            If ob IsNot Nothing Then
                For i As Integer = 0 To Math.Min(3, ob.Length - 1)
                    ob(i) = 0
                Next
                c.O_T_IOData = ob
            End If
            Thread.Sleep(300)
            c.ForwardClose() : c.UnRegisterSession()
            Log("  HOLD 종료")
            Return 0
        Catch ex As Exception
            Log($"[출력-HOLD 실패] {ex.Message}")
            Return 1
        End Try
    End Function

    Private Function OutTest(ip As String, offset As Integer, val As Byte, sec As Integer) As Integer
        Log($"[OUT확인] {ip} O_T_IOData[{offset}]=0x{val:X2} 를 {sec}초 유지 — 출력보드 Q LED 보세요")
        Try
            Dim c As New EEIPClient()
            OpenIoEx(c, ip, &H65US, 10US, &H64US, 4US, RealTimeFormat.Header32Bit, ConnectionType.Point_to_Point, "OUT")
            Dim ob As Byte() = c.O_T_IOData
            Log($"  O_T_IOData len={If(ob Is Nothing, -1, ob.Length)}")
            If ob IsNot Nothing AndAlso ob.Length > offset Then
                ob(offset) = val
                c.O_T_IOData = ob
                Log($"  → [{offset}]=0x{val:X2} 적용, {sec}초 대기")
                Thread.Sleep(sec * 1000)
                ob(offset) = 0
                c.O_T_IOData = ob
                Thread.Sleep(300)
            End If
            c.ForwardClose() : c.UnRegisterSession()
            Log("  완료 — 어느 Q가 켜졌는지 알려주세요 (offset 확정용)")
            Return 0
        Catch ex As Exception
            Log($"[OUT확인 실패] {ex.Message}")
            Return 1
        End Try
    End Function

    ''' <summary>파라미터 명시 Class1 ForwardOpen (진단용)</summary>
    Private Sub OpenIoEx(client As EEIPClient, ip As String, toInst As UShort, toLen As UShort,
                         otInst As UShort, otLen As UShort, otFmt As RealTimeFormat, otType As ConnectionType, label As String)
        client.IPAddress = ip
        client.RegisterSession()
        client.SetAttributeSingle(&H4, &H66, 3, New Byte() {&H6, &H0})
        Log($"  [{label}] {ip} Config 0x66={Hex(client.GetAttributeSingle(&H4, &H66, 3))}")
        client.AssemblyObjectClass = &H4
        client.ConfigurationAssemblyInstanceID = &H66
        client.T_O_InstanceID = toInst : client.T_O_Length = toLen
        client.O_T_InstanceID = otInst : client.O_T_Length = otLen
        client.RequestedPacketRate_O_T = 20000UI : client.RequestedPacketRate_T_O = 20000UI
        client.O_T_RealTimeFormat = otFmt : client.O_T_ConnectionType = otType
        client.T_O_RealTimeFormat = RealTimeFormat.Modeless : client.T_O_ConnectionType = ConnectionType.Point_to_Point
        client.O_T_Priority = Priority.Scheduled : client.T_O_Priority = Priority.Scheduled
        client.O_T_OwnerRedundant = False : client.T_O_OwnerRedundant = False
        client.O_T_VariableLength = False : client.T_O_VariableLength = False
        client.ForwardOpen()
        Log($"  [{label}] {ip} ForwardOpen OK")
    End Sub

    ' ===== 헬퍼 =====
    Private Sub Log(msg As String)
        Dim line As String = $"{DateTime.Now:HH:mm:ss} {msg}"
        Console.WriteLine(line)
        Try : File.AppendAllText(LogPath, line & Environment.NewLine, Encoding.UTF8) : Catch : End Try
    End Sub

    Private Function DetectServerIp() As String
        For Each ni In NetworkInterface.GetAllNetworkInterfaces()
            For Each ua In ni.GetIPProperties().UnicastAddresses
                If ua.Address.AddressFamily = AddressFamily.InterNetwork Then
                    Dim s As String = ua.Address.ToString()
                    If s.StartsWith("192.168.250.") Then Return s
                End If
            Next
        Next
        Return "192.168.250.1"
    End Function

    Private Function ParseDhcpMsgType(p() As Byte, len As Integer) As Integer
        If len < 240 OrElse p(236) <> &H63 OrElse p(237) <> &H82 Then Return -1
        Dim i As Integer = 240
        While i < len
            Dim opt As Integer = p(i)
            If opt = 255 Then Exit While
            If opt = 0 Then i += 1 : Continue While
            If i + 1 >= len Then Exit While
            Dim l As Integer = p(i + 1)
            If opt = 53 AndAlso l >= 1 Then Return p(i + 2)
            i += 2 + l
        End While
        Return -1
    End Function

    Private Function DhcpName(t As Integer) As String
        Select Case t
            Case 1 : Return "DISCOVER"
            Case 2 : Return "OFFER"
            Case 3 : Return "REQUEST"
            Case 5 : Return "ACK"
            Case -1 : Return "BOOTP"
            Case Else : Return "type" & t
        End Select
    End Function

    Private Function MacHex(p() As Byte, off As Integer) As String
        Return String.Join(":", Enumerable.Range(0, 6).Select(Function(k) p(off + k).ToString("X2")))
    End Function

    Private Sub CopyIp(buf() As Byte, off As Integer, ip As String)
        Array.Copy(IpBytes(ip), 0, buf, off, 4)   ' network order (a,b,c,d)
    End Sub

    Private Function IpBytes(ip As String) As Byte()
        Return IPAddress.Parse(ip).GetAddressBytes()
    End Function

    ''' <summary>CIP UDINT little-endian(z,y,x,w)로 IP 기록</summary>
    Private Sub PutIpLE(buf() As Byte, off As Integer, ip As String)
        Dim p() As String = ip.Split("."c)
        buf(off + 0) = CByte(CInt(p(3)))
        buf(off + 1) = CByte(CInt(p(2)))
        buf(off + 2) = CByte(CInt(p(1)))
        buf(off + 3) = CByte(CInt(p(0)))
    End Sub

    ''' <summary>CIP UDINT little-endian 4byte → IP 문자열</summary>
    Private Function IpFromLE(b() As Byte, off As Integer) As String
        If b Is Nothing OrElse b.Length < off + 4 Then Return "?"
        Return $"{b(off + 3)}.{b(off + 2)}.{b(off + 1)}.{b(off + 0)}"
    End Function

    Private Function ShortString(b() As Byte) As String
        If b Is Nothing OrElse b.Length = 0 Then Return ""
        Dim startIdx As Integer = 0, count As Integer = b.Length
        If b(0) = b.Length - 1 Then startIdx = 1 : count = b.Length - 1   ' SHORT_STRING len 프리픽스
        Return Encoding.ASCII.GetString(b, startIdx, count).Trim(ChrW(0), " "c)
    End Function

    Private Function ToU16(b() As Byte) As Integer
        If b Is Nothing OrElse b.Length < 2 Then Return 0
        Return b(0) Or (b(1) << 8)
    End Function

    Private Function ToU32(b() As Byte) As UInteger
        If b Is Nothing OrElse b.Length < 4 Then Return 0UI
        Return CUInt(b(0)) Or (CUInt(b(1)) << 8) Or (CUInt(b(2)) << 16) Or (CUInt(b(3)) << 24)
    End Function

    Private Function Hex(b() As Byte) As String
        Return String.Join(" ", b.Select(Function(x) x.ToString("X2")))
    End Function

End Module
