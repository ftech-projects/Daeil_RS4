-- FTECH_SVR — RS4_PE_Play 프레임 유격 검사 실적 (Op01_v2 조회용)
-- RS4_PE_Play 소스 미수정 전제: 데이터는 별도 적재·동기화 필요

IF OBJECT_ID('dbo.Table_Fram_Inspection', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Table_Fram_Inspection (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Frame_Barcode NVARCHAR(100) NOT NULL,
        JobDate DATE NOT NULL,
        JobStartTime NVARCHAR(8) NULL,
        JobEndTime NVARCHAR(8) NULL,
        Inspection_Value NVARCHAR(20) NULL,
        Decision NVARCHAR(10) NOT NULL
    );
    CREATE INDEX IX_Fram_Inspection_Barcode ON dbo.Table_Fram_Inspection (Frame_Barcode, JobDate DESC);
END
