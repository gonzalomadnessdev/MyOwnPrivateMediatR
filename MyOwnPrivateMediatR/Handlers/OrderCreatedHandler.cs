using MyOwnPrivateMediatR.Events;

namespace MyOwnPrivateMediatR.Handlers
{
    public class OrderCreatedHandler : AbstractEventHandler<OrderCreated>
    {
        private readonly ILogger<OrderCreatedHandler> _logger;
        public OrderCreatedHandler(ILogger<OrderCreatedHandler> logger, IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
            _logger = logger;
        }

        public override Task Handle(OrderCreated domainEvent)
        {
            _logger.LogInformation("An order has been created at {datetime}. ({id})", domainEvent.Date, domainEvent.OrderId);

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IFakeService>();
                service.SendNotification();
            }

            return Task.CompletedTask;
        }
    }
}
