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
    public class CreateProduct
    {
        public readonly Mock<IProductService> _productService;

        public CreateProduct()
        {
            _productService = new Mock<IProductService>();
        }

        private Product NewProduct()
        {
            return new Product() { Id = new Guid("6fca31da-78ec-4a75-ba0a-bd73363a16d2"), Name = "Milk", Price = 18 };
        }

        [Test]
        public void CreateProduct_ReturnNewProductGuid_Successfully()
        {
            _productService.Setup(x => x.CreateProduct(NewProduct())).Returns(NewProduct().Id);

            var result = _productService.Object.CreateProduct(NewProduct());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Guid>(result);
        }
    }
}
