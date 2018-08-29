CREATE PROCEDURE [dbo].[InsertTubeInfo] 
	-- Add the parameters for the stored procedure here
	@genusName NCHAR(30), 
	@speciesName NCHAR(30),
	@dateCollected DATE,
	@datePlanted DATE,
	@datePrickedOut DATE,
	@numberOfTubes INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @GenusId INT, @SpeciesId INT, @BatchId INT, @PlantingId INT;

	SET @GenusId = dbo.GetGenusId(@genusName);
	SET @SpeciesId = dbo.GetSpeciesIdFromGenusIdSpeciesName(@GenusId, @speciesName);
	SET @BatchId = dbo.GetSeedBatchIdFromSpeciesIdDateCollected(@SpeciesId, @dateCollected);
	SET @PlantingId = dbo.GetSeedTrayIdFromSeedBatchIdDatePlanted(@BatchId, @datePlanted);
	
	IF (@PlantingId >= 0)
	BEGIN
		INSERT INTO TubeInfo(SeedTrayId,  DatePrickedOut, NumberOfTubes)
		VALUES (@PlantingId, @datePrickedOut, @numberOfTubes)  
	END
END
