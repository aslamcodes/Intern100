Employee e = new Employee();
this line allocates memory in heap
reference to the heap will be stored in stack
e is not the object, it holds the reference to the object
once e's reference was null, the memory in heap will be garbage collected

# Class in C\#
- By default anything in the class is private
## Access Specifiers
1. Public - everywhere
3. Private - only inside the class
4. Protected - Only inherited classes
5. internal - Inside the same namespace
6. Protected Internal 
7. Private protectefd

- Put the class that models object in models folder

## Assembly
![[Pasted image 20240412101812.png]]![[Pasted image 20240412102656.png]]
### C-sharp way
![[Pasted image 20240412102859.png]]
![[Pasted image 20240412102955.png]]
![[Pasted image 20240412103038.png]]
it means private variable with getter and setter

If you wanted any logic
	![[Pasted image 20240412103803.png]]![[xx]]
![[Pasted image 20240412114542.png]]
First chained constructor will be called and then the new constructor 

### Internal Documentation
![[Pasted image 20240412115745.png]]