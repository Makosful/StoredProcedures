CREATE TABLE dbo.Tmp_Table
(
	[DNumber]		INT		NOT NULL	IDENTITY(1,1),
	[DName]			NVARCHAR(50)	NOT NULL,
	[MgrSSN]		NUMERIC(9,0)	NOT NULL,
	[MgrStartDate]		DATETIME	NOT NULL,
	CONSTRAINT PK_Department	PRIMARY KEY (DNumber),
	CONSTRAINT UC_DName		UNIQUE (DName),
	CONSTRAINT UC_MgrSSN		UNIQUE (MgrSSN)
) ON [PRIMARY]
GO

SET IDENTITY_INSERT dbo.Tmp_Table ON;

ALTER TABLE [dbo].[Department]		DROP CONSTRAINT [FK_Department_Employee]
ALTER TABLE [dbo].[Dept_Locations]	DROP CONSTRAINT [FK_Dept_Locations_Department] 
ALTER TABLE [dbo].[Employee]		DROP CONSTRAINT [FK_Employee_Department] 
ALTER TABLE [dbo].[Project]		DROP CONSTRAINT [FK_Project_Department] 
GO

IF EXISTS(SELECT * FROM dbo.Department)
	INSERT INTO dbo.Tmp_Table (DName, DNumber, MgrSSN, MgrStartDate)
		SELECT DName, DNumber, MgrSSN, MgrStartDate FROM dbo.Department TABLOCKX;
GO

SET IDENTITY_INSERT dbo.Tmp_Table OFF;
GO

DROP TABLE dbo.Department;
GO

EXECUTE sp_rename 'Tmp_Table', 'Department';
GO

ALTER TABLE [dbo].[Department]		ADD	CONSTRAINT	[FK_Department_Employee]	FOREIGN KEY([MgrSSN])	REFERENCES [dbo].[Employee] ([SSN])
ALTER TABLE [dbo].[Dept_Locations]	ADD	CONSTRAINT	[FK_Dept_Locations_Department]	FOREIGN KEY([DNUmber])	REFERENCES [dbo].[Department] ([DNumber])
ALTER TABLE [dbo].[Employee]		ADD	CONSTRAINT	[FK_Employee_Department]	FOREIGN KEY([Dno])	REFERENCES [dbo].[Department] ([DNumber])
ALTER TABLE [dbo].[Project]		ADD	CONSTRAINT	[FK_Project_Department]		FOREIGN KEY([DNum])	REFERENCES [dbo].[Department] ([DNumber])
GO
