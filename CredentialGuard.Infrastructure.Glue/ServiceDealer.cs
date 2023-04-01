using CredentialGuard.Core.Contracts;
using CredentialGuard.Core.Entities;
using CredentialGuard.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CredentialGuard.Infrastructure.Glue
{
    public static class ServiceDealer
    {
        public static void Give(this IServiceCollection services)
        {
            services.AddTransient(typeof(IService<Permission>), typeof(PermissionsService));
            services.AddTransient(typeof(IService<PermissionType>), typeof(PermissionsTypesService));
            services.AddTransient(typeof(IService<Employee>), typeof(EmployeeService));
        }
    }
}
