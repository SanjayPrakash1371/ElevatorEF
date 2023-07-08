using System.Net;
using DataAccess.DbAccess;
using ElevatorEF.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FunctionApp4
{
    public class Function1
    {
        private readonly ILogger _logger;
       
        

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            
        }

        [Function("Function1")]
        public async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestMessage req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            HttpResponseMessage response;

            using(var db=new AllDbContext())
            {
                var name =await db.Employees.FirstOrDefaultAsync(x => x.Id == 1);
                
                 response=req.CreateResponse(HttpStatusCode.OK);

                



            }

           // var response = req.CreateResponse(HttpStatusCode.OK);
           // response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            return response;


            

            
        }
    }
}
