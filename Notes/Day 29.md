---
Date: 2024-05-21
tags:
  - "#aspnet"
  - "#testing"
---
# Testing
- Create a unit testing project
- We're gonna use the mocking techinique to mock the configurations
- `Moq` is the framework of choice for now.
## Setup
- Mocking the configuration 
	- `Mock<IConfigurationSection> configSection = new()`
- Setting up the section
	- `configSection.SetupGet(x => x.Value).Returns("jwtkey")`
- Setting up the configuration
```csharp
Mock<IConfiguration> configMock = new ();
configMock.Setup(x => x.GetSection("tokenKey").Returns(configSection.Object))
```
# Testing Database
- For Testing the DB context, we are going to use in memory database
- We need the `InMemory` Nuget for this from Microsoft.EntitryFramework
- And then we can
```csharp
     DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
     optionsBuilder.UseInMemoryDatabase("EmployeeTest");
     var context = new EmployeeContext(optionsBuilder.Options);
	     context.Database.EnsureCreated();
	     
```
# Dto Validation
- We can annotate with validation attrubutes
- We can dig deeper into it
![[Pasted image 20240521113327.png]]
	-`[RegularExpression("")]`
	- `[MinLength(8), ErrorMessage="message"]`
	-  `[Required(AllowEmptyString = false)]`
- After annotating we need to say on the controller
	```csharp
	if(!ModelState.Valid) {
		return BadRequest("Input not valid")
	}
```
> Int values is auto initialised to zero, therefore using [Range()] attribute will fix it
## What to Excepect in the project
- Proper open API spec
- Also postman is mandate
- Handle all exceptions
- DTOs should be properly organised
- Validation and Auth should managed perfectly
### Expectations
- [ ] All end point properly planned
- [ ] Have understanding of data flow
- [ ] Arrange postman workspace for testing
- [ ] Handle the open API documentations
- [ ] DTO for handling the flow.
- [ ] Layer separation - DTO for that as well
- [ ] Validation 
- [ ] Authentication and Authorization
### Additional
- [ ] ER Diagram
- [ ] Functional Requirement Listings
- [ ] Explore any thing new to implement
- [ ] Find alternative ways to do the same thing

> ***Deadline 2024-05-28***
#### Remaining Concepts
- [ ] Filters
- [ ] Auto-mapper
- [ ] Test Data
- [ ] Few Design patterns
- [ ] Solid Principle

# Mini Project - Cab Booking
## User Management
- Two Types of Users
	- Taxi drivers
	- Passenger
- user can authenticate with email and password
- Additional information can be collected through registration
- Users can modify their profile data
## Booking
- Passengers can specify ==pickup location== & ==vehicle type== and any available taxi should be allocated, only if the driver is open for rides 
	- using sockets would be great addition
- Ride status should be there
- Fare calculation should be done
- Ride can be cancelled before boarding
## Driver Registration
-  drivers can register by providing personal information, vehicle details, and required documents 
-  driver verification can be done
-  drivers can set their availability status (open for ride/offline).
## Passenger Rating
- A ==Passenger== rate any ==ride== & ==driver==
## Admin Controls
- Metrics such as number of rides, active users
- View all registered taxis
- View all passengers


