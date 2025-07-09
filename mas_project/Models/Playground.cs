namespace mas_project.Models
{
    public class Playground
    {
        public int PlaygroundId { get; set; }
        public string address { get; set; }
        public string descriptionOfLand { get; set; }
        public decimal surface {  get; set; }
        public bool fenced { get; set; }
        public decimal fenceHeight { get; set; }
        //
        //public int ContractId { get; set; }
        public virtual Contract Contract { get; set; } = null!;
        public virtual ICollection<Zone> Zones { get; } = new List<Zone>();
        public virtual ICollection<Employee_Playground> Employees { get; } = new List<Employee_Playground>();
        public int DesignerId { get; set; }
        public virtual Designer? Designer { get; set; }

        public override string ToString()
        {
            return $"Address: {address}, Description: {descriptionOfLand}, Surface: {surface}, Fenced: {fenced}, Fence Height: {fenceHeight}";
        }
    }
}
