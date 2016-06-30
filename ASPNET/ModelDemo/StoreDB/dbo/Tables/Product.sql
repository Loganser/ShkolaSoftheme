CREATE TABLE [dbo].[Product] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Title]       NVARCHAR (100)   NOT NULL,
    [Description] NVARCHAR (500)   NULL,
    [Price] FLOAT NOT NULL, 
    [IsAvalialbe] BIT NOT NULL, 
    [CategoryId] UNIQUEIDENTIFIER NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryID]) REFERENCES Category(Id)
);

