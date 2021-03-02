CREATE PROCEDURE usp_CreateDepartment
(
	@DName	NVARCHAR(50),
	@MgrSSN	NUMERIC(9,0)
)
AS
BEGIN

	INSERT INTO Department (DName, MgrSSN, MgrStartDate)
		OUTPUT inserted.DNumber
		VALUES (@DName, @MgrSSN, GETDATE());

END -- PROCEDURE
