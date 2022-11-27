ALTER PROCEDURE  dbo.spUpdateSettingsDaily
AS
BEGIN

---- Create the variables for the random number generation
DECLARE @Random INT;
DECLARE @Upper INT;
DECLARE @Lower INT;
 
DECLARE @UsersCountRegisteredToday INT;
DECLARE @TodayDeposite INT;

---- This will create a random number between 1 and 999
SET @Lower = 10 ---- The lowest random number
SET @Upper = 29 ---- The highest random number
SELECT @Random = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)

UPDATE [Settings]
SET [Value] = [Value] + @Random
  ,[UpdateDate] = GETDATE()
where [Name] LIKE 'UsersCount'

UPDATE [Settings]
SET [Value] = @Random
  ,[UpdateDate] = GETDATE()
where [Name] LIKE 'UsersCountRegisteredToday'

SET @UsersCountRegisteredToday = @Random;

SET @Lower = 800 ---- The lowest random number
SET @Upper = 2500 ---- The highest random number
SELECT @Random = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)

UPDATE [Settings]
SET [Value] = @Random
  ,[UpdateDate] = GETDATE()
where [Name] LIKE 'UsersCountOnline'

SET @Lower = 300000 ---- The lowest random number
SET @Upper = 800000 ---- The highest random number
SELECT @Random = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)

UPDATE [Settings]
SET [Value] = [Value] + @Random
  ,[UpdateDate] = GETDATE()
where [Name] LIKE 'FullDeposite'

UPDATE [Settings]
SET [Value] = @Random
  ,[UpdateDate] = GETDATE()
where [Name] LIKE 'TodayDeposite'

SET @TodayDeposite = @Random;

INSERT INTO [dbo].[DailyStatistics]
           ([Date]
           ,[UserAdded]
           ,[DepositeAdded])
     VALUES
           (GETDATE()
           ,@UsersCountRegisteredToday
           ,@TodayDeposite)

END

GO

GRANT EXECUTE
    ON OBJECT::[dbo].spUpdateSettingsDaily TO PUBLIC
    AS [dbo];