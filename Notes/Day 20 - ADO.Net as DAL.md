# Summary
## Morning
- Data Storage connection with C# 
- ADO .NET
	- Connection
	- Command
	- Parameters
	- Queries / NonQueries
- EF Core
## Afternoon
- Worked on assignment after code showcase
## Evening Plan
- Explore Hugging Face 
# Notes
![[Pasted image 20240508110126.png]]
- EF core has two approach towards the ORM
	- Database first approach
	- Code first approach
- Context class
- The context class has code generated for us
- We can inherit the dbcontext for customisation
![[Pasted image 20240508110054.png]]
- scaffold command can be used to load classes from database
## CodeFirst
- Inherit the DBContext to customise
		`Add Migration` will be used generate a class that inherits Migrate
		`update-database` will migrate the migration
## Primary Key
- use a annotaion `[key]`
- if you name the prop `Id` it'll become primary key by default
- if the datatype is int, it'll become identity

## Steps to migrate

CREATE THE MODEL
CREATE THE CONTEXT
GO TO PACKAGE MANAGER CONSOLE
`Add Migration`
`update-database`

![[Pasted image 20240508095213.png]]