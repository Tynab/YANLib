CREATE DATABASE YANLIB;

USE YANLIB;

CREATE SCHEMA sample;

CREATE TABLE sample.DeveloperTypes
(
    Code INT PRIMARY KEY NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL,
    CreatedDate DATETIME NOT NULL,
    ModifiedDate DATETIME
);

CREATE TABLE sample.Developers
(
    Id VARCHAR(20) PRIMARY KEY NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    IdCard VARCHAR(20) NOT NULL,
    DeveloperTypeCode INT NOT NULL,
    IsActive BIT NOT NULL,
    Version INT NOT NULL,
    CreatedDate DATETIME NOT NULL,
    ModifiedDate DATETIME,
    FOREIGN KEY (DeveloperTypeCode) REFERENCES sample.DeveloperTypes(Code)
);

CREATE TABLE sample.Certificates
(
    Id VARCHAR(20) PRIMARY KEY NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    GPA DOUBLE PRECISION,
    DeveloperId VARCHAR(20),
    CreatedDate DATETIME NOT NULL,
    ModifiedDate DATETIME
);
