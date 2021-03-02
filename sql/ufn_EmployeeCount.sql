ALTER FUNCTION [dbo].[ufn_EmployeeCount] (@DNumber INT)
RETURNS INT
AS
BEGIN
	DECLARE @EmployeeCount INT;
	SELECT @EmployeeCount = count(@DNumber)
	FROM [Employee]
	WHERE [Dno] = @DNumber;
	RETURN @EmployeeCount;
END;
GO

ALTER TABLE [Department]
ADD [Employees] AS [dbo].ufn_EmployeeCount(DNumber);

SELECT * FROM [Department];