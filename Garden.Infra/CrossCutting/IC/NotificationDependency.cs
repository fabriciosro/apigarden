using Garden.Infra.Shared.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Garden.Infra.CrossCutting.IC
{
    public static class NotificationDependency
    {
        public static void AddNotificationDependency(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }
    }
}
