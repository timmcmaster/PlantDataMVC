CREATE TABLE [dbo].[SeedTray] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [SeedBatchId] INT           NOT NULL,
    [DatePlanted] DATE          NOT NULL,
    [Treatment]   NVARCHAR (50) NULL,
    [ThrownOut]   BIT           NOT NULL,
    CONSTRAINT [PK_SeedTray] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeedTray_SeedBatch] FOREIGN KEY ([SeedBatchId]) REFERENCES [dbo].[SeedBatch] ([Id])
);

