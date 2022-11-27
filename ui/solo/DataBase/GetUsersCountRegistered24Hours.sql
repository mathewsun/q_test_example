ALTER PROCEDURE  [dbo].[spGetUsersCountRegistered24Hours]
@Result int OUTPUT
AS
BEGIN

	SET @Result =
	(
	SELECT Count(u.UserId)
	FROM [dbo].[Users] u
	LEFT JOIN Memberships m
	on u.UserId = m.UserId
	WHERE m.CreateDate >= DATEADD(day, -1, GETDATE())
	);
END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spGetUsersCountRegistered24Hours] TO PUBLIC
    AS [dbo];
