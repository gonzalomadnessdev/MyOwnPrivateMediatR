using MyOwnPrivateMediatR;
using OrdersApi.Repository;

namespace OrdersApi.Commands.Handlers
{
    public class CreateOrderCommandHandler : AbstractMessageHandler<CreateOrderCommand>
    {
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(ILogger<CreateOrderCommandHandler> logger, IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
            _logger = logger;
        }

        public override async Task Handle(CreateOrderCommand command)
        {
            using(var scope = _serviceScopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IOrdersRepository>();
                await repository.CreateOrder(command.OrderId);
            }

            _logger.LogInformation("An order has been created at {datetime}. ({id})", command.Date, command.OrderId);
        }
    }
}
