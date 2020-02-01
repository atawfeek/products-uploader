using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Dto.Enums
{
    /// <summary>
    /// multiple supported file types to be uploaded to process products content
    /// </summary>
    public enum SupportedFileTypeEnum
    {
        Text = 1,
        Csv = 2,
        Xml = 3,
        
        //.. opened for more supported types in future.
    }
}
