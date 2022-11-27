ALTER PROCEDURE  [dbo].[spGetCashOutsFullSum]
@Result float OUTPUT
AS
BEGIN

	SET @Result =
	(
	SELECT Sum([Value])
	FROM [solo].[dbo].[CashOuts]
	WHERE WhenDate <= GETDATE()
	and WhenDate >= '2019-01-26 00:00:00.000'
	);
END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spGetCashOutsFullSum] TO PUBLIC
    AS [dbo];
