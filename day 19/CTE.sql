
  with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
  as
  (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
  from [Order Details] od join Products p
  on od.ProductId = p.ProductID
  where p.UnitPrice>15
  union
  SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
  JOIN Products p ON p.ProductID = [Order Details].ProductID
  JOIN Categories c ON c.CategoryID = p.CategoryID
  WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

  select top 10 * from  OrderDetails_CTE order by price desc

  -- View
  create view vwOrderDetails
  as
  (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
  from [Order Details] od join Products p
  on od.ProductId = p.ProductID
  where p.UnitPrice>15
  union
  SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
  JOIN Products p ON p.ProductID = [Order Details].ProductID
  JOIN Categories c ON c.CategoryID = p.CategoryID
  WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')


select * from vwOrderDetails order by UnitPrice
drop view vwOrderDetails;

