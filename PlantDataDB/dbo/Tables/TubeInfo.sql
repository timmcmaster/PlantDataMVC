CREATE TABLE [dbo].[TubeInfo] (
    [Id]             INT  IDENTITY (1, 1) NOT NULL,
    [SeedTrayId]     INT  NOT NULL,
    [DatePrickedOut] DATE NULL,
    [NumberOfTubes]  INT  NULL,
    CONSTRAINT [PK_TubeInfo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TubeInfo_SeedPlanting] FOREIGN KEY ([SeedTrayId]) REFERENCES [dbo].[SeedTray] ([Id])
);

