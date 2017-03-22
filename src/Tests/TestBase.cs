using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Serverless.Dotnet.Core;

namespace Tests
{
    public class TestBase
    {
        protected IContainer Container;

        public TestBase()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new CoreAutofacModule());
            Container = builder.Build();
        }
    }
}
