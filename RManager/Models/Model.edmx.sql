
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/01/2018 11:53:47
-- Generated from EDMX file: D:\Илья\Вышка\3Course\Курсовая\RManager\RManager\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RManager];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ManDocument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Document] DROP CONSTRAINT [FK_ManDocument];
GO
IF OBJECT_ID(N'[dbo].[FK_positionperson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person_Employee] DROP CONSTRAINT [FK_positionperson];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_EmployeeOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person_Employee] DROP CONSTRAINT [FK_BranchPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonEjection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ejection] DROP CONSTRAINT [FK_PersonEjection];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonShift]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShiftSet] DROP CONSTRAINT [FK_PersonShift];
GO
IF OBJECT_ID(N'[dbo].[FK_IngridientPurchase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchase] DROP CONSTRAINT [FK_IngridientPurchase];
GO
IF OBJECT_ID(N'[dbo].[FK_IngridientEjection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ejection] DROP CONSTRAINT [FK_IngridientEjection];
GO
IF OBJECT_ID(N'[dbo].[FK_IngridientDIConnection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipeDishIngr] DROP CONSTRAINT [FK_IngridientDIConnection];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_CategoryProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_CompanyProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductRecipePrepIngr]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipePrepIngr] DROP CONSTRAINT [FK_ProductRecipePrepIngr];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCheckMerchandise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CheckMerchandise] DROP CONSTRAINT [FK_ProductCheckMerchandise];
GO
IF OBJECT_ID(N'[dbo].[FK_DishCheck]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CheckDish] DROP CONSTRAINT [FK_DishCheck];
GO
IF OBJECT_ID(N'[dbo].[FK_DishDIConnection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipeDishIngr] DROP CONSTRAINT [FK_DishDIConnection];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomDish]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dish] DROP CONSTRAINT [FK_RoomDish];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryDish]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dish] DROP CONSTRAINT [FK_CategoryDish];
GO
IF OBJECT_ID(N'[dbo].[FK_DishRecipeDishPrep]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipeDishPrep] DROP CONSTRAINT [FK_DishRecipeDishPrep];
GO
IF OBJECT_ID(N'[dbo].[FK_TableOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_TableOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_OwnerBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Branch] DROP CONSTRAINT [FK_OwnerBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyContactPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person_ContactPerson] DROP CONSTRAINT [FK_CompanyContactPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_PrepackRecipePrepIngr]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipePrepIngr] DROP CONSTRAINT [FK_PrepackRecipePrepIngr];
GO
IF OBJECT_ID(N'[dbo].[FK_PrepackRecipeDishPrep]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipeDishPrep] DROP CONSTRAINT [FK_PrepackRecipeDishPrep];
GO
IF OBJECT_ID(N'[dbo].[FK_PrepackRecipePrepPrep]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipePrepPrep] DROP CONSTRAINT [FK_PrepackRecipePrepPrep];
GO
IF OBJECT_ID(N'[dbo].[FK_PrepackRecipePrepPrep1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecipePrepPrep] DROP CONSTRAINT [FK_PrepackRecipePrepPrep1];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchEncashment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EncashmentSet] DROP CONSTRAINT [FK_BranchEncashment];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchShift]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShiftSet] DROP CONSTRAINT [FK_BranchShift];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderCheckMerchandise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CheckMerchandise] DROP CONSTRAINT [FK_OrderCheckMerchandise];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderCheckDish]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CheckDish] DROP CONSTRAINT [FK_OrderCheckDish];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TableSet] DROP CONSTRAINT [FK_RoomTable];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Room] DROP CONSTRAINT [FK_BranchRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyPurchase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchase] DROP CONSTRAINT [FK_CompanyPurchase];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Category] DROP CONSTRAINT [FK_CategoryCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_LandlordBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Branch] DROP CONSTRAINT [FK_LandlordBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_ClientOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person_Employee] DROP CONSTRAINT [FK_Employee_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyOwner_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person_CompanyOwner] DROP CONSTRAINT [FK_CompanyOwner_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactPerson_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person_ContactPerson] DROP CONSTRAINT [FK_ContactPerson_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Landlord_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person_Landlord] DROP CONSTRAINT [FK_Landlord_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Client_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person_Client] DROP CONSTRAINT [FK_Client_inherits_Person];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Document]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Document];
GO
IF OBJECT_ID(N'[dbo].[Position]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Position];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[Dish]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dish];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[Purchase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchase];
GO
IF OBJECT_ID(N'[dbo].[Ejection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ejection];
GO
IF OBJECT_ID(N'[dbo].[CheckDish]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CheckDish];
GO
IF OBJECT_ID(N'[dbo].[TableSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TableSet];
GO
IF OBJECT_ID(N'[dbo].[RecipeDishIngr]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecipeDishIngr];
GO
IF OBJECT_ID(N'[dbo].[Room]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room];
GO
IF OBJECT_ID(N'[dbo].[Branch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branch];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[PrepackSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrepackSet];
GO
IF OBJECT_ID(N'[dbo].[RecipePrepIngr]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecipePrepIngr];
GO
IF OBJECT_ID(N'[dbo].[RecipeDishPrep]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecipeDishPrep];
GO
IF OBJECT_ID(N'[dbo].[RecipePrepPrep]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecipePrepPrep];
GO
IF OBJECT_ID(N'[dbo].[CheckMerchandise]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CheckMerchandise];
GO
IF OBJECT_ID(N'[dbo].[ShiftSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShiftSet];
GO
IF OBJECT_ID(N'[dbo].[EncashmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EncashmentSet];
GO
IF OBJECT_ID(N'[dbo].[Person_Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person_Employee];
GO
IF OBJECT_ID(N'[dbo].[Person_CompanyOwner]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person_CompanyOwner];
GO
IF OBJECT_ID(N'[dbo].[Person_ContactPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person_ContactPerson];
GO
IF OBJECT_ID(N'[dbo].[Person_Landlord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person_Landlord];
GO
IF OBJECT_ID(N'[dbo].[Person_Client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person_Client];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Document'
CREATE TABLE [dbo].[Document] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Serial] nvarchar(max)  NULL,
    [Number] nvarchar(max)  NULL,
    [Registration] nvarchar(max)  NULL,
    [Exist] bit  NOT NULL,
    [Man_Id] int  NOT NULL
);
GO

-- Creating table 'Position'
CREATE TABLE [dbo].[Position] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [WorkWithOrders] bit  NOT NULL,
    [WorkWithMenu] bit  NOT NULL,
    [WorkWithWarehouse] bit  NOT NULL,
    [WorkWithStuff] bit  NOT NULL,
    [WorkWithReports] bit  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Property] nvarchar(max)  NOT NULL,
    [Measure] tinyint  NOT NULL,
    [IsIngredient] bit  NULL,
    [IsMerchandise] bit  NOT NULL,
    [InspectionDate] datetime  NULL,
    [FactualNumber] float  NULL,
    [Category_Id] int  NOT NULL,
    [Manufacturer_Id] int  NOT NULL
);
GO

-- Creating table 'Dish'
CREATE TABLE [dbo].[Dish] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Cost] float  NOT NULL,
    [FinalVolume] float  NULL,
    [IsExist] bit  NOT NULL,
    [Measure] tinyint  NOT NULL,
    [VendorCode] nvarchar(max)  NOT NULL,
    [CookStartTime] datetime  NULL,
    [CookEndTime] datetime  NULL,
    [Energy_Protains] float  NULL,
    [Energy_Fats] float  NULL,
    [Energy_Carbohydrates] float  NULL,
    [Energy_EnergyCalorie] float  NULL,
    [Energy_EnergyJoule] float  NULL,
    [CookingPlace_Id] int  NULL,
    [Category_Id] int  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FinalPrice] float  NOT NULL,
    [DateOfOrder] datetime  NOT NULL,
    [IsOpen] bit  NOT NULL,
    [Employee_Id] int  NOT NULL,
    [Table_Id] int  NULL,
    [Client_Id] int  NULL
);
GO

-- Creating table 'Purchase'
CREATE TABLE [dbo].[Purchase] (
    [IdPurchase] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Price] float  NULL,
    [Volume] float  NOT NULL,
    [Ingridient_Id] int  NOT NULL,
    [Provider_Id] int  NOT NULL
);
GO

-- Creating table 'Ejection'
CREATE TABLE [dbo].[Ejection] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Volume] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Culprit_Id] int  NULL,
    [Ingridient_Id] int  NOT NULL
);
GO

-- Creating table 'CheckDish'
CREATE TABLE [dbo].[CheckDish] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsPaid] nvarchar(max)  NOT NULL,
    [AddDateTime] nvarchar(max)  NOT NULL,
    [PaidDateTime] nvarchar(max)  NOT NULL,
    [Dish_Id] int  NOT NULL,
    [Order_Id] int  NOT NULL
);
GO

-- Creating table 'TableSet'
CREATE TABLE [dbo].[TableSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] smallint  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [IsExist] bit  NOT NULL,
    [Room_Id] int  NOT NULL
);
GO

-- Creating table 'RecipeDishIngr'
CREATE TABLE [dbo].[RecipeDishIngr] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Volume] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Ingridient_Id] int  NOT NULL,
    [Dish_Id] int  NOT NULL
);
GO

-- Creating table 'Room'
CREATE TABLE [dbo].[Room] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Branch_Id] int  NOT NULL
);
GO

-- Creating table 'Branch'
CREATE TABLE [dbo].[Branch] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Adress_Country] nvarchar(max)  NOT NULL,
    [Adress_City] nvarchar(max)  NOT NULL,
    [Adress_Street] nvarchar(max)  NOT NULL,
    [Adress_Bilding] nvarchar(max)  NOT NULL,
    [Adress_Index] nvarchar(max)  NOT NULL,
    [WebSite] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [StartWorkingTime] time  NULL,
    [EndWorkingTime] time  NULL,
    [Characters_Area] float  NOT NULL,
    [Characters_HasGas] bit  NOT NULL,
    [Characters_HasElectricity] bit  NOT NULL,
    [Characters_HasWater] bit  NOT NULL,
    [Characters_HasWarmWater] bit  NOT NULL,
    [Characters_Property] nvarchar(max)  NULL,
    [InspectionDate] datetime  NULL,
    [FactualCashbox] float  NULL,
    [Owner_Id] int  NOT NULL,
    [Landlord_Id] int  NOT NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ParrentCategory_Id] int  NOT NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [MiddleName] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Adress_Country] nvarchar(max)  NOT NULL,
    [Adress_City] nvarchar(max)  NOT NULL,
    [Adress_Street] nvarchar(max)  NOT NULL,
    [Adress_Bilding] nvarchar(max)  NOT NULL,
    [Adress_Index] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Company'
CREATE TABLE [dbo].[Company] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [INN] nvarchar(max)  NOT NULL,
    [OGRN] nvarchar(max)  NOT NULL,
    [BankAccount] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PrepackSet'
CREATE TABLE [dbo].[PrepackSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [FinalVolume] float  NULL,
    [IsExist] bit  NOT NULL,
    [Measure] tinyint  NOT NULL,
    [VendorCode] nvarchar(max)  NOT NULL,
    [CookStartTime] datetime  NULL,
    [CookEndTime] datetime  NULL,
    [Energy_Protains] float  NULL,
    [Energy_Fats] float  NULL,
    [Energy_Carbohydrates] float  NULL,
    [Energy_EnergyCalorie] float  NULL,
    [Energy_EnergyJoule] float  NULL
);
GO

-- Creating table 'RecipePrepIngr'
CREATE TABLE [dbo].[RecipePrepIngr] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Volume] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Ingredient_Id] int  NOT NULL,
    [Prepack_Id] int  NOT NULL
);
GO

-- Creating table 'RecipeDishPrep'
CREATE TABLE [dbo].[RecipeDishPrep] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Volume] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Dish_Id] int  NOT NULL,
    [Prepack_Id] int  NOT NULL
);
GO

-- Creating table 'RecipePrepPrep'
CREATE TABLE [dbo].[RecipePrepPrep] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Volume] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Prepack_Id] int  NOT NULL,
    [Result_Id] int  NOT NULL
);
GO

-- Creating table 'CheckMerchandise'
CREATE TABLE [dbo].[CheckMerchandise] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsPaid] nvarchar(max)  NOT NULL,
    [AddDateTime] nvarchar(max)  NOT NULL,
    [PaidDateTime] nvarchar(max)  NOT NULL,
    [Product_Id] int  NOT NULL,
    [Order_Id] int  NOT NULL
);
GO

-- Creating table 'ShiftSet'
CREATE TABLE [dbo].[ShiftSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartDateTime] time  NULL,
    [EndDateTime] time  NULL,
    [StartFactualCashbox] decimal(18,0)  NOT NULL,
    [EndFactualCash] decimal(18,0)  NOT NULL,
    [EndFactualNonCash] decimal(18,0)  NOT NULL,
    [Person_Id] int  NOT NULL,
    [Branch_Id] int  NOT NULL
);
GO

-- Creating table 'EncashmentSet'
CREATE TABLE [dbo].[EncashmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [WriteOff] decimal(18,0)  NOT NULL,
    [Branch_Id] int  NOT NULL
);
GO

-- Creating table 'Person_Employee'
CREATE TABLE [dbo].[Person_Employee] (
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [IsWorking] bit  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Id] int  NOT NULL,
    [Position_Id] int  NOT NULL,
    [Branch_Id] int  NOT NULL
);
GO

-- Creating table 'Person_CompanyOwner'
CREATE TABLE [dbo].[Person_CompanyOwner] (
    [INN] nvarchar(max)  NOT NULL,
    [OGRN] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Person_ContactPerson'
CREATE TABLE [dbo].[Person_ContactPerson] (
    [Id] int  NOT NULL,
    [Company_Id] int  NOT NULL
);
GO

-- Creating table 'Person_Landlord'
CREATE TABLE [dbo].[Person_Landlord] (
    [INN] nvarchar(max)  NOT NULL,
    [OGRN] nvarchar(max)  NOT NULL,
    [BankAccount] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Person_Client'
CREATE TABLE [dbo].[Person_Client] (
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Document'
ALTER TABLE [dbo].[Document]
ADD CONSTRAINT [PK_Document]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Position'
ALTER TABLE [dbo].[Position]
ADD CONSTRAINT [PK_Position]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Dish'
ALTER TABLE [dbo].[Dish]
ADD CONSTRAINT [PK_Dish]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdPurchase] in table 'Purchase'
ALTER TABLE [dbo].[Purchase]
ADD CONSTRAINT [PK_Purchase]
    PRIMARY KEY CLUSTERED ([IdPurchase] ASC);
GO

-- Creating primary key on [Id] in table 'Ejection'
ALTER TABLE [dbo].[Ejection]
ADD CONSTRAINT [PK_Ejection]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CheckDish'
ALTER TABLE [dbo].[CheckDish]
ADD CONSTRAINT [PK_CheckDish]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TableSet'
ALTER TABLE [dbo].[TableSet]
ADD CONSTRAINT [PK_TableSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecipeDishIngr'
ALTER TABLE [dbo].[RecipeDishIngr]
ADD CONSTRAINT [PK_RecipeDishIngr]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Room'
ALTER TABLE [dbo].[Room]
ADD CONSTRAINT [PK_Room]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Branch'
ALTER TABLE [dbo].[Branch]
ADD CONSTRAINT [PK_Branch]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [PK_Company]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrepackSet'
ALTER TABLE [dbo].[PrepackSet]
ADD CONSTRAINT [PK_PrepackSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecipePrepIngr'
ALTER TABLE [dbo].[RecipePrepIngr]
ADD CONSTRAINT [PK_RecipePrepIngr]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecipeDishPrep'
ALTER TABLE [dbo].[RecipeDishPrep]
ADD CONSTRAINT [PK_RecipeDishPrep]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecipePrepPrep'
ALTER TABLE [dbo].[RecipePrepPrep]
ADD CONSTRAINT [PK_RecipePrepPrep]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CheckMerchandise'
ALTER TABLE [dbo].[CheckMerchandise]
ADD CONSTRAINT [PK_CheckMerchandise]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShiftSet'
ALTER TABLE [dbo].[ShiftSet]
ADD CONSTRAINT [PK_ShiftSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EncashmentSet'
ALTER TABLE [dbo].[EncashmentSet]
ADD CONSTRAINT [PK_EncashmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person_Employee'
ALTER TABLE [dbo].[Person_Employee]
ADD CONSTRAINT [PK_Person_Employee]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person_CompanyOwner'
ALTER TABLE [dbo].[Person_CompanyOwner]
ADD CONSTRAINT [PK_Person_CompanyOwner]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person_ContactPerson'
ALTER TABLE [dbo].[Person_ContactPerson]
ADD CONSTRAINT [PK_Person_ContactPerson]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person_Landlord'
ALTER TABLE [dbo].[Person_Landlord]
ADD CONSTRAINT [PK_Person_Landlord]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person_Client'
ALTER TABLE [dbo].[Person_Client]
ADD CONSTRAINT [PK_Person_Client]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Man_Id] in table 'Document'
ALTER TABLE [dbo].[Document]
ADD CONSTRAINT [FK_ManDocument]
    FOREIGN KEY ([Man_Id])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManDocument'
CREATE INDEX [IX_FK_ManDocument]
ON [dbo].[Document]
    ([Man_Id]);
GO

-- Creating foreign key on [Position_Id] in table 'Person_Employee'
ALTER TABLE [dbo].[Person_Employee]
ADD CONSTRAINT [FK_positionperson]
    FOREIGN KEY ([Position_Id])
    REFERENCES [dbo].[Position]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_positionperson'
CREATE INDEX [IX_FK_positionperson]
ON [dbo].[Person_Employee]
    ([Position_Id]);
GO

-- Creating foreign key on [Employee_Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_EmployeeOrder]
    FOREIGN KEY ([Employee_Id])
    REFERENCES [dbo].[Person_Employee]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeOrder'
CREATE INDEX [IX_FK_EmployeeOrder]
ON [dbo].[Order]
    ([Employee_Id]);
GO

-- Creating foreign key on [Branch_Id] in table 'Person_Employee'
ALTER TABLE [dbo].[Person_Employee]
ADD CONSTRAINT [FK_BranchPerson]
    FOREIGN KEY ([Branch_Id])
    REFERENCES [dbo].[Branch]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchPerson'
CREATE INDEX [IX_FK_BranchPerson]
ON [dbo].[Person_Employee]
    ([Branch_Id]);
GO

-- Creating foreign key on [Culprit_Id] in table 'Ejection'
ALTER TABLE [dbo].[Ejection]
ADD CONSTRAINT [FK_PersonEjection]
    FOREIGN KEY ([Culprit_Id])
    REFERENCES [dbo].[Person_Employee]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonEjection'
CREATE INDEX [IX_FK_PersonEjection]
ON [dbo].[Ejection]
    ([Culprit_Id]);
GO

-- Creating foreign key on [Person_Id] in table 'ShiftSet'
ALTER TABLE [dbo].[ShiftSet]
ADD CONSTRAINT [FK_PersonShift]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[Person_Employee]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonShift'
CREATE INDEX [IX_FK_PersonShift]
ON [dbo].[ShiftSet]
    ([Person_Id]);
GO

-- Creating foreign key on [Ingridient_Id] in table 'Purchase'
ALTER TABLE [dbo].[Purchase]
ADD CONSTRAINT [FK_IngridientPurchase]
    FOREIGN KEY ([Ingridient_Id])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IngridientPurchase'
CREATE INDEX [IX_FK_IngridientPurchase]
ON [dbo].[Purchase]
    ([Ingridient_Id]);
GO

-- Creating foreign key on [Ingridient_Id] in table 'Ejection'
ALTER TABLE [dbo].[Ejection]
ADD CONSTRAINT [FK_IngridientEjection]
    FOREIGN KEY ([Ingridient_Id])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IngridientEjection'
CREATE INDEX [IX_FK_IngridientEjection]
ON [dbo].[Ejection]
    ([Ingridient_Id]);
GO

-- Creating foreign key on [Ingridient_Id] in table 'RecipeDishIngr'
ALTER TABLE [dbo].[RecipeDishIngr]
ADD CONSTRAINT [FK_IngridientDIConnection]
    FOREIGN KEY ([Ingridient_Id])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IngridientDIConnection'
CREATE INDEX [IX_FK_IngridientDIConnection]
ON [dbo].[RecipeDishIngr]
    ([Ingridient_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_CategoryProduct]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryProduct'
CREATE INDEX [IX_FK_CategoryProduct]
ON [dbo].[Product]
    ([Category_Id]);
GO

-- Creating foreign key on [Manufacturer_Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_CompanyProduct]
    FOREIGN KEY ([Manufacturer_Id])
    REFERENCES [dbo].[Company]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyProduct'
CREATE INDEX [IX_FK_CompanyProduct]
ON [dbo].[Product]
    ([Manufacturer_Id]);
GO

-- Creating foreign key on [Ingredient_Id] in table 'RecipePrepIngr'
ALTER TABLE [dbo].[RecipePrepIngr]
ADD CONSTRAINT [FK_ProductRecipePrepIngr]
    FOREIGN KEY ([Ingredient_Id])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductRecipePrepIngr'
CREATE INDEX [IX_FK_ProductRecipePrepIngr]
ON [dbo].[RecipePrepIngr]
    ([Ingredient_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'CheckMerchandise'
ALTER TABLE [dbo].[CheckMerchandise]
ADD CONSTRAINT [FK_ProductCheckMerchandise]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCheckMerchandise'
CREATE INDEX [IX_FK_ProductCheckMerchandise]
ON [dbo].[CheckMerchandise]
    ([Product_Id]);
GO

-- Creating foreign key on [Dish_Id] in table 'CheckDish'
ALTER TABLE [dbo].[CheckDish]
ADD CONSTRAINT [FK_DishCheck]
    FOREIGN KEY ([Dish_Id])
    REFERENCES [dbo].[Dish]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DishCheck'
CREATE INDEX [IX_FK_DishCheck]
ON [dbo].[CheckDish]
    ([Dish_Id]);
GO

-- Creating foreign key on [Dish_Id] in table 'RecipeDishIngr'
ALTER TABLE [dbo].[RecipeDishIngr]
ADD CONSTRAINT [FK_DishDIConnection]
    FOREIGN KEY ([Dish_Id])
    REFERENCES [dbo].[Dish]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DishDIConnection'
CREATE INDEX [IX_FK_DishDIConnection]
ON [dbo].[RecipeDishIngr]
    ([Dish_Id]);
GO

-- Creating foreign key on [CookingPlace_Id] in table 'Dish'
ALTER TABLE [dbo].[Dish]
ADD CONSTRAINT [FK_RoomDish]
    FOREIGN KEY ([CookingPlace_Id])
    REFERENCES [dbo].[Room]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomDish'
CREATE INDEX [IX_FK_RoomDish]
ON [dbo].[Dish]
    ([CookingPlace_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'Dish'
ALTER TABLE [dbo].[Dish]
ADD CONSTRAINT [FK_CategoryDish]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryDish'
CREATE INDEX [IX_FK_CategoryDish]
ON [dbo].[Dish]
    ([Category_Id]);
GO

-- Creating foreign key on [Dish_Id] in table 'RecipeDishPrep'
ALTER TABLE [dbo].[RecipeDishPrep]
ADD CONSTRAINT [FK_DishRecipeDishPrep]
    FOREIGN KEY ([Dish_Id])
    REFERENCES [dbo].[Dish]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DishRecipeDishPrep'
CREATE INDEX [IX_FK_DishRecipeDishPrep]
ON [dbo].[RecipeDishPrep]
    ([Dish_Id]);
GO

-- Creating foreign key on [Table_Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_TableOrder]
    FOREIGN KEY ([Table_Id])
    REFERENCES [dbo].[TableSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TableOrder'
CREATE INDEX [IX_FK_TableOrder]
ON [dbo].[Order]
    ([Table_Id]);
GO

-- Creating foreign key on [Owner_Id] in table 'Branch'
ALTER TABLE [dbo].[Branch]
ADD CONSTRAINT [FK_OwnerBranch]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [dbo].[Person_CompanyOwner]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnerBranch'
CREATE INDEX [IX_FK_OwnerBranch]
ON [dbo].[Branch]
    ([Owner_Id]);
GO

-- Creating foreign key on [Company_Id] in table 'Person_ContactPerson'
ALTER TABLE [dbo].[Person_ContactPerson]
ADD CONSTRAINT [FK_CompanyContactPerson]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[Company]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyContactPerson'
CREATE INDEX [IX_FK_CompanyContactPerson]
ON [dbo].[Person_ContactPerson]
    ([Company_Id]);
GO

-- Creating foreign key on [Prepack_Id] in table 'RecipePrepIngr'
ALTER TABLE [dbo].[RecipePrepIngr]
ADD CONSTRAINT [FK_PrepackRecipePrepIngr]
    FOREIGN KEY ([Prepack_Id])
    REFERENCES [dbo].[PrepackSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrepackRecipePrepIngr'
CREATE INDEX [IX_FK_PrepackRecipePrepIngr]
ON [dbo].[RecipePrepIngr]
    ([Prepack_Id]);
GO

-- Creating foreign key on [Prepack_Id] in table 'RecipeDishPrep'
ALTER TABLE [dbo].[RecipeDishPrep]
ADD CONSTRAINT [FK_PrepackRecipeDishPrep]
    FOREIGN KEY ([Prepack_Id])
    REFERENCES [dbo].[PrepackSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrepackRecipeDishPrep'
CREATE INDEX [IX_FK_PrepackRecipeDishPrep]
ON [dbo].[RecipeDishPrep]
    ([Prepack_Id]);
GO

-- Creating foreign key on [Prepack_Id] in table 'RecipePrepPrep'
ALTER TABLE [dbo].[RecipePrepPrep]
ADD CONSTRAINT [FK_PrepackRecipePrepPrep]
    FOREIGN KEY ([Prepack_Id])
    REFERENCES [dbo].[PrepackSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrepackRecipePrepPrep'
CREATE INDEX [IX_FK_PrepackRecipePrepPrep]
ON [dbo].[RecipePrepPrep]
    ([Prepack_Id]);
GO

-- Creating foreign key on [Result_Id] in table 'RecipePrepPrep'
ALTER TABLE [dbo].[RecipePrepPrep]
ADD CONSTRAINT [FK_PrepackRecipePrepPrep1]
    FOREIGN KEY ([Result_Id])
    REFERENCES [dbo].[PrepackSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrepackRecipePrepPrep1'
CREATE INDEX [IX_FK_PrepackRecipePrepPrep1]
ON [dbo].[RecipePrepPrep]
    ([Result_Id]);
GO

-- Creating foreign key on [Branch_Id] in table 'EncashmentSet'
ALTER TABLE [dbo].[EncashmentSet]
ADD CONSTRAINT [FK_BranchEncashment]
    FOREIGN KEY ([Branch_Id])
    REFERENCES [dbo].[Branch]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchEncashment'
CREATE INDEX [IX_FK_BranchEncashment]
ON [dbo].[EncashmentSet]
    ([Branch_Id]);
GO

-- Creating foreign key on [Branch_Id] in table 'ShiftSet'
ALTER TABLE [dbo].[ShiftSet]
ADD CONSTRAINT [FK_BranchShift]
    FOREIGN KEY ([Branch_Id])
    REFERENCES [dbo].[Branch]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchShift'
CREATE INDEX [IX_FK_BranchShift]
ON [dbo].[ShiftSet]
    ([Branch_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'CheckMerchandise'
ALTER TABLE [dbo].[CheckMerchandise]
ADD CONSTRAINT [FK_OrderCheckMerchandise]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[Order]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderCheckMerchandise'
CREATE INDEX [IX_FK_OrderCheckMerchandise]
ON [dbo].[CheckMerchandise]
    ([Order_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'CheckDish'
ALTER TABLE [dbo].[CheckDish]
ADD CONSTRAINT [FK_OrderCheckDish]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[Order]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderCheckDish'
CREATE INDEX [IX_FK_OrderCheckDish]
ON [dbo].[CheckDish]
    ([Order_Id]);
GO

-- Creating foreign key on [Room_Id] in table 'TableSet'
ALTER TABLE [dbo].[TableSet]
ADD CONSTRAINT [FK_RoomTable]
    FOREIGN KEY ([Room_Id])
    REFERENCES [dbo].[Room]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomTable'
CREATE INDEX [IX_FK_RoomTable]
ON [dbo].[TableSet]
    ([Room_Id]);
GO

-- Creating foreign key on [Branch_Id] in table 'Room'
ALTER TABLE [dbo].[Room]
ADD CONSTRAINT [FK_BranchRoom]
    FOREIGN KEY ([Branch_Id])
    REFERENCES [dbo].[Branch]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchRoom'
CREATE INDEX [IX_FK_BranchRoom]
ON [dbo].[Room]
    ([Branch_Id]);
GO

-- Creating foreign key on [Provider_Id] in table 'Purchase'
ALTER TABLE [dbo].[Purchase]
ADD CONSTRAINT [FK_CompanyPurchase]
    FOREIGN KEY ([Provider_Id])
    REFERENCES [dbo].[Company]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyPurchase'
CREATE INDEX [IX_FK_CompanyPurchase]
ON [dbo].[Purchase]
    ([Provider_Id]);
GO

-- Creating foreign key on [ParrentCategory_Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [FK_CategoryCategory]
    FOREIGN KEY ([ParrentCategory_Id])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryCategory'
CREATE INDEX [IX_FK_CategoryCategory]
ON [dbo].[Category]
    ([ParrentCategory_Id]);
GO

-- Creating foreign key on [Landlord_Id] in table 'Branch'
ALTER TABLE [dbo].[Branch]
ADD CONSTRAINT [FK_LandlordBranch]
    FOREIGN KEY ([Landlord_Id])
    REFERENCES [dbo].[Person_Landlord]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LandlordBranch'
CREATE INDEX [IX_FK_LandlordBranch]
ON [dbo].[Branch]
    ([Landlord_Id]);
GO

-- Creating foreign key on [Client_Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_ClientOrder]
    FOREIGN KEY ([Client_Id])
    REFERENCES [dbo].[Person_Client]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientOrder'
CREATE INDEX [IX_FK_ClientOrder]
ON [dbo].[Order]
    ([Client_Id]);
GO

-- Creating foreign key on [Id] in table 'Person_Employee'
ALTER TABLE [dbo].[Person_Employee]
ADD CONSTRAINT [FK_Employee_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Person_CompanyOwner'
ALTER TABLE [dbo].[Person_CompanyOwner]
ADD CONSTRAINT [FK_CompanyOwner_inherits_Employee]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Person_Employee]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Person_ContactPerson'
ALTER TABLE [dbo].[Person_ContactPerson]
ADD CONSTRAINT [FK_ContactPerson_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Person_Landlord'
ALTER TABLE [dbo].[Person_Landlord]
ADD CONSTRAINT [FK_Landlord_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Person_Client'
ALTER TABLE [dbo].[Person_Client]
ADD CONSTRAINT [FK_Client_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------