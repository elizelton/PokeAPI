using IoC;

namespace API.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        NativeInjectorBootStrapper.RegisterServices(services);
    }
}