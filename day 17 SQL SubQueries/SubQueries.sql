select * from Categories

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

--select product names from the supplier Tokyo Traders
select productname from products where SupplierID = (select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

--get all the products that are supplied by suppliers from USA
select productname from products where SupplierID in (select SupplierID from Suppliers where Country= 'usa');

--get all the products from the category that has 'ea' in the description
select * from products where CategoryID in (select CategoryID from Categories where Description like '%ea%');
--for (product in product) 
--	for(category in categories) 
--		if(product.categoryid == category.categoryid) 
--			catch

--select the product id and the quantity ordered by customrs from France
select * from  [order details] where orderid in (select orderid from orders where shipcountry = 'france')


--Get the products that are priced above the average price of all the products
select * from products where unitprice > (select AVG(unitprice) from products);

--select the latest order from every employee
select EmployeeId from employees;

-- wrong (not corelated)
select * from orders o1 where orderdate in (select MAX(orderdate) from orders o2 where o2.employeeid = o1.employeeid);
-- correct (corelated)

--Select the lastet order by every employee
select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

--Select the maximum priced product in every category
select * from products p1 where unitprice = (select max(unitprice) from products p2 where p1.categoryid = p2.categoryid)

select categoryId from categories group by categoryid

--select the order number for the maximum fright paid by every customer
select orderid from orders o1 where freight = (select max(freight) from orders o2 where o1.CustomerID = o2.CustomerID)