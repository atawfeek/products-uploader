using Products.Domain.ProcessedFile.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.ProcessedFile.Interfaces.DomainService
{
    public interface IFileDomainService
    {
        bool IsProcessedFile(FileModelBase model);
        void AddFile(FileModelBase model);
    }
}
