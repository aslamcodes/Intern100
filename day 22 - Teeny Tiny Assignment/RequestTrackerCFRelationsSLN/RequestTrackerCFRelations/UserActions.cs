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

        public async void ViewUserRequests()
        {
          var requests = await _userRequestBL.GetAllRequestForUser(_authUser);

          foreach (var request in requests)
          {
              Console.WriteLine(request);
          }
          
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

        public async void ViewRequestStatus()
        {
          

            Console.WriteLine("Enter Request ID");
            
            var requestId = Convert.ToInt32(Console.ReadLine());

            Request? request = await _userRequestBL.GetRequestById(requestId);
            
            if(request == null)
            {
                Console.Write("Could not find request");
                return;
            }
            
            Console.WriteLine($"Request Status: {request.RequestStatus}");
        }

        public async void MarkRequestClosed()
        {
            if (_authUser.Role != "Admin") return;
            
            Console.WriteLine("Enter Request ID");
            
            var requestId = Convert.ToInt32(Console.ReadLine());

            Request? request = await _userRequestBL.GetRequestById(requestId);
            
            if(request == null)
            {
                Console.Write("Could not find request");
                return; 
            }
            
            await _userRequestBL.MarkRequestClosed(request);
        }
    }
}
