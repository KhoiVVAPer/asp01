using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication2.ViewModels;

namespace WebApplication2.Infrastructure
{
    public class ErrorActionResult : IHttpActionResult
    {
        private HttpResponseMessage _response;

        public ErrorActionResult(HttpRequestMessage request, HttpStatusCode statusCode, ErrorModel errors)
        {
            _response = request.CreateResponse(statusCode, errors);
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_response);
        }

        public HttpResponseMessage GetResponse()
        {
            return _response;
        }
    }
}