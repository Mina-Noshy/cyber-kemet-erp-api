using System.ComponentModel.DataAnnotations;
using Kemet.ERP.Contracts.Common;

namespace Kemet.ERP.Contracts.HR.Identity
{
    public class CreateUserDto : IDto
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
