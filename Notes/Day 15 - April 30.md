# Terminologies
- Ef Codd 12 rules for RDBMS
- **Entity / Relation**
	- is Strong if it has Primary key
	- is Weak if there's No PK
	- Derived (first name + last name)
- **Attributes**
	 - Simple - single unit of data
	 - Multiple - More that one unit of data, can't be separated into columns (Skills)
	 - Complex - More than one unit of data, but can be spitted (full name, address)
	 - Derived - value derived from another attribute (age can be derived from DOB)
- Primary key - Non null, No duplication
- Composite Key - Combination of two or more attribute that becomes PK
- Foreign Key - Primary key of another entity appearing in the current entity
# Normalization Rules
- I you wish to organize your data, better look at the rules created by our EFCodd here.
## 1st Normal Form
- No multi-valued attributed (split them in columns/insert them in rows) *creates another table*
- PK is mandate
- All data in a attributes should be of similar datatypes
## 2nd Normal Form
- Entity has to be in 1NF
- No Partial Dependency
	- ![[Pasted image 20240430100826.png]]
	- Skill description has nothing to with id of the skill
	- Skill level is dependent on the composite key
	- ***todo***: separate them out ![[Pasted image 20240430100913.png]]
## 3rd Normal Form
- The table has to be in 2NF
- No Transitive dependency
- A -> B -> C

## SQL Lang Categories
DDL - Definination
DML - Manipulation
DQL - Query

## Create a Database
- Switch to `master` database
- and then write query from there `create database dbname`  
- You can cursor select what part of the query you've written and execute them only;
- `use dbname` switches to the particular database from master
- 
## delete database
- `drop database dbname` drops the database
- you cant delete the database you're currently in.

> [!NOTE] Varchar releases unnecessary blocks `varchar(max)`

> [!NOTE] Column name -> datatype

## How to make a column PK
### 1st Way
1. add Not null constraint
2. add Primary key constraint
### 2nd Way
1. Drop the table
	1. Recreate the table again
### Composite Key
```sql

```
### Today's code
```sql
--Create a database

create Table Areas
(Area varchar(25) primary key,
Zipcode char(5))

ALTER TABLE Areas
ALTER COLUMN Area varchar(25) NOT NULL;

ALTER TABLE Areas
ADD constraint PK_AREAS primary key(Area)


create table Employee (
id INT IDENTITY PRIMARY KEY, 
name varchar(255) not null,
dateOfBirth date constraint checkDOB Check(DateOfBirth < GetDate()),
area varchar(25) constraint fk_area references Areas(Area),
phone varchar(20),
email varchar(20));


select * from Areas
go
sp_help Areas

create table Skills(
Skill_id int constraint pk_skill primary key,
Skill varchar(20),
SkillDescription varchar(100))
go
sp_help Skills

alter table Skills drop constraint pk_skill;
alter table Skills drop column Skill_id;

alter table Skills add Skill_id int identity(1,1) constraint pk_skill primary key;



```