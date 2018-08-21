USE [PlantData]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSpeciesByGenus]    Script Date: 07/24/2014 20:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
