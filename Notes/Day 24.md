---
Date: 2024-05-14
tags:
  - webapi
  - csharp
---
# Summary
# Notes
> New application and a standard for coming days

## Setup
- Clean the repo
- Start with a model `Employee`![[Pasted image 20240514095315.png]]
- Create a new folder models, no need to create separate projects
- Create a folder called contexts
- Add the EF core Nuget plugins, tools and sql-server provider
- Create a context class
![[Pasted image 20240514095857.png]]
- Migrate and Update database
## ASP.net things
- Create the repository interfaces ![[Pasted image 20240514100418.png]]
- Use injection in the constructor
- ASP.NET will have the Dependency injection container ![[Pasted image 20240514100735.png]]
- Add the `DBContext` to the services, and the container will inject the data
- Implement the repository
- **The next step is to inject the repo**
### Add Scoped
- Every request it'll create a object
![[Pasted image 20240514102035.png]]
### Add Singleton
- One object for all injections
### Add Transient

## Services
- Add service interface
- and implement them
# Adding controller
- On controllers, select add controller
- Controller name should always suffix the word `controller`, Eg EmployeeBasicController.
- `EmployeeBasic` is the resource name
- It is only when we name it the right way then the `builder.AddController()` will do the job the right. or when we inherit the controllerBase?
- `[HttpGet]` annotate the function
- All the methods are async
- The swagger picks up the controller too and with the documentation
- The data will be serialised the response
### The Connection String Injection
#### Step 1:
In the appSettings.json
![[Pasted image 20240514104704.png]]
### Step 2:
Injection details
![[Pasted image 20240514104814.png]]
#### Step 3:
Using the injection string
![[Pasted image 20240514104853.png]]

## PUT method
- use `[HttpPut]` annotation over the controller function
- Specify `Task<ActionResult<Resource>>` as return type
- Carry on with the logic
- returns with `ok()` to return a success, 
- If there's any excepion return the bad request
- HTTP verb to Status code, Uniform interface
![[Pasted image 20240514115133.png]]
- Same thing for Get message
- ![[Pasted image 20240514115247.png]]