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
    public class GetProductsTest
    {
        private Mock<IProductService> _productService;
        public ProductController productController;

        [SetUp]
        public void Setup()
        {
            _productService = new Mock<IProductService>();
        }

        private List<Product> GetProducts() => new List<Product>() {
            new Product() { Id = new Guid("6fca31da-78ec-4a75-ba0a-bd73363a16d2"), Name = "Milk", Price = 18 },
            new Product() { Id = new Guid("12b7e8be-fa16-45d7-8615-46c7c8e1ef99"), Name = "Oil", Price = 24 },
            new Product() { Id = new Guid("a1631e86-7db7-4226-82cf-aea174ecfaae"), Name = "Mouse", Price = 81 }
        };

        [Test]
        public void GetProducts_ReturnProductsList_Successfully()
        {
            _productService.Setup(x => x.GetProducts()).Returns(GetProducts());
            productController = new ProductController(_productService.Object);

            var result = ((ObjectResult)productController.Get()).Value;

            Assert.IsNotNull(result);
        }
    }
}
