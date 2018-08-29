CREATE PROCEDURE [dbo].[InsertSeedTray] 
	-- Add the parameters for the stored procedure here
	@genusName NCHAR(30), 
	@speciesName NCHAR(30),
	@dateCollected DATE,
	@datePlanted DATE,
	@treatment NCHAR(50),
	@disposed BIT = false
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @GenusId INT, @SpeciesId INT, @BatchId INT;

	SET @GenusId = dbo.GetGenusId(@genusName);
	SET @SpeciesId = dbo.GetSpeciesIdFromGenusIdSpeciesName(@GenusId, @speciesName);
	SET @BatchId = dbo.GetSeedBatchIdFromSpeciesIdDateCollected(@SpeciesId, @dateCollected);
	
	IF (@BatchId >= 0)
	BEGIN
		INSERT INTO SeedTray (SeedBatchId, DatePlanted, Treatment, ThrownOut)
		VALUES (@BatchId, @datePlanted, @treatment, @disposed)  
	END
END
