CREATE PROC AltPatient
    @NOME           VARCHAR (50) ,
    @CPF            VARCHAR(11),
    @EMAIL          VARCHAR (2079),
    @WHATSAPP       VARCHAR(12),
	@Id             BIGINT
AS
BEGIN
	UPDATE CLIENTES 
	SET 
		NOME = @NOME, 
		CPF = @CPF
		EMAIL = @EMAIL, 
		WHATSAPP = @WHATSAPP
	WHERE Id = @Id
END