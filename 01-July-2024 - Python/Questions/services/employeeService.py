

from utils.file_utils import create_pdf_from_array
from repo.employeeDb import EmployeeRepository
import pandas as pd

class EmployeeService:
    def __init__(self, employeeRepository: EmployeeRepository):
        self.employeeRepository = employeeRepository

    def getEmployee(self, employeeId):
        return self.employeeRepository.get(employeeId)

    def getEmployees(self):
        return self.employeeRepository.getAll()

    def addEmployee(self, employee):
        return self.employeeRepository.add(employee)

    def updateEmployee(self, employee):
        return self.employeeRepository.update(employee)

    def deleteEmployee(self, employeeId):
        return self.employeeRepository.delete(employeeId)
    
    def storeEmployees(self, filetype):
        df = pd.DataFrame([vars(e) for e in self.employeeRepository.getAll()])
        if(filetype == 'csv'):
            df.to_csv('output/employees.csv', index=False)
        elif(filetype == 'xlsx'):
            df.to_excel('output/employees.xlsx', index=False)
        elif(filetype == 'json'):
            df.to_json('output/employees.json')
        elif(filetype == 'pdf'):
            create_pdf_from_array(df, 'output/employees.pdf')
        else:
            raise ValueError('Invalid file type')