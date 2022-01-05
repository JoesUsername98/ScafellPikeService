CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@Surname nvarchar(50),
	@Username nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN 
	UPDATE DBO.[User] 
	SET 
	FirstName = @FirstName,
	Surname = @Surname,
	Username = @Username,
	[Password] = @Password
	WHERE Id = @Id;
END