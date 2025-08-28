using HealthBookTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HealthBookTracker.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task CreateAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);

    }
}
