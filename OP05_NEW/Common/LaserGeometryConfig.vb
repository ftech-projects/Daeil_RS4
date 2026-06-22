' Keyence IL 간거리(모델기준 - raw) 설치각 보정
' 상단 센서: 빔이 수평보다 위로 기울어짐 → 수평 간격 = Value × cos(θ)
' 하단 센서: 수평 설치 → Value 그대로 (선택 scale/offset)

Imports System.Collections.Generic
Imports System.IO
Imports System.Web.Script.Serialization

Public Class LaserGeometryConfig

    ''' <summary>상단 센서 피치 각도(°). 수평 기준 위로 +8° → cos(8°) 적용.</summary>
    Public Property UpperTiltDeg As Double = 8.0

    ''' <summary>하단 Value 보정 배율 (기본 1.0 = 보정 없음).</summary>
    Public Property LowerScale As Double = 1.0

    ''' <summary>하단 Value 보정 오프셋(mm).</summary>
    Public Property LowerOffsetMm As Double = 0.0

    ''' <summary>상단 cos(θ) 적용 후 추가 배율.</summary>
    Public Property UpperScaleAfterCos As Double = 1.0

    ''' <summary>상단 cos(θ) 적용 후 오프셋(mm).</summary>
    Public Property UpperOffsetMm As Double = 0.0

    ''' <summary>상단으로 취급할 mappingIndex (기본 0,1 = LeftUpper, RightUpper).</summary>
    Public Property UpperMappingIndices As Integer() = {0, 1}

    Public Shared Function LoadFromConfig(configPath As String) As LaserGeometryConfig
        Dim cfg As New LaserGeometryConfig()
        If Not File.Exists(configPath) Then Return cfg

        Try
            Dim json = File.ReadAllText(configPath)
            Dim root = CType(New JavaScriptSerializer().DeserializeObject(json), Dictionary(Of String, Object))
            If root Is Nothing OrElse Not root.ContainsKey("keyenceIl") Then Return cfg

            Dim kc = CType(root("keyenceIl"), Dictionary(Of String, Object))
            If kc.ContainsKey("geometryCorrection") Then
                Dim g = CType(kc("geometryCorrection"), Dictionary(Of String, Object))
                If g.ContainsKey("upperTiltDeg") Then cfg.UpperTiltDeg = Convert.ToDouble(g("upperTiltDeg"))
                If g.ContainsKey("lowerScale") Then cfg.LowerScale = Convert.ToDouble(g("lowerScale"))
                If g.ContainsKey("lowerOffsetMm") Then cfg.LowerOffsetMm = Convert.ToDouble(g("lowerOffsetMm"))
                If g.ContainsKey("upperScaleAfterCos") Then cfg.UpperScaleAfterCos = Convert.ToDouble(g("upperScaleAfterCos"))
                If g.ContainsKey("upperOffsetMm") Then cfg.UpperOffsetMm = Convert.ToDouble(g("upperOffsetMm"))
            End If
        Catch
        End Try

        Return cfg
    End Function

    Public Function IsUpperMapping(mappingIndex As Integer) As Boolean
        For Each idx As Integer In UpperMappingIndices
            If idx = mappingIndex Then Return True
        Next
        Return False
    End Function

    ''' <param name="gapMm">Keyence 간거리 = 모델기준거리 - raw (mm)</param>
    Public Function CorrectGapMm(mappingIndex As Integer, gapMm As Double) As Double
        If IsUpperMapping(mappingIndex) Then
            Dim rad = UpperTiltDeg * Math.PI / 180.0
            Return gapMm * Math.Cos(rad) * UpperScaleAfterCos + UpperOffsetMm
        End If
        Return gapMm * LowerScale + LowerOffsetMm
    End Function

End Class
