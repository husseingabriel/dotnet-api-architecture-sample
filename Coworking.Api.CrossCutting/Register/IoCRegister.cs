using Coworking.Api.Application.ApiCaller;
using Coworking.Api.Application.Configuration;
using Coworking.Api.Application.Contracts.ApiCaller;
using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Application.Services;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Coworking.Api.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.CrossCutting.Register
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            AddRegisterOthers(services);
            return services;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IAdminService, AdminService>();
            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {
            services.AddTransient<IAppConfig, AppConfig>();
            services.AddTransient<IApiCaller, ApiCaller>();

            return services;
        }
    }
}
