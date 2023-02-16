CREATE TABLE [dbo].[JournalEntry] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [SpeciesId]          INT           NOT NULL,
    [ProductTypeId]      INT           NOT NULL,
    [Quantity]           INT           NOT NULL,
    [JournalEntryTypeId] INT           NOT NULL,
    [TransactionDate]    DATE          NOT NULL,
    [Source]             NVARCHAR (50) NULL,
    [SeedTrayId]         INT           NULL,
    [Notes]              NVARCHAR (50) NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions_Species] FOREIGN KEY ([SpeciesId]) REFERENCES [dbo].[Species] ([Id]),
    CONSTRAINT [FK_Transactions_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id]),
    CONSTRAINT [FK_Transactions_SeedTray] FOREIGN KEY ([SeedTrayId]) REFERENCES [dbo].[SeedTray] ([Id]),
    CONSTRAINT [FK_Transactions_TransactionType] FOREIGN KEY ([JournalEntryTypeId]) REFERENCES [dbo].[JournalEntryType] ([Id])
);

