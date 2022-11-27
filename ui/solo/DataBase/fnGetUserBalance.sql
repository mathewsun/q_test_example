CREATE FUNCTION dbo.fnGetUserBalance (@UserId uniqueidentifier)
RETURNS float
WITH EXECUTE AS CALLER
AS
BEGIN
     DECLARE @Result float;
     SET @Result =
	(SELECT Balance
	FROM [dbo].[Users] 
	WHERE UserId = @UserId);
     RETURN(@Result);
END;
GO