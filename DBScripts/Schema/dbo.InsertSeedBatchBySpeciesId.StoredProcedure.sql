USE [PlantData]
GO
/****** Object:  StoredProcedure [dbo].[InsertSeedBatchBySpeciesId]    Script Date: 07/24/2014 20:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSeedBatchBySpeciesId] 
	-- Add the parameters for the stored procedure here
	@speciesId INT, 
	@dateCollected DATE,
	@location NCHAR(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @CreatedBatchId INT;

    -- Insert statements for procedure here
	INSERT INTO SeedBatch (SpeciesId, DateCollected, Location)
	VALUES (@speciesId, @dateCollected, @location)
	
	SELECT @CreatedBatchId= dbo.SeedBatch.Id 
	FROM dbo.SeedBatch
	WHERE dbo.SeedBatch.SpeciesId = @speciesId
	AND dbo.SeedBatch.DateCollected = @dateCollected
	AND dbo.SeedBatch.Location = @location;
	
	RETURN @CreatedBatchId

END
GO
