# EF Codd
- Foundation rule -> Only with relations

- Information rule -> All information is represented at logical level with values in the table (columns and rows)

- Guaranteed access -> Each data and every data is already atomic value is guaranteed to be logically accessible through primary key, table name and column name

- Systematic treatment of null values -> These null values are either missing values or inapplicable only not zeros or null strings, should be treated systematically

- Dynamic Online catalogue -> related to database desc and data access

- comprehensive data sublang rule -> Has to support anyway of support language to interact with db?

- view update-> if view updates update the database

- Relational Level Operation -> A database system should follow high-level relational operations such as insert, update, and delete in each level or a single row

- Physical Data Independence Rule -> Each data should not depend on other data or an application

# ACID
These props make sure that a database can perform transactions in a reliable manner

Atomicity 
Consistency
-  Database should help achieve consistency in our database
Isolation
- Database should make sure concurrent transaction are treated as sequential transaction
Durability
- Transactions must be persisted?

What is a transaction?
Single unit of work (one/multiple query)

Why nosql not ACID?
Consitency or Durability is compromised in NoSQL