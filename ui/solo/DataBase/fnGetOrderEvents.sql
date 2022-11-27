CREATE FUNCTION dbo.fnGetOrderEvents (@OrderId int)
RETURNS table
AS
RETURN 
(
	SELECT o.[Id]
      ,o.[OrderId]
      ,o.[AccountId]
      ,o.[Object]
      ,o.[Account]
      ,o.[WhenDate]
      ,o.[OrderType]
      ,o.[Result]
	  ,va.[VkLogo]
	  ,va.[VkontakteId]
	  ,va.[VkName]
	  ,u.UserId
	  ,u.UserName
  FROM [Solo].[dbo].[OrderEvents] o
  left join VkontakteAccounts va
  on o.[Account] = va.[Login]
  left join Users u
  on va.UserId = u.UserId
  where o.[OrderId] = @OrderId
);
GO