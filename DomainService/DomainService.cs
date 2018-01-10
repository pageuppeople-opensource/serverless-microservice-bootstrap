using Microsoft.Extensions.Logging;

namespace Domain
{
    public class DomainService: IDomainService
    {
        private readonly ILogger<DomainService> logger;

        public DomainService(ILogger<DomainService> logger)
        {
            this.logger = logger;
        }
        public Response Process(Request request)
        {
            logger.LogTrace("Processing request: {0}", request);
            return new Response
            {
                Message = "It worked!"
            };
        }
    }
}
