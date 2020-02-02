using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Domain.ProcessedFile.Interfaces
{
    public interface IFile
    {
        //mimics base class, so I can utilize the base class as exactly that... the base functionality for a file.
        int Id { get; set; }
        string Name { get; set; }

        void InsertFileRecord();
    }
}
