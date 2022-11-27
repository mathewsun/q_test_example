ALTER PROCEDURE  [dbo].[spGetTop100CashIns]
AS
BEGIN
	
SELECT TOP (500) 
	co.[Id]
    ,co.[UserId]
    ,co.[Value]
    ,co.[WhenDate]
    ,u.PublicId
FROM [solo].[dbo].[CashIns] co
left join Users u
on co.[UserId] = u.UserId
WHERE WhenDate <= GETDATE()
and WhenDate >= '2019-01-26 00:00:00.000'
order by [WhenDate] desc

END
GO


GRANT EXECUTE
    ON OBJECT::[dbo].[spGetTop100CashIns] TO PUBLIC
    AS [dbo];