using EmployeeCRUD_BE.GenericRepository;
using EmployeeCRUD_BE.Interfaces;
using EmployeeCRUD_BE.Models;
using EmployeeCRUD_BE.Models.Dtos;

namespace EmployeeCRUD_BE.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IGenericRepository<Employee> _employeeRepository { get; set; }
        public EmployeeService(IGenericRepository<Employee> EmployeeRepository)
        {
            _employeeRepository = EmployeeRepository;
        }
        public Task<bool> AddEmployee(EmployeeInputDto employee)
        {
            var Employee = new Employee{

                Name = employee.Name,
                Age = employee.Age,
                isActive = employee.isActive
            };
            _employeeRepository.Insert(Employee);
            _employeeRepository.Save();
            return Task.FromResult(true);
        }

        public Task<bool> DeleteEmployee(int id)
        {
           _employeeRepository.Delete(id);
            _employeeRepository.Save();
            return Task.FromResult(true);
        }

        public async Task<EmployeeOutputDto> EditEmployee(int id, EmployeeInputDto employee)
        {
            var existingEmployee = _employeeRepository.GetById(id);


            // Update the properties of the existing employee with the values from the input DTO
            existingEmployee.Name = employee.Name;
            existingEmployee.Age = employee.Age;
            existingEmployee.isActive = employee.isActive;

            // Save the changes to the database
             _employeeRepository.Save();
            var NewEmployee = new EmployeeOutputDto
            {
                Name = employee.Name,
                Age = employee.Age,
                isActive = employee.isActive
            };
            return NewEmployee;
        }

        public Task<IEnumerable<EmployeeOutputDto>> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllAsQueryable().Select( e => new EmployeeOutputDto
            { 
                Name = e.Name,
                Age = e.Age,
                isActive = e.isActive,
                ID = e.ID
            }).ToList();

            return Task.FromResult<IEnumerable<EmployeeOutputDto>>(employees);
        }

        public Task<EmployeeOutputDto> GetEmployeeById(int id)
        {
            var Employee = _employeeRepository.GetById(id);

            var result = new EmployeeOutputDto
            {
                Name = Employee.Name,
                Age = Employee.Age,
                isActive = Employee.isActive,
                ID = Employee.ID
            };
            return Task.FromResult(result);
        }
    }
}
