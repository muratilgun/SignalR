using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ChartsServer.Models
{
    public partial class SatisDBContext : DbContext
    {
        public SatisDBContext()
        {
        }

        public SatisDBContext(DbContextOptions<SatisDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Personeller> Personellers { get; set; }
        public virtual DbSet<Satislar> Satislars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SatisDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Personeller>(entity =>
            {
                entity.ToTable("Personeller");

                entity.Property(e => e.Adi).HasMaxLength(50);

                entity.Property(e => e.Soyadi).HasMaxLength(50);
            });

            modelBuilder.Entity<Satislar>(entity =>
            {
                entity.ToTable("Satislar");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
