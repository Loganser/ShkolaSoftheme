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
PRINT N'Creating [dbo].[Product]...';


GO
CREATE TABLE [dbo].[Product] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Title]       NVARCHAR (100)   NOT NULL,
    [Description] NVARCHAR (500)   NULL,
    [Price]       FLOAT (53)       NOT NULL,
    [IsAvalialbe] BIT              NOT NULL,
    [CategoryId]  UNIQUEIDENTIFIER NOT NULL,
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
