using EmployeeTrackerDAL;
using Models;

namespace EmployeeTrackerBL;

public class RequestSolutionBl : IRequestSolutionBl
{
    private readonly IRepository<int, RequestSolution> _solutionRepository = new SolutionRepository(new RequestTrackerContext());
    private readonly IRepository<int, Request> _requestRepository = new RequestRepository(new RequestTrackerContext());
    public async Task<List<RequestSolution>> GetAllSolutions()
    {
        var solutions = await _solutionRepository.GetAll();

        return solutions;
    }

    public async Task<List<RequestSolution>> GetAllSolutionsForUser(Employee authUser)
    {
        var solutions = await _solutionRepository.GetAll();
        var userRequests = await _requestRepository.GetAll();
        userRequests = userRequests.Where(r => r.RequestRaisedBy == authUser.Id).ToList();
        var userSolutions = solutions.Where(s => userRequests.Any(r => r.RequestNumber == s.RequestNumber)).ToList();
        return userSolutions;

    }

    public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
    {
        await _solutionRepository.Add(solution);
        return solution;
    }


}