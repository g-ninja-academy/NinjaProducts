using NinjaProducts.Application.Common.Interfaces;
using NinjaProducts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NinjaProducts.Application.Services
{
    public class ProductService : IProductService
    {
        private List<Product> Products = new List<Product>();

        public Guid CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            Products.Add(product);

            return product.Id;
        }

        public Product GetProductById(Guid Id)
        {
            var result = Products.SingleOrDefault(prod => prod.Id.Equals(Id));

            return result;
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }
    }
}
