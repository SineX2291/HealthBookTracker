using HealthBookTracker.Domain.Entities;
using HealthBookTracker.Domain.Interfaces;
using HealthBookTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthBookTracker.Infrastructure.Repositories
{
    public class EmployeeRepository(ApplicationDbContext db) : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<IEnumerable<Employee>> GetAllByUserAsync(string? userId)
        {
            return await _db.Employees
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }
        public async Task<Employee?> GetByIdAsync(int id) => await _db.Employees.FindAsync(id);
        public async Task CreateAsync(Employee employee)
        {
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Employee employee)
        {
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var e = await _db.Employees.FindAsync(id);
            if (e != null) { _db.Employees.Remove(e); await _db.SaveChangesAsync(); }
        }
    }
}
