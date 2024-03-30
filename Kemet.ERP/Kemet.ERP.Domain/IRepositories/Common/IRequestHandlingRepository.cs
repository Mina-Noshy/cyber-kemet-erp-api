namespace Kemet.ERP.Domain.IRepositories.Common
{
    public interface IRequestHandlingRepository
    {
        string GetUserId();
        string GetUserIP();
        string GetDbName();
        string GetLang();
    }
}
