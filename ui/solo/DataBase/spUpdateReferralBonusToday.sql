CREATE PROCEDURE  dbo.spUpdateReferralBonusToday
AS
BEGIN

declare @ReferralPercentFirstLevel int
SET @ReferralPercentFirstLevel = (SELECT [Value] FROM [Settings] WHERE [Name] = 'ReferralPercent')

declare @ReferralPercentSecondLevel int
SET @ReferralPercentSecondLevel = (SELECT [Value] FROM [Settings] WHERE [Name] = 'ReferralPercent2')

declare @ReferralPercentThirdLevel int
SET @ReferralPercentThirdLevel = (SELECT [Value] FROM [Settings] WHERE [Name] = 'ReferralPercent3')

------ 1 level

declare @1level table
(BonusTodaySum float, UserId uniqueidentifier)

insert into @1level SELECT sum(ur.[EarnedToday]) / 100 * @ReferralPercentFirstLevel, r.[ReferrerUserId]
FROM Users ur
LEFT JOIN Referrals r
ON ur.[UserId] = r.ReferralUserId
where r.[ReferrerUserId] is not null
group by r.[ReferrerUserId]
having sum(ur.[EarnedToday]) / 100 * @ReferralPercentFirstLevel > 0

UPDATE Users
SET Users.Balance = Users.Balance + ISNULL(tt.BonusTodaySum, 0)
FROM Users
left join (select * from @1level) tt
on Users.UserId = tt.UserId

insert into [Operations] 
SELECT r.ReferrerUserId, sum(ur.[EarnedToday]) / 100 * @ReferralPercentFirstLevel, 1, 'Ежедневное начисление общего дохода от рефералов I-го уровня', GETDATE()
FROM Users ur
LEFT JOIN Referrals r
ON ur.[UserId] = r.ReferralUserId
where r.[ReferrerUserId] is not null
group by r.[ReferrerUserId]
having sum(ur.[EarnedToday]) / 100 * @ReferralPercentFirstLevel > 0

-------- 2 level

declare @2level table
(BonusTodaySum float, UserId uniqueidentifier)

insert into @2level SELECT sum(u1.EarnedToday / 100 * @ReferralPercentSecondLevel), r2.ReferrerUserId
FROM [Referrals] r1
  left join Users u1
  on u1.UserId = r1.[ReferralUserId]
  left join [Referrals] r2
  on r1.ReferrerUserId = r2.ReferralUserId
where r2.ReferrerUserId is not null
group by r2.ReferrerUserId
having sum(u1.EarnedToday / 100 * @ReferralPercentSecondLevel) > 0

UPDATE Users
SET Users.Balance = Users.Balance + ISNULL(tt.BonusTodaySum, 0)
FROM Users
left join (select * from @2level) tt
on Users.UserId = tt.UserId

insert into [Operations] SELECT r.UserId, sum(r.BonusTodaySum), 1, 'Ежедневное начисление общего дохода от рефералов II-го уровня', GETDATE()
FROM @2level r
group by r.UserId

------- 3 level

declare @3level table
(BonusTodaySum float, UserId uniqueidentifier)

insert into @3level SELECT sum(u1.EarnedToday) / 100 * @ReferralPercentThirdLevel, r3.ReferrerUserId as refererUp3Lvl
FROM [Referrals] r1
left join Users u1
on u1.UserId = r1.[ReferralUserId]
left join [Referrals] r2
on r1.ReferrerUserId = r2.ReferralUserId
left join [Referrals] r3
on r2.ReferrerUserId = r3.ReferralUserId
where r3.ReferrerUserId is not null
group by r3.ReferrerUserId 
having sum(u1.EarnedToday / 100 * @ReferralPercentThirdLevel) > 0

UPDATE Users
SET Users.Balance = Users.Balance + ISNULL(tt.BonusTodaySum, 0)
FROM Users
left join (select * from @3level) tt
on Users.UserId = tt.UserId

insert into [Operations] SELECT r.UserId, sum(r.BonusTodaySum), 1, 'Ежедневное начисление общего дохода от рефералов III-го уровня', GETDATE()
FROM @3level r
group by r.UserId

------ Clear BonusToday

UPDATE Users
SET EarnedToday = 0

END

GO

GRANT EXECUTE
    ON OBJECT::[dbo].spUpdateReferralBonusToday TO PUBLIC
    AS [dbo];