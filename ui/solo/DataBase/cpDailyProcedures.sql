CREATE PROCEDURE  dbo.cpDailyProcedures
AS
BEGIN

GO
exec spUpdateAllUsersBalance;
GO
exec spUpdateReferralBonusToday
GO

END

GO
GRANT EXECUTE
    ON OBJECT::[dbo].cpDailyProcedures TO PUBLIC
    AS [dbo];