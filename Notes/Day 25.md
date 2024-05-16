---
Date: 2024-05-15
tags:
  - csharp
  - webapi
  - REST
---
# Notes

## Day 25 - Summary
### Morning
- Learnt how to improve documentation in Swagger
- Learn about Regions and its usage
- Learned DTOs and Password's encryption
- Created the Request Tracker Application with new things learned
### Afternoon
- Code showcase, Hackerrank SQL, Worked on the Assignment
### Evening
- Finish the assigment

## Documenting the ReqRes
- We are in need of producing more documentation![[Pasted image 20240515094421.png]]![[Pasted image 20240515094455.png]]![[Pasted image 20240515094502.png]]
## Error Model
- We need to have Error Model that further fine tunes the application![[Pasted image 20240515094637.png]]
- We need to have a error model, it enforces uniformity and also the client developer knows what to expect when there's an error
> Doubt - What is intercepting the error
- We can also ue error response type
![[Pasted image 20240515094925.png]]
![[Pasted image 20240515095040.png]]
## Regions
- It is a good practice to use regions on code to show the parts of code
![[Pasted image 20240515095304.png]]![[Pasted image 20240515095308.png]]
## Transcribes
- Create a user model
-  Two different concepts
	- Password encryption
	- DTOs - Data Transfer Objects
- Creates password field and passwordHashkey for user ![[Pasted image 20240515101025.png]]
- Adds it to DBContext ![[Pasted image 20240515101046.png]]
- Migrates to database
- Implements the user repo![[Pasted image 20240515101549.png]]
- ![[Pasted image 20240515102020.png]]
## DTOs
- ![[Pasted image 20240515103412.png]]
- Creates a UserService to make use of these
- ![[Pasted image 20240515103810.png]]
- IMplements the service & injects![[Pasted image 20240515103932.png]]
- ![[Pasted image 20240515104056.png]]
- Implements Login  ![[Pasted image 20240515105407.png]]
- Maps to DTO![[Pasted image 20240515113859.png]]
- Writes the login controller![[Pasted image 20240515120731.png]]
- Illustration of DTOs
![[Pasted image 20240515120816.jpg]]
- Writes the Register controller ![[Pasted image 20240515120908.png]]