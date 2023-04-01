using CredentialGuard.Infrastructure.Glue;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredentialGuard.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DataBaseDealer.Give(services, Configuration);
            RepositoryDealer.Give(services);
            ServiceDealer.Give(services);
            FluentValidationConfigurator.Configure(services);

            services.AddControllers().ConfigureApiBehaviorOptions(options=> {

                options.InvalidModelStateResponseFactory = c =>
                {
                    var errors = c.ModelState.Values.Where(v => v.Errors.Count > 0)
                                    .SelectMany(v => v.Errors).Select(p => p.ErrorMessage);
                    var result = new 
                    {
                        Title = "Error",
                        Errors = errors,
                        TraceId = c.HttpContext.TraceIdentifier
                    };

                    return new BadRequestObjectResult(result);
                };

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CredentialGuard.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CredentialGuard.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
