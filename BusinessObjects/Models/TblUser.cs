using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            Birds = new HashSet<Bird>();
            TblComments = new HashSet<TblComment>();
            TblOrders = new HashSet<TblOrder>();
        }

        public int UserId { get; set; }
        public string RoleId { get; set; } = null!;
        public string? WardId { get; set; }
        public string? DistrictId { get; set; }
        public string? UserName { get; set; }
        public string? Pass { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? UserAddress { get; set; }
        public string Email { get; set; } = null!;
        public bool? UserStatus { get; set; }
        public string? Image { get; set; }

        public virtual TblDistrict? District { get; set; }
        public virtual TblRole Role { get; set; } = null!;
        public virtual TblWard? Ward { get; set; }
        public virtual ICollection<Bird> Birds { get; set; }
        public virtual ICollection<TblComment> TblComments { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
