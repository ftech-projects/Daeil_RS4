' FBEI 입력/출력 ↔ PlcValue(D레지스터) — 핀번호 0-base, FBEI는 PinToChannel 경유

Module IoSignalMap



    Public ReadOnly SyncInputPins() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 31}



    Public Function InputPinToPlcReg(pin As Integer) As Integer

        Select Case pin

            Case IoMap.PinStart : Return 4000

            Case IoMap.PinReset : Return 0

            Case IoMap.PinEStop : Return 0

            Case 3 : Return 4004

            Case 4 : Return 4005

            Case 5 : Return 4006

            Case 6 : Return 4007

            Case 7 : Return 4008

            Case 8 : Return 4010

            Case 9 : Return 4011

            Case 10 : Return 4012

            Case 11 : Return 4013

            Case 12 : Return 4014

            Case 13 : Return 4015

            Case 14 : Return 4001

            Case IoMap.PinAirTool : Return 4002

            Case Else : Return 0

        End Select

    End Function



    Public Function InputChannelToPlcReg(channel As Integer) As Integer

        Return InputPinToPlcReg(IoMap.ChannelToPin(channel))

    End Function



    Public Function PlcRegToOutputPin(reg As Integer) As Integer

        Return -1

    End Function



    Public Sub SyncInputsToPlc(ios As FbeiIoClient)

        If ios Is Nothing Then Exit Sub

        For Each pin As Integer In SyncInputPins

            ApplyInputLevel(ios, pin)

        Next

    End Sub



    Public Sub ApplyInputLevel(ios As FbeiIoClient, pin As Integer)

        If ios Is Nothing Then Exit Sub

        Dim reg As Integer = InputPinToPlcReg(pin)

        If reg > 0 Then

            PlcValue(reg) = If(IoMap.GetIn(ios, pin), 1, 0)

        End If

    End Sub



    Public Sub ApplyInputChange(channel As Integer, value As Boolean)

        Dim reg As Integer = InputChannelToPlcReg(channel)

        If reg > 0 Then PlcValue(reg) = If(value, 1, 0)

    End Sub



    Public Sub ApplyPlcWrite(ios As FbeiIoClient, startReg As Integer, message As String)

        If message Is Nothing Then Exit Sub

        For i As Integer = 0 To message.Length - 1

            Dim reg As Integer = startReg + i

            Dim val As Integer = 0

            Integer.TryParse(message.Substring(i, 1), val)

            PlcValue(reg) = val

            Dim outPin As Integer = PlcRegToOutputPin(reg)

            If outPin >= 0 AndAlso ios IsNot Nothing Then

                IoMap.SetOut(ios, outPin, val <> 0)

            End If

        Next

    End Sub



End Module

