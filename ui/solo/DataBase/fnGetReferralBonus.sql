CREATE FUNCTION dbo.fnGetReferralBonus (@UserId uniqueidentifier)
RETURNS float
WITH EXECUTE AS CALLER
AS
BEGIN
     DECLARE @Result float;
     SET @Result =
	(SELECT Sum([Bonus])
	FROM [Referrals]
	where [ReferrerUserId] =  @UserId);
     RETURN(@Result);
END;
GO