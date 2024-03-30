namespace Kemet.ERP.Abstraction.Common
{
    public interface IRequestHandlingService
    {
        string GetUserId();
        string GetUserIP();
        string GetDbName();
        string GetLang();
    }
}
