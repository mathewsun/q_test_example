CREATE FUNCTION dbo.fnGetUserReferralsSecondLevel (@userId uniqueidentifier)
RETURNS table
AS
RETURN 
(
SELECT r.*, u.PublicId, u.UserName, rup1lvl.ReferrerUserId as refererUp1Lvl
FROM Referrals r
left join Referrals rup1lvl
on rup1lvl.ReferralUserId = r.ReferrerUserId
left join Users u
on u.UserId = r.ReferralUserId
where rup1lvl.ReferrerUserId = @userId
);
GO