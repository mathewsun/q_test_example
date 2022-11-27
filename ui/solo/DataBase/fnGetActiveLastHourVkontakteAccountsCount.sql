CREATE FUNCTION dbo.fnGetActiveLastHourVkontakteAccountsCount ()
RETURNS int
WITH EXECUTE AS CALLER
AS
BEGIN
     DECLARE @Result int;
     SET @Result =
	(SELECT Count(distinct [Login])
	FROM [VkontakteAccounts]
	where [LastActive] > DATEADD(HOUR, -1, GETDATE())
	 );
     RETURN(@Result);
END;
GO