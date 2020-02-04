using Products.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Interfaces.MultipleImplementation
{
    /// <summary>
    /// The purpose of this interface repository to internally decide which implementation should be instantiated 
    /// and called to get the StorePatchProducts method from it
    /// </summary>
    public interface IProductStorageRepository
    {
        Task StorePatchProducts(List<Product> product, ProductSourceEnum storeType);
    }
}
