using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mas_project.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecommenderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    CatalogNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityCertificate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    Substrate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lengthOfExit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    angleOfFall = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RopeLength = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.CatalogNumber);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfConclusion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfImplementation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfCompletionPlanned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfCompletionActual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DownPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualClients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_IndividualClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionClients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_InstitutionClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceImage",
                columns: table => new
                {
                    DeviceImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceImage", x => x.DeviceImageId);
                    table.ForeignKey(
                        name: "FK_DeviceImage_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "CatalogNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    DesignerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.DesignerId);
                    table.ForeignKey(
                        name: "FK_Designers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "Device_Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device_Material", x => new { x.DeviceId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_Device_Material_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "CatalogNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Device_Material_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playgrounds",
                columns: table => new
                {
                    PlaygroundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descriptionOfLand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surface = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fenced = table.Column<bool>(type: "bit", nullable: false),
                    fenceHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    DesignerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playgrounds", x => x.PlaygroundId);
                    table.ForeignKey(
                        name: "FK_Playgrounds_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Playgrounds_Designers_DesignerId",
                        column: x => x.DesignerId,
                        principalTable: "Designers",
                        principalColumn: "DesignerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Playground",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PlaygroundId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    expiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Playground", x => new { x.EmployeeId, x.PlaygroundId });
                    table.ForeignKey(
                        name: "FK_Employee_Playground_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Playground_Playgrounds_PlaygroundId",
                        column: x => x.PlaygroundId,
                        principalTable: "Playgrounds",
                        principalColumn: "PlaygroundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    zoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degreeOfIsolation = table.Column<int>(type: "int", nullable: false),
                    Substrate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaygroundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.zoneId);
                    table.ForeignKey(
                        name: "FK_Zones_Playgrounds_PlaygroundId",
                        column: x => x.PlaygroundId,
                        principalTable: "Playgrounds",
                        principalColumn: "PlaygroundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zone_Device",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone_Device", x => new { x.DeviceId, x.ZoneId });
                    table.ForeignKey(
                        name: "FK_Zone_Device_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "CatalogNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zone_Device_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "zoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Designers_EmployeeId",
                table: "Designers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_Material_MaterialId",
                table: "Device_Material",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceImage_DeviceId",
                table: "DeviceImage",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Playground_PlaygroundId",
                table: "Employee_Playground",
                column: "PlaygroundId");

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_ContractId",
                table: "Playgrounds",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_DesignerId",
                table: "Playgrounds",
                column: "DesignerId");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_Device_ZoneId",
                table: "Zone_Device",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_PlaygroundId",
                table: "Zones",
                column: "PlaygroundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device_Material");

            migrationBuilder.DropTable(
                name: "DeviceImage");

            migrationBuilder.DropTable(
                name: "Employee_Playground");

            migrationBuilder.DropTable(
                name: "IndividualClients");

            migrationBuilder.DropTable(
                name: "InstitutionClients");

            migrationBuilder.DropTable(
                name: "Zone_Device");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Playgrounds");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
