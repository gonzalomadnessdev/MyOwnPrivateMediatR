using Microsoft.Extensions.DependencyInjection;
using MyOwnPrivateMediatR.MyOwnPrivateMediatR;

namespace MyOwnPrivateMediatR.Handlers
{
    abstract public class AbstractEventHandler<TDomainEvent> : IDomainEventHandler where TDomainEvent : class, IDomainEvent
    {
        protected readonly IServiceScopeFactory _serviceScopeFactory;

        protected AbstractEventHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        abstract public Task Handle(TDomainEvent domainEvent);

        public async Task Handle(IDomainEvent domainEvent)
        {
            var _domainEvent = domainEvent as TDomainEvent ?? throw new InvalidCastException();
            await Handle(_domainEvent);
        }
    }
}
