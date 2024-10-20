using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public string RoleId { get; set; } = null!;
        public string? RoleName { get; set; }

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
