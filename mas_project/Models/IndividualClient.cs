using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
    public class IndividualClient : Client, IPerson
    {
        //public int IndividualClientId {  get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public string TypeOfIdentification { get; set; } = null!;
       
    }
}
