using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Services.Models
{
    public partial class HotelManagementContext : DbContext
    {
        public HotelManagementContext()
        {
        }

        public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Occupancy> Occupancies { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                string ConnectionStr = config.GetConnectionString("DB");

                optionsBuilder.UseSqlServer(ConnectionStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__Customer__BE2ACD6E8B12E187");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber)
                    .HasName("PK__Employee__8D6635999348ACB2");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Occupancy>(entity =>
            {
                entity.HasKey(e => e.OccupancyNumber)
                    .HasName("PK__Occupanc__590E9CCFADEABFA0");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOccupied).HasColumnType("date");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Occupancies)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__Occupanci__Accou__4316F928");

                entity.HasOne(d => d.EmployeeNumberNavigation)
                    .WithMany(p => p.Occupancies)
                    .HasForeignKey(d => d.EmployeeNumber)
                    .HasConstraintName("FK__Occupanci__Emplo__4222D4EF");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.Occupancies)
                    .HasForeignKey(d => d.RoomNumber)
                    .HasConstraintName("FK__Occupanci__RoomN__440B1D61");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.ReceiptNumber)
                    .HasName("PK__Payments__C08AFDAADB8EED28");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.TaxRate).HasDefaultValueSql("((0.01))");

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK__Payments__Accoun__47DBAE45");

                entity.HasOne(d => d.EmployeeNumberNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.EmployeeNumber)
                    .HasConstraintName("FK__Payments__Employ__46E78A0C");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomNumber)
                    .HasName("PK__Rooms__AE10E07BE9DB43A4");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BedType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoomStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoomType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
