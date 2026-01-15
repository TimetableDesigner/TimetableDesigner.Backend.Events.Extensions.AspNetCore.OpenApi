using Microsoft.Extensions.DependencyInjection;

namespace TimetableDesigner.Backend.Events.Extensions.AspNetCore.OpenApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEventQueue<T>(this IServiceCollection services, Action<T> configuration) where T : EventQueue, new()
    {
        T builder = new T();
        configuration(builder);
        builder.Setup(services);
        return services;
    }
}