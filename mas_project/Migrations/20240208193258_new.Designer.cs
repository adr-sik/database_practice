﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mas_project.Data;

#nullable disable

namespace mas_project.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20240208193258_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("mas_project.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("ContactDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecommenderId")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.ToTable("Clients", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("mas_project.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfCompletionActual")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfCompletionPlanned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfConclusion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfImplementation")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("DownPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContractId");

                    b.HasIndex("ClientId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("mas_project.Models.Designer", b =>
                {
                    b.Property<int>("DesignerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesignerId"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesignerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Designers", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.Device", b =>
                {
                    b.Property<int>("CatalogNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatalogNumber"));

                    b.Property<string>("DeviceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityCertificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Substrate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatalogNumber");

                    b.ToTable("Devices", (string)null);

                    b.HasDiscriminator<string>("DeviceType").HasValue("Device");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("mas_project.Models.DeviceImage", b =>
                {
                    b.Property<int>("DeviceImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceImageId"));

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeviceImageId");

                    b.HasIndex("DeviceId");

                    b.ToTable("DeviceImage", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.Device_Material", b =>
                {
                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("DeviceId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Device_Material", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.Employee_Playground", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("PlaygroundId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("expiryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeId", "PlaygroundId");

                    b.HasIndex("PlaygroundId");

                    b.ToTable("Employee_Playground", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("mas_project.Models.Playground", b =>
                {
                    b.Property<int>("PlaygroundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaygroundId"));

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("DesignerId")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descriptionOfLand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("fenceHeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("fenced")
                        .HasColumnType("bit");

                    b.Property<decimal>("surface")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PlaygroundId");

                    b.HasIndex("ContractId")
                        .IsUnique();

                    b.HasIndex("DesignerId");

                    b.ToTable("Playgrounds", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.Zone", b =>
                {
                    b.Property<int>("zoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("zoneId"));

                    b.Property<int>("PlaygroundId")
                        .HasColumnType("int");

                    b.Property<string>("Substrate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("degreeOfIsolation")
                        .HasColumnType("int");

                    b.HasKey("zoneId");

                    b.HasIndex("PlaygroundId");

                    b.ToTable("Zones", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.Zone_Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("DeviceId", "ZoneId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Zone_Device", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.IndividualClient", b =>
                {
                    b.HasBaseType("mas_project.Models.Client");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfIdentification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("IndividualClients", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.InstitutionClient", b =>
                {
                    b.HasBaseType("mas_project.Models.Client");

                    b.Property<int>("NIP")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("InstitutionClients", (string)null);
                });

            modelBuilder.Entity("mas_project.Models.Slide", b =>
                {
                    b.HasBaseType("mas_project.Models.Device");

                    b.Property<decimal>("angleOfFall")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("lengthOfExit")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("Slide");
                });

            modelBuilder.Entity("mas_project.Models.Swing", b =>
                {
                    b.HasBaseType("mas_project.Models.Device");

                    b.Property<decimal>("RopeLength")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("Swing");
                });

            modelBuilder.Entity("mas_project.Models.Contract", b =>
                {
                    b.HasOne("mas_project.Models.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("mas_project.Models.Designer", b =>
                {
                    b.HasOne("mas_project.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("mas_project.Models.DeviceImage", b =>
                {
                    b.HasOne("mas_project.Models.Device", "Device")
                        .WithMany("Images")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("mas_project.Models.Device_Material", b =>
                {
                    b.HasOne("mas_project.Models.Device", null)
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mas_project.Models.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mas_project.Models.Employee_Playground", b =>
                {
                    b.HasOne("mas_project.Models.Employee", "Employee")
                        .WithMany("Playgrounds")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mas_project.Models.Playground", "Playground")
                        .WithMany("Employees")
                        .HasForeignKey("PlaygroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Playground");
                });

            modelBuilder.Entity("mas_project.Models.Playground", b =>
                {
                    b.HasOne("mas_project.Models.Contract", "Contract")
                        .WithOne("Playground")
                        .HasForeignKey("mas_project.Models.Playground", "ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mas_project.Models.Designer", "Designer")
                        .WithMany("Playgrounds")
                        .HasForeignKey("DesignerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Designer");
                });

            modelBuilder.Entity("mas_project.Models.Zone", b =>
                {
                    b.HasOne("mas_project.Models.Playground", "Playground")
                        .WithMany("Zones")
                        .HasForeignKey("PlaygroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playground");
                });

            modelBuilder.Entity("mas_project.Models.Zone_Device", b =>
                {
                    b.HasOne("mas_project.Models.Device", "Device")
                        .WithMany("Zones")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mas_project.Models.Zone", "Zone")
                        .WithMany("Devices")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("mas_project.Models.IndividualClient", b =>
                {
                    b.HasOne("mas_project.Models.Client", null)
                        .WithOne()
                        .HasForeignKey("mas_project.Models.IndividualClient", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mas_project.Models.InstitutionClient", b =>
                {
                    b.HasOne("mas_project.Models.Client", null)
                        .WithOne()
                        .HasForeignKey("mas_project.Models.InstitutionClient", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mas_project.Models.Client", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("mas_project.Models.Contract", b =>
                {
                    b.Navigation("Playground");
                });

            modelBuilder.Entity("mas_project.Models.Designer", b =>
                {
                    b.Navigation("Playgrounds");
                });

            modelBuilder.Entity("mas_project.Models.Device", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("mas_project.Models.Employee", b =>
                {
                    b.Navigation("Playgrounds");
                });

            modelBuilder.Entity("mas_project.Models.Playground", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("mas_project.Models.Zone", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
