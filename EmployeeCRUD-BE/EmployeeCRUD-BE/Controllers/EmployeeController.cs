using EmployeeCRUD_BE.Interfaces;
using EmployeeCRUD_BE.Models;
using EmployeeCRUD_BE.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(EmployeeContext employeeContext, IEmployeeService employeeService)
        {
            _employeeContext = employeeContext;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeOutputDto>> GetEmployees()
        {
            return await _employeeService.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public async Task<EmployeeOutputDto> GetEmployeeById(int id)
        {
            //if (_employeeContext.Employees == null)
            //    return NotFound();
            //var employee = await _employeeContext.Employees.FindAsync(id);
            //if(employee == null)
            //    return NotFound();

            //return employee;
            return await _employeeService.GetEmployeeById(id);
        }

        [HttpPost]
        public Task<bool> PostEmployee(EmployeeInputDto employee)
        {
            //_employeeContext.Employees.Add(employee);
            //await _employeeContext.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.ID }, employee);
            return _employeeService.AddEmployee(employee);
        }

        [HttpPut("{id}")]
        public void PutEmployee(int id, EmployeeInputDto employee)
        {
            //if(id != employee.ID)
            //{
            //    return BadRequest();
            //}
            // _employeeContext.Entry(employee).State = EntityState.Modified;
            //try
            //{
            //    await _employeeContext.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{ 
            //    throw;
            //}
            //return Ok();
            _employeeService.EditEmployee(id, employee);
        }

        [HttpDelete("{id}")]
        public Task<bool> DeleteEmployee(int id)
        {
            return _employeeService.DeleteEmployee(id);
        }

         
    }
}
