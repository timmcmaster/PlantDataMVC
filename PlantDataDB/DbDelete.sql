-- delete "user" data
DELETE FROM [dbo].[JournalEntry]
DELETE FROM [dbo].[PlantStock]
DELETE FROM [dbo].[SeedTray]
DELETE FROM [dbo].[SeedBatch]
DELETE FROM [dbo].[Site]
DELETE FROM [dbo].[Species]
DELETE FROM [dbo].[Genus]

-- delete admin data
DELETE FROM [dbo].[ProductPrice]
DELETE FROM [dbo].[ProductType]
DELETE FROM [dbo].[PriceListType]
DELETE FROM [dbo].[JournalEntryType]

