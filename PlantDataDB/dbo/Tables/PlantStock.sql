CREATE TABLE [dbo].[PlantStock] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [SpeciesId]       INT NOT NULL,
    [ProductTypeId]   INT NOT NULL,
    [QuantityInStock] INT NOT NULL,
    CONSTRAINT [PK_PlantStock_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PlantStock_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id]),
    CONSTRAINT [FK_PlantStock_Species] FOREIGN KEY ([SpeciesId]) REFERENCES [dbo].[Species] ([Id]),
    CONSTRAINT [UK_PlantStock] UNIQUE NONCLUSTERED ([SpeciesId] ASC, [ProductTypeId] ASC)
);

