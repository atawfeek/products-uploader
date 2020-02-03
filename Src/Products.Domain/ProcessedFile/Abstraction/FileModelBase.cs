using Microsoft.AspNetCore.Http;
using Products.Domain.Base;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Domain.ProcessedFile.Interfaces.DomainService;
using Products.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.ProcessedFile.Abstraction
{
    public abstract class FileModelBase : DomainBase, IFile, IValidate, IPersist
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

        private readonly long _fileSizeLimit;

        private readonly IFileDomainService _fileDomainService;

        public FileModelBase(IFormFile file, string name, IFileDomainService fileDomainService, int? id = null)
            : base(name, id)
        {
            File = file;

            _fileSizeLimit = 2097152; //[to do] get from configurations

            _fileDomainService = fileDomainService;
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

            if (IsProcessedAlready())
                throw new BusinessRuleValidationException("File is already processed and persisted in database.");
        }

        public virtual bool IsPermittedExtension(string uploadedFileName)
        {
            var ext = Path.GetExtension(uploadedFileName).ToLowerInvariant();

            return (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext)) ? false : true;
        }

        public void ExtractFileMetadata(FileModelBase fileModelBase)
        {
            fileModelBase.FileName = fileModelBase.File.FileName;
            fileModelBase.Size = fileModelBase.File.Length;
            Extension = Path.GetExtension(fileModelBase.File.FileName).ToLowerInvariant();
        }

        public virtual bool IsNotEmptyContent(IFormFile file)
        {
            return file.Length > 0 ? true : false;
        }

        public virtual bool IsNotExceedingSizeLimit(long fileSize)
        {
            return fileSize < _fileSizeLimit ? true : false;
        }

        public virtual bool IsProcessedAlready()
        {
            return _fileDomainService.IsProcessedFile(this);
        }

        public async Task SaveFilePhysically()
        {
            await _fileDomainService.SaveFile(File);
        }

        public void InsertFileRecord()
        {
            /* Track processed files in database */

            _fileDomainService.AddFile(this);
        }
    }
}
