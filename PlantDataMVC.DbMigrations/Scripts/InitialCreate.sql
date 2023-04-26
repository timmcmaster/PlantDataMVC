IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [dbo].[Genus] (
    [Id] int NOT NULL IDENTITY,
    [LatinName] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Genus] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[JournalEntryType] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Effect] int NOT NULL,
    CONSTRAINT [PK_JournalEntryType] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[PriceListType] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Kind] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_PriceListType] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[ProductType] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[SaleEvent] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(30) NULL,
    [SaleDate] date NULL,
    [Location] nvarchar(30) NULL,
    CONSTRAINT [PK_SaleEvent] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[Site] (
    [Id] int NOT NULL IDENTITY,
    [SiteName] nvarchar(50) NULL,
    [Suburb] nvarchar(50) NULL,
    [Latitude] decimal(18,0) NULL,
    [Longitude] decimal(18,0) NULL,
    CONSTRAINT [PK_Site] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[Species] (
    [Id] int NOT NULL IDENTITY,
    [GenusId] int NOT NULL,
    [SpecificName] nvarchar(30) NOT NULL,
    [CommonName] nvarchar(50) NULL,
    [Description] nvarchar(200) NULL,
    [PropagationTime] int NULL,
    [Native] bit NOT NULL,
    CONSTRAINT [PK_Species] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Species_Genus_GenusId] FOREIGN KEY ([GenusId]) REFERENCES [dbo].[Genus] ([Id])
);
GO

CREATE TABLE [dbo].[ProductPrice] (
    [Id] int NOT NULL IDENTITY,
    [PriceListTypeId] int NOT NULL,
    [ProductTypeId] int NOT NULL,
    [Price] decimal(18,0) NOT NULL,
    [DateEffective] date NOT NULL,
    CONSTRAINT [PK_ProductPrice] PRIMARY KEY ([Id]),
    CONSTRAINT [AK_ProductPrice_ProductType_PriceListType_Date] UNIQUE ([PriceListTypeId], [ProductTypeId], [DateEffective]),
    CONSTRAINT [FK_ProductPrice_PriceListType_PriceListTypeId] FOREIGN KEY ([PriceListTypeId]) REFERENCES [dbo].[PriceListType] ([Id]),
    CONSTRAINT [FK_ProductPrice_ProductType_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id])
);
GO

CREATE TABLE [dbo].[PlantStock] (
    [Id] int NOT NULL IDENTITY,
    [SpeciesId] int NOT NULL,
    [ProductTypeId] int NOT NULL,
    [QuantityInStock] int NOT NULL,
    CONSTRAINT [PK_PlantStock] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PlantStock_ProductType_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id]),
    CONSTRAINT [FK_PlantStock_Species_SpeciesId] FOREIGN KEY ([SpeciesId]) REFERENCES [dbo].[Species] ([Id])
);
GO

CREATE TABLE [dbo].[SaleEventStock] (
    [Id] int NOT NULL IDENTITY,
    [SaleEventId] int NOT NULL,
    [SpeciesId] int NOT NULL,
    [ProductTypeId] int NOT NULL,
    [Quantity] int NOT NULL,
    CONSTRAINT [PK_SaleEventStock] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SaleEventStock_ProductType_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SaleEventStock_SaleEvent] FOREIGN KEY ([SaleEventId]) REFERENCES [dbo].[SaleEvent] ([Id]),
    CONSTRAINT [FK_SaleEventStock_Species_SpeciesId] FOREIGN KEY ([SpeciesId]) REFERENCES [dbo].[Species] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[SeedBatch] (
    [Id] int NOT NULL IDENTITY,
    [SpeciesId] int NOT NULL,
    [DateCollected] date NOT NULL,
    [Location] nvarchar(30) NULL,
    [Notes] nvarchar(200) NULL,
    [SiteId] int NULL,
    [Emptied] bit NOT NULL,
    CONSTRAINT [PK_SeedBatch] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SeedBatch_Site_SiteId] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([Id]),
    CONSTRAINT [FK_SeedBatch_Species_SpeciesId] FOREIGN KEY ([SpeciesId]) REFERENCES [dbo].[Species] ([Id])
);
GO

CREATE TABLE [dbo].[SeedTray] (
    [Id] int NOT NULL IDENTITY,
    [SeedBatchId] int NOT NULL,
    [DatePlanted] date NOT NULL,
    [Treatment] nvarchar(50) NULL,
    [ThrownOut] bit NOT NULL,
    CONSTRAINT [PK_SeedTray] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SeedTray_SeedBatch_SeedBatchId] FOREIGN KEY ([SeedBatchId]) REFERENCES [dbo].[SeedBatch] ([Id])
);
GO

CREATE TABLE [dbo].[JournalEntry] (
    [Id] int NOT NULL IDENTITY,
    [SpeciesId] int NOT NULL,
    [ProductTypeId] int NOT NULL,
    [Quantity] int NOT NULL,
    [JournalEntryTypeId] int NOT NULL,
    [TransactionDate] date NOT NULL,
    [Source] nvarchar(50) NULL,
    [SeedTrayId] int NULL,
    [Notes] nvarchar(50) NULL,
    CONSTRAINT [PK_JournalEntry] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JournalEntry_JournalEntryType_JournalEntryTypeId] FOREIGN KEY ([JournalEntryTypeId]) REFERENCES [dbo].[JournalEntryType] ([Id]),
    CONSTRAINT [FK_JournalEntry_ProductType_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_JournalEntry_SeedTray_SeedTrayId] FOREIGN KEY ([SeedTrayId]) REFERENCES [dbo].[SeedTray] ([Id]),
    CONSTRAINT [FK_JournalEntry_Species_SpeciesId] FOREIGN KEY ([SpeciesId]) REFERENCES [dbo].[Species] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_JournalEntry_JournalEntryTypeId] ON [dbo].[JournalEntry] ([JournalEntryTypeId]);
GO

CREATE INDEX [IX_JournalEntry_ProductTypeId] ON [dbo].[JournalEntry] ([ProductTypeId]);
GO

CREATE INDEX [IX_JournalEntry_SeedTrayId] ON [dbo].[JournalEntry] ([SeedTrayId]);
GO

CREATE INDEX [IX_JournalEntry_SpeciesId] ON [dbo].[JournalEntry] ([SpeciesId]);
GO

CREATE INDEX [IX_PlantStock_ProductTypeId] ON [dbo].[PlantStock] ([ProductTypeId]);
GO

CREATE INDEX [IX_PlantStock_SpeciesId] ON [dbo].[PlantStock] ([SpeciesId]);
GO

CREATE INDEX [IX_ProductPrice_ProductTypeId] ON [dbo].[ProductPrice] ([ProductTypeId]);
GO

CREATE INDEX [IX_SaleEventStock_ProductTypeId] ON [dbo].[SaleEventStock] ([ProductTypeId]);
GO

CREATE INDEX [IX_SaleEventStock_SaleEventId] ON [dbo].[SaleEventStock] ([SaleEventId]);
GO

CREATE INDEX [IX_SaleEventStock_SpeciesId] ON [dbo].[SaleEventStock] ([SpeciesId]);
GO

CREATE INDEX [IX_SeedBatch_SiteId] ON [dbo].[SeedBatch] ([SiteId]);
GO

CREATE INDEX [IX_SeedBatch_SpeciesId] ON [dbo].[SeedBatch] ([SpeciesId]);
GO

CREATE INDEX [IX_SeedTray_SeedBatchId] ON [dbo].[SeedTray] ([SeedBatchId]);
GO

CREATE INDEX [IX_Species_GenusId] ON [dbo].[Species] ([GenusId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230425130016_InitialCreate', N'7.0.5');
GO

COMMIT;
GO

