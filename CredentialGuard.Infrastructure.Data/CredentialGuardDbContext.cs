using CredentialGuard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CredentialGuard.Infrastructure.Data
{
    public class CredentialGuardDbContext : DbContext
    {
        public CredentialGuardDbContext(DbContextOptions<CredentialGuardDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>().HasData(new PermissionType { Id = 1, Description = "Enfermedad", Active = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            modelBuilder.Entity<PermissionType>().HasData(new PermissionType { Id = 2, Description = "Diligencias", Active = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            modelBuilder.Entity<PermissionType>().HasData(new PermissionType { Id = 3, Description = "Otros", Active = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 1, Name="Naruto", LastName="Uzumaki", Active = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 2, Name = "Sasori", LastName = "Arena Roja", Active = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 2, Name = "Asuma", LastName = "Sarutobi", Active = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionsTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
