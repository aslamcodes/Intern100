using Microsoft.EntityFrameworkCore;
using Models;

namespace EmployeeTrackerDAL;

public class FeedbackRepository: IRepository<int, Feedback>
{
    
    private readonly RequestTrackerContext _context = new RequestTrackerContext();
    public async Task<Feedback> Add(Feedback entity)
    {
        _context.Feedbacks.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Feedback> Update(Feedback entity)
    {
        _context.Feedbacks.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Feedback> Delete(int key)
    {
        var feedback = await Get(key);
        _context.Feedbacks.Remove(feedback);
        return feedback;
    }

    public async Task<Feedback> Get(int key)
    {
        var feedback = await _context.Feedbacks.FindAsync(key);
        
        return feedback;
    }

    public async Task<IList<Feedback>> GetAll()
    {
        var feedbacks = await _context.Feedbacks.ToListAsync();
        
        return feedbacks;
    }
}