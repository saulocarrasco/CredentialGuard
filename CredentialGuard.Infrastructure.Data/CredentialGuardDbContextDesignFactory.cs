using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace CredentialGuard.Infrastructure.Data
{
    public class CredentialGuardDbContextDesignFactory : IDesignTimeDbContextFactory<CredentialGuardDbContext>
    {
        public CredentialGuardDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                   
            var builder = new DbContextOptionsBuilder<CredentialGuardDbContext>();

            
            var connectionString = configuration.GetConnectionString("SqlDataConnectionString");
            builder.UseSqlServer(connectionString);
            
            return new CredentialGuardDbContext(builder.Options);
        }
    }
}
