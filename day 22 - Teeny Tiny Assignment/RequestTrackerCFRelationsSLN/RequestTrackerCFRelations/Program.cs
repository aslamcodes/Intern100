using Models;
using RequestTrackerCFRelations.Exceptions;

namespace RequestTrackerCFRelations
{
    internal class Program
    {
        private Employee? _authUser { get; set; }

        private bool _isProgramRunning = true;

        void ExitProgram()
        {
            Console.WriteLine("Exiting...");
            _isProgramRunning = false;
        }

        async Task UserMenu()
        {
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View My Requests");
            Console.WriteLine("3. View My Solutions");
            Console.WriteLine("4. Give Feedback for Solutions given to your Requests");
            Console.WriteLine("5. Respond to Solution");

            if (_authUser.Role == "Admin")
            {
                Console.WriteLine("6. View all Requests");
                Console.WriteLine("7. View all Solution");
                Console.WriteLine("8. Provide Solution");
                Console.WriteLine("9. Mark Request as Closed");
                Console.WriteLine("10. View your Feedbacks");
            }

            Console.WriteLine("0. Logout");
            Console.WriteLine("-1. Exit");

            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            var userActions = new UserActions(_authUser);

            switch (choice)
            {
                case 1:
                    await userActions.RaiseRequest();
                    break;
                case 2:
                    await userActions.ViewUserRequests();
                    break;
                case 3:
                    await userActions.ViewUserSolutions();
                    break;
                case 4:
                    await userActions.GiveFeedback();
                    break;
                case 5:
                    await userActions.RespondToSolution();
                    break;
                case 6:
                    await userActions.ViewAllRequests();
                    break;
                case 7:
                    await userActions.ViewAllSolutions();
                    break;
                case 8:
                    await userActions.ProvideSolution();
                    break;
                case 9:
                    await userActions.MarkRequestClosed();
                    break;
                case 10:
                    await userActions.ViewYourFeedbacks();
                    break;
                case -1:
                    ExitProgram();
                    break;
                case 0:
                    _authUser = null;
                    break;
            }
        }

        async Task WelcomeMenu()
        {
            AuthActions authActions = new();
            try
            {
                Console.WriteLine("Welcome to Presidio's Employee Request Tracker");

                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("-1. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try
                        {
                            _authUser = await authActions.Login();
                        }
                        catch (AuthException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            _authUser = await authActions.Register();
                        }
                        catch (AuthException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case -1:
                        ExitProgram();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Home Menu of the Application
        /// </summary>
        async Task HomeMenu()
        {

            while (_isProgramRunning)
            {
                if (_authUser == null) await WelcomeMenu();
                else await UserMenu();

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }

        }
        static async Task Main(string[] args)
        {
            await new Program().HomeMenu();
        }
    }
}
