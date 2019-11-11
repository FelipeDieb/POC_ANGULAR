using System;
using Microsoft.EntityFrameworkCore;
using PocAPI.Model;

namespace PocAPI.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departament> Departament { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departament>(entity =>
            {
                entity.ToTable("departament");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.Name).HasColumnType("longtext");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.DepartamentId)
                    .HasName("IX_Employee_DepartamentId");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.DepartamentId).HasColumnType("bigint(20)");

                entity.Property(e => e.Name).HasColumnType("longtext");

                entity.Property(e => e.Salary).HasColumnType("decimal(65,30)");

                entity.Property(e => e.StartMonth).HasColumnType("int(11)");

                entity.HasOne(d => d.Departament)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartamentId)
                    .HasConstraintName("FK_Employee_Departament_DepartamentId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
