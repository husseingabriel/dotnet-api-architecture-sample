using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coworking.Api.Config;
using Coworking.Api.CrossCutting.Register;
using Coworking.Api.DataAccess;
using Coworking.Api.DataAccess.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Coworking.Api
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
            services.AddScoped<ICoworkingDBContext, CoworkingDBContext>();
            services.AddDbContext<CoworkingDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataBaseConnection")));

            IoCRegister.AddRegistration(services);
            SwaggerConfig.AddRegistration(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            SwaggerConfig.AddRegistration(app);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
