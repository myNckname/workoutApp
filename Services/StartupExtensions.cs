using AutoMapper;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class StartupExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkoutsService, WorkoutsService>();
            services.AddScoped<IDietsService, DietsService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IUsersService, UsersService>();

        }
        public static void AddMapper(this IServiceCollection services)
        {

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
