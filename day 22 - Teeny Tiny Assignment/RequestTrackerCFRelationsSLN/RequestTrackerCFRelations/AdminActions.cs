using EmployeeTrackerBL;
using Models;

namespace RequestTrackerCFRelations
{
    internal class AdminActions
    {
        private readonly Employee _authUser;
        private readonly IUserRequestBl _userRequestBL;

        public AdminActions(Employee authUser)
        {
            _authUser = authUser;
            _userRequestBL = new UserRequestBl();
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


        public async void RaiseRequest()
        { 
            var requests = await _userRequestBL.GetAllRequestForUser(_authUser);

            foreach (var request in requests)
            {
                Console.WriteLine(request);
            }

        }
    }
}
