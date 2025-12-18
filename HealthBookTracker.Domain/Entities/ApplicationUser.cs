using Microsoft.AspNetCore.Identity;

namespace HealthBookTracker.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public ICollection<Employee> Employees { get; set; } = [];
}