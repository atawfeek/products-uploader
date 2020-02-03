using Products.Domain.ProcessedFile.Interfaces;
using Products.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Interfaces
{
    public interface IProductStorage
    {
        Task<bool> StoreProduct(Product product);
        Task<bool> StorePatchProducts(IList<Product> product);
        Task<bool> ProductExist(int Id);
        Task<Product> Get(int Id);
        Task<List<Product>> GetAll();
    }
}
