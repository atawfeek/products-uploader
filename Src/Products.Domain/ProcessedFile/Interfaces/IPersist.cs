using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.ProcessedFile.Interfaces
{
    public interface IPersist
    {
        Task SaveFilePhysically();
    }
}
