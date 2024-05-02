use pubs;

-- Print all the titles names
Select title from titles;

-- Print all the titles that have been published by 1389
Select * from titles where pubdate between '1989-01-01' and '2000-12-30' order by pubdate;

-- Print the books that have a price in the range of 10 to 15
Select * from titles where price between 10 and 15;

-- Print those books that have no price
Select * from titles where price is Null;

-- Print the book names that start with 'The'
Select * from titles where title like 'The %';

-- Print the book names that do not have 'v' in their name
Select * from titles where title not like '%v%';

-- Print the books sorted by royalty
Select * from titles where royalty is not null order by royalty;

-- Print the books sorted by publisher in descending, 
-- then by types in ascending, then by price in descending
Select * from titles where royalty is not null order by pub_id desc, type asc;

-- Print the average price of books in every type
Select type, AVG(price) 'Average Price' from titles group by type;

-- Print all the types in unique
Select type from titles group by type;

-- Print the first 2 costliest books
Select top 2 title from titles order by price desc;

-- Print books that are of type business and have a price less than 20 which also have an advance greater than 7000
select title from titles where type = 'business' and price < 20 and advance > 7000;

-- Select those publisher id and number of books which have a price between 15 to 25 and have 'It' in its name. 
-- Print only those which have a count greater than 2. Also, sort the result in ascending order of count
select pub_id, count(pub_id) 'Number of Books' from titles 
where price between 15 and 25 and title like '%it%' 
group by pub_id
having COUNT(pub_id) > 2
order by COUNT(pub_id);

-- Print the Authors who are from 'CA'
select au_fname+' '+au_lname 'Authors from CA' from authors where state = 'CA';


-- Print the count of authors from every state
select state, COUNT(au_id) from authors group by state;

