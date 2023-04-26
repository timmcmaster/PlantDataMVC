USE [PlantDataDB]
GO
SET IDENTITY_INSERT [dbo].[ProductPrice] ON 

INSERT [dbo].[ProductPrice] ([Id], [PriceListTypeId], [ProductTypeId], [Price], [DateEffective], [BarcodeSKU]) VALUES (1, 1, 1, CAST(3.00 AS Decimal(18, 2)), CAST(N'2011-01-01' AS Date), N'')
INSERT [dbo].[ProductPrice] ([Id], [PriceListTypeId], [ProductTypeId], [Price], [DateEffective], [BarcodeSKU]) VALUES (2, 1, 2, CAST(4.00 AS Decimal(18, 2)), CAST(N'2011-01-01' AS Date), N'')
INSERT [dbo].[ProductPrice] ([Id], [PriceListTypeId], [ProductTypeId], [Price], [DateEffective], [BarcodeSKU]) VALUES (3, 1, 3, CAST(8.00 AS Decimal(18, 2)), CAST(N'2011-01-01' AS Date), N'')
INSERT [dbo].[ProductPrice] ([Id], [PriceListTypeId], [ProductTypeId], [Price], [DateEffective], [BarcodeSKU]) VALUES (4, 2, 1, CAST(0.50 AS Decimal(18, 2)), CAST(N'2011-01-01' AS Date), N'')
INSERT [dbo].[ProductPrice] ([Id], [PriceListTypeId], [ProductTypeId], [Price], [DateEffective], [BarcodeSKU]) VALUES (5, 2, 2, CAST(1.00 AS Decimal(18, 2)), CAST(N'2011-01-01' AS Date), N'')
INSERT [dbo].[ProductPrice] ([Id], [PriceListTypeId], [ProductTypeId], [Price], [DateEffective], [BarcodeSKU]) VALUES (6, 2, 3, CAST(2.00 AS Decimal(18, 2)), CAST(N'2011-01-01' AS Date), N'')
SET IDENTITY_INSERT [dbo].[ProductPrice] OFF
GO
