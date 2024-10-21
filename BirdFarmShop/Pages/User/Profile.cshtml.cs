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
using Services.IServices;

namespace BirdFarmShop.Pages.User
{
    public class ProfileModel : PageModel
    {
        private readonly IUserService _userService;
        public ProfileModel(IUserService userService)
        {
            _userService = userService;
        }

      public UserDTO TblUser { get; set; } = default!;
      public int UserID;

        public IActionResult OnGet()
        {
            try
            {
                UserID = (int)HttpContext.Session.GetInt32("UserID")!;
            }
            catch
            {
                return RedirectToPage("/Login");
            }
            var tbluser = _userService.GetUserDTOById(UserID);
            if (tbluser == null)
            {
                return RedirectToPage("Login");
            }
            else 
            {
                TblUser = tbluser;
            }
            return Page();
        }
    }
}
