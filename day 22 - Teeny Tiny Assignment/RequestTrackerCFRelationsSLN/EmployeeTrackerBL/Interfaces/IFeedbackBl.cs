using Models;
namespace EmployeeTrackerBL;

public interface IFeedbackBl
{
    public Task<Feedback> AddFeedback(Feedback feedback);
    
    public Task<Feedback> UpdateFeedback(Feedback feedback);

    public Task<List<Feedback>> GetAllFeedbacksForSolution(RequestSolution solution);

    public Task<Feedback> GetFeedbackById(int feedbackId);
    public Task<Feedback> GetAllFeedbacksForUser(Employee employee);
}