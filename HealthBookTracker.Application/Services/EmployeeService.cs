using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBookTracker.Application.Interfaces;
using HealthBookTracker.Domain.Entities;
using HealthBookTracker.Domain.Interfaces;

namespace HealthBookTracker.Application.Services
{
    public class EmployeeService(IEmployeeRepository repo) : IEmployeeService
    {
        private readonly IEmployeeRepository _repo = repo;

        public Task<IEnumerable<Employee>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Employee?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateAsync(Employee employee) => _repo.CreateAsync(employee);
        public Task UpdateAsync(Employee employee) => _repo.UpdateAsync(employee);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
