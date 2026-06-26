' 제품 고정 시퀀스 — 핀전진+클램프 동시 / 언클램프 → 핀후진 (1·2번 지그 병행)
' OUT:00~05 = 1번 지그, OUT:06~11 = 2번 지그
' ★ 추후: 지그 회전(IN:07/08) 또는 전용 DI로 GetActiveJigs() 1/2 선택 예정 — 현재 1·2번 항상 동시
' 지그 업/다운: 공정(wStep 3.2/3.6) + Reset 원위치복귀·Start 원위치검사
'
' === I/O 위치 확인 원칙 (전장) ===
' OUT 구동 → 대응 IN 센서 ON = 물리적으로 해당 위치 도달.
' 시퀀스는 OUT ON 후 IN 확인까지 완료해야 다음 단계 진행.
'
' OUT → IN 대응 (FBEI 채널, IoMap 핀표기):
'   핀전진 OUT:00/06  → IN:03/09 전진센서
'   핀후진 OUT:01/07  → IN:04/10 후진센서
'   클램프   OUT:02/08  → IN:05/11 클램프센서
'   언클램프 OUT:03/09  → IN:06/12 언클램프센서
'   지그다운 OUT:10     → IN:13 다운센서
'   지그업   OUT:11     → IN:14 업센서
'   (지그회전 OUT:04/05 → IN:07/08 — 원위치검사만, 공정 미연동)
'
' 센서 미장착/고장 시 SetSensorRequired(핀번호, False) 로 우회(정비 후 True 복구).
Module JigClampSequence

    ''' <summary>구버전 1번만 사용 — GetActiveJigs() 사용</summary>
    <Obsolete("GetActiveJigs() 사용 — 현재 1·2번 동시")>
    Public Const ActiveJigStation As Integer = 1
    Public Const SensorBypassSettleTicks As Integer = 30  ' 센서 우회 시 3초 안정 대기

    ''' <summary>동시 구동 대상 지그 — 추후 IN:07/08·전용 DI로 1만/2만 선택 예정</summary>
    Public Function GetActiveJigs() As Integer()
        Return New Integer() {1, 2}
    End Function

    ' IN 핀별 필수 여부 (0-base, True=IN 확인 필수, False=우회·타이머만)
    Private _sensorRequired(31) As Boolean
    Private _sensorInitDone As Boolean = False

    Private Enum SeqMode
        Idle
        Clamp
        Release
        Homing
        JigDown
        JigUp
        JigRotate
    End Enum

    Private Enum SeqPhase
        None
        PinClampOn
        WaitPinClamp
        UnclampOn
        WaitUnclamp
        UnclampOff
        WaitPinBack
        JigDownOn
        WaitJigDown
        WaitJigUp
        Done
    End Enum

    ' Reset 원위치: ①지그업(필수) → ②언클램프 → ③핀후진 (제품 손상 방지)
    Private Enum HomingStage
        JigLift
        Jig1Release
        Jig2Release
        Verify
    End Enum

    Private _mode As SeqMode = SeqMode.Idle
    Private _phase As SeqPhase = SeqPhase.None
    Private _ticks As Integer
    Private _runJig As Integer = 1
    Private _homingStage As HomingStage = HomingStage.JigLift
    Private _phaseTicks As Integer = 0    ' 현재 동작 센서 대기 누적 tick

    Private Sub EnsureSensorConfig()
        If _sensorInitDone Then Return
        For pin As Integer = 0 To 31
            _sensorRequired(pin) = IsMotionSensorPin(pin)
        Next
        _sensorInitDone = True
    End Sub

    ''' <summary>동작 위치 확인 IN 핀 (0-base, 스위치·에어툴 제외)</summary>
    Private Function IsMotionSensorPin(pin As Integer) As Boolean
        Select Case pin
            Case 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
                Return True
            Case Else
                Return False
        End Select
    End Function

    ''' <summary>센서 필수 여부 — False 시 OUT만 구동·타이머 후 진행(정비 전 임시)</summary>
    Public Sub SetSensorRequired(inPin As Integer, required As Boolean)
        EnsureSensorConfig()
        If inPin < 0 OrElse inPin > 31 Then Return
        _sensorRequired(inPin) = required
    End Sub

    Public Function IsSensorRequired(inPin As Integer) As Boolean
        EnsureSensorConfig()
        If inPin < 0 OrElse inPin > 31 Then Return True
        Return _sensorRequired(inPin)
    End Function

    ''' <summary>모든 동작 IN 센서 필수(우회 해제) — 현장 센서 정상 시 Form_Load에서 호출</summary>
    Public Sub EnableAllMotionSensors()
        EnsureSensorConfig()
        For pin As Integer = 0 To 31
            If IsMotionSensorPin(pin) Then _sensorRequired(pin) = True
        Next
    End Sub

    ''' <summary>지그 다운 위치: IN:13 ON + IN:14 OFF</summary>
    Public Function IsJigAtDown(ios As FbeiIoClient) As Boolean
        If ios Is Nothing Then Return False
        Return IoMap.GetIn(ios, InJigDown) AndAlso Not IoMap.GetIn(ios, InJigUp)
    End Function

    ''' <summary>지그 업 위치: IN:14 ON + IN:13 OFF</summary>
    Public Function IsJigAtUp(ios As FbeiIoClient) As Boolean
        If ios Is Nothing Then Return False
        Return IoMap.GetIn(ios, InJigUp) AndAlso Not IoMap.GetIn(ios, InJigDown)
    End Function

    Public Function OutPinForward(jig As Integer) As Integer
        Return If(jig = 1, 0, 6)
    End Function

    Public Function OutPinBack(jig As Integer) As Integer
        Return If(jig = 1, 1, 7)
    End Function

    Public Function OutClamp(jig As Integer) As Integer
        Return If(jig = 1, 2, 8)
    End Function

    Public Function OutUnclamp(jig As Integer) As Integer
        Return If(jig = 1, 3, 9)
    End Function

    Public Const OutJigDown As Integer = 10
    Public Const OutJigUp As Integer = 11

    Public Function InPinForward(jig As Integer) As Integer
        Return If(jig = 1, 3, 9)
    End Function

    Public Function InPinBack(jig As Integer) As Integer
        Return If(jig = 1, 4, 10)
    End Function

    Public Function InClamp(jig As Integer) As Integer
        Return If(jig = 1, 5, 11)
    End Function

    Public Function InUnclamp(jig As Integer) As Integer
        Return If(jig = 1, 6, 12)
    End Function

    Public Const InJigRotClamp As Integer = 7
    Public Const InJigRotUnclamp As Integer = 8
    Public Const InJigDown As Integer = 13
    Public Const InJigUp As Integer = 14

    Public Function IsHomePosition(ios As FbeiIoClient) As Boolean
        Return GetHomePositionFault(ios) = ""
    End Function

    Public Function GetHomePositionFault(ios As FbeiIoClient) As String
        If ios Is Nothing Then Return "IO 보드 미연결"
        If Not IoMap.GetIn(ios, InPinBack(1)) Then Return "1번 핀후진 센서(IN:04) — 원위치 아님"
        If IsSensorRequired(InUnclamp(1)) AndAlso Not IoMap.GetIn(ios, InUnclamp(1)) Then Return "1번 언클램프 센서(IN:06) — 원위치 아님"
        If Not IoMap.GetIn(ios, InJigRotClamp) Then Return "지그회전 클램프 센서(IN:07) — 원위치 아님"
        If Not IoMap.GetIn(ios, InPinBack(2)) Then Return "2번 핀후진 센서(IN:10) — 원위치 아님"
        If IsSensorRequired(InUnclamp(2)) AndAlso Not IoMap.GetIn(ios, InUnclamp(2)) Then Return "2번 언클램프 센서(IN:12) — 원위치 아님"
        If Not IoMap.GetIn(ios, InJigUp) Then Return "지그 업 센서(IN:14) — 원위치 아님 (지그 업=원위치)"
        If IoMap.GetIn(ios, InJigDown) Then Return "지그 다운 센서(IN:13) ON — 원위치 아님"
        If IoMap.GetIn(ios, InPinForward(1)) Then Return "1번 핀전진 센서(IN:03) ON — 원위치 아님"
        If IsSensorRequired(InClamp(1)) AndAlso IoMap.GetIn(ios, InClamp(1)) Then Return "1번 클램프 센서(IN:05) ON — 원위치 아님"
        If IoMap.GetIn(ios, InJigRotUnclamp) Then Return "지그회전 언클램프 센서(IN:08) ON — 원위치 아님"
        If IoMap.GetIn(ios, InPinForward(2)) Then Return "2번 핀전진 센서(IN:09) ON — 원위치 아님"
        If IsSensorRequired(InClamp(2)) AndAlso IoMap.GetIn(ios, InClamp(2)) Then Return "2번 클램프 센서(IN:11) ON — 원위치 아님"
        Return ""
    End Function

    Private Function NeedsProductHome(ios As FbeiIoClient, jig As Integer) As Boolean
        If IsSensorRequired(InClamp(jig)) AndAlso IoMap.GetIn(ios, InClamp(jig)) Then Return True
        If IsSensorRequired(InPinForward(jig)) AndAlso IoMap.GetIn(ios, InPinForward(jig)) Then Return True
        If IsSensorRequired(InPinBack(jig)) AndAlso Not IoMap.GetIn(ios, InPinBack(jig)) Then Return True
        If IsSensorRequired(InUnclamp(jig)) AndAlso Not IoMap.GetIn(ios, InUnclamp(jig)) Then Return True
        Return False
    End Function

    Public ReadOnly Property IsBusy As Boolean
        Get
            Return _mode <> SeqMode.Idle
        End Get
    End Property

    Public ReadOnly Property IsHoming As Boolean
        Get
            Return _mode = SeqMode.Homing
        End Get
    End Property

    ''' <summary>Reset 호밍 단계 (시스템 정보 rStep 표시용)</summary>
    Public ReadOnly Property CurrentHomingStage As String
        Get
            Select Case _homingStage
                Case HomingStage.JigLift : Return "지그업"
                Case HomingStage.Jig1Release : Return "1번해제"
                Case HomingStage.Jig2Release : Return "2번해제"
                Case HomingStage.Verify : Return "원위치확인"
                Case Else : Return "-"
            End Select
        End Get
    End Property

    ''' <summary>지그 회전 — I/O 미연동 시 즉시 COMPLETE (추후 OUT:04/05·IN:07/08 연결)</summary>
    Public Sub BeginJigRotate()
        EnsureSensorConfig()
        _mode = SeqMode.JigRotate
        _phase = SeqPhase.None
        _ticks = 0
        _phaseTicks = 0
        WriteJigLog(0, "지그 회전 대기 (I/O 추후 연동 — placeholder)")
    End Sub

    Public Sub BeginClamp()
        EnsureSensorConfig()
        _mode = SeqMode.Clamp
        _phase = SeqPhase.PinClampOn
        _ticks = 0
        _phaseTicks = 0
    End Sub

    Public Sub BeginRelease()
        EnsureSensorConfig()
        _mode = SeqMode.Release
        _phase = SeqPhase.UnclampOn
        _ticks = 0
        _phaseTicks = 0
    End Sub

    Public Sub BeginHoming()
        _mode = SeqMode.Homing
        _homingStage = HomingStage.JigLift
        _phase = SeqPhase.None
        _ticks = 0
        _phaseTicks = 0
        WriteJigLog(0, "원위치 복귀 시작 (①지그업 → ②언클램프 → ③핀후진)")
    End Sub

    Public Sub BeginJigDown()
        EnsureSensorConfig()
        _mode = SeqMode.JigDown
        _phase = SeqPhase.JigDownOn
        _ticks = 0
        WriteJigLog(0, "지그 다운 시퀀스 시작")
    End Sub

    Public Sub BeginJigUp()
        EnsureSensorConfig()
        _mode = SeqMode.JigUp
        _phase = SeqPhase.None
        _ticks = 0
        WriteJigLog(0, "지그 업 시퀀스 시작")
    End Sub

    Public Sub Abort()
        _mode = SeqMode.Idle
        _phase = SeqPhase.None
        _ticks = 0
    End Sub

    Public Function Tick(ios As FbeiIoClient) As String
        If ios Is Nothing Then Return "DISCONNECTED"
        If _mode = SeqMode.Idle Then Return "IDLE"

        _ticks += 1

        Select Case _mode
            Case SeqMode.Clamp
                TickClampDual(ios)
            Case SeqMode.Release
                TickReleaseDual(ios)
            Case SeqMode.Homing
                TickHoming(ios)
                If _mode = SeqMode.Idle Then Return "COMPLETE"
            Case SeqMode.JigDown
                TickJigDown(ios)
            Case SeqMode.JigUp
                TickJigUp(ios)
            Case SeqMode.JigRotate
                TickJigRotate(ios)
        End Select

        If _phase = SeqPhase.Done Then
            _mode = SeqMode.Idle
            _phase = SeqPhase.None
            Return "COMPLETE"
        End If

        Return "RUNNING"
    End Function

    ' OUT 구동 후 IN 위치확인: 0=대기, 1=OK
    ' oppositePin>=0 이면 반대 센서 상태도 확인 (지그 업/다운 등 상호배타 위치)
    Private Function TickWaitForPosition(ios As FbeiIoClient, inPin As Integer, expectOn As Boolean,
                                         motionName As String, outPin As Integer, jig As Integer,
                                         Optional oppositePin As Integer = -1, Optional oppositeExpectOn As Boolean = False) As Integer
        If Not IsSensorRequired(inPin) Then
            _phaseTicks += 1
            If _phaseTicks = 1 Then
                WriteJigLog(jig, $"{motionName} — {IoMap.InLabel(inPin)} 센서 우회(미장착/고장), {SensorBypassSettleTicks * 100}ms 후 진행")
            End If
            If _phaseTicks >= SensorBypassSettleTicks Then Return 1
            Return 0
        End If

        If IoMap.GetIn(ios, inPin) = expectOn Then
            If oppositePin >= 0 AndAlso IoMap.GetIn(ios, oppositePin) <> oppositeExpectOn Then
                Return 0
            End If
            LogArrival(jig, motionName, inPin)
            Return 1
        End If

        Return 0
    End Function

    Private Sub StartMotion()
        _phaseTicks = 0
    End Sub

    Private Function TickHoming(ios As FbeiIoClient) As String
        Select Case _homingStage
            Case HomingStage.JigLift
                IoMap.SetOut(ios, OutJigDown, False)
                If IoMap.GetIn(ios, InJigUp) Then
                    IoMap.SetOut(ios, OutJigUp, False)
                    LogArrival(0, "지그 업", InJigUp)
                    _homingStage = HomingStage.Jig1Release
                    _phase = SeqPhase.None
                    StartMotion()
                ElseIf _phase = SeqPhase.None Then
                    IoMap.SetOut(ios, OutJigUp, True)
                    LogMoveOut(0, "지그 업", OutJigUp, InJigUp)
                    _phase = SeqPhase.WaitJigUp
                    StartMotion()
                Else
                    TickWaitForPosition(ios, InJigUp, True, "지그 업", OutJigUp, 0, InJigDown, False)
                End If

            Case HomingStage.Jig1Release
                Dim st As Integer = AdvanceHomingRelease(ios, 1)
                If st = 1 Then _homingStage = HomingStage.Jig2Release

            Case HomingStage.Jig2Release
                Dim st As Integer = AdvanceHomingRelease(ios, 2)
                If st = 1 Then
                    _homingStage = HomingStage.Verify
                    _phase = SeqPhase.None
                    _phaseTicks = 0
                End If

            Case HomingStage.Verify
                If IsHomePosition(ios) Then
                    AllMotionOutputsOff(ios)
                    WriteJigLog(0, "원위치 복귀 완료")
                    _mode = SeqMode.Idle
                    _phase = SeqPhase.None
                ElseIf _phaseTicks = 0 Then
                    WriteJigLog(0, "원위치 대기 — " & GetHomePositionFault(ios))
                    _phaseTicks = 1
                End If
        End Select
        Return ""
    End Function

    Private Function AdvanceHomingRelease(ios As FbeiIoClient, jig As Integer) As Integer
        If Not NeedsProductHome(ios, jig) Then
            WriteJigLog(jig, "핀후진·언클램프 OK — 생략")
            Return 1
        End If
        If _phase = SeqPhase.None Then
            _runJig = jig
            _phase = SeqPhase.UnclampOn
            StartMotion()
            WriteJigLog(jig, "② 언클램프 → ③ 핀후진 (제품 보호 순서)")
            Return 0
        End If
        TickHomingRelease(ios, jig)
        If _phase = SeqPhase.Done Then
            _phase = SeqPhase.None
            Return 1
        End If
        Return 0
    End Function

    Private Sub TickHomingRelease(ios As FbeiIoClient, jig As Integer)
        Select Case _phase
            Case SeqPhase.UnclampOn
                IoMap.SetOut(ios, OutClamp(jig), False)
                IoMap.SetOut(ios, OutUnclamp(jig), True)
                LogMoveOut(jig, $"{jig}번 언클램프", OutUnclamp(jig), InUnclamp(jig))
                _phase = SeqPhase.WaitUnclamp
                StartMotion()

            Case SeqPhase.WaitUnclamp
                Dim ru As Integer = TickWaitForPosition(ios, InUnclamp(jig), True, $"{jig}번 언클램프", OutUnclamp(jig), jig)
                If ru = 1 Then
                    _phase = SeqPhase.UnclampOff
                    StartMotion()
                End If

            Case SeqPhase.UnclampOff
                IoMap.SetOut(ios, OutUnclamp(jig), False)
                IoMap.SetOut(ios, OutPinForward(jig), False)
                IoMap.SetOut(ios, OutPinBack(jig), True)
                LogMoveOut(jig, $"{jig}번 핀후진", OutPinBack(jig), InPinBack(jig))
                _phase = SeqPhase.WaitPinBack
                StartMotion()

            Case SeqPhase.WaitPinBack
                Dim rb As Integer = TickWaitForPosition(ios, InPinBack(jig), True, $"{jig}번 핀후진", OutPinBack(jig), jig, InPinForward(jig), False)
                If rb = 1 Then
                    IoMap.SetOut(ios, OutPinBack(jig), False)
                    _phase = SeqPhase.Done
                End If
        End Select
    End Sub

    Private Sub TickJigDown(ios As FbeiIoClient)
        Select Case _phase
            Case SeqPhase.JigDownOn
                IoMap.SetOut(ios, OutJigUp, False)
                IoMap.SetOut(ios, OutJigDown, True)
                LogMoveOut(0, "지그 다운", OutJigDown, InJigDown)
                _phase = SeqPhase.WaitJigDown
                StartMotion()

            Case SeqPhase.WaitJigDown
                Dim rd As Integer = TickWaitForPosition(ios, InJigDown, True, "지그 다운", OutJigDown, 0, InJigUp, False)
                If rd = 1 Then _phase = SeqPhase.Done
        End Select
    End Sub

    Private Sub TickJigRotate(ios As FbeiIoClient)
        _phaseTicks += 1
        If _phaseTicks = 1 Then
            WriteJigLog(0, "지그 회전 placeholder 완료 (실 I/O 미구동)")
            _phase = SeqPhase.Done
        End If
    End Sub

    Private Sub TickJigUp(ios As FbeiIoClient)
        Select Case _phase
            Case SeqPhase.None
                IoMap.SetOut(ios, OutJigDown, False)
                IoMap.SetOut(ios, OutJigUp, True)
                LogMoveOut(0, "지그 업", OutJigUp, InJigUp)
                _phase = SeqPhase.WaitJigUp
                StartMotion()

            Case SeqPhase.WaitJigUp
                Dim ru As Integer = TickWaitForPosition(ios, InJigUp, True, "지그 업", OutJigUp, 0, InJigDown, False)
                If ru = 1 Then
                    IoMap.SetOut(ios, OutJigUp, False)
                    _phase = SeqPhase.Done
                End If
        End Select
    End Sub

    ''' <summary>1·2번 지그 핀전진+클램프 동시 구동·센서 확인</summary>
    Private Sub TickClampDual(ios As FbeiIoClient)
        Select Case _phase
            Case SeqPhase.PinClampOn
                For Each jig As Integer In GetActiveJigs()
                    SafeOff(ios, jig, clamp:=False, unclamp:=False, pinBack:=False)
                    IoMap.SetOut(ios, OutPinForward(jig), True)
                    IoMap.SetOut(ios, OutClamp(jig), True)
                Next
                WriteJigDualLog("1·2번 핀전진+클램프 동시 출력 — OUT:00,02,06,08 → IN:03,05,09,11 대기")
                _phase = SeqPhase.WaitPinClamp
                StartMotion()

            Case SeqPhase.WaitPinClamp
                If TickWaitDualPinClamp(ios) = 1 Then _phase = SeqPhase.Done
        End Select
    End Sub

    ''' <summary>1·2번 지그 언클램프 → 핀후진 동시 구동·센서 확인</summary>
    Private Sub TickReleaseDual(ios As FbeiIoClient)
        Select Case _phase
            Case SeqPhase.UnclampOn
                For Each jig As Integer In GetActiveJigs()
                    IoMap.SetOut(ios, OutClamp(jig), False)
                    IoMap.SetOut(ios, OutUnclamp(jig), True)
                Next
                WriteJigDualLog("1·2번 언클램프 동시 출력 — OUT:03,09 → IN:06,12 대기")
                _phase = SeqPhase.WaitUnclamp
                StartMotion()

            Case SeqPhase.WaitUnclamp
                If TickWaitDualUnclamp(ios) = 1 Then
                    _phase = SeqPhase.UnclampOff
                    StartMotion()
                End If

            Case SeqPhase.UnclampOff
                For Each jig As Integer In GetActiveJigs()
                    IoMap.SetOut(ios, OutUnclamp(jig), False)
                    IoMap.SetOut(ios, OutPinForward(jig), False)
                    IoMap.SetOut(ios, OutPinBack(jig), True)
                Next
                WriteJigDualLog("1·2번 핀후진 동시 출력 — OUT:01,07 → IN:04,10 대기")
                _phase = SeqPhase.WaitPinBack
                StartMotion()

            Case SeqPhase.WaitPinBack
                If TickWaitDualPinBack(ios) = 1 Then
                    For Each jig As Integer In GetActiveJigs()
                        IoMap.SetOut(ios, OutPinBack(jig), False)
                    Next
                    _phase = SeqPhase.Done
                End If
        End Select
    End Sub

    Private Function TickWaitDualPinClamp(ios As FbeiIoClient) As Integer
        Dim anyRequired As Boolean = False
        For Each jig As Integer In GetActiveJigs()
            If IsSensorRequired(InPinForward(jig)) OrElse IsSensorRequired(InClamp(jig)) Then
                anyRequired = True
                If IsSensorRequired(InPinForward(jig)) Then
                    If Not IoMap.GetIn(ios, InPinForward(jig)) Then Return 0
                    If IoMap.GetIn(ios, InPinBack(jig)) Then Return 0
                End If
                If IsSensorRequired(InClamp(jig)) Then
                    If Not IoMap.GetIn(ios, InClamp(jig)) Then Return 0
                End If
            End If
        Next

        If Not anyRequired Then
            _phaseTicks += 1
            If _phaseTicks = 1 Then
                WriteJigDualLog("핀·클램프 센서 우회 — " & CStr(SensorBypassSettleTicks * 100) & "ms 후 진행")
            End If
            If _phaseTicks >= SensorBypassSettleTicks Then Return 1
            Return 0
        End If

        If _phaseTicks = 0 Then
            For Each jig As Integer In GetActiveJigs()
                LogArrival(jig, $"{jig}번 핀전진", InPinForward(jig))
                LogArrival(jig, $"{jig}번 클램프", InClamp(jig))
            Next
        End If
        Return 1
    End Function

    Private Function TickWaitDualUnclamp(ios As FbeiIoClient) As Integer
        Dim anyRequired As Boolean = False
        For Each jig As Integer In GetActiveJigs()
            If IsSensorRequired(InUnclamp(jig)) Then
                anyRequired = True
                If Not IoMap.GetIn(ios, InUnclamp(jig)) Then Return 0
            End If
        Next

        If Not anyRequired Then
            _phaseTicks += 1
            If _phaseTicks >= SensorBypassSettleTicks Then Return 1
            Return 0
        End If

        If _phaseTicks = 0 Then
            For Each jig As Integer In GetActiveJigs()
                LogArrival(jig, $"{jig}번 언클램프", InUnclamp(jig))
            Next
        End If
        Return 1
    End Function

    Private Function TickWaitDualPinBack(ios As FbeiIoClient) As Integer
        Dim anyRequired As Boolean = False
        For Each jig As Integer In GetActiveJigs()
            If IsSensorRequired(InPinBack(jig)) OrElse IsSensorRequired(InPinForward(jig)) Then
                anyRequired = True
                If IsSensorRequired(InPinBack(jig)) Then
                    If Not IoMap.GetIn(ios, InPinBack(jig)) Then Return 0
                End If
                If IsSensorRequired(InPinForward(jig)) Then
                    If IoMap.GetIn(ios, InPinForward(jig)) Then Return 0
                End If
            End If
        Next

        If Not anyRequired Then
            _phaseTicks += 1
            If _phaseTicks >= SensorBypassSettleTicks Then Return 1
            Return 0
        End If

        If _phaseTicks = 0 Then
            For Each jig As Integer In GetActiveJigs()
                LogArrival(jig, $"{jig}번 핀후진", InPinBack(jig))
            Next
        End If
        Return 1
    End Function

    Public Sub AllOutputsOff(ios As FbeiIoClient, jig As Integer)
        If ios Is Nothing Then Return
        IoMap.SetOut(ios, OutPinForward(jig), False)
        IoMap.SetOut(ios, OutPinBack(jig), False)
        IoMap.SetOut(ios, OutClamp(jig), False)
        IoMap.SetOut(ios, OutUnclamp(jig), False)
    End Sub

    Public Sub AllMotionOutputsOff(ios As FbeiIoClient)
        If ios Is Nothing Then Return
        AllOutputsOff(ios, 1)
        AllOutputsOff(ios, 2)
        IoMap.SetOut(ios, OutJigUp, False)
        IoMap.SetOut(ios, OutJigDown, False)
    End Sub

    Private Sub SafeOff(ios As FbeiIoClient, jig As Integer, pinBack As Boolean, clamp As Boolean, unclamp As Boolean)
        IoMap.SetOut(ios, OutPinBack(jig), pinBack)
        IoMap.SetOut(ios, OutClamp(jig), clamp)
        IoMap.SetOut(ios, OutUnclamp(jig), unclamp)
    End Sub

    Public Event JigLog(message As String)

    Private Sub LogMoveOut(jig As Integer, action As String, outPin As Integer, waitInPin As Integer)
        WriteJigLog(jig, $"{action} 이동 신호 출력 — {IoMap.OutLabel(outPin)} → {IoMap.InLabel(waitInPin)} 대기")
    End Sub

    Private Sub LogArrival(jig As Integer, action As String, inPin As Integer)
        WriteJigLog(jig, $"{action} 도착 신호 수신 — {IoMap.InLabel(inPin)}")
    End Sub

    Private Sub WriteJigDualLog(detail As String)
        RaiseEvent JigLog($"[JIG] {detail}")
    End Sub

    Private Sub WriteJigLog(jig As Integer, detail As String)
        If jig > 0 Then
            RaiseEvent JigLog($"[JIG{jig}] {detail}")
        Else
            RaiseEvent JigLog($"[HOME] {detail}")
        End If
    End Sub

End Module
