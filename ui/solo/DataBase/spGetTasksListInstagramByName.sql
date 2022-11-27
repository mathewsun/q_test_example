ALTER PROCEDURE  [dbo].[spGetTasksListInstagramByName]
@UserName nvarchar(50)
AS
BEGIN
	--declare @UserName nvarchar(50) = 'mmm';
	
	select top(2)
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
        ( select	accs.[Login],
					accs.[Password],
					accs.LastActive,
					u.[Balance],
					accs.WhenDate
		from [InstagramAccounts] accs
		inner join Users u
			on u.UserId = accs.UserId
		where	accs.IsActive = 1
				and u.UserName = @UserName
        ) as X
	where
	  o.IsDone = 0
	  AND o.[Count] > (o.[ReadyCount] * 1.04)
	  AND (	(o.[OrderType] = 9	)
			OR (o.[OrderType] = 10	)
			OR (o.[OrderType] = 11	)
			)
	  and not exists ( select *
						  from OrderEvents oe
						  where x.[Login] = oe.Account
							and o.[Url] = oe.[Object]
						)
	order by x.LastActive, o.LastUpdate

END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].spGetTasksListInstagramByName TO PUBLIC
    AS [dbo];