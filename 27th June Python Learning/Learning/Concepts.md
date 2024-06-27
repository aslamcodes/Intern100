# Initial Setup

- Download the python installer from [Python's official website](https://www.python.org/downloads/) and go through wizard to get python installed.

# IDE

- Python comes with IDLE stands for "Integrated Development and Learning Environment", a minimal IDE to get started and to develop with Python
- VSCode can be configured for python programming with supporting extensions
- Jetbrains's Pycharm is also a great choice with packaged great futures

## VSCODE

- Vscode can be a lightweight option for python with necessary extensions.
- Refer - https://code.visualstudio.com/docs/languages/python

# Syntax

### Indentation

- Where in other programming languages the indentation in code is for readability only, the indentation in Python is very important.
- Python uses indentation to indicate a block of code.

```python
def function(inp):
	# Code
	# Inner block of the function
# Outter of the function
```

### Variables

```text
variablename = value
```

For Example,

```python
a = 10
b = "hello"
```

# Data Types

Refer - https://docs.python.org/3/reference/datamodel.html#objects-values-and-types

> "*Objects* are Python’s abstraction for data. All data in a Python program is represented by objects or by relations between objects."

> Every object has an **identity, a type and a value.**

```python
x = None
y = None
print(x.id()) # Prints the Id
print(x.is(y)) # Uses the Id to check and its
```

### None

```python
v = None
```

It is used to signify the absence of a value in many situations, e.g., it is returned from functions that don’t explicitly return anything.

```python
def notReturns():
    pass

print(notReturns()) # Will Print None
```

Its truth value is false.

```python
if(not None) {
	print("This will be executed")
}
```

### Ellipsis

https://realpython.com/python-ellipsis/

```python
...
```

- Can be used as a placeholder

### numbers.Integral

> Integral is an abstract definition of what integral numbers must provide. int is a concrete implementation of integral numbers

it has two types

- Integers (int)
- Booleans (bool)

#### Integers

- Numbers of unlimited range

#### Booleans

> The Boolean type is a subtype of the integer type, and Boolean values behave like the values 0 and 1, respectively, in almost all contexts, the exception being that when converted to a string, the strings `"False"` or `"True"` are returned, respectively.

### numbers.Complex

> The real and imaginary parts of a complex number `z` can be retrieved through the read-only attributes `z.real` and `z.imag`.

```python
complex(real= 1, imag=2) # 1+2j
complex("1+3j") #1+3j
```

### numbers.Real

```python
float("-1.23")
```

Refer more at https://docs.python.org/3/reference/datamodel.html#objects-values-and-types

# Variables & Operators

# Control Flow

## if Statement

```python
if(expression):
	# Truthy suite
else:
	# False suite
```

## For Statement

- Rather than iterating over arithmetic progression of numbers, python's for iterates over any sequence

```python
for i in seq:
	# iteration body
else:
	# else suite
```

- When the iterator is exhausted, the suite in the `else` clause, if present, is executed, and the loop terminates.
- `break` and `continue` can be used to have controls over the loop - `break` - Breaks the loop - `continue` - Continues the execution
  **Examples**

```python
fruits = ["apple", "banana", "cherry"]
for fruit in fruits:
	print(fruit)
```

\

```python
for i in range(5):
	print(i)
```

```python
fruits = ["apple", "banana", "cherry"]
for i, fruit in enumerate(fruits):
	print(f"Index: {i}, Fruit: {fruit}")
```

```python
name = "Alice" for char in name:
	print(char)
```

# Input & Output

[Refer](https://docs.python.org/3/tutorial/inputoutput.html)

## Output

> "There are several ways to present the output of a program; data can be printed in a human-readable form, or written to a file for future use"

### print()

- Prints the [given data to stdout](https://docs.python.org/3/library/functions.html#print)

#### Formatted String literals

```python
f'Results of the {year} {event}'
```

### write()

```python
with open('outputfile', encoding="utf-8") as f:
	f.write("Hello world")
```

# Methods, Parameters and Returning

> "Function objects are created by function definitions. The only operation on a function object is to call it: func(argument-list). There are really two flavors of function objects: built-in functions and user-defined functions. Both support the same operation (to call the function), but the implementation is different, hence the different object types."

Examples

```python
def calculate_area(length, width):
  return length * width

area = calculate_area(5, 3)  # Calling the user-defined function
```

The parameters are length and width, return statement is used to return any value from the fuction after its execution

```python
print("Hello, world!")  #  Calling the built-in function
```

# List & Indexing

> "Built in Python _Sequence_"

> [!info] List is not Linked List, List more of a array representaion in other languages

```python
sample = [1, "Apple", 2.3, complex("2+1j")]
```

## Indexing

Like all other sequence types, lists can be indexed with [ ]
For example

```python
sample = [1, "Apple", 2.3, complex("2+1j")]
sample[0] #1
sample[-1].imag #1.0
```
