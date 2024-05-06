# Summary
## Morning
- ERD
- Outer Join
## Afternoon Session
- Hackerrank Test
# Notes
- You need database designs everywhere
- Nouns will become entities, the adjectives will become attributes, the connection with the other nouns become relationships
## Scenario

![[Pasted image 20240506105359.png]]
![[Shop ERD 1.png]]
## Outer  join
- inner join only takes the **relevant** entries from parent and child, 
- Whereas when you make the statement `left/right/full outer join` it includes `parent/child/both` entity table respectively and fills with `NULL` values for non relevant entries.
```sql
select * from customers where CustomerID not in (select distinct customerid from Orders)

select * from orders

select ContactName,ShipName,ShipAddress
from customers c join orders o
on c.CustomerID = o.CustomerID

select ContactName,ShipName,ShipAddress
from customers c left outer join orders o
on c.CustomerID = o.CustomerID
```
# Test Strategies
## Note from Gayathri
- Name your classes properly
- When you use array of collection, instantiate every element of it
- If interface, you'll nee to override all the methods.
- Keep everything as properties not (global) variables
- Pay attention to access specifiers
- Remember handling exceptions and custom exceptions
## Note from Rithika
- 1hr 45 min test 3 - 4:30 to 5 
- Use Personal Email IDs
[14:09] Kavin Kumar M (Guest)
1. Number of Questions?
		Will be known from tests
1. do we need to code inside the hackerank platform itself or upload from our source? 
		yes
- No plagiarism, nothing. Can be caught easily.