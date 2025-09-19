using MyOwnPrivateMediatR;

namespace OrdersApi.Commands
{
    public record CreateOrderCommand(Guid OrderId, DateTime Date) : IDomainMessage;
}
