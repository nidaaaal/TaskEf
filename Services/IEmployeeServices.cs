using Task.Models.Dto;
using Task.Models.Entity;

namespace Task.Services
{
    public interface IEmployeeServices
    {
        Task<List<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetById(int id);
        Task<EmployeeDto> Create(EmployeeDto employeeDto);  
        Task<EmployeeDto> Update(int id, EmployeeDto employeeDto);  
        Task<bool> DeleteById(int id);   



    }
}
