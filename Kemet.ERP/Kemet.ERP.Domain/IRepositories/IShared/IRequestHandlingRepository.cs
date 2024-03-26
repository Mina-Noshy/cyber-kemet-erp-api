namespace Kemet.ERP.Domain.IRepositories.IShared
{
    public interface IRequestHandlingRepository
    {
        string GetUserId();
        string GetUserIP();
        string GetDbName();
        string GetLang();
    }
}
