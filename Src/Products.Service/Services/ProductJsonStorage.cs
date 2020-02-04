using Microsoft.Extensions.Options;
using Products.Dto.Options;
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
        private readonly string _targetPath;
        public ProductJsonStorage(IOptions<ApplicationSettingsOptions> applicationSettingsOptions)
        {
            _targetPath = applicationSettingsOptions.Value.StoredFilesPath;
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

        public Task StorePatchProducts(IList<Product> products)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StoreProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
