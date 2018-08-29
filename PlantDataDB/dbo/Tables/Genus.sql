CREATE TABLE [dbo].[Genus] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [LatinName] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Genus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

