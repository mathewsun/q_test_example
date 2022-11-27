ALTER PROCEDURE  dbo.spUpdateAverageMonthPercent
AS
BEGIN

UPDATE [Settings]
SET [Value] = (SELECT AVG([Value])
  FROM [Solo].[dbo].[Percents]
  where [Date] <= GETDATE()
  AND [Date] >= DATEADD(month, -1, GETDATE()))
  ,[UpdateDate] = GETDATE()
where [Name] LIKE 'AverageMonthPercent'

END

GO

GRANT EXECUTE
    ON OBJECT::[dbo].spUpdateAverageMonthPercent TO PUBLIC
    AS [dbo];