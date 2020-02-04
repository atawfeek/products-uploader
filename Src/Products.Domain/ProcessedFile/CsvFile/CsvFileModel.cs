using Microsoft.AspNetCore.Http;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Domain.ProcessedFile.Interfaces.DomainService;
using Products.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Products.Domain.ProcessedFile.CsvFile
{
    public class CsvFileModel : FileModelBase, IAggregateRoot, IContent
    {
        private readonly IFileDomainService _fileDomainService;

        public CsvFileModel(IFormFile file, string name, IFileDomainService fileDomainService, int? id = null)
           : base(file, name, fileDomainService, id)
        {
            ExtractFileMetadata(this);
            Validate();

            _fileDomainService = fileDomainService;
        }

        public async Task<List<ProductDomain>> ExtractContentAsync()
        {
            return await _fileDomainService.ExtractContentAsync(File);
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
