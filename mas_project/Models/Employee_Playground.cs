namespace mas_project.Models
{
    public class Employee_Playground
    {
        public int Id { get; set; }
        public DateTime expiryDate { get; set; }
        //
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public int PlaygroundId { get; set; }
        public virtual Playground Playground { get; set; } = null!;
    }
}
