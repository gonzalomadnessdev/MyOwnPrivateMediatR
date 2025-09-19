using Microsoft.AspNetCore.Mvc;
using OrdersApi.Events;
using MyOwnPrivateMediatR;

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
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var orderId = Guid.NewGuid();
            if (request.sync)
            {
                await _domainMessageBus.EmitSync(new OrderCreated(orderId, DateTime.Now));
            }
            else
            {
                _domainMessageBus.Emit(new OrderCreated(orderId, DateTime.Now));
            }

            Console.WriteLine("Return Ok");
            return Ok();
        }

        public class CreateOrderRequest
        {
            public bool sync { get; set; }
        }
    }

}
