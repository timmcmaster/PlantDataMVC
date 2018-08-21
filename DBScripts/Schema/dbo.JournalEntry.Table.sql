USE [PlantData]
GO
/****** Object:  Table [dbo].[JournalEntry]    Script Date: 07/24/2014 20:05:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalEntry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlantStockId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[JournalEntryTypeId] [int] NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[Source] [nvarchar](50) NULL,
	[SeedTrayId] [int] NULL,
	[Notes] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JournalEntry]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_PlantStock] FOREIGN KEY([PlantStockId])
REFERENCES [dbo].[PlantStock] ([Id])
GO
ALTER TABLE [dbo].[JournalEntry] CHECK CONSTRAINT [FK_Transactions_PlantStock]
GO
ALTER TABLE [dbo].[JournalEntry]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_SeedTray] FOREIGN KEY([SeedTrayId])
REFERENCES [dbo].[SeedTray] ([Id])
GO
ALTER TABLE [dbo].[JournalEntry] CHECK CONSTRAINT [FK_Transactions_SeedTray]
GO
ALTER TABLE [dbo].[JournalEntry]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_TransactionType] FOREIGN KEY([JournalEntryTypeId])
REFERENCES [dbo].[JournalEntryType] ([Id])
GO
ALTER TABLE [dbo].[JournalEntry] CHECK CONSTRAINT [FK_Transactions_TransactionType]
GO
