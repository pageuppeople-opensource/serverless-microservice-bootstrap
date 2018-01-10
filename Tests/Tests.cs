using DomainService;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            var service = new DomainService.DomainService();

            var result = service.Process(new Request());

            Assert.IsType<Response>(result);
        }
    }
}
