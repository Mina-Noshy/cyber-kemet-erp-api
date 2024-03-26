namespace Kemet.ERP.Contracts.HR
{
    public class UserInfoDto : IDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public List<string>? Roles { get; set; }
    }
}
