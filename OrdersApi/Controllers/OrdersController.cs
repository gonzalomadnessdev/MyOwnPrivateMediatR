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

            //emit command for main action
            await _domainMessageBus.EmitSync(new CreateOrderCommand(orderId, DateTime.Now));

            //raise event for side effects
            _domainMessageBus.Emit(new OrderCreatedEvent(orderId, DateTime.Now));

            return Ok();
        }
    }

}
