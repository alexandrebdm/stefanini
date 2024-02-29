using Microsoft.EntityFrameworkCore;
using Stefanini.Data.Context;

namespace Stefanini.Api.Configuration
{
    public static class SqlDataBaseConfiguration
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StefaniniContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var servicesScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = servicesScope.ServiceProvider.GetService<StefaniniContext>();
            context?.Database.Migrate();
            context?.Database.EnsureCreated();
        }
    }
}
