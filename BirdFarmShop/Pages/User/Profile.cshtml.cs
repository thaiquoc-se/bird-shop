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

namespace BirdFarmShop.Pages.User
{
    public class ProfileModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public ProfileModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

      public UserDTO TblUser { get; set; } = default!;
      public int UserID;

        public IActionResult OnGet()
        {
            UserID =(int)HttpContext.Session.GetInt32("UserID")!;
            var tbluser = _userRepository.GetUserDTOById(UserID);
            if (tbluser == null)
            {
                return NotFound();
            }
            else 
            {
                TblUser = tbluser;
            }
            return Page();
        }
    }
}
