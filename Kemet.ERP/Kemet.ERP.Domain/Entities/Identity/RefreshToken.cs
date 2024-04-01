using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Kemet.ERP.Domain.Entities.Identity
{
    [Owned]
    public class RefreshToken
    {
        [Key]
        public long Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsActive => RevokedOn == null && !IsExpired;

    }
}
