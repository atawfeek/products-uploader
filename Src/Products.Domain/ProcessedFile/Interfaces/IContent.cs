using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Products.Domain.ProcessedFile.Interfaces
{
    public interface IContent
    {
        void SaveContent();
        Stream ExtractContent();
    }
}
