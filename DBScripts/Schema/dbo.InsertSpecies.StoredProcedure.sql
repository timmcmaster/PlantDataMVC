USE [PlantData]
GO
/****** Object:  StoredProcedure [dbo].[InsertSpecies]    Script Date: 07/24/2014 20:05:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
		
	INSERT INTO dbo.Species (GenusId, LatinName, CommonName, Description, PropagationTime, Native)
	VALUES (@GenusId, @speciesName, @commonName, @description, @maxPropagationTime, @isNative);
	
	SELECT @CreatedSpeciesId = dbo.Species.Id 
	FROM dbo.Species
	WHERE dbo.Species.GenusId = @genusId
	AND dbo.Species.LatinName = @speciesName;
	
	RETURN @CreatedSpeciesId
END
GO
