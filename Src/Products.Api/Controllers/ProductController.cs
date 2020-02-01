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
using Products.Commands;
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
        public async Task<IActionResult> Post([FromForm] UploadFileCommand.Command command, [FromServices] IHostingEnvironment env)
        {
            try
            {
                // Process uploaded file in mediatr command handler.
                var result = await Mediator.Send(command);

                return Ok(new { count = 1, path = result.Data });
            }
            catch (Exception ex)
            {
                return new ApiActionResult(new ApiResult() { Exception = new ApiException() { Error = ex.Message } });
            }
        }
    }
}