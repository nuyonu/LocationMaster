using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain;
using LocationMaster_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace LocationMaster_API
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureDatabaseBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["PostgreSql:ConnectionString"];
            var dbPassword = configuration["PostgreSql:DbPassword"];
            var builder = new NpgsqlConnectionStringBuilder(connectionString)
            {
                Password = dbPassword
            };
            services.AddDbContext<LocationMasterContext>(options => options.UseNpgsql(builder.ConnectionString));
        }

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
