using Microsoft.AspNetCore.Http;
using Products.Domain.Base;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Products.Domain.ProcessedFile.Abstraction
{
    public abstract class FileModelBase : DomainBase, IValidate, IPersist
    {
        public bool IsOnHold { get; set; }
        public DateTime ProcessedDate { get; private set; }    // internal accessibility only - data encapsulation
        public IFormFile File { get; private set; }
        public string Extension { get; private set; }
        public long Size { get; private set; }
        public string FileName { get; private set; }

        /// <summary>
        /// [to do]  get list of permitted extensions from configuration file
        /// </summary>
        private string[] permittedExtensions = { ".txt", ".csv" };

        public FileModelBase(IFormFile file, string name, Guid? id = null)
            : base(name, id)
        {
            File = file;
        }

        //force file validation to be implemented for any introduced file type like csv, txt, or xml.
        public virtual void Validate()
        {
            if (this.File == null)
                throw new BusinessRuleValidationException("Invalid File.");

            if (!IsPermittedExtension(this.FileName))
                throw new BusinessRuleValidationException("Not allowed file extension to be processed.");

            if (!IsNotEmptyContent(this.File))
                throw new BusinessRuleValidationException("Cannot process empty file.");

            if (!IsNotExceedingSizeLimit(this.Size))
                throw new BusinessRuleValidationException("File size exceeds the max limit.");

            if (!IsProcessedAlready(this.FileName))
                throw new BusinessRuleValidationException("File is already processed and persisted in database.");
        }

        public virtual bool IsPermittedExtension(string uploadedFileName)
        {
            throw new NotImplementedException();
        }

        public void ExtractFileMetadata(FileModelBase fileModelBase)
        {
            fileModelBase.FileName = fileModelBase.File.FileName;
            fileModelBase.Size = fileModelBase.File.Length;
            Extension = Path.GetExtension(fileModelBase.File.FileName).ToLowerInvariant();
        }

        public virtual bool IsNotEmptyContent(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsNotExceedingSizeLimit(long fileSize)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsProcessedAlready(string uploadedFileName)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
