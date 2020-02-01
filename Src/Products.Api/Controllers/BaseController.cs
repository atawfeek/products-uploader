using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        public string baseUrl;
        public IMediator Mediator { get; set; }
        private readonly IHttpContextAccessor _httpContext;

        public BaseController(IMediator mediator,
                                IHttpContextAccessor httpContext)
        {
            Mediator = mediator;
            _httpContext = httpContext;

            baseUrl = GetBaseUrl(httpContext.HttpContext.Request);
        }

        [NonAction]
        public string GetBaseUrl(HttpRequest request)
        {
            // SSL offloading
            var scheme = request.Host.Host.Contains("localhost") ? request.Scheme : "https";
            return $"{scheme}://{request.Host}{request.PathBase}";
        }
    }
}
