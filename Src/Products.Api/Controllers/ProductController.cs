using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Products.Api.Response;
using Products.Dto.Dtos;
using Products.Dto.Results;

namespace Products.Api.Controllers
{
    [Route("api/products")]
    [Produces("application/json")]
    public class ProductController : BaseController
    {
        IConfiguration _configurations;

        public ProductController(IMediator mediator
                                        , IConfiguration configurations
                                        , IHttpContextAccessor httpContext)
            : base(mediator, httpContext)
        {
            Mediator = mediator;
            _configurations = configurations;
        }

        [HttpPost]
        [Route("UploadSingleFile")]
        [ProducesResponseType(typeof(ProcessedFileInfoDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromForm] InputFileDto inputFile, [FromServices] IHostingEnvironment env)
        {
            try
            {
                // Full path to file in temp location
                var filePath = Path.GetTempFileName();

                if (inputFile.File.Length > 0)
                    using (var stream = new FileStream(filePath, FileMode.Create))
                        await inputFile.File.CopyToAsync(stream);

                // Process uploaded file

                return Ok(new { count = 1, path = filePath });
            }
            catch (Exception ex)
            {
                return new ApiActionResult(new ApiResult() { Exception = new ApiException() { Error = ex.Message } });
            }
        }
    }
}