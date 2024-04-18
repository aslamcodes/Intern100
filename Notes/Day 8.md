# Day 8 - April 18th
## Morning
- We were told to self learn today on the topics of *Classes, Structs, Records* and *Polymorphism (specifically methods)* to increase our self learning skills. On top of that, we were told to explain the concepts afternoon, all the 40 people.
## Afternoon
- Learnt Jagged array & Indexer concept in C#
- Exception handling with C#
- Custom exceptions
- Worked on handling business logic, exceptions and DAL layers
## Self Learning
- Concentrate on Angular and Docker, DI with .Net
# Notes
## Polymorphism
- Polymorphism is often referred to as the ***third pillar*** of object-oriented programming, after encapsulation and inheritance
> [!NOTE] At run time, objects of derived class may be treated as objects of base class,

> [!NOTE] In a drawing application, You don't know at compile time which specific types of shapes the user will create.
> The app keeps track of created shapes, here polymorphism can be used

Compile time polymorphism - Method overloading and operator overloading
Run time polymorphism - Method overriding
### Method Overloading
```c#
	public void WriteLine(); 
	public void WriteLine(string value); 
	public void WriteLine(bool value);
```

# Structs
## What?
- Structure is a variable of value type while classes are Reference type variables
- A structure type can't inherit from other class or structure type and it can't be the base of a class. However, a structure type can implement [interfaces](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface).
## Why?
- If you can always send a copy of your variable to other places, you never have to worry about that other place changing the value of your variable underneath you.
- Structures provide better performance when you have small collections of value-types that you want to group together
### Why would someone choose `struct` over `class`?

## How?
### When to use Struct?
- Typically, you use structure types to design small data-centric types that provide little or no behavior
- If you're focused on the behavior of a type, consider defining a [class](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class).
### How to use Struct?
- we can use structure keyword
```c#
public struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public override string ToString() => $"({X}, {Y})";
}
```
# Difference between Class & Structure
✔️ CONSIDER defining a struct instead of a class if instances of the type are small and commonly short-lived or are commonly embedded in other objects.

❌ AVOID defining a struct unless the type has all of the following characteristics:
- It logically represents a single value, similar to primitive types (`int`, `double`, etc.).
- It has an instance size under 16 bytes.
- It is immutable.
- It will not have to be boxed frequently.
# Records
## What?
### What is a Record?
- A record in C# is a class or struct 
- Provides special **syntax and behavior** for working with data models
- Its properties are init-only, you can't change them after initialising.
### What are Boilerplate code it generates
Records generate a lot of boilerplate code automatically, including constructors, equality members (above example), and `with` expression methods.
#### What is `wit
h` expression?
It helps us to perform **non-destructive mutation**
```c#
public record Person(string FirstName, string LastName, string Address);  
  
var person = new Person("Haresh", "Jayabalan", "Melbourne");  
  
var modifedPerson = person with { Address = "Sydney" };
```
## Why?
- To reduce boilerplate code when dealing with Data model objects
- To enforce immutability when working with Data objects
## How?
### When to use Record?
- You want to define a data model that depends on [value equality](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/equality-comparisons#value-equality).
- You want to define a type for which objects are immutable.
- highly effective in scenarios involving **Data Transfer Objects (DTOs), messages, and other analogous data-centric structures**.
## Questions?
### Are Records Immutable?
Yes! They are init only
![[Pasted image 20240418110651.png]]
- 



# Abstract Class
## What?
### What is abstract class?
Abstract classes are only for deriving from it, one cannot create instances for it, it can have declaration and no or less definitions.

Abstract classes act as templates for creating more specific classes. They define a general structure and functionalities (including abstract methods) that concrete subclasses must implement to become usable objects.
# Indexers
## What
### What are they?
- Its a methodology by which we can ==make class look like arrays.==
- Indexers do not have to be indexed by an integer value; it is up to you how to define the specific ==look-up mechanism.==
- Indexers can be **==overloaded==**.
## Why
- Using this, We have ==control over== how the accessors and getters behaves in a **Array like Class.**
## How
- Indexers allow instances of a class or struct to be indexed just like arrays
```C#
using System;

class SampleCollection<T>
{
   // Declare an array to store the data elements.
   private T[] arr = new T[100];

   // Define the indexer to allow client code to use [] notation.
   public T this[int i]
   {
      get { return arr[i]; }
	      set { arr[i] = value; }
   }
}

class Program
{
   static void Main()
   {
      var stringCollection = new SampleCollection<string>();
      stringCollection[0] = "Hello, World";
      Console.WriteLine(stringCollection[0]);
   }
}
// The example displays the following output:
//       Hello, World.
```
# (Archive)Classes, structs, and records in C\#
> [!NOTE] _Encapsulation_ is sometimes referred to as the first pillar or principle of object-oriented programming

> [!NOTE] A class or struct can specify how accessible each of its members is to code outside of the class or struct.

> [!NOTE] Classes (but not structs) support the concept of inheritance.

- Classes may be declared as [abstract](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract), which means that ***one or more of their methods have no implementation***. Although abstract classes cannot be instantiated directly,
##E Record
- We can add the record modifier to a class or struct

### Why Record?
- A record in C# is a class or struct that provides **special syntax and behavior** for working with **data models.**
- When the primary role is to store data.. we use record.
## Value Equality
- For `class` types, two objects are equal if they refer to the same object in memory.
- For `struct` types, two objects are equal if they are of the same type and store the same values.
- For types with the `record` modifier (`record class`, `record struct`, and `readonly record struct`), two objects are equal if they are of the same type and store the same values.
### What are the special syntax and behavior?
### The syntax
- 
### The behaviour
### When to use Record?
- You want to define a data model that depends on [value equality](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/equality-comparisons#value-equality).
- You want to define a type for which objects are immutable.

## Structure
### What?
- Structure is a value type
- Encapsulate data and related functionality
### Why?
Why and When to choose `struct` over a `class`
- whenever we don't need polymorphism
- want to avoid heap allocation and the associated garbage collection overhead.
### How?
- We use `struct` keyword to define a structure type
```c#
public struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public override string ToString() => $"({X}, {Y})";
}
```
## Enum
### Why?
In programming, an enum, or enumeration, is a symbolic name for a set of values that are treated as data types. You can use enums ==to create sets of constants for use with properties and variables==. For example, you can use enums to store values like the days of the week, month days, colors, or deck of cards. Enums can make code easier to read and reduce errors caused by mistyping or transposing number
### How?
```c#
public record Person (int Age, PersonLifeStatus Status)
 {

 }

 public enum PersonLifeStatus
 {
     Dead = 0,
     Living =1,
     Happy = 2,
 }
 public class Program
 {
     static void Main(string[] args)
     {
         Person p = new Person(12, PersonLifeStatus.Dead);
         Person p2 = new Person(12, PersonLifeStatus.Living);
         Person p3 = new Person(20, PersonLifeStatus.Dead);

         Console.WriteLine((PersonLifeStatus)2);        
     }
 }
```


# Exception
- Unexpected things that happens during runtime of the program
# Custom exceptions
- We can tailor our own exception
# Exceptions in Data Pattern
- All the database exceptions should not enter into the buisness login
- In DAL layer, catch all the exceptions and throw them as a custom exception
- in BL should only be visible to the layer