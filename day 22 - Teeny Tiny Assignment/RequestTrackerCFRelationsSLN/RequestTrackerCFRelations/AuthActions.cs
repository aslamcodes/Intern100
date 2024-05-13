using EmployeeTrackerBL;
using Models;
using RequestTrackerCFRelations.Exceptions;
namespace RequestTrackerCFRelations
{
    public class AuthActions
    {
        private IEmployeeAuthBl employeeAuthBL;

        public AuthActions()
        {
            employeeAuthBL = new EmployeeAuthBl();
        }
        public async Task<Employee> Login()
        {
            try
            {
                Console.Write("Enter your ID ");
                var id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your Password: ");
                var password = Console.ReadLine();

                var em = await employeeAuthBL.Login(new Employee()
                {
                    Id = id,
                    Password = password
                });

                return em;
            }
            catch (EntityNotFoundException e)
            {
                throw new AuthException(e.Message);
            }
            catch (InvalidPasswordException e)
            {
                throw new AuthException(e.Message);
            }


        }

        public async Task<Employee> Register()
        {
            try
            {
                Console.WriteLine("Enter your Name ");
                var name = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter your Password: ");
                var password = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("");

                var employee = new Employee()
                {
                    Password = password,
                    Role = "Employee",
                    Name = name,
                };

                var registeredEmployee = await employeeAuthBL.Register(employee);

                return registeredEmployee;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
