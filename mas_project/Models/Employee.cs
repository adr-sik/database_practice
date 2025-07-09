namespace mas_project.Models
{
    public class Employee : IPerson
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateOfEmployment { get; set; }
        //
        public virtual ICollection<Employee_Playground> Playgrounds { get; } = new List<Employee_Playground>();
    }
}
    