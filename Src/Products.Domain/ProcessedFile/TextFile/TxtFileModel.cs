using Microsoft.AspNetCore.Http;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Domain.ProcessedFile.Interfaces.DomainService;
using Products.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.ProcessedFile.TextFile
{
    public class TxtFileModel : FileModelBase, IAggregateRoot, IContent
    {
        private readonly IFileDomainService _fileDomainService;

        public TxtFileModel(IFormFile file, string name, IFileDomainService fileDomainService, int? id = null)
           : base(file, name, fileDomainService, id)
        {
            ExtractFileMetadata(this);
            Validate();

            _fileDomainService = fileDomainService;
        }

        public async Task<List<ProductDomain>> ExtractContentAsync()
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(File.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }

            return new List<ProductDomain>();   //to do : extract result object as List of ProductDomain
        }

        /// <summary>
        /// extract content based on file type
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
