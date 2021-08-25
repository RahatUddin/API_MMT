/*CREATE DATABASE
CREATE DATABASE MMTShop
GO*/

/*CREATE SCHEMA AND TABLES*/
USE [MMTShop]
GO
CREATE SCHEMA Inventory;
GO
CREATE TABLE Inventory.tbl_Category ("ID" int IDENTITY(1,1) PRIMARY KEY, "Name" varchar(50) NOT NULL UNIQUE);
GO
CREATE TABLE Inventory.tbl_Product ("SKU" int NOT NULL PRIMARY KEY, "Name" varchar(150) NOT NULL UNIQUE, "Description" varchar(MAX), "Price" decimal(10,2) NOT NULL, "CategoryID" int NOT NULL REFERENCES Inventory.tbl_Category(ID));
GO
CREATE TABLE Inventory.tbl_FeaturedProducts("CategoryID" INT NOT NULL REFERENCES Inventory.tbl_Category(ID) UNIQUE);
GO

/*INSERT DATA*/
INSERT INTO Inventory.tbl_Category ("Name")
VALUES ('Home'), ('Garden'), ('Electronics'), ('Fitness'), ('Toys');
GO

INSERT INTO Inventory.tbl_Product
VALUES (20001, 'Garden Hose', 'Used to spray water', 25, 2),
		(58821, 'PlayStation 5 - Digital Edition', 'Next-Generation Games Console (Digital)', 349, 5),
		(30005, 'PlayStation 5 - Disc Edition', 'Next-Generation Games Console (Disc)', 449, 3),
		(10002, 'Grey Cushion', 'Cushion that is grey', 14.49, 1),
		(40004, 'FitBit - Black', 'Keep fit with the new FitBit', 99.99, 4),
		(59999, 'Paw Patrol - Lego Set', 'A lego set of Paw Patrol', 99.99, 5);
GO

INSERT INTO Inventory.tbl_FeaturedProducts
VALUES (1),(2),(3);
GO