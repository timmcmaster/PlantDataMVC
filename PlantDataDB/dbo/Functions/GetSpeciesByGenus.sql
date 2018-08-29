-- =============================================
-- Author:		Tim McMaster
-- Create date: 23/2/2011
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetSpeciesByGenus] 
(	
	-- Add the parameters for the function here
	@genusName NCHAR(30)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT dbo.Species.* 
	FROM dbo.Genus, dbo.Species
	WHERE dbo.Genus.Id = dbo.Species.GenusId
	AND dbo.Genus.LatinName LIKE '' + RTRIM(@genusName) + '%'
)
