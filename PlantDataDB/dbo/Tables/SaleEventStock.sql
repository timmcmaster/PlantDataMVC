CREATE TABLE [dbo].[SaleEventStock]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
	[SaleEventId] INT NOT NULL,
	[PlantStockId] INT NOT NULL,
	[Quantity] INT NOT NULL,
    CONSTRAINT [PK_SaleEventStock] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_SaleEventStock_SaleEvent] FOREIGN KEY ([SaleEventId]) REFERENCES [SaleEvent]([Id]),
    CONSTRAINT [FK_SaleEventStock_PlantStock] FOREIGN KEY ([PlantStockId]) REFERENCES [PlantStock]([Id])
);
