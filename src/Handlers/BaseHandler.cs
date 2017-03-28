using Autofac;
using Serverless.Dotnet.Core;

namespace Serverless.Dotnet.Handlers
{
    public class BaseHandler
    {
        protected IContainer Container;

        protected virtual IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CoreAutofacModule());
            return builder.Build();
        }
    }
}