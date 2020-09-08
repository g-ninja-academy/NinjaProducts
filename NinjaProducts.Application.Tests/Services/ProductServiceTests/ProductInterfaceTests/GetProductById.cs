using Moq;
using NinjaProducts.Application.Common.Interfaces;
using NinjaProducts.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaProducts.Application.Tests.Services.ProductServiceTests.ProductInterfaceTests
{
    [TestFixture]
    public class GetProductById
    {
        public readonly Mock<IProductService> _productService;

        public GetProductById()
        {
            _productService = new Mock<IProductService>();
        }

        private List<Product> GetTestProducts()
        {
            return new List<Product>() {
            new Product() { Id = new Guid("6fca31da-78ec-4a75-ba0a-bd73363a16d2"), Name = "Milk", Price = 18 },
            new Product() { Id = new Guid("12b7e8be-fa16-45d7-8615-46c7c8e1ef99"), Name = "Oil", Price = 24 },
            new Product() { Id = new Guid("a1631e86-7db7-4226-82cf-aea174ecfaae"), Name = "Mouse", Price = 81 }
            };
        }

        [Test]
        [TestCase("6fca31da-78ec-4a75-ba0a-bd73363a16d2")]
        [TestCase("12b7e8be-fa16-45d7-8615-46c7c8e1ef99")]
        [TestCase("a1631e86-7db7-4226-82cf-aea174ecfaae")]
        public void GetProductById_ReturnProduct_Successfully(Guid Id)
        {
            _productService.Setup(x => x.GetProductById(Id)).Returns(GetTestProducts().Find(x => x.Id == Id));

            var result = _productService.Object.GetProductById(Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Product>(result);
            Assert.AreEqual(Id, result.Id);
        }

        [Test]
        [TestCase("6fca31da-78ec-4a75-ba0a-bd73363a16d2")]
        [TestCase("12b7e8be-fa16-45d7-8615-46c7c8e1ef99")]
        [TestCase("a1631e86-7db7-4226-82cf-aea174ecfaae")]
        public void GetProductById_ReturnProduct_NotFound(Guid Id)
        {
            _productService.Setup(x => x.GetProductById(Id)).Returns(value: default);

            var result = _productService.Object.GetProductById(Id);

            Assert.IsNull(result);
        }
    }
}
