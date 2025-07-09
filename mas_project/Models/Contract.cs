using mas_project.Util;

namespace mas_project.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public DateTime DateOfConclusion { get; set; }
        public DateTime DateOfImplementation { get; set; }
        public DateTime DateOfCompletionPlanned { get; set; }
        public DateTime DateOfCompletionActual { get; set; }
        public decimal? DownPayment { get; set; }
        public Status Status { get; set; }
        //associations
        public int ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;
        //public int PlaygroundId { get; set; }
        public virtual Playground? Playground { get; set; }
    }
}
