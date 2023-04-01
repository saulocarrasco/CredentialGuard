using CredentialGuard.Core.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CredentialGuard.Infrastructure.Glue
{
    public static class FluentValidationConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddFluentValidation(options =>
            {
                // Validate child properties and root collection elements
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;

                // Automatic registration of validators in assembly
                options.RegisterValidatorsFromAssemblyContaining<PermissionValidator>();
            });
        }
    }
}
