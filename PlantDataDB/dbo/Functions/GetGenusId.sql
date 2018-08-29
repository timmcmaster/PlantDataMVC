-- =============================================
-- Author:		Tim McMaster
-- Create date: 19/02/2011
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetGenusId] 
(
	-- Add the parameters for the function here
	@genusName NCHAR(30)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result INT = -1;

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = Id 
	FROM dbo.Genus 
	WHERE LatinName = @genusName; 

	-- Return the result of the function
	RETURN @Result;

END
