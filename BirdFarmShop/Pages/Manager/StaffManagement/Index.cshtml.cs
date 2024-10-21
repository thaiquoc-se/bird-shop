using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepository;
using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Authorization;
using Services.IServices;

namespace BirdFarmShop.Pages.Manager.StaffManagement
{
    
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<UserDTO> TblUser { get;set; } = default!;
        public UserDTO TblUserDTO { get;set; }
        public string isManager = null!;
        public int UserId;
        public IActionResult OnGet()
        {
            try
            {
                isManager = HttpContext.Session.GetString("isManager")!;
                if (isManager != "MN")
                {
                    return NotFound();
                }
                if (isManager == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
            }
            TblUser = _userService.GetAllUsers().Where(u => u.RoleId.Equals("ST")).ToList();
            UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = _userService.GetUserDTOById(UserId);
            return Page();
        }
    }
}
