using EmployeeTrackerBL;
using EmployeeTrackerBL.Exceptions;
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
            try
            {
                var requests = await _userRequestBL.GetAllRequestForUser(_authUser);

                foreach (var request in requests)
                {
                    Console.WriteLine(request);
                }
            }
            catch (EntityNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task ViewUserSolutions()
        {
            try
            {
                foreach (var solution in await _requestSolutionBl.GetAllSolutionsForUser(_authUser))
                {
                    Console.WriteLine(solution);

                }

            }
            catch (EntityNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async void ViewUserFeedbacks(Employee employee)
        {
            try
            {
                await _feedbackBL.GetAllFeedbacksForUser(employee);

            }
            catch (EntityNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task RaiseRequest()
        {
            try
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
            catch (CouldNotCreateEntityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task ViewAllRequests()
        {
            try
            {
                var requests = await _userRequestBL.GetAllRequests();
                requests.ForEach(Console.WriteLine);

            }
            catch (EntityNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task MarkRequestClosed()
        {
            try
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
            catch (EntityNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task ViewAllSolutions()
        {
            try
            {
                var solutions = await _requestSolutionBl.GetAllSolutions();

                foreach (RequestSolution solution in solutions)
                {
                    Console.WriteLine(solution);
                }
            }
            catch (EntityNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task ProvideSolution()
        {
            try
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
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public async Task GiveFeedback()
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public async Task RespondToSolution()
        {
            try
            {
                (await _requestSolutionBl.GetAllSolutionsForUser(_authUser)).ForEach(Console.WriteLine);

                Console.WriteLine("Enter Solution Number");
                var solutionNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Accept the solution? (Y/N)");
                var isAccepted = Console.ReadLine() ?? string.Empty;

                if (isAccepted.Equals("y", StringComparison.CurrentCultureIgnoreCase)) { await _requestSolutionBl.AcceptSolution(solutionNumber); return; }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task ViewYourFeedbacks()
        {
            try
            {
                var feedbacks = await _feedbackBL.GetAllFeedbacksForUser(_authUser);

                foreach (var feedback in feedbacks)
                {
                    Console.WriteLine(feedback);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
