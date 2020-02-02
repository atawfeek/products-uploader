using Microsoft.AspNetCore.Http;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Domain.SeedWork;
using System;

namespace Products.Domain.ProcessedFile.CsvFile
{
    public class CsvFileModel : FileModelBase, IFile, IAggregateRoot
    {
        public CsvFileModel(IFormFile file, string name, Guid id)
           : base(file, name, id)
        {
            ExtractFileMetadata(this);
        }

        public override void Validate()
        {
            base.Validate();
        }
    }
}
