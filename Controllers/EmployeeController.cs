using EmlpoyeesDetails.Data;
using EmlpoyeesDetails.Models;
using EmlpoyeesDetails.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmlpoyeesDetails.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppliactionDbContext dbContext;

        public EmployeeController(AppliactionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeModel addmodel)
        {
            var employee = new Employeedtl
            {
                Name = addmodel.Name,
                Descriptions = addmodel.Descriptions,
                Phone = addmodel.Phone,
                IsActive = true
            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> list()
        {
            var employee = await dbContext.Employees.Where(e => e.IsActive).ToListAsync();
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employeedtl editmodel)
        {
            var employee = await dbContext.Employees.FindAsync(editmodel.Id);

            if (employee is not null)
            {
                employee.Name = editmodel.Name;
                employee.Descriptions = editmodel.Descriptions;
                employee.Phone = editmodel.Phone;
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if (employee is not null)
            {
                employee.IsActive = false;
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Employee");
        }
    }
}
