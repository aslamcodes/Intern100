select supplierid 'Supplier', avg(UnitPrice) 'Average Price' from products
group by(supplierid) 



select sum(UnitsInStock) "Stock of products in category 1"
from Products where CategoryID =1

select AVG(UnitPrice) 'Average price of products supplied by supplier 2' from Products where supplierid = 2; 

select SUM(unitsinstock * reorderlevel) from products;

select * from Suppliers;


--get teh average price for every supplier for evry category of product
select SupplierId, CategoryId, Avg(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierId

-- Supplier's average
SELECT Suppliers.CompanyName, Products.CategoryID, AVG(Products.UnitPrice)
FROM Products
INNER JOIN Suppliers ON Suppliers.SupplierID=Products.SupplierID
group by Suppliers.CompanyName, Products.CategoryID;

select SupplierId, CategoryId, Avg(UnitPrice) Average_Price
from Products
group by CategoryId,SupplierId
having avg(UnitPrice)>15

select * from Products;
--Select category ID and Sum of products avaible if the total number of products is 
--greater than 10
Select categoryId, SUM(UnitPrice) 'Total Price' from products group by CategoryID having COUNT(UnitsInStock) > 10;

