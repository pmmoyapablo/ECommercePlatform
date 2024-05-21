using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Api.ProductCatalog.Aplication;

namespace ECommerce.Api.ProductCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Execute data) {

            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts() {
            return await _mediator.Send(new Query.Execute());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductUnique(Guid id) {
            return await _mediator.Send(new QueryFilter.ProductUnique { ProductId = id });
        }

    }
}