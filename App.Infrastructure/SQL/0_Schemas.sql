IF NOT EXISTS(
	SELECT schema_name
	FROM information_schema.schemata
	WHERE schema_name = 'org'
)
BEGIN
	EXEC('CREATE SCHEMA org');
END

GO