-- =============================================
-- Author:		Tim McMaster
-- Create date: 17/3/2011
-- Description:	Gets the price for an item at a given date for a given pricelist
-- =============================================
CREATE FUNCTION [dbo].[GetPrice] 
(
	-- Add the parameters for the function here
	@pricelistTypeId int, 
	@productTypeId int, 
	@transactionDate date
)
RETURNS decimal(18,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result decimal(18,2)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = 
		(SELECT TOP(1) pp.Price
		 FROM ProductPrice pp
		 WHERE pp.PriceListTypeId = @pricelistTypeId
		 AND pp.ProductTypeId = @productTypeId
		 AND pp.DateEffective < @transactionDate
		 ORDER BY pp.DateEffective DESC);

	-- Return the result of the function
	RETURN @Result

END
