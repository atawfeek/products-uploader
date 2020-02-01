using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Dto.Results
{
    public class ApiResult : ResultBase
    {
        public ApiException Exception { get; set; }
        public object Data { get; set; }
    }
}
