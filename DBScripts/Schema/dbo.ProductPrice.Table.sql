USE [PlantData]
GO
/****** Object:  Table [dbo].[ProductPrice]    Script Date: 07/24/2014 20:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPrice](
	[PriceListTypeId] [int] NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DateEffective] [date] NOT NULL,
 CONSTRAINT [PK_ProductPrices] PRIMARY KEY CLUSTERED 
(
	[PriceListTypeId] ASC,
	[ProductTypeId] ASC,
	[DateEffective] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductPrice]  WITH CHECK ADD  CONSTRAINT [FK_ProductPrices_PriceListType] FOREIGN KEY([PriceListTypeId])
REFERENCES [dbo].[PriceListType] ([Id])
GO
ALTER TABLE [dbo].[ProductPrice] CHECK CONSTRAINT [FK_ProductPrices_PriceListType]
GO
ALTER TABLE [dbo].[ProductPrice]  WITH CHECK ADD  CONSTRAINT [FK_ProductPrices_ProductType] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[ProductPrice] CHECK CONSTRAINT [FK_ProductPrices_ProductType]
GO
