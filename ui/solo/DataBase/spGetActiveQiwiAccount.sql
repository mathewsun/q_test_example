ALTER PROCEDURE  [dbo].[spGetActiveQiwiAccount]
@Result nvarchar(50) OUTPUT
AS
BEGIN

	DECLARE @LastId int = (SELECT TOP 1 Id
	FROM Phones
	WHERE Blocked = 0
	ORDER BY Balance, LastActive);

	UPDATE Phones
	SET LastActive = GETDATE()
	WHERE Id = @LastId;


	SET @Result =
	(
	SELECT Number
	FROM Phones 
	WHERE Id = @LastId
	);
END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spGetActiveQiwiAccount] TO PUBLIC
    AS [dbo];
