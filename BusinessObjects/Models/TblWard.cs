using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblWard
    {
        public TblWard()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public string WardId { get; set; } = null!;
        public string? DistrictId { get; set; }
        public string? WardName { get; set; }

        public virtual TblDistrict? District { get; set; }
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
