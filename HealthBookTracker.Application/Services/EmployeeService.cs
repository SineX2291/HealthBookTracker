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

        public async Task<IEnumerable<Employee>> GetAllAsync(string? search, string? sortOrder)
        {
            var employees = await _repo.GetAllAsync();

            // 🔎 Фильтрация
            if (!string.IsNullOrEmpty(search))
            {
                employees = employees.Where(e =>
                    (e.FirstName?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (e.LastName?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (e.Position?.Contains(search, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            // ↕ Сортировка
            employees = sortOrder switch
            {
                "name_desc" => employees.OrderByDescending(e => e.LastName),
                "position" => employees.OrderBy(e => e.Position),
                "position_desc" => employees.OrderByDescending(e => e.Position),
                _ => employees.OrderBy(e => e.LastName) // по умолчанию
            };

            return employees;
        }
        public Task<Employee?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateAsync(Employee employee) => _repo.CreateAsync(employee);
        public Task UpdateAsync(Employee employee) => _repo.UpdateAsync(employee);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
