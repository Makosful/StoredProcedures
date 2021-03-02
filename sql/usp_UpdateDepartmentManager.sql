CREATE PROCEDURE usp_UpdateDepartmentManager
(
	@DNumber	INT,
	@MgrSSN		INT
)
AS
BEGIN
	UPDATE Department
	SET	MgrSSN = @MgrSSN,
		MgrStartDate = GETDATE()
	OUTPUT inserted.DNumber, inserted.DName, inserted.MgrSSN, inserted.MgrStartDate
	WHERE DNumber = @DNumber;
END
