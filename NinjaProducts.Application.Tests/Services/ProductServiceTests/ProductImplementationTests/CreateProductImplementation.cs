using NinjaProducts.Application.Services;
using NinjaProducts.Domain.Entities;
using NUnit.Framework;
using System;

namespace NinjaProducts.Application.Tests.Services.ProductServiceTests.ProductImplementationTests
{
    [TestFixture]
    public class CreateProductImplementation
    {
        public readonly ProductService _productService;

        public CreateProductImplementation()
        {
            _productService = new ProductService();
        }

        [Test]
        [TestCase("Keyboard", 88.0)]
        [TestCase("Monitor", 1500.0)]
        public void CreateProduct_ReturnId_Successfully(string name, decimal price)
        {
            var newProduct = new Product() { Name = name, Price = price };

            var result = _productService.CreateProduct(newProduct);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Guid>(result);
        }
    }
}
