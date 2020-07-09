CREATE PROCEDURE [AppUser].[CSP_DeleteContact]
	@Id int
AS
BEGIN
	DELETE FROM Contact Where Id = @Id;
	RETURN 0
END
