using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Handlers;
using Xunit;

namespace Tests
{
    public class HandlerTests
    {
        [Fact]
        public void TestHandler()
        {
            var handler = new Handler();

            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext();

            var response = handler.HealthCheck(request, context);

            Assert.Equal(200, response.StatusCode);
            Assert.Equal("OK", response.Body);
        }
    }
}
