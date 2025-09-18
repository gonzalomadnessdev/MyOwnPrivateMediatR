namespace MyOwnPrivateMediatR.MyOwnPrivateMediatR
{
    public interface IDomainEventHandler
    {
        public void Handle(IDomainEvent domainEvent);
    }
}