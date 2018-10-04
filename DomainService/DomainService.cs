using Microsoft.Extensions.Logging;

namespace Domain
{
    public class DomainService: IDomainService
    {
        private readonly ILogger<DomainService> _logger;

        public DomainService(ILogger<DomainService> logger)
        {
            _logger = logger;
        }
        public Response Process(Request request)
        {
            _logger.LogInformation("Processing request: {0}", request);
            return new Response
            {
                Message = "It worked!"
            };
        }
    }
}
