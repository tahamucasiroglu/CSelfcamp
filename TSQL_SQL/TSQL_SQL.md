# .sql'i direk kendinize ekleyebilriisiniz.


Temel SQL Komutlarý Northwind ile kullanýlmalý.<br>

### USE `DB seçmede kullanýlýr`
USE Northwind<br>

### SELECT `adý üzerinde seçimdir`

SELECT Id <br>
SELECT CategoryID, CategoryName FROM Categories<br>

### WHERE `koþul ifade eder`

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

### DISTINCT ayný verileri teke indirir

SELECT Count(UnitPrice) FROM Products<br>
SELECT Count(DISTINCT(UnitPrice)) FROM Products<br>
























































