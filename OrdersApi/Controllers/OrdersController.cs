using Microsoft.AspNetCore.Mvc;
using OrdersApi.Events;
using MyOwnPrivateMediatR;
using OrdersApi.Commands;

namespace OrdersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IDomainMessageBus _domainMessageBus;

        public OrdersController(
            IDomainMessageBus domainMessageBus
        )
        {
            _domainMessageBus = domainMessageBus;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create()
        {
            var orderId = Guid.NewGuid();
            await _domainMessageBus.EmitSync(new CreateOrderCommand(orderId, DateTime.Now));
            _domainMessageBus.Emit(new OrderCreatedEvent(orderId, DateTime.Now));

            Console.WriteLine("Return Ok");
            return Ok();
        }
    }

}
