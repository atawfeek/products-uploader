using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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
    }
}