using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IMasterService, MasterService>();
        services.AddScoped<IPokemonService, PokemonService>();
        
        services.AddScoped<SqliteDbContext>();
        services.AddScoped<IMasterRepository, MasterRepository>();
        services.AddScoped<IPokemonRepository, PokemonRepository>();
    }
}