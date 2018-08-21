USE [PlantData]
GO
/****** Object:  Table [dbo].[Species]    Script Date: 07/24/2014 20:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Species](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GenusId] [int] NOT NULL,
	[LatinName] [nvarchar](30) NOT NULL,
	[CommonName] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[PropagationTime] [int] NULL,
	[Native] [bit] NOT NULL,
 CONSTRAINT [PK_Species] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_GenusSpecies] UNIQUE NONCLUSTERED 
(
	[GenusId] ASC,
	[LatinName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Species]  WITH CHECK ADD  CONSTRAINT [FK_Species_Genus] FOREIGN KEY([GenusId])
REFERENCES [dbo].[Genus] ([Id])
GO
ALTER TABLE [dbo].[Species] CHECK CONSTRAINT [FK_Species_Genus]
GO
