ALTER PROCEDURE  dbo.spUpdateAverageYearPercent
AS
BEGIN

UPDATE [Settings]
SET [Value] = (SELECT AVG([Value])
  FROM [Solo].[dbo].[Percents]
  where [Date] <= GETDATE()
  AND [Date] >= DATEADD(year, -1, GETDATE()))
  ,[UpdateDate] = GETDATE()
where [Name] LIKE 'AverageYearPercent'

END

GO

GRANT EXECUTE
    ON OBJECT::[dbo].spUpdateAverageYearPercent TO PUBLIC
    AS [dbo];