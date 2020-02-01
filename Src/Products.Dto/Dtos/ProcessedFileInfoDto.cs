using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Dto.Dtos
{
    /// <summary>
    /// uploaded file dto props parsed from client side.
    /// </summary>
    public class ProcessedFileInfoDto
    {
        public Guid FileUniqueId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ResponseMessage { get; set; }
        public int? ProcessedProductItemsCount { get; set; }
    }
}
