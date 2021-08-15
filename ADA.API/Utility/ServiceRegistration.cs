using ADA.API.Authorization;
using ADA.API.DBManager;
using ADA.API.IRepositories;
using ADA.API.IServices;
using ADA.API.Repositories;
using ADA.API.Services;
using Auth.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.API.Utility
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IJwtUtils, JwtUtils>();

            ///repository
            services.AddTransient<IAirCraftRepository, AirCraftRepository>();
            services.AddTransient<IDapper, Dapperr>();
            services.AddTransient<ITokenRepositery, TokenRepositery>();
            services.AddTransient<IPilotRepositery, PilotRepositery>();
            services.AddTransient<IStaffRepositery, StaffRepositery>();



            ////services
            services.AddTransient<IAirCraftService, AirCraftService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IPilotService, PilotService>();
            services.AddTransient<IStaffService, StaffService>();

            ///Dependency Ijection
            services.AddTransient<IDIUnit, DUnit>();

            services.AddMemoryCache();
        }
    }
}
