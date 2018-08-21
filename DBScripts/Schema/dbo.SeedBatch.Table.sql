USE [PlantData]
GO
/****** Object:  Table [dbo].[SeedBatch]    Script Date: 07/24/2014 20:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeedBatch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpeciesId] [int] NOT NULL,
	[DateCollected] [date] NOT NULL,
	[Location] [nvarchar](30) NULL,
	[Notes] [nvarchar](200) NULL,
	[SiteId] [int] NULL,
 CONSTRAINT [PK_SeedBatch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SeedBatch]  WITH CHECK ADD  CONSTRAINT [FK_SeedBatch_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[SeedBatch] CHECK CONSTRAINT [FK_SeedBatch_Site]
GO
ALTER TABLE [dbo].[SeedBatch]  WITH CHECK ADD  CONSTRAINT [FK_SeedBatch_Species] FOREIGN KEY([SpeciesId])
REFERENCES [dbo].[Species] ([Id])
GO
ALTER TABLE [dbo].[SeedBatch] CHECK CONSTRAINT [FK_SeedBatch_Species]
GO
