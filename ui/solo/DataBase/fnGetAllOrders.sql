CREATE FUNCTION dbo.fnGetAllOrders ()
RETURNS table
AS
RETURN 
(
	SELECT o.[Id]
      ,o.[Url]
      ,o.[Count]
      ,o.[OrderType]
      ,o.[UserId]
      ,o.[ReadyCount]
      ,o.[IsDone]
      ,o.[LastUpdate]
      ,o.[Cost]
      ,o.[WhenDate]
      ,o.[CountDays]
	  ,o.[WithAvatar]
      ,o.[City]
      ,o.[Friends]
      ,o.[RegisterDaysVkontakte]
      ,o.[RegisterDaysSmmZilla]
      ,o.[Gender]
	  ,u.[UserName]
  FROM [Orders] o
  LEFT JOIN [Users] u
  ON o.[UserId] = u.[UserId]
);
GO