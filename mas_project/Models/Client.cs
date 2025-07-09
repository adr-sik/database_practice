using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mas_project.Models
{
    [NotMapped]
    public abstract class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ContactDetails { get; set; } = null!;
        public int? RecommenderId { get; set; }
        //public Client? Recommendation { get; set; }
        public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();
    }
}
