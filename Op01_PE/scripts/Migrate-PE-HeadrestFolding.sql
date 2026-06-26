-- Op01_PE HEADREST FOLDING 이중 시퀀스 (FTECH_SVR)

IF COL_LENGTH('Table_Part', 'Use_PE_HeadrestFolding') IS NULL
    ALTER TABLE Table_Part ADD Use_PE_HeadrestFolding BIT NOT NULL CONSTRAINT DF_Table_Part_Use_PE_HeadrestFolding DEFAULT 0;

IF COL_LENGTH('Table_Main', 'PE_HeadrestFoldingTq1') IS NULL
    ALTER TABLE Table_Main ADD PE_HeadrestFoldingTq1 NVARCHAR(20) NULL;
IF COL_LENGTH('Table_Main', 'PE_HeadrestFoldingTq2') IS NULL
    ALTER TABLE Table_Main ADD PE_HeadrestFoldingTq2 NVARCHAR(20) NULL;

IF COL_LENGTH('Table_Main', 'PE_MonitorbracketPreTq1') IS NULL
    ALTER TABLE Table_Main ADD PE_MonitorbracketPreTq1 NVARCHAR(20) NULL;
IF COL_LENGTH('Table_Main', 'PE_MonitorbracketPreTq2') IS NULL
    ALTER TABLE Table_Main ADD PE_MonitorbracketPreTq2 NVARCHAR(20) NULL;
IF COL_LENGTH('Table_Main', 'PE_MonitorbracketPreTq3') IS NULL
    ALTER TABLE Table_Main ADD PE_MonitorbracketPreTq3 NVARCHAR(20) NULL;
IF COL_LENGTH('Table_Main', 'PE_MonitorbracketPreTq4') IS NULL
    ALTER TABLE Table_Main ADD PE_MonitorbracketPreTq4 NVARCHAR(20) NULL;

IF COL_LENGTH('Table_Main', 'PE_HeadrestFoldingFinalTq1') IS NULL
    ALTER TABLE Table_Main ADD PE_HeadrestFoldingFinalTq1 NVARCHAR(20) NULL;
IF COL_LENGTH('Table_Main', 'PE_HeadrestFoldingFinalTq2') IS NULL
    ALTER TABLE Table_Main ADD PE_HeadrestFoldingFinalTq2 NVARCHAR(20) NULL;
IF COL_LENGTH('Table_Main', 'PE_HeadrestFoldingFinalTq3') IS NULL
    ALTER TABLE Table_Main ADD PE_HeadrestFoldingFinalTq3 NVARCHAR(20) NULL;
IF COL_LENGTH('Table_Main', 'PE_HeadrestFoldingFinalTq4') IS NULL
    ALTER TABLE Table_Main ADD PE_HeadrestFoldingFinalTq4 NVARCHAR(20) NULL;
