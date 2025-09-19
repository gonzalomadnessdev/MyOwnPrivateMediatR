using Microsoft.Extensions.DependencyInjection;

namespace MyOwnPrivateMediatR
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainMessageBus(this IServiceCollection services, Action<DomainMessageBusOptions> options)
        {
            options(DomainMessageBus.Options);

            foreach (var handler in DomainMessageBus.Options.HandlerTypes)
            {
                services.AddSingleton(handler);
            }

            services.AddSingleton<IDomainMessageBus, DomainMessageBus>();
            return services;
        }
    }

}
