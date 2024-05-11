using Models;

namespace EmployeeTrackerBL
{
    internal interface IEmployeeAuthBL
    {
        public Task<Employee> Login(Employee employee);
        public Task<Employee> Register(Employee employee);
    }
}
