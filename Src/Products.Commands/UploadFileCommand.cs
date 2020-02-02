using MediatR;
using Microsoft.AspNetCore.Http;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.CsvFile;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Domain.ProcessedFile.TextFile;
using Products.Domain.SeedWork;
using Products.Dto.Dtos;
using Products.Dto.Enums;
using Products.Dto.Extensions;
using Products.Dto.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Commands
{
    public class UploadFileCommand
    {
        /// <summary>
        /// command POCO received from client side.
        /// </summary>
        public class Command : IRequest<ApiResult>
        {
            public InputFileDto InputFile { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }
            public ProcessedFileInfoDto ProcessedFileInfo { get; set; }
        }

        /// <summary>
        /// Handler implementation which is executed by MeddatR
        /// </summary>
        public class Handler : IRequestHandler<Command, ApiResult>
        {
            public async Task<ApiResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = new ApiResult();

                try
                {
                    //Instantiate new domain model
                    var fileDomainModel = InstantiateMembersModel(request.InputFile.File);

                    

                    //....
                    //await _uploadFileService ...

                    result.Data = new Response
                    {
                        Success = true,
                        //ProcessedFileInfo = "returned object from service";
                    };
                }
                catch (Exception ex)
                {
                    result = new ApiResult
                    {
                        Exception = new ApiException
                        {
                            Method = nameof(UploadFileCommand),
                            Error = $"Upload File to process products. {ex.Message}"
                        }
                    };
                }

                return result;
            }

            private FileModelBase InstantiateMembersModel(IFormFile file)
            {
                //get extension
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                //instantiate proper model
                SupportedFileTypeEnum csv = SupportedFileTypeEnum.Csv;
                if (extension == EnumExtension.FileTypeExtensionString(SupportedFileTypeEnum.Csv))
                    return new CsvFileModel(file, file.FileName);
                if (extension == EnumExtension.FileTypeExtensionString(SupportedFileTypeEnum.Txt))
                    return new TxtFileModel(file, file.FileName);

                //Open for extensions!  SOLID

                //one more condition handling for XmlFileModel

                throw new BusinessRuleValidationException("unsupported file extension.");
            }
        }
    }
}
