CREATE TABLE [dbo].[PriceListType] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [Kind] NVARCHAR (1)  NOT NULL,
    CONSTRAINT [PK_PriceListType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

