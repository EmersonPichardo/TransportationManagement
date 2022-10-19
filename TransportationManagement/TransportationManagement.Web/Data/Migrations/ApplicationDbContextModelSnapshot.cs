﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportationManagement.Web.Data;

#nullable disable

namespace TransportationManagement.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Rnc")
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("char(9)")
                        .HasColumnName("RNC")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Driver", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Rnttnumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("RNTTNumber");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Drivers", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Invioce", b =>
                {
                    b.Property<string>("Number")
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("money");

                    b.Property<decimal>("GrossAmount")
                        .HasColumnType("money");

                    b.Property<string>("Ncf")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("char(11)")
                        .HasColumnName("NCF")
                        .IsFixedLength();

                    b.Property<decimal>("NetAmount")
                        .HasColumnType("money");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("money");

                    b.Property<int>("TransportationHeaderId")
                        .HasColumnType("int")
                        .HasColumnName("TransportationHeader_Id");

                    b.HasKey("Number");

                    b.HasIndex("TransportationHeaderId");

                    b.ToTable("Invioces", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("InvioceNumber")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("Invioce_Number");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("InvioceNumber");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("Client_Id");

                    b.Property<string>("DeliveryLocation")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5000)");

                    b.Property<DateTime>("DeliverypDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("DriverId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Driver_Id");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PickUpLocation")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("VehicleLicensePlate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("char(7)")
                        .HasColumnName("Vehicle_LicensePlate")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleLicensePlate");

                    b.ToTable("TransportationsDetails", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationDetailVehicleExtension", b =>
                {
                    b.Property<int>("TransportationDetailId")
                        .HasColumnType("int")
                        .HasColumnName("TransportationDetail_Id");

                    b.Property<string>("VehicleExtensionDescription")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("VehicleExtension_Description");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("TransportationDetailId", "VehicleExtensionDescription")
                        .HasName("PK_TransportationsDetailsVehiclesExtensions");

                    b.HasIndex("VehicleExtensionDescription");

                    b.ToTable("TransportationsDetails_VehiclesExtensions", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("Client_Id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("money");

                    b.Property<int>("TransportationRequestId")
                        .HasColumnType("int")
                        .HasColumnName("TransportationRequest_Id");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TransportationRequestId");

                    b.ToTable("TransportationsHeaders", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContainerNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DeliveryLocation")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5000)");

                    b.Property<DateTime?>("DeliverypDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PickUpLocation")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("TransportationsRequests", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Vehicle", b =>
                {
                    b.Property<string>("LicensePlate")
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("char(7)")
                        .IsFixedLength();

                    b.Property<string>("ChassisNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("VehiclesTypesDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("VehiclesTypes_Description");

                    b.HasKey("LicensePlate");

                    b.HasIndex("VehiclesTypesDescription");

                    b.ToTable("Vehicles", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.VehicleExtension", b =>
                {
                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Description");

                    b.ToTable("VehiclesExtensions", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.VehicleType", b =>
                {
                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Description");

                    b.ToTable("VehiclesTypes", (string)null);
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.VehicleTypeVehicleExtension", b =>
                {
                    b.Property<string>("VehiclesTypesDescription")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("VehiclesTypes_Description");

                    b.Property<string>("VehiclesExtensionsDescription")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("VehiclesExtensions_Description");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("VehiclesTypesDescription", "VehiclesExtensionsDescription")
                        .HasName("PK_VehiclesTypesVehiclesExtensions");

                    b.HasIndex("VehiclesExtensionsDescription");

                    b.ToTable("VehiclesTypes_VehiclesExtensions", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Invioce", b =>
                {
                    b.HasOne("TransportationManagement.Web.Models.TransportationHeader", "TransportationHeader")
                        .WithMany("Invioces")
                        .HasForeignKey("TransportationHeaderId")
                        .IsRequired()
                        .HasConstraintName("FK_Invioces_TransportationsHeaders");

                    b.Navigation("TransportationHeader");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Payment", b =>
                {
                    b.HasOne("TransportationManagement.Web.Models.Invioce", "InvioceNumberNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("InvioceNumber")
                        .IsRequired()
                        .HasConstraintName("FK_Payments_Invioces");

                    b.Navigation("InvioceNumberNavigation");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationDetail", b =>
                {
                    b.HasOne("TransportationManagement.Web.Models.Client", "Client")
                        .WithMany("TransportationsDetails")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("FK_TransportationsDetails_Clients");

                    b.HasOne("TransportationManagement.Web.Models.Driver", "Driver")
                        .WithMany("TransportationsDetails")
                        .HasForeignKey("DriverId")
                        .IsRequired()
                        .HasConstraintName("FK_TransportationsDetails_Drivers");

                    b.HasOne("TransportationManagement.Web.Models.Vehicle", "VehicleLicensePlateNavigation")
                        .WithMany("TransportationsDetails")
                        .HasForeignKey("VehicleLicensePlate")
                        .IsRequired()
                        .HasConstraintName("FK_TransportationsDetails_Vehicles");

                    b.Navigation("Client");

                    b.Navigation("Driver");

                    b.Navigation("VehicleLicensePlateNavigation");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationDetailVehicleExtension", b =>
                {
                    b.HasOne("TransportationManagement.Web.Models.TransportationDetail", "TransportationDetail")
                        .WithMany("TransportationsDetailsVehiclesExtensions")
                        .HasForeignKey("TransportationDetailId")
                        .IsRequired()
                        .HasConstraintName("FK_TransportationsDetailsVehiclesExtensions_TransportationsDetails");

                    b.HasOne("TransportationManagement.Web.Models.VehicleExtension", "VehicleExtensionDescriptionNavigation")
                        .WithMany("TransportationsDetailsVehiclesExtensions")
                        .HasForeignKey("VehicleExtensionDescription")
                        .IsRequired()
                        .HasConstraintName("FK_TransportationsDetailsVehiclesExtensions_VehiclesExtensions");

                    b.Navigation("TransportationDetail");

                    b.Navigation("VehicleExtensionDescriptionNavigation");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationHeader", b =>
                {
                    b.HasOne("TransportationManagement.Web.Models.Client", "Client")
                        .WithMany("TransportationsHeaders")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("FK_TransportationsHeaders_Clients");

                    b.HasOne("TransportationManagement.Web.Models.TransportationRequest", "TransportationRequest")
                        .WithMany("TransportationsHeaders")
                        .HasForeignKey("TransportationRequestId")
                        .IsRequired()
                        .HasConstraintName("FK_TransportationsHeaders_TransportationsRequests");

                    b.Navigation("Client");

                    b.Navigation("TransportationRequest");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Vehicle", b =>
                {
                    b.HasOne("TransportationManagement.Web.Models.VehicleType", "VehiclesTypesDescriptionNavigation")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehiclesTypesDescription")
                        .IsRequired()
                        .HasConstraintName("FK_Vehicles_VehiclesTypes");

                    b.Navigation("VehiclesTypesDescriptionNavigation");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.VehicleTypeVehicleExtension", b =>
                {
                    b.HasOne("TransportationManagement.Web.Models.VehicleExtension", "VehiclesExtensionsDescriptionNavigation")
                        .WithMany("VehiclesTypesVehiclesExtensions")
                        .HasForeignKey("VehiclesExtensionsDescription")
                        .IsRequired()
                        .HasConstraintName("FK_VehiclesTypesVehiclesExtensions_VehiclesExtensions");

                    b.HasOne("TransportationManagement.Web.Models.VehicleType", "VehiclesTypesDescriptionNavigation")
                        .WithMany("VehiclesTypesVehiclesExtensions")
                        .HasForeignKey("VehiclesTypesDescription")
                        .IsRequired()
                        .HasConstraintName("FK_VehiclesTypesVehiclesExtensions_VehiclesTypes");

                    b.Navigation("VehiclesExtensionsDescriptionNavigation");

                    b.Navigation("VehiclesTypesDescriptionNavigation");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Client", b =>
                {
                    b.Navigation("TransportationsDetails");

                    b.Navigation("TransportationsHeaders");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Driver", b =>
                {
                    b.Navigation("TransportationsDetails");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Invioce", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationDetail", b =>
                {
                    b.Navigation("TransportationsDetailsVehiclesExtensions");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationHeader", b =>
                {
                    b.Navigation("Invioces");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.TransportationRequest", b =>
                {
                    b.Navigation("TransportationsHeaders");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.Vehicle", b =>
                {
                    b.Navigation("TransportationsDetails");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.VehicleExtension", b =>
                {
                    b.Navigation("TransportationsDetailsVehiclesExtensions");

                    b.Navigation("VehiclesTypesVehiclesExtensions");
                });

            modelBuilder.Entity("TransportationManagement.Web.Models.VehicleType", b =>
                {
                    b.Navigation("Vehicles");

                    b.Navigation("VehiclesTypesVehiclesExtensions");
                });
#pragma warning restore 612, 618
        }
    }
}
