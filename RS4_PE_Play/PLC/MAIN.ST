(*==============================================================
  유격 검사기 메인 PLC 프로그램
  CPU: Q04UDEHCPU / 모션: QD77MS2 슬롯0 U1
  내부 플래그: M7000~M7007 (Q04 기본 M범위 내, 자동할당 범위 외)
  글로벌 라벨: gXA (BIT, 디바이스 XA) — 1개만 등록 필요
==============================================================*)

(*==============================================================
  1. 비상 감시  (X2 = 비상버튼 A접)
==============================================================*)
IF X2 THEN M7000 := TRUE; ELSE M7000 := FALSE; END_IF;

IF M7000 THEN
    U1\G1536 := 0;
    Y0 := FALSE;    Y1 := FALSE;
    Y2 := FALSE;    Y3 := FALSE;
END_IF;

(*==============================================================
  2. 입력 → D4000 워드 패킹
==============================================================*)
D4000 := 0;
IF X0        THEN D4000 := D4000 OR 16#0001; END_IF;
IF X1        THEN D4000 := D4000 OR 16#0002; END_IF;
IF NOT M7000 THEN D4000 := D4000 OR 16#0004; END_IF;
IF X3        THEN D4000 := D4000 OR 16#0008; END_IF;
IF X4        THEN D4000 := D4000 OR 16#0010; END_IF;
IF X5        THEN D4000 := D4000 OR 16#0020; END_IF;
IF X6        THEN D4000 := D4000 OR 16#0040; END_IF;
IF X7        THEN D4000 := D4000 OR 16#0080; END_IF;
IF X8        THEN D4000 := D4000 OR 16#0100; END_IF;

D4008 := D4008 AND 16#FF00;
IF X10  THEN D4008 := D4008 OR 16#0001; END_IF;
IF X9   THEN D4008 := D4008 OR 16#0002; END_IF;
IF gXA  THEN D4008 := D4008 OR 16#0004; END_IF;

(*==============================================================
  3. D4004 비트 읽기 → 물리 출력
==============================================================*)
IF NOT M7000 THEN
    IF (D4004 AND 16#0001) <> 0 THEN Y0 := TRUE; ELSE Y0 := FALSE; END_IF;
    IF (D4004 AND 16#0002) <> 0 THEN Y1 := TRUE; ELSE Y1 := FALSE; END_IF;
    IF (D4004 AND 16#0004) <> 0 THEN Y2 := TRUE; ELSE Y2 := FALSE; END_IF;
    IF (D4004 AND 16#0008) <> 0 THEN Y3 := TRUE; ELSE Y3 := FALSE; END_IF;
END_IF;

(*==============================================================
  4. 서보 제어
  M7001 = OPR 이전상태   M7002 = POS2 이전상태   M7003 = 에러리셋 이전상태
  M7004 = OPR 감시 중    M7005 = POS2 감시 중
  M7006 = JOG전진        M7007 = JOG후진
==============================================================*)
IF NOT M7000 THEN

    (* 4-1. 홈복귀  D4009.bit0 상승엣지 *)
    IF ((D4009 AND 16#0001) <> 0) AND (NOT M7001) THEN
        U1\G1536 := 0;
        M7004 := TRUE;
        M7005 := FALSE;
        D4008 := D4008 AND 16#FEFF;
    END_IF;
    IF M7004 THEN
        D9800 := U1\G52;
        IF (D9800 AND 16#0008) <> 0 THEN
            M7004 := FALSE;
            D4008 := D4008 OR 16#0100;
        END_IF;
    END_IF;
    IF (D4009 AND 16#0001) <> 0 THEN M7001 := TRUE; ELSE M7001 := FALSE; END_IF;

    (* 4-2. 대기위치 이동  D4009.bit4 상승엣지 *)
    IF ((D4009 AND 16#0010) <> 0) AND (NOT M7002) THEN
        U1\G1536 := 0;
        M7005 := TRUE;
        M7004 := FALSE;
        D4008 := D4008 AND 16#FDFF;
    END_IF;
    IF M7005 THEN
        D9800 := U1\G52;
        IF (D9800 AND 16#0010) <> 0 THEN
            M7005 := FALSE;
            D4008 := D4008 OR 16#0200;
        END_IF;
    END_IF;
    IF (D4009 AND 16#0010) <> 0 THEN M7002 := TRUE; ELSE M7002 := FALSE; END_IF;

    (* 4-3. JOG  D4009.bit1=전진 / bit2=후진 *)
    IF ((D4009 AND 16#0002) <> 0) AND (NOT X9) THEN
        M7006 := TRUE;
    ELSE
        M7006 := FALSE;
    END_IF;
    IF ((D4009 AND 16#0004) <> 0) AND (NOT gXA) THEN
        M7007 := TRUE;
    ELSE
        M7007 := FALSE;
    END_IF;

    IF M7006 AND (NOT M7004) AND (NOT M7005) THEN
        U1\G1534 := D5004;
        U1\G1535 := 0;
        U1\G1536 := 1;
    ELSIF M7007 AND (NOT M7004) AND (NOT M7005) THEN
        U1\G1534 := D5004;
        U1\G1535 := 0;
        U1\G1536 := 2;
    ELSIF (NOT M7006) AND (NOT M7007) THEN
        U1\G1536 := 0;
    END_IF;

    (* 4-4. 에러 리셋  D4009.bit3 상승엣지 *)
    IF ((D4009 AND 16#0008) <> 0) AND (NOT M7003) THEN
        (* Y19 := TRUE; *)
    END_IF;
    IF (D4009 AND 16#0008) = 0 THEN
        (* Y19 := FALSE; *)
    END_IF;
    IF (D4009 AND 16#0008) <> 0 THEN M7003 := TRUE; ELSE M7003 := FALSE; END_IF;

END_IF;
