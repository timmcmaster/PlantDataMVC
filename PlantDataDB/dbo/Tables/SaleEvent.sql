CREATE TABLE [dbo].[SaleEvent] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    [SaleDate] DATE NULL,
    [Location] NVARCHAR (30) NULL,
    CONSTRAINT [PK_SaleEvent] PRIMARY KEY CLUSTERED ([Id] ASC)
);
