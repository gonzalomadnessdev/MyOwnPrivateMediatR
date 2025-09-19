using MyOwnPrivateMediatR;
using OrdersApi.Services;

namespace OrdersApi.Events.Handlers
{
    public class OrderCreatedEventHandler : AbstractMessageHandler<OrderCreatedEvent>
    {
        private readonly ILogger<OrderCreatedEventHandler> _logger;
        public OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger, IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
            _logger = logger;
        }

        public override async Task Handle(OrderCreatedEvent @event)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<INotificationsService>();
                await service.SendNotification(@event.OrderId);
            }
        }
    }
}
