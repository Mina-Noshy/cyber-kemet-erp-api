namespace Kemet.ERP.Domain.IRepositories.App
{
    public interface IAppRepositoryManager
    {
        IRequestHandlingRepository RequestHandlingRepository { get; }
    }
}
