ALTER PROCEDURE  [dbo].[spUpdateUserBalance]
@userId uniqueidentifier
AS
BEGIN

	DECLARE @dateTimeNowValue datetime = GETDATE();

	UPDATE Users
	SET UpdateBalanceDateTime = @dateTimeNowValue
		,Balance = Balance + Balance * CAST(DATEDIFF(second, UpdateBalanceDateTime, @dateTimeNowValue) AS float) / CAST(86400 AS float) / 100 * dbo.fnGetTodayPercent()
		,Earned = Earned + Balance * CAST(DATEDIFF(second, UpdateBalanceDateTime, @dateTimeNowValue) AS float) / CAST(86400 AS float) / 100 * dbo.fnGetTodayPercent()
		,EarnedToday = EarnedToday + Balance * CAST(DATEDIFF(second, UpdateBalanceDateTime, @dateTimeNowValue) AS float) / CAST(86400 AS float) / 100 * dbo.fnGetTodayPercent()
	WHERE UserId = @userId;

END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spUpdateUserBalance] TO PUBLIC
    AS [dbo];
