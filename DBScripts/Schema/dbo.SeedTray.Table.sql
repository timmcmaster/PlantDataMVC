USE [PlantData]
GO
/****** Object:  Table [dbo].[SeedTray]    Script Date: 07/24/2014 20:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeedTray](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SeedBatchId] [int] NOT NULL,
	[DatePlanted] [date] NOT NULL,
	[Treatment] [nvarchar](50) NULL,
	[ThrownOut] [bit] NOT NULL,
 CONSTRAINT [PK_SeedTray] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SeedTray]  WITH CHECK ADD  CONSTRAINT [FK_SeedTray_SeedBatch] FOREIGN KEY([SeedBatchId])
REFERENCES [dbo].[SeedBatch] ([Id])
GO
ALTER TABLE [dbo].[SeedTray] CHECK CONSTRAINT [FK_SeedTray_SeedBatch]
GO
