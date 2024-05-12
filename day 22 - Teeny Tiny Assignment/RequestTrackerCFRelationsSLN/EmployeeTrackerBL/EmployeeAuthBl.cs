using EmployeeTrackerDAL;
using Models;
using Models.Enums;

namespace EmployeeTrackerBL
{
    public class EmployeeAuthBl
    {
        private readonly IRepository<int, Employee> _repo = new EmployeeRepository(new RequestTrackerContext());

        public async Task<Employee> Login(Employee employee)
        {
            var existingEmployee = await _repo.Get(employee.Id);

            if (existingEmployee == null)
            {
                throw new EntityNotFoundException(EntityEnum.Employee);
            }

            if (!existingEmployee.PasswordCheck(employee.Password))
            {
                throw new InvalidPasswordException();
            }

            return existingEmployee;
        }

        public async Task<Employee> Register(Employee employee)
        {
            var existingEmployee = await _repo.Add(employee);

            if (existingEmployee == null)
            {
                throw new EntityNotCreatedException(EntityEnum.Employee);
            }

            return existingEmployee;
        }
    }

    
}
