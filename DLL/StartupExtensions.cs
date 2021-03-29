using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DataStartupExtensions
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(
                      options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
                      ServiceLifetime.Scoped,
                      ServiceLifetime.Scoped);
        }

        public static void UseData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var dbContext = scope.ServiceProvider.GetService<Context>();
            dbContext.Database.EnsureCreated();
        }
    }
}
