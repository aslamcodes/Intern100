class Employee: 
    def __init__(self, name, dob, age, salary, email):
        self.name = name
        self.dob = dob
        self.salary = salary
        self.age = age
        self.email = email
    
    def __str__(self):
        return f"{self.name} {self.dob} {self.age} {self.salary} {self.email}"
    
 

    
    