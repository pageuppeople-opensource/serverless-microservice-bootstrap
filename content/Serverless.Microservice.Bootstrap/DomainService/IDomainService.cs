namespace Domain
{
    public interface IDomainService
    {
        Response Process(Request request);
    }
}
