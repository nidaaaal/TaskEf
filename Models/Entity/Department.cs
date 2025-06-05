using System.ComponentModel.DataAnnotations;

namespace Task.Models.Entity
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; } 

        public string Name { get; set; } = string.Empty;    

        public string Location { get; set; } = string.Empty;    

        public List<Employee> Employees { get; set; }   




    }
}
