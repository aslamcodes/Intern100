using Models;

namespace EmployeeTrackerBL
{
    internal interface IEmployeeAuthBl
    {
        public Task<Employee> Login(Employee employee);
        public Task<Employee> Register(Employee employee);
    }
}
