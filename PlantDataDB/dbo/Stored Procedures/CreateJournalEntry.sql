CREATE PROCEDURE [dbo].[CreateJournalEntry]
	@journalEntryTypeId int,
	@quantity int,
	@speciesId int,
	@productTypeId int,
	@transactionDate date,
	@source nvarchar(50),
	@notes nvarchar(50),
	@seedTrayId int,
    @result int output,
    @errorMessage nvarchar(256) output
AS
BEGIN
	set @result = 0;
	set @errorMessage = '';

	-- check parameters against DB data
	IF NOT EXISTS(select * FROM dbo.JournalEntryType j where j.Id = @journalEntryTypeId) 
	OR NOT EXISTS(select * FROM dbo.Species s where s.Id = @speciesId) 
	OR NOT EXISTS(select * FROM dbo.ProductType p where p.Id = @productTypeId) 
	BEGIN
	  -- set message
	  set @errorMessage = 'Invalid Id parameters';
	  set @result = -1;
	  RETURN @result;
	END

	IF (@seedTrayId IS NOT NULL) AND NOT EXISTS( select * FROM dbo.SeedTray s where s.Id = @seedTrayId)
	BEGIN
	  -- set message
	  set @errorMessage = 'Invalid SeedTrayId parameter';
	  set @result = -1;
	  RETURN @result;
	END


	-- find plant stock record for species and product type
	declare @plantStockId int;
	declare @journalEntryId int;

	-- if exists retrieve id
	IF NOT EXISTS (SELECT * FROM dbo.PlantStock ps WHERE ps.SpeciesId = @speciesId AND ps.ProductTypeId = @productTypeId)
		INSERT dbo.PlantStock (SpeciesId, ProductTypeId, QuantityInStock) VALUES (@speciesId,@productTypeId, 0);
	
	SET @plantStockId = (SELECT ps.Id FROM dbo.PlantStock ps WHERE ps.SpeciesId = @speciesId AND ps.ProductTypeId = @productTypeId);

	-- use plant stock id to insert transaction record
	INSERT dbo.JournalEntry (PlantStockId, Quantity, JournalEntryTypeId, TransactionDate, [Source], SeedTrayId, Notes)
	                 VALUES (@plantStockId, @quantity, @journalEntryTypeId, @transactionDate, @source, @seedTrayId, @notes);
	
	SET @journalEntryId = SCOPE_IDENTITY();


	-- get effect value from journal entry id
	-- update quantity of stock (add quantity of transaction * effect)
	UPDATE dbo.PlantStock
	SET QuantityInStock = ps.QuantityInStock + (je.Quantity * jet.Effect)
	FROM dbo.PlantStock ps 
	INNER JOIN dbo.JournalEntry je ON ps.Id = je.PlantStockId
	INNER JOIN dbo.JournalEntryType jet ON jet.Id = je.JournalEntryTypeId
	WHERE je.Id = @journalEntryId;

	RETURN @result;
END