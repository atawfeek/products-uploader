using Products.Service.Data;
using Products.Service.Interfaces;
using Products.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Services
{
    public class ProductDbStorage : IProductStorage
    {
        private readonly ProductsDbContext _dbContext;
        public ProductDbStorage(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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

        public async Task StorePatchProducts(IList<Product> products)
        {
            await _dbContext.Products.AddRangeAsync(products);
        }

        public Task<bool> StoreProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
