using EmployeeTrackerDAL;
using Models;
using Models.Enums;

namespace EmployeeTrackerBL;

public class FeedbackBL : IFeedbackBl
{
    private readonly IRepository<int, Feedback> _feedbackRepository = new FeedbackRepository(new RequestTrackerContext());
    private readonly IRepository<int, RequestSolution> _solutionRepository = new SolutionRepository(new RequestTrackerContext());
    public async Task<Feedback> AddFeedback(Feedback feedback)
    {
        await _feedbackRepository.Add(feedback);
        return feedback;
    }

    public async Task<Feedback> UpdateFeedback(Feedback feedback)
    {
        await _feedbackRepository.Update(feedback);
        return feedback;
    }

    public async Task<List<Feedback>> GetAllFeedbacksForSolution(RequestSolution solution)
    {
        var feedbacks = await _feedbackRepository.GetAll();
        return feedbacks.Where(feedback => feedback.SolutionId == solution.SolutionNumber).ToList();
    }

    public async Task<Feedback> GetFeedbackById(int feedbackId)
    {
        return await _feedbackRepository.Get(feedbackId);
    }

    public async Task<List<Feedback>> GetAllFeedbacksForUser(Employee employee)
    {
        // get the user solutions and then get the feedbacks for those solutions
        var solutions = await _solutionRepository.GetAll() ?? throw new EntityNotFoundException(EntityEnum.RequestSolution);

        var userSolutions = solutions.Where(solution => solution.SolutionPostedBy == employee.Id).ToList();

        var allFeedbacks = await _feedbackRepository.GetAll() ?? throw new EntityNotFoundException(EntityEnum.Feedback);

        var feedbacksForSolutions = new List<Feedback>();

        foreach (var solution in userSolutions)
        {
            feedbacksForSolutions.AddRange(allFeedbacks.Where(feedback => feedback.SolutionId == solution.SolutionNumber)
                           .ToList());
        }

        return feedbacksForSolutions;

    }
}