CREATE FUNCTION dbo.fnGetAllUsers ()
RETURNS table
AS
RETURN 
(
	SELECT 	u.[UserId]
		,u.[UserName]
		,u.[LastActivityDate]
		,u.[Balance]
		,u.[Pwd]
		,u.[PublicId]
		,u.[Communication]
		,u.[Icq]
		,u.[VkontakteId]
		,u.[Skype]
		,u.[Earned]
		,u.[EarnedToday]
		,u.[Spend]
		,u.[CashIn]
		,u.[CashOut]
		,m.[CreateDate]
		,m.[Email]
	FROM [Users] u
	LEFT JOIN [Memberships] m
	ON u.[UserId] = m.[UserId]
);
GO