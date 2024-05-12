using EmployeeTrackerBL;
using Models;

namespace RequestTrackerCFRelations
{
    internal class UserActions
    {
        private readonly Employee _authUser;
        private readonly IUserRequestBl _userRequestBL;
        public UserActions(Employee authUser)
        {
            _authUser = authUser;
            _userRequestBL = new UserRequestBl();
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

        public async void RaiseRequest()
        {
            Console.WriteLine("Enter your request");
            var requestText = Console.ReadLine() ?? string.Empty;

            var request = new Request()
            {
                RequestMessage = requestText,
                RequestDate = new DateTime(),
                RequestStatus = "Open",
                RequestRaisedBy = _authUser.Id,
                RequestClosedBy = null
                
            };
            await _userRequestBL.RaiseRequest(request);
        }

    }
}
