ALTER PROCEDURE  [dbo].[spUpdateAllUsersBalance]
AS
BEGIN

	DECLARE @dateTimeNowValue datetime = GETDATE();

	UPDATE Users
	SET UpdateBalanceDateTime = @dateTimeNowValue
		,Balance = Balance + Balance * CAST(DATEDIFF(second, UpdateBalanceDateTime, @dateTimeNowValue) AS float) / CAST(86400 AS float) / 100 * dbo.fnGetTodayPercent()
		,Earned = Earned + Balance * CAST(DATEDIFF(second, UpdateBalanceDateTime, @dateTimeNowValue) AS float) / CAST(86400 AS float) / 100 * dbo.fnGetTodayPercent()
		,EarnedToday = EarnedToday + Balance * CAST(DATEDIFF(second, UpdateBalanceDateTime, @dateTimeNowValue) AS float) / CAST(86400 AS float) / 100 * dbo.fnGetTodayPercent()

END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spUpdateAllUsersBalance] TO PUBLIC
    AS [dbo];
