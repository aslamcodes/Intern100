#### Summary
###### Morning
- Learnt how to associate different classes 
- Revisited OOPS concepts (Inheritance, Overriding, Constructor Chaining, Polymorphism, Code Reusability)
- Got Introduced to interfaces in C#
###### Afternoon Session
- Solved a problem comprising of everything we've learned by Morning, which included interfaces and Polymorphism and much more https://github.com/aslamcodes/Intern100/tree/main/day%206/EmployeeBenefits
###### Self Learning
- Im going to practice using Docker
- Continue learning Angular and to
- Get started with Astro
  
>[!NOTE] Default access level of class in C# is internal
# Association
```c#
// Proper Way
class Employee {
	Department dept {get; set;}
}
```

```c#
// Improper way
class Employee {
	public int EmployeeID {get; set;}

	public Employee getEmployee (int id) {
		return Employees.find(id);
	}
}
```
- Having class as a property in another class
- Department object in Employee
- Department can have Employee[ ] array
- one to many
- one Dept to Many emps
# OOPS
- Class ✅
- Object ✅
- Encapsulation ✅
- Inheritance  ✅
- Overriding ✅
# Encapsulation!!!? (Abstraction) 
- It means Hiding data
- The employee class have a seperate logic to calculate logic
- but the program that uses it dont know about it
- We dont know how a phone works, we dial and call it calls, we dont care about its implementations
# Inheritance
```c#
public class ContractEmployee: Employee {
 public double WagesPerDay {get; set;}
}
```

## Single
One base class -> One child class
## Hierarchichal
One base class -> Many children
## Multilevel
One base class -> child -> child

> [!NOTE] Base class of all classes is a class called object

# Chaining of Constructor in Inheritance
- First the base class's Constructor is called and then the inherited class
- Like in 12th standard Python OOPS
## Invoking the base class's parameterized constructor
```c#
ContractEmployee(...args):base(...args)
```
it'll find the right overload
# Overriding
- In order to override a method from base class
- Mark the base class's method with `virtual`
- Mark the child class's method with `override`
- This is how we can do overriding
>[!NOTE] Overriding is runtime polymorphism, since it decides which one to call
- Do it in a way that you take the most common things and generalize them and for special things put them into child classes
- Here base class is `Employee` and child classes are `Permanent` and `Contract` Employees
# Interface
- To abstract an object
- Doesn't provide implementation details but provides a set of functionalities that class should support.
- **Even if you pass the employee object with a interface, it only passes the interfaced behavior, not like TypeScript**
## Adding a interface
- Same way by adding a class file in the solution pane
- Prefix it by with `I`
```c#
public class A : Iinterface {
// Implement the interface in the class
}
```
# Self Learning
## Top Level Statements in C\#
- Instead of writing a program class and main method, you can just omit it and go blank and start coding
- The compiler will generate a class and create a method similar to that of main. 
- But the catch is there should be only one Top level file should be in the application
- Even`Main()` function is explicitly defined, compiler will ignore it and just warn about it

