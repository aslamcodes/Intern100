using Models;

namespace RequestTrackerCFRelations
{
    internal class UserActions
    {
        private readonly Employee _authUser;

        public UserActions(Employee authUser)
        {
            _authUser = authUser;
        }

        public void ViewUserRequests()
        {
            Console.WriteLine("Viewing User Requests");

        }

        public void ViewUserSolutions()
        {
            Console.WriteLine("Viewing User Solutions");

        }

        public void ViewUserFeedbacks()
        {
            Console.WriteLine("Viewing User Feedbacks");

        }

        public void RaiseRequest()
        {
            Console.WriteLine("Raising Request");

        }

    }
}
