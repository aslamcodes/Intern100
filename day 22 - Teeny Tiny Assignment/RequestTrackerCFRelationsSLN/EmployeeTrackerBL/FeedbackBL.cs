using EmployeeTrackerDAL;
using Models;

namespace EmployeeTrackerBL;

public class FeedbackBL: IFeedbackBl
{
    private readonly IRepository<int, Feedback> _feedbackRepository = new FeedbackRepository(new RequestTrackerContext());
    
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

    public Task<Feedback> GetAllFeedbacksForUser(Employee employee)
    {
        throw new System.NotImplementedException();
    }
}