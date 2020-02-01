using MediatR;
using Products.Dto.Dtos;
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
                    //Orchestrate to service
                    var filePath = Path.GetTempFileName();  // Full path to file in temp location
                    if (request.InputFile.File.Length > 0)
                        using (var stream = new FileStream(filePath, FileMode.Create))
                            await request.InputFile.File.CopyToAsync(stream);

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
        }
    }
}
