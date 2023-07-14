-- Temel SQL Komutları Northwind ile kullanılmalı.
-- USE -> DB seçmede kullanılır
USE Northwind

-- SELECT adı üzerinde seçimdir

SELECT Id 
SELECT CategoryID, CategoryName FROM Categories

-- WHERE koşul ifade eder

SELECT CategoryID, CategoryName FROM Categories
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryID > 5

-- BETWEEN Komutu

SELECT CategoryID, CategoryName FROM Categories
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryID  BETWEEN 3 AND 6

-- IN Komutu

SELECT CategoryID, CategoryName FROM Categories
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryID  IN(2,4,6,8)

-- LIKE

SELECT CategoryID, CategoryName FROM Categories
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryName LIKE 'C%'
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryName LIKE '%S'
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryName LIKE 'C%S'

-- AGGREHATE

SELECT ProductID, ProductName, UnitPrice FROM Products
SELECT AVG(UnitPrice) FROM Products
SELECT MAX(UnitPrice) FROM Products
SELECT MIN(UnitPrice) FROM Products
SELECT Count(UnitPrice) FROM Products

-- DISTINCT aynı verileri teke indirir

SELECT Count(UnitPrice) FROM Products
SELECT Count(DISTINCT(UnitPrice)) FROM Products
























































