CREATE PROCEDURE [dbo].[InsertSpecies] 
	-- Add the parameters for the stored procedure here
	@genusName NCHAR(30), 
	@speciesName NCHAR(30),
	@commonName NCHAR(50),
	@description NCHAR(200),
	@maxPropagationTime INT,
	@isNative BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @GenusId INT;
	DECLARE @CreatedSpeciesId INT;

	SET @GenusId = dbo.GetGenusId(@genusName);
	
	IF (@GenusId = -1)
	BEGIN
		INSERT INTO dbo.Genus(LatinName) VALUES(@genusName);
	END

	SET @GenusId = dbo.GetGenusId(@genusName);
		
	INSERT INTO dbo.Species (GenusId, SpecificName, CommonName, Description, PropagationTime, Native)
	VALUES (@GenusId, @speciesName, @commonName, @description, @maxPropagationTime, @isNative);
	
	SELECT @CreatedSpeciesId = dbo.Species.Id 
	FROM dbo.Species
	WHERE dbo.Species.GenusId = @genusId
	AND dbo.Species.SpecificName = @speciesName;
	
	RETURN @CreatedSpeciesId
END