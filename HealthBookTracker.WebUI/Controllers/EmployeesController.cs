using HealthBookTracker.Application.Interfaces;
using HealthBookTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace HealthBookTracker.WebUI.Controllers
{
       [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<HealthBookTracker.Domain.Entities.ApplicationUser> _userManager;

        public EmployeesController(IEmployeeService employeeService, UserManager<HealthBookTracker.Domain.Entities.ApplicationUser> userManager)
        {
            _employeeService = employeeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? search, string? sortOrder)
        {
            var currentSort = string.IsNullOrEmpty(sortOrder) ? "DaysAsc" : sortOrder;
            ViewData["CurrentSort"] = currentSort;
            ViewData["DaysSortParam"] = currentSort == "DaysAsc" ? "DaysDesc" : "DaysAsc";

            var userId = _userManager.GetUserId(User);
            var employees = await _employeeService.GetAllAsync(userId, search, sortOrder);

            employees = sortOrder switch
            {
                "DaysAsc" => employees.OrderBy(e => e.DaysUntilExpiration ?? int.MaxValue),
                "DaysDesc" => employees.OrderByDescending(e => e.DaysUntilExpiration ?? int.MinValue),
                _ => employees.OrderBy(e => e.DaysUntilExpiration ?? int.MaxValue),
            };

            return View(employees.ToList());
        }

        public async Task<IActionResult> Details(int id)
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(Employee employee)
            {
                if (ModelState.IsValid)
                    {
                    employee.UserId = _userManager.GetUserId(User);
                    await _employeeService.CreateAsync(employee);
                    return RedirectToAction(nameof(Index));
                    }

                return View(employee);
            }
            [HttpGet]
            public async Task<IActionResult> Edit(int id)
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }

            [HttpPost]          
            public async Task<IActionResult> Edit(int id, Employee employee)
            {
                if (id != employee.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await _employeeService.UpdateAsync(employee);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await _employeeService.GetByIdAsync(id) == null)
                        {
                            return NotFound();
                        }
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }

            public async Task<IActionResult> Delete(int id)
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }

            [HttpPost, ActionName("Delete")]         
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                await _employeeService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }   
}
