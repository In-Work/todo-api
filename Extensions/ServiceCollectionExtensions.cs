// Extensions/ServiceCollectionExtensions.cs
using Web.Services;

namespace Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        // services.AddScoped<IAnotherService, AnotherService>();
        return services;
    }
}