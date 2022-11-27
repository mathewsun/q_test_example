CREATE PROCEDURE  dbo.cpSystemQuery
AS
BEGIN
	
	--ALTER DATABASE [Solo] SET OFFLINE WITH ROLLBACK IMMEDIATE

	--EXEC sp_who2

	--KILL 61


	--SELECT [OrderId]
	--	,[Account]
	--	,count ([OrderId])
	--FROM [Solo].[dbo].[OrderEvents]
	--group by [OrderId], [Account]
	--having count ([OrderId]) > 1
	--order by count ([OrderId]) desc


	--SELECT [Object]
	--	,[Account]
	--	,COUNT(*)
	--FROM [Solo].[dbo].[OrderEvents]
	--GROUP BY [Object]
	--	,[Account]
	--HAVING COUNT(*) > 1
	--order by COUNT(*) desc


	--delete t1
	--from [OrderEvents] t1, [OrderEvents] t2
	--where t1.[Object] = t2.[Object] AND t1.[Account] = t2.[Account] 
	--and t1.Id>t2.Id


	--ALTER DATABASE [Solo]
	--SET RECOVERY SIMPLE;
	--GO
	---- Shrink the truncated log file to 1 MB.
	--DBCC SHRINKFILE ([solo_log], 1);
	--GO


	--INSERT INTO VkontakteOrdersDone SELECT * FROM Orders
	--where Orders.IsDone = 1

	--delete FROM Orders
	--where Orders.IsDone = 1

END
