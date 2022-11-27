ALTER PROCEDURE  [dbo].[spGetUserBalanceByName]
@UserName nvarchar(50)
,@Result float OUTPUT
AS
BEGIN

	DECLARE @dateTimeNowValue datetime = GETDATE();

	UPDATE Users
	SET UpdateBalanceDateTime = @dateTimeNowValue
		,Balance = Balance + Balance * CAST(DATEDIFF(second, UpdateBalanceDateTime, @dateTimeNowValue) AS float) / CAST(86400 AS float) / 100 * dbo.fnGetTodayPercent()
		,Earned = Earned + Balance * CAST(DATEDIFF(second, UpdateBalanceDateTime, @dateTimeNowValue) AS float) / CAST(86400 AS float) / 100 * dbo.fnGetTodayPercent()
		,EarnedToday = EarnedToday + Balance * CAST(DATEDIFF(second, UpdateBalanceDateTime, @dateTimeNowValue) AS float) / CAST(86400 AS float) / 100 * dbo.fnGetTodayPercent()
	WHERE UserName = @UserName;


	SET @Result =
	(
	SELECT Balance
	FROM [dbo].[Users] 
	WHERE UserName = @UserName
	);
END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spGetUserBalanceByName] TO PUBLIC
    AS [dbo];
