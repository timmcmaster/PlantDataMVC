SET IDENTITY_INSERT [dbo].[JournalEntryType] ON
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (1, N'Sale', -1)
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (2, N'Plant Died', -1)
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (3, N'Potted From Seed Tray', 1)
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (4, N'Gift Received', 1)
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (5, N'Gift Given', -1)
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (6, N'Planted', -1)
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (7, N'Purchase', 1)
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (8, N'Potted From Cutting', 1)
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (9, N'Stock Adjustment', 1)
INSERT INTO [dbo].[JournalEntryType] ([Id], [Name], [Effect]) VALUES (10, N'Repotted', 1)
SET IDENTITY_INSERT [dbo].[JournalEntryType] OFF
