BEGIN TRANSACTION;
GO

ALTER TABLE [dbo].[ProductPrice] ADD [BarcodeSKU] nvarchar(40) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230426130051_AddBarcodeSKU', N'7.0.5');
GO

COMMIT;
GO

