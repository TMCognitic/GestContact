CREATE PROCEDURE [AppUser].[CSP_UpdateContact]
	@Id int,
	@Nom nvarchar(50),
	@Prenom nvarchar(50),
	@Email nvarchar(320),
	@Tel nvarchar(30)
AS
BEGIN
	UPDATE Contact SET
	LastName = @Nom,
	FirstName = @Prenom,
	Email = @Email,
	Phone = @Tel
	WHERE Id = @Id;
	RETURN 0
END
