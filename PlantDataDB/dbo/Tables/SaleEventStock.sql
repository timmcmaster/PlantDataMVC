CREATE TABLE [dbo].[SaleEventStock]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[SaleEventId] INT NOT NULL,
    [SpeciesId]          INT           NOT NULL,
    [ProductTypeId]      INT           NOT NULL,
	[Quantity] INT NOT NULL,
    CONSTRAINT [PK_SaleEventStock] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_SaleEventStock_SaleEvent] FOREIGN KEY ([SaleEventId]) REFERENCES [SaleEvent]([Id]),
    CONSTRAINT [FK_SaleEventStock_Species] FOREIGN KEY ([SpeciesId]) REFERENCES [Species]([Id]),
    CONSTRAINT [FK_SaleEventStock_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [ProductType]([Id])
);
