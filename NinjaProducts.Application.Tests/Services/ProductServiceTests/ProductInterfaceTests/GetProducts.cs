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
    public class GetProducts
    {
        public readonly Mock<IProductService> _productService;

        public GetProducts()
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
        public void GetProducts_ReturnProductList_Successfully()
        {
            _productService.Setup(x => x.GetProducts()).Returns(GetTestProducts());

            var result = _productService.Object.GetProducts();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Product>>(result);
            Assert.AreEqual(3, ((List<Product>)result).Count);
        }

    }
}
