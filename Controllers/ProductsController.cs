using MediatR;
using MediatRConfiguration.Data;
using MediatRConfiguration.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRConfiguration.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly FakeDataStore _fakeDataStore;
        public ProductsController(IMediator mediator, FakeDataStore fakeDataStore)
        {
            this._fakeDataStore = fakeDataStore;
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetProductsQueryCommand());
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetTestProduction()
        {
            var products = await _fakeDataStore.GetAllProduct();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CrateProduct([FromBody] Product product)
        {
            await _mediator.Send(new AddProductCommand(product));
            return StatusCode(200);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById([FromQuery]int id)
        {
            var product = await _mediator.Send(new GetproductByIdCommand(id));
            return Ok(product);
        }
    }
}
