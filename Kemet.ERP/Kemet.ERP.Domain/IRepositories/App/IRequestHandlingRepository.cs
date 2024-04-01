namespace Kemet.ERP.Domain.IRepositories.App
{
    public interface IRequestHandlingRepository
    {
        string GetUserId();
        string GetUserIP();
        string GetDbName();
        string GetLang();
    }
}
