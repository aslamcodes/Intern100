using EmployeeTrackerDAL;
using Models;
using Models.Enums;

namespace EmployeeTrackerBL;

public class RequestSolutionBl : IRequestSolutionBl
{
    private readonly IRepository<int, RequestSolution> _solutionRepository = new SolutionRepository(new RequestTrackerContext());
    private readonly IRepository<int, Request> _requestRepository = new RequestRepository(new RequestTrackerContext());

    public async Task AcceptSolution(int solutionNumber)
    {
        var solution = await _solutionRepository.Get(solutionNumber) ?? throw new EntityNotFoundException(EntityEnum.RequestSolution);

        solution.isAccepted = true;

        await _solutionRepository.Update(solution);
    }

    public async Task<List<RequestSolution>> GetAllSolutions()
    {
        var solutions = await _solutionRepository.GetAll();

        return solutions ?? throw new EntityNotFoundException(EntityEnum.RequestSolution);
    }

    public async Task<List<RequestSolution>> GetAllSolutionsForUser(Employee authUser)
    {
        var solutions = await _solutionRepository.GetAll();
        var userRequests = await _requestRepository.GetAll();

        if (userRequests == null) throw new EntityNotFoundException(EntityEnum.Request);

        if (solutions == null) throw new EntityNotFoundException(EntityEnum.RequestSolution);

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