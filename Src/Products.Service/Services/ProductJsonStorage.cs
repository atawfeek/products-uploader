using Products.Service.Interfaces;
using Products.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Services
{
    public class ProductJsonStorage : IProductStorage
    {
        public Task<Product> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProductExist(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StorePatchProducts(IList<Product> product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StoreProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
