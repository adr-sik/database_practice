namespace mas_project.Models
{
    public class Zone_Device
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; } = null!;
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; } = null!;
    }
}
