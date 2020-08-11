using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Coworking.Api.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basePath, "Coworking.Api.xml");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Coworking API V1", Version = "v1" });
                c.IncludeXmlComments(xmlPath);

            });

            return services;
        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coworking API V1"));

            return app;
        }
    }
}
