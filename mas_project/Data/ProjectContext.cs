using mas_project.Models;
using mas_project.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

//using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace mas_project.Data
{
    public class ProjectContext : DbContext
    {
        public DbSet<IndividualClient> IndividualClients { get; set; }
        public DbSet<InstitutionClient> InstitutionClients { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Playground> Playgrounds { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Employee_Playground> Employee_Playgrounds { get; set; }
        public DbSet<Zone_Device> Zone_Devices { get; set; }
        public DbSet<DeviceImage> Images {  get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Device_Material> Device_Materials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=YOUR_SERVER;Initial Catalog=YOUR_DB;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<IndividualClient>().ToTable("IndividualClients");
            modelBuilder.Entity<InstitutionClient>().ToTable("InstitutionClients");
            modelBuilder.Entity<Designer>().ToTable("Designers");
            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<Contract>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (Status)Enum.Parse(typeof(Status), v));

            modelBuilder.Entity<Playground>().ToTable("Playgrounds");

            modelBuilder.Entity<Zone>().ToTable("Zones")
                .Property(e => e.Substrate)
                .HasConversion(
                    v => v.ToString(),
                    v => (Substrate)Enum.Parse(typeof(Substrate), v));

            modelBuilder.Entity<Device>().ToTable("Devices")
                .HasDiscriminator<string>("DeviceType")
                .HasValue<Slide>("Slide")
                .HasValue<Swing>("Swing");
            //more devices to be added

            modelBuilder.Entity<Device>()
                .Property(e => e.Substrate)
                .HasConversion(
                    v => v.ToString(),
                    v => (Substrate)Enum.Parse(typeof(Substrate), v)); 
            
            modelBuilder.Entity<Employee_Playground>().ToTable("Employee_Playground");
            modelBuilder.Entity<Zone_Device>().ToTable("Zone_Device");
            modelBuilder.Entity<Device_Material>().ToTable("Device_Material");

            //modelBuilder.Entity<Client>().Property(d => d.ContactDetails).IsRequired();

            modelBuilder.Entity<Contract>()
                .HasOne(e => e.Client)
                .WithMany(e => e.Contracts)
                .HasForeignKey(e => e.ClientId)
                .IsRequired();

            modelBuilder.Entity<Contract>()
                .HasOne(e => e.Playground)
                .WithOne(e => e.Contract)
                .HasForeignKey<Playground>("ContractId");

            modelBuilder.Entity<Zone>()
                .HasOne(e => e.Playground)
                .WithMany(e => e.Zones)
                .HasForeignKey(e => e.PlaygroundId)
                .IsRequired();

            modelBuilder.Entity<Employee_Playground>()
                .HasKey(zd => new { zd.EmployeeId, zd.PlaygroundId });

            modelBuilder.Entity<Employee_Playground>()
                .HasOne(e => e.Playground)
                .WithMany(e => e.Employees)
                .HasForeignKey(zd => zd.PlaygroundId);

            modelBuilder.Entity<Employee_Playground>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.Playgrounds)
                .HasForeignKey(zd => zd.EmployeeId);

            modelBuilder.Entity<Playground>()
                .HasOne(e => e.Designer)
                .WithMany(e => e.Playgrounds)
                .HasForeignKey(e => e.DesignerId)
                .IsRequired();

            modelBuilder.Entity<Zone_Device>()
                .HasKey(zd => new { zd.DeviceId, zd.ZoneId });

            modelBuilder.Entity<Zone_Device>()
                .HasOne(zd => zd.Device)
                .WithMany(d => d.Zones)
                .HasForeignKey(zd => zd.DeviceId);

            modelBuilder.Entity<Zone_Device>()
                .HasOne(zd => zd.Zone)
                .WithMany(z => z.Devices)
                .HasForeignKey(zd => zd.ZoneId);

            modelBuilder.Entity<Device>()
                .HasMany(d => d.Images)
                .WithOne(i => i.Device)
                .HasForeignKey(i => i.DeviceId);

            modelBuilder.Entity<DeviceImage>().ToTable("DeviceImage");

            modelBuilder.Entity<Device>()
                .HasMany(e => e.Materials)
                .WithMany(e => e.Devices)
                .UsingEntity<Device_Material>(
                    l => l.HasOne<Material>().WithMany().HasForeignKey(e => e.MaterialId),
                    r => r.HasOne<Device>().WithMany().HasForeignKey(e => e.DeviceId));
        }
    }
}
