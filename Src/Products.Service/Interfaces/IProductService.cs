using Products.Domain;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Service.Interfaces.MultipleImplementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Interfaces
{
    public interface IProductService
    {
        Task<bool> SaveFile(IFile file);
        Task<List<ProductDomain>> ExtractFileContent(IFile file);
        Task StoreProductsAsync(List<ProductDomain> products, ProductSourceEnum storageType);
    }
}
