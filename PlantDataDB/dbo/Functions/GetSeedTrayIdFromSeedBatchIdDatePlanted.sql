-- =============================================
-- Author:		Tim McMaster
-- Create date: 19/02/2011
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetSeedTrayIdFromSeedBatchIdDatePlanted] 
(
	-- Add the parameters for the function here
	@seedBatchId INT,
	@datePlanted DATE
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result INT = -1;

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = Id 
	FROM dbo.SeedTray
	WHERE dbo.SeedTray.SeedBatchId = @seedBatchId
	AND dbo.SeedTray.DatePlanted = @datePlanted;

	-- Return the result of the function
	RETURN @Result

END
