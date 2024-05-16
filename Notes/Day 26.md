---
Date: 2024-05-16
---
# Notes

# Transcribe
## JWT
- Creates a `LoginReturnDTO`, in it are id and token. ![[Pasted image 20240516103603.png]]
- Modify the controller to return the DTO, using a Mapper class
- We need to create tokens to map the employee ![[Pasted image 20240516104022.png]]
- Creates a separate token service, for that Installs `JWTBearer` nuGet extension (Whoever bears a token is authenticated)![[Pasted image 20240516104142.png]]
- Creates a service ![[Pasted image 20240516104358.png]]
- Implements the service, with injection of configuration, which is the secret key ![[Pasted image 20240516104720.png]]
- ==What is this== ![[Pasted image 20240516104839.png]]
- Creates a Claims which is called payload in jwt  ![[Pasted image 20240516105436.png]]
- Creates the signing algorithm ![[Pasted image 20240516105525.png]]
- Creates the token![[Pasted image 20240516105847.png]]
- assigns the token as a string![[Pasted image 20240516105934.png]]
## JWT in Token Service
- Takes token service as injection
- in the mapping class again ![[Pasted image 20240516110106.png]]
- Provides the token service injection
## User Controller 
- Returns the loginDTO back 
## JWT Authentication
- To add the authentication filter`builder.services.AddAuthentication`
- We can customize it, for that Ig we need JWTBearer
```csharp 
builder.services.AddAuthenticaiton(JwtBearerDefaults.AuthenticationScheme)

.AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModels.Tokens.TokenValidationParameters() {
	ValidateIssuer = false;
	ValidateAudience = false;
	ValidateIssuerSigningKey = true;
	IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
}) 
```

And then you have to say
```csharp
app.useAuthentication();
```
## How to use all of this in controller
![[Pasted image 20240516124750.png]]


# Summary
## Learning
- Learnt authentication in ASP.NET with JWT tokens
- Learnt how to set AUTH filters 
## Lab
- Watched Codeshowcase
- Solved a Hackerrank problem
- And worked on the yesterday's assingment
## Self-Learning
- I've saved some articles to read regarding SQL, C#. So going to revisit them after finishing the assigments