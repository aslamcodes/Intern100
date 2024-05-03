--  1) Print the storeid and number of orders for the store
select  stores.stor_id 'Store ID', COUNT(*) 'Number of Orders' from stores join sales on sales.stor_id = stores.stor_id group by stores.stor_id;

--  2) print the numebr of orders for every title
select titles.title, COUNT(*) 'Orders' from sales join titles on sales.title_id = titles.title_id group by titles.title;

--  3) print the publisher name and book name
select publishers.pub_name 'Publisher', titles.title 'Title' from publishers join titles on titles.pub_id = publishers.pub_id;

--  4) Print the author full name for all the authors
select au_id 'Author ID', au_fname + ' ' + au_lname 'Author Full Name' from authors;

--  5) Print the price or every book with tax (price+price*12.36/100)
select title 'Title', price+price*12.36/100 'Price (incl tax)' from titles;

--  6) Print the author name, title name
select A.au_fname + ' ' + A.au_lname 'Author', T.title 'Title' from authors A 
join titleauthor TA on TA.au_id = A.au_id
join titles T on TA.title_id = T.title_id;

 --  7) print the author name, title name and the publisher name
select  A.au_fname + ' ' + A.au_lname 'Author', T.title 'Title', P.pub_name 'Publisher' from authors A
join titleauthor TA on TA.au_id = A.au_id
join titles T on TA.title_id = T.title_id
join publishers P on P.pub_id = T.pub_id;


--  8) Print the average price of books pulished by every publicher
select P.pub_name 'Publisher', AVG(price) 'Average title price'  from titles T join publishers P on P.pub_id = T.pub_id group by P.pub_name;

--  9) print the books published by 'Marjorie'
select *  from titles T where pub_id in (Select pub_id from publishers where pub_name = 'Marjorie');

--  10) Print the order numbers of books published by 'New Moon Books'
--select sales.ord_num 'Order numbers' from sales
select ord_num 'Order numbers' from sales
join titles on titles.title_id = sales.title_id
join publishers on publishers.pub_id = titles.pub_id
where publishers.pub_name = 'New Moon Books';

--  11) Print the number of orders for every publisher
select pub_name 'Publishers', COUNT(*) 'Orders' from publishers P
join titles T on T.pub_id = P.pub_id
join sales S on S.title_id = T.title_id
group by pub_name;


--  12) print the order number , book name, quantity, price and the total price for all orders
select ord_num 'Order', T.title 'Book',  qty 'Quantity', price 'Price' from sales S 
join titles T on T.title_id = S.title_id; 

select ord_num,  SUM(price) 'Total Price' from sales S join titles t on t.title_id = S.title_id group by S.ord_num order by S.ord_num;

--  13) print he total order quantity fro every book
select t.title_id 'Title', SUM(qty) 'Quantity' from sales s
join titles t on t.title_id = s.title_id
group by t.title_id;


--  14) print the total ordervalue for every book
select t.title_id 'Title', SUM(qty) 'Quantity' from sales s
join titles t on t.title_id = s.title_id
group by t.title_id; 

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select ord_num 'Order', SUM(qty * price) 'Total Order value' from sales s join titles t on t.title_id = s.title_id group by ord_num;


