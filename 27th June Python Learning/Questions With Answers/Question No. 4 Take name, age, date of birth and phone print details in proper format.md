```python
def print_details(): 
    name = input("Enter your name: ")
    age = input("Enter your age: ")
    dob = input("Enter your date of birth: ")
    phone = input("Enter your phone number: ")
    print('\n')
    print(f"Name: {name}\nAge: {age}\nDate of Birth: {dob}\nPhone: {phone}")

if __name__ == "__main__":
    print_details()
```