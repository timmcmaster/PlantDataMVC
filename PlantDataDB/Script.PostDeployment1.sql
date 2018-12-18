/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE FROM [dbo].[ProductType]

SET IDENTITY_INSERT [dbo].[ProductType] ON
GO
INSERT INTO [dbo].[ProductType] ([Id], [Name]) VALUES (1, N'Tube')
INSERT INTO [dbo].[ProductType] ([Id], [Name]) VALUES (2, N'Medium Pot')
INSERT INTO [dbo].[ProductType] ([Id], [Name]) VALUES (3, N'Large Pot')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO