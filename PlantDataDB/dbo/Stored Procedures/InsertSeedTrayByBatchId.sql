CREATE PROCEDURE [dbo].[InsertSeedTrayByBatchId] 
	-- Add the parameters for the stored procedure here
	@batchId INT, 
	@datePlanted DATE,
	@treatment NCHAR(50),
	@disposed BIT = false
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @CreatedTrayId INT;

    -- Insert statements for procedure here
	INSERT INTO SeedTray (SeedBatchId, DatePlanted, Treatment, ThrownOut)
	VALUES (@batchId, @datePlanted, @treatment, @disposed)  
	
	SELECT @CreatedTrayId = MAX(dbo.SeedTray.Id)
	FROM dbo.SeedTray
	WHERE dbo.SeedTray.SeedBatchId = @batchId
	AND dbo.SeedTray.DatePlanted = @datePlanted
	AND dbo.SeedTray.Treatment = @treatment;
	
	RETURN @CreatedTrayId
END
