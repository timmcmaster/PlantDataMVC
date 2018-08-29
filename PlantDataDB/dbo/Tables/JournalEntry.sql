CREATE TABLE [dbo].[JournalEntry] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [PlantStockId]       INT           NOT NULL,
    [Quantity]           INT           NOT NULL,
    [JournalEntryTypeId] INT           NOT NULL,
    [TransactionDate]    DATE          NOT NULL,
    [Source]             NVARCHAR (50) NULL,
    [SeedTrayId]         INT           NULL,
    [Notes]              NVARCHAR (50) NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions_PlantStock] FOREIGN KEY ([PlantStockId]) REFERENCES [dbo].[PlantStock] ([Id]),
    CONSTRAINT [FK_Transactions_SeedTray] FOREIGN KEY ([SeedTrayId]) REFERENCES [dbo].[SeedTray] ([Id]),
    CONSTRAINT [FK_Transactions_TransactionType] FOREIGN KEY ([JournalEntryTypeId]) REFERENCES [dbo].[JournalEntryType] ([Id])
);

