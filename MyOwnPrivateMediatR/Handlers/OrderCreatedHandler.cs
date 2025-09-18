using MyOwnPrivateMediatR.Events;

namespace MyOwnPrivateMediatR.Handlers
{
    public class OrderCreatedHandler : AbstractEventHandler<OrderCreated>
    {
        private readonly ILogger<OrderCreatedHandler> _logger;

        public OrderCreatedHandler(ILogger<OrderCreatedHandler> logger)
        {
            _logger = logger;
        }

        public override void Handle(OrderCreated domainEvent)
        {
            _logger.LogInformation("An order has been created.");
        }
    }
}
