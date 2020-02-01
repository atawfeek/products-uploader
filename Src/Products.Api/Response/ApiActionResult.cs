using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Dto.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Response
{
    public class ApiActionResult : IActionResult
    {
        public ApiResult Result { get; }
        public ApiActionResult(ApiResult result)
        {
            Result = result;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(Result.Exception ?? Result.Data)
            {
                StatusCode = Result.Exception != null
                    ? StatusCodes.Status400BadRequest
                    : StatusCodes.Status200OK
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
