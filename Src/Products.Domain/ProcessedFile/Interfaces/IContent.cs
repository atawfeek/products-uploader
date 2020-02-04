using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.ProcessedFile.Interfaces
{
    public interface IContent
    {
        void SaveContent();
        Task<List<ProductDomain>> ExtractContentAsync();
    }
}
