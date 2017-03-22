using Autofac;
using Serverless.Dotnet.Core;
using Serverless.Dotnet.Core.Model;
using Xunit;

namespace Tests
{
    public class Tests : TestBase
    {
        [Fact]
        public void Test1()
        {
            IServiceProcess serviceProcess = Container.Resolve<IServiceProcess>();

            var result = serviceProcess.Process(new Request("test1", "test2", "test3"));

            Assert.IsType<Response>(result);
        }
    }
}