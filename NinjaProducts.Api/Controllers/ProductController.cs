using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NinjaProducts.Application.Common.Interfaces;
using NinjaProducts.Domain.Entities;

namespace NinjaProducts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;        
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _productService.GetProductById(id);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            return Ok(_productService.CreateProduct(value));
        }
    }
}
