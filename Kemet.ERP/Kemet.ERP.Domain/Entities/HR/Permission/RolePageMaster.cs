using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kemet.ERP.Domain.Entities.HR.Permission
{
    public class RolePageMaster : TEntity
    {
        public string RoleId { get; set; }
        public long PageId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual IdentityRole GetRole { get; set; }

        [ForeignKey(nameof(PageId))]
        public virtual PageMaster GetPage { get; set; }
    }
}
