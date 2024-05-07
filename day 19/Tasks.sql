-- 1. Create a stored procedure that will take the author firstname and 
-- print all the books polished by him with the publisher's name
CREATE PROCEDURE GetBooksByAuthor(@AuthorFirstName varchar(50))
AS
BEGIN
	SELECT A.au_fname 'Author', T.title 'Published Books', P.pub_name 'Publishers' from titles T
	JOIN publishers P on T.pub_id = P.pub_id
	JOIN titleauthor TA on TA.title_id = T.title_id 
	JOIN authors A on A.au_fname like '%'+@AuthorFirstName+'%'
END	

EXEC GetBooksByAuthor 'Sheryl'


-- 2. Create a sp that will take the employee's firtname and 
-- print all the titles sold by him/her, price, quantity and the cost.
ALTER PROCEDURE GetEmployeeSalesByName(@EmployeeFirstName varchar(50))
AS
BEGIN
	Select E.fname + ' ' + E.lname 'Employee', title 'Title', T.price 'Price', S.qty 'Quantity', T.price * S.qty 'Total Cost'
	From sales S
	Join titles T on S.title_id = T.title_id
	Join publishers P on P.pub_id = T.pub_id
	Join employee E on E.pub_id = P.pub_id
	where E.fname like '%' + @EmployeeFirstName + '%'
END

EXEC GetEmployeeSalesByName 'Paolo';


-- 3. Create a query that will print all names from authors and employees
select au_fname + ' ' + au_lname 'Names'
from authors
union
select fname + ' ' + lname
from  employee

-- Create a  query that will float the data from sales,titles, publisher and authors table 
-- to print title name, Publisher's name, author's full name with quantity ordered and price 
-- for the order for all orders,
-- print first 5 orders after sorting them based on the price of order
select top 5 T.title 'Title', P.pub_name 'Publisher', A.au_fname + ' ' + A.au_lname 'Author full name', S.qty 'Quantity', S.qty * T.price 'Price' 
from authors A 
join titleauthor TA on TA.au_id = A.au_id
join titles T on T.title_id = TA.title_id
join publishers P on P.pub_id = T.pub_id
join sales S on S.title_id = T.title_id
order by S.qty * T.price desc



