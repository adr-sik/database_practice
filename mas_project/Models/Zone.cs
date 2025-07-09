namespace mas_project.Models
{
    public class Zone
    {
        public int zoneId { get; set; }
        public int degreeOfIsolation { get; set; }
        public Util.Substrate Substrate { get; set; }
        //
        public int PlaygroundId { get; set; }
        public virtual Playground Playground { get; set; } = null!;
        public virtual ICollection<Zone_Device> Devices { get; } = new List<Zone_Device>();
    }
}
