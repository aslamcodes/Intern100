using Microsoft.EntityFrameworkCore;
using Models;

namespace EmployeeTrackerDAL
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        readonly private RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<Employee> Add(Employee entity)
        {
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee?> Delete(int key)
        {
            var e = await Get(key);


            if (e != null) return null;

            _context.Employees.Remove(e);
            await _context.SaveChangesAsync();

            return e;

        }

        public async Task<Employee?> Get(int key)
        {
            Employee? e = await _context.Employees.Include(e => e.RequestSolutions)
                .Include(e => e.RequestsRaised)
                .Include(e => e.RequestsClosed)
                .SingleOrDefaultAsync(e => e.Id == key);

            if (e == null)
            {
                return null;
            }

            return e;
        }

        public async Task<List<Employee>?> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();

            if (employees.Count == 0)
            {
                return null;
            }

            return employees;
        }

        public async Task<Employee> Update(Employee entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
