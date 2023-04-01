using CredentialGuard.Core.Contracts;
using CredentialGuard.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CredentialGuard.Infrastructure.Glue
{
    public static class RepositoryDealer
    {
        public static void Give(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
