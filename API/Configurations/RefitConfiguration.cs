using Application.Interfaces.Services;
using Refit;

namespace API.Configurations;

public static class RefitConfiguration
{
    public static void AddRefitConfiguration(this IServiceCollection services)
    {
        services.AddRefitClient<IExternalPokemonService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://pokeapi.co/api/v2"));
    }
}