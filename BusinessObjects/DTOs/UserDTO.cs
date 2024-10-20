using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string RoleId { get; set; } = null!;
        public string? RoleName { get; set; }
        public string? WardName { get; set; }
        public string? DistrictName { get; set; }
        public string? UserName { get; set; }
        public string? image { get; set; }
        public string? Pass { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? UserAddress { get; set; }
        public string Email { get; set; } = null!;
        public bool? UserStatus { get; set; }
    }
}
