using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
    public abstract class Device
    {
        [Key]
        public int CatalogNumber {  get; set; }
        public string Name { get; set; } = null!;
        public string SecurityCertificate { get; set; } = null!;
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Util.Substrate Substrate { get; set; }
        //
        public virtual ICollection<Zone_Device> Zones{ get; set; }
        public virtual ICollection<DeviceImage> Images { get; set; }
        public virtual ICollection<Material>? Materials { get; set; }
    }
}
