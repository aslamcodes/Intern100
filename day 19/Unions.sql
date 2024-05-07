select * from Categories

select * from Suppliers

select CategoryID 'ID',  categoryname 'Name' from Categories
union
select SupplierId,CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry='Spain'
intersect
select * from orders where Freight>50

--get the order id, productname and quantitysold of products that have price
--greater than 15

select OrderID, ProductName, Quantity "Quantity Sold"
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15


--get the order id, productname and quantitysold of products that are from category 'dairy'
--and within the price range of 10 to 20
select O.OrderId, P.ProductName, OD.Quantity from Orders O
join [Order Details] OD on O.OrderID = OD.OrderID
join Products P on P.ProductID = OD.ProductID
join Categories C on C.CategoryID = P.CategoryID
where C.CategoryName like '%dairy%' and P.UnitPrice between 10 and 20;


select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'
order by p.unitprice desc


sp_help Orders;
sp_help [Order Details];
sp_help Products;
sp_help Categories;