CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
BEGIN 
	DELETE 
	FROM DBO.[User]
	where Id = @Id;
END
 