USE [PlantData]
GO
/****** Object:  Table [dbo].[TubeInfo]    Script Date: 07/24/2014 20:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TubeInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SeedTrayId] [int] NOT NULL,
	[DatePrickedOut] [date] NULL,
	[NumberOfTubes] [int] NULL,
 CONSTRAINT [PK_TubeInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TubeInfo]  WITH CHECK ADD  CONSTRAINT [FK_TubeInfo_SeedPlanting] FOREIGN KEY([SeedTrayId])
REFERENCES [dbo].[SeedTray] ([Id])
GO
ALTER TABLE [dbo].[TubeInfo] CHECK CONSTRAINT [FK_TubeInfo_SeedPlanting]
GO
