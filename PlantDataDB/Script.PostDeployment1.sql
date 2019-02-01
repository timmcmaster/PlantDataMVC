/*
POST-DEPLOYMENT SCRIPT TEMPLATE							
--------------------------------------------------------------------------------------
 THIS FILE CONTAINS SQL STATEMENTS THAT WILL BE APPENDED TO THE BUILD SCRIPT.		
 USE SQLCMD SYNTAX TO INCLUDE A FILE IN THE POST-DEPLOYMENT SCRIPT.			
 EXAMPLE:      :R .\MYFILE.SQL								
 USE SQLCMD SYNTAX TO REFERENCE A VARIABLE IN THE POST-DEPLOYMENT SCRIPT.		
 EXAMPLE:      :SETVAR TABLENAME MYTABLE							
               SELECT * FROM [$(TABLENAME)]					
--------------------------------------------------------------------------------------
*/
/* insert/merge basic product admin data */ 
SET IDENTITY_INSERT [dbo].[ProductType] ON
GO
MERGE INTO [dbo].[ProductType] AS TARGET
USING (VALUES 
(1, N'Tube'),
(2, N'Medium Pot'),
(3, N'Large Pot')
)
AS SOURCE(Id,Name)
ON TARGET.Id = SOURCE.Id
-- update matched rows 
WHEN MATCHED THEN
	UPDATE SET Name = SOURCE.Name
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
	INSERT(Id,Name)
	VALUES(Id,Name)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;

SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO

SET IDENTITY_INSERT [dbo].[JournalEntryType] ON
GO
MERGE INTO [dbo].[JournalEntryType] AS TARGET
USING (VALUES 
	(1, N'SALE', -1),
	(2, N'PLANT DIED', -1),
	(3, N'POTTED FROM SEED TRAY', 1),
	(4, N'GIFT RECEIVED', 1),
	(5, N'GIFT GIVEN', -1),
	(6, N'PLANTED', -1),
	(7, N'PURCHASE', 1),
	(8, N'POTTED FROM CUTTING', 1),
    (9, N'STOCK ADJUSTMENT', 1))
AS SOURCE(Id,Name,Effect)
ON TARGET.Id = SOURCE.Id
-- update matched rows 
WHEN MATCHED THEN
	UPDATE SET Name = SOURCE.Name, Effect = SOURCE.Effect
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
	INSERT(Id,Name,Effect)
	VALUES(Id,Name,Effect)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;

SET IDENTITY_INSERT [dbo].[JournalEntryType] OFF
GO