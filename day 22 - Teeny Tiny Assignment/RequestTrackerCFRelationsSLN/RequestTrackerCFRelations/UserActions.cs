using EmployeeTrackerBL;
using Models;

namespace RequestTrackerCFRelations
{
    internal class UserActions
    {
        private readonly Employee _authUser;
        private readonly IUserRequestBl _userRequestBL;
        private readonly IFeedbackBl _feedbackBL;
        private readonly IRequestSolutionBl _requestSolutionBl;

        public UserActions(Employee authUser)
        {
            _authUser = authUser;
            _userRequestBL = new UserRequestBl();
            _feedbackBL = new FeedbackBL();
            _requestSolutionBl = new RequestSolutionBl();
        }

        public async Task ViewUserRequests()
        {
            var requests = await _userRequestBL.GetAllRequestForUser(_authUser);

            foreach (var request in requests)
            {
                Console.WriteLine(request);
            }

        }

        public async Task ViewUserSolutions()
        {
            foreach (var solution in await _requestSolutionBl.GetAllSolutionsForUser(_authUser))
            {
                Console.WriteLine(solution);

            }
        }

        public void ViewUserFeedbacks(Employee employee)
        {
            _feedbackBL.GetAllFeedbacksForUser(employee);

        }

        public async Task RaiseRequest()
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

        public async Task ViewAllRequests()
        {
            var requests = await _requestSolutionBl.GetAllSolutions();

            if (requests.Count == 0)
            {
                Console.WriteLine("No requests found");
            }

            requests.ForEach(Console.WriteLine);
        }

        public async Task MarkRequestClosed()
        {
            if (_authUser.Role != "Admin") return;

            Console.WriteLine("Enter Request ID");

            var requestId = Convert.ToInt32(Console.ReadLine());

            Request? request = await _userRequestBL.GetRequestById(requestId);

            if (request == null)
            {
                Console.Write("Could not find request");
                return;
            }

            await _userRequestBL.MarkRequestClosed(request);
        }

        public async Task ViewAllSolutions()
        {
            var solutions = await _requestSolutionBl.GetAllSolutions();

            foreach (RequestSolution solution in solutions)
            {
                Console.WriteLine(solution);
            }

        }

        public async Task ProvideSolution()
        {
            Console.WriteLine("Enter Request Id");
            var requestId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Solution");
            var solutionText = Console.ReadLine() ?? string.Empty;

            var solution = new RequestSolution()
            {
                SolutionMessage = solutionText,
                PostedDate = new DateTime(),
                RequestNumber = requestId,
                SolutionPostedBy = _authUser.Id,
                isAccepted = false,
            };

            await _requestSolutionBl.ProvideSolution(solution);
        }

        public async Task GiveFeedback()
        {
            var requests = await _userRequestBL.GetAllRequestForUser(_authUser);

            foreach (var request in requests)
            {
                Console.WriteLine(request);
            }


            Console.WriteLine("Enter Request ID");
            var requestId = Convert.ToInt32(Console.ReadLine());

            (await _requestSolutionBl.GetAllSolutions()).Where(s => s.RequestNumber == requestId).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Enter Solution Number");
            var solutionNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your feedback");
            var feedbackText = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter your rating");
            var rating = Convert.ToInt32(Console.ReadLine());

            var feedback = new Feedback()
            {
                FeedbackMessage = feedbackText,
                SolutionId = solutionNumber,
                PostedDate = new DateTime(),
                Rating = rating,
            };

            await _feedbackBL.AddFeedback(feedback);
        }
    }
}
