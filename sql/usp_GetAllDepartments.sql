CREATE PROCEDURE usp_GetAllDepartments
AS
BEGIN
	SELECT	d.Employees
	FROM	Department AS d;
END
