using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Configurations;

public static class DatabaseConfiguration
{
    public static void AddSqliteConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SqliteDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SqliteConnection")),
            ServiceLifetime.Scoped
            );
    }
}