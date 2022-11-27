CREATE PROCEDURE  dbo.cpSubmitCitiesCount
AS
BEGIN
	UPDATE Cities
	SET VkCount = (SELECT count(*)
				FROM VkontakteAccounts
				WHERE VkontakteAccounts.Location = Cities.Name
				);
END

GO
GRANT EXECUTE
    ON OBJECT::[dbo].cpSubmitCitiesCount TO PUBLIC
    AS [dbo];