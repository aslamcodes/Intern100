# Day 7: April 17 Update
## Morning Session
- Architecture of an Application
- Operator Overloading
- C# Collections
- Introduced to Data access layer
- Repository Design Patterns
## Evening Session
- Created a simple Doctor Patient Appointment management system with the Repository Design pattern.
## Self Learning
- Will update before tonight, after learning something
- Planning to solidify Dependency injection with .NET, Continue Learning Angular and kickstart docker
# Notes
### Architecture
![[Pasted image 20240417094927.png]]
### Checking equality with Equals
![[Pasted image 20240417101124.png]]
### Operator Overloading
It'll be a `static` overloading
![[Pasted image 20240417100906.png]]
Goes like this
```c#
public static bool operator==(Object a, Object b) {
	return a.Id == b.Id;
}

public static bool operator!=(Object a, Object b) {
	return a.Id != b.Id
}
```
### IEquitable
![[Pasted image 20240417102259.png]]
![[Pasted image 20240417102333.png]]
### How to choose between Overriding Equals and Operator Overloading?

### Collections
Instead of this
```c#
	int[] numbers = {};
	// or
	int[] numbers = new int[3] {};
	// you cant do this, index out of rangeo
	// 
	numbers[3] = 100
```
#### To add a element 💀
![[Pasted image 20240417103611.png]]
#### Here's Collections
```c#
using System.Collections;
ArrayList List = new ArrayList();
List.Add(100);
List.Add("Hello");
List.Add(23);
List.Add(new Employee()) //💀
List.Count; //4
List[3] // Employe
```
#### Enumeration
![[Pasted image 20240417105331.png]]
- Look into the interfaces of List
- `MoveNext()`, `current`
### Data Access Layer
- Add a Class Library
- name it with suffix of DAL (RequestTrackerDALLibrary)
- We are going to use Collections
## Repository Design Patterns
1. Think about all the interactions and come up with an Interface
2. And then implement interface GET, GETALL, UPDATE, ADD, DELETE (repository style
![[Pasted image 20240417114904.png]]
**Generic one**
![[Pasted image 20240417115329.png]]
> [!NOTE] Readonly memory is fastest memory, Read

![[Pasted image 20240417120713.png]]
> [!NOTE] Always Override the Equals() function of any Model
