---
Date: 2024-05-13
tags:
  - webapi
  - REST
---
# Summary
# Notes
## Focus on Resource than Method?
- Method names gets subjective
- But when we put the focus on the resource it is clear
- RESTFull service puts focus on the Resource rather than the methods
- ReST - Representational State Transfer
- The methods are very general, in fact the verbs we use from are HTTP verb (GET, PUT, POST, DELETE)
- There will be a resource and a verb
- The request translates to resource
## ASP.net core Architecture
- Between client and server there stands a pipeline/filters that consist several stages of checking
- The checking can be authorization check, media type fit, and so on 
- it also has a routing table
- it is self sufficient to host itself
- ![[Pasted image 20240513120503.png]]
## Action
- Create a new project
- Select Web API category
- GO for ASP.NET core API
### Checking
- Select auth type to be `None`
- uncheck HTTPS configuration
- Enable Swagger OpenAPI support, meaning the assemble is referenced
- Check use controllers
### The Project
- After project has been created, you'll see the structure to be different
- A Sample model called weather forecast is created
- There's a folder called controllers and a file in it
- You'll see appsetting.json
- We have the properties, with a file called lauchSettings.json, it is something that states what to do when executed
	- You can see IIS and YourNameAPI (local api)
	- you can see swagger also under profiles
- The `builder.AddContollers()` will create the the response schema
### How does it know the controllers?
- Only the classes which inherits from ControllerBaseClass will be qualified for the controllers
### Swagger
![[Pasted image 20240513122650.png]]
## Pipeline config
![[Pasted image 20240513123101.png]]
### Where is the IsDevelopement gets from,
from launchSettings.json
