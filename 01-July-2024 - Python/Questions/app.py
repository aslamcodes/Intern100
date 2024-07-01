from utils.console_utils import clear, get_employee_from_console
from repo.employeeDb import EmployeeRepository
from services.employeeService import EmployeeService

class App:
      
    def __init__(self, employeeService: EmployeeService):
        self.employees = []
        self.employeeService: EmployeeService = employeeService
  
    def print_menu(self):
        print('1. Add Employee')
        print('2. List Employees')
        print('3. Save Employees to File') 
        print('4. Bulk Import (CSV, XLSX, JSON)') 
        print('5. Exit')

        choice = int(input('Enter your choice: '))

        if choice == 1:
            try:
                self.employeeService.addEmployee(get_employee_from_console())
            except ValueError as e:
                print(e)

        elif choice == 2:
            for employee in self.employeeService.getEmployees():
                print(employee)

        elif choice == 3:
            try:
                fileType = input('Enter file type: (csv, xlsx, json, pdf)')
                self.employeeService.storeEmployees(fileType)
            except Exception as e:
                print(e)

        elif choice == 4:
            print("Service not available at the moment ;)")

        elif choice == 5:
            exit()

        else:
            print('Invalid choice')
    
    def start(self):
        while True:
            print("\n\n")
            self.print_menu()
    

if __name__ == '__main__':
    service = EmployeeService(EmployeeRepository())
    app = App(service)
    app.start()
    