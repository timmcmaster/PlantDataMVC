CREATE PROCEDURE [dbo].[UpdateSpecies] 
	-- Add the parameters for the stored procedure here
	@speciesId INT, 
	@genusName NCHAR(30), 
	@speciesName NCHAR(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @GenusID INT;

	SET @GenusID = dbo.GetGenusId(@genusName);
	
	IF (@GenusID = -1)
	BEGIN
		INSERT INTO dbo.Genus(LatinName) values(@genusName);
	END

	SET @GenusID = dbo.GetGenusId(@genusName);
		
	UPDATE dbo.Species 
	SET GenusId = @GenusId,
		SpecificName = @speciesName
	WHERE dbo.Species.Id = @speciesId;
	
	RETURN @speciesId
END