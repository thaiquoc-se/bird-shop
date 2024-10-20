using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblDistrict
    {
        public TblDistrict()
        {
            TblUsers = new HashSet<TblUser>();
            TblWards = new HashSet<TblWard>();
        }

        public string DistrictId { get; set; } = null!;
        public string? DistrictName { get; set; }

        public virtual ICollection<TblUser> TblUsers { get; set; }
        public virtual ICollection<TblWard> TblWards { get; set; }
    }
}
