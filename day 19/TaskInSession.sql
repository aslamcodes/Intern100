--Get the first 10 records of

--The order ID, Customer name and the product name for products that are purchased by 
--people from USA

--The order ID, Customer name and the product name for products that are purchased by
-- people from france with fright less than 20

sp_help Orders;
sp_help Customers;
sp_help [Order Details];

with OrderDetailsFRUS_CTE (OrderID,CustomerName,ProductName) as (
select O.OrderId, C.ContactName, P.ProductName 
from Orders O
join [Order Details] OD on OD.OrderID = O.OrderID
join Customers C on C.CustomerID = O.CustomerID
join Products P on P.ProductID = OD.ProductID
where O.ShipCountry like 'USA'
union
select O.OrderId, C.ContactName, P.ProductName 
from Orders O
join [Order Details] OD on OD.OrderID = O.OrderID
join Customers C on C.CustomerID = O.CustomerID
join Products P on P.ProductID = OD.ProductID
where O.ShipCountry like 'France' and O.Freight < 20)

Select top 10 * from OrderDetailsFRUS_CTE;


with OrderDetailsFRUS_CTE2 (OrderID,CustomerName,ProductName) as (
select O.OrderId, C.ContactName, P.ProductName 
from Orders O
join [Order Details] OD on OD.OrderID = O.OrderID
join Customers C on C.CustomerID = O.CustomerID
join Products P on P.ProductID = OD.ProductID
where O.ShipCountry like 'USA' or O.ShipCountry like 'France'and O.Freight < 20)



Select top 10 * from OrderDetailsFRUS_CTE2;
