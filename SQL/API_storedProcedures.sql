USE [MMTShop]
GO
/*Stored Procedure - Get All Products*/
CREATE PROCEDURE SP_GetAllProducts
AS
BEGIN
	SELECT "SKU", "Name", "Description", "Price", (SELECT "Name" FROM Inventory.tbl_Category WHERE ID = Inventory.tbl_Product.CategoryID) AS CategoryName 
	FROM Inventory.tbl_Product
	ORDER BY SKU ASC;
END
GO

/*Stored Procedure - Get All Categories*/
CREATE PROCEDURE SP_GetAllCategories
AS
BEGIN
	SELECT * FROM Inventory.tbl_Category
	ORDER BY ID ASC;
END
GO

/*Stored Procedure - Get Featured Products*/
CREATE PROCEDURE SP_GetFeaturedProducts
AS
BEGIN
	SELECT "SKU", "Name", "Description", "Price", (SELECT "Name" FROM Inventory.tbl_Category WHERE ID = Inventory.tbl_Product.CategoryID) AS CategoryName 
	FROM Inventory.tbl_Product 
	WHERE Inventory.tbl_Product.CategoryID IN (SELECT CategoryID FROM Inventory.tbl_FeaturedProducts)
	ORDER BY SKU ASC;
END
GO

/*Stored Procedure - Get Products By Category*/
CREATE PROCEDURE SP_GetProductByCategory(@Parameter VARCHAR(50))
AS
BEGIN
	SELECT "SKU", "Name", "Description", "Price", (SELECT "Name" FROM Inventory.tbl_Category WHERE ID = Inventory.tbl_Product.CategoryID) AS CategoryName 
	FROM Inventory.tbl_Product
	WHERE Inventory.tbl_Product.CategoryID = (SELECT "ID" FROM Inventory.tbl_Category WHERE Inventory.tbl_Category."Name" = @Parameter)
	ORDER BY SKU ASC;
END
GO