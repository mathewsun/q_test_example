ALTER FUNCTION dbo.fnGetTaskByName (@UserName nvarchar(50))
RETURNS table
AS
RETURN 
(
	--declare @UserId uniqueidentifier = '086A2ED2-024B-4E9F-8AE8-6D2663F05B14';
	--declare @UserName nvarchar(50) = 'mmm';
	
	select top(1) 
	o.Id, 
	x.[Login], 
	x.[Password], 
	o.[Url],
	o.[OrderType],
	o.[Cost],
	o.[Count],
	x.[Balance]
	from Orders o
        cross join 
        ( select	va.[Login],
					va.[Password],
					va.LastActive,
					u.[Balance],
					va.[IsJoinGroup],
					va.[IsLike],
					va.[IsSubscribe],
					va.[IsRepost],
					va.VkLogo,
					va.Gender,
					va.Location,
					va.CountFriends,
					va.Created,
					va.WhenDate
		from [VkontakteAccounts] va 
		inner join Users u 
			on u.UserId = va.UserId
		where	va.IsActive = 1 
				and va.IsDeleted = 0 
				and u.UserName = @UserName
				AND (va.[Created] is null										--Только добавлен в систему
					OR (DATEADD(minute, 120, va.[LastActive]) <= GETDATE())		--Если меньше 7 дней создан в Вк, то событие раз в 2 часа
					OR (DATEADD(day, 7, va.[Created]) <= GETDATE()))			--эт продолжение про 7 дней
				--AND ((DATEADD(minute, 120, va.[LastActive]) <= GETDATE()) OR (DATEADD(day, 1, va.[WhenDate]) <= GETDATE()))
        ) as X
	where 
	  o.IsDone = 0
	  AND (	(o.[OrderType] = 1
				AND X.[IsJoinGroup] = 1
				)
			OR (o.[OrderType] = 2
				AND X.[IsLike] = 1
				)
			OR (o.[OrderType] = 3
				AND X.[IsSubscribe] = 1
				)
			OR (o.[OrderType] = 4
				AND X.[IsRepost] = 1
				)
			OR	(	o.[OrderType] = 5 
				AND X.[IsLike] = 1
				AND ((o.[Count] * (DATEDIFF(minute, o.[WhenDate], GETDATE()) /24 / 60)) / o.[CountDays]) > o.[ReadyCount])
			OR	(o.[OrderType] = 6
				AND X.[IsRepost] = 1
				AND ((o.[Count] * (DATEDIFF(minute, o.[WhenDate], GETDATE()) /24 / 60)) / o.[CountDays]) > o.[ReadyCount])
			OR	(o.[OrderType] = 7
				AND ((o.[Count] * (DATEDIFF(minute, o.[WhenDate], GETDATE()) /24 / 60)) / o.[CountDays]) > o.[ReadyCount])
			)
		AND (o.WithAvatar = 0 OR (X.VkLogo <> '/images/camera_50.png' AND X.VkLogo <> ''))
		AND (o.Gender is null OR o.Gender = X.Gender)
		AND (o.City is null OR o.City = X.Location)
		AND (o.Friends = 0 OR o.Friends < X.CountFriends)
		AND (o.RegisterDaysVkontakte = 0 OR GETDATE() > DATEADD(day,o.RegisterDaysVkontakte,X.Created))
		AND (o.RegisterDaysSmmZilla = 0 OR GETDATE() > DATEADD(day,o.RegisterDaysSmmZilla,X.WhenDate))
	  and not exists ( select *
						  from OrderEvents oe 
						  where x.[Login] = oe.Account 
							and o.[Url] = oe.[Object] 
						) 
	order by x.LastActive, o.LastUpdate
);
GO