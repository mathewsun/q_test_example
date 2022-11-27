ALTER PROCEDURE  [dbo].[spGetCashOutsIn24Hours]
@Result float OUTPUT
AS
BEGIN

	SET @Result =
	(
	SELECT Sum([Value])
	FROM [solo].[dbo].[CashOuts]
	WHERE WhenDate > DATEADD(DAY, -1, GETDATE())
	AND WhenDate <= GETDATE()
	);
END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spGetCashOutsIn24Hours] TO PUBLIC
    AS [dbo];
