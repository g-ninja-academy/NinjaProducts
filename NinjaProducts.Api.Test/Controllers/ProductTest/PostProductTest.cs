using Microsoft.AspNetCore.Mvc;
using Moq;
using NinjaProducts.Api.Controllers;
using NinjaProducts.Application.Common.Interfaces;
using NinjaProducts.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaProducts.Api.Tests.Controllers.ProductTest
{
    [TestFixture]
    public class PostProductTest
    {
        private readonly Mock<IProductService> _productService;
        public ProductController productController;

        public PostProductTest()
        {
            _productService = new Mock<IProductService>();
        }

        [Test]
        [TestCase("Keyboard", 88.0)]
        [TestCase("Monitor", 1500.0)]
        public void PostProduct_ReturnId_Successfully(string name, decimal price)
        {
            var newProduct = new Product() { Name = name, Price = price };
            _productService.Setup(x => x.CreateProduct(newProduct)).Returns(Guid.NewGuid());
            productController = new ProductController(_productService.Object);

            var response = productController.Post(newProduct);
            var result = (Guid)((ObjectResult)response).Value;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Guid>(result);
        }

    }
}
