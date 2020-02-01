using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Dto.Results
{
    public class ResultBase : IResult
    {
        public string Error { get; set; }
        public Exception Trace { get; set; }
        public string Method { get; set; }
    }

    //Marker Interface
    public interface IResult
    {

    }
}
