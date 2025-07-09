using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
    public class Designer : IPerson
    {
        [Key]
        public int DesignerId { get; set; }
        public string Name { get ; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Permissions { get; set; } = null!;
        public virtual Employee? Employee { get; set; }
        //
        public virtual ICollection<Playground> Playgrounds { get; } = new List<Playground>();
    }
}
