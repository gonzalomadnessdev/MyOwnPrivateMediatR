using MyOwnPrivateMediatR.MyOwnPrivateMediatR;

namespace MyOwnPrivateMediatR.Handlers
{
    abstract public class AbstractEventHandler<TDomainEvent> : IDomainEventHandler where TDomainEvent : class, IDomainEvent
    {
        protected readonly IServiceProvider _serviceProvider;

        protected AbstractEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        abstract public Task Handle(TDomainEvent domainEvent);

        public Task Handle(IDomainEvent domainEvent)
        {
            var _domainEvent = domainEvent as TDomainEvent ?? throw new InvalidCastException();
            Handle(_domainEvent);

            return Task.CompletedTask;
        }
    }
}
