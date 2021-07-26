using System.Collections.Generic;
using System.Net;
using Penalty.Application.Common.Responses.Models;

namespace Penalty.Application.Common.Responses
{
    public class OutputResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Model { get; set; }
        public List<ErrorModel> Errors { get; set; }
    }
}
