CREATE TABLE [dbo].[ProductPrice] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [PriceListTypeId] INT             NOT NULL,
    [ProductTypeId]   INT             NOT NULL,
    [Price]           DECIMAL (18, 2) NOT NULL,
    [DateEffective]   DATE            NOT NULL,
    [BarcodeSKU]      NVARCHAR (40)   DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_ProductPrice] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductPrices_PriceListType] FOREIGN KEY ([PriceListTypeId]) REFERENCES [dbo].[PriceListType] ([Id]),
    CONSTRAINT [FK_ProductPrices_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [dbo].[ProductType] ([Id]),
    CONSTRAINT [AK_ProductPrice_ProductType_PriceListType_Date] UNIQUE NONCLUSTERED ([ProductTypeId] ASC, [PriceListTypeId] ASC, [DateEffective] ASC)
);



