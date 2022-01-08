CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@Surname nvarchar(50),
	@Username nvarchar(50),
	@Password nvarchar(50),
	@Admin bit
AS
BEGIN 
	UPDATE DBO.[User] 
	SET 
	FirstName = @FirstName,
	Surname = @Surname,
	Username = @Username,
	[Password] = @Password,
	[Admin] = @Admin
	WHERE Id = @Id;
END