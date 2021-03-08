CREATE PROC PesqPatient
	@iniciarEm int,
	@quantidade int,
	@campoOrdenacao varchar(200),
	@crescente bit	
AS
BEGIN
	DECLARE @SCRIPT NVARCHAR(MAX)
	DECLARE @CAMPOS NVARCHAR(MAX)
	DECLARE @ORDER VARCHAR(50)
	
	IF(@campoOrdenacao = 'EMAIL')
		SET @ORDER =  ' EMAIL '
	ELSE
		SET @ORDER = ' NOME '

	IF(@crescente = 0)
		SET @ORDER = @ORDER + ' DESC'
	ELSE
		SET @ORDER = @ORDER + ' ASC'

	SET @CAMPOS = '@iniciarEm int,@terminaEm int'
	SET @SCRIPT = 
	'SELECT ID, NOME, CPF, EMAIL, WHATSAPP FROM
		(SELECT ROW_NUMBER() OVER (ORDER BY ' + @ORDER + ') AS Row, NOME, CPF, EMAIL, WHATSAPP FROM PATIENTS WITH(NOLOCK))
		AS PatientsWithRowNumbers
	WHERE Row > @iniciarEm AND Row <= @terminaEm ORDER BY'
	
	SET @SCRIPT = @SCRIPT + @ORDER
			
	EXECUTE SP_EXECUTESQL @SCRIPT, @CAMPOS, @iniciarEm, @terminaEm

	SELECT COUNT(1) FROM PATIENTS WITH(NOLOCK)
END