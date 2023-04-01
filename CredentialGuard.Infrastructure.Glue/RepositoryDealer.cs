using CredentialGuard.Core.Contracts;
using CredentialGuard.Core.Entities;
using CredentialGuard.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CredentialGuard.Infrastructure.Glue
{
    public static class RepositoryDealer
    {
        public static void Give(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<Permission>), typeof(Repository<Permission>));
            services.AddTransient(typeof(IRepository<PermissionType>), typeof(Repository<PermissionType>));
            services.AddTransient(typeof(IRepository<Employee>), typeof(Repository<Employee>));
        }
    }
}
