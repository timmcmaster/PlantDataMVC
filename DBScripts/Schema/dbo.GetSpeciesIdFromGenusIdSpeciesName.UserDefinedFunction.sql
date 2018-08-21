USE [PlantData]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSpeciesIdFromGenusIdSpeciesName]    Script Date: 07/24/2014 20:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tim McMaster
-- Create date: 19/02/2011
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetSpeciesIdFromGenusIdSpeciesName] 
(
	-- Add the parameters for the function here
	@genusId INT,
	@speciesName NCHAR(30)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result INT = -1;

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = Id 
	FROM dbo.Species 
	WHERE dbo.Species.GenusID = @genusId
	AND dbo.Species.LatinName = @speciesName; 

	-- Return the result of the function
	RETURN @Result

END
GO
