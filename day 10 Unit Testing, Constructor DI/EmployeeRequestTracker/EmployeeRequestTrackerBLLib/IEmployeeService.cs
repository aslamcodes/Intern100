using EmployeeRequestTrackerModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLib
{
    public interface IEmployeeService
    {
        int AddEmployee(Employee employee);

        Employee GetEmployeeById(int id);

        List<Employee> GetAllEmployee();

        Employee ChangeEmployeeName(int employeeID, string employeeNewName);

        Employee DeleteEmployee(int employeeID);

       
    }
}
