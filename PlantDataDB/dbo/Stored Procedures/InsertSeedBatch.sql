CREATE PROCEDURE [dbo].[InsertSeedBatch] 
	-- Add the parameters for the stored procedure here
	@genusName NCHAR(30), 
	@speciesName NCHAR(30),
	@dateCollected DATE,
	@location NCHAR(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @GenusId INT, @SpeciesId INT;

	SET @GenusId = dbo.GetGenusId(@genusName);
	SET @SpeciesId = dbo.GetSpeciesIdFromGenusIdSpeciesName(@GenusId, @speciesName);
	
	IF (@SpeciesId >= 0)
	BEGIN
		INSERT INTO SeedBatch (SpeciesId, DateCollected, Location)
		VALUES (@SpeciesId, @dateCollected, @location)  
	END
END
