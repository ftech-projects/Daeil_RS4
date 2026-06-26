-- PE 라인 스키마 (FTECH_SVR) — 현장 SQL Server에서 수동 실행
-- OptionType='PE' 사용 안 함. Use_PE_Line=1 로 PE 라인 식별.

-- Table_Part
IF COL_LENGTH('Table_Part', 'Use_PE_Line') IS NULL
    ALTER TABLE Table_Part ADD Use_PE_Line BIT NOT NULL CONSTRAINT DF_Table_Part_Use_PE_Line DEFAULT 0;
IF COL_LENGTH('Table_Part', 'Target_PE05_ToolNum') IS NULL
    ALTER TABLE Table_Part ADD Target_PE05_ToolNum INT NULL;
-- 인사이드 커버 L/R: Target_Op03_InsideCoverL/R 공용 (Target_PE05_InsideCover* 미사용)

-- Table_BASIC (MDB Table_BASIC 동기 컬럼명)
IF COL_LENGTH('Table_BASIC', 'FrtMin_PE') IS NULL
    ALTER TABLE Table_BASIC ADD FrtMin_PE FLOAT NULL;
IF COL_LENGTH('Table_BASIC', 'FrtMax_PE') IS NULL
    ALTER TABLE Table_BASIC ADD FrtMax_PE FLOAT NULL;
IF COL_LENGTH('Table_BASIC', 'RearMin_PE') IS NULL
    ALTER TABLE Table_BASIC ADD RearMin_PE FLOAT NULL;
IF COL_LENGTH('Table_BASIC', 'RearMax_PE') IS NULL
    ALTER TABLE Table_BASIC ADD RearMax_PE FLOAT NULL;
IF COL_LENGTH('Table_BASIC', 'FrtTolPE') IS NULL
    ALTER TABLE Table_BASIC ADD FrtTolPE FLOAT NULL;
IF COL_LENGTH('Table_BASIC', 'RearTolPE') IS NULL
    ALTER TABLE Table_BASIC ADD RearTolPE FLOAT NULL;

-- Table_Main — Op01_PE 실적 (없으면 추가)
IF COL_LENGTH('Table_Main', 'PE_Decision') IS NULL
    ALTER TABLE Table_Main ADD PE_Decision NVARCHAR(10) NULL;
