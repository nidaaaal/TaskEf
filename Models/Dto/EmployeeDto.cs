namespace Task.Models.Dto
{
    public class EmployeeDto
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Salary { get; set; }

        public int EmployeeId { get; set; }

        public int DepartmentId { get; set; }


    }
}
