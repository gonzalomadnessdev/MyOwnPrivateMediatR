using Microsoft.AspNetCore.Mvc;
using MyOwnPrivateMediatR.Events;
using MyOwnPrivateMediatR.MyOwnPrivateMediatR;

namespace MyOwnPrivateMediatR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly DomainEventsBus _domainEventsBus;

        public OrdersController(
            DomainEventsBus domainEventsBus
        )
        {
            _domainEventsBus = domainEventsBus;
        }

        [HttpPost("")]
        public IActionResult Create()
        {
            _domainEventsBus.Emit(new OrderCreated());

            return Ok();
        }
    }


}
