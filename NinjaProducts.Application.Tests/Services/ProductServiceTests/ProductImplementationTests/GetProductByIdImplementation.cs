using NinjaProducts.Application.Services;
using NinjaProducts.Domain.Entities;
using NUnit.Framework;
using System;

namespace NinjaProducts.Application.Tests.Services.ProductServiceTests.ProductImplementationTests
{
    [TestFixture]
    public class GetProductByIdImplementation
    {
        private readonly ProductService _productService;
        private Guid _productId;

        public GetProductByIdImplementation()
        {
            _productService = new ProductService();
        }

        [SetUp]
        public void SetUp() 
        {
            _productId = _productService.CreateProduct(new Product { Name = "Keyboard", Price = 150.776m });   
        }

        [Test]
        public void GetProductById_ReturnProduct_Successfully()
        {
            var result = _productService.GetProductById(_productId);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Product>(result);
            Assert.AreEqual(_productId, result.Id);
        }
    }
}
