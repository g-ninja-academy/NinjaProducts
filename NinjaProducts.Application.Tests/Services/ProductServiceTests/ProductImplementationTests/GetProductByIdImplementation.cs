using NinjaProducts.Application.Services;
using NinjaProducts.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaProducts.Application.Tests.Services.ProductServiceTests.ProductImplementationTests
{
    [TestFixture]
    public class GetProductByIdImplementation
    {
        public readonly ProductService _productService;

        public GetProductByIdImplementation()
        {
            _productService = new ProductService();
        }

        [Test]
        [TestCase("6fca31da-78ec-4a75-ba0a-bd73363a16d2")]
        [TestCase("12b7e8be-fa16-45d7-8615-46c7c8e1ef99")]
        [TestCase("a1631e86-7db7-4226-82cf-aea174ecfaae")]
        public void GetProductById_ReturnProduct_Successfully(Guid Id)
        {
            var result = _productService.GetProductById(Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Product>(result);
            Assert.AreEqual(Id, result.Id);
        }
    }
}
