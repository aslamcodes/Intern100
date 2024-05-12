using EmployeeTrackerBL;
using Models;

namespace RequestTrackerCFRelations
{
    internal class Program
    {
        private Employee? _authUser { get; set; }
        private readonly EmployeeAuthBL employeeAuthBL;

        Program()
        {
            employeeAuthBL = new EmployeeAuthBL();
        }
        public async void Login()
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

            _authUser = em;
        }
        public void Logout()
        {
            _authUser = null;
        }

        public async void Register()
        {
            Console.WriteLine("Enter your Name ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter your Password: ");
            var password = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("");

            var employee = new Employee()   {
                Password = password,
                Role = "Employee",
                Name = name,
            };

            var registeredEmployee = await employeeAuthBL.Register(employee);

            _authUser = registeredEmployee;   
        }

        void UserMenu(ref int choice)
        {
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View My Requests");
            Console.WriteLine("3. View My Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Logout");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            UserActions(ref choice);
        }

        void UserActions(ref int choice)
        {
            if (_authUser == null)
            {
                return;
            }

            //TODO: Implement User actions
            var userActions = new UserActions(_authUser);

            switch (choice)
            {
                case 1:
                    userActions.RaiseRequest();
                    break;
                case 2:
                    userActions.ViewUserRequests();
                    break;
                case 3:
                    userActions.ViewUserSolutions();
                    break;
                case 4:
                    userActions.ViewUserFeedbacks();
                    break;
                case 5:
                    Logout();
                    break;
            }

        }

        void AdminMenu(ref int choice)
        {

            Console.WriteLine("1. Raise Request");

            Console.WriteLine("2. View Request Status(All Requests)");
            Console.WriteLine("3. View Solutions(All Solutions)");

            Console.WriteLine("4. Give Feedback for Solutions for your Request");
            Console.WriteLine("5. Provide Solution");
            Console.WriteLine("6. Mark Request as Closed");

            Console.WriteLine("7. Logout");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            AdminActions(ref choice);
        }

        void AdminActions(ref int choice)
        {
            if (_authUser == null)
            {
                return;
            }

            //TODO: Implement Admin Actions
            var adminActions = new AdminActions(_authUser);
            switch (choice)
            {
                case 1:
                    adminActions.RaiseRequest();
                    break;
                case 2:
                    adminActions.ViewAllRequests();
                    break;
                case 3:
                    adminActions.ViewAllSolutions();
                    break;
                case 4:
                    adminActions.GiveFeedback();
                    break;
                case 5:
                    adminActions.ProvideSolution();
                    break;
                case 6:
                    adminActions.CloseRequest();
                    break;
                case 7:
                    Logout();
                    break;
            }
        }

        void DefaultMenu(ref int choice)
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("-1. Exit");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            DefaultActions(ref choice);
        }

        void DefaultActions(ref int choice)
        {
            switch (choice)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                case -1:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        /// <summary>
        /// Home Menu of the Application
        /// </summary>
        void HomeMenu()
        {

            int choice = 0;

            while (choice != -1)
            {

                if (_authUser != null)
                {
                    if (_authUser.Role == "Employee")
                    {
                        UserMenu(ref choice);
                    }
                    else if (_authUser.Role == "Admin")
                    {
                        AdminMenu(ref choice);
                    }
                }

                else
                {
                    Console.WriteLine("Welcome to Presidio's Employee Request Tracker");
                    DefaultMenu(ref choice);
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }
        static void Main(string[] args)
        {
            new Program().HomeMenu();
        }
    }
}
