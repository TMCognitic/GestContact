CREATE VIEW [AppUser].[V_Contact]
	AS SELECT Id as Id, LastName as LastName, FirstName as FirstName, Email as Email, Phone as Phone FROM [Contact]
