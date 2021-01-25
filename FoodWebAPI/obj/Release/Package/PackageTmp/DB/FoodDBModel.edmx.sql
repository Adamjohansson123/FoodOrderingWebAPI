
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/01/2021 16:31:52
-- Generated from EDMX file: E:\Openssl\UPM400\FoodWebAPI\FoodWebAPI\DB\FoodDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FoodDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Order_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_City];
GO
IF OBJECT_ID(N'[dbo].[FK_Restaurant_City]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Restaurant] DROP CONSTRAINT [FK_Restaurant_City];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_To_Drink_Drink]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_To_Drink] DROP CONSTRAINT [FK_Order_To_Drink_Drink];
GO
IF OBJECT_ID(N'[dbo].[FK_Food_Restaurant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Food] DROP CONSTRAINT [FK_Food_Restaurant];
GO
IF OBJECT_ID(N'[dbo].[FK_Ingredient_To_Food_Food]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ingredient_To_Food] DROP CONSTRAINT [FK_Ingredient_To_Food_Food];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_To_Food_Food]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_To_Food] DROP CONSTRAINT [FK_Order_To_Food_Food];
GO
IF OBJECT_ID(N'[dbo].[FK_Ingredient_To_Food_Ingredient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ingredient_To_Food] DROP CONSTRAINT [FK_Ingredient_To_Food_Ingredient];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_To_Drink_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_To_Drink] DROP CONSTRAINT [FK_Order_To_Drink_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_To_Food_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order_To_Food] DROP CONSTRAINT [FK_Order_To_Food_Order];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[dbo].[Drink]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Drink];
GO
IF OBJECT_ID(N'[dbo].[Food]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Food];
GO
IF OBJECT_ID(N'[dbo].[Ingredient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingredient];
GO
IF OBJECT_ID(N'[dbo].[Ingredient_To_Food]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingredient_To_Food];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[Order_To_Drink]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_To_Drink];
GO
IF OBJECT_ID(N'[dbo].[Order_To_Food]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order_To_Food];
GO
IF OBJECT_ID(N'[dbo].[Restaurant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restaurant];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'City'
CREATE TABLE [dbo].[City] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Drink'
CREATE TABLE [dbo].[Drink] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Price] int  NOT NULL
);
GO

-- Creating table 'Food'
CREATE TABLE [dbo].[Food] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Type] varchar(50)  NOT NULL,
    [Price] int  NOT NULL,
    [Id_Restaurant] int  NULL
);
GO

-- Creating table 'Ingredient'
CREATE TABLE [dbo].[Ingredient] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Ingredient_To_Food'
CREATE TABLE [dbo].[Ingredient_To_Food] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Id_Food] int  NOT NULL,
    [Id_Ingredient] int  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerFirstName] varchar(50)  NOT NULL,
    [CustomerLastName] varchar(50)  NOT NULL,
    [CustomerAdress] varchar(50)  NOT NULL,
    [CustomerZIP] varchar(50)  NOT NULL,
    [CustomerEmail] varchar(50)  NOT NULL,
    [CustomerPhoneNumber] varchar(50)  NOT NULL,
    [Id_City] int  NOT NULL
);
GO

-- Creating table 'Order_To_Drink'
CREATE TABLE [dbo].[Order_To_Drink] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Id_Order] int  NOT NULL,
    [Id_Drink] int  NOT NULL
);
GO

-- Creating table 'Order_To_Food'
CREATE TABLE [dbo].[Order_To_Food] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerMessage] varchar(max)  NULL,
    [Id_Order] int  NOT NULL,
    [Id_Food] int  NOT NULL
);
GO

-- Creating table 'Restaurant'
CREATE TABLE [dbo].[Restaurant] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Popularity] int  NULL,
    [Id_City] int  NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Img] nvarchar(max)  NULL,
    [TypeOfFood] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'City'
ALTER TABLE [dbo].[City]
ADD CONSTRAINT [PK_City]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Drink'
ALTER TABLE [dbo].[Drink]
ADD CONSTRAINT [PK_Drink]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Food'
ALTER TABLE [dbo].[Food]
ADD CONSTRAINT [PK_Food]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ingredient'
ALTER TABLE [dbo].[Ingredient]
ADD CONSTRAINT [PK_Ingredient]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ingredient_To_Food'
ALTER TABLE [dbo].[Ingredient_To_Food]
ADD CONSTRAINT [PK_Ingredient_To_Food]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order_To_Drink'
ALTER TABLE [dbo].[Order_To_Drink]
ADD CONSTRAINT [PK_Order_To_Drink]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order_To_Food'
ALTER TABLE [dbo].[Order_To_Food]
ADD CONSTRAINT [PK_Order_To_Food]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Restaurant'
ALTER TABLE [dbo].[Restaurant]
ADD CONSTRAINT [PK_Restaurant]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Id_City] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_City]
    FOREIGN KEY ([Id_City])
    REFERENCES [dbo].[City]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_City'
CREATE INDEX [IX_FK_Order_City]
ON [dbo].[Order]
    ([Id_City]);
GO

-- Creating foreign key on [Id_City] in table 'Restaurant'
ALTER TABLE [dbo].[Restaurant]
ADD CONSTRAINT [FK_Restaurant_City]
    FOREIGN KEY ([Id_City])
    REFERENCES [dbo].[City]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Restaurant_City'
CREATE INDEX [IX_FK_Restaurant_City]
ON [dbo].[Restaurant]
    ([Id_City]);
GO

-- Creating foreign key on [Id_Drink] in table 'Order_To_Drink'
ALTER TABLE [dbo].[Order_To_Drink]
ADD CONSTRAINT [FK_Order_To_Drink_Drink]
    FOREIGN KEY ([Id_Drink])
    REFERENCES [dbo].[Drink]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_To_Drink_Drink'
CREATE INDEX [IX_FK_Order_To_Drink_Drink]
ON [dbo].[Order_To_Drink]
    ([Id_Drink]);
GO

-- Creating foreign key on [Id_Restaurant] in table 'Food'
ALTER TABLE [dbo].[Food]
ADD CONSTRAINT [FK_Food_Restaurant]
    FOREIGN KEY ([Id_Restaurant])
    REFERENCES [dbo].[Restaurant]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Food_Restaurant'
CREATE INDEX [IX_FK_Food_Restaurant]
ON [dbo].[Food]
    ([Id_Restaurant]);
GO

-- Creating foreign key on [Id_Food] in table 'Ingredient_To_Food'
ALTER TABLE [dbo].[Ingredient_To_Food]
ADD CONSTRAINT [FK_Ingredient_To_Food_Food]
    FOREIGN KEY ([Id_Food])
    REFERENCES [dbo].[Food]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ingredient_To_Food_Food'
CREATE INDEX [IX_FK_Ingredient_To_Food_Food]
ON [dbo].[Ingredient_To_Food]
    ([Id_Food]);
GO

-- Creating foreign key on [Id_Food] in table 'Order_To_Food'
ALTER TABLE [dbo].[Order_To_Food]
ADD CONSTRAINT [FK_Order_To_Food_Food]
    FOREIGN KEY ([Id_Food])
    REFERENCES [dbo].[Food]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_To_Food_Food'
CREATE INDEX [IX_FK_Order_To_Food_Food]
ON [dbo].[Order_To_Food]
    ([Id_Food]);
GO

-- Creating foreign key on [Id_Ingredient] in table 'Ingredient_To_Food'
ALTER TABLE [dbo].[Ingredient_To_Food]
ADD CONSTRAINT [FK_Ingredient_To_Food_Ingredient]
    FOREIGN KEY ([Id_Ingredient])
    REFERENCES [dbo].[Ingredient]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ingredient_To_Food_Ingredient'
CREATE INDEX [IX_FK_Ingredient_To_Food_Ingredient]
ON [dbo].[Ingredient_To_Food]
    ([Id_Ingredient]);
GO

-- Creating foreign key on [Id_Order] in table 'Order_To_Drink'
ALTER TABLE [dbo].[Order_To_Drink]
ADD CONSTRAINT [FK_Order_To_Drink_Order]
    FOREIGN KEY ([Id_Order])
    REFERENCES [dbo].[Order]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_To_Drink_Order'
CREATE INDEX [IX_FK_Order_To_Drink_Order]
ON [dbo].[Order_To_Drink]
    ([Id_Order]);
GO

-- Creating foreign key on [Id_Order] in table 'Order_To_Food'
ALTER TABLE [dbo].[Order_To_Food]
ADD CONSTRAINT [FK_Order_To_Food_Order]
    FOREIGN KEY ([Id_Order])
    REFERENCES [dbo].[Order]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_To_Food_Order'
CREATE INDEX [IX_FK_Order_To_Food_Order]
ON [dbo].[Order_To_Food]
    ([Id_Order]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------