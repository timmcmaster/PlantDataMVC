CREATE TABLE [dbo].[Species] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [GenusId]         INT            NOT NULL,
    [SpecificName]    NVARCHAR (30)  NOT NULL,
    [CommonName]      NVARCHAR (50)  NULL,
    [Description]     NVARCHAR (200) NULL,
    [PropagationTime] INT            NULL,
    [Native]          BIT            NOT NULL,
    CONSTRAINT [PK_Species] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Species_Genus] FOREIGN KEY ([GenusId]) REFERENCES [dbo].[Genus] ([Id]),
    CONSTRAINT [UK_GenusSpecies] UNIQUE NONCLUSTERED ([GenusId] ASC, [SpecificName] ASC)
);

