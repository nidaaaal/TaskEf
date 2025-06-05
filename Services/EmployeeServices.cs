using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Models.Dto;
using Task.Models.Entity;

namespace Task.Services
{
    public class EmployeeServices:IEmployeeServices
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;    
        public EmployeeServices(IMapper mapper,AppDbContext dbContext) 
        {
            _appDbContext = dbContext;
            _mapper = mapper;   
        }

       public async Task<List<EmployeeDto>> GetAll()
        {
            var data = await _appDbContext.Employees.Include(x=>x.Department).ToListAsync();
            return _mapper.Map<List<EmployeeDto>>(data);
        }
       public async Task<EmployeeDto?> GetById(int id)
        {
            var data = await _appDbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id);
            if (data == null) return null;
            return _mapper.Map<EmployeeDto>(data);  

        }
        public async Task<EmployeeDto?> Create(EmployeeDto employeeDto)
        {
            if (await _appDbContext.Employees.AnyAsync(x => x.EmployeeId == employeeDto.EmployeeId)) return null;
            _mapper.Map<Employee>(employeeDto);
            await _appDbContext.SaveChangesAsync();

            return employeeDto; 
        }
       public async Task<EmployeeDto?> Update(int id, EmployeeDto employeeDto)
        {
            var data = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null) return null;
            data.Name = employeeDto.Name;   
            data.Email = employeeDto.Email;
            data.Salary = employeeDto.Salary;   
            data.EmployeeId=employeeDto.EmployeeId;
            data.DepartmentId=employeeDto.DepartmentId;
            await _appDbContext.SaveChangesAsync();

            return employeeDto;

        }
        public async Task<bool> DeleteById(int id)
        {
          var data = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(data == null) return false;  
            _appDbContext.Employees.Remove(data);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

    }
}
