using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.ProcessedFile.Interfaces
{
    public interface IValidate
    {
        bool IsPermittedExtension(string uploadedFileName);
        bool IsNotEmptyContent(IFormFile file);
        bool IsNotExceedingSizeLimit(long fileSize);
        bool IsProcessedAlready();
    }
}
