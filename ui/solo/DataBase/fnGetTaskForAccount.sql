CREATE FUNCTION dbo.fnGetTaskForAccount (@Login nvarchar(max))
RETURNS table
AS
RETURN 
(
	--declare @UserId uniqueidentifier = '086A2ED2-024B-4E9F-8AE8-6D2663F05B14';
	-- declare @Login nvarchar(max) = '89857139542'
	
	select TOP 1 
	o.Id, 
	va.[Login], 
	va.[Password], 
	o.[Url],
	o.[OrderType],
	o.[Cost],
	o.[Count]
	--,((o.[Count] * DATEDIFF(minute, o.[WhenDate], GETDATE())) / o.[CountDays]) /24 / 60
	--,o.[ReadyCount]
	from [VkontakteAccounts] va, Orders o
	where 
	va.[IsActive] = 1 
	AND va.IsDeleted = 0
	AND o.IsDone = 0
	AND va.[Login] = @Login
	AND (va.[Created] is null OR (DATEADD(minute, 60, va.[LastActive]) <= GETDATE()) OR (DATEADD(day, 15, va.[Created]) <= GETDATE()))
	--/Это для эмуляции лайков. Делим количество на разницу в часах, если выполнено меньше, то лайкаем
	AND (	(o.[OrderType] = 1
				AND va.[IsJoinGroup] = 1
				)
			OR (o.[OrderType] = 2
				AND va.[IsLike] = 1
				)
			OR (o.[OrderType] = 3
				AND va.[IsSubscribe] = 1
				)
			OR (o.[OrderType] = 4
				AND va.[IsRepost] = 1
				)
			OR	(	o.[OrderType] = 5 
				AND va.[IsLike] = 1
				AND ((o.[Count] * DATEDIFF(minute, o.[WhenDate], GETDATE())) / o.[CountDays]) /24 / 60 > o.[ReadyCount])
			OR	(o.[OrderType] = 6
				AND va.[IsRepost] = 1
				AND ((o.[Count] * DATEDIFF(minute, o.[WhenDate], GETDATE())) / o.[CountDays]) /24 / 60 > o.[ReadyCount])
			)
	AND not exists (
		select 1 from OrderEvents oe 
		where 	va.[Login] = oe.Account 
				AND o.Url = oe.[Object]
				AND o.[OrderType] = oe.[OrderType] 
				AND o.[OrderType] <> 5
				AND o.[OrderType] <> 6
				
	) 

	order by va.[LastActive], o.[LastUpdate]
);
GO