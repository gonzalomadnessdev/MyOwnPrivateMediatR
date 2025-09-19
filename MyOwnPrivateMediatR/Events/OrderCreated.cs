using MyOwnPrivateMediatR.MyOwnPrivateMediatR;

namespace MyOwnPrivateMediatR.Events
{
    public record OrderCreated(Guid OrderId, DateTime Date) : IDomainEvent;
}
