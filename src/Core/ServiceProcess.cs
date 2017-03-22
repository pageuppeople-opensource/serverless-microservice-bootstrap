using Serverless.Dotnet.Core.Model;

namespace Serverless.Dotnet.Core
{
    public interface IServiceProcess
    {
        Response Process(Request request);
    }

    public class ServiceProcess : IServiceProcess
    {
        public Response Process(Request request)
        {
            return new Response("Go Serverless dotnetcore! Your C# function executed successfully!", request);
        }
    }
}