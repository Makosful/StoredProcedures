CREATE PROCEDURE usp_UpdateDepartmentName
(
	@DNumber	INT,
	@DName		VARCHAR(50)
)
AS
BEGIN
	UPDATE Department
	SET DName = @DName
	OUTPUT inserted.DNumber, inserted.DName
	WHERE DNumber = @DNumber;
END
