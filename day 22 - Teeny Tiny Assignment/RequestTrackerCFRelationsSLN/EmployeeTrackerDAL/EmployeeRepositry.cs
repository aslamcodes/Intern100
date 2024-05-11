﻿using Microsoft.EntityFrameworkCore;
using Models;
using RequestTrackerDALLibrary;

namespace EmployeeTrackerDAL
{
    internal class EmployeeRepositry : IRepository<int, Employee>
    {
        readonly private RequestTrackerContext _context;

        public EmployeeRepositry(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<Employee> Add(Employee entity)
        {
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(int key)
        {
            var e = await Get(key);
            if (e != null) return null;

            _context.Employees.Remove(e);
            await _context.SaveChangesAsync();

            return e;

        }

        public async Task<Employee> Get(int key)
        {
            Employee? e = await _context.Employees.FindAsync(key);

            if (e == null)
            {
                return null;
            }

            return e;
        }

        public async Task<IList<Employee>> GetAll()
        {
            var e = await _context.Employees.ToListAsync();

            if (e == null)
            {
                return null;
            }

            return e;
        }

        public async Task<Employee> Update(Employee entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
