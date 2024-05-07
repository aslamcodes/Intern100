# Summary
## Morning
- SQL Unions and Intersection
- CTE - Common Table Expression
- Learnt Indexing & Stored Procedures
## Evening
- Code showcase
- Self learning on DCL commands
- Assignments
## Self Learning
- Study freecodecamp's [genAI](https://www.youtube.com/watch?v=mEsleV16qdo&t=9808s)course 
 - Try the devContainers from Docker
# Notes
## Union
> [!NOTE] The upper query of union cannot contain order by
## CTE
- They're not gonna be stored in the memory
- Its a temporary schema for set of queries you want
- If you're not planning to do this, you have rely on `views` which are going to be stored in SQL Memory
- CTE lifetime is only about the selected query execution alone.
- After execution of every queries `with` the defined the CTE, the CTE drops
### CTE, View, Temp Table from Reddit 
Views, temp tables, and CTEs primarily differ in scope.

A temp table’s data-set exists for the length of a session.

A CTE’s result-set exists for the length of a single query.

A view is permanent and depending on details, may not actually ‘exist’ as a separate result-set, just as a form of redirection/aliasing.

There are other differences, but they’re the easiest to understand why you’d choose one or the other.
## Indexing
## Stored Procedure
https://stackoverflow.com/questions/5194995/what-is-the-difference-between-a-stored-procedure-and-a-view
## Grant & Revoke
### CREATE Schemas & Database
 while `CREATE DATABASE` is used to create a new database, `CREATE SCHEMA` is used to create a new schema within an existing database. A database can contain multiple schemas, and schemas can contain multiple database objects.
### Grant

### Revoke