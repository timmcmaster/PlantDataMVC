CREATE PROCEDURE [dbo].[ChangeProductType]
	@journalEntryTypeId int,
	@quantity int,
	@speciesId int,
	@fromProductTypeId int,
	@toProductTypeId int,
	@transactionDate date,
	@source nvarchar(50),
	@notes nvarchar(50),
    @result int output,
    @errorMessage nvarchar(256) output
AS

-- Intention is to use this if repotting to different "product type"
BEGIN
	set @result = 0;
	set @errorMessage = '';

	-- check parameters against DB data
	IF NOT EXISTS(select * FROM dbo.JournalEntryType j where j.Id = @journalEntryTypeId) 
	OR NOT EXISTS(select * FROM dbo.Species s where s.Id = @speciesId) 
	OR NOT EXISTS(select * FROM dbo.ProductType p where p.Id = @fromProductTypeId) 
	OR NOT EXISTS(select * FROM dbo.ProductType p where p.Id = @toProductTypeId) 
	BEGIN
	  -- set message
	  set @errorMessage = 'Invalid Id parameters';
	  set @result = -1;
	  RETURN @result;
	END

	DECLARE @RC int;
	DECLARE @negQuantity int;
	DECLARE @jeResult int;
	DECLARE @jeErrorMessage nvarchar(256);

	SET @negQuantity = @quantity * -1;

	--TODO: Should be a transaction around these two, manage error handling

	-- Remove quantity from "from" product 
	EXECUTE @RC = [dbo].[CreateJournalEntry] 
	   @journalEntryTypeId
	  ,@negQuantity
	  ,@speciesId
	  ,@fromProductTypeId
	  ,@transactionDate
	  ,@source
	  ,@notes
	  ,@jeResult OUTPUT
	  ,@jeErrorMessage OUTPUT

	-- Add quantity to "to" product 
	EXECUTE @RC = [dbo].[CreateJournalEntry] 
	   @journalEntryTypeId
	  ,@quantity
	  ,@speciesId
	  ,@toProductTypeId
	  ,@transactionDate
	  ,@source
	  ,@notes
	  ,@jeResult OUTPUT
	  ,@jeErrorMessage OUTPUT

	RETURN @jeResult;
END