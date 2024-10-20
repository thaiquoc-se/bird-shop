using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string? image {  get; set; }

        [Required(ErrorMessage ="Please Input your User Name")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please Input your Password")]
        public string? Pass { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? UserAddress { get; set; }
        public string Email { get; set; } = null!;
        public bool? UserStatus { get; set; }

        public virtual TblDistrict? District { get; set; }
        public virtual TblRole Role { get; set; } = null!;
        public virtual TblWard? Ward { get; set; }
        public virtual ICollection<Bird> Birds { get; set; }
        public virtual ICollection<TblComment> TblComments { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
