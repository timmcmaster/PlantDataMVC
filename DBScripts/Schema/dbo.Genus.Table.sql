USE [PlantData]
GO
/****** Object:  Table [dbo].[Genus]    Script Date: 07/24/2014 20:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LatinName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Genus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
