using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Api.OrderManagement.Aplication;

namespace ECommerce.Api.OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data) {
            return await _mediator.Send(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetOrder(int id) {
            return await _mediator.Send(new Query.Execute { CarSessionId = id });
        }

        [HttpGet]
        public ActionResult<string> Welcome()
        {
          return Ok("Hello Orders");
        }
    }
}