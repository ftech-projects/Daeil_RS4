-- PE 라인 스키마 (FTECH_SVR SQL Server 전용)
-- Table_BASIC 은 MDB 로컬 전용 — 이 스크립트에 포함하지 않음

IF COL_LENGTH('Table_Part', 'Use_PE_Line') IS NULL
    ALTER TABLE Table_Part ADD Use_PE_Line BIT NOT NULL CONSTRAINT DF_Table_Part_Use_PE_Line DEFAULT 0;
IF COL_LENGTH('Table_Part', 'Target_PE05_ToolNum') IS NULL
    ALTER TABLE Table_Part ADD Target_PE05_ToolNum INT NULL;
-- 인사이드 커버 L/R: Target_Op03_InsideCoverL/R 공용 (Target_PE05_InsideCover* 미사용)

IF COL_LENGTH('Table_Main', 'PE_Decision') IS NULL
    ALTER TABLE Table_Main ADD PE_Decision NVARCHAR(10) NULL;
