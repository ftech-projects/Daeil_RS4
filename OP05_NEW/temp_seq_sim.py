from dataclasses import dataclass

@dataclass
class Inputs:
    plc4000:int=0
    scan_valid:bool=False
    before_ok:bool=True
    plc4004:int=0
    length_ok:bool=False
    tool_ok:bool=False
    rivet_ok:bool=False
    coverL_ok:bool=True
    coverR_ok:bool=True
    plc4001:int=0

def step_transition(w, i):
    if i.plc4000 == 0 and w != 0:
        return 0, 'reset by PLC stop'
    if w == 0:
        if i.plc4000 == 1:
            return 1, 'start -> scan wait'
    elif w == 1:
        if i.scan_valid:
            return (2, 'scan accepted') if i.before_ok else (1.1, 'before-check NG')
    elif w == 1.1:
        return 1, 'alarm shown, back to scan wait'
    elif w == 2:
        return 2.1, 'load options'
    elif w == 2.1:
        return 3, 'send PLC options'
    elif w == 3:
        if i.plc4004 == 1:
            return (4, 'length OK') if i.length_ok else (3.1, 'length NG')
    elif w == 3.1:
        if i.plc4004 == 0:
            return 3, 'retry gate'
    elif w == 4:
        all_ok = i.tool_ok and i.rivet_ok and i.coverL_ok and i.coverR_ok
        if all_ok:
            return 5, 'assembly OK'
    elif w == 5:
        return 6, 'complete wait'
    elif w == 6:
        if i.plc4001 == 1:
            return 0, 'print/save done'
    return w, 'hold'

def run(name, seq):
    w=0
    print(f'=== {name} ===')
    for idx, inp in enumerate(seq,1):
        nw,msg=step_transition(w, inp)
        print(f't{idx}: wStep {w} -> {nw} | {msg}')
        w=nw
    print(f'final={w}\n')

run('시나리오A 정상완료', [
    Inputs(plc4000=1),
    Inputs(plc4000=1, scan_valid=True, before_ok=True),
    Inputs(plc4000=1),
    Inputs(plc4000=1),
    Inputs(plc4000=1, plc4004=1, length_ok=True),
    Inputs(plc4000=1, tool_ok=True, rivet_ok=True, coverL_ok=True, coverR_ok=True),
    Inputs(plc4000=1),
    Inputs(plc4000=1, plc4001=1),
])

run('시나리오B 길이NG 후 재시도', [
    Inputs(plc4000=1),
    Inputs(plc4000=1, scan_valid=True, before_ok=True),
    Inputs(plc4000=1),
    Inputs(plc4000=1),
    Inputs(plc4000=1, plc4004=1, length_ok=False),
    Inputs(plc4000=1, plc4004=0),
    Inputs(plc4000=1, plc4004=1, length_ok=True),
    Inputs(plc4000=1, tool_ok=True, rivet_ok=True, coverL_ok=True, coverR_ok=True),
    Inputs(plc4000=1),
    Inputs(plc4000=1, plc4001=1),
])

run('시나리오C 이전공정NG', [
    Inputs(plc4000=1),
    Inputs(plc4000=1, scan_valid=True, before_ok=False),
    Inputs(plc4000=1),
])
