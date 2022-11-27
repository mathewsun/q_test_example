ALTER PROCEDURE  [dbo].[spGetCashInsFullSum]
@Result float OUTPUT
AS
BEGIN

	SET @Result =
	(
	SELECT Sum([Value])
	FROM [solo].[dbo].[CashIns]
	WHERE WhenDate <= GETDATE()
	and WhenDate >= '2019-01-26 00:00:00.000'
	);
END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spGetCashInsFullSum] TO PUBLIC
    AS [dbo];
