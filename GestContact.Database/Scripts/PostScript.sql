/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

exec AppUser.CSP_AddContact @Nom = 'Doe', @Prenom = 'John', @Email = 'john.doe@unknow.com', @Tel = '555-3659876';
exec AppUser.CSP_AddContact @Nom = 'Morre', @Prenom = 'Thierry', @Email = 'thierry.morre@cogntiic.be', @Tel = '555-3659876';
exec AppUser.CSP_AddContact @Nom = 'Doe', @Prenom = 'Jane', @Email = 'jane.doe@unknow.com', @Tel = '555-3659876';