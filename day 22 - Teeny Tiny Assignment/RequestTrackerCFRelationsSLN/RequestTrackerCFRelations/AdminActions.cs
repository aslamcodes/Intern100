using Models;

namespace RequestTrackerCFRelations
{
    internal class AdminActions
    {
        private readonly Employee _authUser;

        public AdminActions(Employee authUser)
        {
            _authUser = authUser;
        }

        public void RaiseRequest()
        {
            Console.WriteLine("Raising Request");

        }

        public void AcceptSolutionForYourRequest()
        {

        }

        /// <summary>
        /// View all requests with its status
        /// </summary>
        public void ViewAllRequests()
        {
            Console.WriteLine("Viewing All Requests");

        }

        public void ViewAllSolutions()
        {
            Console.WriteLine("Viewing All Solutions");

        }

        public void ViewMyFeedbacks()
        {
            Console.WriteLine("Viewing All Feedbacks");

        }

        public void ProvideSolution()
        {
            Console.WriteLine("Giving Solution");

        }

        public void GiveFeedback()
        {
            Console.WriteLine("Giving Feedback");

        }

        public void CloseRequest()
        {
            Console.WriteLine("Closing Request");

        }



    }
}
