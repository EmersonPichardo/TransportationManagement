using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportationManagement.Web.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    RNC = table.Column<string>(type: "char(9)", unicode: false, fixedLength: true, maxLength: 9, nullable: true),
                    Address = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContactNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    RNTTNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportationsRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    PickUpLocation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    DeliveryLocation = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeliverypDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ContainerNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationsRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesExtensions",
                columns: table => new
                {
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesExtensions", x => x.Description);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesTypes",
                columns: table => new
                {
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesTypes", x => x.Description);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportationsHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationsHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportationsHeaders_Clients",
                        column: x => x.Client_Id,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    VehiclesTypes_Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ChassisNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.LicensePlate);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehiclesTypes",
                        column: x => x.VehiclesTypes_Description,
                        principalTable: "VehiclesTypes",
                        principalColumn: "Description");
                });

            migrationBuilder.CreateTable(
                name: "VehiclesTypes_VehiclesExtensions",
                columns: table => new
                {
                    VehiclesTypes_Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    VehiclesExtensions_Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesTypesVehiclesExtensions", x => new { x.VehiclesTypes_Description, x.VehiclesExtensions_Description });
                    table.ForeignKey(
                        name: "FK_VehiclesTypesVehiclesExtensions_VehiclesExtensions",
                        column: x => x.VehiclesExtensions_Description,
                        principalTable: "VehiclesExtensions",
                        principalColumn: "Description");
                    table.ForeignKey(
                        name: "FK_VehiclesTypesVehiclesExtensions_VehiclesTypes",
                        column: x => x.VehiclesTypes_Description,
                        principalTable: "VehiclesTypes",
                        principalColumn: "Description");
                });

            migrationBuilder.CreateTable(
                name: "Invioces",
                columns: table => new
                {
                    Number = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    TransportationHeader_Id = table.Column<int>(type: "int", nullable: false),
                    NCF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    GrossAmount = table.Column<decimal>(type: "money", nullable: false),
                    Taxes = table.Column<decimal>(type: "money", nullable: false),
                    Discount = table.Column<decimal>(type: "money", nullable: true),
                    NetAmount = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invioces", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Invioces_TransportationsHeaders",
                        column: x => x.TransportationHeader_Id,
                        principalTable: "TransportationsHeaders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransportationsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportationHeader_Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    PickUpLocation = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    DeliveryLocation = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeliverypDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Driver_Id = table.Column<int>(type: "int", unicode: false, maxLength: 20, nullable: false),
                    Vehicle_LicensePlate = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportationsDetails_Drivers",
                        column: x => x.Driver_Id,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransportationsDetails_TransportationsHeaders",
                        column: x => x.TransportationHeader_Id,
                        principalTable: "TransportationsHeaders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransportationsDetails_Vehicles",
                        column: x => x.Vehicle_LicensePlate,
                        principalTable: "Vehicles",
                        principalColumn: "LicensePlate");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invioce_Number = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Invioces",
                        column: x => x.Invioce_Number,
                        principalTable: "Invioces",
                        principalColumn: "Number");
                });

            migrationBuilder.CreateTable(
                name: "TransportationsDetails_VehiclesExtensions",
                columns: table => new
                {
                    TransportationDetail_Id = table.Column<int>(type: "int", nullable: false),
                    VehicleExtension_Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationsDetailsVehiclesExtensions", x => new { x.TransportationDetail_Id, x.VehicleExtension_Description });
                    table.ForeignKey(
                        name: "FK_TransportationsDetailsVehiclesExtensions_TransportationsDetails",
                        column: x => x.TransportationDetail_Id,
                        principalTable: "TransportationsDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransportationsDetailsVehiclesExtensions_VehiclesExtensions",
                        column: x => x.VehicleExtension_Description,
                        principalTable: "VehiclesExtensions",
                        principalColumn: "Description");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invioces_TransportationHeader_Id",
                table: "Invioces",
                column: "TransportationHeader_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Invioce_Number",
                table: "Payments",
                column: "Invioce_Number");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationsDetails_Driver_Id",
                table: "TransportationsDetails",
                column: "Driver_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationsDetails_TransportationHeader_Id",
                table: "TransportationsDetails",
                column: "TransportationHeader_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationsDetails_Vehicle_LicensePlate",
                table: "TransportationsDetails",
                column: "Vehicle_LicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationsDetails_VehiclesExtensions_VehicleExtension_Description",
                table: "TransportationsDetails_VehiclesExtensions",
                column: "VehicleExtension_Description");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationsHeaders_Client_Id",
                table: "TransportationsHeaders",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehiclesTypes_Description",
                table: "Vehicles",
                column: "VehiclesTypes_Description");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesTypes_VehiclesExtensions_VehiclesExtensions_Description",
                table: "VehiclesTypes_VehiclesExtensions",
                column: "VehiclesExtensions_Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TransportationsDetails_VehiclesExtensions");

            migrationBuilder.DropTable(
                name: "TransportationsRequests");

            migrationBuilder.DropTable(
                name: "VehiclesTypes_VehiclesExtensions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Invioces");

            migrationBuilder.DropTable(
                name: "TransportationsDetails");

            migrationBuilder.DropTable(
                name: "VehiclesExtensions");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "TransportationsHeaders");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "VehiclesTypes");
        }
    }
}
