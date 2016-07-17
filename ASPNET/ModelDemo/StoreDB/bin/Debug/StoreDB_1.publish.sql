﻿/*
Deployment script for StoreDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "StoreDB"
:setvar DefaultFilePrefix "StoreDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[Product].[CategoryId] on table [dbo].[Product] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[Product].[IsAvalialbe] on table [dbo].[Product] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[Product].[Price] on table [dbo].[Product] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Title on table [dbo].[Product] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[Product])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key 1dd09eb6-d8ec-497a-b759-b51c5c7a4139 is skipped, element [dbo].[FK_Product_ToTable] (SqlForeignKeyConstraint) will not be renamed to [FK_Product_Category]';


GO
PRINT N'Altering [dbo].[Product]...';


GO
ALTER TABLE [dbo].[Product] ALTER COLUMN [Title] NVARCHAR (100) NOT NULL;


GO
ALTER TABLE [dbo].[Product]
    ADD [Price]       FLOAT (53)       NOT NULL,
        [IsAvalialbe] BIT              NOT NULL,
        [CategoryId]  UNIQUEIDENTIFIER NOT NULL;


GO
PRINT N'Creating [dbo].[Category]...';


GO
CREATE TABLE [dbo].[Category] (
    [Id]    UNIQUEIDENTIFIER NOT NULL,
    [Title] NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Order]...';


GO
CREATE TABLE [dbo].[Order] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Date]         DATETIME         NOT NULL,
    [Owner]        NVARCHAR (50)    NOT NULL,
    [IsProcessing] BIT              NOT NULL,
    [Status]       NVARCHAR (50)    NOT NULL,
    [ProductId]    UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Order_ToProduct]...';


GO
ALTER TABLE [dbo].[Order] WITH NOCHECK
    ADD CONSTRAINT [FK_Order_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Product_Category]...';


GO
ALTER TABLE [dbo].[Product] WITH NOCHECK
    ADD CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '1dd09eb6-d8ec-497a-b759-b51c5c7a4139')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('1dd09eb6-d8ec-497a-b759-b51c5c7a4139')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Order] WITH CHECK CHECK CONSTRAINT [FK_Order_ToProduct];

ALTER TABLE [dbo].[Product] WITH CHECK CHECK CONSTRAINT [FK_Product_Category];


GO
PRINT N'Update complete.';


GO