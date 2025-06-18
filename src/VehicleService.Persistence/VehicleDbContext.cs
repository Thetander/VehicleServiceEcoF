using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleService.Domain.Entities;
using VehicleService.Domain.Enums;

namespace VehicleService.Persistence
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

        public DbSet<TipoVehiculo> TiposVehiculo { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<EstadoOperacionalVehiculo> EstadosOperacionales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TipoVehiculo Configuration
            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.TipoId);
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasIndex(e => e.Nombre).IsUnique();
                entity.Property(e => e.TipoMaquinaria)
                    .HasConversion<string>()
                    .HasMaxLength(20);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.CreadoEn).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.ActualizadoEn).HasDefaultValueSql("GETDATE()");
            });

            // Marca Configuration
            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.MarcaId);
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasIndex(e => e.Nombre).IsUnique();
                entity.Property(e => e.CreadoEn).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.ActualizadoEn).HasDefaultValueSql("GETDATE()");
            });

            // Modelo Configuration
            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.ModeloId);
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.TipoCombustible)
                    .HasConversion<string>()
                    .HasMaxLength(20);
                entity.Property(e => e.ConsumoEstandar)
                    .HasColumnType("decimal(10,2)");
                entity.Property(e => e.PorcentajeTolerancia)
                    .HasColumnType("decimal(5,2)");
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.CreadoEn).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.ActualizadoEn).HasDefaultValueSql("GETDATE()");

                // Relationships
                entity.HasOne(e => e.Marca)
                    .WithMany(m => m.Modelos)
                    .HasForeignKey(e => e.MarcaId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Unique constraint
                entity.HasIndex(e => new { e.MarcaId, e.Nombre }).IsUnique();
            });

            // Vehiculo Configuration
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.VehiculoId);
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.HasIndex(e => e.Codigo).IsUnique();
                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.HasIndex(e => e.Placa).IsUnique();
                entity.Property(e => e.TipoMaquinaria)
                    .HasConversion<string>()
                    .HasMaxLength(20);
                entity.Property(e => e.OdometroInicial)
                    .HasColumnType("decimal(12,2)");
                entity.Property(e => e.OdometroActual)
                    .HasColumnType("decimal(12,2)");
                entity.Property(e => e.CapacidadCombustible)
                    .HasColumnType("decimal(8,2)");
                entity.Property(e => e.CapacidadMotor)
                    .HasMaxLength(50);
                entity.Property(e => e.Estado)
                    .HasConversion<string>()
                    .HasMaxLength(20);
                entity.Property(e => e.CreadoEn).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.ActualizadoEn).HasDefaultValueSql("GETDATE()");

                // Relationships
                entity.HasOne(e => e.Tipo)
                    .WithMany(t => t.Vehiculos)
                    .HasForeignKey(e => e.TipoId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Modelo)
                    .WithMany(m => m.Vehiculos)
                    .HasForeignKey(e => e.ModeloId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // EstadoOperacionalVehiculo Configuration
            modelBuilder.Entity<EstadoOperacionalVehiculo>(entity =>
            {
                entity.HasKey(e => e.EstadoId);
                entity.Property(e => e.Estado)
                    .HasConversion<string>()
                    .HasMaxLength(20);
                entity.Property(e => e.Motivo).HasMaxLength(500);
                entity.Property(e => e.RegistradoPor)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.CreadoEn).HasDefaultValueSql("GETDATE()");

                // Relationships
                entity.HasOne(e => e.Vehiculo)
                    .WithMany(v => v.EstadosOperacionales)
                    .HasForeignKey(e => e.VehiculoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}