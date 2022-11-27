CREATE FUNCTION dbo.fnGetAllCashOuts (@userId uniqueidentifier)
RETURNS table
AS
RETURN 
(
     SELECT  co.[Id]
			,co.[State]
			,co.[Value]
			,co.[WhenDate]
			,co.[Sposob]
			,co.[WhenAdminEvent]
			,co.[UserId]
			,u.[UserName]
			,u.[Balance]
	FROM [dbo].CashOuts co
	LEFT JOIN [dbo].[Users] u
		ON u.UserId = co.UserId
	WHERE @userId is null or co.UserId = @userId
);
GO