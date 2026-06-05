# Daeil_RS4 작업 기록

## 2026-06-05 11:28 — OP05_NEW 갱신 Git 푸시

### 커밋
- **OP05_NEW** (내부): `82e8727` — I/O·레이저·스캔·판정·FrmIo 현장 안정화
- **Daeil_RS4** (상위): OP05_NEW gitlink 갱신 + `RS4.sln` 프로젝트명 `OP05_NEW(192.168.0.10)` + 본 문서

### 원격
- `https://github.com/ftech-projects/Daeil_RS4` — `main` 푸시

### 주요 내용 (OP05_NEW)
- Keyence IL-300, COM ESP + FBEI LAN I/O, Menu I/O 모니터(FrmIo)
- PLC 제거·wStep I/O 재정의, 스캔/COM·품번 조회·PASS/띵동·MX 미설치 가드
- DB.mdb·ACE x86·배포 스크립트·FrmPart

### 문제점
- `OP05_NEW`는 **별도 Git 저장소**(`.gitmodules` 없음) — 클론 시 `git submodule update`로는 내용이 안 채워질 수 있음. 폴더 내 `git pull` 또는 상위에서 gitlink 커밋 해시 확인 필요.
- `temp_seq_sim.py`는 커밋 제외(임시 시뮬 스크립트).

### 작업 경로 (2026-06-05)
- 일상 개발: `C:\Program Files (x86)\business\대일공업\RS4\OP05_NEW`
- Git push: `ftech-projects\Daeil_RS4`

---

## 2026-06-03 — Git 첫 커밋 및 푸시

- **커밋**: `7c8c6b4` — 메시지 `첫 커밋`
- **원격**: `https://github.com/ftech-projects/Daeil_RS4` — `main` 브랜치 푸시 완료 (`origin/main` 추적 설정)
- **추가**: `.gitignore` (Visual Studio `.vs/`, `*.suo`, bin/obj 등) — `git add` 시 `.vs` 파일 잠금(Permission denied) 방지
- **주의**: `OP05_NEW`는 내부에 별도 Git 저장소가 있어 submodule 형태로만 인덱스됨. 클론 시 해당 폴더 내용이 비어 있을 수 있음. 로컬에 `modified content, untracked content` 잔여
