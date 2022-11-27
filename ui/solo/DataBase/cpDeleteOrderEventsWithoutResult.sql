CREATE PROCEDURE  dbo.cpDeleteOrderEventsWithoutResult
AS
BEGIN
	delete from [OrderEvents]
	where Result = 0
	AND WhenDate < DateADD(mi, -5, Current_TimeStamp)
END

GO
GRANT EXECUTE
    ON OBJECT::[dbo].cpDeleteOrderEventsWithoutResult TO PUBLIC
    AS [dbo];