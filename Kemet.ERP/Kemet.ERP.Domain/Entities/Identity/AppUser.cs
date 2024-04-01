using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Kemet.ERP.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual List<RefreshToken>? RefreshTokens { get; set; }
    }
}
