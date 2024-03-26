namespace Kemet.ERP.Abstraction.IShared
{
    public interface IRequestHandlingService
    {
        string GetUserId();
        string GetUserIP();
        string GetDbName();
        string GetLang();
    }
}
