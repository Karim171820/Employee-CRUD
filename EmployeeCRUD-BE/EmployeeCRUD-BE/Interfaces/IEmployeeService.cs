using EmployeeCRUD_BE.Models.Dtos;

namespace EmployeeCRUD_BE.Interfaces
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeOutputDto>> GetAllEmployees();
        public Task<bool> DeleteEmployee(int id);
        public Task<bool> AddEmployee(EmployeeInputDto employee);
        public Task<EmployeeOutputDto> EditEmployee(int id, EmployeeInputDto employee);
        public Task<EmployeeOutputDto> GetEmployeeById(int id);
    }
}
