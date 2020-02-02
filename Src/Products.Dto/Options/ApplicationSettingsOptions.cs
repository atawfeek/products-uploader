using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Dto.Options
{
    public class ApplicationSettingsOptions
    {
        public long FileSizeLimit { get; set; }
        public string StoredFilesPath { get; set; }
        public string SqlConnectionString { get; set; }
    }
}
