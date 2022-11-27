ALTER PROCEDURE  [dbo].[spGetCashInsIn24Hours]
@Result float OUTPUT
AS
BEGIN

	SET @Result =
	(
	SELECT Sum([Value])
	FROM [solo].[dbo].[CashIns]
	WHERE WhenDate > DATEADD(DAY, -1, GETDATE())
	AND WhenDate <= GETDATE()
	);
END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spGetCashInsIn24Hours] TO PUBLIC
    AS [dbo];
