CREATE PROCEDURE usp_GetDepartment
(
	@DNumber	INT
)
AS
BEGIN
	SELECT	d.Employees
	FROM	Department AS d
	WHERE	d.DNumber = @DNumber
END
