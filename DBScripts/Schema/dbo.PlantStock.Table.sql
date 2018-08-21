USE [PlantData]
GO
/****** Object:  Table [dbo].[PlantStock]    Script Date: 07/24/2014 20:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlantStock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpeciesId] [int] NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[QuantityInStock] [int] NOT NULL,
 CONSTRAINT [PK_PlantStock_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_PlantStock] UNIQUE NONCLUSTERED 
(
	[SpeciesId] ASC,
	[ProductTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PlantStock]  WITH CHECK ADD  CONSTRAINT [FK_PlantStock_ProductType] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[PlantStock] CHECK CONSTRAINT [FK_PlantStock_ProductType]
GO
ALTER TABLE [dbo].[PlantStock]  WITH CHECK ADD  CONSTRAINT [FK_PlantStock_Species] FOREIGN KEY([SpeciesId])
REFERENCES [dbo].[Species] ([Id])
GO
ALTER TABLE [dbo].[PlantStock] CHECK CONSTRAINT [FK_PlantStock_Species]
GO
