using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBookTracker.Domain.Entities;

namespace HealthBookTracker.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync(string? search, string? sortOrder);
        Task<Employee?> GetByIdAsync(int id);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}