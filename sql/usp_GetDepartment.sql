ALTER PROCEDURE usp_GetDepartment
(
	@DNumber	INT
)
AS
BEGIN
	SELECT	COUNT(e.SSN) AS EmpCount
	FROM	Employee AS e 
			JOIN Department AS d on e.Dno = d.DNumber
	WHERE	d.DNumber = @DNumber
	GROUP BY e.Dno;
END