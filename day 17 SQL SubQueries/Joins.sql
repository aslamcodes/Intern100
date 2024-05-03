-- cross joins
select * from Customers, Orders;


--Inner join

--Get teh categoryId and teh productname
select (select categoryname from Categories c where c.CategoryID = p.CategoryID), ProductName from products p;

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

--Get the Supplier company name, contact person name, Product name and the stock ordered
select CompanyName,ContactName,ProductName,UnitsOnOrder from Suppliers join Products on Suppliers.SupplierID=Products.SupplierID

 --Print the order id, customername and the fright cost for all teh orders
select OrderID, ContactName, Freight from Orders join Customers on Customers.CustomerID = Orders.CustomerID;


 --product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold", od.discount,
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice * od.Quantity) - (p.UnitPrice * od.Quantity) * (od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o 
 join [Order Details] od on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID

 
 --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)
 select * from Customers;
 select * from Products;
 select * from Orders;
 select * from [Order Details];

 select C.ContactName as 'Customer Name', P.ProductName as 'Product Name', OD.Quantity as 'Quantity Sold', O.Freight as 'Freight Cost' from [Order Details] OD 
 join Orders O on OD.OrderID = O.OrderID
 join Products P on OD.ProductID = P.ProductID
 join Customers C on O.CustomerID = C.CustomerID;

 --Print the product name and the total quantity sold
 select productName, SUM(Quantity)
 from products p join [Order Details] od
 on p.ProductID = od.ProductID
 group by ProductName
 order by 2 desc;

 select C.ContactName 'Customer', O.OrderId 'Order', SUM(OD.Quantity) 'Quantity'
 from Customers C 
 join Orders O on O.CustomerID = C.CustomerID
 join [Order Details] OD on OD.OrderID = O.OrderID
 group by C.ContactName, O.OrderID
 order by C.ContactName, O.OrderID;

 select P.ProductName from Products P join [Order Details] OD on OD.ProductID = P.ProductID;
