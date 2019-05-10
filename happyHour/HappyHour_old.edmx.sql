
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/09/2019 15:07:28
-- Generated from EDMX file: C:\Dev\EventAttendanceApp\EventAttendanceApp\HappyHour.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

IF DB_ID('people') IS NULL
CREATE DATABASE people
GO

USE [people];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HappyHours'
CREATE TABLE [dbo].[HappyHours] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [EmployeeName] varchar(255)  NOT NULL,
    [EmployeeLoginTime] datetime  NOT NULL,
    [DrinkCount] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmployeeId] in table 'HappyHours'
ALTER TABLE [dbo].[HappyHours]
ADD CONSTRAINT [PK_HappyHours]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------