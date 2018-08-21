USE [PlantData]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSeedBatchIdFromSpeciesIdDateCollected]    Script Date: 07/24/2014 20:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tim McMaster
-- Create date: 19/02/2011
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetSeedBatchIdFromSpeciesIdDateCollected] 
(
	-- Add the parameters for the function here
	@speciesId int,
	@dateCollected date
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result int = -1;

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = Id 
	FROM dbo.SeedBatch 
	WHERE dbo.SeedBatch.SpeciesId = @speciesId
	AND dbo.SeedBatch.DateCollected = @dateCollected;

	-- Return the result of the function
	RETURN @Result

END
GO
