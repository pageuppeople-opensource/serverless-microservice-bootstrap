using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Serverless.Dotnet.Handlers;
using Xunit;

namespace Tests
{
    public class HandlerTests : TestBase
    {
        [Fact]
        public void TestHandler()
        {
            var handler = new Handler(Container);

            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext();
            var response = handler.HealthCheck(request, context);

            Assert.Equal(200, response.StatusCode);
            Assert.Equal("OK", response.Body);
        }
    }
}