---
Date: 2024-05-10
tags:
  - csharp
---
# Summary
## Morning
- Designed & Practice relationship between entities in code-first approach and migrated to database
- Designed few entities for the project by ourselves
- Lazy Loading in entity framework
## Evening
# Notes
## Rough
- Request Solution, one request has multiple solution, provided by admins only
- It is when the employee accepts any of the solution, that is when the request is closed and request closed by is filled with the post holder
- Think - Request Solution Class
- EF doesnt allow you to load the child classes, it but it is us we have to do it manually ![[Pasted image 20240510114437.png]]
- Loading them manually
```csharp
var employees = _context.Employees.Include(e=>e.RequestsRaised).toListAsync();
```
# Questions & Thoughts

## EF

## Questions & Thoughts

### EF

1. **Concern**: Even though I understand things, it feels uncertain if I'll be creating everything from scratch with all relationships correct and no flaws.
   - **Answer**: Create a project by yourself
     - *Suggestion*: Maybe project-based todos
2. **Vague**: The migrations using the `add-migration` acts like a stack datastructure, so upon adding the up  method will be called, and upon poping the migration the down method will be called, my vagueness is in
		1. Let's say, series of ups and downs
			1. m1 (push)
			2. m2 (push)
			3. m3 (push)
			4. pop (m2)
			5. push(m4)
		2. The vagueness is in, what happens now, right after pushing the m4.
		3. My theory is
![[Day 22 2024-05-10 14.13.12.excalidraw]]