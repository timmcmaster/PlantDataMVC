CREATE TABLE [dbo].[SeedBatch] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [SpeciesId]     INT            NOT NULL,
    [DateCollected] DATE           NOT NULL,
    [Location]      NVARCHAR (30)  NULL,
    [Notes]         NVARCHAR (200) NULL,
    [SiteId]        INT            NULL,
    [Emptied] BIT NOT NULL , 
    CONSTRAINT [PK_SeedBatch] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeedBatch_Site] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Site] ([Id]),
    CONSTRAINT [FK_SeedBatch_Species] FOREIGN KEY ([SpeciesId]) REFERENCES [dbo].[Species] ([Id])
);

