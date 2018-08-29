CREATE TABLE [dbo].[ProductPrice] (
    [PriceListTypeId] INT             NOT NULL,
    [ProductTypeId]   INT             NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [DateEffective]   DATE            NOT NULL,
    CONSTRAINT [PK_ProductPrices] PRIMARY KEY CLUSTERED ([PriceListTypeId] ASC, [ProductTypeId] ASC, [DateEffective] ASC),
    CONSTRAINT [FK_ProductPrices_PriceListType] FOREIGN KEY ([PriceListTypeId]) REFERENCES [dbo].[PriceListType] ([Id]),
    CONSTRAINT [FK_ProductPrices_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id])
);

