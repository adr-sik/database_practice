using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
    public class InstitutionClient : Client
    {
        //public int InstitutionalClientId { get; set; }
        public string Name { get; set; } = null!;
        public int NIP { get; set; }
    }
}
