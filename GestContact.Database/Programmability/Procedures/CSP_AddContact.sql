CREATE PROCEDURE [AppUser].[CSP_AddContact]
	@Nom nvarchar(50),
	@Prenom nvarchar(50),
	@Email nvarchar(320),
	@Tel nvarchar(30)
AS
BEGIN
	INSERT INTO Contact (LastName, FirstName, Email, Phone)
	OUTPUT inserted.Id
	values (@Nom, @Prenom, @Email, @Tel);
	RETURN 0
END