using HealthBookTracker.Application.Interfaces;
using HealthBookTracker.Domain.Entities;
using HealthBookTracker.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthBookTracker.WebUI.Controllers
{
        [SessionAuthorize]
        public class EmployeesController(IEmployeeService employeeService) : Controller
        {
            private readonly IEmployeeService _employeeService = employeeService;

        public async Task<IActionResult> Index()
            {
                var employees = await _employeeService.GetAllAsync();
                return View(employees);
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
