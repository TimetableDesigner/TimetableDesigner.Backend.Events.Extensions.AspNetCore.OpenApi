using Microsoft.Extensions.DependencyInjection;

namespace TimetableDesigner.Backend.Events.Extensions.AspNetCore.OpenApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEventQueue<TQueue, TBuilder>(this IServiceCollection services, Action<TBuilder> configuration) 
        where TQueue : EventQueue<TQueue>, new()
        where TBuilder : EventQueueBuilder<TQueue>, new()
    {
        TBuilder builder = new TBuilder();
        configuration(builder);
        TQueue queue = new TQueue();
        queue.Setup(services, builder);
        return services;
    }

    public static IServiceCollection AddEventQueue<TQueue>(this IServiceCollection services, string connectionString)
        where TQueue : EventQueue<TQueue>, new()
    {
        TQueue queue = new TQueue();
        queue.Setup(services, connectionString);
        return services;
    }
}