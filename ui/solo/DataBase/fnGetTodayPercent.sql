CREATE FUNCTION dbo.fnGetTodayPercent ()
RETURNS float
WITH EXECUTE AS CALLER
AS
BEGIN
	DECLARE @Result float;
	SET @Result = 1.5;
	RETURN(@Result);
END;
GO