using Microsoft.AspNetCore.Http;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Domain.ProcessedFile.Interfaces.DomainService;
using Products.Domain.SeedWork;
using System;
using System.IO;

namespace Products.Domain.ProcessedFile.CsvFile
{
    public class CsvFileModel : FileModelBase, IAggregateRoot, IContent
    {
        private readonly IFileDomainService _fileDomainService;

        public CsvFileModel(IFormFile file, string name, IFileDomainService _fileDomainService, int? id = null)
           : base(file, name, _fileDomainService, id)
        {
            ExtractFileMetadata(this);
            Validate();
        }

        public Stream ExtractContent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// content is extracted according to file type
        /// </summary>
        public void SaveContent()
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            base.Validate();
        }
    }
}
