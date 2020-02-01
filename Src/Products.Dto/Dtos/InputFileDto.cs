using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Dto.Dtos
{
    /// <summary>
    /// uploaded file dto props parsed from client side.
    /// </summary>
    public class InputFileDto
    {
        public IFormFile File { get; set; }
    }
}
