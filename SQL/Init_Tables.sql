USE master
GO

WHILE EXISTS(select NULL from sys.databases where name='PreliminaryTest')
BEGIN

	ALTER DATABASE PreliminaryTest 
	SET SINGLE_USER
	WITH ROLLBACK IMMEDIATE

	DROP TABLE IF EXISTS [PreliminaryTest].[Footfall]
	DROP TABLE IF EXISTS [PreliminaryTest].[Premisses]
	DROP TABLE IF EXISTS [PreliminaryTest].[Businesses]
	DROP DATABASE IF EXISTS PreliminaryTest

END
GO

CREATE DATABASE PreliminaryTest;
GO
 
USE PreliminaryTest;
GO

CREATE TABLE Businesses (
    Id int NOT NULL PRIMARY KEY,
    Business char(32)
);

CREATE TABLE Premisses (
    Id int NOT NULL PRIMARY KEY,
    Street char(32),
	PostCode char(32),
	StreetNo char(32),
	BusinessId int UNIQUE NOT NULL
);

ALTER TABLE Premisses
ADD CONSTRAINT FK_Premiss_Business FOREIGN KEY([BusinessId]) 
    REFERENCES [Businesses]([Id]) ON DELETE CASCADE;

CREATE TABLE Footfall (
    WeekNo int NOT NULL,
    PremissesId int NOT NULL,
	FootfallCount int NOT NULL
);

ALTER TABLE Footfall
ADD CONSTRAINT FK_Footfall_Premiss FOREIGN KEY([PremissesId]) 
    REFERENCES [Premisses]([Id]) ON DELETE CASCADE;
