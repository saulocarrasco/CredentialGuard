using CredentialGuard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CredentialGuard.Infrastructure.Glue
{
    public static class DataBaseDealer
    {
        public static void Give(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlDataConnectionString = configuration.GetConnectionString("SqlDataConnectionString");

            services.AddDbContext<CredentialGuardDbContext>(options =>
            {
                options.UseSqlServer(sqlDataConnectionString);
            });
        }
    }
}
