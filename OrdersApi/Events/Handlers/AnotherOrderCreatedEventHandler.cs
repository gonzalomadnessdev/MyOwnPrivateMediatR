using MyOwnPrivateMediatR;

namespace OrdersApi.Events.Handlers
{
    public class AnotherOrderCreatedEventHandler : AbstractMessageHandler<OrderCreatedEvent>
    {
        public AnotherOrderCreatedEventHandler(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public override Task Handle(OrderCreatedEvent message)
        {
            Console.WriteLine($"Another order created event handler {message.OrderId}");
            return Task.CompletedTask;
        }
    }
}
