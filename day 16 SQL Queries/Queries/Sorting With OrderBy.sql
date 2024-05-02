
select productName,UnitPrice from products
where UnitPrice>15
order by CategoryId;


--Get the products sorted by the price. Fetch only those products that will be discontiued
select ProductName, UnitPrice, UnitsInStock from Products where Discontinued = 1 order by UnitPrice;


--sort by category id and fetch the sum of unit price of products that will not be discontinued
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
order by categoryId

--sort by category id and fetch the sum of unit price of products that will not be discontinued
--select only if the category is having products total price greater than 200
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by categoryId
--(or)
select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by 1


--Select the products order by the price in descending order

select * from products order by 6 desc
--(or)
select * from products order by UnitPrice desc

select *,
Rank() over(order by UnitPrice desc)
from products 

select *, RANK() over (order by Country) from customers;