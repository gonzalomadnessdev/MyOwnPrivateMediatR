using MyOwnPrivateMediatR.Events;

namespace MyOwnPrivateMediatR.Handlers
{
    public class OrderCreatedHandler : AbstractEventHandler<OrderCreated>
    {
        private readonly ILogger<OrderCreatedHandler> _logger;
        public OrderCreatedHandler(ILogger<OrderCreatedHandler> logger, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _logger = logger;
        }

        public override Task Handle(OrderCreated domainEvent)
        {
            _logger.LogInformation("An order has been created at {datetime}. ({id})", domainEvent.Date, domainEvent.OrderId);

            return Task.CompletedTask;
        }
    }
}
