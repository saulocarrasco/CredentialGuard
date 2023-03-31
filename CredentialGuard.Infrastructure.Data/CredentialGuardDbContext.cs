using CredentialGuard.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CredentialGuard.Infrastructure.Data
{
    public class CredentialGuardDbContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionsTypes { get; set; }
    }
}
