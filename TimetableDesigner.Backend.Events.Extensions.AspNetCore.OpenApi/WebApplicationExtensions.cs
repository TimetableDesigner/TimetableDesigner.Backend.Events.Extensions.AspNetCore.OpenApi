using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TimetableDesigner.Backend.Events.Extensions.AspNetCore.OpenApi;

public static class WebApplicationExtensions
{
    public static void AddEventHandler<T>(this WebApplication app, Func<T, Task> handler) where T : class
    {
        IEventQueueSubscriber subscriber = app.Services.GetService<IEventQueueSubscriber>()!;
        subscriber.Subscribe(handler);
    }
}