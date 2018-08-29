CREATE TABLE [dbo].[Site] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [SiteName]  NVARCHAR (50)  NULL,
    [Suburb]    NVARCHAR (50)  NULL,
    [Latitude]  DECIMAL (8, 5) NULL,
    [Longitude] DECIMAL (8, 5) NULL,
    CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED ([Id] ASC)
);

