using MyOwnPrivateMediatR.MyOwnPrivateMediatR;

namespace MyOwnPrivateMediatR.Handlers
{
    abstract public class AbstractEventHandler<TDomainEvent> : IDomainEventHandler where TDomainEvent : class, IDomainEvent
    {
        abstract public void Handle(TDomainEvent domainEvent);

        public void Handle(IDomainEvent domainEvent)
        {
            var _domainEvent = domainEvent as TDomainEvent ?? throw new InvalidCastException();
            Handle(_domainEvent);
        }
    }
}
