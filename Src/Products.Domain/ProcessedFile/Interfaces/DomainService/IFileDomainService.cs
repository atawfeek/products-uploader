using Microsoft.AspNetCore.Http;
using Products.Domain.ProcessedFile.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.ProcessedFile.Interfaces.DomainService
{
    public interface IFileDomainService
    {
        bool IsProcessedFile(FileModelBase model);
        void AddFile(FileModelBase model);
        Task SaveFile(IFormFile File);
        Task<List<ProductDomain>> ExtractContentAsync(IFormFile File);
    }
}
