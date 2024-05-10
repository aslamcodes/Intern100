using EmployeeRequestTrackerDALLib;
using EmployeeRequestTrackerModelLib;

namespace EmployeeRequestTrackerBLLib
{
    public class EmployeeBL : IEmployeeService
    {

        EmployeeRepository employeeRepository;

        public EmployeeBL()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        public int AddEmployee(Employee employee)
        {
            var e = employeeRepository.Add(employee);

            if (e != null) return e.Id;

            throw new DuplicateEmployeeException();
        }

        public Employee ChangeEmployeeName(int employeeID, string employeeNewName)
        {
            var employee = GetEmployeeById(employeeID);
            employee.Name = employeeNewName;
            return employee;
        }

        public Employee DeleteEmployee(int employeeID)
        {

            var result = employeeRepository.Delete(employeeID);

            if (result == null) throw new EmployeeNotFoundException();

            return result;
        }

        public List<Employee> GetAllEmployee()
        {
            var result = employeeRepository.GetAll();

            return result;
        }

        public Employee GetEmployeeById(int id)
        {
            var result = employeeRepository.Get(id);

            if (result == null)
            {
                throw new EmployeeNotFoundException();
            }

            return result;
        }
    }
}
