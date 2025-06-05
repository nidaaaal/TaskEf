using AutoMapper;
using Task.Models.Dto;
using Task.Models.Entity;

namespace Task.Data
{
    public class MappProfile:Profile
    {
        public MappProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();    
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }    

    }
}
