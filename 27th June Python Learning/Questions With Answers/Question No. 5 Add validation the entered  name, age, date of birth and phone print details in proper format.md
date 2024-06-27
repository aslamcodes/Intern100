```python
import datetime

def validate_date(date):
    try:
        datetime.date.fromisoformat(date)
        return True
    except ValueError:
        return False
    
def print_details(): 
    name = input("Enter your name: ")

    while not name.isalpha():
        print("Name should contain only alphabets")
        name = input("Enter your name: ")

    age = input("Enter your age: ")

    while not age.isdigit():
        print("Age should contain only digits")
        age = input("Enter your age: ")

    dob = input("Enter your date of birth (YYYY-MM-DD): ")

    while not validate_date(dob):
        print("Date of birth should be in YYYY-MM-DD format")
        dob = input("Enter your date of birth (YYYY-MM-DD): ")

    
    phone = input("Enter your phone number: ")

    while not phone.isdigit():
        print("Phone number should contain only digits")
        phone = input("Enter your phone number: ")

    
    print('\n')
    print(f"Name: {name}\nAge: {age}\nDate of Birth: {dob}\nPhone: {phone}")

if __name__ == "__main__":
    print_details()
```