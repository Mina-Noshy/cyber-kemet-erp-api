namespace Kemet.ERP.Contracts.HR
{
    public class CreateUserDto : IDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
