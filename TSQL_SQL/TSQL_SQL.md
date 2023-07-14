# .sql'i direk kendinize ekleyebilriisiniz.


Temel SQL Komutlar� Northwind ile kullan�lmal�.<br>

### USE `DB se�mede kullan�l�r`
USE Northwind<br>

### SELECT `ad� �zerinde se�imdir`

SELECT Id <br>
SELECT CategoryID, CategoryName FROM Categories<br>

### WHERE `ko�ul ifade eder`

SELECT CategoryID, CategoryName FROM Categories<br>
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryID > 5<br>

### BETWEEN Komutu

SELECT CategoryID, CategoryName FROM Categories<br>
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryID  BETWEEN 3 AND 6<br>

### IN Komutu

SELECT CategoryID, CategoryName FROM Categories<br>
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryID  IN(2,4,6,8)<br>

### LIKE

SELECT CategoryID, CategoryName FROM Categories<br>
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryName LIKE 'C%'<br>
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryName LIKE '%S'<br>
SELECT CategoryID, CategoryName FROM Categories WHERE CategoryName LIKE 'C%S'<br>

### AGGREHATE

SELECT ProductID, ProductName, UnitPrice FROM Products<br>
SELECT AVG(UnitPrice) FROM Products<br>
SELECT MAX(UnitPrice) FROM Products<br>
SELECT MIN(UnitPrice) FROM Products<br>
SELECT Count(UnitPrice) FROM Products<br>

### DISTINCT ayn� verileri teke indirir

SELECT Count(UnitPrice) FROM Products<br>
SELECT Count(DISTINCT(UnitPrice)) FROM Products<br>
























































