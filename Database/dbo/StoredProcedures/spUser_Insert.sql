CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@Surname nvarchar(50),
	@Username nvarchar(50),
	@Password nvarchar(50),
	@Admin bit
AS
BEGIN 
	INSERT INTO DBO.[User] (FirstName, Surname, Username, [Password], [Admin])
	VALUES (@FirstName, @Surname, @Username, @Password, @Admin);
END
