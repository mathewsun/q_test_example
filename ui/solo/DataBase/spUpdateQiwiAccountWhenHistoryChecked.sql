CREATE PROCEDURE  [dbo].[spUpdateQiwiAccountWhenHistoryChecked]
@number nvarchar(50)
AS
BEGIN

	UPDATE Phones
	SET WhenHistoryChecked = GETDATE()
	WHERE Number = @number;

END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spUpdateQiwiAccountWhenHistoryChecked] TO PUBLIC
    AS [dbo];
