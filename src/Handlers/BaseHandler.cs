using Autofac;
using Serverless.Dotnet.Core;

namespace Serverless.Dotnet.Handlers
{
    public class BaseHandler
    {
        protected IContainer Container;

        public BaseHandler()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CoreAutofacModule());
            Container = builder.Build();
        }
    }
}