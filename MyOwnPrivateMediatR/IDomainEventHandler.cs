namespace MyOwnPrivateMediatR
{
    public interface IDomainEventHandler
    {
        public Task Handle(IDomainEvent domainEvent);
    }
}