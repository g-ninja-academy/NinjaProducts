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
            Id = new Guid("6fca31da-78ec-4a75-ba0a-bd73363a16d2"), Name = "Milk", Price = 18
        };

        [Test]
        [TestCase("6fca31da-78ec-4a75-ba0a-bd73363a16d2")]
        public void GetProducts_ReturnProductsList_Successfully(Guid Id)
        {
            _productService.Setup(x => x.GetProductById(Id)).Returns(GetProduct());
            productController = new ProductController(_productService.Object);

            var response = ((ObjectResult)productController.Get(Id)).Value;
            var result = (Product)response;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Product>(result);
            Assert.AreEqual(Id, result.Id);
        }
    }
}
