using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Autofac;
using Serverless.Dotnet.Core;
using Serverless.Dotnet.Core.Model;

namespace Serverless.Dotnet.Handlers
{
    public class Handler : BaseHandler
    {
        public Handler()
        {
            Container = BuildContainer();
        }

        public Handler(IContainer container)
        {
            Container = container;
        }

        public Response Hello(Request request)
        {
            var serviceProcess = Container.Resolve<IServiceProcess>();
            return serviceProcess.Process(request);
        }

        public APIGatewayProxyResponse HealthCheck(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var logger = context.Logger;
            logger.LogLine(context.FunctionName);
            logger.LogLine(request.HttpMethod);

            return new APIGatewayProxyResponse()
            {
                StatusCode = 200,
                Headers = new Dictionary<string, string>() { {"Context-Type", "text/html"} },
                Body = "OK"
            };
        }
    }
}