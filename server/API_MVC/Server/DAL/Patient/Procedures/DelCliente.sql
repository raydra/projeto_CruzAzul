CREATE PROC DelPatient
	@ID BIGINT
AS
BEGIN
	DELETE PATIENTS WHERE ID = @ID
END