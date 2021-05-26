using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductKata.Domain.Models;
using ProductKata.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductKata.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPrice>> Get(int id)
        {
            ProductPrice result = await productService.GetById(id);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet("{id}/{login}")]
        public async Task<ActionResult<ProductPrice>> Get(int id, string login)
        {
            ProductPrice result = await productService.GetById(id, login);
            return result != null ? Ok(result) : BadRequest();
        }
    }
}
