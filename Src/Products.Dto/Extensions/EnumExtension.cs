using Products.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Dto.Extensions
{
    public static class EnumExtension
    {
        static string _extensionPrefix = ".";

        public static string FileTypeExtensionString(SupportedFileTypeEnum fileTypeEnum)
        {
            return _extensionPrefix + Enum.GetName(typeof(SupportedFileTypeEnum), fileTypeEnum).ToLowerInvariant();
        }
    }
}
