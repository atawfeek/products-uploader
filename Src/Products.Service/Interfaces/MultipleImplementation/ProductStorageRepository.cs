using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Products.Service.Models;

namespace Products.Service.Interfaces.MultipleImplementation
{
    /// <summary>
    /// In the implementation of IProductStorageRepository, we use constructor injection and we take Func delegate as a parameter. 
    /// Func delegate expects a string as parameter and IProductStorage as a return value. So in the StorePatchProducts method, 
    /// we use an enum to pass the parameter value which indicates the type of implementation we want to instantiate.
    /// </summary>
    public class ProductStorageRepository : IProductStorageRepository
    {
        private readonly Func<string, IProductStorage> productStorage;
        public ProductStorageRepository(Func<string, IProductStorage> productStorage)
        {
            this.productStorage = productStorage;
        }

        public Task<bool> StorePatchProducts(IList<Product> products, ProductSourceEnum storeType)
        {
            return productStorage(storeType.ToString()).StorePatchProducts(products);
        }
    }
}
