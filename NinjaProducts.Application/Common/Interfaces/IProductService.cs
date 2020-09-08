using NinjaProducts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaProducts.Application.Common.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(Guid Id);
        Guid CreateProduct(Product product);
    }
}
