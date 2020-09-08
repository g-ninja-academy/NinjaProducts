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
    public class GetProductByIdTest
    {
        private Mock<IProductService> _productService;
        public ProductController productController;

        [SetUp]
        public void Setup()
        {
            _productService = new Mock<IProductService>();
        }

        private Product GetProduct() => new Product {
            Id = Guid.NewGuid(), Name = "Milk", Price = 18
        };

        [Test]
        public void GetProductById_Successfully()
        {
            _productService.Setup(x => x.GetProductById(It.IsAny<Guid>())).Returns(GetProduct());
            var resProduct = _productService.Object.GetProductById(Guid.NewGuid());

            Assert.IsNotNull(resProduct);
            Assert.IsInstanceOf<Product>(resProduct);
        }
    }
}
