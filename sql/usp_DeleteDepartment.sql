ALTER PROCEDURE usp_DeleteDepartment
(
	@DNumber	INT
)
AS
BEGIN
	DECLARE @ProjetcNo INT;

	DELETE Dept_Locations
	WHERE DNUmber = @DNumber;
	
	SELECT @ProjetcNo = PNumber FROM Project;
	DELETE Project WHERE DNum = @DNumber;
	
	DELETE Works_on
	WHERE Works_on.Pno = @ProjetcNo;

	UPDATE Employee
	SET Dno = NULL
	WHERE Dno = @DNumber;
	
	DELETE Department
	WHERE DNumber = @DNumber;
END
