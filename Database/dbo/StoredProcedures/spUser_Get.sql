CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
BEGIN 
	SELECT *
	FROM DBO.[User]
	where Id = @Id;
END
