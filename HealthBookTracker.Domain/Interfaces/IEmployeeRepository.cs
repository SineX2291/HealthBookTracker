using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBookTracker.Domain.Entities;

namespace HealthBookTracker.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllByUserAsync(string? userId);
        Task<Employee?> GetByIdAsync(int id);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}