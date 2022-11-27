ALTER PROCEDURE  [dbo].[spGetRefferals]
@UserId uniqueidentifier
AS
BEGIN
	
SELECT r.[Id]
      ,r.[ReferrerUserId]
      ,r.[ReferralUserId]
      ,r.[WhenDate]
	  ,u.PublicId
	  ,u.Earned
	  ,u.EarnedToday
	  ,u.Balance
	  ,m.CreateDate
  FROM [Referrals] r
  LEFT JOIN Users u
  ON r.[ReferralUserId] = u.UserId
  left join Memberships m
  on r.[ReferralUserId] = m.UserId
 where [ReferrerUserId] = @UserId
	OR      @UserId IS NULL
 order by m.CreateDate desc

END
GO


GRANT EXECUTE
    ON OBJECT::[dbo].[spGetRefferals] TO PUBLIC
    AS [dbo];