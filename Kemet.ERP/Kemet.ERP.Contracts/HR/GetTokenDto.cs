namespace Kemet.ERP.Contracts.HR
{
    public class GetTokenDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
