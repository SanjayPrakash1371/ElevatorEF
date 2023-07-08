using System.Net;
using DataAccess.DbAccess;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EFunction
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly AllDbContext context;

        public Function1(ILoggerFactory loggerFactory,AllDbContext context)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            this.context = context;


        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
