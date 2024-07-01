import datetime
import re
from models.Employee import Employee
import os
import subprocess

def get_employee_from_console(): 
    name = input("Enter your name: ")

    while not all(c.isalpha() or c.isspace() for c in name):
        print("Name should contain only alphabets")
        name = input("Enter your name: ")

    dob = input("Enter your date of birth (YYYY-MM-DD): ")

    while not validate_date(dob):
        print("Date of birth should be in YYYY-MM-DD format")
        dob = input("Enter your date of birth (YYYY-MM-DD): ")

    dob = datetime.date.fromisoformat(dob)
    today = datetime.date.today()
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))

    salary = input("Enter your salary: ")

    while not salary.isdigit():
        print("Salary should be a number")
        salary = input("Enter your salary: ")

    email = input("Enter your email: ")
    
    while not re.match(r'\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,7}\b', email):
        print("Invalid email")
        email = input("Enter your email: ")

    
    

    
    return Employee(name, dob, age, salary, email)
    
def validate_date(date):
    try:
        datetime.date.fromisoformat(date)
        return True
    except ValueError:
        return False
    

def clear():
    if os.name in ('nt','dos'):
        try: 
            subprocess.call("cls")
        except Exception:
            print("\n") * 120
            return

    elif os.name in ('linux','osx','posix'):
        try:
            subprocess.call("clear")
        except Exception:
            print("\n") * 120
            return

    else:
        for i in range(120):
            print("\n")