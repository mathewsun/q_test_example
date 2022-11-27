CREATE FUNCTION dbo.fnGetUserReferralsThirdLevel (@userId uniqueidentifier)
RETURNS table
AS
RETURN 
(
SELECT r.*, u.PublicId, u.UserName, rup2lvl.ReferrerUserId as refererUp2Lvl
FROM Referrals r
left join Referrals rup1lvl
on rup1lvl.ReferralUserId = r.ReferrerUserId
left join Referrals rup2lvl
on rup2lvl.ReferralUserId = rup1lvl.ReferrerUserId
left join Users u
on u.UserId = r.ReferralUserId
where rup2lvl.ReferrerUserId = @userId
);
GO