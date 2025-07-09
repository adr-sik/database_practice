using System.ComponentModel.DataAnnotations;

namespace mas_project.Models
{
    public class DeviceImage
    {
        [Key]
        public int DeviceImageId { get; set; }
        public string Name { get; set; } = null!;
        public string URL { get; set; } = null!;
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; } = null!;
    }
}
