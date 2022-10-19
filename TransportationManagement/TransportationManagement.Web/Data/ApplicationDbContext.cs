using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TransportationManagement.Web.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace TransportationManagement.Web.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Invioce> Invioces { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<TransportationDetail> TransportationsDetails { get; set; } = null!;
        public virtual DbSet<TransportationDetailVehicleExtension> TransportationsDetailsVehiclesExtensions { get; set; } = null!;
        public virtual DbSet<TransportationHeader> TransportationsHeaders { get; set; } = null!;
        public virtual DbSet<TransportationRequest> TransportationsRequests { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<VehicleExtension> VehiclesExtensions { get; set; } = null!;
        public virtual DbSet<VehicleType> VehiclesTypes { get; set; } = null!;
        public virtual DbSet<VehicleTypeVehicleExtension> VehiclesTypesVehiclesExtensions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

             optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rnc)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RNC")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Drivers");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rnttnumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RNTTNumber");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invioce>(entity =>
            {
                entity.ToTable("Invioces");

                entity.HasKey(e => e.Number);

                entity.Property(e => e.Number)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.GrossAmount).HasColumnType("money");

                entity.Property(e => e.Ncf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("NCF")
                    .IsFixedLength();

                entity.Property(e => e.NetAmount).HasColumnType("money");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Taxes).HasColumnType("money");

                entity.Property(e => e.TransportationHeaderId).HasColumnName("TransportationHeader_Id");

                entity.HasOne(d => d.TransportationHeader)
                    .WithMany(p => p.Invioces)
                    .HasForeignKey(d => d.TransportationHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invioces_TransportationsHeaders");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.InvioceNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("Invioce_Number");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.InvioceNumberNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.InvioceNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Invioces");
            });

            modelBuilder.Entity<TransportationDetail>(entity =>
            {
                entity.ToTable("TransportationsDetails");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.DeliveryLocation)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.DeliverypDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DriverId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Driver_Id");

                entity.Property(e => e.PickUpDate).HasColumnType("datetime");

                entity.Property(e => e.PickUpLocation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleLicensePlate)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle_LicensePlate")
                    .IsFixedLength();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TransportationsDetails)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportationsDetails_Clients");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TransportationsDetails)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportationsDetails_Drivers");

                entity.HasOne(d => d.VehicleLicensePlateNavigation)
                    .WithMany(p => p.TransportationsDetails)
                    .HasForeignKey(d => d.VehicleLicensePlate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportationsDetails_Vehicles");
            });

            modelBuilder.Entity<TransportationDetailVehicleExtension>(entity =>
            {
                entity.ToTable("TransportationsDetailsVehiclesExtensions");

                entity.HasKey(e => new { e.TransportationDetailId, e.VehicleExtensionDescription })
                    .HasName("PK_TransportationsDetailsVehiclesExtensions");

                entity.ToTable("TransportationsDetails_VehiclesExtensions");

                entity.Property(e => e.TransportationDetailId).HasColumnName("TransportationDetail_Id");

                entity.Property(e => e.VehicleExtensionDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VehicleExtension_Description");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.TransportationDetail)
                    .WithMany(p => p.TransportationsDetailsVehiclesExtensions)
                    .HasForeignKey(d => d.TransportationDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportationsDetailsVehiclesExtensions_TransportationsDetails");

                entity.HasOne(d => d.VehicleExtensionDescriptionNavigation)
                    .WithMany(p => p.TransportationsDetailsVehiclesExtensions)
                    .HasForeignKey(d => d.VehicleExtensionDescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportationsDetailsVehiclesExtensions_VehiclesExtensions");
            });

            modelBuilder.Entity<TransportationHeader>(entity =>
            {
                entity.ToTable("TransportationsHeaders");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.TransportationRequestId).HasColumnName("TransportationRequest_Id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TransportationsHeaders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportationsHeaders_Clients");

                entity.HasOne(d => d.TransportationRequest)
                    .WithMany(p => p.TransportationsHeaders)
                    .HasForeignKey(d => d.TransportationRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransportationsHeaders_TransportationsRequests");
            });

            modelBuilder.Entity<TransportationRequest>(entity =>
            {
                entity.ToTable("TransportationsRequests");

                entity.Property(e => e.ContainerNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryLocation)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.DeliverypDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PickUpDate).HasColumnType("datetime");

                entity.Property(e => e.PickUpLocation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicles");

                entity.HasKey(e => e.LicensePlate);

                entity.Property(e => e.LicensePlate)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ChassisNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VehiclesTypesDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VehiclesTypes_Description");

                entity.HasOne(d => d.VehiclesTypesDescriptionNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehiclesTypesDescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicles_VehiclesTypes");
            });

            modelBuilder.Entity<VehicleExtension>(entity =>
            {
                entity.ToTable("VehiclesExtensions");

                entity.HasKey(e => e.Description);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehiclesTypes");

                entity.HasKey(e => e.Description);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleTypeVehicleExtension>(entity =>
            {
                entity.ToTable("VehiclesTypesVehiclesExtensions");

                entity.HasKey(e => new { e.VehiclesTypesDescription, e.VehiclesExtensionsDescription })
                    .HasName("PK_VehiclesTypesVehiclesExtensions");

                entity.ToTable("VehiclesTypes_VehiclesExtensions");

                entity.Property(e => e.VehiclesTypesDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VehiclesTypes_Description");

                entity.Property(e => e.VehiclesExtensionsDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VehiclesExtensions_Description");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.VehiclesExtensionsDescriptionNavigation)
                    .WithMany(p => p.VehiclesTypesVehiclesExtensions)
                    .HasForeignKey(d => d.VehiclesExtensionsDescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehiclesTypesVehiclesExtensions_VehiclesExtensions");

                entity.HasOne(d => d.VehiclesTypesDescriptionNavigation)
                    .WithMany(p => p.VehiclesTypesVehiclesExtensions)
                    .HasForeignKey(d => d.VehiclesTypesDescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehiclesTypesVehiclesExtensions_VehiclesTypes");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
