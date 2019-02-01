SET IDENTITY_INSERT [dbo].[ProductType] ON
INSERT INTO [dbo].[ProductType] ([Id], [Name]) VALUES (1, N'Tube')
INSERT INTO [dbo].[ProductType] ([Id], [Name]) VALUES (2, N'Medium Pot')
INSERT INTO [dbo].[ProductType] ([Id], [Name]) VALUES (3, N'Large Pot')
SET IDENTITY_INSERT [dbo].[ProductType] OFF

SET IDENTITY_INSERT [dbo].[PriceListType] ON
INSERT INTO [dbo].[PriceListType] ([Id], [Name], [Kind]) VALUES (1, N'Market Prices', N'R')
INSERT INTO [dbo].[PriceListType] ([Id], [Name], [Kind]) VALUES (2, N'Friends Prices', N'R')
SET IDENTITY_INSERT [dbo].[PriceListType] OFF

-- prices for price list types
INSERT INTO [dbo].[ProductPrice] ([PriceListTypeId], [ProductTypeId], [Price], [DateEffective]) VALUES (1, 1, CAST(3.00 AS Decimal(18, 2)), N'2011-01-01')
INSERT INTO [dbo].[ProductPrice] ([PriceListTypeId], [ProductTypeId], [Price], [DateEffective]) VALUES (1, 2, CAST(4.00 AS Decimal(18, 2)), N'2011-01-01')
INSERT INTO [dbo].[ProductPrice] ([PriceListTypeId], [ProductTypeId], [Price], [DateEffective]) VALUES (1, 3, CAST(8.00 AS Decimal(18, 2)), N'2011-01-01')
INSERT INTO [dbo].[ProductPrice] ([PriceListTypeId], [ProductTypeId], [Price], [DateEffective]) VALUES (2, 1, CAST(0.50 AS Decimal(18, 2)), N'2011-01-01')
INSERT INTO [dbo].[ProductPrice] ([PriceListTypeId], [ProductTypeId], [Price], [DateEffective]) VALUES (2, 2, CAST(1.00 AS Decimal(18, 2)), N'2011-01-01')
INSERT INTO [dbo].[ProductPrice] ([PriceListTypeId], [ProductTypeId], [Price], [DateEffective]) VALUES (2, 3, CAST(2.00 AS Decimal(18, 2)), N'2011-01-01')

-- transaction types
SET IDENTITY_INSERT [dbo].[JournalEntryType] ON
INSERT INTO [dbo].[JournalEntryType] ([Id],[Name],[Effect]) VALUES (1, N'SALE', -1)
INSERT INTO [dbo].[JournalEntryType] ([Id],[Name],[Effect]) VALUES (2, N'PLANT DIED', -1)
INSERT INTO [dbo].[JournalEntryType] ([Id],[Name],[Effect]) VALUES (3, N'POTTED FROM SEED TRAY', 1)
INSERT INTO [dbo].[JournalEntryType] ([Id],[Name],[Effect]) VALUES (4, N'GIFT RECEIVED', 1)
INSERT INTO [dbo].[JournalEntryType] ([Id],[Name],[Effect]) VALUES (5, N'GIFT GIVEN', -1)
INSERT INTO [dbo].[JournalEntryType] ([Id],[Name],[Effect]) VALUES (6, N'PLANTED', -1)
INSERT INTO [dbo].[JournalEntryType] ([Id],[Name],[Effect]) VALUES (7, N'PURCHASE', 1)
INSERT INTO [dbo].[JournalEntryType] ([Id],[Name],[Effect]) VALUES (8, N'POTTED FROM CUTTING', 1)
INSERT INTO [dbo].[JournalEntryType] ([Id],[Name],[Effect]) VALUES (9, N'STOCK ADJUSTMENT', 1)
SET IDENTITY_INSERT [dbo].[JournalEntryType] OFF