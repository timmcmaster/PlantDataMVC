BEGIN TRANSACTION;
GO

CREATE TABLE [Stocktake] (
    [Id] int NOT NULL IDENTITY,
    [StocktakeDate] datetime2 NOT NULL,
    [Reference] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Stocktake] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [StocktakeLine] (
    [Id] int NOT NULL IDENTITY,
    [HeaderId] int NOT NULL,
    [SpeciesId] int NOT NULL,
    [ProductTypeId] int NOT NULL,
    [ExpectedQuantity] int NOT NULL,
    [CountedQuantity] int NOT NULL,
    [Applied] bit NOT NULL,
    CONSTRAINT [PK_StocktakeLine] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_StocktakeLine_ProductType_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StocktakeLine_Species_SpeciesId] FOREIGN KEY ([SpeciesId]) REFERENCES [dbo].[Species] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StocktakeLine_Stocktake_HeaderId] FOREIGN KEY ([HeaderId]) REFERENCES [Stocktake] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_StocktakeLine_HeaderId] ON [StocktakeLine] ([HeaderId]);
GO

CREATE INDEX [IX_StocktakeLine_ProductTypeId] ON [StocktakeLine] ([ProductTypeId]);
GO

CREATE INDEX [IX_StocktakeLine_SpeciesId] ON [StocktakeLine] ([SpeciesId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240515033938_Stocktake', N'8.0.4');
GO

COMMIT;
GO


