CREATE PROCEDURE usp_GetAllDepartments
AS
BEGIN
	SELECT	COUNT(e.SSN) AS EmployeeCount, e.Dno AS DNumber
	FROM	Employee AS e 
	GROUP BY e.Dno;
END
