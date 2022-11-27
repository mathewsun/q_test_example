CREATE PROCEDURE  [dbo].[spAddQiwiBalanceUpdatePerMonth]
@number nvarchar(50), @amount float
AS
BEGIN

	UPDATE Phones
	SET BalanceUpdatePerMonth = BalanceUpdatePerMonth + @amount
	WHERE Number = @number;

END
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[spAddQiwiBalanceUpdatePerMonth] TO PUBLIC
    AS [dbo];
