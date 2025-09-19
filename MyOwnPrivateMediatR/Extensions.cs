using Microsoft.Extensions.DependencyInjection;

namespace MyOwnPrivateMediatR
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainEventsBus(this IServiceCollection services, Action<DomainEventsBusOptions> options)
        {
            options(DomainEventsBus.Options);

            foreach (var handler in DomainEventsBus.Options.handlerTypes)
            {
                services.AddSingleton(handler);
            }

            services.AddSingleton<DomainEventsBus>();
            return services;
        }
    }

}
