using NinjaProducts.Application.Common.Interfaces;
using NinjaProducts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjaProducts.Application.Services
{
    public class ProductService : IProductService
    {
        private List<Product> Products = new List<Product>() { 
            new Product() { Id = new Guid("6fca31da-78ec-4a75-ba0a-bd73363a16d2"), Name = "Milk", Price = 18 },
            new Product() { Id = new Guid("12b7e8be-fa16-45d7-8615-46c7c8e1ef99"), Name = "Oil", Price = 24 },
            new Product() { Id = new Guid("a1631e86-7db7-4226-82cf-aea174ecfaae"), Name = "Mouse", Price = 81 }
        };

        public Guid CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            Products.Add(product);

            return product.Id;
        }

        public Product GetProductById(Guid Id)
        {
            var result = Products.SingleOrDefault(prod => prod.Id == Id);

            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }
    }
}
