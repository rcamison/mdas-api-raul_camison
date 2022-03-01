
using Microsoft.Extensions.DependencyInjection;
using Shared.Events.Domain;

namespace Shared.Events.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddEventsInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(sp => RabbitHutch.CreateBus("amqp://raulcamison:camisonraul@mdas-api-raul_camison.rabbitmq:5672/raulcamisonhost"));

            return services;
        }
    }
}
