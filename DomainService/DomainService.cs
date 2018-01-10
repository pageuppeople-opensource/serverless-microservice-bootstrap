namespace DomainService
{
    public class DomainService: IDomainService
    {
        public Response Process(Request request)
        {
            return new Response
            {
                Message = "It worked!"
            };
        }
    }
}
