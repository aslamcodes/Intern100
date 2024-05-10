---
Date: 2024-05-09
tags:
  - csharp
  - migration
---
# Summary
## Morning
- Pair programming with Sanjai - Created a ER Diagram for Quiz Application
- Saw codefirst approach on migrating models to classes
- Tutor taught how to create a three tier c# application with codefirst approach to migrate the models to sql database
## Afternoon
- The 3 tier dev session continued
## Evening Plan
- Learn more about EF core

# Notes
## Rough Notes
- Use `Add-Migration init` in the PM console to initaite the migration
- itll create a init file
- always read the init file
- notice that it'll create the foreingn keys
- itll create indexes too
- `Update-database` command to to get the changes to server
- make sure the connection string is good
- `onModelCreating` will be triggered everytime the database is created. #Check-Validate
- What is the challenge,
- Request has raisedby and closed by property
- both referencing the employee table
- when you delete the employee entity it'll delete the the requests too
- using `onDelete(DeleteBehavior.Restrict)` fluent api on model builder will not allow deletion in
- never hard code the connetion string
- after awaiting the save changes the enitity object will have id property
![[Pasted image 20240509143342.png]]
![[Pasted image 20240509122514.png]]

## AI Notes draft
### Migration Process:

1. Initiate Migration:
    
    - Use `Add-Migration init` in the Package Manager Console (PMC).
    - This command initializes a migration and generates an "init" file.
    - Always review the contents of the "init" file.
2. Review Migration File:
    
    - Inspect the generated migration file.
    - Note the creation of foreign keys and indexes.
    - Ensure that the generated code aligns with the intended changes.
3. Apply Changes to Database:
    
    - Execute `Update-Database` command in PMC.
    - This command applies the pending changes to the database.
    - Verify that the connection string is correctly configured.

### Data Model Configuration:

1. `OnModelCreating` Method:
    
    - This method is triggered each time the database is created.
    - Utilize this method for configuring model relationships and behaviors.
    - Ensure to validate and cross-check configurations within this method.
2. Challenge Overview:
    
    - The request entity includes properties for "raised by" and "closed by."
    - Both properties reference the employee table.
    - Deleting an employee entity should also delete associated requests.
3. Handling Deletions:
    
    - Use `onDelete(DeleteBehavior.Restrict)` Fluent API within the model builder.
    - This configuration prevents deletion when a related entity exists.
    - Avoid hardcoding connection strings; utilize configuration files or environment variables.
4. Post-Save Changes:
    
    - After awaiting the SaveChanges operation, the entity object will have an ID property.
    - Use this ID for further operations or reference.