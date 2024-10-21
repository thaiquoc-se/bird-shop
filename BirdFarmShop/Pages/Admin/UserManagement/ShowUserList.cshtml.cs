using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using BusinessObjects.DTOs;
using Repositories.IRepository;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.UserManagement
{
    public class ShowUserListModel : PageModel
    {
        private readonly IUserService _userService;

        public ShowUserListModel(IUserService userService)
        {
            _userService = userService;
        }

        public IList<UserDTO> TblUser { get;set; } = default!;
        public UserDTO TblUserDTO { get; set; }
        public int UserId;
        public string isAdmin = null!;

        public IActionResult OnGet()
        {
            try
            {
                isAdmin = HttpContext.Session.GetString("isAdmin")!;
                if (isAdmin != "AD")
                {
                   return NotFound();
                }
                if(isAdmin == null)
                {
                  return  NotFound();
                }
            }
            catch
            {
                NotFound();
            }
            TblUser = _userService.GetAllUsers().Where(u => !u.RoleId.Equals("AD")).ToList();
            UserId = (int)HttpContext.Session.GetInt32("UserID")!;
            TblUserDTO = _userService.GetUserDTOById(UserId);
            return Page();
        }
    }
}
