USE [PlantData]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 07/24/2014 20:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [nvarchar](50) NULL,
	[Suburb] [nvarchar](50) NULL,
	[Latitude] [decimal](8,5) NULL,
	[Longitude] [decimal](8, 5) NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
