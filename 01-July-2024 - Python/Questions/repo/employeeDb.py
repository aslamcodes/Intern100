import models.Employee

class EmployeeRepository:
    def __init__(self):
        self.employees = []
    
    def add(self, employee: models.Employee.Employee):
        self.employees.append(employee)
    
    def getAll(self):
        return self.employees
    
    def get(self, e: models.Employee.Employee): 
        for employee in self.employees:
            if employee.id == e.id:
                return employee
        return None
    
    def delete(self, id: int):
        for employee in self.employees:
            if employee.id == id:
                self.employees.remove(employee)
                return True
        return False
    
    def update(self, e: models.Employee.Employee):
        for employee in self.employees:
            if employee.id == e.id:
                employee.name = e.name
                employee.dob = e.dob
                employee.salary = e.salary
                return True
        return False
    

    
    