using MyOwnPrivateMediatR;

namespace OrdersApi.Commands.Handlers
{
    public class CreateOrderCommandHandler : AbstractMessageHandler<CreateOrderCommand>
    {
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(ILogger<CreateOrderCommandHandler> logger, IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
            _logger = logger;
        }

        public override Task Handle(CreateOrderCommand command)
        {
            _logger.LogInformation("An order has been created at {datetime}. ({id})", command.Date, command.OrderId);

            return Task.CompletedTask;
        }
    }
}
