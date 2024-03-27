namespace Kemet.ERP.Contracts.HR
{
    public class UserToRoleDto : IDto
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
