using MyOwnPrivateMediatR;

namespace OrdersApi.Events
{
    public record OrderCreated(Guid OrderId, DateTime Date) : IDomainMessage;
}
