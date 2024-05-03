### Morning Session
Learnt a variety queries and their usages, including UPDATE, DELETE and Selection Queries. 
Learnt aggregation concepts in SQL such as AVG, COUNT, SUM using them with Group by and having clauses
### Afternoon Session
Worked on 10 to 15 SQL problems on a SQL Database and practiced some problems on Postgre too.
### Evening Plan
Reinforce my understanding some complex SQL concepts and to learn some LLM concepts 


# Update Query
- Implicitly uses cursor behind the scenes
- Without setting filters with Where clause everything will get updated
- Where can have more than one condition using `and`
- `When` and `then` can be used as like `if else` with Update statement
![[Pasted image 20240502095537.png]]
# Delete Query
> [!WARN] Delete will delete everything if there's no `Where` clause

Delete from Employee where area = 'kkkk'

# Select Query
- * means selecting all the columns
- We can handpick with column names
- We can choose to have alias for column names for better readability using `as`
```sql
select * from Products

select ProductName, QuantityPerUnit from Products

select ProductName Name_Of_Product, QuantityPerUnit as Quantity_Per_Unit from Products

select ProductName 'Name Of Product', QuantityPerUnit as Quantity_Per_Unit from Products
```

## Like Clause
`%` - is a wild clause, can be replaced by zero or any number of characters.
`__` - wild clause, can be replaced by exactly 2 characters
![[Pasted image 20240502104356.png]]
# Not so straight forward aggregates
Get the sum of products in stock for every category
> if (Every) then (Group) - Gayathri

Think this way?

What happens when you do
```sql
Select categoryID from Products;
```
it'll return all the category ids right? 111 22 33 ....?

If so, now.. What happens when you do the same but with `group by`?
```sql
Select categoryID from Products group by categoryID;
```
The results are going to look lie 1 2 3.

Now imagine the individual 1 is a representation of many 1s, and 2 is many 2's and three is many 3's

>When you do Sum(on any column) it'll take the represents **group** for calculation!!!

# why `Select * from products group by supplierID` wont work?  
## Gayathri's explanation
You have to say what are you going to do with the category!
You have to aggregate other columns than the one you're grouping

## An absurd query down.
```sql
Select supplierID, ProductName from products group by product
```
For every unique supplier ID you want product name??? you dump...

## Yes we can group by more then one column
![[Pasted image 20240502115249.png]]

## what happens when you group?
First group then aggregate
We can control the grouping phase too, with having clause.
so this below query will only the category when its average price is greater.
![[Pasted image 20240502120000.png]]

## Ranking
```sql
select *,
Rank over(order by UnitPrice desc)
from products 
```