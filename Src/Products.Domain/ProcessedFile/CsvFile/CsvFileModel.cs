﻿using Microsoft.AspNetCore.Http;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Domain.SeedWork;
using System;

namespace Products.Domain.ProcessedFile.CsvFile
{
    public class CsvFileModel : FileModelBase, IAggregateRoot, IContent
    {
        public CsvFileModel(IFormFile file, string name, Guid? id = null)
           : base(file, name, id)
        {
            ExtractFileMetadata(this);
            Validate();
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
