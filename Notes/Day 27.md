---
Date: 2024-05-17
tags:
  - "#csharp"
  - "#webapi"
  - aspnet
  - selflearning
---
# Role based authorization
## Steps I took
- Add User Role
```csharp
    #region Roles
    builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    #endregion
```
- Define Role in UserModel
```csharp
        public required string Role { get; set; }
```
- In the Token Claims
```csharp
   var claims = new List<Claim>(){
       new("uid",user.Id.ToString()),
       new(ClaimTypes.Role, user.Role.ToString())
   };
```
- In the Register method
```csharp

                var user = new User()
                {
                    Email = userRegisterDTO.Email,
                    Name = userRegisterDTO.Name,
                    PasswordHashKey = hMACSHA.Key,
                    Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password)),
                    Role = UserRoleEnum.User.ToString()
                };

                user = await userRepository.Add(user);
```
- This makes the Authorization done