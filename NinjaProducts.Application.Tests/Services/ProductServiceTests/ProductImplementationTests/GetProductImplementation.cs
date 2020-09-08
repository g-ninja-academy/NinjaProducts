using NinjaProducts.Application.Services;
using NinjaProducts.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaProducts.Application.Tests.Services.ProductServiceTests.ProductImplementationTests
{
    [TestFixture]
    public class GetProductImplementation
    {
        public readonly ProductService _productService;

        public GetProductImplementation()
        {
            _productService = new ProductService();
        }

        [Test]
        public void GetProducts_ReturnProducts_Successfully()
        {
            var result = _productService.GetProducts();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Product>>(result);
            Assert.AreEqual(3, ((List<Product>)result).Count);
        }
    }
}
