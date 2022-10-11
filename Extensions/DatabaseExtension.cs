using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreApplication.Migrations;

namespace StoreApplication.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabase (this IServiceCollection services, string connection)
        {
            services.AddDbContext<AppDbContext> (options => options.UseNpgsql (connection));
        }
    }
}
