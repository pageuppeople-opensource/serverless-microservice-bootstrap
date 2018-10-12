using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Handlers
{
    public class Handler
    {
        public Response Hello(Request request, ILambdaContext context)
        {
            var serviceProcess = ServiceCollectionHelper.ConfigureServiceCollection(context).GetService<IDomainService>();
            return serviceProcess.Process(request);
        }

        public APIGatewayProxyResponse HealthCheck(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var logger = ServiceCollectionHelper.ConfigureServiceCollection(context).GetService<ILogger<Handler>>();

            logger.LogInformation("Function name is {0}", context.FunctionName);
            logger.LogCritical("Http method is {0}", request.HttpMethod);

            return new APIGatewayProxyResponse()
            {
                StatusCode = 200,
                Headers = new Dictionary<string, string>() { {"Context-Type", "text/html"} },
                Body = "OK"
            };
        }
    }
}
