using Products.Domain.ProcessedFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Interfaces
{
    public interface IProductService
    {
        Task<bool> SaveFile(IFile file);
        Task<List<string>> ExtractFileContent(IFile file);
    }
}
