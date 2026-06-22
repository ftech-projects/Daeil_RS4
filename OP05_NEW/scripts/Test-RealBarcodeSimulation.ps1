# OP05 real server PartNo / Serial / process barcode simulation
# Mirrors FrmMain: LoadPArt, CheckBefore, Serial_Scanner_DataReceived, Tmr_Work

param(
    [string]$SqlServer = '192.168.0.222\Ftech_Svr',
    [string]$SqlCatalog = 'FTECH_SVR'
)

$ErrorActionPreference = 'Stop'
$connStr = "Provider=SQLOLEDB;Data Source=$SqlServer;Initial Catalog=$SqlCatalog;User ID=sa;Password=sns123.,;Connect Timeout=5"

function VbMid([string]$s, [int]$start, [int]$len) {
    if ([string]::IsNullOrEmpty($s)) { return '' }
    $idx = $start - 1
    if ($idx -ge $s.Length) { return '' }
    $take = [Math]::Min($len, $s.Length - $idx)
    return $s.Substring($idx, $take)
}

function Open-Sql {
    $c = New-Object -ComObject ADODB.Connection
    $c.Open($connStr)
    return $c
}

function Query-One($conn, [string]$sql) {
    $rs = New-Object -ComObject ADODB.Recordset
    $rs.Open($sql, $conn)
    if ($rs.EOF) { $rs.Close(); return $null }
    $row = @{}
    foreach ($f in $rs.Fields) { $row[$f.Name] = $f.Value }
    $rs.Close()
    return $row
}

function Simulate-LoadPart($conn, [string]$scan, [hashtable]$state) {
    $partKey = VbMid $scan 13 11
    $state.partKey = $partKey
    $state.partNoDisplay = VbMid $scan 13 14
    $state.partFound = $false

    $part = Query-One $conn "SELECT * FROM Table_Part WHERE PartNo = '$partKey'"
    if ($part) {
        $state.partFound = $true
        $state.partName = [string]$part.PartName
        $state.optionType = [string]$part.OptionType
        $state.optionLhRh = [string]($(if ($part.OptionLHRH) { $part.OptionLHRH } else { $part.OptionLhRh }))
        $toolRaw = [string]$part.Target_Op04_ToolNum
        $rivetRaw = [string]$part.Target_Op04_RivetNum
        $state.targetTool = if ([string]::IsNullOrWhiteSpace($toolRaw)) { 0 } else { [int]$toolRaw }
        $state.targetRivet = if ([string]::IsNullOrWhiteSpace($rivetRaw)) { 0 } else { [int]$rivetRaw }
        $suffix = if ($state.partNoDisplay.Length -ge 3) { $state.partNoDisplay.Substring($state.partNoDisplay.Length - 3) } else { '' }
        $coverLBase = [string]$part.Target_Op03_InsideCoverL
        $coverRBase = [string]$part.Target_Op03_InsideCoverR
        if ($coverLBase.Trim() -eq '0') { $state.coverLTarget = '0'; $state.coverLDec = 'NA' }
        else { $state.coverLTarget = ($coverLBase.Trim() + $suffix); $state.coverLDec = '' }
        if ($coverRBase.Trim() -eq '0') { $state.coverRTarget = '0'; $state.coverRDec = 'NA' }
        else { $state.coverRTarget = ($coverRBase.Trim() + $suffix); $state.coverRDec = '' }
    } else {
        $state.partName = ''
        $state.log += "[PART] unregistered partKey: $partKey"
    }
}

function Simulate-CheckBefore($conn, [string]$serial, [hashtable]$state, [bool]$flagBeforeCheck) {
    $state.check1 = 'INIT'
    $state.check2_1 = 'INIT'
    $state.check2_2 = 'INIT'
    $state.checkVip = 'INIT'
    $state.checkNoise = 'INIT'
    $state.beforeMainFound = $false

    if (-not $flagBeforeCheck) {
        $state.checkVip = 'NA'
        return
    }

    $main = Query-One $conn "SELECT * FROM Table_Main WHERE SerialNo = '$serial'"
    if (-not $main) {
        $state.log += '[CheckBefore] SerialNo not in Table_Main'
        return
    }
    $state.beforeMainFound = $true

    $map = @{
        check1 = 'Op01_Decision'
        check2_1 = 'Op02_1_Decision'
        check2_2 = 'Op02_2_Decision'
        checkVip = 'OpVip_Decision'
        checkNoise = 'OpTest_Decision'
    }
    foreach ($k in $map.Keys) {
        $val = [string]$main[$map[$k]]
        if ($val.Trim() -eq 'OK') { $state[$k] = 'OK' } else { $state[$k] = 'NG' }
    }

    if ($state.partName -notmatch 'VIP') { $state.checkVip = 'NA' }
}

function Test-BeforeOk([hashtable]$state) {
    return ($state.check1 -eq 'OK' -and $state.check2_1 -eq 'OK' -and $state.check2_2 -eq 'OK' -and
        ($state.checkVip -eq 'OK' -or $state.checkVip -eq 'NA') -and $state.checkNoise -eq 'OK')
}

function Simulate-ScanAtStep1($conn, [string]$scan, [bool]$flagBeforeCheck) {
    $state = @{ scan = $scan; log = @(); wStep = 1 }
    $state.scanLen = $scan.Length

    if ($state.scanLen -lt 23) {
        $state.result = 'IGNORED len under 23'
        $state.nextStep = 1
        return $state
    }

    Simulate-LoadPart $conn $scan $state
    Simulate-CheckBefore $conn $scan $state $flagBeforeCheck

    if ($flagBeforeCheck) {
        if (Test-BeforeOk $state) { $state.nextStep = 2; $state.result = 'PASS -> wStep 2' }
        else { $state.nextStep = 1.1; $state.result = 'BEFORE NG -> wStep 1.1' }
    } else {
        if ($state.partFound) { $state.nextStep = 2; $state.result = 'before-check OFF -> wStep 2' }
        else { $state.nextStep = 1; $state.result = 'part missing, stay wStep 1' }
    }
    return $state
}

function Simulate-ScanAtStep2Plus([string]$scan, [hashtable]$state) {
    if ($state.coverLTarget -ne '0' -and $scan.Contains($state.coverLTarget)) {
        $state.coverLDec = 'OK'
        return "CoverL OK target=$($state.coverLTarget)"
    }
    if ($state.coverRTarget -ne '0' -and $scan.Contains($state.coverRTarget)) {
        $state.coverRDec = 'OK'
        return "CoverR OK target=$($state.coverRTarget)"
    }
    return 'NG process/cover barcode mismatch'
}

function Step-Transition([double]$w, $i) {
    if ($i.plc4000 -eq 0 -and $w -ne 0) { return 0, 'reset' }
    if ($w -eq 0 -and $i.plc4000 -eq 1) { return 1, 'start' }
    if ($w -eq 1 -and $i.scanNextStep) { return [double]$i.scanNextStep, $i.scanMsg }
    if ($w -eq 1.1) { return 1, 'alarm to scan' }
    if ($w -eq 2) { return 2.1, 'options' }
    if ($w -eq 2.1) { return 3, 'plc option sent' }
    if ($w -eq 3 -and $i.plc4004 -eq 1) {
        if ($i.length_ok) { return 4, 'length OK' } else { return 3.1, 'length NG' }
    }
    if ($w -eq 3.1 -and $i.plc4004 -eq 0) { return 3, 'retry' }
    if ($w -eq 4 -and $i.assembly_ok) { return 5, 'assembly OK' }
    if ($w -eq 5) { return 6, 'wait complete' }
    if ($w -eq 6 -and $i.plc4001 -eq 1) { return 0, 'done' }
    return $w, 'hold'
}

function Run-FullScenario($title, $conn, [string]$serial, [bool]$flagBeforeCheck, [bool]$lengthOk, [bool]$assemblyOk) {
    Write-Host ""
    Write-Host "======== $title ========" -ForegroundColor Cyan
    $s1 = Simulate-ScanAtStep1 $conn $serial $flagBeforeCheck
    Write-Host ("Serial: {0} Len={1}" -f $s1.scan.Trim(), $s1.scanLen)
    Write-Host ("PartKey Mid13_11: {0} registered={1} name={2}" -f $s1.partKey, $s1.partFound, $s1.partName.Trim())
    if ($s1.partFound) {
        Write-Host ("Option: {0} {1} Tool={2} Rivet={3}" -f $s1.optionType.Trim(), $s1.optionLhRh.Trim(), $s1.targetTool, $s1.targetRivet)
        Write-Host ("CoverL={0} CoverR={1}" -f $s1.coverLTarget, $s1.coverRTarget)
    }
    Write-Host ("Before: Op01={0} Op02_1={1} Op02_2={2} VIP={3} Test={4}" -f $s1.check1, $s1.check2_1, $s1.check2_2, $s1.checkVip, $s1.checkNoise)
    Write-Host ("Scan wStep1: {0} next={1}" -f $s1.result, $s1.nextStep)
    foreach ($l in $s1.log) { Write-Host "  $l" -ForegroundColor DarkYellow }

    $w = 0.0
    $seq = @(
        @{ plc4000 = 1 },
        @{ plc4000 = 1; scanNextStep = $s1.nextStep; scanMsg = $s1.result }
    )
    if ($s1.nextStep -ge 2) {
        $seq += @(
            @{ plc4000 = 1 },
            @{ plc4000 = 1 },
            @{ plc4000 = 1; plc4004 = 1; length_ok = $lengthOk },
            @{ plc4000 = 1; assembly_ok = $assemblyOk },
            @{ plc4000 = 1 },
            @{ plc4000 = 1; plc4001 = 1 }
        )
    }
    Write-Host 'Sequence:'
    $i = 0
    foreach ($inp in $seq) {
        $i++
        $nw, $msg = Step-Transition $w $inp
        Write-Host ("  t{0}: wStep {1} -> {2} | {3}" -f $i, $w, $nw, $msg)
        $w = $nw
    }
    Write-Host ("Final wStep: {0}" -f $w) -ForegroundColor $(if ($w -eq 0) { 'Green' } else { 'Yellow' })
    return $s1
}

Write-Host '=== OP05 Real Barcode Simulation ===' -ForegroundColor Cyan
Write-Host (Get-Date -Format 'yyyy-MM-dd HH:mm:ss')

$conn = Open-Sql
try {
    $okSerial = (Query-One $conn "SELECT TOP 1 RTRIM(SerialNo) AS SerialNo FROM Table_Main WHERE Op01_Decision='OK' AND Op02_1_Decision='OK' AND Op02_2_Decision='OK' AND OpTest_Decision='OK' ORDER BY Op01_DATE DESC").SerialNo
    $ngTestSerial = (Query-One $conn "SELECT TOP 1 RTRIM(SerialNo) AS SerialNo FROM Table_Main WHERE OpTest_Decision='NG' ORDER BY Op01_DATE DESC").SerialNo
    $foldSerial = (Query-One $conn "SELECT TOP 1 RTRIM(SerialNo) AS SerialNo FROM Table_Main WHERE PartNo LIKE '88411-T4220%' AND OpTest_Decision='OK' ORDER BY Op01_DATE DESC").SerialNo
    $procRow = Query-One $conn "SELECT TOP 1 RTRIM(SerialNo) AS SerialNo, RTRIM(Op02_2_Sab1Barcode) AS Sab1, RTRIM(Op02_2_Sab2Barcode) AS Sab2, RTRIM(Op02_1_LsuptBarcode) AS Lsupt FROM Table_Main WHERE Op02_2_Sab1Barcode IS NOT NULL AND LEN(RTRIM(Op02_2_Sab1Barcode))>10 ORDER BY Op01_DATE DESC"

    Run-FullScenario 'A-Real OK serial full path' $conn $okSerial $true $true $true | Out-Null
    Run-FullScenario 'B-Real NG serial OpTest NG block' $conn $ngTestSerial $true $true $true | Out-Null
    if ($foldSerial) { Run-FullScenario 'C-FOLD part OK serial' $conn $foldSerial $true $true $true | Out-Null }

    Write-Host ""
    Write-Host '======== D-Process barcode Sab1 at wStep1 ========' -ForegroundColor Cyan
    $sab1 = [string]$procRow.Sab1
    $d = Simulate-ScanAtStep1 $conn $sab1 $true
    Write-Host ("Sab1 Len={0}" -f $sab1.Length)
    Write-Host ("Mid13_11={0} partRegistered={1}" -f $d.partKey, $d.partFound)
    Write-Host ("Table_Main hit={0}" -f $d.beforeMainFound)
    Write-Host ("Before: Op01={0} Op02_1={1} Op02_2={2} VIP={3} Test={4}" -f $d.check1, $d.check2_1, $d.check2_2, $d.checkVip, $d.checkNoise)
    Write-Host ("Result: {0}" -f $d.result)

    Write-Host ""
    Write-Host '======== E-Process barcode at wStep2 cover scan ========' -ForegroundColor Cyan
    $base = Simulate-ScanAtStep1 $conn $okSerial $true
    foreach ($label in @('Sab1','Sab2','Lsupt')) {
        $code = [string]$procRow[$label]
        if ([string]::IsNullOrWhiteSpace($code) -or $code -eq 'NA') { continue }
        Write-Host ("{0} Len={1}: {2}" -f $label, $code.Length, (Simulate-ScanAtStep2Plus $code $base))
    }
    Write-Host ("Valid CoverL: {0}" -f (Simulate-ScanAtStep2Plus ($base.coverLTarget + 'X') $base))
    Write-Host ("Valid CoverR: {0}" -f (Simulate-ScanAtStep2Plus ($base.coverRTarget + 'X') $base))

    Write-Host ""
    Write-Host '======== F-Fake unregistered part serial ========' -ForegroundColor Cyan
    $fake = '20260603999999999-T9999ZZZ'
    $f = Simulate-ScanAtStep1 $conn $fake $true
    Write-Host ("Fake serial: {0} partKey={1} registered={2} result={3}" -f $fake, $f.partKey, $f.partFound, $f.result)

    Write-Host ""
    Write-Host '======== G-88310-T4330 test serial ========' -ForegroundColor Cyan
    $t4330 = '20260603000188310-T4330NNB'
    $g = Simulate-ScanAtStep1 $conn $t4330 $true
    Write-Host ("Serial: {0} Len={1}" -f $t4330, $g.scanLen)
    Write-Host ("PartKey={0} registered={1}" -f $g.partKey, $g.partFound)
    Write-Host ("PartName={0}" -f $g.partName.Trim())
    Write-Host ("OptionType=[{0}] LH/RH=[{1}] Tool={2} Rivet={3}" -f $g.optionType.Trim(), $g.optionLhRh.Trim(), $g.targetTool, $g.targetRivet)
    Write-Host ("CoverL={0} CoverR={1}" -f $g.coverLTarget, $g.coverRTarget)
    Write-Host ("Before: Op01={0} Op02_1={1} Op02_2={2} VIP={3} Test={4} mainFound={5}" -f $g.check1, $g.check2_1, $g.check2_2, $g.checkVip, $g.checkNoise, $g.beforeMainFound)
    Write-Host ("Scan result: {0} next={1}" -f $g.result, $g.nextStep)
    $partExtra = Query-One $conn "SELECT target_Op01_FrameBarcode, Target_Op02_LsuptBarcode, Target_Op02_Sab_Barcode FROM Table_Part WHERE PartNo='88310-T4330'"
    if ($partExtra) {
        Write-Host 'Table_Part extra (not loaded on scan by OP05):'
        Write-Host ("  Op01 Frame={0}" -f [string]$partExtra.target_Op01_FrameBarcode)
        Write-Host ("  Op02 Lsupt={0}" -f [string]$partExtra.Target_Op02_LsuptBarcode)
        Write-Host ("  Op02 Sab={0}" -f [string]$partExtra.Target_Op02_Sab_Barcode)
    }
}
finally {
    $conn.Close()
}

Write-Host ""
Write-Host '=== Simulation Complete ===' -ForegroundColor Green
