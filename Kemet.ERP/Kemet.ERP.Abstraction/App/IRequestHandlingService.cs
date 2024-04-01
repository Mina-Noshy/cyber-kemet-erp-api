namespace Kemet.ERP.Abstraction.App
{
    public interface IRequestHandlingService
    {
        string GetUserId();
        string GetUserIP();
        string GetDbName();
        string GetLang();
    }
}
