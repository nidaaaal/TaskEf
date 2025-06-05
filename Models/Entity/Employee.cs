using System.ComponentModel.DataAnnotations;

namespace Task.Models.Entity
{
    public class Employee
    {
        //Id, Name, Email, Salary, JoiningDate, and DepartmentId

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    

        public string Email { get; set; } = string.Empty;

        public int Salary { get; set; }

        public int EmployeeId { get; set; }

        public int DepartmentId { get; set; }


        public Department Department { get; set; }  
    }
}
