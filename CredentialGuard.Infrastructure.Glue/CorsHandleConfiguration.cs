using Microsoft.Extensions.DependencyInjection;

namespace CredentialGuard.Infrastructure.Glue
{
    public static class CorsHandleConfiguration
    {
        public static void Configure(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }
    }
}
